namespace SisPLAN.net
{
    partial class frmAcompanhaPunchlist
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
            this.btnExecute = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.pBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbRespPunchlist = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.dgvPunchlist = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunchlist)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.Location = new System.Drawing.Point(420, 44);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(64, 23);
            this.btnExecute.TabIndex = 14;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(153, 69);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Visible = false;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 88);
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
            // cmbRespPunchlist
            // 
            this.cmbRespPunchlist.FormattingEnabled = true;
            this.cmbRespPunchlist.Location = new System.Drawing.Point(232, 45);
            this.cmbRespPunchlist.Name = "cmbRespPunchlist";
            this.cmbRespPunchlist.Size = new System.Drawing.Size(178, 21);
            this.cmbRespPunchlist.TabIndex = 227;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(147, 49);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 13);
            this.label22.TabIndex = 226;
            this.label22.Text = "Responsável:";
            // 
            // dgvPunchlist
            // 
            this.dgvPunchlist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPunchlist.Location = new System.Drawing.Point(13, 100);
            this.dgvPunchlist.Name = "dgvPunchlist";
            this.dgvPunchlist.Size = new System.Drawing.Size(1444, 608);
            this.dgvPunchlist.TabIndex = 228;
            this.dgvPunchlist.SelectionChanged += new System.EventHandler(this.dgvPunchlist_SelectionChanged);
            // 
            // frmAcompanhaPunchlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1531, 763);
            this.Controls.Add(this.dgvPunchlist);
            this.Controls.Add(this.cmbRespPunchlist);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExecute);
            this.Name = "frmAcompanhaPunchlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acompanha as Punch Lists das Pastas de Comissionamento";
            this.Load += new System.EventHandler(this.frmAcompanhaPunchlist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPunchlist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.PictureBox pBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ComboBox cmbRespPunchlist;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridView dgvPunchlist;
    }
}