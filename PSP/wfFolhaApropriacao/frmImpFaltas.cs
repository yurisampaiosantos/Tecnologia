using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.DataAccess.Client;
using GridCarregamento.DAL;
using Excel = Microsoft.Office.Interop.Excel;

namespace wfFolhaApropriacao
{
    public partial class frmImpFaltas : Form
    {
        public frmImpFaltas()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btPreparar_Click(object sender, EventArgs e)
        {
            int loop = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                lbObs.Visible = false;
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

                    TabelaDAL tabelaNeg = new TabelaDAL();
                    
                    for (int i = 2; i <= qtdLinhas; i++)
                    {
                        string strDataFalta = "";
                        string strMatricula = "";

                        if (WorkSheet.Cells[i, 1].Value.GetType() == typeof(DateTime)) strDataFalta = Convert.ToString(WorkSheet.Cells[i, 1].Value).Substring(0, 10);
                        if (Convert.ToString(WorkSheet.Cells[i, 2].Value) != null) strMatricula = Convert.ToString(WorkSheet.Cells[i, 2].Value);

                        DataTable dtConsulta = new DataTable();
                        dtConsulta = tabelaNeg.PreparaMascaraFaltas(strDataFalta, strMatricula);

                        if (dtConsulta.Rows.Count == 0) 
                        {
                            gvImportacao.Rows.Add(strDataFalta, strMatricula, "", "", "", "Matrícula não encontrada");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                            loop = loop + 1;
                        }
                        else if (strDataFalta == "")
                        {
                            gvImportacao.Rows.Add(Convert.ToString(WorkSheet.Cells[i, 1].Value), strMatricula, "", "", "", "Data da Falta Incorreta");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                            loop = loop + 1;
                        }
                        else
                        {
                            if (!tabelaNeg.ConsultaFalta(strDataFalta, strMatricula))
                            {
                                gvImportacao.Rows.Add(strDataFalta, strMatricula, dtConsulta.Rows[0][0].ToString(), dtConsulta.Rows[0][1].ToString(), dtConsulta.Rows[0][2].ToString(), "");
                            }
                            else
                            {
                                gvImportacao.Rows.Add(strDataFalta, strMatricula, dtConsulta.Rows[0][0].ToString(), dtConsulta.Rows[0][1].ToString(), dtConsulta.Rows[0][2].ToString(), "Falta já importada anteriormente");
                                gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Yellow;

                                loop = loop + 1;
                            }
                        }
                    }

                    if (loop > 0)
                    {
                        lbObs.Text = "Obs.: Existe" + ((loop > 1) ? "m " : " ") + loop + " alerta" + ((loop > 1) ? "s" : "") + " para verificação";
                        lbObs.Visible = true;
                    }
                    else
                    {
                        lbObs.Visible = false;
                    }

                    WorkBook.Close(false, Type.Missing, Type.Missing);
                    App.Quit();
                }

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

        private void btImportar_Click(object sender, EventArgs e)
        {
            int loop = 0;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";


                if (lbObs.Visible == true)
                {
                    MessageBox.Show(lbObs.Text, "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (gvImportacao.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Importação", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Deseja realmente continuar com a Importação?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        TabelaDAL tabelaNeg = new TabelaDAL();

                        for (int i = 0; i < gvImportacao.Rows.Count; i++)
                        {
                            string strDataFalta = gvImportacao.Rows[i].Cells[0].Value.ToString();
                            string strMatricula = gvImportacao.Rows[i].Cells[1].Value.ToString();
                            string strDisciplina = gvImportacao.Rows[i].Cells[2].Value.ToString();
                            string strSubContrato = gvImportacao.Rows[i].Cells[3].Value.ToString();
                            string strSemana = gvImportacao.Rows[i].Cells[4].Value.ToString();

                            if (!tabelaNeg.ConsultaFalta(strDataFalta, strMatricula))
                            {
                                if (tabelaNeg.InsereFalta(strDataFalta, strMatricula, strDisciplina, strSubContrato, strSemana))
                                {
                                    gvImportacao.Rows[i].Cells[5].Value = "Status importado com sucesso";
                                    gvImportacao.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                                    gvImportacao.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                                }
                                else
                                {
                                    gvImportacao.Rows[i].Cells[5].Value = "Erro na integridade do banco";
                                    gvImportacao.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                                    gvImportacao.Rows[i].DefaultCellStyle.ForeColor = Color.White;

                                    loop = loop + 1;
                                }
                            }
                            else
                            {
                                gvImportacao.Rows[i].Cells[5].Value = "Falta já importada anteriormente";
                                gvImportacao.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                                loop = loop + 1;
                            }
                        }

                        if (loop > 0)
                        {
                            lbObs.Text = "Obs.: Existe" + ((loop > 1) ? "m " : " ") + loop + " falta" + ((loop > 1) ? "s" : "") + " que não fo" + ((loop > 1) ? "ram" : "i") + " importada" + ((loop > 1) ? "s" : "");
                            lbObs.Visible = true;
                            MessageBox.Show(lbObs.Text, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lbObs.Visible = false;
                            MessageBox.Show("Todos os Status Importados com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

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

        private void btMascara_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";


                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\Apropriacao_MOD\\Entrada_de_Dados\\Mascaras\\MasFaltas.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

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
    }
}
