namespace wfFolhaApropriacao
{
    partial class frmImpStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImpStatus));
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbObs = new System.Windows.Forms.Label();
            this.lblProcessando = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btImportar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btPreparar = new System.Windows.Forms.Button();
            this.btMascara = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gvImportacao
            // 
            this.gvImportacao.AllowUserToAddRows = false;
            this.gvImportacao.AllowUserToDeleteRows = false;
            this.gvImportacao.AllowUserToResizeColumns = false;
            this.gvImportacao.AllowUserToResizeRows = false;
            this.gvImportacao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvImportacao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.gvImportacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao.Location = new System.Drawing.Point(0, 87);
            this.gvImportacao.Name = "gvImportacao";
            this.gvImportacao.ReadOnly = true;
            this.gvImportacao.RowHeadersVisible = false;
            this.gvImportacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gvImportacao.Size = new System.Drawing.Size(801, 578);
            this.gvImportacao.TabIndex = 56;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "MATRÍCULA";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 94;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "STATUS";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 75;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "INÍCIO AFASTADO";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 124;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "INÍCIO FÉRIAS";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 105;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "FIM FÉRIAS";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 91;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "DATA DEMISSÃO";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 120;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column6.HeaderText = "ALERTAS";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbObs);
            this.panel1.Controls.Add(this.lblProcessando);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(801, 87);
            this.panel1.TabIndex = 57;
            // 
            // lbObs
            // 
            this.lbObs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbObs.ForeColor = System.Drawing.Color.Red;
            this.lbObs.Location = new System.Drawing.Point(539, 63);
            this.lbObs.Name = "lbObs";
            this.lbObs.Size = new System.Drawing.Size(257, 23);
            this.lbObs.TabIndex = 59;
            this.lbObs.Text = "Obs.: Existem 2 alertas para verificação";
            this.lbObs.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbObs.Visible = false;
            // 
            // lblProcessando
            // 
            this.lblProcessando.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcessando.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProcessando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessando.ForeColor = System.Drawing.Color.Red;
            this.lblProcessando.Location = new System.Drawing.Point(685, 10);
            this.lblProcessando.Name = "lblProcessando";
            this.lblProcessando.Size = new System.Drawing.Size(106, 15);
            this.lblProcessando.TabIndex = 58;
            this.lblProcessando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btImportar);
            this.groupBox2.Controls.Add(this.btCancelar);
            this.groupBox2.Controls.Add(this.btPreparar);
            this.groupBox2.Controls.Add(this.btMascara);
            this.groupBox2.Location = new System.Drawing.Point(15, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 63);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // btImportar
            // 
            this.btImportar.Image = global::wfFolhaApropriacao.Properties.Resources.importar1;
            this.btImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImportar.Location = new System.Drawing.Point(104, 24);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(73, 22);
            this.btImportar.TabIndex = 58;
            this.btImportar.Text = "Importar";
            this.btImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Click += new System.EventHandler(this.btImportar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btCancelar.Image")));
            this.btCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btCancelar.Location = new System.Drawing.Point(276, 24);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(73, 22);
            this.btCancelar.TabIndex = 57;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btPreparar
            // 
            this.btPreparar.Image = global::wfFolhaApropriacao.Properties.Resources.Preparar;
            this.btPreparar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPreparar.Location = new System.Drawing.Point(19, 24);
            this.btPreparar.Name = "btPreparar";
            this.btPreparar.Size = new System.Drawing.Size(73, 22);
            this.btPreparar.TabIndex = 56;
            this.btPreparar.Text = "Preparar";
            this.btPreparar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btPreparar.UseVisualStyleBackColor = true;
            this.btPreparar.Click += new System.EventHandler(this.btPreparar_Click);
            // 
            // btMascara
            // 
            this.btMascara.Image = global::wfFolhaApropriacao.Properties.Resources.mascara1;
            this.btMascara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMascara.Location = new System.Drawing.Point(190, 24);
            this.btMascara.Name = "btMascara";
            this.btMascara.Size = new System.Drawing.Size(73, 22);
            this.btMascara.TabIndex = 56;
            this.btMascara.Text = "Máscara";
            this.btMascara.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMascara.UseVisualStyleBackColor = true;
            this.btMascara.Click += new System.EventHandler(this.btMascara_Click);
            // 
            // frmImpStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 665);
            this.Controls.Add(this.gvImportacao);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImpStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Status de Funcionários";
            this.Load += new System.EventHandler(this.frmImpStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btPreparar;
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.Label lblProcessando;
        private System.Windows.Forms.Button btMascara;
        private System.Windows.Forms.Label lbObs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}