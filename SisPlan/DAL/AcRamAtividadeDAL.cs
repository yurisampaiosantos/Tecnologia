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
    public class AcRamAtividadeDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.RAM_ID, X.ACTIVE, X.SBCN_SIGLA, X.ATIV_SIG, X.ATIV_NOME, X.DISC_NOME, X.UNME_ID, X.UNME_SIGLA, X.FOSE_ID, X.FOSE_NUMERO, X.FOSE_REV, X.FOSE_QTD_PREVISTA, X.DESENHO, X.FCME_SIGLA, X.FCES_SIGLA, X.FCES_WBS, X.FCES_PESO_REL_CRON, X.EL01, X.EL02, X.EL03, X.EL04, X.EL05, X.EL06, X.EL07, X.EL08, X.EL09, X.EL10, TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE, X.FOSM_CNTR_CODIGO, X.SBCN_ID, X.DISC_ID, X.ATIV_ID, X.FCME_ID, X.FOSM_ID, X.TIPO_LINHA, TO_CHAR(X.DT_START,'DD/MM/YYYY HH24:MI:SS') AS DT_START, TO_CHAR(X.DT_END,'DD/MM/YYYY HH24:MI:SS') AS DT_END, X.SEMA_ID, X.QTD_PREVISTO_ATIVIDADE FROM EEP_CONVERSION.AC_RAM_ATIVIDADE X ";
        //====================================================================
        public static int Insert(DTO.AcRamAtividadeDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_RAM_ATIVIDADE(RAM_ID, ACTIVE, SBCN_SIGLA, ATIV_SIG, ATIV_NOME, DISC_NOME, UNME_ID, UNME_SIGLA,FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_QTD_PREVISTA, DESENHO, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FCES_PESO_REL_CRON, EL01, EL02, EL03, EL04, EL05, EL06, EL07, EL08, EL09, EL10, CREATED_DATE, FOSM_CNTR_CODIGO, SBCN_ID, DISC_ID, ATIV_ID, FCME_ID, FOSM_ID, TIPO_LINHA, DT_START,DT_END, SEMA_ID, QTD_PREVISTO_ATIVIDADE) VALUES(:RAM_ID, :ACTIVE, :SBCN_SIGLA, :ATIV_SIG, :ATIV_NOME, :DISC_NOME, :UNME_ID, :UNME_SIGLA, :FOSE_ID, :FOSE_NUMERO, :FOSE_REV, :FOSE_QTD_PREVISTA, :DESENHO, :FCME_SIGLA, :FCES_SIGLA, :FCES_WBS, :FCES_PESO_REL_CRON, :EL01, :EL02, :EL03, :EL04, :EL05, :EL06, :EL07, :EL08, :EL09, :EL10, SYSDATE, :FOSM_CNTR_CODIGO, :SBCN_ID, :DISC_ID, :ATIV_ID, :FCME_ID, :FOSM_ID, :TIPO_LINHA, :DT_START, :DT_END, :SEMA_ID, :QTD_PREVISTO_ATIVIDADE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":RAM_ID", OracleDbType.Decimal).Value = entity.RamId;
                cmd.Parameters.Add(":ACTIVE", OracleDbType.Decimal).Value = entity.Active;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ATIV_NOME", OracleDbType.Varchar2).Value = entity.AtivNome;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":UNME_ID", OracleDbType.Decimal).Value = entity.UnmeId;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":FCES_WBS", OracleDbType.Varchar2).Value = entity.FcesWbs;
                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.FcesPesoRelCron;
                cmd.Parameters.Add(":EL01", OracleDbType.Varchar2).Value = entity.El01;
                cmd.Parameters.Add(":EL02", OracleDbType.Varchar2).Value = entity.El02;
                cmd.Parameters.Add(":EL03", OracleDbType.Varchar2).Value = entity.El03;
                cmd.Parameters.Add(":EL04", OracleDbType.Varchar2).Value = entity.El04;
                cmd.Parameters.Add(":EL05", OracleDbType.Varchar2).Value = entity.El05;
                cmd.Parameters.Add(":EL06", OracleDbType.Varchar2).Value = entity.El06;
                cmd.Parameters.Add(":EL07", OracleDbType.Varchar2).Value = entity.El07;
                cmd.Parameters.Add(":EL08", OracleDbType.Varchar2).Value = entity.El08;
                cmd.Parameters.Add(":EL09", OracleDbType.Varchar2).Value = entity.El09;
                cmd.Parameters.Add(":EL10", OracleDbType.Varchar2).Value = entity.El10;
                cmd.Parameters.Add(":FOSM_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FosmCntrCodigo;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":ATIV_ID", OracleDbType.Decimal).Value = entity.AtivId;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":TIPO_LINHA", OracleDbType.Decimal).Value = entity.TipoLinha;
                if (entity.DtStart.ToOADate() == 0.0) cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                else cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                if (entity.DtEnd.ToOADate() == 0.0) cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                else cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":QTD_PREVISTO_ATIVIDADE", OracleDbType.Varchar2).Value = entity.QtdPrevistoAtividade;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcRamAtividade");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcRamAtividade");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcRamAtividadeDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_RAM_ATIVIDADE set ACTIVE = :ACTIVE, SBCN_SIGLA = :SBCN_SIGLA, ATIV_SIG = :ATIV_SIG, ATIV_NOME = :ATIV_NOME, DISC_NOME = :DISC_NOME, UNME_ID = :UNME_ID, UNME_SIGLA = :UNME_SIGLA, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, FOSE_REV = :FOSE_REV, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, DESENHO = :DESENHO, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, FCES_WBS = :FCES_WBS, FCES_PESO_REL_CRON = :FCES_PESO_REL_CRON, EL01 = :EL01, EL02 = :EL02, EL03 = :EL03, EL04 = :EL04, EL05 = :EL05, EL06 = :EL06, EL07 = :EL07, EL08 = :EL08, EL09 = :EL09, EL10 = :EL10, FOSM_CNTR_CODIGO = :FOSM_CNTR_CODIGO, SBCN_ID = :SBCN_ID, DISC_ID = :DISC_ID, ATIV_ID = :ATIV_ID, FCME_ID = :FCME_ID, FOSM_ID = :FOSM_ID, TIPO_LINHA = :TIPO_LINHA, DT_START = :DT_START, DT_END = :DT_END, SEMA_ID = :SEMA_ID, QTD_PREVISTO_ATIVIDADE = :QTD_PREVISTO_ATIVIDADE WHERE  RAM_ID = : RAM_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ACTIVE", OracleDbType.Decimal).Value = entity.Active;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ATIV_NOME", OracleDbType.Varchar2).Value = entity.AtivNome;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":UNME_ID", OracleDbType.Decimal).Value = entity.UnmeId;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":FCES_WBS", OracleDbType.Varchar2).Value = entity.FcesWbs;
                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.FcesPesoRelCron;
                cmd.Parameters.Add(":EL01", OracleDbType.Varchar2).Value = entity.El01;
                cmd.Parameters.Add(":EL02", OracleDbType.Varchar2).Value = entity.El02;
                cmd.Parameters.Add(":EL03", OracleDbType.Varchar2).Value = entity.El03;
                cmd.Parameters.Add(":EL04", OracleDbType.Varchar2).Value = entity.El04;
                cmd.Parameters.Add(":EL05", OracleDbType.Varchar2).Value = entity.El05;
                cmd.Parameters.Add(":EL06", OracleDbType.Varchar2).Value = entity.El06;
                cmd.Parameters.Add(":EL07", OracleDbType.Varchar2).Value = entity.El07;
                cmd.Parameters.Add(":EL08", OracleDbType.Varchar2).Value = entity.El08;
                cmd.Parameters.Add(":EL09", OracleDbType.Varchar2).Value = entity.El09;
                cmd.Parameters.Add(":EL10", OracleDbType.Varchar2).Value = entity.El10;
                cmd.Parameters.Add(":FOSM_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FosmCntrCodigo;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":ATIV_ID", OracleDbType.Decimal).Value = entity.AtivId;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":TIPO_LINHA", OracleDbType.Decimal).Value = entity.TipoLinha;
                if (entity.DtStart.ToOADate() == 0.0) cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                else cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                if (entity.DtEnd.ToOADate() == 0.0) cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                else cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":QTD_PREVISTO_ATIVIDADE", OracleDbType.Varchar2).Value = entity.QtdPrevistoAtividade;
                cmd.Parameters.Add(":RAM_ID", OracleDbType.Decimal).Value = entity.RamId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcRamAtividade"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal RamId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_RAM_ATIVIDADE WHERE RAM_ID = :RAM_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":RamId", OracleDbType.Decimal).Value = RamId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcRamAtividade"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRamAtividade"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_RAM_ATIVIDADE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRamAtividade"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRamAtividade"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRamAtividade"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcRamAtividade"); }
        }
        //====================================================================
        public static DTO.AcRamAtividadeDTO Get(decimal RamId)
        {
            AcRamAtividadeDTO entity = new AcRamAtividadeDTO();
            DataTable dt = null;
            string filter = "RAM_ID = " + RamId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["RAM_ID"] != null) && (dt.Rows[0]["RAM_ID"] != DBNull.Value)) entity.RamId = Convert.ToDecimal(dt.Rows[0]["RAM_ID"]);
            if ((dt.Rows[0]["ACTIVE"] != null) && (dt.Rows[0]["ACTIVE"] != DBNull.Value)) entity.Active = Convert.ToDecimal(dt.Rows[0]["ACTIVE"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["ATIV_NOME"] != null) && (dt.Rows[0]["ATIV_NOME"] != DBNull.Value)) entity.AtivNome = Convert.ToString(dt.Rows[0]["ATIV_NOME"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["UNME_ID"] != null) && (dt.Rows[0]["UNME_ID"] != DBNull.Value)) entity.UnmeId = Convert.ToDecimal(dt.Rows[0]["UNME_ID"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_REV"] != null) && (dt.Rows[0]["FOSE_REV"] != DBNull.Value)) entity.FoseRev = Convert.ToString(dt.Rows[0]["FOSE_REV"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["FCES_WBS"] != null) && (dt.Rows[0]["FCES_WBS"] != DBNull.Value)) entity.FcesWbs = Convert.ToString(dt.Rows[0]["FCES_WBS"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FCES_PESO_REL_CRON"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL01"] != null) && (dt.Rows[0]["EL01"] != DBNull.Value)) entity.El01 = Convert.ToString(dt.Rows[0]["EL01"]);
            if ((dt.Rows[0]["EL02"] != null) && (dt.Rows[0]["EL02"] != DBNull.Value)) entity.El02 = Convert.ToString(dt.Rows[0]["EL02"]);
            if ((dt.Rows[0]["EL03"] != null) && (dt.Rows[0]["EL03"] != DBNull.Value)) entity.El03 = Convert.ToString(dt.Rows[0]["EL03"]);
            if ((dt.Rows[0]["EL04"] != null) && (dt.Rows[0]["EL04"] != DBNull.Value)) entity.El04 = Convert.ToString(dt.Rows[0]["EL04"]);
            if ((dt.Rows[0]["EL05"] != null) && (dt.Rows[0]["EL05"] != DBNull.Value)) entity.El05 = Convert.ToString(dt.Rows[0]["EL05"]);
            if ((dt.Rows[0]["EL06"] != null) && (dt.Rows[0]["EL06"] != DBNull.Value)) entity.El06 = Convert.ToString(dt.Rows[0]["EL06"]);
            if ((dt.Rows[0]["EL07"] != null) && (dt.Rows[0]["EL07"] != DBNull.Value)) entity.El07 = Convert.ToString(dt.Rows[0]["EL07"]);
            if ((dt.Rows[0]["EL08"] != null) && (dt.Rows[0]["EL08"] != DBNull.Value)) entity.El08 = Convert.ToString(dt.Rows[0]["EL08"]);
            if ((dt.Rows[0]["EL09"] != null) && (dt.Rows[0]["EL09"] != DBNull.Value)) entity.El09 = Convert.ToString(dt.Rows[0]["EL09"]);
            if ((dt.Rows[0]["EL10"] != null) && (dt.Rows[0]["EL10"] != DBNull.Value)) entity.El10 = Convert.ToString(dt.Rows[0]["EL10"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["FOSM_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSM_CNTR_CODIGO"] != DBNull.Value)) entity.FosmCntrCodigo = Convert.ToString(dt.Rows[0]["FOSM_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["ATIV_ID"] != null) && (dt.Rows[0]["ATIV_ID"] != DBNull.Value)) entity.AtivId = Convert.ToDecimal(dt.Rows[0]["ATIV_ID"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToDecimal(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["TIPO_LINHA"] != null) && (dt.Rows[0]["TIPO_LINHA"] != DBNull.Value)) entity.TipoLinha = Convert.ToDecimal(dt.Rows[0]["TIPO_LINHA"]);
            if ((dt.Rows[0]["DT_START"] != null) && (dt.Rows[0]["DT_START"] != DBNull.Value)) entity.DtStart = Convert.ToDateTime(dt.Rows[0]["DT_START"]);
            if ((dt.Rows[0]["DT_END"] != null) && (dt.Rows[0]["DT_END"] != DBNull.Value)) entity.DtEnd = Convert.ToDateTime(dt.Rows[0]["DT_END"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            if ((dt.Rows[0]["QTD_PREVISTO_ATIVIDADE"] != null) && (dt.Rows[0]["QTD_PREVISTO_ATIVIDADE"] != DBNull.Value)) entity.QtdPrevistoAtividade = Convert.ToString(dt.Rows[0]["QTD_PREVISTO_ATIVIDADE"]).Replace("%", "") + "%";
            return entity;
        }
        //====================================================================
        public static DTO.AcRamAtividadeDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DT_END Object"); }
        }
        //====================================================================
        public static List<AcRamAtividadeDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcRamAtividadeDTO> list = OracleDataTools.LoadEntity<AcRamAtividadeDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeDTO>"); }
        }
        //====================================================================
        public static List<AcRamAtividadeDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeDTO>"); }
        }
        //====================================================================
        public static List<AcRamAtividadeDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcRamAtividadeDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcRamAtividade"); }
        }
        //====================================================================
        public static DTO.CollectionAcRamAtividadeDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcRamAtividadeDTO collection = new DTO.CollectionAcRamAtividadeDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcRamAtividadeDTO entity = new DTO.AcRamAtividadeDTO();
                    if (dt.Rows[i]["RAM_ID"].ToString().Length != 0) entity.RamId = Convert.ToDecimal(dt.Rows[i]["RAM_ID"]);
                    if (dt.Rows[i]["ACTIVE"].ToString().Length != 0) entity.Active = Convert.ToDecimal(dt.Rows[i]["ACTIVE"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = dt.Rows[i]["ATIV_SIG"].ToString();
                    if (dt.Rows[i]["ATIV_NOME"].ToString().Length != 0) entity.AtivNome = dt.Rows[i]["ATIV_NOME"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["UNME_ID"].ToString().Length != 0) entity.UnmeId = Convert.ToDecimal(dt.Rows[i]["UNME_ID"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSE_REV"].ToString().Length != 0) entity.FoseRev = dt.Rows[i]["FOSE_REV"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_WBS"].ToString().Length != 0) entity.FcesWbs = dt.Rows[i]["FCES_WBS"].ToString();
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL01"].ToString().Length != 0) entity.El01 = dt.Rows[i]["EL01"].ToString();
                    if (dt.Rows[i]["EL02"].ToString().Length != 0) entity.El02 = dt.Rows[i]["EL02"].ToString();
                    if (dt.Rows[i]["EL03"].ToString().Length != 0) entity.El03 = dt.Rows[i]["EL03"].ToString();
                    if (dt.Rows[i]["EL04"].ToString().Length != 0) entity.El04 = dt.Rows[i]["EL04"].ToString();
                    if (dt.Rows[i]["EL05"].ToString().Length != 0) entity.El05 = dt.Rows[i]["EL05"].ToString();
                    if (dt.Rows[i]["EL06"].ToString().Length != 0) entity.El06 = dt.Rows[i]["EL06"].ToString();
                    if (dt.Rows[i]["EL07"].ToString().Length != 0) entity.El07 = dt.Rows[i]["EL07"].ToString();
                    if (dt.Rows[i]["EL08"].ToString().Length != 0) entity.El08 = dt.Rows[i]["EL08"].ToString();
                    if (dt.Rows[i]["EL09"].ToString().Length != 0) entity.El09 = dt.Rows[i]["EL09"].ToString();
                    if (dt.Rows[i]["EL10"].ToString().Length != 0) entity.El10 = dt.Rows[i]["EL10"].ToString();
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["FOSM_CNTR_CODIGO"].ToString().Length != 0) entity.FosmCntrCodigo = dt.Rows[i]["FOSM_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["ATIV_ID"].ToString().Length != 0) entity.AtivId = Convert.ToDecimal(dt.Rows[i]["ATIV_ID"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToDecimal(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["TIPO_LINHA"].ToString().Length != 0) entity.TipoLinha = Convert.ToDecimal(dt.Rows[i]["TIPO_LINHA"]);
                    if (dt.Rows[i]["DT_START"].ToString().Length != 0) entity.DtStart = Convert.ToDateTime(dt.Rows[i]["DT_START"]);
                    if (dt.Rows[i]["DT_END"].ToString().Length != 0) entity.DtEnd = Convert.ToDateTime(dt.Rows[i]["DT_END"]);
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                    if (dt.Rows[i]["QTD_PREVISTO_ATIVIDADE"].ToString().Length != 0) entity.QtdPrevistoAtividade = (dt.Rows[i]["QTD_PREVISTO_ATIVIDADE"]).ToString().Replace("%","") + "%";
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
            dict.Add("RamId", "RAM_ID");
            dict.Add("Active", "ACTIVE");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("AtivSig", "ATIV_SIG");
            dict.Add("AtivNome", "ATIV_NOME");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("UnmeId", "UNME_ID");
            dict.Add("UnmeSigla", "UNME_SIGLA");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FoseRev", "FOSE_REV");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("Desenho", "DESENHO");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("FcesWbs", "FCES_WBS");
            dict.Add("FcesPesoRelCron", "FCES_PESO_REL_CRON");
            dict.Add("El01", "EL01");
            dict.Add("El02", "EL02");
            dict.Add("El03", "EL03");
            dict.Add("El04", "EL04");
            dict.Add("El05", "EL05");
            dict.Add("El06", "EL06");
            dict.Add("El07", "EL07");
            dict.Add("El08", "EL08");
            dict.Add("El09", "EL09");
            dict.Add("El10", "EL10");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("FosmCntrCodigo", "FOSM_CNTR_CODIGO");
            dict.Add("SbcnId", "SBCN_ID");
            dict.Add("DiscId", "DISC_ID");
            dict.Add("AtivId", "ATIV_ID");
            dict.Add("FcmeId", "FCME_ID");
            dict.Add("FosmId", "FOSM_ID");
            dict.Add("TipoLinha", "TIPO_LINHA");
            dict.Add("DtStart", "DT_START");
            dict.Add("DtEnd", "DT_END");
            dict.Add("SemaId", "SEMA_ID");
            dict.Add("QtdPrevistoAtividade", "QTD_PREVISTO_ATIVIDADE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
