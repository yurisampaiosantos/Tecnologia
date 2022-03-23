namespace wfPrintDDPS
{
    partial class frmGenerationPDF
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ListTimeSheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ListActivitiesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ListTimeSheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListActivitiesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ListTimeSheetsBindingSource
            // 
            this.ListTimeSheetsBindingSource.DataSource = typeof(GridCarregamento.Modelo.ListTimeSheets);
            // 
            // ListActivitiesBindingSource
            // 
            this.ListActivitiesBindingSource.DataSource = typeof(GridCarregamento.Modelo.ListActivities);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Right;
            reportDataSource1.Name = "dsCraft";
            reportDataSource1.Value = this.ListTimeSheetsBindingSource;
            reportDataSource2.Name = "dsActivities";
            reportDataSource2.Value = this.ListActivitiesBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "wfPrintDDPS.rFolhaApropriacao.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "";
            this.reportViewer1.Location = new System.Drawing.Point(438, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(402, 282);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(this.reportViewer1_RenderingComplete);
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Left;
            reportDataSource3.Name = "dsCraft";
            reportDataSource3.Value = this.ListTimeSheetsBindingSource;
            reportDataSource4.Name = "dsActivities";
            reportDataSource4.Value = this.ListActivitiesBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "wfPrintDDPS.rFolhaApropriacao.rdlc";
            this.reportViewer2.LocalReport.ReportPath = "";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(399, 282);
            this.reportViewer2.TabIndex = 1;
            // 
            // frmGenerationPDF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 282);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmGenerationPDF";
            this.Text = "frmGenerationPDF";
            this.Load += new System.EventHandler(this.frmGenerationPDF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListTimeSheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListActivitiesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ListTimeSheetsBindingSource;
        private System.Windows.Forms.BindingSource ListActivitiesBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
    }
}