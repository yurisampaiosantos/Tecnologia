using System;
using System.Collections.Generic;

using System.Data;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================
//====================================================================

namespace DAL
{
    public class AcItemControleDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.DESCRICAO_ESTRUTURA, X.ITEM_CONTROLE FROM EEP_CONVERSION.AC_ITEM_CONTROLE X ";
        //============================================
        public static DataTable ReadSpreadSheet(string connStr)
        {
            DataTable dt = null;
            OleDbConnection conn = new OleDbConnection(connStr);
            List<string> planilhas = GetSheetNames(conn);
            dt = null;

            string strSQL = "SELECT * FROM [Plan1$]";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        //============================================
        public static List<String> GetSheetNames(OleDbConnection conn)
        {
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<String> Lista = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                Lista.Add(row["TABLE_NAME"].ToString());
            }
            conn.Close();
            return Lista;
        }
        //====================================================================
        public static int Insert(DTO.AcItemControleDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_ITEM_CONTROLE(DESCRICAO_ESTRUTURA,ITEM_CONTROLE) VALUES(:DESCRICAO_ESTRUTURA,:ITEM_CONTROLE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":ITEM_CONTROLE", OracleDbType.Varchar2).Value = entity.ItemControle;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcItemControle");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcItemControle");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcItemControleDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_ITEM_CONTROLE set DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, ITEM_CONTROLE = :ITEM_CONTROLE WHERE DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add("ITEM_CONTROLE", OracleDbType.Varchar2).Value = entity.ItemControle;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcItemControle"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_ITEM_CONTROLE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcItemControle"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcItemControle"); }
        }
        //====================================================================
        public static int CountByDescricaoEstrutura(string descricaoEstrutura)
        {
            //c = BLL.AcItemControleBLL.Count("UPPER(DESCRICAO_ESTRUTURA) = '" + en.DescricaoEstrutura.ToUpper() + "'");
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_ITEM_CONTROLE WHERE UPPER(DESCRICAO_ESTRUTURA) = :DESCRICAO_ESTRUTURA";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = descricaoEstrutura;
                //OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
                NR = OracleDataTools.ExecuteScalar(strSQL, cmd);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcItemControle"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_ITEM_CONTROLE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcItemControle"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcItemControle"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcItemControle"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcItemControle"); }
        }
        //====================================================================
        public static DTO.AcItemControleDTO Get(decimal ID)
        {
            AcItemControleDTO entity = new AcItemControleDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["DESCRICAO_ESTRUTURA"] != null) && (dt.Rows[0]["DESCRICAO_ESTRUTURA"] != DBNull.Value)) entity.DescricaoEstrutura = Convert.ToString(dt.Rows[0]["DESCRICAO_ESTRUTURA"]);
            if ((dt.Rows[0]["ITEM_CONTROLE"] != null) && (dt.Rows[0]["ITEM_CONTROLE"] != DBNull.Value)) entity.ItemControle = Convert.ToString(dt.Rows[0]["ITEM_CONTROLE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcItemControleDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ITEM_CONTROLE Object"); }
        }
        //====================================================================
        public static List<AcItemControleDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcItemControleDTO> list = OracleDataTools.LoadEntity<AcItemControleDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcItemControleDTO>"); }
        }
        //====================================================================
        public static List<AcItemControleDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcItemControleDTO>"); }
        }
        //====================================================================
        public static List<AcItemControleDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcItemControleDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcItemControleDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcItemControle"); }
        }
        //====================================================================
        public static DTO.CollectionAcItemControleDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcItemControleDTO collection = new DTO.CollectionAcItemControleDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcItemControleDTO entity = new DTO.AcItemControleDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString().Length != 0) entity.DescricaoEstrutura = dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString();
                    if (dt.Rows[i]["ITEM_CONTROLE"].ToString().Length != 0) entity.ItemControle = dt.Rows[i]["ITEM_CONTROLE"].ToString();

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
            dict.Add("DescricaoEstrutura", "DESCRICAO_ESTRUTURA");
            dict.Add("ItemControle", "ITEM_CONTROLE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
