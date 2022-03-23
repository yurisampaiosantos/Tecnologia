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
    public class CpMaterialPendenteDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.MAPE_ID, X.MAPE_CNTR_CODIGO, X.MAPE_PASTA_ID, X.MAPE_DESCRICAO, X.MAPE_QUANTIDADE, X.MAPE_UNIDADE, X.MAPE_LOCA_ID, X.MAPE_STMP_ID, X.MAPE_CREATED_BY, TO_CHAR(X.MAPE_CREATED_DATE,'DD/MM/YYYY HH24:MI') AS MAPE_CREATED_DATE, X.MAPE_FORNECEDOR FROM EEP_CONVERSION.CP_MATERIAL_PENDENTE X ";
        //====================================================================
        public static int Insert(DTO.CpMaterialPendenteDTO entity, bool getIdentity)
        {
                            string strSQL = @"INSERT INTO EEP_CONVERSION.CP_MATERIAL_PENDENTE
                                                     (MAPE_CNTR_CODIGO,MAPE_PASTA_ID,MAPE_DESCRICAO,MAPE_QUANTIDADE,MAPE_UNIDADE,MAPE_LOCA_ID,MAPE_STMP_ID,MAPE_CREATED_BY,MAPE_CREATED_DATE, MAPE_FORNECEDOR) 
                                                     VALUES 
                                                     (:MAPE_CNTR_CODIGO,:MAPE_PASTA_ID,:MAPE_DESCRICAO,:MAPE_QUANTIDADE,:MAPE_UNIDADE,:MAPE_LOCA_ID,:MAPE_STMP_ID,:MAPE_CREATED_BY,SYSDATE, :MAPE_FORNECEDOR)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MAPE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.MapeCntrCodigo;
                cmd.Parameters.Add(":MAPE_PASTA_ID", OracleDbType.Decimal).Value = entity.MapePastaId;
                cmd.Parameters.Add(":MAPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.MapeDescricao;
                cmd.Parameters.Add(":MAPE_QUANTIDADE", OracleDbType.Decimal).Value = entity.MapeQuantidade;
                cmd.Parameters.Add(":MAPE_UNIDADE", OracleDbType.Varchar2).Value = entity.MapeUnidade;
                cmd.Parameters.Add(":MAPE_LOCA_ID", OracleDbType.Decimal).Value = entity.MapeLocaId;
                cmd.Parameters.Add(":MAPE_STMP_ID", OracleDbType.Decimal).Value = entity.MapeStmpId;
                cmd.Parameters.Add(":MAPE_CREATED_BY", OracleDbType.Varchar2).Value = entity.MapeCreatedBy;
                cmd.Parameters.Add(":MAPE_FORNECEDOR", OracleDbType.Varchar2).Value = entity.MapeFornecedor;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpMaterialPendente");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpMaterialPendente");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpMaterialPendenteDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_MATERIAL_PENDENTE set MAPE_CNTR_CODIGO = :MAPE_CNTR_CODIGO, MAPE_PASTA_ID = :MAPE_PASTA_ID, MAPE_DESCRICAO = :MAPE_DESCRICAO, MAPE_QUANTIDADE = :MAPE_QUANTIDADE, MAPE_UNIDADE = :MAPE_UNIDADE, MAPE_LOCA_ID = :MAPE_LOCA_ID, MAPE_STMP_ID = :MAPE_STMP_ID, MAPE_FORNECEDOR = :MAPE_FORNECEDOR WHERE  MAPE_ID = :MAPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MAPE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.MapeCntrCodigo;
                cmd.Parameters.Add(":MAPE_PASTA_ID", OracleDbType.Decimal).Value = entity.MapePastaId;
                cmd.Parameters.Add(":MAPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.MapeDescricao;
                cmd.Parameters.Add(":MAPE_QUANTIDADE", OracleDbType.Decimal).Value = entity.MapeQuantidade;
                cmd.Parameters.Add(":MAPE_UNIDADE", OracleDbType.Varchar2).Value = entity.MapeUnidade;
                cmd.Parameters.Add(":MAPE_LOCA_ID", OracleDbType.Decimal).Value = entity.MapeLocaId;
                cmd.Parameters.Add(":MAPE_STMP_ID", OracleDbType.Decimal).Value = entity.MapeStmpId;
                cmd.Parameters.Add(":MAPE_FORNECEDOR", OracleDbType.Varchar2).Value = entity.MapeFornecedor;

                cmd.Parameters.Add(":MAPE_ID", OracleDbType.Decimal).Value = entity.MapeId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpMaterialPendente"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal MapeId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_MATERIAL_PENDENTE WHERE MAPE_ID = :MAPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MapeId", OracleDbType.Decimal).Value = MapeId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpMaterialPendente"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpMaterialPendente"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_MATERIAL_PENDENTE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpMaterialPendente"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpMaterialPendente"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpMaterialPendente"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpMaterialPendente"); }
        }
        //====================================================================
        public static DTO.CpMaterialPendenteDTO Get(decimal MapeId)
        {
            CpMaterialPendenteDTO entity = new CpMaterialPendenteDTO();
            DataTable dt = null;
            string filter = "MAPE_ID = " + MapeId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MAPE_ID"] != null) && (dt.Rows[0]["MAPE_ID"] != DBNull.Value)) entity.MapeId = Convert.ToDecimal(dt.Rows[0]["MAPE_ID"]);
            if ((dt.Rows[0]["MAPE_CNTR_CODIGO"] != null) && (dt.Rows[0]["MAPE_CNTR_CODIGO"] != DBNull.Value)) entity.MapeCntrCodigo = Convert.ToString(dt.Rows[0]["MAPE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["MAPE_PASTA_ID"] != null) && (dt.Rows[0]["MAPE_PASTA_ID"] != DBNull.Value)) entity.MapePastaId = Convert.ToDecimal(dt.Rows[0]["MAPE_PASTA_ID"]);
            if ((dt.Rows[0]["MAPE_DESCRICAO"] != null) && (dt.Rows[0]["MAPE_DESCRICAO"] != DBNull.Value)) entity.MapeDescricao = Convert.ToString(dt.Rows[0]["MAPE_DESCRICAO"]);
            if ((dt.Rows[0]["MAPE_QUANTIDADE"] != null) && (dt.Rows[0]["MAPE_QUANTIDADE"] != DBNull.Value)) entity.MapeQuantidade = Convert.ToDecimal(dt.Rows[0]["MAPE_QUANTIDADE"]);
            if ((dt.Rows[0]["MAPE_UNIDADE"] != null) && (dt.Rows[0]["MAPE_UNIDADE"] != DBNull.Value)) entity.MapeUnidade = Convert.ToString(dt.Rows[0]["MAPE_UNIDADE"]);
            if ((dt.Rows[0]["MAPE_LOCA_ID"] != null) && (dt.Rows[0]["MAPE_LOCA_ID"] != DBNull.Value)) entity.MapeLocaId = Convert.ToDecimal(dt.Rows[0]["MAPE_LOCA_ID"]);
            if ((dt.Rows[0]["MAPE_STMP_ID"] != null) && (dt.Rows[0]["MAPE_STMP_ID"] != DBNull.Value)) entity.MapeStmpId = Convert.ToDecimal(dt.Rows[0]["MAPE_STMP_ID"]);
            if ((dt.Rows[0]["MAPE_CREATED_BY"] != null) && (dt.Rows[0]["MAPE_CREATED_BY"] != DBNull.Value)) entity.MapeCreatedBy = Convert.ToString(dt.Rows[0]["MAPE_CREATED_BY"]);
            if ((dt.Rows[0]["MAPE_CREATED_DATE"] != null) && (dt.Rows[0]["MAPE_CREATED_DATE"] != DBNull.Value)) entity.MapeCreatedDate = Convert.ToDateTime(dt.Rows[0]["MAPE_CREATED_DATE"]);
            if ((dt.Rows[0]["MAPE_FORNECEDOR"] != null) && (dt.Rows[0]["MAPE_FORNECEDOR"] != DBNull.Value)) entity.MapeFornecedor = Convert.ToString(dt.Rows[0]["MAPE_FORNECEDOR"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.CpMaterialPendenteDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MAPE_CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<CpMaterialPendenteDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpMaterialPendenteDTO> list = OracleDataTools.LoadEntity<CpMaterialPendenteDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static List<CpMaterialPendenteDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static List<CpMaterialPendenteDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpMaterialPendenteDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpMaterialPendenteDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpMaterialPendente"); }
        }
        //====================================================================
        public static DTO.CollectionCpMaterialPendenteDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpMaterialPendenteDTO collection = new DTO.CollectionCpMaterialPendenteDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpMaterialPendenteDTO entity = new DTO.CpMaterialPendenteDTO();
                    if (dt.Rows[i]["MAPE_ID"].ToString().Length != 0) entity.MapeId = Convert.ToDecimal(dt.Rows[i]["MAPE_ID"]);
                    if (dt.Rows[i]["MAPE_CNTR_CODIGO"].ToString().Length != 0) entity.MapeCntrCodigo = dt.Rows[i]["MAPE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["MAPE_PASTA_ID"].ToString().Length != 0) entity.MapePastaId = Convert.ToDecimal(dt.Rows[i]["MAPE_PASTA_ID"]);
                    if (dt.Rows[i]["MAPE_DESCRICAO"].ToString().Length != 0) entity.MapeDescricao = dt.Rows[i]["MAPE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MAPE_QUANTIDADE"].ToString().Length != 0) entity.MapeQuantidade = Convert.ToDecimal(dt.Rows[i]["MAPE_QUANTIDADE"]);
                    if (dt.Rows[i]["MAPE_UNIDADE"].ToString().Length != 0) entity.MapeUnidade = dt.Rows[i]["MAPE_UNIDADE"].ToString();
                    if (dt.Rows[i]["MAPE_LOCA_ID"].ToString().Length != 0) entity.MapeLocaId = Convert.ToDecimal(dt.Rows[i]["MAPE_LOCA_ID"]);
                    if (dt.Rows[i]["MAPE_STMP_ID"].ToString().Length != 0) entity.MapeStmpId = Convert.ToDecimal(dt.Rows[i]["MAPE_STMP_ID"]);
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
