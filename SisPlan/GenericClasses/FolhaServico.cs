using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
 
namespace GenericClasses
{
    //==================================================================
    public class AvancosFolhaServico
    {
        //string contrato, decimal? foseId, string dtInicio, string dtFim, string fcesSigla, decimal? foseQtdPrevista
        public string FsmeCntrCodigo { get; set; }
        public decimal FoseId { get; set; }
        public string DtInicio { get; set; }
        public string DtFim { get; set; }
        public string FcesSigla { get; set; }
        public decimal FoseQtdPrevista { get; set; }
        public string FoseNumero { get; set; }

        public decimal InFsmeId { get; set; }
        public decimal InFsmeFosmId { get; set; }
        public DateTime InFsmeData { get; set; }
        public decimal InFsmeAvancoAcm { get; set; }

        public decimal OutFsmeId { get; set; }
        public decimal OutFsmeFosmId { get; set; }
        public DateTime OutFsmeData { get; set; }
        public decimal OutFsmeAvancoAcm { get; set; }
    }
    //==================================================================
    static public class FolhaServico
    {
        static DataTable dt = null;
        static DataTable dtPercEXEC = null;
        static DataTable dtPercPROG = null;
        static DataTable dtFoseComprimento = null;
        static DataTable dtFoseLocalEstocagem = null;
        static DataRow[] drFoseLocalEstocagem = null;
        static DataTable dtAvancoElementoCriterioSemana = null;

        static int counter, countAP = 0;
        static DTO.CollectionAcControleProducaoDTO cCT = new DTO.CollectionAcControleProducaoDTO();
        static DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        static string strSQL = "";
        static string atpeNome = "";
        static string descricaoAtributo = "";
        static string discAUX = "2,5,6,9,15,20"; //"2,5,6,9,15,20";
        static decimal areaPintura = 0;
        static string filter = "";
        static string exceptionMessage = "";

        static decimal AvancoDentroPeriodo { get ;  set ; }

