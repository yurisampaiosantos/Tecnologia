namespace Replat
{
    partial class frmBatimentosBJ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatimentosBJ));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btEnviar = new System.Windows.Forms.Button();
            this.cbProcedimento = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMovimentacoes = new System.Windows.Forms.Label();
            this.btFechar = new System.Windows.Forms.Button();
            this.btGerar = new System.Windows.Forms.Button();
            this.btAbrir = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.btQuery = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvImportacao2 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 160);
            this.panel1.TabIndex = 63;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Controls.Add(this.cbProcedimento);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(15, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(725, 63);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alertas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Procedimento:";
            // 
            // btEnviar
            // 
            this.btEnviar.Image = global::CI.Properties.Resources.enviar;
            this.btEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnviar.Location = new System.Drawing.Point(382, 23);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(73, 22);
            this.btEnviar.TabIndex = 5;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // cbProcedimento
            // 
            this.cbProcedimento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProcedimento.FormattingEnabled = true;
            this.cbProcedimento.Items.AddRange(new object[] {
            "",
            "Enviar para o Replat",
            "Dados diferente do Replat"});
            this.cbProcedimento.Location = new System.Drawing.Point(114, 24);
            this.cbProcedimento.Name = "cbProcedimento";
            this.cbProcedimento.Size = new System.Drawing.Size(250, 21);
            this.cbProcedimento.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMovimentacoes);
            this.groupBox1.Controls.Add(this.btFechar);
            this.groupBox1.Controls.Add(this.btGerar);
            this.groupBox1.Controls.Add(this.btAbrir);
            this.groupBox1.Controls.Add(this.btExportar);
            this.groupBox1.Controls.Add(this.btQuery);
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(725, 63);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // lblMovimentacoes
            // 
            this.lblMovimentacoes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMovimentacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMovimentacoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMovimentacoes.ForeColor = System.Drawing.Color.Red;
            this.lblMovimentacoes.Location = new System.Drawing.Point(477, 26);
            this.lblMovimentacoes.Name = "lblMovimentacoes";
            this.lblMovimentacoes.Size = new System.Drawing.Size(229, 19);
            this.lblMovimentacoes.TabIndex = 71;
            this.lblMovimentacoes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(382, 24);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 67;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btGerar
            // 
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerar.Location = new System.Drawing.Point(113, 24);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(73, 22);
            this.btGerar.TabIndex = 64;
            this.btGerar.Text = "Gerar";
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // btAbrir
            // 
            this.btAbrir.Image = global::CI.Properties.Resources.importar1;
            this.btAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrir.Location = new System.Drawing.Point(23, 24);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(73, 22);
            this.btAbrir.TabIndex = 65;
            this.btAbrir.Text = "Importar";
            this.btAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // btExportar
            // 
            this.btExportar.Image = global::CI.Properties.Resources.IcoEpPlus1;
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(202, 24);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(73, 22);
            this.btExportar.TabIndex = 61;
            this.btExportar.Text = "Exportar";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // btQuery
            // 
            this.btQuery.Image = ((System.Drawing.Image)(resources.GetObject("btQuery.Image")));
            this.btQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btQuery.Location = new System.Drawing.Point(292, 24);
            this.btQuery.Name = "btQuery";
            this.btQuery.Size = new System.Drawing.Size(73, 22);
            this.btQuery.TabIndex = 63;
            this.btQuery.Text = "Query";
            this.btQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btQuery.UseVisualStyleBackColor = true;
            this.btQuery.Click += new System.EventHandler(this.btQuery_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 390);
            this.panel2.TabIndex = 65;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(757, 390);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvImportacao);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(749, 364);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Dados do Replat";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gvImportacao
            // 
            this.gvImportacao.AllowUserToAddRows = false;
            this.gvImportacao.AllowUserToDeleteRows = false;
            this.gvImportacao.AllowUserToResizeRows = false;
            this.gvImportacao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao.Location = new System.Drawing.Point(3, 3);
            this.gvImportacao.Name = "gvImportacao";
            this.gvImportacao.ReadOnly = true;
            this.gvImportacao.Size = new System.Drawing.Size(743, 358);
            this.gvImportacao.TabIndex = 65;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvImportacao2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(749, 364);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dados do sisEPC";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gvImportacao2
            // 
            this.gvImportacao2.AllowUserToAddRows = false;
            this.gvImportacao2.AllowUserToDeleteRows = false;
            this.gvImportacao2.AllowUserToResizeRows = false;
            this.gvImportacao2.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao2.Location = new System.Drawing.Point(3, 3);
            this.gvImportacao2.Name = "gvImportacao2";
            this.gvImportacao2.ReadOnly = true;
            this.gvImportacao2.Size = new System.Drawing.Size(743, 358);
            this.gvImportacao2.TabIndex = 64;
            this.gvImportacao2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // frmBatimentosBJ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 550);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBatimentosBJ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Batimentos - Transferência Organização (BJ)";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvImportacao2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btQuery;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbProcedimento;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMovimentacoes;

    }
}