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
    public class ProjGenEmailDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.TIPO_DESTINATARIO, X.DISCIPLINA, X.EMAIL, X.ATIVO, X.DESCRICAO FROM EEP_CONVERSION.PROJ_GEN_EMAIL X ";
        //====================================================================
        public static int Insert(DTO.ProjGenEmailDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.PROJ_GEN_EMAIL(TIPO_DESTINATARIO,DISCIPLINA,EMAIL,ATIVO, DESCRICAO) VALUES(:TIPO_DESTINATARIO,:DISCIPLINA,:EMAIL,:ATIVO,:DESCRICAO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":TIPO_DESTINATARIO", OracleDbType.Varchar2).Value = entity.TipoDestinatario;
                cmd.Parameters.Add(":DISCIPLINA", OracleDbType.Varchar2).Value = entity.Disciplina;
                cmd.Parameters.Add(":EMAIL", OracleDbType.Varchar2).Value = entity.Email;
                cmd.Parameters.Add(":ATIVO", OracleDbType.Int32).Value = entity.Ativo;
                cmd.Parameters.Add(":DESCRICAO", OracleDbType.Varchar2).Value = entity.Descricao;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting ProjGenEmail");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting ProjGenEmail");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.ProjGenEmailDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.PROJ_GEN_EMAIL set TIPO_DESTINATARIO = :TIPO_DESTINATARIO, DISCIPLINA = :DISCIPLINA, EMAIL = :EMAIL, ATIVO = :ATIVO, DESCRICAO = :DESCRICAO WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("TIPO_DESTINATARIO", OracleDbType.Varchar2).Value = entity.TipoDestinatario;
                cmd.Parameters.Add("DISCIPLINA", OracleDbType.Varchar2).Value = entity.Disciplina;
                cmd.Parameters.Add("EMAIL", OracleDbType.Varchar2).Value = entity.Email;
                cmd.Parameters.Add("ATIVO", OracleDbType.Int32).Value = entity.Ativo;
                cmd.Parameters.Add("DESCRICAO", OracleDbType.Varchar2).Value = entity.Descricao;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating ProjGenEmail"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_GEN_EMAIL WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Int32).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting ProjGenEmail"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjGenEmail"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.PROJ_GEN_EMAIL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting ProjGenEmail"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjGenEmail"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction ProjGenEmail"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static DataTable GetEmailByTipoDestinatario(string tipoDestinatario)
        {
            string filter = "ATIVO = 1 AND UPPER(TIPO_DESTINATARIO) = '" + tipoDestinatario.ToUpper() + "'" ;
            try
            {
                return Get(filter, "EMAIL");
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjGenEmail"); }
        }
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableProjGenEmail"); }
        }
        //====================================================================
        public static DTO.ProjGenEmailDTO Get(decimal ID)
        {
            ProjGenEmailDTO entity = new ProjGenEmailDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["TIPO_DESTINATARIO"] != null) && (dt.Rows[0]["TIPO_DESTINATARIO"] != DBNull.Value)) entity.TipoDestinatario = Convert.ToString(dt.Rows[0]["TIPO_DESTINATARIO"]);
            if ((dt.Rows[0]["DISCIPLINA"] != null) && (dt.Rows[0]["DISCIPLINA"] != DBNull.Value)) entity.Disciplina = Convert.ToString(dt.Rows[0]["DISCIPLINA"]);
            if ((dt.Rows[0]["EMAIL"] != null) && (dt.Rows[0]["EMAIL"] != DBNull.Value)) entity.Email = Convert.ToString(dt.Rows[0]["EMAIL"]);
            if ((dt.Rows[0]["ATIVO"] != null) && (dt.Rows[0]["ATIVO"] != DBNull.Value)) entity.Ativo = Convert.ToDecimal(dt.Rows[0]["ATIVO"]);
            if ((dt.Rows[0]["DESCRICAO"] != null) && (dt.Rows[0]["DESCRICAO"] != DBNull.Value)) entity.Descricao = Convert.ToString(dt.Rows[0]["DESCRICAO"]);
            return entity;
        }
        //====================================================================
        public static DTO.ProjGenEmailDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting ATIVO Object"); }
        }
        //====================================================================
        public static List<ProjGenEmailDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<ProjGenEmailDTO> list = OracleDataTools.LoadEntity<ProjGenEmailDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjGenEmailDTO>"); }
        }
        //====================================================================
        public static List<ProjGenEmailDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjGenEmailDTO>"); }
        }
        //====================================================================
        public static List<ProjGenEmailDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<ProjGenEmailDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 0";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionProjGenEmail"); }
        }
        //====================================================================
        public static DTO.CollectionProjGenEmailDTO GetCollection(DataTable dt)
        {
            DTO.CollectionProjGenEmailDTO collection = new DTO.CollectionProjGenEmailDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.ProjGenEmailDTO entity = new DTO.ProjGenEmailDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["TIPO_DESTINATARIO"].ToString().Length != 0) entity.TipoDestinatario = dt.Rows[i]["TIPO_DESTINATARIO"].ToString();
                    if (dt.Rows[i]["DISCIPLINA"].ToString().Length != 0) entity.Disciplina = dt.Rows[i]["DISCIPLINA"].ToString();
                    if (dt.Rows[i]["EMAIL"].ToString().Length != 0) entity.Email = dt.Rows[i]["EMAIL"].ToString();
                    if (dt.Rows[i]["ATIVO"].ToString().Length != 0) entity.Ativo = Convert.ToDecimal(dt.Rows[i]["ATIVO"]);
                    if (dt.Rows[i]["DESCRICAO"].ToString().Length != 0) entity.Descricao = dt.Rows[i]["DESCRICAO"].ToString();
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
            dict.Add("TipoDestinatario", "TIPO_DESTINATARIO");
            dict.Add("Disciplina", "DISCIPLINA");
            dict.Add("Email", "EMAIL");
            dict.Add("Ativo", "ATIVO");
            dict.Add("Descricao", "DESCRICAO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
