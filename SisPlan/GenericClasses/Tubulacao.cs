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
    public class Tubulacao
    {
        static string categoria = "";
        static string pipeline = "";
        static string area = "";
        static string origem = "";
        static string asp = Convert.ToChar(34).ToString();
        static DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();
        
        public static bool IsValidTubSpreadsheetPROD(DataTable dtProjRcpt, string fileName, string logFolder, StreamWriter log, string disciplina, string handledFolder, ref bool restricaoMaterial)
        {
            H.ProcessHistory = "A Planilha atendeu aos requisitos básicos para o template PROD ser processado no SISEPC.";
            bool bRet = true;
            bRet = GenericClasses.SpreadSheets.ValidaCodigoProduto(log, dtProjRcpt, "CLIENT_CC", disciplina, fileName, ref restricaoMaterial);
            if (bRet) GenericClasses.Log.SaveLog(log,H);
            else
            {
                if (restricaoMaterial)
                {
                    //<font color="#FFFF66" face="verdana" size="3">
                    H.ProcessHistory = "<br/><br/><b><font color=" + asp + "#FF0000" + asp + " face=" + asp + "verdana" + asp + " size=" + asp + "3" + asp + ">ATENÇÃO: A CORRIDA DE MATERIAIS NÃO SERÁ REALIZADA.</font></b> Elimine as restrições de materiais inválidos descritas acima e reprocesse a planilha.<br/>";
                    GenericClasses.Log.SaveLog(log, H);
                }
                else
                {
                    H.ProcessHistory ="<br/><br/>Não há restrições para criação do template PROD devido a validações de Código de Produto.<br/>A corrida de materiais poderá ser realizada.";
                    GenericClasses.Log.SaveLog(log, H);
                }
            }
            return true;
        }
        //============================================
        public static bool IsValidTubSpreadsheet(DataTable dtSpreadsheet, string fileName, string logFolder, StreamWriter log, string disciplina, string handledFolder)
        {
            H.FileName = fileName;
            bool bRet = true;
            string header = "";
            int numCol;
            string[] columns = new string[22];
            origem = fileName.Substring(0, 4);   //Origem da planilha
            columns[0] = "Area";
            columns[1] = "Isom";
            columns[2] = "Pipeline";
            columns[3] = "Rev";
            columns[4] = "Spool";
            columns[5] = "Contractor_CC";
            columns[6] = "Client_CC";
            columns[7] = "Short_Desc";
            columns[8] = "Categoria";
            columns[9] = "PartDiam1";
            columns[10] = "PartDiam2";
            columns[11] = "PartSched1";
            columns[12] = "PartSched2";
            columns[13] = "Area_Painting";
            columns[14] = "Quantity";
            columns[15] = "Weight";
            columns[16] = "Treatment";
            numCol = 17;
            //Valida estrutura da planilha
            if (origem == "EMM_" || origem == "EEP_")
            {
                columns[0] = "FPSO";
                columns[1] = "Area";
                columns[2] = "SubArea";
                columns[3] = "Isom";
                columns[4] = "Rev";
                columns[5] = "Pipeline";
                columns[6] = "Isolinha";
                columns[7] = "RevLinha";
                columns[8] = "Spool";
                columns[9] = "Client_CC";
                columns[10] = "Contractor_CC";
                columns[11] = "Short_Desc";
                columns[12] = "PartDiam1";
                columns[13] = "PartDiam2";
                columns[14] = "PartSched1";
                columns[15] = "PartSched2";
                columns[16] = "Category";
                columns[17] = "Area_Painting";
                columns[18] = "Quantity";
                columns[19] = "Weight";
                columns[20] = "Painting";
                columns[21] = "Treatment";
                //if (origem == "EMM_") { columns[22] = "DateLastModified"; numCol = 23; }
                //else { numCol = 22; }
                numCol = 22;
                
            }
            for (int c = 0; c < numCol; c++)
            {
                header += "|" + columns[c];
            }
            header = header.Substring(1);
            //for (int i = 0; i < numCol - 1; i++)
            for (int i = 0; i < numCol; i++)
            {
                if (dtSpreadsheet.Columns[i].ColumnName.ToUpper() != columns[i].ToUpper())
                {
                    H.ProcessHistory = "A estrutura da planilha deve obedecer a estrutura abaixo: " + Convert.ToChar(13) + Convert.ToChar(10);
                    GenericClasses.Log.SaveLog(log, H);
                    H.ProcessHistory = "Conferir coluna: " + dtSpreadsheet.Columns[i].ColumnName.ToUpper() + Convert.ToChar(13) + Convert.ToChar(10);
                    GenericClasses.Log.SaveLog(log,H);
                    H.ProcessHistory = header;
                    GenericClasses.Log.SaveLog(log, H);
                    bRet = false;
                    break;
                }

            }
            //Verifica existência de Planilha já processada
            if (bRet) bRet = GenericClasses.Tubulacao.VerificaExistenciaPlanilhaTub(log, fileName, handledFolder);
            if (bRet) bRet = GenericClasses.Tubulacao.VerificaExistenciaCamposObrigatoriosTub(log, dtSpreadsheet);
            if (bRet)
            {
                //Na planilha TEEWEE e na planilha EEP_ essa regra não é aplicada na coluna Spool
                if (origem != "EMM_" && origem != "EEP_") bRet = GenericClasses.Tubulacao.ValidaDiametro(log, dtSpreadsheet, "SPOOL");
            }
            return bRet;
        }
        //============================================
        public static bool ValidaDiametro(StreamWriter log, DataTable dtSpreadsheet, string colunaProduto)
        {
            bool bRet = true;
            string spool = "";
            DataTable dt = null;
            for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
            {
                spool = dtSpreadsheet.Rows[i][colunaProduto].ToString().Trim();
                if (spool.IndexOf('"') < 0 && spool.IndexOf("mm") < 0 )
                {
                    H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==>  Coluna " + colunaProduto + " - formato não possui aspas nem 'mm'. Planilha FOSE/PROD não será gerada";
                    GenericClasses.Log.SaveLog(log, H);
                    bRet = false;
                }
            }
            return bRet;
        }
        //============================================
        public static void SaveProjTubRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        {
            origem = fileName.Substring(0, 4);
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_TUB_RCPT WHERE file_name = '" + fileName + "'";
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction(strSQL);

            //Gravar tabela PROJ_TUB_RCPT
            for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
            {
                //Grava Recepcao no Banco de Dados referente a disciplina Tubulacao
                DTO.ProjTubRcptDTO entity = new DTO.ProjTubRcptDTO();
                entity.Area = dtProjRcpt.Rows[i]["AREA"].ToString().Trim();
                entity.Isom = dtProjRcpt.Rows[i]["ISOM"].ToString().Trim();
                entity.Pipeline = dtProjRcpt.Rows[i]["PIPELINE"].ToString().Trim();
                entity.Revisao = dtProjRcpt.Rows[i]["REV"].ToString().Trim();
                entity.Spool = dtProjRcpt.Rows[i]["SPOOL"].ToString().Trim();
                entity.ContractorCC = dtProjRcpt.Rows[i]["CONTRACTOR_CC"].ToString().Trim();
                entity.ClientCC = dtProjRcpt.Rows[i]["CLIENT_CC"].ToString().Trim();
                entity.ShortDesc = dtProjRcpt.Rows[i]["SHORT_DESC"].ToString().Trim();
                entity.Categoria = dtProjRcpt.Rows[i]["CATEGORIA"].ToString().Trim();
                entity.PartDiam1 = dtProjRcpt.Rows[i]["PartDiam1"].ToString().Trim();
                entity.PartDiam2 = dtProjRcpt.Rows[i]["PartDiam2"].ToString().Trim();
                entity.PartSched1 = dtProjRcpt.Rows[i]["PartSched1"].ToString().Trim();
                entity.PartSched2 = dtProjRcpt.Rows[i]["PartSched2"].ToString().Trim();
                entity.AreaPainting = dtProjRcpt.Rows[i]["Area_Painting"].ToString().Trim();
                entity.Quantity = dtProjRcpt.Rows[i]["Quantity"].ToString().Trim();
                entity.Weight = dtProjRcpt.Rows[i]["Weight"].ToString().Trim();
                entity.Treatment = dtProjRcpt.Rows[i]["Treatment"].ToString().Trim();
                entity.CreatedBy = userId;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = System.DateTime.Now;
                entity.FileName = fileName;
                try { BLL.ProjTubRcptBLL.Insert(entity, false); }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            H.ProcessHistory = "A planilha " + fileName + " foi incorporada ao banco de dados ";
            GenericClasses.Log.SaveLog(log, H);
        }
        //============================================
        public static void SaveProjTubTeeWeeRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        {
            origem = fileName.Substring(0, 4);
            string strSQL = "DELETE FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE WHERE file_name = '" + fileName + "'";
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction(strSQL);
            string spool = "";
            //Gravar tabela PROJ_TUB_RCPT
            for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
            {
                //Grava Recepcao no Banco de Dados referente a disciplina Tubulacao
                DTO.ProjTubRcptTeeweeDTO entity = new DTO.ProjTubRcptTeeweeDTO();
                entity.Fpso = dtProjRcpt.Rows[i]["FPSO"].ToString().Trim();
                entity.Area = dtProjRcpt.Rows[i]["AREA"].ToString().Trim();
                entity.Isom = dtProjRcpt.Rows[i]["ISOM"].ToString().Trim();
                entity.Rev = dtProjRcpt.Rows[i]["REV"].ToString().Trim();
                entity.Pipeline = dtProjRcpt.Rows[i]["PIPELINE"].ToString().Trim();
                entity.Isolinha = dtProjRcpt.Rows[i]["ISOLINHA"].ToString().Trim();
                entity.Revlinha = dtProjRcpt.Rows[i]["REVLINHA"].ToString().Trim();

                entity.Spool = "Spool Mont";
                spool = dtProjRcpt.Rows[i]["SPOOL"].ToString().Trim();
                if (spool != "") entity.Spool = spool;

                entity.ClientCc = dtProjRcpt.Rows[i]["CLIENT_CC"].ToString().Trim();

                //if (entity.ClientCc == "6.91.91.091.05.07.28")
                //{
                //    string X = "";
                //}
                entity.ContractorCc = dtProjRcpt.Rows[i]["CONTRACTOR_CC"].ToString().Trim();
                entity.ShortDesc = dtProjRcpt.Rows[i]["SHORT_DESC"].ToString().Trim();
                entity.PartDiam1 = dtProjRcpt.Rows[i]["PartDiam1"].ToString().Trim();
                entity.PartDiam2 = dtProjRcpt.Rows[i]["PartDiam2"].ToString().Trim();
                entity.PartSched1 = dtProjRcpt.Rows[i]["PartSched1"].ToString().Trim();
                entity.PartSched2 = dtProjRcpt.Rows[i]["PartSched2"].ToString().Trim();
                entity.Category = dtProjRcpt.Rows[i]["CATEGORY"].ToString().Trim();

                entity.AreaPainting = dtProjRcpt.Rows[i]["Area_Painting"].ToString().Trim();
                if ((entity.AreaPainting).ToUpper() == "NULL") entity.AreaPainting = "0";
                
                entity.Quantity = dtProjRcpt.Rows[i]["Quantity"].ToString().Trim();
                entity.Weight = dtProjRcpt.Rows[i]["Weight"].ToString().Trim();
                entity.Painting = dtProjRcpt.Rows[i]["Painting"].ToString().Trim();
                entity.Treatment = dtProjRcpt.Rows[i]["Treatment"].ToString().Trim();
                entity.CreatedBy = userId;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = System.DateTime.Now;
                entity.FileName = fileName;
                try { BLL.ProjTubRcptTeeweeBLL.Insert(entity, false); }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
            H.ProcessHistory = "A planilha " + fileName + " foi incorporada ao banco de dados ";
            GenericClasses.Log.SaveLog(log, H);
        }




        //====================================================================================================================================
        //====================================================================================================================================
        //====================================================================================================================================
        #region CRIA HEADER e DataTables
        //====================================================================
        public static DataTable CreateTubHeaderFOSE()
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
            dt.Columns.Add(new DataColumn("Coluna 21", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 22", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 23", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 24", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 25", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 26", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 27", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 28", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 29", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 30", typeof(string)));
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Número"; row["Coluna 2"] = "Revisão"; row["Coluna 3"] = "Situação"; row["Coluna 4"] = "Critério Medição"; row["Coluna 5"] = "Descrição";
            row["Coluna 6"] = "Sub Contrato"; row["Coluna 7"] = "Unidade Processo"; row["Coluna 8"] = "Área Aplicação"; row["Coluna 9"] = "Produto Fabricado"; row["Coluna 10"] = "Observação";
            row["Coluna 11"] = "Qtd. Prev."; row["Coluna 12"] = "Qtd. Real"; row["Coluna 13"] = "Unid. Medida"; row["Coluna 14"] = "UA";
            row["Coluna 15"] = "Grupo"; row["Coluna 16"] = "Incluso no Grupo";
            row["Coluna 17"] = "Liberação Automática";
            row["Coluna 18"] = "Semana"; row["Coluna 19"] = "Desenho"; row["Coluna 20"] = "Área Pintura (m2)";
            row["Coluna 21"] = "Tratamento"; row["Coluna 22"] = "Classificado"; row["Coluna 23"] = "Regiao"; row["Coluna 24"] = "Diam"; row["Coluna 25"] = "Siatema"; row["Coluna 26"] = "Spec";
            row["Coluna 27"] = "Nota"; row["Coluna 28"] = "Localização"; row["Coluna 29"] = "Equipe"; row["Coluna 30"] = "Setor";

            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Texto"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Número"; row["Coluna 12"] = "Número"; row["Coluna 13"] = "Texto"; row["Coluna 14"] = "Texto";
            row["Coluna 15"] = "Lógico"; row["Coluna 16"] = "Texto"; row["Coluna 17"] = "Lógico"; row["Coluna 18"] = "Número";
            row["Coluna 19"] = "Texto"; row["Coluna 20"] = "Número"; row["Coluna 21"] = "Texto"; row["Coluna 22"] = "Texto";
            row["Coluna 23"] = "Texto"; row["Coluna 24"] = "Texto"; row["Coluna 25"] = "Texto"; row["Coluna 26"] = "Texto";
            row["Coluna 27"] = "Texto"; row["Coluna 28"] = "Texto"; row["Coluna 29"] = "Texto"; row["Coluna 30"] = "Texto";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'10"; row["Coluna 3"] = "'30"; row["Coluna 4"] = "'50"; row["Coluna 5"] = "'2000";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'50"; row["Coluna 9"] = "'400"; row["Coluna 10"] = "'4000";
            row["Coluna 11"] = "'22"; row["Coluna 12"] = "'22"; row["Coluna 13"] = "'10"; row["Coluna 14"] = "'100";
            row["Coluna 15"] = "COD_S, COD_N"; row["Coluna 16"] = "'200"; row["Coluna 17"] = "COD_S, COD_N"; row["Coluna 18"] = "'22";
            row["Coluna 19"] = "'4000"; row["Coluna 20"] = "'22"; row["Coluna 21"] = "'200"; row["Coluna 22"] = "'200";
            row["Coluna 23"] = "'23"; row["Coluna 24"] = "'4000"; row["Coluna 25"] = "'4000"; row["Coluna 26"] = "'4000";
            row["Coluna 27"] = "'4000"; row["Coluna 28"] = "'200"; row["Coluna 29"] = "'200"; row["Coluna 30"] = "'200";

            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Obrigatório"; row["Coluna 8"] = "Opcional"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional"; row["Coluna 12"] = "Opcional"; row["Coluna 13"] = "Opcional"; row["Coluna 14"] = "Opcional";
            row["Coluna 15"] = "Opcional"; row["Coluna 16"] = "Opcional"; row["Coluna 17"] = "Opcional"; row["Coluna 18"] = "Opcional";
            row["Coluna 19"] = "Opcional"; row["Coluna 20"] = "Opcional"; row["Coluna 21"] = "Opcional"; row["Coluna 22"] = "Opcional";
            row["Coluna 23"] = "Opcional"; row["Coluna 24"] = "Opcional"; row["Coluna 25"] = "Opcional"; row["Coluna 26"] = "Opcional";
            row["Coluna 27"] = "Opcional"; row["Coluna 28"] = "Opcional"; row["Coluna 29"] = "Opcional"; row["Coluna 30"] = "Opcional";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único"; row["Coluna 12"] = "Não Único"; row["Coluna 13"] = "Não Único"; row["Coluna 14"] = "Não Único";
            row["Coluna 15"] = "Opcional"; row["Coluna 16"] = "Opcional"; row["Coluna 17"] = "Não Único"; row["Coluna 18"] = "Não Único";
            row["Coluna 19"] = "Não Único"; row["Coluna 20"] = "Não Único"; row["Coluna 21"] = "Não Único"; row["Coluna 22"] = "Não Único";
            row["Coluna 23"] = "Não Único"; row["Coluna 24"] = "Não Único"; row["Coluna 25"] = "Não Único"; row["Coluna 26"] = "Não Único";
            row["Coluna 27"] = "Não Único"; row["Coluna 28"] = "Não Único"; row["Coluna 29"] = "Não Único"; row["Coluna 30"] = "Não Único";
            dt.Rows.Add(row);

            return dt;
        }
        //====================================================================
        public static DataTable CreateTubHeaderPROD()
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
        public static DataTable CreateTubHeaderSERV()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Coluna 1", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 3", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 5", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 6", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 7", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 8", typeof(string)));

            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Número"; row["Coluna 2"] = "Sigla"; row["Coluna 3"] = "UA"; row["Coluna 4"] = "Responsavel"; row["Coluna 5"] = "Qtd. Prev.";
            row["Coluna 6"] = "Unidade Medida"; row["Coluna 7"] = "HH Previsto"; row["Coluna 8"] = "HH Real";
            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Número";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Número"; row["Coluna 8"] = "Número";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'50"; row["Coluna 3"] = "'100"; row["Coluna 4"] = "'200"; row["Coluna 5"] = "'22";
            row["Coluna 6"] = "'10"; row["Coluna 7"] = "'22"; row["Coluna 8"] = "'22";
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Opcional"; row["Coluna 4"] = "Opcional"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Obrigatório"; row["Coluna 8"] = "Obrigatório";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Não Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único";
            dt.Rows.Add(row);
            return dt;
        }
        

        //====================================================================
        public static void FillDataTableFOSE(ref DataTable dtProjFOSE, string isom, string fileName)
        {
            string strSQL = "";
            if (origem == "EMM_" || origem == "EEP_")
            {
                strSQL = @"SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, CASE WHEN X.CATEGORY = 'SHOP' THEN 'SHOP' WHEN X.CATEGORY = 'FIELD' THEN 'FIELD' END AS CATEGORY, ROUND(SUM(TO_NUMBER(X.WEIGHT)) / 1000,2) AS WEIGHT, SUM(TO_NUMBER(AREA_PAINTING)) AS AREA_PAINTING 
                             FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                            WHERE SPOOL IS NOT NULL AND X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' 
                            GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, X.CATEGORY 

                        UNION ALL

                           SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, CASE WHEN X.CATEGORY = 'SHOP' THEN 'FIELD' END AS CATEGORY, ROUND(SUM(TO_NUMBER(X.WEIGHT)) / 1000,2) AS WEIGHT, SUM(TO_NUMBER(AREA_PAINTING)) AS AREA_PAINTING 
                             FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                            WHERE SPOOL IS NOT NULL AND X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' AND SPOOL != 'Spool Mont' 
                            GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, X.CATEGORY 
                         ORDER BY ISOM, PIPELINE, SPOOL, CATEGORY DESC";
            }
            else
            {
                strSQL = @"SELECT X.ISOM, X.SPOOL, X.REVISAO, X.TREATMENT,X.AREA, X.CATEGORIA, ROUND(SUM(TO_NUMBER(X.WEIGHT)) / 1000,2) AS WEIGHT, SUM(TO_NUMBER(AREA_PAINTING)) AS AREA_PAINTING 
                                FROM EEP_CONVERSION.PROJ_TUB_RCPT X 
                               WHERE X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' 
                               GROUP BY X.ISOM, X.SPOOL, X.REVISAO, X.TREATMENT, X.AREA, X.CATEGORIA 
                               ORDER BY X.ISOM, X.SPOOL";
            }


            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = null;
            if (origem == "EMM_" || origem == "EEP_") dtAUX = BLL.ProjTubRcptTeeweeBLL.Select(strSQL);
            else dtAUX = BLL.ProjTubRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            //Prepara o DataTable para FOSE
            if (origem == "EMM_" || origem == "EEP_")
            {
                //TEEWEE
                DataRow row;
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    DTO.AcRegiaoDTO regiao = new DTO.AcRegiaoDTO();
                    string spool = dtAUX.Rows[r]["SPOOL"].ToString().Replace("NULL","");
                    string fpso = dtAUX.Rows[r]["FPSO"].ToString().Trim();
                    string[] auxArray = spool.Split('-');
                    string unidadeProcesso = "";
                    
                    categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim().ToUpper().Replace("Contractor fabricated", "FIELD");
                    pipeline = dtAUX.Rows[r]["PIPELINE"].ToString().Trim();

                    //Area
                    area = dtAUX.Rows[r]["AREA"].ToString().Trim();
                    regiao = BLL.AcRegiaoBLL.GetObject("REGI_DESCRICAO = '" + area + "'");

                    //Localizacao
                    DTO.AcLocalizacaoDTO localizacao = new DTO.AcLocalizacaoDTO();
                    localizacao = BLL.AcLocalizacaoBLL.GetObject("LOCALIZACAO_ID = " + regiao.RegiLocalizacaoId.ToString());

                    //Setor
                    DTO.AcSetorDTO setor = new DTO.AcSetorDTO();
                    setor = BLL.AcSetorBLL.GetObject("SETOR_ID = " + regiao.RegiSetorId.ToString());
                    
                    //Unidade Processo
                    

                    string[] elementos = pipeline.Split('-');
                    string diam = elementos[0];
                    string sistema = elementos[1];
                    string spec = elementos[2];
                    //string piece4 = elementos[3];

                    row = dtProjFOSE.NewRow();
                    row["Coluna 1"] = GetTagFOSETeeWee(area, categoria, isom, pipeline, spool, fpso);
                    row["Coluna 2"] = dtAUX.Rows[r]["REV"].ToString();
                    row["Coluna 3"] = "Liberada";
                    row["Coluna 4"] = GetCriterioMedicao(categoria, fpso);  // "TUB_FAB ou TUB_MONT ou TUB_FAB_INT_MONT_TH";
                    row["Coluna 5"] = "Spool";
                    row["Coluna 6"] = GenericClasses.FPSO.GetFPSO(dtAUX.Rows[r]["ISOM"].ToString().Split('-')[2].Split('.')[1]);
                    row["Coluna 7"] = unidadeProcesso;
                    row["Coluna 8"] = area;
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    if (row["Coluna 1"].ToString().IndexOf("Spool Mont") >= 0) row["Coluna 11"] = "'0";
                    else row["Coluna 11"] = "'" + dtAUX.Rows[r]["WEIGHT"].ToString();
                    row["Coluna 12"] = "";
                    row["Coluna 13"] = "ton";
                    row["Coluna 14"] = "";
                    row["Coluna 15"] = "";
                    row["Coluna 16"] = "";
                    row["Coluna 17"] = "";
                    row["Coluna 18"] = "";
                    row["Coluna 19"] = dtAUX.Rows[r]["ISOM"].ToString();
                    if (categoria.ToUpper() == "FIELD") row["Coluna 20"] = "";
                    else row["Coluna 20"] = "'" + dtAUX.Rows[r]["Area_Painting"].ToString();
                    if (categoria.ToUpper() == "FIELD") row["Coluna 21"] = "";
                    else row["Coluna 21"] = GenericClasses.FPSO.GetTubTreatment(dtAUX.Rows[r]["TREATMENT"].ToString());
                    row["Coluna 22"] = "Não";
                    row["Coluna 23"] = area;
                    row["Coluna 24"] = diam;
                    row["Coluna 25"] = sistema;
                    row["Coluna 26"] = spec;
                    row["Coluna 27"] = "";
                    row["Coluna 28"] = localizacao.LocalizacaoNome;
                    row["Coluna 29"] = "";
                    row["Coluna 30"] = setor.SetorNome;
                    dtProjFOSE.Rows.Add(row);
                }
            }
            else
            {
                //I-IS
                DataRow row;
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    string spool = dtAUX.Rows[r]["SPOOL"].ToString();
                    string[] auxArray = spool.Split('-');
                    categoria = dtAUX.Rows[r]["CATEGORIA"].ToString().Trim();
                    row = dtProjFOSE.NewRow();
                    row["Coluna 1"] = GetTagFOSE(spool, categoria, isom);
                    row["Coluna 2"] = dtAUX.Rows[r]["REVISAO"].ToString();
                    row["Coluna 3"] = "Liberada";
                    row["Coluna 4"] = GetCriterioMedicao(categoria, null);  // "TUB_FAB ou TUB_MONT";
                    row["Coluna 5"] = "Spool";
                    row["Coluna 6"] = GenericClasses.FPSO.GetFPSO(dtAUX.Rows[r]["ISOM"].ToString().Split('-')[2].Split('.')[1]);
                    row["Coluna 7"] = "";
                    row["Coluna 8"] = "";
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    row["Coluna 11"] = "'" + dtAUX.Rows[r]["WEIGHT"].ToString();
                    row["Coluna 12"] = "";
                    row["Coluna 13"] = "ton";
                    row["Coluna 14"] = "";
                    row["Coluna 15"] = "";
                    row["Coluna 16"] = "";

                    row["Coluna 17"] = "";
                    row["Coluna 18"] = "";
                    row["Coluna 19"] = dtAUX.Rows[r]["ISOM"].ToString();
                    row["Coluna 20"] = "'" + dtAUX.Rows[r]["Area_Painting"].ToString();
                    row["Coluna 21"] = GenericClasses.FPSO.GetTubTreatment(dtAUX.Rows[r]["TREATMENT"].ToString());
                    row["Coluna 22"] = "Não";
                    row["Coluna 23"] = dtAUX.Rows[r]["AREA"].ToString();
                    row["Coluna 24"] = auxArray[0];
                    row["Coluna 25"] = auxArray[1];
                    row["Coluna 26"] = auxArray[2];

                    row["Coluna 27"] = "";
                    row["Coluna 28"] = "";
                    row["Coluna 29"] = "";
                    row["Coluna 30"] = "";
                    dtProjFOSE.Rows.Add(row);
                }
            }
        }
        //====================================================================
        public static void FillDataTablePROD(ref DataTable dtProjPROD, string isom, string fileName)
        {
            string strSQL = "";
            if (origem == "EMM_" || origem == "EEP_")
            {
                strSQL = @"SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY, TO_CHAR(SUM(TO_NUMBER(QUANTITY))) AS QUANTITY FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                               WHERE X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"'   --AND SPOOL like '%-BG-B10H-6042'
                               GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY 
                               ORDER BY X.ISOM, X.PIPELINE, X.SPOOL, CLIENT_CC";
            }
            else
            {
                strSQL = @"SELECT X.ISOM, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.CATEGORIA, TO_CHAR(SUM(TO_NUMBER(QUANTITY))) AS QUANTITY FROM EEP_CONVERSION.PROJ_TUB_RCPT X 
                               WHERE X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"'   --AND SPOOL like '%-BG-B10H-6042'
                               GROUP BY X.ISOM, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.CATEGORIA 
                               ORDER BY X.ISOM, X.SPOOL, CLIENT_CC";
            }
            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjTubRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");


            //Prepara o DataTable para PROD
            if (origem == "EMM_" || origem == "EEP_")
            {
                //TEEWEE
                DataRow row;
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    string spool = dtAUX.Rows[r]["SPOOL"].ToString().Replace("NULL", "");
                    string fpso = dtAUX.Rows[r]["FPSO"].ToString().Trim();
                    string[] auxArray = spool.Split('-');
                    //categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim();
                    categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim().ToUpper().Replace("Contractor fabricated", "FIELD");
                    area = dtAUX.Rows[r]["AREA"].ToString().Trim();
                    pipeline = dtAUX.Rows[r]["PIPELINE"].ToString().Trim();
                    string[] elementos = pipeline.Split('-');
                    string diam = elementos[0];
                    string sistema = elementos[1];
                    string spec = elementos[2];
                    //string piece4 = elementos[3];
                    //strSQL = "SELECT DISTINCT SPOOL FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE WHERE SPOOL IS NOT NULL AND SPOOL LIKE '%" + piece4 + "%' AND ROWNUM = 1 ORDER BY 1";
                    //dtSpool = BLL.ProjTubRcptTeeweeBLL.Select(strSQL);
                    //string spool = dtSpool.Rows[0][0].ToString().Split('_')[1];
                    row = dtProjPROD.NewRow();
                    row["Coluna 1"] = GetTagFOSETeeWee(area, categoria, isom, pipeline, spool, fpso);
                    row["Coluna 2"] = "Produto Consumido";
                    row["Coluna 3"] = "Material";
                    row["Coluna 4"] = "'" + dtAUX.Rows[r]["CLIENT_CC"].ToString();
                    row["Coluna 5"] = "'" + dtAUX.Rows[r]["PART_DIAM1"].ToString();
                    row["Coluna 6"] = "'" + GenericClasses.FPSO.GetTubDim2(dtAUX.Rows[r]["SHORT_DESC"].ToString(), dtAUX.Rows[r]["PART_DIAM2"].ToString().Replace("NULL", ""));  //PartDiam2
                    row["Coluna 7"] = "";
                    row["Coluna 8"] = "'" + dtAUX.Rows[r]["QUANTITY"].ToString();
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    row["Coluna 11"] = "";
                    dtProjPROD.Rows.Add(row);
                }
            }
            else
            {
                //EEP
                DataRow row;
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    categoria = dtAUX.Rows[r]["CATEGORIA"].ToString().Trim();
                    row = dtProjPROD.NewRow();
                    row["Coluna 1"] = GetTagFOSE(dtAUX.Rows[r]["SPOOL"].ToString(), categoria, isom);
                    row["Coluna 2"] = "Produto Consumido";
                    row["Coluna 3"] = "Material";
                    row["Coluna 4"] = "'" + dtAUX.Rows[r]["CLIENT_CC"].ToString();
                    row["Coluna 5"] = "'" + dtAUX.Rows[r]["PART_DIAM1"].ToString();
                    row["Coluna 6"] = "'" + GenericClasses.FPSO.GetTubDim2(dtAUX.Rows[r]["SHORT_DESC"].ToString(), dtAUX.Rows[r]["PART_DIAM2"].ToString());  //PartDiam2
                    row["Coluna 7"] = "";
                    row["Coluna 8"] = "'" + dtAUX.Rows[r]["QUANTITY"].ToString();
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    row["Coluna 11"] = "";
                    dtProjPROD.Rows.Add(row);
                }
            }
        }
        //====================================================================
        public static void FillDataTableSERV(ref DataTable dtProjSERV, string isom, string fileName)
        {
            string strSQL = "";
            if (origem == "EMM_")
            {
                strSQL = @"SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY, TO_CHAR(SUM(TO_NUMBER(QUANTITY))) AS QUANTITY FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                               WHERE X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"'   --AND SPOOL like '%-BG-B10H-6042'
                               GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY 
                               ORDER BY X.ISOM, X.PIPELINE, X.SPOOL, CLIENT_CC";
            }
            //Insere as linhas de conteudo agrupado no DataTable dtProjSERV

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjTubRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");


            //Prepara o DataTable para SERV
            if (origem == "EMM_")
            {
                //TEEWEE
                DataRow row;
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    string spool = dtAUX.Rows[r]["SPOOL"].ToString().Replace("NULL", "");
                    string fpso = dtAUX.Rows[r]["FPSO"].ToString().Trim();
                    string[] auxArray = spool.Split('-');
                    categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim().ToUpper().Replace("Contractor fabricated", "FIELD");
                    area = dtAUX.Rows[r]["AREA"].ToString().Trim();
                    pipeline = dtAUX.Rows[r]["PIPELINE"].ToString().Trim();
                    string[] elementos = pipeline.Split('-');
                    string diam = elementos[0];
                    string sistema = elementos[1];
                    string spec = elementos[2];

                    for (int i = 0; i < 4; i++)
                    {
                        row = dtProjSERV.NewRow();
                        row["Coluna 1"] = GetTagFOSETeeWee(area, categoria, isom, pipeline, spool, fpso);
                        row["Coluna 2"] = GetServicosTUB_FAB_INT_MON_TH(i);
                        row["Coluna 3"] = "";
                        row["Coluna 4"] = "";
                        row["Coluna 5"] = "'" + dtAUX.Rows[r]["QUANTITY"].ToString();
                        row["Coluna 6"] = "ton";
                        row["Coluna 7"] = "";
                        row["Coluna 8"] = "'" + dtAUX.Rows[r]["QUANTITY"].ToString();
                        dtProjSERV.Rows.Add(row);
                    }
                }
            }
        }
        //====================================================================
        public static void FillDataTableFOSEMT(ref DataTable dtProjFOSEMT, string isom, string fileName)
        {
            string strSQL = "";
            strSQL = @"
                        SELECT * FROM 
                        (
                            SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, CASE WHEN X.CATEGORY = 'SHOP' THEN 'SHOP' WHEN X.CATEGORY = 'FIELD' THEN 'FIELD' END AS CATEGORY, ROUND(SUM(TO_NUMBER(X.WEIGHT)) / 1000,2) AS WEIGHT, SUM(TO_NUMBER(AREA_PAINTING)) AS AREA_PAINTING 
                                FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                                WHERE SPOOL IS NOT NULL AND X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' 
                                GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, X.CATEGORY 

                            UNION ALL

                            SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, CASE WHEN X.CATEGORY = 'SHOP' THEN 'FIELD' END AS CATEGORY, ROUND(SUM(TO_NUMBER(X.WEIGHT)) / 1000,2) AS WEIGHT, SUM(TO_NUMBER(AREA_PAINTING)) AS AREA_PAINTING 
                                FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                                WHERE SPOOL IS NOT NULL AND X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' AND SPOOL != 'Spool Mont' 
                                GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.REV, X.TREATMENT, X.AREA, X.CATEGORY 
                        )
                        WHERE CATEGORY = 'FIELD'
                        ORDER BY ISOM, PIPELINE, SPOOL, CATEGORY DESC";
            

            //Insere as linhas de conteudo agrupado no DataTable dtProjMTFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = null;
            if (origem == "EMM_") dtAUX = BLL.ProjTubRcptTeeweeBLL.Select(strSQL);
            else dtAUX = BLL.ProjTubRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            //Prepara o DataTable para MT_FOSE
            //TEEWEE
            DataRow row;
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                DTO.AcRegiaoDTO regiao = new DTO.AcRegiaoDTO();
                string spool = dtAUX.Rows[r]["SPOOL"].ToString().Replace("NULL", "");
                string fpso = dtAUX.Rows[r]["FPSO"].ToString().Trim();
                string[] auxArray = spool.Split('-');
                string unidadeProcesso = "";

                categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim().ToUpper().Replace("Contractor fabricated", "FIELD");
                pipeline = dtAUX.Rows[r]["PIPELINE"].ToString().Trim();

                //Area
                area = dtAUX.Rows[r]["AREA"].ToString().Trim();
                regiao = BLL.AcRegiaoBLL.GetObject("REGI_DESCRICAO = '" + area + "'");

                //Localizacao
                DTO.AcLocalizacaoDTO localizacao = new DTO.AcLocalizacaoDTO();
                localizacao = BLL.AcLocalizacaoBLL.GetObject("LOCALIZACAO_ID = " + regiao.RegiLocalizacaoId.ToString());

                //Setor
                DTO.AcSetorDTO setor = new DTO.AcSetorDTO();
                setor = BLL.AcSetorBLL.GetObject("SETOR_ID = " + regiao.RegiSetorId.ToString());

                //Unidade Processo


                string[] elementos = pipeline.Split('-');
                string diam = elementos[0];
                string sistema = elementos[1];
                string spec = elementos[2];
                //string piece4 = elementos[3];

                row = dtProjFOSEMT.NewRow();
                row["Coluna 1"] = isom + "_MT";   //GetTagFOSETeeWee(area, categoria, isom, pipeline, "SPOOL MONT", fpso);
                row["Coluna 2"] = dtAUX.Rows[r]["REV"].ToString();
                row["Coluna 3"] = "Liberada";
                row["Coluna 4"] = "ISO_MT";   //GetCriterioMedicao(categoria, fpso);  // "TUB_FAB ou TUB_MONT ou TUB_FAB_INT_MONT_TH";
                row["Coluna 5"] = "Spool";
                row["Coluna 6"] = GenericClasses.FPSO.GetFPSO(dtAUX.Rows[r]["ISOM"].ToString().Split('-')[2].Split('.')[1]);
                row["Coluna 7"] = unidadeProcesso;
                row["Coluna 8"] = area;
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                if (row["Coluna 1"].ToString().IndexOf("Spool Mont") >= 0) row["Coluna 11"] = "'0";
                else row["Coluna 11"] = "'" + dtAUX.Rows[r]["WEIGHT"].ToString();
                row["Coluna 12"] = "";
                row["Coluna 13"] = "ton";
                row["Coluna 14"] = "";
                row["Coluna 15"] = "";
                row["Coluna 16"] = "";
                row["Coluna 17"] = "";
                row["Coluna 18"] = "";
                row["Coluna 19"] = dtAUX.Rows[r]["ISOM"].ToString();
                if (categoria.ToUpper() == "FIELD") row["Coluna 20"] = "";
                else row["Coluna 20"] = "'" + dtAUX.Rows[r]["Area_Painting"].ToString();
                if (categoria.ToUpper() == "FIELD") row["Coluna 21"] = "";
                else row["Coluna 21"] = GenericClasses.FPSO.GetTubTreatment(dtAUX.Rows[r]["TREATMENT"].ToString());
                row["Coluna 22"] = "Não";
                row["Coluna 23"] = area;
                row["Coluna 24"] = diam;
                row["Coluna 25"] = sistema;
                row["Coluna 26"] = spec;
                row["Coluna 27"] = "";
                row["Coluna 28"] = localizacao.LocalizacaoNome;
                row["Coluna 29"] = "";
                row["Coluna 30"] = setor.SetorNome;
                dtProjFOSEMT.Rows.Add(row);
            }
            
        }
        //====================================================================
        public static void FillDataTablePRODMT(ref DataTable dtProjPRODMT, string isom, string fileName)
        {
            string strSQL = @"SELECT X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY, TO_CHAR(SUM(TO_NUMBER(QUANTITY))) AS QUANTITY FROM EEP_CONVERSION.PROJ_TUB_RCPT_TEEWEE X 
                               WHERE X.ISOM = '" + isom + "' AND FILE_NAME = '" + fileName + @"' CATEGORY = 'FIELD'  --AND SPOOL like '%-BG-B10H-6042'
                               GROUP BY X.ISOM, X.PIPELINE, X.SPOOL, X.FPSO, X.CLIENT_CC, X.SHORT_DESC, X.PART_DIAM1, X.PART_DIAM2, X.AREA, X.CATEGORY 
                               ORDER BY X.ISOM, X.PIPELINE, X.SPOOL, CLIENT_CC";

            //Insere as linhas de conteudo agrupado no DataTable dtProjPRODMT

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjTubRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");


            //Prepara o DataTable para PRODMT
            //TEEWEE
            DataRow row;
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                string spool = dtAUX.Rows[r]["SPOOL"].ToString().Replace("NULL", "");
                string fpso = dtAUX.Rows[r]["FPSO"].ToString().Trim();
                string[] auxArray = spool.Split('-');

                categoria = dtAUX.Rows[r]["CATEGORY"].ToString().Trim().ToUpper().Replace("Contractor fabricated", "FIELD");
                area = dtAUX.Rows[r]["AREA"].ToString().Trim();
                pipeline = dtAUX.Rows[r]["PIPELINE"].ToString().Trim();
                string[] elementos = pipeline.Split('-');
                string diam = elementos[0];
                string sistema = elementos[1];
                string spec = elementos[2];

                row = dtProjPRODMT.NewRow();
                row["Coluna 1"] = GetTagFOSETeeWee(area, categoria, isom, pipeline, spool, fpso);
                row["Coluna 2"] = "Produto Consumido";
                row["Coluna 3"] = "Material";
                row["Coluna 4"] = "'" + dtAUX.Rows[r]["CLIENT_CC"].ToString();
                row["Coluna 5"] = "'" + dtAUX.Rows[r]["PART_DIAM1"].ToString();
                row["Coluna 6"] = "'" + GenericClasses.FPSO.GetTubDim2(dtAUX.Rows[r]["SHORT_DESC"].ToString(), dtAUX.Rows[r]["PART_DIAM2"].ToString().Replace("NULL", ""));  //PartDiam2
                row["Coluna 7"] = "";
                row["Coluna 8"] = "'" + dtAUX.Rows[r]["QUANTITY"].ToString();
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "";
                dtProjPRODMT.Rows.Add(row);
            }            
        }
        //====================================================================
        private static string GetServicosTUB_FAB_INT_MON_TH(int i)
        {
            string serv = "";
            switch (i)
            {
                case 0: serv = "TUB_FAB"; break;
                case 1: serv = "TUB_INT"; break;
                case 2: serv = "TUB_MON"; break;
                case 3: serv = "TUB_TH"; break;
            }
            return serv;
        }
        //====================================================================
        private static object GetCriterioMedicao(string categoria, string fpso)
        {
            string criterio = "TUB_FAB";
            if (categoria.ToUpper() == "FIELD" || categoria.ToUpper() == "") criterio = "TUB_MONT";
            if (fpso == "P76") criterio = "TUB_FAB_INT_MON_TH";
            return criterio;
        }
        //====================================================================
        #endregion
        //====================================================================================================================================
        //====================================================================================================================================
        //====================================================================================================================================




        //====================================================================================================================================
        //====================================================================================================================================
        //====================================================================================================================================
        #region Support
        //====================================================================
        public static bool VerificaExistenciaPlanilhaTub(StreamWriter log, string fileName, string handledFolder)
        {
            string destinationFile = handledFolder + fileName;
            bool bRet = true;
            //bool bBlankLine = true;
            try
            {
                FileInfo f = new FileInfo(destinationFile);
                if (f.Exists)
                {
                    H.ProcessHistory = "Planilha " + fileName + " já aprovada e processada - Reprocessamento inválido."; GenericClasses.Log.SaveLog(log, H);
                    bRet = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bRet;
        }
        //============================================
        public static bool VerificaExistenciaCamposObrigatoriosTub(StreamWriter log, DataTable dtSpreadsheet)
        {
            //int line = 0;
            bool bRet = true;
            string spool = "";
            string[] elementosPipeline;
            //bool bBlankLine = true;
            try
            {
                for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
                {
                    //line = i + 2;
                    spool = dtSpreadsheet.Rows[i]["SPOOL"].ToString().Trim().Replace("NULL","");
                    if (origem == "EMM_" || origem == "EEP_") categoria = dtSpreadsheet.Rows[i]["CATEGORY"].ToString().Trim().Replace("Contractor fabricated", "FIELD").Replace("CONTRACTOR FABRICATED", "FIELD");
                    else categoria = dtSpreadsheet.Rows[i]["CATEGORIA"].ToString().Trim();
                    if (categoria == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna CATEGORIA - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    else
                    {
                        if (categoria.ToUpper() != "SHOP" && categoria.ToUpper() != "FIELD") 
                        { 
                            H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna CATEGORIA - Deve ser Shop ou Field"; 
                            GenericClasses.Log.SaveLog(log, H); bRet = false; 
                        }
                        else
                        {
                            //CATEGORIA É SHOP
                            if (categoria.ToUpper() == "SHOP")
                            {
                                if (spool == "") 
                                { 
                                    H.ProcessHistory  ="Linha " + (i + 2).ToString() + " ==> Categoria Shop Coluna SPOOL - em branco"; 
                                    GenericClasses.Log.SaveLog(log, H); bRet = false; 
                                }
                                //if (dtSpreadsheet.Rows[i]["PartSched1"].ToString().Trim() == "") { GenericClasses.Log.SaveLog(log, "Linha " + (i + 2).ToString() + " ==> Categoria Shop Coluna PartSched1 - em branco"); bRet = false; }
                                if (dtSpreadsheet.Rows[i]["PartDiam1"].ToString().Trim() == "") 
                                {
                                    H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Categoria Shop = Coluna PartDiam1 - em branco";
                                    GenericClasses.Log.SaveLog(log, H); 
                                    bRet = false; 
                                }
                                if (dtSpreadsheet.Rows[i]["Treatment"].ToString().Trim() == "") 
                                {
                                    H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Categoria Shop Coluna Treatment - em branco";
                                    GenericClasses.Log.SaveLog(log, H); 
                                    bRet = false; 
                                }
                                if (origem == "EMM_" || origem == "EEP_")
                                {
                                    if (dtSpreadsheet.Rows[i]["Painting"].ToString().Trim() == "") 
                                    {
                                        H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==>  Categoria Shop Coluna Painting - em branco";
                                        GenericClasses.Log.SaveLog(log, H); 
                                        bRet = false; 
                                    }
                                }
                            }
                        }
                    }

                    if (origem == "EMM_" || origem == "EEP_")
                    {
                        if (dtSpreadsheet.Rows[i]["FPSO"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna FPSO - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                        if (origem == "EMM_")
                        {
                            if (dtSpreadsheet.Rows[i]["IsoLinha"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna IsoLinha - em branco";  GenericClasses.Log.SaveLog(log, H); bRet = false; }
                        }
                        if (dtSpreadsheet.Rows[i]["RevLinha"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna RevLinha - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    }
                    if (dtSpreadsheet.Rows[i]["AREA"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna AREA - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["ISOM"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna ISOM - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    
                    //PIPELINE
                    if (dtSpreadsheet.Rows[i]["PIPELINE"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna PIPELINE - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    else
                    {
                        if (origem == "EMM_" || origem == "EEP_")
                        {
                            elementosPipeline = dtSpreadsheet.Rows[i]["PIPELINE"].ToString().Split('-');
                            if (elementosPipeline[0].IndexOf('"') == -1 && elementosPipeline[0].IndexOf("mm") == -1) 
                            { 
                                H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna PIPELINE - Faltam aspas duplas na indicação do diâmetro"; 
                                GenericClasses.Log.SaveLog(log, H); 
                                bRet = false; 
                            }
                        }
                    }
                    
                    //REV
                    if (dtSpreadsheet.Rows[i]["REV"].ToString().Trim() == "")
                    {
                        H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna REV - em branco";
                        GenericClasses.Log.SaveLog(log, H);
                        bRet = false;
                    }

                    if (dtSpreadsheet.Rows[i]["CONTRACTOR_CC"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna CONTRACTOR_CC - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["CLIENT_CC"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna CLIENT_CC - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["SHORT_DESC"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna SHORT_DESC - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["Quantity"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna Quantity - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["Weight"].ToString().Trim() == "") { H.ProcessHistory = "Linha " + (i + 2).ToString() + " ==> Coluna Weight - em branco"; GenericClasses.Log.SaveLog(log, H); bRet = false; }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bRet;
        }
        //====================================================================
        internal static void DiscardSpool(string spool, string fileName)
        {
            string strSQL = @"UPDATE EEP_CONVERSION.PROJ_TUB_RCPT SET DISCARDED = 1 WHERE SPOOL = '" + spool + "' AND FILE_NAME = '" + fileName + "'";
            BLL.ProjTubRcptBLL.ExecuteSQLInstruction(strSQL);
        }
        //====================================================================
        private static object GetTagFOSE(string spool, string categoria, string isom)
        {
            //2"-BR-B8H-6081_BR-B8H-6081_Spool1.F711
            string tagFOSE = "";
            string fpso = GenericClasses.FPSO.GetFPSO(isom.Split('-')[2].Split('.')[1]) + "_";
            if (fpso == "P74_") fpso = "";
            switch (categoria.ToUpper())
            {
                case "SHOP":
                    {
                        tagFOSE += fpso + spool + ".F" + isom.Split('-')[6];
                        break;
                    }
                case "FIELD":
                    {
                        tagFOSE += fpso + spool + ".M" + isom.Split('-')[6]; ;
                        break;
                    }
            }
            return tagFOSE;
        }
        //====================================================================
        private static object GetTagFOSETeeWee(string area, string categoria, string isom, string pipeline, string spool, string fpso)
        {
            string tagFOSE = "";
            string[] elementos = pipeline.Split('-');
            string diam = elementos[0];
            string sistema = elementos[1];
            string spec = elementos[2];
            //string piece4 = elementos[3];
            string linha = isom.Split('-')[6];
            //string fpso = GenericClasses.FPSO.GetFPSO(isom.Split('-')[2].Split('.')[1]) + "_";
            fpso = fpso + "_";
            if (fpso == "P74_") fpso = "";

                if (spool != "Spool Mont")
                {
                    switch (categoria.ToUpper())
                    {
                        case "SHOP":
                            {
                                if (fpso == "P76_") { tagFOSE += fpso + spool + ".F" + linha; }
                                else { tagFOSE += fpso + pipeline.Split('-')[0] + "-" + spool + ".F" + linha; }
                                break;
                            }
                        case "FIELD":
                            {
                                if (fpso == "P76_") { tagFOSE += fpso + spool + ".M" + linha; }
                                else { tagFOSE += fpso + pipeline.Split('-')[0] + "-" + spool + ".M" + linha; }
                                break;
                            }
                    }
                }
                else
                {
                    if (fpso == "P76_") { tagFOSE += fpso + pipeline.Replace(pipeline.Split('-')[0], "").Substring(1) + "-" + spool + ".M" + linha; }
                    else { tagFOSE += fpso + pipeline + "_" + spool + ".M" + linha; }
                }
            
                //////////////////////////////////////////////////////////
                //Implementação da mudança de Estrutura de Códigos da P76
                tagFOSE = GetNewCodeP76(area, categoria, isom, pipeline, spool, fpso);
                //////////////////////////////////////////////////////////
            
            return tagFOSE;
        }
        //====================================================================
        public static string GetNewCodeP76(string area, string categoria, string isom, string pipeline, string spool, string fpso)
        {
            string tag = "";
            string ns = "";
            string p1, p2 = "";
            string strSpool = spool.ToUpper();
            int i = strSpool.IndexOf("SPOOL");
            ns = "0" + strSpool.Substring(i + 5);
            ns = ns.Substring(ns.Length - 2);
            tag = area + "_" + pipeline.Replace(pipeline.Split('-')[0], "").Substring(1) +"_" + isom.Split('-')[6] + "_";
            if (spool.ToUpper() == "SPOOL MONT") tag += "MT";
            else
            {
                tag += "SP" + ns;
            }
            return tag;
        }
        #endregion
        //====================================================================================================================================
        //====================================================================================================================================
        //====================================================================================================================================



    }
}