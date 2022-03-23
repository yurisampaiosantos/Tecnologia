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
//using System.Xml.Serialization;


namespace SisPLAN.net
{
    public partial class frmPastaResumoAreaDisciplina : Form
    {
        string userName = "";
        decimal usuaClasse = 10000;
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";
        string fpso = "";
        string area = "";
        string discSigla = "";
        string grupo = "";
        string subgrupo = "";
        string smgrSequence = "";
        string smsgSequence = "";
        string smsgId = "";
        decimal total = 0;
        string filter = "";
        string strSQL = "";
        string titulo = "";
        DataTable dtDOC = null;
        DataTable dtDestinos = null;
        DataTable dtArea = null;
        DataTable dtCpPastaResumoSubgrupo = null;
        DataRow[] row = null;
        static string lf = Convert.ToChar(10).ToString();
        DTO.CpPrevistoDTO p = new DTO.CpPrevistoDTO();
        DTO.CpPastaResumoSubgrupoDTO r = new DTO.CpPastaResumoSubgrupoDTO();

        //===================================================================================
        public frmPastaResumoAreaDisciplina()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmPastaResumoAreaDisciplina_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;

            DTO.CollectionCpUsuarioDTO cu = new DTO.CollectionCpUsuarioDTO();
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToLower();//Domínio + Login
            cu = BLL.CpUsuarioBLL.GetCollection("UPPER(USUA_LOGIN) = '" + userName.ToUpper() + "'");
            usuaClasse = cu[0].UsuaClasse;
            //if (usuaClasse <= 5) panelFilter.Enabled = true;
            Application.DoEvents();

            //cmbFPSO
            strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                     @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 2 AS SBCN_ID, 'P75' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 4 AS SBCN_ID, 'P77' AS SBCN_SIGLA from DUAL " +
                     @"ORDER  BY 1 NULLS FIRST";

            dtDOC = BLL.CpPastaResumoBLL.Select(strSQL);
            cmbFPSO.DataSource = dtDOC;
            cmbFPSO.DisplayMember = "SBCN_SIGLA";
            cmbFPSO.ValueMember = "SBCN_ID";

            //Feed cmbArea
            strSQL = @"SELECT NULL AS AREA_ID, NULL AS AREA_DESCRICAO FROM DUAL UNION SELECT AREA_ID, AREA_DESCRICAO FROM EEP_CONVERSION.CP_AREA ORDER BY 2 NULLS FIRST";
            dtArea = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
            cmbArea.DataSource = dtArea;
            cmbArea.DisplayMember = "AREA_DESCRICAO";
            cmbArea.ValueMember = "AREA_ID";

