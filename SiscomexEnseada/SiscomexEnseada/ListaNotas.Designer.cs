namespace SiscomexEnseada
{
    partial class ListaNotas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListaNotas));
            this.btImportar = new System.Windows.Forms.Button();
            this.btSair = new System.Windows.Forms.Button();
            this.btImportarXML = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btSelecionarTodos = new System.Windows.Forms.Button();
            this.btTransformaTonKg = new System.Windows.Forms.Button();
            this.btSalvarExcel = new System.Windows.Forms.Button();
            this.lbTotalNotas = new System.Windows.Forms.Label();
            this.btExcluir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dvListaNotas = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SELECAO = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CHAVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ_FORNECEDOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJ_TRANSPORTADOR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OBSERVACOES_GERAIS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PESO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STATUSBALANCA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balanca = new System.Windows.Forms.DataGridViewImageColumn();
            this.IconStatus = new System.Windows.Forms.DataGridViewImageColumn();
            this.Erro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btSalvar = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvListaNotas)).BeginInit();
            this.SuspendLayout();
            // 
            // btImportar
            // 
            this.btImportar.Location = new System.Drawing.Point(668, 22);
            this.btImportar.Name = "btImportar";
            this.btImportar.Size = new System.Drawing.Size(126, 47);
            this.btImportar.TabIndex = 2;
            this.btImportar.Text = "Importar Excel";
            this.btImportar.UseVisualStyleBackColor = true;
            this.btImportar.Visible = false;
            this.btImportar.Click += new System.EventHandler(this.BtImportar_Click);
            // 
            // btSair
            // 
            this.btSair.Location = new System.Drawing.Point(32, 22);
            this.btSair.Name = "btSair";
            this.btSair.Size = new System.Drawing.Size(126, 47);
            this.btSair.TabIndex = 3;
            this.btSair.Text = "Sair";
            this.btSair.UseVisualStyleBackColor = true;
            this.btSair.Click += new System.EventHandler(this.BtSair_Click);
            // 
            // btImportarXML
            // 
            this.btImportarXML.Location = new System.Drawing.Point(820, 22);
            this.btImportarXML.Name = "btImportarXML";
            this.btImportarXML.Size = new System.Drawing.Size(126, 47);
            this.btImportarXML.TabIndex = 7;
            this.btImportarXML.Text = "Importar XML";
            this.btImportarXML.UseVisualStyleBackColor = true;
            this.btImportarXML.Click += new System.EventHandler(this.BtImportarXML_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Good mark.png");
            this.imageList1.Images.SetKeyName(1, "Bad mark.png");
            this.imageList1.Images.SetKeyName(2, "aguardando.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btSalvar);
            this.panel2.Controls.Add(this.btSelecionarTodos);
            this.panel2.Controls.Add(this.btTransformaTonKg);
            this.panel2.Controls.Add(this.btSalvarExcel);
            this.panel2.Controls.Add(this.lbTotalNotas);
            this.panel2.Controls.Add(this.btExcluir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 447);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(952, 41);
            this.panel2.TabIndex = 8;
            // 
            // btSelecionarTodos
            // 
            this.btSelecionarTodos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btSelecionarTodos.Location = new System.Drawing.Point(150, 10);
            this.btSelecionarTodos.Name = "btSelecionarTodos";
            this.btSelecionarTodos.Size = new System.Drawing.Size(132, 23);
            this.btSelecionarTodos.TabIndex = 4;
            this.btSelecionarTodos.Text = "Selecionar Todos";
            this.btSelecionarTodos.UseVisualStyleBackColor = false;
            this.btSelecionarTodos.Click += new System.EventHandler(this.btSelecionarTodos_Click);
            // 
            // btTransformaTonKg
            // 
            this.btTransformaTonKg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btTransformaTonKg.Location = new System.Drawing.Point(658, 10);
            this.btTransformaTonKg.Name = "btTransformaTonKg";
            this.btTransformaTonKg.Size = new System.Drawing.Size(152, 23);
            this.btTransformaTonKg.TabIndex = 3;
            this.btTransformaTonKg.Text = "Transformar TON em KG";
            this.btTransformaTonKg.UseVisualStyleBackColor = false;
            this.btTransformaTonKg.Click += new System.EventHandler(this.btTransformaTonKg_Click);
            // 
            // btSalvarExcel
            // 
            this.btSalvarExcel.Location = new System.Drawing.Point(12, 10);
            this.btSalvarExcel.Name = "btSalvarExcel";
            this.btSalvarExcel.Size = new System.Drawing.Size(123, 23);
            this.btSalvarExcel.TabIndex = 2;
            this.btSalvarExcel.Text = "Exportar (xls)";
            this.btSalvarExcel.UseVisualStyleBackColor = true;
            this.btSalvarExcel.Click += new System.EventHandler(this.BtSalvarExcel_Click);
            // 
            // lbTotalNotas
            // 
            this.lbTotalNotas.AutoSize = true;
            this.lbTotalNotas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalNotas.Location = new System.Drawing.Point(832, 15);
            this.lbTotalNotas.Name = "lbTotalNotas";
            this.lbTotalNotas.Size = new System.Drawing.Size(36, 13);
            this.lbTotalNotas.TabIndex = 1;
            this.lbTotalNotas.Text = "Total";
            // 
            // btExcluir
            // 
            this.btExcluir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btExcluir.Location = new System.Drawing.Point(541, 10);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(92, 23);
            this.btExcluir.TabIndex = 0;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = false;
            this.btExcluir.Click += new System.EventHandler(this.BtExcluir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dvListaNotas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 360);
            this.panel1.TabIndex = 9;
            // 
            // dvListaNotas
            // 
            this.dvListaNotas.AllowUserToAddRows = false;
            this.dvListaNotas.AllowUserToDeleteRows = false;
            this.dvListaNotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvListaNotas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.SELECAO,
            this.CHAVE,
            this.CNPJ_FORNECEDOR,
            this.CNPJ_TRANSPORTADOR,
            this.OBSERVACOES_GERAIS,
            this.PESO,
            this.Status,
            this.STATUSBALANCA,
            this.Balanca,
            this.IconStatus,
            this.Erro});
            this.dvListaNotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvListaNotas.Location = new System.Drawing.Point(0, 0);
            this.dvListaNotas.MultiSelect = false;
            this.dvListaNotas.Name = "dvListaNotas";
            this.dvListaNotas.RowHeadersWidth = 82;
            this.dvListaNotas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvListaNotas.Size = new System.Drawing.Size(952, 360);
            this.dvListaNotas.TabIndex = 0;
            this.dvListaNotas.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvListaNotas_CellEndEdit);
            this.dvListaNotas.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DvListaNotas_CellFormatting);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.Frozen = true;
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 10;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 200;
            // 
            // SELECAO
            // 
            this.SELECAO.Frozen = true;
            this.SELECAO.HeaderText = "Seleção";
            this.SELECAO.MinimumWidth = 10;
            this.SELECAO.Name = "SELECAO";
            this.SELECAO.Width = 50;
            // 
            // CHAVE
            // 
            this.CHAVE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CHAVE.DataPropertyName = "CHAVE_NOTA";
            this.CHAVE.Frozen = true;
            this.CHAVE.HeaderText = "NFe";
            this.CHAVE.MinimumWidth = 10;
            this.CHAVE.Name = "CHAVE";
            this.CHAVE.ReadOnly = true;
            this.CHAVE.Width = 52;
            // 
            // CNPJ_FORNECEDOR
            // 
            this.CNPJ_FORNECEDOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CNPJ_FORNECEDOR.DataPropertyName = "CNPJ_FORNECEDOR";
            this.CNPJ_FORNECEDOR.Frozen = true;
            this.CNPJ_FORNECEDOR.HeaderText = "CNPJ Fornecedor";
            this.CNPJ_FORNECEDOR.MinimumWidth = 10;
            this.CNPJ_FORNECEDOR.Name = "CNPJ_FORNECEDOR";
            this.CNPJ_FORNECEDOR.ReadOnly = true;
            this.CNPJ_FORNECEDOR.Width = 106;
            // 
            // CNPJ_TRANSPORTADOR
            // 
            this.CNPJ_TRANSPORTADOR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CNPJ_TRANSPORTADOR.DataPropertyName = "CNPJ_TRANSPORTADOR";
            this.CNPJ_TRANSPORTADOR.Frozen = true;
            this.CNPJ_TRANSPORTADOR.HeaderText = "CNPJ Transportador";
            this.CNPJ_TRANSPORTADOR.MinimumWidth = 10;
            this.CNPJ_TRANSPORTADOR.Name = "CNPJ_TRANSPORTADOR";
            this.CNPJ_TRANSPORTADOR.Width = 117;
            // 
            // OBSERVACOES_GERAIS
            // 
            this.OBSERVACOES_GERAIS.DataPropertyName = "OBSERVACOES_GERAIS";
            this.OBSERVACOES_GERAIS.Frozen = true;
            this.OBSERVACOES_GERAIS.HeaderText = "Observações";
            this.OBSERVACOES_GERAIS.MinimumWidth = 10;
            this.OBSERVACOES_GERAIS.Name = "OBSERVACOES_GERAIS";
            this.OBSERVACOES_GERAIS.Width = 115;
            // 
            // PESO
            // 
            this.PESO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PESO.DataPropertyName = "PESO";
            this.PESO.Frozen = true;
            this.PESO.HeaderText = "Peso";
            this.PESO.MinimumWidth = 10;
            this.PESO.Name = "PESO";
            this.PESO.Width = 56;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "STATUS";
            this.Status.Frozen = true;
            this.Status.HeaderText = "STATUS";
            this.Status.MinimumWidth = 2;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 2;
            // 
            // STATUSBALANCA
            // 
            this.STATUSBALANCA.DataPropertyName = "STATUSBALANCA";
            this.STATUSBALANCA.Frozen = true;
            this.STATUSBALANCA.HeaderText = "STATUSBALANCA";
            this.STATUSBALANCA.MinimumWidth = 2;
            this.STATUSBALANCA.Name = "STATUSBALANCA";
            this.STATUSBALANCA.ReadOnly = true;
            this.STATUSBALANCA.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.STATUSBALANCA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.STATUSBALANCA.Width = 2;
            // 
            // Balanca
            // 
            this.Balanca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Balanca.HeaderText = "Balanca";
            this.Balanca.MinimumWidth = 10;
            this.Balanca.Name = "Balanca";
            this.Balanca.ReadOnly = true;
            this.Balanca.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Balanca.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Balanca.Width = 71;
            // 
            // IconStatus
            // 
            this.IconStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IconStatus.HeaderText = "Status";
            this.IconStatus.MinimumWidth = 10;
            this.IconStatus.Name = "IconStatus";
            this.IconStatus.ReadOnly = true;
            this.IconStatus.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IconStatus.Width = 62;
            // 
            // Erro
            // 
            this.Erro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Erro.DataPropertyName = "Erro";
            this.Erro.HeaderText = "Erro";
            this.Erro.MinimumWidth = 10;
            this.Erro.Name = "Erro";
            this.Erro.ReadOnly = true;
            this.Erro.Width = 51;
            // 
            // btSalvar
            // 
            this.btSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btSalvar.Location = new System.Drawing.Point(302, 10);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(152, 23);
            this.btSalvar.TabIndex = 5;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = false;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // ListaNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btImportarXML);
            this.Controls.Add(this.btSair);
            this.Controls.Add(this.btImportar);
            this.Name = "ListaNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lista_Notas";
            this.Load += new System.EventHandler(this.ListaNotas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvListaNotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btImportar;
        private System.Windows.Forms.Button btSair;
        private System.Windows.Forms.Button btImportarXML;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvListaNotas;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Label lbTotalNotas;
        private System.Windows.Forms.Button btSalvarExcel;
        private System.Windows.Forms.Button btTransformaTonKg;
        private System.Windows.Forms.Button btSelecionarTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SELECAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CHAVE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ_FORNECEDOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJ_TRANSPORTADOR;
        private System.Windows.Forms.DataGridViewTextBoxColumn OBSERVACOES_GERAIS;
        private System.Windows.Forms.DataGridViewTextBoxColumn PESO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn STATUSBALANCA;
        private System.Windows.Forms.DataGridViewImageColumn Balanca;
        private System.Windows.Forms.DataGridViewImageColumn IconStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Erro;
        private System.Windows.Forms.Button btSalvar;
    }
}