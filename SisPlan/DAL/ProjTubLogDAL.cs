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
    public class ProjTubLogDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT ID, FILE_NAME, STATUS_ID, STATUS_DESCRIPTION, PROCESS_LOG, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE FROM EEP_CONVERSION.VW_PROJ_TUB_LOG ";
        //====================================================================
        public static int Insert(DTO.ProjTubLogDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO PROJ_TUB_LOG(FILE_NAME,STATUS_ID,PROCESS_LOG,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE) VALUES(:FILE_NAME,:PROCESS_STATUS,:PROCESS_LOG,:CREATED_BY,:CREATED_DATE,:MODIFIED_BY,:MODIFIED_DATE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add(":STATUS_ID", OracleDbType.Decimal).Value = entity.StatusId;
                cmd.Parameters.Add(":PROCESS_LOG", OracleDbType.NVarchar2).Value = entity.ProcessLog;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add(":MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjTubLog");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjTubLog");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjTubLogDTO entity)
        {
            string strSQL = "UPDATE PROJ_TUB_LOG set FILE_NAME = :FILE_NAME, STATUS_ID = :PROCESS_STATUS, PROCESS_LOG = :PROCESS_LOG, CREATED_BY = :CREATED_BY, CREATED_DATE = :CREATED_DATE, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add("STATUS_ID", OracleDbType.Decimal).Value = entity.StatusId;
                cmd.Parameters.Add("PROCESS_LOG", OracleDbType.NVarchar2).Value = entity.ProcessLog;
                cmd.Parameters.Add("CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Decimal).Value = entity.ModifiedDate;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjTubLog"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM PROJ_TUB_LOG WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjTubLog"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubLog"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM PROJ_TUB_LOG";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubLog"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubLog"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubLog"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjTubLog"); }
        }
        //====================================================================
        public static DTO.ProjTubLogDTO Get(decimal ID)
        {
            ProjTubLogDTO entity = new ProjTubLogDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["STATUS_ID"] != null) && (dt.Rows[0]["STATUS_ID"] != DBNull.Value)) entity.StatusId = Convert.ToDecimal(dt.Rows[0]["STATUS_ID"]);
            if ((dt.Rows[0]["PROCESS_LOG"] != null) && (dt.Rows[0]["PROCESS_LOG"] != DBNull.Value)) entity.ProcessLog = Convert.ToString(dt.Rows[0]["PROCESS_LOG"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjTubLogDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MODIFIED_DATE Object"); }
        }
        //====================================================================
        public static List<ProjTubLogDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjTubLogDTO> list = OracleDataTools.LoadEntity<ProjTubLogDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubLogDTO>"); }
        }
        //====================================================================
        public static List<ProjTubLogDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubLogDTO>"); }
        }
        //====================================================================
        public static List<ProjTubLogDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubLogDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubLogDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjTubLog"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubLogDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjTubLogDTO collection = new DTO.CollectionProjTubLogDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjTubLogDTO entity = new DTO.ProjTubLogDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["STATUS_ID"].ToString().Length != 0) entity.StatusId = Convert.ToDecimal(dt.Rows[i]["STATUS_ID"]);
                    if (dt.Rows[i]["PROCESS_LOG"].ToString().Length != 0) entity.ProcessLog = dt.Rows[i]["PROCESS_LOG"].ToString();
                    if (dt.Rows[i]["CREATED_BY"].ToString().Length != 0) entity.CreatedBy = dt.Rows[i]["CREATED_BY"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["MODIFIED_BY"].ToString().Length != 0) entity.ModifiedBy = dt.Rows[i]["MODIFIED_BY"].ToString();
                    if (dt.Rows[i]["MODIFIED_DATE"].ToString().Length != 0) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["MODIFIED_DATE"]);

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
            dict.Add("FileName", "FILE_NAME");
            dict.Add("StatusId", "STATUS_ID");
            dict.Add("ProcessLog", "PROCESS_LOG");
            dict.Add("CreatedBy", "CREATED_BY");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("ModifiedBy", "MODIFIED_BY");
            dict.Add("ModifiedDate", "MODIFIED_DATE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
