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
    public class AcSpoolsPendentesDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.SPPD_ID, X.SPPD_COMA_ID, X.SPPD_SBCN_SIGLA, X.SPPD_FOSE_ID, X.SPPD_FOSE_NUMERO, X.SPPD_PIPELINE, X.SPPD_FOSE_REV, X.SPPD_FOSE_DESCRICAO, X.SPPD_TSTF_UNIDADE_REGIONAL, X.SPPD_REGIAO, X.SPPD_DIPR_CODIGO, X.SPPD_DIPR_DIMENSOES, X.SPPD_DIPR_DESCRICAO, X.SPPD_UNME_SIGLA, X.SPPD_QTD_NECESSARIA, X.SPPD_QTD_FS_CORRIDA, X.SPPD_QTD_A_RESERVAR, X.SPPD_DCMN_NUMERO, X.SPPD_REPL_REV, X.SPPD_AUFO_NUMERO, X.SPPD_PROX_DATA_RECEBIMENTO, X.SPPD_DATAS_RECEBIMENTO, X.SPPD_NOTAS_FISCAIS, X.SPPD_AREAS_ESTOCAGEM, X.SPPD_DCMN_ID, X.SPPD_CREATED_BY, TO_CHAR(X.SPPD_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS SPPD_CREATED_DATE, X.SPPD_FABRICADO FROM EEP_CONVERSION.AC_SPOOLS_PENDENTES X ";
        //====================================================================
        public static int Insert(DTO.AcSpoolsPendentesDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_SPOOLS_PENDENTES(SPPD_COMA_ID, SPPD_SBCN_SIGLA, SPPD_FOSE_ID, SPPD_FOSE_NUMERO, SPPD_PIPELINE, SPPD_FOSE_REV, SPPD_FOSE_DESCRICAO, SPPD_TSTF_UNIDADE_REGIONAL, SPPD_REGIAO, SPPD_DIPR_CODIGO, SPPD_DIPR_DIMENSOES, SPPD_DIPR_DESCRICAO, SPPD_UNME_SIGLA, SPPD_QTD_NECESSARIA, SPPD_QTD_FS_CORRIDA, SPPD_QTD_A_RESERVAR, SPPD_DCMN_NUMERO, SPPD_REPL_REV, SPPD_AUFO_NUMERO, SPPD_PROX_DATA_RECEBIMENTO, SPPD_DATAS_RECEBIMENTO, SPPD_NOTAS_FISCAIS, SPPD_AREAS_ESTOCAGEM, SPPD_FABRICADO, SPPD_DCMN_ID, SPPD_CREATED_BY) VALUES(:SPPD_COMA_ID,:SPPD_SBCN_SIGLA,:SPPD_FOSE_ID,:SPPD_FOSE_NUMERO,:SPPD_PIPELINE, :SPPD_FOSE_REV,:SPPD_FOSE_DESCRICAO,:SPPD_TSTF_UNIDADE_REGIONAL,:SPPD_REGIAO,:SPPD_DIPR_CODIGO,:SPPD_DIPR_DIMENSOES,:SPPD_DIPR_DESCRICAO,:SPPD_UNME_SIGLA,:SPPD_QTD_NECESSARIA,:SPPD_QTD_FS_CORRIDA,:SPPD_QTD_A_RESERVAR,:SPPD_DCMN_NUMERO,:SPPD_REPL_REV,:SPPD_AUFO_NUMERO,:SPPD_PROX_DATA_RECEBIMENTO,:SPPD_DATAS_RECEBIMENTO,:SPPD_NOTAS_FISCAIS,:SPPD_AREAS_ESTOCAGEM, :SPPD_FABRICADO,:SPPD_DCMN_ID,:SPPD_CREATED_BY)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SPPD_COMA_ID", OracleDbType.Decimal).Value = entity.SppdComaId;
                cmd.Parameters.Add(":SPPD_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SppdSbcnSigla;
                cmd.Parameters.Add(":SPPD_FOSE_ID", OracleDbType.Decimal).Value = entity.SppdFoseId;
                cmd.Parameters.Add(":SPPD_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.SppdFoseNumero;
                cmd.Parameters.Add(":SPPD_PIPELINE", OracleDbType.Varchar2).Value = entity.SppdPipeline;
                cmd.Parameters.Add(":SPPD_FOSE_REV", OracleDbType.Varchar2).Value = entity.SppdFoseRev;
                cmd.Parameters.Add(":SPPD_FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.SppdFoseDescricao;
                cmd.Parameters.Add(":SPPD_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.SppdTstfUnidadeRegional;
                cmd.Parameters.Add(":SPPD_REGIAO", OracleDbType.Varchar2).Value = entity.SppdRegiao;
                cmd.Parameters.Add(":SPPD_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.SppdDiprCodigo;
                cmd.Parameters.Add(":SPPD_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.SppdDiprDimensoes;
                cmd.Parameters.Add(":SPPD_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.SppdDiprDescricao;
                cmd.Parameters.Add(":SPPD_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.SppdUnmeSigla;
                cmd.Parameters.Add(":SPPD_QTD_NECESSARIA", OracleDbType.Decimal).Value = entity.SppdQtdNecessaria;
                cmd.Parameters.Add(":SPPD_QTD_FS_CORRIDA", OracleDbType.Decimal).Value = entity.SppdQtdFsCorrida;
                cmd.Parameters.Add(":SPPD_QTD_A_RESERVAR", OracleDbType.Decimal).Value = entity.SppdQtdAReservar;
                cmd.Parameters.Add(":SPPD_DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.SppdDcmnNumero;
                cmd.Parameters.Add(":SPPD_REPL_REV", OracleDbType.Varchar2).Value = entity.SppdReplRev;
                cmd.Parameters.Add(":SPPD_AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.SppdAufoNumero;
                cmd.Parameters.Add(":SPPD_PROX_DATA_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.SppdProxDataRecebimento;
                cmd.Parameters.Add(":SPPD_DATAS_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.SppdDatasRecebimento;
                cmd.Parameters.Add(":SPPD_NOTAS_FISCAIS", OracleDbType.Varchar2).Value = entity.SppdNotasFiscais;
                cmd.Parameters.Add(":SPPD_AREAS_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.SppdAreasEstocagem;
                cmd.Parameters.Add(":SPPD_FABRICADO", OracleDbType.Varchar2).Value = entity.SppdFabricado;
                cmd.Parameters.Add(":SPPD_DCMN_ID", OracleDbType.Decimal).Value = entity.SppdDcmnId;
                cmd.Parameters.Add(":SPPD_CREATED_BY", OracleDbType.Varchar2).Value = entity.SppdCreatedBy;

                if (entity.SppdFabricado == null)
                {
                    string x = "";
                }

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcSpoolsPendentes");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcSpoolsPendentes");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcSpoolsPendentesDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_SPOOLS_PENDENTES set SPPD_COMA_ID = :SPPD_COMA_ID, SPPD_SBCN_SIGLA = :SPPD_SBCN_SIGLA, SPPD_FOSE_ID = :SPPD_FOSE_ID, SPPD_FOSE_NUMERO = :SPPD_FOSE_NUMERO, SPPD_PIPELINE = :SPPD_PIPELINE, SPPD_FOSE_REV = :SPPD_FOSE_REV, SPPD_FOSE_DESCRICAO = :SPPD_FOSE_DESCRICAO, SPPD_TSTF_UNIDADE_REGIONAL = :SPPD_TSTF_UNIDADE_REGIONAL, SPPD_REGIAO = :SPPD_REGIAO, SPPD_DIPR_CODIGO = :SPPD_DIPR_CODIGO, SPPD_DIPR_DIMENSOES = :SPPD_DIPR_DIMENSOES, SPPD_DIPR_DESCRICAO = :SPPD_DIPR_DESCRICAO, SPPD_UNME_SIGLA = :SPPD_UNME_SIGLA, SPPD_QTD_NECESSARIA = :SPPD_QTD_NECESSARIA, SPPD_QTD_FS_CORRIDA = :SPPD_QTD_FS_CORRIDA, SPPD_QTD_A_RESERVAR = :SPPD_QTD_A_RESERVAR, SPPD_DCMN_NUMERO = :SPPD_DCMN_NUMERO, SPPD_REPL_REV = :SPPD_REPL_REV, SPPD_AUFO_NUMERO = :SPPD_AUFO_NUMERO, SPPD_PROX_DATA_RECEBIMENTO = :SPPD_PROX_DATA_RECEBIMENTO, SPPD_DATAS_RECEBIMENTO = :SPPD_DATAS_RECEBIMENTO, SPPD_NOTAS_FISCAIS = :SPPD_NOTAS_FISCAIS, SPPD_AREAS_ESTOCAGEM = :SPPD_AREAS_ESTOCAGEM, SPPD_FABRICADO = :SPPD_FABRICADO, SPPD_DCMN_ID = :SPPD_DCMN_ID WHERE  SPPD_ID = : SPPD_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("SPPD_COMA_ID", OracleDbType.Decimal).Value = entity.SppdComaId;
                cmd.Parameters.Add("SPPD_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SppdSbcnSigla;
                cmd.Parameters.Add("SPPD_FOSE_ID", OracleDbType.Decimal).Value = entity.SppdFoseId;
                cmd.Parameters.Add("SPPD_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.SppdFoseNumero;
                cmd.Parameters.Add("SPPD_PIPELINE", OracleDbType.Varchar2).Value = entity.SppdPipeline;
                cmd.Parameters.Add("SPPD_FOSE_REV", OracleDbType.Varchar2).Value = entity.SppdFoseRev;
                cmd.Parameters.Add("SPPD_FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.SppdFoseDescricao;
                cmd.Parameters.Add("SPPD_TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.SppdTstfUnidadeRegional;
                cmd.Parameters.Add("SPPD_REGIAO", OracleDbType.Varchar2).Value = entity.SppdRegiao;
                cmd.Parameters.Add("SPPD_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.SppdDiprCodigo;
                cmd.Parameters.Add("SPPD_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.SppdDiprDimensoes;
                cmd.Parameters.Add("SPPD_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.SppdDiprDescricao;
                cmd.Parameters.Add("SPPD_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.SppdUnmeSigla;
                cmd.Parameters.Add("SPPD_QTD_NECESSARIA", OracleDbType.Decimal).Value = entity.SppdQtdNecessaria;
                cmd.Parameters.Add("SPPD_QTD_FS_CORRIDA", OracleDbType.Decimal).Value = entity.SppdQtdFsCorrida;
                cmd.Parameters.Add("SPPD_QTD_A_RESERVAR", OracleDbType.Decimal).Value = entity.SppdQtdAReservar;
                cmd.Parameters.Add("SPPD_DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.SppdDcmnNumero;
                cmd.Parameters.Add("SPPD_REPL_REV", OracleDbType.Varchar2).Value = entity.SppdReplRev;
                cmd.Parameters.Add("SPPD_AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.SppdAufoNumero;
                cmd.Parameters.Add("SPPD_PROX_DATA_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.SppdProxDataRecebimento;
                cmd.Parameters.Add("SPPD_DATAS_RECEBIMENTO", OracleDbType.Varchar2).Value = entity.SppdDatasRecebimento;
                cmd.Parameters.Add("SPPD_NOTAS_FISCAIS", OracleDbType.Varchar2).Value = entity.SppdNotasFiscais;
                cmd.Parameters.Add("SPPD_AREAS_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.SppdAreasEstocagem;
                cmd.Parameters.Add("SPPD_FABRICADO", OracleDbType.Varchar2).Value = entity.SppdFabricado;
                cmd.Parameters.Add("SPPD_DCMN_ID", OracleDbType.Decimal).Value = entity.SppdDcmnId;
                cmd.Parameters.Add("SPPD_ID", OracleDbType.Decimal).Value = entity.SppdId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcSpoolsPendentes"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal SppdId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_SPOOLS_PENDENTES WHERE  SPPD_ID = : SPPD_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SppdId", OracleDbType.Decimal).Value = SppdId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcSpoolsPendentes"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSpoolsPendentes"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_SPOOLS_PENDENTES";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcSpoolsPendentes"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSpoolsPendentes"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcSpoolsPendentes"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcSpoolsPendentes"); }
        }
        //====================================================================
        public static DTO.AcSpoolsPendentesDTO Get(decimal SppdId)
        {
            AcSpoolsPendentesDTO entity = new AcSpoolsPendentesDTO();
            DataTable dt = null;
            string filter = "SPPD_ID = " + SppdId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SPPD_ID"] != null) && (dt.Rows[0]["SPPD_ID"] != DBNull.Value)) entity.SppdId = Convert.ToDecimal(dt.Rows[0]["SPPD_ID"]);
            if ((dt.Rows[0]["SPPD_COMA_ID"] != null) && (dt.Rows[0]["SPPD_COMA_ID"] != DBNull.Value)) entity.SppdComaId = Convert.ToDecimal(dt.Rows[0]["SPPD_COMA_ID"]);
            if ((dt.Rows[0]["SPPD_SBCN_SIGLA"] != null) && (dt.Rows[0]["SPPD_SBCN_SIGLA"] != DBNull.Value)) entity.SppdSbcnSigla = Convert.ToString(dt.Rows[0]["SPPD_SBCN_SIGLA"]);
            if ((dt.Rows[0]["SPPD_FOSE_ID"] != null) && (dt.Rows[0]["SPPD_FOSE_ID"] != DBNull.Value)) entity.SppdFoseId = Convert.ToDecimal(dt.Rows[0]["SPPD_FOSE_ID"]);
            if ((dt.Rows[0]["SPPD_FOSE_NUMERO"] != null) && (dt.Rows[0]["SPPD_FOSE_NUMERO"] != DBNull.Value)) entity.SppdFoseNumero = Convert.ToString(dt.Rows[0]["SPPD_FOSE_NUMERO"]);
            if ((dt.Rows[0]["SPPD_PIPELINE"] != null) && (dt.Rows[0]["SPPD_PIPELINE"] != DBNull.Value)) entity.SppdPipeline = Convert.ToString(dt.Rows[0]["SPPD_PIPELINE"]);
            if ((dt.Rows[0]["SPPD_FOSE_REV"] != null) && (dt.Rows[0]["SPPD_FOSE_REV"] != DBNull.Value)) entity.SppdFoseRev = Convert.ToString(dt.Rows[0]["SPPD_FOSE_REV"]);
            if ((dt.Rows[0]["SPPD_FOSE_DESCRICAO"] != null) && (dt.Rows[0]["SPPD_FOSE_DESCRICAO"] != DBNull.Value)) entity.SppdFoseDescricao = Convert.ToString(dt.Rows[0]["SPPD_FOSE_DESCRICAO"]);
            if ((dt.Rows[0]["SPPD_TSTF_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["SPPD_TSTF_UNIDADE_REGIONAL"] != DBNull.Value)) entity.SppdTstfUnidadeRegional = Convert.ToString(dt.Rows[0]["SPPD_TSTF_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["SPPD_REGIAO"] != null) && (dt.Rows[0]["SPPD_REGIAO"] != DBNull.Value)) entity.SppdRegiao = Convert.ToString(dt.Rows[0]["SPPD_REGIAO"]);
            if ((dt.Rows[0]["SPPD_DIPR_CODIGO"] != null) && (dt.Rows[0]["SPPD_DIPR_CODIGO"] != DBNull.Value)) entity.SppdDiprCodigo = Convert.ToString(dt.Rows[0]["SPPD_DIPR_CODIGO"]);
            if ((dt.Rows[0]["SPPD_DIPR_DIMENSOES"] != null) && (dt.Rows[0]["SPPD_DIPR_DIMENSOES"] != DBNull.Value)) entity.SppdDiprDimensoes = Convert.ToString(dt.Rows[0]["SPPD_DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["SPPD_DIPR_DESCRICAO"] != null) && (dt.Rows[0]["SPPD_DIPR_DESCRICAO"] != DBNull.Value)) entity.SppdDiprDescricao = Convert.ToString(dt.Rows[0]["SPPD_DIPR_DESCRICAO"]);
            if ((dt.Rows[0]["SPPD_UNME_SIGLA"] != null) && (dt.Rows[0]["SPPD_UNME_SIGLA"] != DBNull.Value)) entity.SppdUnmeSigla = Convert.ToString(dt.Rows[0]["SPPD_UNME_SIGLA"]);
            if ((dt.Rows[0]["SPPD_QTD_NECESSARIA"] != null) && (dt.Rows[0]["SPPD_QTD_NECESSARIA"] != DBNull.Value)) entity.SppdQtdNecessaria = Convert.ToDecimal(dt.Rows[0]["SPPD_QTD_NECESSARIA"]);
            if ((dt.Rows[0]["SPPD_QTD_FS_CORRIDA"] != null) && (dt.Rows[0]["SPPD_QTD_FS_CORRIDA"] != DBNull.Value)) entity.SppdQtdFsCorrida = Convert.ToDecimal(dt.Rows[0]["SPPD_QTD_FS_CORRIDA"]);
            if ((dt.Rows[0]["SPPD_QTD_A_RESERVAR"] != null) && (dt.Rows[0]["SPPD_QTD_A_RESERVAR"] != DBNull.Value)) entity.SppdQtdAReservar = Convert.ToDecimal(dt.Rows[0]["SPPD_QTD_A_RESERVAR"]);
            if ((dt.Rows[0]["SPPD_DCMN_NUMERO"] != null) && (dt.Rows[0]["SPPD_DCMN_NUMERO"] != DBNull.Value)) entity.SppdDcmnNumero = Convert.ToString(dt.Rows[0]["SPPD_DCMN_NUMERO"]);
            if ((dt.Rows[0]["SPPD_REPL_REV"] != null) && (dt.Rows[0]["SPPD_REPL_REV"] != DBNull.Value)) entity.SppdReplRev = Convert.ToString(dt.Rows[0]["SPPD_REPL_REV"]);
            if ((dt.Rows[0]["SPPD_AUFO_NUMERO"] != null) && (dt.Rows[0]["SPPD_AUFO_NUMERO"] != DBNull.Value)) entity.SppdAufoNumero = Convert.ToString(dt.Rows[0]["SPPD_AUFO_NUMERO"]);
            if ((dt.Rows[0]["SPPD_PROX_DATA_RECEBIMENTO"] != null) && (dt.Rows[0]["SPPD_PROX_DATA_RECEBIMENTO"] != DBNull.Value)) entity.SppdProxDataRecebimento = Convert.ToString(dt.Rows[0]["SPPD_PROX_DATA_RECEBIMENTO"]);
            if ((dt.Rows[0]["SPPD_DATAS_RECEBIMENTO"] != null) && (dt.Rows[0]["SPPD_DATAS_RECEBIMENTO"] != DBNull.Value)) entity.SppdDatasRecebimento = Convert.ToString(dt.Rows[0]["SPPD_DATAS_RECEBIMENTO"]);
            if ((dt.Rows[0]["SPPD_NOTAS_FISCAIS"] != null) && (dt.Rows[0]["SPPD_NOTAS_FISCAIS"] != DBNull.Value)) entity.SppdNotasFiscais = Convert.ToString(dt.Rows[0]["SPPD_NOTAS_FISCAIS"]);
            if ((dt.Rows[0]["SPPD_AREAS_ESTOCAGEM"] != null) && (dt.Rows[0]["SPPD_AREAS_ESTOCAGEM"] != DBNull.Value)) entity.SppdAreasEstocagem = Convert.ToString(dt.Rows[0]["SPPD_AREAS_ESTOCAGEM"]);
            if ((dt.Rows[0]["SPPD_DCMN_ID"] != null) && (dt.Rows[0]["SPPD_DCMN_ID"] != DBNull.Value)) entity.SppdDcmnId = Convert.ToDecimal(dt.Rows[0]["SPPD_DCMN_ID"]);
            if ((dt.Rows[0]["SPPD_CREATED_BY"] != null) && (dt.Rows[0]["SPPD_CREATED_BY"] != DBNull.Value)) entity.SppdCreatedBy = Convert.ToString(dt.Rows[0]["SPPD_CREATED_BY"]);
            if ((dt.Rows[0]["SPPD_CREATED_DATE"] != null) && (dt.Rows[0]["SPPD_CREATED_DATE"] != DBNull.Value)) entity.SppdCreatedDate = Convert.ToDateTime(dt.Rows[0]["SPPD_CREATED_DATE"]);
            if ((dt.Rows[0]["SPPD_FABRICADO"] != null) && (dt.Rows[0]["SPPD_FABRICADO"] != DBNull.Value)) entity.SppdFabricado = Convert.ToString(dt.Rows[0]["SPPD_FABRICADO"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcSpoolsPendentesDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SPPD_CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcSpoolsPendentesDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcSpoolsPendentesDTO> list = OracleDataTools.LoadEntity<AcSpoolsPendentesDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSpoolsPendentesDTO>"); }
        }
        //====================================================================
        public static List<AcSpoolsPendentesDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSpoolsPendentesDTO>"); }
        }
        //====================================================================
        public static List<AcSpoolsPendentesDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcSpoolsPendentesDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcSpoolsPendentesDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcSpoolsPendentes"); }
        }
        //====================================================================
        public static DTO.CollectionAcSpoolsPendentesDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcSpoolsPendentesDTO collection = new DTO.CollectionAcSpoolsPendentesDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcSpoolsPendentesDTO entity = new DTO.AcSpoolsPendentesDTO();
                    if (dt.Rows[i]["SPPD_ID"].ToString().Length != 0) entity.SppdId = Convert.ToDecimal(dt.Rows[i]["SPPD_ID"]);
                    if (dt.Rows[i]["SPPD_COMA_ID"].ToString().Length != 0) entity.SppdComaId = Convert.ToDecimal(dt.Rows[i]["SPPD_COMA_ID"]);
                    if (dt.Rows[i]["SPPD_SBCN_SIGLA"].ToString().Length != 0) entity.SppdSbcnSigla = dt.Rows[i]["SPPD_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["SPPD_FOSE_ID"].ToString().Length != 0) entity.SppdFoseId = Convert.ToDecimal(dt.Rows[i]["SPPD_FOSE_ID"]);
                    if (dt.Rows[i]["SPPD_FOSE_NUMERO"].ToString().Length != 0) entity.SppdFoseNumero = dt.Rows[i]["SPPD_FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["SPPD_PIPELINE"].ToString().Length != 0) entity.SppdPipeline = dt.Rows[i]["SPPD_PIPELINE"].ToString();
                    if (dt.Rows[i]["SPPD_FOSE_REV"].ToString().Length != 0) entity.SppdFoseRev = dt.Rows[i]["SPPD_FOSE_REV"].ToString();
                    if (dt.Rows[i]["SPPD_FOSE_DESCRICAO"].ToString().Length != 0) entity.SppdFoseDescricao = dt.Rows[i]["SPPD_FOSE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["SPPD_TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.SppdTstfUnidadeRegional = dt.Rows[i]["SPPD_TSTF_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["SPPD_REGIAO"].ToString().Length != 0) entity.SppdRegiao = dt.Rows[i]["SPPD_REGIAO"].ToString();
                    if (dt.Rows[i]["SPPD_DIPR_CODIGO"].ToString().Length != 0) entity.SppdDiprCodigo = dt.Rows[i]["SPPD_DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["SPPD_DIPR_DIMENSOES"].ToString().Length != 0) entity.SppdDiprDimensoes = dt.Rows[i]["SPPD_DIPR_DIMENSOES"].ToString();
                    if (dt.Rows[i]["SPPD_DIPR_DESCRICAO"].ToString().Length != 0) entity.SppdDiprDescricao = dt.Rows[i]["SPPD_DIPR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["SPPD_UNME_SIGLA"].ToString().Length != 0) entity.SppdUnmeSigla = dt.Rows[i]["SPPD_UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["SPPD_QTD_NECESSARIA"].ToString().Length != 0) entity.SppdQtdNecessaria = Convert.ToDecimal(dt.Rows[i]["SPPD_QTD_NECESSARIA"]);
                    if (dt.Rows[i]["SPPD_QTD_FS_CORRIDA"].ToString().Length != 0) entity.SppdQtdFsCorrida = Convert.ToDecimal(dt.Rows[i]["SPPD_QTD_FS_CORRIDA"]);
                    if (dt.Rows[i]["SPPD_QTD_A_RESERVAR"].ToString().Length != 0) entity.SppdQtdAReservar = Convert.ToDecimal(dt.Rows[i]["SPPD_QTD_A_RESERVAR"]);
                    if (dt.Rows[i]["SPPD_DCMN_NUMERO"].ToString().Length != 0) entity.SppdDcmnNumero = dt.Rows[i]["SPPD_DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["SPPD_REPL_REV"].ToString().Length != 0) entity.SppdReplRev = dt.Rows[i]["SPPD_REPL_REV"].ToString();
                    if (dt.Rows[i]["SPPD_AUFO_NUMERO"].ToString().Length != 0) entity.SppdAufoNumero = dt.Rows[i]["SPPD_AUFO_NUMERO"].ToString();
                    if (dt.Rows[i]["SPPD_PROX_DATA_RECEBIMENTO"].ToString().Length != 0) entity.SppdProxDataRecebimento = dt.Rows[i]["SPPD_PROX_DATA_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["SPPD_DATAS_RECEBIMENTO"].ToString().Length != 0) entity.SppdDatasRecebimento = dt.Rows[i]["SPPD_DATAS_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["SPPD_NOTAS_FISCAIS"].ToString().Length != 0) entity.SppdNotasFiscais = dt.Rows[i]["SPPD_NOTAS_FISCAIS"].ToString();
                    if (dt.Rows[i]["SPPD_AREAS_ESTOCAGEM"].ToString().Length != 0) entity.SppdAreasEstocagem = dt.Rows[i]["SPPD_AREAS_ESTOCAGEM"].ToString();
                    if (dt.Rows[i]["SPPD_DCMN_ID"].ToString().Length != 0) entity.SppdDcmnId = Convert.ToDecimal(dt.Rows[i]["SPPD_DCMN_ID"]);
                    if (dt.Rows[i]["SPPD_CREATED_BY"].ToString().Length != 0) entity.SppdCreatedBy = dt.Rows[i]["SPPD_CREATED_BY"].ToString();
                    if (dt.Rows[i]["SPPD_CREATED_DATE"].ToString().Length != 0) entity.SppdCreatedDate = Convert.ToDateTime(dt.Rows[i]["SPPD_CREATED_DATE"]);
                    if (dt.Rows[i]["SPPD_FABRICADO"].ToString().Length != 0) entity.SppdFabricado = Convert.ToString(dt.Rows[i]["SPPD_FABRICADO"]);

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
            dict.Add("SppdId", "SPPD_ID");
            dict.Add("SppdComaId", "SPPD_COMA_ID");
            dict.Add("SppdSbcnSigla", "SPPD_SBCN_SIGLA");
            dict.Add("SppdFoseId", "SPPD_FOSE_ID");
            dict.Add("SppdFoseNumero", "SPPD_FOSE_NUMERO");
            dict.Add("SppdPipeline", "SPPD_PIPELINE");
            dict.Add("SppdFoseRev", "SPPD_FOSE_REV");
            dict.Add("SppdFoseDescricao", "SPPD_FOSE_DESCRICAO");
            dict.Add("SppdTstfUnidadeRegional", "SPPD_TSTF_UNIDADE_REGIONAL");
            dict.Add("SppdRegiao", "SPPD_REGIAO");
            dict.Add("SppdDiprCodigo", "SPPD_DIPR_CODIGO");
            dict.Add("SppdDiprDimensoes", "SPPD_DIPR_DIMENSOES");
            dict.Add("SppdDiprDescricao", "SPPD_DIPR_DESCRICAO");
            dict.Add("SppdUnmeSigla", "SPPD_UNME_SIGLA");
            dict.Add("SppdQtdNecessaria", "SPPD_QTD_NECESSARIA");
            dict.Add("SppdQtdFsCorrida", "SPPD_QTD_FS_CORRIDA");
            dict.Add("SppdQtdAReservar", "SPPD_QTD_A_RESERVAR");
            dict.Add("SppdDcmnNumero", "SPPD_DCMN_NUMERO");
            dict.Add("SppdReplRev", "SPPD_REPL_REV");
            dict.Add("SppdAufoNumero", "SPPD_AUFO_NUMERO");
            dict.Add("SppdProxDataRecebimento", "SPPD_PROX_DATA_RECEBIMENTO");
            dict.Add("SppdDatasRecebimento", "SPPD_DATAS_RECEBIMENTO");
            dict.Add("SppdNotasFiscais", "SPPD_NOTAS_FISCAIS");
            dict.Add("SppdAreasEstocagem", "SPPD_AREAS_ESTOCAGEM");
            dict.Add("SppdDcmnId", "SPPD_DCMN_ID");
            dict.Add("SppdCreatedBy", "SPPD_CREATED_BY");
            dict.Add("SppdFabricado", "SPPD_FABRICADO");

            return dict;
        }
        //====================================================================
        #endregion
    }
}
