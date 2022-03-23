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

namespace wfPrintDDPS
{
    public partial class frmExames : Form
    {
        public frmExames()
        {
            InitializeComponent();
        }

        private void frmExames_Load(object sender, EventArgs e)
        {
            monthCalendar1.MinDate = DateTime.Now.Date.AddDays(1);
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                if (lblDe.Text != "" && lblAte.Text != "")
                {
                    TabelaNeg tabelaNeg = new TabelaNeg();
                    DataTable dataTable = tabelaNeg.qtdeEquipes(lblDe.Text, lblAte.Text);
                    
                    DialogResult myDialogResult;
                    myDialogResult = MessageBox.Show("Será gerado um total de " + dataTable.Rows.Count.ToString() + " pág(s), deseja imprimir?", "Impressão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            frmGenerationPDF f = new frmGenerationPDF();
                            f.origem = "Exames";
                            f.date = DateTime.Now.Date.ToString();
                            f.De = lblDe.Text;
                            f.Ate = lblAte.Text;
                            f.teamId = Convert.ToDecimal(dataTable.Rows[i]["TEAM_ID"]);
                            f.teamDescription = dataTable.Rows[i]["LIDER_NOME"].ToString();
                            f.ShowDialog();
                        }

                        MessageBox.Show("Processo de impressão realizado com sucesso.", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("É necessário selecionar no minimo um dia", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            lblDe.Text = monthCalendar1.SelectionStart.ToShortDateString();
            lblAte.Text = monthCalendar1.SelectionEnd.ToShortDateString();

        }
    }
}
