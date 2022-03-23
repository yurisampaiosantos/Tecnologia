namespace Replat
{
    partial class frmImpostoCalculado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpostoCalculado));
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btEnviar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btAbrir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvImportacao
            // 
            this.gvImportacao.AllowUserToAddRows = false;
            this.gvImportacao.AllowUserToDeleteRows = false;
            //this.gvImportacao.AllowUserToResizeColumns = false;
            this.gvImportacao.AllowUserToResizeRows = false;
            //this.gvImportacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvImportacao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8});
            this.gvImportacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao.Location = new System.Drawing.Point(0, 87);
            this.gvImportacao.Name = "gvImportacao";
            this.gvImportacao.ReadOnly = true;
            this.gvImportacao.Size = new System.Drawing.Size(320, 251);
            this.gvImportacao.TabIndex = 62;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "CHAVE";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 87);
            this.panel1.TabIndex = 63;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Controls.Add(this.btFechar);
            this.groupBox2.Controls.Add(this.btAbrir);
            this.groupBox2.Location = new System.Drawing.Point(15, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(288, 63);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // btEnviar
            // 
            this.btEnviar.Image = global::CI.Properties.Resources.enviar;
            this.btEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnviar.Location = new System.Drawing.Point(107, 24);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(73, 22);
            this.btEnviar.TabIndex = 59;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(196, 24);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 57;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btAbrir
            // 
            this.btAbrir.Image = global::CI.Properties.Resources.Open;
            this.btAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAbrir.Location = new System.Drawing.Point(19, 24);
            this.btAbrir.Name = "btAbrir";
            this.btAbrir.Size = new System.Drawing.Size(73, 22);
            this.btAbrir.TabIndex = 56;
            this.btAbrir.Text = "Abrir";
            this.btAbrir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAbrir.UseVisualStyleBackColor = true;
            this.btAbrir.Click += new System.EventHandler(this.btAbrir_Click);
            // 
            // frmImpostoCalculado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 338);
            this.Controls.Add(this.gvImportacao);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmImpostoCalculado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imposto Calculado";
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btAbrir;

    }
}