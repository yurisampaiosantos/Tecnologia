namespace Replat
{
    partial class frmOPsNovas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPsNovas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDisciplina = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSubContrato = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpAte = new System.Windows.Forms.DateTimePicker();
            this.dtpDe = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btGerar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btExportar = new System.Windows.Forms.Button();
            this.btEnviar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gvImportacao2 = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gvImportacao3 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gvImportacao4 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 159);
            this.panel1.TabIndex = 63;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbDisciplina);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbSubContrato);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpAte);
            this.groupBox1.Controls.Add(this.dtpDe);
            this.groupBox1.Location = new System.Drawing.Point(16, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(767, 63);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "Disciplina:";
            // 
            // cbDisciplina
            // 
            this.cbDisciplina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDisciplina.FormattingEnabled = true;
            this.cbDisciplina.Location = new System.Drawing.Point(241, 25);
            this.cbDisciplina.Name = "cbDisciplina";
            this.cbDisciplina.Size = new System.Drawing.Size(196, 21);
            this.cbDisciplina.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Sub Contrato:";
            // 
            // cbSubContrato
            // 
            this.cbSubContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubContrato.FormattingEnabled = true;
            this.cbSubContrato.Location = new System.Drawing.Point(92, 25);
            this.cbSubContrato.Name = "cbSubContrato";
            this.cbSubContrato.Size = new System.Drawing.Size(75, 21);
            this.cbSubContrato.TabIndex = 67;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(606, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 66;
            this.label3.Text = "Até";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "De";
            // 
            // dtpAte
            // 
            this.dtpAte.Checked = false;
            this.dtpAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAte.Location = new System.Drawing.Point(637, 25);
            this.dtpAte.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpAte.Name = "dtpAte";
            this.dtpAte.ShowCheckBox = true;
            this.dtpAte.Size = new System.Drawing.Size(115, 20);
            this.dtpAte.TabIndex = 68;
            this.dtpAte.Value = new System.DateTime(2015, 7, 14, 0, 0, 0, 0);
            // 
            // dtpDe
            // 
            this.dtpDe.Checked = false;
            this.dtpDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDe.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dtpDe.Location = new System.Drawing.Point(479, 25);
            this.dtpDe.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpDe.Name = "dtpDe";
            this.dtpDe.ShowCheckBox = true;
            this.dtpDe.Size = new System.Drawing.Size(115, 20);
            this.dtpDe.TabIndex = 67;
            this.dtpDe.Value = new System.DateTime(2015, 7, 14, 0, 0, 0, 0);
            this.dtpDe.ValueChanged += new System.EventHandler(this.dtpDe_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btGerar);
            this.groupBox2.Controls.Add(this.btFechar);
            this.groupBox2.Controls.Add(this.btExportar);
            this.groupBox2.Controls.Add(this.btEnviar);
            this.groupBox2.Location = new System.Drawing.Point(16, 82);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 63);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // btGerar
            // 
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerar.Location = new System.Drawing.Point(17, 25);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(73, 22);
            this.btGerar.TabIndex = 2;
            this.btGerar.Text = "Gerar";
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(281, 25);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 5;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btExportar
            // 
            this.btExportar.Image = global::CI.Properties.Resources.IcoEpPlus1;
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(105, 25);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(73, 22);
            this.btExportar.TabIndex = 3;
            this.btExportar.Text = "Exportar";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // btEnviar
            // 
            this.btEnviar.Image = global::CI.Properties.Resources.enviar;
            this.btEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btEnviar.Location = new System.Drawing.Point(193, 25);
            this.btEnviar.Name = "btEnviar";
            this.btEnviar.Size = new System.Drawing.Size(73, 22);
            this.btEnviar.TabIndex = 4;
            this.btEnviar.Text = "Enviar";
            this.btEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btEnviar.UseVisualStyleBackColor = true;
            this.btEnviar.Click += new System.EventHandler(this.btEnviar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(798, 432);
            this.panel2.TabIndex = 65;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(798, 432);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gvImportacao);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(790, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Produção (OP)";
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
            this.gvImportacao.Size = new System.Drawing.Size(784, 400);
            this.gvImportacao.TabIndex = 64;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gvImportacao2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(790, 406);
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
            this.gvImportacao2.Size = new System.Drawing.Size(784, 400);
            this.gvImportacao2.TabIndex = 65;
            this.gvImportacao2.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.gvImportacao3);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(790, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Etapa x OP";
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
            this.gvImportacao3.Size = new System.Drawing.Size(784, 400);
            this.gvImportacao3.TabIndex = 68;
            this.gvImportacao3.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gvImportacao4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(790, 406);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Comp. Modelos";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gvImportacao4
            // 
            this.gvImportacao4.AllowUserToAddRows = false;
            this.gvImportacao4.AllowUserToDeleteRows = false;
            this.gvImportacao4.AllowUserToResizeRows = false;
            this.gvImportacao4.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao4.Location = new System.Drawing.Point(3, 3);
            this.gvImportacao4.Name = "gvImportacao4";
            this.gvImportacao4.ReadOnly = true;
            this.gvImportacao4.Size = new System.Drawing.Size(784, 400);
            this.gvImportacao4.TabIndex = 69;
            this.gvImportacao4.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // frmOPsNovas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 591);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOPsNovas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ordem de Produção (OP) - Novas";
            this.Load += new System.EventHandler(this.frmOPsNovas_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btEnviar;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gvImportacao2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView gvImportacao3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gvImportacao4;
        private System.Windows.Forms.DateTimePicker dtpAte;
        private System.Windows.Forms.DateTimePicker dtpDe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDisciplina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSubContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;

    }
}