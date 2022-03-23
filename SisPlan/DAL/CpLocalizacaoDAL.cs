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
    public class CpLocalizacaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.LOCA_ID, X.LOCA_DESCRICAO, X.LOCA_CNTR_CODIGO FROM CP_LOCALIZACAO X ";
        //====================================================================
        public static int Insert(DTO.CpLocalizacaoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO CP_LOCALIZACAO(LOCA_DESCRICAO,LOCA_CNTR_CODIGO) VALUES(:LOCA_DESCRICAO,:LOCA_CNTR_CODIGO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LOCA_DESCRICAO", OracleDbType.Varchar2).Value = entity.LocaDescricao;
                cmd.Parameters.Add(":LOCA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.LocaCntrCodigo;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpLocalizacao");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpLocalizacao");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpLocalizacaoDTO entity)
        {
            string strSQL = "UPDATE CP_LOCALIZACAO set LOCA_DESCRICAO = :LOCA_DESCRICAO, LOCA_CNTR_CODIGO = :LOCA_CNTR_CODIGO WHERE  LOCA_ID = :LOCA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LOCA_DESCRICAO", OracleDbType.Varchar2).Value = entity.LocaDescricao;
                cmd.Parameters.Add(":LOCA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.LocaCntrCodigo;
                cmd.Parameters.Add(":LOCA_ID", OracleDbType.Decimal).Value = entity.LocaId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpLocalizacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal LocaId)
        {
            string strSQL = "DELETE FROM CP_LOCALIZACAO WHERE LOCA_ID = :LOCA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":LocaId", OracleDbType.Decimal).Value = LocaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpLocalizacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpLocalizacao"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM CP_LOCALIZACAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpLocalizacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpLocalizacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpLocalizacao"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpLocalizacao"); }
        }
        //====================================================================
        public static DTO.CpLocalizacaoDTO Get(decimal LocaId)
        {
            CpLocalizacaoDTO entity = new CpLocalizacaoDTO();
            DataTable dt = null;
            string filter = "LOCA_ID = " + LocaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["LOCA_ID"] != null) && (dt.Rows[0]["LOCA_ID"] != DBNull.Value)) entity.LocaId = Convert.ToDecimal(dt.Rows[0]["LOCA_ID"]);
            if ((dt.Rows[0]["LOCA_DESCRICAO"] != null) && (dt.Rows[0]["LOCA_DESCRICAO"] != DBNull.Value)) entity.LocaDescricao = Convert.ToString(dt.Rows[0]["LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["LOCA_CNTR_CODIGO"] != null) && (dt.Rows[0]["LOCA_CNTR_CODIGO"] != DBNull.Value)) entity.LocaCntrCodigo = Convert.ToString(dt.Rows[0]["LOCA_CNTR_CODIGO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpLocalizacaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting LOCA_CNTR_CODIGO Object"); }
        }
        //====================================================================
        public static List<CpLocalizacaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpLocalizacaoDTO> list = OracleDataTools.LoadEntity<CpLocalizacaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpLocalizacaoDTO>"); }
        }
        //====================================================================
        public static List<CpLocalizacaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpLocalizacaoDTO>"); }
        }
        //====================================================================
        public static List<CpLocalizacaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpLocalizacaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpLocalizacaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpLocalizacao"); }
        }
        //====================================================================
        public static DTO.CollectionCpLocalizacaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpLocalizacaoDTO collection = new DTO.CollectionCpLocalizacaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpLocalizacaoDTO entity = new DTO.CpLocalizacaoDTO();
                    if (dt.Rows[i]["LOCA_ID"].ToString().Length != 0) entity.LocaId = Convert.ToDecimal(dt.Rows[i]["LOCA_ID"]);
                    if (dt.Rows[i]["LOCA_DESCRICAO"].ToString().Length != 0) entity.LocaDescricao = dt.Rows[i]["LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["LOCA_CNTR_CODIGO"].ToString().Length != 0) entity.LocaCntrCodigo = dt.Rows[i]["LOCA_CNTR_CODIGO"].ToString();

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
            dict.Add("LocaId", "LOCA_ID");
            dict.Add("LocaDescricao", "LOCA_DESCRICAO");
            dict.Add("LocaCntrCodigo", "LOCA_CNTR_CODIGO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
