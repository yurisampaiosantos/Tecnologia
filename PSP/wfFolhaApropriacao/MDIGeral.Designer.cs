namespace wfFolhaApropriacao
{
    partial class MDIGeral
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">verdade se for necessário descartar os recursos gerenciados; caso contrário, falso.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte do Designer - não modifique
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIGeral));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.apropriarHorasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importaçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.funcionáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.novosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faltaRHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atividadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoDiáriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoDiáriaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.apropriaçãoPorPeríodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtividadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gerenciarContasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xSairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.importaçõesToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.xSairToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1084, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apropriarHorasToolStripMenuItem});
            this.fileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(90, 20);
            this.fileMenu.Text = "&Lançamentos";
            // 
            // apropriarHorasToolStripMenuItem
            // 
            this.apropriarHorasToolStripMenuItem.Name = "apropriarHorasToolStripMenuItem";
            this.apropriarHorasToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.apropriarHorasToolStripMenuItem.Text = "&Apropriação de Horas";
            this.apropriarHorasToolStripMenuItem.Click += new System.EventHandler(this.apropriarHorasToolStripMenuItem_Click);
            // 
            // importaçõesToolStripMenuItem
            // 
            this.importaçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.funcionáriosToolStripMenuItem,
            this.atividadesToolStripMenuItem});
            this.importaçõesToolStripMenuItem.Name = "importaçõesToolStripMenuItem";
            this.importaçõesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.importaçõesToolStripMenuItem.Text = "&Importações";
            // 
            // funcionáriosToolStripMenuItem
            // 
            this.funcionáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novosToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.faltaRHToolStripMenuItem});
            this.funcionáriosToolStripMenuItem.Name = "funcionáriosToolStripMenuItem";
            this.funcionáriosToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.funcionáriosToolStripMenuItem.Text = "&Funcionários";
            // 
            // novosToolStripMenuItem
            // 
            this.novosToolStripMenuItem.Name = "novosToolStripMenuItem";
            this.novosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.novosToolStripMenuItem.Text = "&Cadastrar / Atualizar";
            this.novosToolStripMenuItem.Click += new System.EventHandler(this.novosToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.statusToolStripMenuItem.Text = "&Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // faltaRHToolStripMenuItem
            // 
            this.faltaRHToolStripMenuItem.Name = "faltaRHToolStripMenuItem";
            this.faltaRHToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.faltaRHToolStripMenuItem.Text = "&Faltas RH";
            this.faltaRHToolStripMenuItem.Click += new System.EventHandler(this.faltaRHToolStripMenuItem_Click);
            // 
            // atividadesToolStripMenuItem
            // 
            this.atividadesToolStripMenuItem.Enabled = false;
            this.atividadesToolStripMenuItem.Name = "atividadesToolStripMenuItem";
            this.atividadesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.atividadesToolStripMenuItem.Text = "&UAs - Atividades";
            this.atividadesToolStripMenuItem.Click += new System.EventHandler(this.atividadesToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimentaçãoDiáriaToolStripMenuItem,
            this.toolStripMenuItem2,
            this.produtividadeToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "&Relatórios";
            // 
            // movimentaçãoDiáriaToolStripMenuItem
            // 
            this.movimentaçãoDiáriaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movimentaçãoDiáriaToolStripMenuItem1});
            this.movimentaçãoDiáriaToolStripMenuItem.Name = "movimentaçãoDiáriaToolStripMenuItem";
            this.movimentaçãoDiáriaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.movimentaçãoDiáriaToolStripMenuItem.Text = "Funcionários";
            // 
            // movimentaçãoDiáriaToolStripMenuItem1
            // 
            this.movimentaçãoDiáriaToolStripMenuItem1.Name = "movimentaçãoDiáriaToolStripMenuItem1";
            this.movimentaçãoDiáriaToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.movimentaçãoDiáriaToolStripMenuItem1.Text = "Movimentação Diária";
            this.movimentaçãoDiáriaToolStripMenuItem1.Click += new System.EventHandler(this.movimentaçãoDiáriaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apropriaçãoPorPeríodoToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem2.Text = "&Apropriação";
            // 
            // apropriaçãoPorPeríodoToolStripMenuItem
            // 
            this.apropriaçãoPorPeríodoToolStripMenuItem.Name = "apropriaçãoPorPeríodoToolStripMenuItem";
            this.apropriaçãoPorPeríodoToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.apropriaçãoPorPeríodoToolStripMenuItem.Text = "&Apropriação por Período";
            this.apropriaçãoPorPeríodoToolStripMenuItem.Click += new System.EventHandler(this.apropriaçãoPorPeríodoToolStripMenuItem_Click);
            // 
            // produtividadeToolStripMenuItem
            // 
            this.produtividadeToolStripMenuItem.Name = "produtividadeToolStripMenuItem";
            this.produtividadeToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.produtividadeToolStripMenuItem.Text = "&Produtividade";
            this.produtividadeToolStripMenuItem.Click += new System.EventHandler(this.produtividadeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerenciarContasToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(96, 20);
            this.toolStripMenuItem1.Text = "&Configurações";
            // 
            // gerenciarContasToolStripMenuItem
            // 
            this.gerenciarContasToolStripMenuItem.Name = "gerenciarContasToolStripMenuItem";
            this.gerenciarContasToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.gerenciarContasToolStripMenuItem.Text = "&Gerenciar Contas ";
            // 
            // xSairToolStripMenuItem
            // 
            this.xSairToolStripMenuItem.Name = "xSairToolStripMenuItem";
            this.xSairToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.xSairToolStripMenuItem.Text = "&X Sair";
            this.xSairToolStripMenuItem.Click += new System.EventHandler(this.xSairToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel1});
            this.statusStrip.Location = new System.Drawing.Point(0, 712);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1084, 22);
            this.statusStrip.TabIndex = 2;
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
            // MDIGeral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1084, 734);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIGeral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PSP - Portal de Suporte ao Planejamento";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MDIGeral_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem apropriarHorasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importaçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem funcionáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem novosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faltaRHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoDiáriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xSairToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoDiáriaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gerenciarContasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtividadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem apropriaçãoPorPeríodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem atividadesToolStripMenuItem;
    }
}



