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
    public partial class frmAvancoCompletacao : Form
    {
        static string asp = Convert.ToChar(34).ToString();
        static string contrato = "Conversão";
        static string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";
        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();
        static string filter = "";
        static string strSQL = "";
        static string dtInicio, dtFim = "";
        static string titulo = "";
        DataTable dtDOC = null;
        static string disciplinas = "2,3,4,5,6,9,15,20";
        static string discId = "";
        static string equipeId = "";
        static string sbcnSigla = "";
        static string semaId = "";
        static string zona = "";
        static string semaIdAnterior = "";
        static string fn = "n4";
        static string f2 = "n2";
        static string lf = Convert.ToChar(10).ToString();
        //===================================================================================
        public frmAvancoCompletacao()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmAvancoCompletacao_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();

            strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                        @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                        @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL " +
                        @"ORDER  BY 1 NULLS FIRST";
            dtDOC = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
            cmbFPSO.DataSource = dtDOC;
            cmbFPSO.DisplayMember = "SBCN_SIGLA";
            cmbFPSO.ValueMember = "SBCN_ID";
            
            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();

            semana = BLL.AcSemanaBLL.GetSemanaCorrente();
            semaId = semana.SemaId.ToString();
            semaIdAnterior = (semana.SemaId - 1).ToString();
            lblSemana.Text = "Semana Corrente: " + semaId + "  (" + semana.SemaDataInicio.ToShortDateString() + " - " + semana.SemaDataFim.ToShortDateString() + ")";
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = "1 = 1";
            sbcnSigla = cmbFPSO.Text;
            discId = cmbDisciplina.SelectedValue.ToString();
            if (cmbEquipe.SelectedValue.ToString() != "" || cmbEquipe.SelectedValue == null) equipeId = cmbEquipe.SelectedValue.ToString();
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND FOSE_SBCN_SIGLA = '" + sbcnSigla + "'";
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND DISC_ID = " + discId;
//            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND DISC_ID = " + CRITERIO;
            if (cmbEquipe.SelectedIndex > 0) sRet += @" AND EQUIPE_ID = " + equipeId;
            if (cmbZona.SelectedIndex > 0) sRet += @" AND ZONA_ID = " + zona;
           
            return sRet;
        }
        //===================================================================================
        private void GetStrSQL()
        {
            strSQL = @"SELECT '" + contrato + @"'  AS FOSE_CNTR_CODIGO, '*'||QP.COD_BARRAS||'*' AS COD_BARRAS, QP.FOSE_NUMERO AS FOSE_NUMERO, QP.FOSE_ID,
      (SELECT FCES_SIGLA || ' - ' || FCES_DESCRICAO AS TAREFA FROM EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA WHERE FCES_CNTR_CODIGO = '" + contrato + @"' AND FCES_ID = FOSM_FCES_ID) AS TAREFA,
      (SELECT DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO Z WHERE Z.FOSE_ID = QP.FOSE_ID AND Z.ATPE_NOME = 'Localizacao') AS LOCALIZACAO_REGIAO,
      (SELECT DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO Z WHERE Z.FOSE_ID = QP.FOSE_ID AND Z.ATPE_NOME = 'Regiao') AS REGIAO,
      (SELECT DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO Z WHERE Z.FOSE_ID = QP.FOSE_ID AND Z.ATPE_NOME = 'Zona') AS ZONA,
      (SELECT DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO Z WHERE Z.FOSE_ID = QP.FOSE_ID AND Z.ATPE_NOME = 'Equipe') AS EQUIPE,
      DISC_SIGLA,
      (SELECT SBCN_SIGLA FROM EEP_CONVERSION.SUB_CONTRATO WHERE SBCN_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = FOSE_SBCN_ID) AS FOSE_SBCN_SIGLA
        FROM
        (
              SELECT COD_BARRAS, FOSM_ID, FOSE_ID, FOSE_NUMERO, FOSM_FCES_ID, DISC_SIGLA, FOSE_SBCN_ID, MAX(FSMP_DATA) AS FSMP_DATA, MAX(FSMP_AVANCO_ACM) AS FSMP_AVANCO_ACM
              FROM (
                    SELECT COD_BARRAS, FOSE_NUMERO, CNTR_CODIGO, DISC_NOME,CNTR_ID, FOSE_ID, FOSM_ID, FOSM_FCES_ID, DISC_SIGLA, FOSE_SBCN_ID , FSMP_DATA, FSMP_AVANCO_ACM
                    FROM
                    ( 
                      SELECT    SUBSTR(TO_CHAR(CNTR_ID + 100),2,2) || SUBSTR(TO_CHAR(FOSE_ID + 10000000000),2,10) || SUBSTR(TO_CHAR(FOSM_ID + 10000000000),2,10) AS COD_BARRAS, FOSE_NUMERO,
                                CNTR_CODIGO, DISC_NOME,CNTR_ID, FOSE_ID, FOSM_ID, FOSM_FCES_ID, DISC_SIGLA, FOSE_SBCN_ID, FSMP_DATA, FSMP_AVANCO_ACM
                        FROM    EEP_CONVERSION.FOLHA_SERVICO_MEDICAO, EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.CONTRATO, EEP_CONVERSION.DISCIPLINA,
                                EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG
                       WHERE    CNTR_CODIGO = '" + contrato + @"' AND DISC_ID = " + discId + @" AND
                                FOSM_ID IN
                                          (
                                          SELECT DISTINCT Q.FOSM_ID 
                                            FROM
                                                (
                                                  SELECT  F.FOSE_ID, M.FOSM_ID, MAX(P.FSMP_AVANCO_ACM) AS FSMP_AVANCO_ACM
                                                    FROM    EEP_CONVERSION.FOLHA_SERVICO_MEDICAO M, EEP_CONVERSION.FOLHA_SERVICO F, EEP_CONVERSION.CONTRATO C, EEP_CONVERSION.DISCIPLINA D,EEP_CONVERSION.VW_AVN_FOSM_CRITERIO_PROG P
                                                    WHERE FCES_NIVEL = MAX_NIVEL_CRITERIO AND --FOSE_ID = 450571 AND
                                                    C.CNTR_CODIGO = '" + contrato + @"' AND D.DISC_ID = " + discId + @" AND --FOSE_NUMERO = :FOSE_NUMERO AND
                                                    F.FOSE_CNTR_CODIGO = M.FOSM_CNTR_CODIGO AND F.FOSE_ID = M.FOSM_FOSE_ID AND
                                                    D.DISC_CNTR_CODIGO = F.FOSE_CNTR_CODIGO AND D.DISC_ID = F.FOSE_DISC_ID AND
                                                    P.FOSM_CNTR_CODIGO = M.FOSM_CNTR_CODIGO AND P.FOSM_ID = M.FOSM_ID AND
                                                    P.FSMP_DATA BETWEEN (SELECT SEMA_DATA_INICIO FROM EEP_CONVERSION.AC_SEMANA WHERE SEMA_CNTR_CODIGO = '" + contrato + @"' AND SEMA_ID = " + semaId + @") AND
                                                                      (SELECT SEMA_DATA_FIM FROM EEP_CONVERSION.AC_SEMANA WHERE SEMA_CNTR_CODIGO = '" + contrato + @"' AND SEMA_ID = " + semaId + @")";

            if (cmbCriterio.SelectedIndex > 0) strSQL += @" AND P.FCES_FCME_ID = " + cmbCriterio.SelectedValue.ToString();
            
            strSQL += @" GROUP BY F.FOSE_ID, M.FOSM_ID
                                                    ORDER BY 1,2
                                                ) Q
                                          ) AND
                                FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID AND
                                DISC_CNTR_CODIGO = FOSE_CNTR_CODIGO AND DISC_ID = FOSE_DISC_ID AND
                                FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID AND
                                FSMP_DATA BETWEEN (SELECT SEMA_DATA_INICIO FROM EEP_CONVERSION.AC_SEMANA WHERE SEMA_CNTR_CODIGO = '" + contrato + @"' AND SEMA_ID = " + semaId + @") AND
                                                  (SELECT SEMA_DATA_FIM FROM EEP_CONVERSION.AC_SEMANA WHERE SEMA_CNTR_CODIGO = '" + contrato + @"' AND SEMA_ID = " + semaId + @")
                    )                                  
                                      
                    )
                    GROUP BY COD_BARRAS, FOSE_NUMERO, CNTR_CODIGO, DISC_NOME,CNTR_ID, FOSE_ID, FOSM_ID, FOSM_FCES_ID, DISC_SIGLA, FOSE_SBCN_ID 
        ) QP
        ORDER BY LOCALIZACAO_REGIAO, FOSE_NUMERO, COD_BARRAS";
        }

        #region Filtros
        //===================================================================================
        private void ShowReport(string filter, string strSql)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcAvancoCompletacao.rdlc";

            DTO.CollectionAcAvancoCompletacaoDTO ca = new DTO.CollectionAcAvancoCompletacaoDTO();
            
            DataTable dt = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
            ca = BLL.AcAvancoCompletacaoBLL.GetCollection(dt);
            ReportDataSource rds = new ReportDataSource("dsAvancoCompletacao", ca);
            report.DataSources.Add(rds);

            CollectionDTOBindingSource.DataSource = ca;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }
        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisciplina.Visible = false;
            cmbDisciplina.Visible = false;
            if (cmbFPSO.SelectedIndex > 0)
            {
                strSQL = @"SELECT NULL AS DISC_ID, NULL AS DISC_NOME FROM DUAL UNION SELECT DISTINCT D.DISC_ID, D.DISC_NOME FROM EEP_CONVERSION.DISCIPLINA D WHERE DISC_CNTR_CODIGO = '" + contrato + "' AND DISC_ID IN (" + disciplinas + ") ORDER BY 2 NULLS FIRST";
                dtDOC = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
                cmbDisciplina.DataSource = dtDOC;
                cmbDisciplina.DisplayMember = "DISC_NOME";
                cmbDisciplina.ValueMember = "DISC_ID";
                cmbDisciplina.Visible = true;
                lblDisciplina.Visible = true;
                Application.DoEvents();
            }
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {

            lblCriterio.Visible = false;
            cmbCriterio.Visible = false;
            if (cmbDisciplina.SelectedIndex > 0)
            {
                discId = cmbDisciplina.SelectedValue.ToString();
                strSQL = @"SELECT NULL AS FCME_ID, NULL AS FCME_SIGLA FROM DUAL UNION SELECT DISTINCT FCME_ID, FCME_SIGLA FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO WHERE FCME_CNTR_CODIGO = '" + contrato + @"' AND FCME_DISC_ID = " + discId + @" ORDER BY 2 NULLS FIRST";
                dtDOC = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
                cmbCriterio.DataSource = dtDOC;
                cmbCriterio.DisplayMember = "FCME_SIGLA";
                cmbCriterio.ValueMember = "FCME_ID";

                lblCriterio.Visible = true;
                cmbCriterio.Visible = true;
                lblProgress.Visible = false;
                btnExecute.Visible = true;
                Application.DoEvents();
            }
        }
        //===================================================================================
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEquipe.Visible = false;
            cmbEquipe.Visible = false;
            if (cmbDisciplina.SelectedIndex > 0)
            {
                strSQL = @"SELECT NULL AS EQUIPE_ID, NULL AS EQUIPE_NOME FROM DUAL UNION SELECT DISTINCT E.EQUIPE_ID, E.EQUIPE_NOME FROM EEP_CONVERSION.AC_EQUIPE E ORDER BY 2 NULLS FIRST";
                dtDOC = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
                cmbEquipe.DataSource = dtDOC;
                cmbEquipe.DisplayMember = "EQUIPE_NOME";
                cmbEquipe.ValueMember = "EQUIPE_ID";

                strSQL = @"SELECT NULL AS ZONA_ID, NULL AS ZONA_NOME FROM DUAL UNION SELECT DISTINCT ZONA_ID, (ZONA_ID || ' - ' || ZONA_NOME) AS ZONA_NOME FROM EEP_CONVERSION.CP_ZONA ORDER BY 2 NULLS FIRST";
                dtDOC = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
                cmbZona.DataSource = dtDOC;
                cmbZona.DisplayMember = "ZONA_NOME";
                cmbZona.ValueMember = "ZONA_ID";

                lblEquipe.Visible = true;
                cmbEquipe.Visible = true;
                lblZona.Visible = true;
                cmbZona.Visible = true;
                Application.DoEvents();
            }
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            lblProgress.Visible = true;
            Application.DoEvents();
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            //this.btnExecute.Enabled = false;
            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();
            this.reportViewer1.Visible = false;
            reportViewer1.Reset();
            this.reportViewer1.Visible = false;
            lblProgress.Visible = true;
            Application.DoEvents();
            GetStrSQL();
            if (cmbEquipe.Text != "")
            {
                strSQL = "SELECT * FROM (" + strSQL + ") WHERE EQUIPE = " + cmbEquipe.Text;
            }
            if (cmbZona.Text != "")
            {
                strSQL = "SELECT * FROM (" + strSQL + ") WHERE ZONA = " + cmbZona.SelectedValue.ToString();
            }
            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }
        //===================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));
            ShowReport(filter, strSQL);
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
                    //if (cmbFPSO.SelectedIndex > 0)
                    //{
                    //    //subTitulo += " - FPSO: " + cmbFPSO.Text;
                    //    subTitulo += " - " + cmbFPSO.Text;
                    //}
                    titulo = cmbFPSO.Text + " - Avanços para Completação - Semana " + semaId;
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    // Create the parameterSubtitulo report parameter
                    //string subTitulo = "Disciplina: " + cmbDisciplina.Text;
                    string subTitulo = "";
                    if (cmbCriterio.Text != "") subTitulo = cmbDisciplina.Text + " - Criterio: " + cmbCriterio.Text;
                    else subTitulo = subTitulo + cmbDisciplina.Text;

                    if(cmbEquipe.Text != "") subTitulo += " - Equipe: " + equipeId;
                    if (cmbZona.Text != "") subTitulo += " - Zona: " + cmbZona.Text;
                    
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

            string path = systemRepository + @"Reports\" + titulo + "-" + cmbDisciplina.Text + "-" + cmbFPSO.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

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