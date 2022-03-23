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
    public partial class frmMontagemTubulacao : Form
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
        DTO.CollectionAcControleFolhaServicoDTO csp = new DTO.CollectionAcControleFolhaServicoDTO();
        DTO.CollectionAcMontagemTubulacaoDTO csr = new DTO.CollectionAcMontagemTubulacaoDTO();
        
        //===================================================================================
        public frmMontagemTubulacao()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmMontagemTubulacao_Load(object sender, EventArgs e)
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
            string sRet = "FOSE_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = 5"; ;
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            if (txtPrefixo.Text != "") sRet += @" AND MOTU_PREFIXO_FOSE LIKE '%" + txtPrefixo.Text + "%'";
            if (txtIsometrico.Text != "") sRet += @" AND MOTU_ISOMETRICO_FOSE LIKE '%" + txtIsometrico.Text + "%'";
            if (txtRegiao.Text != "") sRet += @" AND MOTU_ISOMETRICO_FOSE LIKE '%" + txtRegiao.Text + "%'";
            return sRet;
        }
        //===================================================================================
        private void ReportPrepare(string filter)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7
            csp = BLL.AcControleFolhaServicoBLL.GetCollection(filter, "SBCN_SIGLA, FOSE_NUMERO");
            for (int i = 0; i < csp.Count(); i++ )
            {
                try
                {
                    string caracter = "";
                    DTO.AcMontagemTubulacaoDTO mt = new DTO.AcMontagemTubulacaoDTO();
                    mt.MotuSbcnSigla = csp[i].SbcnSigla;
                    mt.MotuSpool = GenericClasses.FolhaServico.FosePrefixoIsometrico(csp[i].FoseNumero, 1); // Em 16"-C-B10H-6241-Spool2.M748C retorna ==> M748C
                    caracter = GenericClasses.FolhaServico.FosePrefixoIsometrico(csp[i].FoseNumero, 2).Substring(0,1);
                    mt.MotuIsometrico = GenericClasses.FolhaServico.FosePrefixoIsometrico(csp[i].FoseNumero, 2).Substring(1);
                    switch (caracter)
                    {
                        default:
                            break;
                    }
                }
                catch (Exception ex) { throw new Exception(ex.Message + " - Looping CollectionAcControleFolhaServico"); }
            }

            csr = BLL.AcMontagemTubulacaoBLL.GetCollection(filter,"MOTU_PREFIXO, MOTU_ISOMETRICO");
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
                    titulo = "Acompanhamento de Montagem de Tubulações " + cmbFPSO.Text;
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterSubtitulo report parameter
                    string subTitulo = "";
                    ReportParameter parameterSubtitulo = new ReportParameter();
                    parameterSubtitulo.Name = "pSubTitulo";
                    parameterSubtitulo.Values.Add(subTitulo);

                    reportViewer1.Reset();
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    LocalReport report = reportViewer1.LocalReport;
                    report.ReportPath = systemRepository + @"RDLC\rdlcMontagemTubulacao.rdlc";

                    ReportDataSource rds = new ReportDataSource("dsMontagemTubulacao", csr);
                    report.DataSources.Add(rds);

                    CollectionDTOBindingSource.DataSource = csr;
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