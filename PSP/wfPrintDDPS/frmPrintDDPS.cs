using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridCarregamento.Negocio;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;
using System.Deployment.Application;

namespace wfPrintDDPS
{
    public partial class frmPrintDDPS : Form
    {
        string turno = "";
        public frmPrintDDPS()
        {
            //frmSplash f = new frmSplash();
            //f.ShowDialog();
            InitializeComponent();
            TabelaNeg tabelaNeg = new TabelaNeg();
            cbGrupo.DataSource = tabelaNeg.ListGroup();
            cbGrupo.DisplayMember = "Descricao";
            cbGrupo.ValueMember = "ID";
            cbGrupo.SelectedIndex = -1;
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (cbDDPS.Checked || cbFAD.Checked)
                {
                    if (lbTime.Items.Count != 0 && lbDates.Items.Count != 0)
                    {
                        DialogResult myDialogResult;
                        myDialogResult = MessageBox.Show("Será gerado um total de " + (lbTime.Items.Count * lbDates.Items.Count).ToString() + " processo(s)\nDeseja realmente imprimir?", "Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                                    f.cbDDPS = cbDDPS.Checked;
                                    f.cbFAD = cbFAD.Checked;
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

                            MessageBox.Show("Processo de impressão realizado com sucesso.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("É necessário selecionar no minimo uma data e uma equipe", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi selecionado nem um tipo de Relatório", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddActivities_Click(object sender, EventArgs e)
        {
            try 
            {
                if (lbTime.FindString(cbEquipe.Text) == -1)
                {
                    lbTime.Items.Add(cbEquipe.Text);
                    lbTimeCode.Items.Add(cbEquipe.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void frmPrintDDPS_KeyDown(object sender, KeyEventArgs e)
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
            cbResponsavel.DataSource = null;
            cbArea.DataSource = null;
            cbEquipe.DataSource = null;
            cbGrupo.SelectedIndex = -1;
        }
        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbArea.Text != "System.Data.DataRowView" && cbArea.Text != "")
                {
                    FillEquipe();
                    pnlEncarregados.Enabled = true;
                }
                else
                {
                    cbEquipe.SelectedIndex = -1;
                    pnlEncarregados.Enabled = false;
                }
            }
            catch
            {
                cbEquipe.SelectedIndex = -1;
                pnlEncarregados.Enabled = false;
            }
        }
        private void FillEquipe()
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            turno = "";
            if (rbDiurno.Checked) turno = "D";
            if (rbNoturno.Checked) turno = "N";
            cbEquipe.DataSource = tabelaNeg.ListaEquipe(Convert.ToDecimal(cbArea.SelectedValue), DateTime.Now.Date.ToString("dd/MM/yyyy"), Convert.ToDecimal(cbGrupo.SelectedValue), turno, Convert.ToDecimal(cbResponsavel.SelectedValue));
            cbEquipe.DisplayMember = "Descricao";
            cbEquipe.ValueMember = "ID";
            cbEquipe.SelectedIndex = -1;
        }
        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbGrupo.Text != "System.Data.DataRowView" && cbGrupo.Text != "")
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    cbResponsavel.DataSource = tabelaNeg.ListaResponsavel(Convert.ToDecimal(cbGrupo.SelectedValue));
                    cbResponsavel.DisplayMember = "Descricao";
                    cbResponsavel.ValueMember = "ID";
                    cbResponsavel.SelectedIndex = -1;
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
        private void cbResponsavel_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                decimal varResponsavel;

                if (cbResponsavel.Text != "System.Data.DataRowView" && cbResponsavel.Text != "")
                {
                    varResponsavel = Convert.ToDecimal(cbResponsavel.SelectedValue);
                }
                else
                {
                    varResponsavel = 0;
                }

                TabelaNeg tabelaNeg = new TabelaNeg();
                cbArea.DataSource = tabelaNeg.ListaArea(Convert.ToDecimal(cbGrupo.SelectedValue), varResponsavel);
                cbArea.DisplayMember = "Descricao";
                cbArea.ValueMember = "ID";
                cbArea.SelectedIndex = -1;
            }
            catch
            {
                cbArea.SelectedIndex = -1;
            }
        }

        private void rbDiurno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDiurno.Checked)
            {
                rbNoturno.Checked = false;
                turno = "D";
                FillEquipe();
            }
        }

        private void rbNoturno_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNoturno.Checked)
            {
                rbDiurno.Checked = false;
                turno = "N";
                FillEquipe();
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int itens = lbTime.Items.Count;
                for (int i = itens - 1; i >= 0 ; i--)
                {
                    lbTime.Items.RemoveAt(i);
                    lbTimeCode.Items.RemoveAt(i);
                }
                if (chkTodos.Checked)
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    DataTable dt = tabelaNeg.ListaEquipe(Convert.ToDecimal(cbArea.SelectedValue), DateTime.Now.Date.ToString("dd/MM/yyyy"), Convert.ToDecimal(cbGrupo.SelectedValue), turno, Convert.ToDecimal(cbResponsavel.SelectedValue));
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (lbTime.FindString(dt.Rows[i]["DESCRICAO"].ToString()) == -1)
                            {
                                lbTime.Items.Add(dt.Rows[i]["DESCRICAO"].ToString());
                                lbTimeCode.Items.Add(dt.Rows[i]["ID"]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btExames_Click(object sender, EventArgs e)
        {
            frmExames frm = new frmExames();
            frm.ShowDialog();
        }

        private void frmPrintDDPS_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version CurrentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                String version = CurrentVersion.Major.ToString() + "." + CurrentVersion.Minor.ToString() + "." + CurrentVersion.Build.ToString() + "." + CurrentVersion.Revision.ToString();

                this.Text = "Impressão - DDPS / FAD / Exames  - v" + version;
            }

            //TESTE
            //cbGrupo.SelectedIndex = 11;
            //cbArea.SelectedIndex = 3;
            //cbEquipe.SelectedIndex = 0;
            //lbTime.Items.Add(cbEquipe.Text);
            //lbTimeCode.Items.Add(cbEquipe.SelectedValue);
            //lbDates.Items.Add("05/08/2015");
            //btExames_Click(this, e);
        }
    }
}
