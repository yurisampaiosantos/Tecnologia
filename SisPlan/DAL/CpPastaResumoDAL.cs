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
    public class CpPastaResumoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.PARE_ID, X.PARE_SBCN_SIGLA, X.PARE_LOCA_DESCRICAO, X.PARE_SMGR_DESCRICAO, X.PARE_AREA_DESCRICAO, X.PARE_CASCO_MEC, X.PARE_CASCO_TUB, X.PARE_CASCO_ELE, X.PARE_CASCO_INS, X.PARE_CASCO_TLC, X.PARE_CASCO_TOTAL, X.PARE_ERPR_MEC, X.PARE_ERPR_TUB, X.PARE_ERPR_ELE, X.PARE_ERPR_INS, X.PARE_ERPR_TLC, X.PARE_ERPR_TOTAL, X.PARE_MS_MEC, X.PARE_MS_TUB, X.PARE_MS_ELE, X.PARE_MS_INS, X.PARE_MS_TLC, X.PARE_MS_TOTAL, X.PARE_MA_MEC, X.PARE_MA_TUB, X.PARE_MA_ELE, X.PARE_MA_INS, X.PARE_MA_TLC, X.PARE_MA_TOTAL, X.PARE_TOTAL_MEC, X.PARE_TOTAL_TUB, X.PARE_TOTAL_ELE, X.PARE_TOTAL_INS, X.PARE_TOTAL_TLC, X.PARE_TOTAL_TOTAL FROM EEP_CONVERSION.CP_PASTA_RESUMO X ";
        //====================================================================
        public static int Insert(DTO.CpPastaResumoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO(PARE_SBCN_SIGLA,PARE_LOCA_DESCRICAO,PARE_SMGR_DESCRICAO,PARE_AREA_DESCRICAO,PARE_CASCO_MEC,PARE_CASCO_TUB,PARE_CASCO_ELE,PARE_CASCO_INS,PARE_CASCO_TLC,PARE_CASCO_TOTAL,PARE_ERPR_MEC,PARE_ERPR_TUB,PARE_ERPR_ELE,PARE_ERPR_INS,PARE_ERPR_TLC,PARE_ERPR_TOTAL,PARE_MS_MEC,PARE_MS_TUB,PARE_MS_ELE,PARE_MS_INS,PARE_MS_TLC,PARE_MS_TOTAL,PARE_MA_MEC,PARE_MA_TUB,PARE_MA_ELE,PARE_MA_INS,PARE_MA_TLC,PARE_MA_TOTAL,PARE_TOTAL_MEC,PARE_TOTAL_TUB,PARE_TOTAL_ELE,PARE_TOTAL_INS,PARE_TOTAL_TLC,PARE_TOTAL_TOTAL) VALUES(:PARE_SBCN_SIGLA,:PARE_LOCA_DESCRICAO,:PARE_SMGR_DESCRICAO,:PARE_AREA_DESCRICAO,:PARE_CASCO_MEC,:PARE_CASCO_TUB,:PARE_CASCO_ELE,:PARE_CASCO_INS,:PARE_CASCO_TLC,:PARE_CASCO_TOTAL,:PARE_ERPR_MEC,:PARE_ERPR_TUB,:PARE_ERPR_ELE,:PARE_ERPR_INS,:PARE_ERPR_TLC,:PARE_ERPR_TOTAL,:PARE_MS_MEC,:PARE_MS_TUB,:PARE_MS_ELE,:PARE_MS_INS,:PARE_MS_TLC,:PARE_MS_TOTAL,:PARE_MA_MEC,:PARE_MA_TUB,:PARE_MA_ELE,:PARE_MA_INS,:PARE_MA_TLC,:PARE_MA_TOTAL,:PARE_TOTAL_MEC,:PARE_TOTAL_TUB,:PARE_TOTAL_ELE,:PARE_TOTAL_INS,:PARE_TOTAL_TLC,:PARE_TOTAL_TOTAL)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PARE_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PareSbcnSigla;
                cmd.Parameters.Add(":PARE_LOCA_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareLocaDescricao;
                cmd.Parameters.Add(":PARE_SMGR_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareSmgrDescricao;
                cmd.Parameters.Add(":PARE_AREA_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareAreaDescricao;
                
                cmd.Parameters.Add(":PARE_CASCO_MEC", OracleDbType.Decimal).Value = entity.PareCascoMec;
                cmd.Parameters.Add(":PARE_CASCO_TUB", OracleDbType.Decimal).Value = entity.PareCascoTub;
                cmd.Parameters.Add(":PARE_CASCO_ELE", OracleDbType.Decimal).Value = entity.PareCascoEle;
                cmd.Parameters.Add(":PARE_CASCO_INS", OracleDbType.Decimal).Value = entity.PareCascoIns;
                cmd.Parameters.Add(":PARE_CASCO_TLC", OracleDbType.Decimal).Value = entity.PareCascoTlc;
                cmd.Parameters.Add(":PARE_CASCO_TOTAL", OracleDbType.Decimal).Value = entity.PareCascoTotal;
                cmd.Parameters.Add(":PARE_ERPR_MEC", OracleDbType.Decimal).Value = entity.PareErprMec;
                cmd.Parameters.Add(":PARE_ERPR_TUB", OracleDbType.Decimal).Value = entity.PareErprTub;
                cmd.Parameters.Add(":PARE_ERPR_ELE", OracleDbType.Decimal).Value = entity.PareErprEle;
                cmd.Parameters.Add(":PARE_ERPR_INS", OracleDbType.Decimal).Value = entity.PareErprIns;
                cmd.Parameters.Add(":PARE_ERPR_TLC", OracleDbType.Decimal).Value = entity.PareErprTlc;
                cmd.Parameters.Add(":PARE_ERPR_TOTAL", OracleDbType.Decimal).Value = entity.PareErprTotal;
                cmd.Parameters.Add(":PARE_MS_MEC", OracleDbType.Decimal).Value = entity.PareMsMec;
                cmd.Parameters.Add(":PARE_MS_TUB", OracleDbType.Decimal).Value = entity.PareMsTub;
                cmd.Parameters.Add(":PARE_MS_ELE", OracleDbType.Decimal).Value = entity.PareMsEle;
                cmd.Parameters.Add(":PARE_MS_INS", OracleDbType.Decimal).Value = entity.PareMsIns;
                cmd.Parameters.Add(":PARE_MS_TLC", OracleDbType.Decimal).Value = entity.PareMsTlc;
                cmd.Parameters.Add(":PARE_MS_TOTAL", OracleDbType.Decimal).Value = entity.PareMsTotal;
                cmd.Parameters.Add(":PARE_MA_MEC", OracleDbType.Decimal).Value = entity.PareMaMec;
                cmd.Parameters.Add(":PARE_MA_TUB", OracleDbType.Decimal).Value = entity.PareMaTub;
                cmd.Parameters.Add(":PARE_MA_ELE", OracleDbType.Decimal).Value = entity.PareMaEle;
                cmd.Parameters.Add(":PARE_MA_INS", OracleDbType.Decimal).Value = entity.PareMaIns;
                cmd.Parameters.Add(":PARE_MA_TLC", OracleDbType.Decimal).Value = entity.PareMaTlc;
                cmd.Parameters.Add(":PARE_MA_TOTAL", OracleDbType.Decimal).Value = entity.PareMaTotal;
                cmd.Parameters.Add(":PARE_TOTAL_MEC", OracleDbType.Decimal).Value = entity.PareTotalMec;
                cmd.Parameters.Add(":PARE_TOTAL_TUB", OracleDbType.Decimal).Value = entity.PareTotalTub;
                cmd.Parameters.Add(":PARE_TOTAL_ELE", OracleDbType.Decimal).Value = entity.PareTotalEle;
                cmd.Parameters.Add(":PARE_TOTAL_INS", OracleDbType.Decimal).Value = entity.PareTotalIns;
                cmd.Parameters.Add(":PARE_TOTAL_TLC", OracleDbType.Decimal).Value = entity.PareTotalTlc;
                cmd.Parameters.Add(":PARE_TOTAL_TOTAL", OracleDbType.Decimal).Value = entity.PareTotalTotal;
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting CpPastaResumo");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting CpPastaResumo");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.CpPastaResumoDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.CP_PASTA_RESUMO set PARE_SBCN_SIGLA = :PARE_SBCN_SIGLA, PARE_LOCA_DESCRICAO = :PARE_LOCA_DESCRICAO, PARE_SMGR_DESCRICAO = :PARE_SMGR_DESCRICAO, PARE_AREA_DESCRICAO = :PARE_AREA_DESCRICAO, PARE_CASCO_MEC = :PARE_CASCO_MEC, PARE_CASCO_TUB = :PARE_CASCO_TUB, PARE_CASCO_ELE = :PARE_CASCO_ELE, PARE_CASCO_INS = :PARE_CASCO_INS, PARE_CASCO_TLC = :PARE_CASCO_TLC, PARE_CASCO_TOTAL = :PARE_CASCO_TOTAL, PARE_ERPR_MEC = :PARE_ERPR_MEC, PARE_ERPR_TUB = :PARE_ERPR_TUB, PARE_ERPR_ELE = :PARE_ERPR_ELE, PARE_ERPR_INS = :PARE_ERPR_INS, PARE_ERPR_TLC = :PARE_ERPR_TLC, PARE_ERPR_TOTAL = :PARE_ERPR_TOTAL, PARE_MS_MEC = :PARE_MS_MEC, PARE_MS_TUB = :PARE_MS_TUB, PARE_MS_ELE = :PARE_MS_ELE, PARE_MS_INS = :PARE_MS_INS, PARE_MS_TLC = :PARE_MS_TLC, PARE_MS_TOTAL = :PARE_MS_TOTAL, PARE_MA_MEC = :PARE_MA_MEC, PARE_MA_TUB = :PARE_MA_TUB, PARE_MA_ELE = :PARE_MA_ELE, PARE_MA_INS = :PARE_MA_INS, PARE_MA_TLC = :PARE_MA_TLC, PARE_MA_TOTAL = :PARE_MA_TOTAL, PARE_TOTAL_MEC = :PARE_TOTAL_MEC, PARE_TOTAL_TUB = :PARE_TOTAL_TUB, PARE_TOTAL_ELE = :PARE_TOTAL_ELE, PARE_TOTAL_INS = :PARE_TOTAL_INS, PARE_TOTAL_TLC = :PARE_TOTAL_TLC, PARE_TOTAL_TOTAL = :PARE_TOTAL_TOTAL WHERE  PARE_ID = :PARE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PARE_SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.PareSbcnSigla;
                cmd.Parameters.Add(":PARE_LOCA_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareLocaDescricao;
                cmd.Parameters.Add(":PARE_SMGR_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareSmgrDescricao;
                cmd.Parameters.Add(":PARE_AREA_DESCRICAO", OracleDbType.Varchar2).Value = entity.PareAreaDescricao;
                
                cmd.Parameters.Add(":PARE_CASCO_MEC", OracleDbType.Decimal).Value = entity.PareCascoMec;
                cmd.Parameters.Add(":PARE_CASCO_TUB", OracleDbType.Decimal).Value = entity.PareCascoTub;
                cmd.Parameters.Add(":PARE_CASCO_ELE", OracleDbType.Decimal).Value = entity.PareCascoEle;
                cmd.Parameters.Add(":PARE_CASCO_INS", OracleDbType.Decimal).Value = entity.PareCascoIns;
                cmd.Parameters.Add(":PARE_CASCO_TLC", OracleDbType.Decimal).Value = entity.PareCascoTlc;
                cmd.Parameters.Add(":PARE_CASCO_TOTAL", OracleDbType.Decimal).Value = entity.PareCascoTotal;
                cmd.Parameters.Add(":PARE_ERPR_MEC", OracleDbType.Decimal).Value = entity.PareErprMec;
                cmd.Parameters.Add(":PARE_ERPR_TUB", OracleDbType.Decimal).Value = entity.PareErprTub;
                cmd.Parameters.Add(":PARE_ERPR_ELE", OracleDbType.Decimal).Value = entity.PareErprEle;
                cmd.Parameters.Add(":PARE_ERPR_INS", OracleDbType.Decimal).Value = entity.PareErprIns;
                cmd.Parameters.Add(":PARE_ERPR_TLC", OracleDbType.Decimal).Value = entity.PareErprTlc;
                cmd.Parameters.Add(":PARE_ERPR_TOTAL", OracleDbType.Decimal).Value = entity.PareErprTotal;
                cmd.Parameters.Add(":PARE_MS_MEC", OracleDbType.Decimal).Value = entity.PareMsMec;
                cmd.Parameters.Add(":PARE_MS_TUB", OracleDbType.Decimal).Value = entity.PareMsTub;
                cmd.Parameters.Add(":PARE_MS_ELE", OracleDbType.Decimal).Value = entity.PareMsEle;
                cmd.Parameters.Add(":PARE_MS_INS", OracleDbType.Decimal).Value = entity.PareMsIns;
                cmd.Parameters.Add(":PARE_MS_TLC", OracleDbType.Decimal).Value = entity.PareMsTlc;
                cmd.Parameters.Add(":PARE_MS_TOTAL", OracleDbType.Decimal).Value = entity.PareMsTotal;
                cmd.Parameters.Add(":PARE_MA_MEC", OracleDbType.Decimal).Value = entity.PareMaMec;
                cmd.Parameters.Add(":PARE_MA_TUB", OracleDbType.Decimal).Value = entity.PareMaTub;
                cmd.Parameters.Add(":PARE_MA_ELE", OracleDbType.Decimal).Value = entity.PareMaEle;
                cmd.Parameters.Add(":PARE_MA_INS", OracleDbType.Decimal).Value = entity.PareMaIns;
                cmd.Parameters.Add(":PARE_MA_TLC", OracleDbType.Decimal).Value = entity.PareMaTlc;
                cmd.Parameters.Add(":PARE_MA_TOTAL", OracleDbType.Decimal).Value = entity.PareMaTotal;
                cmd.Parameters.Add(":PARE_TOTAL_MEC", OracleDbType.Decimal).Value = entity.PareTotalMec;
                cmd.Parameters.Add(":PARE_TOTAL_TUB", OracleDbType.Decimal).Value = entity.PareTotalTub;
                cmd.Parameters.Add(":PARE_TOTAL_ELE", OracleDbType.Decimal).Value = entity.PareTotalEle;
                cmd.Parameters.Add(":PARE_TOTAL_INS", OracleDbType.Decimal).Value = entity.PareTotalIns;
                cmd.Parameters.Add(":PARE_TOTAL_TLC", OracleDbType.Decimal).Value = entity.PareTotalTlc;
                cmd.Parameters.Add(":PARE_TOTAL_TOTAL", OracleDbType.Decimal).Value = entity.PareTotalTotal;
                cmd.Parameters.Add(":PARE_ID", OracleDbType.Decimal).Value = entity.PareId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating CpPastaResumo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal PareId)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.CP_PASTA_RESUMO WHERE PARE_ID = :PARE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":PareId", OracleDbType.Decimal).Value = PareId;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting CpPastaResumo"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPastaResumo"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.CP_PASTA_RESUMO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting CpPastaResumo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPastaResumo"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction CpPastaResumo"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableCpPastaResumo"); }
        }
        //====================================================================
        public static DTO.CpPastaResumoDTO Get(decimal PareId)
        {
            CpPastaResumoDTO entity = new CpPastaResumoDTO();
            DataTable dt = null;
            string filter = "PARE_ID = " + PareId;
            dt = Get(filter, null);
            if ((dt.Rows[0]["PARE_ID"] != null) && (dt.Rows[0]["PARE_ID"] != DBNull.Value)) entity.PareId = Convert.ToDecimal(dt.Rows[0]["PARE_ID"]);
            if ((dt.Rows[0]["PARE_SBCN_SIGLA"] != null) && (dt.Rows[0]["PARE_SBCN_SIGLA"] != DBNull.Value)) entity.PareSbcnSigla = Convert.ToString(dt.Rows[0]["PARE_SBCN_SIGLA"]);
            if ((dt.Rows[0]["PARE_LOCA_DESCRICAO"] != null) && (dt.Rows[0]["PARE_LOCA_DESCRICAO"] != DBNull.Value)) entity.PareLocaDescricao = Convert.ToString(dt.Rows[0]["PARE_LOCA_DESCRICAO"]);
            if ((dt.Rows[0]["PARE_SMGR_DESCRICAO"] != null) && (dt.Rows[0]["PARE_SMGR_DESCRICAO"] != DBNull.Value)) entity.PareSmgrDescricao = Convert.ToString(dt.Rows[0]["PARE_SMGR_DESCRICAO"]);
            if ((dt.Rows[0]["PARE_AREA_DESCRICAO"] != null) && (dt.Rows[0]["PARE_AREA_DESCRICAO"] != DBNull.Value)) entity.PareAreaDescricao = Convert.ToString(dt.Rows[0]["PARE_AREA_DESCRICAO"]);
            
            if ((dt.Rows[0]["PARE_CASCO_MEC"] != null) && (dt.Rows[0]["PARE_CASCO_MEC"] != DBNull.Value)) entity.PareCascoMec = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_MEC"]);
            if ((dt.Rows[0]["PARE_CASCO_TUB"] != null) && (dt.Rows[0]["PARE_CASCO_TUB"] != DBNull.Value)) entity.PareCascoTub = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_TUB"]);
            if ((dt.Rows[0]["PARE_CASCO_ELE"] != null) && (dt.Rows[0]["PARE_CASCO_ELE"] != DBNull.Value)) entity.PareCascoEle = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_ELE"]);
            if ((dt.Rows[0]["PARE_CASCO_INS"] != null) && (dt.Rows[0]["PARE_CASCO_INS"] != DBNull.Value)) entity.PareCascoIns = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_INS"]);
            if ((dt.Rows[0]["PARE_CASCO_TLC"] != null) && (dt.Rows[0]["PARE_CASCO_TLC"] != DBNull.Value)) entity.PareCascoTlc = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_TLC"]);
            if ((dt.Rows[0]["PARE_CASCO_TOTAL"] != null) && (dt.Rows[0]["PARE_CASCO_TOTAL"] != DBNull.Value)) entity.PareCascoTotal = Convert.ToDecimal(dt.Rows[0]["PARE_CASCO_TOTAL"]);
            if ((dt.Rows[0]["PARE_ERPR_MEC"] != null) && (dt.Rows[0]["PARE_ERPR_MEC"] != DBNull.Value)) entity.PareErprMec = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_MEC"]);
            if ((dt.Rows[0]["PARE_ERPR_TUB"] != null) && (dt.Rows[0]["PARE_ERPR_TUB"] != DBNull.Value)) entity.PareErprTub = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_TUB"]);
            if ((dt.Rows[0]["PARE_ERPR_ELE"] != null) && (dt.Rows[0]["PARE_ERPR_ELE"] != DBNull.Value)) entity.PareErprEle = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_ELE"]);
            if ((dt.Rows[0]["PARE_ERPR_INS"] != null) && (dt.Rows[0]["PARE_ERPR_INS"] != DBNull.Value)) entity.PareErprIns = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_INS"]);
            if ((dt.Rows[0]["PARE_ERPR_TLC"] != null) && (dt.Rows[0]["PARE_ERPR_TLC"] != DBNull.Value)) entity.PareErprTlc = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_TLC"]);
            if ((dt.Rows[0]["PARE_ERPR_TOTAL"] != null) && (dt.Rows[0]["PARE_ERPR_TOTAL"] != DBNull.Value)) entity.PareErprTotal = Convert.ToDecimal(dt.Rows[0]["PARE_ERPR_TOTAL"]);
            if ((dt.Rows[0]["PARE_MS_MEC"] != null) && (dt.Rows[0]["PARE_MS_MEC"] != DBNull.Value)) entity.PareMsMec = Convert.ToDecimal(dt.Rows[0]["PARE_MS_MEC"]);
            if ((dt.Rows[0]["PARE_MS_TUB"] != null) && (dt.Rows[0]["PARE_MS_TUB"] != DBNull.Value)) entity.PareMsTub = Convert.ToDecimal(dt.Rows[0]["PARE_MS_TUB"]);
            if ((dt.Rows[0]["PARE_MS_ELE"] != null) && (dt.Rows[0]["PARE_MS_ELE"] != DBNull.Value)) entity.PareMsEle = Convert.ToDecimal(dt.Rows[0]["PARE_MS_ELE"]);
            if ((dt.Rows[0]["PARE_MS_INS"] != null) && (dt.Rows[0]["PARE_MS_INS"] != DBNull.Value)) entity.PareMsIns = Convert.ToDecimal(dt.Rows[0]["PARE_MS_INS"]);
            if ((dt.Rows[0]["PARE_MS_TLC"] != null) && (dt.Rows[0]["PARE_MS_TLC"] != DBNull.Value)) entity.PareMsTlc = Convert.ToDecimal(dt.Rows[0]["PARE_MS_TLC"]);
            if ((dt.Rows[0]["PARE_MS_TOTAL"] != null) && (dt.Rows[0]["PARE_MS_TOTAL"] != DBNull.Value)) entity.PareMsTotal = Convert.ToDecimal(dt.Rows[0]["PARE_MS_TOTAL"]);
            if ((dt.Rows[0]["PARE_MA_MEC"] != null) && (dt.Rows[0]["PARE_MA_MEC"] != DBNull.Value)) entity.PareMaMec = Convert.ToDecimal(dt.Rows[0]["PARE_MA_MEC"]);
            if ((dt.Rows[0]["PARE_MA_TUB"] != null) && (dt.Rows[0]["PARE_MA_TUB"] != DBNull.Value)) entity.PareMaTub = Convert.ToDecimal(dt.Rows[0]["PARE_MA_TUB"]);
            if ((dt.Rows[0]["PARE_MA_ELE"] != null) && (dt.Rows[0]["PARE_MA_ELE"] != DBNull.Value)) entity.PareMaEle = Convert.ToDecimal(dt.Rows[0]["PARE_MA_ELE"]);
            if ((dt.Rows[0]["PARE_MA_INS"] != null) && (dt.Rows[0]["PARE_MA_INS"] != DBNull.Value)) entity.PareMaIns = Convert.ToDecimal(dt.Rows[0]["PARE_MA_INS"]);
            if ((dt.Rows[0]["PARE_MA_TLC"] != null) && (dt.Rows[0]["PARE_MA_TLC"] != DBNull.Value)) entity.PareMaTlc = Convert.ToDecimal(dt.Rows[0]["PARE_MA_TLC"]);
            if ((dt.Rows[0]["PARE_MA_TOTAL"] != null) && (dt.Rows[0]["PARE_MA_TOTAL"] != DBNull.Value)) entity.PareMaTotal = Convert.ToDecimal(dt.Rows[0]["PARE_MA_TOTAL"]);
            if ((dt.Rows[0]["PARE_TOTAL_MEC"] != null) && (dt.Rows[0]["PARE_TOTAL_MEC"] != DBNull.Value)) entity.PareTotalMec = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_MEC"]);
            if ((dt.Rows[0]["PARE_TOTAL_TUB"] != null) && (dt.Rows[0]["PARE_TOTAL_TUB"] != DBNull.Value)) entity.PareTotalTub = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_TUB"]);
            if ((dt.Rows[0]["PARE_TOTAL_ELE"] != null) && (dt.Rows[0]["PARE_TOTAL_ELE"] != DBNull.Value)) entity.PareTotalEle = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_ELE"]);
            if ((dt.Rows[0]["PARE_TOTAL_INS"] != null) && (dt.Rows[0]["PARE_TOTAL_INS"] != DBNull.Value)) entity.PareTotalIns = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_INS"]);
            if ((dt.Rows[0]["PARE_TOTAL_TLC"] != null) && (dt.Rows[0]["PARE_TOTAL_TLC"] != DBNull.Value)) entity.PareTotalTlc = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_TLC"]);
            if ((dt.Rows[0]["PARE_TOTAL_TOTAL"] != null) && (dt.Rows[0]["PARE_TOTAL_TOTAL"] != DBNull.Value)) entity.PareTotalTotal = Convert.ToDecimal(dt.Rows[0]["PARE_TOTAL_TOTAL"]);
            return entity;
        }
        //====================================================================
        public static DTO.CpPastaResumoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting PARE_TOTAL_TOTAL Object"); }
        }
        //====================================================================
        public static List<CpPastaResumoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<CpPastaResumoDTO> list = OracleDataTools.LoadEntity<CpPastaResumoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoDTO>"); }
        }
        //====================================================================
        public static List<CpPastaResumoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoDTO>"); }
        }
        //====================================================================
        public static List<CpPastaResumoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<CpPastaResumoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaResumoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionCpPastaResumo"); }
        }
        //====================================================================
        public static DTO.CollectionCpPastaResumoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionCpPastaResumoDTO collection = new DTO.CollectionCpPastaResumoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.CpPastaResumoDTO entity = new DTO.CpPastaResumoDTO();
                    if (dt.Rows[i]["PARE_ID"].ToString().Length != 0) entity.PareId = Convert.ToDecimal(dt.Rows[i]["PARE_ID"]);
                    if (dt.Rows[i]["PARE_SBCN_SIGLA"].ToString().Length != 0) entity.PareSbcnSigla = dt.Rows[i]["PARE_SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["PARE_LOCA_DESCRICAO"].ToString().Length != 0) entity.PareLocaDescricao = dt.Rows[i]["PARE_LOCA_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PARE_SMGR_DESCRICAO"].ToString().Length != 0) entity.PareSmgrDescricao = dt.Rows[i]["PARE_SMGR_DESCRICAO"].ToString();
                    if (dt.Rows[i]["PARE_AREA_DESCRICAO"].ToString().Length != 0) entity.PareAreaDescricao = dt.Rows[i]["PARE_AREA_DESCRICAO"].ToString();

                    if (dt.Rows[i]["PARE_CASCO_MEC"].ToString().Length != 0) entity.PareCascoMec = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_MEC"]);
                    if (dt.Rows[i]["PARE_CASCO_TUB"].ToString().Length != 0) entity.PareCascoTub = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_TUB"]);
                    if (dt.Rows[i]["PARE_CASCO_ELE"].ToString().Length != 0) entity.PareCascoEle = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_ELE"]);
                    if (dt.Rows[i]["PARE_CASCO_INS"].ToString().Length != 0) entity.PareCascoIns = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_INS"]);
                    if (dt.Rows[i]["PARE_CASCO_TLC"].ToString().Length != 0) entity.PareCascoTlc = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_TLC"]);
                    if (dt.Rows[i]["PARE_CASCO_TOTAL"].ToString().Length != 0) entity.PareCascoTotal = Convert.ToDecimal(dt.Rows[i]["PARE_CASCO_TOTAL"]);
                    if (dt.Rows[i]["PARE_ERPR_MEC"].ToString().Length != 0) entity.PareErprMec = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_MEC"]);
                    if (dt.Rows[i]["PARE_ERPR_TUB"].ToString().Length != 0) entity.PareErprTub = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_TUB"]);
                    if (dt.Rows[i]["PARE_ERPR_ELE"].ToString().Length != 0) entity.PareErprEle = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_ELE"]);
                    if (dt.Rows[i]["PARE_ERPR_INS"].ToString().Length != 0) entity.PareErprIns = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_INS"]);
                    if (dt.Rows[i]["PARE_ERPR_TLC"].ToString().Length != 0) entity.PareErprTlc = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_TLC"]);
                    if (dt.Rows[i]["PARE_ERPR_TOTAL"].ToString().Length != 0) entity.PareErprTotal = Convert.ToDecimal(dt.Rows[i]["PARE_ERPR_TOTAL"]);
                    if (dt.Rows[i]["PARE_MS_MEC"].ToString().Length != 0) entity.PareMsMec = Convert.ToDecimal(dt.Rows[i]["PARE_MS_MEC"]);
                    if (dt.Rows[i]["PARE_MS_TUB"].ToString().Length != 0) entity.PareMsTub = Convert.ToDecimal(dt.Rows[i]["PARE_MS_TUB"]);
                    if (dt.Rows[i]["PARE_MS_ELE"].ToString().Length != 0) entity.PareMsEle = Convert.ToDecimal(dt.Rows[i]["PARE_MS_ELE"]);
                    if (dt.Rows[i]["PARE_MS_INS"].ToString().Length != 0) entity.PareMsIns = Convert.ToDecimal(dt.Rows[i]["PARE_MS_INS"]);
                    if (dt.Rows[i]["PARE_MS_TLC"].ToString().Length != 0) entity.PareMsTlc = Convert.ToDecimal(dt.Rows[i]["PARE_MS_TLC"]);
                    if (dt.Rows[i]["PARE_MS_TOTAL"].ToString().Length != 0) entity.PareMsTotal = Convert.ToDecimal(dt.Rows[i]["PARE_MS_TOTAL"]);
                    if (dt.Rows[i]["PARE_MA_MEC"].ToString().Length != 0) entity.PareMaMec = Convert.ToDecimal(dt.Rows[i]["PARE_MA_MEC"]);
                    if (dt.Rows[i]["PARE_MA_TUB"].ToString().Length != 0) entity.PareMaTub = Convert.ToDecimal(dt.Rows[i]["PARE_MA_TUB"]);
                    if (dt.Rows[i]["PARE_MA_ELE"].ToString().Length != 0) entity.PareMaEle = Convert.ToDecimal(dt.Rows[i]["PARE_MA_ELE"]);
                    if (dt.Rows[i]["PARE_MA_INS"].ToString().Length != 0) entity.PareMaIns = Convert.ToDecimal(dt.Rows[i]["PARE_MA_INS"]);
                    if (dt.Rows[i]["PARE_MA_TLC"].ToString().Length != 0) entity.PareMaTlc = Convert.ToDecimal(dt.Rows[i]["PARE_MA_TLC"]);
                    if (dt.Rows[i]["PARE_MA_TOTAL"].ToString().Length != 0) entity.PareMaTotal = Convert.ToDecimal(dt.Rows[i]["PARE_MA_TOTAL"]);
                    if (dt.Rows[i]["PARE_TOTAL_MEC"].ToString().Length != 0) entity.PareTotalMec = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_MEC"]);
                    if (dt.Rows[i]["PARE_TOTAL_TUB"].ToString().Length != 0) entity.PareTotalTub = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_TUB"]);
                    if (dt.Rows[i]["PARE_TOTAL_ELE"].ToString().Length != 0) entity.PareTotalEle = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_ELE"]);
                    if (dt.Rows[i]["PARE_TOTAL_INS"].ToString().Length != 0) entity.PareTotalIns = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_INS"]);
                    if (dt.Rows[i]["PARE_TOTAL_TLC"].ToString().Length != 0) entity.PareTotalTlc = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_TLC"]);
                    if (dt.Rows[i]["PARE_TOTAL_TOTAL"].ToString().Length != 0) entity.PareTotalTotal = Convert.ToDecimal(dt.Rows[i]["PARE_TOTAL_TOTAL"]);

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
