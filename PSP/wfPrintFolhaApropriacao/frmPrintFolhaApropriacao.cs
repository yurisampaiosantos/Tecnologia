using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridCarregamento.Negocio;
using Microsoft.Reporting.WinForms;

namespace wfPrintFolhaApropriacao
{
    public partial class frmPrintFolhaApropriacao : Form
    {
        public frmPrintFolhaApropriacao()
        {
            frmSplash f = new frmSplash();
            f.ShowDialog();
            InitializeComponent();

            TabelaNeg tabelaNeg = new TabelaNeg();
            cbGrupo.DataSource = tabelaNeg.ListGroup();
            cbGrupo.DisplayMember = "Descricao";
            cbGrupo.ValueMember = "ID";
            cbGrupo.SelectedIndex = -1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbTime.Items.Count != 0 && lbDates.Items.Count != 0)
            {
                DialogResult myDialogResult;
                myDialogResult = MessageBox.Show("Será gerado um total de " + (lbTime.Items.Count * lbDates.Items.Count).ToString() + " pág(s), deseja imprimir?", "Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (myDialogResult == DialogResult.Yes)
                {
                    int cntTime = 0;
                    int cntDate = 0;
                    while (cntDate < lbDates.Items.Count)
                    {
                        while (cntTime < lbTime.Items.Count)
                        {
                            frmGenerationPDF f = new frmGenerationPDF();
                            f.preImpresso = cbPreImpresso.Checked;
                            f.date = lbDates.Items[cntDate].ToString();
                            f.teamId = Convert.ToDecimal(lbTimeCode.Items[cntTime].ToString());
                            f.teamDescription = lbTime.Items[cntTime].ToString();
                            f.ShowDialog();
                            cntTime++;
                        }
                        cntDate++;
                        cntTime = 0;
                    }
                    lbDates.Items.Clear();
                    lbTime.Items.Clear();
                    lbTimeCode.Items.Clear();
                }
            }
            else
                MessageBox.Show("É necessário selecionar no minimo uma date e uma equipe");
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {

        }

        private void btnAddActivities_Click(object sender, EventArgs e)
        {
            if (lbTime.FindString(cbEquipe.Text) == -1)
            {
                lbTime.Items.Add(cbEquipe.Text);
                lbTimeCode.Items.Add(cbEquipe.SelectedValue);
            }
        }

        private void bntDelDate_Click(object sender, EventArgs e)
        {
            lbDates.Items.RemoveAt(lbDates.SelectedIndex);
        }

        private void btnDelActivities_Click(object sender, EventArgs e)
        {
            lbTimeCode.Items.RemoveAt(lbTime.SelectedIndex);
            lbTime.Items.RemoveAt(lbTime.SelectedIndex);
        }

        private void frmPrintFolhaApropriacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                frmSplash f = new frmSplash();
                f.ShowDialog();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (lbDates.FindString(e.Start.Date.ToString("dd/MM/yyyy")) == -1)
            {
                lbDates.Items.Add(e.Start.Date.ToString("dd/MM/yyyy"));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lbDates.Items.Clear();
            lbTime.Items.Clear();
            lbTimeCode.Items.Clear();
            cbArea.SelectedIndex = -1;
            cbEquipe.SelectedIndex = -1;
            cbGrupo.SelectedIndex = -1;
        }
        private void cbEquipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEquipe.Text != "System.Data.DataRowView" && cbEquipe.Text != "" && cbEquipe.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                TabelaNeg tabelaNeg = new TabelaNeg();
                DataTable dt = tabelaNeg.GetTeamCodeByID(cbEquipe.SelectedValue.ToString());
                lblEquipe.Text = "Equipe " + dt.Rows[0]["TEAM_CODE"].ToString();
            }
        }
        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbArea.Text != "System.Data.DataRowView" && cbArea.Text != "")
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    cbEquipe.DataSource = tabelaNeg.ListTeamAreaComissionamento(Convert.ToDecimal(cbArea.SelectedValue), DateTime.Now.Date.ToString("dd/MM/yyyy"), Convert.ToDecimal(cbGrupo.SelectedValue),"");
                    cbEquipe.DisplayMember = "Descricao";
                    cbEquipe.ValueMember = "ID";
                    cbEquipe.SelectedIndex = -1;
                }
                else
                {
                    cbEquipe.SelectedIndex = -1;
                }
            }
            catch
            {
                cbEquipe.SelectedIndex = -1;
            }
        }

        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbGrupo.Text != "System.Data.DataRowView" && cbGrupo.Text != "")
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    cbArea.DataSource = tabelaNeg.ListAreaGroupComissionamento(Convert.ToDecimal(cbGrupo.SelectedValue));
                    cbArea.DisplayMember = "Descricao";
                    cbArea.ValueMember = "ID";
                    cbArea.SelectedIndex = -1;
                }
                else
                {
                    cbArea.SelectedIndex = -1;
                }
            }
            catch
            {
                cbArea.SelectedIndex = -1;
            }
        }
    }
}
