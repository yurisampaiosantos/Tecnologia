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
    public class AcMateriaisPendentesDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.MAPD_ID, X.MAPD_COMA_ID, X.MAPD_SBCN_SIGLA, X.MAPD_DISC_ID, X.MAPD_DIPR_CODIGO, X.MAPD_DIPR_DIMENSOES, X.MAPD_UNME_SIGLA, X.MAPD_QTD_NEC_ANTERIOR_CORRIDA, X.MAPD_QTD_NEC_CORRIDA, X.MAPD_QTD_NEC_TOTAL, X.MAPD_QTD_MATERIAL_RM, X.MAPD_COBERTURA_RM, X.MAPD_QTD_MATERIAL_AF, X.MAPD_COBERTURA_AF, X.MAPD_DCMN_NUMERO, X.MAPD_REPL_REV, X.MAPD_AUFO_NUMERO, X.MAPD_AUFO_EMPR_NOME, X.MAPD_PROX_DATA_RECEBIMENTO, X.MAPD_NOTAS_FISCAIS, X.MAPD_NFIT_QTD, X.MAPD_SALDO_ENTREGA, X.MAPD_AGUARDANDO_RECEBIMENTO, X.MAPD_CORRECAO_RM, X.MAPD_SOLICITACAO_COMPRA, X.MAPD_PREVISAO_RECEBIMENTO, X.MAPD_COMENT_SUPR, X.MAPD_DATAS_RECEBIMENTO, X.MAPD_NOEN_NUMERO, X.MAPD_NOEI_QTD_NEM, X.MAPD_SALDO_LIBERADO, X.MAPD_DVRE_NUMERO, X.MAPD_AREAS_ESTOCAGEM, X.MAPD_DIPR_DESCRICAO, X.MAPD_DCMN_ID, X.MAPD_NOFI_REFERENCIA FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES X ";
        //====================================================================
        public static int Insert(DTO.AcMateriaisPendentesDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_MATERIAIS_PENDENTES(MAPD_COMA_ID,MAPD_SBCN_SIGLA,MAPD_DISC_ID,MAPD_DIPR_CODIGO,MAPD_DIPR_DIMENSOES,MAPD_UNME_SIGLA,MAPD_QTD_NEC_ANTERIOR_CORRIDA,MAPD_QTD_NEC_CORRIDA,MAPD_QTD_NEC_TOTAL,MAPD_QTD_MATERIAL_RM,MAPD_COBERTURA_RM,MAPD_QTD_MATERIAL_AF,MAPD_COBERTURA_AF,MAPD_DCMN_NUMERO,MAPD_REPL_REV,MAPD_AUFO_NUMERO,MAPD_AUFO_EMPR_NOME,MAPD_PROX_DATA_RECEBIMENTO,MAPD_NOTAS_FISCAIS,MAPD_NFIT_QTD,MAPD_SALDO_ENTREGA,MAPD_AGUARDANDO_RECEBIMENTO,MAPD_CORRECAO_RM,MAPD_SOLICITACAO_COMPRA,MAPD_PREVISAO_RECEBIMENTO,MAPD_COMENT_SUPR,MAPD_DATAS_RECEBIMENTO,MAPD_NOEN_NUMERO,MAPD_NOEI_QTD_NEM,MAPD_SALDO_LIBERADO,MAPD_DVRE_NUMERO,MAPD_AREAS_ESTOCAGEM,MAPD_DIPR_DESCRICAO,MAPD_DCMN_ID,MAPD_NOFI_REFERENCIA) VALUES(:MAPD_COMA_ID,:MAPD_SBCN_SIGLA,:MAPD_DISC_ID,:MAPD_DIPR_CODIGO,:MAPD_DIPR_DIMENSOES,:MAPD_UNME_SIGLA,:MAPD_QTD_NEC_ANTERIOR_CORRIDA,:MAPD_QTD_NEC_CORRIDA,:MAPD_QTD_NEC_TOTAL,:MAPD_QTD_MATERIAL_RM,:MAPD_COBERTURA_RM,:MAPD_QTD_MATERIAL_AF,:MAPD_COBERTURA_AF,:MAPD_DCMN_NUMERO,:MAPD_REPL_REV,:MAPD_AUFO_NUMERO,:MAPD_AUFO_EMPR_NOME,:MAPD_PROX_DATA_RECEBIMENTO,:MAPD_NOTAS_FISCAIS,:MAPD_NFIT_QTD,:MAPD_SALDO_ENTREGA,:MAPD_AGUARDANDO_RECEBIMENTO,:MAPD_CORRECAO_RM,:MAPD_SOLICITACAO_COMPRA,:MAPD_PREVISAO_RECEBIMENTO,:MAPD_COMENT_SUPR,:MAPD_DATAS_RECEBIMENTO,:MAPD_NOEN_NUMERO,:MAPD_NOEI_QTD_NEM,:MAPD_SALDO_LIBERADO,:MAPD_DVRE_NUMERO,:MAPD_AREAS_ESTOCAGEM,:MAPD_DIPR_DESCRICAO,:MAPD_DCMN_ID,:MAPD_NOFI_REFERENCIA)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MAPD_COMA_ID", OracleDbType.Decimal).Value = entity.MapdComaId;
                cmd.Parameters.Add(":MAPD_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.MapdSbcnSigla;
                cmd.Parameters.Add(":MAPD_DISC_ID", OracleDbType.Decimal).Value = entity.MapdDiscId;
                cmd.Parameters.Add(":MAPD_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.MapdDiprCodigo;
                cmd.Parameters.Add(":MAPD_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.MapdDiprDimensoes;
                cmd.Parameters.Add(":MAPD_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.MapdUnmeSigla;
                cmd.Parameters.Add(":MAPD_QTD_NEC_ANTERIOR_CORRIDA", OracleDbType.Decimal).Value = entity.MapdQtdNecAnteriorCorrida;
                cmd.Parameters.Add(":MAPD_QTD_NEC_CORRIDA", OracleDbType.Decimal).Value = entity.MapdQtdNecCorrida;
                cmd.Parameters.Add(":MAPD_QTD_NEC_TOTAL", OracleDbType.Decimal).Value = entity.MapdQtdNecTotal;
                cmd.Parameters.Add(":MAPD_QTD_MATERIAL_RM", OracleDbType.Decimal).Value = entity.MapdQtdMaterialRm;
                cmd.Parameters.Add(":MAPD_COBERTURA_RM", OracleDbType.Decimal).Value = entity.MapdCoberturaRm;
                cmd.Parameters.Add(":MAPD_QTD_MATERIAL_AF", OracleDbType.Decimal).Value = entity.MapdQtdMaterialAf;
                cmd.Parameters.Add(":MAPD_COBERTURA_AF", OracleDbType.Decimal).Value = entity.MapdCoberturaAf;
                cmd.Parameters.Add(":MAPD_DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.MapdDcmnNumero;
                cmd.Parameters.Add(":MAPD_REPL_REV", OracleDbType.Varchar2).Value = entity.MapdReplRev;
                cmd.Parameters.Add(":MAPD_AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.MapdAufoNumero;
                cmd.Parameters.Add(":MAPD_AUFO_EMPR_NOME", OracleDbType.Varchar2).Value = entity.MapdAufoEmprNome;
                cmd.Parameters.Add(":MAPD_PROX_DATA_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdProxDataRecebimento;
                cmd.Parameters.Add(":MAPD_NOTAS_FISCAIS", OracleDbType.Varchar2).Value = entity.MapdNotasFiscais;
                cmd.Parameters.Add(":MAPD_NFIT_QTD", OracleDbType.Decimal).Value = entity.MapdNfitQtd;
                cmd.Parameters.Add(":MAPD_SALDO_ENTREGA", OracleDbType.Decimal).Value = entity.MapdSaldoEntrega;
                cmd.Parameters.Add(":MAPD_AGUARDANDO_RECEBIMENTO", OracleDbType.Decimal).Value = entity.MapdAguardandoRecebimento;
                cmd.Parameters.Add(":MAPD_CORRECAO_RM", OracleDbType.Decimal).Value = entity.MapdCorrecaoRm;
                cmd.Parameters.Add(":MAPD_SOLICITACAO_COMPRA", OracleDbType.Decimal).Value = entity.MapdSolicitacaoCompra;
                cmd.Parameters.Add(":MAPD_PREVISAO_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdPrevisaoRecebimento;
                cmd.Parameters.Add(":MAPD_COMENT_SUPR", OracleDbType.Varchar2).Value = entity.MapdComentSupr;
                cmd.Parameters.Add(":MAPD_DATAS_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdDatasRecebimento;
                cmd.Parameters.Add(":MAPD_NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.MapdNoenNumero;
                cmd.Parameters.Add(":MAPD_NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.MapdNoeiQtdNem;
                cmd.Parameters.Add(":MAPD_SALDO_LIBERADO", OracleDbType.Decimal).Value = entity.MapdSaldoLiberado;
                cmd.Parameters.Add(":MAPD_DVRE_NUMERO", OracleDbType.Varchar2).Value = entity.MapdDvreNumero;
                cmd.Parameters.Add(":MAPD_AREAS_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.MapdAreasEstocagem;
                cmd.Parameters.Add(":MAPD_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.MapdDiprDescricao;
                cmd.Parameters.Add(":MAPD_DCMN_ID", OracleDbType.Decimal).Value = entity.MapdDcmnId;
                cmd.Parameters.Add(":MAPD_NOFI_REFERENCIA", OracleDbType.Varchar2).Value = entity.MapdNofiReferencia;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcMateriaisPendentes");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcMateriaisPendentes");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcMateriaisPendentesDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_MATERIAIS_PENDENTES set MAPD_COMA_ID = :MAPD_COMA_ID, MAPD_SBCN_SIGLA = :MAPD_SBCN_SIGLA, MAPD_DISC_ID = :MAPD_DISC_ID, MAPD_DIPR_CODIGO = :MAPD_DIPR_CODIGO, MAPD_DIPR_DIMENSOES = :MAPD_DIPR_DIMENSOES, MAPD_UNME_SIGLA = :MAPD_UNME_SIGLA, MAPD_QTD_NEC_ANTERIOR_CORRIDA = :MAPD_QTD_NEC_ANTERIOR_CORRIDA, MAPD_QTD_NEC_CORRIDA = :MAPD_QTD_NEC_CORRIDA, MAPD_QTD_NEC_TOTAL = :MAPD_QTD_NEC_TOTAL, MAPD_QTD_MATERIAL_RM = :MAPD_QTD_MATERIAL_RM, MAPD_COBERTURA_RM = :MAPD_COBERTURA_RM, MAPD_QTD_MATERIAL_AF = :MAPD_QTD_MATERIAL_AF, MAPD_COBERTURA_AF = :MAPD_COBERTURA_AF, MAPD_DCMN_NUMERO = :MAPD_DCMN_NUMERO, MAPD_REPL_REV = :MAPD_REPL_REV, MAPD_AUFO_NUMERO = :MAPD_AUFO_NUMERO, MAPD_AUFO_EMPR_NOME = :MAPD_AUFO_EMPR_NOME, MAPD_PROX_DATA_RECEBIMENTO = :MAPD_PROX_DATA_RECEBIMENTO, MAPD_NOTAS_FISCAIS = :MAPD_NOTAS_FISCAIS, MAPD_NFIT_QTD = :MAPD_NFIT_QTD, MAPD_SALDO_ENTREGA = :MAPD_SALDO_ENTREGA, MAPD_AGUARDANDO_RECEBIMENTO = :MAPD_AGUARDANDO_RECEBIMENTO, MAPD_CORRECAO_RM = :MAPD_CORRECAO_RM, MAPD_SOLICITACAO_COMPRA = :MAPD_SOLICITACAO_COMPRA, MAPD_PREVISAO_RECEBIMENTO = :MAPD_PREVISAO_RECEBIMENTO, MAPD_COMENT_SUPR = :MAPD_COMENT_SUPR, MAPD_DATAS_RECEBIMENTO = :MAPD_DATAS_RECEBIMENTO, MAPD_NOEN_NUMERO = :MAPD_NOEN_NUMERO, MAPD_NOEI_QTD_NEM = :MAPD_NOEI_QTD_NEM, MAPD_SALDO_LIBERADO = :MAPD_SALDO_LIBERADO, MAPD_DVRE_NUMERO = :MAPD_DVRE_NUMERO, MAPD_AREAS_ESTOCAGEM = :MAPD_AREAS_ESTOCAGEM, MAPD_DIPR_DESCRICAO = :MAPD_DIPR_DESCRICAO, MAPD_DCMN_ID = :MAPD_DCMN_ID, MAPD_NOFI_REFERENCIA = :MAPD_NOFI_REFERENCIA WHERE  MAPD_ID = : MAPD_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("MAPD_COMA_ID", OracleDbType.Decimal).Value = entity.MapdComaId;
                cmd.Parameters.Add("MAPD_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.MapdSbcnSigla;
                cmd.Parameters.Add("MAPD_DISC_ID", OracleDbType.Decimal).Value = entity.MapdDiscId;
                cmd.Parameters.Add("MAPD_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.MapdDiprCodigo;
                cmd.Parameters.Add("MAPD_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.MapdDiprDimensoes;
                cmd.Parameters.Add("MAPD_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.MapdUnmeSigla;
                cmd.Parameters.Add("MAPD_QTD_NEC_ANTERIOR_CORRIDA", OracleDbType.Decimal).Value = entity.MapdQtdNecAnteriorCorrida;
                cmd.Parameters.Add("MAPD_QTD_NEC_CORRIDA", OracleDbType.Decimal).Value = entity.MapdQtdNecCorrida;
                cmd.Parameters.Add("MAPD_QTD_NEC_TOTAL", OracleDbType.Decimal).Value = entity.MapdQtdNecTotal;
                cmd.Parameters.Add("MAPD_QTD_MATERIAL_RM", OracleDbType.Decimal).Value = entity.MapdQtdMaterialRm;
                cmd.Parameters.Add("MAPD_COBERTURA_RM", OracleDbType.Decimal).Value = entity.MapdCoberturaRm;
                cmd.Parameters.Add("MAPD_QTD_MATERIAL_AF", OracleDbType.Decimal).Value = entity.MapdQtdMaterialAf;
                cmd.Parameters.Add("MAPD_COBERTURA_AF", OracleDbType.Decimal).Value = entity.MapdCoberturaAf;
                cmd.Parameters.Add("MAPD_DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.MapdDcmnNumero;
                cmd.Parameters.Add("MAPD_REPL_REV", OracleDbType.Varchar2).Value = entity.MapdReplRev;
                cmd.Parameters.Add("MAPD_AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.MapdAufoNumero;
                cmd.Parameters.Add("MAPD_AUFO_EMPR_NOME", OracleDbType.Varchar2).Value = entity.MapdAufoEmprNome;
                cmd.Parameters.Add("MAPD_PROX_DATA_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdProxDataRecebimento;
                cmd.Parameters.Add("MAPD_NOTAS_FISCAIS", OracleDbType.Varchar2).Value = entity.MapdNotasFiscais;
                cmd.Parameters.Add("MAPD_NFIT_QTD", OracleDbType.Decimal).Value = entity.MapdNfitQtd;
                cmd.Parameters.Add("MAPD_SALDO_ENTREGA", OracleDbType.Decimal).Value = entity.MapdSaldoEntrega;
                cmd.Parameters.Add("MAPD_AGUARDANDO_RECEBIMENTO", OracleDbType.Decimal).Value = entity.MapdAguardandoRecebimento;
                cmd.Parameters.Add("MAPD_CORRECAO_RM", OracleDbType.Decimal).Value = entity.MapdCorrecaoRm;
                cmd.Parameters.Add("MAPD_SOLICITACAO_COMPRA", OracleDbType.Decimal).Value = entity.MapdSolicitacaoCompra;
                cmd.Parameters.Add("MAPD_PREVISAO_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdPrevisaoRecebimento;
                cmd.Parameters.Add("MAPD_COMENT_SUPR", OracleDbType.Varchar2).Value = entity.MapdComentSupr;
                cmd.Parameters.Add("MAPD_DATAS_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.MapdDatasRecebimento;
                cmd.Parameters.Add("MAPD_NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.MapdNoenNumero;
                cmd.Parameters.Add("MAPD_NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.MapdNoeiQtdNem;
                cmd.Parameters.Add("MAPD_SALDO_LIBERADO", OracleDbType.Decimal).Value = entity.MapdSaldoLiberado;
                cmd.Parameters.Add("MAPD_DVRE_NUMERO", OracleDbType.Varchar2).Value = entity.MapdDvreNumero;
                cmd.Parameters.Add("MAPD_AREAS_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.MapdAreasEstocagem;
                cmd.Parameters.Add("MAPD_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.MapdDiprDescricao;
                cmd.Parameters.Add("MAPD_DCMN_ID", OracleDbType.Decimal).Value = entity.MapdDcmnId;
                cmd.Parameters.Add("MAPD_NOFI_REFERENCIA", OracleDbType.Varchar2).Value = entity.MapdNofiReferencia;
                cmd.Parameters.Add("MAPD_ID", OracleDbType.Decimal).Value = entity.MapdId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcMateriaisPendentes"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal MapdId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES WHERE  MAPD_ID = : MAPD_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":MapdId", OracleDbType.Decimal).Value = MapdId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcMateriaisPendentes"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcMateriaisPendentes"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcMateriaisPendentes"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcMateriaisPendentes"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcMateriaisPendentes"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcMateriaisPendentes"); }
        }
        //====================================================================
        public static DTO.AcMateriaisPendentesDTO Get(decimal MapdId)
        {
            AcMateriaisPendentesDTO entity = new AcMateriaisPendentesDTO();
            DataTable dt = null;
            string filter = "MAPD_ID = " + MapdId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MAPD_ID"] != null) && (dt.Rows[0]["MAPD_ID"] != DBNull.Value)) entity.MapdId = Convert.ToDecimal(dt.Rows[0]["MAPD_ID"]);
            if ((dt.Rows[0]["MAPD_COMA_ID"] != null) && (dt.Rows[0]["MAPD_COMA_ID"] != DBNull.Value)) entity.MapdComaId = Convert.ToDecimal(dt.Rows[0]["MAPD_COMA_ID"]);
            if ((dt.Rows[0]["MAPD_SBCN_SIGLA"] != null) && (dt.Rows[0]["MAPD_SBCN_SIGLA"] != DBNull.Value)) entity.MapdSbcnSigla = Convert.ToString(dt.Rows[0]["MAPD_SBCN_SIGLA"]);
            if ((dt.Rows[0]["MAPD_DISC_ID"] != null) && (dt.Rows[0]["MAPD_DISC_ID"] != DBNull.Value)) entity.MapdDiscId = Convert.ToDecimal(dt.Rows[0]["MAPD_DISC_ID"]);
            if ((dt.Rows[0]["MAPD_DIPR_CODIGO"] != null) && (dt.Rows[0]["MAPD_DIPR_CODIGO"] != DBNull.Value)) entity.MapdDiprCodigo = Convert.ToString(dt.Rows[0]["MAPD_DIPR_CODIGO"]);
            if ((dt.Rows[0]["MAPD_DIPR_DIMENSOES"] != null) && (dt.Rows[0]["MAPD_DIPR_DIMENSOES"] != DBNull.Value)) entity.MapdDiprDimensoes = Convert.ToString(dt.Rows[0]["MAPD_DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["MAPD_UNME_SIGLA"] != null) && (dt.Rows[0]["MAPD_UNME_SIGLA"] != DBNull.Value)) entity.MapdUnmeSigla = Convert.ToString(dt.Rows[0]["MAPD_UNME_SIGLA"]);
            if ((dt.Rows[0]["MAPD_QTD_NEC_ANTERIOR_CORRIDA"] != null) && (dt.Rows[0]["MAPD_QTD_NEC_ANTERIOR_CORRIDA"] != DBNull.Value)) entity.MapdQtdNecAnteriorCorrida = Convert.ToDecimal(dt.Rows[0]["MAPD_QTD_NEC_ANTERIOR_CORRIDA"]);
            if ((dt.Rows[0]["MAPD_QTD_NEC_CORRIDA"] != null) && (dt.Rows[0]["MAPD_QTD_NEC_CORRIDA"] != DBNull.Value)) entity.MapdQtdNecCorrida = Convert.ToDecimal(dt.Rows[0]["MAPD_QTD_NEC_CORRIDA"]);
            if ((dt.Rows[0]["MAPD_QTD_NEC_TOTAL"] != null) && (dt.Rows[0]["MAPD_QTD_NEC_TOTAL"] != DBNull.Value)) entity.MapdQtdNecTotal = Convert.ToDecimal(dt.Rows[0]["MAPD_QTD_NEC_TOTAL"]);
            if ((dt.Rows[0]["MAPD_QTD_MATERIAL_RM"] != null) && (dt.Rows[0]["MAPD_QTD_MATERIAL_RM"] != DBNull.Value)) entity.MapdQtdMaterialRm = Convert.ToDecimal(dt.Rows[0]["MAPD_QTD_MATERIAL_RM"]);
            if ((dt.Rows[0]["MAPD_COBERTURA_RM"] != null) && (dt.Rows[0]["MAPD_COBERTURA_RM"] != DBNull.Value)) entity.MapdCoberturaRm = Convert.ToDecimal(dt.Rows[0]["MAPD_COBERTURA_RM"]);
            if ((dt.Rows[0]["MAPD_QTD_MATERIAL_AF"] != null) && (dt.Rows[0]["MAPD_QTD_MATERIAL_AF"] != DBNull.Value)) entity.MapdQtdMaterialAf = Convert.ToDecimal(dt.Rows[0]["MAPD_QTD_MATERIAL_AF"]);
            if ((dt.Rows[0]["MAPD_COBERTURA_AF"] != null) && (dt.Rows[0]["MAPD_COBERTURA_AF"] != DBNull.Value)) entity.MapdCoberturaAf = (decimal?)Convert.ToDecimal(dt.Rows[0]["MAPD_COBERTURA_AF"]);
            if ((dt.Rows[0]["MAPD_DCMN_NUMERO"] != null) && (dt.Rows[0]["MAPD_DCMN_NUMERO"] != DBNull.Value)) entity.MapdDcmnNumero = Convert.ToString(dt.Rows[0]["MAPD_DCMN_NUMERO"]);
            if ((dt.Rows[0]["MAPD_REPL_REV"] != null) && (dt.Rows[0]["MAPD_REPL_REV"] != DBNull.Value)) entity.MapdReplRev = Convert.ToString(dt.Rows[0]["MAPD_REPL_REV"]);
            if ((dt.Rows[0]["MAPD_AUFO_NUMERO"] != null) && (dt.Rows[0]["MAPD_AUFO_NUMERO"] != DBNull.Value)) entity.MapdAufoNumero = Convert.ToString(dt.Rows[0]["MAPD_AUFO_NUMERO"]);
            if ((dt.Rows[0]["MAPD_AUFO_EMPR_NOME"] != null) && (dt.Rows[0]["MAPD_AUFO_EMPR_NOME"] != DBNull.Value)) entity.MapdAufoEmprNome = Convert.ToString(dt.Rows[0]["MAPD_AUFO_EMPR_NOME"]);
            if ((dt.Rows[0]["MAPD_PROX_DATA_RECEBIMENTO"] != null) && (dt.Rows[0]["MAPD_PROX_DATA_RECEBIMENTO"] != DBNull.Value)) entity.MapdProxDataRecebimento = Convert.ToString(dt.Rows[0]["MAPD_PROX_DATA_RECEBIMENTO"]);
            if ((dt.Rows[0]["MAPD_NOTAS_FISCAIS"] != null) && (dt.Rows[0]["MAPD_NOTAS_FISCAIS"] != DBNull.Value)) entity.MapdNotasFiscais = Convert.ToString(dt.Rows[0]["MAPD_NOTAS_FISCAIS"]);
            if ((dt.Rows[0]["MAPD_NFIT_QTD"] != null) && (dt.Rows[0]["MAPD_NFIT_QTD"] != DBNull.Value)) entity.MapdNfitQtd = Convert.ToDecimal(dt.Rows[0]["MAPD_NFIT_QTD"]);
            if ((dt.Rows[0]["MAPD_SALDO_ENTREGA"] != null) && (dt.Rows[0]["MAPD_SALDO_ENTREGA"] != DBNull.Value)) entity.MapdSaldoEntrega = Convert.ToDecimal(dt.Rows[0]["MAPD_SALDO_ENTREGA"]);
            if ((dt.Rows[0]["MAPD_AGUARDANDO_RECEBIMENTO"] != null) && (dt.Rows[0]["MAPD_AGUARDANDO_RECEBIMENTO"] != DBNull.Value)) entity.MapdAguardandoRecebimento = (decimal?)Convert.ToDecimal(dt.Rows[0]["MAPD_AGUARDANDO_RECEBIMENTO"]);
            if ((dt.Rows[0]["MAPD_CORRECAO_RM"] != null) && (dt.Rows[0]["MAPD_CORRECAO_RM"] != DBNull.Value)) entity.MapdCorrecaoRm = (decimal?)Convert.ToDecimal(dt.Rows[0]["MAPD_CORRECAO_RM"]);
            if ((dt.Rows[0]["MAPD_SOLICITACAO_COMPRA"] != null) && (dt.Rows[0]["MAPD_SOLICITACAO_COMPRA"] != DBNull.Value)) entity.MapdSolicitacaoCompra = (decimal?)Convert.ToDecimal(dt.Rows[0]["MAPD_SOLICITACAO_COMPRA"]);
            if ((dt.Rows[0]["MAPD_PREVISAO_RECEBIMENTO"] != null) && (dt.Rows[0]["MAPD_PREVISAO_RECEBIMENTO"] != DBNull.Value)) entity.MapdPrevisaoRecebimento = Convert.ToString(dt.Rows[0]["MAPD_PREVISAO_RECEBIMENTO"]);
            if ((dt.Rows[0]["MAPD_COMENT_SUPR"] != null) && (dt.Rows[0]["MAPD_COMENT_SUPR"] != DBNull.Value)) entity.MapdComentSupr = Convert.ToString(dt.Rows[0]["MAPD_COMENT_SUPR"]);
            if ((dt.Rows[0]["MAPD_DATAS_RECEBIMENTO"] != null) && (dt.Rows[0]["MAPD_DATAS_RECEBIMENTO"] != DBNull.Value)) entity.MapdDatasRecebimento = Convert.ToString(dt.Rows[0]["MAPD_DATAS_RECEBIMENTO"]);
            if ((dt.Rows[0]["MAPD_NOEN_NUMERO"] != null) && (dt.Rows[0]["MAPD_NOEN_NUMERO"] != DBNull.Value)) entity.MapdNoenNumero = Convert.ToString(dt.Rows[0]["MAPD_NOEN_NUMERO"]);
            if ((dt.Rows[0]["MAPD_NOEI_QTD_NEM"] != null) && (dt.Rows[0]["MAPD_NOEI_QTD_NEM"] != DBNull.Value)) entity.MapdNoeiQtdNem = Convert.ToDecimal(dt.Rows[0]["MAPD_NOEI_QTD_NEM"]);
            if ((dt.Rows[0]["MAPD_SALDO_LIBERADO"] != null) && (dt.Rows[0]["MAPD_SALDO_LIBERADO"] != DBNull.Value)) entity.MapdSaldoLiberado = Convert.ToDecimal(dt.Rows[0]["MAPD_SALDO_LIBERADO"]);
            if ((dt.Rows[0]["MAPD_DVRE_NUMERO"] != null) && (dt.Rows[0]["MAPD_DVRE_NUMERO"] != DBNull.Value)) entity.MapdDvreNumero = Convert.ToString(dt.Rows[0]["MAPD_DVRE_NUMERO"]);
            if ((dt.Rows[0]["MAPD_AREAS_ESTOCAGEM"] != null) && (dt.Rows[0]["MAPD_AREAS_ESTOCAGEM"] != DBNull.Value)) entity.MapdAreasEstocagem = Convert.ToString(dt.Rows[0]["MAPD_AREAS_ESTOCAGEM"]);
            if ((dt.Rows[0]["MAPD_DIPR_DESCRICAO"] != null) && (dt.Rows[0]["MAPD_DIPR_DESCRICAO"] != DBNull.Value)) entity.MapdDiprDescricao = Convert.ToString(dt.Rows[0]["MAPD_DIPR_DESCRICAO"]);
            if ((dt.Rows[0]["MAPD_DCMN_ID"] != null) && (dt.Rows[0]["MAPD_DCMN_ID"] != DBNull.Value)) entity.MapdDcmnId = Convert.ToDecimal(dt.Rows[0]["MAPD_DCMN_ID"]);
            if ((dt.Rows[0]["MAPD_NOFI_REFERENCIA"] != null) && (dt.Rows[0]["MAPD_NOFI_REFERENCIA"] != DBNull.Value)) entity.MapdNofiReferencia = Convert.ToString(dt.Rows[0]["MAPD_NOFI_REFERENCIA"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcMateriaisPendentesDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting MAPD_NOFI_REFERENCIA Object"); }
        }
        //====================================================================
        public static List<AcMateriaisPendentesDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcMateriaisPendentesDTO> list = OracleDataTools.LoadEntity<AcMateriaisPendentesDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMateriaisPendentesDTO>"); }
        }
        //====================================================================
        public static List<AcMateriaisPendentesDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMateriaisPendentesDTO>"); }
        }
        //====================================================================
        public static List<AcMateriaisPendentesDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcMateriaisPendentesDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcMateriaisPendentesDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcMateriaisPendentes"); }
        }
        //====================================================================
        public static DTO.CollectionAcMateriaisPendentesDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcMateriaisPendentesDTO collection = new DTO.CollectionAcMateriaisPendentesDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcMateriaisPendentesDTO entity = new DTO.AcMateriaisPendentesDTO();
                    if (dt.Rows[i]["MAPD_ID"].ToString().Length != 0) entity.MapdId = Convert.ToDecimal(dt.Rows[i]["MAPD_ID"]);
                    if (dt.Rows[i]["MAPD_COMA_ID"].ToString().Length != 0) entity.MapdComaId = Convert.ToDecimal(dt.Rows[i]["MAPD_COMA_ID"]);
                    if (dt.Rows[i]["MAPD_SBCN_SIGLA"].ToString().Length != 0) entity.MapdSbcnSigla = dt.Rows[i]["MAPD_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["MAPD_DISC_ID"].ToString().Length != 0) entity.MapdDiscId = Convert.ToDecimal(dt.Rows[i]["MAPD_DISC_ID"]);
                    if (dt.Rows[i]["MAPD_DIPR_CODIGO"].ToString().Length != 0) entity.MapdDiprCodigo = dt.Rows[i]["MAPD_DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["MAPD_DIPR_DIMENSOES"].ToString().Length != 0) entity.MapdDiprDimensoes = dt.Rows[i]["MAPD_DIPR_DIMENSOES"].ToString();
                    if (dt.Rows[i]["MAPD_UNME_SIGLA"].ToString().Length != 0) entity.MapdUnmeSigla = dt.Rows[i]["MAPD_UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["MAPD_QTD_NEC_ANTERIOR_CORRIDA"].ToString().Length != 0) entity.MapdQtdNecAnteriorCorrida = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_QTD_NEC_ANTERIOR_CORRIDA"]);
                    if (dt.Rows[i]["MAPD_QTD_NEC_CORRIDA"].ToString().Length != 0) entity.MapdQtdNecCorrida = Convert.ToDecimal(dt.Rows[i]["MAPD_QTD_NEC_CORRIDA"]);
                    if (dt.Rows[i]["MAPD_QTD_NEC_TOTAL"].ToString().Length != 0) entity.MapdQtdNecTotal = Convert.ToDecimal(dt.Rows[i]["MAPD_QTD_NEC_TOTAL"]);
                    if (dt.Rows[i]["MAPD_QTD_MATERIAL_RM"].ToString().Length != 0) entity.MapdQtdMaterialRm = Convert.ToDecimal(dt.Rows[i]["MAPD_QTD_MATERIAL_RM"]);
                    if (dt.Rows[i]["MAPD_COBERTURA_RM"].ToString().Length != 0) entity.MapdCoberturaRm = Convert.ToDecimal(dt.Rows[i]["MAPD_COBERTURA_RM"]);
                    if (dt.Rows[i]["MAPD_QTD_MATERIAL_AF"].ToString().Length != 0) entity.MapdQtdMaterialAf = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_QTD_MATERIAL_AF"]);
                    if (dt.Rows[i]["MAPD_COBERTURA_AF"].ToString().Length != 0) entity.MapdCoberturaAf = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_COBERTURA_AF"]);
                    if (dt.Rows[i]["MAPD_DCMN_NUMERO"].ToString().Length != 0) entity.MapdDcmnNumero = dt.Rows[i]["MAPD_DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["MAPD_REPL_REV"].ToString().Length != 0) entity.MapdReplRev = dt.Rows[i]["MAPD_REPL_REV"].ToString();
                    if (dt.Rows[i]["MAPD_AUFO_NUMERO"].ToString().Length != 0) entity.MapdAufoNumero = dt.Rows[i]["MAPD_AUFO_NUMERO"].ToString();
                    if (dt.Rows[i]["MAPD_AUFO_EMPR_NOME"].ToString().Length != 0) entity.MapdAufoEmprNome = dt.Rows[i]["MAPD_AUFO_EMPR_NOME"].ToString();
                    if (dt.Rows[i]["MAPD_PROX_DATA_RECEBIMENTO"].ToString().Length != 0) entity.MapdProxDataRecebimento = dt.Rows[i]["MAPD_PROX_DATA_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["MAPD_NOTAS_FISCAIS"].ToString().Length != 0) entity.MapdNotasFiscais = dt.Rows[i]["MAPD_NOTAS_FISCAIS"].ToString();
                    if (dt.Rows[i]["MAPD_NFIT_QTD"].ToString().Length != 0) entity.MapdNfitQtd = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_NFIT_QTD"]);
                    if (dt.Rows[i]["MAPD_SALDO_ENTREGA"].ToString().Length != 0) entity.MapdSaldoEntrega = Convert.ToDecimal(dt.Rows[i]["MAPD_SALDO_ENTREGA"]);
                    if (dt.Rows[i]["MAPD_AGUARDANDO_RECEBIMENTO"].ToString().Length != 0) entity.MapdAguardandoRecebimento = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_AGUARDANDO_RECEBIMENTO"]);
                    if (dt.Rows[i]["MAPD_CORRECAO_RM"].ToString().Length != 0) entity.MapdCorrecaoRm = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_CORRECAO_RM"]);
                    if (dt.Rows[i]["MAPD_SOLICITACAO_COMPRA"].ToString().Length != 0) entity.MapdSolicitacaoCompra = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_SOLICITACAO_COMPRA"]);
                    if (dt.Rows[i]["MAPD_PREVISAO_RECEBIMENTO"].ToString().Length != 0) entity.MapdPrevisaoRecebimento = dt.Rows[i]["MAPD_PREVISAO_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["MAPD_COMENT_SUPR"].ToString().Length != 0) entity.MapdComentSupr = dt.Rows[i]["MAPD_COMENT_SUPR"].ToString();
                    if (dt.Rows[i]["MAPD_DATAS_RECEBIMENTO"].ToString().Length != 0) entity.MapdDatasRecebimento = dt.Rows[i]["MAPD_DATAS_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["MAPD_NOEN_NUMERO"].ToString().Length != 0) entity.MapdNoenNumero = dt.Rows[i]["MAPD_NOEN_NUMERO"].ToString();
                    if (dt.Rows[i]["MAPD_NOEI_QTD_NEM"].ToString().Length != 0) entity.MapdNoeiQtdNem = (decimal?)Convert.ToDecimal(dt.Rows[i]["MAPD_NOEI_QTD_NEM"]);
                    if (dt.Rows[i]["MAPD_SALDO_LIBERADO"].ToString().Length != 0) entity.MapdSaldoLiberado = Convert.ToDecimal(dt.Rows[i]["MAPD_SALDO_LIBERADO"]);
                    if (dt.Rows[i]["MAPD_DVRE_NUMERO"].ToString().Length != 0) entity.MapdDvreNumero = dt.Rows[i]["MAPD_DVRE_NUMERO"].ToString();
                    if (dt.Rows[i]["MAPD_AREAS_ESTOCAGEM"].ToString().Length != 0) entity.MapdAreasEstocagem = dt.Rows[i]["MAPD_AREAS_ESTOCAGEM"].ToString();
                    if (dt.Rows[i]["MAPD_DIPR_DESCRICAO"].ToString().Length != 0) entity.MapdDiprDescricao = dt.Rows[i]["MAPD_DIPR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MAPD_DCMN_ID"].ToString().Length != 0) entity.MapdDcmnId = Convert.ToDecimal(dt.Rows[i]["MAPD_DCMN_ID"]);
                    if (dt.Rows[i]["MAPD_NOFI_REFERENCIA"].ToString().Length != 0) entity.MapdNofiReferencia = dt.Rows[i]["MAPD_NOFI_REFERENCIA"].ToString();

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
            dict.Add("MapdId", "MAPD_ID");
            dict.Add("MapdComaId", "MAPD_COMA_ID");
            dict.Add("MapdSbcnSigla", "MAPD_SBCN_SIGLA");
            dict.Add("MapdDiscId", "MAPD_DISC_ID");
            dict.Add("MapdDiprCodigo", "MAPD_DIPR_CODIGO");
            dict.Add("MapdDiprDimensoes", "MAPD_DIPR_DIMENSOES");
            dict.Add("MapdUnmeSigla", "MAPD_UNME_SIGLA");
            dict.Add("MapdQtdNecAnteriorCorrida", "MAPD_QTD_NEC_ANTERIOR_CORRIDA");
            dict.Add("MapdQtdNecCorrida", "MAPD_QTD_NEC_CORRIDA");
            dict.Add("MapdQtdNecTotal", "MAPD_QTD_NEC_TOTAL");
            dict.Add("MapdQtdMaterialRm", "MAPD_QTD_MATERIAL_RM");
            dict.Add("MapdCoberturaRm", "MAPD_COBERTURA_RM");
            dict.Add("MapdQtdMaterialAf", "MAPD_QTD_MATERIAL_AF");
            dict.Add("MapdCoberturaAf", "MAPD_COBERTURA_AF");
            dict.Add("MapdDcmnNumero", "MAPD_DCMN_NUMERO");
            dict.Add("MapdReplRev", "MAPD_REPL_REV");
            dict.Add("MapdAufoNumero", "MAPD_AUFO_NUMERO");
            dict.Add("MapdAufoEmprNome", "MAPD_AUFO_EMPR_NOME");
            dict.Add("MapdProxDataRecebimento", "MAPD_PROX_DATA_RECEBIMENTO");
            dict.Add("MapdNotasFiscais", "MAPD_NOTAS_FISCAIS");
            dict.Add("MapdNfitQtd", "MAPD_NFIT_QTD");
            dict.Add("MapdSaldoEntrega", "MAPD_SALDO_ENTREGA");
            dict.Add("MapdAguardandoRecebimento", "MAPD_AGUARDANDO_RECEBIMENTO");
            dict.Add("MapdCorrecaoRm", "MAPD_CORRECAO_RM");
            dict.Add("MapdSolicitacaoCompra", "MAPD_SOLICITACAO_COMPRA");
            dict.Add("MapdPrevisaoRecebimento", "MAPD_PREVISAO_RECEBIMENTO");
            dict.Add("MapdComentSupr", "MAPD_COMENT_SUPR");
            dict.Add("MapdDatasRecebimento", "MAPD_DATAS_RECEBIMENTO");
            dict.Add("MapdNoenNumero", "MAPD_NOEN_NUMERO");
            dict.Add("MapdNoeiQtdNem", "MAPD_NOEI_QTD_NEM");
            dict.Add("MapdSaldoLiberado", "MAPD_SALDO_LIBERADO");
            dict.Add("MapdDvreNumero", "MAPD_DVRE_NUMERO");
            dict.Add("MapdAreasEstocagem", "MAPD_AREAS_ESTOCAGEM");
            dict.Add("MapdDiprDescricao", "MAPD_DIPR_DESCRICAO");
            dict.Add("MapdDcmnId", "MAPD_DCMN_ID");
            dict.Add("MapdNofiReferencia", "MAPD_NOFI_REFERENCIA");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
