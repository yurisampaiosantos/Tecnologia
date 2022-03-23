using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Deployment.Application;

namespace SisPLAN.net
{
    public partial class MdiSisplan : Form
    {
        System.Windows.Forms.FormStartPosition startPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        //Size size = new Size(1192, 722);
        Size size = new Size(1410,722);
        public MdiSisplan()
        {
            InitializeComponent();
            this.Text = "ENSEADA - Indústria Naval (SisPlan.Net)";
        }

        //Módulo Materiais
        private void StatusMateriais_Click(object sender, EventArgs e)
        {
            frmStatusMateriais frm = new frmStatusMateriais();
            frm.Text = "Status de Materiais";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void AgrupamentoMateriais_Click(object sender, EventArgs e)
        {
            frmAgrupamentoMateriais frm = new frmAgrupamentoMateriais();
            frm.Text = "Agrupamento de Materias - Folhas de Serviço";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void ImportaMateriaisTubulacao(object sender, EventArgs e)
        {
            frmImportaMateriaisTubulacao frm = new frmImportaMateriaisTubulacao();
            frm.Text = "Importa Materiais de Tubulação";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            //frm.Size = new Size(1410,640);
            frm.Size = size;
            frm.Show();
        }
        private void PendenciaMateriais_Click(object sender, EventArgs e)
        {
            frmPendenciaMateriais frm = new frmPendenciaMateriais();
            frm.Text = "Pendencia de Materiais";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void RecebimentoMateriais_Click(object sender, EventArgs e)
        {
            frmRecebimentoMateriais frm = new frmRecebimentoMateriais();
            frm.Text = "Recebimento de Materiais";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }


        //Módulo Células de Trabalho
        private void CelulasTrabalhoResumo_Click(object sender, EventArgs e)
        {
            frmCelulasTrabalhoResumo frm = new frmCelulasTrabalhoResumo();
            frm.Text = "Células de Trabalho - Resumo";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void ControleFolhaServico_Click(object sender, EventArgs e)
        {
            frmControleFolhaServico frm = new frmControleFolhaServico();
            frm.Text = "Controle de Folhas de Serviço";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void ImportaItensControle_Click(object sender, EventArgs e)
        {
            frmImportaItensControle frm = new frmImportaItensControle();
            frm.Text = "Importa Itens de Controle";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void ResumoSemanalAtividades_Click(object sender, EventArgs e)
        {
            frmResumoSemanalAtividades frm = new frmResumoSemanalAtividades();
            frm.Text = "Resumo Semanal de Atividades";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        
        //Módulo SISPLAN
        private void SisplanMonitor_Click(object sender, EventArgs e)
        {
            frmSisplanMonitor frm = new frmSisplanMonitor();
            frm.Text = "SISPLAN Monitor";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void RAM_Click(object sender, EventArgs e)
        {
            frmRAM frm = new frmRAM();
            frm.Text = "RAM - Relatório de Acompanhamento de Medições";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void VincularGrupoCritério_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
            frmVincularGrupoCriterio frm = new frmVincularGrupoCriterio();
            frm.Text = "Vincular Grupo Critério";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            //frm.Size = size;
            frm.Show();
        }

        //Módulo Gerenciais
        private void StatusTubulacao_Click(object sender, EventArgs e)
        {
            frmStatusTubulacao frm = new frmStatusTubulacao();
            frm.Text = "Status de Tubulação";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void ImportaCorridaMateriais_Click(object sender, EventArgs e)
        {
            frmImportaCorridaMateriais frm = new frmImportaCorridaMateriais();
            frm.Text = "Importa Corrida de Materiais" ;
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void spoolsPendentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpoolsPendentes frm = new frmSpoolsPendentes();
            frm.Text = "Spools Pendentes";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void materiaisPendentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateriaisPendentes frm = new frmMateriaisPendentes();
            frm.Text = "Materiais Pendentes";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void acuracidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcuracidade frm = new frmAcuracidade();
            frm.Text = "Acuracidade de Programação e Execução de Avanços"; //
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void EstoqueDeMateriaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstoqueMaterial frm = new frmEstoqueMaterial();
            frm.Text = "Estoque de Materiais"; //
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }
        private void MontagemTubulacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMontagemTubulacao frm = new frmMontagemTubulacao();
            frm.Text = "Acompanhamento de Montagem de Tubulações"; //
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void importaPastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportaPastas frm = new frmImportaPastas();
            frm.Text = "Importa Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void importaPunchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportaPunchList frm = new frmImportaPunchList();
            frm.Text = "Importa Punch List";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void movimentaPastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.IO.FileInfo f = new FileInfo(@"C:\Sisplan.Net\PunchListTicket\PunchListTicket.xml");
            if (f.Exists) f.Delete();
            frmMovimentaPastas frm = new frmMovimentaPastas();
            frm.Text = "Movimenta Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void listaMovimentoDePastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListaMovimentoPastas frm = new frmListaMovimentoPastas();
            frm.Text = "Lista Movimento de Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void punchListDasPastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPunchlistPasta frm = new frmPunchlistPasta();
            frm.Text = "Emite as Punch Lists das Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void acompanhaPunchListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcompanhaPunchlist frm = new frmAcompanhaPunchlist();
            frm.Text = "Acompanha as Punch Lists das Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }  

        private void materiaisPendentesDasPastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMateriaisPendentesPasta frm = new frmMateriaisPendentesPasta();
            frm.Text = "Emite as listas de materiais pendentes das Pastas de Comissionamento";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void resumoDePastasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPastaResumo frm = new frmPastaResumo();
            frm.Text = "Resumo de Pastas por Disciplina";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void resumoDePastasÁreaDisciplinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPastaResumoAreaDisciplina frm = new frmPastaResumoAreaDisciplina();
            frm.Text = "Resumo de Pastas por Área / Disciplina";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void importaControleGeralEITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImportaControleGeralEIT frm = new frmImportaControleGeralEIT();
            frm.Text = "Importa Controle Geral - EIT";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void avancosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAvancoCompletacao frm = new frmAvancoCompletacao();
            frm.Text = "Importa Controle Geral - EIT";
            frm.BackColor = System.Drawing.Color.Aquamarine;
            frm.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B7BC");
            frm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            frm.MdiParent = this;
            frm.StartPosition = startPosition;
            frm.Size = size;
            frm.Show();
        }

        private void MdiSisplan_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version CurrentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                String version = CurrentVersion.Major.ToString() + "." + CurrentVersion.Minor.ToString() + "." + CurrentVersion.Build.ToString() + "." + CurrentVersion.Revision.ToString();

                toolStripStatusLabel1.Text = "Versão: " + version;
            }
        }

        private void produtividadePorUAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutividadePorUa frm = new frmProdutividadePorUa();
            frm.MdiParent = this;

            frm.Show();
        }

        private void xSairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        } 
    }
}
