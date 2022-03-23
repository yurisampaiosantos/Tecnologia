namespace SisPLAN.net
{
    partial class MdiSisplan
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
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Relatorios;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdiSisplan));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.VincularGrupoCriterio = new System.Windows.Forms.ToolStripMenuItem();
            this.SisplanMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.RAM = new System.Windows.Forms.ToolStripMenuItem();
            this.VincularGrupoCritério = new System.Windows.Forms.ToolStripMenuItem();
            this.Relatorios = new System.Windows.Forms.ToolStripMenuItem();
            this.AgrupamentoMateriais = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusMateriais = new System.Windows.Forms.ToolStripMenuItem();
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PendenciaMateriais = new System.Windows.Forms.ToolStripMenuItem();
            this.RecebimentoMateriais = new System.Windows.Forms.ToolStripMenuItem();
            this.CelulasDeTrabalho = new System.Windows.Forms.ToolStripMenuItem();
            this.CelulasTrabalhoResumo = new System.Windows.Forms.ToolStripMenuItem();
            this.ControleFolhaServico = new System.Windows.Forms.ToolStripMenuItem();
            this.importaItensControle = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoSemanalDeAtividades = new System.Windows.Forms.ToolStripMenuItem();
            this.MontagemTubulacaoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acuracidadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaCorridaDeMateriaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materiaisPendentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spoolsPendentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TubulacaoStatusFabricacao = new System.Windows.Forms.ToolStripMenuItem();
            this.EstoqueDeMateriaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtividadePorUAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comissionamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanhaPunchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaPastasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaMovimentoDePastasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.punchListDasPastasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoDePastasPorDisciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaPastasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaPunchListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eletricaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaControleGeralEITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.completaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.avancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.xSairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VincularGrupoCriterio,
            this.Relatorios,
            this.CelulasDeTrabalho,
            this.gerenciaisToolStripMenuItem,
            this.comissionamentoToolStripMenuItem,
            this.eletricaToolStripMenuItem,
            this.completaçãoToolStripMenuItem,
            this.xSairToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1196, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // VincularGrupoCriterio
            // 
            this.VincularGrupoCriterio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SisplanMonitor,
            this.RAM,
            this.VincularGrupoCritério});
            this.VincularGrupoCriterio.Name = "VincularGrupoCriterio";
            this.VincularGrupoCriterio.Size = new System.Drawing.Size(64, 20);
            this.VincularGrupoCriterio.Text = "SISPLAN";
            // 
            // SisplanMonitor
            // 
            this.SisplanMonitor.Name = "SisplanMonitor";
            this.SisplanMonitor.Size = new System.Drawing.Size(342, 22);
            this.SisplanMonitor.Text = "SISPLAN Monitor";
            this.SisplanMonitor.Click += new System.EventHandler(this.SisplanMonitor_Click);
            // 
            // RAM
            // 
            this.RAM.Name = "RAM";
            this.RAM.Size = new System.Drawing.Size(342, 22);
            this.RAM.Text = "RAM - Relatório de Acompanhamento de Medição";
            this.RAM.Click += new System.EventHandler(this.RAM_Click);
            // 
            // VincularGrupoCritério
            // 
            this.VincularGrupoCritério.Name = "VincularGrupoCritério";
            this.VincularGrupoCritério.Size = new System.Drawing.Size(342, 22);
            this.VincularGrupoCritério.Text = "Vincular Grupo Critério";
            this.VincularGrupoCritério.Click += new System.EventHandler(this.VincularGrupoCritério_Click);
            // 
            // Relatorios
            // 
            this.Relatorios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AgrupamentoMateriais,
            this.StatusMateriais,
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem,
            this.PendenciaMateriais,
            this.RecebimentoMateriais});
            this.Relatorios.Name = "Relatorios";
            this.Relatorios.Size = new System.Drawing.Size(67, 20);
            this.Relatorios.Text = "Materiais";
            // 
            // AgrupamentoMateriais
            // 
            this.AgrupamentoMateriais.Name = "AgrupamentoMateriais";
            this.AgrupamentoMateriais.Size = new System.Drawing.Size(296, 22);
            this.AgrupamentoMateriais.Text = "Agrupamento de Materiais (FOSE)";
            this.AgrupamentoMateriais.Click += new System.EventHandler(this.AgrupamentoMateriais_Click);
            // 
            // StatusMateriais
            // 
            this.StatusMateriais.Name = "StatusMateriais";
            this.StatusMateriais.Size = new System.Drawing.Size(296, 22);
            this.StatusMateriais.Text = "Status de Materiais";
            this.StatusMateriais.Click += new System.EventHandler(this.StatusMateriais_Click);
            // 
            // importaMateriaisPROJEMARTubulaçãoToolStripMenuItem
            // 
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem.Name = "importaMateriaisPROJEMARTubulaçãoToolStripMenuItem";
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem.Text = "Importa Materiais PROJEMAR - Tubulação";
            this.importaMateriaisPROJEMARTubulaçãoToolStripMenuItem.Click += new System.EventHandler(this.ImportaMateriaisTubulacao);
            // 
            // PendenciaMateriais
            // 
            this.PendenciaMateriais.Name = "PendenciaMateriais";
            this.PendenciaMateriais.Size = new System.Drawing.Size(296, 22);
            this.PendenciaMateriais.Text = "Pendência de Materiais";
            this.PendenciaMateriais.Visible = false;
            this.PendenciaMateriais.Click += new System.EventHandler(this.PendenciaMateriais_Click);
            // 
            // RecebimentoMateriais
            // 
            this.RecebimentoMateriais.Name = "RecebimentoMateriais";
            this.RecebimentoMateriais.Size = new System.Drawing.Size(296, 22);
            this.RecebimentoMateriais.Text = "Recebimento de Materiais";
            this.RecebimentoMateriais.Click += new System.EventHandler(this.RecebimentoMateriais_Click);
            // 
            // CelulasDeTrabalho
            // 
            this.CelulasDeTrabalho.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CelulasTrabalhoResumo,
            this.ControleFolhaServico,
            this.importaItensControle,
            this.resumoSemanalDeAtividades,
            this.MontagemTubulacaoToolStripMenuItem});
            this.CelulasDeTrabalho.Name = "CelulasDeTrabalho";
            this.CelulasDeTrabalho.Size = new System.Drawing.Size(123, 20);
            this.CelulasDeTrabalho.Text = "Células de Trabalho";
            // 
            // CelulasTrabalhoResumo
            // 
            this.CelulasTrabalhoResumo.Name = "CelulasTrabalhoResumo";
            this.CelulasTrabalhoResumo.Size = new System.Drawing.Size(239, 22);
            this.CelulasTrabalhoResumo.Text = "Células de Trabalho - Resumo";
            this.CelulasTrabalhoResumo.Click += new System.EventHandler(this.CelulasTrabalhoResumo_Click);
            // 
            // ControleFolhaServico
            // 
            this.ControleFolhaServico.Name = "ControleFolhaServico";
            this.ControleFolhaServico.Size = new System.Drawing.Size(239, 22);
            this.ControleFolhaServico.Text = "Controle Folhas Servico";
            this.ControleFolhaServico.Click += new System.EventHandler(this.ControleFolhaServico_Click);
            // 
            // importaItensControle
            // 
            this.importaItensControle.Name = "importaItensControle";
            this.importaItensControle.Size = new System.Drawing.Size(239, 22);
            this.importaItensControle.Text = "Importa Itens Controle";
            this.importaItensControle.Click += new System.EventHandler(this.ImportaItensControle_Click);
            // 
            // resumoSemanalDeAtividades
            // 
            this.resumoSemanalDeAtividades.Name = "resumoSemanalDeAtividades";
            this.resumoSemanalDeAtividades.Size = new System.Drawing.Size(239, 22);
            this.resumoSemanalDeAtividades.Text = "Resumo Semanal de Atividades";
            this.resumoSemanalDeAtividades.Click += new System.EventHandler(this.ResumoSemanalAtividades_Click);
            // 
            // MontagemTubulacaoToolStripMenuItem
            // 
            this.MontagemTubulacaoToolStripMenuItem.Name = "MontagemTubulacaoToolStripMenuItem";
            this.MontagemTubulacaoToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.MontagemTubulacaoToolStripMenuItem.Text = "Montagem Tubulações";
            this.MontagemTubulacaoToolStripMenuItem.Click += new System.EventHandler(this.MontagemTubulacaoToolStripMenuItem_Click);
            // 
            // gerenciaisToolStripMenuItem
            // 
            this.gerenciaisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acuracidadeToolStripMenuItem,
            this.importaCorridaDeMateriaisToolStripMenuItem,
            this.materiaisPendentesToolStripMenuItem,
            this.spoolsPendentesToolStripMenuItem,
            this.TubulacaoStatusFabricacao,
            this.EstoqueDeMateriaisToolStripMenuItem,
            this.produtividadePorUAToolStripMenuItem});
            this.gerenciaisToolStripMenuItem.Name = "gerenciaisToolStripMenuItem";
            this.gerenciaisToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.gerenciaisToolStripMenuItem.Text = "Análises Gerenciais";
            // 
            // acuracidadeToolStripMenuItem
            // 
            this.acuracidadeToolStripMenuItem.Name = "acuracidadeToolStripMenuItem";
            this.acuracidadeToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.acuracidadeToolStripMenuItem.Text = "Acuracidade";
            this.acuracidadeToolStripMenuItem.Click += new System.EventHandler(this.acuracidadeToolStripMenuItem_Click);
            // 
            // importaCorridaDeMateriaisToolStripMenuItem
            // 
            this.importaCorridaDeMateriaisToolStripMenuItem.Name = "importaCorridaDeMateriaisToolStripMenuItem";
            this.importaCorridaDeMateriaisToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.importaCorridaDeMateriaisToolStripMenuItem.Text = "Importa Corrida de Materiais";
            this.importaCorridaDeMateriaisToolStripMenuItem.Click += new System.EventHandler(this.ImportaCorridaMateriais_Click);
            // 
            // materiaisPendentesToolStripMenuItem
            // 
            this.materiaisPendentesToolStripMenuItem.Name = "materiaisPendentesToolStripMenuItem";
            this.materiaisPendentesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.materiaisPendentesToolStripMenuItem.Text = "Materiais Pendentes";
            this.materiaisPendentesToolStripMenuItem.Click += new System.EventHandler(this.materiaisPendentesToolStripMenuItem_Click);
            // 
            // spoolsPendentesToolStripMenuItem
            // 
            this.spoolsPendentesToolStripMenuItem.Name = "spoolsPendentesToolStripMenuItem";
            this.spoolsPendentesToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.spoolsPendentesToolStripMenuItem.Text = "Spools Pendentes";
            this.spoolsPendentesToolStripMenuItem.Click += new System.EventHandler(this.spoolsPendentesToolStripMenuItem_Click);
            // 
            // TubulacaoStatusFabricacao
            // 
            this.TubulacaoStatusFabricacao.Name = "TubulacaoStatusFabricacao";
            this.TubulacaoStatusFabricacao.Size = new System.Drawing.Size(225, 22);
            this.TubulacaoStatusFabricacao.Text = "Status de Tubulação";
            this.TubulacaoStatusFabricacao.Click += new System.EventHandler(this.StatusTubulacao_Click);
            // 
            // EstoqueDeMateriaisToolStripMenuItem
            // 
            this.EstoqueDeMateriaisToolStripMenuItem.Name = "EstoqueDeMateriaisToolStripMenuItem";
            this.EstoqueDeMateriaisToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.EstoqueDeMateriaisToolStripMenuItem.Text = "Estoque de Materiais";
            this.EstoqueDeMateriaisToolStripMenuItem.Click += new System.EventHandler(this.EstoqueDeMateriaisToolStripMenuItem_Click);
            // 
            // produtividadePorUAToolStripMenuItem
            // 
            this.produtividadePorUAToolStripMenuItem.Name = "produtividadePorUAToolStripMenuItem";
            this.produtividadePorUAToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.produtividadePorUAToolStripMenuItem.Text = "&Produtividade por UA";
            this.produtividadePorUAToolStripMenuItem.Click += new System.EventHandler(this.produtividadePorUAToolStripMenuItem_Click);
            // 
            // comissionamentoToolStripMenuItem
            // 
            this.comissionamentoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acompanhaPunchListToolStripMenuItem,
            this.movimentaPastasToolStripMenuItem,
            this.listaMovimentoDePastasToolStripMenuItem,
            this.punchListDasPastasToolStripMenuItem,
            this.resumoDePastasPorDisciplinaToolStripMenuItem,
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem,
            this.importaPastasToolStripMenuItem,
            this.importaPunchListToolStripMenuItem});
            this.comissionamentoToolStripMenuItem.Name = "comissionamentoToolStripMenuItem";
            this.comissionamentoToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.comissionamentoToolStripMenuItem.Text = "Comissionamento";
            // 
            // acompanhaPunchListToolStripMenuItem
            // 
            this.acompanhaPunchListToolStripMenuItem.Name = "acompanhaPunchListToolStripMenuItem";
            this.acompanhaPunchListToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.acompanhaPunchListToolStripMenuItem.Text = "Acompanha Punch List";
            this.acompanhaPunchListToolStripMenuItem.Click += new System.EventHandler(this.acompanhaPunchListToolStripMenuItem_Click);
            // 
            // movimentaPastasToolStripMenuItem
            // 
            this.movimentaPastasToolStripMenuItem.Name = "movimentaPastasToolStripMenuItem";
            this.movimentaPastasToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.movimentaPastasToolStripMenuItem.Text = "Movimenta Pastas";
            this.movimentaPastasToolStripMenuItem.Click += new System.EventHandler(this.movimentaPastasToolStripMenuItem_Click);
            // 
            // listaMovimentoDePastasToolStripMenuItem
            // 
            this.listaMovimentoDePastasToolStripMenuItem.Name = "listaMovimentoDePastasToolStripMenuItem";
            this.listaMovimentoDePastasToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.listaMovimentoDePastasToolStripMenuItem.Text = "Lista Movimento de Pastas";
            this.listaMovimentoDePastasToolStripMenuItem.Click += new System.EventHandler(this.listaMovimentoDePastasToolStripMenuItem_Click);
            // 
            // punchListDasPastasToolStripMenuItem
            // 
            this.punchListDasPastasToolStripMenuItem.Name = "punchListDasPastasToolStripMenuItem";
            this.punchListDasPastasToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.punchListDasPastasToolStripMenuItem.Text = "Punch List das Pastas";
            this.punchListDasPastasToolStripMenuItem.Click += new System.EventHandler(this.punchListDasPastasToolStripMenuItem_Click);
            // 
            // resumoDePastasPorDisciplinaToolStripMenuItem
            // 
            this.resumoDePastasPorDisciplinaToolStripMenuItem.Name = "resumoDePastasPorDisciplinaToolStripMenuItem";
            this.resumoDePastasPorDisciplinaToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.resumoDePastasPorDisciplinaToolStripMenuItem.Text = "Resumo de Pastas";
            this.resumoDePastasPorDisciplinaToolStripMenuItem.Click += new System.EventHandler(this.resumoDePastasToolStripMenuItem_Click);
            // 
            // resumoDePastasÁreaDisciplinaToolStripMenuItem
            // 
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem.Name = "resumoDePastasÁreaDisciplinaToolStripMenuItem";
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem.Text = "Resumo de Pastas Área/Disciplina";
            this.resumoDePastasÁreaDisciplinaToolStripMenuItem.Click += new System.EventHandler(this.resumoDePastasÁreaDisciplinaToolStripMenuItem_Click);
            // 
            // importaPastasToolStripMenuItem
            // 
            this.importaPastasToolStripMenuItem.Name = "importaPastasToolStripMenuItem";
            this.importaPastasToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.importaPastasToolStripMenuItem.Text = "Importa Pastas";
            this.importaPastasToolStripMenuItem.Click += new System.EventHandler(this.importaPastasToolStripMenuItem_Click);
            // 
            // importaPunchListToolStripMenuItem
            // 
            this.importaPunchListToolStripMenuItem.Name = "importaPunchListToolStripMenuItem";
            this.importaPunchListToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.importaPunchListToolStripMenuItem.Text = "Importa Punch List";
            this.importaPunchListToolStripMenuItem.Visible = false;
            this.importaPunchListToolStripMenuItem.Click += new System.EventHandler(this.importaPunchListToolStripMenuItem_Click);
            // 
            // eletricaToolStripMenuItem
            // 
            this.eletricaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importaControleGeralEITToolStripMenuItem});
            this.eletricaToolStripMenuItem.Name = "eletricaToolStripMenuItem";
            this.eletricaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.eletricaToolStripMenuItem.Text = "Elétrica";
            // 
            // importaControleGeralEITToolStripMenuItem
            // 
            this.importaControleGeralEITToolStripMenuItem.Name = "importaControleGeralEITToolStripMenuItem";
            this.importaControleGeralEITToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.importaControleGeralEITToolStripMenuItem.Text = "Importa Controle Geral EIT";
            this.importaControleGeralEITToolStripMenuItem.Click += new System.EventHandler(this.importaControleGeralEITToolStripMenuItem_Click);
            // 
            // completaçãoToolStripMenuItem
            // 
            this.completaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avancosToolStripMenuItem});
            this.completaçãoToolStripMenuItem.Name = "completaçãoToolStripMenuItem";
            this.completaçãoToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.completaçãoToolStripMenuItem.Text = "Completação";
            // 
            // avancosToolStripMenuItem
            // 
            this.avancosToolStripMenuItem.Name = "avancosToolStripMenuItem";
            this.avancosToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.avancosToolStripMenuItem.Text = "Avanços";
            this.avancosToolStripMenuItem.Click += new System.EventHandler(this.avancosToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 730);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1196, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(81, 17);
            this.toolStripStatusLabel1.Text = "Versão: 1.0.0.0";
            // 
            // xSairToolStripMenuItem
            // 
            this.xSairToolStripMenuItem.Name = "xSairToolStripMenuItem";
            this.xSairToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.xSairToolStripMenuItem.Text = "&X Sair";
            this.xSairToolStripMenuItem.Click += new System.EventHandler(this.xSairToolStripMenuItem_Click);
            // 
            // MdiSisplan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SisPLAN.net.Properties.Resources.wallpaper34;
            this.ClientSize = new System.Drawing.Size(1196, 752);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MdiSisplan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SisPlan - Sistema de Apoio ao Planejamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MdiSisplan_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem RecebimentoMateriais;
        private System.Windows.Forms.ToolStripMenuItem PendenciaMateriais;
        private System.Windows.Forms.ToolStripMenuItem CelulasDeTrabalho;
        private System.Windows.Forms.ToolStripMenuItem CelulasTrabalhoResumo;
        private System.Windows.Forms.ToolStripMenuItem ControleFolhaServico;
        private System.Windows.Forms.ToolStripMenuItem importaItensControle;
        private System.Windows.Forms.ToolStripMenuItem VincularGrupoCriterio;
        private System.Windows.Forms.ToolStripMenuItem SisplanMonitor;
        private System.Windows.Forms.ToolStripMenuItem resumoSemanalDeAtividades;
        private System.Windows.Forms.ToolStripMenuItem RAM;
        private System.Windows.Forms.ToolStripMenuItem AgrupamentoMateriais;
        private System.Windows.Forms.ToolStripMenuItem importaMateriaisPROJEMARTubulaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StatusMateriais;
        private System.Windows.Forms.ToolStripMenuItem VincularGrupoCritério;
        private System.Windows.Forms.ToolStripMenuItem gerenciaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TubulacaoStatusFabricacao;
        private System.Windows.Forms.ToolStripMenuItem importaCorridaDeMateriaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spoolsPendentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem materiaisPendentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acuracidadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EstoqueDeMateriaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MontagemTubulacaoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comissionamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaPastasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaPastasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaMovimentoDePastasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem punchListDasPastasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoDePastasPorDisciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eletricaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaControleGeralEITToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem avancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumoDePastasÁreaDisciplinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaPunchListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acompanhaPunchListToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem produtividadePorUAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xSairToolStripMenuItem;

    }
}