using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;


//====================================================================

namespace DAL
{
    public class CpPastaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT * FROM (SELECT X.PASTA_ID, X.PASTA_CNTR_CODIGO, X.PASTA_SBCN_SIGLA, X.PASTA_CODIGO, X.PASTA_SSOP_ID, X.PASTA_DISC_ID, X.PASTA_AREA_ID, X.PASTA_ESCO_ID, X.PASTA_LOCA_ID, X.PASTA_FASE, X.PASTA_BLOCO, TO_CHAR(X.PASTA_PROG,'DD/MM/YYYY HH24:MI:SS') AS PASTA_PROG, X.PASTA_REDIRECIONAMENTO, X.PASTA_OBSERVACAO, X.PASTA_STPA_ID, X.PASTA_ZONA_ID, Z.ZONA_NOME, X.PASTA_RESPONSAVEL, X.PASTA_REGIAO, X.PASTA_EXECUTOR, X.PASTA_TESTE_LIBERADO FROM EEP_CONVERSION.CP_PASTA X, EEP_CONVERSION.CP_ZONA Z WHERE Z.ZONA_CNTR_CODIGO = X.PASTA_CNTR_CODIGO AND Z.ZONA_ID = X.PASTA_ZONA_ID) ";
        //====================================================================
        public static int Insert(DTO.CpPastaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_PASTA(PASTA_CNTR_CODIGO,PASTA_SBCN_SIGLA,PASTA_CODIGO,PASTA_SSOP_ID,PASTA_DISC_ID,PASTA_AREA_ID,PASTA_ESCO_ID,PASTA_LOCA_ID,PASTA_FASE,PASTA_BLOCO,PASTA_PROG,PASTA_REDIRECIONAMENTO,PASTA_OBSERVACAO,PASTA_STPA_ID, PASTA_ZONA_ID,PASTA_RESPONSAVEL,PASTA_REGIAO,PASTA_EXECUTOR) VALUES(:PASTA_CNTR_CODIGO,:PASTA_SBCN_SIGLA,:PASTA_CODIGO,:PASTA_SSOP_ID,:PASTA_DISC_ID,:PASTA_AREA_ID,:PASTA_ESCO_ID,:PASTA_LOCA_ID,:PASTA_FASE,:PASTA_BLOCO,:PASTA_PROG,:PASTA_REDIRECIONAMENTO,:PASTA_OBSERVACAO,:PASTA_STPA_ID,:PASTA_ZONA_ID,:PASTA_RESPONSAVEL,:PASTA_REGIAO,:PASTA_EXECUTOR)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PASTA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCntrCodigo;
                cmd.Parameters.Add(":PASTA_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PastaSbcnSigla;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":PASTA_SSOP_ID", OracleDbType.Decimal).Value = entity.PastaSsopId;
                cmd.Parameters.Add(":PASTA_DISC_ID", OracleDbType.Decimal).Value = entity.PastaDiscId;
                cmd.Parameters.Add(":PASTA_AREA_ID", OracleDbType.Decimal).Value = entity.PastaAreaId;
                cmd.Parameters.Add(":PASTA_ESCO_ID", OracleDbType.Decimal).Value = entity.PastaEscoId;
                cmd.Parameters.Add(":PASTA_LOCA_ID", OracleDbType.Decimal).Value = entity.PastaLocaId;
                cmd.Parameters.Add(":PASTA_FASE", OracleDbType.Varchar2).Value = entity.PastaFase;
                cmd.Parameters.Add(":PASTA_BLOCO", OracleDbType.Varchar2).Value = entity.PastaBloco;
                cmd.Parameters.Add(":PASTA_PROG", OracleDbType.Date).Value = entity.PastaProg;
                cmd.Parameters.Add(":PASTA_REDIRECIONAMENTO", OracleDbType.Varchar2).Value = entity.PastaRedirecionamento;
                cmd.Parameters.Add(":PASTA_OBSERVACAO", OracleDbType.Varchar2).Value = entity.PastaObservacao;
                cmd.Parameters.Add(":PASTA_STPA_ID", OracleDbType.Decimal).Value = entity.PastaStpaId;
                cmd.Parameters.Add(":PASTA_ZONA_ID", OracleDbType.Decimal).Value = entity.PastaZonaId;
                cmd.Parameters.Add(":PASTA_RESPONSAVEL", OracleDbType.Varchar2).Value = entity.PastaResponsavel;
                cmd.Parameters.Add(":PASTA_REGIAO", OracleDbType.Varchar2).Value = entity.PastaRegiao;
                cmd.Parameters.Add(":PASTA_EXECUTOR", OracleDbType.Varchar2).Value = entity.PastaExecutor;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpPasta");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpPasta");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpPastaDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_PASTA set PASTA_CNTR_CODIGO = :PASTA_CNTR_CODIGO, PASTA_SBCN_SIGLA = :PASTA_SBCN_SIGLA, PASTA_CODIGO = :PASTA_CODIGO, PASTA_SSOP_ID = :PASTA_SSOP_ID, PASTA_DISC_ID = :PASTA_DISC_ID, PASTA_AREA_ID = :PASTA_AREA_ID, PASTA_ESCO_ID = :PASTA_ESCO_ID, PASTA_LOCA_ID = :PASTA_LOCA_ID, PASTA_FASE = :PASTA_FASE, PASTA_BLOCO = :PASTA_BLOCO, PASTA_PROG = :PASTA_PROG, PASTA_REDIRECIONAMENTO = :PASTA_REDIRECIONAMENTO, PASTA_OBSERVACAO = :PASTA_OBSERVACAO, PASTA_STPA_ID = :PASTA_STPA_ID, PASTA_ZONA_ID = :PASTA_ZONA_ID, PASTA_RESPONSAVEL = :PASTA_RESPONSAVEL, PASTA_REGIAO = :PASTA_REGIAO, PASTA_EXECUTOR = :PASTA_EXECUTOR WHERE  PASTA_ID = :PASTA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PASTA_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCntrCodigo;
                cmd.Parameters.Add(":PASTA_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PastaSbcnSigla;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":PASTA_SSOP_ID", OracleDbType.Decimal).Value = entity.PastaSsopId;
                cmd.Parameters.Add(":PASTA_DISC_ID", OracleDbType.Decimal).Value = entity.PastaDiscId;
                cmd.Parameters.Add(":PASTA_AREA_ID", OracleDbType.Decimal).Value = entity.PastaAreaId;
                cmd.Parameters.Add(":PASTA_ESCO_ID", OracleDbType.Decimal).Value = entity.PastaEscoId;
                cmd.Parameters.Add(":PASTA_LOCA_ID", OracleDbType.Decimal).Value = entity.PastaLocaId;
                cmd.Parameters.Add(":PASTA_FASE", OracleDbType.Varchar2).Value = entity.PastaFase;
                cmd.Parameters.Add(":PASTA_BLOCO", OracleDbType.Varchar2).Value = entity.PastaBloco;
                cmd.Parameters.Add(":PASTA_PROG", OracleDbType.Date).Value = entity.PastaProg;
                cmd.Parameters.Add(":PASTA_REDIRECIONAMENTO", OracleDbType.Varchar2).Value = entity.PastaRedirecionamento;
                cmd.Parameters.Add(":PASTA_OBSERVACAO", OracleDbType.Varchar2).Value = entity.PastaObservacao;
                cmd.Parameters.Add(":PASTA_STPA_ID", OracleDbType.Decimal).Value = entity.PastaStpaId;
                cmd.Parameters.Add(":PASTA_ZONA_ID", OracleDbType.Decimal).Value = entity.PastaZonaId;
                cmd.Parameters.Add(":PASTA_SUPERVISOR", OracleDbType.Varchar2).Value = entity.PastaResponsavel;
                cmd.Parameters.Add(":PASTA_REGIAO", OracleDbType.Varchar2).Value = entity.PastaRegiao;
                cmd.Parameters.Add(":PASTA_EXECUTOR", OracleDbType.Varchar2).Value = entity.PastaExecutor;
                cmd.Parameters.Add(":PASTA_ID", OracleDbType.Decimal).Value = entity.PastaId;


                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpPasta"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal PastaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_PASTA WHERE PASTA_ID = :PASTA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PastaId", OracleDbType.Decimal).Value = PastaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpPasta"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPasta"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_PASTA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPasta"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPasta"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPasta"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpPasta"); }
        }
        //====================================================================
        public static DTO.CpPastaDTO Get(decimal PastaId)
        {
            CpPastaDTO entity = new CpPastaDTO();
            DataTable dt = null;
            string filter = "PASTA_ID = " + PastaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PASTA_ID"] != null) && (dt.Rows[0]["PASTA_ID"] != DBNull.Value)) entity.PastaId = Convert.ToDecimal(dt.Rows[0]["PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CNTR_CODIGO"] != null) && (dt.Rows[0]["PASTA_CNTR_CODIGO"] != DBNull.Value)) entity.PastaCntrCodigo = Convert.ToString(dt.Rows[0]["PASTA_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PASTA_SBCN_SIGLA"] != null) && (dt.Rows[0]["PASTA_SBCN_SIGLA"] != DBNull.Value)) entity.PastaSbcnSigla = Convert.ToString(dt.Rows[0]["PASTA_SBCN_SIGLA"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["PASTA_SSOP_ID"] != null) && (dt.Rows[0]["PASTA_SSOP_ID"] != DBNull.Value)) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[0]["PASTA_SSOP_ID"]);
            if ((dt.Rows[0]["PASTA_DISC_ID"] != null) && (dt.Rows[0]["PASTA_DISC_ID"] != DBNull.Value)) entity.PastaDiscId = Convert.ToDecimal(dt.Rows[0]["PASTA_DISC_ID"]);
            if ((dt.Rows[0]["PASTA_AREA_ID"] != null) && (dt.Rows[0]["PASTA_AREA_ID"] != DBNull.Value)) entity.PastaAreaId = Convert.ToDecimal(dt.Rows[0]["PASTA_AREA_ID"]);
            if ((dt.Rows[0]["PASTA_ESCO_ID"] != null) && (dt.Rows[0]["PASTA_ESCO_ID"] != DBNull.Value)) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[0]["PASTA_ESCO_ID"]);
            if ((dt.Rows[0]["PASTA_LOCA_ID"] != null) && (dt.Rows[0]["PASTA_LOCA_ID"] != DBNull.Value)) entity.PastaLocaId = Convert.ToDecimal(dt.Rows[0]["PASTA_LOCA_ID"]);
            if ((dt.Rows[0]["PASTA_FASE"] != null) && (dt.Rows[0]["PASTA_FASE"] != DBNull.Value)) entity.PastaFase = Convert.ToString(dt.Rows[0]["PASTA_FASE"]);
            if ((dt.Rows[0]["PASTA_BLOCO"] != null) && (dt.Rows[0]["PASTA_BLOCO"] != DBNull.Value)) entity.PastaBloco = Convert.ToString(dt.Rows[0]["PASTA_BLOCO"]);
            if ((dt.Rows[0]["PASTA_PROG"] != null) && (dt.Rows[0]["PASTA_PROG"] != DBNull.Value)) entity.PastaProg = Convert.ToDateTime(dt.Rows[0]["PASTA_PROG"]);
            if ((dt.Rows[0]["PASTA_REDIRECIONAMENTO"] != null) && (dt.Rows[0]["PASTA_REDIRECIONAMENTO"] != DBNull.Value)) entity.PastaRedirecionamento = Convert.ToString(dt.Rows[0]["PASTA_REDIRECIONAMENTO"]);
            if ((dt.Rows[0]["PASTA_OBSERVACAO"] != null) && (dt.Rows[0]["PASTA_OBSERVACAO"] != DBNull.Value)) entity.PastaObservacao = Convert.ToString(dt.Rows[0]["PASTA_OBSERVACAO"]);
            if ((dt.Rows[0]["PASTA_STPA_ID"] != null) && (dt.Rows[0]["PASTA_STPA_ID"] != DBNull.Value)) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[0]["PASTA_STPA_ID"]);
            if ((dt.Rows[0]["PASTA_ZONA_ID"] != null) && (dt.Rows[0]["PASTA_ZONA_ID"] != DBNull.Value)) entity.PastaZonaId = Convert.ToDecimal(dt.Rows[0]["PASTA_ZONA_ID"]);
            if ((dt.Rows[0]["PASTA_RESPONSAVEL"] != null) && (dt.Rows[0]["PASTA_RESPONSAVEL"] != DBNull.Value)) entity.PastaResponsavel = Convert.ToString(dt.Rows[0]["PASTA_RESPONSAVEL"]);
            if ((dt.Rows[0]["PASTA_REGIAO"] != null) && (dt.Rows[0]["PASTA_REGIAO"] != DBNull.Value)) entity.PastaRegiao = Convert.ToString(dt.Rows[0]["PASTA_REGIAO"]);
            if ((dt.Rows[0]["PASTA_EXECUTOR"] != null) && (dt.Rows[0]["PASTA_EXECUTOR"] != DBNull.Value)) entity.PastaExecutor = Convert.ToString(dt.Rows[0]["PASTA_EXECUTOR"]);
            if ((dt.Rows[0]["PASTA_TESTE_LIBERADO"] != null) && (dt.Rows[0]["PASTA_TESTE_LIBERADO"] != DBNull.Value)) entity.PastaTesteLiberado = Convert.ToDecimal(dt.Rows[0]["PASTA_TESTE_LIBERADO"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpPastaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PASTA_STATUS_ID Object"); }
        }
        //====================================================================
        public static List<CpPastaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpPastaDTO> list = OracleDataTools.LoadEntity<CpPastaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaDTO>"); }
        }
        //====================================================================
        public static List<CpPastaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaDTO>"); }
        }
        //====================================================================
        public static List<CpPastaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpPasta"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpPastaDTO collection = new DTO.CollectionCpPastaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpPastaDTO entity = new DTO.CpPastaDTO();
                    if (dt.Rows[i]["PASTA_ID"].ToString().Length != 0) entity.PastaId = Convert.ToDecimal(dt.Rows[i]["PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CNTR_CODIGO"].ToString().Length != 0) entity.PastaCntrCodigo = dt.Rows[i]["PASTA_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString().Length != 0) entity.PastaSbcnSigla = dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["PASTA_SSOP_ID"].ToString().Length != 0) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[i]["PASTA_SSOP_ID"]);
                    if (dt.Rows[i]["PASTA_DISC_ID"].ToString().Length != 0) entity.PastaDiscId = Convert.ToDecimal(dt.Rows[i]["PASTA_DISC_ID"]);
                    if (dt.Rows[i]["PASTA_AREA_ID"].ToString().Length != 0) entity.PastaAreaId = Convert.ToDecimal(dt.Rows[i]["PASTA_AREA_ID"]);
                    if (dt.Rows[i]["PASTA_ESCO_ID"].ToString().Length != 0) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[i]["PASTA_ESCO_ID"]);
                    if (dt.Rows[i]["PASTA_LOCA_ID"].ToString().Length != 0) entity.PastaLocaId = Convert.ToDecimal(dt.Rows[i]["PASTA_LOCA_ID"]);
                    if (dt.Rows[i]["PASTA_FASE"].ToString().Length != 0) entity.PastaFase = dt.Rows[i]["PASTA_FASE"].ToString();
                    if (dt.Rows[i]["PASTA_BLOCO"].ToString().Length != 0) entity.PastaBloco = dt.Rows[i]["PASTA_BLOCO"].ToString();
                    if (dt.Rows[i]["PASTA_PROG"].ToString().Length != 0) entity.PastaProg = Convert.ToDateTime(dt.Rows[i]["PASTA_PROG"]);
                    if (dt.Rows[i]["PASTA_REDIRECIONAMENTO"].ToString().Length != 0) entity.PastaRedirecionamento = dt.Rows[i]["PASTA_REDIRECIONAMENTO"].ToString();
                    if (dt.Rows[i]["PASTA_OBSERVACAO"].ToString().Length != 0) entity.PastaObservacao = dt.Rows[i]["PASTA_OBSERVACAO"].ToString();
                    if (dt.Rows[i]["PASTA_STPA_ID"].ToString().Length != 0) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[i]["PASTA_STPA_ID"]);
                    if (dt.Rows[i]["PASTA_ZONA_ID"].ToString().Length != 0) entity.PastaZonaId = Convert.ToDecimal(dt.Rows[i]["PASTA_ZONA_ID"]);
                    if (dt.Rows[i]["PASTA_RESPONSAVEL"].ToString().Length != 0) entity.PastaResponsavel = dt.Rows[i]["PASTA_RESPONSAVEL"].ToString();
                    if (dt.Rows[i]["PASTA_REGIAO"].ToString().Length != 0) entity.PastaRegiao = dt.Rows[i]["PASTA_REGIAO"].ToString();
                    if (dt.Rows[i]["PASTA_EXECUTOR"].ToString().Length != 0) entity.PastaExecutor = dt.Rows[i]["PASTA_EXECUTOR"].ToString();
                    if (dt.Rows[i]["PASTA_TESTE_LIBERADO"].ToString().Length != 0) entity.PastaTesteLiberado = Convert.ToDecimal(dt.Rows[i]["PASTA_TESTE_LIBERADO"]);

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