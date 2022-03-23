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
    public class CpEscopoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ESCO_ID, X.ESCO_DESCRICAO, X.ESCO_CNTR_CODIGO FROM CP_ESCOPO X ";
        //====================================================================
        public static int Insert(DTO.CpEscopoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO CP_ESCOPO(ESCO_DESCRICAO,ESCO_CNTR_CODIGO) VALUES(:ESCO_DESCRICAO,:ESCO_CNTR_CODIGO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ESCO_DESCRICAO", OracleDbType.Varchar2).Value = entity.EscoDescricao;
                cmd.Parameters.Add(":ESCO_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.EscoCntrCodigo;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpEscopo");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpEscopo");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpEscopoDTO entity)
        {
            string strSQL = "UPDATE CP_ESCOPO set ESCO_DESCRICAO = :ESCO_DESCRICAO, ESCO_CNTR_CODIGO = :ESCO_CNTR_CODIGO WHERE  ESCO_ID = :ESCO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ESCO_DESCRICAO", OracleDbType.Varchar2).Value = entity.EscoDescricao;
                cmd.Parameters.Add(":ESCO_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.EscoCntrCodigo;
                cmd.Parameters.Add(":ESCO_ID", OracleDbType.Decimal).Value = entity.EscoId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpEscopo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal EscoId)
        {
            string strSQL = "DELETE FROM CP_ESCOPO WHERE ESCO_ID = :ESCO_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":EscoId", OracleDbType.Decimal).Value = EscoId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpEscopo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpEscopo"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM CP_ESCOPO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpEscopo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpEscopo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpEscopo"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpEscopo"); }
        }
        //====================================================================
        public static DTO.CpEscopoDTO Get(decimal EscoId)
        {
            CpEscopoDTO entity = new CpEscopoDTO();
            DataTable dt = null;
            string filter = "ESCO_ID = " + EscoId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ESCO_ID"] != null) && (dt.Rows[0]["ESCO_ID"] != DBNull.Value)) entity.EscoId = Convert.ToDecimal(dt.Rows[0]["ESCO_ID"]);
            if ((dt.Rows[0]["ESCO_DESCRICAO"] != null) && (dt.Rows[0]["ESCO_DESCRICAO"] != DBNull.Value)) entity.EscoDescricao = Convert.ToString(dt.Rows[0]["ESCO_DESCRICAO"]);
            if ((dt.Rows[0]["ESCO_CNTR_CODIGO"] != null) && (dt.Rows[0]["ESCO_CNTR_CODIGO"] != DBNull.Value)) entity.EscoCntrCodigo = Convert.ToString(dt.Rows[0]["ESCO_CNTR_CODIGO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpEscopoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ESCO_CNTR_CODIGO Object"); }
        }
        //====================================================================
        public static List<CpEscopoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpEscopoDTO> list = OracleDataTools.LoadEntity<CpEscopoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpEscopoDTO>"); }
        }
        //====================================================================
        public static List<CpEscopoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpEscopoDTO>"); }
        }
        //====================================================================
        public static List<CpEscopoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpEscopoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpEscopoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpEscopo"); }
        }
        //====================================================================
        public static DTO.CollectionCpEscopoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpEscopoDTO collection = new DTO.CollectionCpEscopoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpEscopoDTO entity = new DTO.CpEscopoDTO();
                    if (dt.Rows[i]["ESCO_ID"].ToString().Length != 0) entity.EscoId = Convert.ToDecimal(dt.Rows[i]["ESCO_ID"]);
                    if (dt.Rows[i]["ESCO_DESCRICAO"].ToString().Length != 0) entity.EscoDescricao = dt.Rows[i]["ESCO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["ESCO_CNTR_CODIGO"].ToString().Length != 0) entity.EscoCntrCodigo = dt.Rows[i]["ESCO_CNTR_CODIGO"].ToString();

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
            dict.Add("EscoId", "ESCO_ID");
            dict.Add("EscoDescricao", "ESCO_DESCRICAO");
            dict.Add("EscoCntrCodigo", "ESCO_CNTR_CODIGO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
