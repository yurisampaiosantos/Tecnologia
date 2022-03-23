namespace wfPrintDDPS
{
    partial class frmExames
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExames));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProcessando = new System.Windows.Forms.Label();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProcessando);
            this.groupBox1.Controls.Add(this.lblAte);
            this.groupBox1.Controls.Add(this.lblDe);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btImprimir);
            this.groupBox1.Controls.Add(this.btFechar);
            this.groupBox1.Controls.Add(this.monthCalendar1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 264);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período Máximo de 1 Semana";
            // 
            // lblProcessando
            // 
            this.lblProcessando.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblProcessando.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblProcessando.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessando.ForeColor = System.Drawing.Color.Red;
            this.lblProcessando.Location = new System.Drawing.Point(19, 233);
            this.lblProcessando.Name = "lblProcessando";
            this.lblProcessando.Size = new System.Drawing.Size(106, 15);
            this.lblProcessando.TabIndex = 54;
            this.lblProcessando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAte
            // 
            this.lblAte.BackColor = System.Drawing.Color.White;
            this.lblAte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAte.Location = new System.Drawing.Point(215, 26);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(100, 20);
            this.lblAte.TabIndex = 26;
            this.lblAte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDe
            // 
            this.lblDe.BackColor = System.Drawing.Color.White;
            this.lblDe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDe.Location = new System.Drawing.Point(41, 26);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(100, 20);
            this.lblDe.TabIndex = 25;
            this.lblDe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Até";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "De";
            // 
            // btImprimir
            // 
            this.btImprimir.Image = global::wfPrintDDPS.Properties.Resources.Printer_icon;
            this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprimir.Location = new System.Drawing.Point(190, 227);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(73, 23);
            this.btImprimir.TabIndex = 19;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = global::wfPrintDDPS.Properties.Resources.btClose;
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(272, 227);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(75, 23);
            this.btFechar.TabIndex = 20;
            this.btFechar.Text = "Cancelar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.monthCalendar1.Location = new System.Drawing.Point(15, 60);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 18;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // frmExames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 283);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmExames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Convocados para Exames";
            this.Load += new System.EventHandler(this.frmExames_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label lblAte;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblProcessando;

    }
}