            if (usuaClasse <= 15)
            {
                p = GenericClasses.XML.DeserializaArquivoXML(p, @"F:\CONVERSÃO\PLANEJAMENTO\23-Comissionamento\PrevisaoPastas.xml");
                ExibePrevisto(p);
            }
            else
            {
                MessageBox.Show("Usuário sem credenciamento para emissão de relatório");
            }

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void ExibePrevisto(DTO.CpPrevistoDTO p)
        {
            txtCascoMec.Text = p.CascoMec.ToString();
            txtCascoTub.Text = p.CascoTub.ToString();
            txtCascoEle.Text = p.CascoEle.ToString();
            txtCascoIns.Text = p.CascoIns.ToString();
            txtCascoTlc.Text = p.CascoTlc.ToString();

            txtErprMec.Text = p.ErprMec.ToString();
            txtErprTub.Text = p.ErprTub.ToString();
            txtErprEle.Text = p.ErprEle.ToString();
            txtErprIns.Text = p.ErprIns.ToString();
            txtErprTlc.Text = p.ErprTlc.ToString();

            txtMsMec.Text = p.MsMec.ToString();
            txtMsTub.Text = p.MsTub.ToString();
            txtMsEle.Text = p.MsEle.ToString();
            txtMsIns.Text = p.MsIns.ToString();
            txtMsTlc.Text = p.MsTlc.ToString();

            txtMaMec.Text = p.MaMec.ToString();
            txtMaTub.Text = p.MaTub.ToString();
            txtMaEle.Text = p.MaEle.ToString();
            txtMaIns.Text = p.MaIns.ToString();
            txtMaTlc.Text = p.MaTlc.ToString();

            if (usuaClasse > 5)
            {
                txtCascoMec.Enabled = false;
                txtCascoTub.Enabled = false;
                txtCascoEle.Enabled = false;
                txtCascoIns.Enabled = false;
                txtCascoTlc.Enabled = false;
                          
                txtErprMec.Enabled = false;
                txtErprTub.Enabled = false;
                txtErprEle.Enabled = false;
                txtErprIns.Enabled = false;
                txtErprTlc.Enabled = false;
                           
                txtMsMec.Enabled = false;
                txtMsTub.Enabled = false;
                txtMsEle.Enabled = false;
                txtMsIns.Enabled = false;
                txtMsTlc.Enabled = false;
                         
                txtMaMec.Enabled = false;
                txtMaTub.Enabled = false;
                txtMaEle.Enabled = false;
                txtMaIns.Enabled = false;
                txtMaTlc.Enabled = false;
            }
        }
        //===================================================================================
        private string GetFilter()
        {
            //PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA, PRSG_AREA, PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO
            string sRet = @"X.PRSG_CNTR_CODIGO = '" + contrato + "'";
            sRet += @" AND X.PRSG_SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            sRet += @" AND X.PRSG_AREA = '" + cmbArea.Text + "'";
            sRet += @" AND X.PRSG_DISC_SIGLA = '" + cmbDisciplina.Text + "'";
            
            return sRet;
        }
        //===================================================================================
        private void PrepareReport(string filter, string fpso)
        {
            
            //Prepara Situação das Pastas
            PreparaSituacao(fpso);
            //Salva Previsto
            //SalvaPrevisto();

            //Carrega o Resumo de pastas para a FPSO
            strSQL = @"SELECT  M.MOVI_CNTR_CODIGO, M.PASTA_SBCN_SIGLA, M.AREA_ID, M.AREA_DESCRICAO, M.DISC_ID, M.DISC_SIGLA, M.SMGR_ID, M.SMGR_DESCRICAO, L.SMGR_SEQUENCE, L.SMSG_ID, L.SMSG_DESCRICAO, L.SMSG_SEQUENCE
                                --,M.MOVI_STMO_ID, M.STMO_DESCRICAO, M.PASTA_CODIGO, M.PASTA_STPA_ID
                                --, SSOP_CODIGO, SSOP_DESCRICAO
                                , COUNT(*) AS QUANTIDADE
                        FROM EEP_CONVERSION.VW_CP_PASTA_ULT_MOV M, EEP_CONVERSION.VW_CP_MOV_SG_GR_LOCAL L
                        WHERE
                        M.MOVI_CNTR_CODIGO = L.LOCA_CNTR_CODIGO AND M.MOVI_STMO_ID = L.STMO_ID
                        AND M.PASTA_STPA_ID != 3 
                        AND M.AREA_DESCRICAO = '" + area + "' AND M.DISC_SIGLA = '" + discSigla + @"'  
                        GROUP BY M.MOVI_CNTR_CODIGO, M.PASTA_SBCN_SIGLA, M.AREA_ID, M.AREA_DESCRICAO, M.DISC_ID, M.DISC_SIGLA, M.SMGR_ID, M.SMGR_DESCRICAO, L.SMGR_SEQUENCE, L.SMSG_ID, L.SMSG_DESCRICAO, L.SMSG_SEQUENCE
                        ORDER BY  M.AREA_DESCRICAO, M.DISC_SIGLA, L.SMGR_SEQUENCE, L.SMSG_SEQUENCE";
            dtCpPastaResumoSubgrupo = BLL.VwCpPastaUltMovBLL.Select(strSQL);

            //Calcula a Situação das Pastas
            CalculaSituacao(fpso);
            CalculaTotaisDestino(fpso);
            InsereItem7(fpso);
        }
        private void InsereItem7(string fpso)
        {
            //Parte 2
            decimal qtd = 0;
            DataTable dtD = null;
            try
            {
                grupo = "7. COMPLETAÇÃO MECÂNICA OK";
                subgrupo = "Completação Mecânica";
                strSQL = @"SELECT SUM(PRSG_QUANTIDADE) AS PRSG_QUANTIDADE FROM EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO WHERE PRSG_SMSG_ID IN (710, 730, 740,800)";
                dtD = BLL.CpPastaResumoBLL.Select(strSQL);
                if(dtD.Rows[0]["PRSG_QUANTIDADE"] != DBNull.Value) qtd = Convert.ToDecimal(dtD.Rows[0]["PRSG_QUANTIDADE"]);
                strSQL = @" INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO
                                (PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA, PRSG_AREA, PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO, PRSG_QUANTIDADE, PRSG_SMGR_SEQUENCE, PRSG_SMSG_SEQUENCE)
                                VALUES
                                ('" + contrato + "', '" + fpso + "', '" + area + "', '" + discSigla + "', '" + grupo + "', '" + subgrupo + "'," + qtd.ToString() + ",700,700)";
                BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - PreparaSituacao - Parte 2"); }
        }
        //===================================================================================
        private void PreparaSituacao(string fpso)
        {
            try
            {
                //Prepara os Destinos de pastas para a FPSO
                strSQL = @"SELECT DISTINCT SMGR_DESCRICAO,SMSG_DESCRICAO,SMGR_SEQUENCE, SMSG_SEQUENCE, SMSG_ID FROM EEP_CONVERSION.VW_CP_MOV_SG_GR_LOCAL ORDER BY SMGR_SEQUENCE, SMSG_SEQUENCE";
                dtDestinos = BLL.VwCpPastaUltMovBLL.Select(strSQL);
                //Os agrupamentos na tabela CP_PASTA_RESUMO
                for (int i = 0; i < dtDestinos.Rows.Count; i++)
                {
                    grupo = dtDestinos.Rows[i]["SMGR_DESCRICAO"].ToString();
                    subgrupo = dtDestinos.Rows[i]["SMSG_DESCRICAO"].ToString();
                    smgrSequence = dtDestinos.Rows[i]["SMGR_SEQUENCE"].ToString();
                    smsgSequence = dtDestinos.Rows[i]["SMSG_SEQUENCE"].ToString();
                    smsgId = dtDestinos.Rows[i]["SMSG_ID"].ToString();
                    //BLL.CpPastaResumoBLL.Insert(r, false);
                    strSQL = @" INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO
                                (PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA, PRSG_AREA, PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO,PRSG_SMGR_SEQUENCE, PRSG_SMSG_SEQUENCE, PRSG_SMSG_ID)
                                VALUES
                                ('" + contrato + "', '" + fpso + "', '" + area + "', '" + discSigla + "', '" + grupo + "', '" + subgrupo + "'," + smgrSequence + ", " + smsgSequence + ", " + smsgId + ")";
                    BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - PreparaSituacao"); }
        }
        //===================================================================================
        private void CalculaSituacao(string fpso)
        {
            decimal qtd = 0;
            //Parte 1
            for (int i = 0; i < dtCpPastaResumoSubgrupo.Rows.Count; i++)
            {
                qtd = Convert.ToDecimal(dtCpPastaResumoSubgrupo.Rows[i]["QUANTIDADE"]);
                try
                {
                    grupo = dtCpPastaResumoSubgrupo.Rows[i]["SMGR_DESCRICAO"].ToString();
                    subgrupo = dtCpPastaResumoSubgrupo.Rows[i]["SMSG_DESCRICAO"].ToString();
                    strSQL = @"UPDATE EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO SET PRSG_QUANTIDADE = " + qtd.ToString() +
                             @" WHERE PRSG_CNTR_CODIGO = '" + contrato + @"' AND 
                                      PRSG_SBCN_SIGLA = '" + fpso + @"' AND 
                                      PRSG_AREA = '" + area + @"' AND 
                                      PRSG_DISC_SIGLA = '" + discSigla + @"' AND 
                                      PRSG_SMGR_DESCRICAO = '" + grupo + @"' AND 
                                      PRSG_SMSG_DESCRICAO = '" + subgrupo + "'";
                    BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
                }
                catch (Exception ex) { throw new Exception(ex.Message + " - CalculaSituacao - Parte 1"); }
            }
        }
        //===================================================================================
        private void CalculaTotaisDestino(string fpso)
        {
            DataTable dtD = null;
            strSQL = @"SELECT SUM(PRSG_QUANTIDADE) AS PRSG_QUANTIDADE FROM EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO";
            dtD = BLL.CpPastaResumoBLL.Select(strSQL);
            if (dtD.Rows[0]["PRSG_QUANTIDADE"].ToString() != "" ) total = Convert.ToDecimal(dtD.Rows[0]["PRSG_QUANTIDADE"]);
            strSQL = @" INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO
                                (PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA, PRSG_AREA, PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO, PRSG_QUANTIDADE, PRSG_SMGR_SEQUENCE, PRSG_SMSG_SEQUENCE)
                                VALUES
                                ('" + contrato + "', '" + fpso + "', '" + area + "', '" + discSigla + "', 'TOTAL', 'TOTAL'," + total.ToString() + ",1000,10000)";
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);

        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcResumoPastaAreaDisciplina.rdlc";

            DTO.CollectionCpPastaResumoSubgrupoDTO ca = new DTO.CollectionCpPastaResumoSubgrupoDTO();
            ca = BLL.CpPastaResumoSubgrupoBLL.GetCollection(filter, "PRSG_ID");
            ReportDataSource rds = new ReportDataSource("dsResumoPastaAreaDisciplina", ca);
            report.DataSources.Add(rds);

            CollectionDTOBindingSource.DataSource = ca;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        #region Filtros
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Este relatório encontra-se em manutenção, favor aguardar liberação.");
            if (cmbArea.SelectedIndex == 0 || cmbDisciplina.SelectedIndex == 0)
            {
                MessageBox.Show("Área e Disciplina devem ser selecionados.");
            }
            else
            {
                // show animated image
                this.pBox.Image = Properties.Resources.BarraEvolucao;
                //btnExecute.Enabled = false;

                //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
                filter = GetFilter();

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
            //Limpa tabela de resumo
            strSQL = @"DELETE EEP_CONVERSION.CP_PASTA_RESUMO_SUBGRUPO WHERE PRSG_SBCN_SIGLA = '" + fpso + "'";
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction("COMMIT");
            PrepareReport(filter, fpso);
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

                    // Create the parameterPrevisto report parameter
                    string strPrevisto = GetPrevisto(area, discSigla);
                    ReportParameter parameterPrevisto = new ReportParameter();
                    parameterPrevisto.Name = "pPrevisto";
                    parameterPrevisto.Values.Add(strPrevisto);

                    // Create the parameterTitulo report parameter
                    titulo = "Pastas por Área e Disciplina - " + fpso;
                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    string subTitulo = area + " - " + discSigla + " / Previsto: " + strPrevisto;
                    ReportParameter parameterSubtitulo = new ReportParameter();
                    parameterSubtitulo.Name = "pSubTitulo";
                    parameterSubtitulo.Values.Add(subTitulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    // Create the parameterTotal report parameter
                    string total = "";
                    ReportParameter parameterTotal = new ReportParameter();
                    parameterTotal.Name = "pTotal";
                    parameterTotal.Values.Add(total);

                    // Set the report parameters for the report
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterSubtitulo, parameterEmissao, parameterPrevisto, parameterTotal });

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
        private string GetPrevisto(string area, string discSigla)
        {
            string previsto = "INDEFINIDO";

            switch (area)
            {
                case "CASCO":
                    {
                        switch (discSigla)
                        {
                            case "MEC": { previsto = txtCascoMec.Text; break; }
                            case "TUB": { previsto = txtCascoTub.Text; break; }
                            case "ELE": { previsto = txtCascoEle.Text; break; }
                            case "INS": { previsto = txtCascoIns.Text; break; }
                            case "TLC": { previsto = txtCascoTlc.Text; break; }
                        }
                        break;
                    }
                case "ER/PR":
                    {
                        switch (discSigla)
                        {
                            case "MEC": { previsto = txtErprMec.Text; break; }
                            case "TUB": { previsto = txtErprTub.Text; break; }
                            case "ELE": { previsto = txtErprEle.Text; break; }
                            case "INS": { previsto = txtErprIns.Text; break; }
                            case "TLC": { previsto = txtErprTlc.Text; break; }
                        }
                        break;
                    }
                case "MS":
                    {
                        switch (discSigla)
                        {
                            case "MEC": { previsto = txtMsMec.Text; break; }
                            case "TUB": { previsto = txtMsTub.Text; break; }
                            case "ELE": { previsto = txtMsEle.Text; break; }
                            case "INS": { previsto = txtMsIns.Text; break; }
                            case "TLC": { previsto = txtMsTlc.Text; break; }
                        }
                        break;
                    }
                case "MA":
                    {
                        switch (discSigla)
                        {
                            case "MEC": { previsto = txtMaMec.Text; break; }
                            case "TUB": { previsto = txtMaTub.Text; break; }
                            case "ELE": { previsto = txtMaEle.Text; break; }
                            case "INS": { previsto = txtMaIns.Text; break; }
                            case "TLC": { previsto = txtMaTlc.Text; break; }
                        }
                        break;
                    }
                    
            }
            return previsto;
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

            string path = systemRepository + @"Reports\" + titulo + " - " + cmbFPSO.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblProgress.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFPSO.SelectedIndex != 0)
            {
                btnExecute.Visible = true;
                if (usuaClasse <= 5) panelFilter.Visible = true;
                fpso = cmbFPSO.Text;
            }
        }
        //===================================================================================
        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex != 0)
            {
                area = cmbArea.Text;
            }
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex != 0)
            {
                //btnExecute.Visible = true;
                discSigla = cmbDisciplina.Text;
            }
        }

        private void lblFPSO_Click(object sender, EventArgs e)
        {

        }
        //===================================================================================

        #endregion
    }
}