namespace SisPLAN.net
{
    partial class frmStatusMateriais
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatusMateriais));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk3Diversos = new System.Windows.Forms.CheckBox();
            this.chk2Materiais = new System.Windows.Forms.CheckBox();
            this.chk1Equipamentos = new System.Windows.Forms.CheckBox();
            this.chkRDR = new System.Windows.Forms.CheckBox();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoMat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAF = new System.Windows.Forms.TextBox();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CollectionDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsRAMAtividade";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.rdlcRAMAtividade.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 108);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1262, 151);
            this.reportViewer1.TabIndex = 11;
            this.reportViewer1.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Visible = false;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 100);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 57;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnRunWorkerCompleted);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chk3Diversos);
            this.panel2.Controls.Add(this.chk2Materiais);
            this.panel2.Controls.Add(this.chk1Equipamentos);
            this.panel2.Location = new System.Drawing.Point(677, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 74);
            this.panel2.TabIndex = 76;
            // 
            // chk3Diversos
            // 
            this.chk3Diversos.AutoSize = true;
            this.chk3Diversos.Checked = true;
            this.chk3Diversos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk3Diversos.Location = new System.Drawing.Point(4, 54);
            this.chk3Diversos.Name = "chk3Diversos";
            this.chk3Diversos.Size = new System.Drawing.Size(76, 17);
            this.chk3Diversos.TabIndex = 2;
            this.chk3Diversos.Text = "3-Diversos";
            this.chk3Diversos.UseVisualStyleBackColor = true;
            // 
            // chk2Materiais
            // 
            this.chk2Materiais.AutoSize = true;
            this.chk2Materiais.Checked = true;
            this.chk2Materiais.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2Materiais.Location = new System.Drawing.Point(4, 30);
            this.chk2Materiais.Name = "chk2Materiais";
            this.chk2Materiais.Size = new System.Drawing.Size(77, 17);
            this.chk2Materiais.TabIndex = 1;
            this.chk2Materiais.Text = "2-Materiais";
            this.chk2Materiais.UseVisualStyleBackColor = true;
            // 
            // chk1Equipamentos
            // 
            this.chk1Equipamentos.AutoSize = true;
            this.chk1Equipamentos.Checked = true;
            this.chk1Equipamentos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1Equipamentos.Location = new System.Drawing.Point(4, 6);
            this.chk1Equipamentos.Name = "chk1Equipamentos";
            this.chk1Equipamentos.Size = new System.Drawing.Size(102, 17);
            this.chk1Equipamentos.TabIndex = 0;
            this.chk1Equipamentos.Text = "1-Equipamentos";
            this.chk1Equipamentos.UseVisualStyleBackColor = true;
            // 
            // chkRDR
            // 
            this.chkRDR.AutoSize = true;
            this.chkRDR.Location = new System.Drawing.Point(805, 29);
            this.chkRDR.Name = "chkRDR";
            this.chkRDR.Size = new System.Drawing.Size(118, 17);
            this.chkRDR.TabIndex = 75;
            this.chkRDR.Text = "Somente com RDR";
            this.chkRDR.UseVisualStyleBackColor = true;
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
            this.cmbDisciplina.Location = new System.Drawing.Point(251, 29);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(177, 21);
            this.cmbDisciplina.TabIndex = 63;
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
            this.cmbFPSO.Location = new System.Drawing.Point(159, 29);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(86, 21);
            this.cmbFPSO.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(249, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 74;
            this.label8.Text = "Disciplina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 73;
            this.label7.Text = "FPSO";
            // 
            // txtCodigoMat
            // 
            this.txtCodigoMat.Location = new System.Drawing.Point(549, 27);
            this.txtCodigoMat.Multiline = true;
            this.txtCodigoMat.Name = "txtCodigoMat";
            this.txtCodigoMat.Size = new System.Drawing.Size(115, 68);
            this.txtCodigoMat.TabIndex = 72;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 71;
            this.label6.Text = "Código Material";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Fornecedor";
            // 
            // txtAF
            // 
            this.txtAF.Location = new System.Drawing.Point(439, 29);
            this.txtAF.Name = "txtAF";
            this.txtAF.Size = new System.Drawing.Size(100, 20);
            this.txtAF.TabIndex = 70;
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(159, 75);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(269, 21);
            this.cmbFornecedor.TabIndex = 64;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(436, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 69;
            this.label5.Text = "AF";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(804, 73);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 66;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(439, 76);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(100, 20);
            this.txtNF.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(436, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "NF";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.Location = new System.Drawing.Point(885, 74);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 77;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 65);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(127, 20);
            this.pBox.TabIndex = 61;
            this.pBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // CollectionDTOBindingSource
            // 
            this.CollectionDTOBindingSource.DataSource = typeof(DTO.AcStatusMateriaisDTO);
            // 
            // frmStatusMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 379);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkRDR);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodigoMat);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAF);
            this.Controls.Add(this.cmbFornecedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "frmStatusMateriais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Status de Materiais";
            this.Load += new System.EventHandler(this.frmStatusMateriais_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource CollectionDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk3Diversos;
        private System.Windows.Forms.CheckBox chk2Materiais;
        private System.Windows.Forms.CheckBox chk1Equipamentos;
        private System.Windows.Forms.CheckBox chkRDR;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodigoMat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAF;
        private System.Windows.Forms.ComboBox cmbFornecedor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label4;
    }
}