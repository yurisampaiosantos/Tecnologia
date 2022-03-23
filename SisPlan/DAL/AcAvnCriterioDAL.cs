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
    public class AcAvnCriterioDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.GRCR_CNTR_CODIGO, X.GRCR_ID, X.SEMA_ID, X.GRCR_GRUPO_SIGLA, X.GRCR_NOME, X.GRCR_GRUPO_DESCRICAO, X.GRCR_SEQUENCE, X.FCME_ID, X.FCME_SIGLA, X.FCES_ID, X.FCES_SIGLA, X.FCES_PESO_REL_CRON, X.FOSE_ID, X.FOSE_NUMERO, X.FOSM_ID, X.AVANCO_TIPO, X.AVANCO_PERIODO, X.FOSE_QTD_PREVISTA, CONVERT(VARCHAR(10), X.AVANCO_DATA,103) AS AVANCO_DATA, X.QTD_AVANCO FROM EEP_CONVERSION.AC_AVN_CRITERIO X ";
        //====================================================================
        public static int Insert(DTO.AcAvnCriterioDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_AVN_CRITERIO(GRCR_CNTR_CODIGO, GRCR_ID, SEMA_ID, GRCR_GRUPO_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_SEQUENCE, FCME_ID, FCME_SIGLA, FCES_ID, FCES_SIGLA, FCES_PESO_REL_CRON, FOSE_ID, FOSE_NUMERO, FOSM_ID, AVANCO_TIPO, AVANCO_PERIODO, FOSE_QTD_PREVISTA, AVANCO_DATA, QTD_AVANCO) VALUES(:GRCR_CNTR_CODIGO, :GRCR_ID, :SEMA_ID, :GRCR_GRUPO_SIGLA, :GRCR_NOME, :GRCR_GRUPO_DESCRICAO, :GRCR_SEQUENCE, :FCME_ID, :FCME_SIGLA, :FCES_ID, :FCES_SIGLA, :FCES_PESO_REL_CRON, :FOSE_ID, :FOSE_NUMERO, :FOSM_ID, :AVANCO_TIPO, :AVANCO_PERIODO, :FOSE_QTD_PREVISTA, :AVANCO_DATA, :QTD_AVANCO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":GRCR_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.GrcrCntrCodigo;
                cmd.Parameters.Add(":GRCR_ID", OracleDbType.Int32).Value = entity.GrcrId;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                cmd.Parameters.Add(":GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.GrcrGrupoDescricao;
                cmd.Parameters.Add(":GRCR_SEQUENCE", OracleDbType.Int32).Value = entity.GrcrSequence;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Int32).Value = entity.FcmeId;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_ID", OracleDbType.Int32).Value = entity.FcesId;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Int32).Value = entity.FcesPesoRelCron;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Int32).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Int32).Value = entity.FosmId;
                cmd.Parameters.Add(":AVANCO_TIPO", OracleDbType.Varchar2).Value = entity.AvancoTipo;
                cmd.Parameters.Add(":AVANCO_PERIODO", OracleDbType.Varchar2).Value = entity.AvancoPeriodo;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Int32).Value = entity.FoseQtdPrevista;
                if (entity.AvancoData.ToOADate() == 0.0) cmd.Parameters.Add(":AVANCO_DATA", OracleDbType.Date).Value = entity.AvancoData;
                else cmd.Parameters.Add(":AVANCO_DATA", OracleDbType.Date).Value = entity.AvancoData;
                cmd.Parameters.Add(":QTD_AVANCO", OracleDbType.Decimal).Value = entity.QtdAvanco;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcAvnCriterio");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcAvnCriterio");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcAvnCriterioDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_AVN_CRITERIO set GRCR_CNTR_CODIGO = :GRCR_CNTR_CODIGO, GRCR_ID = :GRCR_ID, SEMA_ID = :SEMA_ID, GRCR_GRUPO_SIGLA = :GRCR_GRUPO_SIGLA, GRCR_NOME = :GRCR_NOME, GRCR_GRUPO_DESCRICAO = :GRCR_GRUPO_DESCRICAO, GRCR_SEQUENCE = :GRCR_SEQUENCE, FCME_ID = :FCME_ID, FCME_SIGLA = :FCME_SIGLA, FCES_ID = :FCES_ID, FCES_SIGLA = :FCES_SIGLA, FCES_PESO_REL_CRON = :FCES_PESO_REL_CRON, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, FOSM_ID = :FOSM_ID, AVANCO_TIPO = :AVANCO_TIPO, AVANCO_PERIODO = :AVANCO_PERIODO, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, AVANCO_DATA = :AVANCO_DATA, QTD_AVANCO = :QTD_AVANCO WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":GRCR_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.GrcrCntrCodigo;
                cmd.Parameters.Add(":GRCR_ID", OracleDbType.Int32).Value = entity.GrcrId;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                cmd.Parameters.Add(":GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.GrcrGrupoDescricao;
                cmd.Parameters.Add(":GRCR_SEQUENCE", OracleDbType.Int32).Value = entity.GrcrSequence;
                cmd.Parameters.Add(":FCME_ID", OracleDbType.Int32).Value = entity.FcmeId;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_ID", OracleDbType.Int32).Value = entity.FcesId;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":FCES_PESO_REL_CRON", OracleDbType.Int32).Value = entity.FcesPesoRelCron;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Int32).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSM_ID", OracleDbType.Int32).Value = entity.FosmId;
                cmd.Parameters.Add(":AVANCO_TIPO", OracleDbType.Varchar2).Value = entity.AvancoTipo;
                cmd.Parameters.Add(":AVANCO_PERIODO", OracleDbType.Varchar2).Value = entity.AvancoPeriodo;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Int32).Value = entity.FoseQtdPrevista;
                if (entity.AvancoData.ToOADate() == 0.0) cmd.Parameters.Add("AVANCO_DATA", OracleDbType.Date).Value = entity.AvancoData;
                else cmd.Parameters.Add(":AVANCO_DATA", OracleDbType.Date).Value = entity.AvancoData;
                cmd.Parameters.Add(":QTD_AVANCO", OracleDbType.Int32).Value = entity.QtdAvanco;
                cmd.Parameters.Add(":QTD_AVANCO", OracleDbType.Decimal).Value = entity.QtdAvanco;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcAvnCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_AVN_CRITERIO WHERE  ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcAvnCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void DeleteBySemanaGrupoSigla(decimal semaId, string grupoSigla)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_AVN_CRITERIO WHERE SEMA_ID = :SEMA_ID AND GRCR_GRUPO_SIGLA = :GRCR_GRUPO_SIGLA";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = semaId;
                cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = grupoSigla;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcAvnCriterio by Semana"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvnCriterio"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM AC_AVN_CRITERIO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvnCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvnCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvnCriterio"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static DataTable SelectAgrupamentos()
        {
            string strSQL = @"SELECT SEMA_ID, GRCR_SEQUENCE, GRCR_GRUPO_SIGLA, GRCR_GRUPO_DESCRICAO, GRCR_NOME, AVANCO_TIPO, AVANCO_PERIODO, SUM(QTD_AVANCO) AS QTD_AVANCO
                                FROM EEP_CONVERSION.AC_AVN_CRITERIO 
                            GROUP BY SEMA_ID, GRCR_SEQUENCE,GRCR_GRUPO_SIGLA, GRCR_GRUPO_DESCRICAO, GRCR_NOME, AVANCO_TIPO, AVANCO_PERIODO
                            ORDER BY SEMA_ID, GRCR_SEQUENCE, GRCR_GRUPO_SIGLA, GRCR_GRUPO_DESCRICAO, GRCR_NOME, AVANCO_TIPO DESC, AVANCO_PERIODO DESC";
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcAvnCriterio"); }
        }
        //====================================================================
        public static DTO.AcAvnCriterioDTO Get(decimal ID)
        {
            AcAvnCriterioDTO entity = new AcAvnCriterioDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["GRCR_CNTR_CODIGO"] != null) && (dt.Rows[0]["GRCR_CNTR_CODIGO"] != DBNull.Value)) entity.GrcrCntrCodigo = Convert.ToString(dt.Rows[0]["GRCR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["GRCR_ID"] != null) && (dt.Rows[0]["GRCR_ID"] != DBNull.Value)) entity.GrcrId = Convert.ToDecimal(dt.Rows[0]["GRCR_ID"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            if ((dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_DESCRICAO"]);
            if ((dt.Rows[0]["GRCR_SEQUENCE"] != null) && (dt.Rows[0]["GRCR_SEQUENCE"] != DBNull.Value)) entity.GrcrSequence = Convert.ToDecimal(dt.Rows[0]["GRCR_SEQUENCE"]);
            if ((dt.Rows[0]["FCME_ID"] != null) && (dt.Rows[0]["FCME_ID"] != DBNull.Value)) entity.FcmeId = Convert.ToDecimal(dt.Rows[0]["FCME_ID"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_ID"] != null) && (dt.Rows[0]["FCES_ID"] != DBNull.Value)) entity.FcesId = Convert.ToDecimal(dt.Rows[0]["FCES_ID"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["FCES_PESO_REL_CRON"] != null) && (dt.Rows[0]["FCES_PESO_REL_CRON"] != DBNull.Value)) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[0]["FCES_PESO_REL_CRON"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToInt32(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSM_ID"] != null) && (dt.Rows[0]["FOSM_ID"] != DBNull.Value)) entity.FosmId = Convert.ToInt32(dt.Rows[0]["FOSM_ID"]);
            if ((dt.Rows[0]["AVANCO_TIPO"] != null) && (dt.Rows[0]["AVANCO_TIPO"] != DBNull.Value)) entity.AvancoTipo = Convert.ToString(dt.Rows[0]["AVANCO_TIPO"]);
            if ((dt.Rows[0]["AVANCO_PERIODO"] != null) && (dt.Rows[0]["AVANCO_PERIODO"] != DBNull.Value)) entity.AvancoPeriodo = Convert.ToString(dt.Rows[0]["AVANCO_PERIODO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["AVANCO_DATA"] != null) && (dt.Rows[0]["AVANCO_DATA"] != DBNull.Value)) entity.AvancoData = Convert.ToDateTime(dt.Rows[0]["AVANCO_DATA"]);
            if ((dt.Rows[0]["QTD_AVANCO"] != null) && (dt.Rows[0]["QTD_AVANCO"] != DBNull.Value)) entity.QtdAvanco = Convert.ToDecimal(dt.Rows[0]["QTD_AVANCO"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcAvnCriterioDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting QTD_AVANCO Object"); }
        }
        //====================================================================
        public static List<AcAvnCriterioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcAvnCriterioDTO> list = OracleDataTools.LoadEntity<AcAvnCriterioDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcAvnCriterioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcAvnCriterioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnCriterioDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnCriterioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 1";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcAvnCriterio"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnCriterioDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcAvnCriterioDTO collection = new DTO.CollectionAcAvnCriterioDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcAvnCriterioDTO entity = new DTO.AcAvnCriterioDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString().Length != 0) entity.GrcrCntrCodigo = dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["GRCR_ID"].ToString().Length != 0) entity.GrcrId = Convert.ToDecimal(dt.Rows[i]["GRCR_ID"]);
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                    if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString();
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = dt.Rows[i]["GRCR_NOME"].ToString();
                    if (dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.GrcrGrupoDescricao = dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["GRCR_SEQUENCE"].ToString().Length != 0) entity.GrcrSequence = Convert.ToDecimal(dt.Rows[i]["GRCR_SEQUENCE"]);
                    if (dt.Rows[i]["FCME_ID"].ToString().Length != 0) entity.FcmeId = Convert.ToDecimal(dt.Rows[i]["FCME_ID"]);
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_ID"].ToString().Length != 0) entity.FcesId = Convert.ToDecimal(dt.Rows[i]["FCES_ID"]);
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_PESO_REL_CRON"].ToString().Length != 0) entity.FcesPesoRelCron = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]);
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToInt32(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSM_ID"].ToString().Length != 0) entity.FosmId = Convert.ToInt32(dt.Rows[i]["FOSM_ID"]);
                    if (dt.Rows[i]["AVANCO_TIPO"].ToString().Length != 0) entity.AvancoTipo = dt.Rows[i]["AVANCO_TIPO"].ToString();
                    if (dt.Rows[i]["AVANCO_PERIODO"].ToString().Length != 0) entity.AvancoPeriodo = dt.Rows[i]["AVANCO_PERIODO"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["AVANCO_DATA"].ToString().Length != 0) entity.AvancoData = Convert.ToDateTime(dt.Rows[i]["AVANCO_DATA"]);
                    if (dt.Rows[i]["QTD_AVANCO"].ToString().Length != 0) entity.QtdAvanco = Convert.ToDecimal(dt.Rows[i]["QTD_AVANCO"]);

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
            dict.Add("ID", "ID");
            dict.Add("GrcrCntrCodigo", "GRCR_CNTR_CODIGO");
            dict.Add("GrcrId", "GRCR_ID");
            dict.Add("SemaId", "SEMA_ID");
            dict.Add("GrcrGrupoSigla", "GRCR_GRUPO_SIGLA");
            dict.Add("GrcrNome", "GRCR_NOME");
            dict.Add("GrcrGrupoDescricao", "GRCR_GRUPO_DESCRICAO");
            dict.Add("GrcrSequence", "GRCR_SEQUENCE");
            dict.Add("FcmeId", "FCME_ID");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesId", "FCES_ID");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("FcesPesoRelCron", "FCES_PESO_REL_CRON");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FosmId", "FOSM_ID");
            dict.Add("AvancoTipo", "AVANCO_TIPO");
            dict.Add("AvancoPeriodo", "AVANCO_PERIODO");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("AvancoData", "AVANCO_DATA");
            dict.Add("QtdAvanco", "QTD_AVANCO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
