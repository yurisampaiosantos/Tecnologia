using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using System.IO;
using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;

using Excel = Microsoft.Office.Interop.Excel;

namespace Replat
{
    public partial class frmBatimentosNFS : Form
    {
        public frmBatimentosNFS()
        {
            InitializeComponent();
        }

        public string SQL()
        {
            return @"SELECT 
                        ORGANIZACAO, PART_NUMBER_ITEM, QTDE, NCM, NF, SERIE, NUM_ITEM, DESCRICAO, DATA_NF, CFOP, VALOR_UN, REF_SAIDA, REF_NFS, MACRO_PRODUTO, COD_CONSIGNATARIO, COD_CLIENTE, REF_NFE, PROCEDENCIA_INFO, DATA_GER_LEG, ID_CORPORATIVO, SENF, ENQUADRAMENTO, DATA_SAIDA, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_BAIXA, FINALIDADE_SAIDA, NUM_CONTRATO
                     FROM 
                        RF_NF_SAIDA_BAT";
        }

        public string SQL_REPLAT()
        {
            return @"SELECT 
                        ALERTA, CFOP, COD_CLIENTE, COD_CONSIGNATARIO, DATA_GER_LEG, DATA_NF, DATA_SAIDA, DESCRICAO, ENQUADRAMENTO, ID_CORPORATIVO, MACRO_PRODUTO, NCM, NF, NUM_ITEM, ORGANIZACAO, PART_NUMBER_ITEM, PROCEDENCIA_INFO, QTDE, REF_BAIXA, REF_NFE, REF_NFS, REF_SAIDA, SEGMENTO2, SEGMENTO1, SEGMENTO3, SEGMENTO4, SEGMENTO5, SENF, SERIE, VALOR_UN, FINALIDADE_SAIDA, NUM_CONTRATO
                     FROM 
                        V_NFS_BATIMENTO_REPLAT";
        }

        public string SQL_SISEPC()
        {
            return @"SELECT 
                        ALERTA, ID_IMPORTACAO, ORGANIZACAO, PART_NUMBER_ITEM, QTDE, NCM, NF, SERIE, NUM_ITEM, DESCRICAO, DATA_NF, CFOP, VALOR_UN, REF_SAIDA, REF_NFS, MACRO_PRODUTO, COD_CONSIGNATARIO, COD_CLIENTE, REF_NFE, PROCEDENCIA_INFO, ID_CORPORATIVO, SENF, ENQUADRAMENTO, DATA_SAIDA, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, REF_BAIXA, FINALIDADE_SAIDA, NUM_CONTRATO
                     FROM 
                        V_NFS_BATIMENTO_SISEPC";
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Exportar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 3;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    string folderPath = "C:\\temp\\" + this.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Batimento Replat");                //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                        ws.View.FreezePanes(2, 1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, gvImportacao.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        if (gvImportacao2.Rows.Count > 0)
                        {
                            ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add("Batimento sisEPC");                 //Adicione uma nova planilha para a pasta de trabalho vazia
                            ws2.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao2.DataSource), true);       //Carregar dados da DataTable para a planilha
                            ws2.Cells[ws2.Dimension.Address].AutoFilter = true;
                            ws2.View.FreezePanes(2, 1);

                            using (ExcelRange rng2 = ws2.Cells[1, 1, 1, gvImportacao2.Columns.Count])              //Adiciona um pouco de estilo
                            {
                                rng2.Style.Font.Bold = true;
                                rng2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                rng2.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                                rng2.Style.Font.Color.SetColor(System.Drawing.Color.White);
                            }

                            for (int o = 0; o < gvImportacao2.Rows.Count; o++)
                            {
                                for (int j = 0; j < gvImportacao2.Columns.Count; j++)
                                {
                                    if (gvImportacao2[j, o].Style.BackColor == Color.Yellow)
                                    {
                                        ws2.Cells[o + 2, j + 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                                        ws2.Cells[o + 2, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                        ws2.Cells[o + 2, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                    }
                                }
                            }
                        }

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        pck.Save();

                        Process.Start(folderPath);
                    }

                    frm.progressBar1.Value = 0;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MDIParent1 frm1 = this.MdiParent as MDIParent1;
                frm1.progressBar1.Value = 0;

                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.DataSource = null;
                gvImportacao2.DataSource = null;

                MDIParent1 frm = this.MdiParent as MDIParent1;
                frm.progressBar1.Maximum = 2;
                frm.progressBar1.PerformStep();                                                                                                                     //

                gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL_REPLAT());

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t2 = tabControl1.TabPages[1];
                tabControl1.SelectedTab = t2;

                frm.progressBar1.PerformStep();

                gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_SISEPC());

                for (int o = 0; o < gvImportacao2.Rows.Count; o++)
                {
                    for (int j = 0; j < gvImportacao2.Columns.Count; j++)
                    {
                        if (gvImportacao2[j, o].Value.ToString().IndexOf("-> ") > -1)
                        {
                            gvImportacao2[j, o].Value = gvImportacao2[j, o].Value.ToString().Replace("-> ", "");
                            gvImportacao2[j, o].Style.BackColor = Color.Yellow;
                            gvImportacao2[j, o].Style.ForeColor = Color.Red;
                        }
                    }
                }

