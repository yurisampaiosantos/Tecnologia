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
    public class AcStatusTubDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT  X.TSTF_ID, X.TSTF_DISC_ID, X.TSTF_SBCN_SIGLA, X.TSTF_FCME_SIGLA, X.TSTF_SEQUENCE, X.TSTF_ACTIVE, X.TSTF_UNIDADE_REGIONAL,  
                                            X.TSTF_SPOOLS_PREV_PC, X.TSTF_SPOOLS_PREV_PESO, 
                                            X.TSTF_SPOOLS_SISEPC_PC, X.TSTF_SPOOLS_SISEPC_PESO, 
                                            X.TSTF_SPOOLS_ALIBERAR_PC, X.TSTF_SPOOLS_ALIBERAR_PESO, 
                                            X.TSTF_SPOOLS_PROGRAMADOS_PC, X.TSTF_SPOOLS_PROGRAMADOS_PESO, 
                                            X.TSTF_SPOOLS_AVANCADOS_PC, X.TSTF_SPOOLS_AVANCADOS_PESO, 
                                            X.TSTF_SPOOLS_APROGRAMAR_PC, X.TSTF_SPOOLS_APROGRAMAR_PESO, 
                                            X.TSTF_SPOOLS_AAVANCAR_PC, X.TSTF_SPOOLS_AAVANCAR_PESO, 
                                            X.TSTF_SPOOLS_OFICINA_PC, X.TSTF_SPOOLS_OFICINA_PESO,
                                            TO_CHAR(X.TSTF_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS TSTF_CREATED_DATE 
                                      FROM  EEP_CONVERSION.AC_STATUS_TUB X ";
        //====================================================================
        public static int Insert(DTO.AcStatusTubDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_STATUS_TUB(TSTF_DISC_ID, TSTF_SBCN_SIGLA, TSTF_FCME_SIGLA, TSTF_SPOOLS_PREV_PC, TSTF_SPOOLS_PREV_PESO, TSTF_UNIDADE_REGIONAL, TSTF_SPOOLS_SISEPC_PC, TSTF_SPOOLS_SISEPC_PESO, TSTF_SPOOLS_ALIBERAR_PC, TSTF_SPOOLS_ALIBERAR_PESO, TSTF_SPOOLS_PROGRAMADOS_PC, TSTF_SPOOLS_PROGRAMADOS_PESO, TSTF_SPOOLS_AVANCADOS_PC, TSTF_SPOOLS_AVANCADOS_PESO, TSTF_SPOOLS_APROGRAMAR_PC, TSTF_SPOOLS_APROGRAMAR_PESO, TSTF_SPOOLS_AAVANCAR_PC, TSTF_SPOOLS_AAVANCAR_PESO, TSTF_SPOOLS_OFICINA_PC, TSTF_SPOOLS_OFICINA_PESO) VALUES(:TSTF_DISC_ID,:TSTF_SBCN_SIGLA,:TSTF_FCME_SIGLA, :TSTF_UNIDADE_REGIONAL ,:TSTF_SPOOLS_PREV_PC ,:TSTF_SPOOLS_PREV_PESO ,:TSTF_SPOOLS_SISEPC_PC ,:TSTF_SPOOLS_SISEPC_PESO ,:TSTF_SPOOLS_ALIBERAR_PC ,:TSTF_SPOOLS_ALIBERAR_PESO ,:TSTF_SPOOLS_PROGRAMADOS_PC ,:TSTF_SPOOLS_PROGRAMADOS_PESO ,:TSTF_SPOOLS_AVANCADOS_PC ,:TSTF_SPOOLS_AVANCADOS_PESO ,:TSTF_SPOOLS_APROGRAMAR_PC ,:TSTF_SPOOLS_APROGRAMAR_PESO ,:TSTF_SPOOLS_AAVANCAR_PC ,:TSTF_SPOOLS_AAVANCAR_PESO ,:TSTF_SPOOLS_OFICINA_PC ,:TSTF_SPOOLS_OFICINA_PESO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TSTF_DISC_ID", OracleDbType.Double).Value = entity.TstfDiscId;
                cmd.Parameters.Add(":TSTF_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.TstfSbcnSigla;
                cmd.Parameters.Add(":TSTF_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.TstfFcmeSigla;
                cmd.Parameters.Add(":TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.TstfUnidadeRegional;
                cmd.Parameters.Add(":TSTF_SPOOLS_PREV_PC", OracleDbType.Double).Value = entity.TstfSpoolsPrevPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_PREV_PESO", OracleDbType.Double).Value = entity.TstfSpoolsPrevPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_SISEPC_PC", OracleDbType.Double).Value = entity.TstfSpoolsSisepcPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_SISEPC_PESO", OracleDbType.Double).Value = entity.TstfSpoolsSisepcPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_ALIBERAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAliberarPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_ALIBERAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAliberarPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_PROGRAMADOS_PC", OracleDbType.Double).Value = entity.TstfSpoolsProgramadosPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_PROGRAMADOS_PESO", OracleDbType.Double).Value = entity.TstfSpoolsProgramadosPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_AVANCADOS_PC", OracleDbType.Double).Value = entity.TstfSpoolsAvancadosPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_AVANCADOS_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAvancadosPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_APROGRAMAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAprogramarPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_APROGRAMAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAprogramarPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_AAVANCAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAAvancarPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_AAVANCAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAAvancarPeso;
                cmd.Parameters.Add(":TSTF_SPOOLS_OFICINA_PC", OracleDbType.Double).Value = entity.TstfSpoolsOficinaPc;
                cmd.Parameters.Add(":TSTF_SPOOLS_OFICINA_PESO", OracleDbType.Double).Value = entity.TstfSpoolsOficinaPeso;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcStatusTub");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcStatusTub");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcStatusTubDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_STATUS_TUB set TSTF_DISC_ID = :TSTF_DISC_ID, TSTF_SBCN_SIGLA = :TSTF_SBCN_SIGLA, TSTF_FCME_SIGLA = :TSTF_FCME_SIGLA, TSTF_UNIDADE_REGIONAL = :TSTF_UNIDADE_REGIONAL, TSTF_SPOOLS_PREV_PC = :TSTF_SPOOLS_PREV_PC, TSTF_SPOOLS_PREV_PESO = :TSTF_SPOOLS_PREV_PESO, TSTF_SPOOLS_SISEPC_PC = :TSTF_SPOOLS_SISEPC_PC, TSTF_SPOOLS_SISEPC_PESO = :TSTF_SPOOLS_SISEPC_PESO, TSTF_SPOOLS_ALIBERAR_PC = :TSTF_SPOOLS_ALIBERAR_PC, TSTF_SPOOLS_ALIBERAR_PESO = :TSTF_SPOOLS_ALIBERAR_PESO, TSTF_SPOOLS_PROGRAMADOS_PC = :TSTF_SPOOLS_PROGRAMADOS_PC, TSTF_SPOOLS_PROGRAMADOS_PESO = :TSTF_SPOOLS_PROGRAMADOS_PESO, TSTF_SPOOLS_AVANCADOS_PC = :TSTF_SPOOLS_AVANCADOS_PC, TSTF_SPOOLS_AVANCADOS_PESO = :TSTF_SPOOLS_AVANCADOS_PESO, TSTF_SPOOLS_APROGRAMAR_PC = :TSTF_SPOOLS_APROGRAMAR_PC, TSTF_SPOOLS_APROGRAMAR_PESO = :TSTF_SPOOLS_APROGRAMAR_PESO, TSTF_SPOOLS_AAVANCAR_PC = :TSTF_SPOOLS_AAVANCAR_PC, TSTF_SPOOLS_AAVANCAR_PESO = :TSTF_SPOOLS_AAVANCAR_PESO, TSTF_SPOOLS_OFICINA_PC = :TSTF_SPOOLS_OFICINA_PC, TSTF_SPOOLS_OFICINA_PESO = :TSTF_SPOOLS_OFICINA_PESO, TSTF_SEQUENCE = :TSTF_SEQUENCE, TSTF_ACTIVE = :TSTF_ACTIVE WHERE  TSTF_ID = : TSTF_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("TSTF_DISC_ID", OracleDbType.Double).Value = entity.TstfDiscId;
                cmd.Parameters.Add("TSTF_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.TstfSbcnSigla;
                cmd.Parameters.Add("TSTF_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.TstfFcmeSigla;
                cmd.Parameters.Add("TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.TstfUnidadeRegional;
                cmd.Parameters.Add("TSTF_SPOOLS_PREV_PC", OracleDbType.Double).Value = entity.TstfSpoolsPrevPc;
                cmd.Parameters.Add("TSTF_SPOOLS_PREV_PESO", OracleDbType.Double).Value = entity.TstfSpoolsPrevPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_SISEPC_PC", OracleDbType.Double).Value = entity.TstfSpoolsSisepcPc;
                cmd.Parameters.Add("TSTF_SPOOLS_SISEPC_PESO", OracleDbType.Double).Value = entity.TstfSpoolsSisepcPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_ALIBERAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAliberarPc;
                cmd.Parameters.Add("TSTF_SPOOLS_ALIBERAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAliberarPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_PROGRAMADOS_PC", OracleDbType.Double).Value = entity.TstfSpoolsProgramadosPc;
                cmd.Parameters.Add("TSTF_SPOOLS_PROGRAMADOS_PESO", OracleDbType.Double).Value = entity.TstfSpoolsProgramadosPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_AVANCADOS_PC", OracleDbType.Double).Value = entity.TstfSpoolsAvancadosPc;
                cmd.Parameters.Add("TSTF_SPOOLS_AVANCADOS_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAvancadosPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_APROGRAMAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAprogramarPc;
                cmd.Parameters.Add("TSTF_SPOOLS_APROGRAMAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAprogramarPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_AAVANCAR_PC", OracleDbType.Double).Value = entity.TstfSpoolsAAvancarPc;
                cmd.Parameters.Add("TSTF_SPOOLS_AAVANCAR_PESO", OracleDbType.Double).Value = entity.TstfSpoolsAAvancarPeso;
                cmd.Parameters.Add("TSTF_SPOOLS_OFICINA_PC", OracleDbType.Double).Value = entity.TstfSpoolsOficinaPc;
                cmd.Parameters.Add("TSTF_SPOOLS_OFICINA_PESO", OracleDbType.Double).Value = entity.TstfSpoolsOficinaPeso;
                cmd.Parameters.Add("TSTF_SEQUENCE", OracleDbType.Double).Value = entity.TstfSequence;
                cmd.Parameters.Add("TSTF_ACTIVE", OracleDbType.Double).Value = entity.TstfActive;

                cmd.Parameters.Add("TSTF_ID", OracleDbType.Double).Value = entity.TstfId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcStatusTub"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(double TstfId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_STATUS_TUB WHERE  TSTF_ID = : TSTF_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TstfId", OracleDbType.Double).Value = TstfId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcStatusTub"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusTub"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_STATUS_TUB";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusTub"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusTub"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusTub"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcStatusTub"); }
        }
        //====================================================================
        public static DTO.AcStatusTubDTO Get(decimal TstfId)
        {
            AcStatusTubDTO entity = new AcStatusTubDTO();
            DataTable dt = null;
            string filter = "TSTF_ID = " + TstfId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["TSTF_ID"] != null) && (dt.Rows[0]["TSTF_ID"] != DBNull.Value)) entity.TstfId = Convert.ToDouble(dt.Rows[0]["TSTF_ID"]);
            if ((dt.Rows[0]["TSTF_DISC_ID"] != null) && (dt.Rows[0]["TSTF_DISC_ID"] != DBNull.Value)) entity.TstfDiscId = Convert.ToDouble(dt.Rows[0]["TSTF_DISC_ID"]);
            if ((dt.Rows[0]["TSTF_SBCN_SIGLA"] != null) && (dt.Rows[0]["TSTF_SBCN_SIGLA"] != DBNull.Value)) entity.TstfSbcnSigla = Convert.ToString(dt.Rows[0]["TSTF_SBCN_SIGLA"]);
            if ((dt.Rows[0]["TSTF_FCME_SIGLA"] != null) && (dt.Rows[0]["TSTF_FCME_SIGLA"] != DBNull.Value)) entity.TstfFcmeSigla = Convert.ToString(dt.Rows[0]["TSTF_FCME_SIGLA"]);
            if ((dt.Rows[0]["TSTF_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["TSTF_UNIDADE_REGIONAL"] != DBNull.Value)) entity.TstfUnidadeRegional = Convert.ToString(dt.Rows[0]["TSTF_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_PREV_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_PREV_PC"] != DBNull.Value)) entity.TstfSpoolsPrevPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_PREV_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_PREV_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_PREV_PESO"] != DBNull.Value)) entity.TstfSpoolsPrevPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_PREV_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_SISEPC_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_SISEPC_PC"] != DBNull.Value)) entity.TstfSpoolsSisepcPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_SISEPC_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_SISEPC_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_SISEPC_PESO"] != DBNull.Value)) entity.TstfSpoolsSisepcPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_SISEPC_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PC"] != DBNull.Value)) entity.TstfSpoolsAliberarPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PESO"] != DBNull.Value)) entity.TstfSpoolsAliberarPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_ALIBERAR_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PC"] != DBNull.Value)) entity.TstfSpoolsProgramadosPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PESO"] != DBNull.Value)) entity.TstfSpoolsProgramadosPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_PROGRAMADOS_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PC"] != DBNull.Value)) entity.TstfSpoolsAvancadosPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PESO"] != DBNull.Value)) entity.TstfSpoolsAvancadosPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_AVANCADOS_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PC"] != DBNull.Value)) entity.TstfSpoolsAprogramarPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PESO"] != DBNull.Value)) entity.TstfSpoolsAprogramarPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_APROGRAMAR_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PC"] != DBNull.Value)) entity.TstfSpoolsAAvancarPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PESO"] != DBNull.Value)) entity.TstfSpoolsAAvancarPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_AAVANCAR_PESO"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_OFICINAPC"] != null) && (dt.Rows[0]["TSTF_SPOOLS_OFICINA_PC"] != DBNull.Value)) entity.TstfSpoolsOficinaPc = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_OFICINA_PC"]);
            if ((dt.Rows[0]["TSTF_SPOOLS_OFICINA_PESO"] != null) && (dt.Rows[0]["TSTF_SPOOLS_OFICINA_PESO"] != DBNull.Value)) entity.TstfSpoolsOficinaPeso = Convert.ToDouble(dt.Rows[0]["TSTF_SPOOLS_OFICINA_PESO"]);
            if ((dt.Rows[0]["TSTF_CREATED_DATE"] != null) && (dt.Rows[0]["TSTF_CREATED_DATE"] != DBNull.Value)) entity.TstfCreatedDate = Convert.ToDateTime(dt.Rows[0]["TSTF_CREATED_DATE"]);
            if ((dt.Rows[0]["TSTF_SEQUENCE"] != null) && (dt.Rows[0]["TSTF_SEQUENCE"] != DBNull.Value)) entity.TstfSequence = Convert.ToDouble(dt.Rows[0]["TSTF_SEQUENCE"]);
            if ((dt.Rows[0]["TSTF_ACTIVE"] != null) && (dt.Rows[0]["TSTF_ACTIVE"] != DBNull.Value)) entity.TstfActive = Convert.ToDouble(dt.Rows[0]["TSTF_ACTIVE"]);

            return entity;
        }
        //====================================================================
        public static DTO.AcStatusTubDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting TSTF_CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcStatusTubDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcStatusTubDTO> list = OracleDataTools.LoadEntity<AcStatusTubDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusTubDTO>"); }
        }
        //====================================================================
        public static List<AcStatusTubDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusTubDTO>"); }
        }
        //====================================================================
        public static List<AcStatusTubDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusTubDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusTubDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcStatusTub"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusTubDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcStatusTubDTO collection = new DTO.CollectionAcStatusTubDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcStatusTubDTO entity = new DTO.AcStatusTubDTO();
                    if (dt.Rows[i]["TSTF_ID"].ToString().Length != 0) entity.TstfId = Convert.ToDouble(dt.Rows[i]["TSTF_ID"]);
                    if (dt.Rows[i]["TSTF_DISC_ID"].ToString().Length != 0) entity.TstfDiscId = Convert.ToDouble(dt.Rows[i]["TSTF_DISC_ID"]);
                    if (dt.Rows[i]["TSTF_SBCN_SIGLA"].ToString().Length != 0) entity.TstfSbcnSigla = dt.Rows[i]["TSTF_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["TSTF_FCME_SIGLA"].ToString().Length != 0) entity.TstfFcmeSigla = dt.Rows[i]["TSTF_FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.TstfUnidadeRegional = dt.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["TSTF_SPOOLS_PREV_PC"].ToString().Length != 0) entity.TstfSpoolsPrevPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_PREV_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_PREV_PESO"].ToString().Length != 0) entity.TstfSpoolsPrevPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_PREV_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_SISEPC_PC"].ToString().Length != 0) entity.TstfSpoolsSisepcPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_SISEPC_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_SISEPC_PESO"].ToString().Length != 0) entity.TstfSpoolsSisepcPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_SISEPC_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_ALIBERAR_PC"].ToString().Length != 0) entity.TstfSpoolsAliberarPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_ALIBERAR_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_ALIBERAR_PESO"].ToString().Length != 0) entity.TstfSpoolsAliberarPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_ALIBERAR_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PC"].ToString().Length != 0) entity.TstfSpoolsProgramadosPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PESO"].ToString().Length != 0) entity.TstfSpoolsProgramadosPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_PROGRAMADOS_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_AVANCADOS_PC"].ToString().Length != 0) entity.TstfSpoolsAvancadosPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_AVANCADOS_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"].ToString().Length != 0) entity.TstfSpoolsAvancadosPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_AVANCADOS_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_APROGRAMAR_PC"].ToString().Length != 0) entity.TstfSpoolsAprogramarPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_APROGRAMAR_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_APROGRAMAR_PESO"].ToString().Length != 0) entity.TstfSpoolsAprogramarPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_APROGRAMAR_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_AAVANCAR_PC"].ToString().Length != 0) entity.TstfSpoolsAAvancarPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_AAVANCAR_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_AAVANCAR_PESO"].ToString().Length != 0) entity.TstfSpoolsAAvancarPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_AAVANCAR_PESO"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_OFICINA_PC"].ToString().Length != 0) entity.TstfSpoolsOficinaPc = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_OFICINA_PC"]);
                    if (dt.Rows[i]["TSTF_SPOOLS_OFICINA_PESO"].ToString().Length != 0) entity.TstfSpoolsOficinaPeso = Convert.ToDouble(dt.Rows[i]["TSTF_SPOOLS_OFICINA_PESO"]);
                    if (dt.Rows[i]["TSTF_CREATED_DATE"].ToString().Length != 0) entity.TstfCreatedDate = Convert.ToDateTime(dt.Rows[i]["TSTF_CREATED_DATE"]);
                    if (dt.Rows[i]["TSTF_SEQUENCE"].ToString().Length != 0) entity.TstfSequence = Convert.ToDouble(dt.Rows[i]["TSTF_SEQUENCE"]);
                    if (dt.Rows[i]["TSTF_ACTIVE"].ToString().Length != 0) entity.TstfActive = Convert.ToDouble(dt.Rows[i]["TSTF_ACTIVE"]);

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
            dict.Add("TstfId", "TSTF_ID");
            dict.Add("TstfDiscId", "TSTF_DISC_ID");
            dict.Add("TstfSbcnSigla", "TSTF_SBCN_SIGLA");
            dict.Add("TstfFcmeSigla", "TSTF_FCME_SIGLA");
            dict.Add("TstfUnidadeRegional", "TSTF_UNIDADE_REGIONAL");
            dict.Add("TstfSequence", "TSTF_SEQUENCE");
            dict.Add("TstfSpoolsPrevPc", "TSTF_SPOOLS_PREV_PC");
            dict.Add("TstfSpoolsPrevPeso", "TSTF_SPOOLS_PREV_PESO");
            dict.Add("TstfSpoolsSisepcPc", "TSTF_SPOOLS_SISEPC_PC");
            dict.Add("TstfSpoolsSisepcPeso", "TSTF_SPOOLS_SISEPC_PESO");
            dict.Add("TstfSpoolsAliberarPc", "TSTF_SPOOLS_ALIBERAR_PC");
            dict.Add("TstfSpoolsAliberarPeso", "TSTF_SPOOLS_ALIBERAR_PESO");
            dict.Add("TstfSpoolsProgramadosPc", "TSTF_SPOOLS_PROGRAMADOS_PC");
            dict.Add("TstfSpoolsProgramadosPeso", "TSTF_SPOOLS_PROGRAMADOS_PESO");
            dict.Add("TstfSpoolsAvancadosPc", "TSTF_SPOOLS_AVANCADOS_PC");
            dict.Add("TstfSpoolsAvancadosPeso", "TSTF_SPOOLS_AVANCADOS_PESO");
            dict.Add("TstfSpoolsAprogramarPc", "TSTF_SPOOLS_APROGRAMAR_PC");
            dict.Add("TstfSpoolsAprogramarPeso", "TSTF_SPOOLS_APROGRAMAR_PESO");
            dict.Add("TstfSpoolsAAvancarPc", "TSTF_SPOOLS_AAVANCAR_PC");
            dict.Add("TstfSpoolsAAvancarPeso", "TSTF_SPOOLS_AAVANCAR_PESO");
            dict.Add("TstfSpoolsOficinaPc", "TSTF_SPOOLS_OFICINA_PC");
            dict.Add("TstfSpoolsOficinaPeso", "TSTF_SPOOLS_OFICINA_PESO");
            dict.Add("TstfCreatedDate", "TSTF_CREATED_DATE");
            dict.Add("TstfSequence", "TSTF_SEQUENCE");
            dict.Add("TstfActive", "TSTF_ACTIVE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
