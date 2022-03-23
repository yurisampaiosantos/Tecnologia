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
    public class AcPrevisaoEngenhariaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.PENG_ID, X.PENG_UNIDADE_REGIONAL, X.PENG_PECAS, X.PENG_PESO, X.PENG_SEQUENCE FROM EEP_CONVERSION.AC_PREVISAO_ENGENHARIA X ";
        //====================================================================
        public static int Insert(DTO.AcPrevisaoEngenhariaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_PREVISAO_ENGENHARIA(PENG_UNIDADE_REGIONAL,PENG_PECAS,PENG_PESO,PENG_SEQUENCE) VALUES(:PENG_UNIDADE_REGIONAL,:PENG_PECAS,:PENG_PESO,:PENG_SEQUENCE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PENG_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.PengUnidadeRegional;
                cmd.Parameters.Add(":PENG_PECAS", OracleDbType.Decimal).Value = entity.PengPecas;
                cmd.Parameters.Add(":PENG_PESO", OracleDbType.Decimal).Value = entity.PengPeso;
                cmd.Parameters.Add(":PENG_SEQUENCE", OracleDbType.Decimal).Value = entity.PengSequence;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcPrevisaoEngenharia");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcPrevisaoEngenharia");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcPrevisaoEngenhariaDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_PREVISAO_ENGENHARIA set PENG_UNIDADE_REGIONAL = :PENG_UNIDADE_REGIONAL, PENG_PECAS = :PENG_PECAS, PENG_PESO = :PENG_PESO, PENG_SEQUENCE = :PENG_SEQUENCE WHERE  PENG_ID = : PENG_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("PENG_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.PengUnidadeRegional;
                cmd.Parameters.Add("PENG_PECAS", OracleDbType.Decimal).Value = entity.PengPecas;
                cmd.Parameters.Add("PENG_PESO", OracleDbType.Decimal).Value = entity.PengPeso;
                cmd.Parameters.Add("PENG_SEQUENCE", OracleDbType.Decimal).Value = entity.PengSequence;
                cmd.Parameters.Add("PENG_ID", OracleDbType.Decimal).Value = entity.PengId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcPrevisaoEngenharia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal PengId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_PREVISAO_ENGENHARIA WHERE  PENG_ID = : PENG_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PengId", OracleDbType.Decimal).Value = PengId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcPrevisaoEngenharia"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPrevisaoEngenharia"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_PREVISAO_ENGENHARIA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPrevisaoEngenharia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPrevisaoEngenharia"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPrevisaoEngenharia"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcPrevisaoEngenharia"); }
        }
        //====================================================================
        public static DTO.AcPrevisaoEngenhariaDTO Get(decimal PengId)
        {
            AcPrevisaoEngenhariaDTO entity = new AcPrevisaoEngenhariaDTO();
            DataTable dt = null;
            string filter = "PENG_ID = " + PengId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PENG_ID"] != null) && (dt.Rows[0]["PENG_ID"] != DBNull.Value)) entity.PengId = Convert.ToDecimal(dt.Rows[0]["PENG_ID"]);
            if ((dt.Rows[0]["PENG_UNIDADE_REGIONAL"] != null) && (dt.Rows[0]["PENG_UNIDADE_REGIONAL"] != DBNull.Value)) entity.PengUnidadeRegional = Convert.ToString(dt.Rows[0]["PENG_UNIDADE_REGIONAL"]);
            if ((dt.Rows[0]["PENG_PECAS"] != null) && (dt.Rows[0]["PENG_PECAS"] != DBNull.Value)) entity.PengPecas = Convert.ToDecimal(dt.Rows[0]["PENG_PECAS"]);
            if ((dt.Rows[0]["PENG_PESO"] != null) && (dt.Rows[0]["PENG_PESO"] != DBNull.Value)) entity.PengPeso = Convert.ToDecimal(dt.Rows[0]["PENG_PESO"]);
            if ((dt.Rows[0]["PENG_SEQUENCE"] != null) && (dt.Rows[0]["PENG_SEQUENCE"] != DBNull.Value)) entity.PengSequence = Convert.ToDecimal(dt.Rows[0]["PENG_SEQUENCE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcPrevisaoEngenhariaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PENG_SEQUENCE Object"); }
        }
        //====================================================================
        public static List<AcPrevisaoEngenhariaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcPrevisaoEngenhariaDTO> list = OracleDataTools.LoadEntity<AcPrevisaoEngenhariaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPrevisaoEngenhariaDTO>"); }
        }
        //====================================================================
        public static List<AcPrevisaoEngenhariaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPrevisaoEngenhariaDTO>"); }
        }
        //====================================================================
        public static List<AcPrevisaoEngenhariaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPrevisaoEngenhariaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcPrevisaoEngenhariaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcPrevisaoEngenharia"); }
        }
        //====================================================================
        public static DTO.CollectionAcPrevisaoEngenhariaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcPrevisaoEngenhariaDTO collection = new DTO.CollectionAcPrevisaoEngenhariaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcPrevisaoEngenhariaDTO entity = new DTO.AcPrevisaoEngenhariaDTO();
                    if (dt.Rows[i]["PENG_ID"].ToString().Length != 0) entity.PengId = Convert.ToDecimal(dt.Rows[i]["PENG_ID"]);
                    if (dt.Rows[i]["PENG_UNIDADE_REGIONAL"].ToString().Length != 0) entity.PengUnidadeRegional = dt.Rows[i]["PENG_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["PENG_PECAS"].ToString().Length != 0) entity.PengPecas = Convert.ToDecimal(dt.Rows[i]["PENG_PECAS"]);
                    if (dt.Rows[i]["PENG_PESO"].ToString().Length != 0) entity.PengPeso = Convert.ToDecimal(dt.Rows[i]["PENG_PESO"]);
                    if (dt.Rows[i]["PENG_SEQUENCE"].ToString().Length != 0) entity.PengSequence = Convert.ToDecimal(dt.Rows[i]["PENG_SEQUENCE"]);

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
            dict.Add("PengId", "PENG_ID");
            dict.Add("PengUnidadeRegional", "PENG_UNIDADE_REGIONAL");
            dict.Add("PengPecas", "PENG_PECAS");
            dict.Add("PengPeso", "PENG_PESO");
            dict.Add("PengSequence", "PENG_SEQUENCE");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
