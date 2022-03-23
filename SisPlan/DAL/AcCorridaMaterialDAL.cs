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
    public class AcCorridaMaterialDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.COMA_ID, X.COMA_FILE_NAME, X.COMA_CREATED_BY, TO_CHAR(X.COMA_CREATED_DATE, 'DD/MM/YYYY HH24:MI:SS') AS COMA_CREATED_DATE FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL X ";
        //====================================================================
        public static decimal GetNextval()
        {
            string strSQL = "SELECT EEP_CONVERSION.AC_CORRIDA_MATERIAL_SEQ.NEXTVAL FROM DUAL";
            decimal dRet = OracleDataTools.ExecuteScalar(strSQL);
            return dRet;
        }
        //====================================================================
        public static int Insert(DTO.AcCorridaMaterialDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_CORRIDA_MATERIAL(COMA_ID, COMA_FILE_NAME, COMA_CREATED_BY, COMA_CREATED_DATE) VALUES(:COMA_ID, :COMA_FILE_NAME,:COMA_CREATED_BY, SYSDATE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":COMA_ID", OracleDbType.Decimal).Value = entity.ComaId;
                cmd.Parameters.Add(":COMA_FILE_NAME", OracleDbType.Varchar2).Value = entity.ComaFileName;
                cmd.Parameters.Add(":COMA_CREATED_BY", OracleDbType.NVarchar2).Value = entity.ComaCreatedBy;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcCorridaMaterial");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcCorridaMaterial");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcCorridaMaterialDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_CORRIDA_MATERIAL set COMA_FILE_NAME = :COMA_FILE_NAME, COMA_CREATED_BY = :COMA_CREATED_BY WHERE  COMA_ID = : COMA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("COMA_FILE_NAME", OracleDbType.Varchar2).Value = entity.ComaFileName;
                cmd.Parameters.Add("COMA_CREATED_BY", OracleDbType.NVarchar2).Value = entity.ComaCreatedBy;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcCorridaMaterial"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ComaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL WHERE  COMA_ID = : COMA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ComaId", OracleDbType.Decimal).Value = ComaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcCorridaMaterial"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcCorridaMaterial"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcCorridaMaterial"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcCorridaMaterial"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcCorridaMaterial"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcCorridaMaterial"); }
        }
        //====================================================================
        public static DTO.AcCorridaMaterialDTO Get(decimal ComaId)
        {
            AcCorridaMaterialDTO entity = new AcCorridaMaterialDTO();
            DataTable dt = null;
            string filter = "COMA_ID = " + ComaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["COMA_ID"] != null) && (dt.Rows[0]["COMA_ID"] != DBNull.Value)) entity.ComaId = Convert.ToDecimal(dt.Rows[0]["COMA_ID"]);
            if ((dt.Rows[0]["COMA_FILE_NAME"] != null) && (dt.Rows[0]["COMA_FILE_NAME"] != DBNull.Value)) entity.ComaFileName = Convert.ToString(dt.Rows[0]["COMA_FILE_NAME"]);
            if ((dt.Rows[0]["COMA_CREATED_BY"] != null) && (dt.Rows[0]["COMA_CREATED_BY"] != DBNull.Value)) entity.ComaCreatedBy = Convert.ToString(dt.Rows[0]["COMA_CREATED_BY"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcCorridaMaterialDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcCorridaMaterialDTO> list = OracleDataTools.LoadEntity<AcCorridaMaterialDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialDTO>"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialDTO>"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcCorridaMaterialDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcCorridaMaterial"); }
        }
        //====================================================================
        public static DTO.CollectionAcCorridaMaterialDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcCorridaMaterialDTO collection = new DTO.CollectionAcCorridaMaterialDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcCorridaMaterialDTO entity = new DTO.AcCorridaMaterialDTO();
                    if (dt.Rows[i]["COMA_ID"].ToString().Length != 0) entity.ComaId = Convert.ToDecimal(dt.Rows[i]["COMA_ID"]);
                    if (dt.Rows[i]["COMA_FILE_NAME"].ToString().Length != 0) entity.ComaFileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["COMA_CREATED_BY"].ToString().Length != 0) entity.ComaCreatedBy = dt.Rows[i]["CREATED_BY"].ToString();

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
            dict.Add("ComaId", "COMA_ID");
            dict.Add("ComaFileName", "COMA_FILE_NAME");
            dict.Add("ComaCreatedBy", "COMA_CREATED_BY");

            return dict;
        }
        //====================================================================
        #endregion
    }
}
