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
    public class CpAreaRespPendenciaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ARPE_CNTR_CODIGO, X.ARPE_ID, X.ARPE_DESCRICAO, X.ARPE_EMAIL_AGENTE, X.ARPE_EMAIL_LEADER FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA X ";
        //====================================================================
        public static int Insert(DTO.CpAreaRespPendenciaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_AREA_RESP_PENDENCIA(ARPE_ID,ARPE_DESCRICAO,ARPE_EMAIL_AGENTE,ARPE_EMAIL_LEADER) VALUES(?,:ARPE_ID,:ARPE_DESCRICAO,:ARPE_EMAIL_AGENTE,:ARPE_EMAIL_LEADER)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ARPE_ID", OracleDbType.Decimal).Value = entity.ArpeId;
                cmd.Parameters.Add(":ARPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.ArpeDescricao;
                cmd.Parameters.Add(":ARPE_EMAIL_AGENTE", OracleDbType.Varchar2).Value = entity.ArpeEmailAgente;
                cmd.Parameters.Add(":ARPE_EMAIL_LEADER", OracleDbType.Varchar2).Value = entity.ArpeEmailLeader;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpAreaRespPendencia");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpAreaRespPendencia");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpAreaRespPendenciaDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_AREA_RESP_PENDENCIA set ARPE_CNTR_CODIGO = :ARPE_CNTR_CODIGO, ARPE_DESCRICAO = :ARPE_DESCRICAO, ARPE_EMAIL_AGENTE = :ARPE_EMAIL_AGENTE, ARPE_EMAIL_LEADER = :ARPE_EMAIL_LEADER WHERE  ARPE_ID = :ARPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ARPE_ID", OracleDbType.Decimal).Value = entity.ArpeId;
                cmd.Parameters.Add(":ARPE_DESCRICAO", OracleDbType.Varchar2).Value = entity.ArpeDescricao;
                cmd.Parameters.Add(":ARPE_EMAIL_AGENTE", OracleDbType.Varchar2).Value = entity.ArpeEmailAgente;
                cmd.Parameters.Add(":ARPE_EMAIL_LEADER", OracleDbType.Varchar2).Value = entity.ArpeEmailLeader;
                cmd.Parameters.Add(":ARPE_ID", OracleDbType.Varchar2).Value = entity.ArpeId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpAreaRespPendencia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ArpeId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA WHERE ARPE_ID = :ARPE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ArpeId", OracleDbType.Varchar2).Value = ArpeId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpAreaRespPendencia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpAreaRespPendencia"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpAreaRespPendencia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpAreaRespPendencia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpAreaRespPendencia"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpAreaRespPendencia"); }
        }
        //====================================================================
        public static DTO.CpAreaRespPendenciaDTO Get(decimal ArpeId)
        {
            CpAreaRespPendenciaDTO entity = new CpAreaRespPendenciaDTO();
            DataTable dt = null;
            string filter = "ARPE_ID = " + ArpeId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ARPE_CNTR_CODIGO"] != null) && (dt.Rows[0]["ARPE_CNTR_CODIGO"] != DBNull.Value)) entity.ArpeCntrCodigo = Convert.ToString(dt.Rows[0]["ARPE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["ARPE_ID"] != null) && (dt.Rows[0]["ARPE_ID"] != DBNull.Value)) entity.ArpeId = Convert.ToDecimal(dt.Rows[0]["ARPE_ID"]);
            if ((dt.Rows[0]["ARPE_DESCRICAO"] != null) && (dt.Rows[0]["ARPE_DESCRICAO"] != DBNull.Value)) entity.ArpeDescricao = Convert.ToString(dt.Rows[0]["ARPE_DESCRICAO"]);
            if ((dt.Rows[0]["ARPE_EMAIL_AGENTE"] != null) && (dt.Rows[0]["ARPE_EMAIL_AGENTE"] != DBNull.Value)) entity.ArpeEmailAgente = Convert.ToString(dt.Rows[0]["ARPE_EMAIL_AGENTE"]);
            if ((dt.Rows[0]["ARPE_EMAIL_LEADER"] != null) && (dt.Rows[0]["ARPE_EMAIL_LEADER"] != DBNull.Value)) entity.ArpeEmailLeader = Convert.ToString(dt.Rows[0]["ARPE_EMAIL_LEADER"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpAreaRespPendenciaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ARPE_EMAIL_LEADER Object"); }
        }
        //====================================================================
        public static List<CpAreaRespPendenciaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpAreaRespPendenciaDTO> list = OracleDataTools.LoadEntity<CpAreaRespPendenciaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaRespPendenciaDTO>"); }
        }
        //====================================================================
        public static List<CpAreaRespPendenciaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaRespPendenciaDTO>"); }
        }
        //====================================================================
        public static List<CpAreaRespPendenciaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpAreaRespPendenciaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpAreaRespPendenciaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpAreaRespPendencia"); }
        }
        //====================================================================
        public static DTO.CollectionCpAreaRespPendenciaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpAreaRespPendenciaDTO collection = new DTO.CollectionCpAreaRespPendenciaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpAreaRespPendenciaDTO entity = new DTO.CpAreaRespPendenciaDTO();
                    if (dt.Rows[i]["ARPE_CNTR_CODIGO"].ToString().Length != 0) entity.ArpeCntrCodigo = dt.Rows[i]["ARPE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["ARPE_ID"].ToString().Length != 0) entity.ArpeId = Convert.ToDecimal(dt.Rows[i]["ARPE_ID"]);
                    if (dt.Rows[i]["ARPE_DESCRICAO"].ToString().Length != 0) entity.ArpeDescricao = dt.Rows[i]["ARPE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["ARPE_EMAIL_AGENTE"].ToString().Length != 0) entity.ArpeEmailAgente = dt.Rows[i]["ARPE_EMAIL_AGENTE"].ToString();
                    if (dt.Rows[i]["ARPE_EMAIL_LEADER"].ToString().Length != 0) entity.ArpeEmailLeader = dt.Rows[i]["ARPE_EMAIL_LEADER"].ToString();

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
            dict.Add("ArpeCntrCodigo", "ARPE_CNTR_CODIGO");
            dict.Add("ArpeId", "ARPE_ID");
            dict.Add("ArpeDescricao", "ARPE_DESCRICAO");
            dict.Add("ArpeEmailAgente", "ARPE_EMAIL_AGENTE");
            dict.Add("ArpeEmailLeader", "ARPE_EMAIL_LEADER");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
