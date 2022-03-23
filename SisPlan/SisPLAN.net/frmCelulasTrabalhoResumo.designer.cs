namespace SisPLAN.net
{
    partial class frmCelulasTrabalhoResumo
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
            this.pb = new System.Windows.Forms.ProgressBar();
            this.cmbSemana = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLocalizacao = new System.Windows.Forms.ComboBox();
            this.cmbSetor = new System.Windows.Forms.ComboBox();
            this.lblUltimoCalculo = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRecalcular = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEquipe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AcControleProducaoDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcControleProducaoDTOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(564, 52);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(376, 20);
            this.pb.TabIndex = 43;
            this.pb.Visible = false;
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
            this.cmbSemana.Location = new System.Drawing.Point(146, 28);
            this.cmbSemana.Name = "cmbSemana";
            this.cmbSemana.Size = new System.Drawing.Size(175, 21);
            this.cmbSemana.TabIndex = 40;
            this.cmbSemana.SelectedIndexChanged += new System.EventHandler(this.cmbSemana_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Semana";
            // 
            // cmbLocalizacao
            // 
            this.cmbLocalizacao.Enabled = false;
            this.cmbLocalizacao.FormattingEnabled = true;
            this.cmbLocalizacao.Location = new System.Drawing.Point(740, 28);
            this.cmbLocalizacao.Name = "cmbLocalizacao";
            this.cmbLocalizacao.Size = new System.Drawing.Size(200, 21);
            this.cmbLocalizacao.TabIndex = 38;
            // 
            // cmbSetor
            // 
            this.cmbSetor.Enabled = false;
            this.cmbSetor.FormattingEnabled = true;
            this.cmbSetor.Location = new System.Drawing.Point(564, 28);
            this.cmbSetor.Name = "cmbSetor";
            this.cmbSetor.Size = new System.Drawing.Size(170, 21);
            this.cmbSetor.TabIndex = 37;
            this.cmbSetor.SelectedIndexChanged += new System.EventHandler(this.cmbSetor_SelectedIndexChanged);
            // 
            // lblUltimoCalculo
            // 
            this.lblUltimoCalculo.AutoSize = true;
            this.lblUltimoCalculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUltimoCalculo.Location = new System.Drawing.Point(145, 52);
            this.lblUltimoCalculo.Name = "lblUltimoCalculo";
            this.lblUltimoCalculo.Size = new System.Drawing.Size(104, 16);
            this.lblUltimoCalculo.TabIndex = 36;
            this.lblUltimoCalculo.Text = "UltimoCalculo";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(392, 28);
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
            this.cmbFPSO.Location = new System.Drawing.Point(327, 28);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(59, 21);
            this.cmbFPSO.TabIndex = 34;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(390, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Disciplina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(325, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "FPSO";
            // 
            // chkRecalcular
            // 
            this.chkRecalcular.Location = new System.Drawing.Point(973, 57);
            this.chkRecalcular.Name = "chkRecalcular";
            this.chkRecalcular.Size = new System.Drawing.Size(77, 17);
            this.chkRecalcular.TabIndex = 30;
            this.chkRecalcular.Text = "Recalcular";
            this.chkRecalcular.UseVisualStyleBackColor = true;
            this.chkRecalcular.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(505, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Equipe";
            // 
            // cmbEquipe
            // 
            this.cmbEquipe.FormattingEnabled = true;
            this.cmbEquipe.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17"});
            this.cmbEquipe.Location = new System.Drawing.Point(508, 28);
            this.cmbEquipe.Name = "cmbEquipe";
            this.cmbEquipe.Size = new System.Drawing.Size(50, 21);
            this.cmbEquipe.TabIndex = 28;
            this.cmbEquipe.SelectedIndexChanged += new System.EventHandler(this.cmbEquipe_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(738, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Localização";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(561, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Setor";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(946, 26);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
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
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(156, 99);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 13;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 80);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 57;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(1028, 26);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 58;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsPendenciaMateriais";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.PendenciaMateriais.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 90);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1450, 148);
            this.reportViewer1.TabIndex = 59;
            this.reportViewer1.Visible = false;
            // 
            // AcControleProducaoDTOBindingSource
            // 
            this.AcControleProducaoDTOBindingSource.DataSource = typeof(DTO.AcControleProducaoDTO);
            // 
            // DTOBindingSource
            // 
            this.DTOBindingSource.DataSource = typeof(DTO.CollectionAcControleProducaoDTO);
            // 
            // frmCelulasTrabalhoResumo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1810, 755);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.cmbSemana);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLocalizacao);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbSetor);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblUltimoCalculo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.cmbEquipe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkRecalcular);
            this.Name = "frmCelulasTrabalhoResumo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Células de Trabalho Resumo v1.0.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmCelulasTrabalhoResumo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AcControleProducaoDTOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTOBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource DTOBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEquipe;
        private System.Windows.Forms.CheckBox chkRecalcular;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblUltimoCalculo;
        private System.Windows.Forms.ComboBox cmbLocalizacao;
        private System.Windows.Forms.ComboBox cmbSetor;
        private System.Windows.Forms.ComboBox cmbSemana;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.BindingSource AcControleProducaoDTOBindingSource;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Button btnExcel;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}