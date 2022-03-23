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
    public class VwCpPunchlistDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.PUNCH_ID, X.PUNCH_CNTR_CODIGO, X.PUNCH_PASTA_ID, X.PASTA_CODIGO, X.PUNCH_DESCRICAO, X.PUNCH_TIPE_ID, TO_CHAR(X.PUNCH_DATA_PROMETIDA,'DD/MM/YYYY') AS PUNCH_DATA_PROMETIDA, X.PUNCH_RESPONSIBLE_BY, X.PUNCH_STPU_ID, X.STPU_DESCRICAO, X.PUNCH_APPROVED_BY, TO_CHAR(X.PUNCH_APPROVED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_APPROVED_DATE, X.PUNCH_CREATED_BY, TO_CHAR(X.PUNCH_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_CREATED_DATE, TO_CHAR(X.PUNCH_DATA_CONCLUIDA,'DD/MM/YYYY') AS PUNCH_DATA_CONCLUIDA, X.PUNCH_ARPE_ID, X.PUNCH_SITUACAO, X.PUNCH_IMPEDITIVA, X.PUNCH_IMPEDITIVA_DESC, X.ARPE_DESCRICAO, X.ARPE_EMAIL_AGENTE, X.ARPE_EMAIL_LEADER FROM EEP_CONVERSION.VW_CP_PUNCHLIST X ";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPunchlist"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_CP_PUNCHLIST";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPunchlist"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPunchlist"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPunchlist"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwCpPunchlist"); }
        }
        //====================================================================
        public static DTO.VwCpPunchlistDTO Get(decimal PunchId)
        {
            VwCpPunchlistDTO entity = new VwCpPunchlistDTO();
            DataTable dt = null;
            string filter = "PUNCH_ID = " + PunchId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PUNCH_ID"] != null) && (dt.Rows[0]["PUNCH_ID"] != DBNull.Value)) entity.PunchId = Convert.ToDecimal(dt.Rows[0]["PUNCH_ID"]);
            if ((dt.Rows[0]["PUNCH_CNTR_CODIGO"] != null) && (dt.Rows[0]["PUNCH_CNTR_CODIGO"] != DBNull.Value)) entity.PunchCntrCodigo = Convert.ToString(dt.Rows[0]["PUNCH_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PUNCH_PASTA_ID"] != null) && (dt.Rows[0]["PUNCH_PASTA_ID"] != DBNull.Value)) entity.PunchPastaId = Convert.ToDecimal(dt.Rows[0]["PUNCH_PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["PUNCH_DESCRICAO"] != null) && (dt.Rows[0]["PUNCH_DESCRICAO"] != DBNull.Value)) entity.PunchDescricao = Convert.ToString(dt.Rows[0]["PUNCH_DESCRICAO"]);
            if ((dt.Rows[0]["PUNCH_TIPE_ID"] != null) && (dt.Rows[0]["PUNCH_TIPE_ID"] != DBNull.Value)) entity.PunchTipeId = Convert.ToDecimal(dt.Rows[0]["PUNCH_TIPE_ID"]);
            if ((dt.Rows[0]["PUNCH_DATA_PROMETIDA"] != null) && (dt.Rows[0]["PUNCH_DATA_PROMETIDA"] != DBNull.Value)) entity.PunchDataPrometida = Convert.ToDateTime(dt.Rows[0]["PUNCH_DATA_PROMETIDA"]);
            if ((dt.Rows[0]["PUNCH_RESPONSIBLE_BY"] != null) && (dt.Rows[0]["PUNCH_RESPONSIBLE_BY"] != DBNull.Value)) entity.PunchResponsibleBy = Convert.ToString(dt.Rows[0]["PUNCH_RESPONSIBLE_BY"]);
            if ((dt.Rows[0]["PUNCH_STPU_ID"] != null) && (dt.Rows[0]["PUNCH_STPU_ID"] != DBNull.Value)) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[0]["PUNCH_STPU_ID"]);
            if ((dt.Rows[0]["STPU_DESCRICAO"] != null) && (dt.Rows[0]["STPU_DESCRICAO"] != DBNull.Value)) entity.StpuDescricao = Convert.ToString(dt.Rows[0]["STPU_DESCRICAO"]);
            if ((dt.Rows[0]["PUNCH_APPROVED_BY"] != null) && (dt.Rows[0]["PUNCH_APPROVED_BY"] != DBNull.Value)) entity.PunchApprovedBy = Convert.ToString(dt.Rows[0]["PUNCH_APPROVED_BY"]);
            if ((dt.Rows[0]["PUNCH_APPROVED_DATE"] != null) && (dt.Rows[0]["PUNCH_APPROVED_DATE"] != DBNull.Value)) entity.PunchApprovedDate = Convert.ToDateTime(dt.Rows[0]["PUNCH_APPROVED_DATE"]);
            if ((dt.Rows[0]["PUNCH_CREATED_BY"] != null) && (dt.Rows[0]["PUNCH_CREATED_BY"] != DBNull.Value)) entity.PunchCreatedBy = Convert.ToString(dt.Rows[0]["PUNCH_CREATED_BY"]);
            if ((dt.Rows[0]["PUNCH_CREATED_DATE"] != null) && (dt.Rows[0]["PUNCH_CREATED_DATE"] != DBNull.Value)) entity.PunchCreatedDate = Convert.ToDateTime(dt.Rows[0]["PUNCH_CREATED_DATE"]);
            if ((dt.Rows[0]["PUNCH_DATA_CONCLUIDA"] != null) && (dt.Rows[0]["PUNCH_DATA_CONCLUIDA"] != DBNull.Value)) entity.PunchDataConcluida = Convert.ToDateTime(dt.Rows[0]["PUNCH_DATA_CONCLUIDA"]);
            if ((dt.Rows[0]["PUNCH_ARPE_ID"] != null) && (dt.Rows[0]["PUNCH_ARPE_ID"] != DBNull.Value)) entity.PunchArpeId = Convert.ToDecimal(dt.Rows[0]["PUNCH_ARPE_ID"]);
            if ((dt.Rows[0]["PUNCH_SITUACAO"] != null) && (dt.Rows[0]["PUNCH_SITUACAO"] != DBNull.Value)) entity.PunchSituacao = Convert.ToString(dt.Rows[0]["PUNCH_SITUACAO"]);
            if ((dt.Rows[0]["PUNCH_IMPEDITIVA"] != null) && (dt.Rows[0]["PUNCH_IMPEDITIVA"] != DBNull.Value)) entity.PunchImpeditiva = Convert.ToDecimal(dt.Rows[0]["PUNCH_IMPEDITIVA"]);
            if ((dt.Rows[0]["PUNCH_IMPEDITIVA_DESC"] != null) && (dt.Rows[0]["PUNCH_IMPEDITIVA_DESC"] != DBNull.Value)) entity.PunchImpeditivaDesc = Convert.ToString(dt.Rows[0]["PUNCH_IMPEDITIVA_DESC"]);
            if ((dt.Rows[0]["ARPE_DESCRICAO"] != null) && (dt.Rows[0]["ARPE_DESCRICAO"] != DBNull.Value)) entity.ArpeDescricao = Convert.ToString(dt.Rows[0]["ARPE_DESCRICAO"]);
            if ((dt.Rows[0]["ARPE_EMAIL_AGENTE"] != null) && (dt.Rows[0]["ARPE_EMAIL_AGENTE"] != DBNull.Value)) entity.ArpeEmailAgente = Convert.ToString(dt.Rows[0]["ARPE_EMAIL_AGENTE"]);
            if ((dt.Rows[0]["ARPE_EMAIL_LEADER"] != null) && (dt.Rows[0]["ARPE_EMAIL_LEADER"] != DBNull.Value)) entity.ArpeEmailLeader = Convert.ToString(dt.Rows[0]["ARPE_EMAIL_LEADER"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwCpPunchlistDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ARPE_EMAIL_LEADER Object"); }
        }
        //====================================================================
        public static List<VwCpPunchlistDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwCpPunchlistDTO> list = OracleDataTools.LoadEntity<VwCpPunchlistDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPunchlistDTO>"); }
        }
        //====================================================================
        public static List<VwCpPunchlistDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPunchlistDTO>"); }
        }
        //====================================================================
        public static List<VwCpPunchlistDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPunchlistDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPunchlistDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwCpPunchlist"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPunchlistDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwCpPunchlistDTO collection = new DTO.CollectionVwCpPunchlistDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwCpPunchlistDTO entity = new DTO.VwCpPunchlistDTO();
                    if (dt.Rows[i]["PUNCH_ID"].ToString().Length != 0) entity.PunchId = Convert.ToDecimal(dt.Rows[i]["PUNCH_ID"]);
                    if (dt.Rows[i]["PUNCH_CNTR_CODIGO"].ToString().Length != 0) entity.PunchCntrCodigo = dt.Rows[i]["PUNCH_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PUNCH_PASTA_ID"].ToString().Length != 0) entity.PunchPastaId = Convert.ToDecimal(dt.Rows[i]["PUNCH_PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["PUNCH_DESCRICAO"].ToString().Length != 0) entity.PunchDescricao = dt.Rows[i]["PUNCH_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PUNCH_TIPE_ID"].ToString().Length != 0) entity.PunchTipeId = Convert.ToDecimal(dt.Rows[i]["PUNCH_TIPE_ID"]);
                    if (dt.Rows[i]["PUNCH_DATA_PROMETIDA"].ToString().Length != 0) entity.PunchDataPrometida = Convert.ToDateTime(dt.Rows[i]["PUNCH_DATA_PROMETIDA"]);
                    if (dt.Rows[i]["PUNCH_RESPONSIBLE_BY"].ToString().Length != 0) entity.PunchResponsibleBy = dt.Rows[i]["PUNCH_RESPONSIBLE_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_STPU_ID"].ToString().Length != 0) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[i]["PUNCH_STPU_ID"]);
                    if (dt.Rows[i]["STPU_DESCRICAO"].ToString().Length != 0) entity.StpuDescricao = dt.Rows[i]["STPU_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PUNCH_APPROVED_BY"].ToString().Length != 0) entity.PunchApprovedBy = dt.Rows[i]["PUNCH_APPROVED_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_APPROVED_DATE"].ToString().Length != 0) entity.PunchApprovedDate = Convert.ToDateTime(dt.Rows[i]["PUNCH_APPROVED_DATE"]);
                    if (dt.Rows[i]["PUNCH_CREATED_BY"].ToString().Length != 0) entity.PunchCreatedBy = dt.Rows[i]["PUNCH_CREATED_BY"].ToString();
                    if (dt.Rows[i]["PUNCH_CREATED_DATE"].ToString().Length != 0) entity.PunchCreatedDate = Convert.ToDateTime(dt.Rows[i]["PUNCH_CREATED_DATE"]);
                    if (dt.Rows[i]["PUNCH_DATA_CONCLUIDA"].ToString().Length != 0) entity.PunchDataConcluida = Convert.ToDateTime(dt.Rows[i]["PUNCH_DATA_CONCLUIDA"]);
                    if (dt.Rows[i]["PUNCH_ARPE_ID"].ToString().Length != 0) entity.PunchArpeId = Convert.ToDecimal(dt.Rows[i]["PUNCH_ARPE_ID"]);
                    if (dt.Rows[i]["PUNCH_SITUACAO"].ToString().Length != 0) entity.PunchSituacao = dt.Rows[i]["PUNCH_SITUACAO"].ToString();
                    if (dt.Rows[i]["PUNCH_IMPEDITIVA"].ToString().Length != 0) entity.PunchImpeditiva = Convert.ToDecimal(dt.Rows[i]["PUNCH_IMPEDITIVA"]);
                    if (dt.Rows[i]["PUNCH_IMPEDITIVA_DESC"].ToString().Length != 0) entity.PunchImpeditivaDesc = dt.Rows[i]["PUNCH_IMPEDITIVA_DESC"].ToString();
                    if (dt.Rows[i]["ARPE_DESCRICAO"].ToString().Length != 0) entity.ArpeDescricao = dt.Rows[i]["ARPE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["ARPE_EMAIL_AGENTE"].ToString().Length != 0) entity.ArpeEmailAgente = dt.Rows[i]["ARPE_EMAIL_AGENTE"].ToString();
                    if (dt.Rows[i]["ARPE_EMAIL_LEADER"].ToString().Length != 0) entity.ArpeEmailLeader = dt.Rows[i]["ARPE_EMAIL_LEADER"].ToString();

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
