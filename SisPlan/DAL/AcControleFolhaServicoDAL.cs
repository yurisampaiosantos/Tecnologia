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
    public class AcControleFolhaServicoDAL : BaseDAL
    {
        #region DML - DATA MANIPULATION LANGUAGE (I/U/D/S)
        static string strSelect = @"SELECT X.FOSE_ID, X.FOSE_CNTR_CODIGO, X.SBCN_ID, X.SBCN_SIGLA, X.DISC_ID, X.DISC_NOME, X.FOSE_NUMERO, X.FOSE_REV, X.FOSE_DESCRICAO, X.UNME_SIGLA, X.FCME_SIGLA, X.FCES_SIGLA, X.EQUIPE, X.SETOR, X.LOCALIZACAO, X.CLASSIFICADO, X.DESENHO, X.ORIGEM_FABRICACAO, X.AREA_PINTURA, REPLACE(TO_CHAR(X.FOSE_COMPRIMENTO),'.',',') AS FOSE_COMPRIMENTO, X.DESCRICAO_ESTRUTURA, X.DIAM, X.EMPRESA_RESPONSAVEL, X.NOTA, X.TSTF_UNIDADE_REGIONAL, X.REGIAO, X.SEMANA_FOLHA, X.SISTEMA, X.SPEC, X.TRATAMENTO, X.INDEFINIDO, REPLACE(TO_CHAR(X.FOSE_QTD_PREVISTA),'.',',') AS FOSE_QTD_PREVISTA, REPLACE(TO_CHAR(X.QTD_ACUMULADA),'.',',') AS QTD_ACUMULADA, X.MAX_FSME_DATA, X.SIFS_DESCRICAO, X.PROGRAMACAO, X.FOSE_STATUS, X.STATUS_TRATAMENTO, TO_CHAR(X.DT_STATUS_TRATAMENTO, 'DD/MM/YYYY') AS DT_STATUS_TRATAMENTO, X.LOCAL_ESTOCAGEM, X.LAST_UPDATE FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO X ";
        //====================================================================
        public static int Insert(DTO.AcControleFolhaServicoDTO entity, bool getIdentity)
        {
            string strSQL = "INSERT INTO EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO(FOSE_ID, FOSE_CNTR_CODIGO, SBCN_ID, SBCN_SIGLA, DISC_ID, DISC_NOME, FOSE_NUMERO, FOSE_REV, FOSE_DESCRICAO, UNME_SIGLA, FCME_SIGLA, FCES_SIGLA, EQUIPE, SETOR, LOCALIZACAO, CLASSIFICADO, DESENHO, ORIGEM_FABRICACAO, AREA_PINTURA, FOSE_COMPRIMENTO, DESCRICAO_ESTRUTURA, DIAM, EMPRESA_RESPONSAVEL, NOTA, REGIAO, SEMANA_FOLHA, SISTEMA, SPEC, TRATAMENTO, INDEFINIDO, FOSE_QTD_PREVISTA, QTD_ACUMULADA, SIFS_DESCRICAO, FOSE_STATUS, STATUS_TRATAMENTO, DT_STATUS_TRATAMENTO, LOCAL_ESTOCAGEM, MAX_FSME_DATA, TSTF_UNIDADE_REGIONAL, PROGRAMACAO) VALUES(:FOSE_ID, :FOSE_CNTR_CODIGO, :SBCN_ID, :SBCN_SIGLA, :DISC_ID, :DISC_NOME, :FOSE_NUMERO, :FOSE_REV, :FOSE_DESCRICAO, :UNME_SIGLA, :FCME_SIGLA, :FCES_SIGLA, :EQUIPE, :SETOR, :LOCALIZACAO, :CLASSIFICADO, :DESENHO, :ORIGEM_FABRICACAO, :AREA_PINTURA, :FOSE_COMPRIMENTO, :DESCRICAO_ESTRUTURA, :DIAM, :EMPRESA_RESPONSAVEL, :NOTA, :REGIAO, :SEMANA_FOLHA, :SISTEMA, :SPEC, :TRATAMENTO, :INDEFINIDO, :FOSE_QTD_PREVISTA, :QTD_ACUMULADA, :SIFS_DESCRICAO, :FOSE_STATUS, :STATUS_TRATAMENTO, :DT_STATUS_TRATAMENTO, :LOCAL_ESTOCAGEM, :MAX_FSME_DATA, :TSTF_UNIDADE_REGIONAL, :PROGRAMACAO)";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;
                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.FoseDescricao;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add(":CLASSIFICADO", OracleDbType.Varchar2).Value = entity.Classificado;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add(":AREA_PINTURA", OracleDbType.Varchar2).Value = entity.AreaPintura;
                cmd.Parameters.Add(":FOSE_COMPRIMENTO", OracleDbType.Decimal).Value = entity.FoseComprimento;
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":DIAM", OracleDbType.Varchar2).Value = entity.Diam;
                cmd.Parameters.Add(":EMPRESA_RESPONSAVEL", OracleDbType.Varchar2).Value = entity.EmpresaResponsavel;
                cmd.Parameters.Add(":NOTA", OracleDbType.Varchar2).Value = entity.Nota;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;
                cmd.Parameters.Add(":SEMANA_FOLHA", OracleDbType.Varchar2).Value = entity.SemanaFolha;
                cmd.Parameters.Add(":SISTEMA", OracleDbType.Varchar2).Value = entity.Sistema;
                cmd.Parameters.Add(":SPEC", OracleDbType.Varchar2).Value = entity.Spec;
                cmd.Parameters.Add(":TRATAMENTO", OracleDbType.Varchar2).Value = entity.Tratamento;
                cmd.Parameters.Add(":INDEFINIDO", OracleDbType.Varchar2).Value = entity.Indefinido;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":QTD_ACUMULADA", OracleDbType.Decimal).Value = entity.QtdAcumulada;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":FOSE_STATUS", OracleDbType.Varchar2).Value = entity.FoseStatus;
                cmd.Parameters.Add(":STATUS_TRATAMENTO", OracleDbType.Varchar2).Value = entity.StatusTratamento;
                if (entity.DtStatusTratamento.ToOADate() == 0.0) cmd.Parameters.Add(":DT_STATUS_TRATAMENTO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":DT_STATUS_TRATAMENTO", OracleDbType.Date).Value = entity.DtStatusTratamento;
                cmd.Parameters.Add(":LOCAL_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.LocalEstocagem;
                if (entity.MaxFsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":MAX_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":MAX_FSME_DATA", OracleDbType.Date).Value = entity.MaxFsmeData;
                cmd.Parameters.Add(":TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.TstfUnidadeRegional;
                cmd.Parameters.Add(":PROGRAMACAO", OracleDbType.Varchar2).Value = entity.Programacao;
                
                return OracleDataTools.ExecuteScalar(strSQL, cmd);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("Cannot insert duplicate key in object") != -1)
                {
                    throw new Exception("Cannot insert duplicate key in object - Inserting AcControleFolhaServico");
                }
                else
                {
                    throw new Exception(ex.Message + " - Inserting AcControleFolhaServico");
                }
            }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static void Update(DTO.AcControleFolhaServicoDTO entity)
        {
            //string strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO set FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, FOSE_NUMERO = :FOSE_NUMERO, FOSE_REV = :FOSE_REV, FOSE_DESCRICAO = :FOSE_DESCRICAO, UNME_SIGLA = :UNME_SIGLA, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, EQUIPE = :EQUIPE, SETOR = :SETOR, LOCALIZACAO = :LOCALIZACAO, CLASSIFICADO = :CLASSIFICADO, DESENHO = :DESENHO, ORIGEM_FABRICACAO = :ORIGEM_FABRICACAO, AREA_PINTURA = :AREA_PINTURA, 
            //FOSE_COMPRIMENTO = :FOSE_COMPRIMENTO, DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, DIAM = :DIAM, EMPRESA_RESPONSAVEL = :EMPRESA_RESPONSAVEL, NOTA = :NOTA, REGIAO = :REGIAO
            //, SEMANA_FOLHA = :SEMANA_FOLHA, SISTEMA = :SISTEMA, SPEC = :SPEC, TRATAMENTO = :TRATAMENTO, INDEFINIDO = :INDEFINIDO
            //, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA
            //, QTD_ACUMULADA = :QTD_ACUMULADA, SIFS_DESCRICAO = :SIFS_DESCRICAO, FOSE_STATUS = :FOSE_STATUS
            //, LAST_UPDATE = SYSDATE, STATUS_TRATAMENTO = :STATUS_TRATAMENTO, DT_STATUS_TRATAMENTO = :DT_STATUS_TRATAMENTO, LOCAL_ESTOCAGEM = :LOCAL_ESTOCAGEM
            //, MAX_FSME_DATA = :MAX_FSME_DATA, TSTF_UNIDADE_REGIONAL = :TSTF_UNIDADE_REGIONAL, PROGRAMACAO = :PROGRAMACAO WHERE FOSE_ID = : FOSE_ID";
            string strSQL = "UPDATE EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO set FOSE_CNTR_CODIGO = :FOSE_CNTR_CODIGO, SBCN_ID = :SBCN_ID, SBCN_SIGLA = :SBCN_SIGLA, DISC_ID = :DISC_ID, DISC_NOME = :DISC_NOME, FOSE_NUMERO = :FOSE_NUMERO, FOSE_REV = :FOSE_REV, FOSE_DESCRICAO = :FOSE_DESCRICAO, UNME_SIGLA = :UNME_SIGLA, FCME_SIGLA = :FCME_SIGLA, FCES_SIGLA = :FCES_SIGLA, EQUIPE = :EQUIPE, SETOR = :SETOR, LOCALIZACAO = :LOCALIZACAO, CLASSIFICADO = :CLASSIFICADO, DESENHO = :DESENHO, ORIGEM_FABRICACAO = :ORIGEM_FABRICACAO, AREA_PINTURA = :AREA_PINTURA, FOSE_COMPRIMENTO = :FOSE_COMPRIMENTO, DESCRICAO_ESTRUTURA = :DESCRICAO_ESTRUTURA, DIAM = :DIAM, EMPRESA_RESPONSAVEL = :EMPRESA_RESPONSAVEL, NOTA = :NOTA, REGIAO = :REGIAO, SEMANA_FOLHA = :SEMANA_FOLHA, SISTEMA = :SISTEMA, SPEC = :SPEC, TRATAMENTO = :TRATAMENTO, INDEFINIDO = :INDEFINIDO, FOSE_QTD_PREVISTA = :FOSE_QTD_PREVISTA, QTD_ACUMULADA = :QTD_ACUMULADA, SIFS_DESCRICAO = :SIFS_DESCRICAO, FOSE_STATUS = :FOSE_STATUS, LAST_UPDATE = SYSDATE, STATUS_TRATAMENTO = :STATUS_TRATAMENTO, DT_STATUS_TRATAMENTO = :DT_STATUS_TRATAMENTO, LOCAL_ESTOCAGEM = :LOCAL_ESTOCAGEM, MAX_FSME_DATA = :MAX_FSME_DATA, TSTF_UNIDADE_REGIONAL = :TSTF_UNIDADE_REGIONAL, PROGRAMACAO = :PROGRAMACAO WHERE FOSE_ID = : FOSE_ID";
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = CommandType.Text;
            try
            {

                cmd.Parameters.Add(":FOSE_CNTR_CODIGO", OracleDbType.Varchar2).Value = entity.FoseCntrCodigo;
                cmd.Parameters.Add(":SBCN_ID", OracleDbType.Decimal).Value = entity.SbcnId;
                cmd.Parameters.Add(":SBCN_SIGLA", OracleDbType.Varchar2).Value = entity.SbcnSigla;
                cmd.Parameters.Add(":DISC_ID", OracleDbType.Decimal).Value = entity.DiscId;
                cmd.Parameters.Add(":DISC_NOME", OracleDbType.Varchar2).Value = entity.DiscNome;
                cmd.Parameters.Add(":FOSE_NUMERO", OracleDbType.Varchar2).Value = entity.FoseNumero;
                cmd.Parameters.Add(":FOSE_REV", OracleDbType.Varchar2).Value = entity.FoseRev;
                cmd.Parameters.Add(":FOSE_DESCRICAO", OracleDbType.Varchar2).Value = entity.FoseDescricao;
                cmd.Parameters.Add(":UNME_SIGLA", OracleDbType.Varchar2).Value = entity.UnmeSigla;
                cmd.Parameters.Add(":FCME_SIGLA", OracleDbType.Varchar2).Value = entity.FcmeSigla;
                cmd.Parameters.Add(":FCES_SIGLA", OracleDbType.Varchar2).Value = entity.FcesSigla;
                cmd.Parameters.Add(":EQUIPE", OracleDbType.Varchar2).Value = entity.Equipe;
                cmd.Parameters.Add(":SETOR", OracleDbType.Varchar2).Value = entity.Setor;
                cmd.Parameters.Add(":LOCALIZACAO", OracleDbType.Varchar2).Value = entity.Localizacao;
                cmd.Parameters.Add(":CLASSIFICADO", OracleDbType.Varchar2).Value = entity.Classificado;
                cmd.Parameters.Add(":DESENHO", OracleDbType.Varchar2).Value = entity.Desenho;
                cmd.Parameters.Add(":ORIGEM_FABRICACAO", OracleDbType.Varchar2).Value = entity.OrigemFabricacao;
                cmd.Parameters.Add(":AREA_PINTURA", OracleDbType.Varchar2).Value = entity.AreaPintura;

                cmd.Parameters.Add(":FOSE_COMPRIMENTO", OracleDbType.Decimal).Value = Convert.ToDecimal(entity.FoseComprimento);
                cmd.Parameters.Add(":DESCRICAO_ESTRUTURA", OracleDbType.Varchar2).Value = entity.DescricaoEstrutura;
                cmd.Parameters.Add(":DIAM", OracleDbType.Varchar2).Value = entity.Diam;
                cmd.Parameters.Add(":EMPRESA_RESPONSAVEL", OracleDbType.Varchar2).Value = entity.EmpresaResponsavel;
                cmd.Parameters.Add(":NOTA", OracleDbType.Varchar2).Value = entity.Nota;
                cmd.Parameters.Add(":REGIAO", OracleDbType.Varchar2).Value = entity.Regiao;

                cmd.Parameters.Add(":SEMANA_FOLHA", OracleDbType.Varchar2).Value = entity.SemanaFolha;
                cmd.Parameters.Add(":SISTEMA", OracleDbType.Varchar2).Value = entity.Sistema;
                cmd.Parameters.Add(":SPEC", OracleDbType.Varchar2).Value = entity.Spec;
                cmd.Parameters.Add(":TRATAMENTO", OracleDbType.Varchar2).Value = entity.Tratamento;
                cmd.Parameters.Add(":INDEFINIDO", OracleDbType.Varchar2).Value = entity.Indefinido;
                cmd.Parameters.Add(":FOSE_QTD_PREVISTA", OracleDbType.Decimal).Value = entity.FoseQtdPrevista;
                cmd.Parameters.Add(":QTD_ACUMULADA", OracleDbType.Decimal).Value = entity.QtdAcumulada;
                cmd.Parameters.Add(":SIFS_DESCRICAO", OracleDbType.Varchar2).Value = entity.SifsDescricao;
                cmd.Parameters.Add(":FOSE_STATUS", OracleDbType.Varchar2).Value = entity.FoseStatus;
                cmd.Parameters.Add(":STATUS_TRATAMENTO", OracleDbType.Varchar2).Value = entity.StatusTratamento;
                if (entity.DtStatusTratamento.ToOADate() == 0.0) cmd.Parameters.Add(":DT_STATUS_TRATAMENTO", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":DT_STATUS_TRATAMENTO", OracleDbType.Date).Value = entity.DtStatusTratamento;
                cmd.Parameters.Add(":LOCAL_ESTOCAGEM", OracleDbType.Varchar2).Value = entity.LocalEstocagem;
                if (entity.MaxFsmeData.ToOADate() == 0.0) cmd.Parameters.Add(":MAX_FSME_DATA", OracleDbType.Date).Value = null;
                else cmd.Parameters.Add(":MAX_FSME_DATA", OracleDbType.Date).Value = entity.MaxFsmeData;
                cmd.Parameters.Add(":TSTF_UNIDADE_REGIONAL", OracleDbType.Varchar2).Value = entity.TstfUnidadeRegional;
                cmd.Parameters.Add(":PROGRAMACAO", OracleDbType.Varchar2).Value = entity.Programacao;

                cmd.Parameters.Add(":FOSE_ID", OracleDbType.Decimal).Value = entity.FoseId;

                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Updating AcControleFolhaServico"); }
            finally { cmd.Dispose(); }
        }
        //====================================================================
        public static int Count()
        {
            try
            {
                return Count(null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleFolhaServico"); }
        }
        //====================================================================
        public static int Count(string filter)
        {
            int NR = 0;
            string strSQL = "SELECT COUNT(*) FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO";
            if (filter != null) strSQL += " WHERE " + filter;
            try
            {
                NR = OracleDataTools.ExecuteScalar(strSQL);
                return NR;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Counting AcControleFolhaServico"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL, OracleCommand cmd)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL, cmd);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleFolhaServico"); }
        }
        //====================================================================
        public static void ExecuteSQLInstruction(string strSQL)
        {
            try
            {
                OracleDataTools.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex)
            { throw new Exception(ex.Message + " - Executing SQL Instruction AcControleFolhaServico"); }
        }
        //====================================================================
        public static DataTable Select(string strSQL)
        {
            return OracleDataTools.GetDataTable(strSQL);
        }
        //====================================================================
        public static DataTable SelectAvnFoseFromDataReader(string strSQL)
        {
            //decimal c = 0;
            //decimal fose = 0;
            DataTable dt = new DataTable();
            try
            {
                using (OracleConnection conn = new OracleConnection(OracleDataTools.StandardConnection))
                {
                    OracleDataReader dr;
                    OracleCommand oCmd = conn.CreateCommand();
                    DataRow mLine;
                    dt.Columns.Add(new DataColumn("FCES_CNTR_CODIGO", typeof(string)));
                    dt.Columns.Add(new DataColumn("FOSE_ID", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("FOSE_NUMERO", typeof(string)));
                    dt.Columns.Add(new DataColumn("FCME_SIGLA", typeof(string)));
                    dt.Columns.Add(new DataColumn("AVANCO", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("FCES_WBS", typeof(string)));
                    dt.Columns.Add(new DataColumn("FCES_FCME_ID", typeof(decimal)));
                    dt.Columns.Add(new DataColumn("DATA_AVANCO", typeof(string)));
                    conn.Open();
                    oCmd.CommandText = strSQL;
                    dr = oCmd.ExecuteReader();
                    while (dr.Read())
                    {
                        mLine = dt.NewRow();
                        //fose = Convert.ToDecimal(dr["FOSE_ID"]);
                        mLine["FCES_CNTR_CODIGO"] = Convert.ToString(dr["FCES_CNTR_CODIGO"]);
                        mLine["FOSE_ID"] = Convert.ToDecimal(dr["FOSE_ID"]);
                        mLine["FOSE_NUMERO"] = dr["FOSE_NUMERO"].ToString();
                        mLine["FCME_SIGLA"] = dr["FCME_SIGLA"].ToString();
                        mLine["AVANCO"] = Convert.ToDecimal(dr["AVANCO"]);
                        mLine["FCES_WBS"] = dr["FCES_WBS"].ToString();
                        mLine["FCES_FCME_ID"] = Convert.ToDecimal(dr["FCES_FCME_ID"]);
                        mLine["DATA_AVANCO"] = dr["DATA_AVANCO"].ToString();

                        dt.Rows.Add(mLine);
                        //c += 1;
                    }
                    dr.Close();
                }
                return dt;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableFOSE"); }

        }

        //====================================================================
        public static DataTable Get(string filter, string sortSequence)
        {
            try
            {
                string strSQL = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                return OracleDataTools.GetDataTable(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting DataTableAcControleFolhaServico"); }
        }
        //====================================================================
        public static DTO.AcControleFolhaServicoDTO Get(decimal foseID)
        {
            AcControleFolhaServicoDTO entity = new AcControleFolhaServicoDTO();
            DataTable dt = null;
            string filter = "FOSE_ID = " + foseID.ToString();
            dt = Get(filter, null);
            if ((dt.Rows[0]["FOSE_ID"] != null) && (dt.Rows[0]["FOSE_ID"] != DBNull.Value)) entity.FoseId = Convert.ToDecimal(dt.Rows[0]["FOSE_ID"]);
            if ((dt.Rows[0]["FOSE_CNTR_CODIGO"] != null) && (dt.Rows[0]["FOSE_CNTR_CODIGO"] != DBNull.Value)) entity.FoseCntrCodigo = Convert.ToString(dt.Rows[0]["FOSE_CNTR_CODIGO"]);
            if ((dt.Rows[0]["SBCN_ID"] != null) && (dt.Rows[0]["SBCN_ID"] != DBNull.Value)) entity.SbcnId = Convert.ToDecimal(dt.Rows[0]["SBCN_ID"]);
            if ((dt.Rows[0]["SBCN_SIGLA"] != null) && (dt.Rows[0]["SBCN_SIGLA"] != DBNull.Value)) entity.SbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]);
            if ((dt.Rows[0]["DISC_ID"] != null) && (dt.Rows[0]["DISC_ID"] != DBNull.Value)) entity.DiscId = Convert.ToDecimal(dt.Rows[0]["DISC_ID"]);
            if ((dt.Rows[0]["DISC_NOME"] != null) && (dt.Rows[0]["DISC_NOME"] != DBNull.Value)) entity.DiscNome = Convert.ToString(dt.Rows[0]["DISC_NOME"]);
            if ((dt.Rows[0]["FOSE_NUMERO"] != null) && (dt.Rows[0]["FOSE_NUMERO"] != DBNull.Value)) entity.FoseNumero = Convert.ToString(dt.Rows[0]["FOSE_NUMERO"]);
            if ((dt.Rows[0]["FOSE_REV"] != null) && (dt.Rows[0]["FOSE_REV"] != DBNull.Value)) entity.FoseRev = Convert.ToString(dt.Rows[0]["FOSE_REV"]);
            if ((dt.Rows[0]["FOSE_DESCRICAO"] != null) && (dt.Rows[0]["FOSE_DESCRICAO"] != DBNull.Value)) entity.FoseDescricao = Convert.ToString(dt.Rows[0]["FOSE_DESCRICAO"]);
            if ((dt.Rows[0]["UNME_SIGLA"] != null) && (dt.Rows[0]["UNME_SIGLA"] != DBNull.Value)) entity.UnmeSigla = Convert.ToString(dt.Rows[0]["UNME_SIGLA"]);
            if ((dt.Rows[0]["FCME_SIGLA"] != null) && (dt.Rows[0]["FCME_SIGLA"] != DBNull.Value)) entity.FcmeSigla = Convert.ToString(dt.Rows[0]["FCME_SIGLA"]);
            if ((dt.Rows[0]["FCES_SIGLA"] != null) && (dt.Rows[0]["FCES_SIGLA"] != DBNull.Value)) entity.FcesSigla = Convert.ToString(dt.Rows[0]["FCES_SIGLA"]);
            if ((dt.Rows[0]["EQUIPE"] != null) && (dt.Rows[0]["EQUIPE"] != DBNull.Value)) entity.Equipe = Convert.ToString(dt.Rows[0]["EQUIPE"]);
            if ((dt.Rows[0]["SETOR"] != null) && (dt.Rows[0]["SETOR"] != DBNull.Value)) entity.Setor = Convert.ToString(dt.Rows[0]["SETOR"]);
            if ((dt.Rows[0]["LOCALIZACAO"] != null) && (dt.Rows[0]["LOCALIZACAO"] != DBNull.Value)) entity.Localizacao = Convert.ToString(dt.Rows[0]["LOCALIZACAO"]);
            if ((dt.Rows[0]["CLASSIFICADO"] != null) && (dt.Rows[0]["CLASSIFICADO"] != DBNull.Value)) entity.Classificado = Convert.ToString(dt.Rows[0]["CLASSIFICADO"]);
            if ((dt.Rows[0]["DESENHO"] != null) && (dt.Rows[0]["DESENHO"] != DBNull.Value)) entity.Desenho = Convert.ToString(dt.Rows[0]["DESENHO"]);
            if ((dt.Rows[0]["ORIGEM_FABRICACAO"] != null) && (dt.Rows[0]["ORIGEM_FABRICACAO"] != DBNull.Value)) entity.OrigemFabricacao = Convert.ToString(dt.Rows[0]["ORIGEM_FABRICACAO"]);
            if ((dt.Rows[0]["AREA_PINTURA"] != null) && (dt.Rows[0]["AREA_PINTURA"] != DBNull.Value)) entity.AreaPintura = Convert.ToString(dt.Rows[0]["AREA_PINTURA"]);
            if ((dt.Rows[0]["FOSE_COMPRIMENTO"] != null) && (dt.Rows[0]["FOSE_COMPRIMENTO"] != DBNull.Value)) entity.FoseComprimento = Convert.ToDecimal(dt.Rows[0]["FOSE_COMPRIMENTO"]);
            if ((dt.Rows[0]["DESCRICAO_ESTRUTURA"] != null) && (dt.Rows[0]["DESCRICAO_ESTRUTURA"] != DBNull.Value)) entity.DescricaoEstrutura = Convert.ToString(dt.Rows[0]["DESCRICAO_ESTRUTURA"]);
            if ((dt.Rows[0]["DIAM"] != null) && (dt.Rows[0]["DIAM"] != DBNull.Value)) entity.Diam = Convert.ToString(dt.Rows[0]["DIAM"]);
            if ((dt.Rows[0]["EMPRESA_RESPONSAVEL"] != null) && (dt.Rows[0]["EMPRESA_RESPONSAVEL"] != DBNull.Value)) entity.EmpresaResponsavel = Convert.ToString(dt.Rows[0]["EMPRESA_RESPONSAVEL"]);
            if ((dt.Rows[0]["NOTA"] != null) && (dt.Rows[0]["NOTA"] != DBNull.Value)) entity.Nota = Convert.ToString(dt.Rows[0]["NOTA"]);
            if ((dt.Rows[0]["REGIAO"] != null) && (dt.Rows[0]["REGIAO"] != DBNull.Value)) entity.Regiao = Convert.ToString(dt.Rows[0]["REGIAO"]);
            if ((dt.Rows[0]["SEMANA_FOLHA"] != null) && (dt.Rows[0]["SEMANA_FOLHA"] != DBNull.Value)) entity.SemanaFolha = Convert.ToString(dt.Rows[0]["SEMANA_FOLHA"]);
            if ((dt.Rows[0]["SISTEMA"] != null) && (dt.Rows[0]["SISTEMA"] != DBNull.Value)) entity.Sistema = Convert.ToString(dt.Rows[0]["SISTEMA"]);
            if ((dt.Rows[0]["SPEC"] != null) && (dt.Rows[0]["SPEC"] != DBNull.Value)) entity.Spec = Convert.ToString(dt.Rows[0]["SPEC"]);
            if ((dt.Rows[0]["TRATAMENTO"] != null) && (dt.Rows[0]["TRATAMENTO"] != DBNull.Value)) entity.Tratamento = Convert.ToString(dt.Rows[0]["TRATAMENTO"]);
            if ((dt.Rows[0]["INDEFINIDO"] != null) && (dt.Rows[0]["INDEFINIDO"] != DBNull.Value)) entity.Indefinido = Convert.ToString(dt.Rows[0]["INDEFINIDO"]);
            if ((dt.Rows[0]["FOSE_QTD_PREVISTA"] != null) && (dt.Rows[0]["FOSE_QTD_PREVISTA"] != DBNull.Value)) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[0]["FOSE_QTD_PREVISTA"]);
            if ((dt.Rows[0]["QTD_ACUMULADA"] != null) && (dt.Rows[0]["QTD_ACUMULADA"] != DBNull.Value)) entity.QtdAcumulada = Convert.ToDecimal(dt.Rows[0]["QTD_ACUMULADA"]);
            if ((dt.Rows[0]["SIFS_DESCRICAO"] != null) && (dt.Rows[0]["SIFS_DESCRICAO"] != DBNull.Value)) entity.SifsDescricao = Convert.ToString(dt.Rows[0]["SIFS_DESCRICAO"]);
            if ((dt.Rows[0]["FOSE_STATUS"] != null) && (dt.Rows[0]["FOSE_STATUS"] != DBNull.Value)) entity.FoseStatus = Convert.ToString(dt.Rows[0]["FOSE_STATUS"]);
            if ((dt.Rows[0]["LAST_UPDATE"] != null) && (dt.Rows[0]["LAST_UPDATE"] != DBNull.Value)) entity.LastUpdate = Convert.ToDateTime(dt.Rows[0]["LAST_UPDATE"]);


            if ((dt.Rows[0]["STATUS_TRATAMENTO"] != null) && (dt.Rows[0]["STATUS_TRATAMENTO"] != DBNull.Value)) entity.StatusTratamento = Convert.ToString(dt.Rows[0]["STATUS_TRATAMENTO"]);
            if ((dt.Rows[0]["DT_STATUS_TRATAMENTO"] != null) && (dt.Rows[0]["DT_STATUS_TRATAMENTO"] != DBNull.Value)) entity.DtStatusTratamento = Convert.ToDateTime(dt.Rows[0]["DT_STATUS_TRATAMENTO"]);
            if ((dt.Rows[0]["LOCAL_ESTOCAGEM"] != null) && (dt.Rows[0]["LOCAL_ESTOCAGEM"] != DBNull.Value)) entity.LocalEstocagem = Convert.ToString(dt.Rows[0]["LOCAL_ESTOCAGEM"]);
            if ((dt.Rows[0]["MAX_FSME_DATA"] != null) && (dt.Rows[0]["MAX_FSME_DATA"] != DBNull.Value)) entity.MaxFsmeData = Convert.ToDateTime(dt.Rows[0]["MAX_FSME_DATA"]);
            if ((dt.Rows[0]["TSTF_UNIDAE_REGIONAL"] != null) && (dt.Rows[0]["TSTF_UNIDAE_REGIONAL"] != DBNull.Value)) entity.TstfUnidadeRegional = Convert.ToString(dt.Rows[0]["TSTF_UNIDAE_REGIONAL"]);
            if ((dt.Rows[0]["PROGRAMACAO"] != null) && (dt.Rows[0]["PROGRAMACAO"] != DBNull.Value)) entity.Programacao = Convert.ToString(dt.Rows[0]["PROGRAMACAO"]);

            return entity;
        }
        //====================================================================
        public static DTO.AcControleFolhaServicoDTO GetObject(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence))[0];
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CREATED_DATE Object"); }
        }
        //====================================================================
        public static List<AcControleFolhaServicoDTO> GetList(string filter, string sortSequence)
        {
            try
            {
                strSelect = OracleDataTools.ApplySQLComplement(strSelect, filter, sortSequence);
                List<AcControleFolhaServicoDTO> list = OracleDataTools.LoadEntity<AcControleFolhaServicoDTO>(strSelect);
                return list;
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleFolhaServicoDTO>"); }
        }
        //====================================================================
        public static List<AcControleFolhaServicoDTO> GetList(string sortSequence)
        {
            try
            {
                return GetList(null, sortSequence);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleFolhaServicoDTO>"); }
        }
        //====================================================================
        public static List<AcControleFolhaServicoDTO> GetList()
        {
            try
            {
                return GetList(null, null);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting List<AcControleFolhaServicoDTO>"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleFolhaServicoDTO GetCollection(string filter, string sortSequence)
        {
            try
            {
                return GetCollection(Get(filter, sortSequence));
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - Getting CollectionAcControleFolhaServico"); }
        }
        //====================================================================
        public static DTO.CollectionAcControleFolhaServicoDTO GetCollection(DataTable dt)
        {
            DTO.CollectionAcControleFolhaServicoDTO collection = new DTO.CollectionAcControleFolhaServicoDTO();
            try
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DTO.AcControleFolhaServicoDTO entity = new DTO.AcControleFolhaServicoDTO();

                    if (dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString().Length != 0) entity.FoseCntrCodigo = dt.Rows[i]["FOSE_CNTR_CODIGO"].ToString();
                    if (dt.Rows[i]["SBCN_ID"].ToString().Length != 0) entity.SbcnId = Convert.ToDecimal(dt.Rows[i]["SBCN_ID"]);
                    if (dt.Rows[i]["SBCN_SIGLA"].ToString().Length != 0) entity.SbcnSigla = dt.Rows[i]["SBCN_SIGLA"].ToString();
                    if (dt.Rows[i]["DISC_ID"].ToString().Length != 0) entity.DiscId = Convert.ToDecimal(dt.Rows[i]["DISC_ID"]);
                    if (dt.Rows[i]["DISC_NOME"].ToString().Length != 0) entity.DiscNome = dt.Rows[i]["DISC_NOME"].ToString();
                    if (dt.Rows[i]["FOSE_ID"].ToString().Length != 0) entity.FoseId = Convert.ToDecimal(dt.Rows[i]["FOSE_ID"]);
                    if (dt.Rows[i]["FOSE_NUMERO"].ToString().Length != 0) entity.FoseNumero = dt.Rows[i]["FOSE_NUMERO"].ToString();
                    if (dt.Rows[i]["FOSE_REV"].ToString().Length != 0) entity.FoseRev = dt.Rows[i]["FOSE_REV"].ToString();
                    if (dt.Rows[i]["FOSE_DESCRICAO"].ToString().Length != 0) entity.FoseDescricao = dt.Rows[i]["FOSE_DESCRICAO"].ToString();
                    if (dt.Rows[i]["UNME_SIGLA"].ToString().Length != 0) entity.UnmeSigla = dt.Rows[i]["UNME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCME_SIGLA"].ToString().Length != 0) entity.FcmeSigla = dt.Rows[i]["FCME_SIGLA"].ToString();
                    if (dt.Rows[i]["FCES_SIGLA"].ToString().Length != 0) entity.FcesSigla = dt.Rows[i]["FCES_SIGLA"].ToString();
                    if (dt.Rows[i]["EQUIPE"].ToString().Length != 0) entity.Equipe = dt.Rows[i]["EQUIPE"].ToString();
                    if (dt.Rows[i]["SETOR"].ToString().Length != 0) entity.Setor = dt.Rows[i]["SETOR"].ToString();
                    if (dt.Rows[i]["LOCALIZACAO"].ToString().Length != 0) entity.Localizacao = dt.Rows[i]["LOCALIZACAO"].ToString();
                    if (dt.Rows[i]["CLASSIFICADO"].ToString().Length != 0) entity.Classificado = dt.Rows[i]["CLASSIFICADO"].ToString();
                    if (dt.Rows[i]["DESENHO"].ToString().Length != 0) entity.Desenho = dt.Rows[i]["DESENHO"].ToString();
                    if (dt.Rows[i]["ORIGEM_FABRICACAO"].ToString().Length != 0) entity.OrigemFabricacao = dt.Rows[i]["ORIGEM_FABRICACAO"].ToString();
                    if (dt.Rows[i]["AREA_PINTURA"].ToString().Length != 0) entity.AreaPintura = dt.Rows[i]["AREA_PINTURA"].ToString();
                    if (dt.Rows[i]["FOSE_COMPRIMENTO"].ToString().Length != 0) entity.FoseComprimento = Convert.ToDecimal(dt.Rows[i]["FOSE_COMPRIMENTO"]);
                    if (dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString().Length != 0) entity.DescricaoEstrutura = dt.Rows[i]["DESCRICAO_ESTRUTURA"].ToString();
                    if (dt.Rows[i]["DIAM"].ToString().Length != 0) entity.Diam = dt.Rows[i]["DIAM"].ToString();
                    if (dt.Rows[i]["EMPRESA_RESPONSAVEL"].ToString().Length != 0) entity.EmpresaResponsavel = dt.Rows[i]["EMPRESA_RESPONSAVEL"].ToString();
                    if (dt.Rows[i]["NOTA"].ToString().Length != 0) entity.Nota = dt.Rows[i]["NOTA"].ToString();
                    if (dt.Rows[i]["REGIAO"].ToString().Length != 0) entity.Regiao = dt.Rows[i]["REGIAO"].ToString();
                    if (dt.Rows[i]["SEMANA_FOLHA"].ToString().Length != 0) entity.SemanaFolha = dt.Rows[i]["SEMANA_FOLHA"].ToString();
                    if (dt.Rows[i]["SISTEMA"].ToString().Length != 0) entity.Sistema = dt.Rows[i]["SISTEMA"].ToString();
                    if (dt.Rows[i]["SPEC"].ToString().Length != 0) entity.Spec = dt.Rows[i]["SPEC"].ToString();
                    if (dt.Rows[i]["TRATAMENTO"].ToString().Length != 0) entity.Tratamento = dt.Rows[i]["TRATAMENTO"].ToString();
                    if (dt.Rows[i]["INDEFINIDO"].ToString().Length != 0) entity.Indefinido = dt.Rows[i]["INDEFINIDO"].ToString();
                    if (dt.Rows[i]["FOSE_QTD_PREVISTA"].ToString().Length != 0) entity.FoseQtdPrevista = Convert.ToDecimal(dt.Rows[i]["FOSE_QTD_PREVISTA"]);
                    if (dt.Rows[i]["QTD_ACUMULADA"].ToString().Length != 0) entity.QtdAcumulada = Convert.ToDecimal(dt.Rows[i]["QTD_ACUMULADA"]);
                    if (dt.Rows[i]["SIFS_DESCRICAO"].ToString().Length != 0) entity.SifsDescricao = dt.Rows[i]["SIFS_DESCRICAO"].ToString();
                    if (dt.Rows[i]["FOSE_STATUS"].ToString().Length != 0) entity.FoseStatus = dt.Rows[i]["FOSE_STATUS"].ToString();
                    if (dt.Rows[i]["LAST_UPDATE"].ToString().Length != 0) entity.LastUpdate = Convert.ToDateTime(dt.Rows[i]["LAST_UPDATE"]);

                    if (dt.Rows[i]["STATUS_TRATAMENTO"].ToString().Length != 0) entity.StatusTratamento = dt.Rows[i]["STATUS_TRATAMENTO"].ToString();
                    if (dt.Rows[i]["DT_STATUS_TRATAMENTO"].ToString().Length != 0) entity.DtStatusTratamento = Convert.ToDateTime(dt.Rows[i]["DT_STATUS_TRATAMENTO"]);
                    if (dt.Rows[i]["LOCAL_ESTOCAGEM"].ToString().Length != 0) entity.LocalEstocagem = dt.Rows[i]["LOCAL_ESTOCAGEM"].ToString();
                    if (dt.Rows[i]["MAX_FSME_DATA"].ToString().Length != 0) entity.MaxFsmeData = Convert.ToDateTime(dt.Rows[i]["MAX_FSME_DATA"]);
                    if (dt.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString().Length != 0) entity.TstfUnidadeRegional = dt.Rows[i]["TSTF_UNIDADE_REGIONAL"].ToString();
                    if (dt.Rows[i]["PROGRAMACAO"].ToString().Length != 0) entity.Programacao = dt.Rows[i]["PROGRAMACAO"].ToString();

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

            dict.Add("FoseCntrCodigo", "FOSE_CNTR_CODIGO");
            dict.Add("SbcnId", "SBCN_ID");
            dict.Add("SbcnSigla", "SBCN_SIGLA");
            dict.Add("DiscId", "DISC_ID");
            dict.Add("DiscNome", "DISC_NOME");
            dict.Add("FoseId", "FOSE_ID");
            dict.Add("FoseNumero", "FOSE_NUMERO");
            dict.Add("FoseRev", "FOSE_REV");
            dict.Add("FoseDescricao", "FOSE_DESCRICAO");
            dict.Add("UnmeSigla", "UNME_SIGLA");
            dict.Add("FcmeSigla", "FCME_SIGLA");
            dict.Add("FcesSigla", "FCES_SIGLA");
            dict.Add("Equipe", "EQUIPE");
            dict.Add("Setor", "SETOR");
            dict.Add("Localizacao", "LOCALIZACAO");
            dict.Add("Classificado", "CLASSIFICADO");
            dict.Add("Desenho", "DESENHO");
            dict.Add("OrigemFabricacao", "ORIGEM_FABRICACAO");
            dict.Add("AreaPintura", "AREA_PINTURA");
            dict.Add("FoseComprimento", "FOSE_COMPRIMENTO");
            dict.Add("DescricaoEstrutura", "DESCRICAO_ESTRUTURA");
            dict.Add("Diam", "DIAM");
            dict.Add("EmpresaResponsavel", "EMPRESA_RESPONSAVEL");
            dict.Add("Nota", "NOTA");
            dict.Add("Regiao", "REGIAO");
            dict.Add("SemanaFolha", "SEMANA_FOLHA");
            dict.Add("Sistema", "SISTEMA");
            dict.Add("Spec", "SPEC");
            dict.Add("Tratamento", "TRATAMENTO");
            dict.Add("Indefinido", "INDEFINIDO");
            dict.Add("FoseQtdPrevista", "FOSE_QTD_PREVISTA");
            dict.Add("QtdAcumulada", "QTD_ACUMULADA");
            dict.Add("SifsDescricao", "SIFS_DESCRICAO");
            dict.Add("FoseStatus", "FOSE_STATUS");
            dict.Add("LastUpdate", "LAST_UPDATE");

            dict.Add("statusTratamento", "STATUS_TRATAMENTO");
            dict.Add("DtStatusTratamento", "DT_STATUS_TRATAMENTO");
            dict.Add("LocalEstocagem", "LOCAL_ESTOCAGEM");

            dict.Add("MaxFsmeData", "MAX_FSME_DATA");
            dict.Add("TstfUnidadeRegional", "TSTF_UNIDADE_REGIONAL");
            dict.Add("Programacao", "PROGRAMACAO");
            return dict;
        }
        //====================================================================
        #endregion
    }
}
