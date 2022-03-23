using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================

namespace DAL
{
    public class AcRamAtividadeStageDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //static string strSelect = @"SELECT X.RAM_STAGE_ID, X.FOSM_CNTR_CODIGO, X.FOSM_ID, X.SBCN_ID, X.SBCN_SIGLA, X.ATIV_ID, X.ATIV_SIG, X.ATIV_NOME, X.DISC_ID, X.DISC_NOME, X.UNME_ID, X.UNME_SIGLA, X.FOSE_ID, X.FOSE_NUMERO, X.FOSE_REV, X.FOSE_QTD_PREVISTA, X.FCME_ID, X.FCME_SIGLA, X.FCME_NOME, X.EL01_FCES_SIGLA, X.EL01_FCES_DESCRICAO, X.EL01_FCES_NIVEL, X.EL01_FCES_WBS, X.EL01_FCES_PESO_REL_CRON, X.EL01_FSME_AVANCO_ACM, X.EL01_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL01_FSME_DATA,103) AS EL01_FSME_DATA, X.EL01_FCES_AVN_REAL, X.EL01_FCES_AVN_POND, X.EL02_FCES_SIGLA, X.EL02_FCES_DESCRICAO, X.EL02_FCES_NIVEL, X.EL02_FCES_WBS, X.EL02_FCES_PESO_REL_CRON, X.EL02_FSME_AVANCO_ACM, X.EL02_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL02_FSME_DATA,103) AS EL02_FSME_DATA, X.EL02_FCES_AVN_REAL, X.EL02_FCES_AVN_POND, X.EL03_FCES_SIGLA, X.EL03_FCES_DESCRICAO, X.EL03_FCES_NIVEL, X.EL03_FCES_WBS, X.EL03_FCES_PESO_REL_CRON, X.EL03_FSME_AVANCO_ACM, X.EL03_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL03_FSME_DATA,103) AS EL03_FSME_DATA, X.EL03_FCES_AVN_REAL, X.EL03_FCES_AVN_POND, X.EL04_FCES_SIGLA, X.EL04_FCES_DESCRICAO, X.EL04_FCES_NIVEL, X.EL04_FCES_WBS, X.EL04_FCES_PESO_REL_CRON, X.EL04_FSME_AVANCO_ACM, X.EL04_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL04_FSME_DATA,103) AS EL04_FSME_DATA, X.EL04_FCES_AVN_REAL, X.EL04_FCES_AVN_POND, X.EL05_FCES_SIGLA, X.EL05_FCES_DESCRICAO, X.EL05_FCES_NIVEL, X.EL05_FCES_WBS, X.EL05_FCES_PESO_REL_CRON, X.EL05_FSME_AVANCO_ACM, X.EL05_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL05_FSME_DATA,103) AS EL05_FSME_DATA, X.EL05_FCES_AVN_REAL, X.EL05_FCES_AVN_POND, X.EL06_FCES_SIGLA, X.EL06_FCES_DESCRICAO, X.EL06_FCES_NIVEL, X.EL06_FCES_WBS, X.EL06_FCES_PESO_REL_CRON, X.EL06_FSME_AVANCO_ACM, X.EL06_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL06_FSME_DATA,103) AS EL06_FSME_DATA, X.EL06_FCES_AVN_REAL, X.EL06_FCES_AVN_POND, X.EL07_FCES_SIGLA, X.EL07_FCES_DESCRICAO, X.EL07_FCES_NIVEL, X.EL07_FCES_WBS, X.EL07_FCES_PESO_REL_CRON, X.EL07_FSME_AVANCO_ACM, X.EL07_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL07_FSME_DATA,103) AS EL07_FSME_DATA, X.EL07_FCES_AVN_REAL, X.EL07_FCES_AVN_POND, X.EL08_FCES_SIGLA, X.EL08_FCES_DESCRICAO, X.EL08_FCES_NIVEL, X.EL08_FCES_WBS, X.EL08_FCES_PESO_REL_CRON, X.EL08_FSME_AVANCO_ACM, X.EL08_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL08_FSME_DATA,103) AS EL08_FSME_DATA, X.EL08_FCES_AVN_REAL, X.EL08_FCES_AVN_POND, X.EL09_FCES_SIGLA, X.EL09_FCES_DESCRICAO, X.EL09_FCES_NIVEL, X.EL09_FCES_WBS, X.EL09_FCES_PESO_REL_CRON, X.EL09_FSME_AVANCO_ACM, X.EL09_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL09_FSME_DATA,103) AS EL09_FSME_DATA, X.EL09_FCES_AVN_REAL, X.EL09_FCES_AVN_POND, X.EL10_FCES_SIGLA, X.EL10_FCES_DESCRICAO, X.EL10_FCES_NIVEL, X.EL10_FCES_WBS, X.EL10_FCES_PESO_REL_CRON, X.EL10_FSME_AVANCO_ACM, X.EL10_FSME_QTD_ACM, CONVERT(VARCHAR(10), X.EL10_FSME_DATA,103) AS EL10_FSME_DATA, X.EL10_FCES_AVN_REAL, X.EL10_FCES_AVN_POND, CONVERT(VARCHAR(10), X.CREATED_DATE,103) AS CREATED_DATE, CONVERT(VARCHAR(10), X.DT_START,103) AS DT_START, CONVERT(VARCHAR(10), X.DT_END,103) AS DT_END, X.SEMA_ID FROM EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE X ";

