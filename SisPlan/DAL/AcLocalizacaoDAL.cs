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
    public class AcLocalizacaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.LOCALIZACAO_ID, X.LOCALIZACAO_NOME FROM EEP_CONVERSION.AC_LOCALIZACAO X ";
        //====================================================================
        public static int Insert(DTO.AcLocalizacaoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_LOCALIZACAO(LOCALIZACAO_NOME) VALUES(:LOCALIZACAO_NOME)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LOCALIZACAO_NOME", OracleDbType.Varchar2).Value = entity.LocalizacaoNome;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcLocalizacao");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcLocalizacao");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcLocalizacaoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_LOCALIZACAO set LOCALIZACAO_NOME = :LOCALIZACAO_NOME WHERE  LOCALIZACAO_ID = :LOCALIZACAO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LOCALIZACAO_NOME", OracleDbType.Varchar2).Value = entity.LocalizacaoNome;
                cmd.Parameters.Add(":LOCALIZACAO_ID", OracleDbType.Decimal).Value = entity.LocalizacaoId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcLocalizacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal LocalizacaoId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_LOCALIZACAO WHERE LOCALIZACAO_ID = :LOCALIZACAO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LocalizacaoId", OracleDbType.Decimal).Value = LocalizacaoId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcLocalizacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcLocalizacao"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_LOCALIZACAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcLocalizacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcLocalizacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcLocalizacao"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcLocalizacao"); }
        }
        //====================================================================
        public static DTO.AcLocalizacaoDTO Get(decimal LocalizacaoId)
        {
            AcLocalizacaoDTO entity = new AcLocalizacaoDTO();
            DataTable dt = null;
            string filter = "LOCALIZACAO_ID = " + LocalizacaoId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["LOCALIZACAO_ID"] != null) && (dt.Rows[0]["LOCALIZACAO_ID"] != DBNull.Value)) entity.LocalizacaoId = Convert.ToDecimal(dt.Rows[0]["LOCALIZACAO_ID"]);
            if ((dt.Rows[0]["LOCALIZACAO_NOME"] != null) && (dt.Rows[0]["LOCALIZACAO_NOME"] != DBNull.Value)) entity.LocalizacaoNome = Convert.ToString(dt.Rows[0]["LOCALIZACAO_NOME"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcLocalizacaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting LOCALIZACAO_NOME Object"); }
        }
        //====================================================================
        public static List<AcLocalizacaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcLocalizacaoDTO> list = OracleDataTools.LoadEntity<AcLocalizacaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcLocalizacaoDTO>"); }
        }
        //====================================================================
        public static List<AcLocalizacaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcLocalizacaoDTO>"); }
        }
        //====================================================================
        public static List<AcLocalizacaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcLocalizacaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcLocalizacaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcLocalizacao"); }
        }
        //====================================================================
        public static DTO.CollectionAcLocalizacaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcLocalizacaoDTO collection = new DTO.CollectionAcLocalizacaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcLocalizacaoDTO entity = new DTO.AcLocalizacaoDTO();
                    if (dt.Rows[i]["LOCALIZACAO_ID"].ToString().Length != 0) entity.LocalizacaoId = Convert.ToDecimal(dt.Rows[i]["LOCALIZACAO_ID"]);
                    if (dt.Rows[i]["LOCALIZACAO_NOME"].ToString().Length != 0) entity.LocalizacaoNome = dt.Rows[i]["LOCALIZACAO_NOME"].ToString();

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
