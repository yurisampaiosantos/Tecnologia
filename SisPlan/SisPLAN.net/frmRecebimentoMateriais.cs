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
    public partial class frmRecebimentoMateriais : Form
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
        DTO.CollectionVwAcRecebimentoMateriaisDTO col1 = new DTO.CollectionVwAcRecebimentoMateriaisDTO();
        //===================================================================================
        public frmRecebimentoMateriais()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmRecebimentoMateriais_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();

            //SELECT DISTINCT AUFO_EMPR_NOME FROM V_AF_ITEM; - substituir a expressão abaixo
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

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            this.btnExecute.Enabled = false;

            dtInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            dtFim = dtpFim.Value.ToString("dd/MM/yyyy");
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
                //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
                filter = GetFilter();

                this.reportViewer1.Visible = false;
                lblProgress.Visible = true;
                Application.DoEvents();

                // start background operation
                this.backgroundWorker.RunWorkerAsync();
            }
        }
        //====================================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));
            ShowReport(filter);
        }
        //====================================================================================================
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                this.lblProgress.Text = (String)e.UserState;
            }
        }
        //====================================================================================================
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
        private string GetFilter()
        {
            string sRet = "";
            sRet = @"DATA_REC BETWEEN TO_DATE('" + dtInicio + "', 'DD/MM/YY') AND TO_DATE('" + dtFim + "', 'DD/MM/YY')";
            if (cmbFornecedor.SelectedIndex > 0) sRet += @" AND FORNECEDOR = '" + cmbFornecedor.SelectedValue + "'";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND DISCIPLINA = '" + cmbDisciplina.SelectedValue + "'";

            if (txtNF.Text != "")
            {
                sRet += @" AND NF LIKE '%" + txtNF.Text + "%'";
            }
            if (txtAF.Text != "")
            {
                sRet += @" AND AF LIKE '%" + txtAF.Text + "%'";
            }
            if (txtCodigoMat.Text != "")
            {
                //sRet += @" AND CODIGO_MAT LIKE '%" + txtCodigoMat.Text + "%'";
                sRet += @" AND CODIGO_MAT IN (" + "'" + txtCodigoMat.Text.Replace("\r\n", "','") + "'" + ")";
            }
            if (chkRDR.Checked) sRet += @" AND QTD_RDR > 0 AND DADOS_RDR IS NOT NULL";

            if (chk1Equipamentos.Checked || chk2Materiais.Checked || chk3Diversos.Checked)
            {
                sRet += " AND (";
            }
            if (chk1Equipamentos.Checked)
            {
                sRet += @" REPR_TIPO_DICIONARIO = 1";
            }
            if (chk2Materiais.Checked)
            {
                sRet += @" OR REPR_TIPO_DICIONARIO = 2";
            }
            if (chk3Diversos.Checked)
            {
                sRet += @" OR REPR_TIPO_DICIONARIO = 3";
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
            DataTable dtCorrida = null;
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            string strSqlCorrida = "";
            col1 = BLL.VwAcRecebimentoMateriaisBLL.GetCollection(filter);

            if (chkExibirCorridas.Checked)
            {
                //TRATA GLOBALIZAÇÃO NO ORACLE PARA PORTUGUÊS DO BRASIL
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

                for (int i = 0; i < col1.Count; i++)
                {//LISTAGG(REPLACE(SUBSTR(CORRIDA,1,4),'-',''),'|')
                    strSqlCorrida = @"  SELECT 
                                              SUM(RDII_QTD) AS QTD_APLICADA, 
                                              LISTAGG(REPLACE(SUBSTR(CORRIDA,1,4),'-',''),'|') WITHIN GROUP (ORDER BY CORRIDA) AS CORRIDAS
                                        FROM (
                                              SELECT  DISTINCT (REDI_NUMERO ||'-'|| REDI_DT_REFERENCIA) AS CORRIDA, RDII_QTD
                                              FROM    EPCCQ.FOLHA_SERVICO, EPCCQ.V_FOLHA_SERVICO_ITEM, EPCCQ.RESERVA_DIVERSA_ITEM, EPCCQ.RESERVA_DIVERSA
                                              WHERE
                                                      FOSE_CNTR_CODIGO = '" + contrato + @"' AND
                                                      CODIGO = '" + col1[i].CodigoMat + @"' AND 
                                                      FSIT_CNTR_CODIGO = FOSE_CNTR_CODIGO AND FSIT_FOSE_ID = FOSE_ID AND
                                                      FSIT_CNTR_CODIGO = RDII_CNTR_CODIGO AND FSIT_ID = RDII_FSIT_ID AND
                                                      REDI_CNTR_CODIGO = RDII_CNTR_CODIGO AND REDI_ID = RDII_REDI_ID
                                             )
                                     ";
                    dtCorrida = BLL.VwAcRecebimentoMateriaisBLL.Select(strSqlCorrida);

                    col1[i].Corridas = dtCorrida.Rows[0]["CORRIDAS"].ToString();
                    if (dtCorrida.Rows[0]["QTD_APLICADA"] != null && dtCorrida.Rows[0]["QTD_APLICADA"] != DBNull.Value) col1[i].QtdAplicada = Convert.ToDecimal(dtCorrida.Rows[0]["QTD_APLICADA"]);
                }

                //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
                BLL.VwAcAtributoPersonalizadoBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\RecebimentoMateriais.rdlc";

            ReportDataSource rds = new ReportDataSource("ds", col1);
            report.DataSources.Add(rds);
            CollectionVwAcRecebimentoMateriaisDTOBindingSource.DataSource = col1;

            reportViewer1.LocalReport.DataSources.Add(rds);

            string periodo = "De " + dtInicio + " até " + dtFim;
            // Create the parameterPeriodo report parameter
            ReportParameter parameterPeriodo = new ReportParameter();
            parameterPeriodo.Name = "pPeriodo";
            parameterPeriodo.Values.Add(periodo);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterPeriodo });
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

            string path = systemRepository + @"Reports\Relatório de Recebimento de Materiais (" + System.DateTime.Now.ToString("dd_MM_yyyy hh.mm.ss") + ").xls";

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