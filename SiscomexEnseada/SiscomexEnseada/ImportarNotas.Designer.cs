namespace SiscomexEnseada
{
    partial class ImportarNotas
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
            this.panel1.Size = new System.Drawing.Size(536, 342);
            this.panel1.TabIndex = 0;
            // 
            // dvListanotas
            // 
            this.dvListanotas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvListanotas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvListanotas.Location = new System.Drawing.Point(0, 0);
            this.dvListanotas.Name = "dvListanotas";
            this.dvListanotas.Size = new System.Drawing.Size(536, 342);
            this.dvListanotas.TabIndex = 0;
            // 
            // btImportarPlanilha
            // 
            this.btImportarPlanilha.Location = new System.Drawing.Point(12, 23);
            this.btImportarPlanilha.Name = "btImportarPlanilha";
            this.btImportarPlanilha.Size = new System.Drawing.Size(195, 47);
            this.btImportarPlanilha.TabIndex = 1;
            this.btImportarPlanilha.Text = "Selecionar Planilha";
            this.btImportarPlanilha.UseVisualStyleBackColor = true;
            this.btImportarPlanilha.Click += new System.EventHandler(this.BtImportarPlanilha_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(245, 25);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(256, 44);
            this.btSalvar.TabIndex = 2;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.BtSalvar_Click);
            // 
            // ImportarNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 433);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btImportarPlanilha);
            this.Controls.Add(this.panel1);
            this.Name = "ImportarNotas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importar Notas - Excel";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dvListanotas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dvListanotas;
        private System.Windows.Forms.Button btImportarPlanilha;
        private System.Windows.Forms.Button btSalvar;
    }
}