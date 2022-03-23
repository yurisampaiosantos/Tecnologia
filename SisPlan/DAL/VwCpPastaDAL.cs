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
    public class VwCpPastaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //====================================================================
        static string strSelect = @"SELECT X.PASTA_ID, X.PASTA_CNTR_CODIGO, X.PASTA_SBCN_SIGLA, X.PASTA_CODIGO, X.PASTA_FASE, X.PASTA_BLOCO, TO_CHAR(X.PASTA_PROG,'DD/MM/YYYY HH24:MI') AS PASTA_PROG, X.PASTA_OBSERVACAO, X.PASTA_REDIRECIONAMENTO, X.DISC_NOME, X.ESCO_DESCRICAO, X.LOCA_DESCRICAO, X.SSOP_SBCN_SIGLA, X.SSOP_CODIGO, X.SSOP_DESCRICAO, X.AREA_DESCRICAO, X.STPA_DESCRICAO, X.PASTA_SSOP_ID, X.PASTA_DISC_ID, X.PASTA_AREA_ID, X.PASTA_ESCO_ID, X.PASTA_LOCA_ID, X.PASTA_STPA_ID FROM EEP_CONVERSION.VW_CP_PASTA X ";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPasta"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_CP_PASTA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPasta"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPasta"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPasta"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwCpPasta"); }
        }
        //====================================================================
        public static DTO.VwCpPastaDTO Get(decimal PastaId)
        {
            VwCpPastaDTO entity = new VwCpPastaDTO();
            DataTable dt = null;
            string filter = "PASTA_ID = " + PastaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PASTA_ID"] != null) && (dt.Rows[0]["PASTA_ID"] != DBNull.Value)) entity.PastaId = Convert.ToDecimal(dt.Rows[0]["PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CNTR_CODIGO"] != null) && (dt.Rows[0]["PASTA_CNTR_CODIGO"] != DBNull.Value)) entity.PastaCntrCodigo = Convert.ToString(dt.Rows[0]["PASTA_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PASTA_SBCN_SIGLA"] != null) && (dt.Rows[0]["PASTA_SBCN_SIGLA"] != DBNull.Value)) entity.PastaSbcnSigla = Convert.ToString(dt.Rows[0]["PASTA_SBCN_SIGLA"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["PASTA_FASE"] != null) && (dt.Rows[0]["PASTA_FASE"] != DBNull.Value)) entity.PastaFase = Convert.ToString(dt.Rows[0]["PASTA_FASE"]);
            if ((dt.Rows[0]["PASTA_BLOCO"] != null) && (dt.Rows[0]["PASTA_BLOCO"] != DBNull.Value)) entity.PastaBloco = Convert.ToString(dt.Rows[0]["PASTA_BLOCO"]);
            if ((dt.Rows[0]["PASTA_PROG"] != null) && (dt.Rows[0]["PASTA_PROG"] != DBNull.Value)) entity.PastaProg = Convert.ToDateTime(dt.Rows[0]["PASTA_PROG"]);
            if ((dt.Rows[0]["PASTA_OBSERVACAO"] != null) && (dt.Rows[0]["PASTA_OBSERVACAO"] != DBNull.Value)) entity.PastaObservacao = Convert.ToString(dt.Rows[0]["PASTA_OBSERVACAO"]);
            if ((dt.Rows[0]["PASTA_TESTE_LIBERADO"] != null) && (dt.Rows[0]["PASTA_TESTE_LIBERADO"] != DBNull.Value)) entity.PastaTesteLiberado = Convert.ToDecimal(dt.Rows[0]["PASTA_TESTE_LIBERADO"]);
            if ((dt.Rows[0]["PASTA_REDIRECIONAMENTO"] != null) && (dt.Rows[0]["PASTA_REDIRECIONAMENTO"] != DBNull.Value)) entity.PastaRedirecionamento = Convert.ToString(dt.Rows[0]["PASTA_REDIRECIONAMENTO"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["ESCO_DESCRICAO"] != null) && (dt.Rows[0]["ESCO_DESCRICAO"] != DBNull.Value)) entity.EscoDescricao = Convert.ToString(dt.Rows[0]["ESCO_DESCRICAO"]);
            if ((dt.Rows[0]["LOCA_DESCRICAO"] != null) && (dt.Rows[0]["LOCA_DESCRICAO"] != DBNull.Value)) entity.LocaDescricao = Convert.ToString(dt.Rows[0]["LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["SSOP_SBCN_SIGLA"] != null) && (dt.Rows[0]["SSOP_SBCN_SIGLA"] != DBNull.Value)) entity.SsopSbcnSigla = Convert.ToString(dt.Rows[0]["SSOP_SBCN_SIGLA"]);
            if ((dt.Rows[0]["SSOP_CODIGO"] != null) && (dt.Rows[0]["SSOP_CODIGO"] != DBNull.Value)) entity.SsopCodigo = Convert.ToString(dt.Rows[0]["SSOP_CODIGO"]);
            if ((dt.Rows[0]["SSOP_DESCRICAO"] != null) && (dt.Rows[0]["SSOP_DESCRICAO"] != DBNull.Value)) entity.SsopDescricao = Convert.ToString(dt.Rows[0]["SSOP_DESCRICAO"]);
            if ((dt.Rows[0]["AREA_DESCRICAO"] != null) && (dt.Rows[0]["AREA_DESCRICAO"] != DBNull.Value)) entity.AreaDescricao = Convert.ToString(dt.Rows[0]["AREA_DESCRICAO"]);
            if ((dt.Rows[0]["STPA_DESCRICAO"] != null) && (dt.Rows[0]["STPA_DESCRICAO"] != DBNull.Value)) entity.StpaDescricao = Convert.ToString(dt.Rows[0]["STPA_DESCRICAO"]);
            if ((dt.Rows[0]["PASTA_SSOP_ID"] != null) && (dt.Rows[0]["PASTA_SSOP_ID"] != DBNull.Value)) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[0]["PASTA_SSOP_ID"]);
            if ((dt.Rows[0]["PASTA_DISC_ID"] != null) && (dt.Rows[0]["PASTA_DISC_ID"] != DBNull.Value)) entity.PastaDiscId = Convert.ToDecimal(dt.Rows[0]["PASTA_DISC_ID"]);
            if ((dt.Rows[0]["PASTA_AREA_ID"] != null) && (dt.Rows[0]["PASTA_AREA_ID"] != DBNull.Value)) entity.PastaAreaId = Convert.ToDecimal(dt.Rows[0]["PASTA_AREA_ID"]);
            if ((dt.Rows[0]["PASTA_ESCO_ID"] != null) && (dt.Rows[0]["PASTA_ESCO_ID"] != DBNull.Value)) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[0]["PASTA_ESCO_ID"]);
            if ((dt.Rows[0]["PASTA_LOCA_ID"] != null) && (dt.Rows[0]["PASTA_LOCA_ID"] != DBNull.Value)) entity.PastaLocaId = Convert.ToDecimal(dt.Rows[0]["PASTA_LOCA_ID"]);
            if ((dt.Rows[0]["PASTA_STPA_ID"] != null) && (dt.Rows[0]["PASTA_STPA_ID"] != DBNull.Value)) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[0]["PASTA_STPA_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwCpPastaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PASTA_STPA_ID Object"); }
        }
        //====================================================================
        public static List<VwCpPastaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwCpPastaDTO> list = OracleDataTools.LoadEntity<VwCpPastaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaDTO>"); }
        }
        //====================================================================
        public static List<VwCpPastaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaDTO>"); }
        }
        //====================================================================
        public static List<VwCpPastaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPastaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwCpPasta"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPastaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwCpPastaDTO collection = new DTO.CollectionVwCpPastaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwCpPastaDTO entity = new DTO.VwCpPastaDTO();
                    if (dt.Rows[i]["PASTA_ID"].ToString().Length != 0) entity.PastaId = Convert.ToDecimal(dt.Rows[i]["PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CNTR_CODIGO"].ToString().Length != 0) entity.PastaCntrCodigo = dt.Rows[i]["PASTA_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString().Length != 0) entity.PastaSbcnSigla = dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["PASTA_FASE"].ToString().Length != 0) entity.PastaFase = dt.Rows[i]["PASTA_FASE"].ToString();
                    if (dt.Rows[i]["PASTA_BLOCO"].ToString().Length != 0) entity.PastaBloco = dt.Rows[i]["PASTA_BLOCO"].ToString();
                    if (dt.Rows[i]["PASTA_PROG"].ToString().Length != 0) entity.PastaProg = Convert.ToDateTime(dt.Rows[i]["PASTA_PROG"]);
                    if (dt.Rows[i]["PASTA_OBSERVACAO"].ToString().Length != 0) entity.PastaObservacao = dt.Rows[i]["PASTA_OBSERVACAO"].ToString();
                    if (dt.Rows[i]["PASTA_TESTE_LIBERADO"].ToString().Length != 0) entity.PastaTesteLiberado = Convert.ToDecimal(dt.Rows[i]["PASTA_TESTE_LIBERADO"]);
                    if (dt.Rows[i]["PASTA_REDIRECIONAMENTO"].ToString().Length != 0) entity.PastaRedirecionamento = dt.Rows[i]["PASTA_REDIRECIONAMENTO"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["ESCO_DESCRICAO"].ToString().Length != 0) entity.EscoDescricao = dt.Rows[i]["ESCO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["LOCA_DESCRICAO"].ToString().Length != 0) entity.LocaDescricao = dt.Rows[i]["LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["SSOP_SBCN_SIGLA"].ToString().Length != 0) entity.SsopSbcnSigla = dt.Rows[i]["SSOP_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["SSOP_CODIGO"].ToString().Length != 0) entity.SsopCodigo = dt.Rows[i]["SSOP_CODIGO"].ToString();
                    if (dt.Rows[i]["SSOP_DESCRICAO"].ToString().Length != 0) entity.SsopDescricao = dt.Rows[i]["SSOP_DESCRICAO"].ToString();
                    if (dt.Rows[i]["AREA_DESCRICAO"].ToString().Length != 0) entity.AreaDescricao = dt.Rows[i]["AREA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["STPA_DESCRICAO"].ToString().Length != 0) entity.StpaDescricao = dt.Rows[i]["STPA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PASTA_SSOP_ID"].ToString().Length != 0) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[i]["PASTA_SSOP_ID"]);
                    if (dt.Rows[i]["PASTA_DISC_ID"].ToString().Length != 0) entity.PastaDiscId = Convert.ToDecimal(dt.Rows[i]["PASTA_DISC_ID"]);
                    if (dt.Rows[i]["PASTA_AREA_ID"].ToString().Length != 0) entity.PastaAreaId = Convert.ToDecimal(dt.Rows[i]["PASTA_AREA_ID"]);
                    if (dt.Rows[i]["PASTA_ESCO_ID"].ToString().Length != 0) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[i]["PASTA_ESCO_ID"]);
                    if (dt.Rows[i]["PASTA_LOCA_ID"].ToString().Length != 0) entity.PastaLocaId = Convert.ToDecimal(dt.Rows[i]["PASTA_LOCA_ID"]);
                    if (dt.Rows[i]["PASTA_STPA_ID"].ToString().Length != 0) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[i]["PASTA_STPA_ID"]);

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
