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
    public class AcAcuracidadeDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //static string strSelect = @"SELECT X.ACUR_ID, X.ACUR_SBCN_SIGLA, X.ACUR_DISC_ID, X.ACUR_DISC_NOME, X.ACUR_FCME_ID, X.ACUR_FCME_SIGLA, X.ACUR_FCES_ID, X.ACUR_FCES_SIGLA, X.ACUR_FCES_WBS, X.ACUR_FOSE_ID, X.ACUR_FOSE_NUMERO, X.ACUR_ATIV_SIG, X.ACUR_UNME_SIGLA, X.ACUR_TSTF_UNIDADE_REGIONAL, X.ACUR_REGIAO, X.ACUR_LOCALIZACAO, X.ACUR_EQUIPE, X.ACUR_QTD_PREVISTA, X.ACUR_FCES_PESO_REL_CRON, X.ACUR_FSMP_FOSM_ID, TO_CHAR(X.ACUR_MAX_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS ACUR_MAX_FSMP_DATA, X.ACUR_FSMP_AVANCO_ACM, X.ACUR_QTD_PROG, X.ACUR_QTD_AVANCO_PROG_POND, X.ACUR_FSME_FOSM_ID, TO_CHAR(X.ACUR_MAX_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS ACUR_MAX_FSME_DATA, X.ACUR_FSME_AVANCO_ACM, X.ACUR_QTD_EXEC, X.ACUR_QTD_AVANCO_EXEC_POND, TO_CHAR(X.ACUR_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS ACUR_CREATED_DATE FROM EEP_CONVERSION.AC_ACURACIDADE X ";

        static string strSelect = @"SELECT * FROM (
                                    SELECT 
                                        X.ACUR_ID, X.ACUR_SBCN_SIGLA, X.ACUR_DISC_ID, X.ACUR_DISC_NOME, X.ACUR_FCME_ID, X.ACUR_FCME_SIGLA, X.ACUR_FCES_ID, X.ACUR_FCES_SIGLA, X.ACUR_FCES_WBS, X.ACUR_FOSE_ID, 
                                        X.ACUR_FOSE_NUMERO, ATIV_SIG AS ACUR_ATIV_SIG, X.ACUR_UNME_SIGLA, X.ACUR_TSTF_UNIDADE_REGIONAL, X.ACUR_REGIAO, X.ACUR_LOCALIZACAO, X.ACUR_EQUIPE, X.ACUR_QTD_PREVISTA, X.ACUR_FCES_PESO_REL_CRON, X.ACUR_FSMP_FOSM_ID, 
                                        TO_CHAR(X.ACUR_MAX_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS ACUR_MAX_FSMP_DATA, 
                                        X.ACUR_FSMP_AVANCO_ACM, X.ACUR_QTD_PROG, X.ACUR_QTD_AVANCO_PROG_POND, X.ACUR_FSME_FOSM_ID, 
                                        TO_CHAR(X.ACUR_MAX_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS ACUR_MAX_FSME_DATA, X.ACUR_FSME_AVANCO_ACM, X.ACUR_QTD_EXEC, X.ACUR_QTD_AVANCO_EXEC_POND, 
                                        TO_CHAR(X.ACUR_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS ACUR_CREATED_DATE 
                                        FROM EEP_CONVERSION.AC_ACURACIDADE X, EEP_CONVERSION.ATIV_VINCULO_FS , EEP_CONVERSION.ATIVIDADE
                                        WHERE 
                                          ATVF_FOSM_ID = X.ACUR_FSMP_FOSM_ID AND
                                          ATIV_CNTR_CODIGO = ATVF_CNTR_CODIGO AND ATIV_ID = ATVF_ATIV_ID AND 
                                          ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO) 
                                                   ) ";
        //====================================================================
        public static int Insert(DTO.AcAcuracidadeDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_ACURACIDADE(ACUR_SBCN_SIGLA,ACUR_DISC_ID,ACUR_DISC_NOME,ACUR_FCME_ID,ACUR_FCME_SIGLA,ACUR_FCES_ID,ACUR_FCES_SIGLA,ACUR_FCES_WBS,ACUR_FOSE_ID,ACUR_FOSE_NUMERO,ACUR_ATIV_SIG,ACUR_UNME_SIGLA,ACUR_TSTF_UNIDADE_REGIONAL,ACUR_REGIAO,ACUR_LOCALIZACAO,ACUR_EQUIPE,ACUR_QTD_PREVISTA,ACUR_FCES_PESO_REL_CRON,ACUR_FSMP_FOSM_ID,ACUR_MAX_FSMP_DATA,ACUR_FSMP_AVANCO_ACM,ACUR_QTD_PROG,ACUR_QTD_AVANCO_PROG_POND,ACUR_FSME_FOSM_ID,ACUR_MAX_FSME_DATA,ACUR_FSME_AVANCO_ACM,ACUR_QTD_EXEC,ACUR_QTD_AVANCO_EXEC_POND) VALUES(:ACUR_SBCN_SIGLA,:ACUR_DISC_ID,:ACUR_DISC_NOME,:ACUR_FCME_ID,:ACUR_FCME_SIGLA,:ACUR_FCES_ID,:ACUR_FCES_SIGLA,:ACUR_FCES_WBS,:ACUR_FOSE_ID,:ACUR_FOSE_NUMERO,:ACUR_ATIV_SIG,:ACUR_UNME_SIGLA,:ACUR_TSTF_UNIDADE_REGIONAL,:ACUR_REGIAO,:ACUR_LOCALIZACAO,:ACUR_EQUIPE,:ACUR_QTD_PREVISTA,:ACUR_FCES_PESO_REL_CRON,:ACUR_FSMP_FOSM_ID,:ACUR_MAX_FSMP_DATA,:ACUR_FSMP_AVANCO_ACM,:ACUR_QTD_PROG,:ACUR_QTD_AVANCO_PROG_POND,:ACUR_FSME_FOSM_ID,:ACUR_MAX_FSME_DATA,:ACUR_FSME_AVANCO_ACM,:ACUR_QTD_EXEC,:ACUR_QTD_AVANCO_EXEC_POND)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ACUR_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.AcurSbcnSigla;
                cmd.Parameters.Add(":ACUR_DISC_ID", OracleDbType.Decimal).Value = entity.AcurDiscId;
                cmd.Parameters.Add(":ACUR_DISC_NOME", OracleDbType.Varchar2).Value = entity.AcurDiscNome;
                cmd.Parameters.Add(":ACUR_FCME_ID", OracleDbType.Decimal).Value = entity.AcurFcmeId;
                cmd.Parameters.Add(":ACUR_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.AcurFcmeSigla;
                cmd.Parameters.Add(":ACUR_FCES_ID", OracleDbType.Decimal).Value = entity.AcurFcesId;
                cmd.Parameters.Add(":ACUR_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.AcurFcesSigla;
                cmd.Parameters.Add(":ACUR_FCES_WBS", OracleDbType.Varchar2).Value = entity.AcurFcesWbs;
                cmd.Parameters.Add(":ACUR_FOSE_ID", OracleDbType.Decimal).Value = entity.AcurFoseId;
                cmd.Parameters.Add(":ACUR_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.AcurFoseNumero;
                cmd.Parameters.Add(":ACUR_ATIV_SIG", OracleDbType.Varchar2).Value = entity.AcurAtivSig;
                cmd.Parameters.Add(":ACUR_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.AcurUnmeSigla;
                cmd.Parameters.Add(":ACUR_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.AcurTstfUnidadeRegional;
                cmd.Parameters.Add(":ACUR_REGIAO", OracleDbType.Varchar2).Value = entity.AcurRegiao;
                cmd.Parameters.Add(":ACUR_LOCALIZACAO", OracleDbType.Varchar2).Value = entity.AcurLocalizacao;
                cmd.Parameters.Add(":ACUR_EQUIPE", OracleDbType.Varchar2).Value = entity.AcurEquipe;
                cmd.Parameters.Add(":ACUR_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.AcurQtdPrevista;
                cmd.Parameters.Add(":ACUR_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.AcurFcesPesoRelCron;

                cmd.Parameters.Add(":ACUR_FSMP_FOSM_ID", OracleDbType.Decimal).Value = (decimal)entity.AcurFsmpFosmId;
                //if (entity.AcurMaxFsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":ACUR_MAX_FSMP_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmpData;
                //else 
                cmd.Parameters.Add(":ACUR_MAX_FSMP_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmpData;
                cmd.Parameters.Add(":ACUR_FSMP_AVANCO_ACM", OracleDbType.Decimal).Value = entity.AcurFsmpAvancoAcm;
                cmd.Parameters.Add(":ACUR_QTD_PROG", OracleDbType.Decimal).Value = entity.AcurQtdProg;
                cmd.Parameters.Add(":ACUR_QTD_AVANCO_PROG_POND", OracleDbType.Decimal).Value = entity.AcurQtdAvancoProgPond;

                cmd.Parameters.Add(":ACUR_FSME_FOSM_ID", OracleDbType.Decimal).Value = entity.AcurFsmeFosmId;
                //if (entity.AcurMaxFsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":ACUR_MAX_FSME_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmeData;
                //else 
                cmd.Parameters.Add(":ACUR_MAX_FSME_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmeData;
                cmd.Parameters.Add(":ACUR_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.AcurFsmeAvancoAcm;
                cmd.Parameters.Add(":ACUR_QTD_EXEC", OracleDbType.Decimal).Value = entity.AcurQtdExec;
                cmd.Parameters.Add(":ACUR_QTD_AVANCO_EXEC_POND", OracleDbType.Decimal).Value = entity.AcurQtdAvancoExecPond;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcAcuracidade");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcAcuracidade");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcAcuracidadeDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_ACURACIDADE set ACUR_SBCN_SIGLA = :ACUR_SBCN_SIGLA, ACUR_DISC_ID = :ACUR_DISC_ID, ACUR_DISC_NOME = :ACUR_DISC_NOME, ACUR_FCME_ID = :ACUR_FCME_ID, ACUR_FCME_SIGLA = :ACUR_FCME_SIGLA, ACUR_FCES_ID = :ACUR_FCES_ID, ACUR_FCES_SIGLA = :ACUR_FCES_SIGLA, ACUR_FCES_WBS = :ACUR_FCES_WBS, ACUR_FOSE_ID = :ACUR_FOSE_ID, ACUR_FOSE_NUMERO = :ACUR_FOSE_NUMERO, ACUR_ATIV_SIG = :ACUR_ATIV_SIG, ACUR_UNME_SIGLA = :ACUR_UNME_SIGLA, ACUR_TSTF_UNIDADE_REGIONAL = :ACUR_TSTF_UNIDADE_REGIONAL, ACUR_REGIAO = :ACUR_REGIAO, ACUR_LOCALIZACAO = :ACUR_LOCALIZACAO, ACUR_EQUIPE = :ACUR_EQUIPE, ACUR_QTD_PREVISTA = :ACUR_QTD_PREVISTA, ACUR_FCES_PESO_REL_CRON = :ACUR_FCES_PESO_REL_CRON, ACUR_FSMP_FOSM_ID = :ACUR_FSMP_FOSM_ID, ACUR_MAX_FSMP_DATA = :ACUR_MAX_FSMP_DATA, ACUR_FSMP_AVANCO_ACM = :ACUR_FSMP_AVANCO_ACM, ACUR_QTD_PROG = :ACUR_QTD_PROG, ACUR_QTD_AVANCO_PROG_POND = :ACUR_QTD_AVANCO_PROG_POND, ACUR_FSME_FOSM_ID = :ACUR_FSME_FOSM_ID, ACUR_MAX_FSME_DATA = :ACUR_MAX_FSME_DATA, ACUR_FSME_AVANCO_ACM = :ACUR_FSME_AVANCO_ACM, ACUR_QTD_EXEC = :ACUR_QTD_EXEC, ACUR_QTD_AVANCO_EXEC_POND = :ACUR_QTD_AVANCO_EXEC_POND WHERE  ACUR_ID = :ACUR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ACUR_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.AcurSbcnSigla;
                cmd.Parameters.Add(":ACUR_DISC_ID", OracleDbType.Decimal).Value = entity.AcurDiscId;
                cmd.Parameters.Add(":ACUR_DISC_NOME", OracleDbType.Varchar2).Value = entity.AcurDiscNome;
                cmd.Parameters.Add(":ACUR_FCME_ID", OracleDbType.Decimal).Value = entity.AcurFcmeId;
                cmd.Parameters.Add(":ACUR_FCME_SIGLA", OracleDbType.Varchar2).Value = entity.AcurFcmeSigla;
                cmd.Parameters.Add(":ACUR_FCES_ID", OracleDbType.Decimal).Value = entity.AcurFcesId;
                cmd.Parameters.Add(":ACUR_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.AcurFcesSigla;
                cmd.Parameters.Add(":ACUR_FCES_WBS", OracleDbType.Varchar2).Value = entity.AcurFcesWbs;
                cmd.Parameters.Add(":ACUR_FOSE_ID", OracleDbType.Decimal).Value = entity.AcurFoseId;
                cmd.Parameters.Add(":ACUR_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.AcurFoseNumero;
                cmd.Parameters.Add(":ACUR_ATIV_SIG", OracleDbType.Varchar2).Value = entity.AcurAtivSig;
                cmd.Parameters.Add(":ACUR_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.AcurUnmeSigla;
                cmd.Parameters.Add(":ACUR_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.AcurTstfUnidadeRegional;
                cmd.Parameters.Add(":ACUR_REGIAO", OracleDbType.Varchar2).Value = entity.AcurRegiao;
                cmd.Parameters.Add(":ACUR_LOCALIZACAO", OracleDbType.Varchar2).Value = entity.AcurLocalizacao;
                cmd.Parameters.Add(":ACUR_EQUIPE", OracleDbType.Varchar2).Value = entity.AcurEquipe;
                cmd.Parameters.Add(":ACUR_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.AcurQtdPrevista;
                cmd.Parameters.Add(":ACUR_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.AcurFcesPesoRelCron;

                cmd.Parameters.Add(":ACUR_FSMP_FOSM_ID", OracleDbType.Decimal).Value = (decimal)entity.AcurFsmpFosmId;
                //if (entity.AcurMaxFsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":ACUR_MAX_FSMP_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmpData;
                //else 
                cmd.Parameters.Add(":ACUR_MAX_FSMP_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmpData;
                cmd.Parameters.Add(":ACUR_FSMP_AVANCO_ACM", OracleDbType.Decimal).Value = entity.AcurFsmpAvancoAcm;
                cmd.Parameters.Add(":ACUR_QTD_PROG", OracleDbType.Decimal).Value = entity.AcurQtdProg;
                cmd.Parameters.Add(":ACUR_QTD_AVANCO_PROG_POND", OracleDbType.Decimal).Value = entity.AcurQtdAvancoProgPond;

                cmd.Parameters.Add(":ACUR_FSME_FOSM_ID", OracleDbType.Decimal).Value = entity.AcurFsmeFosmId;
                //if (entity.AcurMaxFsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":ACUR_MAX_FSME_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmeData;
                //else 
                cmd.Parameters.Add(":ACUR_MAX_FSME_DATA", OracleDbType.Date).Value = entity.AcurMaxFsmeData;
                cmd.Parameters.Add(":ACUR_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.AcurFsmeAvancoAcm;
                cmd.Parameters.Add(":ACUR_QTD_EXEC", OracleDbType.Decimal).Value = entity.AcurQtdExec;
                cmd.Parameters.Add(":ACUR_QTD_AVANCO_EXEC_POND", OracleDbType.Decimal).Value = entity.AcurQtdAvancoExecPond;

                cmd.Parameters.Add(":ACUR_ID", OracleDbType.Decimal).Value = entity.AcurId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcAcuracidade"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal AcurId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_ACURACIDADE WHERE ACUR_ID = :ACUR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AcurId", OracleDbType.Decimal).Value = AcurId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcAcuracidade"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAcuracidade"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_ACURACIDADE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAcuracidade"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAcuracidade"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAcuracidade"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcAcuracidade"); }
        }
        //====================================================================
        public static DTO.AcAcuracidadeDTO Get(decimal AcurId)
        {
            AcAcuracidadeDTO entity = new AcAcuracidadeDTO();
            DataTable dt = null;
            string filter = "ACUR_ID = " + AcurId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ACUR_ID"] != null) && (dt.Rows[0]["ACUR_ID"] != DBNull.Value)) entity.AcurId = Convert.ToDecimal(dt.Rows[0]["ACUR_ID"]);
            if ((dt.Rows[0]["ACUR_SBCN_SIGLA"] != null) && (dt.Rows[0]["ACUR_SBCN_SIGLA"] != DBNull.Value)) entity.AcurSbcnSigla = Convert.ToString(dt.Rows[0]["ACUR_SBCN_SIGLA"]);
            if ((dt.Rows[0]["ACUR_DISC_ID"] != null) && (dt.Rows[0]["ACUR_DISC_ID"] != DBNull.Value)) entity.AcurDiscId = Convert.ToDecimal(dt.Rows[0]["ACUR_DISC_ID"]);
            if ((dt.Rows[0]["ACUR_DISC_NOME"] != null) && (dt.Rows[0]["ACUR_DISC_NOME"] != DBNull.Value)) entity.AcurDiscNome = Convert.ToString(dt.Rows[0]["ACUR_DISC_NOME"]);
            if ((dt.Rows[0]["ACUR_FCME_ID"] != null) && (dt.Rows[0]["ACUR_FCME_ID"] != DBNull.Value)) entity.AcurFcmeId = Convert.ToDecimal(dt.Rows[0]["ACUR_FCME_ID"]);
            if ((dt.Rows[0]["ACUR_FCME_SIGLA"] != null) && (dt.Rows[0]["ACUR_FCME_SIGLA"] != DBNull.Value)) entity.AcurFcmeSigla = Convert.ToString(dt.Rows[0]["ACUR_FCME_SIGLA"]);
            if ((dt.Rows[0]["ACUR_FCES_ID"] != null) && (dt.Rows[0]["ACUR_FCES_ID"] != DBNull.Value)) entity.AcurFcesId = Convert.ToDecimal(dt.Rows[0]["ACUR_FCES_ID"]);
            if ((dt.Rows[0]["ACUR_FCES_SIGLA"] != null) && (dt.Rows[0]["ACUR_FCES_SIGLA"] != DBNull.Value)) entity.AcurFcesSigla = Convert.ToString(dt.Rows[0]["ACUR_FCES_SIGLA"]);
            if ((dt.Rows[0]["ACUR_FCES_WBS"] != null) && (dt.Rows[0]["ACUR_FCES_WBS"] != DBNull.Value)) entity.AcurFcesWbs = Convert.ToString(dt.Rows[0]["ACUR_FCES_WBS"]);
            if ((dt.Rows[0]["ACUR_FOSE_ID"] != null) && (dt.Rows[0]["ACUR_FOSE_ID"] != DBNull.Value)) entity.AcurFoseId = Convert.ToDecimal(dt.Rows[0]["ACUR_FOSE_ID"]);
            if ((dt.Rows[0]["ACUR_FOSE_NUMERO"] != null) && (dt.Rows[0]["ACUR_FOSE_NUMERO"] != DBNull.Value)) entity.AcurFoseNumero = Convert.ToString(dt.Rows[0]["ACUR_FOSE_NUMERO"]);
            if ((dt.Rows[0]["ACUR_ATIV_SIG"] != null) && (dt.Rows[0]["ACUR_ATIV_SIG"] != DBNull.Value)) entity.AcurAtivSig = Convert.ToString(dt.Rows[0]["ACUR_ATIV_SIG"]);
            if ((dt.Rows[0]["ACUR_UNME_SIGLA"] != null) && (dt.Rows[0]["ACUR_UNME_SIGLA"] != DBNull.Value)) entity.AcurUnmeSigla = Convert.ToString(dt.Rows[0]["ACUR_UNME_SIGLA"]);
            if ((dt.Rows[0]["ACUR_TSTF_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["ACUR_TSTF_UNIDADE_REGIONAL"] != DBNull.Value)) entity.AcurTstfUnidadeRegional = Convert.ToString(dt.Rows[0]["ACUR_TSTF_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["ACUR_REGIAO"] != null) && (dt.Rows[0]["ACUR_REGIAO"] != DBNull.Value)) entity.AcurRegiao = Convert.ToString(dt.Rows[0]["ACUR_REGIAO"]);
            if ((dt.Rows[0]["ACUR_LOCALIZACAO"] != null) && (dt.Rows[0]["ACUR_LOCALIZACAO"] != DBNull.Value)) entity.AcurLocalizacao = Convert.ToString(dt.Rows[0]["ACUR_LOCALIZACAO"]);
            if ((dt.Rows[0]["ACUR_EQUIPE"] != null) && (dt.Rows[0]["ACUR_EQUIPE"] != DBNull.Value)) entity.AcurEquipe = Convert.ToString(dt.Rows[0]["ACUR_EQUIPE"]);
            if ((dt.Rows[0]["ACUR_QTD_PREVISTA"] != null) && (dt.Rows[0]["ACUR_QTD_PREVISTA"] != DBNull.Value)) entity.AcurQtdPrevista = Convert.ToDecimal(dt.Rows[0]["ACUR_QTD_PREVISTA"]);
            if ((dt.Rows[0]["ACUR_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["ACUR_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.AcurFcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["ACUR_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["ACUR_FSMP_FOSM_ID"] != null) && (dt.Rows[0]["ACUR_FSMP_FOSM_ID"] != DBNull.Value)) entity.AcurFsmpFosmId = Convert.ToDecimal(dt.Rows[0]["ACUR_FSMP_FOSM_ID"]);
            if ((dt.Rows[0]["ACUR_MAX_FSMP_DATA"] != null) && (dt.Rows[0]["ACUR_MAX_FSMP_DATA"] != DBNull.Value)) entity.AcurMaxFsmpData = Convert.ToDateTime(dt.Rows[0]["ACUR_MAX_FSMP_DATA"]);
            if ((dt.Rows[0]["ACUR_FSMP_AVANCO_ACM"] != null) && (dt.Rows[0]["ACUR_FSMP_AVANCO_ACM"] != DBNull.Value)) entity.AcurFsmpAvancoAcm = Convert.ToDecimal(dt.Rows[0]["ACUR_FSMP_AVANCO_ACM"]);
            if ((dt.Rows[0]["ACUR_QTD_PROG"] != null) && (dt.Rows[0]["ACUR_QTD_PROG"] != DBNull.Value)) entity.AcurQtdProg = Convert.ToDecimal(dt.Rows[0]["ACUR_QTD_PROG"]);
            if ((dt.Rows[0]["ACUR_QTD_AVANCO_PROG_POND"] != null) && (dt.Rows[0]["ACUR_QTD_AVANCO_PROG_POND"] != DBNull.Value)) entity.AcurQtdAvancoProgPond = Convert.ToDecimal(dt.Rows[0]["ACUR_QTD_AVANCO_PROG_POND"]);
            if ((dt.Rows[0]["ACUR_FSME_FOSM_ID"] != null) && (dt.Rows[0]["ACUR_FSME_FOSM_ID"] != DBNull.Value)) entity.AcurFsmeFosmId = Convert.ToDecimal(dt.Rows[0]["ACUR_FSME_FOSM_ID"]);
            if ((dt.Rows[0]["ACUR_MAX_FSME_DATA"] != null) && (dt.Rows[0]["ACUR_MAX_FSME_DATA"] != DBNull.Value)) entity.AcurMaxFsmeData = Convert.ToDateTime(dt.Rows[0]["ACUR_MAX_FSME_DATA"]);
            if ((dt.Rows[0]["ACUR_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["ACUR_FSME_AVANCO_ACM"] != DBNull.Value)) entity.AcurFsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["ACUR_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["ACUR_QTD_EXEC"] != null) && (dt.Rows[0]["ACUR_QTD_EXEC"] != DBNull.Value)) entity.AcurQtdExec = Convert.ToDecimal(dt.Rows[0]["ACUR_QTD_EXEC"]);
            if ((dt.Rows[0]["ACUR_QTD_AVANCO_EXEC_POND"] != null) && (dt.Rows[0]["ACUR_QTD_AVANCO_EXEC_POND"] != DBNull.Value)) entity.AcurQtdAvancoExecPond = Convert.ToDecimal(dt.Rows[0]["ACUR_QTD_AVANCO_EXEC_POND"]);
            if ((dt.Rows[0]["ACUR_CREATED_DATE"] != null) && (dt.Rows[0]["ACUR_CREATED_DATE"] != DBNull.Value)) entity.AcurCreatedDate = Convert.ToDateTime(dt.Rows[0]["ACUR_CREATED_DATE"]);

            return entity;
        }
        //====================================================================
        public static DTO.AcAcuracidadeDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ACUR_QTD_AVANCO_EXEC_POND Object"); }
        }
        //====================================================================
        public static List<AcAcuracidadeDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcAcuracidadeDTO> list = OracleDataTools.LoadEntity<AcAcuracidadeDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAcuracidadeDTO>"); }
        }
        //====================================================================
        public static List<AcAcuracidadeDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAcuracidadeDTO>"); }
        }
        //====================================================================
        public static List<AcAcuracidadeDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAcuracidadeDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcAcuracidadeDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcAcuracidade"); }
        }
        //====================================================================
        public static DTO.CollectionAcAcuracidadeDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcAcuracidadeDTO collection = new DTO.CollectionAcAcuracidadeDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcAcuracidadeDTO entity = new DTO.AcAcuracidadeDTO();
                    if (dt.Rows[i]["ACUR_ID"].ToString().Length != 0) entity.AcurId = Convert.ToDecimal(dt.Rows[i]["ACUR_ID"]);
                    if (dt.Rows[i]["ACUR_SBCN_SIGLA"].ToString().Length != 0) entity.AcurSbcnSigla = dt.Rows[i]["ACUR_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["ACUR_DISC_ID"].ToString().Length != 0) entity.AcurDiscId = Convert.ToDecimal(dt.Rows[i]["ACUR_DISC_ID"]);
                    if (dt.Rows[i]["ACUR_DISC_NOME"].ToString().Length != 0) entity.AcurDiscNome = dt.Rows[i]["ACUR_DISC_NOME"].ToString();
                    if (dt.Rows[i]["ACUR_FCME_ID"].ToString().Length != 0) entity.AcurFcmeId = Convert.ToDecimal(dt.Rows[i]["ACUR_FCME_ID"]);
                    if (dt.Rows[i]["ACUR_FCME_SIGLA"].ToString().Length != 0) entity.AcurFcmeSigla = dt.Rows[i]["ACUR_FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["ACUR_FCES_ID"].ToString().Length != 0) entity.AcurFcesId = Convert.ToDecimal(dt.Rows[i]["ACUR_FCES_ID"]);
                    if (dt.Rows[i]["ACUR_FCES_SIGLA"].ToString().Length != 0) entity.AcurFcesSigla = dt.Rows[i]["ACUR_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["ACUR_FCES_WBS"].ToString().Length != 0) entity.AcurFcesWbs = dt.Rows[i]["ACUR_FCES_WBS"].ToString();
                    if (dt.Rows[i]["ACUR_FOSE_ID"].ToString().Length != 0) entity.AcurFoseId = Convert.ToDecimal(dt.Rows[i]["ACUR_FOSE_ID"]);
                    if (dt.Rows[i]["ACUR_FOSE_NUMERO"].ToString().Length != 0) entity.AcurFoseNumero = dt.Rows[i]["ACUR_FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["ACUR_ATIV_SIG"].ToString().Length != 0) entity.AcurAtivSig = dt.Rows[i]["ACUR_ATIV_SIG"].ToString();
                    if (dt.Rows[i]["ACUR_UNME_SIGLA"].ToString().Length != 0) entity.AcurUnmeSigla = dt.Rows[i]["ACUR_UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["ACUR_TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.AcurTstfUnidadeRegional = dt.Rows[i]["ACUR_TSTF_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["ACUR_REGIAO"].ToString().Length != 0) entity.AcurRegiao = dt.Rows[i]["ACUR_REGIAO"].ToString();
                    if (dt.Rows[i]["ACUR_LOCALIZACAO"].ToString().Length != 0) entity.AcurLocalizacao = dt.Rows[i]["ACUR_LOCALIZACAO"].ToString();
                    if (dt.Rows[i]["ACUR_EQUIPE"].ToString().Length != 0) entity.AcurEquipe = dt.Rows[i]["ACUR_EQUIPE"].ToString();
                    if (dt.Rows[i]["ACUR_QTD_PREVISTA"].ToString().Length != 0) entity.AcurQtdPrevista = Convert.ToDecimal(dt.Rows[i]["ACUR_QTD_PREVISTA"]);
                    if (dt.Rows[i]["ACUR_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.AcurFcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["ACUR_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["ACUR_FSMP_FOSM_ID"].ToString().Length != 0) entity.AcurFsmpFosmId = Convert.ToDecimal(dt.Rows[i]["ACUR_FSMP_FOSM_ID"]);
                    if (dt.Rows[i]["ACUR_MAX_FSMP_DATA"].ToString().Length != 0) entity.AcurMaxFsmpData = Convert.ToDateTime(dt.Rows[i]["ACUR_MAX_FSMP_DATA"]);
                    if (dt.Rows[i]["ACUR_FSMP_AVANCO_ACM"].ToString().Length != 0) entity.AcurFsmpAvancoAcm = Convert.ToDecimal(dt.Rows[i]["ACUR_FSMP_AVANCO_ACM"]);
                    if (dt.Rows[i]["ACUR_QTD_PROG"].ToString().Length != 0) entity.AcurQtdProg = Convert.ToDecimal(dt.Rows[i]["ACUR_QTD_PROG"]);
                    if (dt.Rows[i]["ACUR_QTD_AVANCO_PROG_POND"].ToString().Length != 0) entity.AcurQtdAvancoProgPond = Convert.ToDecimal(dt.Rows[i]["ACUR_QTD_AVANCO_PROG_POND"]);
                    if (dt.Rows[i]["ACUR_FSME_FOSM_ID"].ToString().Length != 0) entity.AcurFsmeFosmId = Convert.ToDecimal(dt.Rows[i]["ACUR_FSME_FOSM_ID"]);
                    if (dt.Rows[i]["ACUR_MAX_FSME_DATA"].ToString().Length != 0) entity.AcurMaxFsmeData = Convert.ToDateTime(dt.Rows[i]["ACUR_MAX_FSME_DATA"]);
                    if (dt.Rows[i]["ACUR_FSME_AVANCO_ACM"].ToString().Length != 0) entity.AcurFsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["ACUR_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["ACUR_QTD_EXEC"].ToString().Length != 0) entity.AcurQtdExec = Convert.ToDecimal(dt.Rows[i]["ACUR_QTD_EXEC"]);
                    if (dt.Rows[i]["ACUR_QTD_AVANCO_EXEC_POND"].ToString().Length != 0) entity.AcurQtdAvancoExecPond = Convert.ToDecimal(dt.Rows[i]["ACUR_QTD_AVANCO_EXEC_POND"]);
                    if (dt.Rows[i]["ACUR_CREATED_DATE"].ToString().Length != 0) entity.AcurCreatedDate = Convert.ToDateTime(dt.Rows[i]["ACUR_CREATED_DATE"]);

                    collection.Add(entity);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetCollection Method"); }
            dt.Dispose();
            return collection;
        }
        //====================================================================
        #endregion
    }
}
