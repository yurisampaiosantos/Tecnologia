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
    public partial class frmCalendar : Form
    {
        public string selectDate;
        public frmCalendar()
        {
            InitializeComponent();
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (e.Start.Date <= DateTime.Now.Date)
            {
                selectDate = e.Start.Date.ToString("dd/MM/yyyy");
                Close();
            }
            else
            {
                MessageBox.Show("É necessário seleciona uma data igual ou inferior há data atual");
            }
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            monthCalendar.MinDate = tabelaNeg.ClosingDate();
            monthCalendar.MaxDate = DateTime.Now.Date;
        }
    }
}
