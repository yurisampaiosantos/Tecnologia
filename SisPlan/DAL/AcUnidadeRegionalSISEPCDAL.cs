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
    public class AcUnidadeRegionalSisepcDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.URSP_ID, X.URSP_CNTR_CODIGO, X.URSP_SBCN_SIGLA, X.URSP_DISC_ID, X.URSP_FCME_SIGLA, X.URSP_FOSE_ID, X.URSP_FOSE_NUMERO, X.URSP_REGIAO, X.URSP_UNIDADE_REGIONAL, X.URSP_QTD_PREVISTA, X.URSP_SEQUENCE FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC X ";
        //====================================================================
        public static int Insert(DTO.AcUnidadeRegionalSisepcDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC(URSP_CNTR_CODIGO,URSP_SBCN_SIGLA,URSP_DISC_ID,URSP_FCME_SIGLA,URSP_FOSE_ID,URSP_FOSE_NUMERO,URSP_REGIAO,URSP_UNIDADE_REGIONAL,URSP_QTD_PREVISTA,URSP_SEQUENCE) VALUES(:URSP_CNTR_CODIGO,:URSP_SBCN_SIGLA,:URSP_DISC_ID,:URSP_FCME_SIGLA,:URSP_FOSE_ID,:URSP_FOSE_NUMERO,:URSP_REGIAO,:URSP_UNIDADE_REGIONAL,:URSP_QTD_PREVISTA,:URSP_SEQUENCE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":URSP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.UrspCntrCodigo;
                cmd.Parameters.Add(":URSP_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.UrspSbcnSigla;
                cmd.Parameters.Add(":URSP_DISC_ID", OracleDbType.Decimal).Value = entity.UrspDiscId;
                cmd.Parameters.Add(":URSP_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.UrspFcmeSigla;
                cmd.Parameters.Add(":URSP_FOSE_ID", OracleDbType.Decimal).Value = entity.UrspFoseId;
                cmd.Parameters.Add(":URSP_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.UrspFoseNumero;
                cmd.Parameters.Add(":URSP_REGIAO", OracleDbType.Varchar2).Value = entity.UrspRegiao;
                cmd.Parameters.Add(":URSP_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.UrspUnidadeRegional;
                cmd.Parameters.Add(":URSP_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.UrspQtdPrevista;
                cmd.Parameters.Add(":URSP_SEQUENCE", OracleDbType.Decimal).Value = entity.UrspSequence;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcUnidadeRegionalSisepc");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcUnidadeRegionalSisepc");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcUnidadeRegionalSisepcDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC set URSP_CNTR_CODIGO = :URSP_CNTR_CODIGO, URSP_SBCN_SIGLA = :URSP_SBCN_SIGLA, URSP_DISC_ID = :URSP_DISC_ID, URSP_FCME_SIGLA = :URSP_FCME_SIGLA, URSP_FOSE_ID = :URSP_FOSE_ID, URSP_FOSE_NUMERO = :URSP_FOSE_NUMERO, URSP_REGIAO = :URSP_REGIAO, URSP_UNIDADE_REGIONAL = :URSP_UNIDADE_REGIONAL, URSP_QTD_PREVISTA = :URSP_QTD_PREVISTA, URSP_SEQUENCE = :URSP_SEQUENCE WHERE  URSP_ID = : URSP_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("URSP_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.UrspCntrCodigo;
                cmd.Parameters.Add("URSP_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.UrspSbcnSigla;
                cmd.Parameters.Add("URSP_DISC_ID", OracleDbType.Decimal).Value = entity.UrspDiscId;
                cmd.Parameters.Add("URSP_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.UrspFcmeSigla;
                cmd.Parameters.Add("URSP_FOSE_ID", OracleDbType.Decimal).Value = entity.UrspFoseId;
                cmd.Parameters.Add("URSP_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.UrspFoseNumero;
                cmd.Parameters.Add("URSP_REGIAO", OracleDbType.Varchar2).Value = entity.UrspRegiao;
                cmd.Parameters.Add("URSP_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.UrspUnidadeRegional;
                cmd.Parameters.Add("URSP_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.UrspQtdPrevista;
                cmd.Parameters.Add("URSP_SEQUENCE", OracleDbType.Decimal).Value = entity.UrspSequence;
                cmd.Parameters.Add("URSP_ID", OracleDbType.Decimal).Value = entity.UrspId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcUnidadeRegionalSisepc"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal UrspId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC WHERE  URSP_ID = : URSP_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":UrspId", OracleDbType.Decimal).Value = UrspId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcUnidadeRegionalSisepc"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcUnidadeRegionalSisepc"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_UNIDADE_REGIONAL_SISEPC";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcUnidadeRegionalSisepc"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcUnidadeRegionalSisepc"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcUnidadeRegionalSisepc"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcUnidadeRegionalSisepc"); }
        }
        //====================================================================
        public static DTO.AcUnidadeRegionalSisepcDTO Get(decimal UrspId)
        {
            AcUnidadeRegionalSisepcDTO entity = new AcUnidadeRegionalSisepcDTO();
            DataTable dt = null;
            string filter = "URSP_ID = " + UrspId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["URSP_ID"] != null) && (dt.Rows[0]["URSP_ID"] != DBNull.Value)) entity.UrspId = Convert.ToDecimal(dt.Rows[0]["URSP_ID"]);
            if ((dt.Rows[0]["URSP_CNTR_CODIGO"] != null) && (dt.Rows[0]["URSP_CNTR_CODIGO"] != DBNull.Value)) entity.UrspCntrCodigo = Convert.ToString(dt.Rows[0]["URSP_CNTR_CODIGO"]);
            if ((dt.Rows[0]["URSP_SBCN_SIGLA"] != null) && (dt.Rows[0]["URSP_SBCN_SIGLA"] != DBNull.Value)) entity.UrspSbcnSigla = Convert.ToString(dt.Rows[0]["URSP_SBCN_SIGLA"]);
            if ((dt.Rows[0]["URSP_DISC_ID"] != null) && (dt.Rows[0]["URSP_DISC_ID"] != DBNull.Value)) entity.UrspDiscId = Convert.ToDecimal(dt.Rows[0]["URSP_DISC_ID"]);
            if ((dt.Rows[0]["URSP_FCME_SIGLA"] != null) && (dt.Rows[0]["URSP_FCME_SIGLA"] != DBNull.Value)) entity.UrspFcmeSigla = Convert.ToString(dt.Rows[0]["URSP_FCME_SIGLA"]);
            if ((dt.Rows[0]["URSP_FOSE_ID"] != null) && (dt.Rows[0]["URSP_FOSE_ID"] != DBNull.Value)) entity.UrspFoseId = Convert.ToDecimal(dt.Rows[0]["URSP_FOSE_ID"]);
            if ((dt.Rows[0]["URSP_FOSE_NUMERO"] != null) && (dt.Rows[0]["URSP_FOSE_NUMERO"] != DBNull.Value)) entity.UrspFoseNumero = Convert.ToString(dt.Rows[0]["URSP_FOSE_NUMERO"]);
            if ((dt.Rows[0]["URSP_REGIAO"] != null) && (dt.Rows[0]["URSP_REGIAO"] != DBNull.Value)) entity.UrspRegiao = Convert.ToString(dt.Rows[0]["URSP_REGIAO"]);
            if ((dt.Rows[0]["URSP_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["URSP_UNIDADE_REGIONAL"] != DBNull.Value)) entity.UrspUnidadeRegional = Convert.ToString(dt.Rows[0]["URSP_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["URSP_QTD_PREVISTA"] != null) && (dt.Rows[0]["URSP_QTD_PREVISTA"] != DBNull.Value)) entity.UrspQtdPrevista = Convert.ToDecimal(dt.Rows[0]["URSP_QTD_PREVISTA"]);
            if ((dt.Rows[0]["URSP_SEQUENCE"] != null) && (dt.Rows[0]["URSP_SEQUENCE"] != DBNull.Value)) entity.UrspSequence = Convert.ToDecimal(dt.Rows[0]["URSP_SEQUENCE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcUnidadeRegionalSisepcDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting URSP_SEQUENCE Object"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalSisepcDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcUnidadeRegionalSisepcDTO> list = OracleDataTools.LoadEntity<AcUnidadeRegionalSisepcDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalSisepcDTO>"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalSisepcDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalSisepcDTO>"); }
        }
        //====================================================================
        public static List<AcUnidadeRegionalSisepcDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcUnidadeRegionalSisepcDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcUnidadeRegionalSisepcDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcUnidadeRegionalSisepc"); }
        }
        //====================================================================
        public static DTO.CollectionAcUnidadeRegionalSisepcDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcUnidadeRegionalSisepcDTO collection = new DTO.CollectionAcUnidadeRegionalSisepcDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcUnidadeRegionalSisepcDTO entity = new DTO.AcUnidadeRegionalSisepcDTO();
                    if (dt.Rows[i]["URSP_ID"].ToString().Length != 0) entity.UrspId = Convert.ToDecimal(dt.Rows[i]["URSP_ID"]);
                    if (dt.Rows[i]["URSP_CNTR_CODIGO"].ToString().Length != 0) entity.UrspCntrCodigo = dt.Rows[i]["URSP_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["URSP_SBCN_SIGLA"].ToString().Length != 0) entity.UrspSbcnSigla = dt.Rows[i]["URSP_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["URSP_DISC_ID"].ToString().Length != 0) entity.UrspDiscId = Convert.ToDecimal(dt.Rows[i]["URSP_DISC_ID"]);
                    if (dt.Rows[i]["URSP_FCME_SIGLA"].ToString().Length != 0) entity.UrspFcmeSigla = dt.Rows[i]["URSP_FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["URSP_FOSE_ID"].ToString().Length != 0) entity.UrspFoseId = Convert.ToDecimal(dt.Rows[i]["URSP_FOSE_ID"]);
                    if (dt.Rows[i]["URSP_FOSE_NUMERO"].ToString().Length != 0) entity.UrspFoseNumero = dt.Rows[i]["URSP_FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["URSP_REGIAO"].ToString().Length != 0) entity.UrspRegiao = dt.Rows[i]["URSP_REGIAO"].ToString();
                    if (dt.Rows[i]["URSP_UNIDADE_REGIONAL"].ToString().Length != 0) entity.UrspUnidadeRegional = dt.Rows[i]["URSP_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["URSP_QTD_PREVISTA"].ToString().Length != 0) entity.UrspQtdPrevista = Convert.ToDecimal(dt.Rows[i]["URSP_QTD_PREVISTA"]);
                    if (dt.Rows[i]["URSP_SEQUENCE"].ToString().Length != 0) entity.UrspSequence = Convert.ToDecimal(dt.Rows[i]["URSP_SEQUENCE"]);

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
            dict.Add("UrspId", "URSP_ID");
            dict.Add("UrspCntrCodigo", "URSP_CNTR_CODIGO");
            dict.Add("UrspSbcnSigla", "URSP_SBCN_SIGLA");
            dict.Add("UrspDiscId", "URSP_DISC_ID");
            dict.Add("UrspFcmeSigla", "URSP_FCME_SIGLA");
            dict.Add("UrspFoseId", "URSP_FOSE_ID");
            dict.Add("UrspFoseNumero", "URSP_FOSE_NUMERO");
            dict.Add("UrspRegiao", "URSP_REGIAO");
            dict.Add("UrspUnidadeRegional", "URSP_UNIDADE_REGIONAL");
            dict.Add("UrspQtdPrevista", "URSP_QTD_PREVISTA");
            dict.Add("UrspSequence", "URSP_SEQUENCE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
