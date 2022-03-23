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

namespace Replat
{
    public partial class MDIParent1 : Form
    {
        public MDIParent1()
        {
            InitializeComponent();
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version CurrentVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                String version = CurrentVersion.Major.ToString() + "." + CurrentVersion.Minor.ToString() + "." + CurrentVersion.Build.ToString() + "." + CurrentVersion.Revision.ToString();

                toolStripStatusLabel1.Text = "Versão: " + version + " - Beta";
            }

            //frmMiniFIFO frm = new frmMiniFIFO();
            //frm.MdiParent = this;

            //frm.Show();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void AbrirOuCriar<TForm>() where TForm : Form, new()
        {
            var instance = Application.OpenForms.OfType<TForm>().FirstOrDefault();
            if (instance == null)
            {
                instance = new TForm();
                instance.MdiParent = this;
                instance.Show();
            }
            else
            {
                instance.Focus();
            }
        }

        private void produtosDescriçãoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutosAlterados>();

            //if (Application.OpenForms.OfType<frmProdutos>().Count() > 0)
            //{
            //    MessageBox.Show("O Form2 já está aberto!");
            //}
            //else
            //{
            //    frmProdutos frm = new frmProdutos();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}
        }

        private void editorDeXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmEditorXML>();
        }

        private void produtosFabricadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutosNaoCadastrados>();
        }

        private void locationsInválidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmExecutadasSemAplicacao>();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfInterna>();
        }

        private void transferênciaDeOrganizaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfOrg>();
        }

        private void romaneioIncompletoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmRomaneioIncorreto>();
        }

        private void nEMMovimentoExternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmMovExterno>();
        }

        private void impostoCalculadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmImpostoCalculado>();
        }

        private void produçãoOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOPsNovas>();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFSporLote>();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmEstornoNF>();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmMovimentacoes>();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmDevolucao>();
        }

        private void disponíveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmDisponiveis>();
        }

        private void SaldoStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmSaldo>();
        }

        private void schedulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmAgendarEnviar>();
        }

        private void xSairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void nCNEPesoDeProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdNcmPeso>();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmLocationsAlterados>();
        }

        private void transferênciasDuplicadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfDuplicada>();
        }

        private void análiseUndMedidaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmAnaliseUndMedida>();
        }

        private void oPsExecutadas100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOPsExecutadas>();
        }

        private void transferênciasDuplicadasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfDuplicada>();
        }

        private void platNFxPlatNEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmPlatNFxPlatNEM>();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmInsumoSemConsumo>();
        }

        private void nFESemNEMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFsemNEM>();
        }

        private void nFsSemItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFsemItens>();
        }

        private void nFTENFSSemItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtNFsSemItens>();
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtNFsSemProduto>();
        }

        private void tiposRomaneiosInvalidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTipoRomaneioInvalido>();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtSemRomaneio>();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmRomaneioSemNFt>();
        }

        private void nFTDiferenteDoRomaneioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtDiferenteRomaneio>();
        }

        private void aplicaçõesInválidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmAplicacoesInvalidas>();
        }

        private void nEMLançamentoDuplicadoToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNemDuplicada>();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeVariasNem>();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNEMsemItens>();
        }

        private void nFEPorLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFEporLote>();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFEcomAlertas>();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeAlteradas>();
        }

        private void nFEAlteradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeNovas>();
        }

        private void nFDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosNFE>();
        }

        private void toolStripMenuItem25_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosRM>();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmDisponiveis>();
        }

        private void recortarToolStripButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^(X)");
        }

        private void copiarToolStripButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^(C)");  //Simula um Control + C, para outras teclas http://msdn.microsoft.com/pt-br/library/system.windows.forms.sendkeys.send.aspx
        }

        private void colarToolStripButton_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^(V)");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^(A)");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmAgendarEnviar>();
        }

        private void toolStripMenuItem24_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosQL>();
        }

        private void transferênciaOrganizaçãoBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosBJ>();
        }

        private void movimentoDeBackflushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosBF>();
        }

        private void toolStripMenuItem29_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtNFsComAlertas>();
        }

        private void nFTPorLoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFTporLote>();
        }

        private void toolStripMenuItem30_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNftNovas>();
        }

        private void nFTComREFDuplicadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNftNfsRefDuplicada>();
        }

        private void toolStripMenuItem31_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFtNFsItemDuplicado>();
        }

        private void toolStripMenuItem32_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNftAlteradas>();
        }

        private void toolStripMenuItem28_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosNFT>();
        }

        private void transferênciaTerceiroQKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosQK>();
        }

        private void nFSNovasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfsNovas>();
        }

        private void altaDeProdutoAcabadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosTI>();
        }

        private void transferênciaOrganizaçãoTJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosTJ>();
        }

        private void empresaExternaÁreaTransitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmEmpresaxAreaTransito>();
        }

        private void oPsAlteradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOPsAlteradas>();
        }

        private void toolStripMenuItem33_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNFeDiferenteNEM>();
        }

        private void impostoCalculadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosIC>();
        }

        private void toolStripMenuItem34_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmExecucoesInvalidas>();
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmRequisicaoComReserva>();
        }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutoscomAcerto>();
        }

        private void toolStripMenuItem37_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNemVariasNfe>();
        }

        private void toolStripMenuItem38_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeRecebimentoDiferente>();
        }

        private void toolStripMenuItem39_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmReservaMaiorNEM>();
        }

        private void toolStripMenuItem40_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNemDatasInvalidas>();
        }

        private void nEMNotaDeEntradaDeMateriaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNemGeral>();
        }

        private void toolStripMenuItem42_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmDicionarioProdutos>();
        }

        private void toolStripMenuItem43_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutosUndDiferente>();
        }

        private void toolStripMenuItem44_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOpComAlertas>();
        }

        private void toolStripMenuItem45_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOpDuplicada>();
        }

        private void toolStripMenuItem46_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutoscomAlertas>();
        }

        private void toolStripMenuItem47_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmLocationscomSaldo>();
        }

        private void ordemDeProduçãoOPToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmOpGeral>();
        }

        private void nFSSemAplicacaoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfsSemBaixa>();
        }

        private void toolStripMenuItem48_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfsDiferenteBaixa>();
        }

        private void baixaSemNFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBaixaSemNfs>();
        }

        private void toolStripMenuItem50_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfsAlteradas>();
        }

        private void toolStripMenuItem27_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosNFS>();
        }

        private void toolStripMenuItem26_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmBatimentosNS>();
        }

        private void parceirosNãoCadastradosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmParceirosCad>();
        }

        private void toolStripMenuItem51_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmParceirosComAlertas>();
        }

        private void toolStripMenuItem52_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmMiniFIFO>();
        }

        private void toolStripMenuItem53_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutosDetalhes>();
        }

        private void produtosComSaldoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmProdutoscomSaldo>();
        }

        private void devoluçõesInválidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmDevolucaoInvalida>();
        }

        private void toolStripMenuItem54_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmReservaProduto>();
        }

        private void empresasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmEmpresas>();
        }

        private void logsDeEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmLogDeEnvio>();
        }

        private void requisiçãoDeMateriaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmRequisicaoMaterial>();
        }

        private void notasDeSaídaNFTNFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNftNfsGeral>();
        }

        private void transferênciaDeEstoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfEstoque>();
        }

        private void reservasEAplicaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmReservasAplicacoes>();
        }

        private void unidadeFracionadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmUndFracionada>();
        }

        private void transferênciasExternasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfExternas>();
        }

        private void transfSemEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmTransfSemEntrada>();
        }

        private void toolStripMenuItem55_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNftNfsSemEntrada>();
        }

        private void toolStripMenuItem56_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmRomaneioGeral>();
        }

        private void toolStripMenuItem57_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeGeral>();
        }

        private void toolStripMenuItem58_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmEntradaFabricado>();
        }

        private void nFEForaDaINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmNfeForaDaIn>();
        }

        private void toolStripMenuItem59_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmFolhaServico>();
        }

        private void toolStripMenuItem60_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmAmbienteAgendado>();
        }

        private void reservasComFraçõesMínimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmFacoesMinimas>();
        }

        private void saldoReservaNegativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmSaldoReservaNeg>();
        }

        private void produtosFabricadosSemEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmFabricadoSemEntrada>();
        }

        private void toolStripMenuItem61_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmFabricadosComSaldo>();
        }

        private void toolStripMenuItem62_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmPlanilhao>();
        }

        private void saldoComFraçõesMínimasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.AbrirOuCriar<frmSaldoFacoesMinimas>();
        }
    }
}
