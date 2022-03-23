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
    public class ProjPlatAreaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.PLATAFORMA, X.MODULO, X.BLOCO, X.ARAP_SIGLA, X.ARAP_ID, X.ARAP_CNTR_CODIGO FROM PROJ_PLAT_AREA X ";
        //====================================================================
        public static int Insert(DTO.ProjPlatAreaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO PROJ_PLAT_AREA(PLATAFORMA,MODULO,BLOCO,ARAP_SIGLA,ARAP_ID,ARAP_CNTR_CODIGO) VALUES(:PLATAFORMA,:MODULO,:BLOCO,:ARAP_SIGLA,:ARAP_ID,:ARAP_CNTR_CODIGO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PLATAFORMA", OracleDbType.Varchar2).Value = entity.Plataforma;
                cmd.Parameters.Add(":MODULO", OracleDbType.Varchar2).Value = entity.Modulo;
                cmd.Parameters.Add(":BLOCO", OracleDbType.Varchar2).Value = entity.Bloco;
                cmd.Parameters.Add(":ARAP_SIGLA", OracleDbType.Varchar2).Value = entity.ArapSigla;
                cmd.Parameters.Add(":ARAP_ID", OracleDbType.Int32).Value = entity.ArapId;
                cmd.Parameters.Add(":ARAP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.ArapCntrCodigo;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjPlatArea");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjPlatArea");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjPlatAreaDTO entity)
        {
            string strSQL = "UPDATE PROJ_PLAT_AREA set PLATAFORMA = :PLATAFORMA, MODULO = :MODULO, BLOCO = :BLOCO, ARAP_SIGLA = :ARAP_SIGLA, ARAP_ID = :ARAP_ID, ARAP_CNTR_CODIGO = :ARAP_CNTR_CODIGO WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("PLATAFORMA", OracleDbType.Varchar2).Value = entity.Plataforma;
                cmd.Parameters.Add("MODULO", OracleDbType.Varchar2).Value = entity.Modulo;
                cmd.Parameters.Add("BLOCO", OracleDbType.Varchar2).Value = entity.Bloco;
                cmd.Parameters.Add("ARAP_SIGLA", OracleDbType.Varchar2).Value = entity.ArapSigla;
                cmd.Parameters.Add("ARAP_ID", OracleDbType.Int32).Value = entity.ArapId;
                cmd.Parameters.Add("ARAP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.ArapCntrCodigo;
                cmd.Parameters.Add("ARAP_CNTR_CODIGO", OracleDbType.Int32).Value = entity.ArapCntrCodigo;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjPlatArea"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM PROJ_PLAT_AREA WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjPlatArea"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjPlatArea"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM PROJ_PLAT_AREA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjPlatArea"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjPlatArea"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjPlatArea"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjPlatArea"); }
        }
        //====================================================================
        public static DTO.ProjPlatAreaDTO Get(decimal ID)
        {
            ProjPlatAreaDTO entity = new ProjPlatAreaDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["PLATAFORMA"] != null) && (dt.Rows[0]["PLATAFORMA"] != DBNull.Value)) entity.Plataforma = Convert.ToString(dt.Rows[0]["PLATAFORMA"]);
            if ((dt.Rows[0]["MODULO"] != null) && (dt.Rows[0]["MODULO"] != DBNull.Value)) entity.Modulo = Convert.ToString(dt.Rows[0]["MODULO"]);
            if ((dt.Rows[0]["BLOCO"] != null) && (dt.Rows[0]["BLOCO"] != DBNull.Value)) entity.Bloco = Convert.ToString(dt.Rows[0]["BLOCO"]);
            if ((dt.Rows[0]["ARAP_SIGLA"] != null) && (dt.Rows[0]["ARAP_SIGLA"] != DBNull.Value)) entity.ArapSigla = Convert.ToString(dt.Rows[0]["ARAP_SIGLA"]);
            if ((dt.Rows[0]["ARAP_ID"] != null) && (dt.Rows[0]["ARAP_ID"] != DBNull.Value)) entity.ArapId = Convert.ToDecimal(dt.Rows[0]["ARAP_ID"]);
            if ((dt.Rows[0]["ARAP_CNTR_CODIGO"] != null) && (dt.Rows[0]["ARAP_CNTR_CODIGO"] != DBNull.Value)) entity.ArapCntrCodigo = Convert.ToString(dt.Rows[0]["ARAP_CNTR_CODIGO"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjPlatAreaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ARAP_CNTR_CODIGO Object"); }
        }
        //====================================================================
        public static List<ProjPlatAreaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjPlatAreaDTO> list = OracleDataTools.LoadEntity<ProjPlatAreaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjPlatAreaDTO>"); }
        }
        //====================================================================
        public static List<ProjPlatAreaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjPlatAreaDTO>"); }
        }
        //====================================================================
        public static List<ProjPlatAreaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjPlatAreaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjPlatAreaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjPlatArea"); }
        }
        //====================================================================
        public static DTO.CollectionProjPlatAreaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjPlatAreaDTO collection = new DTO.CollectionProjPlatAreaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjPlatAreaDTO entity = new DTO.ProjPlatAreaDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["PLATAFORMA"].ToString().Length != 0) entity.Plataforma = dt.Rows[i]["PLATAFORMA"].ToString();
                    if (dt.Rows[i]["MODULO"].ToString().Length != 0) entity.Modulo = dt.Rows[i]["MODULO"].ToString();
                    if (dt.Rows[i]["BLOCO"].ToString().Length != 0) entity.Bloco = dt.Rows[i]["BLOCO"].ToString();
                    if (dt.Rows[i]["ARAP_SIGLA"].ToString().Length != 0) entity.ArapSigla = dt.Rows[i]["ARAP_SIGLA"].ToString();
                    if (dt.Rows[i]["ARAP_ID"].ToString().Length != 0) entity.ArapId = Convert.ToDecimal(dt.Rows[i]["ARAP_ID"]);
                    if (dt.Rows[i]["ARAP_CNTR_CODIGO"].ToString().Length != 0) entity.ArapCntrCodigo = dt.Rows[i]["ARAP_CNTR_CODIGO"].ToString();

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
            dict.Add("Plataforma", "PLATAFORMA");
            dict.Add("Modulo", "MODULO");
            dict.Add("Bloco", "BLOCO");
            dict.Add("ArapSigla", "ARAP_SIGLA");
            dict.Add("ArapId", "ARAP_ID");
            dict.Add("ArapCntrCodigo", "ARAP_CNTR_CODIGO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
