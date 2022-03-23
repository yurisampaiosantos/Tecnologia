namespace SisPLAN.net
{
    partial class frmAvancoCompletacao
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
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.lblFPSO = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblSemana = new System.Windows.Forms.Label();
            this.cmbEquipe = new System.Windows.Forms.ComboBox();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.cmbZona = new System.Windows.Forms.ComboBox();
            this.lblZona = new System.Windows.Forms.Label();
            this.CollectionDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(308, 37);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(180, 21);
            this.cmbDisciplina.TabIndex = 31;
            this.cmbDisciplina.Visible = false;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // cmbFPSO
            // 
            this.cmbFPSO.FormattingEnabled = true;
            this.cmbFPSO.Location = new System.Drawing.Point(191, 37);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(52, 21);
            this.cmbFPSO.TabIndex = 30;
            this.cmbFPSO.SelectedIndexChanged += new System.EventHandler(this.cmbFPSO_SelectedIndexChanged);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(249, 40);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lblDisciplina.TabIndex = 29;
            this.lblDisciplina.Text = "Disciplina:";
            this.lblDisciplina.Visible = false;
            // 
            // lblFPSO
            // 
            this.lblFPSO.AutoSize = true;
            this.lblFPSO.Location = new System.Drawing.Point(145, 40);
            this.lblFPSO.Name = "lblFPSO";
            this.lblFPSO.Size = new System.Drawing.Size(38, 13);
            this.lblFPSO.TabIndex = 28;
            this.lblFPSO.Text = "FPSO:";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(543, 62);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(60, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
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
            this.reportViewer1.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(10, 88);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(60, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "Comentário";
            this.lblProgress.Visible = false;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 105);
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
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(609, 62);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 62;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.Location = new System.Drawing.Point(145, 21);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Size = new System.Drawing.Size(112, 13);
            this.lblSemana.TabIndex = 63;
            this.lblSemana.Text = "Semana Corrente: ";
            // 
            // cmbEquipe
            // 
            this.cmbEquipe.FormattingEnabled = true;
            this.cmbEquipe.Location = new System.Drawing.Point(191, 64);
            this.cmbEquipe.Name = "cmbEquipe";
            this.cmbEquipe.Size = new System.Drawing.Size(52, 21);
            this.cmbEquipe.TabIndex = 65;
            this.cmbEquipe.Visible = false;
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Location = new System.Drawing.Point(145, 67);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(43, 13);
            this.lblEquipe.TabIndex = 64;
            this.lblEquipe.Text = "Equipe:";
            this.lblEquipe.Visible = false;
            // 
            // cmbZona
            // 
            this.cmbZona.FormattingEnabled = true;
            this.cmbZona.Location = new System.Drawing.Point(308, 64);
            this.cmbZona.Name = "cmbZona";
            this.cmbZona.Size = new System.Drawing.Size(180, 21);
            this.cmbZona.TabIndex = 67;
            this.cmbZona.Visible = false;
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Location = new System.Drawing.Point(269, 67);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(35, 13);
            this.lblZona.TabIndex = 66;
            this.lblZona.Text = "Zona:";
            this.lblZona.Visible = false;
            // 
            // CollectionDTOBindingSource
            // 
            this.CollectionDTOBindingSource.DataSource = typeof(DTO.CollectionAcRamAtividadeDTO);
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(543, 37);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(180, 21);
            this.cmbCriterio.TabIndex = 69;
            this.cmbCriterio.Visible = false;
            this.cmbCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbCriterio_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(498, 40);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 68;
            this.lblCriterio.Text = "Critério:";
            this.lblCriterio.Visible = false;
            // 
            // frmAvancoCompletacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 379);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.cmbZona);
            this.Controls.Add(this.lblZona);
            this.Controls.Add(this.cmbEquipe);
            this.Controls.Add(this.lblEquipe);
            this.Controls.Add(this.lblSemana);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.lblFPSO);
            this.Name = "frmAvancoCompletacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Avanços para Completação";
            this.Load += new System.EventHandler(this.frmAvancoCompletacao_Load);
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
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Label lblFPSO;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.ComboBox cmbEquipe;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.ComboBox cmbZona;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Label lblCriterio;
    }
}