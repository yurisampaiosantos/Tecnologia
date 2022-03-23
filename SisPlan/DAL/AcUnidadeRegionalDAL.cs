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
    public class AcUnidadeRegionalDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.UNRE_ID, X.UNRE_REGION_LIKE, X.UNRE_UNIDADE_REGIONAL, X.UNRE_SEQUENCE FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL X ";
        //====================================================================
        public static int Insert(DTO.AcUnidadeRegionalDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_UNIDADE_REGIONAL(UNRE_REGION_LIKE,UNRE_UNIDADE_REGIONAL,UNRE_SEQUENCE) VALUES(:UNRE_REGION_LIKE,:UNRE_UNIDADE_REGIONAL,:UNRE_SEQUENCE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":UNRE_REGION_LIKE", OracleDbType.Varchar2).Value = entity.UnreRegionLike;
                cmd.Parameters.Add(":UNRE_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.UnreUnidadeRegional;
                cmd.Parameters.Add(":UNRE_SEQUENCE", OracleDbType.Decimal).Value = entity.UnreSequence;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcUnidadeRegional");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcUnidadeRegional");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcUnidadeRegionalDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_UNIDADE_REGIONAL set UNRE_REGION_LIKE = :UNRE_REGION_LIKE, UNRE_UNIDADE_REGIONAL = :UNRE_UNIDADE_REGIONAL, UNRE_SEQUENCE = :UNRE_SEQUENCE WHERE  UNRE_ID = : UNRE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("UNRE_REGION_LIKE", OracleDbType.Varchar2).Value = entity.UnreRegionLike;
                cmd.Parameters.Add("UNRE_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.UnreUnidadeRegional;
                cmd.Parameters.Add("UNRE_SEQUENCE", OracleDbType.Decimal).Value = entity.UnreSequence;
                cmd.Parameters.Add("UNRE_ID", OracleDbType.Decimal).Value = entity.UnreId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcUnidadeRegional"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal UnreId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL WHERE  UNRE_ID = : UNRE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":UnreId", OracleDbType.Decimal).Value = UnreId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcUnidadeRegional"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcUnidadeRegional"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcUnidadeRegional"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcUnidadeRegional"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcUnidadeRegional"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcUnidadeRegional"); }
        }
        //====================================================================
        public static DTO.AcUnidadeRegionalDTO Get(decimal UnreId)
        {
            AcUnidadeRegionalDTO entity = new AcUnidadeRegionalDTO();
            DataTable dt = null;
            string filter = "UNRE_ID = " + UnreId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["UNRE_ID"] != null) && (dt.Rows[0]["UNRE_ID"] != DBNull.Value)) entity.UnreId = Convert.ToDecimal(dt.Rows[0]["UNRE_ID"]);
            if ((dt.Rows[0]["UNRE_REGION_LIKE"] != null) && (dt.Rows[0]["UNRE_REGION_LIKE"] != DBNull.Value)) entity.UnreRegionLike = Convert.ToString(dt.Rows[0]["UNRE_REGION_LIKE"]);
            if ((dt.Rows[0]["UNRE_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["UNRE_UNIDADE_REGIONAL"] != DBNull.Value)) entity.UnreUnidadeRegional = Convert.ToString(dt.Rows[0]["UNRE_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["UNRE_SEQUENCE"] != null) && (dt.Rows[0]["UNRE_SEQUENCE"] != DBNull.Value)) entity.UnreSequence = Convert.ToDecimal(dt.Rows[0]["UNRE_SEQUENCE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcUnidadeRegionalDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting UNRE_SEQUENCE Object"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcUnidadeRegionalDTO> list = OracleDataTools.LoadEntity<AcUnidadeRegionalDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalDTO>"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalDTO>"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcUnidadeRegionalDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcUnidadeRegional"); }
        }
        //====================================================================
        public static DTO.CollectionAcUnidadeRegionalDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcUnidadeRegionalDTO collection = new DTO.CollectionAcUnidadeRegionalDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcUnidadeRegionalDTO entity = new DTO.AcUnidadeRegionalDTO();
                    if (dt.Rows[i]["UNRE_ID"].ToString().Length != 0) entity.UnreId = Convert.ToDecimal(dt.Rows[i]["UNRE_ID"]);
                    if (dt.Rows[i]["UNRE_REGION_LIKE"].ToString().Length != 0) entity.UnreRegionLike = dt.Rows[i]["UNRE_REGION_LIKE"].ToString();
                    if (dt.Rows[i]["UNRE_UNIDADE_REGIONAL"].ToString().Length != 0) entity.UnreUnidadeRegional = dt.Rows[i]["UNRE_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["UNRE_SEQUENCE"].ToString().Length != 0) entity.UnreSequence = Convert.ToDecimal(dt.Rows[i]["UNRE_SEQUENCE"]);

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
            dict.Add("UnreId", "UNRE_ID");
            dict.Add("UnreRegionLike", "UNRE_REGION_LIKE");
            dict.Add("UnreUnidadeRegional", "UNRE_UNIDADE_REGIONAL");
            dict.Add("UnreSequence", "UNRE_SEQUENCE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
