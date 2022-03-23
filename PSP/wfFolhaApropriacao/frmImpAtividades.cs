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
    public partial class frmImpAtividades : Form
    {
        public frmImpAtividades()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btMascara_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\Apropriacao_MOD\\Entrada_de_Dados\\Mascaras\\MasNovos.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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

        private void btPreparar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";

                int loop = 0;
                int avisos = 0;

                lbAtualizacao.Text = "";
                lbObs.Text = "";
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
                        string strMatricula = "";
                        string strNome = "";
                        string strFuncao = "";
                        string strDtAdmissao = "";
                        string strTipoMO = "";

                        if (Convert.ToString(WorkSheet.Cells[i, 1].Value) != null) strMatricula = Convert.ToString(WorkSheet.Cells[i, 1].Value).Trim();
                        if (Convert.ToString(WorkSheet.Cells[i, 2].Value) != null) strNome = Convert.ToString(WorkSheet.Cells[i, 2].Value).Trim();
                        if (Convert.ToString(WorkSheet.Cells[i, 3].Value) != null) strFuncao = Convert.ToString(WorkSheet.Cells[i, 3].Value).Trim();
                        
                        try 
                        {
                            if (WorkSheet.Cells[i, 4].Value.GetType() == typeof(DateTime)) strDtAdmissao = Convert.ToString(WorkSheet.Cells[i, 4].Value).Substring(0, 10).Trim();
                        } 
                        catch (Exception ex) 
                        {
                            strDtAdmissao = "";
                        }

                        if (Convert.ToString(WorkSheet.Cells[i, 5].Value) != null) strTipoMO = Convert.ToString(WorkSheet.Cells[i, 5].Value).Trim();

                        DataTable dtConsulta = new DataTable();

                        if (tabelaNeg.ConsultaMatricula(strMatricula) == 1)
                        {
                            gvImportacao.Rows.Add(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO, "O Colaborador será atualizado");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Yellow;

                            avisos = avisos + 1;
                        }
                        else if (strDtAdmissao == "")
                        {
                            gvImportacao.Rows.Add(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO, "Data da Admissão Incorreta");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                            loop = loop + 1;
                        }
                        else if (strNome == "" || strFuncao == "" || strTipoMO == "")
                        {
                            gvImportacao.Rows.Add(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO, "Todos os Campos são Obrigatórios");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                            loop = loop + 1;
                        }
                        else
                        {
                            if (!tabelaNeg.EnviaNovos(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO))
                            {
                                gvImportacao.Rows.Add(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO, "Erro na integridade do banco");
                                gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                                gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                                loop = loop + 1;
                            }
                            else
                            {
                                gvImportacao.Rows.Add(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO, "");
                            }
                        }
                    }

                    if (loop > 0)
                    {
                        lbObs.Text = "Existe" + ((loop > 1) ? "m " : " ") + loop + " alerta" + ((loop > 1) ? "s" : "") + " para verificação";
                    }
                    else
                    {
                        lbObs.Text = "";
                    }

                    if (avisos > 0)
                    {
                        lbAtualizacao.Text = avisos + " Colaborador" + ((avisos > 1) ? "es" : "") + " ser" + ((avisos > 1) ? "ão" : "á") + " atualizado" + ((avisos > 1) ? "s" : "");
                    }
                    else
                    {
                        lbAtualizacao.Text = "";
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

                if (lbObs.Text != "")
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
                            string strMatricula = gvImportacao.Rows[i].Cells[0].Value.ToString();
                            string strNome = gvImportacao.Rows[i].Cells[1].Value.ToString();
                            string strFuncao = gvImportacao.Rows[i].Cells[2].Value.ToString();
                            string strDtAdmissao = gvImportacao.Rows[i].Cells[3].Value.ToString();
                            string strTipoMO = gvImportacao.Rows[i].Cells[4].Value.ToString();

                            if (tabelaNeg.ConsultaMatricula(strMatricula) != 1)
                            {
                                if (tabelaNeg.InsereNovos(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO))
                                {
                                    gvImportacao.Rows[i].Cells[5].Value = "Colaborador importado com sucesso";
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
                                if (tabelaNeg.AtualizaColaborador(strMatricula, strNome, strFuncao, strDtAdmissao, strTipoMO))
                                {
                                    gvImportacao.Rows[i].Cells[5].Value = "Colaborador atualizado com sucesso";
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
                        }

                        if (loop > 0)
                        {
                            lbObs.Text = "Existe" + ((loop > 1) ? "m " : " ") + loop + " Funcionário" + ((loop > 1) ? "s" : "") + " que não fo" + ((loop > 1) ? "ram" : "i") + " importado" + ((loop > 1) ? "s" : "");
                            MessageBox.Show(lbObs.Text, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lbAtualizacao.Text = "";
                            lbObs.Text = "";
                            MessageBox.Show("Todos os Funcionários Importados com sucesso", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
