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
    public class AcPendenciaFolhaServicoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.SBCN_SIGLA, X.DISC_NOME, X.FOSE_NUMERO, X.DIPC_CODIGO, X.DIPI_DESCRICAO_RES, X.DIPQ_QTD_RM, X.FSIT_QTD_REAL, X.DCMN_NUMERO, X.STATUS, CONVERT(VARCHAR(10), X.CREATED_DATE,103) AS CREATED_DATE FROM EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO X ";
        //====================================================================
        public static int Insert(DTO.AcPendenciaFolhaServicoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO(ID, SBCN_SIGLA,DISC_NOME,FOSE_NUMERO,DIPC_CODIGO,DIPI_DESCRICAO_RES,DIPQ_QTD_RM,FSIT_QTD_REAL,DCMN_NUMERO,STATUS) VALUES(:ID, :SBCN_SIGLA,:DISC_NOME,:FOSE_NUMERO,:DIPC_CODIGO,:DIPI_DESCRICAO_RES,:DIPQ_QTD_RM,:FSIT_QTD_REAL,:DCMN_NUMERO,:STATUS)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID; ;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":DIPC_CODIGO", OracleDbType.Varchar2).Value = entity.DipcCodigo;
                cmd.Parameters.Add(":DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;
                cmd.Parameters.Add(":DIPQ_QTD_RM", OracleDbType.Int64).Value = entity.DipqQtdRm;
                cmd.Parameters.Add(":FSIT_QTD_REAL", OracleDbType.Int64).Value = entity.FsitQtdReal;
                cmd.Parameters.Add(":DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
                cmd.Parameters.Add(":STATUS", OracleDbType.Varchar2).Value = entity.Status;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcPendenciaFolhaServico");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcPendenciaFolhaServico");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcPendenciaFolhaServicoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO set SBCN_SIGLA = :SBCN_SIGLA, DISC_NOME = :DISC_NOME, FOSE_NUMERO = :FOSE_NUMERO, DIPC_CODIGO = :DIPC_CODIGO, DIPI_DESCRICAO_RES = :DIPI_DESCRICAO_RES, DIPQ_QTD_RM = :DIPQ_QTD_RM, FSIT_QTD_REAL = :FSIT_QTD_REAL, DCMN_NUMERO = :DCMN_NUMERO, STATUS = :STATUS, CREATED_DATE = :CREATED_DATE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add("DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add("FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add("DIPC_CODIGO", OracleDbType.Varchar2).Value = entity.DipcCodigo;
                cmd.Parameters.Add("DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;
                cmd.Parameters.Add("DIPQ_QTD_RM", OracleDbType.Int64).Value = entity.DipqQtdRm;
                cmd.Parameters.Add("FSIT_QTD_REAL", OracleDbType.Int64).Value = entity.FsitQtdReal;
                cmd.Parameters.Add("DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
                cmd.Parameters.Add("STATUS", OracleDbType.Varchar2).Value = entity.Status;
                if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                else cmd.Parameters.Add("CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                cmd.Parameters.Add("CREATED_DATE", OracleDbType.Int64).Value = entity.CreatedDate;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcPendenciaFolhaServico"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int64).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcPendenciaFolhaServico"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPendenciaFolhaServico"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPendenciaFolhaServico"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPendenciaFolhaServico"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPendenciaFolhaServico"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcPendenciaFolhaServico"); }
        }
        //====================================================================
        public static DTO.AcPendenciaFolhaServicoDTO Get(decimal ID)
        {
            AcPendenciaFolhaServicoDTO entity = new AcPendenciaFolhaServicoDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["DIPC_CODIGO"] != null) && (dt.Rows[0]["DIPC_CODIGO"] != DBNull.Value)) entity.DipcCodigo = Convert.ToString(dt.Rows[0]["DIPC_CODIGO"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_RES"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_RES"] != DBNull.Value)) entity.DipiDescricaoRes = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_RES"]);
            if ((dt.Rows[0]["DIPQ_QTD_RM"] != null) && (dt.Rows[0]["DIPQ_QTD_RM"] != DBNull.Value)) entity.DipqQtdRm = Convert.ToDecimal(dt.Rows[0]["DIPQ_QTD_RM"]);
            if ((dt.Rows[0]["FSIT_QTD_REAL"] != null) && (dt.Rows[0]["FSIT_QTD_REAL"] != DBNull.Value)) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[0]["FSIT_QTD_REAL"]);
            if ((dt.Rows[0]["DCMN_NUMERO"] != null) && (dt.Rows[0]["DCMN_NUMERO"] != DBNull.Value)) entity.DcmnNumero = Convert.ToString(dt.Rows[0]["DCMN_NUMERO"]);
            if ((dt.Rows[0]["STATUS"] != null) && (dt.Rows[0]["STATUS"] != DBNull.Value)) entity.Status = Convert.ToString(dt.Rows[0]["STATUS"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcPendenciaFolhaServicoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcPendenciaFolhaServicoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcPendenciaFolhaServicoDTO> list = OracleDataTools.LoadEntity<AcPendenciaFolhaServicoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaFolhaServicoDTO>"); }
        }
        //====================================================================
        public static List<AcPendenciaFolhaServicoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaFolhaServicoDTO>"); }
        }
        //====================================================================
        public static List<AcPendenciaFolhaServicoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaFolhaServicoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaFolhaServicoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcPendenciaFolhaServico"); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaFolhaServicoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcPendenciaFolhaServicoDTO collection = new DTO.CollectionAcPendenciaFolhaServicoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcPendenciaFolhaServicoDTO entity = new DTO.AcPendenciaFolhaServicoDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["DIPC_CODIGO"].ToString().Length != 0) entity.DipcCodigo = dt.Rows[i]["DIPC_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString().Length != 0) entity.DipiDescricaoRes = dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_RM"].ToString().Length != 0) entity.DipqQtdRm = Convert.ToDecimal(dt.Rows[i]["DIPQ_QTD_RM"]);
                    if (dt.Rows[i]["FSIT_QTD_REAL"].ToString().Length != 0) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[i]["FSIT_QTD_REAL"]);
                    if (dt.Rows[i]["DCMN_NUMERO"].ToString().Length != 0) entity.DcmnNumero = dt.Rows[i]["DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["STATUS"].ToString().Length != 0) entity.Status = dt.Rows[i]["STATUS"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);

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
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("DipcCodigo", "DIPC_CODIGO");
            dict.Add("DipiDescricaoRes", "DIPI_DESCRICAO_RES");
            dict.Add("DipqQtdRm", "DIPQ_QTD_RM");
            dict.Add("FsitQtdReal", "FSIT_QTD_REAL");
            dict.Add("DcmnNumero", "DCMN_NUMERO");
            dict.Add("Status", "STATUS");
            dict.Add("CreatedDate", "CREATED_DATE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
