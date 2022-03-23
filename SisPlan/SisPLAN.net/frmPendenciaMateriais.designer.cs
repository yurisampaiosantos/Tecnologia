namespace SisPLAN.net
{
    partial class frmPendenciaMateriais
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRecalcular = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbRM = new System.Windows.Forms.ComboBox();
            this.txtCodigoMat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CollectionAcPendenciaMaterialDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grv = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionAcPendenciaMaterialDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cmbDisciplina);
            this.panel1.Controls.Add(this.cmbFPSO);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.chkRecalcular);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbRM);
            this.panel1.Controls.Add(this.txtCodigoMat);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAF);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Location = new System.Drawing.Point(155, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(927, 63);
            this.panel1.TabIndex = 10;
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Items.AddRange(new object[] {
            "",
            "P74",
            "P75",
            "P76",
            "P77"});
            this.cmbDisciplina.Location = new System.Drawing.Point(141, 26);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(110, 21);
            this.cmbDisciplina.TabIndex = 35;
            // 
            // cmbFPSO
            // 
            this.cmbFPSO.FormattingEnabled = true;
            this.cmbFPSO.Items.AddRange(new object[] {
            "",
            "P74",
            "P75",
            "P76",
            "P77"});
            this.cmbFPSO.Location = new System.Drawing.Point(9, 26);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(110, 21);
            this.cmbFPSO.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(138, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Disciplina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "FPSO";
            // 
            // chkRecalcular
            // 
            this.chkRecalcular.Location = new System.Drawing.Point(751, 28);
            this.chkRecalcular.Name = "chkRecalcular";
            this.chkRecalcular.Size = new System.Drawing.Size(77, 17);
            this.chkRecalcular.TabIndex = 30;
            this.chkRecalcular.Text = "Recalcular";
            this.chkRecalcular.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "RM";
            // 
            // cmbRM
            // 
            this.cmbRM.FormattingEnabled = true;
            this.cmbRM.Location = new System.Drawing.Point(275, 26);
            this.cmbRM.Name = "cmbRM";
            this.cmbRM.Size = new System.Drawing.Size(197, 21);
            this.cmbRM.TabIndex = 28;
            // 
            // txtCodigoMat
            // 
            this.txtCodigoMat.Location = new System.Drawing.Point(623, 26);
            this.txtCodigoMat.Name = "txtCodigoMat";
            this.txtCodigoMat.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoMat.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(621, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Código Material";
            // 
            // txtAF
            // 
            this.txtAF.Location = new System.Drawing.Point(496, 26);
            this.txtAF.Name = "txtAF";
            this.txtAF.Size = new System.Drawing.Size(100, 20);
            this.txtAF.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(493, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "AF";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(834, 24);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSize = true;
            reportDataSource3.Name = "dsPendenciaMateriais";
            reportDataSource3.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.PendenciaMateriais.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 79);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1360, 500);
            this.reportViewer1.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(10, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // CollectionAcPendenciaMaterialDTOBindingSource
            // 
            this.CollectionAcPendenciaMaterialDTOBindingSource.DataSource = typeof(DTO.CollectionAcPendenciaMaterialDTO);
            // 
            // grv
            // 
            this.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grv.Location = new System.Drawing.Point(1108, 10);
            this.grv.Name = "grv";
            this.grv.Size = new System.Drawing.Size(50, 50);
            this.grv.TabIndex = 12;
            this.grv.Visible = false;
            // 
            // frmPendenciaMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 755);
            this.Controls.Add(this.grv);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmPendenciaMateriais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pendência de Materiais v1.2.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPendenciaMateriais_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionAcPendenciaMaterialDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtAF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoMat;
        private System.Windows.Forms.Label label6;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource CollectionAcPendenciaMaterialDTOBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbRM;
        private System.Windows.Forms.CheckBox chkRecalcular;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView grv;
    }
}