using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//using Microsoft.Reporting.WinForms;

namespace SisPLAN.net
{
    public partial class frmSisplanMonitor : Form
    {
        DataTable dtDOC = null;
        DataTable dtPavfose = null;
        //DataTable dtDisciplina = null;

        string contrato = "Conversão";
        string disciplinas = "2,3,4,5,6,9,20";
        string criterios = "2,3,4,6,17,23,25,32,36,37,38,39,40,41,47,48,49,50,51,52,53,54,56,59,60,61,63,64,65,67,71,72,75,76,84,85,89,95,97,99,100,101,103,104,105, 110, 113";
        static string fcmeSigla = "";
        static string strSQL = "";
        string userName = "";
        //===================================================================================
        public frmSisplanMonitor()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmSisplanMonitor_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToUpper();//Domínio + Login
            strSQL = @"SELECT NULL AS DISC_ID, '' AS DISC_NOME FROM DUAL UNION SELECT DISTINCT DISC_ID, DISC_NOME || ' (' || DISC_ID || ')' AS DISC_NOME FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = '" + contrato + @"' AND DISC_ID IN (" + disciplinas + ") ORDER BY 2 NULLS FIRST";

            dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cmbDisciplina.DataSource = dtDOC;
            cmbDisciplina.DisplayMember = "DISC_NOME";
            cmbDisciplina.ValueMember = "DISC_ID";
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDisciplina.SelectedIndex > 0)
            {
                if (cmbDisciplina.SelectedIndex > 0)
                {
                    strSQL = @"SELECT NULL AS DISPLAY, NULL AS FCME_ID FROM DUAL UNION SELECT FCME_SIGLA AS DISPLAY, FCME_ID 
                                    FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO 
                                WHERE FCME_CNTR_CODIGO = '" + contrato + @"' 
                                    AND FCME_DISC_ID = '" + cmbDisciplina.SelectedValue + @"' AND FCME_ID IN (" + criterios + ") ORDER BY 1 NULLS FIRST";
                    dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                    cmbCriterio.DataSource = dtDOC;
                    cmbCriterio.DisplayMember = "DISPLAY";
                    cmbCriterio.ValueMember = "FCME_ID";
                    cmbCriterio.SelectedIndex = -1;
                    cmbCriterio.Enabled = true;
                }
            }
        }
        //===================================================================================
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriterio.SelectedIndex > 0)
            {
                EnableControls(false);
                // show animated image
                fcmeSigla = cmbCriterio.Text;


                //this.backgroundWorker.RunWorkerAsync();
                // Access Database

                UpdateGrid(fcmeSigla);
                
                //int active = 0;
                //for (int c = 0; c < dtPavfose.Rows.Count; c++)
                //{
                //    active = Convert.ToInt32(dtPavfose.Rows[c]["ACTIVE"]);
                //    RealcaSelecao(c, active);
                //}
            }
        }
        //===================================================================================
        private void EnableControls(bool p)
        {
            
        }
        //===================================================================================
        private void UpdateGrid(string fcmeSigla)
        {
            strSQL = @"SELECT 
                              F.ACTIVE, F.FOSE_NUMERO, F.EQUIPE, F.FOSE_QTD_PREVISTA, F.SUMA_ATEA_WBS, F.SUMA_ATIV_SIG, F.UNME_SIGLA, F.FOSM_ID, F.FOSE_ID, F.USER_SESSION, F.APP_USER 
                         FROM 
                              EEP_CONVERSION.PAVFOSE_" + fcmeSigla + @" F
                        WHERE 
                              UPPER(F.APP_USER) = '" + userName + @"'
                        ORDER BY F.ID ";
            dtPavfose = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            dtg.DataSource = dtPavfose;
            dtg.Columns[0].Width = 40;
            dtg.Columns[1].Width = 250;
            dtg.Columns[2].Width = 50;
            dtg.Columns[3].Width = 130;
            dtg.Columns[4].Width = 130;
            dtg.Columns[5].Width = 320;
            dtg.Columns[6].Width = 80;
            dtg.Columns[7].Width = 70;
            dtg.Columns[8].Width = 100;
            dtg.Columns[9].Width = 100;

            int active = 0;
            for (int c = 0; c < dtPavfose.Rows.Count; c++)
            {
                active = Convert.ToInt32(dtPavfose.Rows[c]["ACTIVE"]);
                RealcaSelecao(c, active);
            }
        }
        //===================================================================================
        private void dtg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string foseId = Convert.ToString(dtg.CurrentRow.Cells["FOSE_ID"].Value);
            decimal active = 0;
            
            if (dtg.CurrentRow.Cells["ACTIVE"].Value.ToString() != "")
            {
                if (Convert.ToDecimal(dtg.CurrentRow.Cells["ACTIVE"].Value) == 1) SetCurrentRow(0);
                else
                {
                    SetCurrentRow(1);
                    active = 1;
                }
            }
            else
            {
                SetCurrentRow(1);
                active = 1;
            }

            RealcaSelecao(e.RowIndex, active);

            strSQL = "UPDATE EEP_CONVERSION.PAVFOSE_" + fcmeSigla + " SET ACTIVE = " + active + @" WHERE FOSE_ID = " + foseId + " AND UPPER(APP_USER) = '" + userName + "'";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
        }
        //===================================================================================
        private void RealcaSelecao(int linha, decimal active)
        {
            for (int c = 0; c <= 10; c++)
            {
                if (active == 1)
                {
                    this.dtg.Rows[linha].Cells[c].Style.Font = new Font(this.dtg.DefaultCellStyle.Font, FontStyle.Bold);
                    this.dtg.Rows[linha].Cells[c].Style.ForeColor = Color.Black;
                    this.dtg.Rows[linha].Cells[c].Style.BackColor = Color.Yellow;
                }
                else
                {
                    this.dtg.Rows[linha].Cells[c].Style.Font = new Font(this.dtg.DefaultCellStyle.Font, FontStyle.Regular);
                    this.dtg.Rows[linha].Cells[c].Style.ForeColor = Color.Black;
                    this.dtg.Rows[linha].Cells[c].Style.BackColor = Color.White;
                }
            }
        }
        //===================================================================================
        private void SetCurrentRow(decimal status)
        {
            dtg.CurrentRow.Cells["ACTIVE"].Value = status;
        }
        //===================================================================================
        private void btnExibeTodos_Click(object sender, EventArgs e)
        {
            strSQL = "UPDATE EEP_CONVERSION.PAVFOSE_" + fcmeSigla + " SET ACTIVE = 1 WHERE UPPER(APP_USER) = '" + userName + "'";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
            UpdateGrid(fcmeSigla);
        }
        //===================================================================================
        private void btnOmiteTodos_Click(object sender, EventArgs e)
        {
            strSQL = "UPDATE EEP_CONVERSION.PAVFOSE_" + fcmeSigla + " SET ACTIVE = 0 WHERE UPPER(APP_USER) = '" + userName + "'";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
            UpdateGrid(fcmeSigla);
        }
        //===================================================================================
        private void btnAplicaFiltro_Click(object sender, EventArgs e)
        {
            string texto = txtFilter.Text.Trim();
            string colunas = "";
            try
            {
                if (txtFilter.Text != "")
                {
                    strSQL = "UPDATE EEP_CONVERSION.PAVFOSE_" + fcmeSigla + " SET ACTIVE = 0 WHERE UPPER(APP_USER) = '" + userName + "'";
                    BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);

                    for (int i = 0; i < dtg.Columns.Count; i++)
                    {
                        colunas += dtg.Columns[i].Name + ((i == dtg.Columns.Count - 1) ? "" : " || ");
                    }

                    strSQL = "UPDATE EEP_CONVERSION.PAVFOSE_" + fcmeSigla + " SET ACTIVE = 1 WHERE UPPER(APP_USER) = '" + userName + "' AND " + colunas + " LIKE '%" + texto + "%'";
                    BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
                    UpdateGrid(fcmeSigla);

                    int active = 0;
                    for (int c = 0; c < dtg.Columns.Count; c++)
                    {
                        active = Convert.ToInt32(dtg.Rows[c].Cells["ACTIVE"].Value.ToString());
                        RealcaSelecao(c, active);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //===================================================================================
    }
}