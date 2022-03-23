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
    public class AcAvancoBkpDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.AVBK_ID, X.FSME_CNTR_CODIGO, X.FSME_ID, X.FSME_FOSM_ID, TO_CHAR(X.FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS FSME_DATA, X.FSME_DATA_TEXT, X.FSME_AVANCO_ACM, X.FSME_QTD_ACM, X.FSME_SIFS_ID, X.FSME_OBS, TO_CHAR(X.FSME_DT_CADASTRO,'DD/MM/YYYY HH24:MI:SS') AS FSME_DT_CADASTRO, X.FSME_DT_CADASTRO_TEXT, TO_CHAR(X.AVBK_DT_CAPTURA,'DD/MM/YYYY HH24:MI:SS') AS AVBK_DT_CAPTURA, X.AVBK_DT_CAPTURA_TEXT FROM EEP_CONVERSION.AC_AVANCO_BKP X ";
        //====================================================================
        public static int Insert(DTO.AcAvancoBkpDTO entity, bool getIdentity)
        {
            string strSQL = @"INSERT INTO EEP_CONVERSION.AC_AVANCO_BKP(
AVBK_ID, 
FSME_CNTR_CODIGO, 
FSME_ID, 
FSME_FOSM_ID, 
FSME_DATA, 
FSME_DATA_TEXT, 
FSME_AVANCO_ACM, 
FSME_QTD_ACM, 
FSME_SIFS_ID,
FSME_OBS, 
FSME_DT_CADASTRO,
FSME_DT_CADASTRO_TEXT, 
AVBK_DT_CAPTURA, 
AVBK_DT_CAPTURA_TEXT) 
VALUES(
:AVBK_ID, 
:FSME_CNTR_CODIGO, 
:FSME_ID, 
:FSME_FOSM_ID, 
:FSME_DATA, 
:FSME_DATA_TEXT, 
:FSME_AVANCO_ACM, 
:FSME_QTD_ACM, 
:FSME_SIFS_ID, 
:FSME_OBS, 
:FSME_DT_CADASTRO, 
:FSME_DT_CADASTRO_TEXT, 
SYSDATE, 
TO_CHAR(SYSDATE,'DD/MM/YYYY HH24:MI:SS')
)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AVBK_ID", OracleDbType.Decimal).Value = entity.AvbkId;
                cmd.Parameters.Add(":FSME_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FsmeCntrCodigo;
                cmd.Parameters.Add(":FSME_ID", OracleDbType.Decimal).Value = entity.FsmeId;
                cmd.Parameters.Add(":FSME_FOSM_ID", OracleDbType.Decimal).Value = entity.FsmeFosmId;
                if (entity.FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = entity.FsmeData;

                cmd.Parameters.Add(":FSME_DATA_TEXT", OracleDbType.Varchar2).Value = entity.FsmeDataText;
                  
                if (entity.FsmeAvancoAcm != null) cmd.Parameters.Add(":FSME_AVANCO_ACM", OracleDbType.Decimal).Value = Convert.ToString(entity.FsmeAvancoAcm);
                else cmd.Parameters.Add(":FSME_AVANCO_ACM", OracleDbType.Decimal).Value = null;

                if (entity.FsmeQtdAcm != null) cmd.Parameters.Add(":FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.FsmeQtdAcm;
                else cmd.Parameters.Add(":FSME_QTD_ACM", OracleDbType.Decimal).Value = null;

                if (entity.FsmeSifsId != null) cmd.Parameters.Add(":FSME_SIFS_ID", OracleDbType.Decimal).Value = entity.FsmeSifsId;
                else cmd.Parameters.Add(":FSME_SIFS_ID", OracleDbType.Decimal).Value = null;

                if (entity.FsmeObs != null) cmd.Parameters.Add(":FSME_OBS", OracleDbType.Varchar2).Value = entity.FsmeObs;
                else cmd.Parameters.Add(":FSME_OBS", OracleDbType.Varchar2).Value = null;
                
                if (entity.FsmeDtCadastro.ToOADate() == 0.0) cmd.Parameters.Add(":FSME_DT_CADASTRO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSME_DT_CADASTRO", OracleDbType.Date).Value = entity.FsmeDtCadastro;
                
                cmd.Parameters.Add(":FSME_DT_CADASTRO_TEXT", OracleDbType.Varchar2).Value = entity.FsmeDtCadastroText;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcAvancoBkp");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcAvancoBkp");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcAvancoBkpDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_AVANCO_BKP set FSME_CNTR_CODIGO = :FSME_CNTR_CODIGO, FSME_ID = :FSME_ID, FSME_FOSM_ID = :FSME_FOSM_ID, FSME_DATA = :FSME_DATA, FSME_DATA_TEXT = :FSME_DATA_TEXT, FSME_AVANCO_ACM = :FSME_AVANCO_ACM, FSME_QTD_ACM = :FSME_QTD_ACM, FSME_SIFS_ID = :FSME_SIFS_ID, FSME_OBS = :FSME_OBS, FSME_DT_CADASTRO = :FSME_DT_CADASTRO, FSME_DT_CADASTRO_TEXT = :FSME_DT_CADASTRO_TEXT, AVBK_DT_CAPTURA = SYSDATE, AVBK_DT_CAPTURA_TEXT = TO_CHAR(SYSDATE,'DD/MM/YYYY HH24:MI:SS') WHERE  AVBK_ID = : AVBK_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("FSME_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FsmeCntrCodigo;
                cmd.Parameters.Add("FSME_ID", OracleDbType.Decimal).Value = entity.FsmeId;
                cmd.Parameters.Add("FSME_FOSM_ID", OracleDbType.Decimal).Value = entity.FsmeFosmId;
                if (entity.FsmeData.ToOADate() == 0.0) cmd.Parameters.Add("FSME_DATA", OracleDbType.Date).Value = entity.FsmeData;
                else cmd.Parameters.Add("FSME_DATA", OracleDbType.Date).Value = entity.FsmeData;
                cmd.Parameters.Add("FSME_DATA_TEXT", OracleDbType.Varchar2).Value = entity.FsmeDataText;
                cmd.Parameters.Add("FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.FsmeAvancoAcm;
                cmd.Parameters.Add("FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.FsmeQtdAcm;
                cmd.Parameters.Add("FSME_SIFS_ID", OracleDbType.Decimal).Value = entity.FsmeSifsId;

                cmd.Parameters.Add("FSME_OBS", OracleDbType.Varchar2).Value = entity.FsmeObs;
                if (entity.FsmeObs == "") cmd.Parameters.Add("FSME_OBS", OracleDbType.Varchar2).Value = null;
                
                if (entity.FsmeDtCadastro.ToOADate() == 0.0) cmd.Parameters.Add("FSME_DT_CADASTRO", OracleDbType.Date).Value = entity.FsmeDtCadastro;
                else cmd.Parameters.Add("FSME_DT_CADASTRO", OracleDbType.Date).Value = entity.FsmeDtCadastro;
                cmd.Parameters.Add("FSME_DT_CADASTRO_TEXT", OracleDbType.Varchar2).Value = entity.FsmeDtCadastroText;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcAvancoBkp"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal AvbkId)
        {
            string strSQL = "DELETE EEP_CONVERSION.FROM AC_AVANCO_BKP WHERE  AVBK_ID = : AVBK_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AvbkId", OracleDbType.Decimal).Value = AvbkId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcAvancoBkp"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvancoBkp"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_AVANCO_BKP";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvancoBkp"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvancoBkp"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvancoBkp"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcAvancoBkp"); }
        }
        //====================================================================
        public static DTO.AcAvancoBkpDTO Get(decimal AvbkId)
        {
            AcAvancoBkpDTO entity = new AcAvancoBkpDTO();
            DataTable dt = null;
            string filter = "AVBK_ID = " + AvbkId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["AVBK_ID"] != null) && (dt.Rows[0]["AVBK_ID"] != DBNull.Value)) entity.AvbkId = Convert.ToDecimal(dt.Rows[0]["AVBK_ID"]);
            if ((dt.Rows[0]["FSME_CNTR_CODIGO"] != null) && (dt.Rows[0]["FSME_CNTR_CODIGO"] != DBNull.Value)) entity.FsmeCntrCodigo = Convert.ToString(dt.Rows[0]["FSME_CNTR_CODIGO"]);
            if ((dt.Rows[0]["FSME_ID"] != null) && (dt.Rows[0]["FSME_ID"] != DBNull.Value)) entity.FsmeId = Convert.ToDecimal(dt.Rows[0]["FSME_ID"]);
            if ((dt.Rows[0]["FSME_FOSM_ID"] != null) && (dt.Rows[0]["FSME_FOSM_ID"] != DBNull.Value)) entity.FsmeFosmId = Convert.ToDecimal(dt.Rows[0]["FSME_FOSM_ID"]);
            if ((dt.Rows[0]["FSME_DATA"] != null) && (dt.Rows[0]["FSME_DATA"] != DBNull.Value)) entity.FsmeData = Convert.ToDateTime(dt.Rows[0]["FSME_DATA"]);
            if ((dt.Rows[0]["FSME_DATA_TEXT"] != null) && (dt.Rows[0]["FSME_DATA_TEXT"] != DBNull.Value)) entity.FsmeDataText = Convert.ToString(dt.Rows[0]["FSME_DATA_TEXT"]);
            if ((dt.Rows[0]["FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["FSME_AVANCO_ACM"] != DBNull.Value)) entity.FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["FSME_QTD_ACM"] != null) && (dt.Rows[0]["FSME_QTD_ACM"] != DBNull.Value)) entity.FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["FSME_QTD_ACM"]);
            if ((dt.Rows[0]["FSME_SIFS_ID"] != null) && (dt.Rows[0]["FSME_SIFS_ID"] != DBNull.Value)) entity.FsmeSifsId = Convert.ToDecimal(dt.Rows[0]["FSME_SIFS_ID"]);
            if ((dt.Rows[0]["FSME_OBS"] != null) && (dt.Rows[0]["FSME_OBS"] != DBNull.Value)) entity.FsmeObs = Convert.ToString(dt.Rows[0]["FSME_OBS"]);
            if ((dt.Rows[0]["FSME_DT_CADASTRO"] != null) && (dt.Rows[0]["FSME_DT_CADASTRO"] != DBNull.Value)) entity.FsmeDtCadastro = Convert.ToDateTime(dt.Rows[0]["FSME_DT_CADASTRO"]);
            if ((dt.Rows[0]["FSME_DT_CADASTRO_TEXT"] != null) && (dt.Rows[0]["FSME_DT_CADASTRO_TEXT"] != DBNull.Value)) entity.FsmeDtCadastroText = Convert.ToString(dt.Rows[0]["FSME_DT_CADASTRO_TEXT"]);
            if ((dt.Rows[0]["AVBK_DT_CAPTURA"] != null) && (dt.Rows[0]["AVBK_DT_CAPTURA"] != DBNull.Value)) entity.AvbkDtCaptura = Convert.ToDateTime(dt.Rows[0]["AVBK_DT_CAPTURA"]);
            if ((dt.Rows[0]["AVBK_DT_CAPTURA_TEXT"] != null) && (dt.Rows[0]["AVBK_DT_CAPTURA_TEXT"] != DBNull.Value)) entity.AvbkDtCapturaText = Convert.ToString(dt.Rows[0]["AVBK_DT_CAPTURA_TEXT"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcAvancoBkpDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting AVBK_DT_CAPTURA_TEXT Object"); }
        }
        //====================================================================
        public static List<AcAvancoBkpDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcAvancoBkpDTO> list = OracleDataTools.LoadEntity<AcAvancoBkpDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoBkpDTO>"); }
        }
        //====================================================================
        public static List<AcAvancoBkpDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoBkpDTO>"); }
        }
        //====================================================================
        public static List<AcAvancoBkpDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoBkpDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvancoBkpDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcAvancoBkp"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvancoBkpDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcAvancoBkpDTO collection = new DTO.CollectionAcAvancoBkpDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcAvancoBkpDTO entity = new DTO.AcAvancoBkpDTO();
                    if (dt.Rows[i]["AVBK_ID"].ToString().Length != 0) entity.AvbkId = Convert.ToDecimal(dt.Rows[i]["AVBK_ID"]);
                    if (dt.Rows[i]["FSME_CNTR_CODIGO"].ToString().Length != 0) entity.FsmeCntrCodigo = dt.Rows[i]["FSME_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["FSME_ID"].ToString().Length != 0) entity.FsmeId = Convert.ToDecimal(dt.Rows[i]["FSME_ID"]);
                    if (dt.Rows[i]["FSME_FOSM_ID"].ToString().Length != 0) entity.FsmeFosmId = Convert.ToDecimal(dt.Rows[i]["FSME_FOSM_ID"]);
                    if (dt.Rows[i]["FSME_DATA"].ToString().Length != 0) entity.FsmeData = Convert.ToDateTime(dt.Rows[i]["FSME_DATA"]);
                    if (dt.Rows[i]["FSME_DATA_TEXT"].ToString().Length != 0) entity.FsmeDataText = dt.Rows[i]["FSME_DATA_TEXT"].ToString();
                    if (dt.Rows[i]["FSME_AVANCO_ACM"].ToString().Length != 0) entity.FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["FSME_QTD_ACM"].ToString().Length != 0) entity.FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["FSME_QTD_ACM"]);
                    if (dt.Rows[i]["FSME_SIFS_ID"].ToString().Length != 0) entity.FsmeSifsId = Convert.ToDecimal(dt.Rows[i]["FSME_SIFS_ID"]);
                    if (dt.Rows[i]["FSME_OBS"].ToString().Length != 0) entity.FsmeObs = dt.Rows[i]["FSME_OBS"].ToString();
                    if (dt.Rows[i]["FSME_DT_CADASTRO"].ToString().Length != 0) entity.FsmeDtCadastro = Convert.ToDateTime(dt.Rows[i]["FSME_DT_CADASTRO"]);
                    if (dt.Rows[i]["FSME_DT_CADASTRO_TEXT"].ToString().Length != 0) entity.FsmeDtCadastroText = dt.Rows[i]["FSME_DT_CADASTRO_TEXT"].ToString();
                    if (dt.Rows[i]["AVBK_DT_CAPTURA"].ToString().Length != 0) entity.AvbkDtCaptura = Convert.ToDateTime(dt.Rows[i]["AVBK_DT_CAPTURA"]);
                    if (dt.Rows[i]["AVBK_DT_CAPTURA_TEXT"].ToString().Length != 0) entity.AvbkDtCapturaText = dt.Rows[i]["AVBK_DT_CAPTURA_TEXT"].ToString();

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
            dict.Add("AvbkId", "AVBK_ID");
            dict.Add("FsmeCntrCodigo", "FSME_CNTR_CODIGO");
            dict.Add("FsmeId", "FSME_ID");
            dict.Add("FsmeFosmId", "FSME_FOSM_ID");
            dict.Add("FsmeData", "FSME_DATA");
            dict.Add("FsmeDataText", "FSME_DATA_TEXT");
            dict.Add("FsmeAvancoAcm", "FSME_AVANCO_ACM");
            dict.Add("FsmeQtdAcm", "FSME_QTD_ACM");
            dict.Add("FsmeSifsId", "FSME_SIFS_ID");
            dict.Add("FsmeObs", "FSME_OBS");
            dict.Add("FsmeDtCadastro", "FSME_DT_CADASTRO");
            dict.Add("FsmeDtCadastroText", "FSME_DT_CADASTRO_TEXT");
            dict.Add("AvbkDtCaptura", "AVBK_DT_CAPTURA");
            dict.Add("AvbkDtCapturaText", "AVBK_DT_CAPTURA_TEXT");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
