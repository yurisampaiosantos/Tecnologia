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
    public class VwAvnFoseEletricaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.DISC_NOME, X.ATIV_SIG, X.SBCN_NOME, X.UNPR_SIGLA, X.UNPR_NOME, X.ARAP_SIGLA, X.ARAP_NOME, X.FOSE_NUMERO, X.FOSE_QTD_PREVISTA, X.FOSE_QTD_REALIZADA, X.UNME_NOME, X.SIFS_DESCRICAO, X.PASTA, X.DESENHO, X.TIPO, X.SETOR, X.FCES_SIGLA, X.FCES_WBS, TO_CHAR(X.FSMP_DATA,'DD/MM/YYYY HH24:MI:SS') AS FSMP_DATA, X.FSMP_AVANCO_ACM, X.FSMP_QTD_ACM, TO_CHAR(X.FSMP_DT_CADASTRO,'DD/MM/YYYY HH24:MI:SS') AS FSMP_DT_CADASTRO, TO_CHAR(X.FSME_DATA,'DD/MM/YYYY HH24:MI:SS') AS FSME_DATA, X.FSME_AVANCO_ACM, X.FSME_QTD_ACM, TO_CHAR(X.FSME_DT_CADASTRO,'DD/MM/YYYY HH24:MI:SS') AS FSME_DT_CADASTRO, X.FOSM_ID, X.FOSM_FCES_ID, X.FOSE_CNTR_CODIGO, X.FOSE_SBCN_ID, X.FOSE_UNPR_ID, X.FOSE_ARAP_ID, X.FOSE_DISC_ID, X.DISC_ID, X.FOSE_ID, X.FOSE_SIFS_ID, X.FOSE_UNME_ID, X.FCES_FCME_ID, X.FCME_SIGLA, X.FCES_NIVEL, X.FCES_PESO_REL_CRON FROM EEP_CONVERSION.VW_AVN_FOSE_ELETRICA X ";
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAvnFoseEletrica"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_AVN_FOSE_ELETRICA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwAvnFoseEletrica"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAvnFoseEletrica"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwAvnFoseEletrica"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwAvnFoseEletrica"); }
        }
        //====================================================================
        public static DTO.VwAvnFoseEletricaDTO Get(string FoseNumero)
        {
            VwAvnFoseEletricaDTO entity = new VwAvnFoseEletricaDTO();
            DataTable dt = null;
            string filter = "FOSE_NUMERO = '" + FoseNumero + "'";
            dt = Get(filter, null);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["ATIV_SIG"] != null) && (dt.Rows[0]["ATIV_SIG"] != DBNull.Value)) entity.AtivSig = Convert.ToString(dt.Rows[0]["ATIV_SIG"]);
            if ((dt.Rows[0]["SBCN_NOME"] != null) && (dt.Rows[0]["SBCN_NOME"] != DBNull.Value)) entity.SbcnNome = Convert.ToString(dt.Rows[0]["SBCN_NOME"]);
            if ((dt.Rows[0]["UNPR_SIGLA"] != null) && (dt.Rows[0]["UNPR_SIGLA"] != DBNull.Value)) entity.UnprSigla = Convert.ToString(dt.Rows[0]["UNPR_SIGLA"]);
            if ((dt.Rows[0]["UNPR_NOME"] != null) && (dt.Rows[0]["UNPR_NOME"] != DBNull.Value)) entity.UnprNome = Convert.ToString(dt.Rows[0]["UNPR_NOME"]);
            if ((dt.Rows[0]["ARAP_SIGLA"] != null) && (dt.Rows[0]["ARAP_SIGLA"] != DBNull.Value)) entity.ArapSigla = Convert.ToString(dt.Rows[0]["ARAP_SIGLA"]);
            if ((dt.Rows[0]["ARAP_NOME"] != null) && (dt.Rows[0]["ARAP_NOME"] != DBNull.Value)) entity.ArapNome = Convert.ToString(dt.Rows[0]["ARAP_NOME"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToString(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["FOSE_QTD_REALIZADA"] != null) && (dt.Rows[0]["FOSE_QTD_REALIZADA"] != DBNull.Value)) entity.FoseQtdRealizada = Convert.ToString(dt.Rows[0]["FOSE_QTD_REALIZADA"]);
            if ((dt.Rows[0]["UNME_NOME"] != null) && (dt.Rows[0]["UNME_NOME"] != DBNull.Value)) entity.UnmeNome = Convert.ToString(dt.Rows[0]["UNME_NOME"]);
            if ((dt.Rows[0]["SIFS_DESCRICAO"] != null) && (dt.Rows[0]["SIFS_DESCRICAO"] != DBNull.Value)) entity.SifsDescricao = Convert.ToString(dt.Rows[0]["SIFS_DESCRICAO"]);
            if ((dt.Rows[0]["PASTA"] != null) && (dt.Rows[0]["PASTA"] != DBNull.Value)) entity.Pasta = Convert.ToString(dt.Rows[0]["PASTA"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["TIPO"] != null) && (dt.Rows[0]["TIPO"] != DBNull.Value)) entity.Tipo = Convert.ToString(dt.Rows[0]["TIPO"]);
            if ((dt.Rows[0]["SETOR"] != null) && (dt.Rows[0]["SETOR"] != DBNull.Value)) entity.Setor = Convert.ToString(dt.Rows[0]["SETOR"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["FCES_WBS"] != null) && (dt.Rows[0]["FCES_WBS"] != DBNull.Value)) entity.FcesWbs = Convert.ToString(dt.Rows[0]["FCES_WBS"]);
            if ((dt.Rows[0]["FSMP_DATA"] != null) && (dt.Rows[0]["FSMP_DATA"] != DBNull.Value)) entity.FsmpData = Convert.ToDateTime(dt.Rows[0]["FSMP_DATA"]);
            if ((dt.Rows[0]["FSMP_AVANCO_ACM"] != null) && (dt.Rows[0]["FSMP_AVANCO_ACM"] != DBNull.Value)) entity.FsmpAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSMP_AVANCO_ACM"]);
            if ((dt.Rows[0]["FSMP_QTD_ACM"] != null) && (dt.Rows[0]["FSMP_QTD_ACM"] != DBNull.Value)) entity.FsmpQtdAcm = Convert.ToDecimal(dt.Rows[0]["FSMP_QTD_ACM"]);
            if ((dt.Rows[0]["FSMP_DT_CADASTRO"] != null) && (dt.Rows[0]["FSMP_DT_CADASTRO"] != DBNull.Value)) entity.FsmpDtCadastro = Convert.ToDateTime(dt.Rows[0]["FSMP_DT_CADASTRO"]);
            if ((dt.Rows[0]["FSME_DATA"] != null) && (dt.Rows[0]["FSME_DATA"] != DBNull.Value)) entity.FsmeData = Convert.ToDateTime(dt.Rows[0]["FSME_DATA"]);
            if ((dt.Rows[0]["FSME_AVANCO_ACM"] != null) && (dt.Rows[0]["FSME_AVANCO_ACM"] != DBNull.Value)) entity.FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[0]["FSME_AVANCO_ACM"]);
            if ((dt.Rows[0]["FSME_QTD_ACM"] != null) && (dt.Rows[0]["FSME_QTD_ACM"] != DBNull.Value)) entity.FsmeQtdAcm = Convert.ToDecimal(dt.Rows[0]["FSME_QTD_ACM"]);
            if ((dt.Rows[0]["FSME_DT_CADASTRO"] != null) && (dt.Rows[0]["FSME_DT_CADASTRO"] != DBNull.Value)) entity.FsmeDtCadastro = Convert.ToDateTime(dt.Rows[0]["FSME_DT_CADASTRO"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToDecimal(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["FOSM_FCES_ID"] != null) && (dt.Rows[0]["FOSM_FCES_ID"] != DBNull.Value)) entity.FosmFcesId = Convert.ToDecimal(dt.Rows[0]["FOSM_FCES_ID"]);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["FOSE_SBCN_ID"] != null) && (dt.Rows[0]["FOSE_SBCN_ID"] != DBNull.Value)) entity.FoseSbcnId = Convert.ToDecimal(dt.Rows[0]["FOSE_SBCN_ID"]);
            if ((dt.Rows[0]["FOSE_UNPR_ID"] != null) && (dt.Rows[0]["FOSE_UNPR_ID"] != DBNull.Value)) entity.FoseUnprId = Convert.ToDecimal(dt.Rows[0]["FOSE_UNPR_ID"]);
            if ((dt.Rows[0]["FOSE_ARAP_ID"] != null) && (dt.Rows[0]["FOSE_ARAP_ID"] != DBNull.Value)) entity.FoseArapId = Convert.ToDecimal(dt.Rows[0]["FOSE_ARAP_ID"]);
            if ((dt.Rows[0]["FOSE_DISC_ID"] != null) && (dt.Rows[0]["FOSE_DISC_ID"] != DBNull.Value)) entity.FoseDiscId = Convert.ToDecimal(dt.Rows[0]["FOSE_DISC_ID"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_SIFS_ID"] != null) && (dt.Rows[0]["FOSE_SIFS_ID"] != DBNull.Value)) entity.FoseSifsId = Convert.ToDecimal(dt.Rows[0]["FOSE_SIFS_ID"]);
            if ((dt.Rows[0]["FOSE_UNME_ID"] != null) && (dt.Rows[0]["FOSE_UNME_ID"] != DBNull.Value)) entity.FoseUnmeId = Convert.ToDecimal(dt.Rows[0]["FOSE_UNME_ID"]);
            if ((dt.Rows[0]["FCES_FCME_ID"] != null) && (dt.Rows[0]["FCES_FCME_ID"] != DBNull.Value)) entity.FcesFcmeId = Convert.ToDecimal(dt.Rows[0]["FCES_FCME_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_NIVEL"] != null) && (dt.Rows[0]["FCES_NIVEL"] != DBNull.Value)) entity.FcesNivel = Convert.ToDecimal(dt.Rows[0]["FCES_NIVEL"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FCES_PESO_REL_CRON"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToString(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwAvnFoseEletricaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FCES_PESO_REL_CRON Object"); }
        }
        //====================================================================
        public static List<VwAvnFoseEletricaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwAvnFoseEletricaDTO> list = OracleDataTools.LoadEntity<VwAvnFoseEletricaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAvnFoseEletricaDTO>"); }
        }
        //====================================================================
        public static List<VwAvnFoseEletricaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAvnFoseEletricaDTO>"); }
        }
        //====================================================================
        public static List<VwAvnFoseEletricaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwAvnFoseEletricaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwAvnFoseEletricaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwAvnFoseEletrica"); }
        }
        //====================================================================
        public static DTO.CollectionVwAvnFoseEletricaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwAvnFoseEletricaDTO collection = new DTO.CollectionVwAvnFoseEletricaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwAvnFoseEletricaDTO entity = new DTO.VwAvnFoseEletricaDTO();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["ATIV_SIG"].ToString().Length != 0) entity.AtivSig = dt.Rows[i]["ATIV_SIG"].ToString();
                    if (dt.Rows[i]["SBCN_NOME"].ToString().Length != 0) entity.SbcnNome = dt.Rows[i]["SBCN_NOME"].ToString();
                    if (dt.Rows[i]["UNPR_SIGLA"].ToString().Length != 0) entity.UnprSigla = dt.Rows[i]["UNPR_SIGLA"].ToString();
                    if (dt.Rows[i]["UNPR_NOME"].ToString().Length != 0) entity.UnprNome = dt.Rows[i]["UNPR_NOME"].ToString();
                    if (dt.Rows[i]["ARAP_SIGLA"].ToString().Length != 0) entity.ArapSigla = dt.Rows[i]["ARAP_SIGLA"].ToString();
                    if (dt.Rows[i]["ARAP_NOME"].ToString().Length != 0) entity.ArapNome = dt.Rows[i]["ARAP_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_REALIZADA"].ToString().Length != 0) entity.FoseQtdRealizada = dt.Rows[i]["FOSE_QTD_REALIZADA"].ToString();
                    if (dt.Rows[i]["UNME_NOME"].ToString().Length != 0) entity.UnmeNome = dt.Rows[i]["UNME_NOME"].ToString();
                    if (dt.Rows[i]["SIFS_DESCRICAO"].ToString().Length != 0) entity.SifsDescricao = dt.Rows[i]["SIFS_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PASTA"].ToString().Length != 0) entity.Pasta = dt.Rows[i]["PASTA"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["TIPO"].ToString().Length != 0) entity.Tipo = dt.Rows[i]["TIPO"].ToString();
                    if (dt.Rows[i]["SETOR"].ToString().Length != 0) entity.Setor = dt.Rows[i]["SETOR"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_WBS"].ToString().Length != 0) entity.FcesWbs = dt.Rows[i]["FCES_WBS"].ToString();
                    if (dt.Rows[i]["FSMP_DATA"].ToString().Length != 0) entity.FsmpData = Convert.ToDateTime(dt.Rows[i]["FSMP_DATA"]);
                    if (dt.Rows[i]["FSMP_AVANCO_ACM"].ToString().Length != 0) entity.FsmpAvancoAcm = Convert.ToDecimal(dt.Rows[i]["FSMP_AVANCO_ACM"]);
                    if (dt.Rows[i]["FSMP_QTD_ACM"].ToString().Length != 0) entity.FsmpQtdAcm = Convert.ToDecimal(dt.Rows[i]["FSMP_QTD_ACM"]);
                    if (dt.Rows[i]["FSMP_DT_CADASTRO"].ToString().Length != 0) entity.FsmpDtCadastro = Convert.ToDateTime(dt.Rows[i]["FSMP_DT_CADASTRO"]);
                    if (dt.Rows[i]["FSME_DATA"].ToString().Length != 0) entity.FsmeData = Convert.ToDateTime(dt.Rows[i]["FSME_DATA"]);
                    if (dt.Rows[i]["FSME_AVANCO_ACM"].ToString().Length != 0) entity.FsmeAvancoAcm = Convert.ToDecimal(dt.Rows[i]["FSME_AVANCO_ACM"]);
                    if (dt.Rows[i]["FSME_QTD_ACM"].ToString().Length != 0) entity.FsmeQtdAcm = Convert.ToDecimal(dt.Rows[i]["FSME_QTD_ACM"]);
                    if (dt.Rows[i]["FSME_DT_CADASTRO"].ToString().Length != 0) entity.FsmeDtCadastro = Convert.ToDateTime(dt.Rows[i]["FSME_DT_CADASTRO"]);
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToDecimal(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["FOSM_FCES_ID"].ToString().Length != 0) entity.FosmFcesId = Convert.ToDecimal(dt.Rows[i]["FOSM_FCES_ID"]);
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["FOSE_SBCN_ID"].ToString().Length != 0) entity.FoseSbcnId = Convert.ToDecimal(dt.Rows[i]["FOSE_SBCN_ID"]);
                    if (dt.Rows[i]["FOSE_UNPR_ID"].ToString().Length != 0) entity.FoseUnprId = Convert.ToDecimal(dt.Rows[i]["FOSE_UNPR_ID"]);
                    if (dt.Rows[i]["FOSE_ARAP_ID"].ToString().Length != 0) entity.FoseArapId = Convert.ToDecimal(dt.Rows[i]["FOSE_ARAP_ID"]);
                    if (dt.Rows[i]["FOSE_DISC_ID"].ToString().Length != 0) entity.FoseDiscId = Convert.ToDecimal(dt.Rows[i]["FOSE_DISC_ID"]);
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_SIFS_ID"].ToString().Length != 0) entity.FoseSifsId = Convert.ToDecimal(dt.Rows[i]["FOSE_SIFS_ID"]);
                    if (dt.Rows[i]["FOSE_UNME_ID"].ToString().Length != 0) entity.FoseUnmeId = Convert.ToDecimal(dt.Rows[i]["FOSE_UNME_ID"]);
                    if (dt.Rows[i]["FCES_FCME_ID"].ToString().Length != 0) entity.FcesFcmeId = Convert.ToDecimal(dt.Rows[i]["FCES_FCME_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_NIVEL"].ToString().Length != 0) entity.FcesNivel = Convert.ToDecimal(dt.Rows[i]["FCES_NIVEL"]);
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = dt.Rows[i]["FCES_PESO_REL_CRON"].ToString();

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
