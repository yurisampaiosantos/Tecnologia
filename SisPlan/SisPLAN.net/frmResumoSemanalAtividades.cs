using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace SisPLAN.net
{
    public partial class frmResumoSemanalAtividades : Form
    {
        DataTable dtDOC = null;

        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        string filter = "";
        string strSQL = "";
        DataTable dt = null;
        //===================================================================================
        public frmResumoSemanalAtividades()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmResumoSemanalAtividades_Load(object sender, EventArgs e)
        {

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

            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
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
            string sRet = @"X.SEMA_ID = '" + cmbSemana.SelectedValue + "'";
            if (cmbFPSO.SelectedItem != null) sRet += @" AND X.SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.Reset();
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            strSQL = @"SELECT FOSE_CNTR_CODIGO, SBCN_SIGLA, SEMA_ID, FCME_SIGLA, SUMA_ATIV_SIG, FCES_PESO_REL_CRON, 
                                ROUND((AVN_REAL_EXEC_PERIODO * POND_CRITERIO /100),4) AS AVN_POND_EXEC_PERIODO, AVN_REAL_EXEC_PERIODO, 
                                ROUND((AVN_REAL_PROG_PERIODO * POND_CRITERIO /100),4) AS AVN_POND_PROG_PERIODO, AVN_REAL_PROG_PERIODO,
                                POND_CRITERIO
                                FROM (
                                SELECT P.FOSE_CNTR_CODIGO, P.SBCN_SIGLA, P.SEMA_ID, P.FCME_SIGLA, P.SUMA_ATIV_SIG, P.FCES_PESO_REL_CRON, 
                                P.AVN_POND_EXEC_PERIODO, P.AVN_REAL_EXEC_PERIODO,
                                P.AVN_POND_PROG_PERIODO, P.AVN_REAL_PROG_PERIODO
                                ,(
                                   SELECT CE.FCES_PESO_REL_CRON
                                     FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO ME, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA CE  
                                    WHERE ME.FCME_CNTR_CODIGO = 'Conversão' AND ME.FCME_SIGLA = P.FCME_SIGLA AND CE.FCES_NIVEL = 1
                                      AND CE.FCES_CNTR_CODIGO = ME.FCME_CNTR_CODIGO AND CE.FCES_FCME_ID = ME.FCME_ID
                                ) AS POND_CRITERIO
                                FROM (
                                SELECT AC.FOSE_CNTR_CODIGO, AC.SBCN_SIGLA, AC.SEMA_ID, AC.FCME_SIGLA, AC.SUMA_ATIV_SIG, AC.FCES_PESO_REL_CRON, 
                                ROUND(SUM(AC.AVN_POND_EXEC_PERIODO),4) AS AVN_POND_EXEC_PERIODO, ROUND(SUM(AC.AVN_REAL_EXEC_PERIODO),4) AS AVN_REAL_EXEC_PERIODO,
                                ROUND(SUM(AC.AVN_POND_PROG_PERIODO),4) AS AVN_POND_PROG_PERIODO, ROUND(SUM(AC.AVN_REAL_PROG_PERIODO),4) AS AVN_REAL_PROG_PERIODO

                        FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO AC
                        WHERE  FOSE_CNTR_CODIGO = '" + contrato + @"' AND SEMA_ID = " + cmbSemana.SelectedValue + @" AND SBCN_SIGLA = '" + cmbFPSO.Text + @"'
                        GROUP BY AC.FOSE_CNTR_CODIGO, AC.SBCN_SIGLA, AC.SEMA_ID, AC.FCME_SIGLA, AC.SUMA_ATIV_SIG, AC.FCES_PESO_REL_CRON
                                     ) P
                                )
                                ORDER BY 1,2,3";
            dt = BLL.AcResumoSemanalAtividadesBLL.Select(strSQL);
            DTO.CollectionAcResumoSemanalAtividadesDTO col = new DTO.CollectionAcResumoSemanalAtividadesDTO();
            col = BLL.AcResumoSemanalAtividadesBLL.GetCollection(dt);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcResumoSemanalAtividades.rdlc";

            ReportDataSource rds = new ReportDataSource("dsResumoSemanalAtividades", col);
            report.DataSources.Add(rds);
            DTOBindingSource.DataSource = col;

            reportViewer1.LocalReport.DataSources.Add(rds);

            string subTitulo = cmbFPSO.Text + " / Semana: " + cmbSemana.Text;  //Período do Relatório
            // Create the parameterSubTitulo report parameter
            ReportParameter parameterSubTitulo = new ReportParameter();
            parameterSubTitulo.Name = "pSubTitulo";
            parameterSubTitulo.Values.Add(subTitulo);

            //string itensRelatorio = "TOTAL GERAL DE ITENS: " + col.Count.ToString();
            //ReportParameter parameterItensRelatorio = new ReportParameter();
            //parameterItensRelatorio.Name = "pItensRelatorio";
            //parameterItensRelatorio.Values.Add(itensRelatorio);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterSubTitulo });

            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.Visible = true;
        }
        //===================================================================================
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
    }
}