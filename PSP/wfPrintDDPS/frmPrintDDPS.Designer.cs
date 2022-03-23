namespace wfPrintDDPS
{
    partial class frmPrintDDPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrintDDPS));
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbFAD = new System.Windows.Forms.CheckBox();
            this.btImprimir = new System.Windows.Forms.Button();
            this.btExames = new System.Windows.Forms.Button();
            this.cbResponsavel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlEncarregados = new System.Windows.Forms.Panel();
            this.btnAddActivities = new System.Windows.Forms.PictureBox();
            this.rbNoturno = new System.Windows.Forms.RadioButton();
            this.rbDiurno = new System.Windows.Forms.RadioButton();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.btnDelActivities = new System.Windows.Forms.PictureBox();
            this.lbTimeCode = new System.Windows.Forms.ListBox();
            this.cbEquipe = new System.Windows.Forms.ComboBox();
            this.lbTime = new System.Windows.Forms.ListBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.bntDelDate = new System.Windows.Forms.PictureBox();
            this.lbDates = new System.Windows.Forms.ListBox();
            this.cbPreImpresso = new System.Windows.Forms.CheckBox();
            this.cbDDPS = new System.Windows.Forms.CheckBox();
            this.panel2.SuspendLayout();
            this.pnlEncarregados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntDelDate)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar
            // 
            this.monthCalendar.Location = new System.Drawing.Point(362, 11);
            this.monthCalendar.MaxSelectionCount = 1;
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 19;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbFAD);
            this.panel2.Controls.Add(this.btImprimir);
            this.panel2.Controls.Add(this.btExames);
            this.panel2.Controls.Add(this.cbResponsavel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pnlEncarregados);
            this.panel2.Controls.Add(this.cbGrupo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbArea);
            this.panel2.Controls.Add(this.monthCalendar);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.bntDelDate);
            this.panel2.Controls.Add(this.lbDates);
            this.panel2.Controls.Add(this.cbPreImpresso);
            this.panel2.Controls.Add(this.cbDDPS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 410);
            this.panel2.TabIndex = 1;
            // 
            // cbFAD
            // 
            this.cbFAD.AutoSize = true;
            this.cbFAD.Checked = true;
            this.cbFAD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFAD.Location = new System.Drawing.Point(384, 382);
            this.cbFAD.Name = "cbFAD";
            this.cbFAD.Size = new System.Drawing.Size(47, 17);
            this.cbFAD.TabIndex = 34;
            this.cbFAD.Text = "FAD";
            this.cbFAD.UseVisualStyleBackColor = true;
            // 
            // btImprimir
            // 
            this.btImprimir.Image = global::wfPrintDDPS.Properties.Resources.icone_print;
            this.btImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btImprimir.Location = new System.Drawing.Point(443, 378);
            this.btImprimir.Name = "btImprimir";
            this.btImprimir.Size = new System.Drawing.Size(73, 23);
            this.btImprimir.TabIndex = 12;
            this.btImprimir.Text = "Imprimir";
            this.btImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btImprimir.UseVisualStyleBackColor = true;
            this.btImprimir.Click += new System.EventHandler(this.btImprimir_Click);
            // 
            // btExames
            // 
            this.btExames.Image = global::wfPrintDDPS.Properties.Resources.Printer_icon;
            this.btExames.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExames.Location = new System.Drawing.Point(10, 378);
            this.btExames.Name = "btExames";
            this.btExames.Size = new System.Drawing.Size(74, 23);
            this.btExames.TabIndex = 33;
            this.btExames.Text = "Exames";
            this.btExames.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExames.UseVisualStyleBackColor = true;
            this.btExames.Click += new System.EventHandler(this.btExames_Click);
            // 
            // cbResponsavel
            // 
            this.cbResponsavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbResponsavel.FormattingEnabled = true;
            this.cbResponsavel.Location = new System.Drawing.Point(78, 40);
            this.cbResponsavel.Name = "cbResponsavel";
            this.cbResponsavel.Size = new System.Drawing.Size(275, 21);
            this.cbResponsavel.TabIndex = 32;
            this.cbResponsavel.SelectedIndexChanged += new System.EventHandler(this.cbResponsavel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Responsável";
            // 
            // pnlEncarregados
            // 
            this.pnlEncarregados.Controls.Add(this.btnAddActivities);
            this.pnlEncarregados.Controls.Add(this.rbNoturno);
            this.pnlEncarregados.Controls.Add(this.rbDiurno);
            this.pnlEncarregados.Controls.Add(this.lblEquipe);
            this.pnlEncarregados.Controls.Add(this.btnDelActivities);
            this.pnlEncarregados.Controls.Add(this.lbTimeCode);
            this.pnlEncarregados.Controls.Add(this.cbEquipe);
            this.pnlEncarregados.Controls.Add(this.lbTime);
            this.pnlEncarregados.Controls.Add(this.chkTodos);
            this.pnlEncarregados.Enabled = false;
            this.pnlEncarregados.Location = new System.Drawing.Point(6, 106);
            this.pnlEncarregados.Name = "pnlEncarregados";
            this.pnlEncarregados.Size = new System.Drawing.Size(351, 268);
            this.pnlEncarregados.TabIndex = 2;
            // 
            // btnAddActivities
            // 
            this.btnAddActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddActivities.Image = global::wfPrintDDPS.Properties.Resources.add;
            this.btnAddActivities.Location = new System.Drawing.Point(308, 6);
            this.btnAddActivities.Name = "btnAddActivities";
            this.btnAddActivities.Size = new System.Drawing.Size(16, 15);
            this.btnAddActivities.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddActivities.TabIndex = 37;
            this.btnAddActivities.TabStop = false;
            this.btnAddActivities.Click += new System.EventHandler(this.btnAddActivities_Click);
            // 
            // rbNoturno
            // 
            this.rbNoturno.AutoSize = true;
            this.rbNoturno.Location = new System.Drawing.Point(166, 5);
            this.rbNoturno.Name = "rbNoturno";
            this.rbNoturno.Size = new System.Drawing.Size(68, 17);
            this.rbNoturno.TabIndex = 41;
            this.rbNoturno.Text = "Noturnos";
            this.rbNoturno.UseVisualStyleBackColor = true;
            this.rbNoturno.CheckedChanged += new System.EventHandler(this.rbNoturno_CheckedChanged);
            // 
            // rbDiurno
            // 
            this.rbDiurno.AutoSize = true;
            this.rbDiurno.Location = new System.Drawing.Point(101, 5);
            this.rbDiurno.Name = "rbDiurno";
            this.rbDiurno.Size = new System.Drawing.Size(61, 17);
            this.rbDiurno.TabIndex = 40;
            this.rbDiurno.Text = "Diurnos";
            this.rbDiurno.UseVisualStyleBackColor = true;
            this.rbDiurno.CheckedChanged += new System.EventHandler(this.rbDiurno_CheckedChanged);
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Location = new System.Drawing.Point(1, 7);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(79, 13);
            this.lblEquipe.TabIndex = 39;
            this.lblEquipe.Text = "Encarregado(s)";
            // 
            // btnDelActivities
            // 
            this.btnDelActivities.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelActivities.Image = global::wfPrintDDPS.Properties.Resources.delete;
            this.btnDelActivities.Location = new System.Drawing.Point(327, 6);
            this.btnDelActivities.Name = "btnDelActivities";
            this.btnDelActivities.Size = new System.Drawing.Size(16, 15);
            this.btnDelActivities.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDelActivities.TabIndex = 38;
            this.btnDelActivities.TabStop = false;
            this.btnDelActivities.Click += new System.EventHandler(this.btnDelActivities_Click);
            // 
            // lbTimeCode
            // 
            this.lbTimeCode.FormattingEnabled = true;
            this.lbTimeCode.Location = new System.Drawing.Point(129, 57);
            this.lbTimeCode.Name = "lbTimeCode";
            this.lbTimeCode.Size = new System.Drawing.Size(61, 173);
            this.lbTimeCode.TabIndex = 36;
            this.lbTimeCode.Visible = false;
            // 
            // cbEquipe
            // 
            this.cbEquipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipe.FormattingEnabled = true;
            this.cbEquipe.Location = new System.Drawing.Point(4, 26);
            this.cbEquipe.Name = "cbEquipe";
            this.cbEquipe.Size = new System.Drawing.Size(343, 21);
            this.cbEquipe.TabIndex = 35;
            // 
            // lbTime
            // 
            this.lbTime.FormattingEnabled = true;
            this.lbTime.Location = new System.Drawing.Point(4, 52);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(343, 212);
            this.lbTime.TabIndex = 34;
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(254, 6);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTodos.Size = new System.Drawing.Size(56, 17);
            this.chkTodos.TabIndex = 42;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(78, 12);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(275, 21);
            this.cbGrupo.TabIndex = 30;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Grupo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Área";
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(78, 68);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(275, 21);
            this.cbArea.TabIndex = 20;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Image = global::wfPrintDDPS.Properties.Resources.application_form;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(522, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Limpar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bntDelDate
            // 
            this.bntDelDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntDelDate.Image = global::wfPrintDDPS.Properties.Resources.delete;
            this.bntDelDate.Location = new System.Drawing.Point(571, 177);
            this.bntDelDate.Name = "bntDelDate";
            this.bntDelDate.Size = new System.Drawing.Size(16, 16);
            this.bntDelDate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bntDelDate.TabIndex = 17;
            this.bntDelDate.TabStop = false;
            this.bntDelDate.Click += new System.EventHandler(this.bntDelDate_Click);
            // 
            // lbDates
            // 
            this.lbDates.FormattingEnabled = true;
            this.lbDates.Location = new System.Drawing.Point(363, 197);
            this.lbDates.Name = "lbDates";
            this.lbDates.Size = new System.Drawing.Size(225, 173);
            this.lbDates.TabIndex = 0;
            // 
            // cbPreImpresso
            // 
            this.cbPreImpresso.AutoSize = true;
            this.cbPreImpresso.Enabled = false;
            this.cbPreImpresso.Location = new System.Drawing.Point(363, 177);
            this.cbPreImpresso.Name = "cbPreImpresso";
            this.cbPreImpresso.Size = new System.Drawing.Size(136, 17);
            this.cbPreImpresso.TabIndex = 13;
            this.cbPreImpresso.Text = "Formulário pré-impresso";
            this.cbPreImpresso.UseVisualStyleBackColor = true;
            this.cbPreImpresso.Visible = false;
            // 
            // cbDDPS
            // 
            this.cbDDPS.AutoSize = true;
            this.cbDDPS.Checked = true;
            this.cbDDPS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDDPS.Location = new System.Drawing.Point(324, 382);
            this.cbDDPS.Name = "cbDDPS";
            this.cbDDPS.Size = new System.Drawing.Size(56, 17);
            this.cbDDPS.TabIndex = 35;
            this.cbDDPS.Text = "DDPS";
            this.cbDDPS.UseVisualStyleBackColor = true;
            // 
            // frmPrintDDPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 410);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmPrintDDPS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impressão - DDPS / FAD / Exames  - v1.0.0.0";
            this.Load += new System.EventHandler(this.frmPrintDDPS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintDDPS_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlEncarregados.ResumeLayout(false);
            this.pnlEncarregados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDelActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bntDelDate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btImprimir;
        private System.Windows.Forms.ListBox lbDates;
        private System.Windows.Forms.PictureBox bntDelDate;
        private System.Windows.Forms.CheckBox cbPreImpresso;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlEncarregados;
        private System.Windows.Forms.PictureBox btnAddActivities;
        private System.Windows.Forms.RadioButton rbNoturno;
        private System.Windows.Forms.RadioButton rbDiurno;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.PictureBox btnDelActivities;
        private System.Windows.Forms.ListBox lbTimeCode;
        private System.Windows.Forms.ComboBox cbEquipe;
        private System.Windows.Forms.ListBox lbTime;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.ComboBox cbResponsavel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btExames;
        private System.Windows.Forms.CheckBox cbFAD;
        private System.Windows.Forms.CheckBox cbDDPS;
    }
}

