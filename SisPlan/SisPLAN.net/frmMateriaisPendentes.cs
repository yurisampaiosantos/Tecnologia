using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;
using System.IO;


namespace SisPLAN.net
{
    public partial class frmMateriaisPendentes : Form
    {
        DataTable dtDOC = null;
        //DataTable dt = null;
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        static string discId, sbcnSigla, fcmeSigla, criterio, dataCorteUpdateControl = "";
        string dtInicial, dtFinal = "";
        static string strSQL = "";
        string userName = "";
        string asp = Convert.ToChar(34).ToString();
        string filter, order = "";
        string titulo = "";
        
        //===================================================================================
        public frmMateriaisPendentes()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmMateriaisPendentes_Load(object sender, EventArgs e)
        {
            discId = "5";
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnExcel, "Exporta relatório para Excel");
        }
        //===================================================================================
        private void SetFilterOrder(string fpso)
        {
            order = "MAPD_DIPR_CODIGO";
            filter = "X.MAPD_SBCN_SIGLA = '" + cmbFPSO.Text + "'";
        }
        //===================================================================================
        private void ShowReport(string filter, string order)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7
            reportViewer1.Reset();

            DTO.CollectionAcMateriaisPendentesDTO col = new DTO.CollectionAcMateriaisPendentesDTO();
            col = BLL.AcMateriaisPendentesBLL.GetCollection(filter, order);
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcMateriaisPendentes.rdlc";

            ReportDataSource rds = new ReportDataSource("dsMateriaisPendentes", col);
            
            report.DataSources.Add(rds);
            CollectionAcStatusTubDTOBindingSource.DataSource = col;

            reportViewer1.LocalReport.DataSources.Add(rds);
            
            //Parametros

            // Create the parameterTitulo report parameter
            titulo = "RELATÓRIO DE MATERIAIS PENDENTES - " + cmbFPSO.Text;
            ReportParameter parameterTitulo = new ReportParameter();
            parameterTitulo.Name = "pTitulo";
            parameterTitulo.Values.Add(titulo);

            // Create the parameterTitulo report parameter
            ReportParameter parameterSubTitulo = new ReportParameter();
            parameterSubTitulo.Name = "pSubTitulo";
            parameterSubTitulo.Values.Add(lblMessage.Text);

            string emissao = "Emissão em: " + System.DateTime.Now;
            // Create the parameterEmissao report parameter
            ReportParameter parameterEmissao = new ReportParameter();
            parameterEmissao.Name = "pEmissao";
            parameterEmissao.Values.Add(emissao);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterSubTitulo, parameterEmissao });

            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.Visible = true;
            this.btnExcel.Visible = true;
        }
        //===================================================================================
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string deviceInfo = null;
            byte[] bytes = reportViewer1.LocalReport.Render("Excel", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            string path = systemRepository + @"Reports\Planilha de Base - MATERIAIS PENDENTES - " + cmbFPSO.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblMessage.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string initMsg = "Nenhum material adicionado";
            if (cmbFPSO.SelectedIndex > 0)
            {
                int NR = 0;
                //EnableControls(false);
                // show animated image

                DataTable dtMateriaisPendentes = null;
                dtInicial = System.DateTime.Now.ToString("dd/MM/yyyy");
                dtFinal = dtInicial;
                sbcnSigla = cmbFPSO.Text;

                lblMessage.Text = "Obtendo a lista de Materiais Pendentes...";
                Application.DoEvents();

                //Define o sub-conjunto de Materiais Pendentes
                dtMateriaisPendentes = BLL.AcMateriaisPendentesBLL.Get("MAPD_SBCN_SIGLA = '" + cmbFPSO.Text + "'");
                NR = dtMateriaisPendentes.Rows.Count;
                if (NR > 0)
                {
                    lblMessage.Text = "";
                    Application.DoEvents();
                    SetFilterOrder(sbcnSigla);
                    ShowReport(filter, order);
                }
            }
        }
        //===================================================================================
    }
}

