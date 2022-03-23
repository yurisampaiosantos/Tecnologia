using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUSINESS;

namespace PrimaveraUnlock
{
    public partial class frmPrimaveraUnlock : Form
    {
        public frmPrimaveraUnlock()
        {
            InitializeComponent();
            comboBox1.Items.Add("CEP");
            comboBox1.Items.Add("Conversão");
            comboBox1.Items.Add("Sondas");
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                UsessionBusiness usessionSelect = new UsessionBusiness();
                dataGridView1.DataSource = usessionSelect.SelectUsession(comboBox1.Text);
            }
            else
            {
                MessageBox.Show("Selecione um local!");
            }
        }

        private void btDesbloquear_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Tem certeza que deseja desbloquear o usuário?", "Desbloquio de Usuário - Primavera", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button2);
            if (confirm.ToString().ToUpper() == "YES")
            {
                UsessionBusiness usessionUpdate = new UsessionBusiness();
                usessionUpdate.UpdateUsession(comboBox1.Text, Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].EditedFormattedValue));
                dataGridView1.DataSource = usessionUpdate.SelectUsession(comboBox1.Text);
                dataGridView1.Refresh();
                MessageBox.Show("Usuário desbloqueado");
            }
        }

    }
}
