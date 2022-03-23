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
    public class AcAvancoCompletacaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @" ";
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvancoCompletacao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvancoCompletacao"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcAvancoCompletacao"); }
        }
        ////====================================================================
        //public static DTO.AcAvancoCompletacaoDTO Get(decimal AcurId)
        //{
        //    AcAvancoCompletacaoDTO entity = new AcAvancoCompletacaoDTO();
        //    DataTable dt = null;
        //    string filter = "ACUR_ID = " + AcurId;
        //    dt = Get(filter, null);
        //    if ((dt.Rows[0]["ACUR_ID"] != null) && (dt.Rows[0]["ACUR_ID"] != DBNull.Value)) entity.AcurId = Convert.ToDecimal(dt.Rows[0]["ACUR_ID"]);
        //    if ((dt.Rows[0]["ACUR_SBCN_SIGLA"] != null) && (dt.Rows[0]["ACUR_SBCN_SIGLA"] != DBNull.Value)) entity.AcurSbcnSigla = Convert.ToString(dt.Rows[0]["ACUR_SBCN_SIGLA"]);
        //    if ((dt.Rows[0]["ACUR_DISC_ID"] != null) && (dt.Rows[0]["ACUR_DISC_ID"] != DBNull.Value)) entity.AcurDiscId = Convert.ToDecimal(dt.Rows[0]["ACUR_DISC_ID"]);
        //    if ((dt.Rows[0]["ACUR_DISC_NOME"] != null) && (dt.Rows[0]["ACUR_DISC_NOME"] != DBNull.Value)) entity.AcurDiscNome = Convert.ToString(dt.Rows[0]["ACUR_DISC_NOME"]);
        //    if ((dt.Rows[0]["ACUR_FCME_ID"] != null) && (dt.Rows[0]["ACUR_FCME_ID"] != DBNull.Value)) entity.AcurFcmeId = Convert.ToDecimal(dt.Rows[0]["ACUR_FCME_ID"]);
        //    if ((dt.Rows[0]["ACUR_FCME_SIGLA"] != null) && (dt.Rows[0]["ACUR_FCME_SIGLA"] != DBNull.Value)) entity.AcurFcmeSigla = Convert.ToString(dt.Rows[0]["ACUR_FCME_SIGLA"]);

        //    return entity;
        //}
        //====================================================================
        public static DTO.AcAvancoCompletacaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ACUR_QTD_AVANCO_EXEC_POND Object"); }
        }
        //====================================================================
        public static List<AcAvancoCompletacaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcAvancoCompletacaoDTO> list = OracleDataTools.LoadEntity<AcAvancoCompletacaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoCompletacaoDTO>"); }
        }
        //====================================================================
        public static List<AcAvancoCompletacaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoCompletacaoDTO>"); }
        }
        //====================================================================
        public static List<AcAvancoCompletacaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvancoCompletacaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvancoCompletacaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcAvancoCompletacao"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvancoCompletacaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcAvancoCompletacaoDTO collection = new DTO.CollectionAcAvancoCompletacaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcAvancoCompletacaoDTO entity = new DTO.AcAvancoCompletacaoDTO();
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[i]["FOSE_CNTR_CODIGO"]);
                    if (dt.Rows[i]["DISC_SIGLA"].ToString().Length != 0) entity.DiscSigla = Convert.ToString(dt.Rows[i]["DISC_SIGLA"]);
                    if (dt.Rows[i]["FOSE_SBCN_SIGLA"].ToString().Length != 0) entity.FoseSbcnSigla = Convert.ToString(dt.Rows[i]["FOSE_SBCN_SIGLA"]);
                    if (dt.Rows[i]["COD_BARRAS"].ToString().Length != 0) entity.CodBarras = Convert.ToString(dt.Rows[i]["COD_BARRAS"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = Convert.ToString(dt.Rows[i]["FOSE_NUMERO"]);
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["TAREFA"].ToString().Length != 0) entity.Tarefa = dt.Rows[i]["TAREFA"].ToString();
                    if (dt.Rows[i]["LOCALIZACAO_REGIAO"].ToString().Length != 0) entity.LocalizacaoRegiao = Convert.ToString(dt.Rows[i]["LOCALIZACAO_REGIAO"]);
                    if (dt.Rows[i]["REGIAO"].ToString().Length != 0) entity.Regiao = Convert.ToString(dt.Rows[i]["REGIAO"]);
                    if (dt.Rows[i]["ZONA"].ToString().Length != 0) entity.ZonaId = Convert.ToDecimal(dt.Rows[i]["ZONA"]);
                    if (dt.Rows[i]["EQUIPE"].ToString().Length != 0) entity.Equipe = dt.Rows[i]["EQUIPE"].ToString();

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
