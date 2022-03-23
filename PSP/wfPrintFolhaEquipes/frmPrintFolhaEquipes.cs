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

namespace wfPrintFolhaEquipes
{
    public partial class frmPrintFolhaEquipes : Form
    {
        DataTable dtEquipes = null;
        public frmPrintFolhaEquipes()
        {
            //frmSplash f = new frmSplash();
            //f.ShowDialog();
            InitializeComponent();

            TabelaNeg tabelaNeg = new TabelaNeg();
            cbRP.DataSource = tabelaNeg.ListRP();
            cbRP.DisplayMember = "RP_DESCRIPTION";
            cbRP.ValueMember = "RP_ID";
            cbRP.SelectedIndex = -1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lbTime.Items.Count != 0 && lbDates.Items.Count != 0)
            {
                DialogResult myDialogResult;
                myDialogResult = MessageBox.Show("Confirma os dados selecionados para a impressão?", "Impressão", MessageBoxButtons.YesNo);

                if (myDialogResult == DialogResult.Yes)
                {
                    int cntTime = 0;
                    int cntDate = 0;
                    while (cntDate < lbDates.Items.Count)
                    {
                        //while (cntTime < lbTime.Items.Count)
                        //{
                            frmGenerationPDF f = new frmGenerationPDF();
                            f.preImpresso = cbPreImpresso.Checked;
                            f.date = lbDates.Items[cntDate].ToString();
                            //f.teamId = Convert.ToDecimal(lbTimeCode.Items[cntTime].ToString());
                            //f.teamId = Convert.ToDecimal(dtEquipes.Rows[cntTime]["EQUIPE_ID"]);
                            //f.teamDescription = dtEquipes.Rows[cntTime]["EQUIPE"].ToString();
                            f.rpId = Convert.ToDecimal(dtEquipes.Rows[cntTime]["RP_ID"]);
                            f.ShowDialog();
                            
                            //cntTime++;
                        //}
                        cntDate++;
                        //cntTime = 0;
                    }
                    lbDates.Items.Clear();
                    lbTime.Items.Clear();
                    lbTimeCode.Items.Clear();
                }
            }
            else
                MessageBox.Show("É necessário selecionar no minimo uma data.");
        }

        private void btnAddDate_Click(object sender, EventArgs e)
        {

        }
        private void bntDelDate_Click(object sender, EventArgs e)
        {
            lbDates.Items.RemoveAt(lbDates.SelectedIndex);
        }

        private void btnDelActivities_Click(object sender, EventArgs e)
        {
            //lbTimeCode.Items.RemoveAt(lbTime.SelectedIndex);
            //lbTime.Items.RemoveAt(lbTime.SelectedIndex);
        }

        private void frmPrintFolhaEquipes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                //frmSplash f = new frmSplash();
                //f.ShowDialog();
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
            cbRP.SelectedIndex = -1;
        }
        private void cbRP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbRP.Text != "System.Data.DataRowView" && cbRP.Text != "")
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    dtEquipes = tabelaNeg.GetTeamByRpID(Convert.ToDecimal(cbRP.SelectedValue));
                    for (int i = 0; i < dtEquipes.Rows.Count; i++)
                    { 
                        lbTime.Items.Add(dtEquipes.Rows[i]["EQUIPE"]);
                    }
                }
                else
                {
                    cbRP.SelectedIndex = -1;
                }
            }
            catch
            {
                cbRP.SelectedIndex = -1;
            }
        }
    }
}
