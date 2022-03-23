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
    public class CpMovimentoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.MOVI_ID, X.MOVI_CNTR_CODIGO, X.MOVI_PASTA_ID, X.MOVI_USUA_LOGIN, TO_CHAR(X.MOVI_DATE,'DD/MM/YYYY HH24:MI:SS') AS MOVI_DATE, X.MOVI_CREATED_BY, X.MOVI_IN_GRD FROM CP_MOVIMENTO X ";
        //====================================================================
        public static int Insert(DTO.CpMovimentoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_MOVIMENTO(MOVI_CNTR_CODIGO,MOVI_PASTA_ID,MOVI_USUA_LOGIN,MOVI_CREATED_BY, MOVI_STMO_ID, MOVI_IN_GRD) VALUES(:MOVI_CNTR_CODIGO,:MOVI_PASTA_ID,:MOVI_USUA_LOGIN,:MOVI_CREATED_BY, :MOVI_STMO_ID, :MOVI_IN_GRD)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MOVI_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.MoviCntrCodigo;
                cmd.Parameters.Add(":MOVI_PASTA_ID", OracleDbType.Decimal).Value = entity.MoviPastaId;
                cmd.Parameters.Add(":MOVI_USUA_LOGIN", OracleDbType.Varchar2).Value = entity.MoviUsuaLogin;
                cmd.Parameters.Add(":MOVI_CREATED_BY", OracleDbType.Varchar2).Value = entity.MoviCreatedBy;
                cmd.Parameters.Add(":MOVI_STMO_ID", OracleDbType.Decimal).Value = entity.MoviStmoId;
                cmd.Parameters.Add(":MOVI_IN_GRD", OracleDbType.Decimal).Value = entity.MoviInGRD;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpMovimento");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpMovimento");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpMovimentoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_MOVIMENTO set MOVI_CNTR_CODIGO = :MOVI_CNTR_CODIGO, MOVI_PASTA_ID = :MOVI_PASTA_ID, MOVI_USUA_LOGIN = :MOVI_USUA_LOGIN, MOVI_CREATED_BY = :MOVI_CREATED_BY, MOVI_STMO_ID = :MOVI_STMO_ID, MOVI_IN_GRD = :MOVI_IN_GRD WHERE MOVI_ID = :MOVI_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MOVI_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.MoviCntrCodigo;
                cmd.Parameters.Add(":MOVI_PASTA_ID", OracleDbType.Decimal).Value = entity.MoviPastaId;
                cmd.Parameters.Add(":MOVI_USUA_LOGIN", OracleDbType.Varchar2).Value = entity.MoviUsuaLogin;
                //if (entity.MoviDate.ToOADate() == 0.0) cmd.Parameters.Add(":MOVI_DATE", OracleDbType.Date).Value = entity.MoviDate;
                //else cmd.Parameters.Add(":MOVI_DATE", OracleDbType.Date).Value = entity.MoviDate;
                cmd.Parameters.Add(":MOVI_CREATED_BY", OracleDbType.Varchar2).Value = entity.MoviCreatedBy;
                cmd.Parameters.Add(":MOVI_STMO_ID", OracleDbType.Decimal).Value = entity.MoviStmoId;
                cmd.Parameters.Add(":MOVI_IN_GRD", OracleDbType.Decimal).Value = entity.MoviInGRD;
                
                cmd.Parameters.Add(":MOVI_ID", OracleDbType.Decimal).Value = entity.MoviId;
                
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpMovimento"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal MoviId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_MOVIMENTO WHERE MOVI_ID = :MOVI_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MoviId", OracleDbType.Decimal).Value = MoviId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpMovimento"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpMovimento"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) EEP_CONVERSION.FROM CP_MOVIMENTO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpMovimento"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpMovimento"); }
        }
        //====================================================================
        public static DTO.CpMovimentoDTO Get(decimal MoviId)
        {
            CpMovimentoDTO entity = new CpMovimentoDTO();
            DataTable dt = null;
            string filter = "MOVI_ID = " + MoviId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MOVI_ID"] != null) && (dt.Rows[0]["MOVI_ID"] != DBNull.Value)) entity.MoviId = Convert.ToDecimal(dt.Rows[0]["MOVI_ID"]);
            if ((dt.Rows[0]["MOVI_CNTR_CODIGO"] != null) && (dt.Rows[0]["MOVI_CNTR_CODIGO"] != DBNull.Value)) entity.MoviCntrCodigo = Convert.ToString(dt.Rows[0]["MOVI_CNTR_CODIGO"]);
            if ((dt.Rows[0]["MOVI_PASTA_ID"] != null) && (dt.Rows[0]["MOVI_PASTA_ID"] != DBNull.Value)) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[0]["MOVI_PASTA_ID"]);
            if ((dt.Rows[0]["MOVI_USUA_LOGIN"] != null) && (dt.Rows[0]["MOVI_USUA_LOGIN"] != DBNull.Value)) entity.MoviUsuaLogin = Convert.ToString(dt.Rows[0]["MOVI_USUA_LOGIN"]);
            if ((dt.Rows[0]["MOVI_DATE"] != null) && (dt.Rows[0]["MOVI_DATE"] != DBNull.Value)) entity.MoviDate = Convert.ToDateTime(dt.Rows[0]["MOVI_DATE"]);
            if ((dt.Rows[0]["MOVI_CREATED_BY"] != null) && (dt.Rows[0]["MOVI_CREATED_BY"] != DBNull.Value)) entity.MoviCreatedBy = Convert.ToString(dt.Rows[0]["MOVI_CREATED_BY"]);
            if ((dt.Rows[0]["MOVI_STMO_ID"] != null) && (dt.Rows[0]["MOVI_STMO_ID"] != DBNull.Value)) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[0]["MOVI_STMO_ID"]);
            if ((dt.Rows[0]["MOVI_IN_GRD"] != null) && (dt.Rows[0]["MOVI_IN_GRD"] != DBNull.Value)) entity.MoviInGRD = Convert.ToDecimal(dt.Rows[0]["MOVI_IN_GRD"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.CpMovimentoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MOVI_CREATED_BY Object"); }
        }
        //====================================================================
        public static List<CpMovimentoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpMovimentoDTO> list = OracleDataTools.LoadEntity<CpMovimentoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMovimentoDTO>"); }
        }
        //====================================================================
        public static List<CpMovimentoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMovimentoDTO>"); }
        }
        //====================================================================
        public static List<CpMovimentoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMovimentoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpMovimentoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpMovimento"); }
        }
        //====================================================================
        public static DTO.CollectionCpMovimentoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpMovimentoDTO collection = new DTO.CollectionCpMovimentoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpMovimentoDTO entity = new DTO.CpMovimentoDTO();
                    if (dt.Rows[i]["MOVI_ID"].ToString().Length != 0) entity.MoviId = Convert.ToDecimal(dt.Rows[i]["MOVI_ID"]);
                    if (dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString().Length != 0) entity.MoviCntrCodigo = dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["MOVI_PASTA_ID"].ToString().Length != 0) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[i]["MOVI_PASTA_ID"]);
                    if (dt.Rows[i]["MOVI_USUA_LOGIN"].ToString().Length != 0) entity.MoviUsuaLogin = dt.Rows[i]["MOVI_USUA_LOGIN"].ToString();
                    if (dt.Rows[i]["MOVI_DATE"].ToString().Length != 0) entity.MoviDate = Convert.ToDateTime(dt.Rows[i]["MOVI_DATE"]);
                    if (dt.Rows[i]["MOVI_CREATED_BY"].ToString().Length != 0) entity.MoviCreatedBy = dt.Rows[i]["MOVI_CREATED_BY"].ToString();
                    if (dt.Rows[i]["MOVI_STMO_ID"].ToString().Length != 0) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[i]["MOVI_STMO_ID"]);
                    if (dt.Rows[i]["MOVI_IN_GRD"].ToString().Length != 0) entity.MoviInGRD = Convert.ToDecimal(dt.Rows[i]["MOVI_IN_GRD"]);

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
