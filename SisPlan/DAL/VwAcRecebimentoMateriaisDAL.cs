using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

namespace DAL
{
    public class VwAcRecebimentoMateriaisDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT ROWNUM AS ITENS_RECEBIDOS, SBCN_SIGLA, TO_CHAR(DATA_REC,'DD/MM/YY') AS DATA_REC,  NF,  FORNECEDOR,  AF,  ITEM_AF,  CODIGO_MAT, REPR_TIPO_DICIONARIO, TIPO_DICIONARIO, DESCRICAO,  DIMENSOES,  UN,  QTD_AF,  QTD_NF,  NEM,  TO_CHAR(DATA_NEM,'DD/MM/YY') AS DATA_NEM,  QTD_NEM,  NUMERO_RDR,  QTD_RDR,  DADOS_RDR,  PESO_UNIT,  DISCIPLINA,  RM, QTD_RM,  LM,  REV_LM,  QTD_LM FROM  EEP_CONVERSION.VW_AC_RECEBIMENTO_MATERIAIS";
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_AC_RECEBIMENTO_MATERIAIS";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VW_AC_RECEBIMENTO_MATERIAIS"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_RECEBIMENTO_MATERIAIS"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VW_AC_RECEBIMENTO_MATERIAIS"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTable VW_AC_RECEBIMENTO_MATERIAIS"); }
        }
        ////====================================================================
        public static DTO.VwAcRecebimentoMateriaisDTO Get(string filter)
        {
            VwAcRecebimentoMateriaisDTO entity = new VwAcRecebimentoMateriaisDTO();
            DataTable dt = null;
            dt = Get(filter, null);

            if ((dt.Rows[0]["ITENS_RECEBIDOS"] != null) && (dt.Rows[0]["ITENS_RECEBIDOS"] != DBNull.Value)) entity.ItensRecebidos = Convert.ToDecimal(dt.Rows[0]["ITENS_RECEBIDOS"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DATA_REC"] != null) && (dt.Rows[0]["DATA_REC"] != DBNull.Value)) entity.DataRec = Convert.ToString(dt.Rows[0]["DATA_REC"]);
            if ((dt.Rows[0]["NF"] != null) && (dt.Rows[0]["NF"] != DBNull.Value)) entity.NF = Convert.ToString(dt.Rows[0]["NF"]);
            if ((dt.Rows[0]["FORNECEDOR"] != null) && (dt.Rows[0]["FORNECEDOR"] != DBNull.Value)) entity.Fornecedor = Convert.ToString(dt.Rows[0]["FORNECEDOR"]);
            if ((dt.Rows[0]["AF"] != null) && (dt.Rows[0]["AF"] != DBNull.Value)) entity.AF = Convert.ToString(dt.Rows[0]["AF"]);
            if ((dt.Rows[0]["ITEM_AF"] != null) && (dt.Rows[0]["ITEM_AF"] != DBNull.Value)) entity.ItemAF = Convert.ToInt32(dt.Rows[0]["ITEM_AF"]);
            if ((dt.Rows[0]["CODIGO_MAT"] != null) && (dt.Rows[0]["CODIGO_MAT"] != DBNull.Value)) entity.CodigoMat = Convert.ToString(dt.Rows[0]["CODIGO_MAT"]);
            if ((dt.Rows[0]["REPR_TIPO_DICIONARIO"] != null) && (dt.Rows[0]["REPR_TIPO_DICIONARIO"] != DBNull.Value)) entity.ReprTipoDicionario = Convert.ToInt32(dt.Rows[0]["REPR_TIPO_DICIONARIO"]);
            if ((dt.Rows[0]["TIPO_DICIONARIO"] != null) && (dt.Rows[0]["TIPO_DICIONARIO"] != DBNull.Value)) entity.TipoDicionario = Convert.ToString(dt.Rows[0]["TIPO_DICIONARIO"]);
            if ((dt.Rows[0]["DESCRICAO"] != null) && (dt.Rows[0]["DESCRICAO"] != DBNull.Value)) entity.Descricao = Convert.ToString(dt.Rows[0]["DESCRICAO"]);
            if ((dt.Rows[0]["DIMENSOES"] != null) && (dt.Rows[0]["DIMENSOES"] != DBNull.Value)) entity.Dimensoes = Convert.ToString(dt.Rows[0]["DIMENSOES"]);
            if ((dt.Rows[0]["UN"] != null) && (dt.Rows[0]["UN"] != DBNull.Value)) entity.UN = Convert.ToString(dt.Rows[0]["UN"]);
            if ((dt.Rows[0]["QTD_AF"] != null) && (dt.Rows[0]["QTD_AF"] != DBNull.Value)) entity.QtdAF = Convert.ToDecimal(dt.Rows[0]["QTD_AF"]);
            if ((dt.Rows[0]["QTD_NF"] != null) && (dt.Rows[0]["QTD_NF"] != DBNull.Value)) entity.QtdNF = Convert.ToDecimal(dt.Rows[0]["QTD_NF"]);
            if ((dt.Rows[0]["NEM"] != null) && (dt.Rows[0]["NEM"] != DBNull.Value)) entity.NEM = Convert.ToString(dt.Rows[0]["NEM"]);
            if ((dt.Rows[0]["DATA_NEM"] != null) && (dt.Rows[0]["DATA_NEM"] != DBNull.Value)) entity.DataNEM = Convert.ToString(dt.Rows[0]["DATA_NEM"]);
            if ((dt.Rows[0]["QTD_NEM"] != null) && (dt.Rows[0]["QTD_NEM"] != DBNull.Value)) entity.QtdNEM = Convert.ToDecimal(dt.Rows[0]["QTD_NEM"]);
            if ((dt.Rows[0]["NUMERO_RDR"] != null) && (dt.Rows[0]["NUMERO_RDR"] != DBNull.Value)) entity.NumeroRDR = Convert.ToString(dt.Rows[0]["NUMERO_RDR"]);
            if ((dt.Rows[0]["QTD_RDR"] != null) && (dt.Rows[0]["QTD_RDR"] != DBNull.Value)) entity.QtdRDR = Convert.ToDecimal(dt.Rows[0]["QTD_RDR"]);
            if ((dt.Rows[0]["DADOS_RDR"] != null) && (dt.Rows[0]["DADOS_RDR"] != DBNull.Value)) entity.DadosRDR = Convert.ToString(dt.Rows[0]["DADOS_RDR"]);
            if ((dt.Rows[0]["PESO_UNIT"] != null) && (dt.Rows[0]["PESO_UNIT"] != DBNull.Value)) entity.PesoUnit = Convert.ToDecimal(dt.Rows[0]["PESO_UNIT"]);
            if ((dt.Rows[0]["DISCIPLINA"] != null) && (dt.Rows[0]["DISCIPLINA"] != DBNull.Value)) entity.Disciplina = Convert.ToString(dt.Rows[0]["DISCIPLINA"]);
            if ((dt.Rows[0]["RM"] != null) && (dt.Rows[0]["RM"] != DBNull.Value)) entity.RM = Convert.ToString(dt.Rows[0]["RM"]);
            if ((dt.Rows[0]["QTD_RM"] != null) && (dt.Rows[0]["QTD_RM"] != DBNull.Value)) entity.QtdRM = Convert.ToDecimal(dt.Rows[0]["QTD_RM"]);
            if ((dt.Rows[0]["LM"] != null) && (dt.Rows[0]["LM"] != DBNull.Value)) entity.LM = Convert.ToString(dt.Rows[0]["LM"]);
            if ((dt.Rows[0]["REV_LM"] != null) && (dt.Rows[0]["REV_LM"] != DBNull.Value)) entity.RevLM = Convert.ToString(dt.Rows[0]["REV_LM"]);
            if ((dt.Rows[0]["QTD_LM"] != null) && (dt.Rows[0]["QTD_LM"] != DBNull.Value)) entity.QtdLM = Convert.ToDecimal(dt.Rows[0]["QTD_LM"]);
            //if ((dt.Rows[0]["QTD_APLICADA"] != null) && (dt.Rows[0]["QTD_APLICADA"] != DBNull.Value)) entity.QtdAplicada = Convert.ToDecimal(dt.Rows[0]["QTD_APLICADA"]);

            return entity;
        }
        //====================================================================
        public static DTO.VwAcRecebimentoMateriaisDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VW_AC_RECEBIMENTO_MATERIAIS Object"); }
        }
        //====================================================================
        public static List<VwAcRecebimentoMateriaisDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcRecebimentoMateriaisDTO> list = OracleDataTools.LoadEntity<VwAcRecebimentoMateriaisDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_AC_RECEBIMENTO_MATERIAIS>"); }
        }
        //====================================================================
        public static List<VwAcRecebimentoMateriaisDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_AC_RECEBIMENTO_MATERIAIS>"); }
        }
        //====================================================================
        public static List<VwAcRecebimentoMateriaisDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VW_AC_RECEBIMENTO_MATERIAIS>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcRecebimentoMateriaisDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                //Hashtable dict = GetDictionary();
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcGrupoCriterioMedicaoDTO"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcRecebimentoMateriaisDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcRecebimentoMateriaisDTO collection = new DTO.CollectionVwAcRecebimentoMateriaisDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        DTO.VwAcRecebimentoMateriaisDTO entity = new DTO.VwAcRecebimentoMateriaisDTO();
                        if (dt.Rows[i]["ITENS_RECEBIDOS"].ToString().Length != 0) entity.ItensRecebidos = Convert.ToDecimal(dt.Rows[i]["ITENS_RECEBIDOS"]);
                        if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = Convert.ToString(dt.Rows[i]["SBCN_SIGLA"]);
                        if (dt.Rows[i]["DATA_REC"].ToString().Length != 0) entity.DataRec = Convert.ToString(dt.Rows[i]["DATA_REC"]);
                        if (dt.Rows[i]["NF"].ToString().Length != 0) entity.NF = Convert.ToString(dt.Rows[i]["NF"]);
                        if (dt.Rows[i]["FORNECEDOR"].ToString().Length != 0) entity.Fornecedor = Convert.ToString(dt.Rows[i]["FORNECEDOR"]);
                        if (dt.Rows[i]["AF"].ToString().Length != 0) entity.AF = Convert.ToString(dt.Rows[i]["AF"]);
                        if (dt.Rows[i]["ITEM_AF"].ToString().Length != 0) entity.ItemAF = Convert.ToInt32(dt.Rows[i]["ITEM_AF"]);
                        if (dt.Rows[i]["CODIGO_MAT"].ToString().Length != 0) entity.CodigoMat = Convert.ToString(dt.Rows[i]["CODIGO_MAT"]);
                        if (dt.Rows[i]["REPR_TIPO_DICIONARIO"].ToString().Length != 0) entity.ReprTipoDicionario = Convert.ToInt32(dt.Rows[i]["REPR_TIPO_DICIONARIO"]);
                        if (dt.Rows[i]["TIPO_DICIONARIO"].ToString().Length != 0) entity.TipoDicionario = Convert.ToString(dt.Rows[i]["TIPO_DICIONARIO"]);
                        if (dt.Rows[i]["DESCRICAO"].ToString().Length != 0) entity.Descricao = Convert.ToString(dt.Rows[i]["DESCRICAO"]);
                        if (dt.Rows[i]["DIMENSOES"].ToString().Length != 0) entity.Dimensoes = Convert.ToString(dt.Rows[i]["DIMENSOES"]);
                        if (dt.Rows[i]["UN"].ToString().Length != 0) entity.UN = Convert.ToString(dt.Rows[i]["UN"]);
                        if (dt.Rows[i]["QTD_AF"].ToString().Length != 0) entity.QtdAF = Convert.ToDecimal(dt.Rows[i]["QTD_AF"]);
                        if (dt.Rows[i]["QTD_NF"].ToString().Length != 0) entity.QtdNF = Convert.ToDecimal(dt.Rows[i]["QTD_NF"]);
                        if (dt.Rows[i]["NEM"].ToString().Length != 0) entity.NEM = Convert.ToString(dt.Rows[i]["NEM"]);
                        if (dt.Rows[i]["DATA_NEM"].ToString().Length != 0) entity.DataNEM = Convert.ToString(dt.Rows[i]["DATA_NEM"]);
                        if (dt.Rows[i]["QTD_NEM"].ToString().Length != 0) entity.QtdNEM = Convert.ToDecimal(dt.Rows[i]["QTD_NEM"]);
                        if (dt.Rows[i]["NUMERO_RDR"].ToString().Length != 0) entity.NumeroRDR = Convert.ToString(dt.Rows[i]["NUMERO_RDR"]);
                        if (dt.Rows[i]["QTD_RDR"].ToString().Length != 0) entity.QtdRDR = Convert.ToDecimal(dt.Rows[i]["QTD_RDR"]);
                        if (dt.Rows[i]["DADOS_RDR"].ToString().Length != 0) entity.DadosRDR = Convert.ToString(dt.Rows[i]["DADOS_RDR"]);
                        if (dt.Rows[i]["PESO_UNIT"].ToString().Length != 0) entity.PesoUnit = Convert.ToDecimal(dt.Rows[i]["PESO_UNIT"]);
                        if (dt.Rows[i]["DISCIPLINA"].ToString().Length != 0) entity.Disciplina = Convert.ToString(dt.Rows[i]["DISCIPLINA"]);
                        if (dt.Rows[i]["RM"].ToString().Length != 0) entity.RM = Convert.ToString(dt.Rows[i]["RM"]);
                        if (dt.Rows[i]["QTD_RM"].ToString().Length != 0) entity.QtdRM = Convert.ToDecimal(dt.Rows[i]["QTD_RM"]);
                        if (dt.Rows[i]["LM"].ToString().Length != 0) entity.LM = Convert.ToString(dt.Rows[i]["LM"]);
                        if (dt.Rows[i]["REV_LM"].ToString().Length != 0) entity.RevLM = Convert.ToString(dt.Rows[i]["REV_LM"]);
                        if (dt.Rows[i]["QTD_LM"].ToString().Length != 0) entity.QtdLM = Convert.ToDecimal(dt.Rows[i]["QTD_LM"]);
                        //if (dt.Rows[i]["QTD_APLICADA"].ToString().Length != 0) entity.QtdAplicada = Convert.ToDecimal(dt.Rows[i]["QTD_APLICADA"]);
                        collection.Add(entity);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message != "Input string was not in a correct format.")
                        {
                            throw new Exception(ex.Message);
                        }
                    }
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
