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
    public class AcGrupoCriterioDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.GRCR_CNTR_CODIGO, X.GRCR_ID, X.GRCR_GRUPO_SIGLA, X.GRCR_NOME, X.GRCR_SEQUENCE, X.GRCR_GRUPO_DESCRICAO FROM EEP_CONVERSION.AC_GRUPO_CRITERIO X ";
        //====================================================================
        public static int Insert(DTO.AcGrupoCriterioDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_GRUPO_CRITERIO(GRCR_ID,GRCR_GRUPO_SIGLA,GRCR_NOME,GRCR_SEQUENCE,GRCR_GRUPO_DESCRICAO) VALUES(?,:GRCR_ID,:GRCR_GRUPO_SIGLA,:GRCR_NOME,:GRCR_SEQUENCE,:GRCR_GRUPO_DESCRICAO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":GRCR_CNTR_CODIGO", OracleDbType.Int32).Value = entity.GrcrCntrCodigo;
                cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                cmd.Parameters.Add(":GRCR_SEQUENCE", OracleDbType.Int32).Value = entity.GrcrSequence;
                cmd.Parameters.Add(":GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.GrcrGrupoDescricao;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcGrupoCriterio");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcGrupoCriterio");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcGrupoCriterioDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_GRUPO_CRITERIO set GRCR_CNTR_CODIGO = :GRCR_CNTR_CODIGO, L, GRCR_GRUPO_SIGLA = :GRCR_GRUPO_SIGLA, GRCR_NOME = :GRCR_NOME, GRCR_SEQUENCE = :GRCR_SEQUENCE, GRCR_GRUPO_DESCRICAO = :GRCR_GRUPO_DESCRICAO WHERE GRCR_ID = : GRCR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":GRCR_CNTR_CODIGO", OracleDbType.Int32).Value = entity.GrcrCntrCodigo;
                cmd.Parameters.Add(":GRCR_GRUPO_SIGLA", OracleDbType.Varchar2).Value = entity.GrcrGrupoSigla;
                cmd.Parameters.Add(":GRCR_NOME", OracleDbType.Varchar2).Value = entity.GrcrNome;
                cmd.Parameters.Add(":GRCR_SEQUENCE", OracleDbType.Int32).Value = entity.GrcrSequence;
                cmd.Parameters.Add(":GRCR_GRUPO_DESCRICAO", OracleDbType.Varchar2).Value = entity.GrcrGrupoDescricao;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcGrupoCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal GrcrId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_GRUPO_CRITERIO WHERE  GRCR_CNTR_CODIGO = ?, GRCR_ID = : GRCR_CNTR_CODIGO = ?, GRCR_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":GrcrId", OracleDbType.Varchar2).Value = GrcrId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcGrupoCriterio"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcGrupoCriterio"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_GRUPO_CRITERIO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcGrupoCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcGrupoCriterio"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcGrupoCriterio"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //SELECT DISTINCT GRCR_GRUPO_SIGLA, GRCR_GRUPO_DESCRICAO FROM AC_GRUPO_CRITERIO ORDER BY 1
        //====================================================================
        public static DataTable SelectSiglasGrupoCriterio()
        {
            string strSQL = "SELECT DISTINCT GRCR_GRUPO_SIGLA, GRCR_GRUPO_DESCRICAO FROM EEP_CONVERSION.AC_GRUPO_CRITERIO ORDER BY 1";
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcGrupoCriterio"); }
        }
        //====================================================================
        public static DTO.AcGrupoCriterioDTO Get(decimal GrcrId)
        {
            AcGrupoCriterioDTO entity = new AcGrupoCriterioDTO();
            DataTable dt = null;
            string filter = "GRCR_ID = " + GrcrId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["GRCR_CNTR_CODIGO"] != null) && (dt.Rows[0]["GRCR_CNTR_CODIGO"] != DBNull.Value)) entity.GrcrCntrCodigo = Convert.ToString(dt.Rows[0]["GRCR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["GRCR_ID"] != null) && (dt.Rows[0]["GRCR_ID"] != DBNull.Value)) entity.GrcrId = Convert.ToDecimal(dt.Rows[0]["GRCR_ID"]);
            if ((dt.Rows[0]["GRCR_GRUPO_SIGLA"] != null) && (dt.Rows[0]["GRCR_GRUPO_SIGLA"] != DBNull.Value)) entity.GrcrGrupoSigla = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_SIGLA"]);
            if ((dt.Rows[0]["GRCR_NOME"] != null) && (dt.Rows[0]["GRCR_NOME"] != DBNull.Value)) entity.GrcrNome = Convert.ToString(dt.Rows[0]["GRCR_NOME"]);
            if ((dt.Rows[0]["GRCR_SEQUENCE"] != null) && (dt.Rows[0]["GRCR_SEQUENCE"] != DBNull.Value)) entity.GrcrSequence = Convert.ToDecimal(dt.Rows[0]["GRCR_SEQUENCE"]);
            if ((dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != null) && (dt.Rows[0]["GRCR_GRUPO_DESCRICAO"] != DBNull.Value)) entity.GrcrGrupoDescricao = Convert.ToString(dt.Rows[0]["GRCR_GRUPO_DESCRICAO"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcGrupoCriterioDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting GRCR_GRUPO_DESCRICAO Object"); }
        }
        //====================================================================
        public static List<AcGrupoCriterioDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcGrupoCriterioDTO> list = OracleDataTools.LoadEntity<AcGrupoCriterioDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcGrupoCriterioDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static List<AcGrupoCriterioDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcGrupoCriterioDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                Hashtable dict = GetDictionary();
                string filterAUX = OracleDataTools.ConvertFilterSequence(filter, dict);
                string sortSequenceAUX = OracleDataTools.ConvertSortSequence(sortSequence, dict);
                if ((filterAUX == "" && filter != "") || (sortSequenceAUX == "" && sortSequence != "")) filterAUX = "1 = 1";
                return GetCollection(Get(filterAUX, sortSequenceAUX));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcGrupoCriterio"); }
        }
        //====================================================================
        public static DTO.CollectionAcGrupoCriterioDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcGrupoCriterioDTO collection = new DTO.CollectionAcGrupoCriterioDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcGrupoCriterioDTO entity = new DTO.AcGrupoCriterioDTO();
                    if (dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString().Length != 0) entity.GrcrCntrCodigo = dt.Rows[i]["GRCR_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["GRCR_ID"].ToString().Length != 0) entity.GrcrId = Convert.ToDecimal(dt.Rows[i]["GRCR_ID"]);
                    if (dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString().Length != 0) entity.GrcrGrupoSigla = dt.Rows[i]["GRCR_GRUPO_SIGLA"].ToString();
                    if (dt.Rows[i]["GRCR_NOME"].ToString().Length != 0) entity.GrcrNome = dt.Rows[i]["GRCR_NOME"].ToString();
                    if (dt.Rows[i]["GRCR_SEQUENCE"].ToString().Length != 0) entity.GrcrSequence = Convert.ToDecimal(dt.Rows[i]["GRCR_SEQUENCE"]);
                    if (dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString().Length != 0) entity.GrcrGrupoDescricao = dt.Rows[i]["GRCR_GRUPO_DESCRICAO"].ToString();

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
            dict.Add("GrcrCntrCodigo", "GRCR_CNTR_CODIGO");
            dict.Add("GrcrId", "GRCR_ID");
            dict.Add("GrcrGrupoSigla", "GRCR_GRUPO_SIGLA");
            dict.Add("GrcrNome", "GRCR_NOME");
            dict.Add("GrcrSequence", "GRCR_SEQUENCE");
            dict.Add("GrcrGrupoDescricao", "GRCR_GRUPO_DESCRICAO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
