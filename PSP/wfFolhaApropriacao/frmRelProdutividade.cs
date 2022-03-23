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
    public partial class frmRelProdutividade : Form
    {
        public frmRelProdutividade()
        {
            InitializeComponent();
        }

        private void frmRelMovimentacao_Load(object sender, EventArgs e)
        {
            int AnoAtual = Convert.ToInt32(DateTime.Now.Date.ToString("yyyy"));

            for (int x = AnoAtual; x >= AnoAtual - 3; x--)
            {
                cmbAno.Items.Add(x);
            }

            cmbMes.SelectedIndex = DateTime.Now.Month - 1;
            cmbAno.SelectedIndex = 0;
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                TabelaDAL tabelaNeg = new TabelaDAL();
                DataTable dtbSemanas = new DataTable();
                DataTable dtConsulta = new DataTable();

                dtbSemanas = tabelaNeg.ListarSemanas(cmbMes.SelectedIndex + 1, Convert.ToInt32(cmbAno.Text));
                dtConsulta = tabelaNeg.ListarProdutividade(dtbSemanas);

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

                TabelaDAL tabelaNeg = new TabelaDAL();

                object misValue = System.Reflection.Missing.Value;


                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\Apropriacao_MOD\\Entrada_de_Dados\\Mascaras\\MasProdutividade.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                DataTable dtbSemanas = new DataTable();
                DataTable dtbConsulta = new DataTable();

                dtbSemanas = tabelaNeg.ListarSemanas(cmbMes.SelectedIndex + 1, Convert.ToInt32(cmbAno.Text));
                dtbConsulta = tabelaNeg.ListarProdutividade(dtbSemanas);

                //Tira 5ª semana caso só tenha 4 no mês escolhido
                if (dtbSemanas.Rows.Count == 4) WorkBook.Sheets[1].Columns("AD:AH").Delete();

                WorkSheet.Cells[2, 1] = cmbMes.Text + "/" + cmbAno.Text;

                //seleção das semanas
                int tit = 10;
                for (int i = 0; i < dtbSemanas.Rows.Count; i++)
                {
                    WorkSheet.Cells[2, tit] = "Semana " + dtbSemanas.Rows[i][0];
                    tit += 5;
                }

                //seleção das linhas
                for (int o = 0; o < dtbConsulta.Rows.Count; o++)
                {
                    //Preenchimento das celulas
                    for (int j = 0; j < dtbConsulta.Columns.Count; j++)
                    {
                        WorkSheet.Cells[o + 4, j + 1] = dtbConsulta.Rows[o][j].ToString();
                    }
                }

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
    }
}
