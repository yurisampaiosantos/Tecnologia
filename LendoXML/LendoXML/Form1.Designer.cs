namespace LendoXML
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btSalvarExcel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NomeArquivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJEmit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xNomeEmit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xFant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNPJDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xNomeDest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dEmi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.natOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detnItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infAdProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pICMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vICMS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.infCpl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vUnCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vFrete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vOutro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qVol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vProd2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xMotivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dVenc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refNFe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cStat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pesoL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Selecionar XML´s";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Excel|*.xls";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeArquivo,
            this.chNFe,
            this.CNPJEmit,
            this.xNomeEmit,
            this.xFant,
            this.CNPJDest,
            this.xNomeDest,
            this.nNF,
            this.serie,
            this.dEmi,
            this.UF,
            this.natOp,
            this.tpNF,
            this.cDV,
            this.vNF,
            this.vProd,
            this.detnItem,
            this.cProd,
            this.infAdProd,
            this.xProd,
            this.pICMS,
            this.vICMS,
            this.vBC,
            this.infCpl,
            this.NCM,
            this.CFOP,
            this.uCom,
            this.qCom,
            this.vUnCom,
            this.vFrete,
            this.vOutro,
            this.qVol,
            this.vProd2,
            this.xMotivo,
            this.dVenc,
            this.refNFe,
            this.cStat,
            this.pesoB,
            this.pesoL});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 356);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btSalvarExcel
            // 
            this.btSalvarExcel.Location = new System.Drawing.Point(372, 7);
            this.btSalvarExcel.Name = "btSalvarExcel";
            this.btSalvarExcel.Size = new System.Drawing.Size(193, 58);
            this.btSalvarExcel.TabIndex = 2;
            this.btSalvarExcel.Text = "Salvar em Excel";
            this.btSalvarExcel.UseVisualStyleBackColor = true;
            this.btSalvarExcel.Visible = false;
            this.btSalvarExcel.Click += new System.EventHandler(this.btSalvarExcel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 427);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(575, 22);
            this.progressBar1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btSalvarExcel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 71);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 356);
            this.panel2.TabIndex = 8;
            // 
            // NomeArquivo
            // 
            this.NomeArquivo.HeaderText = "NomeArquivo";
            this.NomeArquivo.Name = "NomeArquivo";
            this.NomeArquivo.Width = 21;
            // 
            // chNFe
            // 
            this.chNFe.HeaderText = "chNFe";
            this.chNFe.Name = "chNFe";
            this.chNFe.Width = 21;
            // 
            // CNPJEmit
            // 
            this.CNPJEmit.HeaderText = "CNPJEmit";
            this.CNPJEmit.Name = "CNPJEmit";
            this.CNPJEmit.Width = 21;
            // 
            // xNomeEmit
            // 
            this.xNomeEmit.HeaderText = "xNomeEmit";
            this.xNomeEmit.Name = "xNomeEmit";
            this.xNomeEmit.Width = 21;
            // 
            // xFant
            // 
            this.xFant.HeaderText = "xFant";
            this.xFant.Name = "xFant";
            this.xFant.Width = 21;
            // 
            // CNPJDest
            // 
            this.CNPJDest.HeaderText = "CNPJDest";
            this.CNPJDest.Name = "CNPJDest";
            this.CNPJDest.Width = 21;
            // 
            // xNomeDest
            // 
            this.xNomeDest.HeaderText = "xNomeDest";
            this.xNomeDest.Name = "xNomeDest";
            this.xNomeDest.Width = 21;
            // 
            // nNF
            // 
            this.nNF.HeaderText = "nNF";
            this.nNF.Name = "nNF";
            this.nNF.Width = 21;
            // 
            // serie
            // 
            this.serie.HeaderText = "serie";
            this.serie.Name = "serie";
            this.serie.Width = 21;
            // 
            // dEmi
            // 
            this.dEmi.HeaderText = "dEmi";
            this.dEmi.Name = "dEmi";
            this.dEmi.Width = 21;
            // 
            // UF
            // 
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            this.UF.Width = 21;
            // 
            // natOp
            // 
            this.natOp.HeaderText = "natOp";
            this.natOp.Name = "natOp";
            this.natOp.Width = 21;
            // 
            // tpNF
            // 
            this.tpNF.HeaderText = "tpNF";
            this.tpNF.Name = "tpNF";
            this.tpNF.Width = 21;
            // 
            // cDV
            // 
            this.cDV.HeaderText = "cDV";
            this.cDV.Name = "cDV";
            this.cDV.Width = 21;
            // 
            // vNF
            // 
            this.vNF.HeaderText = "vNF";
            this.vNF.Name = "vNF";
            this.vNF.Width = 21;
            // 
            // vProd
            // 
            this.vProd.HeaderText = "vProdItem";
            this.vProd.Name = "vProd";
            this.vProd.Width = 21;
            // 
            // detnItem
            // 
            this.detnItem.HeaderText = "detnItem";
            this.detnItem.Name = "detnItem";
            this.detnItem.Width = 21;
            // 
            // cProd
            // 
            this.cProd.HeaderText = "cProd";
            this.cProd.Name = "cProd";
            this.cProd.Width = 21;
            // 
            // infAdProd
            // 
            this.infAdProd.HeaderText = "infAdProd";
            this.infAdProd.Name = "infAdProd";
            this.infAdProd.Width = 21;
            // 
            // xProd
            // 
            this.xProd.HeaderText = "xProd";
            this.xProd.Name = "xProd";
            this.xProd.Width = 21;
            // 
            // pICMS
            // 
            this.pICMS.HeaderText = "pICMS";
            this.pICMS.Name = "pICMS";
            this.pICMS.Width = 21;
            // 
            // vICMS
            // 
            this.vICMS.HeaderText = "vICMS";
            this.vICMS.Name = "vICMS";
            this.vICMS.Width = 21;
            // 
            // vBC
            // 
            this.vBC.HeaderText = "vBC";
            this.vBC.Name = "vBC";
            this.vBC.Width = 21;
            // 
            // infCpl
            // 
            this.infCpl.HeaderText = "infCpl";
            this.infCpl.Name = "infCpl";
            this.infCpl.Width = 21;
            // 
            // NCM
            // 
            this.NCM.HeaderText = "NCM";
            this.NCM.Name = "NCM";
            this.NCM.Width = 21;
            // 
            // CFOP
            // 
            this.CFOP.HeaderText = "CFOP";
            this.CFOP.Name = "CFOP";
            this.CFOP.Width = 21;
            // 
            // uCom
            // 
            this.uCom.HeaderText = "uCom";
            this.uCom.Name = "uCom";
            this.uCom.Width = 21;
            // 
            // qCom
            // 
            this.qCom.HeaderText = "qCom";
            this.qCom.Name = "qCom";
            this.qCom.Width = 21;
            // 
            // vUnCom
            // 
            this.vUnCom.HeaderText = "vUnCom";
            this.vUnCom.Name = "vUnCom";
            this.vUnCom.Width = 21;
            // 
            // vFrete
            // 
            this.vFrete.HeaderText = "vFrete";
            this.vFrete.Name = "vFrete";
            this.vFrete.Width = 21;
            // 
            // vOutro
            // 
            this.vOutro.HeaderText = "vOutro";
            this.vOutro.Name = "vOutro";
            this.vOutro.Width = 21;
            // 
            // qVol
            // 
            this.qVol.HeaderText = "qVol";
            this.qVol.Name = "qVol";
            this.qVol.Width = 21;
            // 
            // vProd2
            // 
            this.vProd2.HeaderText = "vProd";
            this.vProd2.Name = "vProd2";
            this.vProd2.Width = 21;
            // 
            // xMotivo
            // 
            this.xMotivo.HeaderText = "xMotivo";
            this.xMotivo.Name = "xMotivo";
            this.xMotivo.Width = 21;
            // 
            // dVenc
            // 
            this.dVenc.HeaderText = "dVenc";
            this.dVenc.Name = "dVenc";
            this.dVenc.Width = 21;
            // 
            // refNFe
            // 
            this.refNFe.HeaderText = "refNFe";
            this.refNFe.Name = "refNFe";
            this.refNFe.Width = 21;
            // 
            // cStat
            // 
            this.cStat.HeaderText = "cStat";
            this.cStat.Name = "cStat";
            this.cStat.Width = 21;
            // 
            // pesoB
            // 
            this.pesoB.HeaderText = "pesoB";
            this.pesoB.Name = "pesoB";
            this.pesoB.Width = 21;
            // 
            // pesoL
            // 
            this.pesoL.HeaderText = "pesoL";
            this.pesoL.Name = "pesoL";
            this.pesoL.Width = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 449);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progressBar1);
            this.Name = "Form1";
            this.Text = "Captura dados XML";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btSalvarExcel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeArquivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn chNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJEmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn xNomeEmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn xFant;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNPJDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn xNomeDest;
        private System.Windows.Forms.DataGridViewTextBoxColumn nNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn dEmi;
        private System.Windows.Forms.DataGridViewTextBoxColumn UF;
        private System.Windows.Forms.DataGridViewTextBoxColumn natOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDV;
        private System.Windows.Forms.DataGridViewTextBoxColumn vNF;
        private System.Windows.Forms.DataGridViewTextBoxColumn vProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn detnItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn infAdProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn xProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn pICMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn vICMS;
        private System.Windows.Forms.DataGridViewTextBoxColumn vBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn infCpl;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFOP;
        private System.Windows.Forms.DataGridViewTextBoxColumn uCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn qCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn vUnCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn vFrete;
        private System.Windows.Forms.DataGridViewTextBoxColumn vOutro;
        private System.Windows.Forms.DataGridViewTextBoxColumn qVol;
        private System.Windows.Forms.DataGridViewTextBoxColumn vProd2;
        private System.Windows.Forms.DataGridViewTextBoxColumn xMotivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dVenc;
        private System.Windows.Forms.DataGridViewTextBoxColumn refNFe;
        private System.Windows.Forms.DataGridViewTextBoxColumn cStat;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn pesoL;
    }
}

