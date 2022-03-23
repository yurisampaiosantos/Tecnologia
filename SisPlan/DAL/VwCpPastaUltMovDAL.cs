using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;

//====================================================================

namespace DAL
{
    public class VwCpPastaUltMovDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT 
                                        * 
                                    FROM 
                                        (SELECT 
                                            X.MOVI_ID, X.MOVI_CNTR_CODIGO, X.PASTA_SBCN_SIGLA, X.PASTA_FASE, X.PASTA_BLOCO, X.SSOP_CODIGO, X.SSOP_DESCRICAO, X.MOVI_PASTA_ID, X.PASTA_CODIGO, 
                                            TO_CHAR(X.MOVI_DATE,'DD/MM/YYYY HH24:MI:SS') AS MOVI_DATE, X.MOVI_DATE_DESC, X.STMO_LOCA_ID, X.LOCA_DESCRICAO, X.MOVI_USUA_LOGIN, X.USUA_ACTIVE, 
                                            X.USUA_AG_CRIAR_PUNCH, X.USUA_AG_CLASS_PUNCH, X.USUA_AG_STATUS_PUNCH, X.USUA_AG_CRIAR_PENDMAT, X.USUA_AG_STATUS_PENDMAT, X.MOVI_CREATED_BY, 
                                            X.MOVI_STMO_ID, X.SMGR_DESCRICAO, X.STMO_DESCRICAO, X.DISC_ID, X.DISC_SIGLA, X.DISC_NOME, X.AREA_DESCRICAO, X.ESCO_DESCRICAO, X.STMO_SEQUENCE, 
                                            X.MOVI_IN_GRD, X.SMGR_ID, X.PASTA_SSOP_ID, X.AREA_ID, X.PASTA_ESCO_ID, X.PASTA_STPA_ID, X.STPA_DESCRICAO,
                                            X.PASTA_EXECUTOR, P.PUNCH_DESCRICAO, P.PUNCH_SITUACAO, P.PUNCH_STPU_ID, S.STPU_DESCRICAO, past.PASTA_OBSERVACAO, DECODE(past.PASTA_TESTE_LIBERADO, 1, 'LIBERADO', '') AS PASTA_TESTE_LIBERADO
                                        FROM    
                                            EEP_CONVERSION.VW_CP_PASTA_ULT_MOV X , EEP_CONVERSION.CP_PUNCHLIST P, EEP_CONVERSION.CP_STATUS_PUNCHLIST S, EEP_CONVERSION.CP_PASTA past
                                        WHERE   
                                            PUNCH_PASTA_ID(+) = X.MOVI_PASTA_ID AND
                                            X.MOVI_PASTA_ID = past.PASTA_ID AND
                                            STPU_ID(+) = P.PUNCH_STPU_ID)";
        
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPastaUltMov"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.VW_CP_PASTA_ULT_MOV";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting VwCpPastaUltMov"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPastaUltMov"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction VwCpPastaUltMov"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableVwCpPastaUltMov"); }
        }
        //====================================================================
        public static DTO.VwCpPastaUltMovDTO Get(decimal MoviId)
        {
            VwCpPastaUltMovDTO entity = new VwCpPastaUltMovDTO();
            DataTable dt = null;
            string filter = "MOVI_ID = " + MoviId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["MOVI_ID"] != null) && (dt.Rows[0]["MOVI_ID"] != DBNull.Value)) entity.MoviId = Convert.ToDecimal(dt.Rows[0]["MOVI_ID"]);
            if ((dt.Rows[0]["MOVI_CNTR_CODIGO"] != null) && (dt.Rows[0]["MOVI_CNTR_CODIGO"] != DBNull.Value)) entity.MoviCntrCodigo = Convert.ToString(dt.Rows[0]["MOVI_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PASTA_SBCN_SIGLA"] != null) && (dt.Rows[0]["PASTA_SBCN_SIGLA"] != DBNull.Value)) entity.PastaSbcnSigla = Convert.ToString(dt.Rows[0]["PASTA_SBCN_SIGLA"]);
            if ((dt.Rows[0]["PASTA_FASE"] != null) && (dt.Rows[0]["PASTA_FASE"] != DBNull.Value)) entity.PastaFase = Convert.ToString(dt.Rows[0]["PASTA_FASE"]);
            if ((dt.Rows[0]["PASTA_BLOCO"] != null) && (dt.Rows[0]["PASTA_BLOCO"] != DBNull.Value)) entity.PastaBloco = Convert.ToString(dt.Rows[0]["PASTA_BLOCO"]);
            if ((dt.Rows[0]["SSOP_CODIGO"] != null) && (dt.Rows[0]["SSOP_CODIGO"] != DBNull.Value)) entity.SsopCodigo = Convert.ToString(dt.Rows[0]["SSOP_CODIGO"]);
            if ((dt.Rows[0]["SSOP_DESCRICAO"] != null) && (dt.Rows[0]["SSOP_DESCRICAO"] != DBNull.Value)) entity.SsopDescricao = Convert.ToString(dt.Rows[0]["SSOP_DESCRICAO"]);
            if ((dt.Rows[0]["MOVI_PASTA_ID"] != null) && (dt.Rows[0]["MOVI_PASTA_ID"] != DBNull.Value)) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[0]["MOVI_PASTA_ID"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["MOVI_DATE"] != null) && (dt.Rows[0]["MOVI_DATE"] != DBNull.Value)) entity.MoviDate = Convert.ToDateTime(dt.Rows[0]["MOVI_DATE"]);
            if ((dt.Rows[0]["MOVI_DATE_DESC"] != null) && (dt.Rows[0]["MOVI_DATE_DESC"] != DBNull.Value)) entity.MoviDateDesc = Convert.ToString(dt.Rows[0]["MOVI_DATE_DESC"]);
            if ((dt.Rows[0]["STMO_LOCA_ID"] != null) && (dt.Rows[0]["STMO_LOCA_ID"] != DBNull.Value)) entity.StmoLocaId = Convert.ToDecimal(dt.Rows[0]["STMO_LOCA_ID"]);
            if ((dt.Rows[0]["LOCA_DESCRICAO"] != null) && (dt.Rows[0]["LOCA_DESCRICAO"] != DBNull.Value)) entity.LocaDescricao = Convert.ToString(dt.Rows[0]["LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["MOVI_USUA_LOGIN"] != null) && (dt.Rows[0]["MOVI_USUA_LOGIN"] != DBNull.Value)) entity.MoviUsuaLogin = Convert.ToString(dt.Rows[0]["MOVI_USUA_LOGIN"]);
            if ((dt.Rows[0]["USUA_ACTIVE"] != null) && (dt.Rows[0]["USUA_ACTIVE"] != DBNull.Value)) entity.UsuaActive = Convert.ToDecimal(dt.Rows[0]["USUA_ACTIVE"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != DBNull.Value)) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != DBNull.Value)) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CLASS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != DBNull.Value)) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != DBNull.Value)) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != DBNull.Value)) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PENDMAT"]);
            if ((dt.Rows[0]["MOVI_CREATED_BY"] != null) && (dt.Rows[0]["MOVI_CREATED_BY"] != DBNull.Value)) entity.MoviCreatedBy = Convert.ToString(dt.Rows[0]["MOVI_CREATED_BY"]);
            if ((dt.Rows[0]["MOVI_STMO_ID"] != null) && (dt.Rows[0]["MOVI_STMO_ID"] != DBNull.Value)) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[0]["MOVI_STMO_ID"]);
            if ((dt.Rows[0]["SMGR_DESCRICAO"] != null) && (dt.Rows[0]["SMGR_DESCRICAO"] != DBNull.Value)) entity.SmgrDescricao = Convert.ToString(dt.Rows[0]["SMGR_DESCRICAO"]);
            if ((dt.Rows[0]["STMO_DESCRICAO"] != null) && (dt.Rows[0]["STMO_DESCRICAO"] != DBNull.Value)) entity.StmoDescricao = Convert.ToString(dt.Rows[0]["STMO_DESCRICAO"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_SIGLA"] != null) && (dt.Rows[0]["DISC_SIGLA"] != DBNull.Value)) entity.DiscSigla = Convert.ToString(dt.Rows[0]["DISC_SIGLA"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["AREA_DESCRICAO"] != null) && (dt.Rows[0]["AREA_DESCRICAO"] != DBNull.Value)) entity.AreaDescricao = Convert.ToString(dt.Rows[0]["AREA_DESCRICAO"]);
            if ((dt.Rows[0]["ESCO_DESCRICAO"] != null) && (dt.Rows[0]["ESCO_DESCRICAO"] != DBNull.Value)) entity.EscoDescricao = Convert.ToString(dt.Rows[0]["ESCO_DESCRICAO"]);
            if ((dt.Rows[0]["STMO_SEQUENCE"] != null) && (dt.Rows[0]["STMO_SEQUENCE"] != DBNull.Value)) entity.StmoSequence = Convert.ToDecimal(dt.Rows[0]["STMO_SEQUENCE"]);
            if ((dt.Rows[0]["MOVI_IN_GRD"] != null) && (dt.Rows[0]["MOVI_IN_GRD"] != DBNull.Value)) entity.MoviInGrd = Convert.ToDecimal(dt.Rows[0]["MOVI_IN_GRD"]);
            if ((dt.Rows[0]["SMGR_ID"] != null) && (dt.Rows[0]["SMGR_ID"] != DBNull.Value)) entity.SmgrId = Convert.ToDecimal(dt.Rows[0]["SMGR_ID"]);
            if ((dt.Rows[0]["PASTA_SSOP_ID"] != null) && (dt.Rows[0]["PASTA_SSOP_ID"] != DBNull.Value)) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[0]["PASTA_SSOP_ID"]);
            if ((dt.Rows[0]["AREA_ID"] != null) && (dt.Rows[0]["AREA_ID"] != DBNull.Value)) entity.AreaId = Convert.ToDecimal(dt.Rows[0]["AREA_ID"]);
            if ((dt.Rows[0]["PASTA_ESCO_ID"] != null) && (dt.Rows[0]["PASTA_ESCO_ID"] != DBNull.Value)) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[0]["PASTA_ESCO_ID"]);
            if ((dt.Rows[0]["PASTA_STPA_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[0]["PASTA_STPA_ID"]);
            if ((dt.Rows[0]["STPA_DESCRICAO"] != null) && (dt.Rows[0]["DISC_SIGLA"] != DBNull.Value)) entity.StpaDescricao = Convert.ToString(dt.Rows[0]["STPA_DESCRICAO"]);

            if ((dt.Rows[0]["PASTA_EXECUTOR"] != null) && (dt.Rows[0]["PASTA_EXECUTOR"] != DBNull.Value)) entity.PastaExecutor = Convert.ToString(dt.Rows[0]["PASTA_EXECUTOR"]);
            if ((dt.Rows[0]["PUNCH_DESCRICAO"] != null) && (dt.Rows[0]["PUNCH_DESCRICAO"] != DBNull.Value)) entity.PunchDescricao = Convert.ToString(dt.Rows[0]["PUNCH_DESCRICAO"]);
            if ((dt.Rows[0]["PUNCH_SITUACAO"] != null) && (dt.Rows[0]["PUNCH_SITUACAO"] != DBNull.Value)) entity.PunchSituacao = Convert.ToString(dt.Rows[0]["PUNCH_SITUACAO"]);
            if ((dt.Rows[0]["PUNCH_STPU_ID"] != null) && (dt.Rows[0]["PUNCH_STPU_ID"] != DBNull.Value)) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[0]["PUNCH_STPU_ID"]);
            if ((dt.Rows[0]["STPU_DESCRICAO"] != null) && (dt.Rows[0]["STPU_DESCRICAO"] != DBNull.Value)) entity.PunchStpuDescricao = Convert.ToString(dt.Rows[0]["STPU_DESCRICAO"]);
            if ((dt.Rows[0]["PASTA_OBSERVACAO"] != null) && (dt.Rows[0]["PASTA_OBSERVACAO"] != DBNull.Value)) entity.PastaObservacao = Convert.ToString(dt.Rows[0]["PASTA_OBSERVACAO"]);
            if ((dt.Rows[0]["PASTA_TESTE_LIBERADO"] != null) && (dt.Rows[0]["PASTA_TESTE_LIBERADO"] != DBNull.Value)) entity.PastaTesteLiberado = Convert.ToString(dt.Rows[0]["PASTA_TESTE_LIBERADO"]);
            return entity;
        }
        //====================================================================
        public static DTO.VwCpPastaUltMovDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PASTA_ESCO_ID Object"); }
        }
        //====================================================================
        public static List<VwCpPastaUltMovDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<VwCpPastaUltMovDTO> list = OracleDataTools.LoadEntity<VwCpPastaUltMovDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaUltMovDTO>"); }
        }
        //====================================================================
        public static List<VwCpPastaUltMovDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaUltMovDTO>"); }
        }
        //====================================================================
        public static List<VwCpPastaUltMovDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<VwCpPastaUltMovDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPastaUltMovDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionVwCpPastaUltMov"); }
        }
        //====================================================================
        public static DTO.CollectionVwCpPastaUltMovDTO GetCollection(DataTable dt)
        {
            DTO.CollectionVwCpPastaUltMovDTO collection = new DTO.CollectionVwCpPastaUltMovDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.VwCpPastaUltMovDTO entity = new DTO.VwCpPastaUltMovDTO();
                    if (dt.Rows[i]["MOVI_ID"].ToString().Length != 0) entity.MoviId = Convert.ToDecimal(dt.Rows[i]["MOVI_ID"]);
                    if (dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString().Length != 0) entity.MoviCntrCodigo = dt.Rows[i]["MOVI_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString().Length != 0) entity.PastaSbcnSigla = dt.Rows[i]["PASTA_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["PASTA_FASE"].ToString().Length != 0) entity.PastaFase = dt.Rows[i]["PASTA_FASE"].ToString();
                    if (dt.Rows[i]["PASTA_BLOCO"].ToString().Length != 0) entity.PastaBloco = dt.Rows[i]["PASTA_BLOCO"].ToString();
                    if (dt.Rows[i]["SSOP_CODIGO"].ToString().Length != 0) entity.SsopCodigo = dt.Rows[i]["SSOP_CODIGO"].ToString();
                    if (dt.Rows[i]["SSOP_DESCRICAO"].ToString().Length != 0) entity.SsopDescricao = dt.Rows[i]["SSOP_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MOVI_PASTA_ID"].ToString().Length != 0) entity.MoviPastaId = Convert.ToDecimal(dt.Rows[i]["MOVI_PASTA_ID"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["MOVI_DATE"].ToString().Length != 0) entity.MoviDate = Convert.ToDateTime(dt.Rows[i]["MOVI_DATE"]);
                    if (dt.Rows[i]["MOVI_DATE_DESC"].ToString().Length != 0) entity.MoviDateDesc = dt.Rows[i]["MOVI_DATE_DESC"].ToString();
                    if (dt.Rows[i]["STMO_LOCA_ID"].ToString().Length != 0) entity.StmoLocaId = Convert.ToDecimal(dt.Rows[i]["STMO_LOCA_ID"]);
                    if (dt.Rows[i]["LOCA_DESCRICAO"].ToString().Length != 0) entity.LocaDescricao = dt.Rows[i]["LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["MOVI_USUA_LOGIN"].ToString().Length != 0) entity.MoviUsuaLogin = dt.Rows[i]["MOVI_USUA_LOGIN"].ToString();
                    if (dt.Rows[i]["USUA_ACTIVE"].ToString().Length != 0) entity.UsuaActive = Convert.ToDecimal(dt.Rows[i]["USUA_ACTIVE"]);
                    if (dt.Rows[i]["USUA_AG_CRIAR_PUNCH"].ToString().Length != 0) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CLASS_PUNCH"].ToString().Length != 0) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CLASS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PUNCH"].ToString().Length != 0) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"].ToString().Length != 0) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PENDMAT"].ToString().Length != 0) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PENDMAT"]);
                    if (dt.Rows[i]["MOVI_CREATED_BY"].ToString().Length != 0) entity.MoviCreatedBy = dt.Rows[i]["MOVI_CREATED_BY"].ToString();
                    if (dt.Rows[i]["MOVI_STMO_ID"].ToString().Length != 0) entity.MoviStmoId = Convert.ToDecimal(dt.Rows[i]["MOVI_STMO_ID"]);
                    if (dt.Rows[i]["SMGR_DESCRICAO"].ToString().Length != 0) entity.SmgrDescricao = dt.Rows[i]["SMGR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["STMO_DESCRICAO"].ToString().Length != 0) entity.StmoDescricao = dt.Rows[i]["STMO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_SIGLA"].ToString().Length != 0) entity.DiscSigla = dt.Rows[i]["DISC_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["AREA_DESCRICAO"].ToString().Length != 0) entity.AreaDescricao = dt.Rows[i]["AREA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["ESCO_DESCRICAO"].ToString().Length != 0) entity.EscoDescricao = dt.Rows[i]["ESCO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["STMO_SEQUENCE"].ToString().Length != 0) entity.StmoSequence = Convert.ToDecimal(dt.Rows[i]["STMO_SEQUENCE"]);
                    if (dt.Rows[i]["MOVI_IN_GRD"].ToString().Length != 0) entity.MoviInGrd = Convert.ToDecimal(dt.Rows[i]["MOVI_IN_GRD"]);
                    if (dt.Rows[i]["SMGR_ID"].ToString().Length != 0) entity.SmgrId = Convert.ToDecimal(dt.Rows[i]["SMGR_ID"]);
                    if (dt.Rows[i]["PASTA_SSOP_ID"].ToString().Length != 0) entity.PastaSsopId = Convert.ToDecimal(dt.Rows[i]["PASTA_SSOP_ID"]);
                    if (dt.Rows[i]["AREA_ID"].ToString().Length != 0) entity.AreaId = Convert.ToDecimal(dt.Rows[i]["AREA_ID"]);
                    if (dt.Rows[i]["PASTA_ESCO_ID"].ToString().Length != 0) entity.PastaEscoId = Convert.ToDecimal(dt.Rows[i]["PASTA_ESCO_ID"]);
                    if (dt.Rows[i]["PASTA_STPA_ID"].ToString().Length != 0) entity.PastaStpaId = Convert.ToDecimal(dt.Rows[i]["PASTA_STPA_ID"]);
                    if (dt.Rows[i]["STPA_DESCRICAO"].ToString().Length != 0) entity.StpaDescricao = dt.Rows[i]["STPA_DESCRICAO"].ToString();

                    if (dt.Rows[i]["PASTA_EXECUTOR"].ToString().Length != 0) entity.PastaExecutor = dt.Rows[i]["PASTA_EXECUTOR"].ToString();
                    if (dt.Rows[i]["PUNCH_DESCRICAO"].ToString().Length != 0) entity.PunchDescricao = dt.Rows[i]["PUNCH_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PUNCH_SITUACAO"].ToString().Length != 0) entity.PunchSituacao = dt.Rows[i]["PUNCH_SITUACAO"].ToString();
                    if (dt.Rows[i]["PUNCH_STPU_ID"].ToString().Length != 0) entity.PunchStpuId = Convert.ToDecimal(dt.Rows[i]["PUNCH_STPU_ID"]);
                    if (dt.Rows[i]["STPU_DESCRICAO"].ToString().Length != 0) entity.PunchStpuDescricao = dt.Rows[i]["STPU_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PASTA_OBSERVACAO"].ToString().Length != 0) entity.PastaObservacao = dt.Rows[i]["PASTA_OBSERVACAO"].ToString();
                    if (dt.Rows[i]["PASTA_TESTE_LIBERADO"].ToString().Length != 0) entity.PastaTesteLiberado = dt.Rows[i]["PASTA_TESTE_LIBERADO"].ToString();

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
