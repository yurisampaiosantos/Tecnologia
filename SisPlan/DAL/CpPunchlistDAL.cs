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
    public class CpPunchlistDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.PUNCH_ID, X.PUNCH_CNTR_CODIGO, X.PUNCH_PASTA_ID, X.PUNCH_DESCRICAO, X.PUNCH_TIPE_ID, TO_CHAR(X.PUNCH_DATA_PROMETIDA,'DD/MM/YYYY') AS PUNCH_DATA_PROMETIDA, X.PUNCH_RESPONSIBLE_BY, X.PUNCH_STPU_ID, X.PUNCH_APPROVED_BY, TO_CHAR(X.PUNCH_APPROVED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_APPROVED_DATE, X.PUNCH_CREATED_BY, TO_CHAR(X.PUNCH_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_CREATED_DATE, TO_CHAR(X.PUNCH_DATA_CONCLUIDA,'DD/MM/YYYY') AS PUNCH_DATA_CONCLUIDA, X.PUNCH_ARPE_ID, X.PUNCH_SITUACAO, X.PUNCH_IMPEDITIVA FROM EEP_CONVERSION.CP_PUNCHLIST X ";
        //====================================================================
        public static int Insert(DTO.CpPunchlistDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_PUNCHLIST(PUNCH_CNTR_CODIGO,PUNCH_PASTA_ID,PUNCH_DESCRICAO,PUNCH_TIPE_ID,PUNCH_DATA_PROMETIDA,PUNCH_RESPONSIBLE_BY,PUNCH_STPU_ID,PUNCH_APPROVED_BY,PUNCH_APPROVED_DATE,PUNCH_CREATED_BY,PUNCH_CREATED_DATE,PUNCH_DATA_CONCLUIDA,PUNCH_ARPE_ID,PUNCH_SITUACAO,PUNCH_IMPEDITIVA) VALUES  (:PUNCH_CNTR_CODIGO,:PUNCH_PASTA_ID,:PUNCH_DESCRICAO,:PUNCH_TIPE_ID,:PUNCH_DATA_PROMETIDA,:PUNCH_RESPONSIBLE_BY,:PUNCH_STPU_ID,:PUNCH_APPROVED_BY,:PUNCH_APPROVED_DATE,:PUNCH_CREATED_BY,:PUNCH_CREATED_DATE,:PUNCH_DATA_CONCLUIDA,:PUNCH_ARPE_ID,:PUNCH_SITUACAO, :PUNCH_IMPEDITIVA)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PUNCH_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PunchCntrCodigo;
                cmd.Parameters.Add(":PUNCH_PASTA_ID", OracleDbType.Decimal).Value = entity.PunchPastaId;
                cmd.Parameters.Add(":PUNCH_DESCRICAO", OracleDbType.Varchar2).Value = entity.PunchDescricao;
                cmd.Parameters.Add(":PUNCH_TIPE_ID", OracleDbType.Decimal).Value = entity.PunchTipeId;
                
                //if (entity.PunchDataPrometida.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_DATA_PROMETIDA", OracleDbType.Date).Value = entity.PunchDataPrometida;
                //else 
                cmd.Parameters.Add(":PUNCH_DATA_PROMETIDA", OracleDbType.Date).Value = entity.PunchDataPrometida;
                
                cmd.Parameters.Add(":PUNCH_RESPONSIBLE_BY", OracleDbType.Varchar2).Value = entity.PunchResponsibleBy;
                cmd.Parameters.Add(":PUNCH_STPU_ID", OracleDbType.Decimal).Value = entity.PunchStpuId;
                cmd.Parameters.Add(":PUNCH_APPROVED_BY", OracleDbType.Varchar2).Value = entity.PunchApprovedBy;
                
                //if (entity.PunchApprovedDate.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_APPROVED_DATE", OracleDbType.Date).Value = entity.PunchApprovedDate;
                //else 
                cmd.Parameters.Add(":PUNCH_APPROVED_DATE", OracleDbType.Date).Value = entity.PunchApprovedDate;
                
                cmd.Parameters.Add(":PUNCH_CREATED_BY", OracleDbType.Varchar2).Value = entity.PunchCreatedBy;
                //if (entity.PunchCreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_CREATED_DATE", OracleDbType.Date).Value = entity.PunchCreatedDate;
                //else 
                
                cmd.Parameters.Add(":PUNCH_CREATED_DATE", OracleDbType.Date).Value = DateTime.Now;
                
                //if (entity.PunchDataConcluida.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_DATA_CONCLUIDA", OracleDbType.Date).Value = entity.PunchDataConcluida;
                //else 
                cmd.Parameters.Add(":PUNCH_DATA_CONCLUIDA", OracleDbType.Date).Value = entity.PunchDataConcluida;
                
                cmd.Parameters.Add(":PUNCH_ARPE_ID", OracleDbType.Decimal).Value = entity.PunchArpeId;
                cmd.Parameters.Add(":PUNCH_SITUACAO", OracleDbType.Varchar2).Value = entity.PunchSituacao;
                cmd.Parameters.Add(":PUNCH_IMPEDITIVA", OracleDbType.Decimal).Value = entity.PunchImpeditiva;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpPunchlist");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpPunchlist");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpPunchlistDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_PUNCHLIST set PUNCH_CNTR_CODIGO = :PUNCH_CNTR_CODIGO, PUNCH_PASTA_ID = :PUNCH_PASTA_ID, PUNCH_DESCRICAO = :PUNCH_DESCRICAO, PUNCH_TIPE_ID = :PUNCH_TIPE_ID, PUNCH_DATA_PROMETIDA = :PUNCH_DATA_PROMETIDA, PUNCH_RESPONSIBLE_BY = :PUNCH_RESPONSIBLE_BY, PUNCH_STPU_ID = :PUNCH_STPU_ID, PUNCH_APPROVED_BY = :PUNCH_APPROVED_BY, PUNCH_APPROVED_DATE = :PUNCH_APPROVED_DATE, PUNCH_CREATED_BY = :PUNCH_CREATED_BY, PUNCH_CREATED_DATE = :PUNCH_CREATED_DATE, PUNCH_DATA_CONCLUIDA = :PUNCH_DATA_CONCLUIDA, PUNCH_ARPE_ID = :PUNCH_ARPE_ID, PUNCH_SITUACAO = :PUNCH_SITUACAO, PUNCH_IMPEDITIVA = :PUNCH_IMPEDITIVA WHERE  PUNCH_ID = :PUNCH_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PUNCH_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PunchCntrCodigo;
                cmd.Parameters.Add(":PUNCH_PASTA_ID", OracleDbType.Decimal).Value = entity.PunchPastaId;
                cmd.Parameters.Add(":PUNCH_DESCRICAO", OracleDbType.Varchar2).Value = entity.PunchDescricao;
                cmd.Parameters.Add(":PUNCH_TIPE_ID", OracleDbType.Decimal).Value = entity.PunchTipeId;
                
                //if (entity.PunchDataPrometida.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_DATA_PROMETIDA", OracleDbType.Date).Value = entity.PunchDataPrometida;
                //else 
                cmd.Parameters.Add(":PUNCH_DATA_PROMETIDA", OracleDbType.Date).Value = entity.PunchDataPrometida;
                
                cmd.Parameters.Add(":PUNCH_RESPONSIBLE_BY", OracleDbType.Varchar2).Value = entity.PunchResponsibleBy;
                cmd.Parameters.Add(":PUNCH_STPU_ID", OracleDbType.Decimal).Value = entity.PunchStpuId;
                cmd.Parameters.Add(":PUNCH_APPROVED_BY", OracleDbType.Varchar2).Value = entity.PunchApprovedBy;
                
                //if (entity.PunchApprovedDate.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_APPROVED_DATE", OracleDbType.Date).Value = entity.PunchApprovedDate;
                //else 
                cmd.Parameters.Add(":PUNCH_APPROVED_DATE", OracleDbType.Date).Value = entity.PunchApprovedDate;
                
                cmd.Parameters.Add(":PUNCH_CREATED_BY", OracleDbType.Varchar2).Value = entity.PunchCreatedBy;
                if (entity.PunchCreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_CREATED_DATE", OracleDbType.Date).Value = entity.PunchCreatedDate;
                else cmd.Parameters.Add(":PUNCH_CREATED_DATE", OracleDbType.Date).Value = entity.PunchCreatedDate;
                
                //if (entity.PunchDataConcluida.ToOADate() == 0.0) cmd.Parameters.Add(":PUNCH_DATA_CONCLUIDA", OracleDbType.Date).Value = entity.PunchDataConcluida;
                //else 
                cmd.Parameters.Add(":PUNCH_DATA_CONCLUIDA", OracleDbType.Date).Value = entity.PunchDataConcluida;
                
                cmd.Parameters.Add(":PUNCH_ARPE_ID", OracleDbType.Decimal).Value = entity.PunchArpeId;
                cmd.Parameters.Add(":PUNCH_SITUACAO", OracleDbType.Varchar2).Value = entity.PunchSituacao;
                cmd.Parameters.Add(":PUNCH_IMPEDITIVA", OracleDbType.Decimal).Value = entity.PunchImpeditiva;
                cmd.Parameters.Add(":PUNCH_ID", OracleDbType.Decimal).Value = entity.PunchId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpPunchlist"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal PunchId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_PUNCHLIST WHERE PUNCH_ID = :PUNCH_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PunchId", OracleDbType.Decimal).Value = PunchId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpPunchlist"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPunchlist"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_PUNCHLIST";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPunchlist"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPunchlist"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPunchlist"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpPunchlist"); }
        }
        //====================================================================
        public static DTO.CpPunchlistDTO Get(decimal PunchId)
        {
            CpPunchlistDTO entity = new CpPunchlistDTO();
            DataTable dt = null;
            string filter = "PUNCH_ID = " + PunchId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PUNCH_ID"] != null) && (dt.Rows[0]["PUNCH_ID"] != DBNull.Value)) entity.PunchId = Convert.ToDecimal(dt.Rows[0]["PUNCH_ID"]);
            if ((dt.Rows[0]["PUNCH_CNTR_CODIGO"] != null) && (dt.Rows[0]["PUNCH_CNTR_CODIGO"] != DBNull.Value)) entity.PunchCntrCodigo = Convert.ToString(dt.Rows[0]["PUNCH_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PUNCH_PASTA_ID"] != null) && (dt.Rows[0]["PUNCH_PASTA_ID"] != DBNull.Value)) entity.PunchPastaId = Convert.ToDecimal(dt.Rows[0]["PUNCH_PASTA_ID"]);
            if ((dt.Rows[0]["PUNCH_DESCRICAO"] != null) && (dt.Rows[0]["PUNCH_DESCRICAO"] != DBNull.Value)) entity.PunchDescricao = Convert.ToString(dt.Rows[0]["PUNCH_DESCRICAO"]);
            if ((dt.Rows[0]["PUNCH_TIPE_ID"] != null) && (dt.Rows[0]["PUNCH_TIPE_ID"] != DBNull.Value)) entity.PunchTipeId = Convert.ToDecimal(dt.Rows[0]["PUNCH_TIPE_ID"]);
            if ((dt.Rows[0]["PUNCH_DATA_PROMETIDA"] != null) && (dt.Rows[0]["PUNCH_DATA_PROMETIDA"] != DBNull.Value)) entity.PunchDataPrometida = Convert.ToDateTime(dt.Rows[0]["PUNCH_DATA_PROMETIDA"]);
            if ((dt.Rows[0]["PUNCH_RESPONSIBLE_BY"] != null) && (dt.Rows[0]["PUNCH_RESPONSIBLE_BY"] != DBNull.Value)) entity.PunchResponsibleBy = Convert.ToString(dt.Rows[0]["PUNCH_RESPONSIBLE_BY"]);
            if ((dt.Rows[0]["PUNCH_STPU_ID"] != null) && (dt.Rows[0]["PUNCH_STPU_ID"] != DBNull.Value)) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[0]["PUNCH_STPU_ID"]);
            if ((dt.Rows[0]["PUNCH_APPROVED_BY"] != null) && (dt.Rows[0]["PUNCH_APPROVED_BY"] != DBNull.Value)) entity.PunchApprovedBy = Convert.ToString(dt.Rows[0]["PUNCH_APPROVED_BY"]);
            if ((dt.Rows[0]["PUNCH_APPROVED_DATE"] != null) && (dt.Rows[0]["PUNCH_APPROVED_DATE"] != DBNull.Value)) entity.PunchApprovedDate = Convert.ToDateTime(dt.Rows[0]["PUNCH_APPROVED_DATE"]);
            if ((dt.Rows[0]["PUNCH_CREATED_BY"] != null) && (dt.Rows[0]["PUNCH_CREATED_BY"] != DBNull.Value)) entity.PunchCreatedBy = Convert.ToString(dt.Rows[0]["PUNCH_CREATED_BY"]);
            if ((dt.Rows[0]["PUNCH_CREATED_DATE"] != null) && (dt.Rows[0]["PUNCH_CREATED_DATE"] != DBNull.Value)) entity.PunchCreatedDate = Convert.ToDateTime(dt.Rows[0]["PUNCH_CREATED_DATE"]);
            if ((dt.Rows[0]["PUNCH_DATA_CONCLUIDA"] != null) && (dt.Rows[0]["PUNCH_DATA_CONCLUIDA"] != DBNull.Value)) entity.PunchDataConcluida = Convert.ToDateTime(dt.Rows[0]["PUNCH_DATA_CONCLUIDA"]);
            if ((dt.Rows[0]["PUNCH_ARPE_ID"] != null) && (dt.Rows[0]["PUNCH_ARPE_ID"] != DBNull.Value)) entity.PunchArpeId = Convert.ToDecimal(dt.Rows[0]["PUNCH_ARPE_ID"]);
            if ((dt.Rows[0]["PUNCH_SITUACAO"] != null) && (dt.Rows[0]["PUNCH_SITUACAO"] != DBNull.Value)) entity.PunchSituacao = Convert.ToString(dt.Rows[0]["PUNCH_SITUACAO"]);
            if ((dt.Rows[0]["PUNCH_IMPEDITIVA"] != null) && (dt.Rows[0]["PUNCH_IMPEDITIVA"] != DBNull.Value)) entity.PunchImpeditiva = Convert.ToDecimal(dt.Rows[0]["PUNCH_IMPEDITIVA"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpPunchlistDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PUNCH_IMPEDITIVA Object"); }
        }
        //====================================================================
        public static List<CpPunchlistDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpPunchlistDTO> list = OracleDataTools.LoadEntity<CpPunchlistDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPunchlistDTO>"); }
        }
        //====================================================================
        public static List<CpPunchlistDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPunchlistDTO>"); }
        }
        //====================================================================
        public static List<CpPunchlistDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPunchlistDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpPunchlist"); }
        }
        //====================================================================
        public static DTO.CollectionCpPunchlistDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpPunchlistDTO collection = new DTO.CollectionCpPunchlistDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpPunchlistDTO entity = new DTO.CpPunchlistDTO();
                    if (dt.Rows[i]["PUNCH_ID"].ToString().Length != 0) entity.PunchId = Convert.ToDecimal(dt.Rows[i]["PUNCH_ID"]);
                    if (dt.Rows[i]["PUNCH_CNTR_CODIGO"].ToString().Length != 0) entity.PunchCntrCodigo = dt.Rows[i]["PUNCH_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PUNCH_PASTA_ID"].ToString().Length != 0) entity.PunchPastaId = Convert.ToDecimal(dt.Rows[i]["PUNCH_PASTA_ID"]);
                    if (dt.Rows[i]["PUNCH_DESCRICAO"].ToString().Length != 0) entity.PunchDescricao = dt.Rows[i]["PUNCH_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PUNCH_TIPE_ID"].ToString().Length != 0) entity.PunchTipeId = Convert.ToDecimal(dt.Rows[i]["PUNCH_TIPE_ID"]);
                    if (dt.Rows[i]["PUNCH_DATA_PROMETIDA"].ToString().Length != 0) entity.PunchDataPrometida = Convert.ToDateTime(dt.Rows[i]["PUNCH_DATA_PROMETIDA"]);
                    if (dt.Rows[i]["PUNCH_RESPONSIBLE_BY"].ToString().Length != 0) entity.PunchResponsibleBy = dt.Rows[i]["PUNCH_RESPONSIBLE_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_STPU_ID"].ToString().Length != 0) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[i]["PUNCH_STPU_ID"]);
                    if (dt.Rows[i]["PUNCH_APPROVED_BY"].ToString().Length != 0) entity.PunchApprovedBy = dt.Rows[i]["PUNCH_APPROVED_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_APPROVED_DATE"].ToString().Length != 0) entity.PunchApprovedDate = Convert.ToDateTime(dt.Rows[i]["PUNCH_APPROVED_DATE"]);
                    if (dt.Rows[i]["PUNCH_CREATED_BY"].ToString().Length != 0) entity.PunchCreatedBy = dt.Rows[i]["PUNCH_CREATED_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_CREATED_DATE"].ToString().Length != 0) entity.PunchCreatedDate = Convert.ToDateTime(dt.Rows[i]["PUNCH_CREATED_DATE"]);
                    if (dt.Rows[i]["PUNCH_DATA_CONCLUIDA"].ToString().Length != 0) entity.PunchDataConcluida = Convert.ToDateTime(dt.Rows[i]["PUNCH_DATA_CONCLUIDA"]);
                    if (dt.Rows[i]["PUNCH_ARPE_ID"].ToString().Length != 0) entity.PunchArpeId = Convert.ToDecimal(dt.Rows[i]["PUNCH_ARPE_ID"]);
                    if (dt.Rows[i]["PUNCH_SITUACAO"].ToString().Length != 0) entity.PunchSituacao = dt.Rows[i]["PUNCH_SITUACAO"].ToString();
                    if (dt.Rows[i]["PUNCH_IMPEDITIVA"].ToString().Length != 0) entity.PunchImpeditiva = Convert.ToDecimal(dt.Rows[i]["PUNCH_IMPEDITIVA"]);

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
            dict.Add("PunchId", "PUNCH_ID");
            dict.Add("PunchCntrCodigo", "PUNCH_CNTR_CODIGO");
            dict.Add("PunchPastaId", "PUNCH_PASTA_ID");
            dict.Add("PunchDescricao", "PUNCH_DESCRICAO");
            dict.Add("PunchTipeId", "PUNCH_TIPE_ID");
            dict.Add("PunchDataPrometida", "PUNCH_DATA_PROMETIDA");
            dict.Add("PunchResponsibleBy", "PUNCH_RESPONSIBLE_BY");
            dict.Add("PunchStpuId", "PUNCH_STPU_ID");
            dict.Add("PunchApprovedBy", "PUNCH_APPROVED_BY");
            dict.Add("PunchApprovedDate", "PUNCH_APPROVED_DATE");
            dict.Add("PunchCreatedBy", "PUNCH_CREATED_BY");
            dict.Add("PunchCreatedDate", "PUNCH_CREATED_DATE");
            dict.Add("PunchDataConcluida", "PUNCH_DATA_CONCLUIDA");
            dict.Add("PunchArpeId", "PUNCH_ARPE_ID");
            dict.Add("PunchSituacao", "PUNCH_SITUACAO");
            dict.Add("PunchImpeditiva", "PUNCH_IMPEDITIVA");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
