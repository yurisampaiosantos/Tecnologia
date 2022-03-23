using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================

namespace DAL
{
    public class AcControleProducaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.FOSE_CNTR_CODIGO, X.SEMA_ID, X.MES_COMPETENCIA, X.ANO_COMPETENCIA, X.SBCN_ID, X.SBCN_SIGLA, X.DISC_ID, X.DISC_NOME, X.FOSE_ID, X.FOSE_NUMERO, X.FOSE_DESCRICAO, X.UNME_SIGLA, X.SIFS_DESCRICAO, X.FCME_SIGLA, X.FCES_SIGLA, X.SUMA_ATIV_SIG, X.GRCR_NOME, REPLACE(TO_CHAR(X.FOSE_QTD_PREVISTA),'.',',') AS FOSE_QTD_PREVISTA, REPLACE(TO_CHAR(X.QTD_ACUMULADA),'.',',') AS QTD_ACUMULADA, X.FCES_PESO_REL_CRON, TO_DATE(X.FSME_DATA,'DD/MM/YY') AS FSME_DATA, REPLACE(TO_CHAR(AVN_POND_EXEC_PERIODO),'.',',') AS AVN_POND_EXEC_PERIODO, REPLACE(TO_CHAR(AVN_REAL_EXEC_PERIODO),'.',',') AS AVN_REAL_EXEC_PERIODO, TO_DATE(X.FSMP_DATA,'DD/MM/YY') AS FSMP_DATA, REPLACE(TO_CHAR(X.AVN_POND_PROG_PERIODO),'.',',') AS AVN_POND_PROG_PERIODO, REPLACE(TO_CHAR(X.AVN_REAL_PROG_PERIODO),'.',',') AS AVN_REAL_PROG_PERIODO, X.EQUIPE, X.SETOR, X.LOCALIZACAO, X.DESENHO, X.ORIGEM_FABRICACAO, X.AREA_PINTURA, X.CLASSIFICADO, X.DESCRICAO_ESTRUTURA, X.ITEM_CONTROLE, X.DIAM, X.EMPRESA_RESPONSAVEL, X.NOTA, X.REGIAO, X.SEMANA_FOLHA, X.SISTEMA, X.SPEC, X.TRATAMENTO, X.INDEFINIDO, X.ZONA_ID, X.PASTA_CODIGO, X.RESPONSAVEL  FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO X ";
        //====================================================================
        public static int Insert(DTO.AcControleProducaoDTO entity, bool getIdentity)
        {
            //string strSQL = "INSERT INTO EEP_CONVERSION.AC_CONTROLE_PRODUCAO(ID, FOSE_CNTR_CODIGO, SEMA_ID, MES_COMPETENCIA, ANO_COMPETENCIA, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, FCME_SIGLA, FCES_SIGLA, SUMA_ATIV_SIG, GRCR_NOME, FOSE_QTD_PREVISTA, QTD_ACUMULADA, FCES_PESO_REL_CRON, FSME_DATA, AVN_POND_EXEC_PERIODO, AVN_REAL_EXEC_PERIODO, FSMP_DATA, AVN_POND_PROG_PERIODO, AVN_REAL_PROG_PERIODO, EQUIPE, SETOR, LOCALIZACAO, DESENHO, ORIGEM_FABRICACAO, AREA_PINTURA, CLASSIFICADO, DESCRICAO_ESTRUTURA, ITEM_CONTROLE, DIAM, EMPRESA_RESPONSAVEL, NOTA, REGIAO, SEMANA_FOLHA, SISTEMA, SPEC, TRATAMENTO, INDEFINIDO) VALUES(:ID, :FOSE_CNTR_CODIGO, :SEMA_ID, :MES_COMPETENCIA, :ANO_COMPETENCIA, :SBCN_ID, :SBCN_SIGLA, :DISC_ID, :DISC_NOME, :FOSE_ID, :FOSE_NUMERO, :FOSE_DESCRICAO, :UNME_SIGLA, :SIFS_DESCRICAO, :FCME_SIGLA, :FCES_SIGLA, :SUMA_ATIV_SIG, :GRCR_NOME, :FOSE_QTD_PREVISTA, :QTD_ACUMULADA, :FCES_PESO_REL_CRON, :FSME_DATA, :AVN_POND_EXEC_PERIODO, :AVN_REAL_EXEC_PERIODO, :FSMP_DATA, :AVN_POND_PROG_PERIODO, :AVN_REAL_PROG_PERIODO, :EQUIPE, :SETOR, :LOCALIZACAO, :DESENHO, :ORIGEM_FABRICACAO, :AREA_PINTURA, :CLASSIFICADO, :DESCRICAO_ESTRUTURA, :ITEM_CONTROLE, :DIAM,:EMPRESA_RESPONSAVEL, :NOTA, :REGIAO, :SEMANA_FOLHA, :SISTEMA, :SPEC, :TRATAMENTO, :INDEFINIDO)";

            string strSQL = "INSERT INTO EEP_CONVERSION.AC_CONTROLE_PRODUCAO(ID, FOSE_CNTR_CODIGO, SEMA_ID, MES_COMPETENCIA, ANO_COMPETENCIA, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, FOSE_DESCRICAO, UNME_SIGLA, SIFS_DESCRICAO, FCME_SIGLA, FCES_SIGLA, SUMA_ATIV_SIG, GRCR_NOME, FOSE_QTD_PREVISTA, QTD_ACUMULADA, FCES_PESO_REL_CRON, FSME_DATA, AVN_POND_EXEC_PERIODO, AVN_REAL_EXEC_PERIODO, FSMP_DATA, AVN_POND_PROG_PERIODO, AVN_REAL_PROG_PERIODO, EQUIPE, SETOR, LOCALIZACAO, DESENHO, ORIGEM_FABRICACAO, AREA_PINTURA, CLASSIFICADO, DESCRICAO_ESTRUTURA, ITEM_CONTROLE, DIAM, EMPRESA_RESPONSAVEL, NOTA, REGIAO, SEMANA_FOLHA, SISTEMA, SPEC, TRATAMENTO, INDEFINIDO, ZONA_ID, PASTA_CODIGO, RESPONSAVEL) VALUES(:ID, :FOSE_CNTR_CODIGO, :SEMA_ID, :MES_COMPETENCIA, :ANO_COMPETENCIA, :SBCN_ID, :SBCN_SIGLA, :DISC_ID, :DISC_NOME, :FOSE_ID, :FOSE_NUMERO, :FOSE_DESCRICAO, :UNME_SIGLA, :SIFS_DESCRICAO, :FCME_SIGLA, :FCES_SIGLA, :SUMA_ATIV_SIG, :GRCR_NOME, :FOSE_QTD_PREVISTA, :QTD_ACUMULADA, :FCES_PESO_REL_CRON, :FSME_DATA, :AVN_POND_EXEC_PERIODO, :AVN_REAL_EXEC_PERIODO, :FSMP_DATA, :AVN_POND_PROG_PERIODO, :AVN_REAL_PROG_PERIODO, :EQUIPE, :SETOR, :LOCALIZACAO, :DESENHO, :ORIGEM_FABRICACAO, :AREA_PINTURA, :CLASSIFICADO, :DESCRICAO_ESTRUTURA, :ITEM_CONTROLE, :DIAM,:EMPRESA_RESPONSAVEL, :NOTA, :REGIAO, :SEMANA_FOLHA, :SISTEMA, :SPEC, :TRATAMENTO, :INDEFINIDO, :ZONA_ID, :PASTA_CODIGO, :RESPONSAVEL)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":MES_COMPETENCIA", OracleDbType.Varchar2).Value = entity.MesCompetencia;
                cmd.Parameters.Add(":ANO_COMPETENCIA", OracleDbType.Varchar2).Value = entity.AnoCompetencia;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.FoseDescricao;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;

                cmd.Parameters.Add(":SUMA_ATIV_SIG", OracleDbType.Varchar2).Value = entity.SumaAtivSig;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;

                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.FoseQtdPrevista);
                cmd.Parameters.Add(":QTD_ACUMULADA", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.QtdAcumulada);

                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.FcesPesoRelCron;
                if (entity.FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = entity.FsmeData;

                //if (entity.AvnPondExecPeriodo.IndexOf("-") >= 0) cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondExecPeriodo);
                cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondExecPeriodo);

