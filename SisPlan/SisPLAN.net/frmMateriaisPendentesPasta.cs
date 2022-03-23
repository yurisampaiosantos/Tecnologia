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
    public partial class frmMateriaisPendentesPasta : Form
    {
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();

        string filter = "";

        string strSQL = "";
        string titulo = "";
        DataTable dtDOC = null;
        static string lf = Convert.ToChar(10).ToString();
        //===================================================================================
        public frmMateriaisPendentesPasta()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmMateriaisPendentesPasta_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();
            
            //cmbPasta
            strSQL = @"SELECT NULL AS PASTA_CODIGO FROM DUAL UNION SELECT PASTA_CODIGO FROM EEP_CONVERSION.VW_CP_PASTA ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.CpPastaBLL.Select(strSQL);
            cmbPasta.DataSource = dtDOC;
            cmbPasta.DisplayMember = "PASTA_CODIGO";
            cmbPasta.ValueMember = "PASTA_CODIGO";
            cmbPasta.SelectedItem = 0;


            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = @"1 = 1";
            sRet += @" AND X.PASTA_CODIGO = '" + cmbPasta.SelectedValue + "'";
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcMateriaisPendentesPasta.rdlc";

            DTO.CollectionVwCpMaterialPendenteDTO ca = new DTO.CollectionVwCpMaterialPendenteDTO();
            ca = BLL.VwCpMaterialPendenteBLL.GetCollection(filter, "X.MAPE_CREATED_DATE DESC");
            ReportDataSource rds = new ReportDataSource("dsMateriaisPendentesPasta", ca);
            report.DataSources.Add(rds);

            CollectionDTOBindingSource.DataSource = ca;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        #region Filtros
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;

            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();

            reportViewer1.Reset();
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
            ShowReport(filter);
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
                    //this.la.Text = "Operação concluída com sucesso!";
                    //this.pBox.Image = Properties.Resources.InformationImage;

                    // Create the parameterTitulo report parameter
                    titulo = "LISTA DE MATERIAIS PENDENTES";

                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    string subTitulo = "";
                    if (cmbPasta.SelectedIndex > 0) subTitulo = "Pasta: " + cmbPasta.Text;
                    ReportParameter parameterSubtitulo = new ReportParameter();
                    parameterSubtitulo.Name = "pSubTitulo";
                    parameterSubtitulo.Values.Add(subTitulo);

                    // Set the report parameters for the report
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterEmissao, parameterSubtitulo });

                    this.ParentForm.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Maximized;

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.Visible = true;
                    this.btnExcel.Visible = true;
                }
            }
            // restore button states
            lblProgress.Visible = false;
            //this.btnExecute.Enabled = true;
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

            string path = systemRepository + @"Reports" + titulo + " - " + cmbPasta.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblProgress.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
        private void cmbPasta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPasta.SelectedIndex != 0)
            {
                btnExecute.Visible = true;
            }
        }
        //===================================================================================

        #endregion
    }
}