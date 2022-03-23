namespace SisPLAN.net
{
    partial class frmAgrupamentoMateriais
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
            this.btnAgrupar = new System.Windows.Forms.Button();
            this.gridView1 = new System.Windows.Forms.DataGridView();
            this.txtFOSE = new System.Windows.Forms.TextBox();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAgrupar
            // 
            this.btnAgrupar.Location = new System.Drawing.Point(997, 40);
            this.btnAgrupar.Name = "btnAgrupar";
            this.btnAgrupar.Size = new System.Drawing.Size(90, 23);
            this.btnAgrupar.TabIndex = 0;
            this.btnAgrupar.Text = "Agrupar";
            this.btnAgrupar.UseVisualStyleBackColor = true;
            this.btnAgrupar.Click += new System.EventHandler(this.btnAgrupar_Click);
            // 
            // gridView1
            // 
            this.gridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView1.Location = new System.Drawing.Point(12, 108);
            this.gridView1.Name = "gridView1";
            this.gridView1.Size = new System.Drawing.Size(1087, 604);
            this.gridView1.TabIndex = 1;
            // 
            // txtFOSE
            // 
            this.txtFOSE.Location = new System.Drawing.Point(144, 12);
            this.txtFOSE.Multiline = true;
            this.txtFOSE.Name = "txtFOSE";
            this.txtFOSE.Size = new System.Drawing.Size(847, 51);
            this.txtFOSE.TabIndex = 5;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 100);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 56;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
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
            this.pBox.TabIndex = 60;
            this.pBox.TabStop = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 84);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 59;
            // 
            // frmAgrupamentoMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 726);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtFOSE);
            this.Controls.Add(this.gridView1);
            this.Controls.Add(this.btnAgrupar);
            this.Name = "frmAgrupamentoMateriais";
            this.Text = "Agrupamento de Materiais";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgrupar;
        private System.Windows.Forms.DataGridView gridView1;
        private System.Windows.Forms.TextBox txtFOSE;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.PictureBox pBox;
        private System.Windows.Forms.Label lblProgress;
    }
}

