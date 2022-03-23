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
    public partial class frmAcompanhaPunchlist : Form
    {
        static string lf = Convert.ToChar(10).ToString();
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string filter = "";
        string strSQL = "";
        string titulo = "";
        DataTable dtDOC = null;
        DataTable dtResponsaveis = null;
        DataTable dtVwCpPunchlist = null;
        //===================================================================================
        public frmAcompanhaPunchlist()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmAcompanhaPunchlist_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            Application.DoEvents();
            //Feed cmbRespPunchlist
            strSQL = @"SELECT * FROM (SELECT NULL AS ARPE_AGENTE, NULL AS ARPE_DESCRICAO FROM DUAL UNION SELECT ARPE_AGENTE, ARPE_DESCRICAO FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA ORDER BY ARPE_AGENTE) ORDER BY ARPE_DESCRICAO NULLS FIRST";
            dtResponsaveis = BLL.CpPastaBLL.Select(strSQL);
            cmbRespPunchlist.DataSource = dtResponsaveis;
            cmbRespPunchlist.ValueMember = "ARPE_DESCRICAO";
            cmbRespPunchlist.DisplayMember = "ARPE_AGENTE";
            cmbRespPunchlist.SelectedIndex = 0;
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = @"1 = 1";
            if (cmbRespPunchlist.SelectedIndex > 0) sRet += @" AND UPPER(X.PUNCH_RESPONSIBLE_BY) = '" + cmbRespPunchlist.Text.ToUpper() + "'";
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            string strSelect = @"SELECT X.PUNCH_ID, X.PUNCH_PASTA_ID, X.PASTA_CODIGO, X.PUNCH_DESCRICAO, TO_CHAR(X.PUNCH_DATA_PROMETIDA,'DD/MM/YYYY') AS PUNCH_DATA_PROMETIDA, X.PUNCH_RESPONSIBLE_BY, X.STPU_DESCRICAO, X.PUNCH_APPROVED_BY, TO_CHAR(X.PUNCH_APPROVED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_APPROVED_DATE, X.PUNCH_CREATED_BY, TO_CHAR(X.PUNCH_CREATED_DATE,'DD/MM/YYYY HH24:MI:SS') AS PUNCH_CREATED_DATE, TO_CHAR(X.PUNCH_DATA_CONCLUIDA,'DD/MM/YYYY') AS PUNCH_DATA_CONCLUIDA, X.PUNCH_SITUACAO, X.PUNCH_IMPEDITIVA_DESC, X.ARPE_DESCRICAO, X.ARPE_EMAIL_AGENTE, X.ARPE_EMAIL_LEADER FROM EEP_CONVERSION.VW_CP_PUNCHLIST X ";
            strSelect += " WHERE " + filter + " ORDER BY X.PUNCH_ID DESC";
            dtVwCpPunchlist = BLL.VwCpPunchlistBLL.Select(strSelect);

        }

        #region Filtros
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;

            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();

            //Atualizar GRID AQUI

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
                    dgvPunchlist.DataSource = dtVwCpPunchlist;
                }
            }
            lblProgress.Visible = false;
        }
        //===================================================================================
        private void dgvPunchlist_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPunchlist.SelectedRows.Count != 0)
            {
                //CarregaPunchlistForm();
                //pl.PunchId = Convert.ToDecimal(dgvPunchlist.CurrentRow.Cells["ITEM"].Value.ToString());
                //dgvPunchlist.CurrentRow.Cells[0].Value.ToString()
                //"2287"
                //dgvPunchlist.CurrentRow.Cells[1].Value.ToString()
                //"Conversão"
                //dgvPunchlist.CurrentRow.Cells[2].Value.ToString()
                //"13092"
                //dgvPunchlist.CurrentRow.Cells[3].Value.ToString()
                //"P74-5423.501-L208A"


                System.IO.FileInfo f = new FileInfo(@"C:\Sisplan.Net\PunchListTicket\PunchListTicket.xml");
                if (f.Exists) f.Delete();
                DTO.CpPunchListTicketDTO t = new DTO.CpPunchListTicketDTO();
                t.PunchResponsibleBy = dgvPunchlist.CurrentRow.Cells["PUNCH_RESPONSIBLE_BY"].Value.ToString();
                t.PastaId = Convert.ToDecimal(dgvPunchlist.CurrentRow.Cells["PUNCH_PASTA_ID"].Value.ToString());
                t.PastaCodigo = dgvPunchlist.CurrentRow.Cells["PASTA_CODIGO"].Value.ToString();
                GenericClasses.XML.SerializaPunchListTicketXML(t, @"C:\Sisplan.Net\PunchListTicket\PunchListTicket.xml");

                

                System.Windows.Forms.FormStartPosition startPosition = System.Windows.Forms.FormStartPosition.CenterParent;
                
                Size size = new Size(1410, 722);
                frmMovimentaPastas frm = new frmMovimentaPastas();
                frm.Text = "Movimenta Pastas de Comissionamento";
                frm.BackColor = System.Drawing.Color.Aquamarine;
                frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
                frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                frm.MinimizeBox = false;
                frm.MaximizeBox = false;
                frm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None ;
                //frm.StartPosition = startPosition;
                //frm.Size = size;
                frm.Show();


                //dgvPunchlist.CurrentRow.Cells["PUNCH_PASTA_ID"].Value.ToString()
                //"13104"
                //dgvPunchlist.CurrentRow.Cells["PUNCH_RESPONSIBLE_BY"].Value.ToString()
                //"JONATHAN"
                //dgvPunchlist.CurrentRow.Cells["PASTA_CODIGO"].Value.ToString()
                //"P74-5139.502-L119"

            }
        }
        //===================================================================================

        #endregion
    }
}