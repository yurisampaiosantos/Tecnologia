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
    public class ProjEleRcptDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.CODIGO, X.UNIDADE_PROCESSO, X.LOCAL, X.DESENHO, X.REVISAO, X.TAG, X.DESCRICAO, X.DIMENSAO, X.QUANT_PROJETO, X.QUANT_REAL, X.UNIDADE, X.CREATED_BY, CONVERT(VARCHAR(10), X.CREATED_DATE,103) AS CREATED_DATE, X.MODIFIED_BY, CONVERT(VARCHAR(10), X.MODIFIED_DATE,103) AS MODIFIED_DATE, X.FILE_NAME FROM EEP_CONVERSION.PROJ_ELE_RCPT X ";
        //====================================================================
        public static int Insert(DTO.ProjEleRcptDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_ELE_RCPT(CODIGO,UNIDADE_PROCESSO,LOCAL,DESENHO,REVISAO,TAG,DESCRICAO,DIMENSAO,QUANT_PROJETO,QUANT_REAL,UNIDADE,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,FILE_NAME) VALUES(:CODIGO,:UNIDADE_PROCESSO,:LOCAL,:DESENHO,:REVISAO,:TAG,:DESCRICAO,:DIMENSAO,:QUANT_PROJETO,:QUANT_REAL,:UNIDADE,:CREATED_BY,:CREATED_DATE,:MODIFIED_BY,:MODIFIED_DATE,:FILE_NAME)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":CODIGO", OracleDbType.NVarchar2).Value = entity.Codigo;
                cmd.Parameters.Add(":UNIDADE_PROCESSO", OracleDbType.NVarchar2).Value = entity.UnidadeProcesso;
                cmd.Parameters.Add(":LOCAL", OracleDbType.NVarchar2).Value = entity.Local;
                cmd.Parameters.Add(":DESENHO", OracleDbType.NVarchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":REVISAO", OracleDbType.NVarchar2).Value = entity.Revisao;
                cmd.Parameters.Add(":TAG", OracleDbType.NVarchar2).Value = entity.Tag;
                cmd.Parameters.Add(":DESCRICAO", OracleDbType.NVarchar2).Value = entity.Descricao;
                cmd.Parameters.Add(":DIMENSAO", OracleDbType.NVarchar2).Value = entity.Dimensao;
                cmd.Parameters.Add(":QUANT_PROJETO", OracleDbType.NVarchar2).Value = entity.QuantProjeto;
                cmd.Parameters.Add(":QUANT_REAL", OracleDbType.NVarchar2).Value = entity.QuantReal;
                cmd.Parameters.Add(":UNIDADE", OracleDbType.NVarchar2).Value = entity.Unidade;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add(":MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjEleRcpt");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjEleRcpt");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjEleRcptDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_ELE_RCPT set CODIGO = :CODIGO, UNIDADE_PROCESSO = :UNIDADE_PROCESSO, LOCAL = :LOCAL, DESENHO = :DESENHO, REVISAO = :REVISAO, TAG = :TAG, DESCRICAO = :DESCRICAO, DIMENSAO = :DIMENSAO, QUANT_PROJETO = :QUANT_PROJETO, QUANT_REAL = :QUANT_REAL, UNIDADE = :UNIDADE, CREATED_BY = :CREATED_BY, CREATED_DATE = :CREATED_DATE, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE, FILE_NAME = :FILE_NAME WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("CODIGO", OracleDbType.NVarchar2).Value = entity.Codigo;
                cmd.Parameters.Add("UNIDADE_PROCESSO", OracleDbType.NVarchar2).Value = entity.UnidadeProcesso;
                cmd.Parameters.Add("LOCAL", OracleDbType.NVarchar2).Value = entity.Local;
                cmd.Parameters.Add("DESENHO", OracleDbType.NVarchar2).Value = entity.Desenho;
                cmd.Parameters.Add("REVISAO", OracleDbType.NVarchar2).Value = entity.Revisao;
                cmd.Parameters.Add("TAG", OracleDbType.NVarchar2).Value = entity.Tag;
                cmd.Parameters.Add("DESCRICAO", OracleDbType.NVarchar2).Value = entity.Descricao;
                cmd.Parameters.Add("DIMENSAO", OracleDbType.NVarchar2).Value = entity.Dimensao;
                cmd.Parameters.Add("QUANT_PROJETO", OracleDbType.NVarchar2).Value = entity.QuantProjeto;
                cmd.Parameters.Add("QUANT_REAL", OracleDbType.NVarchar2).Value = entity.QuantReal;
                cmd.Parameters.Add("UNIDADE", OracleDbType.NVarchar2).Value = entity.Unidade;
                cmd.Parameters.Add("CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Decimal).Value = entity.FileName;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjEleRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_ELE_RCPT WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjEleRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEleRcpt"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_ELE_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjEleRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEleRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjEleRcpt"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjEleRcpt"); }
        }
        //====================================================================
        public static DTO.ProjEleRcptDTO Get(decimal ID)
        {
            ProjEleRcptDTO entity = new ProjEleRcptDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["CODIGO"] != null) && (dt.Rows[0]["CODIGO"] != DBNull.Value)) entity.Codigo = Convert.ToString(dt.Rows[0]["CODIGO"]);
            if ((dt.Rows[0]["UNIDADE_PROCESSO"] != null) && (dt.Rows[0]["UNIDADE_PROCESSO"] != DBNull.Value)) entity.UnidadeProcesso = Convert.ToString(dt.Rows[0]["UNIDADE_PROCESSO"]);
            if ((dt.Rows[0]["LOCAL"] != null) && (dt.Rows[0]["LOCAL"] != DBNull.Value)) entity.Local = Convert.ToString(dt.Rows[0]["LOCAL"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["REVISAO"] != null) && (dt.Rows[0]["REVISAO"] != DBNull.Value)) entity.Revisao = Convert.ToString(dt.Rows[0]["REVISAO"]);
            if ((dt.Rows[0]["TAG"] != null) && (dt.Rows[0]["TAG"] != DBNull.Value)) entity.Tag = Convert.ToString(dt.Rows[0]["TAG"]);
            if ((dt.Rows[0]["DESCRICAO"] != null) && (dt.Rows[0]["DESCRICAO"] != DBNull.Value)) entity.Descricao = Convert.ToString(dt.Rows[0]["DESCRICAO"]);
            if ((dt.Rows[0]["DIMENSAO"] != null) && (dt.Rows[0]["DIMENSAO"] != DBNull.Value)) entity.Dimensao = Convert.ToString(dt.Rows[0]["DIMENSAO"]);
            if ((dt.Rows[0]["QUANT_PROJETO"] != null) && (dt.Rows[0]["QUANT_PROJETO"] != DBNull.Value)) entity.QuantProjeto = Convert.ToString(dt.Rows[0]["QUANT_PROJETO"]);
            if ((dt.Rows[0]["QUANT_REAL"] != null) && (dt.Rows[0]["QUANT_REAL"] != DBNull.Value)) entity.QuantReal = Convert.ToString(dt.Rows[0]["QUANT_REAL"]);
            if ((dt.Rows[0]["UNIDADE"] != null) && (dt.Rows[0]["UNIDADE"] != DBNull.Value)) entity.Unidade = Convert.ToString(dt.Rows[0]["UNIDADE"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjEleRcptDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FILE_NAME Object"); }
        }
        //====================================================================
        public static List<ProjEleRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjEleRcptDTO> list = OracleDataTools.LoadEntity<ProjEleRcptDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEleRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjEleRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEleRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjEleRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjEleRcptDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjEleRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                //Hashtable dict = new GetDictionary();
                //string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                //string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                //if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 1";
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjEleRcpt"); }
        }
        //====================================================================
        public static DTO.CollectionProjEleRcptDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjEleRcptDTO collection = new DTO.CollectionProjEleRcptDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjEleRcptDTO entity = new DTO.ProjEleRcptDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["CODIGO"].ToString().Length != 0) entity.Codigo = dt.Rows[i]["CODIGO"].ToString();
                    if (dt.Rows[i]["UNIDADE_PROCESSO"].ToString().Length != 0) entity.UnidadeProcesso = dt.Rows[i]["UNIDADE_PROCESSO"].ToString();
                    if (dt.Rows[i]["LOCAL"].ToString().Length != 0) entity.Local = dt.Rows[i]["LOCAL"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["REVISAO"].ToString().Length != 0) entity.Revisao = dt.Rows[i]["REVISAO"].ToString();
                    if (dt.Rows[i]["TAG"].ToString().Length != 0) entity.Tag = dt.Rows[i]["TAG"].ToString();
                    if (dt.Rows[i]["DESCRICAO"].ToString().Length != 0) entity.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                    if (dt.Rows[i]["DIMENSAO"].ToString().Length != 0) entity.Dimensao = dt.Rows[i]["DIMENSAO"].ToString();
                    if (dt.Rows[i]["QUANT_PROJETO"].ToString().Length != 0) entity.QuantProjeto = Convert.ToString(dt.Rows[i]["QUANT_PROJETO"]);
                    if (dt.Rows[i]["QUANT_REAL"].ToString().Length != 0) entity.QuantReal = Convert.ToString(dt.Rows[i]["QUANT_REAL"]);
                    if (dt.Rows[i]["UNIDADE"].ToString().Length != 0) entity.Unidade = dt.Rows[i]["UNIDADE"].ToString();
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
            dict.Add("Codigo", "CODIGO");
            dict.Add("UnidadeProcesso", "UNIDADE_PROCESSO");
            dict.Add("Local", "LOCAL");
            dict.Add("Desenho", "DESENHO");
            dict.Add("Revisao", "REVISAO");
            dict.Add("Tag", "TAG");
            dict.Add("Descricao", "DESCRICAO");
            dict.Add("Dimensao", "DIMENSAO");
            dict.Add("QuantProjeto", "QUANT_PROJETO");
            dict.Add("QuantReal", "QUANT_REAL");
            dict.Add("Unidade", "UNIDADE");
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
