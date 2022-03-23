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
    public class IntTarefasDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.INTA_ID, X.INTA_FUNCIONARIO, X.INTA_TAREFA, X.INTA_INLO_ID, X.INTA_STATUS, X.INTA_ACTIVE , Y.INLO_NOME 
FROM EEP_CONVERSION.INT_TAREFAS X , EEP_CONVERSION.INT_LOCAIS Y";
        //====================================================================
        public static int Insert(DTO.IntTarefasDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.INT_TAREFAS(INTA_FUNCIONARIO,INTA_TAREFA,INTA_INLO_ID,INTA_STATUS,INTA_ACTIVE) VALUES(:INTA_FUNCIONARIO,:INTA_TAREFA,:INTA_INLO_ID,:INTA_STATUS,:INTA_ACTIVE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":INTA_FUNCIONARIO", OracleDbType.Varchar2).Value = entity.IntaFuncionario;
                cmd.Parameters.Add(":INTA_TAREFA", OracleDbType.Varchar2).Value = entity.IntaTarefa;
                cmd.Parameters.Add(":INTA_INLO_ID", OracleDbType.Decimal).Value = entity.IntaInloId;
                cmd.Parameters.Add(":INTA_STATUS", OracleDbType.Decimal).Value = entity.IntaStatus;
                cmd.Parameters.Add(":INTA_ACTIVE", OracleDbType.Decimal).Value = entity.IntaActive;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting IntTarefas");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting IntTarefas");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.IntTarefasDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.INT_TAREFAS set INTA_FUNCIONARIO = :INTA_FUNCIONARIO, INTA_TAREFA = :INTA_TAREFA, INTA_INLO_ID = :INTA_INLO_ID, INTA_STATUS = :INTA_STATUS, INTA_ACTIVE = :INTA_ACTIVE WHERE  INTA_ID = : INTA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":INTA_FUNCIONARIO", OracleDbType.Varchar2).Value = entity.IntaFuncionario;
                cmd.Parameters.Add(":INTA_TAREFA", OracleDbType.Varchar2).Value = entity.IntaTarefa;
                cmd.Parameters.Add(":INTA_INLO_ID", OracleDbType.Decimal).Value = entity.IntaInloId;
                cmd.Parameters.Add(":INTA_STATUS", OracleDbType.Decimal).Value = entity.IntaStatus;
                cmd.Parameters.Add(":INTA_ACTIVE", OracleDbType.Decimal).Value = entity.IntaActive;
                cmd.Parameters.Add(":INTA_ID", OracleDbType.Decimal).Value = entity.IntaId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating IntTarefas"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal IntaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.INT_TAREFAS WHERE  INTA_ID = : INTA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":IntaId", OracleDbType.Decimal).Value = IntaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting IntTarefas"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting IntTarefas"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.INT_TAREFAS";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting IntTarefas"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction IntTarefas"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction IntTarefas"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableIntTarefas"); }
        }
        //====================================================================
        public static DTO.IntTarefasDTO Get(decimal IntaId)
        {
            IntTarefasDTO entity = new IntTarefasDTO();
            DataTable dt = null;
            string filter = "INTA_ID = " + IntaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["INTA_ID"] != null) && (dt.Rows[0]["INTA_ID"] != DBNull.Value)) entity.IntaId = Convert.ToDecimal(dt.Rows[0]["INTA_ID"]);
            if ((dt.Rows[0]["INTA_FUNCIONARIO"] != null) && (dt.Rows[0]["INTA_FUNCIONARIO"] != DBNull.Value)) entity.IntaFuncionario = Convert.ToString(dt.Rows[0]["INTA_FUNCIONARIO"]);
            if ((dt.Rows[0]["INTA_TAREFA"] != null) && (dt.Rows[0]["INTA_TAREFA"] != DBNull.Value)) entity.IntaTarefa = Convert.ToString(dt.Rows[0]["INTA_TAREFA"]);
            if ((dt.Rows[0]["INTA_INLO_ID"] != null) && (dt.Rows[0]["INTA_INLO_ID"] != DBNull.Value)) entity.IntaInloId = Convert.ToDecimal(dt.Rows[0]["INTA_INLO_ID"]);
            if ((dt.Rows[0]["INTA_STATUS"] != null) && (dt.Rows[0]["INTA_STATUS"] != DBNull.Value)) entity.IntaStatus = Convert.ToDecimal(dt.Rows[0]["INTA_STATUS"]);
            if ((dt.Rows[0]["INTA_ACTIVE"] != null) && (dt.Rows[0]["INTA_ACTIVE"] != DBNull.Value)) entity.IntaActive = Convert.ToDecimal(dt.Rows[0]["INTA_ACTIVE"]);
            return entity;
        }
        //====================================================================
        public static DTO.IntTarefasDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting INTA_ACTIVE Object"); }
        }
        //====================================================================
        public static List<IntTarefasDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<IntTarefasDTO> list = OracleDataTools.LoadEntity<IntTarefasDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntTarefasDTO>"); }
        }
        //====================================================================
        public static List<IntTarefasDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntTarefasDTO>"); }
        }
        //====================================================================
        public static List<IntTarefasDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<IntTarefasDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionIntTarefasDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionIntTarefas"); }
        }
        //====================================================================
        public static DTO.CollectionIntTarefasDTO GetCollection(DataTable dt)
        {
            DTO.CollectionIntTarefasDTO collection = new DTO.CollectionIntTarefasDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.IntTarefasDTO entity = new DTO.IntTarefasDTO();
                    if (dt.Rows[i]["INTA_ID"].ToString().Length != 0) entity.IntaId = Convert.ToDecimal(dt.Rows[i]["INTA_ID"]);
                    if (dt.Rows[i]["INTA_FUNCIONARIO"].ToString().Length != 0) entity.IntaFuncionario = dt.Rows[i]["INTA_FUNCIONARIO"].ToString();
                    if (dt.Rows[i]["INTA_TAREFA"].ToString().Length != 0) entity.IntaTarefa = dt.Rows[i]["INTA_TAREFA"].ToString();
                    if (dt.Rows[i]["INTA_INLO_ID"].ToString().Length != 0) entity.IntaInloId = Convert.ToDecimal(dt.Rows[i]["INTA_INLO_ID"]);
                    if (dt.Rows[i]["INTA_STATUS"].ToString().Length != 0) entity.IntaStatus = Convert.ToDecimal(dt.Rows[i]["INTA_STATUS"]);
                    if (dt.Rows[i]["INTA_ACTIVE"].ToString().Length != 0) entity.IntaActive = Convert.ToDecimal(dt.Rows[i]["INTA_ACTIVE"]);

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
            dict.Add("IntaId", "INTA_ID");
            dict.Add("IntaFuncionario", "INTA_FUNCIONARIO");
            dict.Add("IntaTarefa", "INTA_TAREFA");
            dict.Add("IntaInloId", "INTA_INLO_ID");
            dict.Add("IntaStatus", "INTA_STATUS");
            dict.Add("IntaActive", "INTA_ACTIVE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
