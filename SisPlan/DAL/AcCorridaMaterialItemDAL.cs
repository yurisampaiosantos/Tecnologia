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
    public class AcCorridaMaterialItemDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.CMIT_ID, X.CMIT_COMA_ID, X.CMIT_FOSE_NUMERO, X.CMIT_DIPR_CODIGO, X.CMIT_DIPR_DIMENSOES, X.CMIT_DIPR_DESCRICAO, X.CMIT_UNME_SIGLA, X.CMIT_QTD_FS_CORRIDA, X.CMIT_QTD_A_RESERVAR, X.CMIT_STATUS, X.CMIT_CREATED_BY, TO_CHAR(X.CMIT_CREATED_DATE, 'DD/MM/YYYY HH24:MI:SS') AS CMIT_CREATED_DATE FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM X ";
        //====================================================================
        public static int Insert(DTO.AcCorridaMaterialItemDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM(CMIT_COMA_ID, CMIT_FOSE_NUMERO, CMIT_DIPR_CODIGO, CMIT_DIPR_DIMENSOES, CMIT_DIPR_DESCRICAO, CMIT_UNME_SIGLA, CMIT_QTD_FS_CORRIDA, CMIT_QTD_A_RESERVAR, CMIT_STATUS, CMIT_CREATED_BY) VALUES(:CMIT_COMA_ID, :CMIT_FOSE_NUMERO, :CMIT_DIPR_CODIGO, :CMIT_DIPR_DIMENSOES, :CMIT_DIPR_DESCRICAO, :CMIT_UNME_SIGLA, :CMIT_QTD_FS_CORRIDA, :CMIT_QTD_A_RESERVAR, :CMIT_STATUS, :CMIT_CREATED_BY)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":CMIT_COMA_ID", OracleDbType.Decimal).Value = entity.CmitComaId;
                cmd.Parameters.Add(":CMIT_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.CmitFoseNumero;
                cmd.Parameters.Add(":CMIT_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.CmitDiprCodigo;
                cmd.Parameters.Add(":CMIT_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.CmitDiprDimensoes;
                cmd.Parameters.Add(":CMIT_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.CmitDiprDescricao;
                cmd.Parameters.Add(":CMIT_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.CmitUnmeSigla;
                cmd.Parameters.Add(":CMIT_QTD_FS_CORRIDA", OracleDbType.Decimal).Value = entity.CmitQtdFsCorrida;
                cmd.Parameters.Add(":CMIT_QTD_A_RESERVAR", OracleDbType.Decimal).Value = entity.CmitQtdAReservar;
                cmd.Parameters.Add(":CMIT_STATUS", OracleDbType.Varchar2).Value = entity.CmitStatus;
                cmd.Parameters.Add(":CMIT_CREATED_BY", OracleDbType.Varchar2).Value = entity.CmitCreatedBy;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcCorridaMaterialItem");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcCorridaMaterialItem");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcCorridaMaterialItemDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM set CMIT_COMA_ID = :CMIT_COMA_ID, CMIT_FOSE_NUMERO = :CMIT_FOSE_NUMERO, CMIT_DIPR_CODIGO = :CMIT_DIPR_CODIGO, CMIT_DIPR_DIMENSOES = :CMIT_DIPR_DIMENSOES, CMIT_DIPR_DESCRICAO = :CMIT_DIPR_DESCRICAO, CMIT_UNME_SIGLA = :CMIT_UNME_SIGLA, CMIT_QTD_FS_CORRIDA = :CMIT_QTD_FS_CORRIDA, CMIT_QTD_A_RESERVAR = :CMIT_QTD_A_RESERVAR, CMIT_STATUS = :CMIT_STATUS, CMIT_CREATED_BY = :CMIT_CREATED_BY WHERE  CMIT_ID = : CMIT_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("CMIT_COMA_ID", OracleDbType.Decimal).Value = entity.CmitComaId;
                cmd.Parameters.Add("CMIT_FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.CmitFoseNumero;
                cmd.Parameters.Add("CMIT_DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.CmitDiprCodigo;
                cmd.Parameters.Add("CMIT_DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.CmitDiprDimensoes;
                cmd.Parameters.Add("CMIT_DIPR_DESCRICAO", OracleDbType.Varchar2).Value = entity.CmitDiprDescricao;
                cmd.Parameters.Add("CMIT_UNME_SIGLA", OracleDbType.Varchar2).Value = entity.CmitUnmeSigla;
                cmd.Parameters.Add("CMIT_QTD_FS_CORRIDA", OracleDbType.Decimal).Value = entity.CmitQtdFsCorrida;
                cmd.Parameters.Add("CMIT_QTD_A_RESERVAR", OracleDbType.Decimal).Value = entity.CmitQtdAReservar;
                cmd.Parameters.Add("CMIT_STATUS", OracleDbType.Varchar2).Value = entity.CmitStatus;
                cmd.Parameters.Add("CMIT_CREATED_BY", OracleDbType.NVarchar2).Value = entity.CmitCreatedBy;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcCorridaMaterialItem"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal CmitId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM WHERE  CMIT_ID = : CMIT_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":CmitId", OracleDbType.Decimal).Value = CmitId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcCorridaMaterialItem"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcCorridaMaterialItem"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcCorridaMaterialItem"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcCorridaMaterialItem"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcCorridaMaterialItem"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcCorridaMaterialItem"); }
        }
        //====================================================================
        public static DTO.AcCorridaMaterialItemDTO Get(decimal CmitId)
        {
            AcCorridaMaterialItemDTO entity = new AcCorridaMaterialItemDTO();
            DataTable dt = null;
            string filter = "CMIT_ID = " + CmitId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["CMIT_ID"] != null) && (dt.Rows[0]["CMIT_ID"] != DBNull.Value)) entity.CmitId = Convert.ToDecimal(dt.Rows[0]["CMIT_ID"]);
            if ((dt.Rows[0]["CMIT_COMA_ID"] != null) && (dt.Rows[0]["CMIT_COMA_ID"] != DBNull.Value)) entity.CmitComaId = Convert.ToDecimal(dt.Rows[0]["CMIT_COMA_ID"]);
            if ((dt.Rows[0]["CMIT_FOSE_NUMERO"] != null) && (dt.Rows[0]["CMIT_FOSE_NUMERO"] != DBNull.Value)) entity.CmitFoseNumero = Convert.ToString(dt.Rows[0]["CMIT_FOSE_NUMERO"]);
            if ((dt.Rows[0]["CMIT_DIPR_CODIGO"] != null) && (dt.Rows[0]["CMIT_DIPR_CODIGO"] != DBNull.Value)) entity.CmitDiprCodigo = Convert.ToString(dt.Rows[0]["CMIT_DIPR_CODIGO"]);
            if ((dt.Rows[0]["CMIT_DIPR_DIMENSOES"] != null) && (dt.Rows[0]["CMIT_DIPR_DIMENSOES"] != DBNull.Value)) entity.CmitDiprDimensoes = Convert.ToString(dt.Rows[0]["CMIT_DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["CMIT_DIPR_DESCRICAO"] != null) && (dt.Rows[0]["CMIT_DIPR_DESCRICAO"] != DBNull.Value)) entity.CmitDiprDescricao = Convert.ToString(dt.Rows[0]["CMIT_DIPR_DESCRICAO"]);
            if ((dt.Rows[0]["CMIT_UNME_SIGLA"] != null) && (dt.Rows[0]["CMIT_UNME_SIGLA"] != DBNull.Value)) entity.CmitUnmeSigla = Convert.ToString(dt.Rows[0]["CMIT_UNME_SIGLA"]);
            if ((dt.Rows[0]["CMIT_QTD_FS_CORRIDA"] != null) && (dt.Rows[0]["CMIT_QTD_FS_CORRIDA"] != DBNull.Value)) entity.CmitQtdFsCorrida = Convert.ToDecimal(dt.Rows[0]["CMIT_QTD_FS_CORRIDA"]);
            if ((dt.Rows[0]["CMIT_QTD_A_RESERVAR"] != null) && (dt.Rows[0]["CMIT_QTD_A_RESERVAR"] != DBNull.Value)) entity.CmitQtdAReservar = Convert.ToDecimal(dt.Rows[0]["CMIT_QTD_A_RESERVAR"]);
            if ((dt.Rows[0]["CMIT_STATUS"] != null) && (dt.Rows[0]["CMIT_STATUS"] != DBNull.Value)) entity.CmitStatus = Convert.ToString(dt.Rows[0]["CMIT_STATUS"]);
            if ((dt.Rows[0]["CMIT_CREATED_BY"] != null) && (dt.Rows[0]["CMIT_CREATED_BY"] != DBNull.Value)) entity.CmitCreatedBy = Convert.ToString(dt.Rows[0]["CMIT_CREATED_BY"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcCorridaMaterialItemDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialItemDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcCorridaMaterialItemDTO> list = OracleDataTools.LoadEntity<AcCorridaMaterialItemDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialItemDTO>"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialItemDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialItemDTO>"); }
        }
        //====================================================================
        public static List<AcCorridaMaterialItemDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcCorridaMaterialItemDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcCorridaMaterialItemDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcCorridaMaterialItem"); }
        }
        //====================================================================
        public static DTO.CollectionAcCorridaMaterialItemDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcCorridaMaterialItemDTO collection = new DTO.CollectionAcCorridaMaterialItemDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcCorridaMaterialItemDTO entity = new DTO.AcCorridaMaterialItemDTO();
                    if (dt.Rows[i]["CMIT_COMA_ID"].ToString().Length != 0) entity.CmitComaId = Convert.ToDecimal(dt.Rows[i]["CMIT_COMA_ID"]);
                    if (dt.Rows[i]["CMIT_ID"].ToString().Length != 0) entity.CmitId = Convert.ToDecimal(dt.Rows[i]["CMIT_ID"]);
                    if (dt.Rows[i]["CMIT_FOSE_NUMERO"].ToString().Length != 0) entity.CmitFoseNumero = dt.Rows[i]["CMIT_FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["CMIT_DIPR_CODIGO"].ToString().Length != 0) entity.CmitDiprCodigo = dt.Rows[i]["CMIT_DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["CMIT_DIPR_DIMENSOES"].ToString().Length != 0) entity.CmitDiprDimensoes = dt.Rows[i]["CMIT_DIPR_DIMENSOES"].ToString();
                    if (dt.Rows[i]["CMIT_DIPR_DESCRICAO"].ToString().Length != 0) entity.CmitDiprDescricao = dt.Rows[i]["CMIT_DIPR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["CMIT_UNME_SIGLA"].ToString().Length != 0) entity.CmitUnmeSigla = dt.Rows[i]["CMIT_UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["CMIT_QTD_FS_CORRIDA"].ToString().Length != 0) entity.CmitQtdFsCorrida = Convert.ToDecimal(dt.Rows[i]["CMIT_QTD_FS_CORRIDA"]);
                    if (dt.Rows[i]["CMIT_QTD_A_RESERVAR"].ToString().Length != 0) entity.CmitQtdAReservar = Convert.ToDecimal(dt.Rows[i]["CMIT_QTD_A_RESERVAR"]);
                    if (dt.Rows[i]["CMIT_STATUS"].ToString().Length != 0) entity.CmitStatus = dt.Rows[i]["CMIT_STATUS"].ToString();
                    if (dt.Rows[i]["CMIT_CREATED_BY"].ToString().Length != 0) entity.CmitCreatedBy = dt.Rows[i]["CREATED_BY"].ToString();

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
            dict.Add("CmitId", "CMIT_ID");
            dict.Add("CmitComaId", "CMIT_COMA_ID");
            dict.Add("CmitFoseNumero", "CMIT_FOSE_NUMERO");
            dict.Add("CmitDiprCodigo", "CMIT_DIPR_CODIGO");
            dict.Add("CmitDiprDimensoes", "CMIT_DIPR_DIMENSOES");
            dict.Add("CmitDiprDescricao", "CMIT_DIPR_DESCRICAO");
            dict.Add("CmitUnmeSigla", "CMIT_UNME_SIGLA");
            dict.Add("CmitQtdFsCorrida", "CMIT_QTD_FS_CORRIDA");
            dict.Add("CmitQtdAReservar", "CMIT_QTD_A_RESERVAR");
            dict.Add("CmitStatus", "CMIT_STATUS");
            dict.Add("CmitCreatedBy", "CMIT_CREATED_BY");

            return dict;
        }
        //====================================================================
        #endregion
    }
}
