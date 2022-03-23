namespace GedocLerXML
{
    partial class AtualizaXML
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xNomeEmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJEmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ano = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsertUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Automatico = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1288, 28);
            this.progressBar1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 500);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1288, 28);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(250, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Atualizar XML GEDOC";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chNFe,
            this.nNF,
            this.serie,
            this.xNomeEmi,
            this.CNPJEmi,
            this.CNPJDest,
            this.dEmi,
            this.tpNF,
            this.vNF,
            this.Ano,
            this.InsertUpdate});
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1264, 380);
            this.dataGridView1.TabIndex = 3;
            // 
            // chNFe
            // 
            this.chNFe.HeaderText = "chNFe";
            this.chNFe.Name = "chNFe";
            // 
            // nNF
            // 
            this.nNF.HeaderText = "nNF";
            this.nNF.Name = "nNF";
            // 
            // serie
            // 
            this.serie.HeaderText = "serie";
            this.serie.Name = "serie";
            // 
            // xNomeEmi
            // 
            this.xNomeEmi.HeaderText = "xNomeEmi";
            this.xNomeEmi.Name = "xNomeEmi";
            // 
            // CNPJEmi
            // 
            this.CNPJEmi.HeaderText = "CNPJEmi";
            this.CNPJEmi.Name = "CNPJEmi";
            // 
            // CNPJDest
            // 
            this.CNPJDest.HeaderText = "CNPJDest";
            this.CNPJDest.Name = "CNPJDest";
            // 
            // dEmi
            // 
            this.dEmi.HeaderText = "dEmi";
            this.dEmi.Name = "dEmi";
            // 
            // tpNF
            // 
            this.tpNF.HeaderText = "tpNF";
            this.tpNF.Name = "tpNF";
            // 
            // vNF
            // 
            this.vNF.HeaderText = "vNF";
            this.vNF.Name = "vNF";
            // 
            // Ano
            // 
            this.Ano.HeaderText = "Ano";
            this.Ano.Name = "Ano";
            // 
            // InsertUpdate
            // 
            this.InsertUpdate.HeaderText = "InsertUpdate";
            this.InsertUpdate.Name = "InsertUpdate";
            // 
            // Automatico
            // 
            this.Automatico.Enabled = true;
            this.Automatico.Interval = 1000;
            this.Automatico.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // AtualizaXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 528);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "AtualizaXML";
            this.Text = "Atualização da XML - GEDOC";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn xNomeEmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJEmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn vNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ano;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsertUpdate;
        private System.Windows.Forms.Timer Automatico;
    }
}

