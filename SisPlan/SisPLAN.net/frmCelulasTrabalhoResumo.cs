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
    public partial class frmCelulasTrabalhoResumo : Form
    {
        int totRecords = 0;
        DataTable dtDOC = null;
        DataTable dtBaseDados = null;

        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";
        
        DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        string filter = "";
        string strSQL = "";
        string dtInicio = "";
        string dtFim = "";
        DataTable dtAdm = null;
        
        //===================================================================================
        public frmCelulasTrabalhoResumo()
        {
            InitializeComponent();
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
        }
        //===================================================================================
        private void frmCelulasTrabalhoResumo_Load(object sender, EventArgs e)
        {
            
            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1];//Domínio + Login
            dtAdm = BLL.ProjGenEmailBLL.Get("TIPO_DESTINATARIO = 'CCT' AND ATIVO = 1");
            for (int i = 0; i < dtAdm.Rows.Count; i++)
            {
                chkRecalcular.Visible = true;
                break;   
            }
            if (userName.ToLower() == "mara.paiva" || userName.ToLower() == "leanderson.faillace" || userName.ToLower() == "paulo.almeida") chkRecalcular.Visible = true;

            strSQL = @"SELECT SEMA_ID AS VALUE, SEMA_ID ||'  ( '|| SEMA_DATA_INICIO ||' - '|| SEMA_DATA_FIM ||' )' AS DISPLAY FROM 
                                (
                                    SELECT DISTINCT CP.SEMA_ID, SE.SEMA_DATA_INICIO, SE.SEMA_DATA_FIM 
                                      FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO CP, EEP_CONVERSION.AC_SEMANA SE
                                     WHERE CP.SEMA_ID = SE.SEMA_ID
                                     ORDER BY 1 DESC
                                ) 
                        WHERE ROWNUM <= 5";
            dtDOC = BLL.AcControleProducaoBLL.Select(strSQL);
            cmbSemana.DataSource = dtDOC;
            cmbSemana.DisplayMember = "DISPLAY";
            cmbSemana.ValueMember = "VALUE";

            strSQL = @"SELECT NULL AS DISC_ID, '' AS DISC_NOME FROM DUAL UNION SELECT DISTINCT DISC_ID, DISC_NOME FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = 'Conversão' AND DISC_ID IN (2,5,6,9,15,20) ORDER BY 2 NULLS FIRST";
            dtDOC = BLL.AcControleProducaoBLL.Select(strSQL);
            cmbDisciplina.DataSource = dtDOC;
            cmbDisciplina.DisplayMember = "DISC_NOME";
            cmbDisciplina.ValueMember = "DISC_ID";
            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void DesabilitaCombos()
        {
            cmbSetor.SelectedIndex = -1;
            cmbLocalizacao.SelectedIndex = -1;
            cmbSetor.Enabled = false;
            cmbLocalizacao.Enabled = false;
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            filter = GetFilter();
            pb.Visible = false;
            if (chkRecalcular.Checked)
            {
                totRecords = GenericClasses.PreparaSaidasRelatorios.CountRecordPendenciaMateriais(contrato);
                string tempo = " 1 hora ";
                //if (chkEmail.Checked) tempo = " 1:30h ";
                DialogResult result = MessageBox.Show("O Relatório será concluído em aproximadamente" + tempo + ".", "Aviso!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    s = BLL.AcSemanaBLL.GetObject("SEMA_ID = " + cmbSemana.SelectedValue);
                    dtInicio = s.SemaDataInicio.ToString("dd/MM/yy");
                    dtFim = s.SemaDataFim.ToString("dd/MM/yy");
                    pb.Visible = true;
                    GenericClasses.PreparaCelulasTrabalho.GerarControleProducaoBase(contrato, s.SemaId, dtInicio, dtFim, true, lblMessage, pb);
                }
            }
            ShowReport(filter);
            //if (chkEmail.Checked) GenericClasses.PreparaCelulasTrabalho.EmailCriticaProcessamento(Convert.ToDecimal(cmbSemana.SelectedValue));
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = @"X.SEMA_ID = '" + cmbSemana.SelectedValue + "'";
            if (cmbFPSO.SelectedItem != null) sRet += @" AND X.SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            if (cmbDisciplina.SelectedIndex > 0 ) sRet += @" AND X.DISC_ID = '" + cmbDisciplina.SelectedValue + "'";
            if (cmbEquipe.SelectedIndex > 0) sRet += @" AND X.EQUIPE = '" + cmbEquipe.SelectedIndex + "'";
            if (cmbSetor.SelectedIndex > 0) sRet += @" AND X.SETOR = '" + cmbSetor.SelectedValue + "'";
            if (cmbLocalizacao.SelectedIndex > 0) sRet += @" AND X.LOCALIZACAO = '" + cmbLocalizacao.SelectedValue + "'";

            return sRet;
            
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.Reset();
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            DTO.CollectionAcControleProducaoDTO col = new DTO.CollectionAcControleProducaoDTO();
            dtBaseDados = BLL.AcControleProducaoBLL.Get(filter, "X.SBCN_SIGLA, X.EQUIPE, X.DISC_NOME, X.SETOR, X.LOCALIZACAO");
            col = BLL.AcControleProducaoBLL.GetCollection(dtBaseDados);
            
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\CelulasTrabalhoResumo.rdlc";

            ReportDataSource rds = new ReportDataSource("dsControleProducao", col);
            report.DataSources.Add(rds);
            DTOBindingSource.DataSource = col;

            reportViewer1.LocalReport.DataSources.Add(rds);

            string subTitulo = " ";  //Período do Relatório
            // Create the parameterSubTitulo report parameter
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
        private void cmbEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DesabilitaCombos();
            if (cmbEquipe.SelectedIndex > 0)
            {
                cmbSetor.SelectedIndex = -1;
                cmbLocalizacao.SelectedIndex = -1;
                cmbSetor.Enabled = true;
                cmbLocalizacao.Enabled = true;
                strSQL = @"SELECT NULL AS SETOR FROM DUAL UNION SELECT DISTINCT SETOR FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE EQUIPE = " + cmbEquipe.SelectedItem + " ORDER BY 1 NULLS FIRST";
                dtDOC = BLL.AcControleProducaoBLL.Select(strSQL);
                cmbSetor.DataSource = dtDOC;
                cmbSetor.DisplayMember = "SETOR";
                cmbSetor.ValueMember = "SETOR";
            }
        }
        //===================================================================================
        private void cmbSetor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSetor.SelectedIndex > 0)
            {
                cmbLocalizacao.SelectedIndex = -1;
                cmbLocalizacao.Enabled = true;
                strSQL = @"SELECT NULL AS LOCALIZACAO FROM DUAL UNION SELECT DISTINCT LOCALIZACAO FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE EQUIPE = " + cmbEquipe.SelectedItem + " AND  SETOR = '" + cmbSetor.Text + "' ORDER BY 1 NULLS FIRST";
                dtDOC = BLL.AcControleProducaoBLL.Select(strSQL);
                cmbLocalizacao.DataSource = dtDOC;
                cmbLocalizacao.DisplayMember = "LOCALIZACAO";
                cmbLocalizacao.ValueMember = "LOCALIZACAO";
            }
        }

        private void cmbSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemana.SelectedIndex == 0)
            {
                DataTable dt = BLL.AcControleProducaoBLL.Select(@"SELECT 'Último cálculo da semana " + cmbSemana.Text.Split(' ')[0] + " em: ' || TO_CHAR(MAX(CREATED_DATE), 'DD/MM/YYYY - HH24:MI') || 'h' FROM  EEP_CONVERSION.AC_CONTROLE_PRODUCAO");
                lblUltimoCalculo.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                strSQL = @"SELECT 'Último cálculo da semana " + cmbSemana.Text.Split(' ')[0] + " em: ' || TO_CHAR(MAX(CREATED_DATE), 'DD/MM/YYYY - HH24:MI') || 'h' FROM  EEP_CONVERSION.AC_CONTROLE_PRODUCAO WHERE SEMA_ID = TO_NUMBER(" + cmbSemana.Text.Split(' ')[0] + ")";
                DataTable dt = BLL.AcControleProducaoBLL.Select(strSQL);
                lblUltimoCalculo.Text = dt.Rows[0][0].ToString();
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
            string path = systemRepository + @"Reports\Células de Trabalho - " + cmbFPSO.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblMessage.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
    }
}