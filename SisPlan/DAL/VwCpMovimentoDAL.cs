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
    public class VwCpMovimentoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.MOVI_ID, X.MOVI_CNTR_CODIGO, X.MOVI_PASTA_ID, X.PASTA_CODIGO, TO_CHAR(X.MOVI_DATE,'DD/MM/YYYY HH24:MI') AS MOVI_DATE, X.MOVI_DATE_DESC, X.LOCA_DESCRICAO, X.MOVI_USUA_LOGIN, X.USUA_ACTIVE, X.USUA_AG_CRIAR_PUNCH, X.USUA_AG_CLASS_PUNCH, X.USUA_AG_STATUS_PUNCH, X.USUA_AG_CRIAR_PENDMAT, X.USUA_AG_STATUS_PENDMAT, X.MOVI_CREATED_BY, X.MOVI_STMO_ID, X.STMO_DESCRICAO, X.MOVI_IN_GRD, SMGR_ID, SMGR_DESCRICAO FROM EEP_CONVERSION.VW_CP_MOVIMENTO X";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpMovimento"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_CP_MOVIMENTO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpMovimento"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpMovimento"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwCpMovimento"); }
        }
        //====================================================================
        public static DTO.VwCpMovimentoDTO Get(decimal MoviId)
        {
            VwCpMovimentoDTO entity = new VwCpMovimentoDTO();
            DataTable dt = null;
            string filter = "MOVI_ID = " + MoviId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MOVI_ID"] != null) && (dt.Rows[0]["MOVI_ID"] != DBNull.Value)) entity.MoviId = Convert.ToDecimal(dt.Rows[0]["MOVI_ID"]);
            if ((dt.Rows[0]["MOVI_CNTR_CODIGO"] != null) && (dt.Rows[0]["MOVI_CNTR_CODIGO"] != DBNull.Value)) entity.MoviCntrCodigo = Convert.ToString(dt.Rows[0]["MOVI_CNTR_CODIGO"]);
            if ((dt.Rows[0]["MOVI_PASTA_ID"] != null) && (dt.Rows[0]["MOVI_PASTA_ID"] != DBNull.Value)) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[0]["MOVI_PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["MOVI_DATE"] != null) && (dt.Rows[0]["MOVI_DATE"] != DBNull.Value)) entity.MoviDate = Convert.ToDateTime(dt.Rows[0]["MOVI_DATE"]);
            if ((dt.Rows[0]["MOVI_DATE_DESC"] != null) && (dt.Rows[0]["MOVI_DATE_DESC"] != DBNull.Value)) entity.MoviDateDesc = Convert.ToString(dt.Rows[0]["MOVI_DATE_DESC"]);
            if ((dt.Rows[0]["LOCA_DESCRICAO"] != null) && (dt.Rows[0]["LOCA_DESCRICAO"] != DBNull.Value)) entity.LocaDescricao = Convert.ToString(dt.Rows[0]["LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["MOVI_USUA_LOGIN"] != null) && (dt.Rows[0]["MOVI_USUA_LOGIN"] != DBNull.Value)) entity.MoviUsuaLogin = Convert.ToString(dt.Rows[0]["MOVI_USUA_LOGIN"]);
            if ((dt.Rows[0]["USUA_ACTIVE"] != null) && (dt.Rows[0]["USUA_ACTIVE"] != DBNull.Value)) entity.UsuaActive = Convert.ToDecimal(dt.Rows[0]["USUA_ACTIVE"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != DBNull.Value)) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != DBNull.Value)) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CLASS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != DBNull.Value)) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != DBNull.Value)) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != DBNull.Value)) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PENDMAT"]);
            if ((dt.Rows[0]["MOVI_CREATED_BY"] != null) && (dt.Rows[0]["MOVI_CREATED_BY"] != DBNull.Value)) entity.MoviCreatedBy = Convert.ToString(dt.Rows[0]["MOVI_CREATED_BY"]);
            if ((dt.Rows[0]["MOVI_STMO_ID"] != null) && (dt.Rows[0]["MOVI_STMO_ID"] != DBNull.Value)) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[0]["MOVI_STMO_ID"]);
            if ((dt.Rows[0]["STMO_DESCRICAO"] != null) && (dt.Rows[0]["STMO_DESCRICAO"] != DBNull.Value)) entity.StmoDescricao = Convert.ToString(dt.Rows[0]["STMO_DESCRICAO"]);
            if ((dt.Rows[0]["MOVI_IN_GRD"] != null) && (dt.Rows[0]["MOVI_IN_GRD"] != DBNull.Value)) entity.MoviInGrd = Convert.ToDecimal(dt.Rows[0]["MOVI_IN_GRD"]);
            if ((dt.Rows[0]["SMGR_ID"] != null) && (dt.Rows[0]["SMGR_ID"] != DBNull.Value)) entity.SmgrId = Convert.ToDecimal(dt.Rows[0]["SMGR_ID"]);
            if ((dt.Rows[0]["SMGR_DESCRICAO"] != null) && (dt.Rows[0]["SMGR_DESCRICAO"] != DBNull.Value)) entity.SmgrDescricao = Convert.ToString(dt.Rows[0]["SMGR_DESCRICAO"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwCpMovimentoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MOVI_IN_GRD Object"); }
        }
        //====================================================================
        public static List<VwCpMovimentoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwCpMovimentoDTO> list = OracleDataTools.LoadEntity<VwCpMovimentoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMovimentoDTO>"); }
        }
        //====================================================================
        public static List<VwCpMovimentoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMovimentoDTO>"); }
        }
        //====================================================================
        public static List<VwCpMovimentoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMovimentoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpMovimentoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwCpMovimento"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpMovimentoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwCpMovimentoDTO collection = new DTO.CollectionVwCpMovimentoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwCpMovimentoDTO entity = new DTO.VwCpMovimentoDTO();
                    if (dt.Rows[i]["MOVI_ID"].ToString().Length != 0) entity.MoviId = Convert.ToDecimal(dt.Rows[i]["MOVI_ID"]);
                    if (dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString().Length != 0) entity.MoviCntrCodigo = dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["MOVI_PASTA_ID"].ToString().Length != 0) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[i]["MOVI_PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["MOVI_DATE"].ToString().Length != 0) entity.MoviDate = Convert.ToDateTime(dt.Rows[i]["MOVI_DATE"]);
                    if (dt.Rows[i]["MOVI_DATE_DESC"].ToString().Length != 0) entity.MoviDateDesc = dt.Rows[i]["MOVI_DATE_DESC"].ToString();
                    if (dt.Rows[i]["LOCA_DESCRICAO"].ToString().Length != 0) entity.LocaDescricao = dt.Rows[i]["LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MOVI_USUA_LOGIN"].ToString().Length != 0) entity.MoviUsuaLogin = dt.Rows[i]["MOVI_USUA_LOGIN"].ToString();
                    if (dt.Rows[i]["USUA_ACTIVE"].ToString().Length != 0) entity.UsuaActive = Convert.ToDecimal(dt.Rows[i]["USUA_ACTIVE"]);
                    if (dt.Rows[i]["USUA_AG_CRIAR_PUNCH"].ToString().Length != 0) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CLASS_PUNCH"].ToString().Length != 0) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CLASS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PUNCH"].ToString().Length != 0) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"].ToString().Length != 0) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PENDMAT"].ToString().Length != 0) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PENDMAT"]);
                    if (dt.Rows[i]["MOVI_CREATED_BY"].ToString().Length != 0) entity.MoviCreatedBy = dt.Rows[i]["MOVI_CREATED_BY"].ToString();
                    if (dt.Rows[i]["MOVI_STMO_ID"].ToString().Length != 0) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[i]["MOVI_STMO_ID"]);
                    if (dt.Rows[i]["STMO_DESCRICAO"].ToString().Length != 0) entity.StmoDescricao = dt.Rows[i]["STMO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MOVI_IN_GRD"].ToString().Length != 0) entity.MoviInGrd = Convert.ToDecimal(dt.Rows[i]["MOVI_IN_GRD"]);
                    if (dt.Rows[i]["SMGR_ID"].ToString().Length != 0) entity.SmgrId = Convert.ToDecimal(dt.Rows[i]["SMGR_ID"]);
                    if (dt.Rows[i]["SMGR_DESCRICAO"].ToString().Length != 0) entity.SmgrDescricao = dt.Rows[i]["SMGR_DESCRICAO"].ToString();

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
