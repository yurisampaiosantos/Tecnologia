using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

namespace DAL
{
    public class VwAcGrupoCriterioMedicaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT GRCR_CNTR_CODIGO, GRCR_ID, GRCR_GRUPO_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_SEQUENCE, FCME_ID, FCME_SIGLA, FCES_ID, FCES_SIGLA, FCES_PESO_REL_CRON, FOSE_ID, FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSM_ID FROM VW_AC_GRUPO_CRITERIO_MEDICAO ";
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM VW_AC_GRUPO_CRITERIO_MEDICAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VW_AC_GRUPO_CRITERIO_MEDICAO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_GRUPO_CRITERIO_MEDICAO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_GRUPO_CRITERIO_MEDICAO"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTable VW_AC_GRUPO_CRITERIO_MEDICAO"); }
        }
        ////====================================================================
        public static DTO.VwAcGrupoCriterioMedicaoDTO Get(string filter)
        {
            VwAcGrupoCriterioMedicaoDTO entity = new VwAcGrupoCriterioMedicaoDTO();
            DataTable dt = null;
            dt = Get(filter, null);
            if ((dt.Rows[0]["GRCR_CNTR_CODIGO"] != null) && (dt.Rows[0]["GRCR_CNTR_CODIGO"] != DBNull.Value)) entity.GrcrCntrCodigo = Convert.ToString(dt.Rows[0]["GRCR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["GRCR_ID"] != null) && (dt.Rows[0]["GRCR_ID"] != DBNull.Value)) entity.GrcrId = Convert.ToInt32(dt.Rows[0]["GRCR_ID"]);
            if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            if ((dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_DESCRICAO"]);
            if ((dt.Rows[0]["GRCR_SEQUENCE"] != null) && (dt.Rows[0]["GRCR_SEQUENCE"] != DBNull.Value)) entity.GrcrSequence = Convert.ToInt32(dt.Rows[0]["GRCR_SEQUENCE"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToInt32(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_ID"] != null) && (dt.Rows[0]["FCES_ID"] != DBNull.Value)) entity.FcesId = Convert.ToInt32(dt.Rows[0]["FCES_ID"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FCES_PESO_REL_CRON"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToInt32(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToInt32(dt.Rows[0]["FOSM_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwAcGrupoCriterioMedicaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VW_AC_GRUPO_CRITERIO_MEDICAO Object"); }
        }
        //====================================================================
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcGrupoCriterioMedicaoDTO> list = OracleDataTools.LoadEntity<VwAcGrupoCriterioMedicaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_AC_GRUPO_CRITERIO_MEDICAO>"); }
        }
        //====================================================================
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcGrupoCriterioMedicaoDTO>"); }
        }
        //====================================================================
        public static List<VwAcGrupoCriterioMedicaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcGrupoCriterioMedicaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                //string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                //string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                //if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 1";
                //return GetCollection(Get(filterAUX, sortSequenceAUX));
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcGrupoCriterioMedicaoDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcGrupoCriterioMedicaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcGrupoCriterioMedicaoDTO collection = new DTO.CollectionVwAcGrupoCriterioMedicaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwAcGrupoCriterioMedicaoDTO entity = new DTO.VwAcGrupoCriterioMedicaoDTO();
                    if (dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString().Length != 0) entity.GrcrCntrCodigo = dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["GRCR_ID"].ToString().Length != 0) entity.GrcrId = Convert.ToInt32(dt.Rows[i]["GRCR_ID"]);
                    if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_SIGLA"]);
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = Convert.ToString(dt.Rows[i]["GRCR_NOME"]);
                    if (dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_DESCRICAO"]);
                    if (dt.Rows[i]["GRCR_SEQUENCE"].ToString().Length != 0) entity.GrcrSequence = Convert.ToInt32(dt.Rows[i]["GRCR_SEQUENCE"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToInt32(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = Convert.ToString(dt.Rows[i]["FCME_SIGLA"]);
                    if (dt.Rows[i]["FCES_ID"].ToString().Length != 0) entity.FcesId = Convert.ToInt32(dt.Rows[i]["FCES_ID"]);
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = Convert.ToString(dt.Rows[i]["FCES_SIGLA"]);
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToInt32(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = Convert.ToString(dt.Rows[i]["FOSE_NUMERO"]);
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToInt32(dt.Rows[i]["FOSM_ID"]);
                    collection.Add(entity);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetCollection Method"); }
            dt.Dispose();
            return collection;
        }
        //====================================================================
        private static Hashtable GetDictionary()
        {
            Hashtable dict = new Hashtable();
            dict.Add("GrcrCntrCodigo", "GRCR_CNTR_CODIGO");
            dict.Add("GrcrId", "GRCR_ID");
            dict.Add("GrcrGrupoSigla", "GRCR_GRUPO_SIGLA");
            dict.Add("GrcrNome", "GRCR_NOME");
            dict.Add("GrcrGrupoDescricao", "GRCR_GRUPO_DESCRICAO");
            dict.Add("GrcrSequence", "GRCR_SEQUENCE");
            dict.Add("FcmeId", "FCME_ID");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesId", "FCES_ID");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("FcesPesoRelCron", "FCES_PESO_REL_CRON");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("FosmId", "FOSM_ID");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
