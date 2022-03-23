namespace SisPLAN.net
{
    partial class frmImportaMateriaisTubulacao
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
            this.btnImportaPlanilhas = new System.Windows.Forms.Button();
            this.grv = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDivision = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnImportaPlanilhas
            // 
            this.btnImportaPlanilhas.Location = new System.Drawing.Point(156, 39);
            this.btnImportaPlanilhas.Name = "btnImportaPlanilhas";
            this.btnImportaPlanilhas.Size = new System.Drawing.Size(104, 24);
            this.btnImportaPlanilhas.TabIndex = 0;
            this.btnImportaPlanilhas.Text = "Importa Planilhas";
            this.btnImportaPlanilhas.UseVisualStyleBackColor = true;
            this.btnImportaPlanilhas.Click += new System.EventHandler(this.btnImportaPlanilhas_Click);
            // 
            // grv
            // 
            this.grv.AllowUserToAddRows = false;
            this.grv.AllowUserToDeleteRows = false;
            this.grv.AllowUserToOrderColumns = true;
            this.grv.AllowUserToResizeRows = false;
            this.grv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grv.Location = new System.Drawing.Point(12, 78);
            this.grv.Name = "grv";
            this.grv.Size = new System.Drawing.Size(1375, 525);
            this.grv.TabIndex = 1;
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
            // frmImportaMateriaisTubulacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 777);
            this.Controls.Add(this.panelDivision);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grv);
            this.Controls.Add(this.btnImportaPlanilhas);
            this.Name = "frmImportaMateriaisTubulacao";
            this.Text = "Importa Materiais de Tubulação";
            this.Load += new System.EventHandler(this.frmImportaMateriaisTubulacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImportaPlanilhas;
        private System.Windows.Forms.DataGridView grv;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDivision;
    }
}

