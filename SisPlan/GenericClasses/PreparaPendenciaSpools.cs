using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GenericClasses
{
    public class PreparaPendenciaSpools
    {
        static string strSQL = "";
        static decimal comaId = 0;
        static DataTable dtItensCorridaMaterial = null;
        static DataTable dtControleFolhaServico = null;
        static DataTable dtRmMateriais = null;  //Agrupa as pendências por FOSE Status
        static DataTable dtPendenciaMaterial = null;  //Agrupa as AFs e NFs
        static DataTable dtAreaEstocagem = null;
        static DataTable dtNecMatTotalSbcnDisc = null;


        static DataTable dtNfItem = null;

        static DataRow[] rowControleFolhaServico;
        static DataRow[] rowRmMateriais;
        static DataRow[] rowPendenciaMaterial;
        static DataRow[] rowAreaEstocagem;

        static int countFOSE = 0;
        static int countRMs = 0;
        static int countAFs = 0;
        static int countAreaEstocagem = 0;

        static int countMateriaisSpoolPendenteCorrida = 0;
        static int countRMsMateriaisPendentes = 0;
        static int countAFsMateriaisPendentes = 0;
        static int countNFsMateriaisPendentes = 0;
        static int countNEMsMateriaisPendentes = 0;
        
        static DataTable dtMateriaisSpoolPendenteCorrida = null;
        static DataTable dtSpoolMaterialRMs = null;
        static DataTable dtSpoolMaterialAFs = null;
        static DataTable dtSpoolMaterialNFs = null;
        static DataTable dtSpoolMaterialNEMs = null;
        //static DataRow[] rowMateriaisSpoolPendenteCorrida;
        static DataRow[] rowSpoolMaterialRMs;
        static DataRow[] rowSpoolMaterialAFs;
        static DataRow[] rowSpoolMaterialNFs;
        static DataRow[] rowSpoolMaterialNEMs;
        static DataRow[] rowNecMatTotalSBCN;
        static int countNecMatTotalSBCN = 0;

        //==================================================================
        public static void GerarPendenciaSpools(string contrato, string discId, System.Windows.Forms.Label lblMessage, System.Windows.Forms.ProgressBar pb)
        {
            try
            {
                if (contrato == null) contrato = "Conversão";

                //Obtem a Corrida de Material mais recente();
                if (lblMessage != null) { pb.Value = 10;  lblMessage.Text = "Obtendo a última Corrida de Material... " + pb.Value.ToString(); Application.DoEvents(); } 
                comaId = GetUltimaCorridaMaterial();
                if (lblMessage != null) { pb.Value = 20; lblMessage.Text = "Obtendo os itens da última Corrida de Material... 20%"; Application.DoEvents(); }  
                dtItensCorridaMaterial = GetItensCorridaMaterial(comaId);
                if (lblMessage != null) { pb.Value = 30; lblMessage.Text = "Aguarde: Obtendo Controle de Status das Folhas de Serviços..."; Application.DoEvents(); } 
                dtControleFolhaServico = GetControleFolhaServico(contrato, discId);
                if (lblMessage != null) { pb.Value = 40; lblMessage.Text = "Aguarde: Obtendo Pendências de Materiais das folhas de Serviço..."; Application.DoEvents(); } 
                dtRmMateriais = GetRMMateriais(contrato, discId);
                if (lblMessage != null) { pb.Value = 50; lblMessage.Text = "Aguarde: Obtendo AFs e NFs por material..."; Application.DoEvents(); } 
                dtPendenciaMaterial = GetPendenciaMaterial(discId);
                if (lblMessage != null) { pb.Value = 60; lblMessage.Text = "Aguarde: Obtendo as Áreas de Estocagem dos materiais..."; Application.DoEvents(); } 
                dtAreaEstocagem = GetAreaEstocagem(contrato);

                if (lblMessage != null) { pb.Value = 75; lblMessage.Text = "Aguarde: Processando os Spools Pendentes..."; Application.DoEvents(); } 
                ProcessaSpoolsPendentes(contrato, discId);

                //BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_SPOOLS_PENDENTES WHERE SPPD_TSTF_UNIDADE_REGIONAL LIKE '%MÓDULO DE SERVIÇO%'");
                //BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("COMMIT");

                if (lblMessage != null) { pb.Value = 80; lblMessage.Text = "Obtendo os Materiais dos Spools Pendentes da última corrida..."; Application.DoEvents(); } 
                dtItensCorridaMaterial = GetMateriaisSpoolPendenteCorrida();
                if (lblMessage != null) { pb.Value = 83; lblMessage.Text = "Aguarde: Obtendo as RMs dos Spools Pendentes..."; Application.DoEvents(); } 
                dtSpoolMaterialRMs = GetSpoolMaterialRMs(contrato, discId);
                if (lblMessage != null) { pb.Value = 86; lblMessage.Text = "Aguarde: Obtendo as AFs dos Spools Pendentes..."; Application.DoEvents(); } 
                dtSpoolMaterialAFs = GetSpoolMaterialAFs(contrato, discId);
                if (lblMessage != null) { pb.Value = 90; lblMessage.Text = "Aguarde: Obtendo as NFs dos Spools Pendentes..."; Application.DoEvents(); } 
                dtSpoolMaterialNFs = GetSpoolMaterialNFs(contrato, discId);
                if (lblMessage != null) { pb.Value = 93; lblMessage.Text = "Aguarde: Obtendo as NEMs dos Spools Pendentes..."; Application.DoEvents(); } 
                dtSpoolMaterialNEMs = GetSpoolMaterialNEMs(contrato, discId);
                if (lblMessage != null) { pb.Value = 95; lblMessage.Text = "Aguarde: Obtendo os valores de Necessidade, Reserva e Aplicação dos Spools..."; Application.DoEvents(); }
                dtNecMatTotalSbcnDisc = GetNecMatTotalSbcnDisc(contrato, discId);

                if (lblMessage != null) { pb.Value = 98; lblMessage.Text = "Aguarde: Processando os Materiais Pendentes..."; Application.DoEvents(); } 
                ProcessaMateriaisPendentes(contrato, discId);

                if (lblMessage != null) { pb.Value = 100; lblMessage.Text = "Processamento concluído..."; Application.DoEvents(); }  

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==================================================================
        private static DataTable GetNecMatTotalSbcnDisc(string contrato, string discId)
        {
            strSQL = @"SELECT FSIT_CNTR_CODIGO, DISC_ID,
                              CASE
                                  WHEN FOLHA_NUMERO LIKE 'P%' THEN SUBSTR(FOLHA_NUMERO,1,3)
                                  ELSE 'P74'
                              END AS SBCN_SIGLA,
                              FSIT_FOSE_ID, FOLHA_NUMERO, 
                              EEP_CONVERSION.PKG_SISPLAN.FUN_GET_PIPELINE(FOLHA_NUMERO) AS PIPELINE,
                              FSIT_DIPR_ID, CODIGO, DIMENSOES, UNME_SIGLA, 
                              TIPO_DICIONARIO, 
                              CASE
                                  WHEN TIPO_DICIONARIO = 1 THEN 'EQUIPAMENTOS'
                                  WHEN TIPO_DICIONARIO = 2 THEN 'MATERIAIS'
                                  WHEN TIPO_DICIONARIO = 3 THEN 'DIVERSOS'
                              END DESC_DICIONARIO,
                              PESO, FSIT_QTD_REAL, FSIT_QTD_RESERVADA_CALC, FSIT_QTD_APLICADA_CALC, DESCRICAO
                         FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM
                        WHERE FSIT_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = " + discId;
            dtNecMatTotalSbcnDisc = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtNecMatTotalSbcnDisc;
        }
        //==================================================================
        private static DataTable GetSpoolMaterialNEMs(string contrato, string discId)
        {
            //NEMs
            strSQL = @"SELECT DCMN_CNTR_CODIGO, 
                              CASE
                                    WHEN DCMN_NUMERO LIKE '%.0F%' THEN 'P74'
                                    WHEN DCMN_NUMERO LIKE '%.0G%' THEN 'P75'
                                    WHEN DCMN_NUMERO LIKE '%.0H%' THEN 'P76'
                                    WHEN DCMN_NUMERO LIKE '%.0J%' THEN 'P77'
                                    ELSE SBCN_SIGLA
                              END AS SBCN_SIGLA,
                              REPR_CNTR_CODIGO, DISC_ID, DIPR_CODIGO, DIPR_DIMENSOES, REPR_NUMERO, REPL_REV, AUFO_NUMERO, AFIR_QTD, AFIT_QTD_TOTAL, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD, NOEN_NUMERO, NOEI_QTD_NEM, DVRE_NUMERO
                              FROM EEP_CONVERSION.V_NE_ITEM
                        WHERE REPI_CNTR_CODIGO = '" + contrato + @"' AND DISC_ID = " + discId.ToString() + @" 
                        ORDER BY DIPR_CODIGO, REPR_NUMERO, AUFO_NUMERO, NOFI_NUMERO, NOEN_NUMERO";
            dtSpoolMaterialNEMs = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtSpoolMaterialNEMs;
        }
        //==================================================================
        private static DataTable GetSpoolMaterialNFs(string contrato, string discId)
        {
            //NFs
            strSQL = @"SELECT DCMN_CNTR_CODIGO, 
                              CASE
                                    WHEN DCMN_NUMERO LIKE '%.0F%' THEN 'P74'
                                    WHEN DCMN_NUMERO LIKE '%.0G%' THEN 'P75'
                                    WHEN DCMN_NUMERO LIKE '%.0H%' THEN 'P76'
                                    WHEN DCMN_NUMERO LIKE '%.0J%' THEN 'P77'
                                    ELSE SBCN_SIGLA
                              END AS SBCN_SIGLA,
                              DISC_ID, DIPR_CODIGO, DIPR_DIMENSOES, REPR_NUMERO, REPL_REV, AUFO_NUMERO, AFIR_QTD, AFIT_QTD_TOTAL, NOFI_NUMERO, NOFI_REFERENCIA, NOFI_REFERENCIA, NOFI_DT_RECEBIMENTO, NFIT_QTD
                               FROM EEP_CONVERSION.V_NF_ITEM
                        WHERE REPI_CNTR_CODIGO = '" + contrato + @"' AND DISC_ID = " + discId.ToString() + @" 
                        ORDER BY DIPR_CODIGO, REPR_NUMERO, AUFO_NUMERO, NOFI_NUMERO";
            dtSpoolMaterialNFs = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtSpoolMaterialNFs;
        }
        //==================================================================
        private static DataTable GetSpoolMaterialAFs(string contrato, string discId)
        {
            //AFs
            strSQL = @"SELECT DCMN_CNTR_CODIGO, 
                              CASE
                                    WHEN DCMN_NUMERO LIKE '%.0F%' THEN 'P74'
                                    WHEN DCMN_NUMERO LIKE '%.0G%' THEN 'P75'
                                    WHEN DCMN_NUMERO LIKE '%.0H%' THEN 'P76'
                                    WHEN DCMN_NUMERO LIKE '%.0J%' THEN 'P77'
                                    ELSE SBCN_SIGLA
                              END AS SBCN_SIGLA,
                              DISC_ID, DIPR_CODIGO, DIPR_DIMENSOES, REPR_NUMERO, REPL_REV, AUFO_NUMERO, AFIR_QTD, AFIT_QTD_TOTAL, DIPQ_QTD_FS, AUFO_EMPR_NOME
                         FROM EEP_CONVERSION.V_AF_ITEM
                        WHERE REPI_CNTR_CODIGO = '" + contrato + @"' AND DISC_ID = " + discId.ToString() + @" 
                        ORDER BY DIPR_CODIGO, REPR_NUMERO, AUFO_NUMERO";
            dtSpoolMaterialAFs = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtSpoolMaterialAFs;
        }
        //==================================================================
        private static DataTable GetSpoolMaterialRMs(string contrato, string discId)
        {
            //RMs
            strSQL = @"SELECT 
                          DCMN_CNTR_CODIGO, 
                          CASE
                              WHEN DCMN_NUMERO LIKE '%.0F%' THEN 'P74'
                              WHEN DCMN_NUMERO LIKE '%.0G%' THEN 'P75'
                              WHEN DCMN_NUMERO LIKE '%.0H%' THEN 'P76'
                              WHEN DCMN_NUMERO LIKE '%.0J%' THEN 'P77'
                              ELSE SBCN_SIGLA 
                          END AS SBCN_SIGLA, 
                          DISC_ID,
                          DCMN_NUMERO,
                          DIPR_CODIGO, 
                          DIPR_DIMENSOES, 
                          DCMN_ID,
                          REPR_NUMERO, 
                          REPR_REV, 
                          REPI_QTD_TOTAL,
                          DIPQ_QTD_FS
                         FROM EEP_CONVERSION.V_RP_ITEM
                        WHERE DCMN_CNTR_CODIGO = '" + contrato + @"'  AND DISC_ID = " + discId.ToString() + @" 
                        ORDER BY DIPR_CODIGO, REPL_REV";
            dtSpoolMaterialRMs = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtSpoolMaterialRMs;
        }
        //==================================================================
        private static void ProcessaMateriaisPendentes(string contrato, string discId)
        {
            try
            {
                BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_MATERIAIS_PENDENTES");
                BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("COMMIT");

                countMateriaisSpoolPendenteCorrida = dtMateriaisSpoolPendenteCorrida.Rows.Count;
                for (int i = 0; i < countMateriaisSpoolPendenteCorrida; i++)
                {
                    //if (i == 10)
                    //{
                    //    string x = "";
                    //}
                    DTO.AcMateriaisPendentesDTO m = new DTO.AcMateriaisPendentesDTO();
                    m.MapdComaId = Convert.ToDecimal(dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_COMA_ID"]);
                    m.MapdSbcnSigla = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_SBCN_SIGLA"].ToString();
                    m.MapdDiscId = Convert.ToDecimal(discId);
                    m.MapdDiprCodigo = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_DIPR_CODIGO"].ToString();
                    m.MapdDiprDimensoes = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_DIPR_DIMENSOES"].ToString();
                    m.MapdDiprDescricao = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_DIPR_DESCRICAO"].ToString();
                    m.MapdUnmeSigla = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_UNME_SIGLA"].ToString();
                    m.MapdQtdNecCorrida = Convert.ToDecimal(dtMateriaisSpoolPendenteCorrida.Rows[i]["QTD_NEC_TOTAL_CORRIDA"]);
                    m.MapdQtdNecTotal = GetNecMatTotalSBCN(dtNecMatTotalSbcnDisc, contrato, discId, m.MapdSbcnSigla, m.MapdDiprCodigo, m.MapdDiprDimensoes);
                    m.MapdDcmnNumero = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_DCMN_NUMERO"].ToString();
                    m.MapdReplRev = dtMateriaisSpoolPendenteCorrida.Rows[i]["SPPD_REPL_REV"].ToString();
                    
                    //Cria o registro referente ao Material e obtém a chave primária do mesmo
                    BLL.AcMateriaisPendentesBLL.Insert(m, false);
                    string filter = @"MAPD_SBCN_SIGLA = '" + m.MapdSbcnSigla.ToString() + "' AND MAPD_DCMN_NUMERO = '" + m.MapdDcmnNumero + "' AND MAPD_REPL_REV = '" + m.MapdReplRev + "' AND MAPD_DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND MAPD_DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'";
                    m.MapdId = Convert.ToDecimal(BLL.AcMateriaisPendentesBLL.Select(@"SELECT MAPD_ID FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES WHERE " + filter).Rows[0]["MAPD_ID"]);

                    //rowSpoolMaterialRMs;
                    //Obtém as RMs de cada material
                    rowSpoolMaterialRMs = dtSpoolMaterialRMs.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + m.MapdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
                    countRMsMateriaisPendentes = rowSpoolMaterialRMs.Count();
                    //======================================================================================================================================================
                    //Incorpora RMs ao Material e inlcui registro em AC_MATERIAIS_PENDENTES
                    //VARRE AS RMs associadas ao Material
                    for (int rm = 0; rm < countRMsMateriaisPendentes; rm++)
                    {
                        m.MapdDcmnId = Convert.ToDecimal(rowSpoolMaterialRMs[rm]["DCMN_ID"]);
                        m.MapdQtdMaterialRm = Convert.ToDecimal(rowSpoolMaterialRMs[rm]["REPI_QTD_TOTAL"]);
                        //m.MapdQtdNecTotal = Convert.ToDecimal(rowSpoolMaterialRMs[rm]["DIPQ_QTD_FS"]);

                        m.MapdQtdNecAnteriorCorrida = m.MapdQtdNecTotal - m.MapdQtdNecCorrida;
                        if (m.MapdQtdNecAnteriorCorrida <= 0) m.MapdQtdNecAnteriorCorrida = null;
                        
                        //BLL.AcMateriaisPendentesBLL.Update(m);
                       
                        //=======================================================================================================================
                        //Incorpora AFs
                        //rowSpoolMaterialAF
                        rowSpoolMaterialAFs = dtSpoolMaterialAFs.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + m.MapdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
                        string AF = "";
                        string FORNECEDOR = "";
                        decimal totalAFs = 0;
                        
                        countAFsMateriaisPendentes = rowSpoolMaterialAFs.Count();
                        try
                        {
                            for (int r = 0; r < countAFsMateriaisPendentes; r++)
                            {
                                if (AF.IndexOf(rowSpoolMaterialAFs[r]["AUFO_NUMERO"].ToString()) == -1) AF += " ; " + rowSpoolMaterialAFs[r]["AUFO_NUMERO"].ToString();
                                if (FORNECEDOR.IndexOf(rowSpoolMaterialAFs[r]["AUFO_EMPR_NOME"].ToString()) == -1) FORNECEDOR += " ; " + rowSpoolMaterialAFs[r]["AUFO_EMPR_NOME"].ToString();
                                totalAFs += Convert.ToDecimal(rowSpoolMaterialAFs[r]["AFIT_QTD_TOTAL"]);   
                            }

                            if (AF != "") AF = AF.Substring(3);
                            if (FORNECEDOR != "") FORNECEDOR = FORNECEDOR.Substring(3);

                            m.MapdAufoNumero = AF;
                            m.MapdQtdMaterialAf = totalAFs;
                            if (m.MapdQtdMaterialAf == 0) m.MapdQtdMaterialAf = null;
                            m.MapdAufoEmprNome = FORNECEDOR;
                            //BLL.AcMateriaisPendentesBLL.Update(m);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }

                        //=======================================================================================================================

                        //=======================================================================================================================
                        //Incorpora NFs
                        //rowSpoolMaterialNF
                        rowSpoolMaterialNFs = dtSpoolMaterialNFs.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + m.MapdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
                        string datasRecebimento = "";
                        string NF = "";
                        string REFERENCIA = "";
                        decimal totalNFs = 0;
                        countNFsMateriaisPendentes = rowSpoolMaterialNFs.Count();
                        try
                        {
                            for (int f = 0; f < countNFsMateriaisPendentes; f++)
                            {
                                if (NF.IndexOf(rowSpoolMaterialNFs[f]["NOFI_NUMERO"].ToString()) == -1) NF += " ; " + rowSpoolMaterialNFs[f]["NOFI_NUMERO"].ToString();
                                if (REFERENCIA.IndexOf(rowSpoolMaterialNFs[f]["NOFI_REFERENCIA"].ToString()) == -1) REFERENCIA += " ; " + rowSpoolMaterialNFs[f]["NOFI_REFERENCIA"].ToString();
                                if (rowSpoolMaterialNFs[f]["NOFI_DT_RECEBIMENTO"].ToString() != "")
                                {
                                    if (datasRecebimento.IndexOf(Convert.ToDateTime(rowSpoolMaterialNFs[f]["NOFI_DT_RECEBIMENTO"]).ToString("dd/MM/yyyy")) == -1) datasRecebimento += " ; " + Convert.ToDateTime(rowSpoolMaterialNFs[f]["NOFI_DT_RECEBIMENTO"]).ToString("dd/MM/yyyy");
                                }
                                totalNFs += Convert.ToDecimal(rowSpoolMaterialNFs[f]["NFIT_QTD"]);
                            }

                            if (datasRecebimento != "") datasRecebimento = datasRecebimento.Substring(3);
                            if (NF != "") NF = NF.Substring(3);
                            if (REFERENCIA != "") REFERENCIA = REFERENCIA.Substring(3);

                            m.MapdDatasRecebimento = datasRecebimento;
                            m.MapdNotasFiscais = NF;
                            m.MapdNofiReferencia = REFERENCIA;
                            m.MapdNfitQtd = totalNFs;
                            if (m.MapdNfitQtd == 0) m.MapdNfitQtd = null;

                            //BLL.AcMateriaisPendentesBLL.Update(m);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }

                        // Adaptar o bloco de NFs acima e o DataTable dtSpoolMaterialNEMs 
                        //Com rowSpoolMaterialNEMs e countNEMsMateriaisPendentes = rowSpoolMaterialNEMs.Count()

                        //=======================================================================================================================
                        //Incorpora NEMs
                        //rowSpoolMaterialNF
                        rowSpoolMaterialNEMs = dtSpoolMaterialNEMs.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + m.MapdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
                        string NEM = "";
                        decimal totalNEMs = 0;
                        string DIV = "";

                        countNEMsMateriaisPendentes = rowSpoolMaterialNEMs.Count();
                        try
                        {
                            for (int e = 0; e < countNEMsMateriaisPendentes; e++)
                            {
                                if (NEM.IndexOf(rowSpoolMaterialNEMs[e]["NOEN_NUMERO"].ToString()) == -1) NEM += " ; " + rowSpoolMaterialNEMs[e]["NOEN_NUMERO"].ToString();
                                if (DIV.IndexOf(rowSpoolMaterialNEMs[e]["DVRE_NUMERO"].ToString()) == -1) DIV += " ; " + rowSpoolMaterialNEMs[e]["DVRE_NUMERO"].ToString();
                                totalNEMs += Convert.ToDecimal(rowSpoolMaterialNEMs[e]["NOEI_QTD_NEM"]);
                            }

                            if (NEM != "") NEM = NEM.Substring(3);
                            if (DIV != "") DIV = DIV.Substring(3);
                            m.MapdNoenNumero = NEM;
                            m.MapdNoeiQtdNem = totalNEMs;
                            m.MapdDvreNumero = DIV;
                            if (m.MapdNoeiQtdNem == 0) m.MapdNoeiQtdNem = null;

                            //BLL.AcMateriaisPendentesBLL.Update(m);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }

                        //dtAreaEstocagem, rowAreaEstocagem
                        //=======================================================================================================================
                        //Incorpora Area Estocagem
                        //rowAreaEstocagem

                        rowAreaEstocagem = dtAreaEstocagem.Select("DIPR_CNTR_CODIGO = '" + contrato +"' AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
                        string ARES = "";

                        countAreaEstocagem = rowAreaEstocagem.Count();
                        try
                        {
                            for (int a = 0; a < countAreaEstocagem; a++)
                            {
                                if (ARES.IndexOf(rowAreaEstocagem[a]["QTD_AREA_ESTOCAGEM"].ToString()) == -1) ARES += " ; " + rowAreaEstocagem[a]["QTD_AREA_ESTOCAGEM"].ToString();
                            }

                            if (ARES != "") ARES = ARES.Substring(3);
                            m.MapdAreasEstocagem = ARES;
                            BLL.AcMateriaisPendentesBLL.Update(m);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }
                                                
                        //=======================================================================================================================
                        //FECHAMENTO
                        try
                        {
                            m.MapdCoberturaRm = m.MapdQtdMaterialRm - m.MapdQtdNecTotal;        // Cobertura RM ==> Especificar via Engenharia

                            m.MapdCoberturaAf = m.MapdQtdNecTotal;
                            if (m.MapdQtdMaterialAf != null) m.MapdCoberturaAf = m.MapdQtdNecTotal - m.MapdQtdMaterialAf;       // CoberturaAF  ==> Comprar
                            if (m.MapdCoberturaAf <= 0) m.MapdCoberturaAf = null;

                            if (m.MapdQtdMaterialAf != null) m.MapdSaldoEntrega = (decimal)(m.MapdQtdMaterialAf);
                            if (m.MapdNfitQtd != null) m.MapdSaldoEntrega = (decimal)(m.MapdQtdMaterialAf - m.MapdNfitQtd);           // Cobrar do Fornecedor


                            if (m.MapdNfitQtd != null) m.MapdSaldoLiberado = (decimal)(m.MapdNfitQtd);
                            if(m.MapdNoeiQtdNem != null) m.MapdSaldoLiberado = (decimal)(m.MapdNfitQtd - m.MapdNoeiQtdNem);             // Saldo Liberado para uso real do Material

                            //Aguardando Recebimento
                            if (m.MapdSaldoEntrega <= 0) m.MapdAguardandoRecebimento = null;
                            else if (m.MapdSaldoEntrega >= m.MapdQtdNecCorrida) m.MapdAguardandoRecebimento = m.MapdQtdNecCorrida;
                            else if (m.MapdSaldoEntrega < m.MapdQtdNecCorrida) m.MapdAguardandoRecebimento = m.MapdSaldoEntrega;

                            //Correção da RM
                            if (m.MapdQtdMaterialRm >= m.MapdQtdNecTotal) m.MapdCorrecaoRm = null;
                            else m.MapdCorrecaoRm = m.MapdQtdNecTotal - m.MapdQtdMaterialRm;

                            //Solicitação de Compra
                            m.MapdSolicitacaoCompra = null;
                            if (m.MapdSaldoEntrega <= m.MapdQtdNecCorrida) m.MapdSolicitacaoCompra = m.MapdQtdNecCorrida;

                            BLL.AcMateriaisPendentesBLL.Update(m);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }
                    }
                    //======================================================================================================================================================
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==================================================================
        private static decimal GetNecMatTotalSBCN(DataTable dtNecMatTotalSbcnDisc, string contrato, string discId, string sbcnSigla, string diprCodigo, string diprDimensoes)
        {
            decimal necMatTotalSBCN = 0;
            rowNecMatTotalSBCN = dtNecMatTotalSbcnDisc.Select("FSIT_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = " + discId + " AND SBCN_SIGLA = '" + sbcnSigla + "' AND CODIGO = '" + diprCodigo + "' AND DIMENSOES = '" + diprDimensoes + "'");
            countNecMatTotalSBCN = rowNecMatTotalSBCN.Count();
            if (countNecMatTotalSBCN > 0)
            {
                for (int f = 0; f < countNecMatTotalSBCN; f++)
                {
                    necMatTotalSBCN += Convert.ToDecimal(rowNecMatTotalSBCN[f]["FSIT_QTD_REAL"]);
                }
            }
            return necMatTotalSBCN;
        }
        //==================================================================
        private static void ProcessaSpoolsPendentes(string contrato, string discId)
        {
            try
            {
                BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_SPOOLS_PENDENTES");
                BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("COMMIT");

                countFOSE = dtItensCorridaMaterial.Rows.Count;
                for (int i = 0; i < countFOSE; i++)
                {
                    //if (i == 10)
                    //{
                    //    string x = "";
                    //}

                    DTO.AcSpoolsPendentesDTO s = new DTO.AcSpoolsPendentesDTO();
                    s.SppdComaId = comaId;
                    s.SppdCreatedBy = dtItensCorridaMaterial.Rows[i]["CMIT_CREATED_BY"].ToString();
                    s.SppdFoseNumero = dtItensCorridaMaterial.Rows[i]["CMIT_FOSE_NUMERO"].ToString();
                    s.SppdPipeline = GenericClasses.FolhaServico.GetFosePipeline(s.SppdFoseNumero);
                    s.SppdDiprCodigo = dtItensCorridaMaterial.Rows[i]["CMIT_DIPR_CODIGO"].ToString();
                    s.SppdDiprDimensoes = dtItensCorridaMaterial.Rows[i]["CMIT_DIPR_DIMENSOES"].ToString();
                    s.SppdDiprDescricao = dtItensCorridaMaterial.Rows[i]["CMIT_DIPR_DESCRICAO"].ToString();
                    s.SppdUnmeSigla = dtItensCorridaMaterial.Rows[i]["CMIT_UNME_SIGLA"].ToString();
                    s.SppdQtdFsCorrida = Convert.ToDecimal(dtItensCorridaMaterial.Rows[i]["CMIT_QTD_FS_CORRIDA"]);
                    s.SppdQtdAReservar = Convert.ToDecimal(dtItensCorridaMaterial.Rows[i]["CMIT_QTD_A_RESERVAR"]);
                    s.SppdQtdNecessaria = s.SppdQtdFsCorrida - s.SppdQtdAReservar;
                    s.SppdSbcnSigla = GetSbcnSiglaByFOSE(s.SppdFoseNumero);
                    s.SppdFabricado = "N";

                    //if (s.SppdDiprCodigo == "5.01.01.001.52.15.08")
                    //{
                    //    string x = "";
                    //}

                    //Obtém dados de AC_CONTROLE_FOLHA_SERVICO
                    //rowControleFolhaServico
                    rowControleFolhaServico = dtControleFolhaServico.Select("FOSE_NUMERO = '" + s.SppdFoseNumero + "'");
                    switch (rowControleFolhaServico.Count())
                    {
                        case 0: 
                            { 
                                break; 
                            }
                        default:
                            {   
                                s.SppdFoseId = Convert.ToDecimal(rowControleFolhaServico[0]["FOSE_ID"]);
                                s.SppdFoseRev = Convert.ToString(rowControleFolhaServico[0]["FOSE_REV"]);
                                s.SppdFoseDescricao = Convert.ToString(rowControleFolhaServico[0]["FOSE_DESCRICAO"]);
                                s.SppdRegiao = Convert.ToString(rowControleFolhaServico[0]["REGIAO"]);
                                s.SppdTstfUnidadeRegional = Convert.ToString(rowControleFolhaServico[0]["TSTF_UNIDADE_REGIONAL"]);
                                s.SppdFabricado = GetFabricado(s.SppdFoseId);
                                break;
                            }
                    }
                    //rowRmMateriais
                    //Obtém as RMs de cada material da FOSE
                    rowRmMateriais = dtRmMateriais.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + s.SppdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + s.SppdDiprCodigo + "' AND DIPR_DIMENSOES = '" + s.SppdDiprDimensoes + "'");
                    countRMs = rowRmMateriais.Count();
                    if (countRMs > 0)
                    {
                        //Incorpora RMs a FOSE
                        IncludeRmByFOSE(s);

                        //Incorpora AFs e NFs
                        IncludeAFsByRM(s);
                    }

                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==================================================================
        private static void IncludeAFsByRM(DTO.AcSpoolsPendentesDTO s)
        {
            if(s.SppdDiprCodigo == "5.01.01.001.52.15.08")
            {
                string x = "";
            }
            //rowSpoolMaterialAFs = dtSpoolMaterialAFs.Select("DCMN_CNTR_CODIGO = '" + contrato + "' AND SBCN_SIGLA = '" + m.MapdSbcnSigla + "' AND DISC_ID = " + discId + " AND DIPR_CODIGO = '" + m.MapdDiprCodigo + "' AND DIPR_DIMENSOES = '" + m.MapdDiprDimensoes + "'");
            //rowPendenciaMaterial
            //rowPendenciaMaterial = dtPendenciaMaterial.Select("SBCN_SIGLA = '" + s.SppdSbcnSigla + "' AND DIPC_CODIGO = '" + s.SppdDiprCodigo + "' AND DIPR_DIMENSOES = '" + s.SppdDiprDimensoes + "'");

            rowPendenciaMaterial = dtPendenciaMaterial.Select("DCMN_NUMERO = '" + s.SppdDcmnNumero.ToString() + "' AND DIPC_CODIGO = '" + s.SppdDiprCodigo + "' AND DIPR_DIMENSOES = '" + s.SppdDiprDimensoes + "'");
           
            string AF = "";
            string datasRecebimento = "";
            string NF = "";
            countAFs = rowPendenciaMaterial.Count();
            try
            {
                for (int r = 0; r < countAFs; r++)
                {
                    if (AF.IndexOf(rowPendenciaMaterial[r]["AUFO_NUMERO"].ToString()) == -1) AF += " ; " + rowPendenciaMaterial[r]["AUFO_NUMERO"].ToString();

                    if (rowPendenciaMaterial[r]["NOFI_DT_RECEBIMENTO"].ToString() != "")
                    {
                        if (datasRecebimento.IndexOf(Convert.ToDateTime(rowPendenciaMaterial[r]["NOFI_DT_RECEBIMENTO"]).ToString("dd/MM/yyyy")) == -1) datasRecebimento += " ; " + Convert.ToDateTime(rowPendenciaMaterial[r]["NOFI_DT_RECEBIMENTO"]).ToString("dd/MM/yyyy");
                    }

                    if (NF.IndexOf(rowPendenciaMaterial[r]["NOFI_NUMERO"].ToString()) == -1) NF += " ; " + rowPendenciaMaterial[r]["NOFI_NUMERO"].ToString();
                }

                if (AF != "") AF = AF.Substring(3);
                if (datasRecebimento != "") datasRecebimento = datasRecebimento.Substring(3);
                if (NF != "") NF = NF.Substring(3);

                s.SppdAufoNumero = AF;
                s.SppdDatasRecebimento = datasRecebimento;
                s.SppdNotasFiscais = NF;
                BLL.AcSpoolsPendentesBLL.Update(s);

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==================================================================
        private static void IncludeRmByFOSE(DTO.AcSpoolsPendentesDTO s)
        {
            //VARRE AS RMs associadas a FOSE
            for (int rm = 0; rm < countRMs; rm++)
            {
                s.SppdDcmnId = Convert.ToDecimal(rowRmMateriais[rm]["DCMN_ID"]);
                s.SppdDcmnNumero = rowRmMateriais[rm]["DCMN_NUMERO"].ToString();
                s.SppdReplRev = rowRmMateriais[rm]["REPL_REV"].ToString();  // Revisão da RM
                //Cria o registo referente a RMs
                BLL.AcSpoolsPendentesBLL.Insert(s, false);
                string filter = @"SPPD_FOSE_ID = " + s.SppdFoseId.ToString() + "  AND SPPD_DIPR_CODIGO = '" + s.SppdDiprCodigo + "' AND SPPD_DIPR_DIMENSOES = '" + s.SppdDiprDimensoes + "' AND SPPD_DCMN_ID = " + s.SppdDcmnId.ToString();
                s.SppdId = Convert.ToDecimal(BLL.AcSpoolsPendentesBLL.Select(@"SELECT SPPD_ID FROM EEP_CONVERSION.AC_SPOOLS_PENDENTES WHERE " + filter).Rows[0]["SPPD_ID"]);
            }
        }
        //==================================================================
        private static string GetFabricado(decimal sppdFoseId)
        {
            string sppdFabricado = "N";
            string foseStatus = "";
            DataRow[] rowControleSpoolsPendentes = dtControleFolhaServico.Select("FOSE_ID = " + sppdFoseId.ToString());
            if (rowControleFolhaServico.Count() > 0)
            {
                foseStatus = rowControleFolhaServico[0]["FOSE_STATUS"].ToString();
                if (foseStatus.IndexOf("CQ") >= 0)
                {
                    sppdFabricado = "S";
                }
            }
            return sppdFabricado;
        }
        //==================================================================
        private static string GetSbcnSiglaByFOSE(string foseNumero)
        {
            string sbcnSigla = "P74";
            if (foseNumero.Substring(0, 1).ToUpper() == "P") sbcnSigla = foseNumero.Substring(0, 3).ToUpper();
            return sbcnSigla;
        }
        //==================================================================
        private static DataTable GetMateriaisSpoolPendenteCorrida()
        {
            strSQL = @"SELECT
                          SPPD_COMA_ID,
                          SPPD_SBCN_SIGLA,
                          SPPD_DIPR_CODIGO,
                          SPPD_DIPR_DIMENSOES,
                          SPPD_DIPR_DESCRICAO,
                          SPPD_UNME_SIGLA,
                          SPPD_DCMN_NUMERO,
                          SPPD_REPL_REV,
                          SUM(SPPD_QTD_FS_CORRIDA) AS QTD_NEC_TOTAL_CORRIDA
                        FROM
                          EEP_CONVERSION.AC_SPOOLS_PENDENTES
                        GROUP BY 
                          SPPD_COMA_ID,
                          SPPD_SBCN_SIGLA,
                          SPPD_DIPR_CODIGO,
                          SPPD_DIPR_DIMENSOES,
                          SPPD_DIPR_DESCRICAO,
                          SPPD_UNME_SIGLA,
                          SPPD_DCMN_NUMERO,
                          SPPD_REPL_REV
                          ORDER BY SPPD_SBCN_SIGLA, SPPD_DIPR_CODIGO, SPPD_DIPR_DIMENSOES, SPPD_DCMN_NUMERO, SPPD_REPL_REV";
            dtMateriaisSpoolPendenteCorrida = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtMateriaisSpoolPendenteCorrida;
        }

        //==================================================================
        private static DataTable GetAreaEstocagem(string contrato)
        {
            strSQL = @"SELECT DIPR_CNTR_CODIGO, DIPR_CODIGO, DIPR_DIMENSOES, QTD_AREA_ESTOCAGEM FROM EEP_CONVERSION.VW_AC_AREA_ESTOCAGEM WHERE DIPR_CNTR_CODIGO = '" + contrato + "'";
            dtAreaEstocagem = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtAreaEstocagem;
        }
        //==================================================================
        private static DataTable GetPendenciaMaterial(string discId)
        {
            string discNome = "";
            switch (discId)
            {
                case "5":
                    {
                        discNome = "Tubulação";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
                strSQL = @"SELECT ID, DCMN_NUMERO, DCMN_TITULO, DIPC_CODIGO, DIPI_DESCRICAO_RES, DIPR_PESO, DIPR_DIM1, DIPR_DIM2, DIPR_DIM3, REPI_ITEM, REPI_QTD_TOTAL, FSIT_QTD_REAL, AFIT_ITEM, AFIT_QTD_TOTAL,  AUFO_ID, AUFO_NUMERO, AUFO_DT_EMISSAO, AFIC_CONTRATUAL, DIPQ_QTD_AF, UNME_SIGLA, EMPR_NOME, NFIT_QTD, NOFI_DT_RECEBIMENTO, NOFI_NUMERO, NOEN_NUMERO, NOEN_DT_EMISSAO, NOEN_OBS, NOEI_ITEM, NOEI_QTD_NEM, DISC_NOME, SBCN_SIGLA, STATUS, CREATED_DATE, DIPR_DIMENSOES, PRAZOS, ENTREGAS, QTD_RDR,  DADOS_RDR
                             FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL
                            WHERE DISC_NOME = '" + discNome + "'";
            dtPendenciaMaterial = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtPendenciaMaterial;
        }
        //==================================================================
        private static DataTable GetRMMateriais(string contrato, string discId)
        {
            strSQL = @"SELECT 
                                DCMN_CNTR_CODIGO, 
                                CASE
                                WHEN DCMN_NUMERO LIKE '%.0F%' THEN 'P74'
                                WHEN DCMN_NUMERO LIKE '%.0G%' THEN 'P75'
                                WHEN DCMN_NUMERO LIKE '%.0H%' THEN 'P76'
                                WHEN DCMN_NUMERO LIKE '%.0J%' THEN 'P77'
                                ELSE SBCN_SIGLA
                                END AS SBCN_SIGLA, 
                                DISC_ID,
                                DCMN_NUMERO, 
                                REPL_REV, 
                                DIPR_CODIGO, 
                                DIPR_DIMENSOES, 
                                DCMN_ID 
                         FROM EEP_CONVERSION.V_RP_ITEM WHERE DCMN_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = " + discId.ToString();
            dtRmMateriais = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtRmMateriais;
        }
        //==================================================================
        private static DataTable GetControleFolhaServico(string contrato, string discId)
        {
            strSQL = @"SELECT FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_DESCRICAO, UNME_SIGLA, FCME_SIGLA, FCES_SIGLA, EQUIPE, SETOR, LOCALIZACAO, CLASSIFICADO, DESENHO,  ORIGEM_FABRICACAO,
       AREA_PINTURA, FOSE_COMPRIMENTO, DESCRICAO_ESTRUTURA, DIAM, EMPRESA_RESPONSAVEL, NOTA, REGIAO, SEMANA_FOLHA, SISTEMA, SPEC, TRATAMENTO, INDEFINIDO, FOSE_QTD_PREVISTA, QTD_ACUMULADA,
       SIFS_DESCRICAO, FOSE_STATUS, LAST_UPDATE, GRCR_GRUPO_CRITERIO, FOSE_REV, STATUS_TRATAMENTO, DT_STATUS_TRATAMENTO, LOCAL_ESTOCAGEM, MAX_FSME_DATA, TSTF_UNIDADE_REGIONAL
  FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO 
 WHERE FOSE_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = " + discId.ToString();
            dtControleFolhaServico = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtControleFolhaServico;
        }
        //==================================================================
        private static DataTable GetItensCorridaMaterial(decimal comaId)
        {
            strSQL = @"SELECT CMIT_ID,  CMIT_COMA_ID,  CMIT_FOSE_NUMERO,  CMIT_DIPR_CODIGO,  CMIT_DIPR_DIMENSOES,  CMIT_DIPR_DESCRICAO,  CMIT_UNME_SIGLA,  
                              CMIT_QTD_FS_CORRIDA,  CMIT_QTD_A_RESERVAR,  CMIT_STATUS,  CMIT_CREATED_BY,  CMIT_CREATED_DATE 
                         FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM
                        WHERE CMIT_COMA_ID = " + comaId.ToString();
            dtItensCorridaMaterial = BLL.AcSpoolsPendentesBLL.Select(strSQL);
            return dtItensCorridaMaterial;
        }
        //==================================================================
        private static decimal GetUltimaCorridaMaterial()
        {
            decimal corrida = 0;
            strSQL = "SELECT M.COMA_ID FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL M WHERE M.COMA_CREATED_DATE = (SELECT MAX(MA.COMA_CREATED_DATE) FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL MA)";
            corrida = Convert.ToDecimal(BLL.AcSpoolsPendentesBLL.Select(strSQL).Rows[0][0]);
            return corrida;
        }
    }
}
