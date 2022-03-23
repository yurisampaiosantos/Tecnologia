namespace SisPLAN.net
{
    partial class frmEstoqueMaterial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstoqueMaterial));
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.lblFPSO = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaterial = new System.Windows.Forms.TextBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CollectionDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.cmbFPSO.Location = new System.Drawing.Point(181, 19);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(52, 21);
            this.cmbFPSO.TabIndex = 30;
            // 
            // lblFPSO
            // 
            this.lblFPSO.AutoSize = true;
            this.lblFPSO.Location = new System.Drawing.Point(145, 23);
            this.lblFPSO.Name = "lblFPSO";
            this.lblFPSO.Size = new System.Drawing.Size(38, 13);
            this.lblFPSO.TabIndex = 28;
            this.lblFPSO.Text = "FPSO:";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(494, 17);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(60, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Material:";
            // 
            // txtMaterial
            // 
            this.txtMaterial.Location = new System.Drawing.Point(305, 20);
            this.txtMaterial.Name = "txtMaterial";
            this.txtMaterial.Size = new System.Drawing.Size(174, 20);
            this.txtMaterial.TabIndex = 64;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(560, 17);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 62;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 61);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(127, 20);
            this.pBox.TabIndex = 61;
            this.pBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 65;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // CollectionDTOBindingSource
            // 
            this.CollectionDTOBindingSource.DataSource = typeof(DTO.CollectionAcRamAtividadeDTO);
            // 
            // frmEstoqueMaterial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 379);
            this.Controls.Add(this.txtMaterial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.lblFPSO);
            this.Name = "frmEstoqueMaterial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Estoque de Materiais";
            this.Load += new System.EventHandler(this.frmEstoqueMaterial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.BindingSource CollectionDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label lblFPSO;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaterial;
    }
}