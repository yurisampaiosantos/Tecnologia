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
    public class VwCpMaterialPendenteDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        static string strSelect = @"SELECT X.MAPE_ID, X.MAPE_CNTR_CODIGO, X.MAPE_PASTA_ID, X.PASTA_CODIGO, X.MAPE_DESCRICAO, X.MAPE_QUANTIDADE, X.MAPE_UNIDADE, X.MAPE_LOCA_ID, X.LOCA_DESCRICAO, X.MAPE_STMP_ID, X.STMP_DESCRICAO, X.MAPE_CREATED_BY, TO_CHAR(X.MAPE_CREATED_DATE,'DD/MM/YYYY HH24:MI') AS MAPE_CREATED_DATE, MAPE_FORNECEDOR FROM EEP_CONVERSION.VW_CP_MATERIAL_PENDENTE X ";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpMaterialPendente"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_CP_MATERIAL_PENDENTE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpMaterialPendente"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpMaterialPendente"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpMaterialPendente"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwCpMaterialPendente"); }
        }
        //====================================================================
        public static DTO.VwCpMaterialPendenteDTO Get(decimal MapeId)
        {
            VwCpMaterialPendenteDTO entity = new VwCpMaterialPendenteDTO();
            DataTable dt = null;
            string filter = "MAPE_ID = " + MapeId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MAPE_ID"] != null) && (dt.Rows[0]["MAPE_ID"] != DBNull.Value)) entity.MapeId = Convert.ToDecimal(dt.Rows[0]["MAPE_ID"]);
            if ((dt.Rows[0]["MAPE_CNTR_CODIGO"] != null) && (dt.Rows[0]["MAPE_CNTR_CODIGO"] != DBNull.Value)) entity.MapeCntrCodigo = Convert.ToString(dt.Rows[0]["MAPE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["MAPE_PASTA_ID"] != null) && (dt.Rows[0]["MAPE_PASTA_ID"] != DBNull.Value)) entity.MapePastaId = Convert.ToDecimal(dt.Rows[0]["MAPE_PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["MAPE_DESCRICAO"] != null) && (dt.Rows[0]["MAPE_DESCRICAO"] != DBNull.Value)) entity.MapeDescricao = Convert.ToString(dt.Rows[0]["MAPE_DESCRICAO"]);
            if ((dt.Rows[0]["MAPE_QUANTIDADE"] != null) && (dt.Rows[0]["MAPE_QUANTIDADE"] != DBNull.Value)) entity.MapeQuantidade = Convert.ToDecimal(dt.Rows[0]["MAPE_QUANTIDADE"]);
            if ((dt.Rows[0]["MAPE_UNIDADE"] != null) && (dt.Rows[0]["MAPE_UNIDADE"] != DBNull.Value)) entity.MapeUnidade = Convert.ToString(dt.Rows[0]["MAPE_UNIDADE"]);
            if ((dt.Rows[0]["MAPE_LOCA_ID"] != null) && (dt.Rows[0]["MAPE_LOCA_ID"] != DBNull.Value)) entity.MapeLocaId = Convert.ToDecimal(dt.Rows[0]["MAPE_LOCA_ID"]);
            if ((dt.Rows[0]["LOCA_DESCRICAO"] != null) && (dt.Rows[0]["LOCA_DESCRICAO"] != DBNull.Value)) entity.LocaDescricao = Convert.ToString(dt.Rows[0]["LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["MAPE_STMP_ID"] != null) && (dt.Rows[0]["MAPE_STMP_ID"] != DBNull.Value)) entity.MapeStmpId = Convert.ToDecimal(dt.Rows[0]["MAPE_STMP_ID"]);
            if ((dt.Rows[0]["STMP_DESCRICAO"] != null) && (dt.Rows[0]["STMP_DESCRICAO"] != DBNull.Value)) entity.StmpDescricao = Convert.ToString(dt.Rows[0]["STMP_DESCRICAO"]);
            if ((dt.Rows[0]["MAPE_CREATED_BY"] != null) && (dt.Rows[0]["MAPE_CREATED_BY"] != DBNull.Value)) entity.MapeCreatedBy = Convert.ToString(dt.Rows[0]["MAPE_CREATED_BY"]);
            if ((dt.Rows[0]["MAPE_CREATED_DATE"] != null) && (dt.Rows[0]["MAPE_CREATED_DATE"] != DBNull.Value)) entity.MapeCreatedDate = Convert.ToDateTime(dt.Rows[0]["MAPE_CREATED_DATE"]);
            if ((dt.Rows[0]["MAPE_FORNECEDOR"] != null) && (dt.Rows[0]["MAPE_FORNECEDOR"] != DBNull.Value)) entity.MapeFornecedor = Convert.ToString(dt.Rows[0]["MAPE_FORNECEDOR"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwCpMaterialPendenteDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MAPE_CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<VwCpMaterialPendenteDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwCpMaterialPendenteDTO> list = OracleDataTools.LoadEntity<VwCpMaterialPendenteDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static List<VwCpMaterialPendenteDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static List<VwCpMaterialPendenteDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpMaterialPendenteDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwCpMaterialPendente"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpMaterialPendenteDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwCpMaterialPendenteDTO collection = new DTO.CollectionVwCpMaterialPendenteDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwCpMaterialPendenteDTO entity = new DTO.VwCpMaterialPendenteDTO();
                    if (dt.Rows[i]["MAPE_ID"].ToString().Length != 0) entity.MapeId = Convert.ToDecimal(dt.Rows[i]["MAPE_ID"]);
                    if (dt.Rows[i]["MAPE_CNTR_CODIGO"].ToString().Length != 0) entity.MapeCntrCodigo = dt.Rows[i]["MAPE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["MAPE_PASTA_ID"].ToString().Length != 0) entity.MapePastaId = Convert.ToDecimal(dt.Rows[i]["MAPE_PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["MAPE_DESCRICAO"].ToString().Length != 0) entity.MapeDescricao = dt.Rows[i]["MAPE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MAPE_QUANTIDADE"].ToString().Length != 0) entity.MapeQuantidade = Convert.ToDecimal(dt.Rows[i]["MAPE_QUANTIDADE"]);
                    if (dt.Rows[i]["MAPE_UNIDADE"].ToString().Length != 0) entity.MapeUnidade = dt.Rows[i]["MAPE_UNIDADE"].ToString();
                    if (dt.Rows[i]["MAPE_LOCA_ID"].ToString().Length != 0) entity.MapeLocaId = Convert.ToDecimal(dt.Rows[i]["MAPE_LOCA_ID"]);
                    if (dt.Rows[i]["LOCA_DESCRICAO"].ToString().Length != 0) entity.LocaDescricao = dt.Rows[i]["LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MAPE_STMP_ID"].ToString().Length != 0) entity.MapeStmpId = Convert.ToDecimal(dt.Rows[i]["MAPE_STMP_ID"]);
                    if (dt.Rows[i]["STMP_DESCRICAO"].ToString().Length != 0) entity.StmpDescricao = dt.Rows[i]["STMP_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MAPE_CREATED_BY"].ToString().Length != 0) entity.MapeCreatedBy = dt.Rows[i]["MAPE_CREATED_BY"].ToString();
                    if (dt.Rows[i]["MAPE_CREATED_DATE"].ToString().Length != 0) entity.MapeCreatedDate = Convert.ToDateTime(dt.Rows[i]["MAPE_CREATED_DATE"]);
                    if (dt.Rows[i]["MAPE_FORNECEDOR"].ToString().Length != 0) entity.MapeFornecedor = dt.Rows[i]["MAPE_FORNECEDOR"].ToString();

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
