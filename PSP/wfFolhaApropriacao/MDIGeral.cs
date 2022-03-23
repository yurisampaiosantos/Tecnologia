using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment.Application;

namespace wfFolhaApropriacao
{
    public partial class MDIGeral : Form
    {
        //System.Windows.Forms.FormStartPosition startPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        
        public MDIGeral()
        {
            InitializeComponent();
        }

        private void MDIGeral_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version CurrentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                String version = CurrentVersion.Major.ToString() + "." + CurrentVersion.Minor.ToString() + "." + CurrentVersion.Build.ToString() + "." + CurrentVersion.Revision.ToString();

                toolStripStatusLabel1.Text = "Versão: " + version;
            }

            //frmRelProdutividade frm = new frmRelProdutividade();
            //frm.MdiParent = this;

            //frm.Show();
        }

        private void apropriarHorasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFolhaApropriacao frm = new frmFolhaApropriacao();
            frm.MdiParent = this;

            //frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //frm.StartPosition = startPosition;

            //Size size = new Size(this.Width - 5, this.Height - 50);
            //frm.Size = size;

            frm.Show();
        }

        private void movimentaçãoDiáriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelMovimentacao frm = new frmRelMovimentacao();
            frm.MdiParent = this;

            frm.Show();
        }

        private void xSairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpStatus frm = new frmImpStatus();
            frm.MdiParent = this;

            frm.Show();
        }

        private void faltaRHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpFaltas frm = new frmImpFaltas();
            frm.MdiParent = this;

            frm.Show();
        }

        private void produtividadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelProdutividade frm = new frmRelProdutividade();
            frm.MdiParent = this;

            frm.Show();
        }

        private void apropriaçãoPorPeríodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelApropriacaoPeriodo frm = new frmRelApropriacaoPeriodo();
            frm.MdiParent = this;

            frm.Show();
        }

        private void novosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpNovos frm = new frmImpNovos();
            frm.MdiParent = this;

            frm.Show();
        }

        private void atividadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpAtividades frm = new frmImpAtividades();
            frm.MdiParent = this;

            frm.Show();
        }
    }
}
