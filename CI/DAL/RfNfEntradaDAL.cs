using System;
using System.Collections.Generic;

using System.Data;
using Oracle.DataAccess.Client;
using System.Collections;

using EnseadaDatabaseTools;
using DTO;

//====================================================================
//====================================================================

namespace DAL
{
    public class RfNfEntradaDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.ID, X.ID_IMPORTACAO, X.ID_REF, X.CFOP, X.COD_FORNECEDOR, X.COD_PROPRIETARIO, X.DATA_DOC, X.DATA_ENTRADA, X.DATA_GER_LEG, X.DATA_NF, X.DOC_ORIGEM, X.ID_CORPORATIVO, X.NCM, X.NF_E, X.NUM_ADICAO, X.NUM_DI_CAMBIAL, X.NUM_ITEM, X.NUM_ITEM_ADICAO, X.ORGANIZACAO, X.PART_NUMBER, X.PROCEDENCIA_INFO, X.QTDE, X.REF_BAIXA, X.REF_ENTRADA, X.REF_ERP_ENT, X.REF_NFE, X.SEGMENTO1, X.SEGMENTO2, X.SEGMENTO3, X.SEGMENTO4, X.SEGMENTO5, X.SERIE_E, X.TIPO_ENTRADA, X.VALOR_FISCAL, X.VCTO_DI_CAMBIAL, X.NUM_CONTRATO, X.FINALIDADE_ENTRADA FROM RF_NF_ENTRADA X ";
        //====================================================================
        public static int Insert(DTO.RfNfEntradaDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO RF_NF_ENTRADA(ID_IMPORTACAO,ID_REF,CFOP,COD_FORNECEDOR,COD_PROPRIETARIO,DATA_DOC,DATA_ENTRADA,DATA_GER_LEG,DATA_NF,DOC_ORIGEM,ID_CORPORATIVO,NCM,NF_E,NUM_ADICAO,NUM_DI_CAMBIAL,NUM_ITEM,NUM_ITEM_ADICAO,ORGANIZACAO,PART_NUMBER,PROCEDENCIA_INFO,QTDE,REF_BAIXA,REF_ENTRADA,REF_ERP_ENT,REF_NFE,SEGMENTO1,SEGMENTO2,SEGMENTO3,SEGMENTO4,SEGMENTO5,SERIE_E,TIPO_ENTRADA,VALOR_FISCAL,VCTO_DI_CAMBIAL,NUM_CONTRATO,FINALIDADE_ENTRADA) VALUES(:ID_IMPORTACAO,:ID_REF,:CFOP,:COD_FORNECEDOR,:COD_PROPRIETARIO,:DATA_DOC,:DATA_ENTRADA,:DATA_GER_LEG,:DATA_NF,:DOC_ORIGEM,:ID_CORPORATIVO,:NCM,:NF_E,:NUM_ADICAO,:NUM_DI_CAMBIAL,:NUM_ITEM,:NUM_ITEM_ADICAO,:ORGANIZACAO,:PART_NUMBER,:PROCEDENCIA_INFO,:QTDE,:REF_BAIXA,:REF_ENTRADA,:REF_ERP_ENT,:REF_NFE,:SEGMENTO1,:SEGMENTO2,:SEGMENTO3,:SEGMENTO4,:SEGMENTO5,:SERIE_E,:TIPO_ENTRADA,:VALOR_FISCAL,:VCTO_DI_CAMBIAL,:NUM_CONTRATO,:FINALIDADE_ENTRADA)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID_IMPORTACAO", OracleDbType.Decimal).Value = entity.IdImportacao;
                cmd.Parameters.Add(":ID_REF", OracleDbType.Decimal).Value = entity.IdRef;
                cmd.Parameters.Add(":CFOP", OracleDbType.Varchar2).Value = entity.Cfop;
                cmd.Parameters.Add(":COD_FORNECEDOR", OracleDbType.Varchar2).Value = entity.CodFornecedor;
                cmd.Parameters.Add(":COD_PROPRIETARIO", OracleDbType.Varchar2).Value = entity.CodProprietario;
                cmd.Parameters.Add(":DATA_DOC", OracleDbType.Varchar2).Value = entity.DataDoc;
                cmd.Parameters.Add(":DATA_ENTRADA", OracleDbType.Varchar2).Value = entity.DataEntrada;
                cmd.Parameters.Add(":DATA_GER_LEG", OracleDbType.Varchar2).Value = entity.DataGerLeg;
                cmd.Parameters.Add(":DATA_NF", OracleDbType.Varchar2).Value = entity.DataNf;
                cmd.Parameters.Add(":DOC_ORIGEM", OracleDbType.Varchar2).Value = entity.DocOrigem;
                cmd.Parameters.Add(":ID_CORPORATIVO", OracleDbType.Varchar2).Value = entity.IdCorporativo;
                cmd.Parameters.Add(":NCM", OracleDbType.Varchar2).Value = entity.Ncm;
                cmd.Parameters.Add(":NF_E", OracleDbType.Varchar2).Value = entity.NfE;
                cmd.Parameters.Add(":NUM_ADICAO", OracleDbType.Varchar2).Value = entity.NumAdicao;
                cmd.Parameters.Add(":NUM_DI_CAMBIAL", OracleDbType.Varchar2).Value = entity.NumDiCambial;
                cmd.Parameters.Add(":NUM_ITEM", OracleDbType.Decimal).Value = entity.NumItem;
                cmd.Parameters.Add(":NUM_ITEM_ADICAO", OracleDbType.Varchar2).Value = entity.NumItemAdicao;
                cmd.Parameters.Add(":ORGANIZACAO", OracleDbType.Varchar2).Value = entity.Organizacao;
                cmd.Parameters.Add(":PART_NUMBER", OracleDbType.Varchar2).Value = entity.PartNumber;
                cmd.Parameters.Add(":PROCEDENCIA_INFO", OracleDbType.Varchar2).Value = entity.ProcedenciaInfo;
                cmd.Parameters.Add(":QTDE", OracleDbType.Decimal).Value = entity.Qtde;
                cmd.Parameters.Add(":REF_BAIXA", OracleDbType.Varchar2).Value = entity.RefBaixa;
                cmd.Parameters.Add(":REF_ENTRADA", OracleDbType.Varchar2).Value = entity.RefEntrada;
                cmd.Parameters.Add(":REF_ERP_ENT", OracleDbType.Varchar2).Value = entity.RefErpEnt;
                cmd.Parameters.Add(":REF_NFE", OracleDbType.Varchar2).Value = entity.RefNfe;
                cmd.Parameters.Add(":SEGMENTO1", OracleDbType.Varchar2).Value = entity.Segmento1;
                cmd.Parameters.Add(":SEGMENTO2", OracleDbType.Varchar2).Value = entity.Segmento2;
                cmd.Parameters.Add(":SEGMENTO3", OracleDbType.Varchar2).Value = entity.Segmento3;
                cmd.Parameters.Add(":SEGMENTO4", OracleDbType.Varchar2).Value = entity.Segmento4;
                cmd.Parameters.Add(":SEGMENTO5", OracleDbType.Varchar2).Value = entity.Segmento5;
                cmd.Parameters.Add(":SERIE_E", OracleDbType.Varchar2).Value = entity.SerieE;
                cmd.Parameters.Add(":TIPO_ENTRADA", OracleDbType.Varchar2).Value = entity.TipoEntrada;
                cmd.Parameters.Add(":VALOR_FISCAL", OracleDbType.Decimal).Value = entity.ValorFiscal;
                cmd.Parameters.Add(":VCTO_DI_CAMBIAL", OracleDbType.Varchar2).Value = entity.VctoDiCambial;
                cmd.Parameters.Add(":NUM_CONTRATO", OracleDbType.Varchar2).Value = entity.NumContrato;
                cmd.Parameters.Add(":FINALIDADE_ENTRADA", OracleDbType.Varchar2).Value = entity.FinalidadeEntrada;
                //return OracleDataTools.ExecuteScalar(strSQL, cmd);

                return EnseadaOracleDataTools.ExecuteScalar(EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strSQL);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting RfNfEntrada");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting RfNfEntrada");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.RfNfEntradaDTO entity)
        {
            string strSQL = "UPDATE RF_NF_ENTRADA set ID_IMPORTACAO = :ID_IMPORTACAO, ID_REF = :ID_REF, CFOP = :CFOP, COD_FORNECEDOR = :COD_FORNECEDOR, COD_PROPRIETARIO = :COD_PROPRIETARIO, DATA_DOC = :DATA_DOC, DATA_ENTRADA = :DATA_ENTRADA, DATA_GER_LEG = :DATA_GER_LEG, DATA_NF = :DATA_NF, DOC_ORIGEM = :DOC_ORIGEM, ID_CORPORATIVO = :ID_CORPORATIVO, NCM = :NCM, NF_E = :NF_E, NUM_ADICAO = :NUM_ADICAO, NUM_DI_CAMBIAL = :NUM_DI_CAMBIAL, NUM_ITEM = :NUM_ITEM, NUM_ITEM_ADICAO = :NUM_ITEM_ADICAO, ORGANIZACAO = :ORGANIZACAO, PART_NUMBER = :PART_NUMBER, PROCEDENCIA_INFO = :PROCEDENCIA_INFO, QTDE = :QTDE, REF_BAIXA = :REF_BAIXA, REF_ENTRADA = :REF_ENTRADA, REF_ERP_ENT = :REF_ERP_ENT, REF_NFE = :REF_NFE, SEGMENTO1 = :SEGMENTO1, SEGMENTO2 = :SEGMENTO2, SEGMENTO3 = :SEGMENTO3, SEGMENTO4 = :SEGMENTO4, SEGMENTO5 = :SEGMENTO5, SERIE_E = :SERIE_E, TIPO_ENTRADA = :TIPO_ENTRADA, VALOR_FISCAL = :VALOR_FISCAL, VCTO_DI_CAMBIAL = :VCTO_DI_CAMBIAL, NUM_CONTRATO = :NUM_CONTRATO, FINALIDADE_ENTRADA = :FINALIDADE_ENTRADA WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add("ID_IMPORTACAO", OracleDbType.Decimal).Value = entity.IdImportacao;
                cmd.Parameters.Add("ID_REF", OracleDbType.Decimal).Value = entity.IdRef;
                cmd.Parameters.Add("CFOP", OracleDbType.Varchar2).Value = entity.Cfop;
                cmd.Parameters.Add("COD_FORNECEDOR", OracleDbType.Varchar2).Value = entity.CodFornecedor;
                cmd.Parameters.Add("COD_PROPRIETARIO", OracleDbType.Varchar2).Value = entity.CodProprietario;
                cmd.Parameters.Add("DATA_DOC", OracleDbType.Varchar2).Value = entity.DataDoc;
                cmd.Parameters.Add("DATA_ENTRADA", OracleDbType.Varchar2).Value = entity.DataEntrada;
                cmd.Parameters.Add("DATA_GER_LEG", OracleDbType.Varchar2).Value = entity.DataGerLeg;
                cmd.Parameters.Add("DATA_NF", OracleDbType.Varchar2).Value = entity.DataNf;
                cmd.Parameters.Add("DOC_ORIGEM", OracleDbType.Varchar2).Value = entity.DocOrigem;
                cmd.Parameters.Add("ID_CORPORATIVO", OracleDbType.Varchar2).Value = entity.IdCorporativo;
                cmd.Parameters.Add("NCM", OracleDbType.Varchar2).Value = entity.Ncm;
                cmd.Parameters.Add("NF_E", OracleDbType.Varchar2).Value = entity.NfE;
                cmd.Parameters.Add("NUM_ADICAO", OracleDbType.Varchar2).Value = entity.NumAdicao;
                cmd.Parameters.Add("NUM_DI_CAMBIAL", OracleDbType.Varchar2).Value = entity.NumDiCambial;
                cmd.Parameters.Add("NUM_ITEM", OracleDbType.Decimal).Value = entity.NumItem;
                cmd.Parameters.Add("NUM_ITEM_ADICAO", OracleDbType.Varchar2).Value = entity.NumItemAdicao;
                cmd.Parameters.Add("ORGANIZACAO", OracleDbType.Varchar2).Value = entity.Organizacao;
                cmd.Parameters.Add("PART_NUMBER", OracleDbType.Varchar2).Value = entity.PartNumber;
                cmd.Parameters.Add("PROCEDENCIA_INFO", OracleDbType.Varchar2).Value = entity.ProcedenciaInfo;
                cmd.Parameters.Add("QTDE", OracleDbType.Decimal).Value = entity.Qtde;
                cmd.Parameters.Add("REF_BAIXA", OracleDbType.Varchar2).Value = entity.RefBaixa;
                cmd.Parameters.Add("REF_ENTRADA", OracleDbType.Varchar2).Value = entity.RefEntrada;
                cmd.Parameters.Add("REF_ERP_ENT", OracleDbType.Varchar2).Value = entity.RefErpEnt;
                cmd.Parameters.Add("REF_NFE", OracleDbType.Varchar2).Value = entity.RefNfe;
                cmd.Parameters.Add("SEGMENTO1", OracleDbType.Varchar2).Value = entity.Segmento1;
                cmd.Parameters.Add("SEGMENTO2", OracleDbType.Varchar2).Value = entity.Segmento2;
                cmd.Parameters.Add("SEGMENTO3", OracleDbType.Varchar2).Value = entity.Segmento3;
                cmd.Parameters.Add("SEGMENTO4", OracleDbType.Varchar2).Value = entity.Segmento4;
                cmd.Parameters.Add("SEGMENTO5", OracleDbType.Varchar2).Value = entity.Segmento5;
                cmd.Parameters.Add("SERIE_E", OracleDbType.Varchar2).Value = entity.SerieE;
                cmd.Parameters.Add("TIPO_ENTRADA", OracleDbType.Varchar2).Value = entity.TipoEntrada;
                cmd.Parameters.Add("VALOR_FISCAL", OracleDbType.Decimal).Value = entity.ValorFiscal;
                cmd.Parameters.Add("VCTO_DI_CAMBIAL", OracleDbType.Varchar2).Value = entity.VctoDiCambial;
                cmd.Parameters.Add("NUM_CONTRATO", OracleDbType.Varchar2).Value = entity.NumContrato;
                cmd.Parameters.Add("FINALIDADE_ENTRADA", OracleDbType.Varchar2).Value = entity.FinalidadeEntrada;
                cmd.Parameters.Add("FINALIDADE_ENTRADA", OracleDbType.Decimal).Value = entity.FinalidadeEntrada;

                EnseadaDatabaseTools.EnseadaOracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating RfNfEntrada"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Delete(decimal ID)
        {
            string strSQL = "DELETE FROM RF_NF_ENTRADA WHERE  ID = : ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":ID", OracleDbType.Decimal).Value = ID;
                EnseadaDatabaseTools.EnseadaOracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Deleting RfNfEntrada"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting RfNfEntrada"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM RF_NF_ENTRADA";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                //NR = OracleDataTools.ExecuteScalar(strSQL);
                return EnseadaDatabaseTools.EnseadaOracleDataTools.ExecuteScalar(EnseadaDatabaseTools.EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting RfNfEntrada"); }
        }
        ////====================================================================
        //public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        //{
        //    try
        //    {
        //        OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
        //    }
        //    catch (Exception ex)
        //    { throw new Exception(ex.Message + " - Executing SQL Instruction RfNfEntrada"); }
        //}
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                EnseadaDatabaseTools.EnseadaOracleDataTools.ExecuteSQLInstruction(EnseadaDatabaseTools.EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction RfNfEntrada"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return EnseadaDatabaseTools.EnseadaOracleDataTools.GetDataTable(EnseadaDatabaseTools.EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strSQL);
        }
        //====================================================================
        public static void AtualizaSchedule(string strID, string strStatus)
        {
            EnseadaDatabaseTools.EnseadaOracleDataTools.AtualizaSchedule(EnseadaDatabaseTools.EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strID, strStatus);
        }
        //====================================================================
        public static void SalvaChaves(string strChaves)
        {
            EnseadaDatabaseTools.EnseadaOracleDataTools.SalvaChaves(EnseadaDatabaseTools.EnseadaOracleDataTools.EnumConnection.EREPLAT_PRD, strChaves);
        }
        ////====================================================================
        //public static DataTable Select(string strSQL)
        //{
        //    return OracleDataTools.GetDataTable(strSQL);
        //}
        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = EnseadaDatabaseTools.EnseadaOracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return EnseadaDatabaseTools.EnseadaOracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableRfNfEntrada"); }
        }
        //====================================================================
        public static DTO.RfNfEntradaDTO Get(decimal ID)
        {
            RfNfEntradaDTO entity = new RfNfEntradaDTO();
            DataTable dt = null;
            string filter = "ID = " + ID;
            dt = Get(filter, null);
            if ((dt.Rows[0]["ID"] != null) && (dt.Rows[0]["ID"] != DBNull.Value)) entity.ID = Convert.ToDecimal(dt.Rows[0]["ID"]);
            if ((dt.Rows[0]["ID_IMPORTACAO"] != null) && (dt.Rows[0]["ID_IMPORTACAO"] != DBNull.Value)) entity.IdImportacao = Convert.ToDecimal(dt.Rows[0]["ID_IMPORTACAO"]);
            if ((dt.Rows[0]["ID_REF"] != null) && (dt.Rows[0]["ID_REF"] != DBNull.Value)) entity.IdRef = Convert.ToDecimal(dt.Rows[0]["ID_REF"]);
            if ((dt.Rows[0]["CFOP"] != null) && (dt.Rows[0]["CFOP"] != DBNull.Value)) entity.Cfop = Convert.ToString(dt.Rows[0]["CFOP"]);
            if ((dt.Rows[0]["COD_FORNECEDOR"] != null) && (dt.Rows[0]["COD_FORNECEDOR"] != DBNull.Value)) entity.CodFornecedor = Convert.ToString(dt.Rows[0]["COD_FORNECEDOR"]);
            if ((dt.Rows[0]["COD_PROPRIETARIO"] != null) && (dt.Rows[0]["COD_PROPRIETARIO"] != DBNull.Value)) entity.CodProprietario = Convert.ToString(dt.Rows[0]["COD_PROPRIETARIO"]);
            if ((dt.Rows[0]["DATA_DOC"] != null) && (dt.Rows[0]["DATA_DOC"] != DBNull.Value)) entity.DataDoc = Convert.ToString(dt.Rows[0]["DATA_DOC"]);
            if ((dt.Rows[0]["DATA_ENTRADA"] != null) && (dt.Rows[0]["DATA_ENTRADA"] != DBNull.Value)) entity.DataEntrada = Convert.ToString(dt.Rows[0]["DATA_ENTRADA"]);
            if ((dt.Rows[0]["DATA_GER_LEG"] != null) && (dt.Rows[0]["DATA_GER_LEG"] != DBNull.Value)) entity.DataGerLeg = Convert.ToString(dt.Rows[0]["DATA_GER_LEG"]);
            if ((dt.Rows[0]["DATA_NF"] != null) && (dt.Rows[0]["DATA_NF"] != DBNull.Value)) entity.DataNf = Convert.ToString(dt.Rows[0]["DATA_NF"]);
            if ((dt.Rows[0]["DOC_ORIGEM"] != null) && (dt.Rows[0]["DOC_ORIGEM"] != DBNull.Value)) entity.DocOrigem = Convert.ToString(dt.Rows[0]["DOC_ORIGEM"]);
            if ((dt.Rows[0]["ID_CORPORATIVO"] != null) && (dt.Rows[0]["ID_CORPORATIVO"] != DBNull.Value)) entity.IdCorporativo = Convert.ToString(dt.Rows[0]["ID_CORPORATIVO"]);
            if ((dt.Rows[0]["NCM"] != null) && (dt.Rows[0]["NCM"] != DBNull.Value)) entity.Ncm = Convert.ToString(dt.Rows[0]["NCM"]);
            if ((dt.Rows[0]["NF_E"] != null) && (dt.Rows[0]["NF_E"] != DBNull.Value)) entity.NfE = Convert.ToString(dt.Rows[0]["NF_E"]);
            if ((dt.Rows[0]["NUM_ADICAO"] != null) && (dt.Rows[0]["NUM_ADICAO"] != DBNull.Value)) entity.NumAdicao = Convert.ToString(dt.Rows[0]["NUM_ADICAO"]);
            if ((dt.Rows[0]["NUM_DI_CAMBIAL"] != null) && (dt.Rows[0]["NUM_DI_CAMBIAL"] != DBNull.Value)) entity.NumDiCambial = Convert.ToString(dt.Rows[0]["NUM_DI_CAMBIAL"]);
            if ((dt.Rows[0]["NUM_ITEM"] != null) && (dt.Rows[0]["NUM_ITEM"] != DBNull.Value)) entity.NumItem = Convert.ToDecimal(dt.Rows[0]["NUM_ITEM"]);
            if ((dt.Rows[0]["NUM_ITEM_ADICAO"] != null) && (dt.Rows[0]["NUM_ITEM_ADICAO"] != DBNull.Value)) entity.NumItemAdicao = Convert.ToString(dt.Rows[0]["NUM_ITEM_ADICAO"]);
            if ((dt.Rows[0]["ORGANIZACAO"] != null) && (dt.Rows[0]["ORGANIZACAO"] != DBNull.Value)) entity.Organizacao = Convert.ToString(dt.Rows[0]["ORGANIZACAO"]);
            if ((dt.Rows[0]["PART_NUMBER"] != null) && (dt.Rows[0]["PART_NUMBER"] != DBNull.Value)) entity.PartNumber = Convert.ToString(dt.Rows[0]["PART_NUMBER"]);
            if ((dt.Rows[0]["PROCEDENCIA_INFO"] != null) && (dt.Rows[0]["PROCEDENCIA_INFO"] != DBNull.Value)) entity.ProcedenciaInfo = Convert.ToString(dt.Rows[0]["PROCEDENCIA_INFO"]);
            if ((dt.Rows[0]["QTDE"] != null) && (dt.Rows[0]["QTDE"] != DBNull.Value)) entity.Qtde = Convert.ToDecimal(dt.Rows[0]["QTDE"]);
            if ((dt.Rows[0]["REF_BAIXA"] != null) && (dt.Rows[0]["REF_BAIXA"] != DBNull.Value)) entity.RefBaixa = Convert.ToString(dt.Rows[0]["REF_BAIXA"]);
            if ((dt.Rows[0]["REF_ENTRADA"] != null) && (dt.Rows[0]["REF_ENTRADA"] != DBNull.Value)) entity.RefEntrada = Convert.ToString(dt.Rows[0]["REF_ENTRADA"]);
            if ((dt.Rows[0]["REF_ERP_ENT"] != null) && (dt.Rows[0]["REF_ERP_ENT"] != DBNull.Value)) entity.RefErpEnt = Convert.ToString(dt.Rows[0]["REF_ERP_ENT"]);
            if ((dt.Rows[0]["REF_NFE"] != null) && (dt.Rows[0]["REF_NFE"] != DBNull.Value)) entity.RefNfe = Convert.ToString(dt.Rows[0]["REF_NFE"]);
            if ((dt.Rows[0]["SEGMENTO1"] != null) && (dt.Rows[0]["SEGMENTO1"] != DBNull.Value)) entity.Segmento1 = Convert.ToString(dt.Rows[0]["SEGMENTO1"]);
            if ((dt.Rows[0]["SEGMENTO2"] != null) && (dt.Rows[0]["SEGMENTO2"] != DBNull.Value)) entity.Segmento2 = Convert.ToString(dt.Rows[0]["SEGMENTO2"]);
            if ((dt.Rows[0]["SEGMENTO3"] != null) && (dt.Rows[0]["SEGMENTO3"] != DBNull.Value)) entity.Segmento3 = Convert.ToString(dt.Rows[0]["SEGMENTO3"]);
            if ((dt.Rows[0]["SEGMENTO4"] != null) && (dt.Rows[0]["SEGMENTO4"] != DBNull.Value)) entity.Segmento4 = Convert.ToString(dt.Rows[0]["SEGMENTO4"]);
            if ((dt.Rows[0]["SEGMENTO5"] != null) && (dt.Rows[0]["SEGMENTO5"] != DBNull.Value)) entity.Segmento5 = Convert.ToString(dt.Rows[0]["SEGMENTO5"]);
            if ((dt.Rows[0]["SERIE_E"] != null) && (dt.Rows[0]["SERIE_E"] != DBNull.Value)) entity.SerieE = Convert.ToString(dt.Rows[0]["SERIE_E"]);
            if ((dt.Rows[0]["TIPO_ENTRADA"] != null) && (dt.Rows[0]["TIPO_ENTRADA"] != DBNull.Value)) entity.TipoEntrada = Convert.ToString(dt.Rows[0]["TIPO_ENTRADA"]);
            if ((dt.Rows[0]["VALOR_FISCAL"] != null) && (dt.Rows[0]["VALOR_FISCAL"] != DBNull.Value)) entity.ValorFiscal = Convert.ToDecimal(dt.Rows[0]["VALOR_FISCAL"]);
            if ((dt.Rows[0]["VCTO_DI_CAMBIAL"] != null) && (dt.Rows[0]["VCTO_DI_CAMBIAL"] != DBNull.Value)) entity.VctoDiCambial = Convert.ToString(dt.Rows[0]["VCTO_DI_CAMBIAL"]);
            if ((dt.Rows[0]["NUM_CONTRATO"] != null) && (dt.Rows[0]["NUM_CONTRATO"] != DBNull.Value)) entity.NumContrato = Convert.ToString(dt.Rows[0]["NUM_CONTRATO"]);
            if ((dt.Rows[0]["FINALIDADE_ENTRADA"] != null) && (dt.Rows[0]["FINALIDADE_ENTRADA"] != DBNull.Value)) entity.FinalidadeEntrada = Convert.ToString(dt.Rows[0]["FINALIDADE_ENTRADA"]);
            return entity;
        }
        //====================================================================
        public static DTO.RfNfEntradaDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting FINALIDADE_ENTRADA Object"); }
        }
        //====================================================================
        public static List<RfNfEntradaDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = EnseadaDatabaseTools.EnseadaOracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<RfNfEntradaDTO> list = EnseadaDatabaseTools.EnseadaOracleDataTools.LoadEntity<RfNfEntradaDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<RfNfEntradaDTO>"); }
        }
        //====================================================================
        public static List<RfNfEntradaDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<RfNfEntradaDTO>"); }
        }
        //====================================================================
        public static List<RfNfEntradaDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<RfNfEntradaDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionRfNfEntrada"); }
        }
        //====================================================================
        public static DTO.CollectionRfNfEntradaDTO GetCollection(DataTable dt)
        {
            DTO.CollectionRfNfEntradaDTO collection = new DTO.CollectionRfNfEntradaDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.RfNfEntradaDTO entity = new DTO.RfNfEntradaDTO();
                    if (dt.Rows[i]["ID"].ToString().Length != 0) entity.ID = Convert.ToDecimal(dt.Rows[i]["ID"]);
                    if (dt.Rows[i]["ID_IMPORTACAO"].ToString().Length != 0) entity.IdImportacao = Convert.ToDecimal(dt.Rows[i]["ID_IMPORTACAO"]);
                    if (dt.Rows[i]["ID_REF"].ToString().Length != 0) entity.IdRef = Convert.ToDecimal(dt.Rows[i]["ID_REF"]);
                    if (dt.Rows[i]["CFOP"].ToString().Length != 0) entity.Cfop = dt.Rows[i]["CFOP"].ToString();
                    if (dt.Rows[i]["COD_FORNECEDOR"].ToString().Length != 0) entity.CodFornecedor = dt.Rows[i]["COD_FORNECEDOR"].ToString();
                    if (dt.Rows[i]["COD_PROPRIETARIO"].ToString().Length != 0) entity.CodProprietario = dt.Rows[i]["COD_PROPRIETARIO"].ToString();
                    if (dt.Rows[i]["DATA_DOC"].ToString().Length != 0) entity.DataDoc = dt.Rows[i]["DATA_DOC"].ToString();
                    if (dt.Rows[i]["DATA_ENTRADA"].ToString().Length != 0) entity.DataEntrada = dt.Rows[i]["DATA_ENTRADA"].ToString();
                    if (dt.Rows[i]["DATA_GER_LEG"].ToString().Length != 0) entity.DataGerLeg = dt.Rows[i]["DATA_GER_LEG"].ToString();
                    if (dt.Rows[i]["DATA_NF"].ToString().Length != 0) entity.DataNf = dt.Rows[i]["DATA_NF"].ToString();
                    if (dt.Rows[i]["DOC_ORIGEM"].ToString().Length != 0) entity.DocOrigem = dt.Rows[i]["DOC_ORIGEM"].ToString();
                    if (dt.Rows[i]["ID_CORPORATIVO"].ToString().Length != 0) entity.IdCorporativo = dt.Rows[i]["ID_CORPORATIVO"].ToString();
                    if (dt.Rows[i]["NCM"].ToString().Length != 0) entity.Ncm = dt.Rows[i]["NCM"].ToString();
                    if (dt.Rows[i]["NF_E"].ToString().Length != 0) entity.NfE = dt.Rows[i]["NF_E"].ToString();
                    if (dt.Rows[i]["NUM_ADICAO"].ToString().Length != 0) entity.NumAdicao = dt.Rows[i]["NUM_ADICAO"].ToString();
                    if (dt.Rows[i]["NUM_DI_CAMBIAL"].ToString().Length != 0) entity.NumDiCambial = dt.Rows[i]["NUM_DI_CAMBIAL"].ToString();
                    if (dt.Rows[i]["NUM_ITEM"].ToString().Length != 0) entity.NumItem = Convert.ToDecimal(dt.Rows[i]["NUM_ITEM"]);
                    if (dt.Rows[i]["NUM_ITEM_ADICAO"].ToString().Length != 0) entity.NumItemAdicao = dt.Rows[i]["NUM_ITEM_ADICAO"].ToString();
                    if (dt.Rows[i]["ORGANIZACAO"].ToString().Length != 0) entity.Organizacao = dt.Rows[i]["ORGANIZACAO"].ToString();
                    if (dt.Rows[i]["PART_NUMBER"].ToString().Length != 0) entity.PartNumber = dt.Rows[i]["PART_NUMBER"].ToString();
                    if (dt.Rows[i]["PROCEDENCIA_INFO"].ToString().Length != 0) entity.ProcedenciaInfo = dt.Rows[i]["PROCEDENCIA_INFO"].ToString();
                    if (dt.Rows[i]["QTDE"].ToString().Length != 0) entity.Qtde = Convert.ToDecimal(dt.Rows[i]["QTDE"]);
                    if (dt.Rows[i]["REF_BAIXA"].ToString().Length != 0) entity.RefBaixa = dt.Rows[i]["REF_BAIXA"].ToString();
                    if (dt.Rows[i]["REF_ENTRADA"].ToString().Length != 0) entity.RefEntrada = dt.Rows[i]["REF_ENTRADA"].ToString();
                    if (dt.Rows[i]["REF_ERP_ENT"].ToString().Length != 0) entity.RefErpEnt = dt.Rows[i]["REF_ERP_ENT"].ToString();
                    if (dt.Rows[i]["REF_NFE"].ToString().Length != 0) entity.RefNfe = dt.Rows[i]["REF_NFE"].ToString();
                    if (dt.Rows[i]["SEGMENTO1"].ToString().Length != 0) entity.Segmento1 = dt.Rows[i]["SEGMENTO1"].ToString();
                    if (dt.Rows[i]["SEGMENTO2"].ToString().Length != 0) entity.Segmento2 = dt.Rows[i]["SEGMENTO2"].ToString();
                    if (dt.Rows[i]["SEGMENTO3"].ToString().Length != 0) entity.Segmento3 = dt.Rows[i]["SEGMENTO3"].ToString();
                    if (dt.Rows[i]["SEGMENTO4"].ToString().Length != 0) entity.Segmento4 = dt.Rows[i]["SEGMENTO4"].ToString();
                    if (dt.Rows[i]["SEGMENTO5"].ToString().Length != 0) entity.Segmento5 = dt.Rows[i]["SEGMENTO5"].ToString();
                    if (dt.Rows[i]["SERIE_E"].ToString().Length != 0) entity.SerieE = dt.Rows[i]["SERIE_E"].ToString();
                    if (dt.Rows[i]["TIPO_ENTRADA"].ToString().Length != 0) entity.TipoEntrada = dt.Rows[i]["TIPO_ENTRADA"].ToString();
                    if (dt.Rows[i]["VALOR_FISCAL"].ToString().Length != 0) entity.ValorFiscal = Convert.ToDecimal(dt.Rows[i]["VALOR_FISCAL"]);
                    if (dt.Rows[i]["VCTO_DI_CAMBIAL"].ToString().Length != 0) entity.VctoDiCambial = dt.Rows[i]["VCTO_DI_CAMBIAL"].ToString();
                    if (dt.Rows[i]["NUM_CONTRATO"].ToString().Length != 0) entity.NumContrato = dt.Rows[i]["NUM_CONTRATO"].ToString();
                    if (dt.Rows[i]["FINALIDADE_ENTRADA"].ToString().Length != 0) entity.FinalidadeEntrada = dt.Rows[i]["FINALIDADE_ENTRADA"].ToString();

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
            dict.Add("IdImportacao", "ID_IMPORTACAO");
            dict.Add("IdRef", "ID_REF");
            dict.Add("Cfop", "CFOP");
            dict.Add("CodFornecedor", "COD_FORNECEDOR");
            dict.Add("CodProprietario", "COD_PROPRIETARIO");
            dict.Add("DataDoc", "DATA_DOC");
            dict.Add("DataEntrada", "DATA_ENTRADA");
            dict.Add("DataGerLeg", "DATA_GER_LEG");
            dict.Add("DataNf", "DATA_NF");
            dict.Add("DocOrigem", "DOC_ORIGEM");
            dict.Add("IdCorporativo", "ID_CORPORATIVO");
            dict.Add("Ncm", "NCM");
            dict.Add("NfE", "NF_E");
            dict.Add("NumAdicao", "NUM_ADICAO");
            dict.Add("NumDiCambial", "NUM_DI_CAMBIAL");
            dict.Add("NumItem", "NUM_ITEM");
            dict.Add("NumItemAdicao", "NUM_ITEM_ADICAO");
            dict.Add("Organizacao", "ORGANIZACAO");
            dict.Add("PartNumber", "PART_NUMBER");
            dict.Add("ProcedenciaInfo", "PROCEDENCIA_INFO");
            dict.Add("Qtde", "QTDE");
            dict.Add("RefBaixa", "REF_BAIXA");
            dict.Add("RefEntrada", "REF_ENTRADA");
            dict.Add("RefErpEnt", "REF_ERP_ENT");
            dict.Add("RefNfe", "REF_NFE");
            dict.Add("Segmento1", "SEGMENTO1");
            dict.Add("Segmento2", "SEGMENTO2");
            dict.Add("Segmento3", "SEGMENTO3");
            dict.Add("Segmento4", "SEGMENTO4");
            dict.Add("Segmento5", "SEGMENTO5");
            dict.Add("SerieE", "SERIE_E");
            dict.Add("TipoEntrada", "TIPO_ENTRADA");
            dict.Add("ValorFiscal", "VALOR_FISCAL");
            dict.Add("VctoDiCambial", "VCTO_DI_CAMBIAL");
            dict.Add("NumContrato", "NUM_CONTRATO");
            dict.Add("FinalidadeEntrada", "FINALIDADE_ENTRADA");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
