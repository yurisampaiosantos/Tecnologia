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
    public class CpPastaResumoSubgrupoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.PRSG_ID, X.PRSG_CNTR_CODIGO, X.PRSG_SBCN_SIGLA, X.PRSG_AREA, X.PRSG_DISC_SIGLA, X.PRSG_SMGR_DESCRICAO, X.PRSG_SMSG_DESCRICAO, X.PRSG_QUANTIDADE, X.PRSG_SMGR_SEQUENCE, X.PRSG_SMSG_SEQUENCE FROM EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO X ";
        //====================================================================
        public static int Insert(DTO.CpPastaResumoSubgrupoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO(PRSG_CNTR_CODIGO,PRSG_SBCN_SIGLA,PRSG_AREA,PRSG_DISC_SIGLA,PRSG_SMGR_DESCRICAO,PRSG_SMSG_DESCRICAO,PRSG_QUANTIDADE,PRSG_SMGR_SEQUENCE,PRSG_SMSG_SEQUENCE) VALUES(:PRSG_CNTR_CODIGO,:PRSG_SBCN_SIGLA,:PRSG_AREA,:PRSG_DISC_SIGLA,:PRSG_SMGR_DESCRICAO,:PRSG_SMSG_DESCRICAO,:PRSG_QUANTIDADE,:PRSG_SMGR_SEQUENCE,:PRSG_SMSG_SEQUENCE)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PRSG_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PrsgCntrCodigo;
                cmd.Parameters.Add(":PRSG_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PrsgSbcnSigla;
                cmd.Parameters.Add(":PRSG_AREA", OracleDbType.Varchar2).Value = entity.PrsgArea;
                cmd.Parameters.Add(":PRSG_DISC_SIGLA", OracleDbType.Varchar2).Value = entity.PrsgDiscSigla;
                cmd.Parameters.Add(":PRSG_SMGR_DESCRICAO", OracleDbType.Varchar2).Value = entity.PrsgSmgrDescricao;
                cmd.Parameters.Add(":PRSG_SMSG_DESCRICAO", OracleDbType.Varchar2).Value = entity.PrsgSmsgDescricao;
                cmd.Parameters.Add(":PRSG_QUANTIDADE", OracleDbType.Decimal).Value = entity.PrsgQuantidade;
                cmd.Parameters.Add(":PRSG_SMGR_SEQUENCE", OracleDbType.Decimal).Value = entity.PrsgSmgrSequence;
                cmd.Parameters.Add(":PRSG_SMSG_SEQUENCE", OracleDbType.Decimal).Value = entity.PrsgSmsgSequence;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpPastaResumoSubgrupo");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpPastaResumoSubgrupo");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpPastaResumoSubgrupoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO set PRSG_CNTR_CODIGO = :PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA = :PRSG_SBCN_SIGLA, PRSG_AREA = :PRSG_AREA, PRSG_DISC_SIGLA = :PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO = :PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO = :PRSG_SMSG_DESCRICAO, PRSG_QUANTIDADE = :PRSG_QUANTIDADE, PRSG_SMGR_SEQUENCE = :PRSG_SMGR_SEQUENCE, PRSG_SMSG_SEQUENCE = :PRSG_SMSG_SEQUENCE WHERE  PRSG_ID = :PRSG_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PRSG_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.PrsgCntrCodigo;
                cmd.Parameters.Add(":PRSG_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PrsgSbcnSigla;
                cmd.Parameters.Add(":PRSG_AREA", OracleDbType.Varchar2).Value = entity.PrsgArea;
                cmd.Parameters.Add(":PRSG_DISC_SIGLA", OracleDbType.Varchar2).Value = entity.PrsgDiscSigla;
                cmd.Parameters.Add(":PRSG_SMGR_DESCRICAO", OracleDbType.Varchar2).Value = entity.PrsgSmgrDescricao;
                cmd.Parameters.Add(":PRSG_SMSG_DESCRICAO", OracleDbType.Varchar2).Value = entity.PrsgSmsgDescricao;
                cmd.Parameters.Add(":PRSG_QUANTIDADE", OracleDbType.Decimal).Value = entity.PrsgQuantidade;
                cmd.Parameters.Add(":PRSG_SMGR_SEQUENCE", OracleDbType.Decimal).Value = entity.PrsgSmgrSequence;
                cmd.Parameters.Add(":PRSG_SMSG_SEQUENCE", OracleDbType.Decimal).Value = entity.PrsgSmsgSequence;
                cmd.Parameters.Add(":PrsgId", OracleDbType.Decimal).Value = entity.PrsgId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpPastaResumoSubgrupo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal PrsgId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO WHERE PRSG_ID = :PRSG_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PrsgId", OracleDbType.Decimal).Value = PrsgId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpPastaResumoSubgrupo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPastaResumoSubgrupo"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPastaResumoSubgrupo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPastaResumoSubgrupo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPastaResumoSubgrupo"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpPastaResumoSubgrupo"); }
        }
        //====================================================================
        public static DTO.CpPastaResumoSubgrupoDTO Get(decimal PrsgId)
        {
            CpPastaResumoSubgrupoDTO entity = new CpPastaResumoSubgrupoDTO();
            DataTable dt = null;
            string filter = "PRSG_ID = " + PrsgId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PRSG_ID"] != null) && (dt.Rows[0]["PRSG_ID"] != DBNull.Value)) entity.PrsgId = Convert.ToDecimal(dt.Rows[0]["PRSG_ID"]);
            if ((dt.Rows[0]["PRSG_CNTR_CODIGO"] != null) && (dt.Rows[0]["PRSG_CNTR_CODIGO"] != DBNull.Value)) entity.PrsgCntrCodigo = Convert.ToString(dt.Rows[0]["PRSG_CNTR_CODIGO"]);
            if ((dt.Rows[0]["PRSG_SBCN_SIGLA"] != null) && (dt.Rows[0]["PRSG_SBCN_SIGLA"] != DBNull.Value)) entity.PrsgSbcnSigla = Convert.ToString(dt.Rows[0]["PRSG_SBCN_SIGLA"]);
            if ((dt.Rows[0]["PRSG_AREA"] != null) && (dt.Rows[0]["PRSG_AREA"] != DBNull.Value)) entity.PrsgArea = Convert.ToString(dt.Rows[0]["PRSG_AREA"]);
            if ((dt.Rows[0]["PRSG_DISC_SIGLA"] != null) && (dt.Rows[0]["PRSG_DISC_SIGLA"] != DBNull.Value)) entity.PrsgDiscSigla = Convert.ToString(dt.Rows[0]["PRSG_DISC_SIGLA"]);
            if ((dt.Rows[0]["PRSG_SMGR_DESCRICAO"] != null) && (dt.Rows[0]["PRSG_SMGR_DESCRICAO"] != DBNull.Value)) entity.PrsgSmgrDescricao = Convert.ToString(dt.Rows[0]["PRSG_SMGR_DESCRICAO"]);
            if ((dt.Rows[0]["PRSG_SMSG_DESCRICAO"] != null) && (dt.Rows[0]["PRSG_SMSG_DESCRICAO"] != DBNull.Value)) entity.PrsgSmsgDescricao = Convert.ToString(dt.Rows[0]["PRSG_SMSG_DESCRICAO"]);
            if ((dt.Rows[0]["PRSG_QUANTIDADE"] != null) && (dt.Rows[0]["PRSG_QUANTIDADE"] != DBNull.Value)) entity.PrsgQuantidade = Convert.ToDecimal(dt.Rows[0]["PRSG_QUANTIDADE"]);
            if ((dt.Rows[0]["PRSG_SMGR_SEQUENCE"] != null) && (dt.Rows[0]["PRSG_SMGR_SEQUENCE"] != DBNull.Value)) entity.PrsgSmgrSequence = Convert.ToDecimal(dt.Rows[0]["PRSG_SMGR_SEQUENCE"]);
            if ((dt.Rows[0]["PRSG_SMSG_SEQUENCE"] != null) && (dt.Rows[0]["PRSG_SMSG_SEQUENCE"] != DBNull.Value)) entity.PrsgSmsgSequence = Convert.ToDecimal(dt.Rows[0]["PRSG_SMSG_SEQUENCE"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpPastaResumoSubgrupoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PRSG_SMSG_SEQUENCE Object"); }
        }
        //====================================================================
        public static List<CpPastaResumoSubgrupoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpPastaResumoSubgrupoDTO> list = OracleDataTools.LoadEntity<CpPastaResumoSubgrupoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoSubgrupoDTO>"); }
        }
        //====================================================================
        public static List<CpPastaResumoSubgrupoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoSubgrupoDTO>"); }
        }
        //====================================================================
        public static List<CpPastaResumoSubgrupoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoSubgrupoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaResumoSubgrupoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpPastaResumoSubgrupo"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaResumoSubgrupoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpPastaResumoSubgrupoDTO collection = new DTO.CollectionCpPastaResumoSubgrupoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpPastaResumoSubgrupoDTO entity = new DTO.CpPastaResumoSubgrupoDTO();
                    if (dt.Rows[i]["PRSG_ID"].ToString().Length != 0) entity.PrsgId = Convert.ToDecimal(dt.Rows[i]["PRSG_ID"]);
                    if (dt.Rows[i]["PRSG_CNTR_CODIGO"].ToString().Length != 0) entity.PrsgCntrCodigo = dt.Rows[i]["PRSG_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["PRSG_SBCN_SIGLA"].ToString().Length != 0) entity.PrsgSbcnSigla = dt.Rows[i]["PRSG_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["PRSG_AREA"].ToString().Length != 0) entity.PrsgArea = dt.Rows[i]["PRSG_AREA"].ToString();
                    if (dt.Rows[i]["PRSG_DISC_SIGLA"].ToString().Length != 0) entity.PrsgDiscSigla = dt.Rows[i]["PRSG_DISC_SIGLA"].ToString();
                    if (dt.Rows[i]["PRSG_SMGR_DESCRICAO"].ToString().Length != 0) entity.PrsgSmgrDescricao = dt.Rows[i]["PRSG_SMGR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PRSG_SMSG_DESCRICAO"].ToString().Length != 0) entity.PrsgSmsgDescricao = dt.Rows[i]["PRSG_SMSG_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PRSG_QUANTIDADE"].ToString().Length != 0) entity.PrsgQuantidade = Convert.ToDecimal(dt.Rows[i]["PRSG_QUANTIDADE"]);
                    if (dt.Rows[i]["PRSG_SMGR_SEQUENCE"].ToString().Length != 0) entity.PrsgSmgrSequence = Convert.ToDecimal(dt.Rows[i]["PRSG_SMGR_SEQUENCE"]);
                    if (dt.Rows[i]["PRSG_SMSG_SEQUENCE"].ToString().Length != 0) entity.PrsgSmsgSequence = Convert.ToDecimal(dt.Rows[i]["PRSG_SMSG_SEQUENCE"]);

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
