namespace SisPLAN.net
{
    partial class frmRAM
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
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.cmbAtividade = new System.Windows.Forms.ComboBox();
            this.lblAtividade = new System.Windows.Forms.Label();
            this.cmbSemana = new System.Windows.Forms.ComboBox();
            this.rbSemana = new System.Windows.Forms.RadioButton();
            this.rbPeriodo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.lblDisciplina = new System.Windows.Forms.Label();
            this.lblFPSO = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.CollectionDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelDivision = new System.Windows.Forms.Panel();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(706, 41);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(395, 21);
            this.cmbCriterio.TabIndex = 45;
            this.cmbCriterio.Visible = false;
            this.cmbCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbCriterio_SelectedIndexChanged);
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(664, 44);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(42, 13);
            this.lblCriterio.TabIndex = 44;
            this.lblCriterio.Text = "Critério:";
            this.lblCriterio.Visible = false;
            // 
            // cmbAtividade
            // 
            this.cmbAtividade.FormattingEnabled = true;
            this.cmbAtividade.Location = new System.Drawing.Point(212, 41);
            this.cmbAtividade.Name = "cmbAtividade";
            this.cmbAtividade.Size = new System.Drawing.Size(446, 21);
            this.cmbAtividade.TabIndex = 43;
            this.cmbAtividade.Visible = false;
            this.cmbAtividade.SelectedIndexChanged += new System.EventHandler(this.cmbAtividade_SelectedIndexChanged);
            // 
            // lblAtividade
            // 
            this.lblAtividade.AutoSize = true;
            this.lblAtividade.Location = new System.Drawing.Point(157, 44);
            this.lblAtividade.Name = "lblAtividade";
            this.lblAtividade.Size = new System.Drawing.Size(54, 13);
            this.lblAtividade.TabIndex = 42;
            this.lblAtividade.Text = "Atividade:";
            this.lblAtividade.Visible = false;
            // 
            // cmbSemana
            // 
            this.cmbSemana.FormattingEnabled = true;
            this.cmbSemana.Items.AddRange(new object[] {
            "",
            "P74",
            "P75",
            "P76",
            "P77"});
            this.cmbSemana.Location = new System.Drawing.Point(276, 12);
            this.cmbSemana.Name = "cmbSemana";
            this.cmbSemana.Size = new System.Drawing.Size(184, 21);
            this.cmbSemana.TabIndex = 41;
            this.cmbSemana.Visible = false;
            this.cmbSemana.SelectedIndexChanged += new System.EventHandler(this.cmbSemana_SelectedIndexChanged);
            // 
            // rbSemana
            // 
            this.rbSemana.AutoSize = true;
            this.rbSemana.Location = new System.Drawing.Point(215, 13);
            this.rbSemana.Name = "rbSemana";
            this.rbSemana.Size = new System.Drawing.Size(67, 17);
            this.rbSemana.TabIndex = 34;
            this.rbSemana.Text = "Semana:";
            this.rbSemana.UseVisualStyleBackColor = true;
            this.rbSemana.CheckedChanged += new System.EventHandler(this.rbSemana_CheckedChanged);
            // 
            // rbPeriodo
            // 
            this.rbPeriodo.AutoSize = true;
            this.rbPeriodo.Checked = true;
            this.rbPeriodo.Location = new System.Drawing.Point(466, 13);
            this.rbPeriodo.Name = "rbPeriodo";
            this.rbPeriodo.Size = new System.Drawing.Size(81, 17);
            this.rbPeriodo.TabIndex = 33;
            this.rbPeriodo.TabStop = true;
            this.rbPeriodo.Text = "Período de:";
            this.rbPeriodo.UseVisualStyleBackColor = true;
            this.rbPeriodo.CheckedChanged += new System.EventHandler(this.rbPeriodo_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Emissão por: ";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(991, 12);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(110, 21);
            this.cmbDisciplina.TabIndex = 31;
            this.cmbDisciplina.Visible = false;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // cmbFPSO
            // 
            this.cmbFPSO.FormattingEnabled = true;
            this.cmbFPSO.Location = new System.Drawing.Point(866, 12);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(52, 21);
            this.cmbFPSO.TabIndex = 30;
            this.cmbFPSO.Visible = false;
            this.cmbFPSO.SelectedIndexChanged += new System.EventHandler(this.cmbFPSO_SelectedIndexChanged);
            // 
            // lblDisciplina
            // 
            this.lblDisciplina.AutoSize = true;
            this.lblDisciplina.Location = new System.Drawing.Point(938, 14);
            this.lblDisciplina.Name = "lblDisciplina";
            this.lblDisciplina.Size = new System.Drawing.Size(55, 13);
            this.lblDisciplina.TabIndex = 29;
            this.lblDisciplina.Text = "Disciplina:";
            this.lblDisciplina.Visible = false;
            // 
            // lblFPSO
            // 
            this.lblFPSO.AutoSize = true;
            this.lblFPSO.Location = new System.Drawing.Point(830, 16);
            this.lblFPSO.Name = "lblFPSO";
            this.lblFPSO.Size = new System.Drawing.Size(38, 13);
            this.lblFPSO.TabIndex = 28;
            this.lblFPSO.Text = "FPSO:";
            this.lblFPSO.Visible = false;
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(706, 11);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(111, 20);
            this.dtpFim.TabIndex = 21;
            this.dtpFim.ValueChanged += new System.EventHandler(this.dtpFim_ValueChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(545, 13);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(110, 20);
            this.dtpInicio.TabIndex = 20;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(1111, 39);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(60, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Até:";
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
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Visible = false;
            // 
            // CollectionDTOBindingSource
            // 
            this.CollectionDTOBindingSource.DataSource = typeof(DTO.CollectionAcRamAtividadeDTO);
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 100);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 57;
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 65);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(127, 20);
            this.pBox.TabIndex = 61;
            this.pBox.TabStop = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnRunWorkerCompleted);
            // 
            // frmRAM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 379);
            this.Controls.Add(this.cmbCriterio);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.lblCriterio);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.cmbAtividade);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblAtividade);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbSemana);
            this.Controls.Add(this.rbSemana);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rbPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.lblDisciplina);
            this.Controls.Add(this.dtpFim);
            this.Controls.Add(this.lblFPSO);
            this.Name = "frmRAM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RAM";
            this.Load += new System.EventHandler(this.frmRAM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.BindingSource CollectionDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label lblDisciplina;
        private System.Windows.Forms.Label lblFPSO;
        private System.Windows.Forms.RadioButton rbSemana;
        private System.Windows.Forms.RadioButton rbPeriodo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSemana;
        private System.Windows.Forms.ComboBox cmbAtividade;
        private System.Windows.Forms.Label lblAtividade;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}