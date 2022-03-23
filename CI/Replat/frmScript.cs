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
    public partial class frmScript : Form
    {
        public frmScript()
        {
            InitializeComponent();
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            if (txtString.Text != "")
            {
                RfNfEntradaBLL.strScript = txtString.Text;
                Close();
            }
        }

        private void frmScript_Load(object sender, EventArgs e)
        {
            RfNfEntradaBLL.strScript = "";
        }
    }
}
