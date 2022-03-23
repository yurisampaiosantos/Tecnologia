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
    public class AcMontagemTubulacaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.MOTU_ID, X.MOTU_SBCN_SIGLA, X.MOTU_SPOOL, X.MOTU_ISOMETRICO, X.MOTU_SIFS_DESCRICAO, X.MOTU_DESENHO, X.MOTU_PIPELINE, X.MOTU_AREA, X.MOTU_PESO, X.MOTU_COMPRIMENTO, X.MOTU_TSTF_UNIDADE_REGIONAL, X.MOTU_REGIAO, X.MOTU_SISTEMA, X.MOTU_SPEC, TO_CHAR(X.MOTU_PROGRAMADO_FABRICACAO,'DD/MM/YYYY HH24:MI:SS') AS MOTU_PROGRAMADO_FABRICACAO, X.MOTU_FABRICADO, X.MOTU_TRATAMENTO, X.MOTU_TESTE_HIDROSTATICO, X.MOTU_STATUS_GALVANIZADO, TO_CHAR(X.MOTU_DATA_GALVANIZADO,'DD/MM/YYYY HH24:MI:SS') AS MOTU_DATA_GALVANIZADO, X.MOTU_STATUS_REVESTIMENTO, TO_CHAR(X.MOTU_DATA_REVESTIMENTO,'DD/MM/YYYY HH24:MI:SS') AS MOTU_DATA_REVESTIMENTO, X.MOTU_PINTURA, X.MOTU_DISPONIVEL_MONTAGEM, X.MOTU_FOSE_FABRICACAO_ID, X.MOTU_FOSE_MONTAGEM_ID, X.MOTU_FOSE_HIDROSTATICO_ID, X.MOTU_FOSE_GALVANIZACAO_ID, X.MOTU_FOSE_REVESTIMENTO_ID, X.MOTU_FOSE_PINTURA_ID FROM EEP_CONVERSION.AC_MONTAGEM_TUBULACAO X ";
        //====================================================================
        public static int Insert(DTO.AcMontagemTubulacaoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_MONTAGEM_TUBULACAO(MOTU_SBCN_SIGLA,MOTU_SPOOL,MOTU_ISOMETRICO,MOTU_SIFS_DESCRICAO,MOTU_DESENHO,MOTU_PIPELINE,MOTU_AREA,MOTU_PESO,MOTU_COMPRIMENTO,MOTU_TSTF_UNIDADE_REGIONAL,MOTU_REGIAO,MOTU_SISTEMA,MOTU_SPEC,MOTU_PROGRAMADO_FABRICACAO,MOTU_FABRICADO,MOTU_TRATAMENTO,MOTU_TESTE_HIDROSTATICO,MOTU_STATUS_GALVANIZADO,MOTU_DATA_GALVANIZADO,MOTU_STATUS_REVESTIMENTO,MOTU_DATA_REVESTIMENTO,MOTU_PINTURA,MOTU_DISPONIVEL_MONTAGEM,MOTU_FOSE_FABRICACAO_ID,MOTU_FOSE_MONTAGEM_ID,MOTU_FOSE_HIDROSTATICO_ID,MOTU_FOSE_GALVANIZACAO_ID,MOTU_FOSE_REVESTIMENTO_ID,MOTU_FOSE_PINTURA_ID) VALUES(:MOTU_SBCN_SIGLA,:MOTU_SPOOL,:MOTU_ISOMETRICO,:MOTU_SIFS_DESCRICAO,:MOTU_DESENHO,:MOTU_PIPELINE,:MOTU_AREA,:MOTU_PESO,:MOTU_COMPRIMENTO,:MOTU_TSTF_UNIDADE_REGIONAL,:MOTU_REGIAO,:MOTU_SISTEMA,:MOTU_SPEC,:MOTU_PROGRAMADO_FABRICACAO,:MOTU_FABRICADO,:MOTU_TRATAMENTO,:MOTU_TESTE_HIDROSTATICO,:MOTU_STATUS_GALVANIZADO,:MOTU_DATA_GALVANIZADO,:MOTU_STATUS_REVESTIMENTO,:MOTU_DATA_REVESTIMENTO,:MOTU_PINTURA,:MOTU_DISPONIVEL_MONTAGEM,:MOTU_FOSE_FABRICACAO_ID, :MOTU_FOSE_MONTAGEM_ID, :MOTU_FOSE_HIDROSTATICO_ID, :MOTU_FOSE_GALVANIZACAO_ID, :MOTU_FOSE_REVESTIMENTO_ID, :MOTU_FOSE_PINTURA_ID)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MOTU_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.MotuSbcnSigla;
                cmd.Parameters.Add(":MOTU_SPOOL", OracleDbType.Varchar2).Value = entity.MotuSpool;
                cmd.Parameters.Add(":MOTU_ISOMETRICO", OracleDbType.Varchar2).Value = entity.MotuIsometrico;
                cmd.Parameters.Add(":MOTU_SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.MotuSifsDescricao;
                cmd.Parameters.Add(":MOTU_DESENHO", OracleDbType.Varchar2).Value = entity.MotuDesenho;
                cmd.Parameters.Add(":MOTU_PIPELINE", OracleDbType.Varchar2).Value = entity.MotuPipeline;
                cmd.Parameters.Add(":MOTU_AREA", OracleDbType.Decimal).Value = entity.MotuArea;
                cmd.Parameters.Add(":MOTU_PESO", OracleDbType.Decimal).Value = entity.MotuPeso;
                cmd.Parameters.Add(":MOTU_COMPRIMENTO", OracleDbType.Decimal).Value = entity.MotuComprimento;
                cmd.Parameters.Add(":MOTU_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.MotuTstfUnidadeRegional;
                cmd.Parameters.Add(":MOTU_REGIAO", OracleDbType.Varchar2).Value = entity.MotuRegiao;
                cmd.Parameters.Add(":MOTU_SISTEMA", OracleDbType.Varchar2).Value = entity.MotuSistema;
                cmd.Parameters.Add(":MOTU_SPEC", OracleDbType.Varchar2).Value = entity.MotuSpec;
                if (entity.MotuProgramadoFabricacao.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_PROGRAMADO_FABRICACAO", OracleDbType.Date).Value = entity.MotuProgramadoFabricacao;
                else cmd.Parameters.Add(":MOTU_PROGRAMADO_FABRICACAO", OracleDbType.Date).Value = entity.MotuProgramadoFabricacao;
                cmd.Parameters.Add(":MOTU_FABRICADO", OracleDbType.Varchar2).Value = entity.MotuFabricado;
                cmd.Parameters.Add(":MOTU_TRATAMENTO", OracleDbType.Varchar2).Value = entity.MotuTratamento;
                cmd.Parameters.Add(":MOTU_TESTE_HIDROSTATICO", OracleDbType.Varchar2).Value = entity.MotuTesteHidrostatico;
                cmd.Parameters.Add(":MOTU_STATUS_GALVANIZADO", OracleDbType.Decimal).Value = entity.MotuStatusGalvanizado;
                if (entity.MotuDataGalvanizado.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_DATA_GALVANIZADO", OracleDbType.Date).Value = entity.MotuDataGalvanizado;
                else cmd.Parameters.Add(":MOTU_DATA_GALVANIZADO", OracleDbType.Date).Value = entity.MotuDataGalvanizado;
                cmd.Parameters.Add(":MOTU_STATUS_REVESTIMENTO", OracleDbType.Decimal).Value = entity.MotuStatusRevestimento;
                if (entity.MotuDataRevestimento.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_DATA_REVESTIMENTO", OracleDbType.Date).Value = entity.MotuDataRevestimento;
                else cmd.Parameters.Add(":MOTU_DATA_REVESTIMENTO", OracleDbType.Date).Value = entity.MotuDataRevestimento;
                cmd.Parameters.Add(":MOTU_PINTURA", OracleDbType.Decimal).Value = entity.MotuPintura;
                cmd.Parameters.Add(":MOTU_DISPONIVEL_MONTAGEM", OracleDbType.Varchar2).Value = entity.MotuDisponivelMontagem;
                cmd.Parameters.Add(":MOTU_FOSE_FABRICACAO_ID", OracleDbType.Decimal).Value = entity.MotuFoseFabricacaoId;
                cmd.Parameters.Add(":MOTU_FOSE_MONTAGEM_ID", OracleDbType.Decimal).Value = entity.MotuFoseMontagemId;
                cmd.Parameters.Add(":MOTU_FOSE_HIDROSTATICO_ID", OracleDbType.Decimal).Value = entity.MotuFoseHidrostaticoId;
                cmd.Parameters.Add(":MOTU_FOSE_GALVANIZACAO_ID", OracleDbType.Decimal).Value = entity.MotuFoseGalvanizacaoId;
                cmd.Parameters.Add(":MOTU_FOSE_REVESTIMENTO_ID", OracleDbType.Decimal).Value = entity.MotuFoseRevestimentoId;
                cmd.Parameters.Add(":MOTU_FOSE_PINTURA_ID", OracleDbType.Decimal).Value = entity.MotuFosePinturaId;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcMontagemTubulacao");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcMontagemTubulacao");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcMontagemTubulacaoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_MONTAGEM_TUBULACAO set MOTU_SBCN_SIGLA = :MOTU_SBCN_SIGLA, MOTU_SPOOL = :MOTU_SPOOL, MOTU_ISOMETRICO = :MOTU_ISOMETRICO, MOTU_SIFS_DESCRICAO = :MOTU_SIFS_DESCRICAO, MOTU_DESENHO = :MOTU_DESENHO, MOTU_PIPELINE = :MOTU_PIPELINE, MOTU_AREA = :MOTU_AREA, MOTU_PESO = :MOTU_PESO, MOTU_COMPRIMENTO = :MOTU_COMPRIMENTO, MOTU_TSTF_UNIDADE_REGIONAL = :MOTU_TSTF_UNIDADE_REGIONAL, MOTU_REGIAO = :MOTU_REGIAO, MOTU_SISTEMA = :MOTU_SISTEMA, MOTU_SPEC = :MOTU_SPEC, MOTU_PROGRAMADO_FABRICACAO = :MOTU_PROGRAMADO_FABRICACAO, MOTU_FABRICADO = :MOTU_FABRICADO, MOTU_TRATAMENTO = :MOTU_TRATAMENTO, MOTU_TESTE_HIDROSTATICO = :MOTU_TESTE_HIDROSTATICO, MOTU_STATUS_GALVANIZADO = :MOTU_STATUS_GALVANIZADO, MOTU_DATA_GALVANIZADO = :MOTU_DATA_GALVANIZADO, MOTU_STATUS_REVESTIMENTO = :MOTU_STATUS_REVESTIMENTO, MOTU_DATA_REVESTIMENTO = :MOTU_DATA_REVESTIMENTO, MOTU_PINTURA = :MOTU_PINTURA, MOTU_DISPONIVEL_MONTAGEM = :MOTU_DISPONIVEL_MONTAGEM, MOTU_FOSE_FABRICACAO_ID = :MOTU_FOSE_FABRICACAO_ID, MOTU_FOSE_MONTAGEM_ID = :MOTU_FOSE_MONTAGEM_ID, MOTU_FOSE_HIDROSTATICO_ID = :MOTU_FOSE_HIDROSTATICO_ID, MOTU_FOSE_GALVANIZACAO_ID = :MOTU_FOSE_GALVANIZACAO_ID, MOTU_FOSE_REVESTIMENTO_ID = :MOTU_FOSE_REVESTIMENTO_ID, MOTU_FOSE_PINTURA_ID = :MOTU_FOSE_PINTURA_ID WHERE  MOTU_ID = : MOTU_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MOTU_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.MotuSbcnSigla;
                cmd.Parameters.Add(":MOTU_SPOOL", OracleDbType.Varchar2).Value = entity.MotuSpool;
                cmd.Parameters.Add(":MOTU_ISOMETRICO", OracleDbType.Varchar2).Value = entity.MotuIsometrico;
                cmd.Parameters.Add(":MOTU_SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.MotuSifsDescricao;
                cmd.Parameters.Add(":MOTU_DESENHO", OracleDbType.Varchar2).Value = entity.MotuDesenho;
                cmd.Parameters.Add(":MOTU_PIPELINE", OracleDbType.Varchar2).Value = entity.MotuPipeline;
                cmd.Parameters.Add(":MOTU_AREA", OracleDbType.Decimal).Value = entity.MotuArea;
                cmd.Parameters.Add(":MOTU_PESO", OracleDbType.Decimal).Value = entity.MotuPeso;
                cmd.Parameters.Add(":MOTU_COMPRIMENTO", OracleDbType.Decimal).Value = entity.MotuComprimento;
                cmd.Parameters.Add(":MOTU_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.MotuTstfUnidadeRegional;
                cmd.Parameters.Add(":MOTU_REGIAO", OracleDbType.Varchar2).Value = entity.MotuRegiao;
                cmd.Parameters.Add(":MOTU_SISTEMA", OracleDbType.Varchar2).Value = entity.MotuSistema;
                cmd.Parameters.Add(":MOTU_SPEC", OracleDbType.Varchar2).Value = entity.MotuSpec;
                if (entity.MotuProgramadoFabricacao.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_PROGRAMADO_FABRICACAO", OracleDbType.Date).Value = entity.MotuProgramadoFabricacao;
                else cmd.Parameters.Add(":MOTU_PROGRAMADO_FABRICACAO", OracleDbType.Date).Value = entity.MotuProgramadoFabricacao;
                cmd.Parameters.Add(":MOTU_FABRICADO", OracleDbType.Varchar2).Value = entity.MotuFabricado;
                cmd.Parameters.Add(":MOTU_TRATAMENTO", OracleDbType.Varchar2).Value = entity.MotuTratamento;
                cmd.Parameters.Add(":MOTU_TESTE_HIDROSTATICO", OracleDbType.Varchar2).Value = entity.MotuTesteHidrostatico;
                cmd.Parameters.Add(":MOTU_STATUS_GALVANIZADO", OracleDbType.Decimal).Value = entity.MotuStatusGalvanizado;
                if (entity.MotuDataGalvanizado.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_DATA_GALVANIZADO", OracleDbType.Date).Value = entity.MotuDataGalvanizado;
                else cmd.Parameters.Add(":MOTU_DATA_GALVANIZADO", OracleDbType.Date).Value = entity.MotuDataGalvanizado;
                cmd.Parameters.Add(":MOTU_STATUS_REVESTIMENTO", OracleDbType.Decimal).Value = entity.MotuStatusRevestimento;
                if (entity.MotuDataRevestimento.ToOADate() == 0.0) cmd.Parameters.Add(":MOTU_DATA_REVESTIMENTO", OracleDbType.Date).Value = entity.MotuDataRevestimento;
                else cmd.Parameters.Add(":MOTU_DATA_REVESTIMENTO", OracleDbType.Date).Value = entity.MotuDataRevestimento;
                cmd.Parameters.Add(":MOTU_PINTURA", OracleDbType.Decimal).Value = entity.MotuPintura;
                cmd.Parameters.Add(":MOTU_DISPONIVEL_MONTAGEM", OracleDbType.Varchar2).Value = entity.MotuDisponivelMontagem;
                cmd.Parameters.Add(":MOTU_FOSE_FABRICACAO_ID", OracleDbType.Decimal).Value = entity.MotuFoseFabricacaoId;
                cmd.Parameters.Add(":MOTU_FOSE_MONTAGEM_ID", OracleDbType.Decimal).Value = entity.MotuFoseMontagemId;
                cmd.Parameters.Add(":MOTU_FOSE_HIDROSTATICO_ID", OracleDbType.Decimal).Value = entity.MotuFoseHidrostaticoId;
                cmd.Parameters.Add(":MOTU_FOSE_GALVANIZACAO_ID", OracleDbType.Decimal).Value = entity.MotuFoseGalvanizacaoId;
                cmd.Parameters.Add(":MOTU_FOSE_REVESTIMENTO_ID", OracleDbType.Decimal).Value = entity.MotuFoseRevestimentoId;
                cmd.Parameters.Add(":MOTU_FOSE_PINTURA_ID", OracleDbType.Decimal).Value = entity.MotuFosePinturaId;
                cmd.Parameters.Add(":MOTU_ID", OracleDbType.Decimal).Value = entity.MotuFosePinturaId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcMontagemTubulacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal MotuId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_MONTAGEM_TUBULACAO WHERE  MOTU_ID = : MOTU_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MotuId", OracleDbType.Decimal).Value = MotuId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcMontagemTubulacao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcMontagemTubulacao"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_MONTAGEM_TUBULACAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcMontagemTubulacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcMontagemTubulacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcMontagemTubulacao"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcMontagemTubulacao"); }
        }
        //====================================================================
        public static DTO.AcMontagemTubulacaoDTO Get(decimal MotuId)
        {
            AcMontagemTubulacaoDTO entity = new AcMontagemTubulacaoDTO();
            DataTable dt = null;
            string filter = "MOTU_ID = " + MotuId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MOTU_ID"] != null) && (dt.Rows[0]["MOTU_ID"] != DBNull.Value)) entity.MotuId = Convert.ToDecimal(dt.Rows[0]["MOTU_ID"]);
            if ((dt.Rows[0]["MOTU_SBCN_SIGLA"] != null) && (dt.Rows[0]["MOTU_SBCN_SIGLA"] != DBNull.Value)) entity.MotuSbcnSigla = Convert.ToString(dt.Rows[0]["MOTU_SBCN_SIGLA"]);
            if ((dt.Rows[0]["MOTU_SPOOL"] != null) && (dt.Rows[0]["MOTU_SPOOL"] != DBNull.Value)) entity.MotuSpool = Convert.ToString(dt.Rows[0]["MOTU_SPOOL"]);
            if ((dt.Rows[0]["MOTU_ISOMETRICO"] != null) && (dt.Rows[0]["MOTU_ISOMETRICO"] != DBNull.Value)) entity.MotuIsometrico = Convert.ToString(dt.Rows[0]["MOTU_ISOMETRICO"]);
            if ((dt.Rows[0]["MOTU_SIFS_DESCRICAO"] != null) && (dt.Rows[0]["MOTU_SIFS_DESCRICAO"] != DBNull.Value)) entity.MotuSifsDescricao = Convert.ToString(dt.Rows[0]["MOTU_SIFS_DESCRICAO"]);
            if ((dt.Rows[0]["MOTU_DESENHO"] != null) && (dt.Rows[0]["MOTU_DESENHO"] != DBNull.Value)) entity.MotuDesenho = Convert.ToString(dt.Rows[0]["MOTU_DESENHO"]);
            if ((dt.Rows[0]["MOTU_PIPELINE"] != null) && (dt.Rows[0]["MOTU_PIPELINE"] != DBNull.Value)) entity.MotuPipeline = Convert.ToString(dt.Rows[0]["MOTU_PIPELINE"]);
            if ((dt.Rows[0]["MOTU_AREA"] != null) && (dt.Rows[0]["MOTU_AREA"] != DBNull.Value)) entity.MotuArea = Convert.ToDecimal(dt.Rows[0]["MOTU_AREA"]);
            if ((dt.Rows[0]["MOTU_PESO"] != null) && (dt.Rows[0]["MOTU_PESO"] != DBNull.Value)) entity.MotuPeso = Convert.ToDecimal(dt.Rows[0]["MOTU_PESO"]);
            if ((dt.Rows[0]["MOTU_COMPRIMENTO"] != null) && (dt.Rows[0]["MOTU_COMPRIMENTO"] != DBNull.Value)) entity.MotuComprimento = Convert.ToDecimal(dt.Rows[0]["MOTU_COMPRIMENTO"]);
            if ((dt.Rows[0]["MOTU_TSTF_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["MOTU_TSTF_UNIDADE_REGIONAL"] != DBNull.Value)) entity.MotuTstfUnidadeRegional = Convert.ToString(dt.Rows[0]["MOTU_TSTF_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["MOTU_REGIAO"] != null) && (dt.Rows[0]["MOTU_REGIAO"] != DBNull.Value)) entity.MotuRegiao = Convert.ToString(dt.Rows[0]["MOTU_REGIAO"]);
            if ((dt.Rows[0]["MOTU_SISTEMA"] != null) && (dt.Rows[0]["MOTU_SISTEMA"] != DBNull.Value)) entity.MotuSistema = Convert.ToString(dt.Rows[0]["MOTU_SISTEMA"]);
            if ((dt.Rows[0]["MOTU_SPEC"] != null) && (dt.Rows[0]["MOTU_SPEC"] != DBNull.Value)) entity.MotuSpec = Convert.ToString(dt.Rows[0]["MOTU_SPEC"]);
            if ((dt.Rows[0]["MOTU_PROGRAMADO_FABRICACAO"] != null) && (dt.Rows[0]["MOTU_PROGRAMADO_FABRICACAO"] != DBNull.Value)) entity.MotuProgramadoFabricacao = Convert.ToDateTime(dt.Rows[0]["MOTU_PROGRAMADO_FABRICACAO"]);
            if ((dt.Rows[0]["MOTU_FABRICADO"] != null) && (dt.Rows[0]["MOTU_FABRICADO"] != DBNull.Value)) entity.MotuFabricado = Convert.ToString(dt.Rows[0]["MOTU_FABRICADO"]);
            if ((dt.Rows[0]["MOTU_TRATAMENTO"] != null) && (dt.Rows[0]["MOTU_TRATAMENTO"] != DBNull.Value)) entity.MotuTratamento = Convert.ToString(dt.Rows[0]["MOTU_TRATAMENTO"]);
            if ((dt.Rows[0]["MOTU_TESTE_HIDROSTATICO"] != null) && (dt.Rows[0]["MOTU_TESTE_HIDROSTATICO"] != DBNull.Value)) entity.MotuTesteHidrostatico = Convert.ToString(dt.Rows[0]["MOTU_TESTE_HIDROSTATICO"]);
            if ((dt.Rows[0]["MOTU_STATUS_GALVANIZADO"] != null) && (dt.Rows[0]["MOTU_STATUS_GALVANIZADO"] != DBNull.Value)) entity.MotuStatusGalvanizado = Convert.ToDecimal(dt.Rows[0]["MOTU_STATUS_GALVANIZADO"]);
            if ((dt.Rows[0]["MOTU_DATA_GALVANIZADO"] != null) && (dt.Rows[0]["MOTU_DATA_GALVANIZADO"] != DBNull.Value)) entity.MotuDataGalvanizado = Convert.ToDateTime(dt.Rows[0]["MOTU_DATA_GALVANIZADO"]);
            if ((dt.Rows[0]["MOTU_STATUS_REVESTIMENTO"] != null) && (dt.Rows[0]["MOTU_STATUS_REVESTIMENTO"] != DBNull.Value)) entity.MotuStatusRevestimento = Convert.ToDecimal(dt.Rows[0]["MOTU_STATUS_REVESTIMENTO"]);
            if ((dt.Rows[0]["MOTU_DATA_REVESTIMENTO"] != null) && (dt.Rows[0]["MOTU_DATA_REVESTIMENTO"] != DBNull.Value)) entity.MotuDataRevestimento = Convert.ToDateTime(dt.Rows[0]["MOTU_DATA_REVESTIMENTO"]);
            if ((dt.Rows[0]["MOTU_PINTURA"] != null) && (dt.Rows[0]["MOTU_PINTURA"] != DBNull.Value)) entity.MotuPintura = Convert.ToDecimal(dt.Rows[0]["MOTU_PINTURA"]);
            if ((dt.Rows[0]["MOTU_DISPONIVEL_MONTAGEM"] != null) && (dt.Rows[0]["MOTU_DISPONIVEL_MONTAGEM"] != DBNull.Value)) entity.MotuDisponivelMontagem = Convert.ToString(dt.Rows[0]["MOTU_DISPONIVEL_MONTAGEM"]);
            if ((dt.Rows[0]["MOTU_FOSE_FABRICACAO_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_FABRICACAO_ID"] != DBNull.Value)) entity.MotuFoseFabricacaoId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_FABRICACAO_ID"]);
            if ((dt.Rows[0]["MOTU_FOSE_MONTAGEM_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_MONTAGEM_ID"] != DBNull.Value)) entity.MotuFoseMontagemId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_MONTAGEM_ID"]);
            if ((dt.Rows[0]["MOTU_FOSE_HIDROSTATICO_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_HIDROSTATICO_ID"] != DBNull.Value)) entity.MotuFoseHidrostaticoId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_HIDROSTATICO_ID"]);
            if ((dt.Rows[0]["MOTU_FOSE_GALVANIZACAO_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_GALVANIZACAO_ID"] != DBNull.Value)) entity.MotuFoseGalvanizacaoId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_GALVANIZACAO_ID"]);
            if ((dt.Rows[0]["MOTU_FOSE_REVESTIMENTO_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_REVESTIMENTO_ID"] != DBNull.Value)) entity.MotuFoseRevestimentoId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_REVESTIMENTO_ID"]);
            if ((dt.Rows[0]["MOTU_FOSE_PINTURA_ID"] != null) && (dt.Rows[0]["MOTU_FOSE_PINTURA_ID"] != DBNull.Value)) entity.MotuFosePinturaId = Convert.ToDecimal(dt.Rows[0]["MOTU_FOSE_PINTURA_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcMontagemTubulacaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MOTU_FOSE_PINTURA_ID Object"); }
        }
        //====================================================================
        public static List<AcMontagemTubulacaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcMontagemTubulacaoDTO> list = OracleDataTools.LoadEntity<AcMontagemTubulacaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMontagemTubulacaoDTO>"); }
        }
        //====================================================================
        public static List<AcMontagemTubulacaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMontagemTubulacaoDTO>"); }
        }
        //====================================================================
        public static List<AcMontagemTubulacaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMontagemTubulacaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcMontagemTubulacaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcMontagemTubulacao"); }
        }
        //====================================================================
        public static DTO.CollectionAcMontagemTubulacaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcMontagemTubulacaoDTO collection = new DTO.CollectionAcMontagemTubulacaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcMontagemTubulacaoDTO entity = new DTO.AcMontagemTubulacaoDTO();
                    if (dt.Rows[i]["MOTU_ID"].ToString().Length != 0) entity.MotuId = Convert.ToDecimal(dt.Rows[i]["MOTU_ID"]);
                    if (dt.Rows[i]["MOTU_SBCN_SIGLA"].ToString().Length != 0) entity.MotuSbcnSigla = dt.Rows[i]["MOTU_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["MOTU_SPOOL"].ToString().Length != 0) entity.MotuSpool = dt.Rows[i]["MOTU_SPOOL"].ToString();
                    if (dt.Rows[i]["MOTU_ISOMETRICO"].ToString().Length != 0) entity.MotuIsometrico = dt.Rows[i]["MOTU_ISOMETRICO"].ToString();
                    if (dt.Rows[i]["MOTU_SIFS_DESCRICAO"].ToString().Length != 0) entity.MotuSifsDescricao = dt.Rows[i]["MOTU_SIFS_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MOTU_DESENHO"].ToString().Length != 0) entity.MotuDesenho = dt.Rows[i]["MOTU_DESENHO"].ToString();
                    if (dt.Rows[i]["MOTU_PIPELINE"].ToString().Length != 0) entity.MotuPipeline = dt.Rows[i]["MOTU_PIPELINE"].ToString();
                    if (dt.Rows[i]["MOTU_AREA"].ToString().Length != 0) entity.MotuArea = Convert.ToDecimal(dt.Rows[i]["MOTU_AREA"]);
                    if (dt.Rows[i]["MOTU_PESO"].ToString().Length != 0) entity.MotuPeso = Convert.ToDecimal(dt.Rows[i]["MOTU_PESO"]);
                    if (dt.Rows[i]["MOTU_COMPRIMENTO"].ToString().Length != 0) entity.MotuComprimento = Convert.ToDecimal(dt.Rows[i]["MOTU_COMPRIMENTO"]);
                    if (dt.Rows[i]["MOTU_TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.MotuTstfUnidadeRegional = dt.Rows[i]["MOTU_TSTF_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["MOTU_REGIAO"].ToString().Length != 0) entity.MotuRegiao = dt.Rows[i]["MOTU_REGIAO"].ToString();
                    if (dt.Rows[i]["MOTU_SISTEMA"].ToString().Length != 0) entity.MotuSistema = dt.Rows[i]["MOTU_SISTEMA"].ToString();
                    if (dt.Rows[i]["MOTU_SPEC"].ToString().Length != 0) entity.MotuSpec = dt.Rows[i]["MOTU_SPEC"].ToString();
                    if (dt.Rows[i]["MOTU_PROGRAMADO_FABRICACAO"].ToString().Length != 0) entity.MotuProgramadoFabricacao = Convert.ToDateTime(dt.Rows[i]["MOTU_PROGRAMADO_FABRICACAO"]);
                    if (dt.Rows[i]["MOTU_FABRICADO"].ToString().Length != 0) entity.MotuFabricado = dt.Rows[i]["MOTU_FABRICADO"].ToString();
                    if (dt.Rows[i]["MOTU_TRATAMENTO"].ToString().Length != 0) entity.MotuTratamento = dt.Rows[i]["MOTU_TRATAMENTO"].ToString();
                    if (dt.Rows[i]["MOTU_TESTE_HIDROSTATICO"].ToString().Length != 0) entity.MotuTesteHidrostatico = dt.Rows[i]["MOTU_TESTE_HIDROSTATICO"].ToString();
                    if (dt.Rows[i]["MOTU_STATUS_GALVANIZADO"].ToString().Length != 0) entity.MotuStatusGalvanizado = Convert.ToDecimal(dt.Rows[i]["MOTU_STATUS_GALVANIZADO"]);
                    if (dt.Rows[i]["MOTU_DATA_GALVANIZADO"].ToString().Length != 0) entity.MotuDataGalvanizado = Convert.ToDateTime(dt.Rows[i]["MOTU_DATA_GALVANIZADO"]);
                    if (dt.Rows[i]["MOTU_STATUS_REVESTIMENTO"].ToString().Length != 0) entity.MotuStatusRevestimento = Convert.ToDecimal(dt.Rows[i]["MOTU_STATUS_REVESTIMENTO"]);
                    if (dt.Rows[i]["MOTU_DATA_REVESTIMENTO"].ToString().Length != 0) entity.MotuDataRevestimento = Convert.ToDateTime(dt.Rows[i]["MOTU_DATA_REVESTIMENTO"]);
                    if (dt.Rows[i]["MOTU_PINTURA"].ToString().Length != 0) entity.MotuPintura = Convert.ToDecimal(dt.Rows[i]["MOTU_PINTURA"]);
                    if (dt.Rows[i]["MOTU_DISPONIVEL_MONTAGEM"].ToString().Length != 0) entity.MotuDisponivelMontagem = dt.Rows[i]["MOTU_DISPONIVEL_MONTAGEM"].ToString();
                    if (dt.Rows[i]["MOTU_FOSE_FABRICACAO_ID"].ToString().Length != 0) entity.MotuFoseFabricacaoId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_FABRICACAO_ID"]);
                    if (dt.Rows[i]["MOTU_FOSE_MONTAGEM_ID"].ToString().Length != 0) entity.MotuFoseMontagemId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_MONTAGEM_ID"]);
                    if (dt.Rows[i]["MOTU_FOSE_HIDROSTATICO_ID"].ToString().Length != 0) entity.MotuFoseHidrostaticoId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_HIDROSTATICO_ID"]);
                    if (dt.Rows[i]["MOTU_FOSE_GALVANIZACAO_ID"].ToString().Length != 0) entity.MotuFoseGalvanizacaoId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_GALVANIZACAO_ID"]);
                    if (dt.Rows[i]["MOTU_FOSE_REVESTIMENTO_ID"].ToString().Length != 0) entity.MotuFoseRevestimentoId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_REVESTIMENTO_ID"]);
                    if (dt.Rows[i]["MOTU_FOSE_PINTURA_ID"].ToString().Length != 0) entity.MotuFosePinturaId = Convert.ToDecimal(dt.Rows[i]["MOTU_FOSE_PINTURA_ID"]);

                    collection.Add(entity);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - GetCollection Method"); }
            dt.Dispose();
            return collection;
        }
        ////====================================================================
        //private static Hashtable GetDictionary()
        //{
        //    Hashtable dict = new Hashtable();
        //    dict.Add("MotuId", "MOTU_ID");
        //    dict.Add("MotuSbcnSigla", "MOTU_SBCN_SIGLA");
        //    dict.Add("MotuSpool", "MOTU_SPOOL");
        //    dict.Add("MotuIsometrico", "MOTU_ISOMETRICO");
        //    dict.Add("MotuStatus", "MOTU_STATUS");
        //    dict.Add("MotuDesenho", "MOTU_DESENHO");
        //    dict.Add("MotuPipeline", "MOTU_PIPELINE");
        //    dict.Add("MotuArea", "MOTU_AREA");
        //    dict.Add("MotuPeso", "MOTU_PESO");
        //    dict.Add("MotuComprimento", "MOTU_COMPRIMENTO");
        //    dict.Add("MotuTstfUnidadeRegional", "MOTU_TSTF_UNIDADE_REGIONAL");
        //    dict.Add("MotuRegiao", "MOTU_REGIAO");
        //    dict.Add("MotuSistema", "MOTU_SISTEMA");
        //    dict.Add("MotuSpec", "MOTU_SPEC");
        //    dict.Add("MotuProgramadoFabricacao", "MOTU_PROGRAMADO_FABRICACAO");
        //    dict.Add("MotuFabricado", "MOTU_FABRICADO");
        //    dict.Add("MotuTratamento", "MOTU_TRATAMENTO");
        //    dict.Add("MotuTesteHidrostatico", "MOTU_TESTE_HIDROSTATICO");
        //    dict.Add("MotuStatusGalvanizado", "MOTU_STATUS_GALVANIZADO");
        //    dict.Add("MotuDataGalvanizado", "MOTU_DATA_GALVANIZADO");
        //    dict.Add("MotuStatusRevestimento", "MOTU_STATUS_REVESTIMENTO");
        //    dict.Add("MotuDataRevestimento", "MOTU_DATA_REVESTIMENTO");
        //    dict.Add("MotuPintura", "MOTU_PINTURA");
        //    dict.Add("MotuDisponivelMontagem", "MOTU_DISPONIVEL_MONTAGEM");
        //    dict.Add("MotuFoseFabricacaoId", "MOTU_FOSE_FABRICACAO_ID");
        //    dict.Add("MotuFoseMontagemId", "MOTU_FOSE_MONTAGEM_ID");
        //    dict.Add("MotuFoseHidrostaticoId", "MOTU_FOSE_HIDROSTATICO_ID");
        //    dict.Add("MotuFoseGalvanizacaoId", "MOTU_FOSE_GALVANIZACAO_ID");
        //    dict.Add("MotuFoseRevestimentoId", "MOTU_FOSE_REVESTIMENTO_ID");
        //    dict.Add("MotuFosePinturaId", "MOTU_FOSE_PINTURA_ID");
        //    return dict;
        //}
        //====================================================================
        #endregion
    }
}
