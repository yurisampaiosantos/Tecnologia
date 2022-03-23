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
    public class AcControleProducaoLogDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //static string strSelect = @"SELECT X.ID, X.FOSE_CNTR_CODIGO, X.SEMA_ID, X.DISC_ID, X.DISC_NOME, X.FOSE_ID, X.FOSE_NUMERO, X.MESSAGE, X.FCME_SIGLA, X.FCES_SIGLA, X.GRCR_NOME, X.GRCR_GRUPO_SIGLA, X.GRCR_FCME_ID, X.GRFC_GRCR_ID, X.SBCN_ID, X.SBCN_SIGLA, X.ORIGEM_FABRICACAO, X.EQUIPE, X.SETOR, X.LOCALIZACAO, X.DESCRICAO_ESTRUTURA, X.AVN_REAL_EXEC_PERIODO, TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE FROM AC_CONTROLE_PRODUCAO_LOG X ";
        static string strSelect = @"SELECT X.ID, X.FOSE_CNTR_CODIGO, X.SEMA_ID, X.DISC_ID, X.DISC_NOME, X.FOSE_ID, X.FOSE_NUMERO, X.MESSAGE, X.FCME_SIGLA, X.FCES_SIGLA, X.GRCR_NOME, X.SBCN_ID, X.SBCN_SIGLA, X.ORIGEM_FABRICACAO, X.EQUIPE, X.SETOR, X.LOCALIZACAO, X.DESCRICAO_ESTRUTURA, X.AVN_REAL_EXEC_PERIODO, TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG X ";
        //====================================================================
        public static int Insert(DTO.AcControleProducaoLogDTO entity, bool getIdentity)
        {
            //string strSQL = "INSERT INTO AC_CONTROLE_PRODUCAO_LOG(FOSE_CNTR_CODIGO,SEMA_ID,DISC_ID,DISC_NOME,FOSE_ID,FOSE_NUMERO,MESSAGE,FCME_SIGLA,FCES_SIGLA,GRCR_NOME,GRCR_GRUPO_SIGLA,GRCR_FCME_ID,GRFC_GRCR_ID,SBCN_ID,SBCN_SIGLA,ORIGEM_FABRICACAO,EQUIPE,SETOR,LOCALIZACAO,DESCRICAO_ESTRUTURA,AVN_REAL_EXEC_PERIODO) VALUES(:FOSE_CNTR_CODIGO,:SEMA_ID,:DISC_ID,:DISC_NOME,:FOSE_ID,:FOSE_NUMERO,:MESSAGE,:FCME_SIGLA,:FCES_SIGLA,:GRCR_NOME,:GRCR_GRUPO_SIGLA,:GRCR_FCME_ID,:GRFC_GRCR_ID,:SBCN_ID,:SBCN_SIGLA,:ORIGEM_FABRICACAO,:EQUIPE,:SETOR,:LOCALIZACAO,:DESCRICAO_ESTRUTURA,:AVN_REAL_EXEC_PERIODO)";
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG(FOSE_CNTR_CODIGO,SEMA_ID,DISC_ID,DISC_NOME,FOSE_ID,FOSE_NUMERO,MESSAGE,FCME_SIGLA,FCES_SIGLA,GRCR_NOME,SBCN_ID,SBCN_SIGLA,ORIGEM_FABRICACAO,EQUIPE,SETOR,LOCALIZACAO,DESCRICAO_ESTRUTURA,AVN_REAL_EXEC_PERIODO) VALUES(:FOSE_CNTR_CODIGO,:SEMA_ID,:DISC_ID,:DISC_NOME,:FOSE_ID,:FOSE_NUMERO,:MESSAGE,:FCME_SIGLA,:FCES_SIGLA,:GRCR_NOME,:SBCN_ID,:SBCN_SIGLA,:ORIGEM_FABRICACAO,:EQUIPE,:SETOR,:LOCALIZACAO,:DESCRICAO_ESTRUTURA,:AVN_REAL_EXEC_PERIODO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":MESSAGE", OracleDbType.Varchar2).Value = entity.Message;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                //cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                //cmd.Parameters.Add(":GRCR_FCME_ID", OracleDbType.Decimal).Value = entity.GrcrFcmeId;
                //cmd.Parameters.Add(":GRFC_GRCR_ID", OracleDbType.Decimal).Value = entity.GrfcGrcrId;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add(":EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = entity.AvnRealExecPeriodo;
            
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcControleProducaoLog");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcControleProducaoLog");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcControleProducaoLogDTO entity)
        {
            //string strSQL = "UPDATE AC_CONTROLE_PRODUCAO_LOG set FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SEMA_ID = :SEMA_ID, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, MESSAGE = :MESSAGE, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, GRCR_NOME = :GRCR_NOME, GRCR_GRUPO_SIGLA = :GRCR_GRUPO_SIGLA, GRCR_FCME_ID = :GRCR_FCME_ID, GRFC_GRCR_ID = :GRFC_GRCR_ID, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, ORIGEM_FABRICACAO = :ORIGEM_FABRICACAO, EQUIPE = :EQUIPE, SETOR = :SETOR, LOCALIZACAO = :LOCALIZACAO, DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, AVN_REAL_EXEC_PERIODO = :AVN_REAL_EXEC_PERIODO, CREATED_DATE = :CREATED_DATE WHERE  ID = : ID";
            string strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG set FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SEMA_ID = :SEMA_ID, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, FOSE_ID = :FOSE_ID, FOSE_NUMERO = :FOSE_NUMERO, MESSAGE = :MESSAGE, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, GRCR_NOME = :GRCR_NOME, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, ORIGEM_FABRICACAO = :ORIGEM_FABRICACAO, EQUIPE = :EQUIPE, SETOR = :SETOR, LOCALIZACAO = :LOCALIZACAO, DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, AVN_REAL_EXEC_PERIODO = :AVN_REAL_EXEC_PERIODO, CREATED_DATE = :CREATED_DATE WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add("SEMA_ID", OracleDbType.Decimal).Value = entity.SemaId;
                cmd.Parameters.Add("DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add("DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add("FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add("FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add("MESSAGE", OracleDbType.Varchar2).Value = entity.Message;
                cmd.Parameters.Add("FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add("FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add("GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                //cmd.Parameters.Add("GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                //cmd.Parameters.Add("GRCR_FCME_ID", OracleDbType.Decimal).Value = entity.GrcrFcmeId;
                //cmd.Parameters.Add("GRFC_GRCR_ID", OracleDbType.Decimal).Value = entity.GrfcGrcrId;
                cmd.Parameters.Add("SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add("SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add("ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add("EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add("SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add("LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add("DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add("AVN_REAL_EXEC_PERIODO", OracleDbType.Decimal).Value = entity.AvnRealExecPeriodo;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcControleProducaoLog"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void DeleteBySemaId(decimal semaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG WHERE  SEMA_ID = :SEMA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":SEMA_ID", OracleDbType.Decimal).Value = semaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - DeletingBySemaId AcControleProducaoLog"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcControleProducaoLog"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleProducaoLog"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleProducaoLog"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleProducaoLog"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleProducaoLog"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcControleProducaoLog"); }
        }
        //====================================================================
        public static DTO.AcControleProducaoLogDTO Get(decimal ID)
        {
            AcControleProducaoLogDTO entity = new AcControleProducaoLogDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SEMA_ID"] != null) && (dt.Rows[0]["SEMA_ID"] != DBNull.Value)) entity.SemaId = Convert.ToDecimal(dt.Rows[0]["SEMA_ID"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["MESSAGE"] != null) && (dt.Rows[0]["MESSAGE"] != DBNull.Value)) entity.Message = Convert.ToString(dt.Rows[0]["MESSAGE"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            //if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            //if ((dt.Rows[0]["GRCR_FCME_ID"] != null) && (dt.Rows[0]["GRCR_FCME_ID"] != DBNull.Value)) entity.GrcrFcmeId = Convert.ToDecimal(dt.Rows[0]["GRCR_FCME_ID"]);
            //if ((dt.Rows[0]["GRFC_GRCR_ID"] != null) && (dt.Rows[0]["GRFC_GRCR_ID"] != DBNull.Value)) entity.GrfcGrcrId = Convert.ToDecimal(dt.Rows[0]["GRFC_GRCR_ID"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["ORIGEM_FABRICACAO"] != null) && (dt.Rows[0]["ORIGEM_FABRICACAO"] != DBNull.Value)) entity.OrigemFabricacao = Convert.ToString(dt.Rows[0]["ORIGEM_FABRICACAO"]);
            if ((dt.Rows[0]["EQUIPE"] != null) && (dt.Rows[0]["EQUIPE"] != DBNull.Value)) entity.Equipe = Convert.ToString(dt.Rows[0]["EQUIPE"]);
            if ((dt.Rows[0]["SETOR"] != null) && (dt.Rows[0]["SETOR"] != DBNull.Value)) entity.Setor = Convert.ToString(dt.Rows[0]["SETOR"]);
            if ((dt.Rows[0]["LOCALIZACAO"] != null) && (dt.Rows[0]["LOCALIZACAO"] != DBNull.Value)) entity.Localizacao = Convert.ToString(dt.Rows[0]["LOCALIZACAO"]);
            if ((dt.Rows[0]["DESCRICAO_ESTRUTURA"] != null) && (dt.Rows[0]["DESCRICAO_ESTRUTURA"] != DBNull.Value)) entity.DescricaoEstrutura = Convert.ToString(dt.Rows[0]["DESCRICAO_ESTRUTURA"]);
            if ((dt.Rows[0]["AVN_REAL_EXEC_PERIODO"] != null) && (dt.Rows[0]["AVN_REAL_EXEC_PERIODO"] != DBNull.Value)) entity.AvnRealExecPeriodo = Convert.ToDecimal(dt.Rows[0]["AVN_REAL_EXEC_PERIODO"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcControleProducaoLogDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcControleProducaoLogDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcControleProducaoLogDTO> list = OracleDataTools.LoadEntity<AcControleProducaoLogDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoLogDTO>"); }
        }
        //====================================================================
        public static List<AcControleProducaoLogDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoLogDTO>"); }
        }
        //====================================================================
        public static List<AcControleProducaoLogDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleProducaoLogDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleProducaoLogDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcControleProducaoLog"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleProducaoLogDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcControleProducaoLogDTO collection = new DTO.CollectionAcControleProducaoLogDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcControleProducaoLogDTO entity = new DTO.AcControleProducaoLogDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SEMA_ID"].ToString().Length != 0) entity.SemaId = Convert.ToDecimal(dt.Rows[i]["SEMA_ID"]);
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["MESSAGE"].ToString().Length != 0) entity.Message = dt.Rows[i]["MESSAGE"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = dt.Rows[i]["GRCR_NOME"].ToString();
                    //if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString();
                    //if (dt.Rows[i]["GRCR_FCME_ID"].ToString().Length != 0) entity.GrcrFcmeId = Convert.ToDecimal(dt.Rows[i]["GRCR_FCME_ID"]);
                    //if (dt.Rows[i]["GRFC_GRCR_ID"].ToString().Length != 0) entity.GrfcGrcrId = Convert.ToDecimal(dt.Rows[i]["GRFC_GRCR_ID"]);
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["ORIGEM_FABRICACAO"].ToString().Length != 0) entity.OrigemFabricacao = dt.Rows[i]["ORIGEM_FABRICACAO"].ToString();
                    if (dt.Rows[i]["EQUIPE"].ToString().Length != 0) entity.Equipe = dt.Rows[i]["EQUIPE"].ToString();
                    if (dt.Rows[i]["SETOR"].ToString().Length != 0) entity.Setor = dt.Rows[i]["SETOR"].ToString();
                    if (dt.Rows[i]["LOCALIZACAO"].ToString().Length != 0) entity.Localizacao = dt.Rows[i]["LOCALIZACAO"].ToString();
                    if (dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString().Length != 0) entity.DescricaoEstrutura = dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString();
                    if (dt.Rows[i]["AVN_REAL_EXEC_PERIODO"].ToString().Length != 0) entity.AvnRealExecPeriodo = Convert.ToDecimal(dt.Rows[i]["AVN_REAL_EXEC_PERIODO"]);
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);

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
            dict.Add("FoseCntrCodigo", "FOSE_CNTR_CODIGO");
            dict.Add("SemaId", "SEMA_ID");
            dict.Add("DiscId", "DISC_ID");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("Message", "MESSAGE");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("GrcrNome", "GRCR_NOME");
            dict.Add("GrcrGrupoSigla", "GRCR_GRUPO_SIGLA");
            dict.Add("GrcrFcmeId", "GRCR_FCME_ID");
            dict.Add("GrfcGrcrId", "GRFC_GRCR_ID");
            dict.Add("SbcnId", "SBCN_ID");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("OrigemFabricacao", "ORIGEM_FABRICACAO");
            dict.Add("Equipe", "EQUIPE");
            dict.Add("Setor", "SETOR");
            dict.Add("Localizacao", "LOCALIZACAO");
            dict.Add("DescricaoEstrutura", "DESCRICAO_ESTRUTURA");
            dict.Add("AvnRealExecPeriodo", "AVN_REAL_EXEC_PERIODO");
            dict.Add("CreatedDate", "CREATED_DATE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
