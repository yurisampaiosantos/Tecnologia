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
    public class ProjTubHistoryDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, TO_CHAR(X.PROCESS_HISTORY_DATE,'DD/MM/YYYY HH24:MI:SS') AS PROCESS_HISTORY_DATE, X.FILE_NAME, X.PROCESS_HISTORY FROM EEP_CONVERSION.PROJ_TUB_HISTORY X ";
        //====================================================================
        public static int Insert(DTO.ProjTubHistoryDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_TUB_HISTORY(FILE_NAME,PROCESS_HISTORY,STATUS) VALUES(:FILE_NAME,:PROCESS_HISTORY,:STATUS)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {

                cmd.Parameters.Add(":FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add(":PROCESS_HISTORY", OracleDbType.NVarchar2).Value = entity.ProcessHistory;
                cmd.Parameters.Add(":STATUS", OracleDbType.Varchar2).Value = entity.Status;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjTubHistory");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjTubHistory");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjTubHistoryDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_TUB_HISTORY set PROCESS_HISTORY_DATE = :PROCESS_HISTORY_DATE, FILE_NAME = :FILE_NAME, PROCESS_HISTORY = :PROCESS_HISTORY, STATUS = :STATUS WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                if (entity.ProcessHistoryDate.ToOADate() == 0.0) cmd.Parameters.Add("PROCESS_HISTORY_DATE", OracleDbType.Date).Value = entity.ProcessHistoryDate;
                else cmd.Parameters.Add("PROCESS_HISTORY_DATE", OracleDbType.Date).Value = entity.ProcessHistoryDate;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add("PROCESS_HISTORY", OracleDbType.NVarchar2).Value = entity.ProcessHistory;
                cmd.Parameters.Add("STATUS", OracleDbType.Varchar2).Value = entity.Status;
                cmd.Parameters.Add("ID", OracleDbType.Decimal).Value = entity.ID;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjTubHistory"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_TUB_HISTORY WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjTubHistory"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubHistory"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_TUB_HISTORY";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubHistory"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubHistory"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubHistory"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjTubHistory"); }
        }
        //====================================================================
        public static DTO.ProjTubHistoryDTO Get(decimal ID)
        {
            ProjTubHistoryDTO entity = new ProjTubHistoryDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["PROCESS_HISTORY_DATE"] != null) && (dt.Rows[0]["PROCESS_HISTORY_DATE"] != DBNull.Value)) entity.ProcessHistoryDate = Convert.ToDateTime(dt.Rows[0]["PROCESS_HISTORY_DATE"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["PROCESS_HISTORY"] != null) && (dt.Rows[0]["PROCESS_HISTORY"] != DBNull.Value)) entity.ProcessHistory = Convert.ToString(dt.Rows[0]["PROCESS_HISTORY"]);
            if ((dt.Rows[0]["STATUS"] != null) && (dt.Rows[0]["STATUS"] != DBNull.Value)) entity.Status = Convert.ToString(dt.Rows[0]["STATUS"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjTubHistoryDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting STATUS Object"); }
        }
        //====================================================================
        public static List<ProjTubHistoryDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjTubHistoryDTO> list = OracleDataTools.LoadEntity<ProjTubHistoryDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubHistoryDTO>"); }
        }
        //====================================================================
        public static List<ProjTubHistoryDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubHistoryDTO>"); }
        }
        //====================================================================
        public static List<ProjTubHistoryDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubHistoryDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubHistoriesDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjTubHistories"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubHistoriesDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjTubHistoriesDTO collection = new DTO.CollectionProjTubHistoriesDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjTubHistoryDTO entity = new DTO.ProjTubHistoryDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["PROCESS_HISTORY_DATE"].ToString().Length != 0) entity.ProcessHistoryDate = Convert.ToDateTime(dt.Rows[i]["PROCESS_HISTORY_DATE"]);
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["PROCESS_HISTORY"].ToString().Length != 0) entity.ProcessHistory = dt.Rows[i]["PROCESS_HISTORY"].ToString();
                    if (dt.Rows[i]["STATUS"].ToString().Length != 0) entity.Status = dt.Rows[i]["STATUS"].ToString();

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
            dict.Add("ID", "ID");
            dict.Add("ProcessHistoryDate", "PROCESS_HISTORY_DATE");
            dict.Add("FileName", "FILE_NAME");
            dict.Add("ProcessHistory", "PROCESS_HISTORY");
            dict.Add("Status", "STATUS");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