                //Não deixar ordenar na coluna
                foreach (DataGridViewColumn coluna in gvImportacao2.Columns)
                    coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t1 = tabControl1.TabPages[0];
                tabControl1.SelectedTab = t1;

                frm.progressBar1.PerformStep();                                                                                                                     //
                frm.progressBar1.Value = 0;                                                                                                                         //--

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MDIParent1 frm1 = this.MdiParent as MDIParent1;
                frm1.progressBar1.Value = 0;

                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvImportacao_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();
            var rowFont = new System.Drawing.Font("Arial", 8, FontStyle.Bold, System.Drawing.GraphicsUnit.Point);

            var centerFormat = new StringFormat()
            {
                // alinhamento à direita pode realmente fazer mais sentido para os números
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            //obter o tamanho da string
            Size textSize = TextRenderer.MeasureText(rowIdx, this.Font);

            //se cabeçalho largura menor do que a largura string, então redimensioná
            if (grid.RowHeadersWidth < textSize.Width + 25)
            {
                grid.RowHeadersWidth = textSize.Width + 25;
            }

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, /*this.Font*/rowFont, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void btQuery_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery();

            frm.strQuery = @"SELECT O.NOME ORGANIZACAO,
P.PART_NUMBER PART_NUMBER_ITEM,
I.QTDE,
S.NCM,
N.NF,
N.SERIE,
I.NUM_ITEM,
I.DESCRICAO,
TO_CHAR(N.DATA_EMISSAO,'YYYYMMDD') DATA_NF, 
I.CF_OP CFOP,
I.VALOR_UN,
I.REF_SAIDA,
S.REF_NFS,
I.MACRO_PRODUTO,
NULL COD_CONSIGNATARIO,
PAR.COD_PARCEIRO COD_CLIENTE,
S.REF_NFE,
I.PROCEDENCIA_INFO,
TO_CHAR(I.DATA_GER_LEG, 'YYYYMMDD') DATA_GER_LEG,
I.ID_CORPORATIVO,
NULL SENF,
NULL ENQUADRAMENTO,
TO_CHAR(N.DATA_SAIDA, 'YYYYMMDD') DATA_SAIDA,
I.SEGMENTO1,
I.SEGMENTO2,
I.SEGMENTO3,
I.SEGMENTO4,
I.SEGMENTO5,
I.REF_BAIXA,
I.S_FINALIDADE_SAIDA FINALIDADE_SAIDA,
NULL NUM_CONTRATO
FROM NF_SAIDA N, ITENS_NF_SAIDA I, SUBITENS_NF_SAIDA S, SFW_PRODUTO P, SFW_ORGANIZACAO O, SFW_PARCEIRO PAR
WHERE N.ID_NF_SAIDA = I.ID_NF_SAIDA
AND I.ID_ITEM_NF_SAIDA = S.ID_ITEM_NF_SAIDA
AND I.ID_PRODUTO = P.ID_PRODUTO
AND P.ID_ORGANIZACAO = O.ID_ORGANIZACAO
AND N.ID_CLIENTE = PAR.ID_PARCEIRO
AND I.CANCELA = 'N'";

            frm.ShowDialog();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao2.DataSource = null;
                gvImportacao.DataSource = null;
                gvImportacao2.DefaultCellStyle.ForeColor = Color.Black;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivos do Excel | *.xlsx";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    string strTbl = "RF_NF_SAIDA_BAT";
                    RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE " + strTbl);

                    FileInfo file = new FileInfo(openFileDialog1.FileName);

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                        StringBuilder Cols = new StringBuilder();

                        bool booColProximos = false;
                        int qtdCol = workSheet.Dimension.End.Column;
                        int qtdLinhas = workSheet.Dimension.End.Row;
                        var titulos = workSheet.Cells[1, 1, 1, qtdCol];

                        foreach (var firstRowCell in titulos)
                        {
                            if (booColProximos) Cols.Append(", ");
                            Cols.Append(firstRowCell.Text);

                            booColProximos = true;
                        }

                        MDIParent1 frm = this.MdiParent as MDIParent1;
                        frm.progressBar1.Maximum = qtdLinhas;
                        frm.progressBar1.PerformStep();

                        for (var i = 2; i <= qtdLinhas; i++)
                        {
                            frm.progressBar1.PerformStep();                                                                                                                     //

                            StringBuilder Rows = new StringBuilder();
                            bool booRowProximos = false;
                            var row = workSheet.Cells[i, 1, i, qtdCol];

                            for (int c = 1; c <= qtdCol; c++)
                            {
                                if (booRowProximos) Rows.Append(", ");
                                booRowProximos = true;

                                if (row[i, c].Value == null)
                                    Rows.Append("''");
                                else
                                    Rows.Append("'" + row[i, c].Value + "'");
                            }

                            RfNfEntradaBLL.ExecuteSQLInstruction("INSERT INTO " + strTbl + " (" + Cols + ") VALUES (" + Rows + ")");
                        }

                        frm.progressBar1.Value = 0;
                    }

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MDIParent1 frm1 = this.MdiParent as MDIParent1;
                frm1.progressBar1.Value = 0;

                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
