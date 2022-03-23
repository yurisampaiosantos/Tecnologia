namespace SisPLAN.net
{
    partial class frmImportaCorridaMateriais
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grv = new System.Windows.Forms.DataGridView();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.btnImportaCorrida = new System.Windows.Forms.Button();
            this.pb = new System.Windows.Forms.ProgressBar();
            this.lblMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            this.SuspendLayout();
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
            this.grv.ReadOnly = true;
            this.grv.Size = new System.Drawing.Size(457, 193);
            this.grv.TabIndex = 2;
            // 
            // panelDivision
            // 
            this.panelDivision.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(6)))), ((int)(((byte)(19)))));
            this.panelDivision.Location = new System.Drawing.Point(0, 70);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(2000, 2);
            this.panelDivision.TabIndex = 56;
            // 
            // btnImportaCorrida
            // 
            this.btnImportaCorrida.Location = new System.Drawing.Point(146, 27);
            this.btnImportaCorrida.Name = "btnImportaCorrida";
            this.btnImportaCorrida.Size = new System.Drawing.Size(130, 23);
            this.btnImportaCorrida.TabIndex = 57;
            this.btnImportaCorrida.Text = "Importa Corrida";
            this.btnImportaCorrida.UseVisualStyleBackColor = true;
            this.btnImportaCorrida.Click += new System.EventHandler(this.button1_Click);
            // 
            // pb
            // 
            this.pb.Location = new System.Drawing.Point(292, 26);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(168, 23);
            this.pb.TabIndex = 58;
            this.pb.Visible = false;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(151, 54);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 13);
            this.lblMessage.TabIndex = 59;
            // 
            // frmImportaCorridaMateriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 602);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.btnImportaCorrida);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grv);
            this.Controls.Add(this.panelDivision);
            this.Name = "frmImportaCorridaMateriais";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importa Corrida de  Materiais";
            this.Load += new System.EventHandler(this.frmImportaCorridaMateriais_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grv;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Button btnImportaCorrida;
        private System.Windows.Forms.ProgressBar pb;
        private System.Windows.Forms.Label lblMessage;

    }
}

