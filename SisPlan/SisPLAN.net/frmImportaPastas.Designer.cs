namespace SisPLAN.net
{
    partial class frmImportaPastas
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
            this.btnReadXLS = new System.Windows.Forms.Button();
            this.gridView1 = new System.Windows.Forms.DataGridView();
            this.btnParseXLS = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDivision = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadXLS
            // 
            this.btnReadXLS.Location = new System.Drawing.Point(12, 78);
            this.btnReadXLS.Name = "btnReadXLS";
            this.btnReadXLS.Size = new System.Drawing.Size(85, 23);
            this.btnReadXLS.TabIndex = 0;
            this.btnReadXLS.Text = "Abre Planilha";
            this.btnReadXLS.UseVisualStyleBackColor = true;
            this.btnReadXLS.Click += new System.EventHandler(this.btnReadXLS_Click);
            // 
            // gridView1
            // 
            this.gridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView1.Location = new System.Drawing.Point(0, 110);
            this.gridView1.Name = "gridView1";
            this.gridView1.Size = new System.Drawing.Size(1444, 608);
            this.gridView1.TabIndex = 1;
            // 
            // btnParseXLS
            // 
            this.btnParseXLS.Location = new System.Drawing.Point(103, 78);
            this.btnParseXLS.Name = "btnParseXLS";
            this.btnParseXLS.Size = new System.Drawing.Size(81, 23);
            this.btnParseXLS.TabIndex = 2;
            this.btnParseXLS.Text = "Importa Itens";
            this.btnParseXLS.UseVisualStyleBackColor = true;
            this.btnParseXLS.Visible = false;
            this.btnParseXLS.Click += new System.EventHandler(this.btnParseXLS_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(222, 77);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(372, 23);
            this.pb.Step = 2;
            this.pb.TabIndex = 3;
            this.pb.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(600, 83);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(58, 13);
            this.lblProgress.TabIndex = 4;
            this.lblProgress.Text = "lblProgress";
            this.lblProgress.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 70);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 56;
            // 
            // frmImportaPastas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1477, 761);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnParseXLS);
            this.Controls.Add(this.gridView1);
            this.Controls.Add(this.btnReadXLS);
            this.Name = "frmImportaPastas";
            this.Text = "Importação de Itens de Controle";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReadXLS;
        private System.Windows.Forms.DataGridView gridView1;
        private System.Windows.Forms.Button btnParseXLS;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDivision;
    }
}

