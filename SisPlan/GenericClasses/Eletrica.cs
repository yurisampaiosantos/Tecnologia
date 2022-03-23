using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;
using System.IO;
//using System.Windows.Forms;

namespace GenericClasses
{
    public class Eletrica
    {
        static bool restricaoMaterial = false;
        static DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();

        //============================================
        public static bool IsValidEleSpreadsheet(DataTable dtSpreadsheet, string fileName, string logFolder, StreamWriter log, string disciplina)
        {
            bool bRet = true;
            string header = "";
            int numCol;
            //Valida estrutura da planilha
            string[] columns = { "CODIGO", "UNIDADE_PROCESSO", "LOCAL", "DESENHO", "REVISAO", "TAG", "DESCRICAO", "DIMENSAO", "QUANT_PROJETO", "QUANT_REAL", "UNIDADE" };
            numCol = columns.Length;
            for (int c = 0; c < columns.Length; c++)
            {
                header += "|" + columns[c];
            }
            header = header.Substring(1);
            for (int i = 0; i < columns.Length - 1; i++)
            {
                if (dtSpreadsheet.Columns[i].ColumnName.ToUpper() != columns[i].ToUpper())
                {
                    H.ProcessHistory = "A estrutura da planilha deve obedecer a estrutura abaixo: " + Convert.ToChar(13) + Convert.ToChar(10);
                    GenericClasses.Log.SaveLog(log, H);
                    H.ProcessHistory = header;
                    GenericClasses.Log.SaveLog(log, H);
                    bRet = false;
                    break;
                }

            }
            if (bRet) bRet = GenericClasses.Eletrica.VerificaExistenciaCamposObrigatoriosEle(log, dtSpreadsheet);
            if (bRet) bRet = GenericClasses.SpreadSheets.ValidaCodigoProduto(log, dtSpreadsheet, "CODIGO", disciplina, fileName, ref restricaoMaterial);
            //Fim
            if (bRet)
            {
                H.ProcessHistory = "A Planilha atendeu aos requisitos básicos para ser processada.";
                GenericClasses.Log.SaveLog(log, H);
            }
            H.ProcessHistory = "Término da Validação da planilha                                          : " + System.DateTime.Now;
            GenericClasses.Log.SaveLog(log, H);

            return bRet;
        }
        //============================================
        public static void SaveProjEleRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        {
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_ELE_RCPT WHERE file_name = '" + fileName + "'";
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction(strSQL);
            //Gravar tabela PROJ_ELE_RCPT
            for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
            {
                //Grava Recepcao no Banco de Dados referente a disciplina Tubulacao
                DTO.ProjEleRcptDTO entity = new DTO.ProjEleRcptDTO();
                entity.Codigo = dtProjRcpt.Rows[i]["CODIGO"].ToString().Trim();
                entity.UnidadeProcesso = dtProjRcpt.Rows[i]["UNIDADE_PROCESSO"].ToString().Trim();
                entity.Local = dtProjRcpt.Rows[i]["LOCAL"].ToString().Trim();
                entity.Desenho = dtProjRcpt.Rows[i]["DESENHO"].ToString().Trim();
                entity.Revisao = dtProjRcpt.Rows[i]["REVISAO"].ToString().Trim();
                entity.Tag = dtProjRcpt.Rows[i]["TAG"].ToString().Trim();
                entity.Descricao = dtProjRcpt.Rows[i]["DESCRICAO"].ToString().Trim();
                entity.Dimensao = dtProjRcpt.Rows[i]["DIMENSAO"].ToString().Trim();
                entity.QuantProjeto = Convert.ToString(dtProjRcpt.Rows[i]["QUANT_PROJETO"]);
                entity.QuantReal = Convert.ToString(dtProjRcpt.Rows[i]["QUANT_REAL"]);
                entity.Unidade = dtProjRcpt.Rows[i]["UNIDADE"].ToString().Trim();
                entity.CreatedBy = userId;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = System.DateTime.Now;
                entity.FileName = fileName;
                try { BLL.ProjEleRcptBLL.Insert(entity, false); }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            H.ProcessHistory = "A planilha " + fileName + " foi incorporada ao banco de dados ";
            GenericClasses.Log.SaveLog(log, H);
        }
        //====================================================================
        public static DataTable CreateEleHeaderFOSE()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Coluna 1", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 3", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 5", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 6", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 7", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 8", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 9", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 10", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 11", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 12", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 13", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 14", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 15", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 16", typeof(string)));
           
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Número"; row["Coluna 2"] = "Revisão"; row["Coluna 3"] = "Situação"; row["Coluna 4"] = "Critério Medição"; row["Coluna 5"] = "Descrição";
            row["Coluna 6"] = "Sub Contrato"; row["Coluna 7"] = "Unidade Processo"; row["Coluna 8"] = "Área Aplicação"; row["Coluna 9"] = "Produto Fabricado"; row["Coluna 10"] = "Observação";
            row["Coluna 11"] = "Qtd. Prev."; row["Coluna 12"] = "Qtd. Real"; row["Coluna 13"] = "Unid. Medida"; row["Coluna 14"] = "Desenho"; row["Coluna 15"] = "Tratamento";
            row["Coluna 16"] = "Região"; 

            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Texto"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Número"; row["Coluna 12"] = "Número"; row["Coluna 13"] = "Texto"; row["Coluna 14"] = "Texto"; row["Coluna 15"] = "Lógico";
            row["Coluna 16"] = "Número";
            
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'10"; row["Coluna 3"] = "'30"; row["Coluna 4"] = "'50"; row["Coluna 5"] = "'2000";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'50"; row["Coluna 9"] = "'400"; row["Coluna 10"] = "'4000";
            row["Coluna 11"] = "'22"; row["Coluna 12"] = "'22"; row["Coluna 13"] = "'10"; row["Coluna 14"] = "'4000"; row["Coluna 15"] = "'200";
            row["Coluna 16"] = "'4000";
            
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Obrigatório"; row["Coluna 8"] = "Opcional"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional"; row["Coluna 12"] = "Opcional"; row["Coluna 13"] = "Opcional"; row["Coluna 14"] = "Opcional"; row["Coluna 15"] = "Opcional";
            row["Coluna 16"] = "Opcional";

            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único"; row["Coluna 12"] = "Não Único"; row["Coluna 13"] = "Não Único"; row["Coluna 14"] = "Não Único"; row["Coluna 15"] = "Não Único";
            row["Coluna 16"] = "Não Único";
            
