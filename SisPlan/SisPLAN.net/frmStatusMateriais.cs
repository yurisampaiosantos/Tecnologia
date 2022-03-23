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
    public partial class frmStatusMateriais : Form
    {
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        DataTable dtFornecedor = null;
        DataTable dtDisciplina = null;
        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        string filter = "";

        string strSQL = "";
        string dtInicio, dtFim = "";
        static DTO.CollectionAcStatusMateriaisDTO col1 = new DTO.CollectionAcStatusMateriaisDTO();
        static string subtitulo = "";
        static string fn = "n4";
        static string f2 = "n2";
        static string lf = Convert.ToChar(10).ToString();
        //===================================================================================
        public frmStatusMateriais()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmStatusMateriais_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
            Application.DoEvents();

            strSQL = @"SELECT '' AS FORNECEDOR FROM DUAL UNION SELECT DISTINCT EMPR_NOME AS FORNECEDOR FROM EEP_CONVERSION.EMPRESA ORDER BY 1 NULLS FIRST";
            dtFornecedor = BLL.AcSemanaBLL.Select(strSQL);
            cmbFornecedor.DataSource = dtFornecedor;
            cmbFornecedor.DisplayMember = "FORNECEDOR";
            cmbFornecedor.ValueMember = "FORNECEDOR";

            strSQL = @"SELECT '' AS DISCIPLINA FROM DUAL UNION SELECT DISTINCT DISC_NOME AS DISCIPLINA FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = '" + contrato + "' AND DISC_ID IN (2,4,5,6,9,15,20) ORDER BY 1 NULLS FIRST";
            dtDisciplina = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            cmbDisciplina.DataSource = dtDisciplina;
            cmbDisciplina.DisplayMember = "DISCIPLINA";
            cmbDisciplina.ValueMember = "DISCIPLINA";

            
        }
        //===================================================================================
        private string GetSubTitulo()
        {
            string p1 = "";
            string p2 = "";
            string subtitulo = "";
            if (cmbFPSO.SelectedIndex != 0) p1 = cmbFPSO.Text;
            if (cmbDisciplina.SelectedIndex != 0) p2 = cmbDisciplina.Text;
            if (p1 != "") subtitulo = p1;
            if (p1 != "" && p2 != "") subtitulo += " - " + p2;
            else subtitulo += p2;
            return subtitulo;
        }
        
        //===================================================================================
        private string GetFilter()
        {
            string sRet = "";
            sRet = @"1 = 1";
            if (cmbFornecedor.SelectedIndex > 0) sRet += @" AND X.AUFO_EMPR_NOME = '" + cmbFornecedor.SelectedValue + "'";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND X.SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND X.DISC_NOME = '" + cmbDisciplina.SelectedValue + "'";

            if (txtNF.Text != "")
            {
                sRet += @" AND X.NOFI_NUMERO LIKE '%" + txtNF.Text + "%'";
            }
            if (txtAF.Text != "")
            {
                sRet += @" AND X.AUFO_NUMERO LIKE '%" + txtAF.Text + "%'";
            }
            if (txtCodigoMat.Text != "")
            {
                sRet += @" AND X.DIPR_CODIGO IN (" + "'" + txtCodigoMat.Text.Replace("\r\n", "','") + "'" + ")";
            }
            //if (chkRDR.Checked) sRet += @" QTD_RDR > 0 AND DADOS_RDR IS NOT NULL";

            if (chk1Equipamentos.Checked || chk2Materiais.Checked || chk3Diversos.Checked)
            {
                sRet += " AND (";
            }
            if (chk1Equipamentos.Checked)
            {
                sRet += @" X.DESC_TIPO_DICIONARIO = 'EQUIPAMENTOS'";
            }
            if (chk2Materiais.Checked)
            {
                sRet += @" OR X.DESC_TIPO_DICIONARIO = 'MATERIAIS'";
            }
            if (chk3Diversos.Checked)
            {
                sRet += @" OR X.DESC_TIPO_DICIONARIO = 'DIVERSOS'";
            }
            if (chk1Equipamentos.Checked || chk2Materiais.Checked || chk3Diversos.Checked)
            {
                sRet += ")";
            }
            sRet = sRet.Replace("AND ( OR ", "AND (");
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcStatusMateriais.rdlc";

            col1 = BLL.AcStatusMateriaisBLL.GetCollection(filter);
            ReportDataSource rds = new ReportDataSource("dsStatusMateriais", col1);
            report.DataSources.Add(rds);
            CollectionDTOBindingSource.DataSource = col1;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        #region Filtros

        
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            this.btnExecute.Enabled = false;

            txtNF.Text = txtNF.Text.Trim();
            txtAF.Text = txtAF.Text.Trim();
            txtCodigoMat.Text = txtCodigoMat.Text.Trim();
            string[] tempArray = txtCodigoMat.Lines;
            if (tempArray.Length > 1000)
            {
                MessageBox.Show("Número máximo de materiais excedido (1000).");
            }
            else
            {
                //this.reportViewer1.Reset();
                //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
                filter = GetFilter();
                subtitulo = GetSubTitulo();

                reportViewer1.Reset();
                this.reportViewer1.Visible = false;
                lblProgress.Visible = true;
                Application.DoEvents();

                // start background operation
                this.backgroundWorker.RunWorkerAsync();
            }
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

                    string titulo = "STATUS DE MATERIAIS POR RM / CÓDIGO";
                    // Create the parameterPeriodo report parameter
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterSubTitulo report parameter
                    string subTitulo = GetSubTitulo();
                    ReportParameter parameterSubTitulo = new ReportParameter();
                    parameterSubTitulo.Name = "pSubTitulo";
                    parameterSubTitulo.Values.Add(subTitulo);

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
            string path = systemRepository + @"Reports\Status de Materiais (RM - Código) "+ subtitulo + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

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