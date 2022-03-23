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
    public partial class frmFindActivities : Form
    {
        public string strTitleId;
        private string _listActivities;

        public frmFindActivities(string listActivities)
        {
            InitializeComponent();
            _listActivities = listActivities;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            dataGridResult.DataSource = tabelaNeg.ListActivities(_listActivities, txtFindActivitie.Text);
            dataGridResult.Columns[0].HeaderText = "CÓDIGO";
            dataGridResult.Columns[1].HeaderText = "UA";
            dataGridResult.Columns[2].HeaderText = "PEP";
            dataGridResult.Columns[3].HeaderText = "DESCRIÇÃO";
        }

        private void dataGridResult_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strTitleId = dataGridResult.Rows[e.RowIndex].Cells[0].Value.ToString() + "|" + dataGridResult.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            catch { }
            this.Close();
        }

        private void txtFindActivitie_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnFind_Click(sender, e);
            }
        }
    }
}
