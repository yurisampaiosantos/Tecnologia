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
    public class CpAreaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.AREA_ID, X.AREA_DESCRICAO, X.AREA_CNTR_CODIGO FROM CP_AREA X ";
        //====================================================================
        public static int Insert(DTO.CpAreaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO CP_AREA(AREA_DESCRICAO,AREA_CNTR_CODIGO) VALUES(:AREA_DESCRICAO,:AREA_CNTR_CODIGO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AREA_DESCRICAO", OracleDbType.Varchar2).Value = entity.AreaDescricao;
                cmd.Parameters.Add(":AREA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.AreaCntrCodigo;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpArea");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpArea");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpAreaDTO entity)
        {
            string strSQL = "UPDATE CP_AREA set AREA_DESCRICAO = :AREA_DESCRICAO, AREA_CNTR_CODIGO = :AREA_CNTR_CODIGO WHERE  AREA_ID = :AREA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AREA_DESCRICAO", OracleDbType.Varchar2).Value = entity.AreaDescricao;
                cmd.Parameters.Add(":AREA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.AreaCntrCodigo;
                cmd.Parameters.Add(":AREA_ID", OracleDbType.Decimal).Value = entity.AreaId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpArea"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal AreaId)
        {
            string strSQL = "DELETE FROM CP_AREA WHERE AREA_ID = :AREA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AreaId", OracleDbType.Decimal).Value = AreaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpArea"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpArea"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM CP_AREA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpArea"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpArea"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpArea"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpArea"); }
        }
        //====================================================================
        public static DTO.CpAreaDTO Get(decimal AreaId)
        {
            CpAreaDTO entity = new CpAreaDTO();
            DataTable dt = null;
            string filter = "AREA_ID = " + AreaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["AREA_ID"] != null) && (dt.Rows[0]["AREA_ID"] != DBNull.Value)) entity.AreaId = Convert.ToDecimal(dt.Rows[0]["AREA_ID"]);
            if ((dt.Rows[0]["AREA_DESCRICAO"] != null) && (dt.Rows[0]["AREA_DESCRICAO"] != DBNull.Value)) entity.AreaDescricao = Convert.ToString(dt.Rows[0]["AREA_DESCRICAO"]);
            if ((dt.Rows[0]["AREA_CNTR_CODIGO"] != null) && (dt.Rows[0]["AREA_CNTR_CODIGO"] != DBNull.Value)) entity.AreaCntrCodigo = Convert.ToString(dt.Rows[0]["AREA_CNTR_CODIGO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpAreaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting AREA_CNTR_CODIGO Object"); }
        }
        //====================================================================
        public static List<CpAreaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpAreaDTO> list = OracleDataTools.LoadEntity<CpAreaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaDTO>"); }
        }
        //====================================================================
        public static List<CpAreaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaDTO>"); }
        }
        //====================================================================
        public static List<CpAreaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpAreaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpArea"); }
        }
        //====================================================================
        public static DTO.CollectionCpAreaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpAreaDTO collection = new DTO.CollectionCpAreaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpAreaDTO entity = new DTO.CpAreaDTO();
                    if (dt.Rows[i]["AREA_ID"].ToString().Length != 0) entity.AreaId = Convert.ToDecimal(dt.Rows[i]["AREA_ID"]);
                    if (dt.Rows[i]["AREA_DESCRICAO"].ToString().Length != 0) entity.AreaDescricao = dt.Rows[i]["AREA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["AREA_CNTR_CODIGO"].ToString().Length != 0) entity.AreaCntrCodigo = dt.Rows[i]["AREA_CNTR_CODIGO"].ToString();

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
            dict.Add("AreaId", "AREA_ID");
            dict.Add("AreaDescricao", "AREA_DESCRICAO");
            dict.Add("AreaCntrCodigo", "AREA_CNTR_CODIGO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
