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
    public class AcSemanaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.SEMA_CNTR_CODIGO, X.SEMA_ID, X.SEMA_DATA_INICIO, X.SEMA_DATA_FIM, X.SEMA_MES_COMPETENCIA FROM EEP_CONVERSION.AC_SEMANA X ";
        //====================================================================
        public static int Insert(DTO.AcSemanaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_SEMANA(SEMA_ID,SEMA_DATA_INICIO,SEMA_DATA_FIM,SEMA_MES_COMPETENCIA) VALUES(?,:SEMA_ID,:SEMA_DATA_INICIO,:SEMA_DATA_FIM,:SEMA_MES_COMPETENCIA)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Int32).Value = entity.SemaId;
                if (entity.SemaDataInicio.ToOADate() == 0.0) cmd.Parameters.Add(":SEMA_DATA_INICIO", OracleDbType.Date).Value = entity.SemaDataInicio;
                else  cmd.Parameters.Add(":SEMA_DATA_INICIO", OracleDbType.Date).Value = entity.SemaDataInicio;
                if (entity.SemaDataFim.ToOADate() == 0.0) cmd.Parameters.Add(":SEMA_DATA_FIM", OracleDbType.Date).Value = entity.SemaDataFim;
                else  cmd.Parameters.Add(":SEMA_DATA_FIM", OracleDbType.Date).Value = entity.SemaDataFim;
                cmd.Parameters.Add(":SEMA_MES_COMPETENCIA", OracleDbType.Int32).Value = entity.SemaMesCompetencia;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcSemana");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcSemana");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcSemanaDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_SEMANA set SEMA_DATA_INICIO = :SEMA_DATA_INICIO, SEMA_DATA_FIM = :SEMA_DATA_FIM, SEMA_MES_COMPETENCIA = :SEMA_MES_COMPETENCIA WHERE  SEMA_CNTR_CODIGO = ?, SEMA_ID = : SEMA_CNTR_CODIGO = ?, SEMA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("SEMA_ID", OracleDbType.Int32).Value = entity.SemaId;
                if (entity.SemaDataInicio.ToOADate() == 0.0) cmd.Parameters.Add("SEMA_DATA_INICIO", OracleDbType.Date).Value = entity.SemaDataInicio;
                else cmd.Parameters.Add("SEMA_DATA_INICIO", OracleDbType.Date).Value = entity.SemaDataInicio;
                if (entity.SemaDataFim.ToOADate() == 0.0) cmd.Parameters.Add("SEMA_DATA_FIM", OracleDbType.Date).Value = entity.SemaDataFim;
                else cmd.Parameters.Add("SEMA_DATA_FIM", OracleDbType.Date).Value = entity.SemaDataFim;
                cmd.Parameters.Add("SEMA_MES_COMPETENCIA", OracleDbType.Int32).Value = entity.SemaMesCompetencia;
                cmd.Parameters.Add("SEMA_MES_COMPETENCIA", OracleDbType.Varchar2).Value = entity.SemaMesCompetencia;
                cmd.Parameters.Add("SEMA_MES_COMPETENCIA", OracleDbType.Int32).Value = entity.SemaMesCompetencia;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcSemana"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(string SemaCntrCodigo, decimal SemaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_SEMANA WHERE  SEMA_CNTR_CODIGO = ?, SEMA_ID = : SEMA_CNTR_CODIGO = ?, SEMA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SemaCntrCodigo", OracleDbType.Varchar2).Value = SemaCntrCodigo;
                cmd.Parameters.Add(":SemaId", OracleDbType.Varchar2).Value = SemaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcSemana"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSemana"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_SEMANA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSemana"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSemana"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSemana"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static string GetSemanaByFoseStatus(string foseStatus)
        {
            string semana = "";
            string[] status;
            if (foseStatus.IndexOf("Semana") == 0)
            {
                status = foseStatus.Split(' ');
                semana = status[1];
            }
            return semana;
        }
        //====================================================================
        public static DTO.AcSemanaDTO GetSemanaAnteriorCorrente()
        {
            //Calcula a semana ANTERIOR à semana corrente
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = GetSemanaCorrente();
            string strSQL = "SELECT MAX(X.SEMA_ID) FROM EEP_CONVERSION.AC_SEMANA X WHERE SEMA_ID < " + s.SemaId.ToString();
            DataTable dtSemanaAnterior = Select(strSQL);
            s = GetObject("SEMA_ID = " + (dtSemanaAnterior.Rows[0][0]).ToString(), "SEMA_ID");
            return s;
        }
        //====================================================================
        public static DTO.AcSemanaDTO GetSemanaCorrente()
        {
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = GetObject("TO_DATE(SYSDATE,'DD/MM/YY') BETWEEN TO_DATE(X.SEMA_DATA_INICIO,'DD/MM/YY') AND TO_DATE(X.SEMA_DATA_FIM,'DD/MM/YY')", "SEMA_ID");
            return s;
        }
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcSemana"); }
        }
        //====================================================================
        public static DTO.AcSemanaDTO Get(string SemaCntrCodigo, decimal SemaId)
        {
            AcSemanaDTO entity = new AcSemanaDTO();
            DataTable dt = null;
            string filter = "SEMA_CNTR_CODIGO = '" + SemaCntrCodigo + "' and SEMA_ID = " + SemaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SEMA_CNTR_CODIGO"] != null) && (dt.Rows[0]["SEMA_CNTR_CODIGO"] != DBNull.Value)) entity.SemaCntrCodigo = Convert.ToString(dt.Rows[0]["SEMA_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            if ((dt.Rows[0]["SEMA_DATA_INICIO"] != null) && (dt.Rows[0]["SEMA_DATA_INICIO"] != DBNull.Value)) entity.SemaDataInicio = Convert.ToDateTime(dt.Rows[0]["SEMA_DATA_INICIO"]);
            if ((dt.Rows[0]["SEMA_DATA_FIM"] != null) && (dt.Rows[0]["SEMA_DATA_FIM"] != DBNull.Value)) entity.SemaDataFim = Convert.ToDateTime(dt.Rows[0]["SEMA_DATA_FIM"]);
            if ((dt.Rows[0]["SEMA_MES_COMPETENCIA"] != null) && (dt.Rows[0]["SEMA_MES_COMPETENCIA"] != DBNull.Value)) entity.SemaMesCompetencia = Convert.ToString(dt.Rows[0]["SEMA_MES_COMPETENCIA"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcSemanaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SEMA_MES_COMPETENCIA Object"); }
        }
        //====================================================================
        public static List<AcSemanaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcSemanaDTO> list = OracleDataTools.LoadEntity<AcSemanaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSemanaDTO>"); }
        }
        //====================================================================
        public static List<AcSemanaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSemanaDTO>"); }
        }
        //====================================================================
        public static List<AcSemanaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSemanaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcSemanaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcSemana"); }
        }
        //====================================================================
        public static DTO.CollectionAcSemanaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcSemanaDTO collection = new DTO.CollectionAcSemanaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcSemanaDTO entity = new DTO.AcSemanaDTO();
                    if (dt.Rows[i]["SEMA_CNTR_CODIGO"].ToString().Length != 0) entity.SemaCntrCodigo = dt.Rows[i]["SEMA_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                    if (dt.Rows[i]["SEMA_DATA_INICIO"].ToString().Length != 0) entity.SemaDataInicio = Convert.ToDateTime(dt.Rows[i]["SEMA_DATA_INICIO"]);
                    if (dt.Rows[i]["SEMA_DATA_FIM"].ToString().Length != 0) entity.SemaDataFim = Convert.ToDateTime(dt.Rows[i]["SEMA_DATA_FIM"]);
                    if (dt.Rows[i]["SEMA_MES_COMPETENCIA"].ToString().Length != 0) entity.SemaMesCompetencia = Convert.ToString(dt.Rows[i]["SEMA_MES_COMPETENCIA"]);

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
            dict.Add("SemaCntrCodigo", "SEMA_CNTR_CODIGO");
            dict.Add("SemaId", "SEMA_ID");
            dict.Add("SemaDataInicio", "SEMA_DATA_INICIO");
            dict.Add("SemaDataFim", "SEMA_DATA_FIM");
            dict.Add("SemaMesCompetencia", "SEMA_MES_COMPETENCIA");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