                //if (entity.AvnRealExecPeriodo.IndexOf("-") >= 0) cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealExecPeriodo);
                cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealExecPeriodo);

                if (entity.FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSMP_DATA", OracleDbType.Date).Value = entity.FsmpData;


                //if (entity.AvnPondProgPeriodo.IndexOf("-") >= 0) cmd.Parameters.Add(":AVN_POND_PROG_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_POND_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondProgPeriodo);
                cmd.Parameters.Add(":AVN_POND_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondProgPeriodo);

                //if (entity.AvnRealProgPeriodo.IndexOf("-") >= 0) cmd.Parameters.Add(":AVN_REAL_PROG_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_REAL_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealProgPeriodo);
                cmd.Parameters.Add(":AVN_REAL_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealProgPeriodo);

                cmd.Parameters.Add(":EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add(":AREA_PINTURA", OracleDbType.Varchar2).Value = entity.AreaPintura;
                cmd.Parameters.Add(":CLASSIFICADO", OracleDbType.Varchar2).Value = entity.Classificado;
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":ITEM_CONTROLE", OracleDbType.Varchar2).Value = entity.ItemControle;
                cmd.Parameters.Add(":DIAM", OracleDbType.Varchar2).Value = entity.Diam;
                cmd.Parameters.Add(":EMPRESA_RESPONSAVEL", OracleDbType.Varchar2).Value = entity.EmpresaResponsavel;
                cmd.Parameters.Add(":NOTA", OracleDbType.Varchar2).Value = entity.Nota;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;
                cmd.Parameters.Add(":SEMANA_FOLHA", OracleDbType.Varchar2).Value = entity.SemanaFolha;
                cmd.Parameters.Add(":SISTEMA", OracleDbType.Varchar2).Value = entity.Sistema;
                cmd.Parameters.Add(":SPEC", OracleDbType.Varchar2).Value = entity.Spec;
                cmd.Parameters.Add(":TRATAMENTO", OracleDbType.Varchar2).Value = entity.Tratamento;
                cmd.Parameters.Add(":INDEFINIDO", OracleDbType.Varchar2).Value = entity.Indefinido;
                cmd.Parameters.Add(":ZONA_ID", OracleDbType.Decimal).Value = entity.ZonaId;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":RESPONSAVEL", OracleDbType.Varchar2).Value = entity.Responsavel;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcControleProducao");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcControleProducao");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcControleProducaoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_PRODUCAO set FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SEMA_ID = :SEMA_ID, MES_COMPETENCIA = :MES_COMPETENCIA, ANO_COMPETENCIA = :ANO_COMPETENCIA, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, FOSE_DESCRICAO = :FOSE_DESCRICAO, UNME_SIGLA = :UNME_SIGLA, SIFS_DESCRICAO = :SIFS_DESCRICAO, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, SUMA_ATIV_SIG = :SUMA_ATIV_SIG, GRCR_NOME = :GRCR_NOME, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, QTD_ACUMULADA = :QTD_ACUMULADA, FCES_PESO_REL_CRON = :FCES_PESO_REL_CRON , FSME_DATA = :FSME_DATA, AVN_POND_EXEC_PERIODO = :AVN_POND_EXEC_PERIODO, AVN_REAL_EXEC_PERIODO = :AVN_REAL_EXEC_PERIODO, FSMP_DATA = :FSMP_DATA, AVN_POND_PROG_PERIODO = :AVN_POND_PROG_PERIODO, AVN_REAL_PROG_PERIODO = :AVN_REAL_PROG_PERIODO, EQUIPE = :EQUIPE, SETOR = :SETOR, LOCALIZACAO = :LOCALIZACAO, DESENHO = :DESENHO, ORIGEM_FABRICACAO = :ORIGEM_FABRICACAO, AREA_PINTURA = :AREA_PINTURA, CLASSIFICADO = :CLASSIFICADO, DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, ITEM_CONTROLE = :ITEM_CONTROLE, DIAM = :DIAM, EMPRESA_RESPONSAVEL = :EMPRESA_RESPONSAVEL, NOTA = :NOTA, REGIAO = :REGIAO, SEMANA_FOLHA = :SEMANA_FOLHA, SISTEMA = :SISTEMA, SPEC = :SPEC, TRATAMENTO = :TRATAMENTO, INDEFINIDO = :INDEFINIDO, ZONA_ID = :ZONA_ID, PASTA_CODIGO = :PASTA_CODIGO, RESPONSAVEL = :RESPONSAVEL WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":MES_COMPETENCIA", OracleDbType.Varchar2).Value = entity.MesCompetencia;
                cmd.Parameters.Add(":ANO_COMPETENCIA", OracleDbType.Varchar2).Value = entity.AnoCompetencia;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.FoseDescricao;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;

                cmd.Parameters.Add(":SUMA_ATIV_SIG", OracleDbType.Varchar2).Value = entity.SumaAtivSig;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;

                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.FoseQtdPrevista);
                cmd.Parameters.Add(":QTD_ACUMULADA", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.QtdAcumulada);
                
                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Decimal).Value = entity.FcesPesoRelCron;

                if (entity.FsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSME_DATA", OracleDbType.Date).Value = entity.FsmeData;
                
                //if (entity.AvnPondExecPeriodo <= 0) cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondExecPeriodo);
                cmd.Parameters.Add(":AVN_POND_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondExecPeriodo);

                //if (entity.AvnRealExecPeriodo <= 0) cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = null;
                //else cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = entity.AvnRealExecPeriodo;
                cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealExecPeriodo);

                if (entity.FsmpData.ToOADate() == 0.0) cmd.Parameters.Add(":FSMP_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":FSMP_DATA", OracleDbType.Date).Value = entity.FsmpData;
                
                cmd.Parameters.Add(":AVN_POND_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnPondProgPeriodo);
                cmd.Parameters.Add(":AVN_REAL_PROG_PERIODO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.AvnRealProgPeriodo);

                cmd.Parameters.Add(":EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add(":AREA_PINTURA", OracleDbType.Varchar2).Value = entity.AreaPintura;
                cmd.Parameters.Add(":CLASSIFICADO", OracleDbType.Varchar2).Value = entity.Classificado;
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":ITEM_CONTROLE", OracleDbType.Varchar2).Value = entity.ItemControle;
                cmd.Parameters.Add(":DIAM", OracleDbType.Varchar2).Value = entity.Diam;
                cmd.Parameters.Add(":EMPRESA_RESPONSAVEL", OracleDbType.Varchar2).Value = entity.EmpresaResponsavel;
                cmd.Parameters.Add(":NOTA", OracleDbType.Varchar2).Value = entity.Nota;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;
                cmd.Parameters.Add(":SEMANA_FOLHA", OracleDbType.Varchar2).Value = entity.SemanaFolha;
                cmd.Parameters.Add(":SISTEMA", OracleDbType.Varchar2).Value = entity.Sistema;
                cmd.Parameters.Add(":SPEC", OracleDbType.Varchar2).Value = entity.Spec;
                cmd.Parameters.Add(":TRATAMENTO", OracleDbType.Varchar2).Value = entity.Tratamento;
                cmd.Parameters.Add(":INDEFINIDO", OracleDbType.Varchar2).Value = entity.Indefinido;
                cmd.Parameters.Add(":ZONA_ID", OracleDbType.Decimal).Value = entity.ZonaId;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":RESPONSAVEL", OracleDbType.Varchar2).Value = entity.Responsavel;
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;
                
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcControleProducao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void DeleteBySemana(decimal semaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE SEMA_ID = " + semaId.ToString();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - DeletingBySemaId AcControleProducao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void DeleteByFoseId(decimal foseId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE FOSE_ID = " + foseId.ToString();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - DeletingByFoseId AcControleProducao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleProducao"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleProducao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleProducao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleProducao"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static DataTable SelectAvnFoseFromDataReader(string strSQL)
        {
            //decimal c = 0;
            //decimal fose = 0;
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection conn = new OracleConnection(OracleDataTools.StandardConnection))
                {
                    OracleDataReader dr;
                    OracleCommand oCmd = conn.CreateCommand();
                    DataRow mLine;
                    dt.Columns.Add(new DataColumn("FOSE_ID", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("FOSE_NUMERO", typeof(string)));
                    dt.Columns.Add(new DataColumn("FCME_SIGLA", typeof(string)));
                    dt.Columns.Add(new DataColumn("AVANCO", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("FCES_WBS", typeof(string)));
                    conn.Open();
                    oCmd.CommandText = strSQL;
                    dr = oCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        mLine = dt.NewRow();
                        //fose = Convert.ToDecimal(dr["FOSE_ID"]);
                        mLine["FOSE_ID"] = Convert.ToDecimal(dr["FOSE_ID"]);
                        mLine["FOSE_NUMERO"] = dr["FOSE_NUMERO"].ToString();
                        mLine["FCME_SIGLA"] = dr["FCME_SIGLA"].ToString();
                        mLine["AVANCO"] = Convert.ToDecimal(dr["AVANCO"]);
                        mLine["FCES_WBS"] = dr["FCES_WBS"].ToString();
                        
                        dt.Rows.Add(mLine);
                        //c += 1;
                    }
                    dr.Close();
                }
                return dt;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableFOSE"); }
           
        }
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcControleProducao"); }
        }
        //====================================================================
        public static DTO.AcControleProducaoDTO Get(decimal ID)
        {
            AcControleProducaoDTO entity = new AcControleProducaoDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            if ((dt.Rows[0]["MES"] != null) && (dt.Rows[0]["MES_COMPETENCIA"] != DBNull.Value)) entity.MesCompetencia = Convert.ToString(dt.Rows[0]["MES_COMPETENCIA"]);
            if ((dt.Rows[0]["ANO"] != null) && (dt.Rows[0]["ANO_COMPETENCIA"] != DBNull.Value)) entity.AnoCompetencia = Convert.ToString(dt.Rows[0]["ANO_COMPETENCIA"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_DESCRICAO"] != null) && (dt.Rows[0]["FOSE_DESCRICAO"] != DBNull.Value)) entity.FoseDescricao = Convert.ToString(dt.Rows[0]["FOSE_DESCRICAO"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["SIFS_DESCRICAO"] != null) && (dt.Rows[0]["SIFS_DESCRICAO"] != DBNull.Value)) entity.SifsDescricao = Convert.ToString(dt.Rows[0]["SIFS_DESCRICAO"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);

            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["SUMA_ATIV_SIG"] != DBNull.Value)) entity.SumaAtivSig = Convert.ToString(dt.Rows[0]["SUMA_ATIV_SIG"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);

            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToString(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["QTD_ACUMULADA"] != null) && (dt.Rows[0]["QTD_ACUMULADA"] != DBNull.Value)) entity.QtdAcumulada = Convert.ToString(dt.Rows[0]["QTD_ACUMULADA"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FCES_PESO_REL_CRON"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["FSME_DATA"] != null) && (dt.Rows[0]["FSME_DATA"] != DBNull.Value)) entity.FsmeData = Convert.ToDateTime(dt.Rows[0]["FSME_DATA"]);
            if ((dt.Rows[0]["AVN_POND_EXEC_PERIODO"] != null) && (dt.Rows[0]["AVN_POND_EXEC_PERIODO"] != DBNull.Value)) entity.AvnPondExecPeriodo = Convert.ToString(dt.Rows[0]["AVN_POND_EXEC_PERIODO"]);
            if ((dt.Rows[0]["AVN_REAL_EXEC_PERIODO"] != null) && (dt.Rows[0]["AVN_REAL_EXEC_PERIODO"] != DBNull.Value)) entity.AvnRealExecPeriodo = Convert.ToString(dt.Rows[0]["AVN_REAL_EXEC_PERIODO"]);
            if ((dt.Rows[0]["FSMP_DATA"] != null) && (dt.Rows[0]["FSMP_DATA"] != DBNull.Value)) entity.FsmpData = Convert.ToDateTime(dt.Rows[0]["FSMP_DATA"]);
            if ((dt.Rows[0]["AVN_POND_PROG_PERIODO"] != null) && (dt.Rows[0]["AVN_POND_PROG_PERIODO"] != DBNull.Value)) entity.AvnPondProgPeriodo = Convert.ToString(dt.Rows[0]["AVN_POND_PROG_PERIODO"]);
            if ((dt.Rows[0]["AVN_REAL_PROG_PERIODO"] != null) && (dt.Rows[0]["AVN_REAL_PROG_PERIODO"] != DBNull.Value)) entity.AvnRealProgPeriodo = Convert.ToString(dt.Rows[0]["AVN_REAL_PROG_PERIODO"]);
            if ((dt.Rows[0]["EQUIPE"] != null) && (dt.Rows[0]["EQUIPE"] != DBNull.Value)) entity.Equipe = Convert.ToString(dt.Rows[0]["EQUIPE"]);
            if ((dt.Rows[0]["SETOR"] != null) && (dt.Rows[0]["SETOR"] != DBNull.Value)) entity.Setor = Convert.ToString(dt.Rows[0]["SETOR"]);
            if ((dt.Rows[0]["LOCALIZACAO"] != null) && (dt.Rows[0]["LOCALIZACAO"] != DBNull.Value)) entity.Localizacao = Convert.ToString(dt.Rows[0]["LOCALIZACAO"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["ORIGEM_FABRICACAO"] != null) && (dt.Rows[0]["ORIGEM_FABRICACAO"] != DBNull.Value)) entity.OrigemFabricacao = Convert.ToString(dt.Rows[0]["ORIGEM_FABRICACAO"]);
            if ((dt.Rows[0]["AREA_PINTURA"] != null) && (dt.Rows[0]["AREA_PINTURA"] != DBNull.Value)) entity.AreaPintura = Convert.ToString(dt.Rows[0]["AREA_PINTURA"]);
            if ((dt.Rows[0]["CLASSIFICADO"] != null) && (dt.Rows[0]["CLASSIFICADO"] != DBNull.Value)) entity.Classificado = Convert.ToString(dt.Rows[0]["CLASSIFICADO"]);
            if ((dt.Rows[0]["DESCRICAO_ESTRUTURA"] != null) && (dt.Rows[0]["DESCRICAO_ESTRUTURA"] != DBNull.Value)) entity.DescricaoEstrutura = Convert.ToString(dt.Rows[0]["DESCRICAO_ESTRUTURA"]);
            if ((dt.Rows[0]["ITEM_CONTROLE"] != null) && (dt.Rows[0]["ITEM_CONTROLE"] != DBNull.Value)) entity.ItemControle = Convert.ToString(dt.Rows[0]["ITEM_CONTROLE"]);
            if ((dt.Rows[0]["DIAM"] != null) && (dt.Rows[0]["DIAM"] != DBNull.Value)) entity.Diam = Convert.ToString(dt.Rows[0]["DIAM"]);
            if ((dt.Rows[0]["EMPRESA_RESPONSAVEL"] != null) && (dt.Rows[0]["EMPRESA_RESPONSAVEL"] != DBNull.Value)) entity.EmpresaResponsavel = Convert.ToString(dt.Rows[0]["EMPRESA_RESPONSAVEL"]);
            if ((dt.Rows[0]["NOTA"] != null) && (dt.Rows[0]["NOTA"] != DBNull.Value)) entity.Nota = Convert.ToString(dt.Rows[0]["NOTA"]);
            if ((dt.Rows[0]["REGIAO"] != null) && (dt.Rows[0]["REGIAO"] != DBNull.Value)) entity.Regiao = Convert.ToString(dt.Rows[0]["REGIAO"]);
            if ((dt.Rows[0]["SEMANA_FOLHA"] != null) && (dt.Rows[0]["SEMANA_FOLHA"] != DBNull.Value)) entity.SemanaFolha = Convert.ToString(dt.Rows[0]["SEMANA_FOLHA"]);
            if ((dt.Rows[0]["SISTEMA"] != null) && (dt.Rows[0]["SISTEMA"] != DBNull.Value)) entity.Sistema = Convert.ToString(dt.Rows[0]["SISTEMA"]);
            if ((dt.Rows[0]["SPEC"] != null) && (dt.Rows[0]["SPEC"] != DBNull.Value)) entity.Spec = Convert.ToString(dt.Rows[0]["SPEC"]);
            if ((dt.Rows[0]["TRATAMENTO"] != null) && (dt.Rows[0]["TRATAMENTO"] != DBNull.Value)) entity.Tratamento = Convert.ToString(dt.Rows[0]["TRATAMENTO"]);
            if ((dt.Rows[0]["INDEFINIDO"] != null) && (dt.Rows[0]["INDEFINIDO"] != DBNull.Value)) entity.Indefinido = Convert.ToString(dt.Rows[0]["INDEFINIDO"]);
            if ((dt.Rows[0]["ZONA_ID"] != null) && (dt.Rows[0]["ZONA_ID"] != DBNull.Value)) entity.ZonaId = Convert.ToDecimal(dt.Rows[0]["ZONA_ID"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["RESPONSAVEL"] != null) && (dt.Rows[0]["RESPONSAVEL"] != DBNull.Value)) entity.Responsavel = Convert.ToString(dt.Rows[0]["RESPONSAVEL"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.AcControleProducaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcControleProducaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcControleProducaoDTO> list = OracleDataTools.LoadEntity<AcControleProducaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoDTO>"); }
        }
        //====================================================================
        public static List<AcControleProducaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoDTO>"); }
        }
        //====================================================================
        public static List<AcControleProducaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleProducaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcControleProducao"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleProducaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcControleProducaoDTO collection = new DTO.CollectionAcControleProducaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcControleProducaoDTO entity = new DTO.AcControleProducaoDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                    if (dt.Rows[i]["MES_COMPETENCIA"].ToString().Length != 0) entity.MesCompetencia = Convert.ToString(dt.Rows[i]["MES_COMPETENCIA"]);
                    if (dt.Rows[i]["ANO_COMPETENCIA"].ToString().Length != 0) entity.AnoCompetencia = Convert.ToString(dt.Rows[i]["ANO_COMPETENCIA"]);
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSE_DESCRICAO"].ToString().Length != 0) entity.FoseDescricao = dt.Rows[i]["FOSE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();

                    if (dt.Rows[i]["SUMA_ATIV_SIG"].ToString().Length != 0) entity.SumaAtivSig = dt.Rows[i]["SUMA_ATIV_SIG"].ToString();
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = dt.Rows[i]["GRCR_NOME"].ToString();

                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["SIFS_DESCRICAO"].ToString().Length != 0) entity.SifsDescricao = dt.Rows[i]["SIFS_DESCRICAO"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToString(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["QTD_ACUMULADA"].ToString().Length != 0) entity.QtdAcumulada = Convert.ToString(dt.Rows[i]["QTD_ACUMULADA"]);
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["FSME_DATA"].ToString().Length != 0) entity.FsmeData = Convert.ToDateTime(dt.Rows[i]["FSME_DATA"]);
                    if (dt.Rows[i]["AVN_POND_EXEC_PERIODO"].ToString().Length != 0) entity.AvnPondExecPeriodo = Convert.ToString(dt.Rows[i]["AVN_POND_EXEC_PERIODO"]);
                    if (dt.Rows[i]["AVN_REAL_EXEC_PERIODO"].ToString().Length != 0) entity.AvnRealExecPeriodo = Convert.ToString(dt.Rows[i]["AVN_REAL_EXEC_PERIODO"]);
                    if (dt.Rows[i]["FSMP_DATA"].ToString().Length != 0) entity.FsmpData = Convert.ToDateTime(dt.Rows[i]["FSMP_DATA"]);
                    if (dt.Rows[i]["AVN_POND_PROG_PERIODO"].ToString().Length != 0) entity.AvnPondProgPeriodo = Convert.ToString(dt.Rows[i]["AVN_POND_PROG_PERIODO"]);
                    if (dt.Rows[i]["AVN_REAL_PROG_PERIODO"].ToString().Length != 0) entity.AvnRealProgPeriodo = Convert.ToString(dt.Rows[i]["AVN_REAL_PROG_PERIODO"]);
                    if (dt.Rows[i]["EQUIPE"].ToString().Length != 0) entity.Equipe = dt.Rows[i]["EQUIPE"].ToString();
                    if (dt.Rows[i]["SETOR"].ToString().Length != 0) entity.Setor = dt.Rows[i]["SETOR"].ToString();
                    if (dt.Rows[i]["LOCALIZACAO"].ToString().Length != 0) entity.Localizacao = dt.Rows[i]["LOCALIZACAO"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["ORIGEM_FABRICACAO"].ToString().Length != 0) entity.OrigemFabricacao = dt.Rows[i]["ORIGEM_FABRICACAO"].ToString();
                    if (dt.Rows[i]["AREA_PINTURA"].ToString().Length != 0) entity.AreaPintura = dt.Rows[i]["AREA_PINTURA"].ToString();
                    if (dt.Rows[i]["CLASSIFICADO"].ToString().Length != 0) entity.Classificado = dt.Rows[i]["CLASSIFICADO"].ToString();
                    if (dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString().Length != 0) entity.DescricaoEstrutura = dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString();
                    if (dt.Rows[i]["ITEM_CONTROLE"].ToString().Length != 0) entity.ItemControle = dt.Rows[i]["ITEM_CONTROLE"].ToString();
                    if (dt.Rows[i]["DIAM"].ToString().Length != 0) entity.Diam = dt.Rows[i]["DIAM"].ToString();
                    if (dt.Rows[i]["EMPRESA_RESPONSAVEL"].ToString().Length != 0) entity.EmpresaResponsavel = dt.Rows[i]["EMPRESA_RESPONSAVEL"].ToString();
                    if (dt.Rows[i]["NOTA"].ToString().Length != 0) entity.Nota = dt.Rows[i]["NOTA"].ToString();
                    if (dt.Rows[i]["REGIAO"].ToString().Length != 0) entity.Regiao = dt.Rows[i]["REGIAO"].ToString();
                    if (dt.Rows[i]["SEMANA_FOLHA"].ToString().Length != 0) entity.SemanaFolha = dt.Rows[i]["SEMANA_FOLHA"].ToString();
                    if (dt.Rows[i]["SISTEMA"].ToString().Length != 0) entity.Sistema = dt.Rows[i]["SISTEMA"].ToString();
                    if (dt.Rows[i]["SPEC"].ToString().Length != 0) entity.Spec = dt.Rows[i]["SPEC"].ToString();
                    if (dt.Rows[i]["TRATAMENTO"].ToString().Length != 0) entity.Tratamento = dt.Rows[i]["TRATAMENTO"].ToString();
                    if (dt.Rows[i]["INDEFINIDO"].ToString().Length != 0) entity.Indefinido = dt.Rows[i]["INDEFINIDO"].ToString();
                    if (dt.Rows[i]["ZONA_ID"].ToString().Length != 0) entity.ZonaId = Convert.ToDecimal(dt.Rows[i]["ZONA_ID"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["RESPONSAVEL"].ToString().Length != 0) entity.Responsavel = dt.Rows[i]["RESPONSAVEL"].ToString();
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
