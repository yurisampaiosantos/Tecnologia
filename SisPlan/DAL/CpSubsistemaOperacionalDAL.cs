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
    public class CpSubsistemaOperacionalDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.SSOP_ID, X.SSOP_CNTR_CODIGO, X.SSOP_DESCRICAO, X.SSOP_SBCN_SIGLA, X.SSOP_CODIGO FROM EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL X ";
        //====================================================================
        public static int Insert(DTO.CpSubsistemaOperacionalDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL(SSOP_CNTR_CODIGO,SSOP_DESCRICAO,SSOP_SBCN_SIGLA,SSOP_CODIGO) VALUES(:SSOP_CNTR_CODIGO,:SSOP_DESCRICAO,:SSOP_SBCN_SIGLA,:SSOP_CODIGO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SSOP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.SsopCntrCodigo;
                cmd.Parameters.Add(":SSOP_DESCRICAO", OracleDbType.Varchar2).Value = entity.SsopDescricao;
                cmd.Parameters.Add(":SSOP_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SsopSbcnSigla;
                cmd.Parameters.Add(":SSOP_CODIGO", OracleDbType.Varchar2).Value = entity.SsopCodigo;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpSubsistemaOperacional");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpSubsistemaOperacional");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpSubsistemaOperacionalDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL set SSOP_CNTR_CODIGO = :SSOP_CNTR_CODIGO, SSOP_DESCRICAO = :SSOP_DESCRICAO, SSOP_SBCN_SIGLA = :SSOP_SBCN_SIGLA, SSOP_CODIGO = :SSOP_CODIGO WHERE  SSOP_ID = :SSOP_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SSOP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.SsopCntrCodigo;
                cmd.Parameters.Add(":SSOP_DESCRICAO", OracleDbType.Varchar2).Value = entity.SsopDescricao;
                cmd.Parameters.Add(":SSOP_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SsopSbcnSigla;
                cmd.Parameters.Add(":SSOP_CODIGO", OracleDbType.Varchar2).Value = entity.SsopCodigo;
                cmd.Parameters.Add(":SSOP_ID", OracleDbType.Decimal).Value = entity.SsopId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpSubsistemaOperacional"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal SsopId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL WHERE SSOP_ID = :SSOP_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SsopId", OracleDbType.Decimal).Value = SsopId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpSubsistemaOperacional"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpSubsistemaOperacional"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpSubsistemaOperacional"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpSubsistemaOperacional"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpSubsistemaOperacional"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpSubsistemaOperacional"); }
        }
        //====================================================================
        public static DTO.CpSubsistemaOperacionalDTO Get(decimal SsopId)
        {
            CpSubsistemaOperacionalDTO entity = new CpSubsistemaOperacionalDTO();
            DataTable dt = null;
            string filter = "SSOP_ID = " + SsopId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SSOP_ID"] != null) && (dt.Rows[0]["SSOP_ID"] != DBNull.Value)) entity.SsopId = Convert.ToDecimal(dt.Rows[0]["SSOP_ID"]);
            if ((dt.Rows[0]["SSOP_CNTR_CODIGO"] != null) && (dt.Rows[0]["SSOP_CNTR_CODIGO"] != DBNull.Value)) entity.SsopCntrCodigo = Convert.ToString(dt.Rows[0]["SSOP_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SSOP_DESCRICAO"] != null) && (dt.Rows[0]["SSOP_DESCRICAO"] != DBNull.Value)) entity.SsopDescricao = Convert.ToString(dt.Rows[0]["SSOP_DESCRICAO"]);
            if ((dt.Rows[0]["SSOP_SBCN_SIGLA"] != null) && (dt.Rows[0]["SSOP_SBCN_SIGLA"] != DBNull.Value)) entity.SsopSbcnSigla = Convert.ToString(dt.Rows[0]["SSOP_SBCN_SIGLA"]);
            if ((dt.Rows[0]["SSOP_CODIGO"] != null) && (dt.Rows[0]["SSOP_CODIGO"] != DBNull.Value)) entity.SsopCodigo = Convert.ToString(dt.Rows[0]["SSOP_CODIGO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpSubsistemaOperacionalDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SSOP_CODIGO Object"); }
        }
        //====================================================================
        public static List<CpSubsistemaOperacionalDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpSubsistemaOperacionalDTO> list = OracleDataTools.LoadEntity<CpSubsistemaOperacionalDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpSubsistemaOperacionalDTO>"); }
        }
        //====================================================================
        public static List<CpSubsistemaOperacionalDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpSubsistemaOperacionalDTO>"); }
        }
        //====================================================================
        public static List<CpSubsistemaOperacionalDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpSubsistemaOperacionalDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpSubsistemaOperacionalDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpSubsistemaOperacional"); }
        }
        //====================================================================
        public static DTO.CollectionCpSubsistemaOperacionalDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpSubsistemaOperacionalDTO collection = new DTO.CollectionCpSubsistemaOperacionalDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpSubsistemaOperacionalDTO entity = new DTO.CpSubsistemaOperacionalDTO();
                    if (dt.Rows[i]["SSOP_ID"].ToString().Length != 0) entity.SsopId = Convert.ToDecimal(dt.Rows[i]["SSOP_ID"]);
                    if (dt.Rows[i]["SSOP_CNTR_CODIGO"].ToString().Length != 0) entity.SsopCntrCodigo = dt.Rows[i]["SSOP_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SSOP_DESCRICAO"].ToString().Length != 0) entity.SsopDescricao = dt.Rows[i]["SSOP_DESCRICAO"].ToString();
                    if (dt.Rows[i]["SSOP_SBCN_SIGLA"].ToString().Length != 0) entity.SsopSbcnSigla = dt.Rows[i]["SSOP_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["SSOP_CODIGO"].ToString().Length != 0) entity.SsopCodigo = dt.Rows[i]["SSOP_CODIGO"].ToString();

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
