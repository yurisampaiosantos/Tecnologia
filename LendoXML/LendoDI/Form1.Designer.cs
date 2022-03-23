namespace LendoDI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btSalvarExcel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.aFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anumeroDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anumeroLI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anumeroAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aExportadorNomeAdição = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPaisAquisicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aFabricanteNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPaisOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNCMDescricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSeqMercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDescricaoMercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aQuantidadeMercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aUnidadeMercadoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVUCVMoeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVCMVMoeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVCMCMoedaAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVCMVValorAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVCMVIncontermAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDadosCoberturaCambial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aUnidadeAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPesoLiquidoAdicao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DadosMercadoriaPesoLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aOrigem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataDesembaraco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataEmbarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aDataChegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPesoBruto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPesoLiquido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVMLDUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVMLDBRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVMLEUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aVMLEBRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aMoedaFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aValorFreteUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aValorFreteMoeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aValorFreteBRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSeguroMoeda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSeguroUSD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSeguroMoedaCodigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aSeguroBRL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aQuantidadeVolumes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aEmbalagem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNumeroManifesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aArmazem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aRecintoAduaneiro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aInformacaoComplementar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aModalidadeDespacho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoDeclaracaoNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viaTransporteNome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viaTransporteNomeTransportador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viaTransporteNomeVeiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cofinsAliquotaAdValorem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iiAliquotaAdValorem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipiAliquotaAdValorem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pisPasepAliquotaAdValorem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Selecionar XML´s";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aFileName,
            this.anumeroDI,
            this.anumeroLI,
            this.anumeroAdicao,
            this.aExportadorNomeAdição,
            this.aPaisAquisicao,
            this.aFabricanteNome,
            this.aPaisOrigem,
            this.aNCM,
            this.aNCMDescricao,
            this.aSeqMercadoria,
            this.aDescricaoMercadoria,
            this.aQuantidadeMercadoria,
            this.aUnidadeMercadoria,
            this.aVUCVMoeda,
            this.aVCMVMoeda,
            this.aVCMCMoedaAdicao,
            this.aVCMVValorAdicao,
            this.aVCMVIncontermAdicao,
            this.aDadosCoberturaCambial,
            this.aUnidadeAdicao,
            this.aPesoLiquidoAdicao,
            this.DadosMercadoriaPesoLiquido,
            this.aDI,
            this.aOrigem,
            this.aDestino,
            this.aDataRegistro,
            this.aDataDesembaraco,
            this.aDataEmbarque,
            this.aDataChegada,
            this.aPesoBruto,
            this.aPesoLiquido,
            this.aVMLDUSD,
            this.aVMLDBRL,
            this.aVMLEUSD,
            this.aVMLEBRL,
            this.aMoedaFrete,
            this.aValorFreteUSD,
            this.aValorFreteMoeda,
            this.aValorFreteBRL,
            this.aSeguroMoeda,
            this.aSeguroUSD,
            this.aSeguroMoedaCodigo,
            this.aSeguroBRL,
            this.aQuantidadeVolumes,
            this.aEmbalagem,
            this.aNumeroManifesto,
            this.aArmazem,
            this.aRecintoAduaneiro,
            this.aInformacaoComplementar,
            this.aModalidadeDespacho,
            this.tipoDeclaracaoNome,
            this.viaTransporteNome,
            this.viaTransporteNomeTransportador,
            this.viaTransporteNomeVeiculo,
            this.cofinsAliquotaAdValorem,
            this.iiAliquotaAdValorem,
            this.ipiAliquotaAdValorem,
            this.pisPasepAliquotaAdValorem});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 356);
            this.dataGridView1.TabIndex = 1;
            // 
            // btSalvarExcel
            // 
            this.btSalvarExcel.Location = new System.Drawing.Point(372, 7);
            this.btSalvarExcel.Name = "btSalvarExcel";
            this.btSalvarExcel.Size = new System.Drawing.Size(193, 58);
            this.btSalvarExcel.TabIndex = 2;
            this.btSalvarExcel.Text = "Salvar em Excel";
            this.btSalvarExcel.UseVisualStyleBackColor = true;
            this.btSalvarExcel.Visible = false;
            this.btSalvarExcel.Click += new System.EventHandler(this.btSalvarExcel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 427);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(575, 22);
            this.progressBar1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btSalvarExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 71);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 356);
            this.panel2.TabIndex = 8;
            // 
            // aFileName
            // 
            this.aFileName.HeaderText = "FileName";
            this.aFileName.Name = "aFileName";
            this.aFileName.Width = 21;
            // 
            // anumeroDI
            // 
            this.anumeroDI.HeaderText = "numeroDI";
            this.anumeroDI.Name = "anumeroDI";
            this.anumeroDI.Width = 21;
            // 
            // anumeroLI
            // 
            this.anumeroLI.HeaderText = "numeroLI";
            this.anumeroLI.Name = "anumeroLI";
            this.anumeroLI.Width = 21;
            // 
            // anumeroAdicao
            // 
            this.anumeroAdicao.HeaderText = "numeroAdicao";
            this.anumeroAdicao.Name = "anumeroAdicao";
            this.anumeroAdicao.Width = 21;
            // 
            // aExportadorNomeAdição
            // 
            this.aExportadorNomeAdição.HeaderText = "ExportadorNomeAdicao";
            this.aExportadorNomeAdição.Name = "aExportadorNomeAdição";
            this.aExportadorNomeAdição.Width = 21;
            // 
            // aPaisAquisicao
            // 
            this.aPaisAquisicao.HeaderText = "PaisAquisicaoAdicao";
            this.aPaisAquisicao.Name = "aPaisAquisicao";
            this.aPaisAquisicao.Width = 21;
            // 
            // aFabricanteNome
            // 
            this.aFabricanteNome.HeaderText = "FabricanteNomeAdicao";
            this.aFabricanteNome.Name = "aFabricanteNome";
            this.aFabricanteNome.Width = 21;
            // 
            // aPaisOrigem
            // 
            this.aPaisOrigem.HeaderText = "PaisOrigemAdicao";
            this.aPaisOrigem.Name = "aPaisOrigem";
            this.aPaisOrigem.Width = 21;
            // 
            // aNCM
            // 
            this.aNCM.HeaderText = "NCM";
            this.aNCM.Name = "aNCM";
            this.aNCM.Width = 21;
            // 
            // aNCMDescricao
            // 
            this.aNCMDescricao.HeaderText = "NCMDescricao";
            this.aNCMDescricao.Name = "aNCMDescricao";
            this.aNCMDescricao.Width = 21;
            // 
            // aSeqMercadoria
            // 
            this.aSeqMercadoria.HeaderText = "SeqMercadoria";
            this.aSeqMercadoria.Name = "aSeqMercadoria";
            this.aSeqMercadoria.Width = 21;
            // 
            // aDescricaoMercadoria
            // 
            this.aDescricaoMercadoria.HeaderText = "DescricaoMercadoria";
            this.aDescricaoMercadoria.Name = "aDescricaoMercadoria";
            this.aDescricaoMercadoria.Width = 21;
            // 
            // aQuantidadeMercadoria
            // 
            this.aQuantidadeMercadoria.HeaderText = "QuantidadeMercadoria";
            this.aQuantidadeMercadoria.Name = "aQuantidadeMercadoria";
            this.aQuantidadeMercadoria.Width = 21;
            // 
            // aUnidadeMercadoria
            // 
            this.aUnidadeMercadoria.HeaderText = "UnidadeMercadoria";
            this.aUnidadeMercadoria.Name = "aUnidadeMercadoria";
            this.aUnidadeMercadoria.Width = 21;
            // 
            // aVUCVMoeda
            // 
            this.aVUCVMoeda.HeaderText = "VUCVMercadoriaMoeda";
            this.aVUCVMoeda.Name = "aVUCVMoeda";
            this.aVUCVMoeda.Width = 21;
            // 
            // aVCMVMoeda
            // 
            this.aVCMVMoeda.HeaderText = "VCMVMoedaAdicao";
            this.aVCMVMoeda.Name = "aVCMVMoeda";
            this.aVCMVMoeda.Width = 21;
            // 
            // aVCMCMoedaAdicao
            // 
            this.aVCMCMoedaAdicao.HeaderText = "VCMVValorMoedaAdicao";
            this.aVCMCMoedaAdicao.Name = "aVCMCMoedaAdicao";
            this.aVCMCMoedaAdicao.Width = 21;
            // 
            // aVCMVValorAdicao
            // 
            this.aVCMVValorAdicao.HeaderText = "VCMVValorBRLAdicao";
            this.aVCMVValorAdicao.Name = "aVCMVValorAdicao";
            this.aVCMVValorAdicao.Width = 21;
            // 
            // aVCMVIncontermAdicao
            // 
            this.aVCMVIncontermAdicao.HeaderText = "IncontermAdicao";
            this.aVCMVIncontermAdicao.Name = "aVCMVIncontermAdicao";
            this.aVCMVIncontermAdicao.Width = 21;
            // 
            // aDadosCoberturaCambial
            // 
            this.aDadosCoberturaCambial.HeaderText = "DadosCoberturaCambial";
            this.aDadosCoberturaCambial.Name = "aDadosCoberturaCambial";
            this.aDadosCoberturaCambial.Width = 21;
            // 
            // aUnidadeAdicao
            // 
            this.aUnidadeAdicao.HeaderText = "UnidadeAdicao";
            this.aUnidadeAdicao.Name = "aUnidadeAdicao";
            this.aUnidadeAdicao.Width = 21;
            // 
            // aPesoLiquidoAdicao
            // 
            this.aPesoLiquidoAdicao.HeaderText = "PesoLiquidoAdicao";
            this.aPesoLiquidoAdicao.Name = "aPesoLiquidoAdicao";
            this.aPesoLiquidoAdicao.Width = 21;
            // 
            // DadosMercadoriaPesoLiquido
            // 
            this.DadosMercadoriaPesoLiquido.HeaderText = "DadosMercadoriaPesoLiquido";
            this.DadosMercadoriaPesoLiquido.Name = "DadosMercadoriaPesoLiquido";
            this.DadosMercadoriaPesoLiquido.Width = 21;
            // 
            // aDI
            // 
            this.aDI.HeaderText = "DI";
            this.aDI.Name = "aDI";
            this.aDI.Width = 21;
            // 
            // aOrigem
            // 
            this.aOrigem.HeaderText = "Origem";
            this.aOrigem.Name = "aOrigem";
            this.aOrigem.Width = 21;
            // 
            // aDestino
            // 
            this.aDestino.HeaderText = "Destino";
            this.aDestino.Name = "aDestino";
            this.aDestino.Width = 21;
            // 
            // aDataRegistro
            // 
            this.aDataRegistro.HeaderText = "DataRegistro";
            this.aDataRegistro.Name = "aDataRegistro";
            this.aDataRegistro.Width = 21;
            // 
            // aDataDesembaraco
            // 
            this.aDataDesembaraco.HeaderText = "DataDesembaraco";
            this.aDataDesembaraco.Name = "aDataDesembaraco";
            this.aDataDesembaraco.Width = 21;
            // 
            // aDataEmbarque
            // 
            this.aDataEmbarque.HeaderText = "DataEmbarque";
            this.aDataEmbarque.Name = "aDataEmbarque";
            this.aDataEmbarque.Width = 21;
            // 
            // aDataChegada
            // 
            this.aDataChegada.HeaderText = "DataChegada";
            this.aDataChegada.Name = "aDataChegada";
            this.aDataChegada.Width = 21;
            // 
            // aPesoBruto
            // 
            this.aPesoBruto.HeaderText = "PesoBrutoDI";
            this.aPesoBruto.Name = "aPesoBruto";
            this.aPesoBruto.Width = 21;
            // 
            // aPesoLiquido
            // 
            this.aPesoLiquido.HeaderText = "PesoLiquidoDI";
            this.aPesoLiquido.Name = "aPesoLiquido";
            this.aPesoLiquido.Width = 21;
            // 
            // aVMLDUSD
            // 
            this.aVMLDUSD.HeaderText = "VMLDUSD";
            this.aVMLDUSD.Name = "aVMLDUSD";
            this.aVMLDUSD.Width = 21;
            // 
            // aVMLDBRL
            // 
            this.aVMLDBRL.HeaderText = "VMLDBRL";
            this.aVMLDBRL.Name = "aVMLDBRL";
            this.aVMLDBRL.Width = 21;
            // 
            // aVMLEUSD
            // 
            this.aVMLEUSD.HeaderText = "VMLEUSD";
            this.aVMLEUSD.Name = "aVMLEUSD";
            this.aVMLEUSD.Width = 21;
            // 
            // aVMLEBRL
            // 
            this.aVMLEBRL.HeaderText = "VMLEBRL";
            this.aVMLEBRL.Name = "aVMLEBRL";
            this.aVMLEBRL.Width = 21;
            // 
            // aMoedaFrete
            // 
            this.aMoedaFrete.HeaderText = "MoedaFrete";
            this.aMoedaFrete.Name = "aMoedaFrete";
            this.aMoedaFrete.Width = 21;
            // 
            // aValorFreteUSD
            // 
            this.aValorFreteUSD.HeaderText = "ValorFreteUSD";
            this.aValorFreteUSD.Name = "aValorFreteUSD";
            this.aValorFreteUSD.Width = 21;
            // 
            // aValorFreteMoeda
            // 
            this.aValorFreteMoeda.HeaderText = "ValorFreteMoeda";
            this.aValorFreteMoeda.Name = "aValorFreteMoeda";
            this.aValorFreteMoeda.Width = 21;
            // 
            // aValorFreteBRL
            // 
            this.aValorFreteBRL.HeaderText = "ValorFreteBRL";
            this.aValorFreteBRL.Name = "aValorFreteBRL";
            this.aValorFreteBRL.Width = 21;
            // 
            // aSeguroMoeda
            // 
            this.aSeguroMoeda.HeaderText = "SeguroMoeda";
            this.aSeguroMoeda.Name = "aSeguroMoeda";
            this.aSeguroMoeda.Width = 21;
            // 
            // aSeguroUSD
            // 
            this.aSeguroUSD.HeaderText = "SeguroUSD";
            this.aSeguroUSD.Name = "aSeguroUSD";
            this.aSeguroUSD.Width = 21;
            // 
            // aSeguroMoedaCodigo
            // 
            this.aSeguroMoedaCodigo.HeaderText = "SeguroMoedaCodigo";
            this.aSeguroMoedaCodigo.Name = "aSeguroMoedaCodigo";
            this.aSeguroMoedaCodigo.Width = 21;
            // 
            // aSeguroBRL
            // 
            this.aSeguroBRL.HeaderText = "SeguroBRL";
            this.aSeguroBRL.Name = "aSeguroBRL";
            this.aSeguroBRL.Width = 21;
            // 
            // aQuantidadeVolumes
            // 
            this.aQuantidadeVolumes.HeaderText = "QuantidadeVolumes";
            this.aQuantidadeVolumes.Name = "aQuantidadeVolumes";
            this.aQuantidadeVolumes.Width = 21;
            // 
            // aEmbalagem
            // 
            this.aEmbalagem.HeaderText = "Embalagem";
            this.aEmbalagem.Name = "aEmbalagem";
            this.aEmbalagem.Width = 21;
            // 
            // aNumeroManifesto
            // 
            this.aNumeroManifesto.HeaderText = "NumeroManifesto";
            this.aNumeroManifesto.Name = "aNumeroManifesto";
            this.aNumeroManifesto.Width = 21;
            // 
            // aArmazem
            // 
            this.aArmazem.HeaderText = "Armazem";
            this.aArmazem.Name = "aArmazem";
            this.aArmazem.Width = 21;
            // 
            // aRecintoAduaneiro
            // 
            this.aRecintoAduaneiro.HeaderText = "RecintoAduaneiro";
            this.aRecintoAduaneiro.Name = "aRecintoAduaneiro";
            this.aRecintoAduaneiro.Width = 21;
            // 
            // aInformacaoComplementar
            // 
            this.aInformacaoComplementar.HeaderText = "InformacaoComplementar";
            this.aInformacaoComplementar.Name = "aInformacaoComplementar";
            this.aInformacaoComplementar.Width = 21;
            // 
            // aModalidadeDespacho
            // 
            this.aModalidadeDespacho.HeaderText = "ModalidadeDespacho";
            this.aModalidadeDespacho.Name = "aModalidadeDespacho";
            this.aModalidadeDespacho.Width = 21;
            // 
            // tipoDeclaracaoNome
            // 
            this.tipoDeclaracaoNome.HeaderText = "tipoDeclaracaoNome";
            this.tipoDeclaracaoNome.Name = "tipoDeclaracaoNome";
            this.tipoDeclaracaoNome.Width = 21;
            // 
            // viaTransporteNome
            // 
            this.viaTransporteNome.HeaderText = "Modal";
            this.viaTransporteNome.Name = "viaTransporteNome";
            this.viaTransporteNome.Width = 21;
            // 
            // viaTransporteNomeTransportador
            // 
            this.viaTransporteNomeTransportador.HeaderText = "NomeTransportador";
            this.viaTransporteNomeTransportador.Name = "viaTransporteNomeTransportador";
            this.viaTransporteNomeTransportador.Width = 21;
            // 
            // viaTransporteNomeVeiculo
            // 
            this.viaTransporteNomeVeiculo.HeaderText = "NomeVeiculo";
            this.viaTransporteNomeVeiculo.Name = "viaTransporteNomeVeiculo";
            this.viaTransporteNomeVeiculo.Width = 21;
            // 
            // cofinsAliquotaAdValorem
            // 
            this.cofinsAliquotaAdValorem.HeaderText = "cofinsAliquotaAdValorem";
            this.cofinsAliquotaAdValorem.Name = "cofinsAliquotaAdValorem";
            this.cofinsAliquotaAdValorem.Width = 21;
            // 
            // iiAliquotaAdValorem
            // 
            this.iiAliquotaAdValorem.HeaderText = "iiAliquotaAdValorem";
            this.iiAliquotaAdValorem.Name = "iiAliquotaAdValorem";
            this.iiAliquotaAdValorem.Width = 21;
            // 
            // ipiAliquotaAdValorem
            // 
            this.ipiAliquotaAdValorem.HeaderText = "ipiAliquotaAdValorem";
            this.ipiAliquotaAdValorem.Name = "ipiAliquotaAdValorem";
            this.ipiAliquotaAdValorem.Width = 21;
            // 
            // pisPasepAliquotaAdValorem
            // 
            this.pisPasepAliquotaAdValorem.HeaderText = "pisPasepAliquotaAdValorem";
            this.pisPasepAliquotaAdValorem.Name = "pisPasepAliquotaAdValorem";
            this.pisPasepAliquotaAdValorem.Width = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Captura dados DI - V.1.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btSalvarExcel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn aFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn anumeroDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn anumeroLI;
        private System.Windows.Forms.DataGridViewTextBoxColumn anumeroAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aExportadorNomeAdição;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPaisAquisicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aFabricanteNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPaisOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNCMDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSeqMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDescricaoMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn aQuantidadeMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUnidadeMercadoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVUCVMoeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVCMVMoeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVCMCMoedaAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVCMVValorAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVCMVIncontermAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDadosCoberturaCambial;
        private System.Windows.Forms.DataGridViewTextBoxColumn aUnidadeAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPesoLiquidoAdicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DadosMercadoriaPesoLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDI;
        private System.Windows.Forms.DataGridViewTextBoxColumn aOrigem;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataDesembaraco;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataEmbarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn aDataChegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPesoBruto;
        private System.Windows.Forms.DataGridViewTextBoxColumn aPesoLiquido;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVMLDUSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVMLDBRL;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVMLEUSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn aVMLEBRL;
        private System.Windows.Forms.DataGridViewTextBoxColumn aMoedaFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn aValorFreteUSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn aValorFreteMoeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn aValorFreteBRL;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSeguroMoeda;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSeguroUSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSeguroMoedaCodigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn aSeguroBRL;
        private System.Windows.Forms.DataGridViewTextBoxColumn aQuantidadeVolumes;
        private System.Windows.Forms.DataGridViewTextBoxColumn aEmbalagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNumeroManifesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn aArmazem;
        private System.Windows.Forms.DataGridViewTextBoxColumn aRecintoAduaneiro;
        private System.Windows.Forms.DataGridViewTextBoxColumn aInformacaoComplementar;
        private System.Windows.Forms.DataGridViewTextBoxColumn aModalidadeDespacho;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoDeclaracaoNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn viaTransporteNome;
        private System.Windows.Forms.DataGridViewTextBoxColumn viaTransporteNomeTransportador;
        private System.Windows.Forms.DataGridViewTextBoxColumn viaTransporteNomeVeiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn cofinsAliquotaAdValorem;
        private System.Windows.Forms.DataGridViewTextBoxColumn iiAliquotaAdValorem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipiAliquotaAdValorem;
        private System.Windows.Forms.DataGridViewTextBoxColumn pisPasepAliquotaAdValorem;
    }
}

