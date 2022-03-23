using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;
using DTO;
using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Replat
{
    public partial class frmProdutosDetalhes : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmProdutosDetalhes()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
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

        private int NumCol(string strCol)
        {
            int colSeq = -1;

            for (int u = 0; u < gvImportacao.Columns.Count; u++)
            {
                if (gvImportacao.Columns[u].Name == strCol) colSeq = u;
            }

            return colSeq;
        }

        public string CarregaSQL()
        {
            return @"SELECT
                        ROW_NUMBER() OVER (PARTITION BY ORDEM ORDER BY DATA_MOV NULLS LAST, ORIGEM) SEQ, DIPR_ID, DIPR_COD, DIPR_DIMENSOES, DESCRICAO_PRODUTO, REFERENCIA, ORGANIZACAO, ORIGEM, QTDE, '' SALDO, DATA_MOV
                    FROM 
                        V_MINI_FIFO
                    ORDER BY
                        DIPR_ID, ORGANIZACAO, DATA_MOV, TO_NUMBER(REPLACE(SUBSTR(ORIGEM, 1, 2), '-', '')), SEQ";
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.DataSource = RfNfEntradaBLL.Select(CarregaSQL());

                int colDiprId = NumCol("DIPR_ID");
                int colDiprCod = NumCol("DIPR_COD");
                int colOrg = NumCol("ORGANIZACAO");
                int colOrigem = NumCol("ORIGEM");
                int colQtde = NumCol("QTDE");
                int colSaldo = NumCol("SALDO");

                decimal decSaldo = 0;
                for (int i = 0; i < gvImportacao.Rows.Count; i++) //Detalhe do Produto
                {
                    bool erro = false;
                    decimal decDiprID = Convert.ToDecimal(gvImportacao[colDiprId, i].Value);

                    string strDiprCod = gvImportacao[colDiprCod, i].Value.ToString();

                    string decOrg = gvImportacao[colOrg, i].Value.ToString();

                    string strOrigem = gvImportacao[colOrigem, i].Value.ToString();
                    string[] strOrigemMov = strOrigem.Split('-');

                    decimal decQtde = Convert.ToDecimal(gvImportacao[colQtde, i].Value);

                    if (i > 0)
                    {
                        decimal decDiprIDAnterior = Convert.ToDecimal(gvImportacao[colDiprId, i - 1].Value);
                        string decOrgAnterior = gvImportacao[colOrg, i - 1].Value.ToString();

                        if (decDiprID + decOrg != decDiprIDAnterior + decOrgAnterior) decSaldo = 0;
                    }

                    if (strOrigem == "1-NFE" || strOrigem == "3-FAB" || strOrigem == "4-SUC" || strOrigem == "6-TRF-e")
                    {
                        decSaldo += decQtde;
                    }
                    else if (strOrigem == "2-NEM")
                    {
                        if (i - 1 < 0)
                        {
                            erro = true;
                        }
                        else
                        {
                            if (gvImportacao[colOrigem, i - 1].Value.ToString() != "1-NFE") erro = true;
                        }

                        if (erro) decSaldo += decQtde;
                    }
                    else if (strOrigem == "7-TRF-s" || strOrigem == "10-APL" || strOrigem == "11-NFS")
                    {
                        decSaldo = decSaldo + (decQtde * (-1));
                    }
                    else if (strOrigem == "12-BAX")
                    {
                        if (i - 1 < 0)
                        {
                            erro = true;
                        }
                        else
                        {
                            if (gvImportacao[colOrigem, i - 1].Value.ToString() != "11-NFS") erro = true;
                        }

                        if (erro) decSaldo = decSaldo + (decQtde * (-1));
                    }

                    gvImportacao[colSaldo, i].Value = decSaldo;
                }

                lblRegistros.Text = "Registros: " + gvImportacao.Rows.Count;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Exportar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string folderPath = "C:\\temp\\" + this.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.Name);                         //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                        ws.View.FreezePanes(2, 1);
                        //ws.Cells.AutoFitColumns();
                        //ws.Cells["A1"].Value = this.Text;

                        using (ExcelRange rng = ws.Cells[1, 1, 1, gvImportacao.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        pck.Save();

                        Process.Start(folderPath);
                    }
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
