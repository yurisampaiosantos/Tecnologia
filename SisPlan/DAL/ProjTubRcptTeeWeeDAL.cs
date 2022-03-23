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
    public class ProjTubRcptTeeweeDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.FPSO, X.AREA, X.SUBAREA, X.ISOM, X.REV, X.PIPELINE, X.ISOLINHA, X.REVLINHA, X.SPOOL, X.CLIENT_CC, X.CONTRACTOR_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.PART_SCHED1, X.PART_SCHED2, X.CATEGORY, X.AREA_PAINTING, X.QUANTITY, X.WEIGHT, X.PAINTING, X.TREATMENT, X.FILE_NAME, X.CREATED_BY, TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE, X.MODIFIED_BY, TO_CHAR(X.MODIFIED_DATE,'DD/MM/YYYY HH24:MI:SS') AS MODIFIED_DATE FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X ";
        //====================================================================
        public static int Insert(DTO.ProjTubRcptTeeweeDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE(FPSO,AREA,SUBAREA,ISOM,REV,PIPELINE,ISOLINHA,REVLINHA,SPOOL,CLIENT_CC,CONTRACTOR_CC,SHORT_DESC,PART_DIAM1,PART_DIAM2,PART_SCHED1,PART_SCHED2,CATEGORY,AREA_PAINTING,QUANTITY,WEIGHT,PAINTING,TREATMENT,FILE_NAME,CREATED_BY,CREATED_DATE) VALUES(:FPSO,:AREA,:SUBAREA,:ISOM,:REV,:PIPELINE,:ISOLINHA,:REVLINHA,:SPOOL,:CLIENT_CC,:CONTRACTOR_CC,:SHORT_DESC,:PART_DIAM1,:PART_DIAM2,:PART_SCHED1,:PART_SCHED2,:CATEGORY,:AREA_PAINTING,:QUANTITY,:WEIGHT,:PAINTING,:TREATMENT,:FILE_NAME,:CREATED_BY,SYSDATE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FPSO", OracleDbType.NVarchar2).Value = entity.Fpso;
                cmd.Parameters.Add(":AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add(":SUBAREA", OracleDbType.NVarchar2).Value = entity.Subarea;
                cmd.Parameters.Add(":ISOM", OracleDbType.NVarchar2).Value = entity.Isom;
                cmd.Parameters.Add(":REV", OracleDbType.NVarchar2).Value = entity.Rev;
                cmd.Parameters.Add(":PIPELINE", OracleDbType.NVarchar2).Value = entity.Pipeline;
                cmd.Parameters.Add(":ISOLINHA", OracleDbType.NVarchar2).Value = entity.Isolinha;
                cmd.Parameters.Add(":REVLINHA", OracleDbType.NVarchar2).Value = entity.Revlinha;
                cmd.Parameters.Add(":SPOOL", OracleDbType.NVarchar2).Value = entity.Spool;
                cmd.Parameters.Add(":CLIENT_CC", OracleDbType.NVarchar2).Value = entity.ClientCc;
                cmd.Parameters.Add(":CONTRACTOR_CC", OracleDbType.NVarchar2).Value = entity.ContractorCc;
                cmd.Parameters.Add(":SHORT_DESC", OracleDbType.NVarchar2).Value = entity.ShortDesc;
                cmd.Parameters.Add(":PART_DIAM1", OracleDbType.NVarchar2).Value = entity.PartDiam1;
                cmd.Parameters.Add(":PART_DIAM2", OracleDbType.NVarchar2).Value = entity.PartDiam2;
                cmd.Parameters.Add(":PART_SCHED1", OracleDbType.NVarchar2).Value = entity.PartSched1;
                cmd.Parameters.Add(":PART_SCHED2", OracleDbType.NVarchar2).Value = entity.PartSched2;
                cmd.Parameters.Add(":CATEGORY", OracleDbType.NVarchar2).Value = entity.Category;
                cmd.Parameters.Add(":AREA_PAINTING", OracleDbType.NVarchar2).Value = entity.AreaPainting;
                cmd.Parameters.Add(":QUANTITY", OracleDbType.NVarchar2).Value = entity.Quantity;
                cmd.Parameters.Add(":WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add(":PAINTING", OracleDbType.NVarchar2).Value = entity.Painting;
                cmd.Parameters.Add(":TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjTubRcptTeewee");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjTubRcptTeewee");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjTubRcptTeeweeDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE set FPSO = :FPSO, AREA = :AREA, SUBAREA = :SUBAREA, ISOM = :ISOM, REV = :REV, PIPELINE = :PIPELINE, ISOLINHA = :ISOLINHA, REVLINHA = :REVLINHA, SPOOL = :SPOOL, CLIENT_CC = :CLIENT_CC, CONTRACTOR_CC = :CONTRACTOR_CC, SHORT_DESC = :SHORT_DESC, PART_DIAM1 = :PART_DIAM1, PART_DIAM2 = :PART_DIAM2, PART_SCHED1 = :PART_SCHED1, PART_SCHED2 = :PART_SCHED2, CATEGORY = :CATEGORY, AREA_PAINTING = :AREA_PAINTING, QUANTITY = :QUANTITY, WEIGHT = :WEIGHT, PAINTING = :PAINTING, TREATMENT = :TREATMENT, FILE_NAME = :FILE_NAME, CREATED_BY = :CREATED_BY, CREATED_DATE = :CREATED_DATE, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = SYSDATE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("FPSO", OracleDbType.NVarchar2).Value = entity.Fpso;
                cmd.Parameters.Add("AREA", OracleDbType.NVarchar2).Value = entity.Area;
                cmd.Parameters.Add("SUBAREA", OracleDbType.NVarchar2).Value = entity.Subarea;
                cmd.Parameters.Add("ISOM", OracleDbType.NVarchar2).Value = entity.Isom;
                cmd.Parameters.Add("REV", OracleDbType.NVarchar2).Value = entity.Rev;
                cmd.Parameters.Add("PIPELINE", OracleDbType.NVarchar2).Value = entity.Pipeline;
                cmd.Parameters.Add("ISOLINHA", OracleDbType.NVarchar2).Value = entity.Isolinha;
                cmd.Parameters.Add("REVLINHA", OracleDbType.NVarchar2).Value = entity.Revlinha;
                cmd.Parameters.Add("SPOOL", OracleDbType.NVarchar2).Value = entity.Spool;
                cmd.Parameters.Add("CLIENT_CC", OracleDbType.NVarchar2).Value = entity.ClientCc;
                cmd.Parameters.Add("CONTRACTOR_CC", OracleDbType.NVarchar2).Value = entity.ContractorCc;
                cmd.Parameters.Add("SHORT_DESC", OracleDbType.NVarchar2).Value = entity.ShortDesc;
                cmd.Parameters.Add("PART_DIAM1", OracleDbType.NVarchar2).Value = entity.PartDiam1;
                cmd.Parameters.Add("PART_DIAM2", OracleDbType.NVarchar2).Value = entity.PartDiam2;
                cmd.Parameters.Add("PART_SCHED1", OracleDbType.NVarchar2).Value = entity.PartSched1;
                cmd.Parameters.Add("PART_SCHED2", OracleDbType.NVarchar2).Value = entity.PartSched2;
                cmd.Parameters.Add("CATEGORY", OracleDbType.NVarchar2).Value = entity.Category;
                cmd.Parameters.Add("AREA_PAINTING", OracleDbType.NVarchar2).Value = entity.AreaPainting;
                cmd.Parameters.Add("QUANTITY", OracleDbType.NVarchar2).Value = entity.Quantity;
                cmd.Parameters.Add("WEIGHT", OracleDbType.NVarchar2).Value = entity.Weight;
                cmd.Parameters.Add("PAINTING", OracleDbType.NVarchar2).Value = entity.Painting;
                cmd.Parameters.Add("TREATMENT", OracleDbType.NVarchar2).Value = entity.Treatment;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.Varchar2).Value = entity.FileName;
                cmd.Parameters.Add("CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjTubRcptTeewee"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjTubRcptTeewee"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubRcptTeewee"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjTubRcptTeewee"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubRcptTeewee"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjTubRcptTeewee"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjTubRcptTeewee"); }
        }
        //====================================================================
        public static DTO.ProjTubRcptTeeweeDTO Get(decimal ID)
        {
            ProjTubRcptTeeweeDTO entity = new ProjTubRcptTeeweeDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["FPSO"] != null) && (dt.Rows[0]["FPSO"] != DBNull.Value)) entity.Fpso = Convert.ToString(dt.Rows[0]["FPSO"]);
            if ((dt.Rows[0]["AREA"] != null) && (dt.Rows[0]["AREA"] != DBNull.Value)) entity.Area = Convert.ToString(dt.Rows[0]["AREA"]);
            if ((dt.Rows[0]["SUBAREA"] != null) && (dt.Rows[0]["SUBAREA"] != DBNull.Value)) entity.Subarea = Convert.ToString(dt.Rows[0]["SUBAREA"]);
            if ((dt.Rows[0]["ISOM"] != null) && (dt.Rows[0]["ISOM"] != DBNull.Value)) entity.Isom = Convert.ToString(dt.Rows[0]["ISOM"]);
            if ((dt.Rows[0]["REV"] != null) && (dt.Rows[0]["REV"] != DBNull.Value)) entity.Rev = Convert.ToString(dt.Rows[0]["REV"]);
            if ((dt.Rows[0]["PIPELINE"] != null) && (dt.Rows[0]["PIPELINE"] != DBNull.Value)) entity.Pipeline = Convert.ToString(dt.Rows[0]["PIPELINE"]);
            if ((dt.Rows[0]["ISOLINHA"] != null) && (dt.Rows[0]["ISOLINHA"] != DBNull.Value)) entity.Isolinha = Convert.ToString(dt.Rows[0]["ISOLINHA"]);
            if ((dt.Rows[0]["REVLINHA"] != null) && (dt.Rows[0]["REVLINHA"] != DBNull.Value)) entity.Revlinha = Convert.ToString(dt.Rows[0]["REVLINHA"]);
            if ((dt.Rows[0]["SPOOL"] != null) && (dt.Rows[0]["SPOOL"] != DBNull.Value)) entity.Spool = Convert.ToString(dt.Rows[0]["SPOOL"]);
            if ((dt.Rows[0]["CLIENT_CC"] != null) && (dt.Rows[0]["CLIENT_CC"] != DBNull.Value)) entity.ClientCc = Convert.ToString(dt.Rows[0]["CLIENT_CC"]);
            if ((dt.Rows[0]["CONTRACTOR_CC"] != null) && (dt.Rows[0]["CONTRACTOR_CC"] != DBNull.Value)) entity.ContractorCc = Convert.ToString(dt.Rows[0]["CONTRACTOR_CC"]);
            if ((dt.Rows[0]["SHORT_DESC"] != null) && (dt.Rows[0]["SHORT_DESC"] != DBNull.Value)) entity.ShortDesc = Convert.ToString(dt.Rows[0]["SHORT_DESC"]);
            if ((dt.Rows[0]["PART_DIAM1"] != null) && (dt.Rows[0]["PART_DIAM1"] != DBNull.Value)) entity.PartDiam1 = Convert.ToString(dt.Rows[0]["PART_DIAM1"]);
            if ((dt.Rows[0]["PART_DIAM2"] != null) && (dt.Rows[0]["PART_DIAM2"] != DBNull.Value)) entity.PartDiam2 = Convert.ToString(dt.Rows[0]["PART_DIAM2"]);
            if ((dt.Rows[0]["PART_SCHED1"] != null) && (dt.Rows[0]["PART_SCHED1"] != DBNull.Value)) entity.PartSched1 = Convert.ToString(dt.Rows[0]["PART_SCHED1"]);
            if ((dt.Rows[0]["PART_SCHED2"] != null) && (dt.Rows[0]["PART_SCHED2"] != DBNull.Value)) entity.PartSched2 = Convert.ToString(dt.Rows[0]["PART_SCHED2"]);
            if ((dt.Rows[0]["CATEGORY"] != null) && (dt.Rows[0]["CATEGORY"] != DBNull.Value)) entity.Category = Convert.ToString(dt.Rows[0]["CATEGORY"]);
            if ((dt.Rows[0]["AREA_PAINTING"] != null) && (dt.Rows[0]["AREA_PAINTING"] != DBNull.Value)) entity.AreaPainting = Convert.ToString(dt.Rows[0]["AREA_PAINTING"]);
            if ((dt.Rows[0]["QUANTITY"] != null) && (dt.Rows[0]["QUANTITY"] != DBNull.Value)) entity.Quantity = Convert.ToString(dt.Rows[0]["QUANTITY"]);
            if ((dt.Rows[0]["WEIGHT"] != null) && (dt.Rows[0]["WEIGHT"] != DBNull.Value)) entity.Weight = Convert.ToString(dt.Rows[0]["WEIGHT"]);
            if ((dt.Rows[0]["PAINTING"] != null) && (dt.Rows[0]["PAINTING"] != DBNull.Value)) entity.Painting = Convert.ToString(dt.Rows[0]["PAINTING"]);
            if ((dt.Rows[0]["TREATMENT"] != null) && (dt.Rows[0]["TREATMENT"] != DBNull.Value)) entity.Treatment = Convert.ToString(dt.Rows[0]["TREATMENT"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjTubRcptTeeweeDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MODIFIED_DATE Object"); }
        }
        //====================================================================
        public static List<ProjTubRcptTeeweeDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjTubRcptTeeweeDTO> list = OracleDataTools.LoadEntity<ProjTubRcptTeeweeDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptTeeweeDTO>"); }
        }
        //====================================================================
        public static List<ProjTubRcptTeeweeDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptTeeweeDTO>"); }
        }
        //====================================================================
        public static List<ProjTubRcptTeeweeDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjTubRcptTeeweeDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubRcptTeeweeDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjTubRcptTeewee"); }
        }
        //====================================================================
        public static DTO.CollectionProjTubRcptTeeweeDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjTubRcptTeeweeDTO collection = new DTO.CollectionProjTubRcptTeeweeDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjTubRcptTeeweeDTO entity = new DTO.ProjTubRcptTeeweeDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["FPSO"].ToString().Length != 0) entity.Fpso = dt.Rows[i]["FPSO"].ToString();
                    if (dt.Rows[i]["AREA"].ToString().Length != 0) entity.Area = dt.Rows[i]["AREA"].ToString();
                    if (dt.Rows[i]["SUBAREA"].ToString().Length != 0) entity.Subarea = dt.Rows[i]["SUBAREA"].ToString();
                    if (dt.Rows[i]["ISOM"].ToString().Length != 0) entity.Isom = dt.Rows[i]["ISOM"].ToString();
                    if (dt.Rows[i]["REV"].ToString().Length != 0) entity.Rev = dt.Rows[i]["REV"].ToString();
                    if (dt.Rows[i]["PIPELINE"].ToString().Length != 0) entity.Pipeline = dt.Rows[i]["PIPELINE"].ToString();
                    if (dt.Rows[i]["ISOLINHA"].ToString().Length != 0) entity.Isolinha = dt.Rows[i]["ISOLINHA"].ToString();
                    if (dt.Rows[i]["REVLINHA"].ToString().Length != 0) entity.Revlinha = dt.Rows[i]["REVLINHA"].ToString();
                    if (dt.Rows[i]["SPOOL"].ToString().Length != 0) entity.Spool = dt.Rows[i]["SPOOL"].ToString();
                    if (dt.Rows[i]["CLIENT_CC"].ToString().Length != 0) entity.ClientCc = dt.Rows[i]["CLIENT_CC"].ToString();
                    if (dt.Rows[i]["CONTRACTOR_CC"].ToString().Length != 0) entity.ContractorCc = dt.Rows[i]["CONTRACTOR_CC"].ToString();
                    if (dt.Rows[i]["SHORT_DESC"].ToString().Length != 0) entity.ShortDesc = dt.Rows[i]["SHORT_DESC"].ToString();
                    if (dt.Rows[i]["PART_DIAM1"].ToString().Length != 0) entity.PartDiam1 = dt.Rows[i]["PART_DIAM1"].ToString();
                    if (dt.Rows[i]["PART_DIAM2"].ToString().Length != 0) entity.PartDiam2 = dt.Rows[i]["PART_DIAM2"].ToString();
                    if (dt.Rows[i]["PART_SCHED1"].ToString().Length != 0) entity.PartSched1 = dt.Rows[i]["PART_SCHED1"].ToString();
                    if (dt.Rows[i]["PART_SCHED2"].ToString().Length != 0) entity.PartSched2 = dt.Rows[i]["PART_SCHED2"].ToString();
                    if (dt.Rows[i]["CATEGORY"].ToString().Length != 0) entity.Category = dt.Rows[i]["CATEGORY"].ToString();
                    if (dt.Rows[i]["AREA_PAINTING"].ToString().Length != 0) entity.AreaPainting = dt.Rows[i]["AREA_PAINTING"].ToString();
                    if (dt.Rows[i]["QUANTITY"].ToString().Length != 0) entity.Quantity = dt.Rows[i]["QUANTITY"].ToString();
                    if (dt.Rows[i]["WEIGHT"].ToString().Length != 0) entity.Weight = dt.Rows[i]["WEIGHT"].ToString();
                    if (dt.Rows[i]["PAINTING"].ToString().Length != 0) entity.Painting = dt.Rows[i]["PAINTING"].ToString();
                    if (dt.Rows[i]["TREATMENT"].ToString().Length != 0) entity.Treatment = dt.Rows[i]["TREATMENT"].ToString();
                    if (dt.Rows[i]["FILE_NAME"].ToString().Length != 0) entity.FileName = dt.Rows[i]["FILE_NAME"].ToString();
                    if (dt.Rows[i]["CREATED_BY"].ToString().Length != 0) entity.CreatedBy = dt.Rows[i]["CREATED_BY"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["MODIFIED_BY"].ToString().Length != 0) entity.ModifiedBy = dt.Rows[i]["MODIFIED_BY"].ToString();
                    if (dt.Rows[i]["MODIFIED_DATE"].ToString().Length != 0) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[i]["MODIFIED_DATE"]);

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
            dict.Add("Fpso", "FPSO");
            dict.Add("Area", "AREA");
            dict.Add("Subarea", "SUBAREA");
            dict.Add("Isom", "ISOM");
            dict.Add("Rev", "REV");
            dict.Add("Pipeline", "PIPELINE");
            dict.Add("Isolinha", "ISOLINHA");
            dict.Add("Revlinha", "REVLINHA");
            dict.Add("Spool", "SPOOL");
            dict.Add("ClientCc", "CLIENT_CC");
            dict.Add("ContractorCc", "CONTRACTOR_CC");
            dict.Add("ShortDesc", "SHORT_DESC");
            dict.Add("PartDiam1", "PART_DIAM1");
            dict.Add("PartDiam2", "PART_DIAM2");
            dict.Add("PartSched1", "PART_SCHED1");
            dict.Add("PartSched2", "PART_SCHED2");
            dict.Add("Category", "CATEGORY");
            dict.Add("AreaPainting", "AREA_PAINTING");
            dict.Add("Quantity", "QUANTITY");
            dict.Add("Weight", "WEIGHT");
            dict.Add("Painting", "PAINTING");
            dict.Add("Treatment", "TREATMENT");
            dict.Add("FileName", "FILE_NAME");
            dict.Add("CreatedBy", "CREATED_BY");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("ModifiedBy", "MODIFIED_BY");
            dict.Add("ModifiedDate", "MODIFIED_DATE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
