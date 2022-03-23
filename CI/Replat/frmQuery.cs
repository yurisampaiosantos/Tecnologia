using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Replat
{
    public partial class frmQuery : Form
    {
        public string strQuery;

        public frmQuery()
        {
            InitializeComponent();
        }

        private void frmQuery_Load(object sender, EventArgs e)
        {
            txtQuery.Text = strQuery;
        }
    }
}
