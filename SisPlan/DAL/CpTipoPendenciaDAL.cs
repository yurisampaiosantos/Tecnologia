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
    public class CpTipoPendenciaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.TIPE_ID, X.TIPE_DESCRICAO FROM EEP_CONVERSION.CP_TIPO_PENDENCIA X ";
        //====================================================================
        public static int Insert(DTO.CpTipoPendenciaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_TIPO_PENDENCIA(TIPE_DESCRICAO) VALUES(:TIPE_DESCRICAO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TIPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.TipeDescricao;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpTipoPendencia");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpTipoPendencia");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpTipoPendenciaDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_TIPO_PENDENCIA set TIPE_DESCRICAO = :TIPE_DESCRICAO WHERE  TIPE_ID = :TIPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TIPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.TipeDescricao;
                cmd.Parameters.Add(":TIPE_ID", OracleDbType.Decimal).Value = entity.TipeId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpTipoPendencia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal TipeId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_TIPO_PENDENCIA WHERE TIPE_ID = :TIPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TipeId", OracleDbType.Decimal).Value = TipeId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpTipoPendencia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpTipoPendencia"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_TIPO_PENDENCIA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpTipoPendencia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpTipoPendencia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpTipoPendencia"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpTipoPendencia"); }
        }
        //====================================================================
        public static DTO.CpTipoPendenciaDTO Get(decimal TipeId)
        {
            CpTipoPendenciaDTO entity = new CpTipoPendenciaDTO();
            DataTable dt = null;
            string filter = "TIPE_ID = " + TipeId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["TIPE_ID"] != null) && (dt.Rows[0]["TIPE_ID"] != DBNull.Value)) entity.TipeId = Convert.ToDecimal(dt.Rows[0]["TIPE_ID"]);
            if ((dt.Rows[0]["TIPE_DESCRICAO"] != null) && (dt.Rows[0]["TIPE_DESCRICAO"] != DBNull.Value)) entity.TipeDescricao = Convert.ToString(dt.Rows[0]["TIPE_DESCRICAO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpTipoPendenciaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting TIPE_DESCRICAO Object"); }
        }
        //====================================================================
        public static List<CpTipoPendenciaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpTipoPendenciaDTO> list = OracleDataTools.LoadEntity<CpTipoPendenciaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpTipoPendenciaDTO>"); }
        }
        //====================================================================
        public static List<CpTipoPendenciaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpTipoPendenciaDTO>"); }
        }
        //====================================================================
        public static List<CpTipoPendenciaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpTipoPendenciaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpTipoPendenciaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpTipoPendencia"); }
        }
        //====================================================================
        public static DTO.CollectionCpTipoPendenciaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpTipoPendenciaDTO collection = new DTO.CollectionCpTipoPendenciaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpTipoPendenciaDTO entity = new DTO.CpTipoPendenciaDTO();
                    if (dt.Rows[i]["TIPE_ID"].ToString().Length != 0) entity.TipeId = Convert.ToDecimal(dt.Rows[i]["TIPE_ID"]);
                    if (dt.Rows[i]["TIPE_DESCRICAO"].ToString().Length != 0) entity.TipeDescricao = dt.Rows[i]["TIPE_DESCRICAO"].ToString();

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
            dict.Add("TipeId", "TIPE_ID");
            dict.Add("TipeDescricao", "TIPE_DESCRICAO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