            dt.Rows.Add(row);

            return dt;
        }
        //====================================================================
        public static void FillDataTableFOSE(ref DataTable dtProjFOSE, string fileName, string plataforma)
        {
            string strSQL = @"SELECT X.ID, X.CODIGO, X.UNIDADE_PROCESSO, X.LOCAL, X.DESENHO, X.REVISAO, X.TAG, X.DESCRICAO, X.DIMENSAO, X.QUANT_PROJETO, X.QUANT_REAL, X.UNIDADE, X.CREATED_BY, CREATED_DATE, X.MODIFIED_BY, MODIFIED_DATE, X.FILE_NAME FROM EEP_CONVERSION.PROJ_ELE_RCPT X WHERE file_name = '" + fileName + "'";
            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PROTUGUÊS DO BRASIL
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjEleRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;
            //Insere o DataTable na Tabela PROJ_TUB_FOSE excluindo o cabeçalho(6 linhas)
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                row = dtProjFOSE.NewRow();
                row["Coluna 1"] = dtAUX.Rows[r]["TAG"].ToString();
                row["Coluna 2"] = dtAUX.Rows[r]["REVISAO"].ToString();
                row["Coluna 3"] = "Liberada";
                row["Coluna 4"] = "SUP_ELETRICA_MONT";
                row["Coluna 5"] = dtAUX.Rows[r]["DESCRICAO"].ToString();
                row["Coluna 6"] = plataforma;
                row["Coluna 7"] = "";
                row["Coluna 8"] = "";
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "";
                row["Coluna 12"] = "";
                row["Coluna 13"] = dtAUX.Rows[r]["UNIDADE"].ToString();
                row["Coluna 14"] = dtAUX.Rows[r]["DESENHO"].ToString();
                row["Coluna 15"] = "";
                row["Coluna 16"] = dtAUX.Rows[r]["LOCAL"].ToString();
                
                dtProjFOSE.Rows.Add(row);
            }
        }
        //====================================================================
        public static DataTable CreateEleHeaderPROD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Coluna 1", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 3", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 5", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 6", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 7", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 8", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 9", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 10", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 11", typeof(string)));
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Folha de Serviço"; row["Coluna 2"] = "Tipo"; row["Coluna 3"] = "Origem"; row["Coluna 4"] = "Código Recurso"; row["Coluna 5"] = "Dim 1";
            row["Coluna 6"] = "Dim 2"; row["Coluna 7"] = "Dim 3"; row["Coluna 8"] = "Qtd. Necessária"; row["Coluna 9"] = "Etapa de Medição"; row["Coluna 10"] = "Certificado";
            row["Coluna 11"] = "UA";
            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Número"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Texto";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'4000"; row["Coluna 3"] = "'4000"; row["Coluna 4"] = "'4000"; row["Coluna 5"] = "'50";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'22"; row["Coluna 9"] = "'50"; row["Coluna 10"] = "'100";
            row["Coluna 11"] = "'100";
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Opcional"; row["Coluna 8"] = "Obrigatório"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Não Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único";
            dt.Rows.Add(row);
            return dt;
        }
        //============================================
        public static bool VerificaExistenciaCamposObrigatoriosEle(StreamWriter log, DataTable dtSpreadsheet)
        {
            int line = 0;
            bool bRet = true;
            //bool bBlankLine = true;
            try
            {
                for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
                {
                    line = i + 2;
                    //if (dtSpreadsheet.Rows[i]["CODIGO"].ToString().Trim() == "") { GenericClasses.Log.SaveLog(log, "Linha " + (line).ToString() + " ==>  Coluna CODIGO - em branco"); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["UNIDADE_PROCESSO"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna UNIDADE_PROCESSO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["LOCAL"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna LOCAL - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DESENHO"].ToString().Trim() == "") { 
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna DESENHO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["REVISAO"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna REVISAO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DESCRICAO"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna DESCRICAO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    //if (dtSpreadsheet.Rows[i]["DIMENSAO"].ToString().Trim() == "") { GenericClasses.Log.SaveLog(log, "Linha " + (line).ToString() + " ==>  Coluna DIMENSAO - em branco"); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["QUANT_PROJETO"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna QUANT_PROJETO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    //if (dtSpreadsheet.Rows[i]["QUANT_REAL"].ToString().Trim() == "")  { GenericClasses.Log.SaveLog(log, "Linha " + (line).ToString() + " ==>  Coluna QUANT_REAL - em branco"); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["UNIDADE"].ToString().Trim() == "") {
                        H.ProcessHistory = "Linha " + (line).ToString() + " ==>  Coluna UNIDADE - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bRet;
        }
        //====================================================================
        public static void FillDataTablePROD(ref DataTable dtProjPROD, string fileName)
        {
            string strSQL = @"SELECT X.ID, X.CODIGO, X.UNIDADE_PROCESSO, X.LOCAL, X.DESENHO, X.REVISAO, X.TAG, X.DESCRICAO, X.DIMENSAO, X.QUANT_PROJETO, X.QUANT_REAL, X.UNIDADE, X.CREATED_BY, CREATED_DATE, X.MODIFIED_BY, MODIFIED_DATE, X.FILE_NAME FROM PROJ_ELE_RCPT X WHERE file_name = '" + fileName + "'";
            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PROTUGUÊS DO BRASIL
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjEleRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjEleRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;
            //Insere o DataTable na Tabela PROJ_TUB_FOSE excluindo o cabeçalho(6 linhas)
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                row = dtProjPROD.NewRow();
                row["Coluna 1"] = dtAUX.Rows[r]["TAG"].ToString();
                row["Coluna 2"] = "Produto Consumido";
                row["Coluna 3"] = "Material";
                row["Coluna 4"] = "";
                row["Coluna 5"] = "";
                row["Coluna 6"] = "";
                row["Coluna 7"] = "";
                row["Coluna 8"] = dtAUX.Rows[r]["QUANT_PROJETO"].ToString();
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "";
                dtProjPROD.Rows.Add(row);
            }
        }
        //====================================================================
    }
}
