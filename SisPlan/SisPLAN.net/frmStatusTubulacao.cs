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
    public partial class frmStatusTubulacao : Form
    {
        DataTable dtDOC = null;
        //DataTable dt = null;
        string initMsg = "Spools identificados";
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
        public frmStatusTubulacao()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmSisplanMonitor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
            discId = "5";
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToUpper();//Domínio + Login

            strSQL = @"SELECT NULL AS DISPLAY, NULL AS FCME_ID FROM DUAL UNION SELECT FCME_SIGLA AS DISPLAY, FCME_ID 
                                    FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO 
                                WHERE FCME_CNTR_CODIGO = '" + contrato + @"' 
                                    AND FCME_DISC_ID = '" + discId + @"' AND (FCME_SIGLA = 'TUB_FAB' OR FCME_SIGLA = 'TUB_MONT') ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cmbCriterio.DataSource = dtDOC;
            cmbCriterio.DisplayMember = "DISPLAY";
            cmbCriterio.ValueMember = "FCME_ID";
            cmbCriterio.SelectedIndex = -1;
            cmbCriterio.Enabled = true;

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnExcel, "Exporta relatório para Excel");
        }
        //===================================================================================
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbCriterio.SelectedIndex > 0)
            {
                //int NR = 0;
                //EnableControls(false);
                // show animated image
                
                //DataTable dtFolhasServico = null;
                dtInicial = System.DateTime.Now.ToString("dd/MM/yyyy");
                dtFinal = dtInicial;
                sbcnSigla = cmbFPSO.Text;
                fcmeSigla = cmbCriterio.Text;
                dataCorteUpdateControl = GenericClasses.FolhaServico.GetDataCorteUpdateControl(contrato, discId, sbcnSigla, fcmeSigla);
                lblMessage.Text = "Localizando as Folhas de Serviço avançadas após a data de corte...";
                Application.DoEvents();
                
                ////Define o sub-conjunto de Folhas para o Contrato, Disciplina, Subcontrato, Critério acima da data de corte
                //strSQL = GenericClasses.FolhaServico.GetQuerySelecaoFOSECriterioFPSO(contrato, discId, sbcnSigla, fcmeSigla, dataCorteUpdateControl);
                ////Obtém as FOSEs atualizadas acima da data de corte
                //dtFolhasServico = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                //NR = dtFolhasServico.Rows.Count;
                //if (NR > 0)
                //{
                //    //Atualiza o status das FOSES acima da data de corte
                //    lblMessage.Text = "Atualizando o Status das Folhas de Serviço complementares...";
                //    Application.DoEvents();
                //    GenericClasses.FolhaServico.GerarStatusFOSE(contrato, dtFolhasServico, discId, false);

                //    DTO.AcStatusFoseUpdtCntrlDTO s = new DTO.AcStatusFoseUpdtCntrlDTO();
                //    s.SfucCntrCodigo = contrato;
                //    s.SfucDiscId = Convert.ToDecimal(discId);
                //    s.SfucSbcnSigla = sbcnSigla;
                //    s.SfucFcmeSigla = fcmeSigla;
                //    s.SfucDataCorteUpdateControl = dataCorteUpdateControl;                    
                //    GenericClasses.FolhaServico.SaveDataCorteUpdateControl(s);
                //}
                ////Salva a data de corte atual
                //dataCorteUpdateControl = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                //if(NR > 0) initMsg = NR.ToString() + " spool(s) adicionado(s)";
                lblMessage.Text = initMsg + " até " + dataCorteUpdateControl;
                Application.DoEvents();
                SetFilterOrder(sbcnSigla, fcmeSigla);
                ShowReport(filter, order);
            }
        }
        //===================================================================================
        private void SetFilterOrder(string fpso, string fcmeSigla)
        {
            order = "TSTF_SEQUENCE";
            //X.TSTF_ID, X.TSTF_DISC_ID, X.TSTF_SBCN_SIGLA, X.TSTF_FCME_SIGLA, X.TSTF_SEQUENCE, X.TSTF_ACTIVE, X.TSTF_UNIDADE_REGIONAL
            filter = "TSTF_ACTIVE = 1 AND X.TSTF_SBCN_SIGLA = '" + cmbFPSO.Text + "' AND X.TSTF_DISC_ID = 5 " + " AND X.TSTF_FCME_SIGLA = '" + cmbCriterio.Text + "'";
        }
        //===================================================================================
        private void ShowReport(string filter, string order)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7
            reportViewer1.Reset();
            DTO.CollectionAcStatusTubDTO col = new DTO.CollectionAcStatusTubDTO();
            col = BLL.AcStatusTubBLL.GetCollection(filter, order);
            //DataTable dtBaseDados = BLL.AcPendenciaMaterialBLL.Get(filter, "TSTF_SEQUENCE");
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcStatusTub.rdlc";

            ReportDataSource rds = new ReportDataSource("dsStatusTub", col);
            
            report.DataSources.Add(rds);
            CollectionAcStatusTubDTOBindingSource.DataSource = col;

            
            reportViewer1.LocalReport.DataSources.Add(rds);
            
            //Parametros

            string spoolsAvancados = "";
            string spoolsAAvancar = "";
            string spoolsOficina = "";

            switch (cmbCriterio.Text)
            {
                case "TUB_FAB":
                    {
                        titulo = "STATUS DE FABRICAÇÃO DE TUBULAÇÃO - " + cmbFPSO.Text;
                        spoolsAvancados = "Spools Fabricados (F)";
                        spoolsAAvancar = "Saldo à Fabricar (E-F)";
                        spoolsOficina = "Spools Oficina para\r\nFabricar (P-F)";
                        break;
                    }
                case "TUB_MONT":
                    {
                        titulo = "STATUS DE MONTAGEM DE TUBULAÇÃO - " + cmbFPSO.Text;
                        spoolsAvancados = "Spools Montados (M)";
                        spoolsAAvancar = "Saldo à Montar (P-M)";
                        spoolsOficina = "Spools Oficina para\r\nMontar (P-M)";
                        break;
                    }
            }

            // Create the parameterTitulo report parameter
            ReportParameter parameterTitulo = new ReportParameter();
            parameterTitulo.Name = "pTitulo";
            parameterTitulo.Values.Add(titulo);

            // Create the parameterSubTitulo report parameter
            
            lblMessage.Text = initMsg + " até " + dataCorteUpdateControl;
            Application.DoEvents();

            ReportParameter parameterSubTitulo = new ReportParameter();
            parameterSubTitulo.Name = "pSubTitulo";
            parameterSubTitulo.Values.Add(lblMessage.Text);

            string emissao = "Emissão em: " + System.DateTime.Now;
            // Create the parameterEmissao report parameter
            ReportParameter parameterEmissao = new ReportParameter();
            parameterEmissao.Name = "pEmissao";
            parameterEmissao.Values.Add(emissao);

            // Create the parameterSpoolsAvancados report parameter
            ReportParameter parameterSpoolsAvancados = new ReportParameter();
            parameterSpoolsAvancados.Name = "pSpoolsAvancados";
            parameterSpoolsAvancados.Values.Add(spoolsAvancados);

            // Create the parameterSpoolsAAvancar report parameter
            ReportParameter parameterSpoolsAAvancar = new ReportParameter();
            parameterSpoolsAAvancar.Name = "pSpoolsAAvancar";
            parameterSpoolsAAvancar.Values.Add(spoolsAAvancar);

            // Create the parameterSpoolsOficina report parameter
            ReportParameter parameterSpoolsOficina = new ReportParameter();
            parameterSpoolsOficina.Name = "pSpoolsOficina";
            parameterSpoolsOficina.Values.Add(spoolsOficina);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterSubTitulo, parameterEmissao, parameterSpoolsAvancados, parameterSpoolsAAvancar, parameterSpoolsOficina });

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
            
            string path = systemRepository + @"Reports\" + titulo + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

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