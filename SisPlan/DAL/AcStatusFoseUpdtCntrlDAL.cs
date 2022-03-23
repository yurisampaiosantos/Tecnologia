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
    public class AcStatusFoseUpdtCntrlDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.SFUC_ID, X.SFUC_CNTR_CODIGO, X.SFUC_DISC_ID, X.SFUC_SBCN_SIGLA, X.SFUC_FCME_SIGLA, X.SFUC_DATA_CORTE_UPDATE_CONTROL FROM EEP_CONVERSION.AC_STATUS_FOSE_UPDT_CNTRL X ";
        //====================================================================
        public static int Insert(DTO.AcStatusFoseUpdtCntrlDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_STATUS_FOSE_UPDT_CNTRL(SFUC_CNTR_CODIGO, SFUC_DISC_ID, SFUC_SBCN_SIGLA, SFUC_FCME_SIGLA, SFUC_DATA_CORTE_UPDATE_CONTROL) VALUES(:SFUC_CNTR_CODIGO, :SFUC_DISC_ID, :SFUC_SBCN_SIGLA, :SFUC_FCME_SIGLA, :SFUC_DATA_CORTE_UPDATE_CONTROL)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SFUC_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.SfucCntrCodigo;
                cmd.Parameters.Add(":SFUC_DISC_ID", OracleDbType.Decimal).Value = entity.SfucDiscId;
                cmd.Parameters.Add(":SFUC_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SfucSbcnSigla;
                cmd.Parameters.Add(":SFUC_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.SfucFcmeSigla;
                cmd.Parameters.Add(":SFUC_DATA_CORTE_UPDATE_CONTROL", OracleDbType.Varchar2).Value = entity.SfucDataCorteUpdateControl;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcStatusFoseUpdtCntrl");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcStatusFoseUpdtCntrl");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcStatusFoseUpdtCntrlDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_STATUS_FOSE_UPDT_CNTRL SET SFUC_CNTR_CODIGO = :SFUC_CNTR_CODIGO, SFUC_DISC_ID = :SFUC_DISC_ID, SFUC_SBCN_SIGLA = :SFUC_SBCN_SIGLA, SFUC_FCME_SIGLA = :SFUC_FCME_SIGLA, SFUC_DATA_CORTE_UPDATE_CONTROL = :SFUC_DATA_CORTE_UPDATE_CONTROL WHERE  SFUC_ID = : SFUC_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("SFUC_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.SfucCntrCodigo;
                cmd.Parameters.Add("SFUC_DISC_ID", OracleDbType.Decimal).Value = entity.SfucDiscId;
                cmd.Parameters.Add("SFUC_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SfucSbcnSigla;
                cmd.Parameters.Add("SFUC_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.SfucFcmeSigla;
                cmd.Parameters.Add("SFUC_DATA_CORTE_UPDATE_CONTROL", OracleDbType.Varchar2).Value = entity.SfucDataCorteUpdateControl;
                cmd.Parameters.Add("SFUC_ID", OracleDbType.Decimal).Value = entity.SfucId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcStatusFoseUpdtCntrl"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal SfucId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_STATUS_FOSE_UPDT_CNTRL WHERE  SFUC_ID = : SFUC_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SfucId", OracleDbType.Decimal).Value = SfucId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcStatusFoseUpdtCntrl"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusFoseUpdtCntrl"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_STATUS_FOSE_UPDT_CNTRL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusFoseUpdtCntrl"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusFoseUpdtCntrl"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusFoseUpdtCntrl"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcStatusFoseUpdtCntrl"); }
        }
        //====================================================================
        public static DTO.AcStatusFoseUpdtCntrlDTO Get(decimal SfucId)
        {
            AcStatusFoseUpdtCntrlDTO entity = new AcStatusFoseUpdtCntrlDTO();
            DataTable dt = null;
            string filter = "SFUC_ID = " + SfucId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SFUC_ID"] != null) && (dt.Rows[0]["SFUC_ID"] != DBNull.Value)) entity.SfucId = Convert.ToDecimal(dt.Rows[0]["SFUC_ID"]);
            if ((dt.Rows[0]["SFUC_CNTR_CODIGO"] != null) && (dt.Rows[0]["SFUC_CNTR_CODIGO"] != DBNull.Value)) entity.SfucCntrCodigo = Convert.ToString(dt.Rows[0]["SFUC_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SFUC_DISC_ID"] != null) && (dt.Rows[0]["SFUC_DISC_ID"] != DBNull.Value)) entity.SfucDiscId = Convert.ToDecimal(dt.Rows[0]["SFUC_DISC_ID"]);
            if ((dt.Rows[0]["SFUC_SBCN_SIGLA"] != null) && (dt.Rows[0]["SFUC_SBCN_SIGLA"] != DBNull.Value)) entity.SfucSbcnSigla = Convert.ToString(dt.Rows[0]["SFUC_SBCN_SIGLA"]);
            if ((dt.Rows[0]["SFUC_FCME_SIGLA"] != null) && (dt.Rows[0]["SFUC_FCME_SIGLA"] != DBNull.Value)) entity.SfucFcmeSigla = Convert.ToString(dt.Rows[0]["SFUC_FCME_SIGLA"]);
            if ((dt.Rows[0]["SFUC_DATA_CORTE_UPDATE_CONTROL"] != null) && (dt.Rows[0]["SFUC_DATA_CORTE_UPDATE_CONTROL"] != DBNull.Value)) entity.SfucDataCorteUpdateControl = dt.Rows[0]["SFUC_DATA_CORTE_UPDATE_CONTROL"].ToString();
            return entity;
        }
        //====================================================================
        public static DTO.AcStatusFoseUpdtCntrlDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SFUC_DATA_CORTE_UPDATE_CONTROL Object"); }
        }
        //====================================================================
        public static List<AcStatusFoseUpdtCntrlDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcStatusFoseUpdtCntrlDTO> list = OracleDataTools.LoadEntity<AcStatusFoseUpdtCntrlDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusFoseUpdtCntrlDTO>"); }
        }
        //====================================================================
        public static List<AcStatusFoseUpdtCntrlDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusFoseUpdtCntrlDTO>"); }
        }
        //====================================================================
        public static List<AcStatusFoseUpdtCntrlDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusFoseUpdtCntrlDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusFoseUpdtCntrlDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcStatusFoseUpdtCntrl"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusFoseUpdtCntrlDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcStatusFoseUpdtCntrlDTO collection = new DTO.CollectionAcStatusFoseUpdtCntrlDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcStatusFoseUpdtCntrlDTO entity = new DTO.AcStatusFoseUpdtCntrlDTO();
                    if (dt.Rows[i]["SFUC_ID"].ToString().Length != 0) entity.SfucId = Convert.ToDecimal(dt.Rows[i]["SFUC_ID"]);
                    if (dt.Rows[i]["SFUC_CNTR_CODIGO"].ToString().Length != 0) entity.SfucCntrCodigo = dt.Rows[i]["SFUC_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SFUC_DISC_ID"].ToString().Length != 0) entity.SfucDiscId = Convert.ToDecimal(dt.Rows[i]["SFUC_DISC_ID"]);
                    if (dt.Rows[i]["SFUC_SBCN_SIGLA"].ToString().Length != 0) entity.SfucSbcnSigla = dt.Rows[i]["SFUC_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["SFUC_FCME_SIGLA"].ToString().Length != 0) entity.SfucFcmeSigla = dt.Rows[i]["SFUC_FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["SFUC_DATA_CORTE_UPDATE_CONTROL"].ToString().Length != 0) entity.SfucDataCorteUpdateControl = dt.Rows[i]["SFUC_DATA_CORTE_UPDATE_CONTROL"].ToString();

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
            dict.Add("SfucId", "SFUC_ID");
            dict.Add("SfucCntrCodigo", "SFUC_CNTR_CODIGO");
            dict.Add("SfucDiscId", "SFUC_DISC_ID");
            dict.Add("SfucSbcnSigla", "SFUC_SBCN_SIGLA");
            dict.Add("SfucFcmeSigla", "SFUC_FCME_SIGLA");
            dict.Add("SfucDataCorteUpdateControl", "SFUC_DATA_CORTE_UPDATE_CONTROL");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
