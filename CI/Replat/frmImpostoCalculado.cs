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

using Excel = Microsoft.Office.Interop.Excel;

namespace Replat
{
    public partial class frmImpostoCalculado : Form
    {
        public frmImpostoCalculado()
        {
            InitializeComponent();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.Rows.Clear();

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivos do Excel | *.xlsx";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    WorkSheet.Cells[1, 100].Formula = "=COUNTA(C[-99])";

                    int qtdLinhas = Convert.ToInt32(WorkSheet.Cells[1, 100].Value);

                    for (int i = 2; i <= qtdLinhas; i++)
                    {
                        string strChave = "";

                        if (Convert.ToString(WorkSheet.Cells[i, 1].Value) != null) strChave = Convert.ToString(WorkSheet.Cells[i, 1].Value);

                        gvImportacao.Rows.Add(strChave);
                    }

                    WorkBook.Close(false, Type.Missing, Type.Missing);
                    App.Quit();
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Importação", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string strSQL = @"TRUNCATE TABLE EREPLAT.RC_CONTROLE_IMPOSTO";
                    RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                    for (int i = 0; i < gvImportacao.Rows.Count; i++)
                    {
                        string strChave = Convert.ToString(gvImportacao.Rows[i].Cells[0].Value);

                        RfNfEntradaBLL.SalvaChaves(strChave);
                    }

                    strSQL = @"INSERT INTO RF_IMPOSTO_CALC
                                    (ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA_CONTABIL, DATA_EMISSAO, INFO_COMPLEMENTARES, NF, NUM_ITEM, ORGANIZACAO, REF_ERP_ENT, SERIE, SIGLA_IMPOSTO, TIPO_NF, VALOR, DATA_GER_LEG)
                                SELECT
                                    ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA_CONTABIL, DATA_EMISSAO, INFO_COMPLEMENTARES, NF, NUM_ITEM, ORGANIZACAO, REF_ERP_ENT, SERIE, SIGLA_IMPOSTO, TIPO_NF, VALOR, DATA_GER_LEG
                                FROM 
                                    V_IMPOSTO_REPLAT";

                    RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                    gvImportacao.Rows.Clear();
                    MessageBox.Show("Lote de Imposto Calculado Disponível no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
