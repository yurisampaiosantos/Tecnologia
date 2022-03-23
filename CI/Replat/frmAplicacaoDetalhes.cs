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
    public partial class frmAplicacaoDetalhes : Form
    {
        string[] CodProd_SubContrato;
        string strSQL;

        public frmAplicacaoDetalhes()
        {
            InitializeComponent();
        }

        private void frmAplicacaoDetalhes_Load(object sender, EventArgs e)
        {
            try
            {
                CodProd_SubContrato = RfNfEntradaBLL.strScript.Split('-');

                strSQL = @"SELECT 
                                FOSE_NUMERO,
                                DATA_FILTRO DATA_AVANCO,
                                QTDE,
                                COD_LOCATION,
                                REDI_NUMERO RESERVA
                            FROM 
                                V_APLICACAO_GERAL
                            WHERE
                                    DIPR_ID = " + CodProd_SubContrato[0] + @"
                                AND ORGANIZACAO = '" + CodProd_SubContrato[1] + @"'
                                AND DATA_FILTRO " + ((RfNfEntradaBLL.strDataFiltro == "") ? "IS NULL" : "= TO_DATE('" + RfNfEntradaBLL.strDataFiltro + "', 'DD/MM/YYYY')") + @"
                            ORDER BY
                                FOSE_NUMERO";

                gvImportacao.DataSource = RfNfEntradaBLL.Select(strSQL);

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
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

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
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
