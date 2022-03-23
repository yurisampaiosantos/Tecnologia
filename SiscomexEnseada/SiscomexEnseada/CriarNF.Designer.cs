namespace SiscomexEnseada
{
    partial class CriarNF
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
            this.txtCnpj = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrf = new System.Windows.Forms.TextBox();
            this.txtRa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAvaria = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDivergencia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSair = new System.Windows.Forms.Button();
            this.btNotaFiscal = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCnpjFornecedor = new System.Windows.Forms.ComboBox();
            this.cbLocalRecepcao = new System.Windows.Forms.ComboBox();
            this.cbLocalArmazenamento = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCnpj
            // 
            this.txtCnpj.Enabled = false;
            this.txtCnpj.Location = new System.Drawing.Point(15, 25);
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(179, 20);
            this.txtCnpj.TabIndex = 0;
            this.txtCnpj.Text = "12243301000125";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CNPJ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codigo URF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(357, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo RA";
            // 
            // txtUrf
            // 
            this.txtUrf.Enabled = false;
            this.txtUrf.Location = new System.Drawing.Point(230, 25);
            this.txtUrf.Name = "txtUrf";
            this.txtUrf.Size = new System.Drawing.Size(100, 20);
            this.txtUrf.TabIndex = 4;
            this.txtUrf.Text = "0517800";
            // 
            // txtRa
            // 
            this.txtRa.Enabled = false;
            this.txtRa.Location = new System.Drawing.Point(360, 25);
            this.txtRa.Name = "txtRa";
            this.txtRa.Size = new System.Drawing.Size(100, 20);
            this.txtRa.TabIndex = 5;
            this.txtRa.Text = "5921404";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Local Recepção";
            // 
            // txtAvaria
            // 
            this.txtAvaria.Location = new System.Drawing.Point(15, 211);
            this.txtAvaria.Name = "txtAvaria";
            this.txtAvaria.Size = new System.Drawing.Size(445, 20);
            this.txtAvaria.TabIndex = 8;
            this.txtAvaria.Text = "NAO ENCONTRADAS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Avarias Identificadas";
            // 
            // txtDivergencia
            // 
            this.txtDivergencia.Location = new System.Drawing.Point(15, 258);
            this.txtDivergencia.Name = "txtDivergencia";
            this.txtDivergencia.Size = new System.Drawing.Size(445, 20);
            this.txtDivergencia.TabIndex = 10;
            this.txtDivergencia.Text = "NAO ENCONTRADAS";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Divergencias Identificadas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSair);
            this.panel1.Controls.Add(this.btNotaFiscal);
            this.panel1.Controls.Add(this.btSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 59);
            this.panel1.TabIndex = 14;
            // 
            // btSair
            // 
            this.btSair.Location = new System.Drawing.Point(18, 19);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(113, 28);
            this.btSair.TabIndex = 2;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // btNotaFiscal
            // 
            this.btNotaFiscal.Location = new System.Drawing.Point(179, 19);
            this.btNotaFiscal.Name = "btNotaFiscal";
            this.btNotaFiscal.Size = new System.Drawing.Size(113, 28);
            this.btNotaFiscal.TabIndex = 1;
            this.btNotaFiscal.Text = "Notas Fiscais";
            this.btNotaFiscal.UseVisualStyleBackColor = true;
            this.btNotaFiscal.Click += new System.EventHandler(this.BtNotaFiscal_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(347, 19);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(113, 28);
            this.btSalvar.TabIndex = 0;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 146);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Local Armazenamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Fornecedor";
            // 
            // cbCnpjFornecedor
            // 
            this.cbCnpjFornecedor.FormattingEnabled = true;
            this.cbCnpjFornecedor.Location = new System.Drawing.Point(15, 65);
            this.cbCnpjFornecedor.Name = "cbCnpjFornecedor";
            this.cbCnpjFornecedor.Size = new System.Drawing.Size(445, 21);
            this.cbCnpjFornecedor.TabIndex = 18;
            this.cbCnpjFornecedor.SelectedIndexChanged += new System.EventHandler(this.cbCnpjFornecedor_SelectedIndexChanged);
            // 
            // cbLocalRecepcao
            // 
            this.cbLocalRecepcao.FormattingEnabled = true;
            this.cbLocalRecepcao.Location = new System.Drawing.Point(15, 112);
            this.cbLocalRecepcao.Name = "cbLocalRecepcao";
            this.cbLocalRecepcao.Size = new System.Drawing.Size(445, 21);
            this.cbLocalRecepcao.TabIndex = 19;
            // 
            // cbLocalArmazenamento
            // 
            this.cbLocalArmazenamento.FormattingEnabled = true;
            this.cbLocalArmazenamento.Location = new System.Drawing.Point(15, 162);
            this.cbLocalArmazenamento.Name = "cbLocalArmazenamento";
            this.cbLocalArmazenamento.Size = new System.Drawing.Size(445, 21);
            this.cbLocalArmazenamento.TabIndex = 20;
            // 
            // CriarNF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 360);
            this.Controls.Add(this.cbLocalArmazenamento);
            this.Controls.Add(this.cbLocalRecepcao);
            this.Controls.Add(this.cbCnpjFornecedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDivergencia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAvaria);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRa);
            this.Controls.Add(this.txtUrf);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCnpj);
            this.Name = "CriarNF";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CriarNF";
            this.Load += new System.EventHandler(this.CriarNF_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCnpj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrf;
        private System.Windows.Forms.TextBox txtRa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAvaria;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDivergencia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btNotaFiscal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCnpjFornecedor;
        private System.Windows.Forms.ComboBox cbLocalRecepcao;
        private System.Windows.Forms.ComboBox cbLocalArmazenamento;
    }
}