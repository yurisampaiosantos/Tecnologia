namespace Replat
{
    partial class frmNFEporLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNFEporLote));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btAbrir = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btMascara = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvImportacao2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gvImportacao3 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 87);
            this.panel1.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btAbrir);
            this.groupBox1.Controls.Add(this.btFechar);
            this.groupBox1.Controls.Add(this.btExportar);
            this.groupBox1.Controls.Add(this.btEnviar);
            this.groupBox1.Controls.Add(this.btMascara);
            this.groupBox1.Location = new System.Drawing.Point(15, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 63);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // btAbrir
            // 
            this.btAbrir.Image = global::CI.Properties.Resources.Open;
            this.btAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrir.Location = new System.Drawing.Point(23, 24);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(73, 22);
            this.btAbrir.TabIndex = 59;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(381, 24);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 58;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btExportar
            // 
            this.btExportar.Image = global::CI.Properties.Resources.IcoEpPlus1;
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(113, 24);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(73, 22);
            this.btExportar.TabIndex = 63;
            this.btExportar.Text = "Exportar";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.Image = global::CI.Properties.Resources.enviar;
            this.btEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnviar.Location = new System.Drawing.Point(202, 24);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(73, 22);
            this.btEnviar.TabIndex = 64;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btMascara
            // 
            this.btMascara.Image = global::CI.Properties.Resources.mascara1;
            this.btMascara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMascara.Location = new System.Drawing.Point(292, 24);
            this.btMascara.Name = "btMascara";
            this.btMascara.Size = new System.Drawing.Size(73, 22);
            this.btMascara.TabIndex = 60;
            this.btMascara.Text = "Máscara";
            this.btMascara.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMascara.UseVisualStyleBackColor = true;
            this.btMascara.Click += new System.EventHandler(this.btMascara_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 537);
            this.tabControl1.TabIndex = 67;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvImportacao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 511);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "NF de Entrada";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            this.gvImportacao.Size = new System.Drawing.Size(649, 505);
            this.gvImportacao.TabIndex = 64;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvImportacao2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 511);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Movimentações";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.gvImportacao2.Size = new System.Drawing.Size(649, 505);
            this.gvImportacao2.TabIndex = 65;
            this.gvImportacao2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gvImportacao3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(655, 511);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Imposto Calculado";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gvImportacao3
            // 
            this.gvImportacao3.AllowUserToAddRows = false;
            this.gvImportacao3.AllowUserToDeleteRows = false;
            this.gvImportacao3.AllowUserToResizeRows = false;
            this.gvImportacao3.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao3.Location = new System.Drawing.Point(3, 3);
            this.gvImportacao3.Name = "gvImportacao3";
            this.gvImportacao3.ReadOnly = true;
            this.gvImportacao3.Size = new System.Drawing.Size(649, 505);
            this.gvImportacao3.TabIndex = 66;
            this.gvImportacao3.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // frmNFEporLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 624);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNFEporLote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NFE por Lote";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btMascara;
        private System.Windows.Forms.Button btAbrir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvImportacao2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gvImportacao3;

    }
}