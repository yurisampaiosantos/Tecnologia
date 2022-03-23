
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
    public partial class frmControleFolhaServico : Form
    {
        DataTable dtDOC = null;
        DataTable dtBaseDados = null;
        //DataTable dtDisciplina = null;

        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        string filter = "";
        string strSQL = "";
        string disciplinas = "2,3,5,6,9,15,20";
        string fileName, fileFullName = "";
        //===================================================================================
        public frmControleFolhaServico()
        {
            InitializeComponent();
            fileName = System.DateTime.Now.ToString("yyyy_MM_dd HH.mm.ss") + " Acompanhamento_FOSE.xls";
            fileFullName = systemRepository + @"Reports\" + fileName;
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
        }
        //===================================================================================
        private void frmControleFolhaServico_Load(object sender, EventArgs e)
        {
            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            lblUltimoCalculo.Text = "";

            strSQL = @"SELECT NULL AS DISC_ID, '' AS DISC_NOME FROM DUAL UNION SELECT DISTINCT DISC_ID, DISC_NOME FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = 'Conversão' AND DISC_ID IN (" + disciplinas + ") ORDER BY 2 NULLS FIRST";
            dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cmbDisciplina.DataSource = dtDOC;
            cmbDisciplina.DisplayMember = "DISC_NOME";
            cmbDisciplina.ValueMember = "DISC_ID";

            strSQL = @"SELECT '' AS FOSE_STATUS FROM DUAL UNION SELECT DISTINCT FOSE_STATUS FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE FOSE_CNTR_CODIGO = 'Conversão' AND DISC_ID IN (" + disciplinas + ") ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cmbStatus.DataSource = dtDOC;
            cmbStatus.DisplayMember = "FOSE_STATUS";
            cmbStatus.ValueMember = "FOSE_STATUS";

            strSQL = @"SELECT '' AS TSTF_UNIDADE_REGIONAL FROM DUAL UNION SELECT DISTINCT TSTF_UNIDADE_REGIONAL FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE FOSE_CNTR_CODIGO = 'Conversão' AND DISC_ID IN (" + disciplinas + ") ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cmbUnidadeRegional.DataSource = dtDOC;
            cmbUnidadeRegional.DisplayMember = "TSTF_UNIDADE_REGIONAL";
            cmbUnidadeRegional.ValueMember = "TSTF_UNIDADE_REGIONAL";
            cmbUnidadeRegional.SelectedIndex = -1;

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnExcel, "Exporta relatório para Excel");
            toolTip1.SetToolTip(btnExecute, "Executa o relatório");
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            filter = GetFilter();
            ShowReport(filter);
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = @"UPPER(X.FOSE_NUMERO) NOT LIKE '%SPOOL MONT%'";
            if (cmbFPSO.SelectedItem != null) sRet += @" AND X.SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            if (cmbDisciplina.SelectedIndex > 0 ) sRet += @" AND X.DISC_ID = '" + cmbDisciplina.SelectedValue + "'";
            if (cmbCriterio.SelectedIndex > 0) sRet += @" AND X.FCME_SIGLA = '" + cmbCriterio.Text + "'";
            if (cmbUnidadeRegional.SelectedIndex > 0) sRet += @" AND X.TSTF_UNIDADE_REGIONAL = '" + cmbUnidadeRegional.SelectedValue + "'";
            if (cmbEquipe.SelectedIndex > 0) sRet += @" AND X.EQUIPE = '" + cmbEquipe.SelectedIndex + "'";
            if (cmbStatus.SelectedIndex > 0) sRet += @" AND X.FOSE_STATUS = '" + cmbStatus.SelectedValue + "'";
            if (txtFolhaServico.Text.Trim() != "") sRet += @" AND UPPER(X.FOSE_NUMERO) = UPPER('" + txtFolhaServico.Text.Trim() + "')";

            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            Application.DoEvents();
            reportViewer1.Reset();
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            dtBaseDados = BLL.AcControleFolhaServicoBLL.Get(filter, "X.SBCN_SIGLA, X.TSTF_UNIDADE_REGIONAL, X.EQUIPE, X.DISC_NOME, X.SETOR, X.LOCALIZACAO");
            DTO.CollectionAcControleFolhaServicoDTO col = new DTO.CollectionAcControleFolhaServicoDTO();
            
            col = BLL.AcControleFolhaServicoBLL.GetCollection(dtBaseDados);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcControleFolhaServico.rdlc";

            ReportDataSource rds = new ReportDataSource(@"dsControleFolhaServico", col);
            report.DataSources.Add(rds);
            DTOBindingSource.DataSource = col;

            reportViewer1.LocalReport.DataSources.Add(rds);

            string subTitulo = " ";  //Período do Relatório
            // Create the parameterSubTitulo report parameter
            if (cmbCriterio.Text == "TUB_MONT" || cmbCriterio.Text == "") subTitulo = "As folhas de serviço de TUB_MONT - Spool Mont não são exibidas";
            ReportParameter parameterSubTitulo = new ReportParameter();
            parameterSubTitulo.Name = "pSubTitulo";
            parameterSubTitulo.Values.Add(subTitulo);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterSubTitulo });

            this.reportViewer1.RefreshReport();
            this.reportViewer1.Visible = true;
            this.btnExcel.Visible = true;
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex != 0)
            {
                DataTable dt = BLL.AcControleFolhaServicoBLL.Select(@"SELECT 'Último cálculo de ' || DISC_NOME || ' em: ' || TO_CHAR(MAX(LAST_UPDATE), 'DD/MM/YYYY - HH24:MI') || 'h' AS MSG FROM  EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE DISC_ID = " + cmbDisciplina.SelectedValue + @" GROUP BY DISC_NOME");
                lblUltimoCalculo.Text = dt.Rows[0][0].ToString();

                cmbCriterio.SelectedIndex = -1;
                cmbCriterio.Enabled = true;
                strSQL = @"SELECT NULL AS FCME_ID, '' AS FCME_SIGLA FROM DUAL UNION 
                           SELECT FCME_ID, FCME_SIGLA
                             FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.DISCIPLINA
                            WHERE FCME_CNTR_CODIGO = 'Conversão' AND FCME_DISC_ID = " + cmbDisciplina.SelectedValue+ @"
                              AND FCME_CNTR_CODIGO = DISC_CNTR_CODIGO AND FCME_DISC_ID = DISC_ID
                            ORDER BY FCME_SIGLA NULLS FIRST
                ";
                dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                cmbCriterio.DataSource = dtDOC;
                cmbCriterio.DisplayMember = "FCME_SIGLA";
                cmbCriterio.ValueMember = "FCME_SIGLA";
            }
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

            string path = systemRepository + @"Reports\Acompanhamento de Folhas de Serviço (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
    }
}