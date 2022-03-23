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
    public class IntLocaisDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.INLO_ID, X.INLO_NOME FROM EEP_CONVERSION.INT_LOCAIS X ";
        //====================================================================
        public static int Insert(DTO.IntLocaisDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.INT_LOCAIS(INLO_NOME) VALUES(:INLO_NOME)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":INLO_NOME", OracleDbType.Varchar2).Value = entity.InloNome;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting IntLocais");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting IntLocais");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.IntLocaisDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.INT_LOCAIS set INLO_NOME = :INLO_NOME WHERE  INLO_ID = : INLO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":INLO_NOME", OracleDbType.Varchar2).Value = entity.InloNome;
                cmd.Parameters.Add(":INLO_ID", OracleDbType.Varchar2).Value = entity.InloId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating IntLocais"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal InloId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.INT_LOCAIS WHERE  INLO_ID = : INLO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":InloId", OracleDbType.Decimal).Value = InloId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting IntLocais"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting IntLocais"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.INT_LOCAIS";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting IntLocais"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction IntLocais"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction IntLocais"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableIntLocais"); }
        }
        //====================================================================
        public static DTO.IntLocaisDTO Get(decimal InloId)
        {
            IntLocaisDTO entity = new IntLocaisDTO();
            DataTable dt = null;
            string filter = "INLO_ID = " + InloId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["INLO_ID"] != null) && (dt.Rows[0]["INLO_ID"] != DBNull.Value)) entity.InloId = Convert.ToDecimal(dt.Rows[0]["INLO_ID"]);
            if ((dt.Rows[0]["INLO_NOME"] != null) && (dt.Rows[0]["INLO_NOME"] != DBNull.Value)) entity.InloNome = Convert.ToString(dt.Rows[0]["INLO_NOME"]);
            return entity;
        }
        //====================================================================
        public static DTO.IntLocaisDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting INLO_NOME Object"); }
        }
        //====================================================================
        public static List<IntLocaisDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<IntLocaisDTO> list = OracleDataTools.LoadEntity<IntLocaisDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntLocaisDTO>"); }
        }
        //====================================================================
        public static List<IntLocaisDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntLocaisDTO>"); }
        }
        //====================================================================
        public static List<IntLocaisDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntLocaisDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionIntLocais"); }
        }
        //====================================================================
        public static DTO.CollectionIntLocaisDTO GetCollection(DataTable dt)
        {
            DTO.CollectionIntLocaisDTO collection = new DTO.CollectionIntLocaisDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.IntLocaisDTO entity = new DTO.IntLocaisDTO();
                    if (dt.Rows[i]["INLO_ID"].ToString().Length != 0) entity.InloId = Convert.ToDecimal(dt.Rows[i]["INLO_ID"]);
                    if (dt.Rows[i]["INLO_NOME"].ToString().Length != 0) entity.InloNome = dt.Rows[i]["INLO_NOME"].ToString();

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
            dict.Add("InloId", "INLO_ID");
            dict.Add("InloNome", "INLO_NOME");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
