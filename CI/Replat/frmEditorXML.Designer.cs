namespace Replat
{
    partial class frmEditorXML
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditorXML));
            this.gvImportacao = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblAlertas = new System.Windows.Forms.Label();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btMascara = new System.Windows.Forms.Button();
            this.btXLS = new System.Windows.Forms.Button();
            this.txtXLS = new System.Windows.Forms.TextBox();
            this.btXML = new System.Windows.Forms.Button();
            this.txtXML = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvImportacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvImportacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvImportacao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column6,
            this.Column5,
            this.Column4});
            this.gvImportacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvImportacao.Location = new System.Drawing.Point(0, 124);
            this.gvImportacao.Name = "gvImportacao";
            this.gvImportacao.ReadOnly = true;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvImportacao.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvImportacao.Size = new System.Drawing.Size(728, 464);
            this.gvImportacao.TabIndex = 70;
            this.gvImportacao.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gvImportacao_RowPostPaint);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "CÓDIGO SAP";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 98;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "CÓDIGO SISEPC";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 115;
            // 
            // Column1
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column1.HeaderText = "QTDE";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 62;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "V. UND";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 69;
            // 
            // Column5
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column5.HeaderText = "LINHA";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 64;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "ALERTAS";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(728, 124);
            this.panel1.TabIndex = 71;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAlertas);
            this.groupBox1.Controls.Add(this.btAlterar);
            this.groupBox1.Controls.Add(this.btFechar);
            this.groupBox1.Controls.Add(this.btMascara);
            this.groupBox1.Controls.Add(this.btXLS);
            this.groupBox1.Controls.Add(this.txtXLS);
            this.groupBox1.Controls.Add(this.btXML);
            this.groupBox1.Controls.Add(this.txtXML);
            this.groupBox1.Location = new System.Drawing.Point(18, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 98);
            this.groupBox1.TabIndex = 68;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções";
            // 
            // lblAlertas
            // 
            this.lblAlertas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAlertas.ForeColor = System.Drawing.Color.Red;
            this.lblAlertas.Location = new System.Drawing.Point(427, 27);
            this.lblAlertas.Name = "lblAlertas";
            this.lblAlertas.Size = new System.Drawing.Size(250, 18);
            this.lblAlertas.TabIndex = 75;
            this.lblAlertas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btAlterar
            // 
            this.btAlterar.Image = global::CI.Properties.Resources.Apropriar1;
            this.btAlterar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAlterar.Location = new System.Drawing.Point(426, 61);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(73, 22);
            this.btAlterar.TabIndex = 2;
            this.btAlterar.Text = "Alterar";
            this.btAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(605, 61);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(73, 22);
            this.btFechar.TabIndex = 4;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btMascara
            // 
            this.btMascara.Image = global::CI.Properties.Resources.mascara1;
            this.btMascara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btMascara.Location = new System.Drawing.Point(516, 61);
            this.btMascara.Name = "btMascara";
            this.btMascara.Size = new System.Drawing.Size(73, 22);
            this.btMascara.TabIndex = 3;
            this.btMascara.Text = "Máscara";
            this.btMascara.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btMascara.UseVisualStyleBackColor = true;
            this.btMascara.Click += new System.EventHandler(this.btMascara_Click);
            // 
            // btXLS
            // 
            this.btXLS.Image = global::CI.Properties.Resources.xls;
            this.btXLS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXLS.Location = new System.Drawing.Point(304, 61);
            this.btXLS.Name = "btXLS";
            this.btXLS.Size = new System.Drawing.Size(73, 22);
            this.btXLS.TabIndex = 1;
            this.btXLS.Text = "XLS";
            this.btXLS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXLS.UseVisualStyleBackColor = true;
            this.btXLS.Click += new System.EventHandler(this.btXLS_Click);
            // 
            // txtXLS
            // 
            this.txtXLS.Location = new System.Drawing.Point(24, 62);
            this.txtXLS.Name = "txtXLS";
            this.txtXLS.Size = new System.Drawing.Size(264, 20);
            this.txtXLS.TabIndex = 73;
            // 
            // btXML
            // 
            this.btXML.Image = global::CI.Properties.Resources.xml;
            this.btXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btXML.Location = new System.Drawing.Point(304, 25);
            this.btXML.Name = "btXML";
            this.btXML.Size = new System.Drawing.Size(73, 22);
            this.btXML.TabIndex = 0;
            this.btXML.Text = "XML";
            this.btXML.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btXML.UseVisualStyleBackColor = true;
            this.btXML.Click += new System.EventHandler(this.btXML_Click);
            // 
            // txtXML
            // 
            this.txtXML.Location = new System.Drawing.Point(24, 26);
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(264, 20);
            this.txtXML.TabIndex = 74;
            // 
            // frmEditorXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 588);
            this.Controls.Add(this.gvImportacao);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditorXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de XML";
            ((System.ComponentModel.ISupportInitialize)(this.gvImportacao)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvImportacao;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btMascara;
        private System.Windows.Forms.Button btXLS;
        private System.Windows.Forms.Button btXML;
        private System.Windows.Forms.TextBox txtXLS;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Label lblAlertas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}