        //==================================================================
        static public string GetDataCorteUpdateControl(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            string dataCorteUpdateControl = "";
            DTO.AcStatusFoseUpdtCntrlDTO e = new DTO.AcStatusFoseUpdtCntrlDTO();
            e.SfucCntrCodigo = contrato;
            e.SfucDiscId = Convert.ToDecimal(discId);
            e.SfucSbcnSigla = sbcnSigla;
            e.SfucFcmeSigla = fcmeSigla;
            filter = "SFUC_CNTR_CODIGO = '" + e.SfucCntrCodigo + "' AND SFUC_DISC_ID = " + e.SfucDiscId + " AND SFUC_SBCN_SIGLA = '" + e.SfucSbcnSigla + "' AND SFUC_FCME_SIGLA = '" + e.SfucFcmeSigla + "'";
            e = BLL.AcStatusFoseUpdtCntrlBLL.GetObject(filter);

            dataCorteUpdateControl = e.SfucDataCorteUpdateControl.ToString();
            return dataCorteUpdateControl;
        }
        //==================================================================
        static public void SaveDataCorteUpdateControl(DTO.AcStatusFoseUpdtCntrlDTO e)
        {
            string dataCorteUpdateControl = e.SfucDataCorteUpdateControl;
            filter = "SFUC_CNTR_CODIGO = '" + e.SfucCntrCodigo + "' AND SFUC_DISC_ID = " + e.SfucDiscId + " AND SFUC_SBCN_SIGLA = '" + e.SfucSbcnSigla + "' AND SFUC_FCME_SIGLA = '" + e.SfucFcmeSigla + "'";
            int NR = BLL.AcStatusFoseUpdtCntrlBLL.Count(filter);
            if (NR == 0) BLL.AcStatusFoseUpdtCntrlBLL.Insert(e, false);
            else
            {
                e = BLL.AcStatusFoseUpdtCntrlBLL.GetObject(filter);
                e.SfucDataCorteUpdateControl = dataCorteUpdateControl;
                BLL.AcStatusFoseUpdtCntrlBLL.Update(e);
            }
        }
        //==================================================================
        static public string GetFoseComprimento(decimal foseId)
        {
            decimal comprimento = 0;
            string strSQL = @"SELECT SUM(FSIT_QTD_REAL) AS FOSE_COMPRIMENTO 
                                FROM (
                                        SELECT FSIT_CNTR_CODIGO, FOLHA_NUMERO, CODIGO, UNME_SIGLA, FSIT_QTD_REAL, PESO , DESCRICAO
                                          FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM 
                                         WHERE UNME_SIGLA = 'm' 
                                           AND FSIT_FOSE_ID = " + foseId.ToString() + @"
                                     )";
            DataTable dt = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            if (dt.Rows.Count != 0)
            {
                if ((dt.Rows[0][0] != null) && (dt.Rows[0][0] != DBNull.Value))
                {
                    comprimento = Convert.ToDecimal(dt.Rows[0][0]);
                }
            }
            return comprimento.ToString();
        }
        //==================================================================
        static public DataTable GetFoseComprimento()
        {
            string strSQL = @"SELECT FSIT_FOSE_ID, FOLHA_NUMERO, SUM(FSIT_QTD_REAL) AS FOSE_COMPRIMENTO 
                                FROM ( SELECT FSIT_CNTR_CODIGO, FSIT_FOSE_ID, FOLHA_NUMERO, CODIGO, UNME_SIGLA, FSIT_QTD_REAL, PESO , DESCRICAO
                                         FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM 
                                        WHERE DISC_ID = 5 AND LOWER(UNME_SIGLA) = 'm'
                                     )
                            GROUP BY FSIT_FOSE_ID, FOLHA_NUMERO";
            dtFoseComprimento = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            return dtFoseComprimento;
        }
        //==================================================================
        static public decimal GetFoseComprimento(decimal foseId, DataTable dtFoseComprimento)
        {
            decimal comprimento = 0;
            DataRow[] dr = dtFoseComprimento.Select("FSIT_FOSE_ID = " + foseId.ToString(), null);
            if (dr.Count() > 0) comprimento = Convert.ToDecimal(dr[0].ItemArray[2]);
            return comprimento;
        }
        //==================================================================
        static public DataTable GetFoseLocalEstocagem()
        {
            string strSQL = @"SELECT DISTINCT FI.FSIT_TIPO, FSIT_FOSE_ID, EI.FSEI_OBS, EI.FSEI_ARES_ID, EI.FSEI_DT_CADASTRO, AE.ARES_SIGLA, AE.ARES_NOME
                                FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM FI, EEP_CONVERSION.FOLHA_SERVICO_ESTOQUE_ITEM EI, EEP_CONVERSION.AREA_ESTOCAGEM AE
                               WHERE FI.FSIT_ID = EI.FSEI_FSIT_ID 
                                 AND AE.ARES_ID(+) = EI.FSEI_ARES_ID";
            dtFoseLocalEstocagem = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            return dtFoseLocalEstocagem;
        }
        //==================================================================
        private static DataRow[] GetFoseLocalEstocagem(decimal foseId, DataTable dtFoseLocalEstocagem)
        {
            DataRow[] drFoseLocalEstocagem = dtFoseLocalEstocagem.Select("FSIT_FOSE_ID = " + foseId.ToString());
            return drFoseLocalEstocagem;
        }
        //==================================================================
        internal static string GetFosePipeline(string foseNumero)
        {
            try
            {
                string pipeline = "";
                string fst = "";
                string[] snd;
                string[] foseStructure = foseNumero.Split('_');

                if (foseNumero.Substring(0, 1) != "P")
                {
                    fst = foseStructure[0];
                }
                else
                {
                    fst = foseStructure[1];
                }
                snd = fst.Split('-');
                if (snd.Length == 4) pipeline = snd[1] + "-" + snd[2] + "-" + snd[3];
                return pipeline;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
        }
        //==================================================================
        internal static DataTable GetAvancoElementoCriterioSemana(string fsmeDataBase)
        {
            strSQL = @"SELECT FCES_CNTR_CODIGO, FCES_FCME_ID, FCES_WBS, FOSE_ID, FSME_CNTR_CODIGO, FCES_ID, FCES_SIGLA, FOSM_ID, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM, SEMA_ID 
                         FROM EEP_CONVERSION.VW_AC_AVN_ELEM_CRITERIO_SEMANA WHERE FSME_DATA >= TO_DATE('" + fsmeDataBase + "', 'DD/MM/YYYY')";
            DataTable dtAvancoElementoCriterioSemana = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            return dtAvancoElementoCriterioSemana;
        }

        //==================================================================
        static public string GetFoseStatus(decimal foseId, DataTable dtPercEXEC, DataTable dtPercPROG, DataTable dtAvancoElementoCriterioSemana)
        {

            //if (foseId == 199333)
            //{
            //    string x = "";
            //}
            int c = 0;
            decimal perc = 0;
            string status = "";
            DataRow[] drSigla = null;
            DataRow[] rowE = dtPercEXEC.Select("FOSE_ID = " + foseId.ToString());
            c = rowE.Count();
            if (c > 0)
            {

                //FSME_CNTR_CODIGO, FCES_ID, FCES_SIGLA, FOSM_ID, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM, SEMA_ID
                drSigla = dtAvancoElementoCriterioSemana.Select(@"FCES_CNTR_CODIGO = '" + Convert.ToString(rowE[0]["FCES_CNTR_CODIGO"]) +
                                                             @"' AND FCES_FCME_ID = " + Convert.ToString(rowE[0]["FCES_FCME_ID"]) +
                                                             @"  AND FCES_WBS = '" + Convert.ToString(rowE[0]["FCES_WBS"]) +
                                                             @"' AND FOSE_ID = " + Convert.ToString(rowE[0]["FOSE_ID"], null)
                                                           );
                status = strSQL;
                if (drSigla.Count() == 1) status = "Semana " + drSigla[0]["SEMA_ID"].ToString() + " - " + drSigla[0]["FSME_AVANCO_ACM"].ToString() + "% - " + drSigla[0]["FCES_SIGLA"].ToString();
            }
            else
            {
                DataRow[] rowP = dtPercPROG.Select("FOSE_ID = " + foseId.ToString());
                c = rowP.Count();
                if (c > 0)
                {
                    status = "PROGRAMADO " + Convert.ToString(rowP[0]["DATA_AVANCO"]).Substring(0, 10);
                }
                else
                {
                    status = "NÃO PROG";
                }
            }
            return status;
        }
        //==================================================================
        static public string GetFoseProgramacao(decimal foseId, DataTable dtPercPROG)
        {
            int c = 0;
            string programacao = "";
            DataRow[] rowP = dtPercPROG.Select("FOSE_ID = " + foseId.ToString());
            c = rowP.Count();
            if (c > 0)
            {
                programacao = Convert.ToString(rowP[0]["DATA_AVANCO"]).Substring(0, 10);
            }
            return programacao;
        }
        //==================================================================
        static public string GetFoseStatus(decimal foseId, DataTable dtPercEXEC, DataTable dtPercPROG)
        {
            int c = 0;
            decimal perc = 0;
            string status = "";
            DataRow[] rowE = dtPercEXEC.Select("FOSE_ID = " + foseId.ToString());
            c = rowE.Count();
            if (c > 0)
            {
                    strSQL = @" SELECT FSME_CNTR_CODIGO, FCES_ID, FCES_SIGLA, FOSM_ID, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM, SEMA_ID
                                    FROM
                                    (
                                        SELECT FSME_CNTR_CODIGO, FCES_ID, FCES_SIGLA, FOSM_ID, MAX(FSME_DATA) AS FSME_DATA, MAX(ROUND(FSME_AVANCO_ACM, 2)) AS FSME_AVANCO_ACM, MAX(ROUND(FSME_QTD_ACM, 2)) AS FSME_QTD_ACM
                                          FROM EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC, EEP_CONVERSION.FOLHA_SERVICO
                                         WHERE FCES_CNTR_CODIGO = '" + Convert.ToString(rowE[0]["FCES_CNTR_CODIGO"]) + 
                                           @"' AND FCES_FCME_ID = " + Convert.ToString(rowE[0]["FCES_FCME_ID"]) + 
                                           @"  AND FCES_WBS = '" + Convert.ToString(rowE[0]["FCES_WBS"]) + 
                                           @"' AND FOSE_ID = " + Convert.ToString(rowE[0]["FOSE_ID"]) + 
                                           @"  AND FOSM_CNTR_CODIGO = FCES_CNTR_CODIGO AND FOSM_FCES_ID = FCES_ID
                                           AND FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                           AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                         GROUP BY FSME_CNTR_CODIGO, FCES_ID, FCES_SIGLA, FOSM_ID
                                         ORDER BY FCES_ID, FCES_SIGLA, FOSM_ID
                                    )
                                    , EEP_CONVERSION.AC_SEMANA
                                    WHERE SEMA_CNTR_CODIGO = FSME_CNTR_CODIGO AND TO_DATE(TO_CHAR(FSME_DATA,'DD/MM/YYYY'),'DD/MM/YYYY') BETWEEN TO_DATE(TO_CHAR(SEMA_DATA_INICIO,'DD/MM/YYYY'),'DD/MM/YYYY') AND TO_DATE(TO_CHAR(SEMA_DATA_FIM,'DD/MM/YYYY'),'DD/MM/YYYY') ";
                    
                    DataTable dtSigla = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                    //status = perc.ToString() + "% - " + dtSigla.Rows[0]["FCES_SIGLA"].ToString() + " - Semana " + dtSigla.Rows[0]["SEMA_ID"].ToString();
                    status = strSQL;
                    if (dtSigla.Rows.Count == 1) status = "Semana " + dtSigla.Rows[0]["SEMA_ID"].ToString() + " - " + dtSigla.Rows[0]["FSME_AVANCO_ACM"].ToString() + "% - " + dtSigla.Rows[0]["FCES_SIGLA"].ToString();
                //}
            }
            else
            {
                DataRow[] rowP = dtPercPROG.Select("FOSE_ID = " + foseId.ToString());
                c = rowP.Count();
                if (c > 0)
                {
                    status = "PROGRAMADO " + Convert.ToString(rowP[0]["DATA_AVANCO"]).Substring(0, 10);
                }
                else
                {
                    status = "NÃO PROG";
                }
            }
            return status;
        }

        //==================================================================
        /// <param name="contrato">Contrato</param>
        /// <param name="discId">Disciplina</param>
        public static void GerarStatusFOSE(string contrato, string discId, string rangeCalc)
        {
            //Obtém a semana corrente
            s = BLL.AcSemanaBLL.GetSemanaCorrente();
            GerarStatusFOSE(contrato, discId, s.SemaId, rangeCalc);
        }
        //==================================================================
        /// <param name="contrato">Contrato</param>
        /// <param name="discId">Disciplina</param>
        /// <param name="semaId">Semana desejada para o cálculo do Status de Folha de Serviço</param>
        public static void GerarStatusFOSE(string contrato, string discId, decimal semaId, string rangeCalc)
        {
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = BLL.AcSemanaBLL.GetObject("SEMA_ID = " + semaId.ToString());
            string dtInicial = s.SemaDataInicio.AddDays(-1).ToString("dd/MM/yyyy");
            //string dtFinal = s.SemaDataFim.ToString("dd/MM/yyyy");
            string dtFinal = s.SemaDataFim.AddDays(1).ToString("dd/MM/yyyy");
            GerarStatusFOSE(contrato, discId, dtInicial, dtFinal, rangeCalc);
        }
        /// <param name="contrato">Contrato</param>
        /// <param name="contrato">Contrato</param>
        /// <param name="discId">Disciplina</param>
        /// <param name="dtInicial">Data do início da Semana desejada para o cálculo do Status de Folha de Serviço</param>
        /// <param name="dtFinal">Data do final da Semana desejada para o cálculo do Status de Folha de Serviço</param>
        public static void GerarStatusFOSE(string contrato, string discId, string dtInicial, string dtFinal, string rangeCalc)
        {
            if (rangeCalc == "All") dtInicial = "22/06/2012";
            strSQL = GetQuerySelecaoFOSE(contrato, discId, dtInicial, dtFinal, rangeCalc);
            dt = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            counter = dt.Rows.Count;
            GerarStatusFOSE(contrato, dt, discId, true, dtInicial, rangeCalc);
        }
        //==================================================================
        private static string GetQuerySelecaoFOSE(string contrato, string discId, string dtInicial, string dtFinal, string rangeCalc)
        {
            string strSQL = "";
            if (rangeCalc == "All") strSQL = GetAllDiscFOSE(contrato, discId, dtInicial, dtFinal);
            else strSQL = GetRangeDiscFOSE(contrato, discId, dtInicial, dtFinal);
            return strSQL;
        }
        //==================================================================
        private static string GetAllDiscFOSE(string contrato, string discId, string dtInicial, string dtFinal)
        {
            //Seleciona todas as folhas de serviço da disciplina selecionada na lista de disciplinas COM AVANÇOS EXECUTADOS (no período!?)
            string strSQL = @"SELECT    FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                        FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, QTD_ACUMULADA, FSME_AVANCO_ACM,
                                        FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID, FSME_DATA
                                FROM (          
                                        SELECT 
                                                FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                                FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, MAX(FSME_DATA) AS FSME_DATA, ROUND(MAX(FSME_QTD_ACM),2) AS QTD_ACUMULADA, ROUND(MAX(FSME_AVANCO_ACM),2) AS FSME_AVANCO_ACM,
                                                FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                                        FROM
                                                EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO,
                                                EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC
                                        WHERE 
                                                FOSE_CNTR_CODIGO = '" + contrato + @"' AND SIFS_DESCRICAO != ' ' --AND FOSE_NUMERO = 'M-CVTQ1B-02-00R'
                                        AND  FSME_CNTR_CODIGO(+) = FOSE_CNTR_CODIGO AND  FSME_FOSM_ID(+) = FOSM_ID 
                                        --AND  DISC_ID IN (" + discAUX + @") 
                                        AND  DISC_ID = " + discId + @" 
                                        GROUP BY   FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                                FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, --FSME_DATA, 
                                                FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                                    )                                    
                            ORDER  BY DISC_ID DESC, FSME_DATA DESC, FOSE_ID
                ";
                return strSQL;
        }
        //==================================================================
        private static string GetRangeDiscFOSE(string contrato, string discId, string dtInicial, string dtFinal)
        {
            string strSQL = @"
                        SELECT  FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, 
                                FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID,
                                MAX(QTD_ACUMULADA) AS QTD_ACUMULADA, MAX(FSME_AVANCO_ACM) AS FSME_AVANCO_ACM, MAX(FSME_DATA) AS MAX_FSME_DATA
                          FROM(
                                SELECT FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                       FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, QTD_ACUMULADA, FSME_AVANCO_ACM,
                                       FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID, FSME_DATA
                                  FROM (          
                                        SELECT 
                                                FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                                FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FSME_DATA, ROUND(MAX(FSME_QTD_ACM),2) AS QTD_ACUMULADA, ROUND(MAX(FSME_AVANCO_ACM),2) AS FSME_AVANCO_ACM,
                                                FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                                          FROM
                                                EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO,
                                                EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC
                                          WHERE 
                                                FOSE_CNTR_CODIGO = '" + contrato + @"' 
                                                AND  FSME_CNTR_CODIGO(+) = FOSE_CNTR_CODIGO AND  FSME_FOSM_ID(+) = FOSM_ID 
                                                --AND  DISC_ID IN (" + discAUX + @")
                                                AND  DISC_ID = " + discId + @" 
                                                --AND FOSE_ID = 427978
                                                AND FOSE_ID IN
                                                        (
                                                            SELECT DISTINCT U.FOSE_ID FROM
                                                            (
                                                                SELECT VE.FOSE_ID
                                                                    FROM
                                                                        EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO VE,
                                                                        EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC E
                                                                    WHERE 
                                                                        VE.FOSE_CNTR_CODIGO = '" + contrato + @"' 
                                                                    AND E.FSME_CNTR_CODIGO(+) = VE.FOSE_CNTR_CODIGO AND  E.FSME_FOSM_ID(+) = VE.FOSM_ID 
                                                                    --AND VE.DISC_ID IN (" + discAUX + @") 
                                                                    AND VE.DISC_ID = " + discId + @"  
                                                                    AND E.FSME_DATA BETWEEN TO_DATE('" + dtInicial + @"', 'DD/MM/YYYY') AND TO_DATE('" + dtFinal + @"', 'DD/MM/YYYY')
                                                                    GROUP BY VE.FOSE_ID
                                                                UNION
                                                                SELECT VP.FOSE_ID
                                                                    FROM
                                                                        EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO VP,
                                                                        EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG P
                                                                    WHERE 
                                                                        VP.FOSE_CNTR_CODIGO = '" + contrato + @"' 
                                                                    AND  P.FSMP_CNTR_CODIGO(+) = VP.FOSE_CNTR_CODIGO AND P.FSMP_FOSM_ID(+) = VP.FOSM_ID 
                                                                    --AND  VP.DISC_ID IN (" + discAUX + @") 
                                                                    AND  VP.DISC_ID = " + discId + @"
                                                                    AND  P.FSMP_DATA BETWEEN TO_DATE('" + dtInicial + @"', 'DD/MM/YYYY') AND TO_DATE('" + dtFinal + @"', 'DD/MM/YYYY')
                                                                    GROUP BY VP.FOSE_ID
                                                                UNION
                                                                SELECT FS.FOSE_ID
                                                                  FROM EEP_CONVERSION.FOLHA_SERVICO FS
                                                                 WHERE FS.FOSE_CNTR_CODIGO = '" + contrato + @"' 
                                                                   AND FS.FOSE_DISC_ID = " + discId + @"
                                                                   AND FS.FOSE_ID NOT IN (
                                                                                            SELECT CF.FOSE_ID 
                                                                                              FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO CF 
                                                                                             WHERE CF.FOSE_CNTR_CODIGO = '" + contrato + @"' 
                                                                                               AND CF.DISC_ID = " + discId + @"
                                                                                         )
                                                                ) U
                                                        )
                                        GROUP BY   FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, 
                                                    FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
                                                    FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FSME_DATA, 
                                                    FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                                    )                                    
                            ORDER  BY DISC_ID DESC, FSME_DATA DESC, FOSE_ID
                        )
                        GROUP BY FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, 
                                 FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
                        ORDER BY FOSE_ID
                    ";
            return strSQL;
        }
        //==================================================================
        // Gera Status das FOSEs selecionadas a atualiza controle AC_STATUS_FOSE_UPDT_CNTRL
        /// <param name="contrato">Contrato</param>
        /// <param name="contrato">dt - Folhas de servico a terem Status atualizado</param>  
        public static void GerarStatusFOSE(string contrato, DataTable dtFolhasServico, string discId, bool batchExecution, string fsmeDataBase, string rangeCalc)
        {
            #region Avanços percentuais EXECUTADOS da disciplina
            //Todos os avanços percentuais executados da disciplina
            strSQL = @"SELECT DISTINCT FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_ID, FCME_SIGLA, AVANCO, DATA_AVANCO, FCES_WBS, FCES_FCME_ID
FROM (
SELECT FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_ID, FCME_SIGLA, MAX(AVANCO) AS AVANCO, MAX(DATA_AVANCO) AS DATA_AVANCO, MAX(FCES_WBS) AS FCES_WBS, MAX(FCES_FCME_ID) AS FCES_FCME_ID
  FROM
  (
  SELECT FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_ID, FCME_SIGLA, FCES_ID, ROUND(MAX(FSME_AVANCO_ACM),2) AS AVANCO, MAX(FCES_WBS) AS FCES_WBS, MAX(FCES_FCME_ID) AS FCES_FCME_ID, MAX(FSME_DATA) AS DATA_AVANCO FROM 
                         (
                              SELECT FCES_CNTR_CODIGO, FOSE_ID,FOSE_NUMERO, FCME_ID, FCME_SIGLA, FCES_ID, FCES_WBS, FCES_FCME_ID, FSME_AVANCO_ACM, FSME_DATA
                                FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC,       EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,           EEP_CONVERSION.FOLHA_SERVICO, 
                                     EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,         EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                               WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                 AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                 AND FCME_CNTR_CODIGO = FOSE_CNTR_CODIGO AND FCME_ID = FOSE_FCME_ID
                                 AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                 AND LENGTH(FCES_WBS) > 2 AND FOSE_CNTR_CODIGO = '" + contrato + @"'
                                 AND FOSE_DISC_ID = " + discId + @" 
                               ORDER BY FCES_WBS, FCES_SIGLA, FSME_DATA DESC
                         )
                        GROUP BY FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_ID, FCME_SIGLA, FCES_ID
                        ORDER BY FOSE_NUMERO
  )
  GROUP BY FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_ID, FCME_SIGLA
ORDER BY FOSE_NUMERO
)
                      ";
            dtPercEXEC = BLL.AcControleFolhaServicoBLL.SelectAvnFoseFromDataReader(strSQL);
            #endregion

            #region Avanços percentuais PROGRAMADOS da disciplina
                //Todos os avanços percentuais programados da disciplina
                strSQL = @"SELECT FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_SIGLA, ROUND(MAX(FSMP_AVANCO_ACM),2) AS AVANCO, MAX(FCES_WBS) AS FCES_WBS, MAX(FCES_FCME_ID) AS FCES_FCME_ID, MAX(FSMP_DATA) AS DATA_AVANCO FROM 
                           (
                                SELECT FCES_CNTR_CODIGO, FOSE_ID,FOSE_NUMERO, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FCES_FCME_ID, FSMP_AVANCO_ACM, FSMP_DATA
                                  FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG,       EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,           EEP_CONVERSION.FOLHA_SERVICO,                                                                 EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,         EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                                 WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                   AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                   AND FCME_CNTR_CODIGO = FOSE_CNTR_CODIGO AND FCME_ID = FOSE_FCME_ID
                                   AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                   AND LENGTH(FCES_WBS) > 2 AND FOSE_CNTR_CODIGO = '" + contrato + @"'
                                   AND FOSE_DISC_ID = " + discId + @" 
                                 ORDER BY FCES_WBS, FCES_SIGLA, FSMP_DATA DESC
                           )
                          GROUP BY FCES_CNTR_CODIGO, FOSE_ID, FOSE_NUMERO, FCME_SIGLA
                          ";
                dtPercPROG = BLL.AcControleFolhaServicoBLL.SelectAvnFoseFromDataReader(strSQL);
            #endregion

            #region FoseComprimento
                //Todos os Comprimentos de folhas de servico de Tubulacao (discId = 5)
                if(discId == "5") dtFoseComprimento = GetFoseComprimento();
            #endregion

            #region FoseLocalEstocagem
                //Todos os Locais de Estocagem de folhas de servico de Tubulacao (discId = 5)
                dtFoseLocalEstocagem = GetFoseLocalEstocagem();
            #endregion

            #region Avancos Folha Servico
                //Todos os Avanços dos Elementos dos Criterios de Medição nas semanas
                dtAvancoElementoCriterioSemana = GetAvancoElementoCriterioSemana(fsmeDataBase);
            #endregion

            //Elimina todos os registros de FOSE da tabela AC_CONTROLE_FOLHA_SERVICO que já foram eliminadas no SISEPC 
                
            #region Delete By SISEPC
                strSQL = @"DELETE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO DF 
                        WHERE DF.FOSE_ID IN 
                                ( SELECT CF.FOSE_ID FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO CF WHERE CF.FOSE_ID NOT IN ( SELECT FS.FOSE_ID FROM EEP_CONVERSION.FOLHA_SERVICO FS) )";
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
            #endregion
                
            strSQL = "";
            //Varre as Folhas de Serviço do período
            for (int i = 0; i < dtFolhasServico.Rows.Count; i++)
            {
                exceptionMessage = "Registro i = " + i.ToString();
                DTO.AcControleFolhaServicoDTO ap = new DTO.AcControleFolhaServicoDTO();
                ap.FoseId = Convert.ToDecimal(dtFolhasServico.Rows[i]["FOSE_ID"]);
                //if (ap.FoseId == 359782)
                //{
                //    string x = "";
                //}
                countAP = BLL.AcControleFolhaServicoBLL.Count("FOSE_ID = " + Convert.ToString(dtFolhasServico.Rows[i]["FOSE_ID"]));

                if ((dtFolhasServico.Rows[i]["SBCN_ID"] != null) && (dtFolhasServico.Rows[i]["SBCN_ID"] != DBNull.Value)) ap.SbcnId = Convert.ToDecimal(dtFolhasServico.Rows[i]["SBCN_ID"]);
                ap.FoseCntrCodigo = contrato;
                ap.SbcnSigla = Convert.ToString(dtFolhasServico.Rows[i]["SBCN_SIGLA"]);
                ap.DiscId = Convert.ToDecimal(dtFolhasServico.Rows[i]["DISC_ID"]);
                ap.DiscNome = Convert.ToString(dtFolhasServico.Rows[i]["DISC_NOME"]);

                ap.FoseNumero = Convert.ToString(dtFolhasServico.Rows[i]["FOSE_NUMERO"]);
                ap.FoseRev = Convert.ToString(dtFolhasServico.Rows[i]["FOSE_REV"]);
                ap.FoseDescricao = Convert.ToString(dtFolhasServico.Rows[i]["FOSE_DESCRICAO"]);
                ap.UnmeSigla = Convert.ToString(dtFolhasServico.Rows[i]["UNME_SIGLA"]);
                
                ////Batch Execution
                //if (batchExecution) ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG, dtAvancoElementoCriterioSemana);
                //else ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG);
                ap.Programacao = GenericClasses.FolhaServico.GetFoseProgramacao(ap.FoseId, dtPercPROG);
                ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG, dtAvancoElementoCriterioSemana);
                
                if (rangeCalc == "All") 
                    { 
                        if ((dtFolhasServico.Rows[i]["FSME_DATA"] != null) && (dtFolhasServico.Rows[i]["FSME_DATA"] != DBNull.Value)) ap.MaxFsmeData = Convert.ToDateTime(dtFolhasServico.Rows[i]["FSME_DATA"]);
                    }
                else 
                    { 
                        if ((dtFolhasServico.Rows[i]["MAX_FSME_DATA"] != null) && (dtFolhasServico.Rows[i]["MAX_FSME_DATA"] != DBNull.Value)) ap.MaxFsmeData = Convert.ToDateTime(dtFolhasServico.Rows[i]["MAX_FSME_DATA"]); 
                    }

                if (ap.MaxFsmeData.Year >= 2012) ap.SemanaFolha = BLL.AcSemanaBLL.GetSemanaByFoseStatus(ap.FoseStatus);
                else ap.MaxFsmeData = Convert.ToDateTime("01/01/01"); 

                ap.SifsDescricao = Convert.ToString(dtFolhasServico.Rows[i]["SIFS_DESCRICAO"]);
                if ((dtFolhasServico.Rows[i]["FOSE_QTD_PREVISTA"] != null) && (dtFolhasServico.Rows[i]["FOSE_QTD_PREVISTA"] != DBNull.Value)) ap.FoseQtdPrevista = Convert.ToDecimal(dtFolhasServico.Rows[i]["FOSE_QTD_PREVISTA"]);
                if ((dtFolhasServico.Rows[i]["QTD_ACUMULADA"] != null) && (dtFolhasServico.Rows[i]["QTD_ACUMULADA"] != DBNull.Value)) ap.QtdAcumulada = Convert.ToDecimal(dtFolhasServico.Rows[i]["QTD_ACUMULADA"]);

                //Comprimento - Válido apenas para Tubulação
                if(ap.DiscId == 5)  ap.FoseComprimento = GenericClasses.FolhaServico.GetFoseComprimento(ap.FoseId, dtFoseComprimento);

                ap.FcmeSigla = Convert.ToString(dtFolhasServico.Rows[i]["FCME_SIGLA"]);
                ap.FcesSigla = Convert.ToString(dtFolhasServico.Rows[i]["FCES_SIGLA"]);

                //LOCAL DE ESTOCAGEM - Válido apenas para Tubulação
                if (ap.DiscId == 5)
                {
                    drFoseLocalEstocagem = GenericClasses.FolhaServico.GetFoseLocalEstocagem(ap.FoseId, dtFoseLocalEstocagem);
                    if (drFoseLocalEstocagem.Count() > 0)
                    {
                        ap.StatusTratamento = drFoseLocalEstocagem[0]["FSEI_OBS"].ToString();
                        ap.DtStatusTratamento = Convert.ToDateTime(drFoseLocalEstocagem[0]["FSEI_DT_CADASTRO"]);
                        ap.LocalEstocagem = drFoseLocalEstocagem[0]["ARES_NOME"].ToString();
                    }
                }
                //Salva registro
                if (countAP == 0)
                {
                    try
                    {
                        atpeNome = Convert.ToString(dtFolhasServico.Rows[i]["ATPE_NOME"]).ToUpper();
                        if (atpeNome != "" && atpeNome != null)
                        {
                            descricaoAtributo = Convert.ToString(dtFolhasServico.Rows[i]["DESCRICAO_ATRIBUTO"]);
                            switch (atpeNome)
                            {
                                case "EQUIPE": { ap.Equipe = descricaoAtributo; break; } //Equipe
                                case "SETOR": { ap.Setor = descricaoAtributo; break; } //Setor
                                case "LOCALIZAÇÃO": { ap.Localizacao = descricaoAtributo; break; } //Localização
                                case "LOCALIZACAO": 
                                    { ap.Localizacao = descricaoAtributo; break; } //Localização
                                case "DESENHO": { ap.Desenho = descricaoAtributo; break; } //Desenho
                                case "ORIGEM DE FABRICAÇÃO": { ap.OrigemFabricacao = descricaoAtributo; break; }
                                case "ÁREA DE PINTURA (M2)":  //Área de pintura (m2)
                                    {
                                        areaPintura = Convert.ToDecimal(dtFolhasServico.Rows[i]["AREA_PINTURA"]) / 1000;
                                        ap.AreaPintura = areaPintura.ToString("n2");  //GenericClasses.Util.FormataString("#########.##",areaPintura.ToString()); 
                                        break;
                                    }
                                case "CLASSIFICADO": { ap.Classificado = descricaoAtributo; break; } //Classificado
                                case "DESCRIÇÃO DA ESTRUTURA": { ap.DescricaoEstrutura = descricaoAtributo; break; } //Descrição da Estrutura
                                case "DIAM": { ap.Diam = descricaoAtributo; break; } // Diam
                                case "EMPRESA RESPONSÁVEL": { ap.EmpresaResponsavel = descricaoAtributo; break; }
                                case "NOTA": { ap.Nota = descricaoAtributo; break; } //Nota
                                case "REGIAO": { ap.Regiao = descricaoAtributo; break; } //Regiao
                                case "SEMANA": { ap.SemanaFolha = descricaoAtributo; break; } //Semana
                                case "SISTEMA": { ap.Sistema = descricaoAtributo; break; } //Sistema
                                case "SPEC": { ap.Spec = descricaoAtributo; break; } //Spec
                                case "TRATAMENTO": { ap.Tratamento = descricaoAtributo; break; } //Tratamento
                            }
                        }
                        else
                        {
                            ap.Indefinido = "ATPE_NOME ou ATPI_TEXTO indefinido: " + ap.FoseNumero + " ==> " + atpeNome + " - " + descricaoAtributo;
                        }
                        BLL.AcControleFolhaServicoBLL.Insert(ap, false);
                    }
                    catch (Exception ex) 
                    {
                        exceptionMessage += " - Insert Controle Folha Serviço - " + ex.Message;
                        throw new Exception(exceptionMessage); 
                    }
                }
                else
                {
                    try
                    {
                        ap = BLL.AcControleFolhaServicoBLL.GetObject("FOSE_ID = " + ap.FoseId.ToString());
                        atpeNome = Convert.ToString(dtFolhasServico.Rows[i]["ATPE_NOME"]).ToUpper();
                        if (atpeNome != "" && atpeNome != null)
                        {
                            descricaoAtributo = Convert.ToString(dtFolhasServico.Rows[i]["DESCRICAO_ATRIBUTO"]);
                            switch (atpeNome)
                            {
                                case "EQUIPE":
                                    {
                                        ap.Equipe = descricaoAtributo; break;  //Equipe
                                    }
                                case "SETOR": { ap.Setor = descricaoAtributo; break; } //Setor
                                case "LOCALIZAÇÃO": { ap.Localizacao = descricaoAtributo; break; } //Localização
                                case "LOCALIZACAO": 
                                    { ap.Localizacao = descricaoAtributo; break; } //Localização
                                case "DESENHO": { ap.Desenho = descricaoAtributo; break; } //Desenho
                                case "ORIGEM DE FABRICAÇÃO": { ap.OrigemFabricacao = descricaoAtributo; break; }
                                case "ÁREA DE PINTURA (M2)":  //Área de pintura (m2)
                                    {
                                        areaPintura = Convert.ToDecimal(dtFolhasServico.Rows[i]["AREA_PINTURA"]) / 1000;
                                        ap.AreaPintura = areaPintura.ToString("n2");
                                        break;
                                    }
                                case "CLASSIFICADO": { ap.Classificado = descricaoAtributo; break; } //Classificado
                                case "DESCRIÇÃO DA ESTRUTURA": { ap.DescricaoEstrutura = descricaoAtributo; break; } //Descrição da Estrutura
                                case "DIAM": { ap.Diam = descricaoAtributo; break; } // Diam
                                case "EMPRESA RESPONSÁVEL": { ap.EmpresaResponsavel = descricaoAtributo; break; }
                                case "NOTA": { ap.Nota = descricaoAtributo; break; } //Nota
                                case "REGIAO": { ap.Regiao = descricaoAtributo; break; } //Regiao
                                case "SEMANA": { ap.SemanaFolha = descricaoAtributo; break; } //Semana
                                case "SISTEMA": { ap.Sistema = descricaoAtributo; break; } //Sistema
                                case "SPEC": { ap.Spec = descricaoAtributo; break; } //Spec
                                case "TRATAMENTO": { ap.Tratamento = descricaoAtributo; break; } //Tratamento
                            }
                        }
                        else
                        {
                            ap.Indefinido = "ATPE_NOME ou ATPI_TEXTO indefinido: " + ap.FoseNumero + " ==> " + atpeNome + " - " + descricaoAtributo;
                        }
                        ////Batch Execution
                        //if (batchExecution) ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG, dtAvancoElementoCriterioSemana);
                        //else ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG);

                        ap.Programacao = GenericClasses.FolhaServico.GetFoseProgramacao(ap.FoseId, dtPercPROG);
                        ap.FoseStatus = GenericClasses.FolhaServico.GetFoseStatus(ap.FoseId, dtPercEXEC, dtPercPROG, dtAvancoElementoCriterioSemana);
                        BLL.AcControleFolhaServicoBLL.Update(ap);
                    }
                    catch (Exception ex)
                    {
                        exceptionMessage += " - Update Controle Folha Serviço - " + ex.Message;
                        throw new Exception(exceptionMessage);
                    }
                }
            }
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
         }
        //==================================================================
        public static void RealizaCapturaSISEPC(string contrato)
        {
            strSQL = @"SELECT FSME_CNTR_CODIGO,  FSME_ID,  FSME_FOSM_ID, FSME_DATA, TO_CHAR(FSME_DATA, 'DD/MM/YYYY HH24:MI:SS') AS FSME_DATA_TEXT, ROUND(FSME_AVANCO_ACM, 15) AS FSME_AVANCO_ACM, ROUND(FSME_QTD_ACM, 15) AS FSME_QTD_ACM,  FSME_SIFS_ID,  FSME_OBS, FSME_DT_CADASTRO, TO_CHAR(FSME_DT_CADASTRO, 'DD/MM/YYYY HH24:MI:SS') AS FSME_DT_CADASTRO_TEXT FROM  EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC 
--WHERE TO_CHAR(FSME_DATA, 'HH24:MI:SS') != '00:00:00'";
            DataTable dtAvancos = BLL.AcAvancoBkpBLL.Select(strSQL);
            DTO.CollectionAcAvancoBkpDTO col = new DTO.CollectionAcAvancoBkpDTO();
            for (int i = 0; i < dtAvancos.Rows.Count; i++)
            {
                try
                {
                    DTO.AcAvancoBkpDTO av = new DTO.AcAvancoBkpDTO();
                    av.FsmeCntrCodigo = Convert.ToString(dtAvancos.Rows[i]["FSME_CNTR_CODIGO"]);
                    av.FsmeId = Convert.ToDecimal(dtAvancos.Rows[i]["FSME_ID"]);
                    av.FsmeFosmId = Convert.ToDecimal(dtAvancos.Rows[i]["FSME_FOSM_ID"]);
                    if ((dtAvancos.Rows[i]["FSME_DATA"] != null) && (dtAvancos.Rows[i]["FSME_DATA"] != DBNull.Value)) av.FsmeData = Convert.ToDateTime(dtAvancos.Rows[i]["FSME_DATA"]);
                    if ((dtAvancos.Rows[i]["FSME_DATA_TEXT"] != null) && (dtAvancos.Rows[i]["FSME_DATA_TEXT"] != DBNull.Value)) av.FsmeDataText = Convert.ToString(dtAvancos.Rows[i]["FSME_DATA_TEXT"]);
                    if ((dtAvancos.Rows[i]["FSME_AVANCO_ACM"] != null) && (dtAvancos.Rows[i]["FSME_AVANCO_ACM"] != DBNull.Value)) av.FsmeAvancoAcm = Convert.ToDecimal(dtAvancos.Rows[i]["FSME_AVANCO_ACM"].ToString().Replace(",", "."));
                    else av.FsmeAvancoAcm = null;
                    if ((dtAvancos.Rows[i]["FSME_QTD_ACM"] != null) && (dtAvancos.Rows[i]["FSME_QTD_ACM"] != DBNull.Value)) av.FsmeQtdAcm = Convert.ToDecimal(dtAvancos.Rows[i]["FSME_QTD_ACM"].ToString().Replace(",", "."));
                    else av.FsmeQtdAcm = null;
                    if ((dtAvancos.Rows[i]["FSME_SIFS_ID"] != null) && (dtAvancos.Rows[i]["FSME_SIFS_ID"] != DBNull.Value)) av.FsmeSifsId = Convert.ToDecimal(dtAvancos.Rows[i]["FSME_SIFS_ID"]);
                    else av.FsmeSifsId = null;
                    if ((dtAvancos.Rows[i]["FSME_OBS"] != null) && (dtAvancos.Rows[i]["FSME_OBS"] != DBNull.Value)) av.FsmeObs = Convert.ToString(dtAvancos.Rows[i]["FSME_OBS"]);
                    else av.FsmeObs = null;
                    av.FsmeDtCadastro = Convert.ToDateTime(dtAvancos.Rows[i]["FSME_DT_CADASTRO"]);
                    av.FsmeDtCadastroText = Convert.ToString(dtAvancos.Rows[i]["FSME_DT_CADASTRO_TEXT"]);
                    SaveAvanco(av);
                 }
                    catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
        //==================================================================
        private static void SaveAvanco(DTO.AcAvancoBkpDTO av)
        {
            int c = 0;
            StringBuilder sbFilter = new StringBuilder();
            sbFilter.Append("FSME_CNTR_CODIGO = '" + av.FsmeCntrCodigo + "' AND ");
            sbFilter.Append("FSME_ID = " + av.FsmeId.ToString() + " AND ");
            sbFilter.Append("FSME_FOSM_ID = " + av.FsmeFosmId.ToString() + " AND ");
            sbFilter.Append("FSME_DATA_TEXT = '" + av.FsmeData.ToString() + "' AND ");
            
            if (av.FsmeAvancoAcm != null) sbFilter.Append("FSME_AVANCO_ACM = " + av.FsmeAvancoAcm.ToString() + " AND ");
            else sbFilter.Append("FSME_AVANCO_ACM IS NULL AND ");
            
            if (av.FsmeQtdAcm != null) sbFilter.Append("FSME_QTD_ACM = " + av.FsmeQtdAcm.ToString() + " AND ");
            else sbFilter.Append("FSME_QTD_ACM IS NULL AND ");

            if (av.FsmeSifsId != null) sbFilter.Append("FSME_SIFS_ID = " + av.FsmeSifsId.ToString() + " AND ");
            else sbFilter.Append("FSME_SIFS_ID IS NULL AND ");

            if (av.FsmeObs != null) sbFilter.Append("FSME_OBS = '" + av.FsmeObs + "' AND ");
            else sbFilter.Append("FSME_OBS IS NULL AND ");
            
            sbFilter.Append("FSME_DT_CADASTRO_TEXT = '" + av.FsmeDtCadastroText + "'");

            filter = sbFilter.ToString();
            c = BLL.AcAvancoBkpBLL.Count(filter);
            if (c == 0)
            {
                try
                {
                    av.AvbkId = GetSequence();
                    BLL.AcAvancoBkpBLL.Insert(av, false);
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }
        //==================================================================
        private static decimal GetSequence()
        {
            decimal sequence = 0;
            string strSQL = "SELECT MAX(AVBK_ID) FROM EEP_CONVERSION.AC_AVANCO_BKP";
            DataTable dt = BLL.AcAvancoBkpBLL.Select(strSQL);
            if (dt.Rows[0][0].ToString() == "") sequence = 1;
            else sequence = Convert.ToDecimal(dt.Rows[0][0]) + 1;
            return sequence;
        }
        //==================================================================
        public static GenericClasses.AvancosFolhaServico GetAvancosFolhaServico(string contrato, decimal? foseId, string dtInicio, string dtFim, string fcesSigla, decimal? foseQtdPrevista)
        {
            GenericClasses.AvancosFolhaServico avancosFolhaServico = new GenericClasses.AvancosFolhaServico();
            DataTable dt = null;
            avancosFolhaServico.FsmeCntrCodigo = contrato;
            avancosFolhaServico.FoseId = (decimal)foseId;
            avancosFolhaServico.DtInicio = dtInicio;
            avancosFolhaServico.DtFim = dtFim;
            avancosFolhaServico.FcesSigla = fcesSigla;
            avancosFolhaServico.FoseQtdPrevista = (decimal)foseQtdPrevista;
            try
            {
                strSQL = @"SELECT FSME_ID, FSME_FOSM_ID, FSME_DATA, FOSE_NUMERO, ROUND(NVL(MAX(FSME_AVANCO_ACM),0),6) AS FSME_AVANCO_ACM
                             FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO, EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA
                            WHERE FOSE_CNTR_CODIGO = '" + contrato + @"' 
                               AND FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                               AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                               AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                               AND TO_DATE(TO_CHAR(FSME_DATA, 'DD/MM/YY'), 'DD/MM/YY') >= TO_DATE('" + dtInicio + @"', 'DD/MM/YY') 
                               AND TO_DATE(TO_CHAR(FSME_DATA, 'DD/MM/YY'), 'DD/MM/YY') <= TO_DATE('" + dtFim + @"', 'DD/MM/YY')
--AND FOSM_FOSE_ID = 79849
                               AND FOSM_FOSE_ID = " + foseId + @" 
                               AND FCES_SIGLA = '" + fcesSigla + @"' 
                             GROUP BY FSME_ID, FSME_FOSM_ID, FSME_DATA, FOSE_NUMERO
                          ";
                dt = BLL.AcRamAtividadeBLL.Select(strSQL);
                if (dt.Rows.Count != 0)
                {
                    avancosFolhaServico.InFsmeId = Convert.ToDecimal(dt.Rows[0]["FSME_ID"]);
                    avancosFolhaServico.InFsmeFosmId = Convert.ToDecimal(dt.Rows[0]["FSME_FOSM_ID"]);
                    avancosFolhaServico.InFsmeData = Convert.ToDateTime(dt.Rows[0]["FSME_DATA"]);
                    avancosFolhaServico.InFsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSME_AVANCO_ACM"]);
                    avancosFolhaServico.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
                }

                strSQL = @"SELECT FSME_ID, FSME_FOSM_ID, FSME_DATA, FOSE_NUMERO, ROUND(NVL(MAX(FSME_AVANCO_ACM),0),6) AS FSME_AVANCO_ACM
                             FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC, EEP_CONVERSION.FOLHA_SERVICO_MEDICAO, EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA
                            WHERE FOSE_CNTR_CODIGO = '" + contrato + @"' 
                               AND FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                               AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                               AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                               AND TO_DATE(TO_CHAR(FSME_DATA, 'DD/MM/YY'), 'DD/MM/YY') < TO_DATE('" + dtInicio + @"', 'DD/MM/YY') 
                               AND TO_DATE(TO_CHAR(FSME_DATA, 'DD/MM/YYYY'), 'DD/MM/YYYY') >= TO_DATE('23/06/2012', 'DD/MM/YYYY')
--AND FOSM_FOSE_ID = 79849
                               AND FOSM_FOSE_ID = " + foseId + @" 
                               AND FCES_SIGLA = '" + fcesSigla + @"'
                             GROUP BY FSME_ID, FSME_FOSM_ID, FSME_DATA, FOSE_NUMERO
                          ";
                dt = BLL.AcRamAtividadeBLL.Select(strSQL);
                if (dt.Rows.Count != 0)
                {
                    avancosFolhaServico.OutFsmeId = Convert.ToDecimal(dt.Rows[0]["FSME_ID"]);
                    avancosFolhaServico.OutFsmeFosmId = Convert.ToDecimal(dt.Rows[0]["FSME_FOSM_ID"]);
                    avancosFolhaServico.OutFsmeData = Convert.ToDateTime(dt.Rows[0]["FSME_DATA"]);
                    avancosFolhaServico.OutFsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSME_AVANCO_ACM"]);
                }
                return avancosFolhaServico;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==================================================================
        public static void AtualizaStatusTubulacao(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            //OBTÉM O ELEMENTO DE MAIOR NÍVEL NO CRITÉRIO PROCESSADO
            string maxFcesSigla = GetMaiorElementoCriterio(fcmeSigla);
            //Agrupa Unidades Regionais na tabela AC_CONTROLE_FOLHA_SERVICO
            AgrupaUnidadeRegional(contrato, discId, sbcnSigla, fcmeSigla);
            AplicaDadosEngenhariaTubulacao(discId, sbcnSigla, fcmeSigla);
            SetConsolidadoUnidadesRegionaisSISEPC(contrato, discId, sbcnSigla, fcmeSigla);
            AplicaDadosSISEPCTubulacao(contrato, discId, sbcnSigla, fcmeSigla);
            AplicaDadosProgramadosTubulacao(contrato, discId, sbcnSigla, fcmeSigla);
            AplicaDadosConcluidosTubulacao(contrato, discId, sbcnSigla, fcmeSigla, maxFcesSigla);
            CalculosEstatisticos(contrato, discId, sbcnSigla, fcmeSigla);
        }
        //==================================================================
        private static DataTable GetConsolidadoUnidadesRegionaisConcluidas(string discId, string sbcnSigla, string fcmeSigla, string maxFcesSigla)
        {
            //Obtém o resumo por Unidades Regionais dos avanços programados do critério
            DataTable dtSpoolsConcluidos = null;
            //OBTÉM SPOOLS CONCLUIDOS POR UNIDADE_REGIONAL (F)
            strSQL = @"SELECT FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL, COUNT(FOSE_QTD_PREVISTA) AS QTD, SUM(FOSE_QTD_PREVISTA) AS FOSE_QTD_PREVISTA
                         FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO
                        WHERE DISC_ID = " + discId.ToString();
            switch (fcmeSigla)
            {
                case "TUB_FAB": { strSQL += @" AND FOSE_STATUS LIKE '%" + maxFcesSigla + "'"; break; }
                case "TUB_MONT": { strSQL += @" AND FOSE_STATUS NOT LIKE '%PROG%' AND FOSE_STATUS IS NOT NULL"; break; }
            }

            strSQL +=  @" AND FCME_SIGLA = '" + fcmeSigla + @"' AND SBCN_SIGLA = '" + sbcnSigla + @"' AND TSTF_UNIDADE_REGIONAL NOT LIKE 'UR INDEFINIDA%'
                        GROUP BY FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL
                        ORDER BY FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL";
            dtSpoolsConcluidos = BLL.AcStatusTubBLL.Select(strSQL);
            return dtSpoolsConcluidos;
        }
        //==================================================================
        private static DataTable GetConsolidadoUnidadesRegionaisProgramados(string discId, string sbcnSigla, string fcmeSigla)
        {
            //Obtém o resumo por Unidades Regionais dos avanços programados do critério
            DataTable dtSpoolsProgramados = null;
            //OBTÉM SPOOLS PROGRAMADOS POR UNIDADE_REGIONAL (P)
            strSQL = @"SELECT FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL, COUNT(FOSE_QTD_PREVISTA) AS QTD, SUM(FOSE_QTD_PREVISTA) AS FOSE_QTD_PREVISTA
                         FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO 
                        WHERE DISC_ID = " + discId.ToString() + @" 
                          AND FOSE_STATUS != 'NÃO PROG' 
                          AND FOSE_STATUS != 'Cancelada'
                          AND FCME_SIGLA = '" + fcmeSigla + @"' AND SBCN_SIGLA = '" + sbcnSigla + @"' AND TSTF_UNIDADE_REGIONAL NOT LIKE 'UR INDEFINIDA%'            
                        GROUP BY FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL
                        ORDER BY FOSE_CNTR_CODIGO, DISC_ID, SBCN_SIGLA, TSTF_UNIDADE_REGIONAL";
            dtSpoolsProgramados = BLL.AcStatusTubBLL.Select(strSQL);
            return dtSpoolsProgramados;
        }
        //==================================================================
        private static string GetMaiorElementoCriterio(string fcmeSigla)
        {
            string maxFcesSigla = "";
            strSQL = @"SELECT FCES_SIGLA 
                        FROM (
                            SELECT FCES_SIGLA 
                            FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA
                            WHERE FCME_SIGLA = '" + fcmeSigla + @"'
                                AND FCME_CNTR_CODIGO = FCES_CNTR_CODIGO AND FCME_ID = FCES_FCME_ID
                                AND FCES_WBS IN (
                                                SELECT MAX(ES.FCES_WBS) AS FCES_WBS FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO CR, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA ES
                                                WHERE CR.FCME_SIGLA = '" + fcmeSigla + @"'
                                                AND CR.FCME_CNTR_CODIGO = ES.FCES_CNTR_CODIGO AND CR.FCME_ID = ES.FCES_FCME_ID
                                                )
                            )";
            maxFcesSigla = BLL.AcStatusTubBLL.Select(strSQL).Rows[0]["FCES_SIGLA"].ToString();
            return maxFcesSigla;
        }
        //==================================================================
        private static void SetConsolidadoUnidadesRegionaisSISEPC(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            //Prepara tabela para novo agrupamento de Unidade Regional
            strSQL = @"DELETE FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC WHERE URSP_CNTR_CODIGO = '" + contrato +  "' AND URSP_DISC_ID = " + discId + " AND URSP_SBCN_SIGLA = '" + sbcnSigla + "' AND URSP_FCME_SIGLA = '" + fcmeSigla + "'";
            BLL.AcUnidadeRegionalSisepcBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");

            //Alimenta tabela com as regioes corespondentes e suas quantidades

            strSQL = @"INSERT INTO EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC
                              ( URSP_CNTR_CODIGO, URSP_SBCN_SIGLA, URSP_DISC_ID, URSP_FCME_SIGLA, URSP_FOSE_ID, URSP_FOSE_NUMERO, URSP_REGIAO, URSP_QTD_PREVISTA)
                              SELECT V.FOSE_CNTR_CODIGO, V.SBCN_SIGLA, V.DISC_ID, V.FCME_SIGLA, V.FOSE_ID, V.FOSE_NUMERO, V.DESCRICAO_ATRIBUTO as REGIAO, V.FOSE_QTD_PREVISTA
                                FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO V
                               WHERE V.FOSE_CNTR_CODIGO = '" + contrato + "' AND V.DISC_ID = " + discId + " AND V.SBCN_SIGLA = '" + sbcnSigla + "' AND V.FCME_SIGLA = '" + fcmeSigla + @"' AND ATPE_NOME = 'Regiao'
                               ORDER BY V.DESCRICAO_ATRIBUTO";
            BLL.AcUnidadeRegionalSisepcBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcUnidadeRegionalSisepcBLL.ExecuteSQLInstruction("COMMIT");

            string updateUnidadeRegional = @"UPDATE EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC SET URSP_UNIDADE_REGIONAL = '";
            string valueSetUnidadeRegional = @"";

            string whereUnidadeRegional = @"' WHERE URSP_UNIDADE_REGIONAL IS NULL AND URSP_REGIAO IS NOT NULL AND URSP_SBCN_SIGLA = '" + sbcnSigla + @"' AND URSP_FCME_SIGLA = '" + fcmeSigla + @"' ";
            string complementoWhereUnidadeRegional = "";

            //FOSE_NUMERO LIKE '%773'
            valueSetUnidadeRegional = "FRAMO";
            complementoWhereUnidadeRegional = @" AND URSP_FOSE_NUMERO LIKE '%773'";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //FOSE_NUMERO LIKE '%B27H%'
            valueSetUnidadeRegional = "FRP";
            complementoWhereUnidadeRegional = @" AND URSP_FOSE_NUMERO LIKE '%B27H%'";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'DECK%'
            valueSetUnidadeRegional = "MÓDULO DE SERVIÇO";
            complementoWhereUnidadeRegional = @" AND RTRIM(LTRIM(UPPER(URSP_REGIAO))) LIKE UPPER('DECK%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION = 'HELIDECK'
            valueSetUnidadeRegional = "HELIDECK";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) = UPPER('HELIDECK')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'PRACK%'
            valueSetUnidadeRegional = "MARINE PIPE RACK";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('PRACK%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'TK%'
            valueSetUnidadeRegional = "TANQUES";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('TK%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'Ship Side%'
            valueSetUnidadeRegional = "ENGINE ROOM - PLAT 4";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('Ship Side%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'MDF%'
            valueSetUnidadeRegional = "PROA";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('MDF%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'MDA%'
            valueSetUnidadeRegional = "POPA";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('MDA%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'SLOP%'
            valueSetUnidadeRegional = "TANQUES";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('SLOP%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'FW%'
            valueSetUnidadeRegional = "PROA";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('FW%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'AF%'
            valueSetUnidadeRegional = "POPA";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('AF%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'FPTK%'
            valueSetUnidadeRegional = "PROA";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('FPTK%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'PR%'
            valueSetUnidadeRegional = "PUMP ROOM";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('PR%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);

            //REGION LIKE 'MD%'
            valueSetUnidadeRegional = "MAIN DECK";
            complementoWhereUnidadeRegional = @" AND UPPER(URSP_REGIAO) LIKE UPPER('MD%')";
            ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);


            //REGION LIKE 'ER%'
            for (int i = 1; i < 6; i++)
            {
                valueSetUnidadeRegional = "ENGINE ROOM - PLAT " + i.ToString();
                complementoWhereUnidadeRegional = @" AND RTRIM(LTRIM(UPPER(URSP_REGIAO))) LIKE UPPER('ER" + i.ToString() + "%')";
                ClassificaUnidadeRegional(updateUnidadeRegional, valueSetUnidadeRegional, whereUnidadeRegional, complementoWhereUnidadeRegional);
            }

            //CASO REGIAO IS NULL ATRIBUI UR COMO INDEFINIDA (QUANTIFICANDO AS FOLHAS DE SERVIÇO)
            DataTable dtUnidadesIndefinidas = null;
            strSQL = @"SELECT COUNT(*) AS QTD FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC WHERE URSP_UNIDADE_REGIONAL IS NULL AND URSP_REGIAO IS NULL AND URSP_SBCN_SIGLA = '" + sbcnSigla + "' AND URSP_FCME_SIGLA = '" + fcmeSigla + "'";
            dtUnidadesIndefinidas = BLL.AcStatusTubBLL.Select(strSQL);
            string urspUnidadeRegional = "UR INDEFINIDA (" + dtUnidadesIndefinidas.Rows[0]["QTD"].ToString() + " FS)";

            strSQL = @"UPDATE EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC SET URSP_UNIDADE_REGIONAL = '" + urspUnidadeRegional + @"' WHERE URSP_SBCN_SIGLA = '" + sbcnSigla + @"' AND URSP_FCME_SIGLA = '" + fcmeSigla + @"' AND URSP_UNIDADE_REGIONAL IS NULL AND URSP_REGIAO IS NULL";
            BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        private static void CalculosEstatisticos(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            DataTable dtStatusTub = BLL.AcStatusTubBLL.Get("TSTF_UNIDADE_REGIONAL != 'TOTAL' AND TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "'", "TSTF_SEQUENCE");

            //OBTÉM E GRAVA ELEMENTOS DE CADA REGIAO
            for (int i = 0; i < dtStatusTub.Rows.Count; i++)
            {
                DTO.AcStatusTubDTO st = new DTO.AcStatusTubDTO();
                st.TstfDiscId = Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_DISC_ID"]);
                st.TstfSbcnSigla = dtStatusTub.Rows[i]["TSTF_SBCN_SIGLA"].ToString();
                st.TstfFcmeSigla = dtStatusTub.Rows[i]["TSTF_FCME_SIGLA"].ToString();
                st.TstfUnidadeRegional = dtStatusTub.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString();

//                string filter = "";
                //if (st.TstfUnidadeRegional != "")
                //{
                string filter = "TSTF_DISC_ID = " + st.TstfDiscId + " AND TSTF_SBCN_SIGLA = '" + st.TstfSbcnSigla + "' AND TSTF_FCME_SIGLA = '" + st.TstfFcmeSigla + "' AND TSTF_UNIDADE_REGIONAL = '" + st.TstfUnidadeRegional + "'";
                //}
                //else
                //{
                //    filter = "TSTF_DISC_ID = " + st.TstfDiscId + " AND TSTF_SBCN_SIGLA = '" + st.TstfSbcnSigla + "' AND TSTF_FCME_SIGLA = '" + st.TstfFcmeSigla + "' AND TSTF_UNIDADE_REGIONAL IS NULL";
                //}
                //int NR = BLL.AcStatusTubBLL.Count(filter);
                //if (NR > 0) 
                st = BLL.AcStatusTubBLL.GetObject(filter);

                //Spools no SisEPC
                st.TstfSpoolsSisepcPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_SISEPC_PC"]), 1);
                st.TstfSpoolsSisepcPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_SISEPC_PESO"]), 1);

                //Spools a Liberar pela Engenharia
                st.TstfSpoolsAliberarPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsPrevPc - st.TstfSpoolsSisepcPc), 1);
                st.TstfSpoolsAliberarPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsPrevPeso - st.TstfSpoolsSisepcPeso), 1);
                if (st.TstfSpoolsAliberarPc <= 0) st.TstfSpoolsAliberarPc = null;
                if (st.TstfSpoolsAliberarPeso <= 0) st.TstfSpoolsAliberarPeso = null;

                if ((dtStatusTub.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PC"] != null) && (dtStatusTub.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PC"] != DBNull.Value)) st.TstfSpoolsProgramadosPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PC"]), 1);
                if ((dtStatusTub.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PESO"] != null) && (dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"] != DBNull.Value)) st.TstfSpoolsProgramadosPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PESO"]), 1);

                if ((dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PC"] != null) && (dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PC"] != DBNull.Value)) st.TstfSpoolsAvancadosPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PC"]), 1);
                if ((dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"] != null) && (dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"] != DBNull.Value)) st.TstfSpoolsAvancadosPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(dtStatusTub.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"]), 1);

                //Spools a Programar
                st.TstfSpoolsAprogramarPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsSisepcPc - st.TstfSpoolsProgramadosPc), 1);
                st.TstfSpoolsAprogramarPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsSisepcPeso - st.TstfSpoolsProgramadosPeso), 1);
                if (st.TstfSpoolsAprogramarPc <= 0) st.TstfSpoolsAprogramarPc = null;
                if (st.TstfSpoolsAprogramarPeso <= 0) st.TstfSpoolsAprogramarPeso = null;

                //Spools a AVANCAR
                st.TstfSpoolsAAvancarPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsPrevPc - st.TstfSpoolsAvancadosPc), 1);
                st.TstfSpoolsAAvancarPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsPrevPeso - st.TstfSpoolsAvancadosPeso), 1);
                if (st.TstfSpoolsAAvancarPc <= 0) st.TstfSpoolsAAvancarPc = null;
                if (st.TstfSpoolsAAvancarPeso <= 0) st.TstfSpoolsAAvancarPeso = null;

                //Spools a OFICINA
                st.TstfSpoolsOficinaPc = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsProgramadosPc - st.TstfSpoolsAvancadosPc), 1);
                st.TstfSpoolsOficinaPeso = GenericClasses.Util.MathRoundValue(Convert.ToDouble(st.TstfSpoolsProgramadosPeso - st.TstfSpoolsAvancadosPeso), 1);
                if (st.TstfSpoolsOficinaPc <= 0) st.TstfSpoolsOficinaPc = null;
                if (st.TstfSpoolsOficinaPeso <= 0) st.TstfSpoolsOficinaPeso = null;

                //Salva Região
                BLL.AcStatusTubBLL.Update(st);
            }
        }
        //==================================================================
        private static void AplicaDadosConcluidosTubulacao(string contrato, string discId, string sbcnSigla, string fcmeSigla, string maxFcesSigla)
        {
            DataTable dtSpoolsConcluidos = GetConsolidadoUnidadesRegionaisConcluidas(discId, sbcnSigla, fcmeSigla, maxFcesSigla);
            string urspUnidadeRegional = "";
            string urspPecas = "";
            string urspPeso = "";
            //Para cada correspondente em AC_STATUS_FAB atualiza a coluna Avançados
            for (int i = 0; i < dtSpoolsConcluidos.Rows.Count; i++)
            {
                urspUnidadeRegional = dtSpoolsConcluidos.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString();
                urspPecas = Convert.ToString(dtSpoolsConcluidos.Rows[i]["QTD"]).Replace(",", ".");
                urspPeso = Convert.ToString(dtSpoolsConcluidos.Rows[i]["FOSE_QTD_PREVISTA"]).Replace(",", ".");
                strSQL = @"UPDATE EEP_CONVERSION.AC_STATUS_TUB SET TSTF_SPOOLS_AVANCADOS_PC = " + urspPecas + ", TSTF_SPOOLS_AVANCADOS_PESO = " + urspPeso + @"
                            WHERE TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "' AND TSTF_UNIDADE_REGIONAL = '" + urspUnidadeRegional + "'";
                BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            }
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        private static void AplicaDadosProgramadosTubulacao(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            DataTable dtSpoolsProgramados = GetConsolidadoUnidadesRegionaisProgramados(discId, sbcnSigla, fcmeSigla);
            string urspUnidadeRegional = "";
            string urspPecas = "";
            string urspPeso = "";
            //Para cada correspondente em AC_STATUS_FAB atualiza a coluna Programados
            for (int i = 0; i < dtSpoolsProgramados.Rows.Count; i++)
            {
                urspUnidadeRegional = dtSpoolsProgramados.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString();
                urspPecas = Convert.ToString(dtSpoolsProgramados.Rows[i]["QTD"]).Replace(",", ".");
                urspPeso = Convert.ToString(dtSpoolsProgramados.Rows[i]["FOSE_QTD_PREVISTA"]).Replace(",", ".");
                strSQL = @"UPDATE EEP_CONVERSION.AC_STATUS_TUB SET TSTF_SPOOLS_PROGRAMADOS_PC = " + urspPecas + ", TSTF_SPOOLS_PROGRAMADOS_PESO = " + urspPeso + @"
                            WHERE TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "' AND TSTF_UNIDADE_REGIONAL = '" + urspUnidadeRegional + "'";
                BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            }
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        private static void AplicaDadosSISEPCTubulacao(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            //Obtém as Unidades Regionais
            strSQL = @"SELECT URSP_CNTR_CODIGO, URSP_SBCN_SIGLA, URSP_DISC_ID, URSP_FCME_SIGLA, URSP_UNIDADE_REGIONAL, COUNT(URSP_FOSE_ID) AS URSP_PECAS, SUM(URSP_QTD_PREVISTA) AS URSP_PESO
                         FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC
                        WHERE URSP_SBCN_SIGLA = '" + sbcnSigla + @"' AND URSP_FCME_SIGLA = '" + fcmeSigla + @"' AND URSP_REGIAO IS NOT NULL                        
                        GROUP BY URSP_CNTR_CODIGO, URSP_SBCN_SIGLA, URSP_DISC_ID, URSP_FCME_SIGLA, URSP_UNIDADE_REGIONAL
                        ORDER BY URSP_CNTR_CODIGO, URSP_SBCN_SIGLA, URSP_DISC_ID, URSP_FCME_SIGLA, URSP_UNIDADE_REGIONAL
                        ";
            DataTable dtSpoolsSISEPC = BLL.AcUnidadeRegionalSisepcBLL.Select(strSQL);
            string urspUnidadeRegional = "";
            string urspPecas = "";
            string urspPeso = "";
            //Para cada correspondente em AC_STATUS_FAB atualiza a coluna SISEPC
            for (int i = 0; i < dtSpoolsSISEPC.Rows.Count; i++)
            {
                urspUnidadeRegional = dtSpoolsSISEPC.Rows[i]["URSP_UNIDADE_REGIONAL"].ToString();
                urspPecas = Convert.ToString(dtSpoolsSISEPC.Rows[i]["URSP_PECAS"]).Replace(",",".");
                urspPeso = Convert.ToString(dtSpoolsSISEPC.Rows[i]["URSP_PESO"]).Replace(",",".");
                strSQL = @"UPDATE EEP_CONVERSION.AC_STATUS_TUB SET TSTF_SPOOLS_SISEPC_PC = " + urspPecas + ", TSTF_SPOOLS_SISEPC_PESO = " + urspPeso + @"
                            WHERE TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "' AND TSTF_UNIDADE_REGIONAL = '" + urspUnidadeRegional + "'";
                BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            }
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");
         }
        //==================================================================
        private static void AplicaDadosEngenhariaTubulacao(string discId, string sbcnSigla, string fcmeSigla)
        {
            DataTable dtTotal = null;
            decimal totalPecas = 0;
            decimal totalPeso = 0;
            strSQL = @"DELETE EEP_CONVERSION.AC_STATUS_TUB WHERE TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "'";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");

            //P74
            //=============================================
            if (sbcnSigla == "P74")
            {
                DTO.CollectionAcPrevisaoEngenhariaDTO pe = new DTO.CollectionAcPrevisaoEngenhariaDTO();
                pe = BLL.AcPrevisaoEngenhariaBLL.GetCollection("PENG_SBCN_SIGLA = '" + sbcnSigla + "'", "PENG_SEQUENCE");
                for (int c = 0; c < pe.Count; c++)
                {
                    strSQL = @"INSERT INTO EEP_CONVERSION.AC_STATUS_TUB (TSTF_DISC_ID, TSTF_SBCN_SIGLA, TSTF_FCME_SIGLA, TSTF_UNIDADE_REGIONAL, TSTF_SPOOLS_PREV_PC, TSTF_SPOOLS_PREV_PESO, TSTF_SEQUENCE) VALUES (" + discId + ", '" + sbcnSigla + "' , '" + fcmeSigla + "' , '" + pe[c].PengUnidadeRegional + "', " + pe[c].PengPecas + ", " + pe[c].PengPeso.ToString().Replace(",",".") + ", " + pe[c].PengSequence + ")";
                    BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
                }

                strSQL = @"SELECT SUM(TSTF_SPOOLS_PREV_PC) AS TSTF_SPOOLS_PREV_PC, SUM(TSTF_SPOOLS_PREV_PESO) AS TSTF_SPOOLS_PREV_PESO
                             FROM EEP_CONVERSION.AC_STATUS_TUB
                            WHERE TSTF_DISC_ID = " + discId + @" AND TSTF_SBCN_SIGLA = '" + sbcnSigla + @"' AND TSTF_FCME_SIGLA = '" + fcmeSigla  + "'";
                dtTotal = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                totalPecas = Convert.ToDecimal(dtTotal.Rows[0]["TSTF_SPOOLS_PREV_PC"]);
                totalPeso = Convert.ToDecimal(dtTotal.Rows[0]["TSTF_SPOOLS_PREV_PESO"]);
                strSQL = @"INSERT INTO EEP_CONVERSION.AC_STATUS_TUB (TSTF_DISC_ID, TSTF_SBCN_SIGLA, TSTF_FCME_SIGLA, TSTF_UNIDADE_REGIONAL, TSTF_SPOOLS_PREV_PC, TSTF_SPOOLS_PREV_PESO, TSTF_SEQUENCE) VALUES (" + discId + ", '" + sbcnSigla + "' , '" + fcmeSigla + "' , 'TOTAL', " + totalPecas.ToString().Replace(",", ".") + ", " +  totalPeso.ToString().Replace(",", ".") + ",999)";
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
            }
            //=============================================
        }
        //==================================================================
        private static void AgrupaUnidadeRegional(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            DTO.CollectionAcUnidadeRegionalDTO ur = new DTO.CollectionAcUnidadeRegionalDTO();
            ur = BLL.AcUnidadeRegionalBLL.GetCollection("1 = 1", "UNRE_SEQUENCE");

            //LIMPA UNIDADES NA TABELA DE STATUS DAS FOLHAS DE SERVIÇO
            strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO SET TSTF_UNIDADE_REGIONAL = NULL WHERE FOSE_CNTR_CODIGO = '" + contrato + @"' AND SBCN_SIGLA = '" + sbcnSigla + @"' AND FCME_SIGLA = '" + fcmeSigla + "'";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");

            string updateUnidadeRegional = @"UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO SET TSTF_UNIDADE_REGIONAL = '";
            string unreUnidadeRegional = "";
            string whereUnidadeRegional = @"' WHERE TSTF_UNIDADE_REGIONAL IS NULL AND SIFS_DESCRICAO != 'Cancelada' AND REGIAO IS NOT NULL AND SBCN_SIGLA = '" + sbcnSigla + @"' AND FCME_SIGLA = '" + fcmeSigla + "' ";
            string unreRegionLike = "";
            
            for (int u = 0; u < ur.Count; u++)
            {
                unreUnidadeRegional = ur[u].UnreUnidadeRegional;
                unreRegionLike = ur[u].UnreRegionLike;
                if (unreUnidadeRegional != "ENGINE ROOM - PLAT ")
                {
                    ClassificaUnidadeRegional(updateUnidadeRegional, unreUnidadeRegional, whereUnidadeRegional, unreRegionLike);
                }
                else
                {
                    //REGIAO LIKE 'ER%'
                    for (int i = 1; i < 6; i++)
                    {
                        unreUnidadeRegional = "ENGINE ROOM - PLAT " + i.ToString();
                        unreRegionLike = @" AND UPPER(REGIAO) LIKE UPPER('ER" + i.ToString() + "%')";
                        ClassificaUnidadeRegional(updateUnidadeRegional, unreUnidadeRegional, whereUnidadeRegional, unreRegionLike);
                    }
                }
            }

            //CASO REGIAO IS NULL ATRIBUI UR COMO INDEFINIDA (QUANTIFICANDO AS FOLHAS DE SERVIÇO)
            DataTable dtUnidadesIndefinidas = null;
            strSQL = @"SELECT COUNT(*) AS QTD FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE REGIAO IS NULL AND TSTF_UNIDADE_REGIONAL IS NULL AND SIFS_DESCRICAO != 'Cancelada' AND SBCN_SIGLA = '" + sbcnSigla + "' AND FCME_SIGLA = '" + fcmeSigla + "'";
            dtUnidadesIndefinidas = BLL.AcStatusTubBLL.Select(strSQL);
            unreUnidadeRegional = "UR INDEFINIDA (" + dtUnidadesIndefinidas.Rows[0]["QTD"].ToString() + " FS)";
            unreRegionLike = "";
            //ClassificaUnidadeRegional(updateUnidadeRegional, unreUnidadeRegional, whereUnidadeRegional, unreRegionLike);
            //strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO SET TSTF_UNIDADE_REGIONAL = 'UR INDEFINIDA (4 FS)' WHERE TSTF_UNIDADE_REGIONAL IS NULL AND SIFS_DESCRICAO != 'Cancelada' AND REGIAO IS NULL AND SBCN_SIGLA = 'P74' AND FCME_SIGLA = 'TUB_FAB'";

            strSQL = @"UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO SET TSTF_UNIDADE_REGIONAL = '" + unreUnidadeRegional + @"' WHERE SBCN_SIGLA = '" + sbcnSigla + @"' AND FCME_SIGLA = '" + fcmeSigla + @"' AND  TSTF_UNIDADE_REGIONAL IS NULL AND REGIAO IS NULL AND SIFS_DESCRICAO != 'Cancelada'";
            BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        private static void ClassificaUnidadeRegional(string updateUnidadeRegional, string valueSetUnidadeRegional, string whereUnidadeRegional, string complementoWhereUnidadeRegional)
        {
            strSQL = updateUnidadeRegional + valueSetUnidadeRegional + whereUnidadeRegional + complementoWhereUnidadeRegional;
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        public static void TotalizaCriterio(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            strSQL = @"DELETE FROM EEP_CONVERSION.AC_STATUS_TUB WHERE TSTF_UNIDADE_REGIONAL = 'TOTAL' AND TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "'";
            BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");
            //DESATIVAR MÓDULO DE SERVIÇO, FRAMO, FRP, UR INDEFINIDA
            strSQL = @"UPDATE EEP_CONVERSION.AC_STATUS_TUB SET TSTF_ACTIVE = 0 WHERE TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "' AND (UPPER(TSTF_UNIDADE_REGIONAL) LIKE UPPER('UR INDEFINIDA%') OR TSTF_UNIDADE_REGIONAL IS NULL OR UPPER(TSTF_UNIDADE_REGIONAL) = UPPER('FRAMO') OR UPPER(TSTF_UNIDADE_REGIONAL) = UPPER('FRP') OR UPPER(TSTF_UNIDADE_REGIONAL) = UPPER('MÓDULO DE SERVIÇO'))";
            BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");

            //CALCULA e GRAVA TOTAL
            strSQL = @"INSERT INTO  EEP_CONVERSION.AC_STATUS_TUB(TSTF_DISC_ID, TSTF_SBCN_SIGLA, TSTF_FCME_SIGLA, TSTF_UNIDADE_REGIONAL, 
                                    TSTF_SPOOLS_PREV_PC, TSTF_SPOOLS_PREV_PESO,                                                                                                                                                                                 TSTF_SPOOLS_SISEPC_PC, TSTF_SPOOLS_SISEPC_PESO, 
                                    TSTF_SPOOLS_ALIBERAR_PC, TSTF_SPOOLS_ALIBERAR_PESO, 
                                    TSTF_SPOOLS_PROGRAMADOS_PC, TSTF_SPOOLS_PROGRAMADOS_PESO, 
                                    TSTF_SPOOLS_AVANCADOS_PC, TSTF_SPOOLS_AVANCADOS_PESO, 
                                    TSTF_SPOOLS_APROGRAMAR_PC, TSTF_SPOOLS_APROGRAMAR_PESO, 
                                    TSTF_SPOOLS_AAVANCAR_PC, TSTF_SPOOLS_AAVANCAR_PESO, 
                                    TSTF_SPOOLS_OFICINA_PC, TSTF_SPOOLS_OFICINA_PESO, 
                                    TSTF_SEQUENCE
                                    )
                                    SELECT
                                            " + discId + @" AS TSTF_DISC_ID,
                                            '" + sbcnSigla + @"' AS TSTF_SBCN_SIGLA,
                                            '" + fcmeSigla + @"' AS TSTF_FCME_SIGLA,
                                            'TOTAL',
                                                SUM(TSTF_SPOOLS_PREV_PC) AS TSTF_SPOOLS_PREV_PC,
                                                SUM(TSTF_SPOOLS_PREV_PESO) AS TSTF_SPOOLS_PREV_PESO,
                                                SUM(TSTF_SPOOLS_SISEPC_PC) AS TSTF_SPOOLS_SISEPC_PC,
                                                SUM(TSTF_SPOOLS_SISEPC_PESO) AS TSTF_SPOOLS_SISEPC_PESO,
                                                SUM(TSTF_SPOOLS_ALIBERAR_PC) AS TSTF_SPOOLS_ALIBERAR_PC,
                                                SUM(TSTF_SPOOLS_ALIBERAR_PESO) AS TSTF_SPOOLS_ALIBERAR_PESO,
                                                SUM(TSTF_SPOOLS_PROGRAMADOS_PC) AS TSTF_SPOOLS_PROGRAMADOS_PC,
                                                SUM(TSTF_SPOOLS_PROGRAMADOS_PESO) AS TSTF_SPOOLS_PROGRAMADOS_PESO,
                                                SUM(TSTF_SPOOLS_AVANCADOS_PC)AS TSTF_SPOOLS_AVANCADOS_PC,
                                                SUM(TSTF_SPOOLS_AVANCADOS_PESO) AS TSTF_SPOOLS_AVANCADOS_PESO,
                                                SUM(TSTF_SPOOLS_APROGRAMAR_PC) AS TSTF_SPOOLS_APROGRAMAR_PC,
                                                SUM(TSTF_SPOOLS_APROGRAMAR_PESO) AS TSTF_SPOOLS_APROGRAMAR_PESO,
                                                SUM(TSTF_SPOOLS_AAVANCAR_PC) AS TSTF_SPOOLS_AAVANCAR_PC,
                                                SUM(TSTF_SPOOLS_AAVANCAR_PESO) AS TSTF_SPOOLS_AAVANCAR_PESO,
                                                SUM(TSTF_SPOOLS_OFICINA_PC) AS TSTF_SPOOLS_OFICINA_PC,
                                                SUM(TSTF_SPOOLS_OFICINA_PESO) AS TSTF_SPOOLS_OFICINA_PESO,
                                                1000 AS TSTF_SEQUENCE
                                        FROM
                                                EEP_CONVERSION.AC_STATUS_TUB
                                        WHERE   TSTF_ACTIVE = 1 AND TSTF_DISC_ID = " + discId + " AND TSTF_SBCN_SIGLA = '" + sbcnSigla + "' AND TSTF_FCME_SIGLA = '" + fcmeSigla + "'";
            BLL.AcStatusTubBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcStatusTubBLL.ExecuteSQLInstruction("COMMIT");
        }
        //==================================================================
        public static void EmailsURIndefinidas(string contrato, string discId, string sbcnSigla, string fcmeSigla)
        {
            strSQL = @"SELECT FOSE_CNTR_CODIGO, SBCN_SIGLA, DISC_NOME, FOSE_NUMERO FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO  
                        WHERE UPPER(TSTF_UNIDADE_REGIONAL) LIKE UPPER('UR INDEFINIDA%') AND FOSE_CNTR_CODIGO  = '" + contrato + "' AND DISC_ID = " + discId + " AND SBCN_SIGLA = '" + sbcnSigla + "' AND FCME_SIGLA = '" + fcmeSigla + "'";
            DataTable dtUnidadesIndefinidas = BLL.AcStatusTubBLL.Select(strSQL);
        }
        //==================================================================
        public static string FosePrefixoIsometrico(string fose, int piece)
        {
            string sRet = "";
            string[] foseNumero = sRet.Split('.');
            switch (piece)
            {
                case 1: { sRet = foseNumero[0]; break; }
                case 2: { sRet = foseNumero[1]; break; }
            }
            return sRet;
        }
        //==================================================================
        public static void GetMaxAvnProgFose(DTO.AcAcuracidadeDTO a)
        {
            string strSQL = "SELECT ROUND(MAX(FSMP_AVANCO_ACM),5) AS FSMP_AVANCO_ACM, ROUND(MAX(FSMP_QTD_ACM),5) AS FSMP_QTD_ACM, MAX(FSMP_DATA) AS FSMP_DATA FROM EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG WHERE FSMP_FOSM_ID = " + a.AcurFsmpFosmId.ToString();
            DataTable dt = BLL.AcAcuracidadeBLL.Select(strSQL);
            if(dt.Rows[0]["FSMP_AVANCO_ACM"] != System.DBNull.Value) a.AcurFsmpAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSMP_AVANCO_ACM"]);
            if (dt.Rows[0]["FSMP_DATA"] != System.DBNull.Value) a.AcurMaxFsmpData = Convert.ToDateTime(dt.Rows[0]["FSMP_DATA"]);
            if (dt.Rows[0]["FSMP_QTD_ACM"] != System.DBNull.Value) a.AcurQtdAvancoProgPond = Convert.ToDecimal(dt.Rows[0]["FSMP_QTD_ACM"]);
            if (dt.Rows[0]["FSMP_DATA"] != System.DBNull.Value && a.AcurFcesPesoRelCron != 0) a.AcurQtdProg = a.AcurQtdPrevista * 100 / a.AcurFcesPesoRelCron;
            BLL.AcAcuracidadeBLL.Update(a);
            dt = null;
        }
    }
}


//        //==================================================================
//        public static string GetQuerySelecaoFOSECriterioFPSO(string contrato, string discId, string sbcnSigla, string fcmeSigla, string dataCorteUpdateControl)
//        {
//            string strSQL = "";

//            strSQL = @"
//                        SELECT FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID,
//                        MAX(QTD_ACUMULADA) AS QTD_ACUMULADA, MAX(FSME_AVANCO_ACM) AS FSME_AVANCO_ACM, MAX(FSME_DATA) AS MAX_FSME_DATA
//                        FROM(
//                            SELECT  FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
//                                    FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, QTD_ACUMULADA, FSME_AVANCO_ACM,
//                                    FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID, FSME_DATA
//                            FROM (          
//                                    SELECT 
//                                            FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
//                                            FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FSME_DATA, ROUND(MAX(FSME_QTD_ACM),2) AS QTD_ACUMULADA, ROUND(MAX(FSME_AVANCO_ACM),2) AS FSME_AVANCO_ACM,
//                                            FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
//                                    FROM
//                                            EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO,
//                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC
//                                    WHERE 
//                                            FOSE_CNTR_CODIGO = '" + contrato + @"' 
//                                    AND  FSME_CNTR_CODIGO(+) = FOSE_CNTR_CODIGO AND  FSME_FOSM_ID(+) = FOSM_ID 
//                                    AND  DISC_ID = " + discId + @"  
//                                    AND FOSE_ID IN
//                                                    (
//                                                        SELECT DISTINCT U.FOSE_ID FROM
//                                                        (
//                                                            SELECT VE.FOSE_ID
//                                                                FROM
//                                                                    EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO VE,
//                                                                    EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC E
//                                                                WHERE 
//                                                                    VE.FOSE_CNTR_CODIGO = '" + contrato + @"' 
//                                                                AND E.FSME_CNTR_CODIGO(+) = VE.FOSE_CNTR_CODIGO AND  E.FSME_FOSM_ID(+) = VE.FOSM_ID 
//                                                                AND VE.DISC_ID = " + discId + @" AND VE.SBCN_SIGLA = '" + sbcnSigla + @"' AND VE.FCME_SIGLA = '" + fcmeSigla + @"'
//                                                                AND  E.FSME_DT_CADASTRO >=  TO_DATE('" + dataCorteUpdateControl + @"', 'DD/MM/YYYY HH24:MI:SS')
//                                                                GROUP BY VE.FOSE_ID
//                                                                UNION
//                                                            SELECT VP.FOSE_ID
//                                                                FROM
//                                                                    EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO VP,
//                                                                    EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG P
//                                                                WHERE 
//                                                                    VP.FOSE_CNTR_CODIGO = '" + contrato + @"' 
//                                                                AND  P.FSMP_CNTR_CODIGO(+) = VP.FOSE_CNTR_CODIGO AND P.FSMP_FOSM_ID(+) = VP.FOSM_ID 
//                                                                AND  VP.DISC_ID = " + discId + @" AND VP.SBCN_SIGLA = '" + sbcnSigla + @"' AND VP.FCME_SIGLA = '" + fcmeSigla + @"'
//                                                                AND  P.FSMP_DT_CADASTRO >=  TO_DATE('" + dataCorteUpdateControl + @"', 'DD/MM/YYYY HH24:MI:SS')
//                                                                GROUP BY VP.FOSE_ID
//                                                            ) U
//                                                    )
//                                    GROUP BY   FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, 
//                                                FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO,
//                                                FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FSME_DATA, 
//                                                FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
//                                )                                    
//                        ORDER  BY DISC_ID DESC, FSME_DATA DESC, FOSE_ID
//                        )
//                        GROUP BY FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, 
//                                 FCME_SIGLA, FCES_SIGLA, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, AREA_PINTURA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSM_ID
//                        ORDER BY FOSE_ID
//                    ";
//            return strSQL;
//        }