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
    public class AcPendenciaMaterialDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        //                                            TO_CHAR(X.REPI_DT_NECESSIDADE,'DD/MM/YYYY') AS REPI_DT_NECESSIDADE, 
        static string strSelect = @"SELECT 
                                            X.ID, X.DCMN_NUMERO, X.DCMN_TITULO, X.DIPC_CODIGO, X.DIPI_DESCRICAO_RES, 
                                            X.DIPR_PESO, X.DIPR_DIMENSOES, X.DIPR_DIM1, X.DIPR_DIM2, X.DIPR_DIM3, X.REPI_ITEM, 
                                            X.REPI_QTD_TOTAL, X.FSIT_QTD_REAL, X.AFIT_ITEM, 
                                            X.AFIT_QTD_TOTAL, X.AUFO_ID, X.AUFO_NUMERO, TO_CHAR(X.AUFO_DT_EMISSAO,'DD/MM/YYYY') AS AUFO_DT_EMISSAO, TO_CHAR(X.AFIC_CONTRATUAL,'DD/MM/YYYY') AS AFIC_CONTRATUAL, 
                                            X.DIPQ_QTD_AF, X.UNME_SIGLA, X.PRAZOS, X.ENTREGAS, X.EMPR_NOME,
                                            X.NFIT_QTD, 
                                            TO_CHAR(X.NOFI_DT_RECEBIMENTO,'DD/MM/YYYY') AS NOFI_DT_RECEBIMENTO, X.NOFI_NUMERO, 
                                            X.NOEN_NUMERO, TO_CHAR(X.NOEN_DT_EMISSAO,'DD/MM/YYYY') AS NOEN_DT_EMISSAO, X.NOEN_OBS, 
                                            X.NOEI_ITEM, X.NOEI_QTD_NEM, 
                                            X.DISC_NOME, X.SBCN_SIGLA,  X.STATUS,  
                                            X.QTD_RDR,  X.DADOS_RDR 
                                      FROM  EEP_CONVERSION.AC_PENDENCIA_MATERIAL X ";
        public static int Insert(DTO.AcPendenciaMaterialDTO entity, bool getIdentity)
        {
            //SLD_COMPRA, SLD_ENTREGA, SLD_LIBERADO, SLD_NECESSIDADE, 
            //:SLD_COMPRA, :SLD_ENTREGA, :SLD_LIBERADO, :SLD_NECESSIDADE, 

            string strSQL = @"INSERT INTO EEP_CONVERSION.AC_PENDENCIA_MATERIAL
                                        (
                                        ID, DCMN_NUMERO, DCMN_TITULO, DIPC_CODIGO, DIPI_DESCRICAO_RES, 
                                        DIPR_PESO, DIPR_DIMENSOES, DIPR_DIM1, DIPR_DIM2, DIPR_DIM3, REPI_ITEM, 
                                        REPI_QTD_TOTAL, FSIT_QTD_REAL, AFIT_ITEM, 
                                        AFIT_QTD_TOTAL, AUFO_ID, AUFO_NUMERO, AUFO_DT_EMISSAO, AFIC_CONTRATUAL, 
                                        DIPQ_QTD_AF, UNME_SIGLA, PRAZOS, ENTREGAS, EMPR_NOME, 
                                        NFIT_QTD, 
                                        NOFI_DT_RECEBIMENTO, NOFI_NUMERO, 
                                        NOEN_NUMERO, NOEN_DT_EMISSAO, NOEN_OBS, 
                                        NOEI_ITEM, NOEI_QTD_NEM, 
                                        DISC_NOME, SBCN_SIGLA, STATUS,  
                                        QTD_RDR,  DADOS_RDR
                                        ) 
                              VALUES 
                                        (
                                        :ID, :DCMN_NUMERO, :DCMN_TITULO, :DIPC_CODIGO, :DIPI_DESCRICAO_RES, 
                                        :DIPR_PESO, :DIPR_DIMENSOES, :DIPR_DIM1, :DIPR_DIM2, :DIPR_DIM3, :REPI_ITEM, 
                                        :REPI_QTD_TOTAL, :FSIT_QTD_REAL, :AFIT_ITEM, 
                                        :AFIT_QTD_TOTAL, :AUFO_ID, :AUFO_NUMERO, :AUFO_DT_EMISSAO, :AFIC_CONTRATUAL, 
                                        :DIPQ_QTD_AF, :UNME_SIGLA, :PRAZOS, :ENTREGAS, :EMPR_NOME, 
                                        :NFIT_QTD, 
                                        :NOFI_DT_RECEBIMENTO, :NOFI_NUMERO, 
                                        :NOEN_NUMERO, :NOEN_DT_EMISSAO, :NOEN_OBS, 
                                        :NOEI_ITEM, :NOEI_QTD_NEM, 
                                        :DISC_NOME, :SBCN_SIGLA, :STATUS, 
                                        :QTD_RDR,  :DADOS_RDR
                                        )";


            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;
                cmd.Parameters.Add(":DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
                cmd.Parameters.Add(":DCMN_TITULO", OracleDbType.Varchar2).Value = entity.DcmnTitulo;
                cmd.Parameters.Add(":DIPC_CODIGO", OracleDbType.Varchar2).Value = entity.DipcCodigo;
                cmd.Parameters.Add(":DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;

                cmd.Parameters.Add(":DIPR_PESO", OracleDbType.Decimal).Value = entity.DiprPeso;
                cmd.Parameters.Add(":DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.DiprDimensoes;
                cmd.Parameters.Add(":DIPR_DIM1", OracleDbType.Varchar2).Value = entity.DiprDim1;
                cmd.Parameters.Add(":DIPR_DIM2", OracleDbType.Varchar2).Value = entity.DiprDim2;
                cmd.Parameters.Add(":DIPR_DIM3", OracleDbType.Varchar2).Value = entity.DiprDim3;
                cmd.Parameters.Add(":REPI_ITEM", OracleDbType.Decimal).Value = entity.RepiItem;
                
                cmd.Parameters.Add(":REPI_QTD_TOTAL", OracleDbType.Decimal).Value = entity.RepiQtdTotal;
                cmd.Parameters.Add(":FSIT_QTD_REAL", OracleDbType.Decimal).Value = entity.FsitQtdReal;
                cmd.Parameters.Add(":AFIT_ITEM", OracleDbType.Decimal).Value = entity.AfitItem;

                cmd.Parameters.Add(":AFIT_QTD_TOTAL", OracleDbType.Decimal).Value = entity.AfitQtdTotal;
                cmd.Parameters.Add(":AUFO_ID", OracleDbType.Decimal).Value = entity.AufoId;
                cmd.Parameters.Add(":AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.AufoNumero;
                if (entity.AufoDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
                if (entity.AficContratual.ToOADate() == 0.0) cmd.Parameters.Add(":AFIC_CONTRATUAL", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":AFIC_CONTRATUAL", OracleDbType.Date).Value = entity.AficContratual;


                cmd.Parameters.Add(":DIPQ_QTD_AF", OracleDbType.Decimal).Value = entity.DipqQtdAf;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":PRAZOS", OracleDbType.Varchar2).Value = entity.Prazos;
                cmd.Parameters.Add(":ENTREGAS", OracleDbType.Varchar2).Value = entity.Entregas;
                cmd.Parameters.Add(":EMPR_NOME", OracleDbType.Varchar2).Value = entity.EmprNome;

                cmd.Parameters.Add(":NFIT_QTD", OracleDbType.Decimal).Value = entity.NfitQtd;

                //cmd.Parameters.Add(":SLD_COMPRA", OracleDbType.Decimal).Value = entity.SldCompra;
                //cmd.Parameters.Add(":SLD_ENTREGA", OracleDbType.Decimal).Value = entity.SldEntrega;
                //cmd.Parameters.Add(":SLD_LIBERADO", OracleDbType.Decimal).Value = entity.SldLiberado;
                //cmd.Parameters.Add(":SLD_NECESSIDADE", OracleDbType.Decimal).Value = entity.SldNecessidade;
                
                if (entity.NofiDtRecebimento.ToOADate() == 0.0) cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
                cmd.Parameters.Add(":NOFI_NUMERO", OracleDbType.Varchar2).Value = entity.NofiNumero;
                
                cmd.Parameters.Add(":NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.NoenNumero;
                if (entity.NoenDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":NOEN_DT_EMISSAO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":NOEN_DT_EMISSAO", OracleDbType.Date).Value = entity.NoenDtEmissao;
                cmd.Parameters.Add(":NOEN_OBS", OracleDbType.Varchar2).Value = entity.NoenObs;

                cmd.Parameters.Add(":NOEI_ITEM", OracleDbType.Decimal).Value = entity.NoeiItem;
                cmd.Parameters.Add(":NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.NoeiQtdNem;


                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":STATUS", OracleDbType.Varchar2).Value = entity.Status;

                cmd.Parameters.Add(":QTD_RDR", OracleDbType.Decimal).Value = entity.QtdRDR;
                cmd.Parameters.Add(":DAOS_RDR", OracleDbType.Varchar2).Value = entity.DadosRDR;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcPendenciaMaterial");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcPendenciaMaterial");
                }
            }
            finally { cmd.Dispose(); }
        }
        ////====================================================================
        //public static void Update(DTO.AcPendenciaMaterialDTO entity)
        //{
        //    string strSQL = "UPDATE EEP_CONVERSION.AC_PENDENCIA_MATERIAL set DCMN_NUMERO = :DCMN_NUMERO, DCMN_TITULO = :DCMN_TITULO, DIPC_CODIGO = :DIPC_CODIGO, DIPI_DESCRICAO_RES = :DIPI_DESCRICAO_RES, DIPR_PESO = :DIPR_PESO, REPI_ITEM = :REPI_ITEM, REPI_DT_NECESSIDADE = :REPI_DT_NECESSIDADE, REPI_QTD_TOTAL = :REPI_QTD_TOTAL, DIPQ_QTD_RM = :DIPQ_QTD_RM, AFIT_ITEM = :AFIT_ITEM, AFIT_QTD_TOTAL = :AFIT_QTD_TOTAL, AFIT_DT_PREV_OBRA = :AFIT_DT_PREV_OBRA, AUFO_ID = :AUFO_ID, AUFO_NUMERO = :AUFO_NUMERO, AUFO_DT_EMISSAO = :AUFO_DT_EMISSAO, EMPR_NOME = :EMPR_NOME, DIPQ_QTD_AF = :DIPQ_QTD_AF, UNME_SIGLA = :UNME_SIGLA, NFIT_QTD = :NFIT_QTD, SALDO = :SALDO, NOFI_DT_RECEBIMENTO = :NOFI_DT_RECEBIMENTO, NOFI_NUMERO = :NOFI_NUMERO, NOEN_NUMERO = :NOEN_NUMERO, NOEN_DT_EMISSAO = :NOEN_DT_EMISSAO, NOEN_OBS = :NOEN_OBS, NOEI_ITEM = :NOEI_ITEM, NOEI_QTD_NEM = :NOEI_QTD_NEM, DIPQ_QTD_NE = :DIPQ_QTD_NE, DISC_NOME = :DISC_NOME, SBCN_SIGLA = :SBCN_SIGLA, STATUS = :STATUS WHERE  ID = : ID";
        //    OracleCommand cmd = new OracleCommand();
        //    cmd.CommandText = strSQL;
        //    cmd.CommandType = CommandType.Text;
        //    try
        //    {
        //        cmd.Parameters.Add(":DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
        //        cmd.Parameters.Add(":DCMN_TITULO", OracleDbType.Varchar2).Value = entity.DcmnTitulo;
        //        cmd.Parameters.Add(":DIPC_CODIGO", OracleDbType.Varchar2).Value = entity.DipcCodigo;
        //        cmd.Parameters.Add(":DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;
        //        cmd.Parameters.Add(":DIPR_PESO", OracleDbType.Decimal).Value = entity.DiprPeso;
        //        cmd.Parameters.Add(":REPI_ITEM", OracleDbType.Decimal).Value = entity.RepiItem;
        ////        if (entity.RepiDtNecessidade.ToOADate() == 0.0) cmd.Parameters.Add(":REPI_DT_NECESSIDADE", OracleDbType.Date).Value = entity.RepiDtNecessidade;
        ////        else cmd.Parameters.Add(":REPI_DT_NECESSIDADE", OracleDbType.Date).Value = entity.RepiDtNecessidade;
        //        cmd.Parameters.Add(":REPI_QTD_TOTAL", OracleDbType.Decimal).Value = entity.RepiQtdTotal;
        //        cmd.Parameters.Add(":DIPQ_QTD_RM", OracleDbType.Decimal).Value = entity.DipqQtdRm;
        //        cmd.Parameters.Add(":AFIT_ITEM", OracleDbType.Decimal).Value = entity.AfitItem;
        //        cmd.Parameters.Add(":AFIT_QTD_TOTAL", OracleDbType.Decimal).Value = entity.AfitQtdTotal;
        //        //if (entity.AfitDtPrevObra.ToOADate() == 0.0) cmd.Parameters.Add("AFIT_DT_PREV_OBRA", OracleDbType.Date).Value = entity.AfitDtPrevObra;
        //        //else cmd.Parameters.Add("AFIT_DT_PREV_OBRA", OracleDbType.Date).Value = entity.AfitDtPrevObra;
        //        cmd.Parameters.Add(":AUFO_ID", OracleDbType.Decimal).Value = entity.AufoId;
        //        cmd.Parameters.Add(":AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.AufoNumero;
        //        if (entity.AufoDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
        //        else cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;


        //        cmd.Parameters.Add(":EMPR_NOME", OracleDbType.Varchar2).Value = entity.EmprNome;
        //        cmd.Parameters.Add(":DIPQ_QTD_AF", OracleDbType.Decimal).Value = entity.DipqQtdAf;
        //        cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
        //        cmd.Parameters.Add(":NFIT_QTD", OracleDbType.Decimal).Value = entity.NfitQtd;
        //        cmd.Parameters.Add(":SALDO", OracleDbType.Decimal).Value = entity.Saldo;
        //        //if (entity.NofiDtRecebimento.ToOADate() == 0.0) cmd.Parameters.Add("NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
        //        //else cmd.Parameters.Add("NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
        //        cmd.Parameters.Add(":NOFI_NUMERO", OracleDbType.Varchar2).Value = entity.NofiNumero;
        //        cmd.Parameters.Add(":NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.NoenNumero;
        //        if (entity.NoenDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":NOEN_DT_EMISSAO", OracleDbType.Date).Value = entity.NoenDtEmissao;
        //        else cmd.Parameters.Add(":NOEN_DT_EMISSAO", OracleDbType.Date).Value = entity.NoenDtEmissao;
        //        cmd.Parameters.Add(":NOEN_OBS", OracleDbType.Varchar2).Value = entity.NoenObs;
        //        cmd.Parameters.Add(":NOEI_ITEM", OracleDbType.Decimal).Value = entity.NoeiItem;
        //        cmd.Parameters.Add(":NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.NoeiQtdNem;
        //        cmd.Parameters.Add(":DIPQ_QTD_NE", OracleDbType.Decimal).Value = entity.DipqQtdNe;
        //        cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
        //        cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
        //        cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
        //        cmd.Parameters.Add(":STATUS", OracleDbType.Varchar2).Value = entity.Status;

        //        OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcPendenciaMaterial"); }
        //    finally { cmd.Dispose(); }
        //}
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL WHERE  ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcPendenciaMaterial"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPendenciaMaterial"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcPendenciaMaterial"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPendenciaMaterial"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcPendenciaMaterial"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcPendenciaMaterial"); }
        }
        //====================================================================
        public static DTO.AcPendenciaMaterialDTO Get(decimal ID)
        {
            AcPendenciaMaterialDTO entity = new AcPendenciaMaterialDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["DCMN_NUMERO"] != null) && (dt.Rows[0]["DCMN_NUMERO"] != DBNull.Value)) entity.DcmnNumero = Convert.ToString(dt.Rows[0]["DCMN_NUMERO"]);
            if ((dt.Rows[0]["DCMN_TITULO"] != null) && (dt.Rows[0]["DCMN_TITULO"] != DBNull.Value)) entity.DcmnTitulo = Convert.ToString(dt.Rows[0]["DCMN_TITULO"]);
            if ((dt.Rows[0]["DIPC_CODIGO"] != null) && (dt.Rows[0]["DIPC_CODIGO"] != DBNull.Value)) entity.DipcCodigo = Convert.ToString(dt.Rows[0]["DIPC_CODIGO"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_RES"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_RES"] != DBNull.Value)) entity.DipiDescricaoRes = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_RES"]);
            if ((dt.Rows[0]["DIPR_DIMENSOES"] != null) && (dt.Rows[0]["DIPR_DIMENSOES"] != DBNull.Value)) entity.DiprDimensoes = Convert.ToString(dt.Rows[0]["DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["DIPR_PESO"] != null) && (dt.Rows[0]["DIPR_PESO"] != DBNull.Value)) entity.DiprPeso = Convert.ToDecimal(dt.Rows[0]["DIPR_PESO"]);
            //if ((dt.Rows[0]["DIPR_DIM1"] != null) && (dt.Rows[0]["DIPR_DIM1"] != DBNull.Value)) 
                entity.DiprDim1 = Convert.ToString(dt.Rows[0]["DIPR_DIM1"]);
            //if ((dt.Rows[0]["DIPR_DIM2"] != null) && (dt.Rows[0]["DIPR_DIM2"] != DBNull.Value)) 
                entity.DiprDim2 = Convert.ToString(dt.Rows[0]["DIPR_DIM2"]);
            //if ((dt.Rows[0]["DIPR_DIM3"] != null) && (dt.Rows[0]["DIPR_DIM3"] != DBNull.Value)) 
                entity.DiprDim3 = Convert.ToString(dt.Rows[0]["DIPR_DIM3"]);
            if ((dt.Rows[0]["REPI_ITEM"] != null) && (dt.Rows[0]["REPI_ITEM"] != DBNull.Value)) entity.RepiItem = Convert.ToDecimal(dt.Rows[0]["REPI_ITEM"]);
            if ((dt.Rows[0]["REPI_QTD_TOTAL"] != null) && (dt.Rows[0]["REPI_QTD_TOTAL"] != DBNull.Value)) entity.RepiQtdTotal = Convert.ToDecimal(dt.Rows[0]["REPI_QTD_TOTAL"]);
            if ((dt.Rows[0]["FSIT_QTD_REAL"] != null) && (dt.Rows[0]["FSIT_QTD_REAL"] != DBNull.Value)) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[0]["FSIT_QTD_REAL"]);
            if ((dt.Rows[0]["AFIT_ITEM"] != null) && (dt.Rows[0]["AFIT_ITEM"] != DBNull.Value)) entity.AfitItem = Convert.ToDecimal(dt.Rows[0]["AFIT_ITEM"]); 
            if ((dt.Rows[0]["AFIT_QTD_TOTAL"] != null) && (dt.Rows[0]["AFIT_QTD_TOTAL"] != DBNull.Value)) entity.AfitQtdTotal = Convert.ToDecimal(dt.Rows[0]["AFIT_QTD_TOTAL"]);
            if ((dt.Rows[0]["AUFO_ID"] != null) && (dt.Rows[0]["AUFO_ID"] != DBNull.Value)) entity.AufoId = Convert.ToDecimal(dt.Rows[0]["AUFO_ID"]);
            if ((dt.Rows[0]["AUFO_NUMERO"] != null) && (dt.Rows[0]["AUFO_NUMERO"] != DBNull.Value)) entity.AufoNumero = Convert.ToString(dt.Rows[0]["AUFO_NUMERO"]);
            if ((dt.Rows[0]["AUFO_DT_EMISSAO"] != null) && (dt.Rows[0]["AUFO_DT_EMISSAO"] != DBNull.Value)) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[0]["AUFO_DT_EMISSAO"]);
            if ((dt.Rows[0]["AFIC_CONTRATUAL"] != null) && (dt.Rows[0]["AFIC_CONTRATUAL"] != DBNull.Value)) entity.AficContratual = Convert.ToDateTime(dt.Rows[0]["AFIC_CONTRATUAL"]);
            if ((dt.Rows[0]["DIPQ_QTD_AF"] != null) && (dt.Rows[0]["DIPQ_QTD_AF"] != DBNull.Value)) entity.DipqQtdAf = Convert.ToDecimal(dt.Rows[0]["DIPQ_QTD_AF"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["AFIP_PRAZO"] != null) && (dt.Rows[0]["AFIP_PRAZO"] != DBNull.Value)) entity.Prazos = Convert.ToString(dt.Rows[0]["AFIP_PRAZO"]);
            if ((dt.Rows[0]["ENTREGAS"] != null) && (dt.Rows[0]["ENTREGAS"] != DBNull.Value)) entity.Entregas = Convert.ToString(dt.Rows[0]["ENTREGAS"]);
            if ((dt.Rows[0]["EMPR_NOME"] != null) && (dt.Rows[0]["EMPR_NOME"] != DBNull.Value)) entity.EmprNome = Convert.ToString(dt.Rows[0]["EMPR_NOME"]);
            if ((dt.Rows[0]["NFIT_QTD"] != null) && (dt.Rows[0]["NFIT_QTD"] != DBNull.Value)) entity.NfitQtd = Convert.ToDecimal(dt.Rows[0]["NFIT_QTD"]);

            //if ((dt.Rows[0]["SLD_COMPRA"] != null) && (dt.Rows[0]["SLD_COMPRA"] != DBNull.Value)) entity.SldCompra = Convert.ToDecimal(dt.Rows[0]["SLD_COMPRA"]);
            //if ((dt.Rows[0]["SLD_ENTREGA"] != null) && (dt.Rows[0]["SLD_ENTREGA"] != DBNull.Value)) entity.SldEntrega = Convert.ToDecimal(dt.Rows[0]["SLD_ENTREGA"]);
            //if ((dt.Rows[0]["SLD_LIBERADO"] != null) && (dt.Rows[0]["SLD_LIBERADO"] != DBNull.Value)) entity.SldLiberado = Convert.ToDecimal(dt.Rows[0]["SLD_LIBERADO"]);
            //if ((dt.Rows[0]["SLD_NECESIDADE"] != null) && (dt.Rows[0]["SLD_NECESIDADE"] != DBNull.Value)) entity.SldNecessidade = Convert.ToDecimal(dt.Rows[0]["SLD_NECESIDADE"]);
            
            if ((dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != null) && (dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != DBNull.Value)) entity.NofiDtRecebimento = Convert.ToDateTime(dt.Rows[0]["NOFI_DT_RECEBIMENTO"]);
            if ((dt.Rows[0]["NOFI_NUMERO"] != null) && (dt.Rows[0]["NOFI_NUMERO"] != DBNull.Value)) entity.NofiNumero = Convert.ToString(dt.Rows[0]["NOFI_NUMERO"]);
            if ((dt.Rows[0]["NOEN_NUMERO"] != null) && (dt.Rows[0]["NOEN_NUMERO"] != DBNull.Value)) entity.NoenNumero = Convert.ToString(dt.Rows[0]["NOEN_NUMERO"]);
            if ((dt.Rows[0]["NOEN_DT_EMISSAO"] != null) && (dt.Rows[0]["NOEN_DT_EMISSAO"] != DBNull.Value)) entity.NoenDtEmissao = Convert.ToDateTime(dt.Rows[0]["NOEN_DT_EMISSAO"]);
            if ((dt.Rows[0]["NOEN_OBS"] != null) && (dt.Rows[0]["NOEN_OBS"] != DBNull.Value)) entity.NoenObs = Convert.ToString(dt.Rows[0]["NOEN_OBS"]);
            if ((dt.Rows[0]["NOEI_ITEM"] != null) && (dt.Rows[0]["NOEI_ITEM"] != DBNull.Value)) entity.NoeiItem = Convert.ToDecimal(dt.Rows[0]["NOEI_ITEM"]);
            if ((dt.Rows[0]["NOEI_QTD_NEM"] != null) && (dt.Rows[0]["NOEI_QTD_NEM"] != DBNull.Value)) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[0]["NOEI_QTD_NEM"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["STATUS"] != null) && (dt.Rows[0]["STATUS"] != DBNull.Value)) entity.Status = Convert.ToString(dt.Rows[0]["STATUS"]);

            if ((dt.Rows[0]["QTD_RDR"] != null) && (dt.Rows[0]["QTD_RDR"] != DBNull.Value)) entity.QtdRDR = Convert.ToDecimal(dt.Rows[0]["QTD_RDR"]);
            if ((dt.Rows[0]["DADOS_RDR"] != null) && (dt.Rows[0]["DADOS_RDR"] != DBNull.Value)) entity.DadosRDR = Convert.ToString(dt.Rows[0]["DADOS_RDR"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcPendenciaMaterialDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting SBCN_SIGLA Object"); }
        }
        //====================================================================
        public static List<AcPendenciaMaterialDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcPendenciaMaterialDTO> list = OracleDataTools.LoadEntity<AcPendenciaMaterialDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaMaterialDTO>"); }
        }
        //====================================================================
        public static List<AcPendenciaMaterialDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaMaterialDTO>"); }
        }
        //====================================================================
        public static List<AcPendenciaMaterialDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcPendenciaMaterialDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcPendenciaMaterial"); }
        }
        //====================================================================
        public static DTO.CollectionAcPendenciaMaterialDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcPendenciaMaterialDTO collection = new DTO.CollectionAcPendenciaMaterialDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcPendenciaMaterialDTO entity = new DTO.AcPendenciaMaterialDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["DCMN_NUMERO"].ToString().Length != 0) entity.DcmnNumero = dt.Rows[i]["DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["DCMN_TITULO"].ToString().Length != 0) entity.DcmnTitulo = dt.Rows[i]["DCMN_TITULO"].ToString();
                    if (dt.Rows[i]["DIPC_CODIGO"].ToString().Length != 0) entity.DipcCodigo = dt.Rows[i]["DIPC_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString().Length != 0) entity.DipiDescricaoRes = dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    if (dt.Rows[i]["DIPR_PESO"].ToString().Length != 0) entity.DiprPeso = Convert.ToDecimal(dt.Rows[i]["DIPR_PESO"]);
                    if (dt.Rows[i]["DIPR_DIMENSOES"].ToString().Length != 0) entity.DiprDimensoes = Convert.ToString(dt.Rows[i]["DIPR_DIMENSOES"]);
                    if (dt.Rows[i]["DIPR_DIM1"].ToString().Length != 0) entity.DiprDim1 = Convert.ToString(dt.Rows[i]["DIPR_DIM1"]);
                    if (dt.Rows[i]["DIPR_DIM2"].ToString().Length != 0) entity.DiprDim2 = Convert.ToString(dt.Rows[i]["DIPR_DIM2"]);
                    if (dt.Rows[i]["DIPR_DIM3"].ToString().Length != 0) entity.DiprDim3 = Convert.ToString(dt.Rows[i]["DIPR_DIM3"]);
                    if (dt.Rows[i]["REPI_ITEM"].ToString().Length != 0) entity.RepiItem = Convert.ToDecimal(dt.Rows[i]["REPI_ITEM"]);
                    if (dt.Rows[i]["REPI_QTD_TOTAL"].ToString().Length != 0) entity.RepiQtdTotal = Convert.ToDecimal(dt.Rows[i]["REPI_QTD_TOTAL"]);
                    if (dt.Rows[i]["FSIT_QTD_REAL"].ToString().Length != 0) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[i]["FSIT_QTD_REAL"]);
                    if (dt.Rows[i]["AFIT_ITEM"].ToString().Length != 0) entity.AfitItem = Convert.ToDecimal(dt.Rows[i]["AFIT_ITEM"]);
                    if (dt.Rows[i]["AFIT_QTD_TOTAL"].ToString().Length != 0) entity.AfitQtdTotal = Convert.ToDecimal(dt.Rows[i]["AFIT_QTD_TOTAL"]);
                    
                    
                    if (dt.Rows[i]["AUFO_ID"].ToString().Length != 0) entity.AufoId = Convert.ToDecimal(dt.Rows[i]["AUFO_ID"]);
                    if (dt.Rows[i]["AUFO_NUMERO"].ToString().Length != 0) entity.AufoNumero = dt.Rows[i]["AUFO_NUMERO"].ToString();
                    if (dt.Rows[i]["AUFO_DT_EMISSAO"].ToString().Length != 0) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[i]["AUFO_DT_EMISSAO"]);
                    if (dt.Rows[i]["AFIC_CONTRATUAL"].ToString().Length != 0) entity.AficContratual = Convert.ToDateTime(dt.Rows[i]["AFIC_CONTRATUAL"]);
                    if (dt.Rows[i]["DIPQ_QTD_AF"].ToString().Length != 0) entity.DipqQtdAf = Convert.ToDecimal(dt.Rows[i]["DIPQ_QTD_AF"]);
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["PRAZOS"].ToString().Length != 0) entity.Prazos = Convert.ToString(dt.Rows[i]["PRAZOS"]);
                    if (dt.Rows[i]["ENTREGAS"].ToString().Length != 0) entity.Entregas = Convert.ToString(dt.Rows[i]["ENTREGAS"]);
                    if (dt.Rows[i]["EMPR_NOME"].ToString().Length != 0) entity.EmprNome = Convert.ToString(dt.Rows[i]["EMPR_NOME"]);
                    if (dt.Rows[i]["NFIT_QTD"].ToString().Length != 0) entity.NfitQtd = Convert.ToDecimal(dt.Rows[i]["NFIT_QTD"]);

                    //if (dt.Rows[i]["SLD_COMPRA"].ToString().Length != 0) entity.SldCompra = Convert.ToDecimal(dt.Rows[i]["SLD_COMPRA"]);
                    //if (dt.Rows[i]["SLD_ENTREGA"].ToString().Length != 0) entity.SldEntrega = Convert.ToDecimal(dt.Rows[i]["SLD_ENTREGA"]);
                    //if (dt.Rows[i]["SLD_LIBERADO"].ToString().Length != 0) entity.SldLiberado = Convert.ToDecimal(dt.Rows[i]["SLD_LIBERADO"]);
                    //if (dt.Rows[i]["SLD_NECESSIDADE"].ToString().Length != 0) entity.SldNecessidade = Convert.ToDecimal(dt.Rows[i]["SLD_NECESSIDADE"]);
                    
                    if (dt.Rows[i]["NOFI_DT_RECEBIMENTO"].ToString().Length != 0) entity.NofiDtRecebimento = Convert.ToDateTime(dt.Rows[i]["NOFI_DT_RECEBIMENTO"]);
                    if (dt.Rows[i]["NOFI_NUMERO"].ToString().Length != 0) entity.NofiNumero = dt.Rows[i]["NOFI_NUMERO"].ToString();
                    if (dt.Rows[i]["NOEN_NUMERO"].ToString().Length != 0) entity.NoenNumero = dt.Rows[i]["NOEN_NUMERO"].ToString();
                    if (dt.Rows[i]["NOEN_DT_EMISSAO"].ToString().Length != 0) entity.NoenDtEmissao = Convert.ToDateTime(dt.Rows[i]["NOEN_DT_EMISSAO"]);
                    if (dt.Rows[i]["NOEN_OBS"].ToString().Length != 0) entity.NoenObs = dt.Rows[i]["NOEN_OBS"].ToString();
                    if (dt.Rows[i]["NOEI_ITEM"].ToString().Length != 0) entity.NoeiItem = Convert.ToDecimal(dt.Rows[i]["NOEI_ITEM"]);
                    if (dt.Rows[i]["NOEI_QTD_NEM"].ToString().Length != 0) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[i]["NOEI_QTD_NEM"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["STATUS"].ToString().Length != 0) entity.Status = dt.Rows[i]["STATUS"].ToString();

                    if (dt.Rows[i]["QTD_RDR"].ToString().Length != 0) entity.QtdRDR = Convert.ToDecimal(dt.Rows[i]["QTD_RDR"]);
                    if (dt.Rows[i]["DADOS_RDR"].ToString().Length != 0) entity.DadosRDR = Convert.ToString(dt.Rows[i]["DADOS_RDR"]);

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
            dict.Add("DcmnNumero", "DCMN_NUMERO");
            dict.Add("DcmnTitulo", "DCMN_TITULO");
            dict.Add("DipcCodigo", "DIPC_CODIGO");
            dict.Add("DipiDescricaoRes", "DIPI_DESCRICAO_RES");
            dict.Add("DiprPeso", "DIPR_PESO");
            dict.Add("DiprDimensoes", "DIPR_DIMENSOES");
            dict.Add("DiprDim1", "DIPR_DIM1");
            dict.Add("DiprDim2", "DIPR_DIM2");
            dict.Add("DiprDim3", "DIPR_DIM3");
            dict.Add("RepiItem", "REPI_ITEM");
            //dict.Add("RepiDtNecessidade", "REPI_DT_NECESSIDADE");
            dict.Add("RepiQtdTotal", "REPI_QTD_TOTAL");
            dict.Add("DipqQtdRm", "DIPQ_QTD_RM");
            dict.Add("FsitQtdReal", "FSIT_QTD_REAL");
            dict.Add("AfitItem", "AFIT_ITEM");
            dict.Add("AfitQtdTotal", "AFIT_QTD_TOTAL");
            dict.Add("AufoId", "AUFO_ID");
            dict.Add("AufoNumero", "AUFO_NUMERO");
            dict.Add("AufoDtEmissao", "AUFO_DT_EMISSAO");
            dict.Add("AficContratual", "AFIC_CONTRATUAL");
            dict.Add("DipqQtdAf", "DIPQ_QTD_AF");
            dict.Add("UnmeSigla", "UNME_SIGLA");
            dict.Add("Prazos", "PRAZOS");
            dict.Add("Entregas", "ENTREGAS");
            dict.Add("EmprNome", "EMPR_NOME");
            dict.Add("NfitQtd", "NFIT_QTD");

            //dict.Add("SldCompra", "SLD_COMPRA");
            //dict.Add("SldEntrega", "SLD_ENTREGA");
            //dict.Add("SldLiberado", "SLD_LIBERADO");
            //dict.Add("SldNecessidade", "SLD_NECESSIDADE");

            dict.Add("NofiDtRecebimento", "NOFI_DT_RECEBIMENTO");
            dict.Add("NofiNumero", "NOFI_NUMERO");
            dict.Add("NoenNumero", "NOEN_NUMERO");
            dict.Add("NoenDtEmissao", "NOEN_DT_EMISSAO");
            dict.Add("NoenObs", "NOEN_OBS");
            dict.Add("NoeiItem", "NOEI_ITEM");
            dict.Add("NoeiQtdNem", "NOEI_QTD_NEM");
            dict.Add("DipqQtdNe", "DIPQ_QTD_NE");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("Status", "STATUS");

            dict.Add("QtdRDR", "QTD_RDR");
            dict.Add("DadosRDR", "DADOS_RDR");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
