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
    public partial class frmListaMovimentoPastas : Form
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
        static string usuario = "";
        static int totPastas = 0;
        DataTable dtArea = null;
        //===================================================================================
        public frmListaMovimentoPastas()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmListaMovimentoPastas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();
            
            //cmbDestinatario
            strSQL = @"SELECT NULL AS MOVI_USUA_LOGIN FROM DUAL UNION SELECT MOVI_USUA_LOGIN FROM EEP_CONVERSION.VW_CP_MOVIMENTO ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.CpPastaBLL.Select(strSQL);
            cmbDestinatario.DataSource = dtDOC;
            cmbDestinatario.DisplayMember = "MOVI_USUA_LOGIN";
            cmbDestinatario.ValueMember = "MOVI_USUA_LOGIN";
            cmbDestinatario.SelectedItem = 0;

            //cmbFPSO
            strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                     @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 2 AS SBCN_ID, 'P75' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 4 AS SBCN_ID, 'P77' AS SBCN_SIGLA from DUAL " +
                     @"ORDER  BY 1 NULLS FIRST";

            dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
            cmbFPSO.DataSource = dtDOC;
            cmbFPSO.DisplayMember = "SBCN_SIGLA";
            cmbFPSO.ValueMember = "SBCN_ID";

            //Feed cmbArea
            strSQL = @"SELECT NULL AS AREA_ID, NULL AS AREA_DESCRICAO FROM DUAL UNION SELECT AREA_ID, AREA_DESCRICAO FROM EEP_CONVERSION.CP_AREA ORDER BY 2 NULLS FIRST";
            dtArea = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
            cmbArea.DataSource = dtArea;
            cmbArea.DisplayMember = "AREA_DESCRICAO";
            cmbArea.ValueMember = "AREA_ID";

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private string GetFilter()
        {
            //string sRet = @"MOVI_IN_GRD = 0";
            string sRet = "1 = 1";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND PASTA_SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            if (txtPastas.Text != "") { sRet += @" AND PASTA_CODIGO IN (" + "'" + txtPastas.Text.Replace("\r\n", "','").Replace(",''","") + "'" + ")"; }
            if (cmbDestinatario.SelectedIndex != 0) sRet += @" AND MOVI_USUA_LOGIN = '" + cmbDestinatario.SelectedValue + "'";

            if (cmbArea.SelectedIndex != 0) sRet += @" AND AREA_ID = " + cmbArea.SelectedValue.ToString();
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND DISC_SIGLA = '" + cmbDisciplina.Text + "'";
            if (txtPesquisar.Text != "") { sRet += @" AND UPPER(PASTA_CODIGO) LIKE '%" + txtPesquisar.Text.Replace("\r\n", "','").Replace(",''", "").ToUpper() + "%'"; }
            if (txtExecutor.Text != "") { sRet += @" AND UPPER(PASTA_EXECUTOR) LIKE '%" + txtExecutor.Text.Replace("\r\n", "','").Replace(",''", "").ToUpper() + "%'"; }
            if (chkNaoAtendidos.Checked) { sRet += @" AND PUNCH_STPU_ID = 0"; }
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter, string user)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            //report.ReportPath = @"D:\Aplicações\Planning\SisPLAN.net\rdlcListaMovimentoPastas.rdlc";
            report.ReportPath = systemRepository + @"RDLC\rdlcListaMovimentoPastas.rdlc";
            DTO.CollectionVwCpPastaUltMovDTO ca = new DTO.CollectionVwCpPastaUltMovDTO();
            ca = BLL.VwCpPastaUltMovBLL.GetCollection(filter, "MOVI_DATE");
            string p2 = "<b><font color=" + asp + "#e30613" + asp + ">";
            string p1 = "<b><font color=" + asp + "Green" + asp + ">";
            string s = "</b>";

            /*
             bgcolor="#E6E6FA"
             */
            DateTime today = System.DateTime.Today;
            for (int i = 0; i < ca.Count; i++)
            {
                string dtBase = ca[i].MoviDateDesc.Substring(0, 16);
                DateTime? dataFutura = null;
                dataFutura = ca[i].MoviDate.AddDays(0);
                if (dataFutura > today)
                {
                    ca[i].MoviDateDesc = p1 + dtBase + s;
                }
                dataFutura = ca[i].MoviDate.AddDays(3);
                if (dataFutura <= today)
                {
                    ca[i].MoviDateDesc = p2 + dtBase + s;
                }
                if (ca[i].MoviDateDesc.Length == 19) ca[i].MoviDateDesc = p1 + dtBase + s;
            }
            totPastas = ca.Count;
