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
    public class ProjOutRcptDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.AREA, X.DESENHO, X.REV, X.TAG, X.CODIGO, X.MATERIAL, X.DIM1, X.DIM2, X.DIM3, X.QTD, X.UNID, X.WEIGHT, X.TIPO, X.CREATED_BY, CONVERT(VARCHAR(10), X.CREATED_DATE,103) AS CREATED_DATE, X.MODIFIED_BY, CONVERT(VARCHAR(10), X.MODIFIED_DATE,103) AS MODIFIED_DATE, X.FILE_NAME, X.TREATMENT, X.MULT FROM EEP_CONVERSION.PROJ_OUT_RCPT X ";
        //====================================================================
        public static int Insert(DTO.ProjOutRcptDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_OUT_RCPT(AREA,DESENHO,REV,TAG,CODIGO,MATERIAL,DIM1,DIM2,DIM3,QTD,UNID,WEIGHT,TIPO,TREATMENT,CREATED_BY,CREATED_DATE,MODIFIED_BY,MODIFIED_DATE,FILE_NAME, MULT) VALUES(:AREA,:DESENHO,:REV,:TAG,:CODIGO,:MATERIAL,:DIM1,:DIM2,:DIM3,:QTD,:UNID,:WEIGHT,:TIPO,:TREATMENT,:CREATED_BY,:CREATED_DATE,:MODIFIED_BY,:MODIFIED_DATE,:FILE_NAME, :MULT)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add(":DESENHO", OracleDbType.NVarchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":REV", OracleDbType.NVarchar2).Value = entity.Rev;
                cmd.Parameters.Add(":TAG", OracleDbType.NVarchar2).Value = entity.Tag;
                cmd.Parameters.Add(":CODIGO", OracleDbType.NVarchar2).Value = entity.Codigo;
                cmd.Parameters.Add(":MATERIAL", OracleDbType.NVarchar2).Value = entity.Material;
                cmd.Parameters.Add(":DIM1", OracleDbType.NVarchar2).Value = entity.Dim1;
                cmd.Parameters.Add(":DIM2", OracleDbType.NVarchar2).Value = entity.Dim2;
                cmd.Parameters.Add(":DIM3", OracleDbType.NVarchar2).Value = entity.Dim3;
                cmd.Parameters.Add(":QTD", OracleDbType.NVarchar2).Value = entity.Qtd;
                cmd.Parameters.Add(":UNID", OracleDbType.NVarchar2).Value = entity.Unid;
                cmd.Parameters.Add(":WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add(":TIPO", OracleDbType.NVarchar2).Value = entity.Tipo;
                cmd.Parameters.Add(":TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else  cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add(":MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else  cmd.Parameters.Add(":MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add(":MULT", OracleDbType.NVarchar2).Value = entity.Mult;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjOutRcpt");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjOutRcpt");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjOutRcptDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_OUT_RCPT set AREA = :AREA, DESENHO = :DESENHO, REV = :REV, TAG = :TAG, CODIGO = :CODIGO, MATERIAL = :MATERIAL, DIM1 = :DIM1, DIM2 = :DIM2, DIM3 = :DIM3, QTD = :QTD, UNID = :UNID, WEIGHT = :WEIGHT, TIPO = :TIPO, TREATMENT = :TREATMENT, CREATED_BY = :CREATED_BY, CREATED_DATE = :CREATED_DATE, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE, FILE_NAME = :FILE_NAME, MULT = :MULT WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add("DESENHO", OracleDbType.NVarchar2).Value = entity.Desenho;
                cmd.Parameters.Add("REV", OracleDbType.NVarchar2).Value = entity.Rev;
                cmd.Parameters.Add("TAG", OracleDbType.NVarchar2).Value = entity.Tag;
                cmd.Parameters.Add("CODIGO", OracleDbType.NVarchar2).Value = entity.Codigo;
                cmd.Parameters.Add("MATERIAL", OracleDbType.NVarchar2).Value = entity.Material;
                cmd.Parameters.Add("DIM1", OracleDbType.NVarchar2).Value = entity.Dim1;
                cmd.Parameters.Add("DIM2", OracleDbType.NVarchar2).Value = entity.Dim2;
                cmd.Parameters.Add("DIM3", OracleDbType.NVarchar2).Value = entity.Dim3;
                cmd.Parameters.Add("QTD", OracleDbType.NVarchar2).Value = entity.Qtd;
                cmd.Parameters.Add("UNID", OracleDbType.NVarchar2).Value = entity.Unid;
                cmd.Parameters.Add("WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add("TIPO", OracleDbType.NVarchar2).Value = entity.Tipo;
                cmd.Parameters.Add("TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add("CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add("MULT", OracleDbType.NVarchar2).Value = entity.Mult;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjOutRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_OUT_RCPT WHERE  ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjOutRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjOutRcpt"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_OUT_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjOutRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjOutRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjOutRcpt"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjOutRcpt"); }
        }
        //====================================================================
        public static DTO.ProjOutRcptDTO Get(decimal ID)
        {
            ProjOutRcptDTO entity = new ProjOutRcptDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["AREA"] != null) && (dt.Rows[0]["AREA"] != DBNull.Value)) entity.Area = Convert.ToString(dt.Rows[0]["AREA"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["REV"] != null) && (dt.Rows[0]["REV"] != DBNull.Value)) entity.Rev = Convert.ToString(dt.Rows[0]["REV"]);
            if ((dt.Rows[0]["TAG"] != null) && (dt.Rows[0]["TAG"] != DBNull.Value)) entity.Tag = Convert.ToString(dt.Rows[0]["TAG"]);
            if ((dt.Rows[0]["CODIGO"] != null) && (dt.Rows[0]["CODIGO"] != DBNull.Value)) entity.Codigo = Convert.ToString(dt.Rows[0]["CODIGO"]);
            if ((dt.Rows[0]["MATERIAL"] != null) && (dt.Rows[0]["MATERIAL"] != DBNull.Value)) entity.Material = Convert.ToString(dt.Rows[0]["MATERIAL"]);
            if ((dt.Rows[0]["DIM1"] != null) && (dt.Rows[0]["DIM1"] != DBNull.Value)) entity.Dim1 = Convert.ToString(dt.Rows[0]["DIM1"]);
            if ((dt.Rows[0]["DIM2"] != null) && (dt.Rows[0]["DIM2"] != DBNull.Value)) entity.Dim2 = Convert.ToString(dt.Rows[0]["DIM2"]);
            if ((dt.Rows[0]["DIM3"] != null) && (dt.Rows[0]["DIM3"] != DBNull.Value)) entity.Dim3 = Convert.ToString(dt.Rows[0]["DIM3"]);
            if ((dt.Rows[0]["QTD"] != null) && (dt.Rows[0]["QTD"] != DBNull.Value)) entity.Qtd = Convert.ToString(dt.Rows[0]["QTD"]);
            if ((dt.Rows[0]["UNID"] != null) && (dt.Rows[0]["UNID"] != DBNull.Value)) entity.Unid = Convert.ToString(dt.Rows[0]["UNID"]);
            if ((dt.Rows[0]["WEIGHT"] != null) && (dt.Rows[0]["WEIGHT"] != DBNull.Value)) entity.Weight = Convert.ToString(dt.Rows[0]["WEIGHT"]);
            if ((dt.Rows[0]["TIPO"] != null) && (dt.Rows[0]["TIPO"] != DBNull.Value)) entity.Tipo = Convert.ToString(dt.Rows[0]["TIPO"]);
            if ((dt.Rows[0]["TREATMENT"] != null) && (dt.Rows[0]["TREATMENT"] != DBNull.Value)) entity.Treatment = Convert.ToString(dt.Rows[0]["TREATMENT"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["MULT"] != null) && (dt.Rows[0]["MULT"] != DBNull.Value)) entity.Mult = Convert.ToString(dt.Rows[0]["MULT"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjOutRcptDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FILE_NAME Object"); }
        }
        //====================================================================
        public static List<ProjOutRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjOutRcptDTO> list = OracleDataTools.LoadEntity<ProjOutRcptDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjOutRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjOutRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjOutRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjOutRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjOutRcptDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjOutRcpt"); }
        }
        //====================================================================
        public static DTO.CollectionProjOutRcptDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjOutRcptDTO collection = new DTO.CollectionProjOutRcptDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjOutRcptDTO entity = new DTO.ProjOutRcptDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["AREA"].ToString().Length != 0) entity.Area = dt.Rows[i]["AREA"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["REV"].ToString().Length != 0) entity.Rev = dt.Rows[i]["REV"].ToString();
                    if (dt.Rows[i]["TAG"].ToString().Length != 0) entity.Tag = dt.Rows[i]["TAG"].ToString();
                    if (dt.Rows[i]["CODIGO"].ToString().Length != 0) entity.Codigo = dt.Rows[i]["CODIGO"].ToString();
                    if (dt.Rows[i]["MATERIAL"].ToString().Length != 0) entity.Material = dt.Rows[i]["MATERIAL"].ToString();
                    if (dt.Rows[i]["DIM1"].ToString().Length != 0) entity.Dim1 = dt.Rows[i]["DIM1"].ToString();
                    if (dt.Rows[i]["DIM2"].ToString().Length != 0) entity.Dim2 = dt.Rows[i]["DIM2"].ToString();
                    if (dt.Rows[i]["DIM3"].ToString().Length != 0) entity.Dim3 = dt.Rows[i]["DIM3"].ToString();
                    if (dt.Rows[i]["QTD"].ToString().Length != 0) entity.Qtd = dt.Rows[i]["QTD"].ToString();
                    if (dt.Rows[i]["UNID"].ToString().Length != 0) entity.Unid = dt.Rows[i]["UNID"].ToString();
                    if (dt.Rows[i]["WEIGHT"].ToString().Length != 0) entity.Weight = dt.Rows[i]["WEIGHT"].ToString();
                    if (dt.Rows[i]["TIPO"].ToString().Length != 0) entity.Tipo = dt.Rows[i]["TIPO"].ToString();
                    if (dt.Rows[i]["TREATMENT"].ToString().Length != 0) entity.Treatment = dt.Rows[i]["TREATMENT"].ToString();
                    if (dt.Rows[i]["CREATED_BY"].ToString().Length != 0) entity.CreatedBy = dt.Rows[i]["CREATED_BY"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["MODIFIED_BY"].ToString().Length != 0) entity.ModifiedBy = dt.Rows[i]["MODIFIED_BY"].ToString();
                    if (dt.Rows[i]["MODIFIED_DATE"].ToString().Length != 0) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["MODIFIED_DATE"]);
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["MULT"].ToString().Length != 0) entity.Mult = dt.Rows[i]["MULT"].ToString();

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
            dict.Add("Area", "AREA");
            dict.Add("Desenho", "DESENHO");
            dict.Add("Rev", "REV");
            dict.Add("Tag", "TAG");
            dict.Add("Codigo", "CODIGO");
            dict.Add("Material", "MATERIAL");
            dict.Add("Dim1", "DIM1");
            dict.Add("Dim2", "DIM2");
            dict.Add("Dim3", "DIM3");
            dict.Add("Qtd", "QTD");
            dict.Add("Unid", "UNID");
            dict.Add("Weight", "WEIGHT");
            dict.Add("Tipo", "TIPO");
            dict.Add("Treatment", "TREATMENT");
            dict.Add("CreatedBy", "CREATED_BY");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("ModifiedBy", "MODIFIED_BY");
            dict.Add("ModifiedDate", "MODIFIED_DATE");
            dict.Add("FileName", "FILE_NAME");
            dict.Add("Mult", "MULT");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
