using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace Replat
{
    public partial class frmAmbiente : Form
    {
        public string TipoBt;

        public frmAmbiente()
        {
            InitializeComponent();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    MessageBox.Show("Escolha um Ambiente para Enviar os Dados", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } 
                else
                {
                    RfNfEntradaBLL.strAmbiente = (radioButton1.Checked) ? radioButton1.Tag.ToString() : radioButton2.Tag.ToString();
                    RfNfEntradaBLL.ExecuteSQLInstruction("UPDATE CI_AMBIENTE SET AMBIENTE = '" + RfNfEntradaBLL.strAmbiente + "'");
                    Close();
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAmbiente_Load(object sender, EventArgs e)
        {
            RfNfEntradaBLL.strAmbiente = "";

            if (TipoBt == "Gerar") 
            {
                btEnviar.Text = TipoBt;
                btEnviar.Image = CI.Properties.Resources.atualizar;
            }
        }
    }
}
