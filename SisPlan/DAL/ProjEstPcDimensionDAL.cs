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
    public class ProjEstPcDimensionDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.PC, X.DIMENSION FROM EEP_CONVERSION.PROJ_EST_PC_DIMENSION X ";
        //====================================================================
        public static int Insert(DTO.ProjEstPcDimensionDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_EST_PC_DIMENSION(PC,DIMENSION) VALUES(:PC,:DIMENSION)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PC", OracleDbType.Varchar2).Value = entity.PC;
                cmd.Parameters.Add(":DIMENSION", OracleDbType.Varchar2).Value = entity.Dimension;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjEstPcDimension");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjEstPcDimension");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjEstPcDimensionDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_EST_PC_DIMENSION set PC = :PC, DIMENSION = :DIMENSION WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("PC", OracleDbType.Varchar2).Value = entity.PC;
                cmd.Parameters.Add("DIMENSION", OracleDbType.Varchar2).Value = entity.Dimension;
                cmd.Parameters.Add("DIMENSION", OracleDbType.Int64).Value = entity.Dimension;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjEstPcDimension"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_EST_PC_DIMENSION WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int64).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjEstPcDimension"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEstPcDimension"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_EST_PC_DIMENSION";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEstPcDimension"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEstPcDimension"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEstPcDimension"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static string GetCodigoProduto(string dim1, string dim2, string dim3, string grau)
        {
            DataTable dt = null;
            string produto = "";
            string strSQL = @"SELECT DIPC_CODIGO
                                FROM EPCCQ.DICIONARIO_PRODUTO_COMPOSTO, EPCCQ.DICIONARIO_PRODUTO, EPCCQ.DICIONARIO_PRODUTO_IDIOMA, EPCCQ.DICIONARIO_PRODUTO_UNICO
                               WHERE DIPC_CNTR_CODIGO = 'Conversão'
                                 AND DIPR_CNTR_CODIGO = DIPC_CNTR_CODIGO AND DIPR_ID = DIPC_DIPR_ID
                                 AND DIPR_CNTR_CODIGO = DIPI_CNTR_CODIGO AND DIPR_ID = DIPI_DIPR_ID
                                 AND DIPR_CNTR_CODIGO = DIPU_CNTR_CODIGO(+) AND DIPR_ID = DIPU_DIPR_ID(+)
                                 AND DIPR_PESO > 0
                                 AND REPLACE(DIPI_DESCRICAO_RES,' ', '') LIKE '%" + grau + "%'" +
                                " AND REPLACE(DIPC_DIM1,'.', '') = '" + dim1 + "'" +
                                " AND REPLACE(DIPC_DIM2,'.', '') = '" + dim2 + "'" +
                                " AND REPLACE(DIPC_DIM3,'.', '') = '" + dim3 + "'" +
                                " AND ROWNUM = 1";
            dt = OracleDataTools.GetDataTable(strSQL);
            if (dt.Rows.Count != 0) produto = dt.Rows[0]["DIPC_CODIGO"].ToString().Trim();
            return produto;
        }
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjEstPcDimension"); }
        }
        //====================================================================
        public static DTO.ProjEstPcDimensionDTO Get(decimal ID)
        {
            ProjEstPcDimensionDTO entity = new ProjEstPcDimensionDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["PC"] != null) && (dt.Rows[0]["PC"] != DBNull.Value)) entity.PC = Convert.ToString(dt.Rows[0]["PC"]);
            if ((dt.Rows[0]["DIMENSION"] != null) && (dt.Rows[0]["DIMENSION"] != DBNull.Value)) entity.Dimension = Convert.ToString(dt.Rows[0]["DIMENSION"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjEstPcDimensionDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DIMENSION Object"); }
        }
        //====================================================================
        public static List<ProjEstPcDimensionDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjEstPcDimensionDTO> list = OracleDataTools.LoadEntity<ProjEstPcDimensionDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstPcDimensionDTO>"); }
        }
        //====================================================================
        public static List<ProjEstPcDimensionDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstPcDimensionDTO>"); }
        }
        //====================================================================
        public static List<ProjEstPcDimensionDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstPcDimensionDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjEstPcDimensionDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjEstPcDimension"); }
        }
        //====================================================================
        public static DTO.CollectionProjEstPcDimensionDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjEstPcDimensionDTO collection = new DTO.CollectionProjEstPcDimensionDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjEstPcDimensionDTO entity = new DTO.ProjEstPcDimensionDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["PC"].ToString().Length != 0) entity.PC = dt.Rows[i]["PC"].ToString();
                    if (dt.Rows[i]["DIMENSION"].ToString().Length != 0) entity.Dimension = dt.Rows[i]["DIMENSION"].ToString();

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
            dict.Add("ID", "ID");
            dict.Add("PC", "PC");
            dict.Add("Dimension", "DIMENSION");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
