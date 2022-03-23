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
    public class CpUsuarioDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.USUA_ID, X.USUA_LOGIN, X.USUA_LOCA_ID, X.USUA_EMAIL, X.USUA_CLASSE, X.USUA_ACTIVE, X.USUA_CLASSE_DESCRICAO, X.USUA_OBSERVACAO, X.USUA_AG_CRIAR_PUNCH, X.USUA_AG_CLASS_PUNCH, X.USUA_AG_STATUS_PUNCH, X.USUA_AG_CRIAR_PENDMAT, X.USUA_AG_STATUS_PENDMAT FROM EEP_CONVERSION.CP_USUARIO X ";
        //====================================================================
        public static int Insert(DTO.CpUsuarioDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_USUARIO(USUA_LOGIN,USUA_LOCA_ID,USUA_EMAIL,USUA_CLASSE,USUA_ACTIVE,USUA_CLASSE_DESCRICAO,USUA_OBSERVACAO,USUA_AG_CRIAR_PUNCH,USUA_AG_CLASS_PUNCH,USUA_AG_STATUS_PUNCH,USUA_AG_CRIAR_PENDMAT,USUA_AG_STATUS_PENDMAT) VALUES(:USUA_LOGIN,:USUA_LOCA_ID,:USUA_EMAIL,:USUA_CLASSE,:USUA_ACTIVE,:USUA_CLASSE_DESCRICAO,:USUA_OBSERVACAO,:USUA_AG_CRIAR_PUNCH,:USUA_AG_CLASS_PUNCH,:USUA_AG_STATUS_PUNCH,:USUA_AG_CRIAR_PENDMAT,:USUA_AG_STATUS_PENDMAT)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":USUA_LOGIN", OracleDbType.Varchar2).Value = entity.UsuaLogin;
                cmd.Parameters.Add(":USUA_LOCA_ID", OracleDbType.Decimal).Value = entity.UsuaLocaId;
                cmd.Parameters.Add(":USUA_EMAIL", OracleDbType.Varchar2).Value = entity.UsuaEmail;
                cmd.Parameters.Add(":USUA_CLASSE", OracleDbType.Decimal).Value = entity.UsuaClasse;
                cmd.Parameters.Add(":USUA_ACTIVE", OracleDbType.Decimal).Value = entity.UsuaActive;
                cmd.Parameters.Add(":USUA_CLASSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.UsuaClasseDescricao;
                cmd.Parameters.Add(":USUA_OBSERVACAO", OracleDbType.Varchar2).Value = entity.UsuaObservacao;
                cmd.Parameters.Add(":USUA_AG_CRIAR_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgCriarPunch;
                cmd.Parameters.Add(":USUA_AG_CLASS_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgClassPunch;
                cmd.Parameters.Add(":USUA_AG_STATUS_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgStatusPunch;
                cmd.Parameters.Add(":USUA_AG_CRIAR_PENDMAT", OracleDbType.Decimal).Value = entity.UsuaAgCriarPendmat;
                cmd.Parameters.Add(":USUA_AG_STATUS_PENDMAT", OracleDbType.Decimal).Value = entity.UsuaAgStatusPendmat;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpUsuario");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpUsuario");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpUsuarioDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_USUARIO set USUA_LOGIN = :USUA_LOGIN, USUA_LOCA_ID = :USUA_LOCA_ID, USUA_EMAIL = :USUA_EMAIL, USUA_CLASSE = :USUA_CLASSE, USUA_ACTIVE = :USUA_ACTIVE, USUA_CLASSE_DESCRICAO = :USUA_CLASSE_DESCRICAO, USUA_OBSERVACAO = :USUA_OBSERVACAO, USUA_AG_CRIAR_PUNCH = :USUA_AG_CRIAR_PUNCH, USUA_AG_CLASS_PUNCH = :USUA_AG_CLASS_PUNCH, USUA_AG_STATUS_PUNCH = :USUA_AG_STATUS_PUNCH, USUA_AG_CRIAR_PENDMAT = :USUA_AG_CRIAR_PENDMAT, USUA_AG_STATUS_PENDMAT = :USUA_AG_STATUS_PENDMAT WHERE  USUA_ID = :USUA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":USUA_LOGIN", OracleDbType.Varchar2).Value = entity.UsuaLogin;
                cmd.Parameters.Add(":USUA_LOCA_ID", OracleDbType.Decimal).Value = entity.UsuaLocaId;
                cmd.Parameters.Add(":USUA_EMAIL", OracleDbType.Varchar2).Value = entity.UsuaEmail;
                cmd.Parameters.Add(":USUA_CLASSE", OracleDbType.Decimal).Value = entity.UsuaClasse;
                cmd.Parameters.Add(":USUA_ACTIVE", OracleDbType.Decimal).Value = entity.UsuaActive;
                cmd.Parameters.Add(":USUA_CLASSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.UsuaClasseDescricao;
                cmd.Parameters.Add(":USUA_OBSERVACAO", OracleDbType.Varchar2).Value = entity.UsuaObservacao;
                cmd.Parameters.Add(":USUA_AG_CRIAR_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgCriarPunch;
                cmd.Parameters.Add(":USUA_AG_CLASS_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgClassPunch;
                cmd.Parameters.Add(":USUA_AG_STATUS_PUNCH", OracleDbType.Decimal).Value = entity.UsuaAgStatusPunch;
                cmd.Parameters.Add(":USUA_AG_CRIAR_PENDMAT", OracleDbType.Decimal).Value = entity.UsuaAgCriarPendmat;
                cmd.Parameters.Add(":USUA_AG_STATUS_PENDMAT", OracleDbType.Decimal).Value = entity.UsuaAgStatusPendmat;
                cmd.Parameters.Add(":USUA_ID", OracleDbType.Decimal).Value = entity.UsuaId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpUsuario"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal UsuaId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_USUARIO WHERE USUA_ID = :USUA_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":UsuaId", OracleDbType.Decimal).Value = UsuaId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpUsuario"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpUsuario"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_USUARIO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpUsuario"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpUsuario"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpUsuario"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpUsuario"); }
        }
        //====================================================================
        public static DTO.CpUsuarioDTO Get(decimal UsuaId)
        {
            CpUsuarioDTO entity = new CpUsuarioDTO();
            DataTable dt = null;
            string filter = "USUA_ID = " + UsuaId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["USUA_ID"] != null) && (dt.Rows[0]["USUA_ID"] != DBNull.Value)) entity.UsuaId = Convert.ToDecimal(dt.Rows[0]["USUA_ID"]);
            if ((dt.Rows[0]["USUA_LOGIN"] != null) && (dt.Rows[0]["USUA_LOGIN"] != DBNull.Value)) entity.UsuaLogin = Convert.ToString(dt.Rows[0]["USUA_LOGIN"]);
            if ((dt.Rows[0]["USUA_LOCA_ID"] != null) && (dt.Rows[0]["USUA_LOCA_ID"] != DBNull.Value)) entity.UsuaLocaId = Convert.ToDecimal(dt.Rows[0]["USUA_LOCA_ID"]);
            if ((dt.Rows[0]["USUA_EMAIL"] != null) && (dt.Rows[0]["USUA_EMAIL"] != DBNull.Value)) entity.UsuaEmail = Convert.ToString(dt.Rows[0]["USUA_EMAIL"]);
            if ((dt.Rows[0]["USUA_CLASSE"] != null) && (dt.Rows[0]["USUA_CLASSE"] != DBNull.Value)) entity.UsuaClasse = Convert.ToDecimal(dt.Rows[0]["USUA_CLASSE"]);
            if ((dt.Rows[0]["USUA_ACTIVE"] != null) && (dt.Rows[0]["USUA_ACTIVE"] != DBNull.Value)) entity.UsuaActive = Convert.ToDecimal(dt.Rows[0]["USUA_ACTIVE"]);
            if ((dt.Rows[0]["USUA_CLASSE_DESCRICAO"] != null) && (dt.Rows[0]["USUA_CLASSE_DESCRICAO"] != DBNull.Value)) entity.UsuaClasseDescricao = Convert.ToString(dt.Rows[0]["USUA_CLASSE_DESCRICAO"]);
            if ((dt.Rows[0]["USUA_OBSERVACAO"] != null) && (dt.Rows[0]["USUA_OBSERVACAO"] != DBNull.Value)) entity.UsuaObservacao = Convert.ToString(dt.Rows[0]["USUA_OBSERVACAO"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PUNCH"] != DBNull.Value)) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_CLASS_PUNCH"] != DBNull.Value)) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CLASS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PUNCH"] != DBNull.Value)) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PUNCH"]);
            if ((dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"] != DBNull.Value)) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_CRIAR_PENDMAT"]);
            if ((dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != null) && (dt.Rows[0]["USUA_AG_STATUS_PENDMAT"] != DBNull.Value)) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[0]["USUA_AG_STATUS_PENDMAT"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpUsuarioDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting USUA_AG_STATUS_PENDMAT Object"); }
        }
        //====================================================================
        public static List<CpUsuarioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpUsuarioDTO> list = OracleDataTools.LoadEntity<CpUsuarioDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpUsuarioDTO>"); }
        }
        //====================================================================
        public static List<CpUsuarioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpUsuarioDTO>"); }
        }
        //====================================================================
        public static List<CpUsuarioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpUsuarioDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpUsuarioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpUsuario"); }
        }
        //====================================================================
        public static DTO.CollectionCpUsuarioDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpUsuarioDTO collection = new DTO.CollectionCpUsuarioDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpUsuarioDTO entity = new DTO.CpUsuarioDTO();
                    if (dt.Rows[i]["USUA_ID"].ToString().Length != 0) entity.UsuaId = Convert.ToDecimal(dt.Rows[i]["USUA_ID"]);
                    if (dt.Rows[i]["USUA_LOGIN"].ToString().Length != 0) entity.UsuaLogin = dt.Rows[i]["USUA_LOGIN"].ToString();
                    if (dt.Rows[i]["USUA_LOCA_ID"].ToString().Length != 0) entity.UsuaLocaId = Convert.ToDecimal(dt.Rows[i]["USUA_LOCA_ID"]);
                    if (dt.Rows[i]["USUA_EMAIL"].ToString().Length != 0) entity.UsuaEmail = dt.Rows[i]["USUA_EMAIL"].ToString();
                    if (dt.Rows[i]["USUA_CLASSE"].ToString().Length != 0) entity.UsuaClasse = Convert.ToDecimal(dt.Rows[i]["USUA_CLASSE"]);
                    if (dt.Rows[i]["USUA_ACTIVE"].ToString().Length != 0) entity.UsuaActive = Convert.ToDecimal(dt.Rows[i]["USUA_ACTIVE"]);
                    if (dt.Rows[i]["USUA_CLASSE_DESCRICAO"].ToString().Length != 0) entity.UsuaClasseDescricao = dt.Rows[i]["USUA_CLASSE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["USUA_OBSERVACAO"].ToString().Length != 0) entity.UsuaObservacao = dt.Rows[i]["USUA_OBSERVACAO"].ToString();
                    if (dt.Rows[i]["USUA_AG_CRIAR_PUNCH"].ToString().Length != 0) entity.UsuaAgCriarPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CLASS_PUNCH"].ToString().Length != 0) entity.UsuaAgClassPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CLASS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PUNCH"].ToString().Length != 0) entity.UsuaAgStatusPunch = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PUNCH"]);
                    if (dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"].ToString().Length != 0) entity.UsuaAgCriarPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_CRIAR_PENDMAT"]);
                    if (dt.Rows[i]["USUA_AG_STATUS_PENDMAT"].ToString().Length != 0) entity.UsuaAgStatusPendmat = Convert.ToDecimal(dt.Rows[i]["USUA_AG_STATUS_PENDMAT"]);

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
