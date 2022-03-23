using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using DTO;
using System.Data.OleDb;

//====================================================================
//====================================================================

namespace DAL
{
    public class ElControleGeralEitDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.CONTRATO, X.SBCN_SIGLA, X.CLASSE_DISCIPLINA, X.CRITERIO, X.EAP, X.ATIVIDADE_CRITERIO, X.TIPO_MATERIAL, X.STATUS_ENGENHARIA, X.DESENHO, X.DESENHO_REV, X.REGIAO, X.LOCAL, X.TAG, X.DESCRICAO, X.QUANTIDADE_PROJETO, X.UNME_SIGLA, X.AVANCO_FISICO, X.SEMANA_, X.DIPR_CODIGO, X.RESERVA, TO_CHAR(X.BL_PROJECT_START,'DD/MM/YYYY') AS BL_PROJECT_START, TO_CHAR(X.BL_PROJECT_FINISH,'DD/MM/YYYY') AS BL_PROJECT_FINISH, X.PASTA_CODIGO, X.SSOP, X.FASE, X.BLOCO, X.DES_REFERENCIA, X.RM, X.RM_REV, X.AFS, TO_CHAR(X.DATA_NECESSARIA,'DD/MM/YYYY') AS DATA_NECESSARIA, X.STATUS_CHEGADA, X.INDICE, X.FOTA_ID, X.PRODUTIVIDADE FROM EL_CONTROLE_GERAL_EIT X ";
        //====================================================================
        public static DataTable ReadSpreadSheet(string connStr)
        {
            DataTable dt = null;
            OleDbConnection conn = new OleDbConnection(connStr);
            List<string> planilhas = GetSheetNames(conn);
            dt = null;

            string strSQL = "SELECT * FROM [Plan1$]";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }
        //====================================================================
        public static List<String> GetSheetNames(OleDbConnection conn)
        {
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<String> Lista = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                Lista.Add(row["TABLE_NAME"].ToString());
            }
            conn.Close();
            return Lista;
        }
        //====================================================================
        public static int Insert(DTO.ElControleGeralEitDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EL_CONTROLE_GERAL_EIT(CONTRATO,SBCN_SIGLA,CLASSE_DISCIPLINA,CRITERIO,EAP,ATIVIDADE_CRITERIO,TIPO_MATERIAL,STATUS_ENGENHARIA,DESENHO,DESENHO_REV,REGIAO,LOCAL,TAG,DESCRICAO,QUANTIDADE_PROJETO,UNME_SIGLA,AVANCO_FISICO,SEMANA,DIPR_CODIGO,RESERVA,BL_PROJECT_START,BL_PROJECT_FINISH,PASTA_CODIGO,SSOP,FASE,BLOCO,DES_REFERENCIA,RM,RM_REV,AFS,DATA_NECESSARIA,STATUS_CHEGADA,INDICE,FOTA_ID,PRODUTIVIDADE) VALUES(:CONTRATO,:SBCN_SIGLA,:CLASSE_DISCIPLINA,:CRITERIO,:EAP,:ATIVIDADE_CRITERIO,:TIPO_MATERIAL,:STATUS_ENGENHARIA,:DESENHO,:DESENHO_REV,:REGIAO,:LOCAL,:TAG,:DESCRICAO,:QUANTIDADE_PROJETO,:UNME_SIGLA,:AVANCO_FISICO,:SEMANA,:DIPR_CODIGO,:RESERVA,:BL_PROJECT_START,:BL_PROJECT_FINISH,:PASTA_CODIGO,:SSOP,:FASE,:BLOCO,:DES_REFERENCIA,:RM,:RM_REV,:AFS,:DATA_NECESSARIA,:STATUS_CHEGADA,:INDICE,:FOTA_ID,:PRODUTIVIDADE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":CONTRATO", OracleDbType.Varchar2).Value = entity.Contrato;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":CLASSE_DISCIPLINA", OracleDbType.Varchar2).Value = entity.ClasseDisciplina;
                cmd.Parameters.Add(":CRITERIO", OracleDbType.Varchar2).Value = entity.Criterio;
                cmd.Parameters.Add(":EAP", OracleDbType.Varchar2).Value = entity.Eap;
                cmd.Parameters.Add(":ATIVIDADE_CRITERIO", OracleDbType.Varchar2).Value = entity.AtividadeCriterio;
                cmd.Parameters.Add(":TIPO_MATERIAL", OracleDbType.Varchar2).Value = entity.TipoMaterial;
                cmd.Parameters.Add(":STATUS_ENGENHARIA", OracleDbType.Varchar2).Value = entity.StatusEngenharia;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":DESENHO_REV", OracleDbType.Varchar2).Value = entity.DesenhoRev;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;
                cmd.Parameters.Add(":LOCAL", OracleDbType.Varchar2).Value = entity.Local;
                cmd.Parameters.Add(":TAG", OracleDbType.Varchar2).Value = entity.Tag;
                cmd.Parameters.Add(":DESCRICAO", OracleDbType.Varchar2).Value = entity.Descricao;
                cmd.Parameters.Add(":QUANTIDADE_PROJETO", OracleDbType.Decimal).Value = entity.QuantidadeProjeto;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":AVANCO_FISICO", OracleDbType.Decimal).Value = entity.AvancoFisico;
                cmd.Parameters.Add(":SEMANA", OracleDbType.Varchar2).Value = entity.Semana;
                cmd.Parameters.Add(":DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCodigo;
                cmd.Parameters.Add(":RESERVA", OracleDbType.Varchar2).Value = entity.Reserva;
                if (entity.BlProjectStart == null) cmd.Parameters.Add(":BL_PROJECT_START", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":BL_PROJECT_START", OracleDbType.Date).Value = entity.BlProjectStart;
                if (entity.BlProjectFinish == null) cmd.Parameters.Add(":BL_PROJECT_FINISH", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":BL_PROJECT_FINISH", OracleDbType.Date).Value = entity.BlProjectFinish;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":SSOP", OracleDbType.Varchar2).Value = entity.Ssop;
                cmd.Parameters.Add(":FASE", OracleDbType.Varchar2).Value = entity.Fase;
                cmd.Parameters.Add(":BLOCO", OracleDbType.Varchar2).Value = entity.Bloco;
                cmd.Parameters.Add(":DES_REFERENCIA", OracleDbType.Varchar2).Value = entity.DesReferencia;
                cmd.Parameters.Add(":RM", OracleDbType.Varchar2).Value = entity.RM;
                cmd.Parameters.Add(":RM_REV", OracleDbType.Varchar2).Value = entity.RmRev;
                cmd.Parameters.Add(":AFS", OracleDbType.Varchar2).Value = entity.Afs;
                if (entity.DataNecessaria == null) cmd.Parameters.Add(":DATA_NECESSARIA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":DATA_NECESSARIA", OracleDbType.Date).Value = entity.DataNecessaria;
                cmd.Parameters.Add(":STATUS_CHEGADA", OracleDbType.Varchar2).Value = entity.StatusChegada;
                cmd.Parameters.Add(":INDICE", OracleDbType.Decimal).Value = entity.Indice;
                cmd.Parameters.Add(":FOTA_ID", OracleDbType.Decimal).Value = entity.FotaId;
                cmd.Parameters.Add(":PRODUTIVIDADE", OracleDbType.Decimal).Value = entity.Produtividade;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ElControleGeralEit");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ElControleGeralEit");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ElControleGeralEitDTO entity)
        {
            string strSQL = "UPDATE EL_CONTROLE_GERAL_EIT set CONTRATO = :CONTRATO, SBCN_SIGLA = :SBCN_SIGLA, CLASSE_DISCIPLINA = :CLASSE_DISCIPLINA, CRITERIO = :CRITERIO, EAP = :EAP, ATIVIDADE_CRITERIO = :ATIVIDADE_CRITERIO, TIPO_MATERIAL = :TIPO_MATERIAL, STATUS_ENGENHARIA = :STATUS_ENGENHARIA, DESENHO = :DESENHO, DESENHO_REV = :DESENHO_REV, REGIAO = :REGIAO, LOCAL = :LOCAL, TAG = :TAG, DESCRICAO = :DESCRICAO, QUANTIDADE_PROJETO = :QUANTIDADE_PROJETO, UNME_SIGLA = :UNME_SIGLA, AVANCO_FISICO = :AVANCO_FISICO, SEMANA = :SEMANA, DIPR_CODIGO = :DIPR_CODIGO, RESERVA = :RESERVA, BL_PROJECT_START = :BL_PROJECT_START, BL_PROJECT_FINISH = :BL_PROJECT_FINISH, PASTA_CODIGO = :PASTA_CODIGO, SSOP = :SSOP, FASE = :FASE, BLOCO = :BLOCO, DES_REFERENCIA = :DES_REFERENCIA, RM = :RM, RM_REV = :RM_REV, AFS = :AFS, DATA_NECESSARIA = :DATA_NECESSARIA, STATUS_CHEGADA = :STATUS_CHEGADA, INDICE = :INDICE, FOTA_ID = :FOTA_ID, PRODUTIVIDADE = :PRODUTIVIDADE WHERE  ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":CONTRATO", OracleDbType.Varchar2).Value = entity.Contrato;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":LASSE_DISCIPLINA", OracleDbType.Varchar2).Value = entity.ClasseDisciplina;
                cmd.Parameters.Add(":CRITERIO", OracleDbType.Varchar2).Value = entity.Criterio;
                cmd.Parameters.Add(":EAP", OracleDbType.Varchar2).Value = entity.Eap;
                cmd.Parameters.Add(":ATIVIDADE_CRITERIO", OracleDbType.Varchar2).Value = entity.AtividadeCriterio;
                cmd.Parameters.Add(":TIPO_MATERIAL", OracleDbType.Varchar2).Value = entity.TipoMaterial;
                cmd.Parameters.Add(":STATUS_ENGENHARIA", OracleDbType.Varchar2).Value = entity.StatusEngenharia;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":DESENHO_REV", OracleDbType.Varchar2).Value = entity.DesenhoRev;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;
                cmd.Parameters.Add(":LOCAL", OracleDbType.Varchar2).Value = entity.Local;
                cmd.Parameters.Add(":TAG", OracleDbType.Varchar2).Value = entity.Tag;
                cmd.Parameters.Add(":DESCRICAO", OracleDbType.Varchar2).Value = entity.Descricao;
                if (entity.QuantidadeProjeto == null) cmd.Parameters.Add(":QUANTIDADE_PROJETO", OracleDbType.Decimal).Value = null;
                else cmd.Parameters.Add(":QUANTIDADE_PROJETO", OracleDbType.Decimal).Value = entity.QuantidadeProjeto;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                if (entity.AvancoFisico == null) cmd.Parameters.Add(":AVANCO_FISICO", OracleDbType.Decimal).Value = null;
                else cmd.Parameters.Add(":AVANCO_FISICO", OracleDbType.Decimal).Value = entity.AvancoFisico;
                cmd.Parameters.Add(":SEMANA", OracleDbType.Varchar2).Value = entity.Semana;
                cmd.Parameters.Add(":DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCodigo;
                cmd.Parameters.Add(":RESERVA", OracleDbType.Varchar2).Value = entity.Reserva;
                if (entity.BlProjectStart == null) cmd.Parameters.Add(":BL_PROJECT_START", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":BL_PROJECT_START", OracleDbType.Date).Value = entity.BlProjectStart;
                if (entity.BlProjectFinish == null) cmd.Parameters.Add(":BL_PROJECT_FINISH", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":BL_PROJECT_FINISH", OracleDbType.Date).Value = entity.BlProjectFinish;
                cmd.Parameters.Add(":PASTA_CODIGO", OracleDbType.Varchar2).Value = entity.PastaCodigo;
                cmd.Parameters.Add(":SSOP", OracleDbType.Varchar2).Value = entity.Ssop;
                cmd.Parameters.Add(":FASE", OracleDbType.Varchar2).Value = entity.Fase;
                cmd.Parameters.Add(":BLOCO", OracleDbType.Varchar2).Value = entity.Bloco;
                cmd.Parameters.Add(":DES_REFERENCIA", OracleDbType.Varchar2).Value = entity.DesReferencia;
                cmd.Parameters.Add(":RM", OracleDbType.Varchar2).Value = entity.RM;
                cmd.Parameters.Add(":RM_REV", OracleDbType.Varchar2).Value = entity.RmRev;
                cmd.Parameters.Add(":AFS", OracleDbType.Varchar2).Value = entity.Afs;
                if (entity.DataNecessaria == null) cmd.Parameters.Add(":DATA_NECESSARIA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":DATA_NECESSARIA", OracleDbType.Date).Value = entity.DataNecessaria;
                cmd.Parameters.Add(":STATUS_CHEGADA", OracleDbType.Varchar2).Value = entity.StatusChegada;
                cmd.Parameters.Add(":INDICE", OracleDbType.Decimal).Value = entity.Indice;
                cmd.Parameters.Add(":FOTA_ID", OracleDbType.Decimal).Value = entity.FotaId;
                cmd.Parameters.Add(":PRODUTIVIDADE", OracleDbType.Decimal).Value = entity.Produtividade;
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ElControleGeralEit"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EL_CONTROLE_GERAL_EIT WHERE ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ElControleGeralEit"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ElControleGeralEit"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EL_CONTROLE_GERAL_EIT";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ElControleGeralEit"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ElControleGeralEit"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ElControleGeralEit"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableElControleGeralEit"); }
        }
        //====================================================================
        public static DTO.ElControleGeralEitDTO Get(decimal ID)
        {
            ElControleGeralEitDTO entity = new ElControleGeralEitDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["CONTRATO"] != null) && (dt.Rows[0]["CONTRATO"] != DBNull.Value)) entity.Contrato = Convert.ToString(dt.Rows[0]["CONTRATO"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["CLASSE_DISCIPLINA"] != null) && (dt.Rows[0]["CLASSE_DISCIPLINA"] != DBNull.Value)) entity.ClasseDisciplina = Convert.ToString(dt.Rows[0]["CLASSE_DISCIPLINA"]);
            if ((dt.Rows[0]["CRITERIO"] != null) && (dt.Rows[0]["CRITERIO"] != DBNull.Value)) entity.Criterio = Convert.ToString(dt.Rows[0]["CRITERIO"]);
            if ((dt.Rows[0]["EAP"] != null) && (dt.Rows[0]["EAP"] != DBNull.Value)) entity.Eap = Convert.ToString(dt.Rows[0]["EAP"]);
            if ((dt.Rows[0]["ATIVIDADE_CRITERIO"] != null) && (dt.Rows[0]["ATIVIDADE_CRITERIO"] != DBNull.Value)) entity.AtividadeCriterio = Convert.ToString(dt.Rows[0]["ATIVIDADE_CRITERIO"]);
            if ((dt.Rows[0]["TIPO_MATERIAL"] != null) && (dt.Rows[0]["TIPO_MATERIAL"] != DBNull.Value)) entity.TipoMaterial = Convert.ToString(dt.Rows[0]["TIPO_MATERIAL"]);
            if ((dt.Rows[0]["STATUS_ENGENHARIA"] != null) && (dt.Rows[0]["STATUS_ENGENHARIA"] != DBNull.Value)) entity.StatusEngenharia = Convert.ToString(dt.Rows[0]["STATUS_ENGENHARIA"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["DESENHO_REV"] != null) && (dt.Rows[0]["DESENHO_REV"] != DBNull.Value)) entity.DesenhoRev = Convert.ToString(dt.Rows[0]["DESENHO_REV"]);
            if ((dt.Rows[0]["REGIAO"] != null) && (dt.Rows[0]["REGIAO"] != DBNull.Value)) entity.Regiao = Convert.ToString(dt.Rows[0]["REGIAO"]);
            if ((dt.Rows[0]["LOCAL"] != null) && (dt.Rows[0]["LOCAL"] != DBNull.Value)) entity.Local = Convert.ToString(dt.Rows[0]["LOCAL"]);
            if ((dt.Rows[0]["TAG"] != null) && (dt.Rows[0]["TAG"] != DBNull.Value)) entity.Tag = Convert.ToString(dt.Rows[0]["TAG"]);
            if ((dt.Rows[0]["DESCRICAO"] != null) && (dt.Rows[0]["DESCRICAO"] != DBNull.Value)) entity.Descricao = Convert.ToString(dt.Rows[0]["DESCRICAO"]);
            if ((dt.Rows[0]["QUANTIDADE_PROJETO"] != null) && (dt.Rows[0]["QUANTIDADE_PROJETO"] != DBNull.Value)) entity.QuantidadeProjeto = Convert.ToDecimal(dt.Rows[0]["QUANTIDADE_PROJETO"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["AVANCO_FISICO"] != null) && (dt.Rows[0]["AVANCO_FISICO"] != DBNull.Value)) entity.AvancoFisico = Convert.ToDecimal(dt.Rows[0]["AVANCO_FISICO"]);
            if ((dt.Rows[0]["SEMANA"] != null) && (dt.Rows[0]["SEMANA_CALIBRACAO"] != DBNull.Value)) entity.Semana = Convert.ToString(dt.Rows[0]["SEMANA"]);
            if ((dt.Rows[0]["DIPR_CODIGO"] != null) && (dt.Rows[0]["DIPR_CODIGO"] != DBNull.Value)) entity.DiprCodigo = Convert.ToString(dt.Rows[0]["DIPR_CODIGO"]);
            if ((dt.Rows[0]["RESERVA"] != null) && (dt.Rows[0]["RESERVA"] != DBNull.Value)) entity.Reserva = Convert.ToString(dt.Rows[0]["RESERVA"]);
            if ((dt.Rows[0]["BL_PROJECT_START"] != null) && (dt.Rows[0]["BL_PROJECT_START"] != DBNull.Value)) entity.BlProjectStart = Convert.ToDateTime(dt.Rows[0]["BL_PROJECT_START"]);
            if ((dt.Rows[0]["BL_PROJECT_FINISH"] != null) && (dt.Rows[0]["BL_PROJECT_FINISH"] != DBNull.Value)) entity.BlProjectFinish = Convert.ToDateTime(dt.Rows[0]["BL_PROJECT_FINISH"]);
            if ((dt.Rows[0]["PASTA_CODIGO"] != null) && (dt.Rows[0]["PASTA_CODIGO"] != DBNull.Value)) entity.PastaCodigo = Convert.ToString(dt.Rows[0]["PASTA_CODIGO"]);
            if ((dt.Rows[0]["SSOP"] != null) && (dt.Rows[0]["SSOP"] != DBNull.Value)) entity.Ssop = Convert.ToString(dt.Rows[0]["SSOP"]);
            if ((dt.Rows[0]["FASE"] != null) && (dt.Rows[0]["FASE"] != DBNull.Value)) entity.Fase = Convert.ToString(dt.Rows[0]["FASE"]);
            if ((dt.Rows[0]["BLOCO"] != null) && (dt.Rows[0]["BLOCO"] != DBNull.Value)) entity.Bloco = Convert.ToString(dt.Rows[0]["BLOCO"]);
            if ((dt.Rows[0]["DES_REFERENCIA"] != null) && (dt.Rows[0]["DES_REFERENCIA"] != DBNull.Value)) entity.DesReferencia = Convert.ToString(dt.Rows[0]["DES_REFERENCIA"]);
            if ((dt.Rows[0]["RM"] != null) && (dt.Rows[0]["RM"] != DBNull.Value)) entity.RM = Convert.ToString(dt.Rows[0]["RM"]);
            if ((dt.Rows[0]["RM_REV"] != null) && (dt.Rows[0]["RM_REV"] != DBNull.Value)) entity.RmRev = Convert.ToString(dt.Rows[0]["RM_REV"]);
            if ((dt.Rows[0]["AFS"] != null) && (dt.Rows[0]["AFS"] != DBNull.Value)) entity.Afs = Convert.ToString(dt.Rows[0]["AFS"]);
            if ((dt.Rows[0]["DATA_NECESSARIA"] != null) && (dt.Rows[0]["DATA_NECESSARIA"] != DBNull.Value)) entity.DataNecessaria = Convert.ToDateTime(dt.Rows[0]["DATA_NECESSARIA"]);
            if ((dt.Rows[0]["STATUS_CHEGADA"] != null) && (dt.Rows[0]["STATUS_CHEGADA"] != DBNull.Value)) entity.StatusChegada = Convert.ToString(dt.Rows[0]["STATUS_CHEGADA"]);
            if ((dt.Rows[0]["INDICE"] != null) && (dt.Rows[0]["INDICE"] != DBNull.Value)) entity.Indice = Convert.ToDecimal(dt.Rows[0]["INDICE"]);
            if ((dt.Rows[0]["FOTA_ID"] != null) && (dt.Rows[0]["FOTA_ID"] != DBNull.Value)) entity.FotaId = Convert.ToDecimal(dt.Rows[0]["FOTA_ID"]);
            if ((dt.Rows[0]["PRODUTIVIDADE"] != null) && (dt.Rows[0]["PRODUTIVIDADE"] != DBNull.Value)) entity.Produtividade = Convert.ToDecimal(dt.Rows[0]["PRODUTIVIDADE"]);
            return entity;
        }
        //====================================================================
        public static DTO.ElControleGeralEitDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PRODUTIVIDADE Object"); }
        }
        //====================================================================
        public static List<ElControleGeralEitDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ElControleGeralEitDTO> list = OracleDataTools.LoadEntity<ElControleGeralEitDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElControleGeralEitDTO>"); }
        }
        //====================================================================
        public static List<ElControleGeralEitDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElControleGeralEitDTO>"); }
        }
        //====================================================================
        public static List<ElControleGeralEitDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ElControleGeralEitDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionElControleGeralEitDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionElControleGeralEit"); }
        }
        //====================================================================
        public static DTO.CollectionElControleGeralEitDTO GetCollection(DataTable dt)
        {
            DTO.CollectionElControleGeralEitDTO collection = new DTO.CollectionElControleGeralEitDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ElControleGeralEitDTO entity = new DTO.ElControleGeralEitDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["CONTRATO"].ToString().Length != 0) entity.Contrato = dt.Rows[i]["CONTRATO"].ToString();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["CLASSE_DISCIPLINA"].ToString().Length != 0) entity.ClasseDisciplina = dt.Rows[i]["CLASSE_DISCIPLINA"].ToString();
                    if (dt.Rows[i]["CRITERIO"].ToString().Length != 0) entity.Criterio = dt.Rows[i]["CRITERIO"].ToString();
                    if (dt.Rows[i]["EAP"].ToString().Length != 0) entity.Eap = dt.Rows[i]["EAP"].ToString();
                    if (dt.Rows[i]["ATIVIDADE_CRITERIO"].ToString().Length != 0) entity.AtividadeCriterio = dt.Rows[i]["ATIVIDADE_CRITERIO"].ToString();
                    if (dt.Rows[i]["TIPO_MATERIAL"].ToString().Length != 0) entity.TipoMaterial = dt.Rows[i]["TIPO_MATERIAL"].ToString();
                    if (dt.Rows[i]["STATUS_ENGENHARIA"].ToString().Length != 0) entity.StatusEngenharia = dt.Rows[i]["STATUS_ENGENHARIA"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["DESENHO_REV"].ToString().Length != 0) entity.DesenhoRev = dt.Rows[i]["DESENHO_REV"].ToString();
                    if (dt.Rows[i]["REGIAO"].ToString().Length != 0) entity.Regiao = dt.Rows[i]["REGIAO"].ToString();
                    if (dt.Rows[i]["LOCAL"].ToString().Length != 0) entity.Local = dt.Rows[i]["LOCAL"].ToString();
                    if (dt.Rows[i]["TAG"].ToString().Length != 0) entity.Tag = dt.Rows[i]["TAG"].ToString();
                    if (dt.Rows[i]["DESCRICAO"].ToString().Length != 0) entity.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
                    if (dt.Rows[i]["QUANTIDADE_PROJETO"].ToString().Length != 0) entity.QuantidadeProjeto = Convert.ToDecimal(dt.Rows[i]["QUANTIDADE_PROJETO"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["AVANCO_FISICO"].ToString().Length != 0) entity.AvancoFisico = Convert.ToDecimal(dt.Rows[i]["AVANCO_FISICO"]);
                    if (dt.Rows[i]["SEMANA"].ToString().Length != 0) entity.Semana = dt.Rows[i]["SEMANA"].ToString();
                    if (dt.Rows[i]["DIPR_CODIGO"].ToString().Length != 0) entity.DiprCodigo = dt.Rows[i]["DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["RESERVA"].ToString().Length != 0) entity.Reserva = dt.Rows[i]["RESERVA"].ToString();
                    if (dt.Rows[i]["BL_PROJECT_START"].ToString().Length != 0) entity.BlProjectStart = Convert.ToDateTime(dt.Rows[i]["BL_PROJECT_START"]);
                    if (dt.Rows[i]["BL_PROJECT_FINISH"].ToString().Length != 0) entity.BlProjectFinish = Convert.ToDateTime(dt.Rows[i]["BL_PROJECT_FINISH"]);
                    if (dt.Rows[i]["PASTA_CODIGO"].ToString().Length != 0) entity.PastaCodigo = dt.Rows[i]["PASTA_CODIGO"].ToString();
                    if (dt.Rows[i]["SSOP"].ToString().Length != 0) entity.Ssop = dt.Rows[i]["SSOP"].ToString();
                    if (dt.Rows[i]["FASE"].ToString().Length != 0) entity.Fase = dt.Rows[i]["FASE"].ToString();
                    if (dt.Rows[i]["BLOCO"].ToString().Length != 0) entity.Bloco = dt.Rows[i]["BLOCO"].ToString();
                    if (dt.Rows[i]["DES_REFERENCIA"].ToString().Length != 0) entity.DesReferencia = dt.Rows[i]["DES_REFERENCIA"].ToString();
                    if (dt.Rows[i]["RM"].ToString().Length != 0) entity.RM = dt.Rows[i]["RM"].ToString();
                    if (dt.Rows[i]["RM_REV"].ToString().Length != 0) entity.RmRev = dt.Rows[i]["RM_REV"].ToString();
                    if (dt.Rows[i]["AFS"].ToString().Length != 0) entity.Afs = dt.Rows[i]["AFS"].ToString();
                    if (dt.Rows[i]["DATA_NECESSARIA"].ToString().Length != 0) entity.DataNecessaria = Convert.ToDateTime(dt.Rows[i]["DATA_NECESSARIA"]);
                    if (dt.Rows[i]["STATUS_CHEGADA"].ToString().Length != 0) entity.StatusChegada = dt.Rows[i]["STATUS_CHEGADA"].ToString();
                    if (dt.Rows[i]["INDICE"].ToString().Length != 0) entity.Indice = Convert.ToDecimal(dt.Rows[i]["INDICE"]);
                    if (dt.Rows[i]["FOTA_ID"].ToString().Length != 0) entity.FotaId = Convert.ToDecimal(dt.Rows[i]["FOTA_ID"]);
                    if (dt.Rows[i]["PRODUTIVIDADE"].ToString().Length != 0) entity.Produtividade = Convert.ToDecimal(dt.Rows[i]["PRODUTIVIDADE"]);

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
