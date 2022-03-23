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
    public class VwAcQuantidadeAtividadeDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //static string strSelect = @"SELECT X.POCR_CNTR_CODIGO, TO_CHAR(X.POCR_DT,'DD/MM/YYYY') AS POCR_DT, X.ATIV_SIG, X.ATIV_NOME, X.ATRE_QTD, TO_CHAR(X.ATRE_DT_INICIO,'DD/MM/YYYY') AS ATRE_DT_INICIO, TO_CHAR(X.ATRE_DT_FIM,'DD/MM/YYYY') AS ATRE_DT_FIM, X.POCR_ID, X.ATRE_ID, X.ATIV_ID FROM EEP_CONVERSION.VW_AC_QUANTIDADE_ATIVIDADE X ";
        static string strSelect = @"SELECT X.POCR_CNTR_CODIGO, X.ATIV_SIG, X.ATIV_NOME, X.ATRE_QTD, X.ATRE_ID, X.ATIV_ID, MAX(POCR_DT) AS POCR_DT FROM EEP_CONVERSION.VW_AC_QUANTIDADE_ATIVIDADE X";

        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAcQuantidadeAtividadeDTO"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_AC_QUANTIDADE_ATIVIDADE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAcQuantidadeAtividadeDTO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAcQuantidadeAtividadeDTO"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAcQuantidadeAtividadeDTO"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwAcQuantidadeAtividadeDTO"); }
        }
        //====================================================================
        public static DTO.VwAcQuantidadeAtividadeDTO Get(decimal ID)
        {
            VwAcQuantidadeAtividadeDTO entity = new VwAcQuantidadeAtividadeDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);

            if ((dt.Rows[0]["POCR_CNTR_CODIGO"] != null) && (dt.Rows[0]["POCR_CNTR_CODIGO"] != DBNull.Value)) entity.PocrCntrCodigo = Convert.ToString(dt.Rows[0]["POCR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["POCR_DT"] != null) && (dt.Rows[0]["POCR_DT"] != DBNull.Value)) entity.PocrDt = Convert.ToDateTime(dt.Rows[0]["POCR_DT"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["ATIV_NOME"] != null) && (dt.Rows[0]["ATIV_NOME"] != DBNull.Value)) entity.AtivNome = Convert.ToString(dt.Rows[0]["ATIV_NOME"]);
            if ((dt.Rows[0]["ATRE_QTD"] != null) && (dt.Rows[0]["ATRE_QTD"] != DBNull.Value)) entity.AtreQtd = Convert.ToDecimal(dt.Rows[0]["ATRE_QTD"]);
            //if ((dt.Rows[0]["ATRE_DT_INICIO"] != null) && (dt.Rows[0]["ATRE_DT_INICIO"] != DBNull.Value)) entity.AtreDtInicio = Convert.ToDateTime(dt.Rows[0]["ATRE_DT_INICIO"]);
            //if ((dt.Rows[0]["ATRE_DT_FIM"] != null) && (dt.Rows[0]["ATRE_DT_FIM"] != DBNull.Value)) entity.AtreDtFim = Convert.ToDateTime(dt.Rows[0]["ATRE_DT_FIM"]);
            //if ((dt.Rows[0]["POCR_ID"] != null) && (dt.Rows[0]["POCR_ID"] != DBNull.Value)) entity.PocrId = Convert.ToDecimal(dt.Rows[0]["POCR_ID"]);
            if ((dt.Rows[0]["ATRE_ID"] != null) && (dt.Rows[0]["ATRE_ID"] != DBNull.Value)) entity.AtreId = Convert.ToDecimal(dt.Rows[0]["ATRE_ID"]);
            if ((dt.Rows[0]["ATIV_ID"] != null) && (dt.Rows[0]["ATIV_ID"] != DBNull.Value)) entity.AtivId = Convert.ToDecimal(dt.Rows[0]["ATIV_ID"]);

            return entity;
        }
        //====================================================================
        public static DTO.VwAcQuantidadeAtividadeDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VwAcQuantidadeAtividadeDTO Object"); }
        }
        //====================================================================
        public static List<VwAcQuantidadeAtividadeDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcQuantidadeAtividadeDTO> list = OracleDataTools.LoadEntity<VwAcQuantidadeAtividadeDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcQuantidadeAtividadeDTO>"); }
        }
        //====================================================================
        public static List<VwAcQuantidadeAtividadeDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcQuantidadeAtividadeDTO>"); }
        }
        //====================================================================
        public static List<VwAcQuantidadeAtividadeDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcQuantidadeAtividadeDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcQuantidadeAtividadeDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcQuantidadeAtividadeDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcQuantidadeAtividadeDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcQuantidadeAtividadeDTO collection = new DTO.CollectionVwAcQuantidadeAtividadeDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwAcQuantidadeAtividadeDTO entity = new DTO.VwAcQuantidadeAtividadeDTO();
                    if (dt.Rows[i]["POCR_CNTR_CODIGO"].ToString().Length != 0) entity.PocrCntrCodigo = Convert.ToString(dt.Rows[i]["POCR_CNTR_CODIGO"]);
                    if (dt.Rows[i]["POCR_DT"].ToString().Length != 0) entity.PocrDt = Convert.ToDateTime(dt.Rows[i]["POCR_DT"]);
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = dt.Rows[i]["ATIV_SIG"].ToString();
                    if (dt.Rows[i]["ATIV_NOME"].ToString().Length != 0) entity.AtivNome = Convert.ToString(dt.Rows[i]["ATIV_NOME"]);
                    if (dt.Rows[i]["ATRE_QTD"].ToString().Length != 0) entity.AtreQtd = Convert.ToDecimal(dt.Rows[i]["ATRE_QTD"]);
                    //if (dt.Rows[i]["ATRE_DT_INICIO"].ToString().Length != 0) entity.AtreDtInicio = Convert.ToDateTime(dt.Rows[i]["ATRE_DT_INICIO"]);
                    //if (dt.Rows[i]["ATRE_DT_FIM"].ToString().Length != 0) entity.AtreDtFim = Convert.ToDateTime(dt.Rows[i]["ATRE_DT_FIM"]);
                    //if (dt.Rows[i]["POCR_ID"].ToString().Length != 0) entity.PocrId = Convert.ToDecimal(dt.Rows[i]["POCR_ID"]);
                    if (dt.Rows[i]["ATRE_ID"].ToString().Length != 0) entity.AtreId = Convert.ToDecimal(dt.Rows[i]["ATRE_ID"]);
                    if (dt.Rows[i]["ATIV_ID"].ToString().Length != 0) entity.AtivId = Convert.ToDecimal(dt.Rows[i]["ATIV_ID"]);

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
            dict.Add("PocrCntrCodigo", "POCR_CNTR_CODIGO");
            dict.Add("PocrDt", "POCR_DT");
            dict.Add("AtivSig", "ATIV_SIG");
            dict.Add("AtivNome", "ATIV_NOME");
            dict.Add("AtreQtd", "ATRE_QTD");
            dict.Add("AtreDtInicio", "ATRE_DT_INICIO");
            dict.Add("AtreDtFim", "ATRE_DT_FIM");
            dict.Add("PocrId", "POCR_ID");
            dict.Add("AtreId", "ATRE_ID");
            dict.Add("AtivId", "ATIV_ID");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
