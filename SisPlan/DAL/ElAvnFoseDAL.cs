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
    public class ElAvnFoseDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT 
                                            X.ID, X.ACTIVE, X.FOSE_CNTR_CODIGO, X.SBCN_SIGLA, X.DISC_NOME, X.SIFS_DESCRICAO, 
                                            X.ATIV_SIG, X.ARAP_NOME, X.UNPR_NOME, X.TIPO_LINHA, 
                                            X.FOSE_NUMERO, X.FCME_SIGLA, X.FCES_NIVEL, X.PASTA, X.DESENHO, X.TIPO, X.SETOR, X.FOSE_QTD_PREVISTA, X.UNME_SIGLA, 
                                            X.EL01_FCES_SIGLA, TO_CHAR(X.EL01_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL01_FSMP_DATA, TO_CHAR(X.EL01_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL01_FSME_DATA, X.EL01_FSME_QTD_ACM, X.EL01_FSME_AVANCO_ACM, 
                                            X.EL02_FCES_SIGLA, TO_CHAR(X.EL02_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL02_FSMP_DATA, TO_CHAR(X.EL02_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL02_FSME_DATA, X.EL02_FSME_QTD_ACM, X.EL02_FSME_AVANCO_ACM, 
                                            X.EL03_FCES_SIGLA, TO_CHAR(X.EL03_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL03_FSMP_DATA, TO_CHAR(X.EL03_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL03_FSME_DATA, X.EL03_FSME_QTD_ACM, X.EL03_FSME_AVANCO_ACM, 
                                            X.EL04_FCES_SIGLA, TO_CHAR(X.EL04_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL04_FSMP_DATA, TO_CHAR(X.EL04_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL04_FSME_DATA, X.EL04_FSME_QTD_ACM, X.EL04_FSME_AVANCO_ACM, 
                                            X.EL05_FCES_SIGLA, TO_CHAR(X.EL05_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL05_FSMP_DATA, TO_CHAR(X.EL05_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL05_FSME_DATA, X.EL05_FSME_QTD_ACM, X.EL05_FSME_AVANCO_ACM, 
                                            X.EL06_FCES_SIGLA, TO_CHAR(X.EL06_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL06_FSMP_DATA, TO_CHAR(X.EL06_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL06_FSME_DATA, X.EL06_FSME_QTD_ACM, X.EL06_FSME_AVANCO_ACM, 
                                            X.EL07_FCES_SIGLA, TO_CHAR(X.EL07_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL07_FSMP_DATA, TO_CHAR(X.EL07_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL07_FSME_DATA, X.EL07_FSME_QTD_ACM, X.EL07_FSME_AVANCO_ACM, 
                                            X.EL08_FCES_SIGLA, TO_CHAR(X.EL08_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL08_FSMP_DATA, TO_CHAR(X.EL08_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL08_FSME_DATA, X.EL08_FSME_QTD_ACM, X.EL08_FSME_AVANCO_ACM, 
                                            X.EL09_FCES_SIGLA, TO_CHAR(X.EL09_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL09_FSMP_DATA, TO_CHAR(X.EL09_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL09_FSME_DATA, X.EL09_FSME_QTD_ACM, X.EL09_FSME_AVANCO_ACM, 
                                            X.EL10_FCES_SIGLA, TO_CHAR(X.EL10_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL10_FSMP_DATA, TO_CHAR(X.EL10_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL10_FSME_DATA, X.EL10_FSME_QTD_ACM, X.EL10_FSME_AVANCO_ACM, 
                                            X.EL11_FCES_SIGLA, TO_CHAR(X.EL11_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL11_FSMP_DATA, TO_CHAR(X.EL11_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL11_FSME_DATA, X.EL11_FSME_QTD_ACM, X.EL11_FSME_AVANCO_ACM, 
                                            X.EL12_FCES_SIGLA, TO_CHAR(X.EL12_FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL12_FSMP_DATA, TO_CHAR(X.EL12_FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS EL12_FSME_DATA, X.EL12_FSME_QTD_ACM, X.EL12_FSME_AVANCO_ACM, 

                                            X.DISC_ID, X.FOSE_ID, X.FOSM_ID, X.FCME_ID, 
                                            TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE FROM EEP_CONVERSION.EL_AVN_FOSE X ";
        //====================================================================
        public static int Insert(DTO.ElAvnFoseDTO entity, bool getIdentity)
        {
            string strSQL = @"INSERT INTO EEP_CONVERSION.EL_AVN_FOSE
                                            (
                                            ID,ACTIVE,FOSE_CNTR_CODIGO,SBCN_SIGLA,DISC_NOME,SIFS_DESCRICAO,
                                            ATIV_SIG,ARAP_NOME,UNPR_NOME,TIPO_LINHA,
                                            FOSE_NUMERO,FCME_SIGLA,FCES_NIVEL,PASTA,DESENHO,TIPO,SETOR,FOSE_QTD_PREVISTA,UNME_SIGLA,
                                            EL01_FCES_SIGLA,EL01_FSMP_DATA,EL01_FSME_DATA,EL01_FSME_QTD_ACM,EL01_FSME_AVANCO_ACM,
                                            EL02_FCES_SIGLA,EL02_FSMP_DATA,EL02_FSME_DATA,EL02_FSME_QTD_ACM,EL02_FSME_AVANCO_ACM,
                                            EL03_FCES_SIGLA,EL03_FSMP_DATA,EL03_FSME_DATA,EL03_FSME_QTD_ACM,EL03_FSME_AVANCO_ACM,
                                            EL04_FCES_SIGLA,EL04_FSMP_DATA,EL04_FSME_DATA,EL04_FSME_QTD_ACM,EL04_FSME_AVANCO_ACM,
                                            EL05_FCES_SIGLA,EL05_FSMP_DATA,EL05_FSME_DATA,EL05_FSME_QTD_ACM,EL05_FSME_AVANCO_ACM,
                                            EL06_FCES_SIGLA,EL06_FSMP_DATA,EL06_FSME_DATA,EL06_FSME_QTD_ACM,EL06_FSME_AVANCO_ACM,
                                            EL07_FCES_SIGLA,EL07_FSMP_DATA,EL07_FSME_DATA,EL07_FSME_QTD_ACM,EL07_FSME_AVANCO_ACM,
                                            EL08_FCES_SIGLA,EL08_FSMP_DATA,EL08_FSME_DATA,EL08_FSME_QTD_ACM,EL08_FSME_AVANCO_ACM,
                                            EL09_FCES_SIGLA,EL09_FSMP_DATA,EL09_FSME_DATA,EL09_FSME_QTD_ACM,EL09_FSME_AVANCO_ACM,
                                            EL10_FCES_SIGLA,EL10_FSMP_DATA,EL10_FSME_DATA,EL10_FSME_QTD_ACM,EL10_FSME_AVANCO_ACM,
                                            EL11_FCES_SIGLA,EL11_FSMP_DATA,EL11_FSME_DATA,EL11_FSME_QTD_ACM,EL11_FSME_AVANCO_ACM,
                                            EL12_FCES_SIGLA,EL12_FSMP_DATA,EL12_FSME_DATA,EL12_FSME_QTD_ACM,EL12_FSME_AVANCO_ACM,
                                            DISC_ID,FOSE_ID,FOSM_ID,FCME_ID,
                                            CREATED_DATE
                                            ) VALUES(:ID,:ACTIVE,:FOSE_CNTR_CODIGO,:SBCN_SIGLA,:DISC_NOME,:SIFS_DESCRICAO,:ATIV_SIG,:ARAP_NOME,:UNPR_NOME,:TIPO_LINHA,
                                            :FOSE_NUMERO,:FCME_SIGLA,:FCES_NIVEL,:PASTA,:DESENHO,:TIPO,:SETOR,:FOSE_QTD_PREVISTA,:UNME_SIGLA,
                                            :EL01_FCES_SIGLA,:EL01_FSMP_DATA,:EL01_FSME_DATA,:EL01_FSME_QTD_ACM,:EL01_FSME_AVANCO_ACM,
                                            :EL02_FCES_SIGLA,:EL02_FSMP_DATA,:EL02_FSME_DATA,:EL02_FSME_QTD_ACM,:EL02_FSME_AVANCO_ACM,
                                            :EL03_FCES_SIGLA,:EL03_FSMP_DATA,:EL03_FSME_DATA,:EL03_FSME_QTD_ACM,:EL03_FSME_AVANCO_ACM,
                                            :EL04_FCES_SIGLA,:EL04_FSMP_DATA,:EL04_FSME_DATA,:EL04_FSME_QTD_ACM,:EL04_FSME_AVANCO_ACM,
                                            :EL05_FCES_SIGLA,:EL05_FSMP_DATA,:EL05_FSME_DATA,:EL05_FSME_QTD_ACM,:EL05_FSME_AVANCO_ACM,
                                            :EL06_FCES_SIGLA,:EL06_FSMP_DATA,:EL06_FSME_DATA,:EL06_FSME_QTD_ACM,:EL06_FSME_AVANCO_ACM,
                                            :EL07_FCES_SIGLA,:EL07_FSMP_DATA,:EL07_FSME_DATA,:EL07_FSME_QTD_ACM,:EL07_FSME_AVANCO_ACM,
                                            :EL08_FCES_SIGLA,:EL08_FSMP_DATA,:EL08_FSME_DATA,:EL08_FSME_QTD_ACM,:EL08_FSME_AVANCO_ACM,
                                            :EL09_FCES_SIGLA,:EL09_FSMP_DATA,:EL09_FSME_DATA,:EL09_FSME_QTD_ACM,:EL09_FSME_AVANCO_ACM,
                                            :EL10_FCES_SIGLA,:EL10_FSMP_DATA,:EL10_FSME_DATA,:EL10_FSME_QTD_ACM,:EL10_FSME_AVANCO_ACM,
                                            :EL11_FCES_SIGLA,:EL11_FSMP_DATA,:EL11_FSME_DATA,:EL11_FSME_QTD_ACM,:EL11_FSME_AVANCO_ACM,
                                            :EL12_FCES_SIGLA,:EL12_FSMP_DATA,:EL12_FSME_DATA,:EL12_FSME_QTD_ACM,:EL12_FSME_AVANCO_ACM,
                                            :DISC_ID,:FOSE_ID,:FOSM_ID,:FCME_ID, 
                                            SYSDATE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;
                cmd.Parameters.Add(":ACTIVE", OracleDbType.Decimal).Value = entity.Active;
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ARAP_NOME", OracleDbType.Varchar2).Value = entity.ArapNome;
                cmd.Parameters.Add(":UNPR_NOME", OracleDbType.Varchar2).Value = entity.UnprNome;
                cmd.Parameters.Add(":TIPO_LINHA", OracleDbType.Decimal).Value = entity.TipoLinha;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_NIVEL", OracleDbType.Decimal).Value = entity.FcesNivel;
                cmd.Parameters.Add(":PASTA", OracleDbType.Varchar2).Value = entity.Pasta;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":TIPO", OracleDbType.Varchar2).Value = entity.Tipo;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                
                cmd.Parameters.Add(":EL01_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El01FcesSigla;
                if (entity.El01FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL01_FSMP_DATA", OracleDbType.Date).Value = entity.El01FsmpData;
                if (entity.El01FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                cmd.Parameters.Add(":EL01_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El01FsmeQtdAcm;
                cmd.Parameters.Add(":EL01_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El01FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL02_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El02FcesSigla;
                if (entity.El02FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL02_FSMP_DATA", OracleDbType.Date).Value = entity.El02FsmpData;
                if (entity.El02FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                cmd.Parameters.Add(":EL02_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El02FsmeQtdAcm;
                cmd.Parameters.Add(":EL02_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El02FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL03_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El03FcesSigla;
                if (entity.El03FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL03_FSMP_DATA", OracleDbType.Date).Value = entity.El03FsmpData;
                if (entity.El03FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                cmd.Parameters.Add(":EL03_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El03FsmeQtdAcm;
                cmd.Parameters.Add(":EL03_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El03FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL04_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El04FcesSigla;
                if (entity.El04FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL04_FSMP_DATA", OracleDbType.Date).Value = entity.El04FsmpData;
                if (entity.El04FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                cmd.Parameters.Add(":EL04_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El04FsmeQtdAcm;
                cmd.Parameters.Add(":EL04_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El04FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL05_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El05FcesSigla;
                if (entity.El05FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL05_FSMP_DATA", OracleDbType.Date).Value = entity.El05FsmpData;
                if (entity.El05FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                cmd.Parameters.Add(":EL05_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El05FsmeQtdAcm;
                cmd.Parameters.Add(":EL05_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El05FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL06_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El06FcesSigla;
                if (entity.El06FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL06_FSMP_DATA", OracleDbType.Date).Value = entity.El06FsmpData;
                if (entity.El06FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                cmd.Parameters.Add(":EL06_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El06FsmeQtdAcm;
                cmd.Parameters.Add(":EL06_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El06FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL07_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El07FcesSigla;
                if (entity.El07FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL07_FSMP_DATA", OracleDbType.Date).Value = entity.El07FsmpData;
                if (entity.El07FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                cmd.Parameters.Add(":EL07_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El07FsmeQtdAcm;
                cmd.Parameters.Add(":EL07_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El07FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL08_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El08FcesSigla;
                if (entity.El08FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL08_FSMP_DATA", OracleDbType.Date).Value = entity.El08FsmpData;
                if (entity.El08FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                cmd.Parameters.Add(":EL08_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El08FsmeQtdAcm;
                cmd.Parameters.Add(":EL08_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El08FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL09_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El09FcesSigla;
                if (entity.El09FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL09_FSMP_DATA", OracleDbType.Date).Value = entity.El09FsmpData;
                if (entity.El09FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                cmd.Parameters.Add(":EL09_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El09FsmeQtdAcm;
                cmd.Parameters.Add(":EL09_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El09FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL10_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El10FcesSigla;
                if (entity.El10FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL10_FSMP_DATA", OracleDbType.Date).Value = entity.El10FsmpData;
                if (entity.El10FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                cmd.Parameters.Add(":EL10_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El10FsmeQtdAcm;
                cmd.Parameters.Add(":EL10_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El10FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL11_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El11FcesSigla;
                if (entity.El11FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL11_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL11_FSMP_DATA", OracleDbType.Date).Value = entity.El11FsmpData;
                if (entity.El11FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL11_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL11_FSME_DATA", OracleDbType.Date).Value = entity.El11FsmeData;
                cmd.Parameters.Add(":EL11_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El11FsmeQtdAcm;
                cmd.Parameters.Add(":EL11_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El11FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL12_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El12FcesSigla;
                if (entity.El12FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL12_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL12_FSMP_DATA", OracleDbType.Date).Value = entity.El12FsmpData;
                if (entity.El12FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL12_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL12_FSME_DATA", OracleDbType.Date).Value = entity.El12FsmeData;
                cmd.Parameters.Add(":EL12_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El12FsmeQtdAcm;
                cmd.Parameters.Add(":EL12_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El12FsmeAvancoAcm;
                
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ElAvnFose");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ElAvnFose");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ElAvnFoseDTO entity)
        {
            string strSQL = @"UPDATE EEP_CONVERSION.EL_AVN_FOSE SET 
                                            ACTIVE = :ACTIVE, FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SBCN_SIGLA = :SBCN_SIGLA, DISC_NOME = :DISC_NOME, SIFS_DESCRICAO = :SIFS_DESCRICAO, 
                                            ATIV_SIG = :ATIV_SIG, ARAP_NOME = :ARAP_NOME, UNPR_NOME = :UNPR_NOME, TIPO_LINHA = :TIPO_LINHA, 
                                            FOSE_NUMERO = :FOSE_NUMERO, FCME_SIGLA = :FCME_SIGLA, FCES_NIVEL = :FCES_NIVEL, PASTA = :PASTA, DESENHO = :DESENHO, TIPO = :TIPO, SETOR = :SETOR, 
                                            FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, UNME_SIGLA = :UNME_SIGLA, 
                                            EL01_FCES_SIGLA = :EL01_FCES_SIGLA, EL01_FSMP_DATA = :EL01_FSMP_DATA, EL01_FSME_DATA = :EL01_FSME_DATA, EL01_FSME_QTD_ACM = :EL01_FSME_QTD_ACM, EL01_FSME_AVANCO_ACM = :EL01_FSME_AVANCO_ACM, 
                                            EL02_FCES_SIGLA = :EL02_FCES_SIGLA, EL02_FSMP_DATA = :EL02_FSMP_DATA, EL02_FSME_DATA = :EL02_FSME_DATA, EL02_FSME_QTD_ACM = :EL02_FSME_QTD_ACM, EL02_FSME_AVANCO_ACM = :EL02_FSME_AVANCO_ACM, 
                                            EL03_FCES_SIGLA = :EL03_FCES_SIGLA, EL03_FSMP_DATA = :EL03_FSMP_DATA, EL03_FSME_DATA = :EL03_FSME_DATA, EL03_FSME_QTD_ACM = :EL03_FSME_QTD_ACM, EL03_FSME_AVANCO_ACM = :EL03_FSME_AVANCO_ACM, 
                                            EL04_FCES_SIGLA = :EL04_FCES_SIGLA, EL04_FSMP_DATA = :EL04_FSMP_DATA, EL04_FSME_DATA = :EL04_FSME_DATA, EL04_FSME_QTD_ACM = :EL04_FSME_QTD_ACM, EL04_FSME_AVANCO_ACM = :EL04_FSME_AVANCO_ACM, 
                                            EL05_FCES_SIGLA = :EL05_FCES_SIGLA, EL05_FSMP_DATA = :EL05_FSMP_DATA, EL05_FSME_DATA = :EL05_FSME_DATA, EL05_FSME_QTD_ACM = :EL05_FSME_QTD_ACM, EL05_FSME_AVANCO_ACM = :EL05_FSME_AVANCO_ACM, 
                                            EL06_FCES_SIGLA = :EL06_FCES_SIGLA, EL06_FSMP_DATA = :EL06_FSMP_DATA, EL06_FSME_DATA = :EL06_FSME_DATA, EL06_FSME_QTD_ACM = :EL06_FSME_QTD_ACM, EL06_FSME_AVANCO_ACM = :EL06_FSME_AVANCO_ACM, 
                                            EL07_FCES_SIGLA = :EL07_FCES_SIGLA, EL07_FSMP_DATA = :EL07_FSMP_DATA, EL07_FSME_DATA = :EL07_FSME_DATA, EL07_FSME_QTD_ACM = :EL07_FSME_QTD_ACM, EL07_FSME_AVANCO_ACM = :EL07_FSME_AVANCO_ACM, 
                                            EL08_FCES_SIGLA = :EL08_FCES_SIGLA, EL08_FSMP_DATA = :EL08_FSMP_DATA, EL08_FSME_DATA = :EL08_FSME_DATA, EL08_FSME_QTD_ACM = :EL08_FSME_QTD_ACM, EL08_FSME_AVANCO_ACM = :EL08_FSME_AVANCO_ACM, 
                                            EL09_FCES_SIGLA = :EL09_FCES_SIGLA, EL09_FSMP_DATA = :EL09_FSMP_DATA, EL09_FSME_DATA = :EL09_FSME_DATA, EL09_FSME_QTD_ACM = :EL09_FSME_QTD_ACM, EL09_FSME_AVANCO_ACM = :EL09_FSME_AVANCO_ACM, 
                                            EL10_FCES_SIGLA = :EL10_FCES_SIGLA, EL10_FSMP_DATA = :EL10_FSMP_DATA, EL10_FSME_DATA = :EL10_FSME_DATA, EL10_FSME_QTD_ACM = :EL10_FSME_QTD_ACM, EL10_FSME_AVANCO_ACM = :EL10_FSME_AVANCO_ACM, 
                                            EL11_FCES_SIGLA = :EL11_FCES_SIGLA, EL11_FSMP_DATA = :EL11_FSMP_DATA, EL11_FSME_DATA = :EL11_FSME_DATA, EL11_FSME_QTD_ACM = :EL11_FSME_QTD_ACM, EL11_FSME_AVANCO_ACM = :EL11_FSME_AVANCO_ACM, 
                                            EL12_FCES_SIGLA = :EL12_FCES_SIGLA, EL12_FSMP_DATA = :EL12_FSMP_DATA, EL12_FSME_DATA = :EL12_FSME_DATA, EL12_FSME_QTD_ACM = :EL12_FSME_QTD_ACM, EL12_FSME_AVANCO_ACM = :EL12_FSME_AVANCO_ACM, 
                                            DISC_ID = :DISC_ID, FOSE_ID = :FOSE_ID, FOSM_ID = :FOSM_ID, FCME_ID = :FCME_ID
                                            WHERE  ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ACTIVE", OracleDbType.Decimal).Value = entity.Active;
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":ATIV_SIG", OracleDbType.Varchar2).Value = entity.AtivSig;
                cmd.Parameters.Add(":ARAP_NOME", OracleDbType.Varchar2).Value = entity.ArapNome;
                cmd.Parameters.Add(":UNPR_NOME", OracleDbType.Varchar2).Value = entity.UnprNome;
                cmd.Parameters.Add(":TIPO_LINHA", OracleDbType.Decimal).Value = entity.TipoLinha;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_NIVEL", OracleDbType.Decimal).Value = entity.FcesNivel;
                cmd.Parameters.Add(":PASTA", OracleDbType.Varchar2).Value = entity.Pasta;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":TIPO", OracleDbType.Varchar2).Value = entity.Tipo;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;

                cmd.Parameters.Add(":EL01_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El01FcesSigla;
                if (entity.El01FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL01_FSMP_DATA", OracleDbType.Date).Value = entity.El01FsmpData;
                if (entity.El01FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL01_FSME_DATA", OracleDbType.Date).Value = entity.El01FsmeData;
                cmd.Parameters.Add(":EL01_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El01FsmeQtdAcm;
                cmd.Parameters.Add(":EL01_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El01FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL02_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El02FcesSigla;
                if (entity.El02FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL02_FSMP_DATA", OracleDbType.Date).Value = entity.El02FsmpData;
                if (entity.El02FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL02_FSME_DATA", OracleDbType.Date).Value = entity.El02FsmeData;
                cmd.Parameters.Add(":EL02_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El02FsmeQtdAcm;
                cmd.Parameters.Add(":EL02_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El02FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL03_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El03FcesSigla;
                if (entity.El03FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL03_FSMP_DATA", OracleDbType.Date).Value = entity.El03FsmpData;
                if (entity.El03FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL03_FSME_DATA", OracleDbType.Date).Value = entity.El03FsmeData;
                cmd.Parameters.Add(":EL03_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El03FsmeQtdAcm;
                cmd.Parameters.Add(":EL03_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El03FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL04_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El04FcesSigla;
                if (entity.El04FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL04_FSMP_DATA", OracleDbType.Date).Value = entity.El04FsmpData;
                if (entity.El04FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL04_FSME_DATA", OracleDbType.Date).Value = entity.El04FsmeData;
                cmd.Parameters.Add(":EL04_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El04FsmeQtdAcm;
                cmd.Parameters.Add(":EL04_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El04FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL05_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El05FcesSigla;
                if (entity.El05FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL05_FSMP_DATA", OracleDbType.Date).Value = entity.El05FsmpData;
                if (entity.El05FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL05_FSME_DATA", OracleDbType.Date).Value = entity.El05FsmeData;
                cmd.Parameters.Add(":EL05_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El05FsmeQtdAcm;
                cmd.Parameters.Add(":EL05_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El05FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL06_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El06FcesSigla;
                if (entity.El06FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL06_FSMP_DATA", OracleDbType.Date).Value = entity.El06FsmpData;
                if (entity.El06FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL06_FSME_DATA", OracleDbType.Date).Value = entity.El06FsmeData;
                cmd.Parameters.Add(":EL06_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El06FsmeQtdAcm;
                cmd.Parameters.Add(":EL06_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El06FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL07_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El07FcesSigla;
                if (entity.El07FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL07_FSMP_DATA", OracleDbType.Date).Value = entity.El07FsmpData;
                if (entity.El07FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL07_FSME_DATA", OracleDbType.Date).Value = entity.El07FsmeData;
                cmd.Parameters.Add(":EL07_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El07FsmeQtdAcm;
                cmd.Parameters.Add(":EL07_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El07FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL08_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El08FcesSigla;
                if (entity.El08FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL08_FSMP_DATA", OracleDbType.Date).Value = entity.El08FsmpData;
                if (entity.El08FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL08_FSME_DATA", OracleDbType.Date).Value = entity.El08FsmeData;
                cmd.Parameters.Add(":EL08_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El08FsmeQtdAcm;
                cmd.Parameters.Add(":EL08_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El08FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL09_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El09FcesSigla;
                if (entity.El09FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL09_FSMP_DATA", OracleDbType.Date).Value = entity.El09FsmpData;
                if (entity.El09FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL09_FSME_DATA", OracleDbType.Date).Value = entity.El09FsmeData;
                cmd.Parameters.Add(":EL09_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El09FsmeQtdAcm;
                cmd.Parameters.Add(":EL09_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El09FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL10_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El10FcesSigla;
                if (entity.El10FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL10_FSMP_DATA", OracleDbType.Date).Value = entity.El10FsmpData;
                if (entity.El10FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL10_FSME_DATA", OracleDbType.Date).Value = entity.El10FsmeData;
                cmd.Parameters.Add(":EL10_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El10FsmeQtdAcm;
                cmd.Parameters.Add(":EL10_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El10FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL11_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El11FcesSigla;
                if (entity.El11FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL11_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL11_FSMP_DATA", OracleDbType.Date).Value = entity.El11FsmpData;
                if (entity.El11FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL11_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL11_FSME_DATA", OracleDbType.Date).Value = entity.El11FsmeData;
                cmd.Parameters.Add(":EL11_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El11FsmeQtdAcm;
                cmd.Parameters.Add(":EL11_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El11FsmeAvancoAcm;
                
                cmd.Parameters.Add(":EL12_FCES_SIGLA", OracleDbType.Varchar2).Value = entity.El12FcesSigla;
                if (entity.El12FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":EL12_FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL12_FSMP_DATA", OracleDbType.Date).Value = entity.El12FsmpData;
                if (entity.El12FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":EL12_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":EL12_FSME_DATA", OracleDbType.Date).Value = entity.El12FsmeData;
                cmd.Parameters.Add(":EL12_FSME_QTD_ACM", OracleDbType.Decimal).Value = entity.El12FsmeQtdAcm;
                cmd.Parameters.Add(":EL12_FSME_AVANCO_ACM", OracleDbType.Decimal).Value = entity.El12FsmeAvancoAcm;

                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Decimal).Value = entity.FosmId;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Decimal).Value = entity.FcmeId;

                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ElAvnFose"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.EL_AVN_FOSE WHERE ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ElAvnFose"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ElAvnFose"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.EL_AVN_FOSE";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ElAvnFose"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ElAvnFose"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ElAvnFose"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableElAvnFose"); }
        }
        //====================================================================
        public static DTO.ElAvnFoseDTO Get(decimal ID)
        {
            ElAvnFoseDTO entity = new ElAvnFoseDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["ACTIVE"] != null) && (dt.Rows[0]["ACTIVE"] != DBNull.Value)) entity.Active = Convert.ToDecimal(dt.Rows[0]["ACTIVE"]);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["SIFS_DESCRICAO"] != null) && (dt.Rows[0]["SIFS_DESCRICAO"] != DBNull.Value)) entity.SifsDescricao = Convert.ToString(dt.Rows[0]["SIFS_DESCRICAO"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["ARAP_NOME"] != null) && (dt.Rows[0]["ARAP_NOME"] != DBNull.Value)) entity.ArapNome = Convert.ToString(dt.Rows[0]["ARAP_NOME"]);
            if ((dt.Rows[0]["UNPR_NOME"] != null) && (dt.Rows[0]["UNPR_NOME"] != DBNull.Value)) entity.UnprNome = Convert.ToString(dt.Rows[0]["UNPR_NOME"]);
            if ((dt.Rows[0]["TIPO_LINHA"] != null) && (dt.Rows[0]["TIPO_LINHA"] != DBNull.Value)) entity.TipoLinha = Convert.ToDecimal(dt.Rows[0]["TIPO_LINHA"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_NIVEL"] != null) && (dt.Rows[0]["FCES_NIVEL"] != DBNull.Value)) entity.FcesNivel = Convert.ToDecimal(dt.Rows[0]["FCES_NIVEL"]);
            if ((dt.Rows[0]["PASTA"] != null) && (dt.Rows[0]["PASTA"] != DBNull.Value)) entity.Pasta = Convert.ToString(dt.Rows[0]["PASTA"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["TIPO"] != null) && (dt.Rows[0]["TIPO"] != DBNull.Value)) entity.Tipo = Convert.ToString(dt.Rows[0]["TIPO"]);
            if ((dt.Rows[0]["SETOR"] != null) && (dt.Rows[0]["SETOR"] != DBNull.Value)) entity.Setor = Convert.ToString(dt.Rows[0]["SETOR"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["EL01_FCES_SIGLA"] != null) && (dt.Rows[0]["EL01_FCES_SIGLA"] != DBNull.Value)) entity.El01FcesSigla = Convert.ToString(dt.Rows[0]["EL01_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL01_FSMP_DATA"] != null) && (dt.Rows[0]["EL01_FSMP_DATA"] != DBNull.Value)) entity.El01FsmpData = Convert.ToDateTime(dt.Rows[0]["EL01_FSMP_DATA"]);
            if ((dt.Rows[0]["EL01_FSME_DATA"] != null) && (dt.Rows[0]["EL01_FSME_DATA"] != DBNull.Value)) entity.El01FsmeData = Convert.ToDateTime(dt.Rows[0]["EL01_FSME_DATA"]);
            if ((dt.Rows[0]["EL01_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL01_FSME_QTD_ACM"] != DBNull.Value)) entity.El01FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL01_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL01_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL01_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El01FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL01_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL02_FCES_SIGLA"] != null) && (dt.Rows[0]["EL02_FCES_SIGLA"] != DBNull.Value)) entity.El02FcesSigla = Convert.ToString(dt.Rows[0]["EL02_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL02_FSMP_DATA"] != null) && (dt.Rows[0]["EL02_FSMP_DATA"] != DBNull.Value)) entity.El02FsmpData = Convert.ToDateTime(dt.Rows[0]["EL02_FSMP_DATA"]);
            if ((dt.Rows[0]["EL02_FSME_DATA"] != null) && (dt.Rows[0]["EL02_FSME_DATA"] != DBNull.Value)) entity.El02FsmeData = Convert.ToDateTime(dt.Rows[0]["EL02_FSME_DATA"]);
            if ((dt.Rows[0]["EL02_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL02_FSME_QTD_ACM"] != DBNull.Value)) entity.El02FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL02_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL02_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL02_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El02FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL02_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL03_FCES_SIGLA"] != null) && (dt.Rows[0]["EL03_FCES_SIGLA"] != DBNull.Value)) entity.El03FcesSigla = Convert.ToString(dt.Rows[0]["EL03_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL03_FSMP_DATA"] != null) && (dt.Rows[0]["EL03_FSMP_DATA"] != DBNull.Value)) entity.El03FsmpData = Convert.ToDateTime(dt.Rows[0]["EL03_FSMP_DATA"]);
            if ((dt.Rows[0]["EL03_FSME_DATA"] != null) && (dt.Rows[0]["EL03_FSME_DATA"] != DBNull.Value)) entity.El03FsmeData = Convert.ToDateTime(dt.Rows[0]["EL03_FSME_DATA"]);
            if ((dt.Rows[0]["EL03_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL03_FSME_QTD_ACM"] != DBNull.Value)) entity.El03FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL03_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL03_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL03_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El03FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL03_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL04_FCES_SIGLA"] != null) && (dt.Rows[0]["EL04_FCES_SIGLA"] != DBNull.Value)) entity.El04FcesSigla = Convert.ToString(dt.Rows[0]["EL04_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL04_FSMP_DATA"] != null) && (dt.Rows[0]["EL04_FSMP_DATA"] != DBNull.Value)) entity.El04FsmpData = Convert.ToDateTime(dt.Rows[0]["EL04_FSMP_DATA"]);
            if ((dt.Rows[0]["EL04_FSME_DATA"] != null) && (dt.Rows[0]["EL04_FSME_DATA"] != DBNull.Value)) entity.El04FsmeData = Convert.ToDateTime(dt.Rows[0]["EL04_FSME_DATA"]);
            if ((dt.Rows[0]["EL04_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL04_FSME_QTD_ACM"] != DBNull.Value)) entity.El04FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL04_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL04_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL04_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El04FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL04_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL05_FCES_SIGLA"] != null) && (dt.Rows[0]["EL05_FCES_SIGLA"] != DBNull.Value)) entity.El05FcesSigla = Convert.ToString(dt.Rows[0]["EL05_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL05_FSMP_DATA"] != null) && (dt.Rows[0]["EL05_FSMP_DATA"] != DBNull.Value)) entity.El05FsmpData = Convert.ToDateTime(dt.Rows[0]["EL05_FSMP_DATA"]);
            if ((dt.Rows[0]["EL05_FSME_DATA"] != null) && (dt.Rows[0]["EL05_FSME_DATA"] != DBNull.Value)) entity.El05FsmeData = Convert.ToDateTime(dt.Rows[0]["EL05_FSME_DATA"]);
            if ((dt.Rows[0]["EL05_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL05_FSME_QTD_ACM"] != DBNull.Value)) entity.El05FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL05_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL05_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL05_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El05FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL05_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL06_FCES_SIGLA"] != null) && (dt.Rows[0]["EL06_FCES_SIGLA"] != DBNull.Value)) entity.El06FcesSigla = Convert.ToString(dt.Rows[0]["EL06_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL06_FSMP_DATA"] != null) && (dt.Rows[0]["EL06_FSMP_DATA"] != DBNull.Value)) entity.El06FsmpData = Convert.ToDateTime(dt.Rows[0]["EL06_FSMP_DATA"]);
            if ((dt.Rows[0]["EL06_FSME_DATA"] != null) && (dt.Rows[0]["EL06_FSME_DATA"] != DBNull.Value)) entity.El06FsmeData = Convert.ToDateTime(dt.Rows[0]["EL06_FSME_DATA"]);
            if ((dt.Rows[0]["EL06_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL06_FSME_QTD_ACM"] != DBNull.Value)) entity.El06FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL06_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL06_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL06_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El06FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL06_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL07_FCES_SIGLA"] != null) && (dt.Rows[0]["EL07_FCES_SIGLA"] != DBNull.Value)) entity.El07FcesSigla = Convert.ToString(dt.Rows[0]["EL07_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL07_FSMP_DATA"] != null) && (dt.Rows[0]["EL07_FSMP_DATA"] != DBNull.Value)) entity.El07FsmpData = Convert.ToDateTime(dt.Rows[0]["EL07_FSMP_DATA"]);
            if ((dt.Rows[0]["EL07_FSME_DATA"] != null) && (dt.Rows[0]["EL07_FSME_DATA"] != DBNull.Value)) entity.El07FsmeData = Convert.ToDateTime(dt.Rows[0]["EL07_FSME_DATA"]);
            if ((dt.Rows[0]["EL07_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL07_FSME_QTD_ACM"] != DBNull.Value)) entity.El07FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL07_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL07_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL07_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El07FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL07_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL08_FCES_SIGLA"] != null) && (dt.Rows[0]["EL08_FCES_SIGLA"] != DBNull.Value)) entity.El08FcesSigla = Convert.ToString(dt.Rows[0]["EL08_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL08_FSMP_DATA"] != null) && (dt.Rows[0]["EL08_FSMP_DATA"] != DBNull.Value)) entity.El08FsmpData = Convert.ToDateTime(dt.Rows[0]["EL08_FSMP_DATA"]);
            if ((dt.Rows[0]["EL08_FSME_DATA"] != null) && (dt.Rows[0]["EL08_FSME_DATA"] != DBNull.Value)) entity.El08FsmeData = Convert.ToDateTime(dt.Rows[0]["EL08_FSME_DATA"]);
            if ((dt.Rows[0]["EL08_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL08_FSME_QTD_ACM"] != DBNull.Value)) entity.El08FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL08_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL08_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL08_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El08FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL08_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL09_FCES_SIGLA"] != null) && (dt.Rows[0]["EL09_FCES_SIGLA"] != DBNull.Value)) entity.El09FcesSigla = Convert.ToString(dt.Rows[0]["EL09_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL09_FSMP_DATA"] != null) && (dt.Rows[0]["EL09_FSMP_DATA"] != DBNull.Value)) entity.El09FsmpData = Convert.ToDateTime(dt.Rows[0]["EL09_FSMP_DATA"]);
            if ((dt.Rows[0]["EL09_FSME_DATA"] != null) && (dt.Rows[0]["EL09_FSME_DATA"] != DBNull.Value)) entity.El09FsmeData = Convert.ToDateTime(dt.Rows[0]["EL09_FSME_DATA"]);
            if ((dt.Rows[0]["EL09_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL09_FSME_QTD_ACM"] != DBNull.Value)) entity.El09FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL09_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL09_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL09_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El09FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL09_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL10_FCES_SIGLA"] != null) && (dt.Rows[0]["EL10_FCES_SIGLA"] != DBNull.Value)) entity.El10FcesSigla = Convert.ToString(dt.Rows[0]["EL10_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL10_FSMP_DATA"] != null) && (dt.Rows[0]["EL10_FSMP_DATA"] != DBNull.Value)) entity.El10FsmpData = Convert.ToDateTime(dt.Rows[0]["EL10_FSMP_DATA"]);
            if ((dt.Rows[0]["EL10_FSME_DATA"] != null) && (dt.Rows[0]["EL10_FSME_DATA"] != DBNull.Value)) entity.El10FsmeData = Convert.ToDateTime(dt.Rows[0]["EL10_FSME_DATA"]);
            if ((dt.Rows[0]["EL10_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL10_FSME_QTD_ACM"] != DBNull.Value)) entity.El10FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL10_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL10_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL10_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El10FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL10_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL11_FCES_SIGLA"] != null) && (dt.Rows[0]["EL11_FCES_SIGLA"] != DBNull.Value)) entity.El11FcesSigla = Convert.ToString(dt.Rows[0]["EL11_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL11_FSMP_DATA"] != null) && (dt.Rows[0]["EL11_FSMP_DATA"] != DBNull.Value)) entity.El11FsmpData = Convert.ToDateTime(dt.Rows[0]["EL11_FSMP_DATA"]);
            if ((dt.Rows[0]["EL11_FSME_DATA"] != null) && (dt.Rows[0]["EL11_FSME_DATA"] != DBNull.Value)) entity.El11FsmeData = Convert.ToDateTime(dt.Rows[0]["EL11_FSME_DATA"]);
            if ((dt.Rows[0]["EL11_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL11_FSME_QTD_ACM"] != DBNull.Value)) entity.El11FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL11_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL11_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL11_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El11FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL11_FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["EL12_FCES_SIGLA"] != null) && (dt.Rows[0]["EL12_FCES_SIGLA"] != DBNull.Value)) entity.El12FcesSigla = Convert.ToString(dt.Rows[0]["EL12_FCES_SIGLA"]);
            if ((dt.Rows[0]["EL12_FSMP_DATA"] != null) && (dt.Rows[0]["EL12_FSMP_DATA"] != DBNull.Value)) entity.El12FsmpData = Convert.ToDateTime(dt.Rows[0]["EL12_FSMP_DATA"]);
            if ((dt.Rows[0]["EL12_FSME_DATA"] != null) && (dt.Rows[0]["EL12_FSME_DATA"] != DBNull.Value)) entity.El12FsmeData = Convert.ToDateTime(dt.Rows[0]["EL12_FSME_DATA"]);
            if ((dt.Rows[0]["EL12_FSME_QTD_ACM"] != null) && (dt.Rows[0]["EL12_FSME_QTD_ACM"] != DBNull.Value)) entity.El12FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["EL12_FSME_QTD_ACM"]);
            if ((dt.Rows[0]["EL12_FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["EL12_FSME_AVANCO_ACM"] != DBNull.Value)) entity.El12FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["EL12_FSME_AVANCO_ACM"]);

            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToDecimal(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.ElAvnFoseDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<ElAvnFoseDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ElAvnFoseDTO> list = OracleDataTools.LoadEntity<ElAvnFoseDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElAvnFoseDTO>"); }
        }
        //====================================================================
        public static List<ElAvnFoseDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElAvnFoseDTO>"); }
        }
        //====================================================================
        public static List<ElAvnFoseDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElAvnFoseDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionElAvnFoseDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionElAvnFose"); }
        }
        //====================================================================
        public static DTO.CollectionElAvnFoseDTO GetCollection(DataTable dt)
        {
            DTO.CollectionElAvnFoseDTO collection = new DTO.CollectionElAvnFoseDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ElAvnFoseDTO entity = new DTO.ElAvnFoseDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["ACTIVE"].ToString().Length != 0) entity.Active = Convert.ToDecimal(dt.Rows[i]["ACTIVE"]);
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["SIFS_DESCRICAO"].ToString().Length != 0) entity.SifsDescricao = dt.Rows[i]["SIFS_DESCRICAO"].ToString();
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = dt.Rows[i]["ATIV_SIG"].ToString();
                    if (dt.Rows[i]["ARAP_NOME"].ToString().Length != 0) entity.ArapNome = dt.Rows[i]["ARAP_NOME"].ToString();
                    if (dt.Rows[i]["UNPR_NOME"].ToString().Length != 0) entity.UnprNome = dt.Rows[i]["UNPR_NOME"].ToString();
                    if (dt.Rows[i]["TIPO_LINHA"].ToString().Length != 0) entity.TipoLinha = Convert.ToDecimal(dt.Rows[i]["TIPO_LINHA"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_NIVEL"].ToString().Length != 0) entity.FcesNivel = Convert.ToDecimal(dt.Rows[i]["FCES_NIVEL"]);
                    if (dt.Rows[i]["PASTA"].ToString().Length != 0) entity.Pasta = dt.Rows[i]["PASTA"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["TIPO"].ToString().Length != 0) entity.Tipo = dt.Rows[i]["TIPO"].ToString();
                    if (dt.Rows[i]["SETOR"].ToString().Length != 0) entity.Setor = dt.Rows[i]["SETOR"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["EL01_FCES_SIGLA"].ToString().Length != 0) entity.El01FcesSigla = dt.Rows[i]["EL01_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL01_FSMP_DATA"].ToString().Length != 0) entity.El01FsmpData = Convert.ToDateTime(dt.Rows[i]["EL01_FSMP_DATA"]);
                    if (dt.Rows[i]["EL01_FSME_DATA"].ToString().Length != 0) entity.El01FsmeData = Convert.ToDateTime(dt.Rows[i]["EL01_FSME_DATA"]);
                    if (dt.Rows[i]["EL01_FSME_QTD_ACM"].ToString().Length != 0) entity.El01FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL01_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL01_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El01FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL01_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL02_FCES_SIGLA"].ToString().Length != 0) entity.El02FcesSigla = dt.Rows[i]["EL02_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL02_FSMP_DATA"].ToString().Length != 0) entity.El02FsmpData = Convert.ToDateTime(dt.Rows[i]["EL02_FSMP_DATA"]);
                    if (dt.Rows[i]["EL02_FSME_DATA"].ToString().Length != 0) entity.El02FsmeData = Convert.ToDateTime(dt.Rows[i]["EL02_FSME_DATA"]);
                    if (dt.Rows[i]["EL02_FSME_QTD_ACM"].ToString().Length != 0) entity.El02FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL02_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL02_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El02FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL02_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL03_FCES_SIGLA"].ToString().Length != 0) entity.El03FcesSigla = dt.Rows[i]["EL03_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL03_FSMP_DATA"].ToString().Length != 0) entity.El03FsmpData = Convert.ToDateTime(dt.Rows[i]["EL03_FSMP_DATA"]);
                    if (dt.Rows[i]["EL03_FSME_DATA"].ToString().Length != 0) entity.El03FsmeData = Convert.ToDateTime(dt.Rows[i]["EL03_FSME_DATA"]);
                    if (dt.Rows[i]["EL03_FSME_QTD_ACM"].ToString().Length != 0) entity.El03FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL03_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL03_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El03FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL03_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL04_FCES_SIGLA"].ToString().Length != 0) entity.El04FcesSigla = dt.Rows[i]["EL04_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL04_FSMP_DATA"].ToString().Length != 0) entity.El04FsmpData = Convert.ToDateTime(dt.Rows[i]["EL04_FSMP_DATA"]);
                    if (dt.Rows[i]["EL04_FSME_DATA"].ToString().Length != 0) entity.El04FsmeData = Convert.ToDateTime(dt.Rows[i]["EL04_FSME_DATA"]);
                    if (dt.Rows[i]["EL04_FSME_QTD_ACM"].ToString().Length != 0) entity.El04FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL04_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL04_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El04FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL04_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL05_FCES_SIGLA"].ToString().Length != 0) entity.El05FcesSigla = dt.Rows[i]["EL05_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL05_FSMP_DATA"].ToString().Length != 0) entity.El05FsmpData = Convert.ToDateTime(dt.Rows[i]["EL05_FSMP_DATA"]);
                    if (dt.Rows[i]["EL05_FSME_DATA"].ToString().Length != 0) entity.El05FsmeData = Convert.ToDateTime(dt.Rows[i]["EL05_FSME_DATA"]);
                    if (dt.Rows[i]["EL05_FSME_QTD_ACM"].ToString().Length != 0) entity.El05FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL05_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL05_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El05FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL05_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL06_FCES_SIGLA"].ToString().Length != 0) entity.El06FcesSigla = dt.Rows[i]["EL06_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL06_FSMP_DATA"].ToString().Length != 0) entity.El06FsmpData = Convert.ToDateTime(dt.Rows[i]["EL06_FSMP_DATA"]);
                    if (dt.Rows[i]["EL06_FSME_DATA"].ToString().Length != 0) entity.El06FsmeData = Convert.ToDateTime(dt.Rows[i]["EL06_FSME_DATA"]);
                    if (dt.Rows[i]["EL06_FSME_QTD_ACM"].ToString().Length != 0) entity.El06FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL06_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL06_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El06FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL06_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL07_FCES_SIGLA"].ToString().Length != 0) entity.El07FcesSigla = dt.Rows[i]["EL07_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL07_FSMP_DATA"].ToString().Length != 0) entity.El07FsmpData = Convert.ToDateTime(dt.Rows[i]["EL07_FSMP_DATA"]);
                    if (dt.Rows[i]["EL07_FSME_DATA"].ToString().Length != 0) entity.El07FsmeData = Convert.ToDateTime(dt.Rows[i]["EL07_FSME_DATA"]);
                    if (dt.Rows[i]["EL07_FSME_QTD_ACM"].ToString().Length != 0) entity.El07FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL07_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL07_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El07FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL07_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL08_FCES_SIGLA"].ToString().Length != 0) entity.El08FcesSigla = dt.Rows[i]["EL08_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL08_FSMP_DATA"].ToString().Length != 0) entity.El08FsmpData = Convert.ToDateTime(dt.Rows[i]["EL08_FSMP_DATA"]);
                    if (dt.Rows[i]["EL08_FSME_DATA"].ToString().Length != 0) entity.El08FsmeData = Convert.ToDateTime(dt.Rows[i]["EL08_FSME_DATA"]);
                    if (dt.Rows[i]["EL08_FSME_QTD_ACM"].ToString().Length != 0) entity.El08FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL08_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL08_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El08FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL08_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL09_FCES_SIGLA"].ToString().Length != 0) entity.El09FcesSigla = dt.Rows[i]["EL09_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL09_FSMP_DATA"].ToString().Length != 0) entity.El09FsmpData = Convert.ToDateTime(dt.Rows[i]["EL09_FSMP_DATA"]);
                    if (dt.Rows[i]["EL09_FSME_DATA"].ToString().Length != 0) entity.El09FsmeData = Convert.ToDateTime(dt.Rows[i]["EL09_FSME_DATA"]);
                    if (dt.Rows[i]["EL09_FSME_QTD_ACM"].ToString().Length != 0) entity.El09FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL09_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL09_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El09FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL09_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL10_FCES_SIGLA"].ToString().Length != 0) entity.El10FcesSigla = dt.Rows[i]["EL10_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL10_FSMP_DATA"].ToString().Length != 0) entity.El10FsmpData = Convert.ToDateTime(dt.Rows[i]["EL10_FSMP_DATA"]);
                    if (dt.Rows[i]["EL10_FSME_DATA"].ToString().Length != 0) entity.El10FsmeData = Convert.ToDateTime(dt.Rows[i]["EL10_FSME_DATA"]);
                    if (dt.Rows[i]["EL10_FSME_QTD_ACM"].ToString().Length != 0) entity.El10FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL10_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL10_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El10FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL10_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL11_FCES_SIGLA"].ToString().Length != 0) entity.El11FcesSigla = dt.Rows[i]["EL11_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL11_FSMP_DATA"].ToString().Length != 0) entity.El11FsmpData = Convert.ToDateTime(dt.Rows[i]["EL11_FSMP_DATA"]);
                    if (dt.Rows[i]["EL11_FSME_DATA"].ToString().Length != 0) entity.El11FsmeData = Convert.ToDateTime(dt.Rows[i]["EL11_FSME_DATA"]);
                    if (dt.Rows[i]["EL11_FSME_QTD_ACM"].ToString().Length != 0) entity.El11FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL11_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL11_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El11FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL11_FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["EL12_FCES_SIGLA"].ToString().Length != 0) entity.El12FcesSigla = dt.Rows[i]["EL12_FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EL12_FSMP_DATA"].ToString().Length != 0) entity.El12FsmpData = Convert.ToDateTime(dt.Rows[i]["EL12_FSMP_DATA"]);
                    if (dt.Rows[i]["EL12_FSME_DATA"].ToString().Length != 0) entity.El12FsmeData = Convert.ToDateTime(dt.Rows[i]["EL12_FSME_DATA"]);
                    if (dt.Rows[i]["EL12_FSME_QTD_ACM"].ToString().Length != 0) entity.El12FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["EL12_FSME_QTD_ACM"]);
                    if (dt.Rows[i]["EL12_FSME_AVANCO_ACM"].ToString().Length != 0) entity.El12FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["EL12_FSME_AVANCO_ACM"]);

                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToDecimal(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);

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
