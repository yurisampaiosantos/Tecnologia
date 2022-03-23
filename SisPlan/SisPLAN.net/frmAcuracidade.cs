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
    public partial class frmAcuracidade : Form
    {
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";
        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();

        string filter = "";

        string strSQL = "";
        string dtInicio, dtFim = "";
        //DataTable dtVwAcAcuracidade = null;
        //DataTable dtAcuracidade = null;
        string titulo = "";
        DataTable dtDOC = null;
        //static DataTable dtCriterioEstrutura = null;
        static string disciplinas = "2,3,4,5,6,9,15,20";
        static string fn = "n4";
        static string f2 = "n2";
        static string lf = Convert.ToChar(10).ToString();
        //===================================================================================
        public frmAcuracidade()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmAcuracidade_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            Application.DoEvents();
            
            //cmbSemana
            strSQL = @"SELECT NULL AS VALUE, '' AS DISPLAY FROM DUAL UNION " +
                        @"SELECT SEMA_ID AS VALUE, SEMA_ID ||'  ( '|| SEMA_DATA_INICIO ||' - '|| SEMA_DATA_FIM ||' )' AS DISPLAY FROM 
                                (
                                    SELECT DISTINCT CP.SEMA_ID, SE.SEMA_DATA_INICIO, SE.SEMA_DATA_FIM 
                                      FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO CP, EEP_CONVERSION.AC_SEMANA SE
                                     WHERE CP.SEMA_ID = SE.SEMA_ID
                                     ORDER BY 1 DESC
                                ) 
                        WHERE ROWNUM <= 5
                        ORDER BY 1 DESC NULLS FIRST";
            dtDOC = BLL.AcSemanaBLL.Select(strSQL);
            cmbSemana.DataSource = dtDOC;
            cmbSemana.DisplayMember = "DISPLAY";
            cmbSemana.ValueMember = "VALUE";
            cmbSemana.SelectedItem = 0;

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private DataTable GetCriterioEstrutura(decimal fcmeId)
        {
          strSQL = @"SELECT FCME_DISC_ID, DISC_NOME, FCME_ID, FCME_SIGLA, FCME_NOME, FCME_SIGLA ||' - '||FCME_NOME AS TITULO_CRITERIO, FCES_SIGLA, FCES_DESCRICAO, FCES_NIVEL, FCES_WBS, FCES_PESO_REL_CRON
                    ,  FCES_SIGLA || CHR(10) ||'('|| FCES_PESO_REL_CRON ||'%)' AS TITULO_ESTRUTURA
                       FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA, EEP_CONVERSION.DISCIPLINA
                      WHERE FCME_CNTR_CODIGO = 'Conversão'
                        AND FCES_CNTR_CODIGO = FCME_CNTR_CODIGO AND FCES_FCME_ID = FCME_ID
                        AND FCME_CNTR_CODIGO = DISC_CNTR_CODIGO AND FCME_DISC_ID = DISC_ID
                        AND FCME_ID = " + fcmeId.ToString() + @" 
                   ORDER BY DISC_ID, FCME_ID, FCES_WBS";
          DataTable dt = BLL.AcRamAtividadeBLL.Select(strSQL);
          return dt;
        }
        
        //===================================================================================
        private string GetFilter()
        {
            string sRet = "1 = 1";
            //sRet = "X.ACUR_MAX_FSMP_DATA BETWEEN TO_DATE('" + dtInicio + "','DD/MM/YYYY') AND TO_DATE('" + dtFim + "','DD/MM/YYYY')";
//            sRet = @"(
//                      (X.ACUR_MAX_FSMP_DATA BETWEEN TO_DATE('" + dtInicio + "','DD/MM/YYYY') AND TO_DATE('" + dtFim + @"','DD/MM/YYYY')) OR  
//                      (X.ACUR_MAX_FSME_DATA BETWEEN TO_DATE('" + dtInicio + "','DD/MM/YYYY') AND TO_DATE('" + dtFim + @"','DD/MM/YYYY') AND X.ACUR_MAX_FSMP_DATA < TO_DATE('" + dtInicio + @"','DD/MM/YYYY'))
//                    )";
            //sRet = "(X.ACUR_MAX_FSMP_DATA IS NULL OR X.ACUR_MAX_FSMP_DATA < TO_DATE('" + dtInicio + "','DD/MM/YYYY'))";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND ACUR_SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND ACUR_DISC_ID = " + cmbDisciplina.SelectedValue;
            if (cmbCriterio.SelectedIndex > 0) sRet += @" AND ACUR_FCME_ID = " + cmbCriterio.SelectedValue;
            if (cmbRegiao.SelectedIndex > 0) sRet += @" AND ACUR_REGIAO = '" + cmbRegiao.SelectedValue + "'";
            if (cmbLocalizacao.SelectedIndex > 0) sRet += @" AND ACUR_LOCALIZACAO = '" + cmbLocalizacao.SelectedValue + "'";
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcAcuracidade.rdlc";

            DTO.CollectionAcAcuracidadeDTO ca = new DTO.CollectionAcAcuracidadeDTO();
            ca = BLL.AcAcuracidadeBLL.GetCollection(filter, "ACUR_FOSE_NUMERO");
            ReportDataSource rds = new ReportDataSource("dsAcuracidade", ca);
            report.DataSources.Add(rds);

            CollectionDTOBindingSource.DataSource = ca;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        #region Filtros

        //===================================================================================
        private void rbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = true;
            dtpFim.Enabled = true;
            cmbSemana.Visible = false;
            cmbSemana.SelectedIndex = 0;
        }
        //===================================================================================
        private void rbSemana_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = false;
            dtpFim.Enabled = false;
            cmbSemana.Visible = true;
        }
        //===================================================================================
        private void cmbSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemana.Text.ToString() != "System.Data.DataRowView" && cmbSemana.Text.ToString() != "")
            {
                if (cmbSemana.SelectedIndex != -1)
                {
                    dtpInicio.Value = Convert.ToDateTime(cmbSemana.Text.Split(' ')[3]);
                    dtpFim.Value = Convert.ToDateTime(cmbSemana.Text.Split(' ')[5]);
                    Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            PreparaControlesPeriodo();
        }
        //===================================================================================
        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            PreparaControlesPeriodo();
        }
        //===================================================================================
        private void PreparaControlesPeriodo()
        {
            lblFPSO.Visible = false;
            cmbFPSO.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value)
                {
                    //cmbFPSO
                    strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                             @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                             @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL " +
                             @"ORDER  BY 1 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbFPSO.DataSource = dtDOC;
                    cmbFPSO.DisplayMember = "SBCN_SIGLA";
                    cmbFPSO.ValueMember = "SBCN_ID";

                    cmbFPSO.Visible = true;
                    lblFPSO.Visible = true;
                }
            }
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCriterio.Visible = false;
            cmbCriterio.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbDisciplina.SelectedIndex > 0)
                {
                    lblProgress.Visible = true;
                    Application.DoEvents();
                    strSQL = @"SELECT NULL AS FCME_ID, NULL AS CRITERIO FROM DUAL 
                                UNION 
                               SELECT DISTINCT CM.FCME_ID, CM.FCME_SIGLA || ' - ' || CM.FCME_NOME AS CRITERIO 
                                 FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO FS, EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO CM
                                WHERE FS.DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + @"  AND 
                                      CM.FCME_CNTR_CODIGO = FS.FOSE_CNTR_CODIGO AND CM.FCME_SIGLA = FS.FCME_SIGLA
                                ORDER BY 2 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbCriterio.DataSource = dtDOC;
                    cmbCriterio.DisplayMember = "CRITERIO";
                    cmbCriterio.ValueMember = "FCME_ID";
                    cmbCriterio.Visible = true;
                    lblCriterio.Visible = true;

                    lblProgress.Visible = false;
                    Application.DoEvents();

                    //Alimenta cmbRegiao
                    lblRegiao.Visible = false;
                    cmbRegiao.Visible = false;
                    if (dtpInicio.Value != null && dtpFim.Value != null)
                    {
                        if (dtpInicio.Value <= dtpFim.Value)
                        {
                            lblProgress.Visible = true;
                            Application.DoEvents();
                            strSQL = @"SELECT NULL AS REGIAO FROM DUAL UNION SELECT DISTINCT REGIAO FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + " ORDER BY 1 NULLS FIRST";
                            dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                            cmbRegiao.DataSource = dtDOC;
                            cmbRegiao.DisplayMember = "REGIAO";
                            cmbRegiao.ValueMember = "REGIAO";
                            cmbRegiao.Visible = true;
                            lblRegiao.Visible = true;

                            lblProgress.Visible = false;
                            btnExecute.Visible = true;
                            Application.DoEvents();
                        }
                    }

                    //Alimenta cmbLocalizacao
                    lblLocalizacao.Visible = false;
                    cmbLocalizacao.Visible = false;
                    if (dtpInicio.Value != null && dtpFim.Value != null)
                    {
                        if (dtpInicio.Value <= dtpFim.Value)
                        {
                            lblProgress.Visible = true;
                            Application.DoEvents();
                            strSQL = @"SELECT NULL AS LOCALIZACAO FROM DUAL UNION SELECT DISTINCT LOCALIZACAO FROM EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO WHERE DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + " ORDER BY 1 NULLS FIRST";
                            dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                            cmbLocalizacao.DataSource = dtDOC;
                            cmbLocalizacao.DisplayMember = "LOCALIZACAO";
                            cmbLocalizacao.ValueMember = "LOCALIZACAO";
                            lblLocalizacao.Visible = true;
                            cmbLocalizacao.Visible = true;
                            lblRegiao.Visible = true;

                            lblProgress.Visible = false;
                            //btnExecute.Visible = true;
                            Application.DoEvents();
                        }
                    }

                }
            }
            
        }

        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisciplina.Visible = false;
            cmbDisciplina.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbFPSO.SelectedIndex > 0)
                {
                    strSQL = @"SELECT NULL AS DISC_ID, NULL AS DISC_NOME FROM DUAL 
                               UNION 
                               SELECT DISTINCT DISC_ID, DISC_NOME FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = '" + contrato + "' AND DISC_ID IN (" + disciplinas + ") ORDER BY 2 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbDisciplina.DataSource = dtDOC;
                    cmbDisciplina.DisplayMember = "DISC_NOME";
                    cmbDisciplina.ValueMember = "DISC_ID";
                    cmbDisciplina.Visible = true;
                    lblDisciplina.Visible = true;
                }
            }
        }
        //===================================================================================
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            //btnExecute.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbCriterio.SelectedIndex > 0)
                {
                    lblProgress.Visible = true;
                    Application.DoEvents();
                    lblProgress.Visible = false;
                    //btnExecute.Visible = true;
                    //Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            //this.btnExecute.Enabled = false;

            dtInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            dtFim = DateTime.Now.ToString("dd/MM/yyyy");

            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();
            //if (cmbCriterio.SelectedIndex > 0) dtCriterioEstrutura = GetCriterioEstrutura(Convert.ToDecimal(cmbCriterio.SelectedValue));
            this.reportViewer1.Visible = false;

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
                    titulo = "Acuracidade de Programação e Execução de Avanços - " + cmbFPSO.Text;
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    // Create the parameterSubtitulo report parameter
                    string subTitulo = "Disciplina: " + cmbDisciplina.Text;
                    if (cmbCriterio.SelectedIndex > 0)
                    {
                        subTitulo += " - Critério de Medição: " + cmbCriterio.Text;
                    }
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

            string path = systemRepository + @"Reports\" + titulo + "-" + cmbDisciplina.Text + "-" + cmbCriterio.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

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

//            //A3 - 29,7 x 42,0
//            //A4 - 21,0 x 29,7
//            strSQL = @"SELECT DISTINCT SBCN_SIGLA, TIPO_AVANCO, MAX(DATA_AVANCO) AS DATA_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
//                              TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE, 
//                              FOSM_ID, MAX(PERCENTUAL_AVANCO) AS PERCENTUAL_AVANCO, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, MAX(QTD_AVANCO_REAL) AS QTD_AVANCO_REAL,
//                              FOSM_FOSE_ID, FOSM_FCES_ID,
//                              FCES_FCME_ID,
//                              FCME_ID
//                        FROM (
//                              SELECT SBCN_SIGLA, TIPO_AVANCO, DATA_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
//                                     TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE,
//                              FOSM_ID, PERCENTUAL_AVANCO, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, QTD_AVANCO_REAL,
//                              FOSM_FOSE_ID, FOSM_FCES_ID,
//                              FCES_FCME_ID,
//                              FCME_ID FROM EEP_CONVERSION.VW_AC_ACURACIDADE)
//                     ";
//            strSQL += @" WHERE " + filter +
//                      @" GROUP BY SBCN_SIGLA, TIPO_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
//                                  TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE, 
//                                  FOSM_ID, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, FOSM_FOSE_ID, FOSM_FCES_ID, FCES_FCME_ID, FCME_ID 
//                         ORDER BY SBCN_SIGLA, FOSE_NUMERO,TIPO_AVANCO, FCES_WBS, DATA_AVANCO";
//            dtVwAcAcuracidade = BLL.VwAcAcuracidadeBLL.Select(strSQL);

//            DTO.CollectionVwAcAcuracidadeDTO col = new DTO.CollectionVwAcAcuracidadeDTO();
//            col = BLL.VwAcAcuracidadeBLL.GetCollection(dtVwAcAcuracidade);

//            BLL.AcAcuracidadeBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_ACURACIDADE");
//            BLL.AcAcuracidadeBLL.ExecuteSQLInstruction("COMMIT");

//            string filterAcuracidade = "";
//            DTO.CollectionAcAcuracidadeDTO ca = new DTO.CollectionAcAcuracidadeDTO();
//            for (int i = 0; i < col.Count; i++)
//            {
//                DTO.AcAcuracidadeDTO a = new DTO.AcAcuracidadeDTO();
//                a.AcurSbcnSigla = col[i].SbcnSigla;
//                a.AcurTipoAvanco = col[i].TipoAvanco;
//                a.AcurDataAvanco = col[i].DataAvanco;
//                a.AcurDiscId = col[i].FoseDiscId;
//                a.AcurDiscNome = col[i].DiscNome;
//                a.AcurFcmeId = col[i].FcmeId;
//                a.AcurFcmeSigla = col[i].FcmeSigla;
//                a.AcurFcesId = col[i].FosmFcesId;
//                a.AcurFcesSigla = col[i].FcesSigla;
//                a.AcurFcesWbs = col[i].FcesWbs;
//                a.AcurFoseId = col[i].FosmFoseId;
//                a.AcurFoseNumero = col[i].FoseNumero;
//                a.AcurUnmeSigla = col[i].UnmeSigla;
//                a.AcurTstfUnidadeRegional = col[i].TstfUnidadeRegional;
//                a.AcurRegiao = col[i].Regiao;
//                a.AcurLocalizacao = col[i].Localizacao;
//                a.AcurEquipe = col[i].Equipe;
//                a.AcurQtdPrevista = col[i].FoseQtdPrevista;
//                a.AcurFcesPesoRelCron = col[i].FcesPesoRelCron;
//                a.AcurFsmpFosmId = col[i].FosmId;
//                filterAcuracidade = @"ACUR_FOSE_ID = " + col[i].FosmFoseId.ToString() + " AND ACUR_TIPO_AVANCO = '" + col[i].TipoAvanco + "' AND ACUR_FCES_SIGLA = '" + col[i].FcesSigla + "'";
//                ca = BLL.AcAcuracidadeBLL.GetCollection(filterAcuracidade);
//                switch (a.AcurTipoAvanco)
//                {
//                    case "P": 
//                        {

//                            if (ca.Count == 0)
//                            {
//                                a.AcurFsmpAvancoAcm = col[i].PercentualAvanco;
//                                a.AcurMaxFsmpData = col[i].DataAvanco;
//                                a.AcurQtdProg = col[i].QtdAvancoReal;
//                                a.AcurQtdAvancoProgPond = col[i].QtdAvancoPond;
//                                BLL.AcAcuracidadeBLL.Insert(a, false);
//                            }
//                            else
//                            {
//                                a = ca[0];
//                                a.AcurFsmpAvancoAcm = col[i].PercentualAvanco;
//                                a.AcurMaxFsmpData = col[i].DataAvanco;
//                                a.AcurQtdProg = col[i].QtdAvancoReal;
//                                a.AcurQtdAvancoProgPond = col[i].QtdAvancoPond;
//                                BLL.AcAcuracidadeBLL.Update(a);
//                            }
//                            break;
//                        }
//                    case "X": 
//                        {
//                            //if (a.AcurFoseId == 277711)
//                            //{
//                            //    string x = "";
//                            //}
//                            filterAcuracidade = @"ACUR_MAX_FSMP_DATA IS NOT NULL AND ACUR_FOSE_ID = " + col[i].FosmFoseId.ToString() + " AND ACUR_TIPO_AVANCO = 'P' AND ACUR_FCES_SIGLA = '" + col[i].FcesSigla + "'";
//                            ca = BLL.AcAcuracidadeBLL.GetCollection(filterAcuracidade);
//                            if (ca.Count == 0)
//                            {
//                                //Não insere registro de execução sem avanco de programação
//                                if (a.AcurMaxFsmpData != null)
//                                {
//                                    a.AcurFsmeFosmId = col[i].FosmId;
//                                    a.AcurFsmeAvancoAcm = col[i].PercentualAvanco;
//                                    a.AcurMaxFsmeData = col[i].DataAvanco;
//                                    a.AcurQtdExec = col[i].QtdAvancoReal;
//                                    a.AcurQtdAvancoExecPond = col[i].QtdAvancoPond;
//                                    BLL.AcAcuracidadeBLL.Insert(a, false);
//                                }
//                            }
//                            else
//                            {
//                                a = ca[0];
//                                a.AcurFsmeFosmId = col[i].FosmId;
//                                a.AcurFsmeAvancoAcm = col[i].PercentualAvanco;
//                                a.AcurMaxFsmeData = col[i].DataAvanco;
//                                a.AcurQtdExec = col[i].QtdAvancoReal;
//                                a.AcurQtdAvancoExecPond = col[i].QtdAvancoPond;
//                                BLL.AcAcuracidadeBLL.Update(a);
//                            }
//                            break;
//                        }
//                }
//            }