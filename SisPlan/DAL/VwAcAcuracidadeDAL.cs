using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

namespace DAL
{
    public class VwAcAcuracidadeDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT   SBCN_SIGLA,  TIPO_AVANCO,  DATA_AVANCO,  FOSE_DISC_ID,  DISC_NOME,  FCME_SIGLA,  FCES_SIGLA,  FCES_WBS,  FOSE_NUMERO, ATIV_SIG, ATIV_NOME,  TSTF_UNIDADE_REGIONAL,  REGIAO, LOCALIZACAO, EQUIPE,  FOSM_ID,  PERCENTUAL_AVANCO,  FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, QTD_AVANCO_REAL,  FOSM_FOSE_ID,  FOSM_FCES_ID,  FCES_FCME_ID,  FCME_ID FROM  EEP_CONVERSION.VW_AC_ACURACIDADE ";
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_AC_ACURACIDADE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VW_AC_ACURACIDADE"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_ACURACIDADE"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_ACURACIDADE"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTable VW_AC_ACURACIDADE"); }
        }
        ////====================================================================
        public static DTO.VwAcAcuracidadeDTO Get(string filter)
        {
            VwAcAcuracidadeDTO entity = new VwAcAcuracidadeDTO();
            DataTable dt = null;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["TIPO_AVANCO"] != null) && (dt.Rows[0]["TIPO_AVANCO"] != DBNull.Value)) entity.TipoAvanco = Convert.ToString(dt.Rows[0]["TIPO_AVANCO"]);
            if ((dt.Rows[0]["DATA_AVANCO"] != null) && (dt.Rows[0]["DATA_AVANCO"] != DBNull.Value)) entity.DataAvanco = Convert.ToDateTime(dt.Rows[0]["DATA_AVANCO"]);
            if ((dt.Rows[0]["FOSE_DISC_ID"] != null) && (dt.Rows[0]["FOSE_DISC_ID"] != DBNull.Value)) entity.FoseDiscId = Convert.ToDecimal(dt.Rows[0]["FOSE_DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["FCES_WBS"] != null) && (dt.Rows[0]["FCES_WBS"] != DBNull.Value)) entity.FcesWbs = Convert.ToString(dt.Rows[0]["FCES_WBS"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["ATIV_NOME"] != null) && (dt.Rows[0]["ATIV_NOME"] != DBNull.Value)) entity.AtivNome = Convert.ToString(dt.Rows[0]["ATIV_NOME"]);
            if ((dt.Rows[0]["TSTF_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["TSTF_UNIDADE_REGIONAL"] != DBNull.Value)) entity.TstfUnidadeRegional = Convert.ToString(dt.Rows[0]["TSTF_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["REGIAO"] != null) && (dt.Rows[0]["REGIAO"] != DBNull.Value)) entity.Regiao = Convert.ToString(dt.Rows[0]["REGIAO"]);
            if ((dt.Rows[0]["LOCALIZACAO"] != null) && (dt.Rows[0]["LOCALIZACAO"] != DBNull.Value)) entity.Localizacao = Convert.ToString(dt.Rows[0]["LOCALIZACAO"]);
            if ((dt.Rows[0]["EQUIPE"] != null) && (dt.Rows[0]["EQUIPE"] != DBNull.Value)) entity.Equipe = Convert.ToString(dt.Rows[0]["EQUIPE"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["PERCENTUAL_AVANCO"] != null) && (dt.Rows[0]["PERCENTUAL_AVANCO"] != DBNull.Value)) entity.PercentualAvanco = Convert.ToDecimal(dt.Rows[0]["PERCENTUAL_AVANCO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["QTD_AVANCO_POND"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.QtdAvancoPond = Convert.ToDecimal(dt.Rows[0]["QTD_AVANCO_POND"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["QTD_AVANCO_REAL"] != null) && (dt.Rows[0]["QTD_AVANCO_REAL"] != DBNull.Value)) entity.QtdAvancoReal = Convert.ToDecimal(dt.Rows[0]["QTD_AVANCO_REAL"]);
            if ((dt.Rows[0]["FOSM_FOSE_ID"] != null) && (dt.Rows[0]["FOSM_FOSE_ID"] != DBNull.Value)) entity.FosmFoseId = Convert.ToDecimal(dt.Rows[0]["FOSM_FOSE_ID"]);
            if ((dt.Rows[0]["FOSM_FCES_ID"] != null) && (dt.Rows[0]["FOSM_FCES_ID"] != DBNull.Value)) entity.FosmFcesId = Convert.ToDecimal(dt.Rows[0]["FOSM_FCES_ID"]);
            if ((dt.Rows[0]["FCES_FCME_ID"] != null) && (dt.Rows[0]["FCES_FCME_ID"] != DBNull.Value)) entity.FcesFcmeId = Convert.ToDecimal(dt.Rows[0]["FCES_FCME_ID"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToDecimal(dt.Rows[0]["FCME_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwAcAcuracidadeDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VW_AC_ACURACIDADE Object"); }
        }
        //====================================================================
        public static List<VwAcAcuracidadeDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcAcuracidadeDTO> list = OracleDataTools.LoadEntity<VwAcAcuracidadeDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_AC_ACURACIDADE>"); }
        }
        //====================================================================
        public static List<VwAcAcuracidadeDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcAcuracidadeDTO>"); }
        }
        //====================================================================
        public static List<VwAcAcuracidadeDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcGrupoCriterioMedicaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAcuracidadeDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcAcuracidadeDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAcuracidadeDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcAcuracidadeDTO collection = new DTO.CollectionVwAcAcuracidadeDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwAcAcuracidadeDTO entity = new DTO.VwAcAcuracidadeDTO();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["TIPO_AVANCO"].ToString().Length != 0) entity.TipoAvanco = Convert.ToString(dt.Rows[i]["TIPO_AVANCO"]);
                    if (dt.Rows[i]["DATA_AVANCO"].ToString().Length != 0) entity.DataAvanco = Convert.ToDateTime(dt.Rows[i]["DATA_AVANCO"]);
                    if (dt.Rows[i]["FOSE_DISC_ID"].ToString().Length != 0) entity.FoseDiscId = Convert.ToDecimal(dt.Rows[i]["FOSE_DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = Convert.ToString(dt.Rows[i]["DISC_NOME"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = Convert.ToString(dt.Rows[i]["FCME_SIGLA"]);
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = Convert.ToString(dt.Rows[i]["FCES_SIGLA"]);
                    if (dt.Rows[i]["FCES_WBS"].ToString().Length != 0) entity.FcesWbs = Convert.ToString(dt.Rows[i]["FCES_WBS"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = Convert.ToString(dt.Rows[i]["FOSE_NUMERO"]);
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = Convert.ToString(dt.Rows[i]["ATIV_SIG"]);
                    if (dt.Rows[i]["ATIV_NOME"].ToString().Length != 0) entity.AtivNome = Convert.ToString(dt.Rows[i]["ATIV_NOME"]);
                    if (dt.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.TstfUnidadeRegional = Convert.ToString(dt.Rows[i]["TSTF_UNIDADE_REGIONAL"]);
                    if (dt.Rows[i]["REGIAO"].ToString().Length != 0) entity.Regiao = Convert.ToString(dt.Rows[i]["REGIAO"]);
                    if (dt.Rows[i]["LOCALIZACAO"].ToString().Length != 0) entity.Localizacao = Convert.ToString(dt.Rows[i]["LOCALIZACAO"]);
                    if (dt.Rows[i]["EQUIPE"].ToString().Length != 0) entity.Equipe = Convert.ToString(dt.Rows[i]["EQUIPE"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["PERCENTUAL_AVANCO"].ToString().Length != 0) entity.PercentualAvanco = Convert.ToDecimal(dt.Rows[i]["PERCENTUAL_AVANCO"]);
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["QTD_AVANCO_POND"].ToString().Length != 0) entity.QtdAvancoPond = Convert.ToDecimal(dt.Rows[i]["QTD_AVANCO_POND"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = Convert.ToString(dt.Rows[i]["UNME_SIGLA"]);
                    if (dt.Rows[i]["QTD_AVANCO_REAL"].ToString().Length != 0) entity.QtdAvancoReal = Convert.ToDecimal(dt.Rows[i]["QTD_AVANCO_REAL"]);
                    if (dt.Rows[i]["FOSM_FOSE_ID"].ToString().Length != 0) entity.FosmFoseId = Convert.ToDecimal(dt.Rows[i]["FOSM_FOSE_ID"]);
                    if (dt.Rows[i]["FOSM_FCES_ID"].ToString().Length != 0) entity.FosmFcesId = Convert.ToDecimal(dt.Rows[i]["FOSM_FCES_ID"]);
                    if (dt.Rows[i]["FCES_FCME_ID"].ToString().Length != 0) entity.FcesFcmeId = Convert.ToDecimal(dt.Rows[i]["FCES_FCME_ID"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToDecimal(dt.Rows[i]["FCME_ID"]);
                    collection.Add(entity);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetCollection Method"); }
            dt.Dispose();
            return collection;
        }
        //====================================================================
        #endregion
    }
}
