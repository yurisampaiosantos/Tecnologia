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
    public class VwRmItemDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.DCMN_NUMERO, X.DCMN_TITULO, X.DIPC_CODIGO, X.DIPI_DESCRICAO_RES, X.DIPI_DESCRICAO_COMPL, X.AFIT_ITEM, X.AFIT_QTD_TOTAL, X.AUFO_ID, X.AUFO_NUMERO, X.AUFO_REV,TO_DATE(X.AUFO_DT_EMISSAO,'DD/MM/YYYY') AS AUFO_DT_EMISSAO, TO_DATE(X.AUFO_DT_CADASTRO,'DD/MM/YYYY') AS AUFO_DT_CADASTRO, X.DIPQ_QTD_RM, X.DIPQ_QTD_RMD, X.DIPQ_QTD_RMC, X.DIPQ_QTD_CP, X.DIPQ_QTD_AF, X.DIPQ_QTD_NF, X.DIPQ_QTD_NFD, X.DIPQ_QTD_DR, X.DIPQ_QTD_DRD, X.DIPQ_QTD_NE, X.DIPQ_QTD_NED, X.DIPQ_QTD_FS, X.DIPQ_QTD_ESTOQUE, X.DIPQ_QTD_ESTOQUE_CORRIDA, X.REPR_NUMERO, X.REPR_REV, TO_DATE(X.REPR_DT_EMISSAO,'DD/MM/YYYY') AS REPR_DT_EMISSAO, TO_DATE(X.REPL_NUMERO,'DD/MM/YYYY') AS REPL_NUMERO, X.DIPR_CODIGO, X.DIPR_DIM1, X.DIPR_DIM2, X.DIPR_DIM3, X.DIPR_DIMENSOES, X.DIPR_PESO, TO_DATE(X.DIPR_DT_CADASTRO,'DD/MM/YYYY') AS DIPR_DT_CADASTRO, X.DIPU_CODIGO, X.UNME_SIGLA, X.UNME_NOME, X.EMPR_NOME, X.DIPC_DIM1, X.DIPC_DIM2, X.SBCN_SIGLA, X.DISC_SIGLA, X.DISC_NOME, X.UNPR_SIGLA, X.UNPR_NOME, X.ARAP_SIGLA, X.ARAP_NOME, X.DCPR_SIGLA, X.DCPR_NOME, X.COMP_NOME, X.COMP_FONE1, X.COMP_EMAIL FROM VW_RM_ITEM X ";

        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwRmItem"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM VW_RM_ITEM";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwRmItem"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwRmItem"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwRmItem"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwRmItem"); }
        }
        //====================================================================
        public static DTO.VwRmItemDTO Get(string DcmnNumero)
        {
            VwRmItemDTO entity = new VwRmItemDTO();
            DataTable dt = null;
            string filter = "DCMN_NUMERO = '" + DcmnNumero + "'";
            dt = Get(filter, null);
            if ((dt.Rows[0]["DCMN_NUMERO"] != null) && (dt.Rows[0]["DCMN_NUMERO"] != DBNull.Value)) entity.DcmnNumero = Convert.ToString(dt.Rows[0]["DCMN_NUMERO"]);
            if ((dt.Rows[0]["DCMN_TITULO"] != null) && (dt.Rows[0]["DCMN_TITULO"] != DBNull.Value)) entity.DcmnTitulo = Convert.ToString(dt.Rows[0]["DCMN_TITULO"]);
            if ((dt.Rows[0]["DIPC_CODIGO"] != null) && (dt.Rows[0]["DIPC_CODIGO"] != DBNull.Value)) entity.DipcCodigo = Convert.ToString(dt.Rows[0]["DIPC_CODIGO"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_RES"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_RES"] != DBNull.Value)) entity.DipiDescricaoRes = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_RES"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_COMPL"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_COMPL"] != DBNull.Value)) entity.DipiDescricaoCompl = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_COMPL"]);
            if ((dt.Rows[0]["AFIT_ITEM"] != null) && (dt.Rows[0]["AFIT_ITEM"] != DBNull.Value)) entity.AfitItem = Convert.ToDecimal(dt.Rows[0]["AFIT_ITEM"]);
            if ((dt.Rows[0]["AFIT_QTD_TOTAL"] != null) && (dt.Rows[0]["AFIT_QTD_TOTAL"] != DBNull.Value)) entity.AfitQtdTotal = Convert.ToDecimal(dt.Rows[0]["AFIT_QTD_TOTAL"]);
            if ((dt.Rows[0]["AUFO_ID"] != null) && (dt.Rows[0]["AUFO_ID"] != DBNull.Value)) entity.AufoId = Convert.ToDecimal(dt.Rows[0]["AUFO_ID"]);
            if ((dt.Rows[0]["AUFO_NUMERO"] != null) && (dt.Rows[0]["AUFO_NUMERO"] != DBNull.Value)) entity.AufoNumero = Convert.ToString(dt.Rows[0]["AUFO_NUMERO"]);
            if ((dt.Rows[0]["AUFO_REV"] != null) && (dt.Rows[0]["AUFO_REV"] != DBNull.Value)) entity.AufoRev = Convert.ToDecimal(dt.Rows[0]["AUFO_REV"]);
            if ((dt.Rows[0]["AUFO_DT_EMISSAO"] != null) && (dt.Rows[0]["AUFO_DT_EMISSAO"] != DBNull.Value)) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[0]["AUFO_DT_EMISSAO"]);
            if ((dt.Rows[0]["AUFO_DT_CADASTRO"] != null) && (dt.Rows[0]["AUFO_DT_CADASTRO"] != DBNull.Value)) entity.AufoDtCadastro = Convert.ToDateTime(dt.Rows[0]["AUFO_DT_CADASTRO"]);
            if ((dt.Rows[0]["DIPQ_QTD_RM"] != null) && (dt.Rows[0]["DIPQ_QTD_RM"] != DBNull.Value)) entity.DipqQtdRm = Convert.ToString(dt.Rows[0]["DIPQ_QTD_RM"]);
            if ((dt.Rows[0]["DIPQ_QTD_RMD"] != null) && (dt.Rows[0]["DIPQ_QTD_RMD"] != DBNull.Value)) entity.DipqQtdRmd = Convert.ToString(dt.Rows[0]["DIPQ_QTD_RMD"]);
            if ((dt.Rows[0]["DIPQ_QTD_RMC"] != null) && (dt.Rows[0]["DIPQ_QTD_RMC"] != DBNull.Value)) entity.DipqQtdRmc = Convert.ToString(dt.Rows[0]["DIPQ_QTD_RMC"]);
            if ((dt.Rows[0]["DIPQ_QTD_CP"] != null) && (dt.Rows[0]["DIPQ_QTD_CP"] != DBNull.Value)) entity.DipqQtdCp = Convert.ToString(dt.Rows[0]["DIPQ_QTD_CP"]);
            if ((dt.Rows[0]["DIPQ_QTD_AF"] != null) && (dt.Rows[0]["DIPQ_QTD_AF"] != DBNull.Value)) entity.DipqQtdAf = Convert.ToString(dt.Rows[0]["DIPQ_QTD_AF"]);
            if ((dt.Rows[0]["DIPQ_QTD_NF"] != null) && (dt.Rows[0]["DIPQ_QTD_NF"] != DBNull.Value)) entity.DipqQtdNf = Convert.ToString(dt.Rows[0]["DIPQ_QTD_NF"]);
            if ((dt.Rows[0]["DIPQ_QTD_NFD"] != null) && (dt.Rows[0]["DIPQ_QTD_NFD"] != DBNull.Value)) entity.DipqQtdNfd = Convert.ToString(dt.Rows[0]["DIPQ_QTD_NFD"]);
            if ((dt.Rows[0]["DIPQ_QTD_DR"] != null) && (dt.Rows[0]["DIPQ_QTD_DR"] != DBNull.Value)) entity.DipqQtdDr = Convert.ToString(dt.Rows[0]["DIPQ_QTD_DR"]);
            if ((dt.Rows[0]["DIPQ_QTD_DRD"] != null) && (dt.Rows[0]["DIPQ_QTD_DRD"] != DBNull.Value)) entity.DipqQtdDrd = Convert.ToString(dt.Rows[0]["DIPQ_QTD_DRD"]);
            if ((dt.Rows[0]["DIPQ_QTD_NE"] != null) && (dt.Rows[0]["DIPQ_QTD_NE"] != DBNull.Value)) entity.DipqQtdNe = Convert.ToString(dt.Rows[0]["DIPQ_QTD_NE"]);
            if ((dt.Rows[0]["DIPQ_QTD_NED"] != null) && (dt.Rows[0]["DIPQ_QTD_NED"] != DBNull.Value)) entity.DipqQtdNed = Convert.ToString(dt.Rows[0]["DIPQ_QTD_NED"]);
            if ((dt.Rows[0]["DIPQ_QTD_FS"] != null) && (dt.Rows[0]["DIPQ_QTD_FS"] != DBNull.Value)) entity.DipqQtdFs = Convert.ToString(dt.Rows[0]["DIPQ_QTD_FS"]);
            if ((dt.Rows[0]["DIPQ_QTD_ESTOQUE"] != null) && (dt.Rows[0]["DIPQ_QTD_ESTOQUE"] != DBNull.Value)) entity.DipqQtdEstoque = Convert.ToString(dt.Rows[0]["DIPQ_QTD_ESTOQUE"]);
            if ((dt.Rows[0]["DIPQ_QTD_ESTOQUE_CORRIDA"] != null) && (dt.Rows[0]["DIPQ_QTD_ESTOQUE_CORRIDA"] != DBNull.Value)) entity.DipqQtdEstoqueCorrida = Convert.ToDecimal(dt.Rows[0]["DIPQ_QTD_ESTOQUE_CORRIDA"]);
            if ((dt.Rows[0]["REPR_NUMERO"] != null) && (dt.Rows[0]["REPR_NUMERO"] != DBNull.Value)) entity.ReprNumero = Convert.ToString(dt.Rows[0]["REPR_NUMERO"]);
            if ((dt.Rows[0]["REPR_REV"] != null) && (dt.Rows[0]["REPR_REV"] != DBNull.Value)) entity.ReprRev = Convert.ToString(dt.Rows[0]["REPR_REV"]);
            if ((dt.Rows[0]["REPR_DT_EMISSAO"] != null) && (dt.Rows[0]["REPR_DT_EMISSAO"] != DBNull.Value)) entity.ReprDtEmissao = Convert.ToDateTime(dt.Rows[0]["REPR_DT_EMISSAO"]);
            if ((dt.Rows[0]["REPL_NUMERO"] != null) && (dt.Rows[0]["REPL_NUMERO"] != DBNull.Value)) entity.ReplNumero = Convert.ToDateTime(dt.Rows[0]["REPL_NUMERO"]);
            if ((dt.Rows[0]["DIPR_CODIGO"] != null) && (dt.Rows[0]["DIPR_CODIGO"] != DBNull.Value)) entity.DiprCodigo = Convert.ToString(dt.Rows[0]["DIPR_CODIGO"]);
            if ((dt.Rows[0]["DIPR_DIM1"] != null) && (dt.Rows[0]["DIPR_DIM1"] != DBNull.Value)) entity.DiprDim1 = Convert.ToString(dt.Rows[0]["DIPR_DIM1"]);
            if ((dt.Rows[0]["DIPR_DIM2"] != null) && (dt.Rows[0]["DIPR_DIM2"] != DBNull.Value)) entity.DiprDim2 = Convert.ToString(dt.Rows[0]["DIPR_DIM2"]);
            if ((dt.Rows[0]["DIPR_DIM3"] != null) && (dt.Rows[0]["DIPR_DIM3"] != DBNull.Value)) entity.DiprDim3 = Convert.ToString(dt.Rows[0]["DIPR_DIM3"]);
            if ((dt.Rows[0]["DIPR_DIMENSOES"] != null) && (dt.Rows[0]["DIPR_DIMENSOES"] != DBNull.Value)) entity.DiprDimensoes = Convert.ToString(dt.Rows[0]["DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["DIPR_PESO"] != null) && (dt.Rows[0]["DIPR_PESO"] != DBNull.Value)) entity.DiprPeso = Convert.ToString(dt.Rows[0]["DIPR_PESO"]);
            if ((dt.Rows[0]["DIPR_DT_CADASTRO"] != null) && (dt.Rows[0]["DIPR_DT_CADASTRO"] != DBNull.Value)) entity.DiprDtCadastro = Convert.ToDateTime(dt.Rows[0]["DIPR_DT_CADASTRO"]);
            if ((dt.Rows[0]["DIPU_CODIGO"] != null) && (dt.Rows[0]["DIPU_CODIGO"] != DBNull.Value)) entity.DipuCodigo = Convert.ToString(dt.Rows[0]["DIPU_CODIGO"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["UNME_NOME"] != null) && (dt.Rows[0]["UNME_NOME"] != DBNull.Value)) entity.UnmeNome = Convert.ToString(dt.Rows[0]["UNME_NOME"]);
            if ((dt.Rows[0]["EMPR_NOME"] != null) && (dt.Rows[0]["EMPR_NOME"] != DBNull.Value)) entity.EmprNome = Convert.ToString(dt.Rows[0]["EMPR_NOME"]);
            if ((dt.Rows[0]["DIPC_DIM1"] != null) && (dt.Rows[0]["DIPC_DIM1"] != DBNull.Value)) entity.DipcDim1 = Convert.ToString(dt.Rows[0]["DIPC_DIM1"]);
            if ((dt.Rows[0]["DIPC_DIM2"] != null) && (dt.Rows[0]["DIPC_DIM2"] != DBNull.Value)) entity.DipcDim2 = Convert.ToString(dt.Rows[0]["DIPC_DIM2"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_SIGLA"] != null) && (dt.Rows[0]["DISC_SIGLA"] != DBNull.Value)) entity.DiscSigla = Convert.ToString(dt.Rows[0]["DISC_SIGLA"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["UNPR_SIGLA"] != null) && (dt.Rows[0]["UNPR_SIGLA"] != DBNull.Value)) entity.UnprSigla = Convert.ToString(dt.Rows[0]["UNPR_SIGLA"]);
            if ((dt.Rows[0]["UNPR_NOME"] != null) && (dt.Rows[0]["UNPR_NOME"] != DBNull.Value)) entity.UnprNome = Convert.ToString(dt.Rows[0]["UNPR_NOME"]);
            if ((dt.Rows[0]["ARAP_SIGLA"] != null) && (dt.Rows[0]["ARAP_SIGLA"] != DBNull.Value)) entity.ArapSigla = Convert.ToString(dt.Rows[0]["ARAP_SIGLA"]);
            if ((dt.Rows[0]["ARAP_NOME"] != null) && (dt.Rows[0]["ARAP_NOME"] != DBNull.Value)) entity.ArapNome = Convert.ToString(dt.Rows[0]["ARAP_NOME"]);
            if ((dt.Rows[0]["DCPR_SIGLA"] != null) && (dt.Rows[0]["DCPR_SIGLA"] != DBNull.Value)) entity.DcprSigla = Convert.ToString(dt.Rows[0]["DCPR_SIGLA"]);
            if ((dt.Rows[0]["DCPR_NOME"] != null) && (dt.Rows[0]["DCPR_NOME"] != DBNull.Value)) entity.DcprNome = Convert.ToString(dt.Rows[0]["DCPR_NOME"]);
            if ((dt.Rows[0]["COMP_NOME"] != null) && (dt.Rows[0]["COMP_NOME"] != DBNull.Value)) entity.CompNome = Convert.ToString(dt.Rows[0]["COMP_NOME"]);
            if ((dt.Rows[0]["COMP_FONE1"] != null) && (dt.Rows[0]["COMP_FONE1"] != DBNull.Value)) entity.CompFone1 = Convert.ToString(dt.Rows[0]["COMP_FONE1"]);
            if ((dt.Rows[0]["COMP_EMAIL"] != null) && (dt.Rows[0]["COMP_EMAIL"] != DBNull.Value)) entity.CompEmail = Convert.ToString(dt.Rows[0]["COMP_EMAIL"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwRmItemDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting COMP_EMAIL Object"); }
        }
        //====================================================================
        public static List<VwRmItemDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwRmItemDTO> list = OracleDataTools.LoadEntity<VwRmItemDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwRmItemDTO>"); }
        }
        //====================================================================
        public static List<VwRmItemDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwRmItemDTO>"); }
        }
        //====================================================================
        public static List<VwRmItemDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwRmItemDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwRmItemDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwRmItem"); }
        }
        //====================================================================
        public static DTO.CollectionVwRmItemDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwRmItemDTO collection = new DTO.CollectionVwRmItemDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwRmItemDTO entity = new DTO.VwRmItemDTO();
                    if (dt.Rows[i]["DCMN_NUMERO"].ToString().Length != 0) entity.DcmnNumero = dt.Rows[i]["DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["DCMN_TITULO"].ToString().Length != 0) entity.DcmnTitulo = dt.Rows[i]["DCMN_TITULO"].ToString();
                    if (dt.Rows[i]["DIPC_CODIGO"].ToString().Length != 0) entity.DipcCodigo = dt.Rows[i]["DIPC_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString().Length != 0) entity.DipiDescricaoRes = dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    if (dt.Rows[i]["DIPI_DESCRICAO_COMPL"].ToString().Length != 0) entity.DipiDescricaoCompl = dt.Rows[i]["DIPI_DESCRICAO_COMPL"].ToString();
                    if (dt.Rows[i]["AFIT_ITEM"].ToString().Length != 0) entity.AfitItem = Convert.ToDecimal(dt.Rows[i]["AFIT_ITEM"]);
                    if (dt.Rows[i]["AFIT_QTD_TOTAL"].ToString().Length != 0) entity.AfitQtdTotal = Convert.ToDecimal(dt.Rows[i]["AFIT_QTD_TOTAL"]);
                    if (dt.Rows[i]["AUFO_ID"].ToString().Length != 0) entity.AufoId = Convert.ToDecimal(dt.Rows[i]["AUFO_ID"]);
                    if (dt.Rows[i]["AUFO_NUMERO"].ToString().Length != 0) entity.AufoNumero = dt.Rows[i]["AUFO_NUMERO"].ToString();
                    if (dt.Rows[i]["AUFO_REV"].ToString().Length != 0) entity.AufoRev = Convert.ToDecimal(dt.Rows[i]["AUFO_REV"]);
                    if (dt.Rows[i]["AUFO_DT_EMISSAO"].ToString().Length != 0) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[i]["AUFO_DT_EMISSAO"]);
                    if (dt.Rows[i]["AUFO_DT_CADASTRO"].ToString().Length != 0) entity.AufoDtCadastro = Convert.ToDateTime(dt.Rows[i]["AUFO_DT_CADASTRO"]);
                    if (dt.Rows[i]["DIPQ_QTD_RM"].ToString().Length != 0) entity.DipqQtdRm = dt.Rows[i]["DIPQ_QTD_RM"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_RMD"].ToString().Length != 0) entity.DipqQtdRmd = dt.Rows[i]["DIPQ_QTD_RMD"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_RMC"].ToString().Length != 0) entity.DipqQtdRmc = dt.Rows[i]["DIPQ_QTD_RMC"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_CP"].ToString().Length != 0) entity.DipqQtdCp = dt.Rows[i]["DIPQ_QTD_CP"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_AF"].ToString().Length != 0) entity.DipqQtdAf = dt.Rows[i]["DIPQ_QTD_AF"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_NF"].ToString().Length != 0) entity.DipqQtdNf = dt.Rows[i]["DIPQ_QTD_NF"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_NFD"].ToString().Length != 0) entity.DipqQtdNfd = dt.Rows[i]["DIPQ_QTD_NFD"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_DR"].ToString().Length != 0) entity.DipqQtdDr = dt.Rows[i]["DIPQ_QTD_DR"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_DRD"].ToString().Length != 0) entity.DipqQtdDrd = dt.Rows[i]["DIPQ_QTD_DRD"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_NE"].ToString().Length != 0) entity.DipqQtdNe = dt.Rows[i]["DIPQ_QTD_NE"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_NED"].ToString().Length != 0) entity.DipqQtdNed = dt.Rows[i]["DIPQ_QTD_NED"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_FS"].ToString().Length != 0) entity.DipqQtdFs = dt.Rows[i]["DIPQ_QTD_FS"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_ESTOQUE"].ToString().Length != 0) entity.DipqQtdEstoque = dt.Rows[i]["DIPQ_QTD_ESTOQUE"].ToString();
                    if (dt.Rows[i]["DIPQ_QTD_ESTOQUE_CORRIDA"].ToString().Length != 0) entity.DipqQtdEstoqueCorrida = Convert.ToDecimal(dt.Rows[i]["DIPQ_QTD_ESTOQUE_CORRIDA"]);
                    if (dt.Rows[i]["REPR_NUMERO"].ToString().Length != 0) entity.ReprNumero = dt.Rows[i]["REPR_NUMERO"].ToString();
                    if (dt.Rows[i]["REPR_REV"].ToString().Length != 0) entity.ReprRev = dt.Rows[i]["REPR_REV"].ToString();
                    if (dt.Rows[i]["REPR_DT_EMISSAO"].ToString().Length != 0) entity.ReprDtEmissao = Convert.ToDateTime(dt.Rows[i]["REPR_DT_EMISSAO"]);
                    if (dt.Rows[i]["REPL_NUMERO"].ToString().Length != 0) entity.ReplNumero = Convert.ToDateTime(dt.Rows[i]["REPL_NUMERO"]);
                    if (dt.Rows[i]["DIPR_CODIGO"].ToString().Length != 0) entity.DiprCodigo = dt.Rows[i]["DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPR_DIM1"].ToString().Length != 0) entity.DiprDim1 = dt.Rows[i]["DIPR_DIM1"].ToString();
                    if (dt.Rows[i]["DIPR_DIM2"].ToString().Length != 0) entity.DiprDim2 = dt.Rows[i]["DIPR_DIM2"].ToString();
                    if (dt.Rows[i]["DIPR_DIM3"].ToString().Length != 0) entity.DiprDim3 = dt.Rows[i]["DIPR_DIM3"].ToString();
                    if (dt.Rows[i]["DIPR_DIMENSOES"].ToString().Length != 0) entity.DiprDimensoes = dt.Rows[i]["DIPR_DIMENSOES"].ToString();
                    if (dt.Rows[i]["DIPR_PESO"].ToString().Length != 0) entity.DiprPeso = dt.Rows[i]["DIPR_PESO"].ToString();
                    if (dt.Rows[i]["DIPR_DT_CADASTRO"].ToString().Length != 0) entity.DiprDtCadastro = Convert.ToDateTime(dt.Rows[i]["DIPR_DT_CADASTRO"]);
                    if (dt.Rows[i]["DIPU_CODIGO"].ToString().Length != 0) entity.DipuCodigo = dt.Rows[i]["DIPU_CODIGO"].ToString();
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["UNME_NOME"].ToString().Length != 0) entity.UnmeNome = dt.Rows[i]["UNME_NOME"].ToString();
                    if (dt.Rows[i]["EMPR_NOME"].ToString().Length != 0) entity.EmprNome = dt.Rows[i]["EMPR_NOME"].ToString();
                    if (dt.Rows[i]["DIPC_DIM1"].ToString().Length != 0) entity.DipcDim1 = dt.Rows[i]["DIPC_DIM1"].ToString();
                    if (dt.Rows[i]["DIPC_DIM2"].ToString().Length != 0) entity.DipcDim2 = dt.Rows[i]["DIPC_DIM2"].ToString();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_SIGLA"].ToString().Length != 0) entity.DiscSigla = dt.Rows[i]["DISC_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["UNPR_SIGLA"].ToString().Length != 0) entity.UnprSigla = dt.Rows[i]["UNPR_SIGLA"].ToString();
                    if (dt.Rows[i]["UNPR_NOME"].ToString().Length != 0) entity.UnprNome = dt.Rows[i]["UNPR_NOME"].ToString();
                    if (dt.Rows[i]["ARAP_SIGLA"].ToString().Length != 0) entity.ArapSigla = dt.Rows[i]["ARAP_SIGLA"].ToString();
                    if (dt.Rows[i]["ARAP_NOME"].ToString().Length != 0) entity.ArapNome = dt.Rows[i]["ARAP_NOME"].ToString();
                    if (dt.Rows[i]["DCPR_SIGLA"].ToString().Length != 0) entity.DcprSigla = dt.Rows[i]["DCPR_SIGLA"].ToString();
                    if (dt.Rows[i]["DCPR_NOME"].ToString().Length != 0) entity.DcprNome = dt.Rows[i]["DCPR_NOME"].ToString();
                    if (dt.Rows[i]["COMP_NOME"].ToString().Length != 0) entity.CompNome = dt.Rows[i]["COMP_NOME"].ToString();
                    if (dt.Rows[i]["COMP_FONE1"].ToString().Length != 0) entity.CompFone1 = dt.Rows[i]["COMP_FONE1"].ToString();
                    if (dt.Rows[i]["COMP_EMAIL"].ToString().Length != 0) entity.CompEmail = dt.Rows[i]["COMP_EMAIL"].ToString();

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
            dict.Add("DcmnNumero", "DCMN_NUMERO");
            dict.Add("DcmnTitulo", "DCMN_TITULO");
            dict.Add("DipcCodigo", "DIPC_CODIGO");
            dict.Add("DipiDescricaoRes", "DIPI_DESCRICAO_RES");
            dict.Add("DipiDescricaoCompl", "DIPI_DESCRICAO_COMPL");
            dict.Add("AfitItem", "AFIT_ITEM");
            dict.Add("AfitQtdTotal", "AFIT_QTD_TOTAL");
            dict.Add("AufoId", "AUFO_ID");
            dict.Add("AufoNumero", "AUFO_NUMERO");
            dict.Add("AufoRev", "AUFO_REV");
            dict.Add("AufoDtEmissao", "AUFO_DT_EMISSAO");
            dict.Add("AufoDtCadastro", "AUFO_DT_CADASTRO");
            dict.Add("DipqQtdRm", "DIPQ_QTD_RM");
            dict.Add("DipqQtdRmd", "DIPQ_QTD_RMD");
            dict.Add("DipqQtdRmc", "DIPQ_QTD_RMC");
            dict.Add("DipqQtdCp", "DIPQ_QTD_CP");
            dict.Add("DipqQtdAf", "DIPQ_QTD_AF");
            dict.Add("DipqQtdNf", "DIPQ_QTD_NF");
            dict.Add("DipqQtdNfd", "DIPQ_QTD_NFD");
            dict.Add("DipqQtdDr", "DIPQ_QTD_DR");
            dict.Add("DipqQtdDrd", "DIPQ_QTD_DRD");
            dict.Add("DipqQtdNe", "DIPQ_QTD_NE");
            dict.Add("DipqQtdNed", "DIPQ_QTD_NED");
            dict.Add("DipqQtdFs", "DIPQ_QTD_FS");
            dict.Add("DipqQtdEstoque", "DIPQ_QTD_ESTOQUE");
            dict.Add("DipqQtdEstoqueCorrida", "DIPQ_QTD_ESTOQUE_CORRIDA");
            dict.Add("ReprNumero", "REPR_NUMERO");
            dict.Add("ReprRev", "REPR_REV");
            dict.Add("ReprDtEmissao", "REPR_DT_EMISSAO");
            dict.Add("ReplNumero", "REPL_NUMERO");
            dict.Add("DiprCodigo", "DIPR_CODIGO");
            dict.Add("DiprDim1", "DIPR_DIM1");
            dict.Add("DiprDim2", "DIPR_DIM2");
            dict.Add("DiprDim3", "DIPR_DIM3");
            dict.Add("DiprDimensoes", "DIPR_DIMENSOES");
            dict.Add("DiprPeso", "DIPR_PESO");
            dict.Add("DiprDtCadastro", "DIPR_DT_CADASTRO");
            dict.Add("DipuCodigo", "DIPU_CODIGO");
            dict.Add("UnmeSigla", "UNME_SIGLA");
            dict.Add("UnmeNome", "UNME_NOME");
            dict.Add("EmprNome", "EMPR_NOME");
            dict.Add("DipcDim1", "DIPC_DIM1");
            dict.Add("DipcDim2", "DIPC_DIM2");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("DiscSigla", "DISC_SIGLA");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("UnprSigla", "UNPR_SIGLA");
            dict.Add("UnprNome", "UNPR_NOME");
            dict.Add("ArapSigla", "ARAP_SIGLA");
            dict.Add("ArapNome", "ARAP_NOME");
            dict.Add("DcprSigla", "DCPR_SIGLA");
            dict.Add("DcprNome", "DCPR_NOME");
            dict.Add("CompNome", "COMP_NOME");
            dict.Add("CompFone1", "COMP_FONE1");
            dict.Add("CompEmail", "COMP_EMAIL");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
