using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Diagnostics;


namespace SisPLAN.net
{
    public partial class frmImportaMateriaisTubulacao : Form
    {

        #region Initialize

        static DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();
        static bool validaFOSE = false;
        //static bool validaPROD = false;
        static private string login = "";
        static DTO.LoggedUserDTO user = new DTO.LoggedUserDTO();

        static DataTable dtProjRcpt = null;
        static DataTable dtProjFOSE = null;
        static DataTable dtProjPROD = null;
        static DataTable dtProjSERV = null;
        static DataTable dtProjFOSEMT = null;
        static DataTable dtProjPRODMT = null;

        //static DataTable dtProjemarSISEPCTubulacao = null;

        static string disciplina = "Tubulacao";
        static string repositoryFolder = @"F:\CONVERSÃO\PROJEMAR\Tubulacao\";
        static string worksheetDisciplina = @"Plan1$";
        static string destinatariosTO = "";
        static string destinatariosCC = "";
        static string destinatariosBCC = "";
        static string destinatariosLOG = "";
        static string mainFileName = "";
        static string fileNameFOSE = "";
        static string fileNamePROD = "";
        static string fileNameSERV = "";
        static string fileNameFOSEMT = "";
        static string fileNamePRODMT = "";

        static string isom = "";

        //string spool = "";

        //static string spool = "";

        static string exceptionFolder = "";
        static string handledFolder = "";
        static string sisepcFolder = "";
        static string revisionFolder = "";
        static string logFolder = "";
        static System.IO.FileInfo[] files;
        static string plataforma = "";
        static DirectoryInfo dir;
        static string tituloEmail = "";
        static string origem = "";

        static bool restricaoMaterial = false;

        #endregion

