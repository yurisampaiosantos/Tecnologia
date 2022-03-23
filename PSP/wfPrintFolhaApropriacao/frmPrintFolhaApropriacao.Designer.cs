namespace wfPrintFolhaApropriacao
{
    partial class frmPrintFolhaApropriacao
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
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.cbEquipe = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.btnDelActivities = new System.Windows.Forms.PictureBox();
            this.btnAddActivities = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bntDelDate = new System.Windows.Forms.PictureBox();
            this.lbTimeCode = new System.Windows.Forms.ListBox();
            this.lbTime = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lbDates = new System.Windows.Forms.ListBox();
            this.cbPreImpresso = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntDelDate)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(362, 11);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 19;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // cbEquipe
            // 
            this.cbEquipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipe.FormattingEnabled = true;
            this.cbEquipe.Location = new System.Drawing.Point(9, 105);
            this.cbEquipe.Name = "cbEquipe";
            this.cbEquipe.Size = new System.Drawing.Size(297, 21);
            this.cbEquipe.TabIndex = 13;
            this.cbEquipe.SelectedIndexChanged += new System.EventHandler(this.cbEquipe_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbGrupo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblEquipe);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbArea);
            this.panel2.Controls.Add(this.btnDelActivities);
            this.panel2.Controls.Add(this.monthCalendar);
            this.panel2.Controls.Add(this.btnAddActivities);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.bntDelDate);
            this.panel2.Controls.Add(this.lbTimeCode);
            this.panel2.Controls.Add(this.cbEquipe);
            this.panel2.Controls.Add(this.lbTime);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.lbDates);
            this.panel2.Controls.Add(this.cbPreImpresso);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(601, 360);
            this.panel2.TabIndex = 1;
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(9, 20);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(341, 21);
            this.cbGrupo.TabIndex = 30;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(417, 346);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "V.4.0";
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Location = new System.Drawing.Point(13, 89);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(68, 13);
            this.lblEquipe.TabIndex = 22;
            this.lblEquipe.Text = "Encarregado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Área";
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(9, 61);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(341, 21);
            this.cbArea.TabIndex = 20;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // btnDelActivities
            // 
            this.btnDelActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelActivities.Image = global::wfPrintFolhaApropriacao.Properties.Resources.delete;
            this.btnDelActivities.Location = new System.Drawing.Point(331, 105);
            this.btnDelActivities.Name = "btnDelActivities";
            this.btnDelActivities.Size = new System.Drawing.Size(16, 16);
            this.btnDelActivities.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelActivities.TabIndex = 18;
            this.btnDelActivities.TabStop = false;
            this.btnDelActivities.Click += new System.EventHandler(this.btnDelActivities_Click);
            // 
            // btnAddActivities
            // 
            this.btnAddActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddActivities.Image = global::wfPrintFolhaApropriacao.Properties.Resources.add;
            this.btnAddActivities.Location = new System.Drawing.Point(312, 105);
            this.btnAddActivities.Name = "btnAddActivities";
            this.btnAddActivities.Size = new System.Drawing.Size(16, 16);
            this.btnAddActivities.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddActivities.TabIndex = 17;
            this.btnAddActivities.TabStop = false;
            this.btnAddActivities.Click += new System.EventHandler(this.btnAddActivities_Click);
            // 
            // button2
            // 
            this.button2.Image = global::wfPrintFolhaApropriacao.Properties.Resources.application_form;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(526, 322);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Limpar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bntDelDate
            // 
            this.bntDelDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntDelDate.Image = global::wfPrintFolhaApropriacao.Properties.Resources.delete;
            this.bntDelDate.Location = new System.Drawing.Point(571, 175);
            this.bntDelDate.Name = "bntDelDate";
            this.bntDelDate.Size = new System.Drawing.Size(16, 16);
            this.bntDelDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bntDelDate.TabIndex = 17;
            this.bntDelDate.TabStop = false;
            this.bntDelDate.Click += new System.EventHandler(this.bntDelDate_Click);
            // 
            // lbTimeCode
            // 
            this.lbTimeCode.FormattingEnabled = true;
            this.lbTimeCode.Location = new System.Drawing.Point(134, 141);
            this.lbTimeCode.Name = "lbTimeCode";
            this.lbTimeCode.Size = new System.Drawing.Size(61, 173);
            this.lbTimeCode.TabIndex = 14;
            this.lbTimeCode.Visible = false;
            // 
            // lbTime
            // 
            this.lbTime.FormattingEnabled = true;
            this.lbTime.Location = new System.Drawing.Point(11, 141);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(339, 173);
            this.lbTime.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Image = global::wfPrintFolhaApropriacao.Properties.Resources.icone_print;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(450, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Imprimir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbDates
            // 
            this.lbDates.FormattingEnabled = true;
            this.lbDates.Location = new System.Drawing.Point(362, 193);
            this.lbDates.Name = "lbDates";
            this.lbDates.Size = new System.Drawing.Size(227, 121);
            this.lbDates.TabIndex = 0;
            // 
            // cbPreImpresso
            // 
            this.cbPreImpresso.AutoSize = true;
            this.cbPreImpresso.Enabled = false;
            this.cbPreImpresso.Location = new System.Drawing.Point(309, 326);
            this.cbPreImpresso.Name = "cbPreImpresso";
            this.cbPreImpresso.Size = new System.Drawing.Size(136, 17);
            this.cbPreImpresso.TabIndex = 13;
            this.cbPreImpresso.Text = "Formulário pré-impresso";
            this.cbPreImpresso.UseVisualStyleBackColor = true;
            // 
            // frmPrintFolhaApropriacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 360);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.Name = "frmPrintFolhaApropriacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão da Apropriação para o Comissionamento - v5.516.15.1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintFolhaApropriacao_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntDelDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbEquipe;
        private System.Windows.Forms.ListBox lbTime;
        private System.Windows.Forms.ListBox lbDates;
        private System.Windows.Forms.PictureBox btnAddActivities;
        private System.Windows.Forms.PictureBox btnDelActivities;
        private System.Windows.Forms.PictureBox bntDelDate;
        private System.Windows.Forms.CheckBox cbPreImpresso;
        private System.Windows.Forms.ListBox lbTimeCode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label6;
    }
}