        static string strSelect = @"SELECT X.RAM_STAGE_ID, X.FOSM_CNTR_CODIGO, X.FOSM_ID, X.SBCN_ID, X.SBCN_SIGLA, X.ATIV_ID, X.ATIV_SIG, X.ATIV_NOME, X.DISC_ID, X.DISC_NOME, X.UNME_ID, X.UNME_SIGLA, X.FOSE_ID, X.FOSE_NUMERO, X.FOSE_REV, X.FOSE_QTD_PREVISTA, X.FCME_ID, X.FCME_SIGLA, X.FCME_NOME, X.EL01_FCES_SIGLA, X.EL01_FCES_DESCRICAO, X.EL01_FCES_NIVEL, X.EL01_FCES_WBS, X.EL01_FCES_PESO_REL_CRON, X.EL01_FSME_AVANCO_ACM, X.EL01_FSME_QTD_ACM, TO_CHAR(X.EL01_FSME_DATA, 'DD/MM/YY') AS EL01_FSME_DATA, X.EL01_FCES_AVN_REAL, X.EL01_FCES_AVN_POND, X.EL02_FCES_SIGLA, X.EL02_FCES_DESCRICAO, X.EL02_FCES_NIVEL, X.EL02_FCES_WBS, X.EL02_FCES_PESO_REL_CRON, X.EL02_FSME_AVANCO_ACM, X.EL02_FSME_QTD_ACM, TO_CHAR(X.EL02_FSME_DATA, 'DD/MM/YY') AS EL02_FSME_DATA, X.EL02_FCES_AVN_REAL, X.EL02_FCES_AVN_POND, X.EL03_FCES_SIGLA, X.EL03_FCES_DESCRICAO, X.EL03_FCES_NIVEL, X.EL03_FCES_WBS, X.EL03_FCES_PESO_REL_CRON, X.EL03_FSME_AVANCO_ACM, X.EL03_FSME_QTD_ACM, TO_CHAR(X.EL03_FSME_DATA, 'DD/MM/YY') AS EL03_FSME_DATA, X.EL03_FCES_AVN_REAL, X.EL03_FCES_AVN_POND, X.EL04_FCES_SIGLA, X.EL04_FCES_DESCRICAO, X.EL04_FCES_NIVEL, X.EL04_FCES_WBS, X.EL04_FCES_PESO_REL_CRON, X.EL04_FSME_AVANCO_ACM, X.EL04_FSME_QTD_ACM, TO_CHAR(X.EL04_FSME_DATA, 'DD/MM/YY') AS EL04_FSME_DATA, X.EL04_FCES_AVN_REAL, X.EL04_FCES_AVN_POND, X.EL05_FCES_SIGLA, X.EL05_FCES_DESCRICAO, X.EL05_FCES_NIVEL, X.EL05_FCES_WBS, X.EL05_FCES_PESO_REL_CRON, X.EL05_FSME_AVANCO_ACM, X.EL05_FSME_QTD_ACM, TO_CHAR(X.EL05_FSME_DATA, 'DD/MM/YY') AS EL05_FSME_DATA, X.EL05_FCES_AVN_REAL, X.EL05_FCES_AVN_POND, X.EL06_FCES_SIGLA, X.EL06_FCES_DESCRICAO, X.EL06_FCES_NIVEL, X.EL06_FCES_WBS, X.EL06_FCES_PESO_REL_CRON, X.EL06_FSME_AVANCO_ACM, X.EL06_FSME_QTD_ACM, TO_CHAR(X.EL06_FSME_DATA, 'DD/MM/YY') AS EL06_FSME_DATA, X.EL06_FCES_AVN_REAL, X.EL06_FCES_AVN_POND, X.EL07_FCES_SIGLA, X.EL07_FCES_DESCRICAO, X.EL07_FCES_NIVEL, X.EL07_FCES_WBS, X.EL07_FCES_PESO_REL_CRON, X.EL07_FSME_AVANCO_ACM, X.EL07_FSME_QTD_ACM, TO_CHAR(X.EL07_FSME_DATA, 'DD/MM/YY') AS EL07_FSME_DATA, X.EL07_FCES_AVN_REAL, X.EL07_FCES_AVN_POND, X.EL08_FCES_SIGLA, X.EL08_FCES_DESCRICAO, X.EL08_FCES_NIVEL, X.EL08_FCES_WBS, X.EL08_FCES_PESO_REL_CRON, X.EL08_FSME_AVANCO_ACM, X.EL08_FSME_QTD_ACM, TO_CHAR(X.EL08_FSME_DATA, 'DD/MM/YY') AS EL08_FSME_DATA, X.EL08_FCES_AVN_REAL, X.EL08_FCES_AVN_POND, X.EL09_FCES_SIGLA, X.EL09_FCES_DESCRICAO, X.EL09_FCES_NIVEL, X.EL09_FCES_WBS, X.EL09_FCES_PESO_REL_CRON, X.EL09_FSME_AVANCO_ACM, X.EL09_FSME_QTD_ACM, TO_CHAR(X.EL09_FSME_DATA, 'DD/MM/YY') AS EL09_FSME_DATA, X.EL09_FCES_AVN_REAL, X.EL09_FCES_AVN_POND, X.EL10_FCES_SIGLA, X.EL10_FCES_DESCRICAO, X.EL10_FCES_NIVEL, X.EL10_FCES_WBS, X.EL10_FCES_PESO_REL_CRON, X.EL10_FSME_AVANCO_ACM, X.EL10_FSME_QTD_ACM, TO_CHAR(X.EL10_FSME_DATA, 'DD/MM/YY') AS EL10_FSME_DATA, X.EL10_FCES_AVN_REAL, X.EL10_FCES_AVN_POND, TO_CHAR(X.CREATED_DATE, 'DD/MM/YY') AS CREATED_DATE, TO_CHAR(X.DT_START, 'DD/MM/YY') AS DT_START, TO_CHAR(X.DT_END, 'DD/MM/YY') AS DT_END, X.SEMA_ID FROM EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE X ";
        //====================================================================
        public static int Insert(DTO.AcRamAtividadeStageDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE(FOSM_CNTR_CODIGO, FOSM_ID, SBCN_ID, SBCN_SIGLA, ATIV_ID, ATIV_SIG, ATIV_NOME, DISC_ID, DISC_NOME, UNME_ID, UNME_SIGLA, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_QTD_PREVISTA, FCME_ID, FCME_SIGLA, FCME_NOME, EL01_FCES_SIGLA, EL01_FCES_DESCRICAO, EL01_FCES_NIVEL, EL01_FCES_WBS, EL01_FCES_PESO_REL_CRON, EL01_FSME_AVANCO_ACM, EL01_FSME_QTD_ACM, EL01_FSME_DATA, EL01_FCES_AVN_REAL, EL01_FCES_AVN_POND, EL02_FCES_SIGLA, EL02_FCES_DESCRICAO, EL02_FCES_NIVEL, EL02_FCES_WBS, EL02_FCES_PESO_REL_CRON, EL02_FSME_AVANCO_ACM, EL02_FSME_QTD_ACM, EL02_FSME_DATA, EL02_FCES_AVN_REAL, EL02_FCES_AVN_POND, EL03_FCES_SIGLA, EL03_FCES_DESCRICAO, EL03_FCES_NIVEL, EL03_FCES_WBS, EL03_FCES_PESO_REL_CRON, EL03_FSME_AVANCO_ACM, EL03_FSME_QTD_ACM, EL03_FSME_DATA, EL03_FCES_AVN_REAL, EL03_FCES_AVN_POND, EL04_FCES_SIGLA, EL04_FCES_DESCRICAO, EL04_FCES_NIVEL, EL04_FCES_WBS, EL04_FCES_PESO_REL_CRON, EL04_FSME_AVANCO_ACM, EL04_FSME_QTD_ACM, EL04_FSME_DATA, EL04_FCES_AVN_REAL, EL04_FCES_AVN_POND, EL05_FCES_SIGLA, EL05_FCES_DESCRICAO, EL05_FCES_NIVEL, EL05_FCES_WBS, EL05_FCES_PESO_REL_CRON, EL05_FSME_AVANCO_ACM, EL05_FSME_QTD_ACM, EL05_FSME_DATA, EL05_FCES_AVN_REAL, EL05_FCES_AVN_POND, EL06_FCES_SIGLA, EL06_FCES_DESCRICAO, EL06_FCES_NIVEL, EL06_FCES_WBS, EL06_FCES_PESO_REL_CRON, EL06_FSME_AVANCO_ACM, EL06_FSME_QTD_ACM, EL06_FSME_DATA, EL06_FCES_AVN_REAL, EL06_FCES_AVN_POND, EL07_FCES_SIGLA, EL07_FCES_DESCRICAO, EL07_FCES_NIVEL, EL07_FCES_WBS, EL07_FCES_PESO_REL_CRON, EL07_FSME_AVANCO_ACM, EL07_FSME_QTD_ACM, EL07_FSME_DATA, EL07_FCES_AVN_REAL, EL07_FCES_AVN_POND, EL08_FCES_SIGLA, EL08_FCES_DESCRICAO, EL08_FCES_NIVEL, EL08_FCES_WBS, EL08_FCES_PESO_REL_CRON, EL08_FSME_AVANCO_ACM, EL08_FSME_QTD_ACM, EL08_FSME_DATA, EL08_FCES_AVN_REAL, EL08_FCES_AVN_POND, EL09_FCES_SIGLA, EL09_FCES_DESCRICAO, EL09_FCES_NIVEL, EL09_FCES_WBS, EL09_FCES_PESO_REL_CRON, EL09_FSME_AVANCO_ACM, EL09_FSME_QTD_ACM, EL09_FSME_DATA, EL09_FCES_AVN_REAL, EL09_FCES_AVN_POND, EL10_FCES_SIGLA, EL10_FCES_DESCRICAO, EL10_FCES_NIVEL, EL10_FCES_WBS, EL10_FCES_PESO_REL_CRON, EL10_FSME_AVANCO_ACM, EL10_FSME_QTD_ACM, EL10_FSME_DATA, EL10_FCES_AVN_REAL, EL10_FCES_AVN_POND, CREATED_DATE, DT_START, DT_END, SEMA_ID) VALUES(:FOSM_CNTR_CODIGO, :FOSM_ID, :SBCN_ID, :SBCN_SIGLA, :ATIV_ID, :ATIV_SIG, :ATIV_NOME, :DISC_ID, :DISC_NOME, :UNME_ID, :UNME_SIGLA, :FOSE_ID, :FOSE_NUMERO, :FOSE_REV, :FOSE_QTD_PREVISTA, :FCME_ID, :FCME_SIGLA, :FCME_NOME, :EL01_FCES_SIGLA, :EL01_FCES_DESCRICAO, :EL01_FCES_NIVEL, :EL01_FCES_WBS, :EL01_FCES_PESO_REL_CRON, :EL01_FSME_AVANCO_ACM, :EL01_FSME_QTD_ACM, :EL01_FSME_DATA, :EL01_FCES_AVN_REAL, :EL01_FCES_AVN_POND, :EL02_FCES_SIGLA, :EL02_FCES_DESCRICAO, :EL02_FCES_NIVEL, :EL02_FCES_WBS, :EL02_FCES_PESO_REL_CRON, :EL02_FSME_AVANCO_ACM, :EL02_FSME_QTD_ACM, :EL02_FSME_DATA, :EL02_FCES_AVN_REAL, :EL02_FCES_AVN_POND, :EL03_FCES_SIGLA, :EL03_FCES_DESCRICAO, :EL03_FCES_NIVEL, :EL03_FCES_WBS, :EL03_FCES_PESO_REL_CRON, :EL03_FSME_AVANCO_ACM, :EL03_FSME_QTD_ACM, :EL03_FSME_DATA, :EL03_FCES_AVN_REAL, :EL03_FCES_AVN_POND, :EL04_FCES_SIGLA, :EL04_FCES_DESCRICAO, :EL04_FCES_NIVEL, :EL04_FCES_WBS, :EL04_FCES_PESO_REL_CRON, :EL04_FSME_AVANCO_ACM, :EL04_FSME_QTD_ACM, :EL04_FSME_DATA, :EL04_FCES_AVN_REAL, :EL04_FCES_AVN_POND, :EL05_FCES_SIGLA, :EL05_FCES_DESCRICAO, :EL05_FCES_NIVEL, :EL05_FCES_WBS, :EL05_FCES_PESO_REL_CRON, :EL05_FSME_AVANCO_ACM, :EL05_FSME_QTD_ACM, :EL05_FSME_DATA, :EL05_FCES_AVN_REAL, :EL05_FCES_AVN_POND, :EL06_FCES_SIGLA, :EL06_FCES_DESCRICAO, :EL06_FCES_NIVEL, :EL06_FCES_WBS, :EL06_FCES_PESO_REL_CRON, :EL06_FSME_AVANCO_ACM, :EL06_FSME_QTD_ACM, :EL06_FSME_DATA, :EL06_FCES_AVN_REAL, :EL06_FCES_AVN_POND, :EL07_FCES_SIGLA, :EL07_FCES_DESCRICAO, :EL07_FCES_NIVEL, :EL07_FCES_WBS, :EL07_FCES_PESO_REL_CRON, :EL07_FSME_AVANCO_ACM, :EL07_FSME_QTD_ACM, :EL07_FSME_DATA, :EL07_FCES_AVN_REAL, :EL07_FCES_AVN_POND, :EL08_FCES_SIGLA, :EL08_FCES_DESCRICAO, :EL08_FCES_NIVEL, :EL08_FCES_WBS, :EL08_FCES_PESO_REL_CRON, :EL08_FSME_AVANCO_ACM, :EL08_FSME_QTD_ACM, :EL08_FSME_DATA, :EL08_FCES_AVN_REAL, :EL08_FCES_AVN_POND, :EL09_FCES_SIGLA, :EL09_FCES_DESCRICAO, :EL09_FCES_NIVEL, :EL09_FCES_WBS, :EL09_FCES_PESO_REL_CRON, :EL09_FSME_AVANCO_ACM, :EL09_FSME_QTD_ACM, :EL09_FSME_DATA, :EL09_FCES_AVN_REAL, :EL09_FCES_AVN_POND, :EL10_FCES_SIGLA, :EL10_FCES_DESCRICAO, :EL10_FCES_NIVEL, :EL10_FCES_WBS, :EL10_FCES_PESO_REL_CRON, :EL10_FSME_AVANCO_ACM, :EL10_FSME_QTD_ACM, :EL10_FSME_DATA, :EL10_FCES_AVN_REAL, :EL10_FCES_AVN_POND,  SYSDATE, :DT_START, :DT_END, :SEMA_ID)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FOSM_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FosmCntrCodigo;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":ATIV_ID", OracleDbType.Decimal).Value = entity.AtivId;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ATIV_NOME", OracleDbType.Varchar2).Value = entity.AtivNome;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":UNME_ID", OracleDbType.Decimal).Value = entity.UnmeId;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCME_NOME", OracleDbType.Varchar2).Value = entity.FcmeNome;
                
                cmd.Parameters.Add(":EL01_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El01FcesSigla;
                cmd.Parameters.Add(":EL01_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El01FcesDescricao;
                cmd.Parameters.Add(":EL01_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El01FcesNivel;
                cmd.Parameters.Add(":EL01_FCES_WBS", OracleDbType.Varchar2).Value = entity.El01FcesWbs;
                cmd.Parameters.Add(":EL01_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El01FcesPesoRelCron;
                cmd.Parameters.Add(":EL01_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El01FsmeAvancoAcm;
                cmd.Parameters.Add(":EL01_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El01FsmeQtdAcm;
                if (entity.El01FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                else cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                cmd.Parameters.Add(":EL01_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El01FcesAvnReal;
                cmd.Parameters.Add(":EL01_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El01FcesAvnPond;
                
                cmd.Parameters.Add(":EL02_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El02FcesSigla;
                cmd.Parameters.Add(":EL02_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El02FcesDescricao;
                cmd.Parameters.Add(":EL02_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El02FcesNivel;
                cmd.Parameters.Add(":EL02_FCES_WBS", OracleDbType.Varchar2).Value = entity.El02FcesWbs;
                cmd.Parameters.Add(":EL02_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El02FcesPesoRelCron;
                cmd.Parameters.Add(":EL02_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El02FsmeAvancoAcm;
                cmd.Parameters.Add(":EL02_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El02FsmeQtdAcm;
                if (entity.El02FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                else cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                cmd.Parameters.Add(":EL02_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El02FcesAvnReal;
                cmd.Parameters.Add(":EL02_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El02FcesAvnPond;
                
                cmd.Parameters.Add(":EL03_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El03FcesSigla;
                cmd.Parameters.Add(":EL03_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El03FcesDescricao;
                cmd.Parameters.Add(":EL03_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El03FcesNivel;
                cmd.Parameters.Add(":EL03_FCES_WBS", OracleDbType.Varchar2).Value = entity.El03FcesWbs;
                cmd.Parameters.Add(":EL03_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El03FcesPesoRelCron;
                cmd.Parameters.Add(":EL03_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El03FsmeAvancoAcm;
                cmd.Parameters.Add(":EL03_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El03FsmeQtdAcm;
                if (entity.El03FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                else cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                cmd.Parameters.Add(":EL03_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El03FcesAvnReal;
                cmd.Parameters.Add(":EL03_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El03FcesAvnPond;
                
                cmd.Parameters.Add(":EL04_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El04FcesSigla;
                cmd.Parameters.Add(":EL04_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El04FcesDescricao;
                cmd.Parameters.Add(":EL04_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El04FcesNivel;
                cmd.Parameters.Add(":EL04_FCES_WBS", OracleDbType.Varchar2).Value = entity.El04FcesWbs;
                cmd.Parameters.Add(":EL04_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El04FcesPesoRelCron;
                cmd.Parameters.Add(":EL04_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El04FsmeAvancoAcm;
                cmd.Parameters.Add(":EL04_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El04FsmeQtdAcm;
                if (entity.El04FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                else cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                cmd.Parameters.Add(":EL04_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El04FcesAvnReal;
                cmd.Parameters.Add(":EL04_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El04FcesAvnPond;
                
                cmd.Parameters.Add(":EL05_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El05FcesSigla;
                cmd.Parameters.Add(":EL05_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El05FcesDescricao;
                cmd.Parameters.Add(":EL05_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El05FcesNivel;
                cmd.Parameters.Add(":EL05_FCES_WBS", OracleDbType.Varchar2).Value = entity.El05FcesWbs;
                cmd.Parameters.Add(":EL05_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El05FcesPesoRelCron;
                cmd.Parameters.Add(":EL05_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El05FsmeAvancoAcm;
                cmd.Parameters.Add(":EL05_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El05FsmeQtdAcm;
                if (entity.El05FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                else cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                cmd.Parameters.Add(":EL05_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El05FcesAvnReal;
                cmd.Parameters.Add(":EL05_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El05FcesAvnPond;
                
                cmd.Parameters.Add(":EL06_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El06FcesSigla;
                cmd.Parameters.Add(":EL06_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El06FcesDescricao;
                cmd.Parameters.Add(":EL06_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El06FcesNivel;
                cmd.Parameters.Add(":EL06_FCES_WBS", OracleDbType.Varchar2).Value = entity.El06FcesWbs;
                cmd.Parameters.Add(":EL06_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El06FcesPesoRelCron;
                cmd.Parameters.Add(":EL06_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El06FsmeAvancoAcm;
                cmd.Parameters.Add(":EL06_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El06FsmeQtdAcm;
                if (entity.El06FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                else cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                cmd.Parameters.Add(":EL06_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El06FcesAvnReal;
                cmd.Parameters.Add(":EL06_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El06FcesAvnPond;
                
                cmd.Parameters.Add(":EL07_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El07FcesSigla;
                cmd.Parameters.Add(":EL07_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El07FcesDescricao;
                cmd.Parameters.Add(":EL07_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El07FcesNivel;
                cmd.Parameters.Add(":EL07_FCES_WBS", OracleDbType.Varchar2).Value = entity.El07FcesWbs;
                cmd.Parameters.Add(":EL07_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El07FcesPesoRelCron;
                cmd.Parameters.Add(":EL07_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El07FsmeAvancoAcm;
                cmd.Parameters.Add(":EL07_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El07FsmeQtdAcm;
                if (entity.El07FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                else cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                cmd.Parameters.Add(":EL07_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El07FcesAvnReal;
                cmd.Parameters.Add(":EL07_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El07FcesAvnPond;
                
                cmd.Parameters.Add(":EL08_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El08FcesSigla;
                cmd.Parameters.Add(":EL08_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El08FcesDescricao;
                cmd.Parameters.Add(":EL08_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El08FcesNivel;
                cmd.Parameters.Add(":EL08_FCES_WBS", OracleDbType.Varchar2).Value = entity.El08FcesWbs;
                cmd.Parameters.Add(":EL08_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El08FcesPesoRelCron;
                cmd.Parameters.Add(":EL08_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El08FsmeAvancoAcm;
                cmd.Parameters.Add(":EL08_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El08FsmeQtdAcm;
                if (entity.El08FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                else cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                cmd.Parameters.Add(":EL08_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El08FcesAvnReal;
                cmd.Parameters.Add(":EL08_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El08FcesAvnPond;
                
                cmd.Parameters.Add(":EL09_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El09FcesSigla;
                cmd.Parameters.Add(":EL09_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El09FcesDescricao;
                cmd.Parameters.Add(":EL09_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El09FcesNivel;
                cmd.Parameters.Add(":EL09_FCES_WBS", OracleDbType.Varchar2).Value = entity.El09FcesWbs;
                cmd.Parameters.Add(":EL09_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El09FcesPesoRelCron;
                cmd.Parameters.Add(":EL09_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El09FsmeAvancoAcm;
                cmd.Parameters.Add(":EL09_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El09FsmeQtdAcm;
                if (entity.El09FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                else cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                cmd.Parameters.Add(":EL09_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El09FcesAvnReal;
                cmd.Parameters.Add(":EL09_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El09FcesAvnPond;
                cmd.Parameters.Add(":EL10_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El10FcesSigla;
                
                cmd.Parameters.Add(":EL10_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El10FcesDescricao;
                cmd.Parameters.Add(":EL10_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El10FcesNivel;
                cmd.Parameters.Add(":EL10_FCES_WBS", OracleDbType.Varchar2).Value = entity.El10FcesWbs;
                cmd.Parameters.Add(":EL10_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El10FcesPesoRelCron;
                cmd.Parameters.Add(":EL10_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El10FsmeAvancoAcm;
                cmd.Parameters.Add(":EL10_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El10FsmeQtdAcm;
                if (entity.El10FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                else cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                cmd.Parameters.Add(":EL10_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El10FcesAvnReal;
                cmd.Parameters.Add(":EL10_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El10FcesAvnPond;
                
                //if (entity.CreatedDate.ToOADate() == 0.0) cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                //else cmd.Parameters.Add(":CREATED_DATE", OracleDbType.Date).Value = entity.CreatedDate;
                if (entity.DtStart.ToOADate() == 0.0) cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                else cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                if (entity.DtEnd.ToOADate() == 0.0) cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                else cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcRamAtividadeStage");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcRamAtividadeStage");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcRamAtividadeStageDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE set FOSM_CNTR_CODIGO = :FOSM_CNTR_CODIGO, FOSM_ID = :FOSM_ID, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, ATIV_ID = :ATIV_ID, ATIV_SIG = :ATIV_SIG, ATIV_NOME = :ATIV_NOME, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, UNME_ID = :UNME_ID, UNME_SIGLA = :UNME_SIGLA, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, FOSE_REV = :FOSE_REV, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, FCME_ID = :FCME_ID, FCME_SIGLA = :FCME_SIGLA, FCME_NOME = :FCME_NOME, EL01_FCES_SIGLA = :EL01_FCES_SIGLA, EL01_FCES_DESCRICAO = :EL01_FCES_DESCRICAO, EL01_FCES_NIVEL = :EL01_FCES_NIVEL, EL01_FCES_WBS = :EL01_FCES_WBS, EL01_FCES_PESO_REL_CRON = :EL01_FCES_PESO_REL_CRON, EL01_FSME_AVANCO_ACM = :EL01_FSME_AVANCO_ACM, EL01_FSME_QTD_ACM = :EL01_FSME_QTD_ACM, EL01_FSME_DATA = :EL01_FSME_DATA, EL01_FCES_AVN_REAL = :EL01_FCES_AVN_REAL, EL01_FCES_AVN_POND = :EL01_FCES_AVN_POND, EL02_FCES_SIGLA = :EL02_FCES_SIGLA, EL02_FCES_DESCRICAO = :EL02_FCES_DESCRICAO, EL02_FCES_NIVEL = :EL02_FCES_NIVEL, EL02_FCES_WBS = :EL02_FCES_WBS, EL02_FCES_PESO_REL_CRON = :EL02_FCES_PESO_REL_CRON, EL02_FSME_AVANCO_ACM = :EL02_FSME_AVANCO_ACM, EL02_FSME_QTD_ACM = :EL02_FSME_QTD_ACM, EL02_FSME_DATA = :EL02_FSME_DATA, EL02_FCES_AVN_REAL = :EL02_FCES_AVN_REAL, EL02_FCES_AVN_POND = :EL02_FCES_AVN_POND, EL03_FCES_SIGLA = :EL03_FCES_SIGLA, EL03_FCES_DESCRICAO = :EL03_FCES_DESCRICAO, EL03_FCES_NIVEL = :EL03_FCES_NIVEL, EL03_FCES_WBS = :EL03_FCES_WBS, EL03_FCES_PESO_REL_CRON = :EL03_FCES_PESO_REL_CRON, EL03_FSME_AVANCO_ACM = :EL03_FSME_AVANCO_ACM, EL03_FSME_QTD_ACM = :EL03_FSME_QTD_ACM, EL03_FSME_DATA = :EL03_FSME_DATA, EL03_FCES_AVN_REAL = :EL03_FCES_AVN_REAL, EL03_FCES_AVN_POND = :EL03_FCES_AVN_POND, EL04_FCES_SIGLA = :EL04_FCES_SIGLA, EL04_FCES_DESCRICAO = :EL04_FCES_DESCRICAO, EL04_FCES_NIVEL = :EL04_FCES_NIVEL, EL04_FCES_WBS = :EL04_FCES_WBS, EL04_FCES_PESO_REL_CRON = :EL04_FCES_PESO_REL_CRON, EL04_FSME_AVANCO_ACM = :EL04_FSME_AVANCO_ACM, EL04_FSME_QTD_ACM = :EL04_FSME_QTD_ACM, EL04_FSME_DATA = :EL04_FSME_DATA, EL04_FCES_AVN_REAL = :EL04_FCES_AVN_REAL, EL04_FCES_AVN_POND = :EL04_FCES_AVN_POND, EL05_FCES_SIGLA = :EL05_FCES_SIGLA, EL05_FCES_DESCRICAO = :EL05_FCES_DESCRICAO, EL05_FCES_NIVEL = :EL05_FCES_NIVEL, EL05_FCES_WBS = :EL05_FCES_WBS, EL05_FCES_PESO_REL_CRON = :EL05_FCES_PESO_REL_CRON, EL05_FSME_AVANCO_ACM = :EL05_FSME_AVANCO_ACM, EL05_FSME_QTD_ACM = :EL05_FSME_QTD_ACM, EL05_FSME_DATA = :EL05_FSME_DATA, EL05_FCES_AVN_REAL = :EL05_FCES_AVN_REAL, EL05_FCES_AVN_POND = :EL05_FCES_AVN_POND, EL06_FCES_SIGLA = :EL06_FCES_SIGLA, EL06_FCES_DESCRICAO = :EL06_FCES_DESCRICAO, EL06_FCES_NIVEL = :EL06_FCES_NIVEL, EL06_FCES_WBS = :EL06_FCES_WBS, EL06_FCES_PESO_REL_CRON = :EL06_FCES_PESO_REL_CRON, EL06_FSME_AVANCO_ACM = :EL06_FSME_AVANCO_ACM, EL06_FSME_QTD_ACM = :EL06_FSME_QTD_ACM, EL06_FSME_DATA = :EL06_FSME_DATA, EL06_FCES_AVN_REAL = :EL06_FCES_AVN_REAL, EL06_FCES_AVN_POND = :EL06_FCES_AVN_POND, EL07_FCES_SIGLA = :EL07_FCES_SIGLA, EL07_FCES_DESCRICAO = :EL07_FCES_DESCRICAO, EL07_FCES_NIVEL = :EL07_FCES_NIVEL, EL07_FCES_WBS = :EL07_FCES_WBS, EL07_FCES_PESO_REL_CRON = :EL07_FCES_PESO_REL_CRON, EL07_FSME_AVANCO_ACM = :EL07_FSME_AVANCO_ACM, EL07_FSME_QTD_ACM = :EL07_FSME_QTD_ACM, EL07_FSME_DATA = :EL07_FSME_DATA, EL07_FCES_AVN_REAL = :EL07_FCES_AVN_REAL, EL07_FCES_AVN_POND = :EL07_FCES_AVN_POND, EL08_FCES_SIGLA = :EL08_FCES_SIGLA, EL08_FCES_DESCRICAO = :EL08_FCES_DESCRICAO, EL08_FCES_NIVEL = :EL08_FCES_NIVEL, EL08_FCES_WBS = :EL08_FCES_WBS, EL08_FCES_PESO_REL_CRON = :EL08_FCES_PESO_REL_CRON, EL08_FSME_AVANCO_ACM = :EL08_FSME_AVANCO_ACM, EL08_FSME_QTD_ACM = :EL08_FSME_QTD_ACM, EL08_FSME_DATA = :EL08_FSME_DATA, EL08_FCES_AVN_REAL = :EL08_FCES_AVN_REAL, EL08_FCES_AVN_POND = :EL08_FCES_AVN_POND, EL09_FCES_SIGLA = :EL09_FCES_SIGLA, EL09_FCES_DESCRICAO = :EL09_FCES_DESCRICAO, EL09_FCES_NIVEL = :EL09_FCES_NIVEL, EL09_FCES_WBS = :EL09_FCES_WBS, EL09_FCES_PESO_REL_CRON = :EL09_FCES_PESO_REL_CRON, EL09_FSME_AVANCO_ACM = :EL09_FSME_AVANCO_ACM, EL09_FSME_QTD_ACM = :EL09_FSME_QTD_ACM, EL09_FSME_DATA = :EL09_FSME_DATA, EL09_FCES_AVN_REAL = :EL09_FCES_AVN_REAL, EL09_FCES_AVN_POND = :EL09_FCES_AVN_POND, EL10_FCES_SIGLA = :EL10_FCES_SIGLA, EL10_FCES_DESCRICAO = :EL10_FCES_DESCRICAO, EL10_FCES_NIVEL = :EL10_FCES_NIVEL, EL10_FCES_WBS = :EL10_FCES_WBS, EL10_FCES_PESO_REL_CRON = :EL10_FCES_PESO_REL_CRON, EL10_FSME_AVANCO_ACM = :EL10_FSME_AVANCO_ACM, EL10_FSME_QTD_ACM = :EL10_FSME_QTD_ACM, EL10_FSME_DATA = :EL10_FSME_DATA, EL10_FCES_AVN_REAL = :EL10_FCES_AVN_REAL, EL10_FCES_AVN_POND = :EL10_FCES_AVN_POND, DT_START = :DT_START, DT_END = :DT_END, SEMA_ID = :SEMA_ID WHERE  RAM_STAGE_ID = :RAM_STAGE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FOSM_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FosmCntrCodigo;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":ATIV_ID", OracleDbType.Decimal).Value = entity.AtivId;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ATIV_NOME", OracleDbType.Varchar2).Value = entity.AtivNome;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":UNME_ID", OracleDbType.Decimal).Value = entity.UnmeId;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCME_NOME", OracleDbType.Varchar2).Value = entity.FcmeNome;
                
                cmd.Parameters.Add(":EL01_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El01FcesSigla;
                cmd.Parameters.Add(":EL01_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El01FcesDescricao;
                cmd.Parameters.Add(":EL01_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El01FcesNivel;
                cmd.Parameters.Add(":EL01_FCES_WBS", OracleDbType.Varchar2).Value = entity.El01FcesWbs;
                cmd.Parameters.Add(":EL01_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El01FcesPesoRelCron;
                cmd.Parameters.Add(":EL01_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El01FsmeAvancoAcm;
                cmd.Parameters.Add(":EL01_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El01FsmeQtdAcm;
                if (entity.El01FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                else cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                cmd.Parameters.Add(":EL01_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El01FcesAvnReal;
                cmd.Parameters.Add(":EL01_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El01FcesAvnPond;
                
                cmd.Parameters.Add(":EL02_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El02FcesSigla;
                cmd.Parameters.Add(":EL02_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El02FcesDescricao;
                cmd.Parameters.Add(":EL02_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El02FcesNivel;
                cmd.Parameters.Add(":EL02_FCES_WBS", OracleDbType.Varchar2).Value = entity.El02FcesWbs;
                cmd.Parameters.Add(":EL02_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El02FcesPesoRelCron;
                cmd.Parameters.Add(":EL02_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El02FsmeAvancoAcm;
                cmd.Parameters.Add(":EL02_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El02FsmeQtdAcm;
                if (entity.El02FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                else cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                cmd.Parameters.Add(":EL02_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El02FcesAvnReal;
                cmd.Parameters.Add(":EL02_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El02FcesAvnPond;
                
                cmd.Parameters.Add(":EL03_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El03FcesSigla;
                cmd.Parameters.Add(":EL03_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El03FcesDescricao;
                cmd.Parameters.Add(":EL03_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El03FcesNivel;
                cmd.Parameters.Add(":EL03_FCES_WBS", OracleDbType.Varchar2).Value = entity.El03FcesWbs;
                cmd.Parameters.Add(":EL03_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El03FcesPesoRelCron;
                cmd.Parameters.Add(":EL03_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El03FsmeAvancoAcm;
                cmd.Parameters.Add(":EL03_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El03FsmeQtdAcm;
                if (entity.El03FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                else cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                cmd.Parameters.Add(":EL03_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El03FcesAvnReal;
                cmd.Parameters.Add(":EL03_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El03FcesAvnPond;
                
                cmd.Parameters.Add(":EL04_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El04FcesSigla;
                cmd.Parameters.Add(":EL04_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El04FcesDescricao;
                cmd.Parameters.Add(":EL04_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El04FcesNivel;
                cmd.Parameters.Add(":EL04_FCES_WBS", OracleDbType.Varchar2).Value = entity.El04FcesWbs;
                cmd.Parameters.Add(":EL04_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El04FcesPesoRelCron;
                cmd.Parameters.Add(":EL04_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El04FsmeAvancoAcm;
                cmd.Parameters.Add(":EL04_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El04FsmeQtdAcm;
                if (entity.El04FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                else cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                cmd.Parameters.Add(":EL04_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El04FcesAvnReal;
                cmd.Parameters.Add(":EL04_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El04FcesAvnPond;
                
                cmd.Parameters.Add(":EL05_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El05FcesSigla;
                cmd.Parameters.Add(":EL05_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El05FcesDescricao;
                cmd.Parameters.Add(":EL05_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El05FcesNivel;
                cmd.Parameters.Add(":EL05_FCES_WBS", OracleDbType.Varchar2).Value = entity.El05FcesWbs;
                cmd.Parameters.Add(":EL05_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El05FcesPesoRelCron;
                cmd.Parameters.Add(":EL05_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El05FsmeAvancoAcm;
                cmd.Parameters.Add(":EL05_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El05FsmeQtdAcm;
                if (entity.El05FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                else cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                cmd.Parameters.Add(":EL05_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El05FcesAvnReal;
                cmd.Parameters.Add(":EL05_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El05FcesAvnPond;
                
                cmd.Parameters.Add(":EL06_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El06FcesSigla;
                cmd.Parameters.Add(":EL06_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El06FcesDescricao;
                cmd.Parameters.Add(":EL06_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El06FcesNivel;
                cmd.Parameters.Add(":EL06_FCES_WBS", OracleDbType.Varchar2).Value = entity.El06FcesWbs;
                cmd.Parameters.Add(":EL06_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El06FcesPesoRelCron;
                cmd.Parameters.Add(":EL06_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El06FsmeAvancoAcm;
                cmd.Parameters.Add(":EL06_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El06FsmeQtdAcm;
                if (entity.El06FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                else cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                cmd.Parameters.Add(":EL06_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El06FcesAvnReal;
                cmd.Parameters.Add(":EL06_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El06FcesAvnPond;
                
                cmd.Parameters.Add(":EL07_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El07FcesSigla;
                cmd.Parameters.Add(":EL07_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El07FcesDescricao;
                cmd.Parameters.Add(":EL07_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El07FcesNivel;
                cmd.Parameters.Add(":EL07_FCES_WBS", OracleDbType.Varchar2).Value = entity.El07FcesWbs;
                cmd.Parameters.Add(":EL07_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El07FcesPesoRelCron;
                cmd.Parameters.Add(":EL07_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El07FsmeAvancoAcm;
                cmd.Parameters.Add(":EL07_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El07FsmeQtdAcm;
                if (entity.El07FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                else cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                cmd.Parameters.Add(":EL07_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El07FcesAvnReal;
                cmd.Parameters.Add(":EL07_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El07FcesAvnPond;
                
                cmd.Parameters.Add(":EL08_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El08FcesSigla;
                cmd.Parameters.Add(":EL08_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El08FcesDescricao;
                cmd.Parameters.Add(":EL08_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El08FcesNivel;
                cmd.Parameters.Add(":EL08_FCES_WBS", OracleDbType.Varchar2).Value = entity.El08FcesWbs;
                cmd.Parameters.Add(":EL08_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El08FcesPesoRelCron;
                cmd.Parameters.Add(":EL08_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El08FsmeAvancoAcm;
                cmd.Parameters.Add(":EL08_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El08FsmeQtdAcm;
                if (entity.El08FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                else cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                cmd.Parameters.Add(":EL08_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El08FcesAvnReal;
                cmd.Parameters.Add(":EL08_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El08FcesAvnPond;
                
                cmd.Parameters.Add(":EL09_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El09FcesSigla;
                cmd.Parameters.Add(":EL09_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El09FcesDescricao;
                cmd.Parameters.Add(":EL09_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El09FcesNivel;
                cmd.Parameters.Add(":EL09_FCES_WBS", OracleDbType.Varchar2).Value = entity.El09FcesWbs;
                cmd.Parameters.Add(":EL09_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El09FcesPesoRelCron;
                cmd.Parameters.Add(":EL09_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El09FsmeAvancoAcm;
                cmd.Parameters.Add(":EL09_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El09FsmeQtdAcm;
                if (entity.El09FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                else cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                cmd.Parameters.Add(":EL09_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El09FcesAvnReal;
                cmd.Parameters.Add(":EL09_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El09FcesAvnPond;
                
                cmd.Parameters.Add(":EL10_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El10FcesSigla;
                cmd.Parameters.Add(":EL10_FCES_DESCRICAO", OracleDbType.Varchar2).Value = entity.El10FcesDescricao;
                cmd.Parameters.Add(":EL10_FCES_NIVEL", OracleDbType.Decimal).Value = entity.El10FcesNivel;
                cmd.Parameters.Add(":EL10_FCES_WBS", OracleDbType.Varchar2).Value = entity.El10FcesWbs;
                cmd.Parameters.Add(":EL10_FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.El10FcesPesoRelCron;
                cmd.Parameters.Add(":EL10_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El10FsmeAvancoAcm;
                cmd.Parameters.Add(":EL10_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El10FsmeQtdAcm;
                if (entity.El10FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                else cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                cmd.Parameters.Add(":EL10_FCES_AVN_REAL", OracleDbType.Decimal).Value = entity.El10FcesAvnReal;
                cmd.Parameters.Add(":EL10_FCES_AVN_POND", OracleDbType.Decimal).Value = entity.El10FcesAvnPond;
                

                if (entity.DtStart.ToOADate() == 0.0) cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                else cmd.Parameters.Add(":DT_START", OracleDbType.Date).Value = entity.DtStart;
                if (entity.DtEnd.ToOADate() == 0.0) cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                else cmd.Parameters.Add(":DT_END", OracleDbType.Date).Value = entity.DtEnd;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":RAM_STAGE_ID_ID", OracleDbType.Decimal).Value = entity.RamStageId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcRamAtividadeStage"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal RamStageId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE WHERE  RAM_STAGE_ID = :RAM_STAGE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":RamStageId", OracleDbType.Decimal).Value = RamStageId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcRamAtividadeStage"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRamAtividadeStage"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRamAtividadeStage"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRamAtividadeStage"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRamAtividadeStage"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcRamAtividadeStage"); }
        }
        //====================================================================
        public static DTO.AcRamAtividadeStageDTO Get(decimal RamStageId)
        {
            AcRamAtividadeStageDTO entity = new AcRamAtividadeStageDTO();
            DataTable dt = null;
            string filter = "RAM_STAGE_ID = " + RamStageId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["RAM_STAGE_ID"] != null) && (dt.Rows[0]["RAM_STAGE_ID"] != DBNull.Value)) entity.RamStageId = Convert.ToDecimal(dt.Rows[0]["RAM_STAGE_ID"]);
            if ((dt.Rows[0]["FOSM_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSM_CNTR_CODIGO"] != DBNull.Value)) entity.FosmCntrCodigo = Convert.ToString(dt.Rows[0]["FOSM_CNTR_CODIGO"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["ATIV_ID"] != null) && (dt.Rows[0]["ATIV_ID"] != DBNull.Value)) entity.AtivId = Convert.ToDecimal(dt.Rows[0]["ATIV_ID"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["ATIV_NOME"] != null) && (dt.Rows[0]["ATIV_NOME"] != DBNull.Value)) entity.AtivNome = Convert.ToString(dt.Rows[0]["ATIV_NOME"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["UNME_ID"] != null) && (dt.Rows[0]["UNME_ID"] != DBNull.Value)) entity.UnmeId = Convert.ToDecimal(dt.Rows[0]["UNME_ID"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_REV"] != null) && (dt.Rows[0]["FOSE_REV"] != DBNull.Value)) entity.FoseRev = Convert.ToString(dt.Rows[0]["FOSE_REV"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToDecimal(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCME_NOME"] != null) && (dt.Rows[0]["FCME_NOME"] != DBNull.Value)) entity.FcmeNome = Convert.ToString(dt.Rows[0]["FCME_NOME"]);
            
            if ((dt.Rows[0]["EL01_FCES_SIGLA"] != null) && (dt.Rows[0]["EL01_FCES_SIGLA"] != DBNull.Value)) entity.El01FcesSigla = Convert.ToString(dt.Rows[0]["EL01_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL01_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL01_FCES_DESCRICAO"] != DBNull.Value)) entity.El01FcesDescricao = Convert.ToString(dt.Rows[0]["EL01_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL01_FCES_NIVEL"] != null) && (dt.Rows[0]["EL01_FCES_NIVEL"] != DBNull.Value)) entity.El01FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL01_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL01_FCES_WBS"] != null) && (dt.Rows[0]["EL01_FCES_WBS"] != DBNull.Value)) entity.El01FcesWbs = Convert.ToString(dt.Rows[0]["EL01_FCES_WBS"]);
            if ((dt.Rows[0]["EL01_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL01_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El01FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL01_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL01_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL01_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El01FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL01_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL01_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL01_FSME_QTD_ACM"] != DBNull.Value)) entity.El01FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL01_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL01_FSME_DATA"] != null) && (dt.Rows[0]["EL01_FSME_DATA"] != DBNull.Value)) entity.El01FsmeData = Convert.ToDateTime(dt.Rows[0]["EL01_FSME_DATA"]);
            if ((dt.Rows[0]["EL01_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL01_FCES_AVN_REAL"] != DBNull.Value)) entity.El01FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL01_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL01_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL01_FCES_AVN_POND"] != DBNull.Value)) entity.El01FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL01_FCES_AVN_POND"]);
            if ((dt.Rows[0]["EL02_FCES_SIGLA"] != null) && (dt.Rows[0]["EL02_FCES_SIGLA"] != DBNull.Value)) entity.El02FcesSigla = Convert.ToString(dt.Rows[0]["EL02_FCES_SIGLA"]);
            
            if ((dt.Rows[0]["EL02_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL02_FCES_DESCRICAO"] != DBNull.Value)) entity.El02FcesDescricao = Convert.ToString(dt.Rows[0]["EL02_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL02_FCES_NIVEL"] != null) && (dt.Rows[0]["EL02_FCES_NIVEL"] != DBNull.Value)) entity.El02FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL02_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL02_FCES_WBS"] != null) && (dt.Rows[0]["EL02_FCES_WBS"] != DBNull.Value)) entity.El02FcesWbs = Convert.ToString(dt.Rows[0]["EL02_FCES_WBS"]);
            if ((dt.Rows[0]["EL02_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL02_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El02FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL02_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL02_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL02_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El02FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL02_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL02_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL02_FSME_QTD_ACM"] != DBNull.Value)) entity.El02FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL02_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL02_FSME_DATA"] != null) && (dt.Rows[0]["EL02_FSME_DATA"] != DBNull.Value)) entity.El02FsmeData = Convert.ToDateTime(dt.Rows[0]["EL02_FSME_DATA"]);
            if ((dt.Rows[0]["EL02_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL02_FCES_AVN_REAL"] != DBNull.Value)) entity.El02FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL02_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL02_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL02_FCES_AVN_POND"] != DBNull.Value)) entity.El02FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL02_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL03_FCES_SIGLA"] != null) && (dt.Rows[0]["EL03_FCES_SIGLA"] != DBNull.Value)) entity.El03FcesSigla = Convert.ToString(dt.Rows[0]["EL03_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL03_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL03_FCES_DESCRICAO"] != DBNull.Value)) entity.El03FcesDescricao = Convert.ToString(dt.Rows[0]["EL03_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL03_FCES_NIVEL"] != null) && (dt.Rows[0]["EL03_FCES_NIVEL"] != DBNull.Value)) entity.El03FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL03_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL03_FCES_WBS"] != null) && (dt.Rows[0]["EL03_FCES_WBS"] != DBNull.Value)) entity.El03FcesWbs = Convert.ToString(dt.Rows[0]["EL03_FCES_WBS"]);
            if ((dt.Rows[0]["EL03_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL03_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El03FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL03_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL03_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL03_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El03FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL03_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL03_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL03_FSME_QTD_ACM"] != DBNull.Value)) entity.El03FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL03_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL03_FSME_DATA"] != null) && (dt.Rows[0]["EL03_FSME_DATA"] != DBNull.Value)) entity.El03FsmeData = Convert.ToDateTime(dt.Rows[0]["EL03_FSME_DATA"]);
            if ((dt.Rows[0]["EL03_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL03_FCES_AVN_REAL"] != DBNull.Value)) entity.El03FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL03_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL03_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL03_FCES_AVN_POND"] != DBNull.Value)) entity.El03FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL03_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL04_FCES_SIGLA"] != null) && (dt.Rows[0]["EL04_FCES_SIGLA"] != DBNull.Value)) entity.El04FcesSigla = Convert.ToString(dt.Rows[0]["EL04_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL04_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL04_FCES_DESCRICAO"] != DBNull.Value)) entity.El04FcesDescricao = Convert.ToString(dt.Rows[0]["EL04_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL04_FCES_NIVEL"] != null) && (dt.Rows[0]["EL04_FCES_NIVEL"] != DBNull.Value)) entity.El04FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL04_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL04_FCES_WBS"] != null) && (dt.Rows[0]["EL04_FCES_WBS"] != DBNull.Value)) entity.El04FcesWbs = Convert.ToString(dt.Rows[0]["EL04_FCES_WBS"]);
            if ((dt.Rows[0]["EL04_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL04_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El04FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL04_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL04_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL04_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El04FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL04_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL04_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL04_FSME_QTD_ACM"] != DBNull.Value)) entity.El04FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL04_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL04_FSME_DATA"] != null) && (dt.Rows[0]["EL04_FSME_DATA"] != DBNull.Value)) entity.El04FsmeData = Convert.ToDateTime(dt.Rows[0]["EL04_FSME_DATA"]);
            if ((dt.Rows[0]["EL04_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL04_FCES_AVN_REAL"] != DBNull.Value)) entity.El04FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL04_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL04_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL04_FCES_AVN_POND"] != DBNull.Value)) entity.El04FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL04_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL05_FCES_SIGLA"] != null) && (dt.Rows[0]["EL05_FCES_SIGLA"] != DBNull.Value)) entity.El05FcesSigla = Convert.ToString(dt.Rows[0]["EL05_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL05_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL05_FCES_DESCRICAO"] != DBNull.Value)) entity.El05FcesDescricao = Convert.ToString(dt.Rows[0]["EL05_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL05_FCES_NIVEL"] != null) && (dt.Rows[0]["EL05_FCES_NIVEL"] != DBNull.Value)) entity.El05FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL05_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL05_FCES_WBS"] != null) && (dt.Rows[0]["EL05_FCES_WBS"] != DBNull.Value)) entity.El05FcesWbs = Convert.ToString(dt.Rows[0]["EL05_FCES_WBS"]);
            if ((dt.Rows[0]["EL05_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL05_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El05FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL05_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL05_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL05_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El05FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL05_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL05_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL05_FSME_QTD_ACM"] != DBNull.Value)) entity.El05FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL05_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL05_FSME_DATA"] != null) && (dt.Rows[0]["EL05_FSME_DATA"] != DBNull.Value)) entity.El05FsmeData = Convert.ToDateTime(dt.Rows[0]["EL05_FSME_DATA"]);
            if ((dt.Rows[0]["EL05_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL05_FCES_AVN_REAL"] != DBNull.Value)) entity.El05FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL05_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL05_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL05_FCES_AVN_POND"] != DBNull.Value)) entity.El05FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL05_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL06_FCES_SIGLA"] != null) && (dt.Rows[0]["EL06_FCES_SIGLA"] != DBNull.Value)) entity.El06FcesSigla = Convert.ToString(dt.Rows[0]["EL06_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL06_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL06_FCES_DESCRICAO"] != DBNull.Value)) entity.El06FcesDescricao = Convert.ToString(dt.Rows[0]["EL06_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL06_FCES_NIVEL"] != null) && (dt.Rows[0]["EL06_FCES_NIVEL"] != DBNull.Value)) entity.El06FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL06_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL06_FCES_WBS"] != null) && (dt.Rows[0]["EL06_FCES_WBS"] != DBNull.Value)) entity.El06FcesWbs = Convert.ToString(dt.Rows[0]["EL06_FCES_WBS"]);
            if ((dt.Rows[0]["EL06_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL06_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El06FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL06_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL06_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL06_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El06FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL06_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL06_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL06_FSME_QTD_ACM"] != DBNull.Value)) entity.El06FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL06_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL06_FSME_DATA"] != null) && (dt.Rows[0]["EL06_FSME_DATA"] != DBNull.Value)) entity.El06FsmeData = Convert.ToDateTime(dt.Rows[0]["EL06_FSME_DATA"]);
            if ((dt.Rows[0]["EL06_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL06_FCES_AVN_REAL"] != DBNull.Value)) entity.El06FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL06_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL06_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL06_FCES_AVN_POND"] != DBNull.Value)) entity.El06FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL06_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL07_FCES_SIGLA"] != null) && (dt.Rows[0]["EL07_FCES_SIGLA"] != DBNull.Value)) entity.El07FcesSigla = Convert.ToString(dt.Rows[0]["EL07_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL07_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL07_FCES_DESCRICAO"] != DBNull.Value)) entity.El07FcesDescricao = Convert.ToString(dt.Rows[0]["EL07_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL07_FCES_NIVEL"] != null) && (dt.Rows[0]["EL07_FCES_NIVEL"] != DBNull.Value)) entity.El07FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL07_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL07_FCES_WBS"] != null) && (dt.Rows[0]["EL07_FCES_WBS"] != DBNull.Value)) entity.El07FcesWbs = Convert.ToString(dt.Rows[0]["EL07_FCES_WBS"]);
            if ((dt.Rows[0]["EL07_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL07_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El07FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL07_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL07_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL07_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El07FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL07_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL07_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL07_FSME_QTD_ACM"] != DBNull.Value)) entity.El07FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL07_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL07_FSME_DATA"] != null) && (dt.Rows[0]["EL07_FSME_DATA"] != DBNull.Value)) entity.El07FsmeData = Convert.ToDateTime(dt.Rows[0]["EL07_FSME_DATA"]);
            if ((dt.Rows[0]["EL07_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL07_FCES_AVN_REAL"] != DBNull.Value)) entity.El07FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL07_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL07_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL07_FCES_AVN_POND"] != DBNull.Value)) entity.El07FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL07_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL08_FCES_SIGLA"] != null) && (dt.Rows[0]["EL08_FCES_SIGLA"] != DBNull.Value)) entity.El08FcesSigla = Convert.ToString(dt.Rows[0]["EL08_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL08_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL08_FCES_DESCRICAO"] != DBNull.Value)) entity.El08FcesDescricao = Convert.ToString(dt.Rows[0]["EL08_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL08_FCES_NIVEL"] != null) && (dt.Rows[0]["EL08_FCES_NIVEL"] != DBNull.Value)) entity.El08FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL08_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL08_FCES_WBS"] != null) && (dt.Rows[0]["EL08_FCES_WBS"] != DBNull.Value)) entity.El08FcesWbs = Convert.ToString(dt.Rows[0]["EL08_FCES_WBS"]);
            if ((dt.Rows[0]["EL08_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL08_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El08FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL08_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL08_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL08_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El08FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL08_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL08_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL08_FSME_QTD_ACM"] != DBNull.Value)) entity.El08FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL08_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL08_FSME_DATA"] != null) && (dt.Rows[0]["EL08_FSME_DATA"] != DBNull.Value)) entity.El08FsmeData = Convert.ToDateTime(dt.Rows[0]["EL08_FSME_DATA"]);
            if ((dt.Rows[0]["EL08_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL08_FCES_AVN_REAL"] != DBNull.Value)) entity.El08FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL08_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL08_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL08_FCES_AVN_POND"] != DBNull.Value)) entity.El08FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL08_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL09_FCES_SIGLA"] != null) && (dt.Rows[0]["EL09_FCES_SIGLA"] != DBNull.Value)) entity.El09FcesSigla = Convert.ToString(dt.Rows[0]["EL09_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL09_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL09_FCES_DESCRICAO"] != DBNull.Value)) entity.El09FcesDescricao = Convert.ToString(dt.Rows[0]["EL09_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL09_FCES_NIVEL"] != null) && (dt.Rows[0]["EL09_FCES_NIVEL"] != DBNull.Value)) entity.El09FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL09_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL09_FCES_WBS"] != null) && (dt.Rows[0]["EL09_FCES_WBS"] != DBNull.Value)) entity.El09FcesWbs = Convert.ToString(dt.Rows[0]["EL09_FCES_WBS"]);
            if ((dt.Rows[0]["EL09_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL09_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El09FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL09_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL09_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL09_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El09FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL09_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL09_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL09_FSME_QTD_ACM"] != DBNull.Value)) entity.El09FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL09_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL09_FSME_DATA"] != null) && (dt.Rows[0]["EL09_FSME_DATA"] != DBNull.Value)) entity.El09FsmeData = Convert.ToDateTime(dt.Rows[0]["EL09_FSME_DATA"]);
            if ((dt.Rows[0]["EL09_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL09_FCES_AVN_REAL"] != DBNull.Value)) entity.El09FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL09_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL09_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL09_FCES_AVN_POND"] != DBNull.Value)) entity.El09FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL09_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["EL10_FCES_SIGLA"] != null) && (dt.Rows[0]["EL10_FCES_SIGLA"] != DBNull.Value)) entity.El10FcesSigla = Convert.ToString(dt.Rows[0]["EL10_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL10_FCES_DESCRICAO"] != null) && (dt.Rows[0]["EL10_FCES_DESCRICAO"] != DBNull.Value)) entity.El10FcesDescricao = Convert.ToString(dt.Rows[0]["EL10_FCES_DESCRICAO"]);
            if ((dt.Rows[0]["EL10_FCES_NIVEL"] != null) && (dt.Rows[0]["EL10_FCES_NIVEL"] != DBNull.Value)) entity.El10FcesNivel = Convert.ToDecimal(dt.Rows[0]["EL10_FCES_NIVEL"]);
            if ((dt.Rows[0]["EL10_FCES_WBS"] != null) && (dt.Rows[0]["EL10_FCES_WBS"] != DBNull.Value)) entity.El10FcesWbs = Convert.ToString(dt.Rows[0]["EL10_FCES_WBS"]);
            if ((dt.Rows[0]["EL10_FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["EL10_FCES_PESO_REL_CRON"] != DBNull.Value)) entity.El10FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["EL10_FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["EL10_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL10_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El10FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL10_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL10_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL10_FSME_QTD_ACM"] != DBNull.Value)) entity.El10FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL10_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL10_FSME_DATA"] != null) && (dt.Rows[0]["EL10_FSME_DATA"] != DBNull.Value)) entity.El10FsmeData = Convert.ToDateTime(dt.Rows[0]["EL10_FSME_DATA"]);
            if ((dt.Rows[0]["EL10_FCES_AVN_REAL"] != null) && (dt.Rows[0]["EL10_FCES_AVN_REAL"] != DBNull.Value)) entity.El10FcesAvnReal = Convert.ToDecimal(dt.Rows[0]["EL10_FCES_AVN_REAL"]);
            if ((dt.Rows[0]["EL10_FCES_AVN_POND"] != null) && (dt.Rows[0]["EL10_FCES_AVN_POND"] != DBNull.Value)) entity.El10FcesAvnPond = Convert.ToDecimal(dt.Rows[0]["EL10_FCES_AVN_POND"]);
            
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            if ((dt.Rows[0]["DT_START"] != null) && (dt.Rows[0]["DT_START"] != DBNull.Value)) entity.DtStart = Convert.ToDateTime(dt.Rows[0]["DT_START"]);
            if ((dt.Rows[0]["DT_END"] != null) && (dt.Rows[0]["DT_END"] != DBNull.Value)) entity.DtEnd = Convert.ToDateTime(dt.Rows[0]["DT_END"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcRamAtividadeStageDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SEMA_ID Object"); }
        }
        //====================================================================
        public static List<AcRamAtividadeStageDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcRamAtividadeStageDTO> list = OracleDataTools.LoadEntity<AcRamAtividadeStageDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeStageDTO>"); }
        }
        //====================================================================
        public static List<AcRamAtividadeStageDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeStageDTO>"); }
        }
        //====================================================================
        public static List<AcRamAtividadeStageDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRamAtividadeStageDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcRamAtividadeStageDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcRamAtividadeStage"); }
        }
        //====================================================================
        public static DTO.CollectionAcRamAtividadeStageDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcRamAtividadeStageDTO collection = new DTO.CollectionAcRamAtividadeStageDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcRamAtividadeStageDTO entity = new DTO.AcRamAtividadeStageDTO();
                    if (dt.Rows[i]["RAM_STAGE_ID"].ToString().Length != 0) entity.RamStageId = Convert.ToDecimal(dt.Rows[i]["RAM_STAGE_ID"]);
                    if (dt.Rows[i]["FOSM_CNTR_CODIGO"].ToString().Length != 0) entity.FosmCntrCodigo = dt.Rows[i]["FOSM_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["ATIV_ID"].ToString().Length != 0) entity.AtivId = Convert.ToDecimal(dt.Rows[i]["ATIV_ID"]);
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = dt.Rows[i]["ATIV_SIG"].ToString();
                    if (dt.Rows[i]["ATIV_NOME"].ToString().Length != 0) entity.AtivNome = dt.Rows[i]["ATIV_NOME"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["UNME_ID"].ToString().Length != 0) entity.UnmeId = Convert.ToDecimal(dt.Rows[i]["UNME_ID"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSE_REV"].ToString().Length != 0) entity.FoseRev = dt.Rows[i]["FOSE_REV"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToDecimal(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCME_NOME"].ToString().Length != 0) entity.FcmeNome = dt.Rows[i]["FCME_NOME"].ToString();
                    
                    if (dt.Rows[i]["EL01_FCES_SIGLA"].ToString().Length != 0) entity.El01FcesSigla = dt.Rows[i]["EL01_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL01_FCES_DESCRICAO"].ToString().Length != 0) entity.El01FcesDescricao = dt.Rows[i]["EL01_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL01_FCES_NIVEL"].ToString().Length != 0) entity.El01FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL01_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL01_FCES_WBS"].ToString().Length != 0) entity.El01FcesWbs = dt.Rows[i]["EL01_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL01_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El01FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL01_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL01_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El01FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL01_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL01_FSME_QTD_ACM"].ToString().Length != 0) entity.El01FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL01_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL01_FSME_DATA"].ToString().Length != 0) entity.El01FsmeData = Convert.ToDateTime(dt.Rows[i]["EL01_FSME_DATA"]);
                    if (dt.Rows[i]["EL01_FCES_AVN_REAL"].ToString().Length != 0) entity.El01FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL01_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL01_FCES_AVN_POND"].ToString().Length != 0) entity.El01FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL01_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL02_FCES_SIGLA"].ToString().Length != 0) entity.El02FcesSigla = dt.Rows[i]["EL02_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL02_FCES_DESCRICAO"].ToString().Length != 0) entity.El02FcesDescricao = dt.Rows[i]["EL02_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL02_FCES_NIVEL"].ToString().Length != 0) entity.El02FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL02_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL02_FCES_WBS"].ToString().Length != 0) entity.El02FcesWbs = dt.Rows[i]["EL02_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL02_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El02FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL02_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL02_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El02FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL02_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL02_FSME_QTD_ACM"].ToString().Length != 0) entity.El02FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL02_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL02_FSME_DATA"].ToString().Length != 0) entity.El02FsmeData = Convert.ToDateTime(dt.Rows[i]["EL02_FSME_DATA"]);
                    if (dt.Rows[i]["EL02_FCES_AVN_REAL"].ToString().Length != 0) entity.El02FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL02_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL02_FCES_AVN_POND"].ToString().Length != 0) entity.El02FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL02_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL03_FCES_SIGLA"].ToString().Length != 0) entity.El03FcesSigla = dt.Rows[i]["EL03_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL03_FCES_DESCRICAO"].ToString().Length != 0) entity.El03FcesDescricao = dt.Rows[i]["EL03_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL03_FCES_NIVEL"].ToString().Length != 0) entity.El03FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL03_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL03_FCES_WBS"].ToString().Length != 0) entity.El03FcesWbs = dt.Rows[i]["EL03_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL03_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El03FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL03_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL03_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El03FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL03_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL03_FSME_QTD_ACM"].ToString().Length != 0) entity.El03FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL03_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL03_FSME_DATA"].ToString().Length != 0) entity.El03FsmeData = Convert.ToDateTime(dt.Rows[i]["EL03_FSME_DATA"]);
                    if (dt.Rows[i]["EL03_FCES_AVN_REAL"].ToString().Length != 0) entity.El03FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL03_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL03_FCES_AVN_POND"].ToString().Length != 0) entity.El03FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL03_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL04_FCES_SIGLA"].ToString().Length != 0) entity.El04FcesSigla = dt.Rows[i]["EL04_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL04_FCES_DESCRICAO"].ToString().Length != 0) entity.El04FcesDescricao = dt.Rows[i]["EL04_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL04_FCES_NIVEL"].ToString().Length != 0) entity.El04FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL04_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL04_FCES_WBS"].ToString().Length != 0) entity.El04FcesWbs = dt.Rows[i]["EL04_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL04_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El04FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL04_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL04_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El04FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL04_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL04_FSME_QTD_ACM"].ToString().Length != 0) entity.El04FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL04_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL04_FSME_DATA"].ToString().Length != 0) entity.El04FsmeData = Convert.ToDateTime(dt.Rows[i]["EL04_FSME_DATA"]);
                    if (dt.Rows[i]["EL04_FCES_AVN_REAL"].ToString().Length != 0) entity.El04FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL04_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL04_FCES_AVN_POND"].ToString().Length != 0) entity.El04FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL04_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL05_FCES_SIGLA"].ToString().Length != 0) entity.El05FcesSigla = dt.Rows[i]["EL05_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL05_FCES_DESCRICAO"].ToString().Length != 0) entity.El05FcesDescricao = dt.Rows[i]["EL05_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL05_FCES_NIVEL"].ToString().Length != 0) entity.El05FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL05_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL05_FCES_WBS"].ToString().Length != 0) entity.El05FcesWbs = dt.Rows[i]["EL05_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL05_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El05FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL05_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL05_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El05FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL05_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL05_FSME_QTD_ACM"].ToString().Length != 0) entity.El05FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL05_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL05_FSME_DATA"].ToString().Length != 0) entity.El05FsmeData = Convert.ToDateTime(dt.Rows[i]["EL05_FSME_DATA"]);
                    if (dt.Rows[i]["EL05_FCES_AVN_REAL"].ToString().Length != 0) entity.El05FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL05_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL05_FCES_AVN_POND"].ToString().Length != 0) entity.El05FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL05_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL06_FCES_SIGLA"].ToString().Length != 0) entity.El06FcesSigla = dt.Rows[i]["EL06_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL06_FCES_DESCRICAO"].ToString().Length != 0) entity.El06FcesDescricao = dt.Rows[i]["EL06_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL06_FCES_NIVEL"].ToString().Length != 0) entity.El06FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL06_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL06_FCES_WBS"].ToString().Length != 0) entity.El06FcesWbs = dt.Rows[i]["EL06_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL06_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El06FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL06_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL06_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El06FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL06_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL06_FSME_QTD_ACM"].ToString().Length != 0) entity.El06FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL06_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL06_FSME_DATA"].ToString().Length != 0) entity.El06FsmeData = Convert.ToDateTime(dt.Rows[i]["EL06_FSME_DATA"]);
                    if (dt.Rows[i]["EL06_FCES_AVN_REAL"].ToString().Length != 0) entity.El06FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL06_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL06_FCES_AVN_POND"].ToString().Length != 0) entity.El06FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL06_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL07_FCES_SIGLA"].ToString().Length != 0) entity.El07FcesSigla = dt.Rows[i]["EL07_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL07_FCES_DESCRICAO"].ToString().Length != 0) entity.El07FcesDescricao = dt.Rows[i]["EL07_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL07_FCES_NIVEL"].ToString().Length != 0) entity.El07FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL07_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL07_FCES_WBS"].ToString().Length != 0) entity.El07FcesWbs = dt.Rows[i]["EL07_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL07_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El07FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL07_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL07_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El07FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL07_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL07_FSME_QTD_ACM"].ToString().Length != 0) entity.El07FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL07_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL07_FSME_DATA"].ToString().Length != 0) entity.El07FsmeData = Convert.ToDateTime(dt.Rows[i]["EL07_FSME_DATA"]);
                    if (dt.Rows[i]["EL07_FCES_AVN_REAL"].ToString().Length != 0) entity.El07FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL07_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL07_FCES_AVN_POND"].ToString().Length != 0) entity.El07FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL07_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL08_FCES_SIGLA"].ToString().Length != 0) entity.El08FcesSigla = dt.Rows[i]["EL08_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL08_FCES_DESCRICAO"].ToString().Length != 0) entity.El08FcesDescricao = dt.Rows[i]["EL08_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL08_FCES_NIVEL"].ToString().Length != 0) entity.El08FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL08_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL08_FCES_WBS"].ToString().Length != 0) entity.El08FcesWbs = dt.Rows[i]["EL08_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL08_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El08FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL08_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL08_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El08FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL08_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL08_FSME_QTD_ACM"].ToString().Length != 0) entity.El08FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL08_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL08_FSME_DATA"].ToString().Length != 0) entity.El08FsmeData = Convert.ToDateTime(dt.Rows[i]["EL08_FSME_DATA"]);
                    if (dt.Rows[i]["EL08_FCES_AVN_REAL"].ToString().Length != 0) entity.El08FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL08_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL08_FCES_AVN_POND"].ToString().Length != 0) entity.El08FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL08_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL09_FCES_SIGLA"].ToString().Length != 0) entity.El09FcesSigla = dt.Rows[i]["EL09_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL09_FCES_DESCRICAO"].ToString().Length != 0) entity.El09FcesDescricao = dt.Rows[i]["EL09_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL09_FCES_NIVEL"].ToString().Length != 0) entity.El09FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL09_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL09_FCES_WBS"].ToString().Length != 0) entity.El09FcesWbs = dt.Rows[i]["EL09_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL09_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El09FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL09_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL09_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El09FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL09_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL09_FSME_QTD_ACM"].ToString().Length != 0) entity.El09FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL09_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL09_FSME_DATA"].ToString().Length != 0) entity.El09FsmeData = Convert.ToDateTime(dt.Rows[i]["EL09_FSME_DATA"]);
                    if (dt.Rows[i]["EL09_FCES_AVN_REAL"].ToString().Length != 0) entity.El09FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL09_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL09_FCES_AVN_POND"].ToString().Length != 0) entity.El09FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL09_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["EL10_FCES_SIGLA"].ToString().Length != 0) entity.El10FcesSigla = dt.Rows[i]["EL10_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL10_FCES_DESCRICAO"].ToString().Length != 0) entity.El10FcesDescricao = dt.Rows[i]["EL10_FCES_DESCRICAO"].ToString();
                    if (dt.Rows[i]["EL10_FCES_NIVEL"].ToString().Length != 0) entity.El10FcesNivel = Convert.ToDecimal(dt.Rows[i]["EL10_FCES_NIVEL"]);
                    if (dt.Rows[i]["EL10_FCES_WBS"].ToString().Length != 0) entity.El10FcesWbs = dt.Rows[i]["EL10_FCES_WBS"].ToString();
                    if (dt.Rows[i]["EL10_FCES_PESO_REL_CRON"].ToString().Length != 0) entity.El10FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["EL10_FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["EL10_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El10FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL10_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL10_FSME_QTD_ACM"].ToString().Length != 0) entity.El10FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL10_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL10_FSME_DATA"].ToString().Length != 0) entity.El10FsmeData = Convert.ToDateTime(dt.Rows[i]["EL10_FSME_DATA"]);
                    if (dt.Rows[i]["EL10_FCES_AVN_REAL"].ToString().Length != 0) entity.El10FcesAvnReal = Convert.ToDecimal(dt.Rows[i]["EL10_FCES_AVN_REAL"]);
                    if (dt.Rows[i]["EL10_FCES_AVN_POND"].ToString().Length != 0) entity.El10FcesAvnPond = Convert.ToDecimal(dt.Rows[i]["EL10_FCES_AVN_POND"]);
                    
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);
                    if (dt.Rows[i]["DT_START"].ToString().Length != 0) entity.DtStart = Convert.ToDateTime(dt.Rows[i]["DT_START"]);
                    if (dt.Rows[i]["DT_END"].ToString().Length != 0) entity.DtEnd = Convert.ToDateTime(dt.Rows[i]["DT_END"]);
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);

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
            dict.Add("RamStageId", "RAM_STAGE_ID");
            dict.Add("FosmCntrCodigo", "FOSM_CNTR_CODIGO");
            dict.Add("FosmId", "FOSM_ID");
            dict.Add("SbcnId", "SBCN_ID");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("AtivId", "ATIV_ID");
            dict.Add("AtivSig", "ATIV_SIG");
            dict.Add("AtivNome", "ATIV_NOME");
            dict.Add("DiscId", "DISC_ID");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("UnmeId", "UNME_ID");
            dict.Add("UnmeSigla", "UNME_SIGLA");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FoseRev", "FOSE_REV");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("FcmeId", "FCME_ID");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcmeNome", "FCME_NOME");
            dict.Add("El01FcesSigla", "EL01_FCES_SIGLA");
            dict.Add("El01FcesDescricao", "EL01_FCES_DESCRICAO");
            dict.Add("El01FcesNivel", "EL01_FCES_NIVEL");
            dict.Add("El01FcesWbs", "EL01_FCES_WBS");
            dict.Add("El01FcesPesoRelCron", "EL01_FCES_PESO_REL_CRON");
            dict.Add("El01FsmeAvancoAcm", "EL01_FSME_AVANCO_ACM");
            dict.Add("El01FsmeQtdAcm", "EL01_FSME_QTD_ACM");
            dict.Add("El01FsmeData", "EL01_FSME_DATA");
            dict.Add("El01FcesAvnReal", "EL01_FCES_AVN_REAL");
            dict.Add("El01FcesAvnPond", "EL01_FCES_AVN_POND");
            dict.Add("El02FcesSigla", "EL02_FCES_SIGLA");
            dict.Add("El02FcesDescricao", "EL02_FCES_DESCRICAO");
            dict.Add("El02FcesNivel", "EL02_FCES_NIVEL");
            dict.Add("El02FcesWbs", "EL02_FCES_WBS");
            dict.Add("El02FcesPesoRelCron", "EL02_FCES_PESO_REL_CRON");
            dict.Add("El02FsmeAvancoAcm", "EL02_FSME_AVANCO_ACM");
            dict.Add("El02FsmeQtdAcm", "EL02_FSME_QTD_ACM");
            dict.Add("El02FsmeData", "EL02_FSME_DATA");
            dict.Add("El02FcesAvnReal", "EL02_FCES_AVN_REAL");
            dict.Add("El02FcesAvnPond", "EL02_FCES_AVN_POND");
            dict.Add("El03FcesSigla", "EL03_FCES_SIGLA");
            dict.Add("El03FcesDescricao", "EL03_FCES_DESCRICAO");
            dict.Add("El03FcesNivel", "EL03_FCES_NIVEL");
            dict.Add("El03FcesWbs", "EL03_FCES_WBS");
            dict.Add("El03FcesPesoRelCron", "EL03_FCES_PESO_REL_CRON");
            dict.Add("El03FsmeAvancoAcm", "EL03_FSME_AVANCO_ACM");
            dict.Add("El03FsmeQtdAcm", "EL03_FSME_QTD_ACM");
            dict.Add("El03FsmeData", "EL03_FSME_DATA");
            dict.Add("El03FcesAvnReal", "EL03_FCES_AVN_REAL");
            dict.Add("El03FcesAvnPond", "EL03_FCES_AVN_POND");
            dict.Add("El04FcesSigla", "EL04_FCES_SIGLA");
            dict.Add("El04FcesDescricao", "EL04_FCES_DESCRICAO");
            dict.Add("El04FcesNivel", "EL04_FCES_NIVEL");
            dict.Add("El04FcesWbs", "EL04_FCES_WBS");
            dict.Add("El04FcesPesoRelCron", "EL04_FCES_PESO_REL_CRON");
            dict.Add("El04FsmeAvancoAcm", "EL04_FSME_AVANCO_ACM");
            dict.Add("El04FsmeQtdAcm", "EL04_FSME_QTD_ACM");
            dict.Add("El04FsmeData", "EL04_FSME_DATA");
            dict.Add("El04FcesAvnReal", "EL04_FCES_AVN_REAL");
            dict.Add("El04FcesAvnPond", "EL04_FCES_AVN_POND");
            dict.Add("El05FcesSigla", "EL05_FCES_SIGLA");
            dict.Add("El05FcesDescricao", "EL05_FCES_DESCRICAO");
            dict.Add("El05FcesNivel", "EL05_FCES_NIVEL");
            dict.Add("El05FcesWbs", "EL05_FCES_WBS");
            dict.Add("El05FcesPesoRelCron", "EL05_FCES_PESO_REL_CRON");
            dict.Add("El05FsmeAvancoAcm", "EL05_FSME_AVANCO_ACM");
            dict.Add("El05FsmeQtdAcm", "EL05_FSME_QTD_ACM");
            dict.Add("El05FsmeData", "EL05_FSME_DATA");
            dict.Add("El05FcesAvnReal", "EL05_FCES_AVN_REAL");
            dict.Add("El05FcesAvnPond", "EL05_FCES_AVN_POND");
            dict.Add("El06FcesSigla", "EL06_FCES_SIGLA");
            dict.Add("El06FcesDescricao", "EL06_FCES_DESCRICAO");
            dict.Add("El06FcesNivel", "EL06_FCES_NIVEL");
            dict.Add("El06FcesWbs", "EL06_FCES_WBS");
            dict.Add("El06FcesPesoRelCron", "EL06_FCES_PESO_REL_CRON");
            dict.Add("El06FsmeAvancoAcm", "EL06_FSME_AVANCO_ACM");
            dict.Add("El06FsmeQtdAcm", "EL06_FSME_QTD_ACM");
            dict.Add("El06FsmeData", "EL06_FSME_DATA");
            dict.Add("El06FcesAvnReal", "EL06_FCES_AVN_REAL");
            dict.Add("El06FcesAvnPond", "EL06_FCES_AVN_POND");
            dict.Add("El07FcesSigla", "EL07_FCES_SIGLA");
            dict.Add("El07FcesDescricao", "EL07_FCES_DESCRICAO");
            dict.Add("El07FcesNivel", "EL07_FCES_NIVEL");
            dict.Add("El07FcesWbs", "EL07_FCES_WBS");
            dict.Add("El07FcesPesoRelCron", "EL07_FCES_PESO_REL_CRON");
            dict.Add("El07FsmeAvancoAcm", "EL07_FSME_AVANCO_ACM");
            dict.Add("El07FsmeQtdAcm", "EL07_FSME_QTD_ACM");
            dict.Add("El07FsmeData", "EL07_FSME_DATA");
            dict.Add("El07FcesAvnReal", "EL07_FCES_AVN_REAL");
            dict.Add("El07FcesAvnPond", "EL07_FCES_AVN_POND");
            dict.Add("El08FcesSigla", "EL08_FCES_SIGLA");
            dict.Add("El08FcesDescricao", "EL08_FCES_DESCRICAO");
            dict.Add("El08FcesNivel", "EL08_FCES_NIVEL");
            dict.Add("El08FcesWbs", "EL08_FCES_WBS");
            dict.Add("El08FcesPesoRelCron", "EL08_FCES_PESO_REL_CRON");
            dict.Add("El08FsmeAvancoAcm", "EL08_FSME_AVANCO_ACM");
            dict.Add("El08FsmeQtdAcm", "EL08_FSME_QTD_ACM");
            dict.Add("El08FsmeData", "EL08_FSME_DATA");
            dict.Add("El08FcesAvnReal", "EL08_FCES_AVN_REAL");
            dict.Add("El08FcesAvnPond", "EL08_FCES_AVN_POND");
            dict.Add("El09FcesSigla", "EL09_FCES_SIGLA");
            dict.Add("El09FcesDescricao", "EL09_FCES_DESCRICAO");
            dict.Add("El09FcesNivel", "EL09_FCES_NIVEL");
            dict.Add("El09FcesWbs", "EL09_FCES_WBS");
            dict.Add("El09FcesPesoRelCron", "EL09_FCES_PESO_REL_CRON");
            dict.Add("El09FsmeAvancoAcm", "EL09_FSME_AVANCO_ACM");
            dict.Add("El09FsmeQtdAcm", "EL09_FSME_QTD_ACM");
            dict.Add("El09FsmeData", "EL09_FSME_DATA");
            dict.Add("El09FcesAvnReal", "EL09_FCES_AVN_REAL");
            dict.Add("El09FcesAvnPond", "EL09_FCES_AVN_POND");
            dict.Add("El10FcesSigla", "EL10_FCES_SIGLA");
            dict.Add("El10FcesDescricao", "EL10_FCES_DESCRICAO");
            dict.Add("El10FcesNivel", "EL10_FCES_NIVEL");
            dict.Add("El10FcesWbs", "EL10_FCES_WBS");
            dict.Add("El10FcesPesoRelCron", "EL10_FCES_PESO_REL_CRON");
            dict.Add("El10FsmeAvancoAcm", "EL10_FSME_AVANCO_ACM");
            dict.Add("El10FsmeQtdAcm", "EL10_FSME_QTD_ACM");
            dict.Add("El10FsmeData", "EL10_FSME_DATA");
            dict.Add("El10FcesAvnReal", "EL10_FCES_AVN_REAL");
            dict.Add("El10FcesAvnPond", "EL10_FCES_AVN_POND");
            dict.Add("CreatedDate", "CREATED_DATE");
            dict.Add("DtStart", "DT_START");
            dict.Add("DtEnd", "DT_END");
            dict.Add("SemaId", "SEMA_ID");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