        //============================================
        public frmImportaMateriaisTubulacao()
        {
            InitializeComponent();
        }
        //============================================
        private void frmImportaMateriaisTubulacao_Load(object sender, EventArgs e)
        {

                this.WindowState = FormWindowState.Maximized;
                panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                //reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
                //reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;

                GenericClasses.Mail m = new GenericClasses.Mail();

                user.UserId = System.Windows.Forms.SystemInformation.UserName; ;
                user.Domain = System.Windows.Forms.SystemInformation.UserDomainName;

                dir = new DirectoryInfo(repositoryFolder);
                files = dir.GetFiles();
                grv.DataSource = files;
                grv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
        }
        //============================================
        private void btnImportaPlanilhas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Importações suspensas, programa em manutenção!");
            if (1 == 0)
            {
                grv.CurrentRow.Selected = false;
                Application.DoEvents();
                GetSpreadsheets();
            }
        }
        //============================================
        private void GetSpreadsheets()
        {
            if (files.Length == 0)
            {
                MessageBox.Show("Não há planilhas a serem importadas!");
            }
            else
            {
                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        if (ValidSpreadSheetName(files[i].Name))
                        {
                            if (files[i].Name.Substring(0, 4).ToUpper() == "EMM_") 
                            {
                                plataforma = GenericClasses.FPSO.GetFPSO(files[i].ToString().Split('_')[2].Split('.')[1].Split('-')[0]);
                                }
                            else plataforma = GenericClasses.FPSO.GetFPSO(files[i].ToString().Split('-')[2].Split('.')[1]);
                            exceptionFolder = repositoryFolder + plataforma + @"\Exceptions\";
                            handledFolder = repositoryFolder + plataforma + @"\Handled\";
                            sisepcFolder = repositoryFolder + plataforma + @"\SISEPC\";

                            revisionFolder = repositoryFolder + plataforma + @"\Revision\";
                            logFolder = repositoryFolder + plataforma + @"\LOG\";

                            System.IO.FileInfo file = new FileInfo(repositoryFolder + files[i]);
                            //Processa a planilha se ainda não foi processada
                            if (!SpreadsheetProcessed(file))
                            {
                                //Copia planilha para o EXCEPTION
                                file.CopyTo(exceptionFolder + file.Name, true);
                                file.Delete();
                                mainFileName = file.Name;
                                fileNameFOSE = "FOSE_" + mainFileName;
                                fileNamePROD = "PROD_" + mainFileName;
                                fileNameSERV = "SERV_" + mainFileName;
                                fileNameFOSEMT = "FOSEMT" + mainFileName;
                                fileNamePRODMT = "PRODMT" + mainFileName;

                                //Processa Arquivo Recebido
                                SettingDestinatarios(disciplina);
                                if (mainFileName.Substring(0, 4) == "EMM_" || mainFileName.Substring(0, 4) == "EEP_") origem = "EMM_";
                                FileContentProcessing(exceptionFolder + file.Name, worksheetDisciplina, user.UserId, file.Name);
                                this.grv.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                                this.grv.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                                Application.DoEvents();
                            }
                            file = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message == "Index was outside the bounds of the array.")
                        {
                            System.Windows.Forms.MessageBox.Show("O nome da planilha não segue a nomenclatura padrão");
                        }
                        else System.Windows.Forms.MessageBox.Show(ex.Message);
                    }
                }
                MessageBox.Show("Fim do processamento!");
            }
        }
        //==============================================
        private static bool ValidSpreadSheetName(string name)
        {
            bool bRet = true;
            if (name.IndexOf(" ") >= 0) { bRet = false; MessageBox.Show("Planilha " + name + " ==> Nome não pode conter espaços"); }
            else if (name.IndexOf(".0F") == -1 && name.IndexOf(".0G") == -1 && name.IndexOf(".0H") == -1 && name.IndexOf(".0J") == -1) { bRet = false; MessageBox.Show("Nome de planilha precisa possuir '.0F' ou '.0G' ou '.0H' ou '.0J'"); }
            return bRet;
        }
        //==============================================
        private static void SettingDestinatarios(string disciplina)
        {
            try
            {
                DataTable dt = null;
                //To
                if (mainFileName.Substring(0, 3) == "EMM" || mainFileName.Substring(0, 3) == "EEP")
                {
                    dt = BLL.ProjGenEmailBLL.Get("(TIPO_DESTINATARIO = 'TO' OR TIPO_DESTINATARIO = 'EMT') AND X.DISCIPLINA = '" + disciplina + "' AND X.ATIVO = 1", "EMAIL");
                }
                else
                {
                    dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'TO' AND X.DISCIPLINA = '" + disciplina + "' AND X.ATIVO = 1", "EMAIL");
                }
                destinatariosTO = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosTO += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosTO.Length > 0) destinatariosTO = destinatariosTO.Substring(1);

                //Cc
                if (mainFileName.Substring(0, 3) == "EMM" || mainFileName.Substring(0, 3) == "EEP")
                {
                    dt = BLL.ProjGenEmailBLL.Get("(TIPO_DESTINATARIO = 'CC' OR TIPO_DESTINATARIO = 'EMC') AND (X.DISCIPLINA = 'TODAS' OR X.DISCIPLINA = '" + disciplina + "' ) AND X.ATIVO = 1", "EMAIL");
                }
                else
                {
                    dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'CC' AND (X.DISCIPLINA = 'TODAS' OR X.DISCIPLINA = '" + disciplina + "' ) AND X.ATIVO = 1", "EMAIL");
                }

                destinatariosCC = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosCC += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosCC.Length > 0) destinatariosCC = destinatariosCC.Substring(1);
                //Bcc
                dt = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'BCC' AND X.DISCIPLINA = 'TODAS' AND X.ATIVO = 1", "EMAIL");
                destinatariosBCC = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosBCC += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosBCC.Length > 0) destinatariosBCC = destinatariosBCC.Substring(1);
                //LOG
                dt = BLL.ProjGenEmailBLL.Get("(TIPO_DESTINATARIO = 'LOG' OR TIPO_DESTINATARIO = 'EMC' OR TIPO_DESTINATARIO = 'EMT') AND X.DISCIPLINA = '" + disciplina + "' AND X.ATIVO = 1", "EMAIL");
                destinatariosLOG = "";
                for (int I = 0; I < dt.Rows.Count; I++) { destinatariosLOG += ";" + dt.Rows[I]["EMAIL"].ToString(); }
                if (destinatariosLOG.Length > 0) destinatariosLOG = destinatariosLOG.Substring(1);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //==============================================
        public static string GetCorpoEmail(string disciplina, System.IO.FileInfo file, bool restricaoMaterial)
        {
            string corpo = "";
            corpo += "Prezado Integrante,<br/><br/>";
            if (restricaoMaterial)
            {
                corpo += "A planiha " + file.Name + " foi processada COM RESTRIÇÕES.<br/>";
                corpo += "Acesse a pasta " + sisepcFolder + " para prosseguir com o processo de importação de dados para o SISEPC, corrija as invalidações abaixo e reprocesse a planilha:<br/><br/><br/>";
            }
            else
            {
                corpo += "A planiha " + file.Name + " foi importada com sucesso.<br/>";
                corpo += "Acesse a pasta " + sisepcFolder + " para prosseguir com o processo de importação de dados para o SISEPC.<br/><br/><br/>";
            }

            string fileName = logFolder + @"\" + file.Name + @"_LOG.txt";
            string strLine = "";
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                strLine = sr.ReadLine().ToString();
                corpo += strLine + @"<br/>";
            }
            sr.Close();
            return corpo;
        }
        //==============================================
        public static string GetCorpoRejeicao(string disciplina, System.IO.FileInfo file)
        {
            string corpo = "";
            corpo += "Prezado Integrante,<br/><br/>";
            corpo += "A planiha " + file.Name + " foi rejeitada para importação.<br/>";
            corpo += "Acesse o arquivo " + logFolder + file.Name + @"_LOG.txt para analisar as causas da rejeição.<br/><br/><br/>";
            return corpo;
        }
        //============================================
        private static bool SpreadsheetProcessed(FileInfo file)
        {
            bool bRet = false;
            int X = BLL.ProjTubRcptBLL.Count("FILE_NAME = '" + file.Name + "'");
            if (X > 0)
            {
                //Deleta registros da planilha caso tenham sido recebidos anteriormente
                BLL.ProjTubRcptBLL.ExecuteSQLInstruction("DELETE FROM EEP_CONVERSION.PROJ_TUB_RCPT WHERE FILE_NAME = '" + file.Name + "'");
                BLL.ProjTubRcptBLL.ExecuteSQLInstruction("COMMIT");
            }

            return bRet;
        }
        //============================================
        private static void FileContentProcessing(string fileFullName, string worksheetDisciplina, string userId, string fileName)
        {
            try
            {
                restricaoMaterial = false;
                System.IO.FileInfo file = new FileInfo(fileFullName);
                string connStr = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;'", fileFullName);
                string strSQL = "SELECT * FROM [" + worksheetDisciplina + "]";    // WHERE ISOM IS NOT NULL";
                origem = fileName.Substring(0, 4);
                //Open rLog
                StreamWriter log = new StreamWriter(logFolder + @"\" + fileName + @"_LOG.txt");
                //Inicio
                H.ProcessHistory = "Início da Validação da planilha                                           : " + System.DateTime.Now;
                H.FileName = fileName;
                GenericClasses.Log.SaveLog(log, H);
                //Recebe no DataTable a planilha
                dtProjRcpt = GenericClasses.SpreadSheets.SpreadSheetReception(connStr, strSQL, disciplina, userId, fileName);

                //VALIDA FOSE
                validaFOSE = GenericClasses.Tubulacao.IsValidTubSpreadsheet(dtProjRcpt, fileName, logFolder, log, disciplina, handledFolder);
                if (validaFOSE)
                {
                    //Recebe no banco a planilha Tubulacao da Projemar

                    if (origem == "EMM_" || origem == "EEP_")
                    {
                        GenericClasses.Tubulacao.SaveProjTubTeeWeeRcpt(dtProjRcpt, disciplina, userId, fileName, log);
                    }
                    else
                    {
                        GenericClasses.Tubulacao.SaveProjTubRcpt(dtProjRcpt, disciplina, userId, fileName, log);
                    }
                    //Obtem ISOMÉTRICO
                    isom = dtProjRcpt.Rows[0]["ISOM"].ToString().Trim();


                    //Cria cabeçalho no DataTable dtProjFOSE
                    dtProjFOSE = GenericClasses.Tubulacao.CreateTubHeaderFOSE();
                    //Preenche o DataTable FOSE
                    GenericClasses.Tubulacao.FillDataTableFOSE(ref dtProjFOSE, isom, fileName);
                    //CriaPlanilhaFOSE a partir do DataTable dtProjFOSE
                    GenericClasses.SpreadSheets.CreateSpreadSheet(dtProjFOSE, sisepcFolder + @"FOSE\" + fileNameFOSE);

                    tituloEmail = "Planejamento - PCP - FOSE gerada com sucesso: " + fileNameFOSE;
                    
                    if (plataforma == "P76")
                    {
                        //SERV
                        //Cria cabeçalho no DataTable dtProjSERV
                        dtProjSERV = GenericClasses.Tubulacao.CreateTubHeaderSERV();
                        //Preenche o DataTable SERV
                        GenericClasses.Tubulacao.FillDataTableSERV(ref dtProjSERV, isom, fileName);
                        //CriaPlanilhaSERV a partir do DataTable dtProjSERV
                        GenericClasses.SpreadSheets.CreateSpreadSheet(dtProjSERV, sisepcFolder + @"SERV\" + fileNameSERV);


                        //MT
                        //Cria cabeçalho para o DataTable dtProjMT_FOSE (Usa o mesmo de FOSE)
                        dtProjFOSEMT = GenericClasses.Tubulacao.CreateTubHeaderFOSE();
                        //Preenche o DataTable dtProjFOSEMT
                        GenericClasses.Tubulacao.FillDataTableFOSEMT(ref dtProjFOSEMT, isom, fileName);
                        //CriaPlanilhaMT_FOSE a partir do DataTable dtProjFOSEMT
                        GenericClasses.SpreadSheets.CreateSpreadSheet(dtProjFOSEMT, sisepcFolder + @"MT\" + fileNameFOSEMT);

                        tituloEmail = "Planejamento - PCP - FOSE / SERV / MT geradas com sucesso a partir de: " + fileName;
                    }

                    
                    //Grava Log
                    H.ProcessHistory = tituloEmail;
                    GenericClasses.Log.SaveLog(log, H);
                    //Envia email de sucesso
                    GenericClasses.Mail m = new GenericClasses.Mail();

                    log.Close();
                    log.Dispose();
                    m.Sendmail("Goliath@eepsa.com.br", destinatariosTO, destinatariosCC, destinatariosBCC, "", tituloEmail, GetCorpoEmail(disciplina, file, false), "");

                }
                else
                {
                    tituloEmail = "Falha na importação: FOSE/PROD: " + fileName + " não foram criadas.";
                    //Grava Log
                    H.ProcessHistory = tituloEmail;
                    GenericClasses.Log.SaveLog(log, H);
                    //Envia email de rejeição
                    GenericClasses.Mail m = new GenericClasses.Mail();
                    log.Close();
                    log.Dispose();
                    m.Sendmail("Goliath@eepsa.com.br", "", destinatariosCC, "", destinatariosLOG, tituloEmail, GetCorpoRejeicao(disciplina, file), logFolder + file.Name + "_LOG.txt");
                }

                if (validaFOSE)
                {
                    //Open rLog
                    StreamWriter logPROD = new StreamWriter(logFolder + @"\" + fileName + @"_LOG.txt");
                    //VALIDA PROD
                    if (GenericClasses.Tubulacao.IsValidTubSpreadsheetPROD(dtProjRcpt, fileName, logFolder, logPROD, disciplina, handledFolder, ref restricaoMaterial))
                    {
                        //Cria cabeçalho no DataTable dtProjPROD
                        dtProjPROD = GenericClasses.Tubulacao.CreateTubHeaderPROD();
                        //Preenche o DataTable PROD
                        GenericClasses.Tubulacao.FillDataTablePROD(ref dtProjPROD, isom, fileName);
                        //CriaPlanilhaPROD a partir do DataTable dtProjPROD
                        GenericClasses.SpreadSheets.CreateSpreadSheet(dtProjPROD, sisepcFolder + @"PROD\" + fileNamePROD);

                        if (plataforma == "P76")
                        {
                            //MT
                            //Cria cabeçalho no DataTable dtProjPROD
                            dtProjPRODMT = GenericClasses.Tubulacao.CreateTubHeaderPROD();
                            //Preenche o DataTable PRODMT
                            GenericClasses.Tubulacao.FillDataTablePRODMT(ref dtProjPRODMT, isom, fileName);
                            //CriaPlanilhaPRODMT a partir do DataTable dtProjPRODMT
                            GenericClasses.SpreadSheets.CreateSpreadSheet(dtProjPRODMT, sisepcFolder + @"PRODMT\" + fileNamePRODMT);
                        }
                        //Copia planilha para o HANDLER
                        file.CopyTo(handledFolder + file.Name, true);

                        if (restricaoMaterial)
                        {
                            tituloEmail = "Planejamento - PCP - Template PROD gerado COM RESTRIÇÕES: " + fileNamePROD;
                        }
                        else
                        {
                            tituloEmail = "Planejamento - PCP - Template PROD gerado com sucesso: " + fileNamePROD;
                        }
                        //Grava Log
                        H.ProcessHistory = tituloEmail;
                        GenericClasses.Log.SaveLog(logPROD, H);
                        //Envia email de sucesso
                        GenericClasses.Mail m = new GenericClasses.Mail();
                        logPROD.Close();
                        logPROD.Dispose();
                        m.Sendmail("Goliath@eepsa.com.br", destinatariosTO, destinatariosCC, destinatariosBCC, "", tituloEmail, GetCorpoEmail(disciplina, file, restricaoMaterial), "");

                        file.Delete();
                    }
                    else
                    {
                        tituloEmail = "Houve falha no procesamento da planilha: " + fileName;
                        //Grava Log
                        H.ProcessHistory = tituloEmail;
                        GenericClasses.Log.SaveLog(log, H);
                        //Envia email de rejeição
                        GenericClasses.Mail m = new GenericClasses.Mail();
                        logPROD.Close();
                        logPROD.Dispose();
                        m.Sendmail("Goliath@eepsa.com.br", "", "", "", destinatariosLOG, tituloEmail, GetCorpoRejeicao(disciplina, file), "");
                    }
                }
                //Close Log
                log.Close();
                log.Dispose();
            }
            catch (Exception ex)
            {
                GenericClasses.Mail m = new GenericClasses.Mail();
                m.Sendmail("Goliath@eepsa.com.br", "", "", "", destinatariosLOG, "Falha no processo de recepção da planilha:  " + fileName, ex.Message, "");
                throw new Exception(ex.Message);
            }
        }
        //============================================
        //============================================

        public static void WriteCSV(string strFileName, DataTable tbl)
        {
            try
            {
                StringBuilder strResult = new StringBuilder();
                foreach(DataColumn col in tbl.Columns) 
                { 
                    strResult.Append(@""" " + col.ColumnName + @" "",");
                }
                //strResult.Append(vbNewLine)
                //string CRLF = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); 


                foreach(DataRow row in tbl.Rows)
                {
                    foreach(DataColumn col in tbl.Columns)
                    {
                        strResult.Append(@"""" + col.ColumnName.ToString() + @""",");
                    }
                    //strResult.Append(vbNewLine)
                    //string CRLF = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); 
                }
                

                HttpContext.Current.Response.Expires = 0;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName + "");
                HttpContext.Current.Response.AddHeader("Content-type", "application/vnd.ms-excel");
                HttpContext.Current.Response.Write(strResult.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}



