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
    public class AcAvnGrupoCriterioDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.AVGC_CNTR_CODIGO, X.AVGC_ID, X.AVGC_MES, X.AVGC_SEMA_ID, X.AVGC_MES, X.AVGC_OBRA, X.AVGC_GRUPO_SIGLA, X.AVGC_GRCR_NOME, X.AVGC_GRCR_GRUPO_DESCRICAO, X.AVGC_PREVISTO_SEMANAL, X.AVGC_AVANCO_SEMANAL_PROG, X.AVGC_AVANCO_SEMANAL_EXEC, X.AVGC_PREVISTO_MENSAL, X.AVGC_AVANCO_MENSAL_PROG, X.AVGC_AVANCO_MENSAL_EXEC, X.AVGC_PREVISTO_ACUMULADO, X.AVGC_AVANCO_ACUMULADO_PROG, X.AVGC_AVANCO_ACUMULADO_EXEC FROM EEP_CONVERSION.AC_AVN_GRUPO_CRITERIO X ";
        //====================================================================
        public static int Insert(DTO.AcAvnGrupoCriterioDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_AVN_GRUPO_CRITERIO(AVGC_CNTR_CODIGO,AVGC_SEMA_ID, AVGC_MES, AVGC_OBRA, AVGC_GRUPO_SIGLA, AVGC_GRCR_NOME,  AVGC_GRCR_GRUPO_DESCRICAO, AVGC_PREVISTO_SEMANAL, AVGC_AVANCO_SEMANAL_PROG, AVGC_AVANCO_SEMANAL_EXEC, AVGC_PREVISTO_MENSAL, AVGC_AVANCO_MENSAL_PROG, AVGC_AVANCO_MENSAL_EXEC, AVGC_PREVISTO_ACUMULADO, AVGC_AVANCO_ACUMULADO_PROG, AVGC_AVANCO_ACUMULADO_EXEC) VALUES(:AVGC_CNTR_CODIGO, :AVGC_SEMA_ID, :AVGC__MES, :AVGC_OBRA, :AVGC_GRUPO_SIGLA, :AVGC_GRCR_NOME, :AVGC_GRCR_GRUPO_DESCRICAO, :AVGC_PREVISTO_SEMANAL, :AVGC_AVANCO_SEMANAL_PROG, :AVGC_AVANCO_SEMANAL_EXEC, :AVGC_PREVISTO_MENSAL, :AVGC_AVANCO_MENSAL_PROG, :AVGC_AVANCO_MENSAL_EXEC, :AVGC_PREVISTO_ACUMULADO, :AVGC_AVANCO_ACUMULADO_PROG, :AVGC_AVANCO_ACUMULADO_EXEC)";
            if (getIdentity) strSQL += " SELECT @@IDENTITY AS 'Identity'";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AVGC_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.AvgcCntrCodigo;
                cmd.Parameters.Add(":AVGC_SEMA_ID", OracleDbType.Int32).Value = entity.AvgcSemaId;
                cmd.Parameters.Add(":AVGC_MES", OracleDbType.Varchar2).Value = entity.AvgcMes;
                cmd.Parameters.Add(":AVGC_OBRA", OracleDbType.Varchar2).Value = entity.AvgcObra;
                cmd.Parameters.Add(":AVGC_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.AvgcGrupoSigla;
                cmd.Parameters.Add(":AVGC_GRCR_NOME", OracleDbType.Varchar2).Value = entity.AvgcGrcrNome;
                cmd.Parameters.Add(":AVGC_GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.AvgcGrcrGrupoDescricao;
                cmd.Parameters.Add(":AVGC_PREVISTO_SEMANAL", OracleDbType.Decimal).Value = entity.AvgcPrevistoSemanal;
                cmd.Parameters.Add(":AVGC_AVANCO_SEMANAL_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoSemanalProg;
                cmd.Parameters.Add(":AVGC_AVANCO_SEMANAL_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoSemanalExec;
                cmd.Parameters.Add(":AVGC_PREVISTO_MENSAL", OracleDbType.Decimal).Value = entity.AvgcPrevistoMensal;
                cmd.Parameters.Add(":AVGC_AVANCO_MENSAL_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoMensalProg;
                cmd.Parameters.Add(":AVGC_AVANCO_MENSAL_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoMensalExec;
                cmd.Parameters.Add(":AVGC_PREVISTO_ACUMULADO", OracleDbType.Decimal).Value = entity.AvgcPrevistoAcumulado;
                cmd.Parameters.Add(":AVGC_AVANCO_ACUMULADO_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoAcumuladoProg;
                cmd.Parameters.Add(":AVGC_AVANCO_ACUMULADO_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoAcumuladoExec;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcAvnGrupoCriterio");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcAvnGrupoCriterio");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcAvnGrupoCriterioDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_AVN_GRUPO_CRITERIO set AVGC_CNTR_CODIGO = :AVGC_CNTR_CODIGO, AVGC_SEMA_ID = :AVGC_SEMA_ID, AVGC_MES = :AVGC_MES, AVGC_OBRA = :AVGC_OBRA, AVGC_GRUPO_SIGLA = :AVGC_GRUPO_SIGLA, AVGC_GRCR_NOME = :AVGC_GRCR_NOME, AVGC_GRCR_GRUPO_DESCRICAO = :AVGC_GRCR_GRUPO_DESCRICAO, AVGC_PREVISTO_SEMANAL = :AVGC_PREVISTO_SEMANAL, AVGC_AVANCO_SEMANAL_PROG = :AVGC_AVANCO_SEMANAL_PROG, AVGC_AVANCO_SEMANAL_EXEC = :AVGC_AVANCO_SEMANAL_EXEC, AVGC_PREVISTO_MENSAL = :AVGC_PREVISTO_MENSAL, AVGC_AVANCO_MENSAL_PROG = :AVGC_AVANCO_MENSAL_PROG, AVGC_AVANCO_MENSAL_EXEC = :AVGC_AVANCO_MENSAL_EXEC, AVGC_PREVISTO_ACUMULADO = :AVGC_PREVISTO_ACUMULADO, AVGC_AVANCO_ACUMULADO_PROG = :AVGC_AVANCO_ACUMULADO_PROG, AVGC_AVANCO_ACUMULADO_EXEC = :AVGC_AVANCO_ACUMULADO_EXEC WHERE  AVGC_ID = : AVGC_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("AVGC_ID", OracleDbType.Int32).Value = entity.AvgcId;
                cmd.Parameters.Add("AVGC_SEMA_ID", OracleDbType.Int32).Value = entity.AvgcSemaId;
                cmd.Parameters.Add("AVGC_MES", OracleDbType.Varchar2).Value = entity.AvgcMes;
                cmd.Parameters.Add("AVGC_OBRA", OracleDbType.Varchar2).Value = entity.AvgcObra;
                cmd.Parameters.Add("AVGC_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.AvgcGrupoSigla;
                cmd.Parameters.Add("AVGC_GRCR_NOME", OracleDbType.Varchar2).Value = entity.AvgcGrcrNome;
                cmd.Parameters.Add("AVGC_GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.AvgcGrcrGrupoDescricao;
                cmd.Parameters.Add("AVGC_PREVISTO_SEMANAL", OracleDbType.Decimal).Value = entity.AvgcPrevistoSemanal;
                cmd.Parameters.Add("AVGC_AVANCO_SEMANAL_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoSemanalProg;
                cmd.Parameters.Add("AVGC_AVANCO_SEMANAL_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoSemanalExec;
                cmd.Parameters.Add("AVGC_PREVISTO_MENSAL", OracleDbType.Decimal).Value = entity.AvgcPrevistoMensal;
                cmd.Parameters.Add("AVGC_AVANCO_MENSAL_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoMensalProg;
                cmd.Parameters.Add("AVGC_AVANCO_MENSAL_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoMensalExec;
                cmd.Parameters.Add("AVGC_PREVISTO_ACUMULADO", OracleDbType.Decimal).Value = entity.AvgcPrevistoAcumulado;
                cmd.Parameters.Add("AVGC_AVANCO_ACUMULADO_PROG", OracleDbType.Decimal).Value = entity.AvgcAvancoAcumuladoProg;
                cmd.Parameters.Add("AVGC_AVANCO_ACUMULADO_EXEC", OracleDbType.Decimal).Value = entity.AvgcAvancoAcumuladoExec;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcAvnGrupoCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal AvgcId)
        {
            string strSQL = "DELETE FROM AC_AVN_GRUPO_CRITERIO WHERE  AVGC_ID = : AVGC_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":AvgcId", OracleDbType.Varchar2).Value = AvgcId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcAvnGrupoCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_AVN_GRUPO_CRITERIO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }

        //====================================================================
        public static DataTable SelectAvancosSemanaObraGrupoCriterio(string semanaSelected, string obra, string grupoSigla)
        {
            DataTable dtSaida = null;
            string filter = @" WHERE AVGC_SEMA_ID = " + semanaSelected + " AND AVGC_OBRA = '" + obra + "' AND AVGC_GRUPO_SIGLA = '" + grupoSigla + "'";
            string strSQL = @"
                                SELECT
		                                AVGC_SEMA_ID,
		                                AVGC_OBRA,
		                                AVGC_MES,
		                                AVGC_GRUPO_SIGLA,
		                                AVGC_GRCR_GRUPO_DESCRICAO,
		                                AVGC_GRCR_NOME,
		                                AVGC_PREVISTO_SEMANAL,
		                                AVGC_AVANCO_SEMANAL_PROG,
		                                AVGC_AVANCO_SEMANAL_EXEC,
		                                AVGC_PREVISTO_MENSAL,
		                                AVGC_AVANCO_MENSAL_PROG,
		                                AVGC_AVANCO_MENSAL_EXEC,
		                                AVGC_PREVISTO_ACUMULADO,
		                                AVGC_AVANCO_ACUMULADO_PROG,
		                                AVGC_AVANCO_ACUMULADO_EXEC
                                  FROM
		                                EEP_CONVERSION.AC_AVN_GRUPO_CRITERIO" + filter;
            dtSaida = OracleDataTools.GetDataTable(strSQL);
            return dtSaida;
        }






        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static DTO.AcAvnGrupoCriterioDTO Get(decimal AvgcId)
        {
            AcAvnGrupoCriterioDTO entity = new AcAvnGrupoCriterioDTO();
            DataTable dt = null;
            string filter = "AVGC_ID = " + AvgcId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["AVGC_CNTR_CODIGO"] != null) && (dt.Rows[0]["AVGC_CNTR_CODIGO"] != DBNull.Value)) entity.AvgcCntrCodigo = Convert.ToString(dt.Rows[0]["AVGC_CNTR_CODIGO"]);
            if ((dt.Rows[0]["AVGC_ID"] != null) && (dt.Rows[0]["AVGC_ID"] != DBNull.Value)) entity.AvgcId = Convert.ToDecimal(dt.Rows[0]["AVGC_ID"]);
            if ((dt.Rows[0]["AVGC_SEMA_ID"] != null) && (dt.Rows[0]["AVGC_SEMA_ID"] != DBNull.Value)) entity.AvgcSemaId = Convert.ToDecimal(dt.Rows[0]["AVGC_SEMA_ID"]);
            if ((dt.Rows[0]["AVGC_MES"] != null) && (dt.Rows[0]["AVGC_MES"] != DBNull.Value)) entity.AvgcMes = Convert.ToString(dt.Rows[0]["AVGC_MES"]);
            if ((dt.Rows[0]["AVGC_OBRA"] != null) && (dt.Rows[0]["AVGC_OBRA"] != DBNull.Value)) entity.AvgcObra = Convert.ToString(dt.Rows[0]["AVGC_OBRA"]);
            if ((dt.Rows[0]["AVGC_GRUPO_SIGLA"] != null) && (dt.Rows[0]["AVGC_GRUPO_SIGLA"] != DBNull.Value)) entity.AvgcGrupoSigla = Convert.ToString(dt.Rows[0]["AVGC_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["AVGC_GRCR_NOME"] != null) && (dt.Rows[0]["AVGC_GRCR_NOME"] != DBNull.Value)) entity.AvgcGrcrNome = Convert.ToString(dt.Rows[0]["AVGC_GRCR_NOME"]);
            if ((dt.Rows[0]["AVGC_GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["AVGC_GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.AvgcGrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["AVGC_GRCR_GRUPO_DESCRICAO"]);
            if ((dt.Rows[0]["AVGC_PREVISTO_SEMANAL"] != null) && (dt.Rows[0]["AVGC_PREVISTO_SEMANAL"] != DBNull.Value)) entity.AvgcPrevistoSemanal = Convert.ToDecimal(dt.Rows[0]["AVGC_PREVISTO_SEMANAL"]);
            if ((dt.Rows[0]["AVGC_AVANCO_SEMANAL_PROG"] != null) && (dt.Rows[0]["AVGC_AVANCO_SEMANAL_PROG"] != DBNull.Value)) entity.AvgcAvancoSemanalProg = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_SEMANAL_PROG"]);
            if ((dt.Rows[0]["AVGC_AVANCO_SEMANAL_EXEC"] != null) && (dt.Rows[0]["AVGC_AVANCO_SEMANAL_EXEC"] != DBNull.Value)) entity.AvgcAvancoSemanalExec = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_SEMANAL_EXEC"]);
            if ((dt.Rows[0]["AVGC_PREVISTO_MENSAL"] != null) && (dt.Rows[0]["AVGC_PREVISTO_MENSAL"] != DBNull.Value)) entity.AvgcPrevistoMensal = Convert.ToDecimal(dt.Rows[0]["AVGC_PREVISTO_MENSAL"]);
            if ((dt.Rows[0]["AVGC_AVANCO_MENSAL_PROG"] != null) && (dt.Rows[0]["AVGC_AVANCO_MENSAL_PROG"] != DBNull.Value)) entity.AvgcAvancoMensalProg = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_MENSAL_PROG"]);
            if ((dt.Rows[0]["AVGC_AVANCO_MENSAL_EXEC"] != null) && (dt.Rows[0]["AVGC_AVANCO_MENSAL_EXEC"] != DBNull.Value)) entity.AvgcAvancoMensalExec = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_MENSAL_EXEC"]);
            if ((dt.Rows[0]["AVGC_PREVISTO_ACUMULADO"] != null) && (dt.Rows[0]["AVGC_PREVISTO_ACUMULADO"] != DBNull.Value)) entity.AvgcPrevistoAcumulado = Convert.ToDecimal(dt.Rows[0]["AVGC_PREVISTO_ACUMULADO"]);
            if ((dt.Rows[0]["AVGC_AVANCO_ACUMULADO_PROG"] != null) && (dt.Rows[0]["AVGC_AVANCO_ACUMULADO_PROG"] != DBNull.Value)) entity.AvgcAvancoAcumuladoProg = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_ACUMULADO_PROG"]);
            if ((dt.Rows[0]["AVGC_AVANCO_ACUMULADO_EXEC"] != null) && (dt.Rows[0]["AVGC_AVANCO_ACUMULADO_EXEC"] != DBNull.Value)) entity.AvgcAvancoAcumuladoExec = Convert.ToDecimal(dt.Rows[0]["AVGC_AVANCO_ACUMULADO_EXEC"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcAvnGrupoCriterioDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting AVGC_AVANCO_ACUMULADO_EXEC Object"); }
        }
        //====================================================================
        public static List<AcAvnGrupoCriterioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcAvnGrupoCriterioDTO> list = OracleDataTools.LoadEntity<AcAvnGrupoCriterioDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcAvnGrupoCriterioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcAvnGrupoCriterioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcAvnGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                //Hashtable dict = GetDictionary();
                //string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                //string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                //if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 1";
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcAvnGrupoCriterio"); }
        }
        //====================================================================
        public static DTO.CollectionAcAvnGrupoCriterioDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcAvnGrupoCriterioDTO collection = new DTO.CollectionAcAvnGrupoCriterioDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcAvnGrupoCriterioDTO entity = new DTO.AcAvnGrupoCriterioDTO();
                    if (dt.Rows[i]["AVGC_CNTR_CODIGO"].ToString().Length != 0) entity.AvgcCntrCodigo = dt.Rows[i]["AVGC_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["AVGC_ID"].ToString().Length != 0) entity.AvgcId = Convert.ToDecimal(dt.Rows[i]["AVGC_ID"]);
                    if (dt.Rows[i]["AVGC_SEMA_ID"].ToString().Length != 0) entity.AvgcSemaId = Convert.ToDecimal(dt.Rows[i]["AVGC_SEMA_ID"]);
                    if (dt.Rows[i]["AVGC_MES"].ToString().Length != 0) entity.AvgcMes = dt.Rows[i]["AVGC_MES"].ToString();
                    if (dt.Rows[i]["AVGC_OBRA"].ToString().Length != 0) entity.AvgcObra = dt.Rows[i]["AVGC_OBRA"].ToString();
                    if (dt.Rows[i]["AVGC_GRUPO_SIGLA"].ToString().Length != 0) entity.AvgcGrupoSigla = dt.Rows[i]["AVGC_GRUPO_SIGLA"].ToString();
                    if (dt.Rows[i]["AVGC_GRCR_NOME"].ToString().Length != 0) entity.AvgcGrcrNome = dt.Rows[i]["AVGC_GRCR_NOME"].ToString();
                    if (dt.Rows[i]["AVGC_GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.AvgcGrcrGrupoDescricao = dt.Rows[i]["AVGC_GRCR_GRUPO_DESCRICAO"].ToString();
                    if (dt.Rows[i]["AVGC_PREVISTO_SEMANAL"].ToString().Length != 0) entity.AvgcPrevistoSemanal = Convert.ToDecimal(dt.Rows[i]["AVGC_PREVISTO_SEMANAL"]);
                    if (dt.Rows[i]["AVGC_AVANCO_SEMANAL_PROG"].ToString().Length != 0) entity.AvgcAvancoSemanalProg = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_SEMANAL_PROG"]);
                    if (dt.Rows[i]["AVGC_AVANCO_SEMANAL_EXEC"].ToString().Length != 0) entity.AvgcAvancoSemanalExec = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_SEMANAL_EXEC"]);
                    if (dt.Rows[i]["AVGC_PREVISTO_MENSAL"].ToString().Length != 0) entity.AvgcPrevistoMensal = Convert.ToDecimal(dt.Rows[i]["AVGC_PREVISTO_MENSAL"]);
                    if (dt.Rows[i]["AVGC_AVANCO_MENSAL_PROG"].ToString().Length != 0) entity.AvgcAvancoMensalProg = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_MENSAL_PROG"]);
                    if (dt.Rows[i]["AVGC_AVANCO_MENSAL_EXEC"].ToString().Length != 0) entity.AvgcAvancoMensalExec = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_MENSAL_EXEC"]);
                    if (dt.Rows[i]["AVGC_PREVISTO_ACUMULADO"].ToString().Length != 0) entity.AvgcPrevistoAcumulado = Convert.ToDecimal(dt.Rows[i]["AVGC_PREVISTO_ACUMULADO"]);
                    if (dt.Rows[i]["AVGC_AVANCO_ACUMULADO_PROG"].ToString().Length != 0) entity.AvgcAvancoAcumuladoProg = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_ACUMULADO_PROG"]);
                    if (dt.Rows[i]["AVGC_AVANCO_ACUMULADO_EXEC"].ToString().Length != 0) entity.AvgcAvancoAcumuladoExec = Convert.ToDecimal(dt.Rows[i]["AVGC_AVANCO_ACUMULADO_EXEC"]);

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
            dict.Add("AvgcCntrCodigo", "AVGC_CNTR_CODIGO");
            dict.Add("AvgcId", "AVGC_ID");
            dict.Add("AvgcSemaId", "AVGC_SEMA_ID");
            dict.Add("AvgcMes", "AVGC_MES");
            dict.Add("AvgcObra", "AVGC_OBRA");
            dict.Add("AvgcGrupoSigla", "AVGC_GRUPO_SIGLA");
            dict.Add("AvgcGrcrNome", "AVGC_GRCR_NOME");
            dict.Add("AvgcGrcrGrupoDescricao", "AVGC_GRCR_GRUPO_DESCRICAO");
            dict.Add("AvgcPrevistoSemanal", "AVGC_PREVISTO_SEMANAL");
            dict.Add("AvgcAvancoSemanalProg", "AVGC_AVANCO_SEMANAL_PROG");
            dict.Add("AvgcAvancoSemanalExec", "AVGC_AVANCO_SEMANAL_EXEC");
            dict.Add("AvgcPrevistoMensal", "AVGC_PREVISTO_MENSAL");
            dict.Add("AvgcAvancoMensalProg", "AVGC_AVANCO_MENSAL_PROG");
            dict.Add("AvgcAvancoMensalExec", "AVGC_AVANCO_MENSAL_EXEC");
            dict.Add("AvgcPrevistoAcumulado", "AVGC_PREVISTO_ACUMULADO");
            dict.Add("AvgcAvancoAcumuladoProg", "AVGC_AVANCO_ACUMULADO_PROG");
            dict.Add("AvgcAvancoAcumuladoExec", "AVGC_AVANCO_ACUMULADO_EXEC");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
