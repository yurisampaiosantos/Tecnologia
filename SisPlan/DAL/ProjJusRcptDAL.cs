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
    public class ProjJusRcptDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.ID_JUNTA, X.PLATAFORMA, X.MODULO, X.BLOCO, X.JUNTA_REL, X.LEGENDA_EXECUTADA, X.SIGLA_TIPO, X.NUMISO, X.FILE_NAME, X.CREATED_BY, TO_DATE(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE, X.MODIFIED_BY, TO_DATE(X.MODIFIED_DATE,'DD/MM/YYYY HH24:MI:SS') AS MODIFIED_DATE FROM PROJ_JUS_RCPT X ";
        //====================================================================
        public static int Insert(DTO.ProjJusRcptDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO PROJ_JUS_RCPT(ID_JUNTA, PLATAFORMA, MODULO, BLOCO, JUNTA_REL, LEGENDA_EXECUTADA, SIGLA_TIPO, NUMISO, FILE_NAME, CREATED_BY,CREATED_DATE) VALUES(:ID_JUNTA, :PLATAFORMA, :MODULO, :BLOCO, :JUNTA_REL, :LEGENDA_EXECUTADA, :SIGLA_TIPO, :NUMISO, :FILE_NAME, :CREATED_BY,:CREATED_DATE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID_JUNTA", OracleDbType.NVarchar2).Value = entity.IdJunta;
                cmd.Parameters.Add(":PLATAFORMA", OracleDbType.NVarchar2).Value = entity.Plataforma;
                cmd.Parameters.Add(":MODULO", OracleDbType.NVarchar2).Value = entity.Modulo;
                cmd.Parameters.Add(":BLOCO", OracleDbType.NVarchar2).Value = entity.Bloco;
                cmd.Parameters.Add(":JUNTA_REL", OracleDbType.NVarchar2).Value = entity.JuntaRel;
                cmd.Parameters.Add(":LEGENDA_EXECUTADA", OracleDbType.NVarchar2).Value = entity.LegendaExecutada;
                cmd.Parameters.Add(":SIGLA_TIPO", OracleDbType.NVarchar2).Value = entity.SiglaTipo;
                cmd.Parameters.Add(":NUMISO", OracleDbType.NVarchar2).Value = entity.Numiso;
                cmd.Parameters.Add(":FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add(":CREATED_BY", OracleDbType.NVarchar2).Value = entity.CreatedBy;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else  cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjJusRcpt");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjJusRcpt");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjJusRcptDTO entity)
        {
            string strSQL = "UPDATE PROJ_JUS_RCPT SET PLATAFORMA = :PLATAFORMA, MODULO = :MODULO, BLOCO = :BLOCO, JUNTA_REL = :JUNTA_REL, LEGENDA_EXECUTADA = :LEGENDA_EXECUTADA, SIGLA_TIPO = :SIGLA_TIPO, NUMISO = :NUMISO, FILE_NAME = :FILE_NAME, MODIFIED_BY = :MODIFIED_BY, MODIFIED_DATE = :MODIFIED_DATE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("PLATAFORMA", OracleDbType.NVarchar2).Value = entity.Plataforma;
                cmd.Parameters.Add("MODULO", OracleDbType.NVarchar2).Value = entity.Modulo;
                cmd.Parameters.Add("BLOCO", OracleDbType.NVarchar2).Value = entity.Bloco;
                cmd.Parameters.Add("JUNTA_REL", OracleDbType.NVarchar2).Value = entity.JuntaRel;
                cmd.Parameters.Add("LEGENDA_EXECUTADA", OracleDbType.NVarchar2).Value = entity.LegendaExecutada;
                cmd.Parameters.Add("SIGLA_TIPO", OracleDbType.NVarchar2).Value = entity.SiglaTipo;
                cmd.Parameters.Add("NUMISO", OracleDbType.NVarchar2).Value = entity.Numiso;
                cmd.Parameters.Add("FILE_NAME", OracleDbType.NVarchar2).Value = entity.FileName;
                cmd.Parameters.Add("MODIFIED_BY", OracleDbType.NVarchar2).Value = entity.ModifiedBy;
                if (entity.ModifiedDate.ToOADate() == 0.0) cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                else cmd.Parameters.Add("MODIFIED_DATE", OracleDbType.Date).Value = entity.ModifiedDate;
                cmd.Parameters.Add("ID", OracleDbType.Decimal).Value = entity.ID;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) 
            { throw new Exception(ex.Message + " - Updating ProjJusRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM PROJ_JUS_RCPT WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjJusRcpt"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjJusRcpt"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM PROJ_JUS_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjJusRcpt"); }
        }
        //====================================================================
        public static int GetID(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT ID FROM PROJ_JUS_RCPT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetID ProjJusRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjJusRcpt"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjJusRcpt"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjJusRcpt"); }
        }
        //====================================================================
        public static DTO.ProjJusRcptDTO Get(decimal ID)
        {
            ProjJusRcptDTO entity = new ProjJusRcptDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["ID_JUNTA"] != null) && (dt.Rows[0]["ID_JUNTA"] != DBNull.Value)) entity.IdJunta = Convert.ToString(dt.Rows[0]["ID_JUNTA"]);
            if ((dt.Rows[0]["PLATAFORMA"] != null) && (dt.Rows[0]["PLATAFORMA"] != DBNull.Value)) entity.Plataforma = Convert.ToString(dt.Rows[0]["PLATAFORMA"]);
            if ((dt.Rows[0]["MODULO"] != null) && (dt.Rows[0]["MODULO"] != DBNull.Value)) entity.Modulo = Convert.ToString(dt.Rows[0]["MODULO"]);
            if ((dt.Rows[0]["BLOCO"] != null) && (dt.Rows[0]["BLOCO"] != DBNull.Value)) entity.Bloco = Convert.ToString(dt.Rows[0]["BLOCO"]);
            if ((dt.Rows[0]["JUNTA_REL"] != null) && (dt.Rows[0]["JUNTA_REL"] != DBNull.Value)) entity.JuntaRel = Convert.ToString(dt.Rows[0]["JUNTA_REL"]);
            if ((dt.Rows[0]["LEGENDA_EXECUTADA"] != null) && (dt.Rows[0]["LEGENDA_EXECUTADA"] != DBNull.Value)) entity.LegendaExecutada = Convert.ToString(dt.Rows[0]["LEGENDA_EXECUTADA"]);
            if ((dt.Rows[0]["SIGLA_TIPO"] != null) && (dt.Rows[0]["SIGLA_TIPO"] != DBNull.Value)) entity.SiglaTipo = Convert.ToString(dt.Rows[0]["SIGLA_TIPO"]);
            if ((dt.Rows[0]["NUMISO"] != null) && (dt.Rows[0]["NUMISO"] != DBNull.Value)) entity.Numiso = Convert.ToString(dt.Rows[0]["NUMISO"]);
            if ((dt.Rows[0]["FILE_NAME"] != null) && (dt.Rows[0]["FILE_NAME"] != DBNull.Value)) entity.FileName = Convert.ToString(dt.Rows[0]["FILE_NAME"]);
            if ((dt.Rows[0]["CREATED_BY"] != null) && (dt.Rows[0]["CREATED_BY"] != DBNull.Value)) entity.CreatedBy = Convert.ToString(dt.Rows[0]["CREATED_BY"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["MODIFIED_BY"] != null) && (dt.Rows[0]["MODIFIED_BY"] != DBNull.Value)) entity.ModifiedBy = Convert.ToString(dt.Rows[0]["MODIFIED_BY"]);
            if ((dt.Rows[0]["MODIFIED_DATE"] != null) && (dt.Rows[0]["MODIFIED_DATE"] != DBNull.Value)) entity.ModifiedDate = Convert.ToDateTime(dt.Rows[0]["MODIFIED_DATE"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.ProjJusRcptDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FILE_NAME Object"); }
        }
        //====================================================================
        public static List<ProjJusRcptDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjJusRcptDTO> list = OracleDataTools.LoadEntity<ProjJusRcptDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjJusRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjJusRcptDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjJusRcptDTO>"); }
        }
        //====================================================================
        public static List<ProjJusRcptDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjJusRcptDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjJusRcptDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjJusRcpt"); }
        }
        //====================================================================
        public static DTO.CollectionProjJusRcptDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjJusRcptDTO collection = new DTO.CollectionProjJusRcptDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjJusRcptDTO entity = new DTO.ProjJusRcptDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["ID_JUNTA"].ToString().Length != 0) entity.IdJunta = dt.Rows[i]["ID_JUNTA"].ToString();
                    if (dt.Rows[i]["PLATAFORMA"].ToString().Length != 0) entity.Plataforma = dt.Rows[i]["PLATAFORMA"].ToString();
                    if (dt.Rows[i]["MODULO"].ToString().Length != 0) entity.Modulo = dt.Rows[i]["MODULO"].ToString();
                    if (dt.Rows[i]["BLOCO"].ToString().Length != 0) entity.Bloco = dt.Rows[i]["BLOCO"].ToString();
                    if (dt.Rows[i]["JUNTA_REL"].ToString().Length != 0) entity.JuntaRel = dt.Rows[i]["JUNTA_REL"].ToString();
                    if (dt.Rows[i]["LEGENDA_EXECUTADA"].ToString().Length != 0) entity.LegendaExecutada = dt.Rows[i]["LEGENDA_EXECUTADA"].ToString();
                    if (dt.Rows[i]["SIGLA_TIPO"].ToString().Length != 0) entity.SiglaTipo = dt.Rows[i]["SIGLA_TIPO"].ToString();
                    if (dt.Rows[i]["NUMISO"].ToString().Length != 0) entity.Numiso = dt.Rows[i]["NUMISO"].ToString();
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
            dict.Add("IdJunta", "ID_JUNTA");
            dict.Add("Plataforma", "PLATAFORMA");
            dict.Add("Modulo", "MODULO");
            dict.Add("Bloco", "BLOCO");
            dict.Add("JuntaRel", "JUNTA_REL");
            dict.Add("LegendaExecutada", "LEGENDA_EXECUTADA");
            dict.Add("SiglaTipo", "SIGLA_TIPO");
            dict.Add("Numiso", "NUMISO");
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