namespace SiscomexEnseada
{
    partial class ImportarNotasXML
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dvListanotas = new System.Windows.Forms.DataGridView();
            this.Chave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnpjFornedorDrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJTRANSPORTADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Erro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacoes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btImportarPlanilha = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvListanotas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dvListanotas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 342);
            this.panel1.TabIndex = 0;
            // 
            // dvListanotas
            // 
            this.dvListanotas.AllowUserToAddRows = false;
            this.dvListanotas.AllowUserToDeleteRows = false;
            this.dvListanotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvListanotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chave,
            this.cnpjFornedorDrid,
            this.CNPJTRANSPORTADOR,
            this.Peso,
            this.Erro,
            this.Observacoes});
            this.dvListanotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvListanotas.Location = new System.Drawing.Point(0, 0);
            this.dvListanotas.MultiSelect = false;
            this.dvListanotas.Name = "dvListanotas";
            this.dvListanotas.ReadOnly = true;
            this.dvListanotas.RowHeadersWidth = 82;
            this.dvListanotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dvListanotas.Size = new System.Drawing.Size(1008, 342);
            this.dvListanotas.TabIndex = 0;
            // 
            // Chave
            // 
            this.Chave.DataPropertyName = "chavenota";
            this.Chave.HeaderText = "NFe";
            this.Chave.MinimumWidth = 10;
            this.Chave.Name = "Chave";
            this.Chave.ReadOnly = true;
            this.Chave.Width = 200;
            // 
            // cnpjFornedorDrid
            // 
            this.cnpjFornedorDrid.DataPropertyName = "cnpj";
            this.cnpjFornedorDrid.HeaderText = "CNPJ Fornedecor";
            this.cnpjFornedorDrid.MinimumWidth = 10;
            this.cnpjFornedorDrid.Name = "cnpjFornedorDrid";
            this.cnpjFornedorDrid.ReadOnly = true;
            this.cnpjFornedorDrid.Width = 200;
            // 
            // CNPJTRANSPORTADOR
            // 
            this.CNPJTRANSPORTADOR.DataPropertyName = "CNPJTRANSPORTADOR";
            this.CNPJTRANSPORTADOR.HeaderText = "CNPJ Transportador";
            this.CNPJTRANSPORTADOR.MinimumWidth = 10;
            this.CNPJTRANSPORTADOR.Name = "CNPJTRANSPORTADOR";
            this.CNPJTRANSPORTADOR.ReadOnly = true;
            this.CNPJTRANSPORTADOR.Width = 200;
            // 
            // Peso
            // 
            this.Peso.DataPropertyName = "Peso";
            this.Peso.HeaderText = "Peso";
            this.Peso.MinimumWidth = 10;
            this.Peso.Name = "Peso";
            this.Peso.ReadOnly = true;
            this.Peso.Width = 200;
            // 
            // Erro
            // 
            this.Erro.DataPropertyName = "Erro";
            this.Erro.HeaderText = "Erro";
            this.Erro.MinimumWidth = 10;
            this.Erro.Name = "Erro";
            this.Erro.ReadOnly = true;
            this.Erro.Width = 200;
            // 
            // Observacoes
            // 
            this.Observacoes.DataPropertyName = "Observacoes";
            this.Observacoes.HeaderText = "Observações";
            this.Observacoes.MinimumWidth = 10;
            this.Observacoes.Name = "Observacoes";
            this.Observacoes.ReadOnly = true;
            this.Observacoes.Width = 200;
            // 
            // btImportarPlanilha
            // 
            this.btImportarPlanilha.Location = new System.Drawing.Point(654, 22);
            this.btImportarPlanilha.Name = "btImportarPlanilha";
            this.btImportarPlanilha.Size = new System.Drawing.Size(195, 47);
            this.btImportarPlanilha.TabIndex = 1;
            this.btImportarPlanilha.Text = "Selecionar Diretorio (XMLs)";
            this.btImportarPlanilha.UseVisualStyleBackColor = true;
            this.btImportarPlanilha.Click += new System.EventHandler(this.BtImportarPlanilha_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(33, 22);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(205, 44);
            this.btSalvar.TabIndex = 2;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Visible = false;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // ImportarNotasXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 433);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btImportarPlanilha);
            this.Controls.Add(this.panel1);
            this.Name = "ImportarNotasXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importar Notas - XML";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvListanotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvListanotas;
        private System.Windows.Forms.Button btImportarPlanilha;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Chave;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnpjFornedorDrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJTRANSPORTADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacoes;
    }
}