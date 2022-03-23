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
    //====================================================================
    public class AcResumoSemanalAtividadesDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //static string strSelect = @"SELECT X.ID, X.FOSE_CNTR_CODIGO, X.SEMA_ID, X.MES_COMPETENCIA, X.ANO_COMPETENCIA, X.SBCN_ID, X.SBCN_SIGLA, X.DISC_ID, X.DISC_NOME, X.FOSE_ID, X.FOSE_NUMERO, X.FOSE_DESCRICAO, X.UNME_SIGLA, X.SIFS_DESCRICAO, X.FCME_SIGLA, X.FCES_SIGLA, X.SUMA_ATIV_SIG, X.GRCR_NOME, X.FOSE_QTD_PREVISTA, X.QTD_ACUMULADA, X.FCES_PESO_REL_CRON, TO_DATE(X.FSME_DATA,'DD/MM/YY') AS FSME_DATA, AVN_POND_EXEC_PERIODO, AVN_REAL_EXEC_PERIODO, TO_DATE(X.FSMP_DATA,'DD/MM/YY') AS FSMP_DATA, X.AVN_POND_PROG_PERIODO, X.AVN_REAL_PROG_PERIODO, X.EQUIPE, X.SETOR, X.LOCALIZACAO, X.DESENHO, X.ORIGEM_FABRICACAO, X.AREA_PINTURA, X.CLASSIFICADO, X.DESCRICAO_ESTRUTURA, X.ITEM_CONTROLE, X.DIAM, X.EMPRESA_RESPONSAVEL, X.NOTA, X.REGIAO, X.SEMANA_FOLHA, X.SISTEMA, X.SPEC, X.TRATAMENTO, X.INDEFINIDO  FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO X ";
        static string strSelect = @"";
    //====================================================================
    public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
    {
        try
        {
            OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
        }
        catch (Exception ex)
        { throw new Exception(ex.Message + " - Executing SQL Instruction AcResumoSemanalAtividades"); }
    }
    //====================================================================
    public static void ExecuteSQLInstruction(string strSQL)
    {
        try
        {
            OracleDataTools.ExecuteSQLInstruction(strSQL);
        }
        catch (Exception ex)
        { throw new Exception(ex.Message + " - Executing SQL Instruction AcResumoSemanalAtividades"); }
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
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcResumoSemanalAtividades"); }
    }
    ////====================================================================
    //public static DTO.AcResumoSemanalAtividadesDTO Get(decimal ID)
    //{
    //    AcResumoSemanalAtividadesDTO entity = new AcResumoSemanalAtividadesDTO();
    //    DataTable dt = null;
    //    string filter = "ID = " + ID;
    //    dt = Get(filter, null);
    //    if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
    //    if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
    //    if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
    //    if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
    //    if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
    //    if ((dt.Rows[0]["AVN_POND_EXEC_PERIODO"] != null) && (dt.Rows[0]["AVN_POND_EXEC_PERIODO"] != DBNull.Value)) entity.AvnPondExecPeriodo = Convert.ToDecimal(dt.Rows[0]["AVN_POND_EXEC_PERIODO"]);
            
    //    return entity;
    //}
    //====================================================================
    public static DTO.AcResumoSemanalAtividadesDTO GetObject(string filter, string sortSequence)
    {
        try
        {
            return GetCollection(Get(filter, sortSequence))[0];
        }
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting AcResumoSemanalAtividades Object"); }
    }
    //====================================================================
    public static List<AcResumoSemanalAtividadesDTO> GetList(string filter, string sortSequence)
    {
        try
        {
            strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
            List<AcResumoSemanalAtividadesDTO> list = OracleDataTools.LoadEntity<AcResumoSemanalAtividadesDTO>(strSelect);
            return list;
        }
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcResumoSemanalAtividadesDTO>"); }
    }
    //====================================================================
    public static List<AcResumoSemanalAtividadesDTO> GetList(string sortSequence)
    {
        try
        {
            return GetList(null, sortSequence);
        }
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcResumoSemanalAtividadesDTO>"); }
    }
    //====================================================================
    public static List<AcResumoSemanalAtividadesDTO> GetList()
    {
        try
        {
            return GetList(null, null);
        }
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcResumoSemanalAtividadesDTO>"); }
    }
    //====================================================================
    public static DTO.CollectionAcResumoSemanalAtividadesDTO GetCollection(string filter, string sortSequence)
    {
        try
        {
            return GetCollection(Get(filter, sortSequence));
        }
        catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcResumoSemanalAtividades"); }
    }
    //====================================================================
    public static DTO.CollectionAcResumoSemanalAtividadesDTO GetCollection(DataTable dt)
    {
        DTO.CollectionAcResumoSemanalAtividadesDTO collection = new DTO.CollectionAcResumoSemanalAtividadesDTO();
        try
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DTO.AcResumoSemanalAtividadesDTO entity = new DTO.AcResumoSemanalAtividadesDTO();
                if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                if (dt.Rows[i]["SUMA_ATIV_SIG"].ToString().Length != 0) entity.SumaAtivSig = dt.Rows[i]["SUMA_ATIV_SIG"].ToString();
                if (dt.Rows[i]["AVN_POND_EXEC_PERIODO"].ToString().Length != 0) entity.AvnPondExecPeriodo = Convert.ToDecimal(dt.Rows[i]["AVN_POND_EXEC_PERIODO"]);
                if (dt.Rows[i]["AVN_REAL_EXEC_PERIODO"].ToString().Length != 0) entity.AvnRealExecPeriodo = Convert.ToDecimal(dt.Rows[i]["AVN_REAL_EXEC_PERIODO"]);
                if (dt.Rows[i]["AVN_POND_PROG_PERIODO"].ToString().Length != 0) entity.AvnPondProgPeriodo = Convert.ToDecimal(dt.Rows[i]["AVN_POND_PROG_PERIODO"]);
                if (dt.Rows[i]["AVN_REAL_PROG_PERIODO"].ToString().Length != 0) entity.AvnRealProgPeriodo = Convert.ToDecimal(dt.Rows[i]["AVN_REAL_PROG_PERIODO"]);
                if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                if (dt.Rows[i]["POND_CRITERIO"].ToString().Length != 0) entity.PondCriterio = Convert.ToDecimal(dt.Rows[i]["POND_CRITERIO"]);
                    
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
        dict.Add("FoseCntrCodigo", "FOSE_CNTR_CODIGO");
        dict.Add("SemaId", "SEMA_ID");
        dict.Add("SbcnSigla", "SBCN_SIGLA");
        dict.Add("FcmeSigla", "FCME_SIGLA");
        dict.Add("SumaAtivSig", "SUMA_ATIV_SIG");
        dict.Add("AvnPondExecPeriodo", "AVN_POND_EXEC_PERIODO");
        dict.Add("AvnRealExecPeriodo", "AVN_REAL_EXEC_PERIODO");
        dict.Add("AvnPondProgPeriodo", "AVN_POND_PROG_PERIODO");
        dict.Add("AvnRealProgPeriodo", "AVN_REAL_PROG_PERIODO");
        dict.Add("FcesPesoRelCron", "FCES_PESO_REL_CRON");
        dict.Add("PondCriterio", "POND_CRITERIO");
        return dict;
    }
    //====================================================================
    #endregion
    }
}
