namespace wfFolhaApropriacao
{
    partial class frmFolhaApropriacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFolhaApropriacao));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbEquipe = new System.Windows.Forms.ComboBox();
            this.btnAddTarefa = new System.Windows.Forms.Button();
            this.btnAddMatricula = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblEquipeH = new System.Windows.Forms.Label();
            this.lblEquipe = new System.Windows.Forms.Label();
            this.cbGrupo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.btnCalendar = new System.Windows.Forms.PictureBox();
            this.txtDateSelect = new System.Windows.Forms.TextBox();
            this.pictureCalendar = new System.Windows.Forms.PictureBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.pnValidacao = new System.Windows.Forms.Panel();
            this.dataGridValidation = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.conGrid1 = new wfFolhaApropriacao.conGrid();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnValidacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridValidation)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbEquipe
            // 
            this.cbEquipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEquipe.FormattingEnabled = true;
            this.cbEquipe.Location = new System.Drawing.Point(677, 29);
            this.cbEquipe.Name = "cbEquipe";
            this.cbEquipe.Size = new System.Drawing.Size(227, 21);
            this.cbEquipe.TabIndex = 2;
            this.cbEquipe.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // btnAddTarefa
            // 
            this.btnAddTarefa.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTarefa.Image")));
            this.btnAddTarefa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddTarefa.Location = new System.Drawing.Point(975, 3);
            this.btnAddTarefa.Name = "btnAddTarefa";
            this.btnAddTarefa.Size = new System.Drawing.Size(64, 23);
            this.btnAddTarefa.TabIndex = 7;
            this.btnAddTarefa.Text = "Add UA";
            this.btnAddTarefa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddTarefa.UseVisualStyleBackColor = true;
            this.btnAddTarefa.Visible = false;
            this.btnAddTarefa.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddMatricula
            // 
            this.btnAddMatricula.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMatricula.Image")));
            this.btnAddMatricula.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddMatricula.Location = new System.Drawing.Point(808, 3);
            this.btnAddMatricula.Name = "btnAddMatricula";
            this.btnAddMatricula.Size = new System.Drawing.Size(96, 23);
            this.btnAddMatricula.TabIndex = 6;
            this.btnAddMatricula.Text = "Add Matricula";
            this.btnAddMatricula.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddMatricula.UseVisualStyleBackColor = true;
            this.btnAddMatricula.Visible = false;
            this.btnAddMatricula.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = ((System.Drawing.Image)(resources.GetObject("btnSalvar.Image")));
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalvar.Location = new System.Drawing.Point(1124, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Visible = false;
            this.btnSalvar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(1045, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblEquipeH);
            this.panel1.Controls.Add(this.lblEquipe);
            this.panel1.Controls.Add(this.cbGrupo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbArea);
            this.panel1.Controls.Add(this.btnAddMatricula);
            this.panel1.Controls.Add(this.btnAddTarefa);
            this.panel1.Controls.Add(this.btnCalendar);
            this.panel1.Controls.Add(this.txtDateSelect);
            this.panel1.Controls.Add(this.pictureCalendar);
            this.panel1.Controls.Add(this.txtBarcode);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.cbEquipe);
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1197, 57);
            this.panel1.TabIndex = 8;
            // 
            // lblEquipeH
            // 
            this.lblEquipeH.AutoSize = true;
            this.lblEquipeH.Location = new System.Drawing.Point(910, 11);
            this.lblEquipeH.Name = "lblEquipeH";
            this.lblEquipeH.Size = new System.Drawing.Size(40, 13);
            this.lblEquipeH.TabIndex = 30;
            this.lblEquipeH.Text = "Equipe";
            this.lblEquipeH.Visible = false;
            // 
            // lblEquipe
            // 
            this.lblEquipe.AutoSize = true;
            this.lblEquipe.Location = new System.Drawing.Point(910, 32);
            this.lblEquipe.Name = "lblEquipe";
            this.lblEquipe.Size = new System.Drawing.Size(50, 13);
            this.lblEquipe.TabIndex = 29;
            this.lblEquipe.Text = "lblEquipe";
            this.lblEquipe.Visible = false;
            // 
            // cbGrupo
            // 
            this.cbGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGrupo.FormattingEnabled = true;
            this.cbGrupo.Location = new System.Drawing.Point(286, 29);
            this.cbGrupo.Name = "cbGrupo";
            this.cbGrupo.Size = new System.Drawing.Size(213, 21);
            this.cbGrupo.TabIndex = 28;
            this.cbGrupo.SelectedIndexChanged += new System.EventHandler(this.cbGrupo_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(283, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Grupo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(674, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Encarregado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(504, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Área";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Código de Barras";
            // 
            // cbArea
            // 
            this.cbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(504, 29);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(168, 21);
            this.cbArea.TabIndex = 21;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // btnCalendar
            // 
            this.btnCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalendar.Image = ((System.Drawing.Image)(resources.GetObject("btnCalendar.Image")));
            this.btnCalendar.Location = new System.Drawing.Point(260, 29);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(20, 20);
            this.btnCalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCalendar.TabIndex = 9;
            this.btnCalendar.TabStop = false;
            this.btnCalendar.Click += new System.EventHandler(this.btnCalendar_Click);
            // 
            // txtDateSelect
            // 
            this.txtDateSelect.Location = new System.Drawing.Point(194, 29);
            this.txtDateSelect.Name = "txtDateSelect";
            this.txtDateSelect.ReadOnly = true;
            this.txtDateSelect.Size = new System.Drawing.Size(66, 20);
            this.txtDateSelect.TabIndex = 8;
            // 
            // pictureCalendar
            // 
            this.pictureCalendar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCalendar.Enabled = false;
            this.pictureCalendar.Image = ((System.Drawing.Image)(resources.GetObject("pictureCalendar.Image")));
            this.pictureCalendar.Location = new System.Drawing.Point(169, 29);
            this.pictureCalendar.Name = "pictureCalendar";
            this.pictureCalendar.Size = new System.Drawing.Size(20, 20);
            this.pictureCalendar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCalendar.TabIndex = 7;
            this.pictureCalendar.TabStop = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(6, 29);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(162, 20);
            this.txtBarcode.TabIndex = 6;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripTextBox2,
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripTextBox3,
            this.toolStripLabel3,
            this.toolStripSeparator3,
            this.toolStripTextBox4,
            this.toolStripLabel4,
            this.toolStripLabel5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 485);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1197, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(16, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(155, 22);
            this.toolStripLabel1.Text = "Excedeu total horas normais";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toolStripTextBox2.Enabled = false;
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(16, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(142, 22);
            this.toolStripLabel2.Text = "Excedeu total horas extras";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.toolStripTextBox3.Enabled = false;
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(16, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(217, 22);
            this.toolStripLabel3.Text = "Matricula já utilizada e excedeu as horas";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(200)))), ((int)(((byte)(225)))));
            this.toolStripTextBox4.Enabled = false;
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(16, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(272, 22);
            this.toolStripLabel4.Text = "Total de Horas Normais inferior a hora de trabalho";
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(32, 22);
            this.toolStripLabel5.Text = "V.5.0";
            this.toolStripLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripLabel5.Visible = false;
            // 
            // pnValidacao
            // 
            this.pnValidacao.Controls.Add(this.dataGridValidation);
            this.pnValidacao.Controls.Add(this.panel2);
            this.pnValidacao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnValidacao.Location = new System.Drawing.Point(0, 510);
            this.pnValidacao.Name = "pnValidacao";
            this.pnValidacao.Size = new System.Drawing.Size(1197, 152);
            this.pnValidacao.TabIndex = 11;
            this.pnValidacao.Visible = false;
            // 
            // dataGridValidation
            // 
            this.dataGridValidation.AllowUserToAddRows = false;
            this.dataGridValidation.AllowUserToDeleteRows = false;
            this.dataGridValidation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridValidation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridValidation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridValidation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridValidation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridValidation.Location = new System.Drawing.Point(0, 26);
            this.dataGridValidation.Name = "dataGridValidation";
            this.dataGridValidation.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridValidation.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridValidation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridValidation.Size = new System.Drawing.Size(1197, 126);
            this.dataGridValidation.TabIndex = 0;
            this.dataGridValidation.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridValidation_CellDoubleClick);
            this.dataGridValidation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridValidation_MouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "IdTeam";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Equipe";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Total HN";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total HE";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Total Matricula";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1197, 26);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(133)))), ((int)(((byte)(150)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1197, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Validações";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // conGrid1
            // 
            this.conGrid1.AutoSize = true;
            this.conGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.conGrid1.Location = new System.Drawing.Point(0, 57);
            this.conGrid1.Name = "conGrid1";
            this.conGrid1.Size = new System.Drawing.Size(1197, 428);
            this.conGrid1.TabIndex = 3;
            // 
            // frmFolhaApropriacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 662);
            this.Controls.Add(this.conGrid1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnValidacao);
            this.KeyPreview = true;
            this.Name = "frmFolhaApropriacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apropriação de Horas - v5.505.29.1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmFolhaApropriacao_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCalendar)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnValidacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridValidation)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbEquipe;
        private conGrid conGrid1;
        private System.Windows.Forms.Button btnAddTarefa;
        private System.Windows.Forms.Button btnAddMatricula;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.PictureBox pictureCalendar;
        private System.Windows.Forms.PictureBox btnCalendar;
        private System.Windows.Forms.TextBox txtDateSelect;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.Panel pnValidacao;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridValidation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewImageColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbGrupo;
        private System.Windows.Forms.Label lblEquipe;
        private System.Windows.Forms.Label lblEquipeH;
    }
}

