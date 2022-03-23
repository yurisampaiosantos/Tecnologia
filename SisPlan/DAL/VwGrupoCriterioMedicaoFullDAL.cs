using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

namespace DAL
{
    public class VwGrupoCriterioMedicaoFullDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT FCME_DISC_ID, FCME_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_GRUPO_SIGLA, FCME_ID, GRFC_GRCR_ID, GRCR_SEQUENCE FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO_FULL ";
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO_FULL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VW_GRUPO_CRITERIO_MEDICAO_FULL"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_GRUPO_CRITERIO_MEDICAO_FULL"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_GRUPO_CRITERIO_MEDICAO_FULL"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTable VW_GRUPO_CRITERIO_MEDICAO_FULL"); }
        }
        ////====================================================================
        public static DTO.VwGrupoCriterioMedicaoFullDTO Get(string filter)
        {
            VwGrupoCriterioMedicaoFullDTO entity = new VwGrupoCriterioMedicaoFullDTO();
            DataTable dt = null;
            dt = Get(filter, null);

            if ((dt.Rows[0]["FCME_DISC_ID"] != null) && (dt.Rows[0]["FCME_DISC_ID"] != DBNull.Value)) entity.FcmeDiscId = Convert.ToDecimal(dt.Rows[0]["FCME_DISC_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            if ((dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_DESCRICAO"]);
            if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToInt32(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["GRFC_GRCR_ID"] != null) && (dt.Rows[0]["GRFC_GRCR_ID"] != DBNull.Value)) entity.GrfcGrcrId = Convert.ToInt32(dt.Rows[0]["GRFC_GRCR_ID"]);
            if ((dt.Rows[0]["GRCR_SEQUENCE"] != null) && (dt.Rows[0]["GRCR_SEQUENCE"] != DBNull.Value)) entity.GrcrSequence = Convert.ToInt32(dt.Rows[0]["GRCR_SEQUENCE"]);

            return entity;
        }
        //====================================================================
        public static DTO.VwGrupoCriterioMedicaoFullDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VW_GRUPO_CRITERIO_MEDICAO Object"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoFullDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwGrupoCriterioMedicaoFullDTO> list = OracleDataTools.LoadEntity<VwGrupoCriterioMedicaoFullDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_GRUPO_CRITERIO_MEDICAO_FULL>"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoFullDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwGrupoCriterioMedicaoFullDTO>"); }
        }
        //====================================================================
        public static List<VwGrupoCriterioMedicaoFullDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwGrupoCriterioMedicaoFullDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwGrupoCriterioMedicaoFullDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwGrupoCriterioMedicaoFullDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwGrupoCriterioMedicaoFullDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwGrupoCriterioMedicaoFullDTO collection = new DTO.CollectionVwGrupoCriterioMedicaoFullDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwGrupoCriterioMedicaoFullDTO entity = new DTO.VwGrupoCriterioMedicaoFullDTO();

                    if (dt.Rows[i]["FCME_DISC_ID"].ToString().Length != 0) entity.FcmeDiscId = Convert.ToDecimal(dt.Rows[i]["FCME_DISC_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = Convert.ToString(dt.Rows[i]["FCME_SIGLA"]);
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = Convert.ToString(dt.Rows[i]["GRCR_NOME"]);
                    if (dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_DESCRICAO"]);
                    if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[i]["GRCR_GRUPO_SIGLA"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToInt32(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["GRFC_GRCR_ID"].ToString().Length != 0) entity.GrfcGrcrId = Convert.ToInt32(dt.Rows[i]["GRFC_GRCR_ID"]);
                    if (dt.Rows[i]["GRCR_SEQUENCE"].ToString().Length != 0) entity.GrcrSequence = Convert.ToInt32(dt.Rows[i]["GRCR_SEQUENCE"]);

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
            dict.Add("FcmeDiscId", "FCME_DISC_ID");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("GrcrNome", "GRCR_NOME");
            dict.Add("GrcrGrupoDescricao", "GRCR_GRUPO_DESCRICAO");
            dict.Add("GrcrGrupoSigla", "GRCR_GRUPO_SIGLA");
            dict.Add("FcmeId", "FCME_ID");
            dict.Add("GrfcGrcrId", "GRFC_GRCR_ID");
            dict.Add("GrcrSequence", "GRCR_SEQUENCE");

            return dict;
        }
        //====================================================================
        #endregion
    }
}
