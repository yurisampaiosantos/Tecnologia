namespace SisPLAN.net
{
    partial class frmRecebimentoMateriais
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
            this.CollectionVwAcRecebimentoMateriaisDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.txtAF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbFornecedor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.chkExibirCorridas = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionVwAcRecebimentoMateriaisDTOBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CollectionVwAcRecebimentoMateriaisDTOBindingSource
            // 
            this.CollectionVwAcRecebimentoMateriaisDTOBindingSource.DataSource = typeof(DTO.CollectionVwAcRecebimentoMateriaisDTO);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chk3Diversos);
            this.panel2.Controls.Add(this.chk2Materiais);
            this.panel2.Controls.Add(this.chk1Equipamentos);
            this.panel2.Location = new System.Drawing.Point(848, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(114, 74);
            this.panel2.TabIndex = 33;
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
            this.chkRDR.Location = new System.Drawing.Point(981, 30);
            this.chkRDR.Name = "chkRDR";
            this.chkRDR.Size = new System.Drawing.Size(118, 17);
            this.chkRDR.TabIndex = 32;
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
            this.cmbDisciplina.Location = new System.Drawing.Point(290, 75);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(110, 21);
            this.cmbDisciplina.TabIndex = 31;
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
            this.cmbFPSO.Location = new System.Drawing.Point(148, 75);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(110, 21);
            this.cmbFPSO.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Disciplina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "FPSO";
            // 
            // txtCodigoMat
            // 
            this.txtCodigoMat.Location = new System.Drawing.Point(720, 27);
            this.txtCodigoMat.Multiline = true;
            this.txtCodigoMat.Name = "txtCodigoMat";
            this.txtCodigoMat.Size = new System.Drawing.Size(115, 68);
            this.txtCodigoMat.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(717, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Código Material";
            // 
            // txtAF
            // 
            this.txtAF.Location = new System.Drawing.Point(576, 75);
            this.txtAF.Name = "txtAF";
            this.txtAF.Size = new System.Drawing.Size(100, 20);
            this.txtAF.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(573, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "AF";
            // 
            // txtNF
            // 
            this.txtNF.Location = new System.Drawing.Point(434, 75);
            this.txtNF.Name = "txtNF";
            this.txtNF.Size = new System.Drawing.Size(100, 20);
            this.txtNF.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(431, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "NF";
            // 
            // dtpFim
            // 
            this.dtpFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFim.Location = new System.Drawing.Point(290, 29);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(110, 20);
            this.dtpFim.TabIndex = 21;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(148, 29);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(110, 20);
            this.dtpInicio.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Período de";
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(981, 72);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbFornecedor
            // 
            this.cmbFornecedor.FormattingEnabled = true;
            this.cmbFornecedor.Location = new System.Drawing.Point(435, 27);
            this.cmbFornecedor.Name = "cmbFornecedor";
            this.cmbFornecedor.Size = new System.Drawing.Size(269, 21);
            this.cmbFornecedor.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Fornecedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(287, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Até";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "dsVwAcRecebimentoMateriais";
            reportDataSource1.Value = this.CollectionVwAcRecebimentoMateriaisDTOBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.RecebimentoMateriais.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 121);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(1340, 190);
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
            this.lblProgress.Size = new System.Drawing.Size(13, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "+";
            this.lblProgress.Visible = false;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 100);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 56;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(1062, 72);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 57;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 65);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(127, 20);
            this.pBox.TabIndex = 58;
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
            // chkExibirCorridas
            // 
            this.chkExibirCorridas.AutoSize = true;
            this.chkExibirCorridas.Location = new System.Drawing.Point(981, 50);
            this.chkExibirCorridas.Name = "chkExibirCorridas";
            this.chkExibirCorridas.Size = new System.Drawing.Size(92, 17);
            this.chkExibirCorridas.TabIndex = 59;
            this.chkExibirCorridas.Text = "Exibir Corridas";
            this.chkExibirCorridas.UseVisualStyleBackColor = true;
            // 
            // frmRecebimentoMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 807);
            this.Controls.Add(this.chkExibirCorridas);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkRDR);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoMat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAF);
            this.Controls.Add(this.cmbFornecedor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtNF);
            this.Controls.Add(this.dtpInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpFim);
            this.Name = "frmRecebimentoMateriais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recebimento de Materiais - v1.0.0";
            this.Load += new System.EventHandler(this.frmRecebimentoMateriais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CollectionVwAcRecebimentoMateriaisDTOBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cmbFornecedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.BindingSource CollectionVwAcRecebimentoMateriaisDTOBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txtAF;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoMat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkRDR;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chk2Materiais;
        private System.Windows.Forms.CheckBox chk1Equipamentos;
        private System.Windows.Forms.CheckBox chk3Diversos;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox chkExibirCorridas;
    }
}