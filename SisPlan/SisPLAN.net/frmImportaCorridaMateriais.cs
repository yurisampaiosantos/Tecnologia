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
    public partial class frmImportaCorridaMateriais : Form
    {

        #region Initialize

        static DTO.LoggedUserDTO user = new DTO.LoggedUserDTO();

        static DataTable dtCorridaMaterial = null;

        static string contrato = "Conversão";
        static decimal discId = 5;
        static string disciplina = "Tubulacao";
        static string repositoryFolder = @"F:\CONVERSÃO\PLANEJAMENTO\3-PCP\19-Corridas de Materiais de Tubulação";
        static string worksheetDisciplina = @"Programação Via Corrida$";
        static string mainFileName = "";

        static string exceptionFolder = "";
        static string handledFolder = "";
        static System.IO.FileInfo[] files;
        static DirectoryInfo dir;

        #endregion

        //============================================
        public frmImportaCorridaMateriais()
        {
            InitializeComponent();
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        }
        //============================================
        private void frmImportaCorridaMateriais_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            user.UserId = System.Windows.Forms.SystemInformation.UserName; ;
            user.Domain = System.Windows.Forms.SystemInformation.UserDomainName;

            dir = new DirectoryInfo(repositoryFolder);
            files = dir.GetFiles("*.xls" );
            if (files.Length == 0) grv.Visible = false;
            grv.DataSource = files;
            OmiteColunasGrid();
            grv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        //============================================
        private void OmiteColunasGrid()
        {
            grv.Columns[1].Visible = false;
            grv.Columns[2].Visible = false;
            grv.Columns[3].Visible = false;
            grv.Columns[4].Visible = false;
            grv.Columns[5].Visible = false;
            grv.Columns[6].Visible = false;
            grv.Columns[7].Visible = false;
            grv.Columns[9].Visible = false;
            grv.Columns[10].Visible = false;
            grv.Columns[11].Visible = false;
            grv.Columns[12].Visible = false;
            grv.Columns[13].Visible = false;
            grv.Columns[14].Visible = false;
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
                            exceptionFolder = repositoryFolder + @"\Exceptions\";
                            handledFolder = repositoryFolder + @"\Handled\";

                            System.IO.FileInfo file = new FileInfo(repositoryFolder + @"\" + files[i]);

                            //Copia planilha para o EXCEPTION
                            file.CopyTo(exceptionFolder + file.Name, true);
                            file.Delete();
                            mainFileName = file.Name;

                            //Processa Arquivo Recebido
                            FileContentProcessing(exceptionFolder + file.Name, worksheetDisciplina, user.UserId, file.Name);
                            this.grv.Rows[i].Cells[0].Style.ForeColor = Color.Black;
                            this.grv.Rows[i].Cells[0].Style.BackColor = Color.Yellow;
                            Application.DoEvents();

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
                System.IO.FileInfo fileImported  = new FileInfo(exceptionFolder + @"\" + mainFileName);

                //Copia planilha para o EXCEPTION
                fileImported.CopyTo(handledFolder + fileImported.Name, true);
                fileImported.Delete();
                MessageBox.Show("Corrida de material importada com sucesso!");
            }
        }
        //==============================================
        private static bool ValidSpreadSheetName(string name)
        {
            bool bRet = true;
            
            return bRet;
        }
        //============================================
        private static bool SpreadsheetProcessed(FileInfo file)
        {
            bool bRet = false;
            //Deleta registros da planilha caso tenham sido recebidos anteriormente
            BLL.AcCorridaMaterialBLL.ExecuteSQLInstruction("DELETE FROM EEP_CONVERSION.AC_CORRIDA_MATERIAL WHERE FILE_NAME = '" + file.Name + "'");
            BLL.AcCorridaMaterialBLL.ExecuteSQLInstruction("COMMIT");
            return bRet;
        }
        //============================================
        private static void FileContentProcessing(string fileFullName, string worksheetDisciplina, string userId, string fileName)
        {
            try
            {
                System.IO.FileInfo file = new FileInfo(fileFullName);
                string connStr = string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;'", fileFullName);
                string strSQL = "SELECT * FROM [" + worksheetDisciplina + "]";

                //Recebe no DataTable a planilha
                dtCorridaMaterial = GenericClasses.SpreadSheets.SpreadSheetReception(connStr, strSQL, disciplina, user.UserId, fileName);

                //Recebe no banco a planilha Tubulacao da Projemar
                //SaveCorridaMaterial(dtCorridaMaterial, disciplina, user.UserId, fileName);

                SaveCorridaMaterial(dtCorridaMaterial, disciplina, user, fileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //============================================
        private static void SaveCorridaMaterial(DataTable dtProjRcpt, string disciplina, DTO.LoggedUserDTO user, string fileName)
        {

            //Grava Corrida de Material
            string status = "";
            DTO.AcCorridaMaterialDTO corrida = new DTO.AcCorridaMaterialDTO();
            DTO.AcCorridaMaterialItemDTO itemCorrida = new DTO.AcCorridaMaterialItemDTO();

            //Obter Chave primária de AC_CORRIDA_MATERIAL
            corrida.ComaId = BLL.AcCorridaMaterialBLL.GetNextval();
            corrida.ComaCreatedBy = user.UserId;
            corrida.ComaFileName = "SISEPC - Pendências da Corrida de Materiais Nº " + corrida.ComaId.ToString() + " em (" + System.DateTime.Now.ToString("yyyy_MM_dd HH.mm.ss") + ")";

            try 
            {
                BLL.AcSpoolsPendentesBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_CORRIDA_MATERIAL_ITEM");

                //Inserir tabela AC_CORRIDA_MATERIAL
                BLL.AcCorridaMaterialBLL.Insert(corrida, true);

                //Definir Chave estrangeira em AC_CORRIDA_MATERIAL_ITEM
                itemCorrida.CmitComaId = corrida.ComaId;

                //Inserir Itens na tabela AC_CORRIDA_MATERIAL_ITEM
                for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
                {
                    status = dtProjRcpt.Rows[i]["Status"].ToString().Trim();
                    if (status != "OK")
                    {
                        itemCorrida.CmitFoseNumero = dtProjRcpt.Rows[i]["Folha de Serviço"].ToString().Trim();
                        itemCorrida.CmitDiprCodigo = dtProjRcpt.Rows[i]["Código"].ToString().Trim();
                        itemCorrida.CmitDiprDimensoes = dtProjRcpt.Rows[i]["Dimensões"].ToString().Trim();
                        itemCorrida.CmitDiprDescricao = dtProjRcpt.Rows[i]["Descrição"].ToString().Trim();
                        itemCorrida.CmitUnmeSigla = dtProjRcpt.Rows[i]["Unidade Medida"].ToString().Trim();
                        itemCorrida.CmitQtdFsCorrida = Convert.ToDecimal(dtProjRcpt.Rows[i]["Qtd# FS corrida"]);
                        itemCorrida.CmitQtdAReservar = Convert.ToDecimal(dtProjRcpt.Rows[i]["Qtd# à reservar"]);
                        itemCorrida.CmitStatus = status;
                        itemCorrida.CmitCreatedBy = user.UserId;
                        try { BLL.AcCorridaMaterialItemBLL.Insert(itemCorrida, false); }
                        catch (Exception ex) { throw new Exception(ex.Message); }
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private void button1_Click(object sender, EventArgs e)
        {
            string msg = "";
            if (grv.Rows.Count > 0)
            {
                pb.Visible = true;
                grv.CurrentRow.Selected = false;
                Application.DoEvents();
                lblMessage.Text = "Capturando a Corrida de Material...";
                Application.DoEvents();
                GetSpreadsheets();
                GenericClasses.PreparaPendenciaSpools.GerarPendenciaSpools(contrato, discId.ToString(), lblMessage, pb);
                msg = "Captura de corrida e cálculo de pendências realizados com sucesso.";
            }
            else
            {
                msg = "Não há corridas a importar.";
            }
            MessageBox.Show(msg);
            this.Close();
        }

        //============================================
    }
}