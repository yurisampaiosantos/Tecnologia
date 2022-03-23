namespace SisPLAN.net
{
    partial class frmVincularGrupoCriterio
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
            this.lblCriterioMedicao = new System.Windows.Forms.Label();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblGrupoCriterio = new System.Windows.Forms.Label();
            this.cmbCriterioMedicao = new System.Windows.Forms.ComboBox();
            this.cmbSchedule = new System.Windows.Forms.ComboBox();
            this.cmbGrupoCriterio = new System.Windows.Forms.ComboBox();
            this.btnAplicarVinculo = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCriterioMedicao
            // 
            this.lblCriterioMedicao.AutoSize = true;
            this.lblCriterioMedicao.Location = new System.Drawing.Point(36, 37);
            this.lblCriterioMedicao.Name = "lblCriterioMedicao";
            this.lblCriterioMedicao.Size = new System.Drawing.Size(98, 13);
            this.lblCriterioMedicao.TabIndex = 0;
            this.lblCriterioMedicao.Text = "Critério de Medição";
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(204, 37);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(52, 13);
            this.lblSchedule.TabIndex = 1;
            this.lblSchedule.Text = "Schedule";
            // 
            // lblGrupoCriterio
            // 
            this.lblGrupoCriterio.AutoSize = true;
            this.lblGrupoCriterio.Location = new System.Drawing.Point(348, 37);
            this.lblGrupoCriterio.Name = "lblGrupoCriterio";
            this.lblGrupoCriterio.Size = new System.Drawing.Size(71, 13);
            this.lblGrupoCriterio.TabIndex = 2;
            this.lblGrupoCriterio.Text = "Grupo Critério";
            // 
            // cmbCriterioMedicao
            // 
            this.cmbCriterioMedicao.FormattingEnabled = true;
            this.cmbCriterioMedicao.Location = new System.Drawing.Point(36, 53);
            this.cmbCriterioMedicao.Name = "cmbCriterioMedicao";
            this.cmbCriterioMedicao.Size = new System.Drawing.Size(150, 21);
            this.cmbCriterioMedicao.TabIndex = 3;
            this.cmbCriterioMedicao.SelectedIndexChanged += new System.EventHandler(this.cmbCriterioMedicao_SelectedIndexChanged);
            // 
            // cmbSchedule
            // 
            this.cmbSchedule.FormattingEnabled = true;
            this.cmbSchedule.Items.AddRange(new object[] {
            "",
            "Schedule A",
            "Schedule B"});
            this.cmbSchedule.Location = new System.Drawing.Point(207, 53);
            this.cmbSchedule.Name = "cmbSchedule";
            this.cmbSchedule.Size = new System.Drawing.Size(121, 21);
            this.cmbSchedule.TabIndex = 4;
            this.cmbSchedule.SelectedIndexChanged += new System.EventHandler(this.cmbSchedule_SelectedIndexChanged);
            // 
            // cmbGrupoCriterio
            // 
            this.cmbGrupoCriterio.Enabled = false;
            this.cmbGrupoCriterio.FormattingEnabled = true;
            this.cmbGrupoCriterio.Location = new System.Drawing.Point(349, 53);
            this.cmbGrupoCriterio.Name = "cmbGrupoCriterio";
            this.cmbGrupoCriterio.Size = new System.Drawing.Size(121, 21);
            this.cmbGrupoCriterio.TabIndex = 5;
            this.cmbGrupoCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbGrupoCriterio_SelectedIndexChanged);
            // 
            // btnAplicarVinculo
            // 
            this.btnAplicarVinculo.Enabled = false;
            this.btnAplicarVinculo.Location = new System.Drawing.Point(507, 53);
            this.btnAplicarVinculo.Name = "btnAplicarVinculo";
            this.btnAplicarVinculo.Size = new System.Drawing.Size(121, 21);
            this.btnAplicarVinculo.TabIndex = 6;
            this.btnAplicarVinculo.Text = "Aplicar Vínculo";
            this.btnAplicarVinculo.UseVisualStyleBackColor = true;
            this.btnAplicarVinculo.Click += new System.EventHandler(this.btnAplicarVinculo_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(36, 85);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(60, 13);
            this.lblMessage.TabIndex = 7;
            this.lblMessage.Text = "lblMessage";
            // 
            // frmVincularGrupoCriterio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 121);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnAplicarVinculo);
            this.Controls.Add(this.cmbGrupoCriterio);
            this.Controls.Add(this.cmbSchedule);
            this.Controls.Add(this.cmbCriterioMedicao);
            this.Controls.Add(this.lblGrupoCriterio);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblCriterioMedicao);
            this.Name = "frmVincularGrupoCriterio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vincular Grupos com Critérios de Medições";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCriterioMedicao;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblGrupoCriterio;
        private System.Windows.Forms.ComboBox cmbCriterioMedicao;
        private System.Windows.Forms.ComboBox cmbSchedule;
        private System.Windows.Forms.ComboBox cmbGrupoCriterio;
        private System.Windows.Forms.Button btnAplicarVinculo;
        private System.Windows.Forms.Label lblMessage;

    }
}

