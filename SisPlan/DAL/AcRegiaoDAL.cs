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
    public class AcRegiaoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.REGI_ID, X.REGI_DESCRICAO, X.REGI_CNTR_CODIGO, X.REGI_SBCN_SIGLA, X.REGI_LOCALIZACAO_ID, X.REGI_SETOR_ID FROM EEP_CONVERSION.AC_REGIAO X ";
        //====================================================================
        public static int Insert(DTO.AcRegiaoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_REGIAO(REGI_DESCRICAO,REGI_CNTR_CODIGO,REGI_SBCN_SIGLA,REGI_LOCALIZACAO_ID,REGI_SETOR_ID) VALUES(:REGI_DESCRICAO,:REGI_CNTR_CODIGO,:REGI_SBCN_SIGLA,:REGI_LOCALIZACAO_ID,:REGI_SETOR_ID)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":REGI_DESCRICAO", OracleDbType.Varchar2).Value = entity.RegiDescricao;
                cmd.Parameters.Add(":REGI_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.RegiCntrCodigo;
                cmd.Parameters.Add(":REGI_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.RegiSbcnSigla;
                cmd.Parameters.Add(":REGI_LOCALIZACAO_ID", OracleDbType.Decimal).Value = entity.RegiLocalizacaoId;
                cmd.Parameters.Add(":REGI_SETOR_ID", OracleDbType.Decimal).Value = entity.RegiSetorId;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcRegiao");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcRegiao");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcRegiaoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_REGIAO set REGI_DESCRICAO = :REGI_DESCRICAO, REGI_CNTR_CODIGO = :REGI_CNTR_CODIGO, REGI_SBCN_SIGLA = :REGI_SBCN_SIGLA, REGI_LOCALIZACAO_ID = :REGI_LOCALIZACAO_ID, REGI_SETOR_ID = :REGI_SETOR_ID WHERE  REGI_ID = :REGI_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":REGI_DESCRICAO", OracleDbType.Varchar2).Value = entity.RegiDescricao;
                cmd.Parameters.Add(":REGI_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.RegiCntrCodigo;
                cmd.Parameters.Add(":REGI_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.RegiSbcnSigla;
                cmd.Parameters.Add(":REGI_LOCALIZACAO_ID", OracleDbType.Decimal).Value = entity.RegiLocalizacaoId;
                cmd.Parameters.Add(":REGI_SETOR_ID", OracleDbType.Decimal).Value = entity.RegiSetorId;
                cmd.Parameters.Add(":REGI_ID", OracleDbType.Decimal).Value = entity.RegiId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcRegiao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal RegiId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_REGIAO WHERE REGI_ID = :REGI_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":RegiId", OracleDbType.Decimal).Value = RegiId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcRegiao"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRegiao"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_REGIAO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcRegiao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRegiao"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcRegiao"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcRegiao"); }
        }
        //====================================================================
        public static DTO.AcRegiaoDTO Get(decimal RegiId)
        {
            AcRegiaoDTO entity = new AcRegiaoDTO();
            DataTable dt = null;
            string filter = "REGI_ID = " + RegiId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["REGI_ID"] != null) && (dt.Rows[0]["REGI_ID"] != DBNull.Value)) entity.RegiId = Convert.ToDecimal(dt.Rows[0]["REGI_ID"]);
            if ((dt.Rows[0]["REGI_DESCRICAO"] != null) && (dt.Rows[0]["REGI_DESCRICAO"] != DBNull.Value)) entity.RegiDescricao = Convert.ToString(dt.Rows[0]["REGI_DESCRICAO"]);
            if ((dt.Rows[0]["REGI_CNTR_CODIGO"] != null) && (dt.Rows[0]["REGI_CNTR_CODIGO"] != DBNull.Value)) entity.RegiCntrCodigo = Convert.ToString(dt.Rows[0]["REGI_CNTR_CODIGO"]);
            if ((dt.Rows[0]["REGI_SBCN_SIGLA"] != null) && (dt.Rows[0]["REGI_SBCN_SIGLA"] != DBNull.Value)) entity.RegiSbcnSigla = Convert.ToString(dt.Rows[0]["REGI_SBCN_SIGLA"]);
            if ((dt.Rows[0]["REGI_LOCALIZACAO_ID"] != null) && (dt.Rows[0]["REGI_LOCALIZACAO_ID"] != DBNull.Value)) entity.RegiLocalizacaoId = Convert.ToDecimal(dt.Rows[0]["REGI_LOCALIZACAO_ID"]);
            if ((dt.Rows[0]["REGI_SETOR_ID"] != null) && (dt.Rows[0]["REGI_SETOR_ID"] != DBNull.Value)) entity.RegiSetorId = Convert.ToDecimal(dt.Rows[0]["REGI_SETOR_ID"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcRegiaoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting REGI_SETOR_ID Object"); }
        }
        //====================================================================
        public static List<AcRegiaoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcRegiaoDTO> list = OracleDataTools.LoadEntity<AcRegiaoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRegiaoDTO>"); }
        }
        //====================================================================
        public static List<AcRegiaoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRegiaoDTO>"); }
        }
        //====================================================================
        public static List<AcRegiaoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcRegiaoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcRegiaoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcRegiao"); }
        }
        //====================================================================
        public static DTO.CollectionAcRegiaoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcRegiaoDTO collection = new DTO.CollectionAcRegiaoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcRegiaoDTO entity = new DTO.AcRegiaoDTO();
                    if (dt.Rows[i]["REGI_ID"].ToString().Length != 0) entity.RegiId = Convert.ToDecimal(dt.Rows[i]["REGI_ID"]);
                    if (dt.Rows[i]["REGI_DESCRICAO"].ToString().Length != 0) entity.RegiDescricao = dt.Rows[i]["REGI_DESCRICAO"].ToString();
                    if (dt.Rows[i]["REGI_CNTR_CODIGO"].ToString().Length != 0) entity.RegiCntrCodigo = dt.Rows[i]["REGI_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["REGI_SBCN_SIGLA"].ToString().Length != 0) entity.RegiSbcnSigla = dt.Rows[i]["REGI_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["REGI_LOCALIZACAO_ID"].ToString().Length != 0) entity.RegiLocalizacaoId = Convert.ToDecimal(dt.Rows[i]["REGI_LOCALIZACAO_ID"]);
                    if (dt.Rows[i]["REGI_SETOR_ID"].ToString().Length != 0) entity.RegiSetorId = Convert.ToDecimal(dt.Rows[i]["REGI_SETOR_ID"]);

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
