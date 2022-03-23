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
    public class Outfitting
    {
        static DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();
        static bool restricaoMaterial = false;
        //============================================
        public static bool IsValidOutSpreadsheet(DataTable dtSpreadsheet, string fileName, string logFolder, StreamWriter log, string disciplina)
        {
            bool bRet = true;
            string header = "";
            int numCol;
            DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();
            //Valida estrutura da planilha
            string[] columns = { "Area", "Desenho", "Rev", "Tag", "Codigo", "Material", "Dim1", "Dim2", "Dim3", "Qtd", "Unid", "Mult", "Weight", "Tipo", "Treatment" };
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
            if (bRet) bRet = GenericClasses.Outfitting.VerificaExistenciaCamposObrigatoriosOut(log, dtSpreadsheet);
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
        public static void SaveProjOutRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        {
            string strSQL = "DELETE FROM PROJ_OUT_RCPT WHERE file_name = '" + fileName + "'";
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction(strSQL);
            //Gravar tabela PROJ_OUT_RCPT
            for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
            {
                //Grava Recepcao no Banco de Dados referente a disciplina Outfitting
                DTO.ProjOutRcptDTO entity = new DTO.ProjOutRcptDTO();
                entity.Area = dtProjRcpt.Rows[i]["AREA"].ToString().Trim();
                entity.Desenho = dtProjRcpt.Rows[i]["DESENHO"].ToString().Trim();
                entity.Rev = dtProjRcpt.Rows[i]["REV"].ToString().Trim();
                entity.Tag = dtProjRcpt.Rows[i]["TAG"].ToString().Trim();
                entity.Codigo = dtProjRcpt.Rows[i]["CODIGO"].ToString().Trim();
                entity.Material = dtProjRcpt.Rows[i]["MATERIAL"].ToString().Trim();
                entity.Dim1 = dtProjRcpt.Rows[i]["DIM1"].ToString().Trim();
                entity.Dim2 = dtProjRcpt.Rows[i]["DIM2"].ToString().Trim();
                entity.Dim3 = dtProjRcpt.Rows[i]["DIM3"].ToString().Trim();
                entity.Qtd = dtProjRcpt.Rows[i]["QTD"].ToString().Trim();
                entity.Unid = dtProjRcpt.Rows[i]["UNID"].ToString().Trim();
                entity.Weight = dtProjRcpt.Rows[i]["WEIGHT"].ToString().Trim();
                entity.Tipo = dtProjRcpt.Rows[i]["TIPO"].ToString().Trim();
                entity.Treatment = dtProjRcpt.Rows[i]["TREATMENT"].ToString().Trim();
                entity.CreatedBy = userId;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = System.DateTime.Now;
                entity.FileName = fileName;
                entity.Mult = dtProjRcpt.Rows[i]["MULT"].ToString().Trim();
                try { BLL.ProjOutRcptBLL.Insert(entity, false); }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            H.ProcessHistory = "A planilha " + fileName + " foi incorporada ao banco de dados ";
            GenericClasses.Log.SaveLog(log, H);
        }
        //====================================================================
        public static DataTable CreateOutHeaderFOSE()
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
            dt.Columns.Add(new DataColumn("Coluna 17", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 18", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 19", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 20", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 21", typeof(string)));
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Número"; row["Coluna 2"] = "Revisão"; row["Coluna 3"] = "Situação"; row["Coluna 4"] = "Critério Medição"; row["Coluna 5"] = "Descrição";
            row["Coluna 6"] = "Sub Contrato"; row["Coluna 7"] = "Unidade Processo"; row["Coluna 8"] = "Área Aplicação"; row["Coluna 9"] = "Produto Fabricado"; row["Coluna 10"] = "Observação";
            row["Coluna 11"] = "Qtd. Prev."; row["Coluna 12"] = "Qtd. Real"; row["Coluna 13"] = "Unid. Medida"; row["Coluna 14"] = "UA"; row["Coluna 15"] = "Liberação Automática";
            row["Coluna 16"] = "Semana"; row["Coluna 17"] = "Desenho"; row["Coluna 18"] = "Área Pintura (m2)";
            row["Coluna 19"] = "Tratamento"; row["Coluna 20"] = "Classificado"; row["Coluna 21"] = "Região";

            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Texto"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Número"; row["Coluna 12"] = "Número"; row["Coluna 13"] = "Texto"; row["Coluna 14"] = "Texto"; row["Coluna 15"] = "Lógico";
            row["Coluna 16"] = "Número";
            row["Coluna 17"] = "Texto"; row["Coluna 18"] = "Número"; row["Coluna 19"] = "Texto"; row["Coluna 20"] = "Texto"; row["Coluna 21"] = "Texto";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'10"; row["Coluna 3"] = "'30"; row["Coluna 4"] = "'50"; row["Coluna 5"] = "'2000";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'50"; row["Coluna 9"] = "'400"; row["Coluna 10"] = "'4000";
            row["Coluna 11"] = "'22"; row["Coluna 12"] = "'22"; row["Coluna 13"] = "'10"; row["Coluna 14"] = "'100"; row["Coluna 15"] = "COD_S, COD_N";
            row["Coluna 16"] = "'22";
            row["Coluna 17"] = "'4000"; row["Coluna 18"] = "'22"; row["Coluna 19"] = "'200"; row["Coluna 20"] = "'200"; row["Coluna 21"] = "'4000";
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Obrigatório"; row["Coluna 8"] = "Opcional"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional"; row["Coluna 12"] = "Opcional"; row["Coluna 13"] = "Opcional"; row["Coluna 14"] = "Opcional"; row["Coluna 15"] = "Opcional";
            row["Coluna 16"] = "Opcional";
            row["Coluna 17"] = "Opcional"; row["Coluna 18"] = "Opcional"; row["Coluna 19"] = "Opcional"; row["Coluna 20"] = "Opcional"; row["Coluna 21"] = "Opcional";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único"; row["Coluna 12"] = "Não Único"; row["Coluna 13"] = "Não Único"; row["Coluna 14"] = "Não Único"; row["Coluna 15"] = "Não Único";
            row["Coluna 16"] = "Não Único";
            row["Coluna 17"] = "Não Único"; row["Coluna 18"] = "Não Único"; row["Coluna 19"] = "Não Único"; row["Coluna 20"] = "Não Único"; row["Coluna 21"] = "Não Único";
            dt.Rows.Add(row);

            return dt;
        }
        //====================================================================
        public static void FillDataTableFOSE(ref DataTable dtProjFOSE, string fileName, string plataforma)
        {
            string tipo = "";
            string strSQL = @"SELECT X.ID, X.AREA, X.DESENHO, X.REV, X.TAG, X.CODIGO, X.MATERIAL, X.DIM1, X.DIM2, X.DIM3, X.QTD, X.UNID, X.WEIGHT, X.TIPO, X.CREATED_BY, CREATED_DATE, X.MODIFIED_BY, MODIFIED_DATE, X.FILE_NAME, X.TREATMENT, X.MULT FROM PROJ_OUT_RCPT X WHERE file_name = '" + fileName + "'";

            //"' ORDER BY TO_NUMBER(PKG_TOOLS.FUN_PIECE(X.PECA,1, '-'))";


            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE
            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PROTUGUÊS DO BRASIL
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");
            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjOutRcptBLL.Select(strSQL);
            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;
            //Insere o DataTable na Tabela PROJ_OUT_FOSE excluindo o cabeçalho(6 linhas)
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                tipo = dtAUX.Rows[r]["TIPO"].ToString();
                //if (tipo.ToUpper() == "EEP-SUPORTE")
                //{
                    row = dtProjFOSE.NewRow();
                    row["Coluna 1"] = dtAUX.Rows[r]["TAG"].ToString();
                    row["Coluna 2"] = dtAUX.Rows[r]["REV"].ToString();
                    row["Coluna 3"] = "Liberada";
                    row["Coluna 4"] = "";
                    row["Coluna 5"] = "";
                    row["Coluna 6"] = plataforma;
                    row["Coluna 7"] = "";
                    row["Coluna 8"] = ""; 
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    row["Coluna 11"] = "";  //"'" + (Convert.ToDecimal(dtAUX.Rows[r]["WEIGHT"]) * Convert.ToDecimal(dtAUX.Rows[r]["MULT"])).ToString();
                    row["Coluna 12"] = "";
                    row["Coluna 13"] = "ton"; // dtAUX.Rows[r]["UNID"].ToString();
                    row["Coluna 14"] = "";
                    row["Coluna 15"] = "";
                    row["Coluna 16"] = "";
                    row["Coluna 17"] = dtAUX.Rows[r]["DESENHO"].ToString();
                    row["Coluna 18"] = "";
                    row["Coluna 19"] = "Sem Tratamento";
                    row["Coluna 20"] = "";
                    row["Coluna 21"] = dtAUX.Rows[r]["AREA"].ToString();

                    dtProjFOSE.Rows.Add(row);
                //}
            }
        }
        //====================================================================
        public static DataTable CreateOutHeaderPROD()
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
        //====================================================================
        public static void FillDataTablePROD(ref DataTable dtProjPROD, string fileName)
        {
            string strSQL = @"SELECT X.ID, X.AREA, X.DESENHO, X.REV, X.TAG, X.CODIGO, X.MATERIAL, X.DIM1, X.DIM2, X.DIM3, X.QTD, X.UNID, X.WEIGHT, X.TIPO, X.CREATED_BY, CREATED_DATE, X.MODIFIED_BY, MODIFIED_DATE, X.FILE_NAME, X.TREATMENT, X.MULT FROM PROJ_OUT_RCPT X WHERE file_name = '" + fileName + "'";

            //"' ORDER BY TO_NUMBER(PKG_TOOLS.FUN_PIECE(X.PECA,1, '-'))";


            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE
            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjOutRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;
            //Insere o DataTable na Tabela PROJ_TUB_FOSE excluindo o cabeçalho(6 linhas)
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                row = dtProjPROD.NewRow();
                row["Coluna 1"] = dtAUX.Rows[r]["TAG"].ToString();
                row["Coluna 2"] = "Produto Consumido";
                row["Coluna 3"] = "Material";
                row["Coluna 4"] = dtAUX.Rows[r]["CODIGO"].ToString();
                row["Coluna 5"] = dtAUX.Rows[r]["DIM1"].ToString();
                row["Coluna 6"] = dtAUX.Rows[r]["DIM2"].ToString();
                row["Coluna 7"] = dtAUX.Rows[r]["DIM3"].ToString();
                if(dtAUX.Rows[r]["MATERIAL"].ToString().Trim().ToUpper().Substring(0,5) == "CHAPA")
                {
                    row["Coluna 8"] = "'" + (Convert.ToDecimal(Convert.ToDecimal(dtAUX.Rows[r]["WEIGHT"]) * Convert.ToDecimal(dtAUX.Rows[r]["MULT"])).ToString());
                }
                else
                {
                    row["Coluna 8"] = "'" + (Convert.ToDecimal(Convert.ToDecimal(dtAUX.Rows[r]["QTD"]) * Convert.ToDecimal(dtAUX.Rows[r]["MULT"])).ToString());
                }
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "";
                dtProjPROD.Rows.Add(row);
            }

            /*
                         for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                row = dtProjPROD.NewRow();
                row["Coluna 1"] = dtAUX.Rows[r]["SPOOL"].ToString() + ".F" + dtAUX.Rows[r]["ISOM"].ToString().Split('-')[6];
                row["Coluna 2"] = "Produto Consumido";
                row["Coluna 3"] = "Material";
                row["Coluna 4"] = "'" + dtAUX.Rows[r]["CLIENT_CC"].ToString();
                row["Coluna 5"] = dtAUX.Rows[r]["PART_DIAM1"].ToString();
                row["Coluna 6"] = GenericClasses.FPSO.GetTubDim2(dtAUX.Rows[r]["SHORT_DESC"].ToString(), dtAUX.Rows[r]["PART_DIAM2"].ToString());  //PartDiam2
                row["Coluna 7"] = "";
                row["Coluna 8"] = dtAUX.Rows[r]["QUANTITY"].ToString();
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "";
                dtProjPROD.Rows.Add(row);
            }
             */
        }
        //============================================
        //public static void SaveProjEstRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        //{
        //    //Gravar tabela PROJ_EST_RCPT
        //    for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
        //    {
        //        //int c = 0;
        //        //Grava Recepcao no Banco de Dados referente a disciplina Tubulacao
        //        DTO.ProjEstRcptDTO entity = new DTO.ProjEstRcptDTO();
        //        entity.Peca = dtProjRcpt.Rows[i]["PECA"].ToString().Trim();
        //        entity.Peso = dtProjRcpt.Rows[i]["PESO"].ToString().Trim();
        //        entity.Criterio = dtProjRcpt.Rows[i]["CRITERIO"].ToString().Trim();
        //        entity.Descricao = dtProjRcpt.Rows[i]["DESCRICAO"].ToString().Trim();
        //        entity.CreatedBy = userId;
        //        entity.CreatedDate = System.DateTime.Now;
        //        entity.ModifiedBy = userId;
        //        entity.ModifiedDate = System.DateTime.Now;
        //        entity.FileName = fileName;
        //        try
        //        {
        //            BLL.ProjEstRcptBLL.Insert(entity, false);
        //        }
        //        catch (Exception ex)
        //        {

        //            throw new Exception(ex.Message);
        //        }
        //    }
        //    GenericClasses.Log.SaveLog(log, "A planilha " + fileName + " foi incorporada ao banco de dados ");
        //}
        //============================================
        public static bool VerificaExistenciaCamposObrigatoriosOut(StreamWriter log, DataTable dtSpreadsheet)
        {
            bool bRet = true;
            try
            {
                for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
                {
                    if (dtSpreadsheet.Rows[i]["AREA"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna AREA - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DESENHO"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna DESENHO - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["REV"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna REV - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["TAG"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna TAG - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["CODIGO"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  ColunaCODIGO - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["MATERIAL"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna MATERIAL - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DIM1"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna DIM1 - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DIM2"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna DIM2 - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DIM3"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna DIM3 - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["QTD"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna QTD - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["UNID"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna UNID - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["WEIGHT"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna WEIGHT - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["TIPO"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna TIPO - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["TREATMENT"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna TREATMENT - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bRet;
        }
    }
}
