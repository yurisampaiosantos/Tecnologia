using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Microsoft.Reporting.WinForms;

namespace SisPLAN.net
{
    public partial class frmEstoqueMaterial : Form
    {
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();

        string filter = "";

        string strSQL = "";

        string titulo = "";
        static string fn = "n4";
        static string f2 = "n2";
        static string lf = Convert.ToChar(10).ToString();
        DTO.CollectionVwAcEstoqueMaterialDTO dataSourceReport = new DTO.CollectionVwAcEstoqueMaterialDTO();
        //===================================================================================
        public frmEstoqueMaterial()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmEstoqueMaterial_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = "1 = 1";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            if (txtMaterial.Text != "") sRet += @" AND DIPR_CODIGO = '" + txtMaterial.Text + "'";
            return sRet;
        }
        //===================================================================================
        private void ReportPrepare(string filter)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7
//            strSQL = @"SELECT DISTINCT
//                            SBCN_SIGLA, ARES_SIGLA, DIPR_CODIGO, DIPR_DIMENSOES, UNME_SIGLA, DIPI_DESCRICAO_RES, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD, NOEN_NUMERO, NOEI_QTD_NEM, NOEN_DT_EMISSAO, DVRE_NUMERO, DVRE_OBS
//                            FROM EEP_CONVERSION.V_NE_ITEM
//                            WHERE DIPR_CODIGO||DIPR_DIMENSOES IN (SELECT DISTINCT( MAPD_DIPR_CODIGO || MAPD_DIPR_DIMENSOES) AS MATERIAL FROM EEP_CONVERSION.AC_MATERIAIS_PENDENTES)
//                      ";

            dataSourceReport = BLL.VwAcEstoqueMaterialBLL.GetCollection(filter,"DIPR_CODIGO, DIPR_DIMENSOES");
        }

        #region Filtros
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            this.btnExecute.Enabled = false;

            filter = GetFilter();
            this.reportViewer1.Visible = false;

            this.reportViewer1.Visible = false;
            lblProgress.Visible = true;
            Application.DoEvents();

            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }
        //===================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));
            ReportPrepare(filter);
        }
        //===================================================================================
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                this.lblProgress.Text = (String)e.UserState;
            }
        }
        //===================================================================================
        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // hide animation
            this.pBox.Image = null;
            // show result indication
            if (e.Cancelled)
            {
                //this.labelProgress.Text = "Operação cancelada pelo usuário!";
                this.pBox.Image = Properties.Resources.WarningImage;
            }
            else
            {
                if (e.Error != null)
                {
                    //this.labelProgress.Text = "Falha na operação: " + e.Error.Message;
                    this.pBox.Image = Properties.Resources.ErrorImage;
                }
                else
                {

                    // Create the parameterTitulo report parameter
                    titulo = "Estoque de Materiais " + cmbFPSO.Text;
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterSubtitulo report parameter
                    string subTitulo = "Lista baseada na pendência de materiais da planilha de corrida mais recente";
                    ReportParameter parameterSubtitulo = new ReportParameter();
                    parameterSubtitulo.Name = "pSubTitulo";
                    parameterSubtitulo.Values.Add(subTitulo);

                    reportViewer1.Reset();
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    LocalReport report = reportViewer1.LocalReport;
                    report.ReportPath = systemRepository + @"RDLC\rdlcEstoqueMaterial.rdlc";

                    ReportDataSource rds = new ReportDataSource("dsEstoqueMaterial", dataSourceReport);
                    report.DataSources.Add(rds);

                    CollectionDTOBindingSource.DataSource = dataSourceReport;
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    // Set the report parameters for the report
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterSubtitulo });

                    this.ParentForm.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Maximized;
                    
                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.Visible = true;
                    this.btnExcel.Visible = true;
                }
            }
            // restore button states
            lblProgress.Visible = false;
            this.btnExecute.Enabled = true;
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

            string path = systemRepository + @"Reports\" + titulo + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblProgress.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================

        #endregion
    }
}