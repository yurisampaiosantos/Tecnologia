namespace Replat
{
    partial class frmDisponiveis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisponiveis));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btFechar = new System.Windows.Forms.Button();
            this.btAtualizar = new System.Windows.Forms.Button();
            this.gvInterfaces = new System.Windows.Forms.DataGridView();
            this.ckbTodos = new System.Windows.Forms.CheckBox();
            this.Column6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTDE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TABELA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvInterfaces)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 87);
            this.panel1.TabIndex = 61;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btLimpar);
            this.groupBox2.Controls.Add(this.btFechar);
            this.groupBox2.Controls.Add(this.btAtualizar);
            this.groupBox2.Location = new System.Drawing.Point(15, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(310, 63);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Opções";
            // 
            // btLimpar
            // 
            this.btLimpar.Image = global::CI.Properties.Resources.application_form1;
            this.btLimpar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btLimpar.Location = new System.Drawing.Point(115, 24);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(81, 22);
            this.btLimpar.TabIndex = 56;
            this.btLimpar.Text = "Limpar";
            this.btLimpar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // btFechar
            // 
            this.btFechar.Image = ((System.Drawing.Image)(resources.GetObject("btFechar.Image")));
            this.btFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btFechar.Location = new System.Drawing.Point(210, 24);
            this.btFechar.Name = "btFechar";
            this.btFechar.Size = new System.Drawing.Size(81, 22);
            this.btFechar.TabIndex = 57;
            this.btFechar.Text = "Fechar";
            this.btFechar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btFechar.UseVisualStyleBackColor = true;
            this.btFechar.Click += new System.EventHandler(this.btFechar_Click);
            // 
            // btAtualizar
            // 
            this.btAtualizar.Image = global::CI.Properties.Resources.atualizar;
            this.btAtualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAtualizar.Location = new System.Drawing.Point(20, 24);
            this.btAtualizar.Name = "btAtualizar";
            this.btAtualizar.Size = new System.Drawing.Size(81, 22);
            this.btAtualizar.TabIndex = 59;
            this.btAtualizar.Text = "Atualizar";
            this.btAtualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAtualizar.UseVisualStyleBackColor = true;
            this.btAtualizar.Click += new System.EventHandler(this.btAtualizar_Click);
            // 
            // gvInterfaces
            // 
            this.gvInterfaces.AllowUserToAddRows = false;
            this.gvInterfaces.AllowUserToDeleteRows = false;
            this.gvInterfaces.AllowUserToResizeColumns = false;
            this.gvInterfaces.AllowUserToResizeRows = false;
            this.gvInterfaces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvInterfaces.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gvInterfaces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gvInterfaces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column8,
            this.QUAL,
            this.QTDE,
            this.TABELA});
            this.gvInterfaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvInterfaces.Location = new System.Drawing.Point(0, 87);
            this.gvInterfaces.Name = "gvInterfaces";
            this.gvInterfaces.RowHeadersVisible = false;
            this.gvInterfaces.Size = new System.Drawing.Size(341, 421);
            this.gvInterfaces.TabIndex = 62;
            // 
            // ckbTodos
            // 
            this.ckbTodos.AutoSize = true;
            this.ckbTodos.Location = new System.Drawing.Point(12, 93);
            this.ckbTodos.Name = "ckbTodos";
            this.ckbTodos.Size = new System.Drawing.Size(15, 14);
            this.ckbTodos.TabIndex = 63;
            this.ckbTodos.UseVisualStyleBackColor = true;
            this.ckbTodos.CheckedChanged += new System.EventHandler(this.ckbTodos_CheckedChanged);
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = " ";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Width = 35;
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column8.HeaderText = "INTERFACES";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // QUAL
            // 
            this.QUAL.HeaderText = "QUAL";
            this.QUAL.Name = "QUAL";
            this.QUAL.Width = 61;
            // 
            // QTDE
            // 
            this.QTDE.HeaderText = "PROD";
            this.QTDE.Name = "QTDE";
            this.QTDE.ReadOnly = true;
            this.QTDE.Width = 63;
            // 
            // TABELA
            // 
            this.TABELA.HeaderText = "TABELA";
            this.TABELA.Name = "TABELA";
            this.TABELA.Visible = false;
            this.TABELA.Width = 73;
            // 
            // frmDisponiveis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 508);
            this.Controls.Add(this.ckbTodos);
            this.Controls.Add(this.gvInterfaces);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisponiveis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disponíveis no IN-OUT";
            this.Load += new System.EventHandler(this.frmDisponiveis_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvInterfaces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btFechar;
        private System.Windows.Forms.Button btLimpar;
        private System.Windows.Forms.DataGridView gvInterfaces;
        private System.Windows.Forms.CheckBox ckbTodos;
        private System.Windows.Forms.Button btAtualizar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn QTDE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TABELA;
    }
}