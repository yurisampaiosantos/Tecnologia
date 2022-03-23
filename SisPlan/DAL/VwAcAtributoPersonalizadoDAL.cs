using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================
//====================================================================

namespace DAL
{
    public class VwAcAtributoPersonalizadoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FCME_SIGLA, FCES_SIGLA, ATPE_NOME, DESCRICAO_ATRIBUTO, FOSE_QTD_PREVISTA, FOSM_ID FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO X ";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAcAtributoPersonalizado"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAcAtributoPersonalizado"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAcAtributoPersonalizado"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAcAtributoPersonalizado"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwAcAtributoPersonalizado"); }
        }
        //====================================================================
        public static DTO.VwAcAtributoPersonalizadoDTO Get(decimal ID)
        {
            VwAcAtributoPersonalizadoDTO entity = new VwAcAtributoPersonalizadoDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["ATPE_NOME"] != null) && (dt.Rows[0]["ATPE_NOME"] != DBNull.Value)) entity.AtpeNome = Convert.ToString(dt.Rows[0]["ATPE_NOME"]);
            if ((dt.Rows[0]["DESCRICAO_ATRIBUTO"] != null) && (dt.Rows[0]["DESCRICAO_ATRIBUTO"] != DBNull.Value)) entity.DescricaoAtributo = Convert.ToString(dt.Rows[0]["DESCRICAO_ATRIBUTO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);

            return entity;
        }
        //====================================================================
        public static DTO.VwAcAtributoPersonalizadoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FSME_AVANCO_ACM Object"); }
        }
        //====================================================================
        public static List<VwAcAtributoPersonalizadoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcAtributoPersonalizadoDTO> list = OracleDataTools.LoadEntity<VwAcAtributoPersonalizadoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcAtributoPersonalizadoDTO>"); }
        }
        //====================================================================
        public static List<VwAcAtributoPersonalizadoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcAtributoPersonalizadoDTO>"); }
        }
        //====================================================================
        public static List<VwAcAtributoPersonalizadoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcAtributoPersonalizadoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcAtributoPersonalizado"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcAtributoPersonalizadoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcAtributoPersonalizadoDTO collection = new DTO.CollectionVwAcAtributoPersonalizadoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwAcAtributoPersonalizadoDTO entity = new DTO.VwAcAtributoPersonalizadoDTO();
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[i]["FOSE_CNTR_CODIGO"]);
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["ATPE_NOME"].ToString().Length != 0) entity.AtpeNome = dt.Rows[i]["ATPE_NOME"].ToString();
                    if (dt.Rows[i]["DESCRICAO_ATRIBUTO"].ToString().Length != 0) entity.DescricaoAtributo = dt.Rows[i]["DESCRICAO_ATRIBUTO"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);

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
            dict.Add("FoseCntrCodigo", "FOSE_CNTR_CODIGO");
            dict.Add("SbcnId", "SBCN_ID");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("DiscId", "DISC_ID");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("AtpeNome", "ATPE_NOME");
            dict.Add("DescricaoAtributo", "DESCRICAO_ATRIBUTO");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("FosmId", "FOSM_ID");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
