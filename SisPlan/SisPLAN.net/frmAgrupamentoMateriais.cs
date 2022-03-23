using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Diagnostics;


namespace SisPLAN.net
{
    public partial class frmAgrupamentoMateriais : Form
    {
        //====================================================================================================
        DataTable dtDetalhado, dtAgrupado = null;
        //decimal empNumber = 0;
        static string repositoryFolder = "";
        //static string exceptionFolder = "";
        //static string handledFolder = "";
        //static string safeFileName = "";
        //====================================================================================================
        public frmAgrupamentoMateriais()
        {
            InitializeComponent();
        }
        //====================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;
            repositoryFolder = @"F:\CONVERSÃO\PLANEJAMENTO\6-Materiais\05-Materiais x Spools\Atual\";
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
                    //this.labelProgress.Text = "Operação concluída com sucesso!";
                    //this.p.Image = Properties.Resources.InformationImage;
                }
            }
            // restore button states
            lblProgress.Visible = false;
            this.btnAgrupar.Enabled = true;
            gridView1.DataSource = dtAgrupado;
        }
        //====================================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Executando...", ""));

            // Operation
            string lista = ("'" + txtFOSE.Text.Trim().Replace(" ", "") + "'").Replace(",", "','").Replace(Convert.ToChar(8221), Convert.ToChar(34));
            if (txtFOSE.Text.Trim() != "")
            {
                string fileDate = System.DateTime.Now.ToString("dd_MM_yyyy hh.mm.ss");
                string fileNameDetalhe, fileNameSumario = "";
                //string connStr = GetConnectionString();
                string strSQL = @"SELECT SI.FOLHA_NUMERO AS FOSE, SI.FSIT_DIPR_ID, SI.CODIGO AS MATERIAL_SISEPC, PE.DIPE_CODIGO AS MATERIAL_SAP, SI.DESCRICAO, SI.UNME_SIGLA, 
                                         SI.FSIT_QTD_REAL, ROUND(AVG(NFIT_VLR_UNIT),2) AS VALOR_UNITARIO, (SI.FSIT_QTD_REAL * ROUND(AVG(NFIT_VLR_UNIT),2)) AS VALOR_TOTAL
                                    FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM SI, EEP_CONVERSION.DICIONARIO_PRODUTO_EMPRESA PE, EEP_CONVERSION.V_NE_ITEM NE
                                   WHERE SI.FOLHA_NUMERO IN(" + lista + @") 
                                     AND PE.DIPE_CNTR_CODIGO = SI.FSIT_CNTR_CODIGO AND PE.DIPE_DIPR_ID = SI.FSIT_DIPR_ID AND PE.DIPE_EMPR_ID = 156   --Empresa: SAP CONV
                                     AND NE.NOEI_CNTR_CODIGO = SI.FSIT_CNTR_CODIGO AND NE.DIPR_ID = SI.FSIT_DIPR_ID
                                   GROUP BY SI.FOLHA_NUMERO, SI.FSIT_DIPR_ID, SI.CODIGO, PE.DIPE_CODIGO, SI.DESCRICAO, SI.UNME_SIGLA, SI.FSIT_QTD_REAL
                                   ORDER BY SI.CODIGO";
                dtDetalhado = BLL.AcControleFolhaServicoBLL.Select(strSQL);


                strSQL = @"
                                  SELECT MATERIAL_SISEPC, MATERIAL_SAP, DESCRICAO, '' AS NCM, UNME_SIGLA, FSIT_QTD_REAL, VALOR_UNITARIO, ROUND((FSIT_QTD_REAL * VALOR_UNITARIO),2) AS VALOR_TOTAL
                                    FROM ( 
                                            SELECT MATERIAL_SISEPC, MATERIAL_SAP, DESCRICAO, UNME_SIGLA, SUM(FSIT_QTD_REAL) AS FSIT_QTD_REAL, 
                                                   AVG(VALOR_UNITARIO) AS VALOR_UNITARIO
                                              FROM (
                                                        SELECT SI.FOLHA_NUMERO AS FOSE, SI.FSIT_DIPR_ID, 
                                                               SI.CODIGO AS MATERIAL_SISEPC, PE.DIPE_CODIGO AS MATERIAL_SAP, SI.DESCRICAO, SI.UNME_SIGLA, 
                                                               SI.FSIT_QTD_REAL, ROUND(AVG(NFIT_VLR_UNIT),2) AS VALOR_UNITARIO, (SI.FSIT_QTD_REAL * ROUND(AVG(NFIT_VLR_UNIT),2)) AS VALOR_TOTAL
                                                          FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM SI, EEP_CONVERSION.DICIONARIO_PRODUTO_EMPRESA PE, EEP_CONVERSION.V_NE_ITEM NE
                                                         WHERE SI.FOLHA_NUMERO IN(" + lista + @") 
                                                           AND PE.DIPE_CNTR_CODIGO = SI.FSIT_CNTR_CODIGO AND PE.DIPE_DIPR_ID = SI.FSIT_DIPR_ID AND PE.DIPE_EMPR_ID = 156   --Empresa: SAP CONV
                                                           AND NE.NOEI_CNTR_CODIGO = SI.FSIT_CNTR_CODIGO AND NE.DIPR_ID = SI.FSIT_DIPR_ID
                                                      GROUP BY SI.FOLHA_NUMERO, SI.FSIT_DIPR_ID, SI.CODIGO, PE.DIPE_CODIGO, SI.DESCRICAO, SI.UNME_SIGLA, SI.FSIT_QTD_REAL
                                                      ORDER BY SI.CODIGO
                                                   )
                                          GROUP BY MATERIAL_SISEPC, MATERIAL_SAP, DESCRICAO, UNME_SIGLA
                                          ORDER BY MATERIAL_SISEPC
                                         )";
                dtAgrupado = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                

                //if (chkSpreadsheet.Checked)
                //{
                    DirectoryInfo dir = new DirectoryInfo(repositoryFolder);
                    FileInfo[] files = dir.GetFiles();
                    for (int i = 0; i < files.Length; i++)
                    {
                        files[i].CopyTo(repositoryFolder.Replace("Atual", "Historico") + files[0].Name, true);
                        files[i].Delete();
                    }
                    fileNameDetalhe = repositoryFolder + fileDate + "_AgrupamentoMateriaisDetalhe" + ".xls";
                    fileNameSumario = repositoryFolder + fileDate + "_AgrupamentoMateriaisSumario" + ".xls";
                    GenericClasses.SpreadSheets.CreateSpreadSheet(dtDetalhado, fileNameDetalhe);
                    GenericClasses.SpreadSheets.CreateSpreadSheet(dtAgrupado, fileNameSumario);
                    MessageBox.Show(@"Planilhas geradas com sucesso!" + Convert.ToChar(13) + Convert.ToChar(10) + Convert.ToChar(10) + "Acesse: " + Convert.ToChar(13) + Convert.ToChar(10) + repositoryFolder);
                //}
            }
        }
        //====================================================================================================
        private void btnAgrupar_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            // change button states
            this.btnAgrupar.Enabled = false;
            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }
        //====================================================================================================
    }
}



