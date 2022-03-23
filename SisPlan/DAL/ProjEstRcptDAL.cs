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
    public class ProjEstRcptDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.PECA, X.PC, X.PESO, X.CRITERIO, X.DESCRICAO, X.CREATED_BY, CONVERT(VARCHAR(10), X.CREATED_DATE,103) AS CREATED_DATE, X.MODIFIED_BY, CONVERT(VARCHAR(10), X.MODIFIED_DATE,103) AS MODIFIED_DATE, X.FILE_NAME FROM PROJ_EST_RCPT X ";
        //====================================================================
        public static int Insert(DTO.ProjEstRcptDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO PROJ_EST_RCPT(PECA, PC,PESO,CRITERIO,DESCRICAO,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,FILE_NAME) VALUES(:PECA,:PC,:PESO,:CRITERIO,:DESCRICAO,:CREATED_BY,:CREATED_DATE,:MODIFIED_BY,:MODIFIED_DATE,:FILE_NAME)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PECA", OracleDbType.NVarchar2).Value = entity.Peca;
                cmd.Parameters.Add(":PC", OracleDbType.NVarchar2).Value = entity.PC;
                cmd.Parameters.Add(":PESO", OracleDbType.NVarchar2).Value = entity.Peso;
                cmd.Parameters.Add(":CRITERIO", OracleDbType.NVarchar2).Value = entity.Criterio;
                cmd.Parameters.Add(":DESCRICAO", OracleDbType.NVarchar2).Value = entity.Descricao;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else  cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add(":MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else  cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjEstRcpt");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjEstRcpt");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjEstRcptDTO entity)
        {
            string strSQL = "UPDATE PROJ_EST_RCPT set PECA = :PECA, PC = :PC, PESO = :PESO, CRITERIO = :CRITERIO, DESCRICAO = :DESCRICAO, CREATED_BY = :CREATED_BY, CREATED_DATE = :CREATED_DATE, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE, FILE_NAME = :FILE_NAME WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("PECA", OracleDbType.NVarchar2).Value = entity.Peca;
                cmd.Parameters.Add("PC", OracleDbType.NVarchar2).Value = entity.PC;
                cmd.Parameters.Add("PESO", OracleDbType.NVarchar2).Value = entity.Peso;
                cmd.Parameters.Add("CRITERIO", OracleDbType.NVarchar2).Value = entity.Criterio;
                cmd.Parameters.Add("DESCRICAO", OracleDbType.NVarchar2).Value = entity.Descricao;
                cmd.Parameters.Add("CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                //if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                //else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                //if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                //else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                //cmd.Parameters.Add("ID", OracleDbType.Int32).Value = entity.FileName;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjEstRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM PROJ_EST_RCPT WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjEstRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEstRcpt"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM PROJ_EST_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEstRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEstRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEstRcpt"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjEstRcpt"); }
        }
        
        //====================================================================
        public static DTO.ProjEstRcptDTO Get(decimal ID)
        {
            ProjEstRcptDTO entity = new ProjEstRcptDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["PECA"] != null) && (dt.Rows[0]["PECA"] != DBNull.Value)) entity.Peca = Convert.ToString(dt.Rows[0]["PECA"]);
            if ((dt.Rows[0]["PC"] != null) && (dt.Rows[0]["PC"] != DBNull.Value)) entity.PC = Convert.ToString(dt.Rows[0]["PC"]);
            if ((dt.Rows[0]["PESO"] != null) && (dt.Rows[0]["PESO"] != DBNull.Value)) entity.Peso = Convert.ToString(dt.Rows[0]["PESO"]);
            if ((dt.Rows[0]["CRITERIO"] != null) && (dt.Rows[0]["CRITERIO"] != DBNull.Value)) entity.Criterio = Convert.ToString(dt.Rows[0]["CRITERIO"]);
            if ((dt.Rows[0]["DESCRICAO"] != null) && (dt.Rows[0]["DESCRICAO"] != DBNull.Value)) entity.Descricao = Convert.ToString(dt.Rows[0]["DESCRICAO"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjEstRcptDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FILE_NAME Object"); }
        }
        //====================================================================
        public static List<ProjEstRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjEstRcptDTO> list = OracleDataTools.LoadEntity<ProjEstRcptDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjEstRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjEstRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEstRcptDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjEstRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjEstRcpt"); }
        }
        //====================================================================
        public static DTO.CollectionProjEstRcptDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjEstRcptDTO collection = new DTO.CollectionProjEstRcptDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjEstRcptDTO entity = new DTO.ProjEstRcptDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["PECA"].ToString().Length != 0) entity.Peca = dt.Rows[i]["PECA"].ToString();
                    if (dt.Rows[i]["PC"].ToString().Length != 0) entity.PC = dt.Rows[i]["PC"].ToString();
                    if (dt.Rows[i]["PESO"].ToString().Length != 0) entity.Peso = dt.Rows[i]["PESO"].ToString();
                    if (dt.Rows[i]["CRITERIO"].ToString().Length != 0) entity.Criterio = dt.Rows[i]["CRITERIO"].ToString();
                    if (dt.Rows[i]["DESCRICAO"].ToString().Length != 0) entity.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                    if (dt.Rows[i]["CREATED_BY"].ToString().Length != 0) entity.CreatedBy = dt.Rows[i]["CREATED_BY"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["MODIFIED_BY"].ToString().Length != 0) entity.ModifiedBy = dt.Rows[i]["MODIFIED_BY"].ToString();
                    if (dt.Rows[i]["MODIFIED_DATE"].ToString().Length != 0) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["MODIFIED_DATE"]);
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();

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
            dict.Add("Peca", "PECA");
            dict.Add("Peca", "PC");
            dict.Add("Peso", "PESO");
            dict.Add("Criterio", "CRITERIO");
            dict.Add("Descricao", "DESCRICAO");
            dict.Add("CreatedBy", "CREATED_BY");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("ModifiedBy", "MODIFIED_BY");
            dict.Add("ModifiedDate", "MODIFIED_DATE");
            dict.Add("FileName", "FILE_NAME");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
