namespace SiscomexEnseada
{
    partial class Principal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.tsmCriarNota = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtSelecionada = new System.Windows.Forms.DateTimePicker();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btExcluir = new System.Windows.Forms.Button();
            this.lbVersao = new System.Windows.Forms.Label();
            this.btEnviar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dvCarga = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Local_Recepcao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_NOTAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IMPORTADOS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_ERRO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.msPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvCarga)).BeginInit();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msPrincipal.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCriarNota});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(800, 40);
            this.msPrincipal.TabIndex = 1;
            this.msPrincipal.Text = "Principal";
            // 
            // tsmCriarNota
            // 
            this.tsmCriarNota.Name = "tsmCriarNota";
            this.tsmCriarNota.Size = new System.Drawing.Size(137, 36);
            this.tsmCriarNota.Text = "Criar Lote";
            this.tsmCriarNota.Click += new System.EventHandler(this.TsmCriarNota_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(480, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // dtSelecionada
            // 
            this.dtSelecionada.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSelecionada.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSelecionada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtSelecionada.Location = new System.Drawing.Point(26, 56);
            this.dtSelecionada.Name = "dtSelecionada";
            this.dtSelecionada.Size = new System.Drawing.Size(122, 37);
            this.dtSelecionada.TabIndex = 4;
            this.dtSelecionada.ValueChanged += new System.EventHandler(this.DtSelecionada_ValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Good mark.png");
            this.imageList1.Images.SetKeyName(1, "Bad mark.png");
            this.imageList1.Images.SetKeyName(2, "aguardando.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btExcluir);
            this.panel2.Controls.Add(this.lbVersao);
            this.panel2.Controls.Add(this.btEnviar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 427);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 56);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(594, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(205, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExcluir.Location = new System.Drawing.Point(233, 14);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(143, 30);
            this.btExcluir.TabIndex = 2;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // lbVersao
            // 
            this.lbVersao.AutoSize = true;
            this.lbVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVersao.Location = new System.Drawing.Point(482, 23);
            this.lbVersao.Name = "lbVersao";
            this.lbVersao.Size = new System.Drawing.Size(87, 26);
            this.lbVersao.TabIndex = 1;
            this.lbVersao.Text = "Versao";
            // 
            // btEnviar
            // 
            this.btEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btEnviar.Location = new System.Drawing.Point(17, 14);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(164, 30);
            this.btEnviar.TabIndex = 0;
            this.btEnviar.Text = "Enviar Selecionados";
            this.btEnviar.UseVisualStyleBackColor = false;
            this.btEnviar.Click += new System.EventHandler(this.BtEnviar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dvCarga);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 318);
            this.panel1.TabIndex = 7;
            // 
            // dvCarga
            // 
            this.dvCarga.AllowUserToAddRows = false;
            this.dvCarga.AllowUserToDeleteRows = false;
            this.dvCarga.AllowUserToResizeRows = false;
            this.dvCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvCarga.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.CNPJ,
            this.Local_Recepcao,
            this.TOTAL_NOTAS,
            this.IMPORTADOS,
            this.TOTAL_ERRO,
            this.Login,
            this.Status,
            this.IconStatus});
            this.dvCarga.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvCarga.Location = new System.Drawing.Point(0, 0);
            this.dvCarga.Name = "dvCarga";
            this.dvCarga.ReadOnly = true;
            this.dvCarga.RowHeadersWidth = 82;
            this.dvCarga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvCarga.Size = new System.Drawing.Size(800, 318);
            this.dvCarga.TabIndex = 0;
            this.dvCarga.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DvCarga_CellDoubleClick);
            this.dvCarga.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DvCarga_CellFormatting);
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Id.DataPropertyName = "ID";
            this.Id.HeaderText = "N. Lote";
            this.Id.MinimumWidth = 10;
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 87;
            // 
            // CNPJ
            // 
            this.CNPJ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CNPJ.DataPropertyName = "CNPJ";
            this.CNPJ.HeaderText = "CNPJ";
            this.CNPJ.MinimumWidth = 10;
            this.CNPJ.Name = "CNPJ";
            this.CNPJ.ReadOnly = true;
            this.CNPJ.Width = 79;
            // 
            // Local_Recepcao
            // 
            this.Local_Recepcao.DataPropertyName = "Local_Recepcao";
            this.Local_Recepcao.HeaderText = "Local Recepção";
            this.Local_Recepcao.MinimumWidth = 10;
            this.Local_Recepcao.Name = "Local_Recepcao";
            this.Local_Recepcao.ReadOnly = true;
            this.Local_Recepcao.Width = 180;
            // 
            // TOTAL_NOTAS
            // 
            this.TOTAL_NOTAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TOTAL_NOTAS.DataPropertyName = "TOTAL_NOTAS";
            this.TOTAL_NOTAS.HeaderText = "Total de Notas";
            this.TOTAL_NOTAS.MinimumWidth = 10;
            this.TOTAL_NOTAS.Name = "TOTAL_NOTAS";
            this.TOTAL_NOTAS.ReadOnly = true;
            this.TOTAL_NOTAS.Width = 122;
            // 
            // IMPORTADOS
            // 
            this.IMPORTADOS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IMPORTADOS.DataPropertyName = "IMPORTADOS";
            this.IMPORTADOS.HeaderText = "Notas Importadas";
            this.IMPORTADOS.MinimumWidth = 10;
            this.IMPORTADOS.Name = "IMPORTADOS";
            this.IMPORTADOS.ReadOnly = true;
            this.IMPORTADOS.Width = 125;
            // 
            // TOTAL_ERRO
            // 
            this.TOTAL_ERRO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TOTAL_ERRO.DataPropertyName = "TOTAL_ERRO";
            this.TOTAL_ERRO.HeaderText = "Notas com Erros";
            this.TOTAL_ERRO.MinimumWidth = 10;
            this.TOTAL_ERRO.Name = "TOTAL_ERRO";
            this.TOTAL_ERRO.ReadOnly = true;
            this.TOTAL_ERRO.Width = 99;
            // 
            // Login
            // 
            this.Login.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Login.DataPropertyName = "Login_cadastro";
            this.Login.HeaderText = "Login";
            this.Login.MinimumWidth = 10;
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 78;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 2;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 2;
            // 
            // IconStatus
            // 
            this.IconStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IconStatus.HeaderText = "Status";
            this.IconStatus.MinimumWidth = 10;
            this.IconStatus.Name = "IconStatus";
            this.IconStatus.ReadOnly = true;
            this.IconStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IconStatus.Width = 82;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 483);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dtSelecionada);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.msPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siscomex";
            this.Load += new System.EventHandler(this.Principal_Load);
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvCarga)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem tsmCriarNota;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker dtSelecionada;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvCarga;
        private System.Windows.Forms.Label lbVersao;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Local_Recepcao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_NOTAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn IMPORTADOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_ERRO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Login;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
    }
}