//            strSQL = @"SELECT Q.MOVI_ID, Q.PASTA_CODIGO AS PastaCodigo, Q.MOVI_USUA_LOGIN 
//, (SELECT MOV.MOVI_DATE FROM EEP_CONVERSION.CP_MOVIMENTO MOV WHERE MOV.MOVI_ID = Q.MOVI_ID) AS MoviDate
//, (SELECT MOV.STMO_DESCRICAO FROM EEP_CONVERSION.CP_MOVIMENTO MOV, EEP_CONVERSION.CP_STATUS_MOVIMENTO MOV WHERE STMO_ID = MOVI_STMO_ID AND MOVI_ID = Q.MOVI_ID) AS StmoDescricao
//FROM (
// SELECT M.MOVI_ID,M.MOVI_USUA_LOGIN, V.PASTA_CODIGO
//   FROM (
//            SELECT PASTA_SBCN_SIGLA, MOVI_PASTA_ID, PASTA_CODIGO, MAX(MOVI_ID) AS MOVI_ID
//            FROM EEP_CONVERSION.VW_CP_MOVIMENTO V
//            GROUP BY PASTA_SBCN_SIGLA, MOVI_PASTA_ID, PASTA_CODIGO
//        ) V, 
//        EEP_CONVERSION.CP_MOVIMENTO M
//  WHERE 
//  V.MOVI_ID = M.MOVI_ID AND 
//  M.MOVI_USUA_LOGIN = '" + user + @"' 
//                                ORDER BY MOVI_USUA_LOGIN, MOVI_DATE desc, PASTA_CODIGO) Q";
//            DataTable dtPastasAUX = BLL.CpPastaBLL.Select(strSQL);
            
            ReportDataSource rds = new ReportDataSource("dsVwCpPastaUltMov", ca);
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
            // change button states
            //this.btnExecute.Enabled = false;


            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();
            //if (cmbCriterio.SelectedIndex > 0) dtCriterioEstrutura = GetCriterioEstrutura(Convert.ToDecimal(cmbCriterio.SelectedValue));


            reportViewer1.Reset();
            this.reportViewer1.Visible = false;
            lblProgress.Visible = true;
            Application.DoEvents();

            if (cmbDestinatario.SelectedIndex > 0) usuario = cmbDestinatario.SelectedValue.ToString();
            
            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }
        //===================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));

            ShowReport(filter, usuario);
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
                    titulo = "Lista Movimento das Pastas de Comissionamento";
                    //if (cmbFPSO.Text != "") titulo += " - " + cmbFPSO.Text;

                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    string subTitulo = "";
                    if (cmbDestinatario.SelectedIndex > 0) subTitulo = "Usuário: " + cmbDestinatario.Text + " (" + totPastas.ToString() + " pastas)";
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

            //string path = @"F:\CONVERSÃO\PLANEJAMENTO\23-Comissionamento\3 - Controle\1 - Acompanhamento de pastas\Atual\Panilhas de Base\" + titulo + " - " + cmbDestinatario.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";
            string path = systemRepository + @"Reports\" + titulo + " - " + cmbDestinatario.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblProgress.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
        private void cmbDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDestinatario.SelectedIndex != 0)
            {
                //lblFPSO.Visible = true;
                //cmbFPSO.Visible = true;
                btnExecute.Visible = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoMat_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDestinatario_Click(object sender, EventArgs e)
        {

        }
        //===================================================================================

        #endregion
    }
}