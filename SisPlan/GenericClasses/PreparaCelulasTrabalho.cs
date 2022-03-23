using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GenericClasses
{
    public class PreparaCelulasTrabalho
    {
        static int baseID = 1000000;
        static DataTable dt = null;
        static DataTable dtPercEXEC = null;
        static DataTable dtPercPROG = null;
        static DataTable dtAtivFosm = null;
        static DataTable dtGrupoCriterio = null;
        static DataTable dtNoGroup = null;
        static int counter, pkCT, countAP = 0;
        //static DTO.CollectionVwAcAtributoPersonalizadoDTO cAP = new DTO.CollectionVwAcAtributoPersonalizadoDTO();
        static DTO.CollectionAcControleProducaoDTO cCT = new DTO.CollectionAcControleProducaoDTO();
        static DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        static string mesCompetencia = "";
        static string anoCompetencia = "";
        static string strSQL = "";
        static string atpeNome = "";
        static string descricaoAtributo = "";

        static string discAUX = "5,4,2,6"; //"2,4,5,6,9,15,20";
        
        static string tituloEmail = "";
        static string destinatariosTO = "";
        static string destinatariosCC = "";
        static string destinatariosBCC = "";
        static string destinatariosLOG = "";
        //static decimal foseIdToValidation = 0;
        static bool bFoseIsValid = true;
        static bool bGruposCriteriosOk = true;
        static string from = "goliath@enseada.com";
        //static DataRow[] descricoes;
        //===================================================================================
        public static void GerarControleProducaoBase(string contrato, decimal semaId)
        {
            try
            {
                //GerarControleProducaoBase(contrato, semaId, null, null, false, null, null); // Sem E-mail automático
                GerarControleProducaoBase(contrato, semaId, null, null, true, null, null);    // Com E-mail automático
            }
            catch (Exception ex) { throw new Exception("GerarControleProducaoBase: " + ex.Message); }
        }
        //===================================================================================
        public static void GerarControleProducaoBase(string contrato, decimal semaId, string dtStart, string dtEnd, bool enviaEmail, Label lblMessage, ProgressBar pb)
        {
            try
            {
                if (contrato == null) contrato = "Conversão";
                pkCT = baseID * Convert.ToInt32(semaId);

                ObtemAtividades(contrato);
                if (lblMessage != null) { lblMessage.Text = "Obtendo Grupos Critérios..."; pb.Value = 10; Application.DoEvents(); } //10
                ObtemGrupoCriterio(contrato);
                if (lblMessage != null) { lblMessage.Text = "Obtendo Dados Semanais..."; pb.Value = 20; Application.DoEvents(); }  //20
                ObtemDadosSemanais(contrato, semaId, ref dtStart, ref dtEnd);
                if (lblMessage != null) { lblMessage.Text = "Aguarde: Extraindo Folhas de Serviços..."; pb.Value = 40; Application.DoEvents(); } // 40
                ExtraiFolhasServico(contrato, dtStart, dtEnd);
                if (lblMessage != null) { lblMessage.Text = "Aguarde: Validando os Grupos de Critério..."; pb.Value = 55; Application.DoEvents(); } // 55
                bGruposCriteriosOk = ValidarGruposCriterio(dtGrupoCriterio, dt, contrato, dtStart, dtEnd);
                if (bGruposCriteriosOk)
                {
                    if (lblMessage != null) { lblMessage.Text = "Aguarde: Processando Folhas de Serviços..."; pb.Value = 60; Application.DoEvents(); } // 60
                    ProcessaFolhasServico(contrato, semaId);
                    if (lblMessage != null) { lblMessage.Text = "Aguarde: Normalizando a nomenclatura de Itens de Controle..."; pb.Value = 80; Application.DoEvents(); } // 80
                    NormalizaNomenclatura(semaId);
                    if (lblMessage != null) { lblMessage.Text = "Aguarde: Validando as Folhas de Serviços..."; pb.Value = 90; Application.DoEvents(); }  // 90
                    ValidaFOSEs(semaId);
                    if (lblMessage != null) { lblMessage.Text = "Enviando e-mails de LOG..."; pb.Value = 95; Application.DoEvents(); }  // 95
                    EmailCriticaProcessamento(semaId);
                    if (lblMessage != null) { lblMessage.Text = "Enviando e-mails de LOG..."; pb.Value = 100; Application.DoEvents(); }  // 100
                }
                else
                {
                    //Mensagem grupos criterios faltando
                    //Envia e-mail Paulo Marcella GRUPO CRITERIO

                    EmailNoGroup(dtNoGroup);
                }
            }
            catch (Exception ex) { throw new Exception("GerarControleProducaoBase: " + ex.Message); }
        }
        //===================================================================================
        private static bool ValidarGruposCriterio(DataTable dtGrupoCriterio, DataTable dt, string contrato, string dtStart, string dtEnd)
        {
            try
            {
                bool bRet = true;
                strSQL = @"SELECT FCME_SIGLA 
                                    FROM (
                                            SELECT DISTINCT FCME_SIGLA
                                              FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC
                                             WHERE FSME_CNTR_CODIGO(+) = FOSE_CNTR_CODIGO AND FSME_FOSM_ID(+) = FOSM_ID 
                                               AND DISC_ID IN (" + discAUX + @") 
                                               AND FOSE_CNTR_CODIGO = '" + contrato + @"' --and fose_numero = 'AUXILIARY WINCH (AFT).M732'
                                               AND FSME_DATA BETWEEN TO_DATE('" + dtStart + @"', 'DD/MM/YY') AND TO_DATE('" + dtEnd + @"', 'DD/MM/YY')
                                          ORDER BY FCME_SIGLA
                                         )
                                    WHERE FCME_SIGLA NOT IN (SELECT FCME_SIGLA FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO_FULL WHERE GRFC_GRCR_ID IS NOT NULL AND GRFC_GRCR_ID > 1)";
                dtNoGroup = BLL.AcControleProducaoBLL.Select(strSQL);
                //counter = dtNoGroup.Rows.Count;
                if (dtNoGroup.Rows.Count > 0) bRet = false;
                return bRet;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - ValidarGruposCriterio " + contrato + " - " + dtStart + " - " + dtEnd); }
        }
        //===================================================================================
        private static void ObtemGrupoCriterio(string contrato)
        {
            try
            {
                strSQL = @"SELECT GRCR_CNTR_CODIGO, FCME_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_GRUPO_SIGLA FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO WHERE GRCR_CNTR_CODIGO = '" + contrato + "'";
                dtGrupoCriterio = BLL.AcControleProducaoBLL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - ObtemGrupoCriterio " + contrato); }
        }
        //===================================================================================
        private static void ObtemDadosSemanais(string contrato, decimal semaId, ref string dtStart, ref string dtEnd)
        {
            try
            {
                DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
                s = BLL.AcSemanaBLL.GetObject("SEMA_CNTR_CODIGO = '" + contrato + "' AND SEMA_ID = " + semaId.ToString());
                mesCompetencia = s.SemaMesCompetencia.Split('/')[0];
                anoCompetencia = s.SemaMesCompetencia.Split('/')[1];
                dtStart = s.SemaDataInicio.ToString("dd/MM/yy");
                dtEnd = s.SemaDataFim.ToString("dd/MM/yy");
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - ObtemDadosSemanais " + contrato); }
        }
        //===================================================================================
        private static void ObtemAtividades(string contrato)
        {
            try
            {
                strSQL = @"SELECT ATVF_FOSM_ID, ATVF_ATIV_ID, ATIV_SIG, ATIV_NOME
                             FROM EEP_CONVERSION.ATIV_VINCULO_FS, EEP_CONVERSION.ATIVIDADE
                            WHERE ATVF_CNTR_CODIGO = '" + contrato + @"'
                              AND ATIV_CNTR_CODIGO = ATVF_CNTR_CODIGO AND ATIV_ID = ATVF_ATIV_ID
                              AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO)
                            ORDER BY ATVF_FOSM_ID DESC
                          ";
                dtAtivFosm = BLL.AcControleProducaoBLL.Select(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - ObtemAtividades " + contrato); }
        }
        //===================================================================================
        private static void ObtemAvancosPROG(string contrato)
        {
            try
            {
                strSQL = @"SELECT FOSE_ID, FOSE_NUMERO, FCME_SIGLA, ROUND(MAX(FSMP_AVANCO_ACM),2) AS AVANCO, MAX(FCES_WBS) AS FCES_WBS FROM 
                           (
                                SELECT FOSE_ID,FOSE_NUMERO, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FSMP_AVANCO_ACM
                                  FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG,       EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,           EEP_CONVERSION.FOLHA_SERVICO,                                                                 EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,         EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                                 WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                   AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                   AND FCME_CNTR_CODIGO = FOSE_CNTR_CODIGO AND FCME_ID = FOSE_FCME_ID
                                   AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                   AND LENGTH(FCES_WBS) > 2 AND FOSE_CNTR_CODIGO = '" + contrato + @"'
                                 ORDER BY FCES_WBS, FCES_SIGLA, FSMP_DATA DESC
                           )
                          GROUP BY FOSE_ID, FOSE_NUMERO, FCME_SIGLA
                          ";
                dtPercPROG = BLL.AcControleProducaoBLL.SelectAvnFoseFromDataReader(strSQL);
             }
            catch (Exception ex) { throw new Exception("ObtemAvancosPROG: " + ex.Message); }
        }
        //===================================================================================
        private static void ObtemAvancosEXEC(string contrato)
        {
            try
            {
                strSQL = @"SELECT FOSE_ID, FOSE_NUMERO, FCME_SIGLA, ROUND(MAX(FSME_AVANCO_ACM),2) AS AVANCO, MAX(FCES_WBS) AS FCES_WBS FROM 
                           (
                                SELECT FOSE_ID,FOSE_NUMERO, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FSME_AVANCO_ACM
                                  FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC,       EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,           EEP_CONVERSION.FOLHA_SERVICO, 
                                       EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,         EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                                 WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                   AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                   AND FCME_CNTR_CODIGO = FOSE_CNTR_CODIGO AND FCME_ID = FOSE_FCME_ID
                                   AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                   AND LENGTH(FCES_WBS) > 2 AND FOSE_CNTR_CODIGO = '" + contrato + @"'
                                 ORDER BY FCES_WBS, FCES_SIGLA, FSME_DATA DESC
                           )
                          GROUP BY FOSE_ID, FOSE_NUMERO, FCME_SIGLA
                          ";
                dtPercEXEC = BLL.AcControleProducaoBLL.SelectAvnFoseFromDataReader(strSQL);
             }
            catch (Exception ex) { throw new Exception("ObtemAvancosEXEC: " + ex.Message); }
        }
        //===================================================================================
        private static void ExtraiFolhasServico(string contrato, string dtStart, string dtEnd)
        {
            try
            {
                //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");
                //Carrega na memória as quantidades necessarias por Material do contrato

// COM BASE EM EXEC
//=================
                strSQL = @"SELECT FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME,      
                                  FOSE_ID, FOSE_NUMERO, FOSE_DESCRICAO, UNME_SIGLA,  SIFS_DESCRICAO,    
                                  FCME_SIGLA, FCES_SIGLA,
                                  FOSE_QTD_PREVISTA, ROUND(FSME_QTD_ACM,3) AS QTD_ACUMULADA, FCES_PESO_REL_CRON,
                                  EEP_CONVERSION.PKG_SISPLAN.FUN_GET_MAXDATA_EXEC_FOSE(FOSE_ID, '" + dtStart + "', '" + dtEnd + @"') AS FSME_DATA,
                                  EEP_CONVERSION.PKG_SISPLAN.FUN_GET_AVANCO_EXEC_FOSE(FOSE_ID, '" + dtStart + "', '" + dtEnd + @"') AS AVN_REAL_EXEC_PERIODO,
                                  EEP_CONVERSION.PKG_SISPLAN.FUN_GET_MAXDATA_PROG_FOSE(FOSE_ID, '" + dtStart + "', '" + dtEnd + @"') AS FSMP_DATA,
                                  EEP_CONVERSION.PKG_SISPLAN.FUN_GET_AVANCO_PROG_FOSE(FOSE_ID, '" + dtStart + "', '" + dtEnd + @"') AS AVN_REAL_PROG_PERIODO,
                                  AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                             FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC
                            WHERE FSME_CNTR_CODIGO(+) = FOSE_CNTR_CODIGO AND FSME_FOSM_ID(+) = FOSM_ID 
                              AND DISC_ID IN (" + discAUX + @") 
                              AND FOSE_CNTR_CODIGO = '" + contrato + @"' --and fose_numero = 'TANQUE 01BB - BB - TETO - CAVERNA 94'
                              AND FSME_DATA BETWEEN TO_DATE('" + dtStart + @"', 'DD/MM/YY') AND TO_DATE('" + dtEnd + @"', 'DD/MM/YY')
    --AND rownum <= 10
                              ORDER BY DISC_ID DESC, FOSE_NUMERO
                          ";


                //string fose = "1.1/2" + Convert.ToChar(34) + "-BG-B10H-6019_Spool1.F746";
                //strSQL += " AND FOSE_NUMERO = '" + fose + "'";

                //FSME_QTD_AVN_POND => AVN_POND_EXEC_PERIODO
                //FSMP_QTD_AVN_POND => AVN_POND_PROG_PERIODO
                dt = BLL.AcControleProducaoBLL.Select(strSQL);
                counter = dt.Rows.Count;

                //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");
             }
            catch (Exception ex) { throw new Exception(ex.Message + " - ExtraiFolhasServico " + contrato + " - " + dtStart + " - " + dtEnd); }
        }
        //===================================================================================
        private static void ProcessaFolhasServico(string contrato, decimal semaId)
        {
            //Inicializa tabela de saída (AC_CELULA_TRABALHO) - Deleta semana do cálculo corrente
            BLL.AcControleProducaoBLL.DeleteBySemana(semaId);
            //Inicializa Log da Semana
            BLL.AcControleProducaoLogBLL.DeleteBySemaId(semaId);
            //ATENÇÃO:
            //***************************************************************************************
            DataTable dtReponderacao = BLL.AcControleProducaoBLL.Select("SELECT CRRE_CNTR_CODIGO, CRRE_ID, CRRE_FCME_SIGLA, CRRE_PERCENT FROM EEP_CONVERSION.AC_CRITERIO_REPONDERADO ORDER BY 1,2");
            //***************************************************************************************

            for (int i = 0; i < counter; i++)
            {
                if(i == 60752)
                {
                    string x = "";
                }
                try
                {
                    //bFoseIsValid = true;
                    DTO.AcControleProducaoDTO ap = new DTO.AcControleProducaoDTO();
                    countAP = BLL.AcControleProducaoBLL.Count("FOSE_ID = " + Convert.ToString(dt.Rows[i]["FOSE_ID"]) + @" AND SEMA_ID = " + semaId.ToString());
                    if ((dt.Rows[i]["SBCN_ID"] != null) && (dt.Rows[i]["SBCN_ID"] != DBNull.Value)) ap.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    ap.FoseCntrCodigo = contrato;
                    ap.SemaId = semaId;
                    ap.MesCompetencia = mesCompetencia;
                    ap.AnoCompetencia = anoCompetencia;
                    ap.SbcnSigla = Convert.ToString(dt.Rows[i]["SBCN_SIGLA"]);
                    ap.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    ap.DiscNome = Convert.ToString(dt.Rows[i]["DISC_NOME"]);
                    ap.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    ap.FoseNumero = Convert.ToString(dt.Rows[i]["FOSE_NUMERO"]);
                    ap.FoseDescricao = Convert.ToString(dt.Rows[i]["FOSE_DESCRICAO"]);
                    ap.UnmeSigla = Convert.ToString(dt.Rows[i]["UNME_SIGLA"]);
                    ap.SifsDescricao = Convert.ToString(dt.Rows[i]["SIFS_DESCRICAO"]);
                    if ((dt.Rows[i]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[i]["FOSE_QTD_PREVISTA"] != DBNull.Value)) ap.FoseQtdPrevista = Convert.ToString(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if ((dt.Rows[i]["QTD_ACUMULADA"] != null) && (dt.Rows[i]["QTD_ACUMULADA"] != DBNull.Value)) ap.QtdAcumulada = Convert.ToString(dt.Rows[i]["QTD_ACUMULADA"]);
                    if ((dt.Rows[i]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[i]["FCES_PESO_REL_CRON"] != DBNull.Value)) ap.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    ap.FcmeSigla = Convert.ToString(dt.Rows[i]["FCME_SIGLA"]);
                    ap.FcesSigla = Convert.ToString(dt.Rows[i]["FCES_SIGLA"]);

                    ap.SumaAtivSig = GetAtividadesFosm(contrato, Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]));
                    ap.GrcrNome = GetGrupoCriterio(contrato, ap.FcmeSigla);

                    //Troca FOSE atual
                    //ATENÇÃO:
                    //***************************************************************************************
                    //EXEC
                    if ((dt.Rows[i]["FSME_DATA"] != null) && (dt.Rows[i]["FSME_DATA"] != DBNull.Value)) ap.FsmeData = Convert.ToDateTime(dt.Rows[i]["FSME_DATA"]);
                    //Critérios de Elétrica que precisaram ser ajustados na Célula de Trabalho FORA do SISEPC operam cálculo com ponderação = 100%
                    ap.AvnRealExecPeriodo = Convert.ToString(dt.Rows[i]["AVN_REAL_EXEC_PERIODO"]);

                    for (int r = 0; r < dtReponderacao.Rows.Count; r++)
                    {
                        if (dtReponderacao.Rows[r]["CRRE_CNTR_CODIGO"].ToString() == contrato && dtReponderacao.Rows[r]["CRRE_FCME_SIGLA"].ToString() == ap.FcmeSigla)
                        {
                            ap.FcesPesoRelCron = Convert.ToDecimal(dtReponderacao.Rows[r]["CRRE_PERCENT"]);
                            break;
                        }
                    }
                    if (ap.AvnRealExecPeriodo != null) ap.AvnPondExecPeriodo = Convert.ToString(Convert.ToDecimal(ap.AvnRealExecPeriodo) * Convert.ToDecimal(ap.FcesPesoRelCron) / 100);
                    //PROG
                    if ((dt.Rows[i]["FSMP_DATA"] != null) && (dt.Rows[i]["FSMP_DATA"] != DBNull.Value)) ap.FsmpData = Convert.ToDateTime(dt.Rows[i]["FSMP_DATA"]);
                    //Critérios de Elétrica que precisaram ser ajustados na Célula de Trabalho FORA do SISEPC
                    ap.AvnRealProgPeriodo = Convert.ToString(dt.Rows[i]["AVN_REAL_PROG_PERIODO"]);
                    for (int r = 0; i < dtReponderacao.Rows.Count; i++)
                    {
                        if (dtReponderacao.Rows[r]["CRRE_CNTR_CODIGO"].ToString() == contrato && dtReponderacao.Rows[r]["CRRE_FCME_SIGLA"].ToString() == ap.FcmeSigla)
                        {
                            ap.FcesPesoRelCron = Convert.ToDecimal(dtReponderacao.Rows[r]["CRRE_PERCENT"]);
                            break;
                        }
                    }
                    if (ap.AvnRealProgPeriodo != null) ap.AvnPondProgPeriodo = Convert.ToString(Convert.ToDecimal(ap.AvnRealProgPeriodo) * Convert.ToDecimal(ap.FcesPesoRelCron) / 100);
                    //***************************************************************************************

                    //Prepara registro para salvar
                    if (countAP == 0)
                    {
                        try
                        {
                            atpeNome = Convert.ToString(dt.Rows[i]["ATPE_NOME"]).ToUpper();
                            if (atpeNome != "" && atpeNome != null)
                            {
                                descricaoAtributo = Convert.ToString(dt.Rows[i]["DESCRICAO_ATRIBUTO"]);
                                switch (atpeNome)
                                {
                                    case "EQUIPE": 
                                        { ap.Equipe = descricaoAtributo; break; } //Equipe
                                    case "SETOR": { ap.Setor = descricaoAtributo; break; } //Setor
                                    case "LOCALIZACAO": 
                                        { ap.Localizacao = descricaoAtributo; break; } //Localização
                                    case "DESENHO": { ap.Desenho = descricaoAtributo; break; } //Desenho
                                    case "ORIGEM DE FABRICAÇÃO": { ap.OrigemFabricacao = descricaoAtributo; break; }
                                    case "ÁREA DE PINTURA (M2)":  //Área de pintura (m2)
                                        {
                                            ap.AreaPintura = Convert.ToString(dt.Rows[i]["AREA_PINTURA"]); break;
                                        }
                                    case "CLASSIFICADO": { ap.Classificado = descricaoAtributo; break; } //Classificado
                                    case "DESCRIÇÃO DA ESTRUTURA":  //Descrição da Estrutura
                                        {
                                            ap.DescricaoEstrutura = descricaoAtributo.Trim();
                                            ap.ItemControle = GetItemControle(ap.DescricaoEstrutura);
                                            break;
                                        }
                                    case "DIAM": { ap.Diam = descricaoAtributo; break; } // Diam
                                    case "EMPRESA RESPONSÁVEL": { ap.EmpresaResponsavel = descricaoAtributo; break; }
                                    case "NOTA": { ap.Nota = descricaoAtributo; break; } //Nota
                                    case "REGIAO": { ap.Regiao = descricaoAtributo; break; } //Regiao
                                    case "SEMANA": 
                                        { ap.SemanaFolha = descricaoAtributo; break; } //Semana
                                    case "SISTEMA": { ap.Sistema = descricaoAtributo; break; } //Sistema
                                    case "SPEC": { ap.Spec = descricaoAtributo; break; } //Spec
                                    case "TRATAMENTO": { ap.Tratamento = descricaoAtributo; break; } //Tratamento
                                    case "ZONA": 
                                        {
                                            ap.ZonaId = null;
                                            if (descricaoAtributo != "") ap.ZonaId = Convert.ToDecimal(descricaoAtributo); break;  //Zona
                                        }
                                    case "PASTA": 
                                        { ap.PastaCodigo = descricaoAtributo; break; } //Pasta
                                    case "RESPONSAVEL": 
                                        { ap.Responsavel = descricaoAtributo; break; } //Responsavel

                                }
                            }
                            else
                            {
                                ap.Indefinido = "ATPE_NOME ou ATPI_TEXTO indefinido: " + ap.FoseNumero + " ==> " + atpeNome + " - " + descricaoAtributo;
                            }
                            pkCT += 1;
                            ap.ID = pkCT;
                            BLL.AcControleProducaoBLL.Insert(ap, false);
                        }
                        catch (Exception ex) 
                        { 
                            throw new Exception(ex.Message + " - Inserting AcControleProducao"); 
                        }
                    }
                    else
                    {
                        try
                        {
                            ap.ID = pkCT;
                            ap = BLL.AcControleProducaoBLL.GetObject("ID = " + ap.ID.ToString());
                            atpeNome = Convert.ToString(dt.Rows[i]["ATPE_NOME"]).ToUpper();
                            if (atpeNome != "" && atpeNome != null)
                            {
                                descricaoAtributo = Convert.ToString(dt.Rows[i]["DESCRICAO_ATRIBUTO"]);
                                switch (atpeNome)
                                {
                                    case "EQUIPE":
                                        {
                                            ap.Equipe = descricaoAtributo; break;
                                        } //Equipe
                                    case "SETOR": { ap.Setor = descricaoAtributo; break; } //Setor
                                    case "LOCALIZAÇÃO": { ap.Localizacao = descricaoAtributo; break; } //Localização
                                    case "LOCALIZACAO": 
                                        { ap.Localizacao = descricaoAtributo; break; } //Localização
                                    case "DESENHO": { ap.Desenho = descricaoAtributo; break; } //Desenho
                                    case "ORIGEM DE FABRICAÇÃO": { ap.OrigemFabricacao = descricaoAtributo; break; }
                                    case "ÁREA DE PINTURA (M2)": { ap.AreaPintura = descricaoAtributo; break; }  //Área de pintura (m2)
                                    case "CLASSIFICADO": { ap.Classificado = descricaoAtributo; break; } //Classificado
                                    case "DESCRIÇÃO DA ESTRUTURA":   //Descrição da Estrutura
                                        {
                                            ap.DescricaoEstrutura = descricaoAtributo.Trim();
                                            ap.ItemControle = GetItemControle(ap.DescricaoEstrutura);
                                            break;
                                        }
                                    case "DIAM": { ap.Diam = descricaoAtributo; break; } // Diam
                                    case "EMPRESA RESPONSÁVEL": { ap.EmpresaResponsavel = descricaoAtributo; break; }
                                    case "NOTA": { ap.Nota = descricaoAtributo; break; } //Nota
                                    case "REGIAO": { ap.Regiao = descricaoAtributo; break; } //Regiao
                                    case "SEMANA": 
                                        { ap.SemanaFolha = descricaoAtributo; break; } //Semana
                                    case "SISTEMA": { ap.Sistema = descricaoAtributo; break; } //Sistema
                                    case "SPEC": { ap.Spec = descricaoAtributo; break; } //Spec
                                    case "TRATAMENTO": { ap.Tratamento = descricaoAtributo; break; } //Tratamento
                                    case "ZONA":
                                        {
                                            ap.ZonaId = null;
                                            if (descricaoAtributo != "") ap.ZonaId = Convert.ToDecimal(descricaoAtributo); break;  //Zona
                                        }
                                    case "PASTA": 
                                        { ap.PastaCodigo = descricaoAtributo; break; } //Pasta
                                    case "RESPONSAVEL": 
                                        { ap.Responsavel = descricaoAtributo; break; } //Responsavel
                                }
                            }
                            else
                            {
                                ap.Indefinido = "ATPE_NOME ou ATPI_TEXTO indefinido: " + ap.FoseNumero + " ==> " + atpeNome + " - " + descricaoAtributo;
                            }
                            BLL.AcControleProducaoBLL.Update(ap);
                        }
                        catch (Exception ex) 
                        { 
                            //throw new Exception(ex.Message + " - Updating AcControleProducao"); 
                        }
                    }
                    UpdatePasta(ap);
                }
                catch (Exception ex) 
                { 
                    //throw new Exception("ProcessaFolhasServico: " + ex.Message); 
                }
            }
        }
        //===================================================================================
        private static void UpdatePasta(DTO.AcControleProducaoDTO ap)
        {
            if(ap.PastaCodigo != "" && ap.PastaCodigo != null)
            {
                DTO.CollectionCpPastaDTO cp = new DTO.CollectionCpPastaDTO();
                try
                {
                    cp = BLL.CpPastaBLL.GetCollection("PASTA_CODIGO = '" + ap.PastaCodigo + "'");
                    if (cp.Count > 0)
                    {
                        cp[0].PastaCodigo = ap.PastaCodigo;
                        cp[0].PastaResponsavel = ap.Responsavel;
                        cp[0].PastaRegiao = ap.Regiao;
                        if (ap.ZonaId != null) cp[0].PastaZonaId = (decimal)ap.ZonaId;
                        BLL.CpPastaBLL.Update(cp[0]);
                    }
                }
                catch (Exception ex) { throw new Exception("UpdatePasta: " + ex.Message); }
            }
        }
        //===================================================================================
        public static void EmailNoGroup(DataTable dtNoGroup)
        {
            try
            {
                if (dtNoGroup.Rows.Count > 0)
                {

                    string criterios = "";
                    string destinatariosTONoGroup = "";
                    string destinatariosCCNoGroup = "";
                    DataTable dtEmails = null;
                    for (int d = 0; d < dtNoGroup.Rows.Count; d++)
                    {
                        criterios += ", " + dtNoGroup.Rows[d]["FCME_SIGLA"].ToString();
                    }
                    criterios = criterios.Substring(2);
                    string corpo = PreparaEnvioNoGroup(criterios);
                    dtEmails = BLL.ProjGenEmailBLL.GetEmailByTipoDestinatario("OCT");
                    for (int e = 0; e < dtEmails.Rows.Count; e++)
                    {
                        destinatariosTONoGroup += ";" + dtEmails.Rows[e]["EMAIL"].ToString();
                    }
                    destinatariosTONoGroup = destinatariosTONoGroup.Substring(1);
                    dtEmails = BLL.ProjGenEmailBLL.GetEmailByTipoDestinatario("CCT");
                    for (int e = 0; e < dtEmails.Rows.Count; e++)
                    {
                        destinatariosCCNoGroup += ";" + dtEmails.Rows[e]["EMAIL"].ToString();
                    }
                    destinatariosCCNoGroup = destinatariosCCNoGroup.Substring(1);
                    tituloEmail = "Critérios de medições sem vínculo com Grupos (AC_GRCR_VINCULO_FCME)";
                    GenericClasses.Mail m = new GenericClasses.Mail();

                    //destinatariosTONoGroup = "paulo.almeida@enseada.com";
                    //destinatariosCCNoGroup = "paulo.almeida@enseada.com";
                    from = "Goliath@enseada.com";
                    m.Sendmail(from, destinatariosTONoGroup, destinatariosCCNoGroup, "", "", tituloEmail, corpo, "");
                }
            }
            catch (Exception ex) { throw new Exception("EmailNoGroup: " + ex.Message); }
        }
        //===================================================================================
        public static void EmailCriticaProcessamento(decimal semaId)
        {
            string path = @"F:\CONVERSÃO\PLANEJAMENTO\3-PCP\15-Células de Trabalho\LOG\";
            path = @"C:\Users\F_GL_CONVERSION\Documents\CELULAS_TRABALHO\";
            string fullNameFile = "";
            decimal peso = 0;
            string disciplina = "";
            DataTable dtDisciplinas = null;
            try
            {
                strSQL = "SELECT DISTINCT DISC_NOME FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG WHERE SEMA_ID = " + semaId.ToString() + " ORDER BY 1";
                dtDisciplinas = BLL.AcControleProducaoBLL.Select(strSQL);

                if (dtDisciplinas.Rows.Count > 0)
                {
                    for (int d = 0; d < dtDisciplinas.Rows.Count; d++)
                    {
                        disciplina = dtDisciplinas.Rows[d]["DISC_NOME"].ToString();
                        strSQL = @"SELECT DISTINCT DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, MESSAGE, AVN_REAL_EXEC_PERIODO FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG WHERE SEMA_ID = " + semaId.ToString() + " AND DISC_NOME = '" + disciplina + "' ORDER BY FOSE_NUMERO";

                        DataTable dtDescricoes = BLL.AcControleProducaoBLL.Select(strSQL);
                        fullNameFile = path + "Controle_Producao_" + semaId.ToString() + "_" + disciplina + ".xls";
                        GenericClasses.SpreadSheets.CreateSpreadSheet(dtDescricoes, fullNameFile);
                        //ENVIA EMAIL PARA COORDENADOR DE DISCIPLINA
                        SettingDestinatarios(disciplina.Split(' ')[0]);
                        string corpo = PreparaEnvio(disciplina, dtDescricoes, peso.ToString());
                        GenericClasses.Mail m = new GenericClasses.Mail();

                        destinatariosCC = "mara.paiva@enseada.com; leanderson.faillace@enseada.com; paulo.almeida@enseada.com; vanessa.moraes@enseada.com";
                        //destinatariosCC = "paulo.almeida@enseada.com";
                        //destinatariosTO = "paulo.almeida@enseada.com";

                        tituloEmail = "Inconformidades na geração das células de trabalho - Semana: " + semaId.ToString() + " Disciplina: " + disciplina;
                        m.Sendmail(from, destinatariosTO, destinatariosCC, "", "", tituloEmail, corpo, fullNameFile);
                    }
                }
                else
                {
                    destinatariosTO = "mara.paiva@enseada.com; leanderson.faillace@enseada.com; paulo.almeida@enseada.com; vanessa.moraes@enseada.com";
                    destinatariosCC = "";
                    tituloEmail = "Geração das células de trabalho - Semana: " + semaId.ToString() + " realizada com sucesso." + disciplina;
                    GenericClasses.Mail m = new GenericClasses.Mail();
                    string corpo = "A geração das células de trabalho da semana: " + semaId.ToString() + " foi realizada com sucesso, às " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    m.Sendmail(from, destinatariosTO, destinatariosCC, "", "", tituloEmail, corpo, fullNameFile);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - EmailCriticaProcessamento " + semaId.ToString()); }
        }
        //===================================================================================
        private static void ValidaFOSEs(decimal semaId)
        {
            try
            {
                decimal foseId = 0;
                DTO.CollectionAcControleProducaoDTO cp = new DTO.CollectionAcControleProducaoDTO();
                cp = BLL.AcControleProducaoBLL.GetCollection("SEMA_ID = " + semaId.ToString(), "FOSE_NUMERO");
                for (int d = 0; d < cp.Count; d++)
                {
                    foseId = cp[d].FoseId;
                    //Valida Controle Producao
                    //===================================================================================
                    bFoseIsValid = GenericClasses.Log.ValidaControleProducao(cp[d]);
                    //===================================================================================
                    if (!bFoseIsValid) 
                    {
                        //BLL.AcControleProducaoBLL.DeleteByFoseId(cp[d].FoseId);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - ValidaFOSEs " + semaId.ToString()); }
        }
        //===================================================================================
        private static void NormalizaNomenclatura(decimal semaId)
        {
            try
            {
                string foseId, descricao = "";
                DataTable dtDescricoes = null;
                DataTable dtItemControle = null;
                strSQL = "SELECT FOSE_ID, DESCRICAO_ESTRUTURA FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE DESCRICAO_ESTRUTURA IS NOT NULL AND ITEM_CONTROLE IS NULL and SEMA_ID = " + semaId.ToString();
                dtDescricoes = BLL.AcControleProducaoBLL.Select(strSQL);

                for (int d = 0; d < dtDescricoes.Rows.Count; d++)
                {
                    foseId = dtDescricoes.Rows[d]["FOSE_ID"].ToString();
                    descricao = dtDescricoes.Rows[d]["DESCRICAO_ESTRUTURA"].ToString();
                    strSQL = @"SELECT ITEM_CONTROLE FROM EEP_CONVERSION.AC_ITEM_CONTROLE WHERE DESCRICAO_ESTRUTURA = '" + descricao + "'";
                    dtItemControle = BLL.AcItemControleBLL.Select(strSQL);
                    if (dtItemControle.Rows.Count > 0)
                    {
                        strSQL = @"UPDATE EEP_CONVERSION.AC_CONTROLE_PRODUCAO SET ITEM_CONTROLE = '" + dtItemControle.Rows[0]["ITEM_CONTROLE"].ToString() + "' WHERE FOSE_ID = " + foseId;
                        BLL.AcControleProducaoBLL.ExecuteSQLInstruction(strSQL);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - NormalizaNomenclatura " + semaId.ToString()); }
        }
        //===================================================================================
        private static string PreparaEnvioNoGroup(string criterios)
        {
            string corpo = "";
            corpo += "Prezado Integrante,<br/><br/>";
            corpo += "Os critérios de medição abaixo NÃO POSSUEM suas associações com o grupo critério a que pertencem.<br/><br/>";
            corpo += "<b>O cálculo das Células de Trabalho só poderá ser realizado após tais critérios serem vinculados aos seus respectivos Grupos.</b> <br/><br/><br/>";
            corpo += "PS: Critérios a serem vinculados:";
            corpo += "<br/>" + criterios;
            corpo += "<br/><br/>PS: Esse email é automático, favor não responder.";
            return corpo;
        }
        //===================================================================================
        private static string PreparaEnvio(string disciplina, DataTable dtDescricoes, string peso )
        {
            string corpo = "";
            corpo += "Prezado Integrante,<br/><br/>";
            corpo += "As descrições de estrutura das folhas de serviços da planilha em anexo, não possuem seu correspondente ao Item Controle do Relatório de Controle de Produção.<br/><br/>";
            corpo += "Solicitamos ao Coordenador da Disciplina, que providencie a correção imediata, uma vez que tais ocorrências impedem que as folhas de serviço relacionadas, sejam computadas no cálculo das Células de Trabalho.<br/><br/><br/>";
            //corpo += "DISCIPLINA - FOSE_NUMERO - DESCRICAO_ESTRUTURA<br/>";
            //for (int i = 0; i < dtDescricoes.Rows.Count; i++)
            //{
            //    corpo += dtDescricoes.Rows[i]["DISC_NOME"].ToString() + " - " + dtDescricoes.Rows[i]["FOSE_NUMERO"].ToString() + " - " + dtDescricoes.Rows[i]["DESCRICAO_ESTRUTURA"].ToString() + "<br/>";
            //}

            //corpo += "<br/><br/> As folhas de serviços aqui relacionadas, totalizam " + peso;
            corpo += "<br/><br/>PS: Esse email é automático, favor não responder.";
            return corpo;
        }
        //===================================================================================
        private static void SettingDestinatarios(string disciplina)
        {
            try
            {
                DataTable dt = null;
                //COO - Coordenadores
                dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'COO' AND X.DISCIPLINA = '" + disciplina + "' AND X.ATIVO = 1", "EMAIL");
                destinatariosTO = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosTO += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosTO.Length > 0) destinatariosTO = destinatariosTO.Substring(1);
                //Cc
                dt = BLL.ProjGenEmailBLL.Get("(TIPO_DESTINATARIO = 'CCT' OR TIPO_DESTINATARIO = 'OCT') AND X.DISCIPLINA = 'TODAS' AND X.ATIVO = 1", "EMAIL");
                destinatariosCC = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosCC += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosCC.Length > 0) destinatariosCC = destinatariosCC.Substring(1);
                //Bcc
                //dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'BCC' AND X.DISCIPLINA = 'TODAS' AND X.ATIVO = 1", "EMAIL");
                destinatariosBCC = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosBCC += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosBCC.Length > 0) destinatariosBCC = destinatariosBCC.Substring(1);
                //LOG
                //dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'LOG' AND X.DISCIPLINA = '" + disciplina + "' AND X.ATIVO = 1", "EMAIL");
                destinatariosLOG = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosLOG += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosLOG.Length > 0) destinatariosLOG = destinatariosLOG.Substring(1);
            }
            catch (Exception ex) { throw new Exception("SettingDestinatarios: " + ex.Message); }
        }
        //===================================================================================
        private static string GetAtividadesFosm(string contrato, decimal fosmId)
        {
            string sRet = "";
            string strSQL = "SELECT ATIV_ID, ATIV_SIG FROM EEP_CONVERSION.ATIV_VINCULO_FS, EEP_CONVERSION.ATIVIDADE WHERE ATIV_CNTR_CODIGO = '" + contrato + @"' AND  ATIV_ID = ATVF_ATIV_ID AND ATIV_CNTR_CODIGO = ATVF_CNTR_CODIGO AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO) AND ATVF_FOSM_ID = " + fosmId.ToString();
            DataTable dt = BLL.AcControleProducaoBLL.Select(strSQL);
            int nr = dt.Rows.Count;
            if (nr != 0)
            {
                for (int i = 0; i < nr; i++)
                {
                    sRet += "/" + dt.Rows[i]["ATIV_SIG"].ToString();
                }
                sRet = sRet.Substring(1);
            }
            return sRet;
        }
        //===================================================================================
        private static string GetGrupoCriterio(string contrato, string fcmeSigla)
        {
            string sRet = "";
            string strSQL = "SELECT GRCR_NOME FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO WHERE GRCR_CNTR_CODIGO = '" + contrato + @"' AND FCME_SIGLA = '" + fcmeSigla + "'";
            DataTable dt = BLL.AcControleProducaoBLL.Select(strSQL);
            if (dt.Rows.Count > 0) sRet = dt.Rows[0]["GRCR_NOME"].ToString();
            return sRet;
        }
        //===================================================================================
        private static string GetItemControle(string descricaoEstrutura)
        {
            string itemControle = "";
            DTO.CollectionAcItemControleDTO col = new DTO.CollectionAcItemControleDTO();
            col = BLL.AcItemControleBLL.GetCollection("UPPER(TRIM(DESCRICAO_ESTRUTURA)) = '" + descricaoEstrutura.Trim().ToUpper() + "'");
            if (col.Count > 0) itemControle = col[0].ItemControle.Trim();
            return itemControle;
        }
        //===================================================================================
    }
}