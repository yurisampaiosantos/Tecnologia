namespace Replat
{
    partial class frmNfeForaDaIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNfeForaDaIn));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegistros = new System.Windows.Forms.Label();
            this.btExportar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btGerar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLocalizar = new System.Windows.Forms.TextBox();
            this.btLocalizar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 88);
            this.panel1.TabIndex = 63;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblRegistros);
            this.groupBox2.Controls.Add(this.btExportar);
            this.groupBox2.Controls.Add(this.btFechar);
            this.groupBox2.Controls.Add(this.btGerar);
            this.groupBox2.Location = new System.Drawing.Point(15, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(425, 63);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // lblRegistros
            // 
            this.lblRegistros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRegistros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRegistros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistros.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegistros.Location = new System.Drawing.Point(287, 26);
            this.lblRegistros.Name = "lblRegistros";
            this.lblRegistros.Size = new System.Drawing.Size(120, 19);
            this.lblRegistros.TabIndex = 56;
            this.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btExportar
            // 
            this.btExportar.Image = ((System.Drawing.Image)(resources.GetObject("btExportar.Image")));
            this.btExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExportar.Location = new System.Drawing.Point(108, 24);
            this.btExportar.Name = "btExportar";
            this.btExportar.Size = new System.Drawing.Size(73, 22);
            this.btExportar.TabIndex = 3;
            this.btExportar.Text = "Exportar";
            this.btExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExportar.UseVisualStyleBackColor = true;
            this.btExportar.Click += new System.EventHandler(this.btExportar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(196, 24);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 4;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btGerar
            // 
            this.btGerar.Image = ((System.Drawing.Image)(resources.GetObject("btGerar.Image")));
            this.btGerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btGerar.Location = new System.Drawing.Point(20, 24);
            this.btGerar.Name = "btGerar";
            this.btGerar.Size = new System.Drawing.Size(73, 22);
            this.btGerar.TabIndex = 2;
            this.btGerar.Text = "Gerar";
            this.btGerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btGerar.UseVisualStyleBackColor = true;
            this.btGerar.Click += new System.EventHandler(this.btGerar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.gvImportacao);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 88);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(663, 416);
            this.panel2.TabIndex = 65;
            // 
            // gvImportacao
            // 
            this.gvImportacao.AllowUserToAddRows = false;
            this.gvImportacao.AllowUserToDeleteRows = false;
            this.gvImportacao.AllowUserToResizeRows = false;
            this.gvImportacao.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao.Location = new System.Drawing.Point(0, 0);
            this.gvImportacao.Name = "gvImportacao";
            this.gvImportacao.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvImportacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gvImportacao.Size = new System.Drawing.Size(663, 416);
            this.gvImportacao.TabIndex = 66;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLocalizar);
            this.groupBox1.Controls.Add(this.btLocalizar);
            this.groupBox1.Location = new System.Drawing.Point(456, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 63);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Localizar";
            // 
            // txtLocalizar
            // 
            this.txtLocalizar.Location = new System.Drawing.Point(19, 25);
            this.txtLocalizar.Name = "txtLocalizar";
            this.txtLocalizar.Size = new System.Drawing.Size(137, 20);
            this.txtLocalizar.TabIndex = 43;
            this.txtLocalizar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLocalizar_KeyDown);
            // 
            // btLocalizar
            // 
            this.btLocalizar.Image = global::CI.Properties.Resources.icoLocalizar;
            this.btLocalizar.Location = new System.Drawing.Point(154, 24);
            this.btLocalizar.Name = "btLocalizar";
            this.btLocalizar.Size = new System.Drawing.Size(21, 22);
            this.btLocalizar.TabIndex = 44;
            this.btLocalizar.UseVisualStyleBackColor = true;
            this.btLocalizar.Click += new System.EventHandler(this.btLocalizar_Click);
            // 
            // frmNfeForaDaIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 504);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNfeForaDaIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NFE Fora da IN";
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btExportar;
        private System.Windows.Forms.Button btGerar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.Label lblRegistros;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLocalizar;
        private System.Windows.Forms.Button btLocalizar;

    }
}