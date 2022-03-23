using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

namespace DAL
{
    public class VwGrupoCriterioMedicaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT GRCR_CNTR_CODIGO, GRCR_ID, GRCR_GRUPO_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_SEQUENCE, GRFC_FCME_ID, FCME_SIGLA FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO ";
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VW_GRUPO_CRITERIO_MEDICAO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_GRUPO_CRITERIO_MEDICAO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_GRUPO_CRITERIO_MEDICAO"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTable VW_GRUPO_CRITERIO_MEDICAO"); }
        }
        ////====================================================================
        public static DTO.VwGrupoCriterioMedicaoDTO Get(string filter)
        {
            VwGrupoCriterioMedicaoDTO entity = new VwGrupoCriterioMedicaoDTO();
            DataTable dt = null;
            dt = Get(filter, null);
            if ((dt.Rows[0]["GRCR_CNTR_CODIGO"] != null) && (dt.Rows[0]["GRCR_CNTR_CODIGO"] != DBNull.Value)) entity.GrcrCntrCodigo = Convert.ToString(dt.Rows[0]["GRCR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["GRCR_ID"] != null) && (dt.Rows[0]["GRCR_ID"] != DBNull.Value)) entity.GrcrId = Convert.ToInt32(dt.Rows[0]["GRCR_ID"]);
            if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            if ((dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_DESCRICAO"]);
            if ((dt.Rows[0]["GRCR_SEQUENCE"] != null) && (dt.Rows[0]["GRCR_SEQUENCE"] != DBNull.Value)) entity.GrcrSequence = Convert.ToInt32(dt.Rows[0]["GRCR_SEQUENCE"]);
            if ((dt.Rows[0]["GRFC_FCME_ID"] != null) && (dt.Rows[0]["GRFC_FCME_ID"] != DBNull.Value)) entity.GrfcFcmeId = Convert.ToInt32(dt.Rows[0]["GRFC_FCME_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.VwGrupoCriterioMedicaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VW_GRUPO_CRITERIO_MEDICAO Object"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwGrupoCriterioMedicaoDTO> list = OracleDataTools.LoadEntity<VwGrupoCriterioMedicaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_GRUPO_CRITERIO_MEDICAO>"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwGrupoCriterioMedicaoDTO>"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwGrupoCriterioMedicaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwGrupoCriterioMedicaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwGrupoCriterioMedicaoDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwGrupoCriterioMedicaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwGrupoCriterioMedicaoDTO collection = new DTO.CollectionVwGrupoCriterioMedicaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwGrupoCriterioMedicaoDTO entity = new DTO.VwGrupoCriterioMedicaoDTO();
                    if (dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString().Length != 0) entity.GrcrCntrCodigo = dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["GRCR_ID"].ToString().Length != 0) entity.GrcrId = Convert.ToInt32(dt.Rows[i]["GRCR_ID"]);
                    if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_SIGLA"]);
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = Convert.ToString(dt.Rows[i]["GRCR_NOME"]);
                    if (dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_DESCRICAO"]);
                    if (dt.Rows[i]["GRCR_SEQUENCE"].ToString().Length != 0) entity.GrcrSequence = Convert.ToInt32(dt.Rows[i]["GRCR_SEQUENCE"]);
                    if (dt.Rows[i]["GRFC_FCME_ID"].ToString().Length != 0) entity.GrfcFcmeId = Convert.ToInt32(dt.Rows[i]["GRFC_FCME_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = Convert.ToString(dt.Rows[i]["FCME_SIGLA"]);
                    
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
            dict.Add("GrfcFcmeId", "GRFC_FCME_ID");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            
            return dict;
        }
        //====================================================================
        #endregion
    }
}
