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
    public class VwAcEstoqueMaterialDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT * FROM (
                                            SELECT  DISTINCT
                                            SBCN_SIGLA, ARES_SIGLA, DIPR_CODIGO, DIPR_DIMENSOES, UNME_SIGLA, DIPI_DESCRICAO_RES, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD, NOEN_NUMERO, NOEI_QTD_NEM, NOEN_DT_EMISSAO, DVRE_NUMERO, DVRE_OBS
                                            FROM EEP_CONVERSION.V_NE_ITEM
                                            WHERE DIPR_CODIGO||DIPR_DIMENSOES IN (SELECT DISTINCT( MAPD_DIPR_CODIGO || MAPD_DIPR_DIMENSOES) AS MATERIAL FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES)) ";
        
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwAcEstoqueMaterial"); }
        }
        //====================================================================
        public static DTO.VwAcEstoqueMaterialDTO Get(decimal AcurId)
        {
            VwAcEstoqueMaterialDTO entity = new VwAcEstoqueMaterialDTO();
            DataTable dt = null;
            string filter = "ACUR_ID = " + AcurId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["ARES_SIGLA"] != null) && (dt.Rows[0]["ARES_SIGLA"] != DBNull.Value)) entity.AresSigla = Convert.ToString(dt.Rows[0]["ARES_SIGLA"]);
            if ((dt.Rows[0]["DIPR_CODIGO"] != null) && (dt.Rows[0]["DIPR_CODIGO"] != DBNull.Value)) entity.DiprCodigo = Convert.ToString(dt.Rows[0]["DIPR_CODIGO"]);
            if ((dt.Rows[0]["DIPR_DIMENSOES"] != null) && (dt.Rows[0]["DIPR_DIMENSOES"] != DBNull.Value)) entity.DiprDimensoes = Convert.ToString(dt.Rows[0]["DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_RES"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_RES"] != DBNull.Value)) entity.DipiDescricaoRes = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_RES"]);
            if ((dt.Rows[0]["NOFI_NUMERO"] != null) && (dt.Rows[0]["NOFI_NUMERO"] != DBNull.Value)) entity.NofiNumero = Convert.ToString(dt.Rows[0]["NOFI_NUMERO"]);
            if ((dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != null) && (dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != DBNull.Value)) entity.NofiDtRecebimento = Convert.ToString(dt.Rows[0]["NOFI_DT_RECEBIMENTO"]);
            if ((dt.Rows[0]["NFIT_QTD"] != null) && (dt.Rows[0]["NFIT_QTD"] != DBNull.Value)) entity.NfitQtd = Convert.ToDecimal(dt.Rows[0]["NFIT_QTD"]);
            if ((dt.Rows[0]["NOEN_NUMERO"] != null) && (dt.Rows[0]["NOEN_NUMERO"] != DBNull.Value)) entity.NoenNumero = Convert.ToString(dt.Rows[0]["NOEN_NUMERO"]);
            if ((dt.Rows[0]["NOEI_QTD_NEM"] != null) && (dt.Rows[0]["NOEI_QTD_NEM"] != DBNull.Value)) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[0]["NOEI_QTD_NEM"]);
            if ((dt.Rows[0]["NOEN_DT_EMISSAO"] != null) && (dt.Rows[0]["NOEN_DT_EMISSAO"] != DBNull.Value)) entity.NoenDtEmissao = Convert.ToString(dt.Rows[0]["NOEN_DT_EMISSAO"]);
            if ((dt.Rows[0]["DVRE_NUMERO"] != null) && (dt.Rows[0]["DVRE_NUMERO"] != DBNull.Value)) entity.DvreNumero = Convert.ToString(dt.Rows[0]["DVRE_NUMERO"]);
            if ((dt.Rows[0]["DVRE_OBS"] != null) && (dt.Rows[0]["DVRE_OBS"] != DBNull.Value)) entity.DvreObs = Convert.ToString(dt.Rows[0]["DVRE_OBS"]);
            
            return entity;
        }
        //====================================================================
        public static DTO.VwAcEstoqueMaterialDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting VwAcEstoqueMaterialDTO Object"); }
        }
        //====================================================================
        public static List<VwAcEstoqueMaterialDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAcEstoqueMaterialDTO> list = OracleDataTools.LoadEntity<VwAcEstoqueMaterialDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcEstoqueMaterialDTO>"); }
        }
        //====================================================================
        public static List<VwAcEstoqueMaterialDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcEstoqueMaterialDTO>"); }
        }
        //====================================================================
        public static List<VwAcEstoqueMaterialDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAcEstoqueMaterialDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcEstoqueMaterialDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAcEstoqueMaterial"); }
        }
        //====================================================================
        public static DTO.CollectionVwAcEstoqueMaterialDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAcEstoqueMaterialDTO collection = new DTO.CollectionVwAcEstoqueMaterialDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //SBCN_SIGLA, ARES_SIGLA, DIPR_CODIGO, DIPR_DIMENSOES, UNME_SIGLA, DIPI_DESCRICAO_RES, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD, NOEN_NUMERO, NOEI_QTD_NEM, NOEN_DT_EMISSAO, DVRE_NUMERO, DVRE_OBS
                    DTO.VwAcEstoqueMaterialDTO entity = new DTO.VwAcEstoqueMaterialDTO();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = Convert.ToString(dt.Rows[i]["SBCN_SIGLA"]);
                    if (dt.Rows[i]["ARES_SIGLA"].ToString().Length != 0) entity.AresSigla = dt.Rows[i]["ARES_SIGLA"].ToString();
                    if (dt.Rows[i]["DIPR_CODIGO"].ToString().Length != 0) entity.DiprCodigo = dt.Rows[i]["DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPR_DIMENSOES"].ToString().Length != 0) entity.DiprDimensoes = Convert.ToString(dt.Rows[i]["DIPR_DIMENSOES"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = Convert.ToString(dt.Rows[i]["UNME_SIGLA"]);
                    if (dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString().Length != 0) entity.DipiDescricaoRes = dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    if (dt.Rows[i]["NOFI_NUMERO"].ToString().Length != 0) entity.NofiNumero = Convert.ToString(dt.Rows[i]["NOFI_NUMERO"]);
                    if (dt.Rows[i]["NOFI_DT_RECEBIMENTO"].ToString().Length != 0) entity.NofiDtRecebimento = dt.Rows[i]["NOFI_DT_RECEBIMENTO"].ToString();
                    if (dt.Rows[i]["NFIT_QTD"].ToString().Length != 0) entity.NfitQtd = Convert.ToDecimal(dt.Rows[i]["NFIT_QTD"]);
                    if (dt.Rows[i]["NOEN_NUMERO"].ToString().Length != 0) entity.NoenNumero = dt.Rows[i]["NOEN_NUMERO"].ToString();
                    if (dt.Rows[i]["NOEI_QTD_NEM"].ToString().Length != 0) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[i]["NOEI_QTD_NEM"]);
                    if (dt.Rows[i]["NOEN_DT_EMISSAO"].ToString().Length != 0) entity.NoenDtEmissao = Convert.ToString(dt.Rows[i]["NOEN_DT_EMISSAO"]);
                    if (dt.Rows[i]["DVRE_NUMERO"].ToString().Length != 0) entity.DvreNumero = dt.Rows[i]["DVRE_NUMERO"].ToString();
                    if (dt.Rows[i]["DVRE_OBS"].ToString().Length != 0) entity.DvreObs = dt.Rows[i]["DVRE_OBS"].ToString();

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
        //    dict.Add("AcurId", "ACUR_ID");
        //    dict.Add("AcurSbcnSigla", "ACUR_SBCN_SIGLA");
        //    dict.Add("AcurTipoAvanco", "ACUR_TIPO_AVANCO");
        //    dict.Add("AcurDataAvanco", "ACUR_DATA_AVANCO");
        //    dict.Add("AcurDiscId", "ACUR_DISC_ID");
        //    dict.Add("AcurDiscNome", "ACUR_DISC_NOME");
        //    dict.Add("AcurFcmeId", "ACUR_FCME_ID");
        //    dict.Add("AcurFcmeSigla", "ACUR_FCME_SIGLA");
        //    dict.Add("AcurFcesId", "ACUR_FCES_ID");
        //    dict.Add("AcurFcesSigla", "ACUR_FCES_SIGLA");
        //    dict.Add("AcurFcesWbs", "ACUR_FCES_WBS");
        //    dict.Add("AcurFoseId", "ACUR_FOSE_ID");
        //    dict.Add("AcurFoseNumero", "ACUR_FOSE_NUMERO");
        //    dict.Add("AcurUnmeSigla", "ACUR_UNME_SIGLA");
        //    dict.Add("AcurTstfUnidadeRegional", "ACUR_TSTF_UNIDADE_REGIONAL");
        //    dict.Add("AcurRegiao", "ACUR_REGIAO");
        //    dict.Add("AcurQtdPrevista", "ACUR_QTD_PREVISTA");
        //    dict.Add("AcurFsmpFosmId", "ACUR_FSMP_FOSM_ID");
        //    dict.Add("AcurMaxFsmpData", "ACUR_MAX_FSMP_DATA");
        //    dict.Add("AcurFsmpAvancoAcm", "ACUR_FSMP_AVANCO_ACM");
        //    dict.Add("AcurQtdProg", "ACUR_QTD_PROG");
        //    dict.Add("AcurFsmeFosmId", "ACUR_FSME_FOSM_ID");
        //    dict.Add("AcurMaxFsmeData", "ACUR_MAX_FSME_DATA");
        //    dict.Add("AcurFsmeAvancoAcm", "ACUR_FSME_AVANCO_ACM");
        //    dict.Add("AcurQtdExec", "ACUR_QTD_EXEC");
        //    return dict;
        //}
        //====================================================================
        #endregion
    }
}
