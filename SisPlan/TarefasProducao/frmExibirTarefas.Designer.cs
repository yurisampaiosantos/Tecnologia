namespace TarefasProducao
{
    partial class frmExibirTarefas
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
            this.dtg = new System.Windows.Forms.DataGridView();
            this.INTA_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTA_FUNCIONARIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTA_TAREFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTA_INLO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INLO_NOME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTA_STATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INTA_ACTIVE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConverteP76FOSE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // dtg
            // 
            this.dtg.AllowUserToAddRows = false;
            this.dtg.AllowUserToDeleteRows = false;
            this.dtg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INTA_ID,
            this.INTA_FUNCIONARIO,
            this.INTA_TAREFA,
            this.INTA_INLO_ID,
            this.INLO_NOME,
            this.INTA_STATUS,
            this.INTA_ACTIVE});
            this.dtg.Location = new System.Drawing.Point(2, 183);
            this.dtg.Name = "dtg";
            this.dtg.ReadOnly = true;
            this.dtg.Size = new System.Drawing.Size(744, 339);
            this.dtg.TabIndex = 1;
            // 
            // INTA_ID
            // 
            this.INTA_ID.DataPropertyName = "INTA_ID";
            this.INTA_ID.HeaderText = "ID";
            this.INTA_ID.Name = "INTA_ID";
            this.INTA_ID.ReadOnly = true;
            this.INTA_ID.Visible = false;
            // 
            // INTA_FUNCIONARIO
            // 
            this.INTA_FUNCIONARIO.DataPropertyName = "INTA_FUNCIONARIO";
            this.INTA_FUNCIONARIO.HeaderText = "Funcionário";
            this.INTA_FUNCIONARIO.Name = "INTA_FUNCIONARIO";
            this.INTA_FUNCIONARIO.ReadOnly = true;
            this.INTA_FUNCIONARIO.Width = 200;
            // 
            // INTA_TAREFA
            // 
            this.INTA_TAREFA.DataPropertyName = "INTA_TAREFA";
            this.INTA_TAREFA.HeaderText = "Tarefa";
            this.INTA_TAREFA.Name = "INTA_TAREFA";
            this.INTA_TAREFA.ReadOnly = true;
            this.INTA_TAREFA.Width = 300;
            // 
            // INTA_INLO_ID
            // 
            this.INTA_INLO_ID.DataPropertyName = "INTA_INLO_ID";
            this.INTA_INLO_ID.HeaderText = "Local Id";
            this.INTA_INLO_ID.Name = "INTA_INLO_ID";
            this.INTA_INLO_ID.ReadOnly = true;
            this.INTA_INLO_ID.Visible = false;
            this.INTA_INLO_ID.Width = 150;
            // 
            // INLO_NOME
            // 
            this.INLO_NOME.DataPropertyName = "INLO_NOME";
            this.INLO_NOME.HeaderText = "Local";
            this.INLO_NOME.Name = "INLO_NOME";
            this.INLO_NOME.ReadOnly = true;
            // 
            // INTA_STATUS
            // 
            this.INTA_STATUS.DataPropertyName = "INTA_STATUS";
            this.INTA_STATUS.HeaderText = "INTA_STATUS";
            this.INTA_STATUS.Name = "INTA_STATUS";
            this.INTA_STATUS.ReadOnly = true;
            this.INTA_STATUS.Visible = false;
            this.INTA_STATUS.Width = 50;
            // 
            // INTA_ACTIVE
            // 
            this.INTA_ACTIVE.DataPropertyName = "INTA_ACTIVE";
            this.INTA_ACTIVE.HeaderText = "ACTIVE";
            this.INTA_ACTIVE.Name = "INTA_ACTIVE";
            this.INTA_ACTIVE.ReadOnly = true;
            this.INTA_ACTIVE.Visible = false;
            // 
            // btnConverteP76FOSE
            // 
            this.btnConverteP76FOSE.Location = new System.Drawing.Point(12, 29);
            this.btnConverteP76FOSE.Name = "btnConverteP76FOSE";
            this.btnConverteP76FOSE.Size = new System.Drawing.Size(175, 23);
            this.btnConverteP76FOSE.TabIndex = 2;
            this.btnConverteP76FOSE.Text = "Converte FoseNumero P76";
            this.btnConverteP76FOSE.UseVisualStyleBackColor = true;
            this.btnConverteP76FOSE.Click += new System.EventHandler(this.btnConverteP76FOSE_Click);
            // 
            // frmExibirTarefas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 682);
            this.Controls.Add(this.btnConverteP76FOSE);
            this.Controls.Add(this.dtg);
            this.Name = "frmExibirTarefas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Status Tarefas Produção";
            this.Load += new System.EventHandler(this.frmExibirTarefas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtg;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_FUNCIONARIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_TAREFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_INLO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INLO_NOME;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_STATUS;
        private System.Windows.Forms.DataGridViewTextBoxColumn INTA_ACTIVE;
        private System.Windows.Forms.Button btnConverteP76FOSE;
    }
}

