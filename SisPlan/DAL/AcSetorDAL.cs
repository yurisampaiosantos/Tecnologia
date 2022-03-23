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
    public class AcSetorDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.SETOR_ID, X.SETOR_NOME FROM EEP_CONVERSION.AC_SETOR X ";
        //====================================================================
        public static int Insert(DTO.AcSetorDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_SETOR(SETOR_NOME) VALUES(:SETOR_NOME)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SETOR_NOME", OracleDbType.Varchar2).Value = entity.SetorNome;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcSetor");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcSetor");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcSetorDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_SETOR set SETOR_NOME = :SETOR_NOME WHERE  SETOR_ID = :SETOR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SETOR_NOME", OracleDbType.Varchar2).Value = entity.SetorNome;
                cmd.Parameters.Add(":SETOR_ID", OracleDbType.Decimal).Value = entity.SetorId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcSetor"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal SetorId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_SETOR WHERE SETOR_ID = :SETOR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SetorId", OracleDbType.Decimal).Value = SetorId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcSetor"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSetor"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_SETOR";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSetor"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSetor"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSetor"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcSetor"); }
        }
        //====================================================================
        public static DTO.AcSetorDTO Get(decimal SetorId)
        {
            AcSetorDTO entity = new AcSetorDTO();
            DataTable dt = null;
            string filter = "SETOR_ID = " + SetorId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SETOR_ID"] != null) && (dt.Rows[0]["SETOR_ID"] != DBNull.Value)) entity.SetorId = Convert.ToDecimal(dt.Rows[0]["SETOR_ID"]);
            if ((dt.Rows[0]["SETOR_NOME"] != null) && (dt.Rows[0]["SETOR_NOME"] != DBNull.Value)) entity.SetorNome = Convert.ToString(dt.Rows[0]["SETOR_NOME"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcSetorDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SETOR_NOME Object"); }
        }
        //====================================================================
        public static List<AcSetorDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcSetorDTO> list = OracleDataTools.LoadEntity<AcSetorDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSetorDTO>"); }
        }
        //====================================================================
        public static List<AcSetorDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSetorDTO>"); }
        }
        //====================================================================
        public static List<AcSetorDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSetorDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcSetorDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcSetor"); }
        }
        //====================================================================
        public static DTO.CollectionAcSetorDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcSetorDTO collection = new DTO.CollectionAcSetorDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcSetorDTO entity = new DTO.AcSetorDTO();
                    if (dt.Rows[i]["SETOR_ID"].ToString().Length != 0) entity.SetorId = Convert.ToDecimal(dt.Rows[i]["SETOR_ID"]);
                    if (dt.Rows[i]["SETOR_NOME"].ToString().Length != 0) entity.SetorNome = dt.Rows[i]["SETOR_NOME"].ToString();

                    collection.Add(entity);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetCollection Method"); }
            dt.Dispose();
            return collection;
        }
        //====================================================================
        #endregion
    }
}
