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
    public class CpStatusMovimentoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.STMO_ID, X.STMO_DESCRICAO, X.STMO_LOCA_ID, X.STMO_SEQUENCE FROM EEP_CONVERSION.CP_STATUS_MOVIMENTO X ";
        //====================================================================
        public static int Insert(DTO.CpStatusMovimentoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_STATUS_MOVIMENTO(STMO_DESCRICAO,STMO_LOCA_ID,STMO_SEQUENCE) VALUES(:STMO_DESCRICAO,:STMO_LOCA_ID,:STMO_SEQUENCE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":STMO_DESCRICAO", OracleDbType.Varchar2).Value = entity.StmoDescricao;
                cmd.Parameters.Add(":STMO_LOCA_ID", OracleDbType.Decimal).Value = entity.StmoLocaId;
                cmd.Parameters.Add(":STMO_SEQUENCE", OracleDbType.Decimal).Value = entity.StmoSequence;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpStatusMovimento");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpStatusMovimento");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpStatusMovimentoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_STATUS_MOVIMENTO set STMO_DESCRICAO = :STMO_DESCRICAO, STMO_LOCA_ID = :STMO_LOCA_ID, STMO_SEQUENCE = :STMO_SEQUENCE WHERE  STMO_ID = :STMO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":STMO_DESCRICAO", OracleDbType.Varchar2).Value = entity.StmoDescricao;
                cmd.Parameters.Add(":STMO_LOCA_ID", OracleDbType.Decimal).Value = entity.StmoLocaId;
                cmd.Parameters.Add(":STMO_SEQUENCE", OracleDbType.Decimal).Value = entity.StmoSequence;
                cmd.Parameters.Add(":STMO_ID", OracleDbType.Decimal).Value = entity.StmoId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpStatusMovimento"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal StmoId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_STATUS_MOVIMENTO WHERE STMO_ID = :STMO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":StmoId", OracleDbType.Decimal).Value = StmoId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpStatusMovimento"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpStatusMovimento"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_STATUS_MOVIMENTO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpStatusMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpStatusMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpStatusMovimento"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpStatusMovimento"); }
        }
        //====================================================================
        public static DTO.CpStatusMovimentoDTO Get(decimal StmoId)
        {
            CpStatusMovimentoDTO entity = new CpStatusMovimentoDTO();
            DataTable dt = null;
            string filter = "STMO_ID = " + StmoId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["STMO_ID"] != null) && (dt.Rows[0]["STMO_ID"] != DBNull.Value)) entity.StmoId = Convert.ToDecimal(dt.Rows[0]["STMO_ID"]);
            if ((dt.Rows[0]["STMO_DESCRICAO"] != null) && (dt.Rows[0]["STMO_DESCRICAO"] != DBNull.Value)) entity.StmoDescricao = Convert.ToString(dt.Rows[0]["STMO_DESCRICAO"]);
            if ((dt.Rows[0]["STMO_LOCA_ID"] != null) && (dt.Rows[0]["STMO_LOCA_ID"] != DBNull.Value)) entity.StmoLocaId = Convert.ToDecimal(dt.Rows[0]["STMO_LOCA_ID"]);
            if ((dt.Rows[0]["STMO_SEQUENCE"] != null) && (dt.Rows[0]["STMO_SEQUENCE"] != DBNull.Value)) entity.StmoSequence = Convert.ToDecimal(dt.Rows[0]["STMO_SEQUENCE"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpStatusMovimentoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting STMO_SEQUENCE Object"); }
        }
        //====================================================================
        public static List<CpStatusMovimentoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpStatusMovimentoDTO> list = OracleDataTools.LoadEntity<CpStatusMovimentoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpStatusMovimentoDTO>"); }
        }
        //====================================================================
        public static List<CpStatusMovimentoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpStatusMovimentoDTO>"); }
        }
        //====================================================================
        public static List<CpStatusMovimentoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpStatusMovimentoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpStatusMovimentoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpStatusMovimento"); }
        }
        //====================================================================
        public static DTO.CollectionCpStatusMovimentoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpStatusMovimentoDTO collection = new DTO.CollectionCpStatusMovimentoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpStatusMovimentoDTO entity = new DTO.CpStatusMovimentoDTO();
                    if (dt.Rows[i]["STMO_ID"].ToString().Length != 0) entity.StmoId = Convert.ToDecimal(dt.Rows[i]["STMO_ID"]);
                    if (dt.Rows[i]["STMO_DESCRICAO"].ToString().Length != 0) entity.StmoDescricao = dt.Rows[i]["STMO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["STMO_LOCA_ID"].ToString().Length != 0) entity.StmoLocaId = Convert.ToDecimal(dt.Rows[i]["STMO_LOCA_ID"]);
                    if (dt.Rows[i]["STMO_SEQUENCE"].ToString().Length != 0) entity.StmoSequence = Convert.ToDecimal(dt.Rows[i]["STMO_SEQUENCE"]);

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
