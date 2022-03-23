namespace wfaFTPTeewe
{
    partial class frmFTP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFTP));
            this.epccq = new System.Windows.Forms.RichTextBox();
            this.conversion = new System.Windows.Forms.RichTextBox();
            this.fechar = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // epccq
            // 
            this.epccq.Location = new System.Drawing.Point(12, 28);
            this.epccq.Name = "epccq";
            this.epccq.Size = new System.Drawing.Size(850, 59);
            this.epccq.TabIndex = 0;
            this.epccq.Text = resources.GetString("epccq.Text");
            // 
            // conversion
            // 
            this.conversion.Location = new System.Drawing.Point(12, 93);
            this.conversion.Name = "conversion";
            this.conversion.Size = new System.Drawing.Size(850, 59);
            this.conversion.TabIndex = 2;
            this.conversion.Text = "select * from EEP_CONVERSION.AC_CONTROLE_FOLHA_SERVICO \nwhere regexp_like(FOSE_DE" +
    "SCRICAO,\'^SPOOL$\',\'i\')";
            // 
            // fechar
            // 
            this.fechar.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 161);
            this.Controls.Add(this.conversion);
            this.Controls.Add(this.epccq);
            this.Name = "frmFTP";
            this.Text = "Gerar Arquivo - FTP";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox epccq;
        private System.Windows.Forms.RichTextBox conversion;
        private System.Windows.Forms.Timer fechar;

    }
}

