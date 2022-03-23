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
    public partial class frmExecutadasSemAplicacao : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmExecutadasSemAplicacao()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmExecutadasSemAplicacao_Load(object sender, EventArgs e)
        {
            dtpDe.MaxDate = DateTime.Now.Date;
            dtpDe.Value = DateTime.Now.Date;
            dtpDe.Checked = false;
            dtpAte.Checked = false;
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            dtpAte.MinDate = dtpDe.Value;
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

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.DataSource = CarregaGrid();

                lblRegistros.Text = "Registros: " + gvImportacao.Rows.Count;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable CarregaGrid()
        {
            string strSQL = @"SELECT 
                                    FOSE_NUMERO, ORGANIZACAO, PART_NUMBER, QTDE, COD_LOCATION, DATA, DATA_FILTRO, NUM_ORDER, REDI_NUMERO, ADII_RESPONSAVEL, ARES_SIGLA
                                FROM 
                                    V_APLICACAO_GERAL
                                WHERE
                                        QTDE IS NULL
                                    AND DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')";

            DataTable dtConsulta2 = new DataTable();
            dtConsulta2 = RfNfEntradaBLL.Select(strSQL);

            return dtConsulta2;
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
                    DateTime dt1 = Convert.ToDateTime(dtpDe.Value);
                    DateTime dt2 = Convert.ToDateTime(dtpAte.Value);

                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = gvImportacao.Rows.Count;
                    frm.progressBar1.PerformStep();

                    object misValue = System.Reflection.Missing.Value;

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    //Cabeçalho WorkSheet
                    for (int i = 1; i <= gvImportacao.Columns.Count; i++)
                    {
                        WorkSheet.Cells[3, i] = gvImportacao.Columns[i - 1].Name;
                    }

                    //seleção das linhas
                    for (int o = 0; o < gvImportacao.Rows.Count; o++)
                    {
                        frm.progressBar1.PerformStep();

                        //Preenchimento das celulas
                        for (int j = 0; j < gvImportacao.Columns.Count; j++)
                        {
                            if (Convert.ToString(gvImportacao[j, o].Value) != null) WorkSheet.Cells[o + 4, j + 1] = gvImportacao[j, o].Value.ToString();
                        }
                    }

                    App.Columns.AutoFit();

                    WorkSheet.Cells[1, 1] = "Locations Inválidos para a Organização no Período: " + dt1.ToString("dd/MM/yy") + " a " + dt2.ToString("dd/MM/yy");
                    WorkSheet.Cells[2, 1].Select();
                    WorkSheet.Name = "Locations Inválidos";

                    frm.progressBar1.Value = 0;

                    App.Visible = true;
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
