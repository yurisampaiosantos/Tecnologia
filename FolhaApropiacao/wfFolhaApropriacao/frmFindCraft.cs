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

namespace wfFolhaApropriacao
{
    public partial class frmFindCraft : Form
    {
        public string strCraftId;
        private string _listMatriculas;
        public frmFindCraft(string listMatriculas)
        {
            InitializeComponent();
            _listMatriculas = listMatriculas;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            dataGridResult.DataSource = tabelaNeg.ListCraft(_listMatriculas, txtFindCraft.Text);
            dataGridResult.Columns[0].HeaderText = "MATRICULA";
            dataGridResult.Columns[1].HeaderText = "NOME";
        }

        private void txtFindCraft_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnFind_Click(sender,e);
            }
        }

        private void dataGridResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strCraftId = dataGridResult.Rows[e.RowIndex].Cells[0].Value.ToString() + "|" + dataGridResult.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { } 
            this.Close();
        }
    }
}
