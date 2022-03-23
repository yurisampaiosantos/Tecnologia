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
    public class ProjemarTubulacaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.AREA, X.ISOM, X.PIPELINE, X.REVISAO, X.SPOOL, X.CONTRACTOR_CC, X.CLIENT_CC, X.SHORT_DESC, X.CATEGORIA, X.PART_DIAM1, X.PART_DIAM2, X.PART_SCHED1, X.PART_SCHED2, X.AREA_PAINTING, X.QUANTITY, X.WEIGHT, X.TREATMENT, X.CREATED_BY, TO_CHAR(CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE, X.MODIFIED_BY, TO_CHAR(X.MODIFIED_DATE,'DD/MM/YYYY HH24:MI:SS') AS MODIFIED_DATE, X.FILE_NAME FROM EEP_CONVERSION.PROJ_TUB_RCPT X ";
        //====================================================================
        public static void Insert(DTO.ProjTubRcptDTO entity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_TUB_RCPT(ISOM,SPOOL,CLIENT_CC,REVISAO,PIPELINE,CONTRACTOR_CC,SHORT_DESC,PART_DIAM1,PART_DIAM2,PART_SCHED1,PART_SCHED2,AREA_PAINTING,QUANTITY,WEIGHT,TREATMENT,AREA,CREATED_BY,CREATED_DATE, FILE_NAME, CATEGORIA) VALUES(:ISOM,:SPOOL,:CLIENT_CC,:REVISAO,:PIPELINE,:CONTRACTOR_CC,:SHORT_DESC,:PART_DIAM1,:PART_DIAM2,:PART_SCHED1,:PART_SCHED2,:AREA_PAINTING,:QUANTITY,:WEIGHT,:TREATMENT,:AREA,:CREATED_BY,:CREATED_DATE, :FILE_NAME, :CATEGORIA)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ISOM", OracleDbType.NVarchar2).Value = entity.Isom;
                cmd.Parameters.Add(":SPOOL", OracleDbType.NVarchar2).Value = entity.Spool;
                cmd.Parameters.Add(":CLIENT_CC", OracleDbType.NVarchar2).Value = entity.ClientCC;
                cmd.Parameters.Add(":REVISAO", OracleDbType.NVarchar2).Value = entity.Revisao;
                cmd.Parameters.Add(":CONTRACTOR_CC", OracleDbType.NVarchar2).Value = entity.ContractorCC;
                cmd.Parameters.Add(":PIPELINE", OracleDbType.NVarchar2).Value = entity.Pipeline;
                cmd.Parameters.Add(":SHORT_DESC", OracleDbType.NVarchar2).Value = entity.ShortDesc;
                cmd.Parameters.Add(":PART_DIAM1", OracleDbType.NVarchar2).Value = entity.PartDiam1;
                cmd.Parameters.Add(":PART_DIAM2", OracleDbType.NVarchar2).Value = entity.PartDiam2;
                cmd.Parameters.Add(":PART_SCHED1", OracleDbType.NVarchar2).Value = entity.PartSched1;
                cmd.Parameters.Add(":PART_SCHED2", OracleDbType.NVarchar2).Value = entity.PartSched2;
                cmd.Parameters.Add(":AREA_PAINTING", OracleDbType.NVarchar2).Value = entity.AreaPainting;
                cmd.Parameters.Add(":QUANTITY", OracleDbType.NVarchar2).Value = entity.Quantity;
                cmd.Parameters.Add(":WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add(":TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add(":AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add(":FILENAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add(":CATEGORIA", OracleDbType.NVarchar2).Value = entity.Categoria;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " - Inserting PROJ_TUB_RCPT");
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjTubRcptDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_TUB_RCPT set AREA = :AREA, ISOM = :ISOM, PIPELINE = :PIPELINE, REVISAO = :REVISAO, SPOOL = :SPOOL, CONTRACTOR_CC = :CONTRACTOR_CC, CLIENT_CC = :CLIENT_CC, SHORT_DESC = :SHORT_DESC, PART_DIAM1 = :PART_DIAM1, PART_DIAM2 = :PART_DIAM2, PART_SCHED1 = :PART_SCHED1, PART_SCHED2 = :PART_SCHED2, AREA_PAINTING = :AREA_PAINTING, QUANTITY = :QUANTITY, WEIGHT = :WEIGHT, TREATMENT = :TREATMENT,  MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE , FILE_NAME,  = :FILE_NAME, CATEGORIA = :CATEGORIA WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("ID", OracleDbType.NVarchar2).Value = entity.ID;
                cmd.Parameters.Add("AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add("ISOM", OracleDbType.NVarchar2).Value = entity.Isom;
                cmd.Parameters.Add("PIPELINE", OracleDbType.NVarchar2).Value = entity.Pipeline;
                cmd.Parameters.Add("REVISAO", OracleDbType.NVarchar2).Value = entity.Revisao;
                cmd.Parameters.Add("SPOOL", OracleDbType.NVarchar2).Value = entity.Spool;
                cmd.Parameters.Add("CONTRACTOR_CC", OracleDbType.NVarchar2).Value = entity.ContractorCC;
                cmd.Parameters.Add("CLIENT_CC", OracleDbType.NVarchar2).Value = entity.ClientCC;
                cmd.Parameters.Add("SHORT_DESC", OracleDbType.NVarchar2).Value = entity.ShortDesc;
                cmd.Parameters.Add("PART_DIAM1", OracleDbType.NVarchar2).Value = entity.PartDiam1;
                cmd.Parameters.Add("PART_DIAM2", OracleDbType.NVarchar2).Value = entity.PartDiam2;
                cmd.Parameters.Add("PART_SCHED1", OracleDbType.NVarchar2).Value = entity.PartSched1;
                cmd.Parameters.Add("PART_SCHED2", OracleDbType.NVarchar2).Value = entity.PartSched2;
                cmd.Parameters.Add("AREA_PAINTING", OracleDbType.NVarchar2).Value = entity.AreaPainting;
                cmd.Parameters.Add("QUANTITY", OracleDbType.NVarchar2).Value = entity.Quantity;
                cmd.Parameters.Add("WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add("TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add("CATEGORIA", OracleDbType.NVarchar2).Value = entity.Categoria;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating PROJ_TUB_RCPT"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_TUB_RCPT WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting PROJ_TUB_RCPT"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting PROJ_TUB_RCPT"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_TUB_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting PROJ_TUB_RCPT"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction PROJ_TUB_RCPT"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction PROJ_TUB_RCPT"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTablePROJ_TUB_RCPT"); }
        }
        //====================================================================
        public static DTO.ProjTubRcptDTO Get(decimal ID)
        {
            ProjTubRcptDTO entity = new ProjTubRcptDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["AREA"] != null) && (dt.Rows[0]["AREA"] != DBNull.Value)) entity.Area = Convert.ToString(dt.Rows[0]["AREA"]);
            if ((dt.Rows[0]["ISOM"] != null) && (dt.Rows[0]["ISOM"] != DBNull.Value)) entity.Isom = Convert.ToString(dt.Rows[0]["ISOM"]);
            if ((dt.Rows[0]["PIPELINE"] != null) && (dt.Rows[0]["PIPELINE"] != DBNull.Value)) entity.Pipeline = Convert.ToString(dt.Rows[0]["PIPELINE"]);
            if ((dt.Rows[0]["REVISAO"] != null) && (dt.Rows[0]["REVISAO"] != DBNull.Value)) entity.Revisao = Convert.ToString(dt.Rows[0]["REVISAO"]);
            if ((dt.Rows[0]["SPOOL"] != null) && (dt.Rows[0]["SPOOL"] != DBNull.Value)) entity.Spool = Convert.ToString(dt.Rows[0]["SPOOL"]);
            if ((dt.Rows[0]["CONTRACTOR_CC"] != null) && (dt.Rows[0]["CONTRACTOR_CC"] != DBNull.Value)) entity.ContractorCC = Convert.ToString(dt.Rows[0]["CONTRACTOR_CC"]);
            if ((dt.Rows[0]["CLIENT_CC"] != null) && (dt.Rows[0]["CLIENT_CC"] != DBNull.Value)) entity.ClientCC = Convert.ToString(dt.Rows[0]["CLIENT_CC"]);
            if ((dt.Rows[0]["SHORT_DESC"] != null) && (dt.Rows[0]["SHORT_DESC"] != DBNull.Value)) entity.ShortDesc = Convert.ToString(dt.Rows[0]["SHORT_DESC"]);
            if ((dt.Rows[0]["PART_DIAM1"] != null) && (dt.Rows[0]["PART_DIAM1"] != DBNull.Value)) entity.PartDiam1 = Convert.ToString(dt.Rows[0]["PART_DIAM1"]);
            if ((dt.Rows[0]["PART_DIAM2"] != null) && (dt.Rows[0]["PART_DIAM2"] != DBNull.Value)) entity.PartDiam2 = Convert.ToString(dt.Rows[0]["PART_DIAM2"]);
            if ((dt.Rows[0]["PART_SCHED1"] != null) && (dt.Rows[0]["PART_SCHED1"] != DBNull.Value)) entity.PartSched1 = Convert.ToString(dt.Rows[0]["PART_SCHED1"]);
            if ((dt.Rows[0]["PART_SCHED2"] != null) && (dt.Rows[0]["PART_SCHED2"] != DBNull.Value)) entity.PartSched2 = Convert.ToString(dt.Rows[0]["PART_SCHED2"]);
            if ((dt.Rows[0]["AREA_PAINTING"] != null) && (dt.Rows[0]["AREA_PAINTING"] != DBNull.Value)) entity.AreaPainting = Convert.ToString(dt.Rows[0]["AREA_PAINTING"]);
            if ((dt.Rows[0]["QUANTITY"] != null) && (dt.Rows[0]["QUANTITY"] != DBNull.Value)) entity.Quantity = dt.Rows[0]["QUANTITY"].ToString();
            if ((dt.Rows[0]["WEIGHT"] != null) && (dt.Rows[0]["WEIGHT"] != DBNull.Value)) entity.Weight = dt.Rows[0]["WEIGHT"].ToString();
            if ((dt.Rows[0]["TREATMENT"] != null) && (dt.Rows[0]["TREATMENT"] != DBNull.Value)) entity.Treatment = Convert.ToString(dt.Rows[0]["TREATMENT"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["CATEGORIA"] != null) && (dt.Rows[0]["CATEGORIA"] != DBNull.Value)) entity.Categoria = Convert.ToString(dt.Rows[0]["CATEGORIA"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjTubRcptDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MODIFIED_DATE Object"); }
        }
        //====================================================================
        public static List<ProjTubRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjTubRcptDTO> list = OracleDataTools.LoadEntity<ProjTubRcptDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjTubRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjTubRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionPROJ_TUB_RCPT"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubRcptDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjTubRcptDTO collection = new DTO.CollectionProjTubRcptDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjTubRcptDTO entity = new DTO.ProjTubRcptDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["AREA"].ToString().Length != 0) entity.Area = dt.Rows[i]["AREA"].ToString();
                    if (dt.Rows[i]["ISOM"].ToString().Length != 0) entity.Isom = dt.Rows[i]["ISOM"].ToString();
                    if (dt.Rows[i]["PIPELINE"].ToString().Length != 0) entity.Pipeline = dt.Rows[i]["PIPELINE"].ToString();
                    if (dt.Rows[i]["REVISAO"].ToString().Length != 0) entity.Revisao = dt.Rows[i]["REVISAO"].ToString();
                    if (dt.Rows[i]["SPOOL"].ToString().Length != 0) entity.Spool = dt.Rows[i]["SPOOL"].ToString();
                    if (dt.Rows[i]["CONTRACTOR_CC"].ToString().Length != 0) entity.ContractorCC = dt.Rows[i]["CONTRACTOR_CC"].ToString();
                    if (dt.Rows[i]["CLIENT_CC"].ToString().Length != 0) entity.ClientCC = dt.Rows[i]["CLIENT_CC"].ToString();
                    if (dt.Rows[i]["SHORT_DESC"].ToString().Length != 0) entity.ShortDesc = dt.Rows[i]["SHORT_DESC"].ToString();
                    if (dt.Rows[i]["PART_DIAM1"].ToString().Length != 0) entity.PartDiam1 = dt.Rows[i]["PART_DIAM1"].ToString();
                    if (dt.Rows[i]["PART_DIAM2"].ToString().Length != 0) entity.PartDiam2 = dt.Rows[i]["PART_DIAM2"].ToString();
                    if (dt.Rows[i]["PART_SCHED1"].ToString().Length != 0) entity.PartSched1 = dt.Rows[i]["PART_SCHED1"].ToString();
                    if (dt.Rows[i]["PART_SCHED2"].ToString().Length != 0) entity.PartSched2 = dt.Rows[i]["PART_SCHED2"].ToString();
                    if (dt.Rows[i]["AREA_PAINTING"].ToString().Length != 0) entity.AreaPainting = dt.Rows[i]["AREA_PAINTING"].ToString();
                    if (dt.Rows[i]["QUANTITY"].ToString().Length != 0) entity.Quantity = dt.Rows[i]["QUANTITY"].ToString();
                    if (dt.Rows[i]["WEIGHT"].ToString().Length != 0) entity.Weight = dt.Rows[i]["WEIGHT"].ToString();
                    if (dt.Rows[i]["TREATMENT"].ToString().Length != 0) entity.Treatment = dt.Rows[i]["TREATMENT"].ToString();
                    if (dt.Rows[i]["CREATED_BY"].ToString().Length != 0) entity.CreatedBy = dt.Rows[i]["CREATED_BY"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["MODIFIED_BY"].ToString().Length != 0) entity.ModifiedBy = dt.Rows[i]["MODIFIED_BY"].ToString();
                    if (dt.Rows[i]["MODIFIED_DATE"].ToString().Length != 0) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["MODIFIED_DATE"]);
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["CATEGORIA"].ToString().Length != 0) entity.Categoria = dt.Rows[i]["CATEGORIA"].ToString();

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
            dict.Add("Isom", "ISOM");
            dict.Add("Pipeline", "PIPELINE");
            dict.Add("Revisao", "REVISAO");
            dict.Add("Spool", "SPOOL");
            dict.Add("ContractorCC", "CONTRACTOR_CC");
            dict.Add("ClientCC", "CLIENT_CC");
            dict.Add("ShortDesc", "SHORT_DESC");
            dict.Add("PartDiam1", "PART_DIAM1");
            dict.Add("PartDiam2", "PART_DIAM2");
            dict.Add("PartSched1", "PART_SCHED1");
            dict.Add("PartSched2", "PART_SCHED2");
            dict.Add("AreaPainting", "AREA_PAINTING");
            dict.Add("Quantity", "QUANTITY");
            dict.Add("Weight", "WEIGHT");
            dict.Add("Treatment", "TREATMENT");
            dict.Add("CreatedBy", "CREATED_BY");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("ModifiedBy", "MODIFIED_BY");
            dict.Add("ModifiedDate", "MODIFIED_DATE");
            dict.Add("FileName", "FILE_NAME");
            dict.Add("Categoria", "CATEGORIA");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
