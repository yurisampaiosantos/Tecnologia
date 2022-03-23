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
    public class AcStatusMateriaisDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.DIPR_CNTR_CODIGO, X.DIPR_ID, X.DIPR_PESO, X.SBCN_SIGLA, X.DISC_ID, X.DISC_NOME, X.DESC_TIPO_DICIONARIO, X.DCMN_ID, X.DCMN_NUMERO, X.REPL_REV, X.DIPR_CODIGO, X.DIPI_DESCRICAO_RES, X.UNME_SIGLA, X.REPI_QTD_TOTAL, X.DIPR_DIMENSOES, X.AUFO_NUMERO, TO_CHAR(X.AUFO_DT_EMISSAO,'DD/MM/YYYY HH24:MI:SS') AS AUFO_DT_EMISSAO, X.AUFO_EMPR_NOME, X.AFIT_QTD, X.SLD_COMPRA, X.NOFI_NUMERO, TO_CHAR(X.NOFI_DT_RECEBIMENTO,'DD/MM/YYYY HH24:MI:SS') AS NOFI_DT_RECEBIMENTO, X.NFIT_QTD, X.NOEN_NUMERO, X.NOEI_QTD_NEM, X.DVRE_NUMERO, X.ARES_SIGLA, X.SLD_NECESSIDADE, X.SLD_ENTREGA, X.FSIT_QTD_REAL, TO_CHAR(X.CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS CREATED_DATE FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL X ";
        //====================================================================
        public static int Insert(DTO.AcStatusMateriaisDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL(DIPR_CNTR_CODIGO,DIPR_ID,DIPR_PESO,SBCN_SIGLA,DISC_ID,DISC_NOME,DESC_TIPO_DICIONARIO,DCMN_ID,DCMN_NUMERO,REPL_REV,DIPR_CODIGO,DIPI_DESCRICAO_RES,UNME_SIGLA,REPI_QTD_TOTAL,DIPR_DIMENSOES,AUFO_NUMERO,AUFO_DT_EMISSAO,AUFO_EMPR_NOME,AFIT_QTD,SLD_COMPRA,NOFI_NUMERO,NOFI_DT_RECEBIMENTO,NFIT_QTD,NOEN_NUMERO,NOEI_QTD_NEM,DVRE_NUMERO,ARES_SIGLA,SLD_NECESSIDADE,SLD_ENTREGA,FSIT_QTD_REAL) VALUES(:DIPR_CNTR_CODIGO,:DIPR_ID,:DIPR_PESO,:SBCN_SIGLA,:DISC_ID,:DISC_NOME,:DESC_TIPO_DICIONARIO ,:DCMN_ID,:DCMN_NUMERO,:REPL_REV,:DIPR_CODIGO,:DIPI_DESCRICAO_RES,:UNME_SIGLA,:REPI_QTD_TOTAL,:DIPR_DIMENSOES,:AUFO_NUMERO,:AUFO_DT_EMISSAO,:AUFO_EMPR_NOME,:AFIT_QTD,:SLD_COMPRA,:NOFI_NUMERO,:NOFI_DT_RECEBIMENTO,:NFIT_QTD,:NOEN_NUMERO,:NOEI_QTD_NEM,:DVRE_NUMERO,:ARES_SIGLA,:SLD_NECESSIDADE,:SLD_ENTREGA,:FSIT_QTD_REAL)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":DIPR_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCntrCodigo;
                cmd.Parameters.Add(":DIPR_ID", OracleDbType.Decimal).Value = entity.DiprId;
                cmd.Parameters.Add(":DIPR_PESO", OracleDbType.Decimal).Value = entity.DiprPeso;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":DESC_TIPO_DICIONARIO", OracleDbType.Varchar2).Value = entity.DescTipoDicionario;
                cmd.Parameters.Add(":DCMN_ID", OracleDbType.Decimal).Value = entity.DcmnId;
                cmd.Parameters.Add(":DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
                cmd.Parameters.Add(":REPL_REV", OracleDbType.Varchar2).Value = entity.ReplRev;
                cmd.Parameters.Add(":DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCodigo;
                cmd.Parameters.Add(":DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":REPI_QTD_TOTAL", OracleDbType.Decimal).Value = entity.RepiQtdTotal;
                cmd.Parameters.Add(":DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.DiprDimensoes;
                cmd.Parameters.Add(":AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.AufoNumero;
                //if (entity.AufoDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
                //else 
                cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
                cmd.Parameters.Add(":AUFO_EMPR_NOME", OracleDbType.Varchar2).Value = entity.AufoEmprNome;
                cmd.Parameters.Add(":AFIT_QTD", OracleDbType.Decimal).Value = entity.AfitQtd;
                cmd.Parameters.Add(":SLD_COMPRA", OracleDbType.Decimal).Value = entity.SldCompra;
                cmd.Parameters.Add(":NOFI_NUMERO", OracleDbType.Varchar2).Value = entity.NofiNumero;
                //if (entity.NofiDtRecebimento.ToOADate() == 0.0) cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
                //else 
                cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
                cmd.Parameters.Add(":NFIT_QTD", OracleDbType.Decimal).Value = entity.NfitQtd;
                cmd.Parameters.Add(":NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.NoenNumero;
                cmd.Parameters.Add(":NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.NoeiQtdNem;
                cmd.Parameters.Add(":DVRE_NUMERO", OracleDbType.Varchar2).Value = entity.DvreNumero;
                cmd.Parameters.Add(":ARES_SIGLA", OracleDbType.Varchar2).Value = entity.AresSigla;
                cmd.Parameters.Add(":SLD_NECESSIDADE", OracleDbType.Decimal).Value = entity.SldNecessidade;
                cmd.Parameters.Add(":SLD_ENTREGA", OracleDbType.Decimal).Value = entity.SldEntrega;
                cmd.Parameters.Add(":FSIT_QTD_REAL", OracleDbType.Decimal).Value = entity.FsitQtdReal;

                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcStatusMateriais");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcStatusMateriais");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcStatusMateriaisDTO entity)
        {
            string strSQL = "UPDATE EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL set DIPR_CNTR_CODIGO = :DIPR_CNTR_CODIGO, DIPR_ID = :DIPR_ID, DIPR_PESO = :DIPR_PESO, SBCN_SIGLA = :SBCN_SIGLA, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, DESC_TIPO_DICIONARIO = :DESC_TIPO_DICIONARIO, DCMN_ID = :DCMN_ID, DCMN_NUMERO = :DCMN_NUMERO, REPL_REV = :REPL_REV, DIPR_CODIGO = :DIPR_CODIGO, DIPI_DESCRICAO_RES = :DIPI_DESCRICAO_RES, UNME_SIGLA = :UNME_SIGLA, REPI_QTD_TOTAL = :REPI_QTD_TOTAL, DIPR_DIMENSOES = :DIPR_DIMENSOES, AUFO_NUMERO = :AUFO_NUMERO, AUFO_DT_EMISSAO = :AUFO_DT_EMISSAO, AUFO_EMPR_NOME = :AUFO_EMPR_NOME, AFIT_QTD = :AFIT_QTD, SLD_COMPRA = :SLD_COMPRA, NOFI_NUMERO = :NOFI_NUMERO, NOFI_DT_RECEBIMENTO = :NOFI_DT_RECEBIMENTO, NFIT_QTD = :NFIT_QTD, NOEN_NUMERO = :NOEN_NUMERO, NOEI_QTD_NEM = :NOEI_QTD_NEM, DVRE_NUMERO = :DVRE_NUMERO, ARES_SIGLA = :ARES_SIGLA, SLD_NECESSIDADE = :SLD_NECESSIDADE, SLD_ENTREGA = :SLD_ENTREGA, FSIT_QTD_REAL = :FSIT_QTD_REAL WHERE ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":DIPR_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCntrCodigo;
                cmd.Parameters.Add(":DIPR_ID", OracleDbType.Decimal).Value = entity.DiprId;
                cmd.Parameters.Add(":DIPR_PESO", OracleDbType.Decimal).Value = entity.DiprPeso;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":DESC_TIPO_DICIONARIO", OracleDbType.Varchar2).Value = entity.DescTipoDicionario;
                cmd.Parameters.Add(":DCMN_ID", OracleDbType.Decimal).Value = entity.DcmnId;
                cmd.Parameters.Add(":DCMN_NUMERO", OracleDbType.Varchar2).Value = entity.DcmnNumero;
                cmd.Parameters.Add(":REPL_REV", OracleDbType.Varchar2).Value = entity.ReplRev;
                cmd.Parameters.Add(":DIPR_CODIGO", OracleDbType.Varchar2).Value = entity.DiprCodigo;
                cmd.Parameters.Add(":DIPI_DESCRICAO_RES", OracleDbType.Varchar2).Value = entity.DipiDescricaoRes;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":REPI_QTD_TOTAL", OracleDbType.Decimal).Value = entity.RepiQtdTotal;
                cmd.Parameters.Add(":DIPR_DIMENSOES", OracleDbType.Varchar2).Value = entity.DiprDimensoes;
                cmd.Parameters.Add(":AUFO_NUMERO", OracleDbType.Varchar2).Value = entity.AufoNumero;
                //if (entity.AufoDtEmissao.ToOADate() == 0.0) cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
                //else 
                cmd.Parameters.Add(":AUFO_DT_EMISSAO", OracleDbType.Date).Value = entity.AufoDtEmissao;
                cmd.Parameters.Add(":AUFO_EMPR_NOME", OracleDbType.Varchar2).Value = entity.AufoEmprNome;
                cmd.Parameters.Add(":AFIT_QTD", OracleDbType.Decimal).Value = entity.AfitQtd;
                cmd.Parameters.Add(":SLD_COMPRA", OracleDbType.Decimal).Value = entity.SldCompra;
                cmd.Parameters.Add(":NOFI_NUMERO", OracleDbType.Varchar2).Value = entity.NofiNumero;
                //if (entity.NofiDtRecebimento.ToOADate() == 0.0) cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
                //else 
                cmd.Parameters.Add(":NOFI_DT_RECEBIMENTO", OracleDbType.Date).Value = entity.NofiDtRecebimento;
                cmd.Parameters.Add(":NFIT_QTD", OracleDbType.Decimal).Value = entity.NfitQtd;
                cmd.Parameters.Add(":NOEN_NUMERO", OracleDbType.Varchar2).Value = entity.NoenNumero;
                cmd.Parameters.Add(":NOEI_QTD_NEM", OracleDbType.Decimal).Value = entity.NoeiQtdNem;
                cmd.Parameters.Add(":DVRE_NUMERO", OracleDbType.Varchar2).Value = entity.DvreNumero;
                cmd.Parameters.Add(":ARES_SIGLA", OracleDbType.Varchar2).Value = entity.AresSigla;
                cmd.Parameters.Add(":SLD_NECESSIDADE", OracleDbType.Decimal).Value = entity.SldNecessidade;
                cmd.Parameters.Add(":SLD_ENTREGA", OracleDbType.Decimal).Value = entity.SldEntrega;
                cmd.Parameters.Add(":FSIT_QTD_REAL", OracleDbType.Decimal).Value = entity.FsitQtdReal;

                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = entity.ID;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcStatusMateriais"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL WHERE ID = :ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting AcStatusMateriais"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusMateriais"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcStatusMateriais"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusMateriais"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcStatusMateriais"); }
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
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcStatusMateriais"); }
        }
        //====================================================================
        public static DTO.AcStatusMateriaisDTO Get(decimal ID)
        {
            AcStatusMateriaisDTO entity = new AcStatusMateriaisDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["DIPR_CNTR_CODIGO"] != null) && (dt.Rows[0]["DIPR_CNTR_CODIGO"] != DBNull.Value)) entity.DiprCntrCodigo = Convert.ToString(dt.Rows[0]["DIPR_CNTR_CODIGO"]);
            if ((dt.Rows[0]["DIPR_ID"] != null) && (dt.Rows[0]["DIPR_ID"] != DBNull.Value)) entity.DiprId = Convert.ToDecimal(dt.Rows[0]["DIPR_ID"]);
            if ((dt.Rows[0]["DIPR_PESO"] != null) && (dt.Rows[0]["DIPR_PESO"] != DBNull.Value)) entity.DiprPeso = Convert.ToDecimal(dt.Rows[0]["DIPR_PESO"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["DESC_TIPO_DICIONARIO"] != null) && (dt.Rows[0]["DESC_TIPO_DICIONARIO"] != DBNull.Value)) entity.DescTipoDicionario = Convert.ToString(dt.Rows[0]["DESC_TIPO_DICIONARIO"]);
            if ((dt.Rows[0]["DCMN_ID"] != null) && (dt.Rows[0]["DCMN_ID"] != DBNull.Value)) entity.DcmnId = Convert.ToDecimal(dt.Rows[0]["DCMN_ID"]);
            if ((dt.Rows[0]["DCMN_NUMERO"] != null) && (dt.Rows[0]["DCMN_NUMERO"] != DBNull.Value)) entity.DcmnNumero = Convert.ToString(dt.Rows[0]["DCMN_NUMERO"]);
            if ((dt.Rows[0]["REPL_REV"] != null) && (dt.Rows[0]["REPL_REV"] != DBNull.Value)) entity.ReplRev = Convert.ToString(dt.Rows[0]["REPL_REV"]);
            if ((dt.Rows[0]["DIPR_CODIGO"] != null) && (dt.Rows[0]["DIPR_CODIGO"] != DBNull.Value)) entity.DiprCodigo = Convert.ToString(dt.Rows[0]["DIPR_CODIGO"]);
            if ((dt.Rows[0]["DIPI_DESCRICAO_RES"] != null) && (dt.Rows[0]["DIPI_DESCRICAO_RES"] != DBNull.Value)) entity.DipiDescricaoRes = Convert.ToString(dt.Rows[0]["DIPI_DESCRICAO_RES"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["REPI_QTD_TOTAL"] != null) && (dt.Rows[0]["REPI_QTD_TOTAL"] != DBNull.Value)) entity.RepiQtdTotal = Convert.ToDecimal(dt.Rows[0]["REPI_QTD_TOTAL"]);
            if ((dt.Rows[0]["DIPR_DIMENSOES"] != null) && (dt.Rows[0]["DIPR_DIMENSOES"] != DBNull.Value)) entity.DiprDimensoes = Convert.ToString(dt.Rows[0]["DIPR_DIMENSOES"]);
            if ((dt.Rows[0]["AUFO_NUMERO"] != null) && (dt.Rows[0]["AUFO_NUMERO"] != DBNull.Value)) entity.AufoNumero = Convert.ToString(dt.Rows[0]["AUFO_NUMERO"]);
            if ((dt.Rows[0]["AUFO_DT_EMISSAO"] != null) && (dt.Rows[0]["AUFO_DT_EMISSAO"] != DBNull.Value)) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[0]["AUFO_DT_EMISSAO"]);
            if ((dt.Rows[0]["AUFO_EMPR_NOME"] != null) && (dt.Rows[0]["AUFO_EMPR_NOME"] != DBNull.Value)) entity.AufoEmprNome = Convert.ToString(dt.Rows[0]["AUFO_EMPR_NOME"]);
            if ((dt.Rows[0]["AFIT_QTD"] != null) && (dt.Rows[0]["AFIT_QTD"] != DBNull.Value)) entity.AfitQtd = Convert.ToDecimal(dt.Rows[0]["AFIT_QTD"]);
            if ((dt.Rows[0]["SLD_COMPRA"] != null) && (dt.Rows[0]["SLD_COMPRA"] != DBNull.Value)) entity.SldCompra = Convert.ToDecimal(dt.Rows[0]["SLD_COMPRA"]);
            if ((dt.Rows[0]["NOFI_NUMERO"] != null) && (dt.Rows[0]["NOFI_NUMERO"] != DBNull.Value)) entity.NofiNumero = Convert.ToString(dt.Rows[0]["NOFI_NUMERO"]);
            if ((dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != null) && (dt.Rows[0]["NOFI_DT_RECEBIMENTO"] != DBNull.Value)) entity.NofiDtRecebimento = Convert.ToDateTime(dt.Rows[0]["NOFI_DT_RECEBIMENTO"]);
            if ((dt.Rows[0]["NFIT_QTD"] != null) && (dt.Rows[0]["NFIT_QTD"] != DBNull.Value)) entity.NfitQtd = Convert.ToDecimal(dt.Rows[0]["NFIT_QTD"]);
            if ((dt.Rows[0]["NOEN_NUMERO"] != null) && (dt.Rows[0]["NOEN_NUMERO"] != DBNull.Value)) entity.NoenNumero = Convert.ToString(dt.Rows[0]["NOEN_NUMERO"]);
            if ((dt.Rows[0]["NOEI_QTD_NEM"] != null) && (dt.Rows[0]["NOEI_QTD_NEM"] != DBNull.Value)) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[0]["NOEI_QTD_NEM"]);
            if ((dt.Rows[0]["DVRE_NUMERO"] != null) && (dt.Rows[0]["DVRE_NUMERO"] != DBNull.Value)) entity.DvreNumero = Convert.ToString(dt.Rows[0]["DVRE_NUMERO"]);
            if ((dt.Rows[0]["ARES_SIGLA"] != null) && (dt.Rows[0]["ARES_SIGLA"] != DBNull.Value)) entity.AresSigla = Convert.ToString(dt.Rows[0]["ARES_SIGLA"]);
            if ((dt.Rows[0]["SLD_NECESSIDADE"] != null) && (dt.Rows[0]["SLD_NECESSIDADE"] != DBNull.Value)) entity.SldNecessidade = Convert.ToDecimal(dt.Rows[0]["SLD_NECESSIDADE"]);
            if ((dt.Rows[0]["SLD_ENTREGA"] != null) && (dt.Rows[0]["SLD_ENTREGA"] != DBNull.Value)) entity.SldEntrega = Convert.ToDecimal(dt.Rows[0]["SLD_ENTREGA"]);
            if ((dt.Rows[0]["FSIT_QTD_REAL"] != null) && (dt.Rows[0]["FSIT_QTD_REAL"] != DBNull.Value)) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[0]["FSIT_QTD_REAL"]);
            if ((dt.Rows[0]["CREATED_DATE"] != null) && (dt.Rows[0]["CREATED_DATE"] != DBNull.Value)) entity.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CREATED_DATE"]);
            return entity;
        }
        //====================================================================
        public static DTO.AcStatusMateriaisDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcStatusMateriaisDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcStatusMateriaisDTO> list = OracleDataTools.LoadEntity<AcStatusMateriaisDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusMateriaisDTO>"); }
        }
        //====================================================================
        public static List<AcStatusMateriaisDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusMateriaisDTO>"); }
        }
        //====================================================================
        public static List<AcStatusMateriaisDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcStatusMateriaisDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusMateriaisDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcStatusMateriais"); }
        }
        //====================================================================
        public static DTO.CollectionAcStatusMateriaisDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcStatusMateriaisDTO collection = new DTO.CollectionAcStatusMateriaisDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcStatusMateriaisDTO entity = new DTO.AcStatusMateriaisDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["DIPR_CNTR_CODIGO"].ToString().Length != 0) entity.DiprCntrCodigo = dt.Rows[i]["DIPR_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPR_ID"].ToString().Length != 0) entity.DiprId = Convert.ToDecimal(dt.Rows[i]["DIPR_ID"]);
                    if (dt.Rows[i]["DIPR_PESO"].ToString().Length != 0) entity.DiprPeso = Convert.ToDecimal(dt.Rows[i]["DIPR_PESO"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["DESC_TIPO_DICIONARIO"].ToString().Length != 0) entity.DescTipoDicionario = dt.Rows[i]["DESC_TIPO_DICIONARIO"].ToString();
                    if (dt.Rows[i]["DCMN_ID"].ToString().Length != 0) entity.DcmnId = Convert.ToDecimal(dt.Rows[i]["DCMN_ID"]);
                    if (dt.Rows[i]["DCMN_NUMERO"].ToString().Length != 0) entity.DcmnNumero = dt.Rows[i]["DCMN_NUMERO"].ToString();
                    if (dt.Rows[i]["REPL_REV"].ToString().Length != 0) entity.ReplRev = dt.Rows[i]["REPL_REV"].ToString();
                    if (dt.Rows[i]["DIPR_CODIGO"].ToString().Length != 0) entity.DiprCodigo = dt.Rows[i]["DIPR_CODIGO"].ToString();
                    if (dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString().Length != 0) entity.DipiDescricaoRes = dt.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["REPI_QTD_TOTAL"].ToString().Length != 0) entity.RepiQtdTotal = Convert.ToDecimal(dt.Rows[i]["REPI_QTD_TOTAL"]);
                    if (dt.Rows[i]["DIPR_DIMENSOES"].ToString().Length != 0) entity.DiprDimensoes = dt.Rows[i]["DIPR_DIMENSOES"].ToString();
                    if (dt.Rows[i]["AUFO_NUMERO"].ToString().Length != 0) entity.AufoNumero = dt.Rows[i]["AUFO_NUMERO"].ToString();
                    if (dt.Rows[i]["AUFO_DT_EMISSAO"].ToString().Length != 0) entity.AufoDtEmissao = Convert.ToDateTime(dt.Rows[i]["AUFO_DT_EMISSAO"]);
                    if (dt.Rows[i]["AUFO_EMPR_NOME"].ToString().Length != 0) entity.AufoEmprNome = dt.Rows[i]["AUFO_EMPR_NOME"].ToString();
                    if (dt.Rows[i]["AFIT_QTD"].ToString().Length != 0) entity.AfitQtd = Convert.ToDecimal(dt.Rows[i]["AFIT_QTD"]);
                    if (dt.Rows[i]["SLD_COMPRA"].ToString().Length != 0) entity.SldCompra = Convert.ToDecimal(dt.Rows[i]["SLD_COMPRA"]);
                    if (dt.Rows[i]["NOFI_NUMERO"].ToString().Length != 0) entity.NofiNumero = dt.Rows[i]["NOFI_NUMERO"].ToString();
                    if (dt.Rows[i]["NOFI_DT_RECEBIMENTO"].ToString().Length != 0) entity.NofiDtRecebimento = Convert.ToDateTime(dt.Rows[i]["NOFI_DT_RECEBIMENTO"]);
                    if (dt.Rows[i]["NFIT_QTD"].ToString().Length != 0) entity.NfitQtd = Convert.ToDecimal(dt.Rows[i]["NFIT_QTD"]);
                    if (dt.Rows[i]["NOEN_NUMERO"].ToString().Length != 0) entity.NoenNumero = dt.Rows[i]["NOEN_NUMERO"].ToString();
                    if (dt.Rows[i]["NOEI_QTD_NEM"].ToString().Length != 0) entity.NoeiQtdNem = Convert.ToDecimal(dt.Rows[i]["NOEI_QTD_NEM"]);
                    if (dt.Rows[i]["DVRE_NUMERO"].ToString().Length != 0) entity.DvreNumero = dt.Rows[i]["DVRE_NUMERO"].ToString();
                    if (dt.Rows[i]["ARES_SIGLA"].ToString().Length != 0) entity.AresSigla = dt.Rows[i]["ARES_SIGLA"].ToString();
                    if (dt.Rows[i]["SLD_NECESSIDADE"].ToString().Length != 0) entity.SldNecessidade = Convert.ToDecimal(dt.Rows[i]["SLD_NECESSIDADE"]);
                    if (dt.Rows[i]["SLD_ENTREGA"].ToString().Length != 0) entity.SldEntrega = Convert.ToDecimal(dt.Rows[i]["SLD_ENTREGA"]);
                    if (dt.Rows[i]["FSIT_QTD_REAL"].ToString().Length != 0) entity.FsitQtdReal = Convert.ToDecimal(dt.Rows[i]["FSIT_QTD_REAL"]);
                    if (dt.Rows[i]["CREATED_DATE"].ToString().Length != 0) entity.CreatedDate = Convert.ToDateTime(dt.Rows[i]["CREATED_DATE"]);

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
