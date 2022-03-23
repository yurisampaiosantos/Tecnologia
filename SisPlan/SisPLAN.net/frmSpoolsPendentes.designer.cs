namespace SisPLAN.net
{
    partial class frmSpoolsPendentes
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CollectionAcStatusTubDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionAcStatusTubDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsPendenciaMateriais";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.PendenciaMateriais.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 85);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1450, 148);
            this.reportViewer1.TabIndex = 13;
            this.reportViewer1.Visible = false;
            // 
            // CollectionAcStatusTubDTOBindingSource
            // 
            this.CollectionAcStatusTubDTOBindingSource.DataSource = typeof(DTO.CollectionAcControleFolhaServicoDTO);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(149, 53);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 54;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(213, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 53;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
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
            this.cmbFPSO.Location = new System.Drawing.Point(148, 28);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(59, 21);
            this.cmbFPSO.TabIndex = 52;
            this.cmbFPSO.SelectedIndexChanged += new System.EventHandler(this.cmbFPSO_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 51;
            this.label7.Text = "FPSO";
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 70);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 56;
            // 
            // frmSpoolsPendentes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1743, 802);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Name = "frmSpoolsPendentes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Spools Pendentes";
            this.Load += new System.EventHandler(this.frmSpoolsPendentes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionAcStatusTubDTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.BindingSource CollectionAcStatusTubDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel panelDivision;
        
    }
}