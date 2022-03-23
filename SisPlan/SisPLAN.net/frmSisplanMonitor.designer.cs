namespace SisPLAN.net
{
    partial class frmSisplanMonitor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAplicaFiltro = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOmiteTodos = new System.Windows.Forms.Button();
            this.btnExibeTodos = new System.Windows.Forms.Button();
            this.cmbDisciplina = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCriterio = new System.Windows.Forms.ComboBox();
            this.dtg = new System.Windows.Forms.DataGridView();
            this.ACTIVE = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FOSE_NUMERO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.DTOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTOBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAplicaFiltro);
            this.panel1.Controls.Add(this.txtFilter);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnOmiteTodos);
            this.panel1.Controls.Add(this.btnExibeTodos);
            this.panel1.Controls.Add(this.cmbDisciplina);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbCriterio);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1469, 83);
            this.panel1.TabIndex = 10;
            // 
            // btnAplicaFiltro
            // 
            this.btnAplicaFiltro.Location = new System.Drawing.Point(499, 52);
            this.btnAplicaFiltro.Name = "btnAplicaFiltro";
            this.btnAplicaFiltro.Size = new System.Drawing.Size(75, 23);
            this.btnAplicaFiltro.TabIndex = 40;
            this.btnAplicaFiltro.Text = "Aplica Filtro";
            this.btnAplicaFiltro.UseVisualStyleBackColor = true;
            this.btnAplicaFiltro.Click += new System.EventHandler(this.btnAplicaFiltro_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(499, 26);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(662, 20);
            this.txtFilter.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(496, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Filtrar";
            // 
            // btnOmiteTodos
            // 
            this.btnOmiteTodos.Location = new System.Drawing.Point(296, 52);
            this.btnOmiteTodos.Name = "btnOmiteTodos";
            this.btnOmiteTodos.Size = new System.Drawing.Size(75, 23);
            this.btnOmiteTodos.TabIndex = 37;
            this.btnOmiteTodos.Text = "Omite todos";
            this.btnOmiteTodos.UseVisualStyleBackColor = true;
            this.btnOmiteTodos.Click += new System.EventHandler(this.btnOmiteTodos_Click);
            // 
            // btnExibeTodos
            // 
            this.btnExibeTodos.Location = new System.Drawing.Point(162, 52);
            this.btnExibeTodos.Name = "btnExibeTodos";
            this.btnExibeTodos.Size = new System.Drawing.Size(75, 23);
            this.btnExibeTodos.TabIndex = 36;
            this.btnExibeTodos.Text = "Exibe todos";
            this.btnExibeTodos.UseVisualStyleBackColor = true;
            this.btnExibeTodos.Click += new System.EventHandler(this.btnExibeTodos_Click);
            // 
            // cmbDisciplina
            // 
            this.cmbDisciplina.FormattingEnabled = true;
            this.cmbDisciplina.Location = new System.Drawing.Point(162, 26);
            this.cmbDisciplina.Name = "cmbDisciplina";
            this.cmbDisciplina.Size = new System.Drawing.Size(110, 21);
            this.cmbDisciplina.TabIndex = 35;
            this.cmbDisciplina.SelectedIndexChanged += new System.EventHandler(this.cmbDisciplina_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(159, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Disciplina";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Critério de Medição";
            // 
            // cmbCriterio
            // 
            this.cmbCriterio.Enabled = false;
            this.cmbCriterio.FormattingEnabled = true;
            this.cmbCriterio.Location = new System.Drawing.Point(296, 26);
            this.cmbCriterio.Name = "cmbCriterio";
            this.cmbCriterio.Size = new System.Drawing.Size(184, 21);
            this.cmbCriterio.TabIndex = 28;
            this.cmbCriterio.SelectedIndexChanged += new System.EventHandler(this.cmbCriterio_SelectedIndexChanged);
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACTIVE,
            this.FOSE_NUMERO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtg.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtg.Location = new System.Drawing.Point(0, 83);
            this.dtg.Name = "dtg";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtg.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtg.Size = new System.Drawing.Size(1469, 601);
            this.dtg.TabIndex = 12;
            this.dtg.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_CellContentClick);
            // 
            // ACTIVE
            // 
            this.ACTIVE.DataPropertyName = "ACTIVE";
            this.ACTIVE.HeaderText = "ATIVA";
            this.ACTIVE.Name = "ACTIVE";
            this.ACTIVE.Width = 60;
            // 
            // FOSE_NUMERO
            // 
            this.FOSE_NUMERO.DataPropertyName = "FOSE_NUMERO";
            this.FOSE_NUMERO.HeaderText = "FOSE_NUMERO";
            this.FOSE_NUMERO.Name = "FOSE_NUMERO";
            this.FOSE_NUMERO.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisPLAN.net.Properties.Resources.Enseada;
            this.pictureBox1.Location = new System.Drawing.Point(16, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // DTOBindingSource
            // 
            this.DTOBindingSource.DataSource = typeof(DTO.CollectionAcControleFolhaServicoDTO);
            // 
            // frmSisplanMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 684);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtg);
            this.Controls.Add(this.panel1);
            this.Name = "frmSisplanMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SISPLAN Monitor";
            this.Load += new System.EventHandler(this.frmSisplanMonitor_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTOBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource DTOBindingSource;
        private System.Windows.Forms.ComboBox cmbDisciplina;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCriterio;
        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.Button btnOmiteTodos;
        private System.Windows.Forms.Button btnExibeTodos;
        private System.Windows.Forms.Button btnAplicaFiltro;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ACTIVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOSE_NUMERO;
        
    }
}