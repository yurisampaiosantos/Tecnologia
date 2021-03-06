using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GridCarregamento.DAL;
using Excel = Microsoft.Office.Interop.Excel;

namespace wfFolhaApropriacao
{
    public partial class frmRelMovimentacao : Form
    {
        public frmRelMovimentacao()
        {
            InitializeComponent();
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                DateTime dt1 = Convert.ToDateTime(dtData.Value);

                TabelaDAL tabelaNeg = new TabelaDAL();
                DataTable dtConsulta = new DataTable();

                dtConsulta = tabelaNeg.ListarMovimentacaoDiaria(dt1);

                dgvConsulta.DataSource = dtConsulta;

                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                DateTime dt1 = Convert.ToDateTime(dtData.Value);

                TabelaDAL tabelaNeg = new TabelaDAL();
                DataTable dtConsulta = new DataTable();

                object misValue = System.Reflection.Missing.Value;

                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                dtConsulta = tabelaNeg.ListarMovimentacaoDiaria(dt1);

                //Cabeçalho
                for (int i = 1; i <= dtConsulta.Columns.Count; i++)
                {
                    WorkSheet.Cells[3, i] = dtConsulta.Columns[i - 1].ColumnName;
                }

                //seleção das linhas
                for (int o = 0; o < dtConsulta.Rows.Count; o++)
                {
                    //Preenchimendo das celulas
                    for (int j = 0; j < dtConsulta.Columns.Count; j++)
                    {
                        WorkSheet.Cells[o + 4, j + 1] = dtConsulta.Rows[o][j].ToString();
                    }
                }

                App.Columns.AutoFit();

                WorkSheet.Cells[1, 1] = "Relatório de Movimentação Diária: " + dt1.ToString("dd/MM/yy");                                 //WorkSheet.Range["B1"].Value = "Colaboradores";

                App.Visible = true;

                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmRelMovimentacao_Load(object sender, EventArgs e)
        {
            dtData.Value = DateTime.Now.Date;
        }
    }
}
