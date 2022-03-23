namespace SisPLAN.net
{
    partial class frmPastaResumoAreaDisciplina
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.txtMaTlc = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtErprTlc = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtMsTlc = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtCascoTlc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaIns = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtMaEle = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtMaTub = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMaMec = new System.Windows.Forms.TextBox();
            this.lblMa = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMsIns = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMsEle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMsTub = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtMsMec = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtErprIns = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtErprEle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtErprTub = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtErprMec = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCascoIns = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCascoEle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCascoTub = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCascoMec = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.cmbFPSO = new System.Windows.Forms.ComboBox();
            this.lblFPSO = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.CollectionDTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CollectionDTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource3.Name = "dsRAMAtividade";
            reportDataSource3.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SisPLAN.net.rdlcRAMAtividade.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 113);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1264, 151);
            this.reportViewer1.TabIndex = 11;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 109);
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
            // panelFilter
            // 
            this.panelFilter.Controls.Add(this.label23);
            this.panelFilter.Controls.Add(this.txtMaTlc);
            this.panelFilter.Controls.Add(this.label24);
            this.panelFilter.Controls.Add(this.txtErprTlc);
            this.panelFilter.Controls.Add(this.label21);
            this.panelFilter.Controls.Add(this.txtMsTlc);
            this.panelFilter.Controls.Add(this.label22);
            this.panelFilter.Controls.Add(this.txtCascoTlc);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.txtMaIns);
            this.panelFilter.Controls.Add(this.label17);
            this.panelFilter.Controls.Add(this.txtMaEle);
            this.panelFilter.Controls.Add(this.label18);
            this.panelFilter.Controls.Add(this.txtMaTub);
            this.panelFilter.Controls.Add(this.label19);
            this.panelFilter.Controls.Add(this.txtMaMec);
            this.panelFilter.Controls.Add(this.lblMa);
            this.panelFilter.Controls.Add(this.label12);
            this.panelFilter.Controls.Add(this.txtMsIns);
            this.panelFilter.Controls.Add(this.label13);
            this.panelFilter.Controls.Add(this.txtMsEle);
            this.panelFilter.Controls.Add(this.label14);
            this.panelFilter.Controls.Add(this.txtMsTub);
            this.panelFilter.Controls.Add(this.label15);
            this.panelFilter.Controls.Add(this.txtMsMec);
            this.panelFilter.Controls.Add(this.label16);
            this.panelFilter.Controls.Add(this.label7);
            this.panelFilter.Controls.Add(this.txtErprIns);
            this.panelFilter.Controls.Add(this.label8);
            this.panelFilter.Controls.Add(this.txtErprEle);
            this.panelFilter.Controls.Add(this.label9);
            this.panelFilter.Controls.Add(this.txtErprTub);
            this.panelFilter.Controls.Add(this.label10);
            this.panelFilter.Controls.Add(this.txtErprMec);
            this.panelFilter.Controls.Add(this.label11);
            this.panelFilter.Controls.Add(this.label6);
            this.panelFilter.Controls.Add(this.txtCascoIns);
            this.panelFilter.Controls.Add(this.label5);
            this.panelFilter.Controls.Add(this.txtCascoEle);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.txtCascoTub);
            this.panelFilter.Controls.Add(this.label3);
            this.panelFilter.Controls.Add(this.txtCascoMec);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Location = new System.Drawing.Point(148, 37);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1126, 51);
            this.panelFilter.TabIndex = 108;
            this.panelFilter.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(1032, 27);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 13);
            this.label23.TabIndex = 156;
            this.label23.Text = "TLC:";
            // 
            // txtMaTlc
            // 
            this.txtMaTlc.Location = new System.Drawing.Point(1067, 24);
            this.txtMaTlc.Name = "txtMaTlc";
            this.txtMaTlc.Size = new System.Drawing.Size(53, 20);
            this.txtMaTlc.TabIndex = 155;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(1032, 5);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 13);
            this.label24.TabIndex = 154;
            this.label24.Text = "TLC:";
            // 
            // txtErprTlc
            // 
            this.txtErprTlc.Location = new System.Drawing.Point(1067, 2);
            this.txtErprTlc.Name = "txtErprTlc";
            this.txtErprTlc.Size = new System.Drawing.Size(53, 20);
            this.txtErprTlc.TabIndex = 153;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(467, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(34, 13);
            this.label21.TabIndex = 152;
            this.label21.Text = "TLC:";
            // 
            // txtMsTlc
            // 
            this.txtMsTlc.Location = new System.Drawing.Point(502, 24);
            this.txtMsTlc.Name = "txtMsTlc";
            this.txtMsTlc.Size = new System.Drawing.Size(53, 20);
            this.txtMsTlc.TabIndex = 151;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(467, 5);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 150;
            this.label22.Text = "TLC:";
            // 
            // txtCascoTlc
            // 
            this.txtCascoTlc.Location = new System.Drawing.Point(502, 2);
            this.txtCascoTlc.Name = "txtCascoTlc";
            this.txtCascoTlc.Size = new System.Drawing.Size(53, 20);
            this.txtCascoTlc.TabIndex = 149;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(938, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 148;
            this.label2.Text = "INS:";
            // 
            // txtMaIns
            // 
            this.txtMaIns.Location = new System.Drawing.Point(973, 24);
            this.txtMaIns.Name = "txtMaIns";
            this.txtMaIns.Size = new System.Drawing.Size(53, 20);
            this.txtMaIns.TabIndex = 147;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(842, 27);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 146;
            this.label17.Text = "ELE:";
            // 
            // txtMaEle
            // 
            this.txtMaEle.Location = new System.Drawing.Point(878, 24);
            this.txtMaEle.Name = "txtMaEle";
            this.txtMaEle.Size = new System.Drawing.Size(53, 20);
            this.txtMaEle.TabIndex = 145;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(747, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(36, 13);
            this.label18.TabIndex = 144;
            this.label18.Text = "TUB:";
            // 
            // txtMaTub
            // 
            this.txtMaTub.Location = new System.Drawing.Point(785, 24);
            this.txtMaTub.Name = "txtMaTub";
            this.txtMaTub.Size = new System.Drawing.Size(53, 20);
            this.txtMaTub.TabIndex = 143;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(653, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 142;
            this.label19.Text = "MEC:";
            // 
            // txtMaMec
            // 
            this.txtMaMec.Location = new System.Drawing.Point(692, 24);
            this.txtMaMec.Name = "txtMaMec";
            this.txtMaMec.Size = new System.Drawing.Size(53, 20);
            this.txtMaMec.TabIndex = 141;
            // 
            // lblMa
            // 
            this.lblMa.AutoSize = true;
            this.lblMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.lblMa.Location = new System.Drawing.Point(577, 27);
            this.lblMa.Name = "lblMa";
            this.lblMa.Size = new System.Drawing.Size(70, 13);
            this.lblMa.TabIndex = 140;
            this.lblMa.Text = "MA      ==>";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(369, 27);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(32, 13);
            this.label12.TabIndex = 139;
            this.label12.Text = "INS:";
            // 
            // txtMsIns
            // 
            this.txtMsIns.Location = new System.Drawing.Point(404, 24);
            this.txtMsIns.Name = "txtMsIns";
            this.txtMsIns.Size = new System.Drawing.Size(53, 20);
            this.txtMsIns.TabIndex = 138;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(267, 27);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 137;
            this.label13.Text = "ELE:";
            // 
            // txtMsEle
            // 
            this.txtMsEle.Location = new System.Drawing.Point(303, 24);
            this.txtMsEle.Name = "txtMsEle";
            this.txtMsEle.Size = new System.Drawing.Size(53, 20);
            this.txtMsEle.TabIndex = 136;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(172, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 135;
            this.label14.Text = "TUB:";
            // 
            // txtMsTub
            // 
            this.txtMsTub.Location = new System.Drawing.Point(210, 24);
            this.txtMsTub.Name = "txtMsTub";
            this.txtMsTub.Size = new System.Drawing.Size(53, 20);
            this.txtMsTub.TabIndex = 134;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(78, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 133;
            this.label15.Text = "MEC:";
            // 
            // txtMsMec
            // 
            this.txtMsMec.Location = new System.Drawing.Point(117, 24);
            this.txtMsMec.Name = "txtMsMec";
            this.txtMsMec.Size = new System.Drawing.Size(53, 20);
            this.txtMsMec.TabIndex = 132;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.label16.Location = new System.Drawing.Point(-1, 27);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 13);
            this.label16.TabIndex = 131;
            this.label16.Text = "MS       ==>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(938, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 130;
            this.label7.Text = "INS:";
            // 
            // txtErprIns
            // 
            this.txtErprIns.Location = new System.Drawing.Point(973, 2);
            this.txtErprIns.Name = "txtErprIns";
            this.txtErprIns.Size = new System.Drawing.Size(53, 20);
            this.txtErprIns.TabIndex = 129;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(842, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 128;
            this.label8.Text = "ELE:";
            // 
            // txtErprEle
            // 
            this.txtErprEle.Location = new System.Drawing.Point(878, 2);
            this.txtErprEle.Name = "txtErprEle";
            this.txtErprEle.Size = new System.Drawing.Size(53, 20);
            this.txtErprEle.TabIndex = 127;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(747, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 126;
            this.label9.Text = "TUB:";
            // 
            // txtErprTub
            // 
            this.txtErprTub.Location = new System.Drawing.Point(785, 2);
            this.txtErprTub.Name = "txtErprTub";
            this.txtErprTub.Size = new System.Drawing.Size(53, 20);
            this.txtErprTub.TabIndex = 125;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(653, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 124;
            this.label10.Text = "MEC:";
            // 
            // txtErprMec
            // 
            this.txtErprMec.Location = new System.Drawing.Point(692, 2);
            this.txtErprMec.Name = "txtErprMec";
            this.txtErprMec.Size = new System.Drawing.Size(53, 20);
            this.txtErprMec.TabIndex = 123;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.label11.Location = new System.Drawing.Point(575, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 122;
            this.label11.Text = "ER/PR ==>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(369, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 121;
            this.label6.Text = "INS:";
            // 
            // txtCascoIns
            // 
            this.txtCascoIns.Location = new System.Drawing.Point(404, 2);
            this.txtCascoIns.Name = "txtCascoIns";
            this.txtCascoIns.Size = new System.Drawing.Size(53, 20);
            this.txtCascoIns.TabIndex = 120;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(267, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 119;
            this.label5.Text = "ELE:";
            // 
            // txtCascoEle
            // 
            this.txtCascoEle.Location = new System.Drawing.Point(303, 2);
            this.txtCascoEle.Name = "txtCascoEle";
            this.txtCascoEle.Size = new System.Drawing.Size(53, 20);
            this.txtCascoEle.TabIndex = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(172, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 117;
            this.label4.Text = "TUB:";
            // 
            // txtCascoTub
            // 
            this.txtCascoTub.Location = new System.Drawing.Point(210, 2);
            this.txtCascoTub.Name = "txtCascoTub";
            this.txtCascoTub.Size = new System.Drawing.Size(53, 20);
            this.txtCascoTub.TabIndex = 116;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "MEC:";
            // 
            // txtCascoMec
            // 
            this.txtCascoMec.Location = new System.Drawing.Point(117, 2);
            this.txtCascoMec.Name = "txtCascoMec";
            this.txtCascoMec.Size = new System.Drawing.Size(53, 20);
            this.txtCascoMec.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "CASCO ==>";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(9, 93);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(60, 13);
            this.lblProgress.TabIndex = 108;
            this.lblProgress.Text = "Comentário";
            this.lblProgress.Visible = false;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(651, 10);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(108, 23);
            this.btnExecute.TabIndex = 109;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Visible = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // cmbFPSO
            // 
            this.cmbFPSO.FormattingEnabled = true;
            this.cmbFPSO.Location = new System.Drawing.Point(190, 12);
            this.cmbFPSO.Name = "cmbFPSO";
            this.cmbFPSO.Size = new System.Drawing.Size(52, 21);
            this.cmbFPSO.TabIndex = 111;
            this.cmbFPSO.SelectedIndexChanged += new System.EventHandler(this.cmbFPSO_SelectedIndexChanged);
            // 
            // lblFPSO
            // 
            this.lblFPSO.AutoSize = true;
            this.lblFPSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFPSO.Location = new System.Drawing.Point(145, 16);
            this.lblFPSO.Name = "lblFPSO";
            this.lblFPSO.Size = new System.Drawing.Size(43, 13);
            this.lblFPSO.TabIndex = 110;
            this.lblFPSO.Text = "FPSO:";
            this.lblFPSO.Click += new System.EventHandler(this.lblFPSO_Click);
            // 
            // pBox
            // 
            this.pBox.Location = new System.Drawing.Point(12, 66);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(127, 20);
            this.pBox.TabIndex = 61;
            this.pBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SisPLAN.net.Properties.Resources.excel;
            this.btnExcel.Location = new System.Drawing.Point(765, 9);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(23, 23);
            this.btnExcel.TabIndex = 112;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Visible = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cmbArea
            // 
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(295, 12);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(141, 21);
            this.cmbArea.TabIndex = 228;
            this.cmbArea.SelectedIndexChanged += new System.EventHandler(this.cmbArea_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(251, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 13);
            this.label20.TabIndex = 227;
            this.label20.Text = "Área:";
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Items.AddRange(new object[] {
            "MEC",
            "TUB",
            "ELE",
            "INS",
            "TLC"});
            this.cmbDisciplina.Location = new System.Drawing.Point(512, 10);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(116, 21);
            this.cmbDisciplina.TabIndex = 230;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(442, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 13);
            this.label25.TabIndex = 229;
            this.label25.Text = "Disciplina:";
            // 
            // CollectionDTOBindingSource
            // 
            this.CollectionDTOBindingSource.DataSource = typeof(DTO.CollectionAcRamAtividadeDTO);
            // 
            // frmPastaResumoAreaDisciplina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 379);
            this.Controls.Add(this.cmbDisciplina);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lblFPSO);
            this.Controls.Add(this.cmbFPSO);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnExcel);
            this.Name = "frmPastaResumoAreaDisciplina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resumo de Pastas por Área e Disciplina";
            this.Load += new System.EventHandler(this.frmPastaResumoAreaDisciplina_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
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
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtMaTlc;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtErprTlc;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtMsTlc;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtCascoTlc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaIns;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMaEle;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtMaTub;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtMaMec;
        private System.Windows.Forms.Label lblMa;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMsIns;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMsEle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMsTub;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtMsMec;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtErprIns;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtErprEle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtErprTub;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtErprMec;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCascoIns;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCascoEle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCascoTub;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCascoMec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.ComboBox cmbFPSO;
        private System.Windows.Forms.Label lblFPSO;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label25;
    }
}