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
    public partial class frmImpStatus : Form
    {
        public frmImpStatus()
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
                        string strMatricula = "";
                        string strInicioAfastado = "";
                        string strInicioFerias = "";
                        string strFimFerias = "";
                        string strDataDemissao = "";

                        if (Convert.ToString(WorkSheet.Cells[i, 1].Value) != null) strMatricula = Convert.ToString(WorkSheet.Cells[i, 1].Value);
                        if (Convert.ToString(WorkSheet.Cells[i, 2].Value) != null) strInicioAfastado = Convert.ToString(WorkSheet.Cells[i, 2].Value).Substring(0, 10);
                        if (Convert.ToString(WorkSheet.Cells[i, 3].Value) != null) strInicioFerias = Convert.ToString(WorkSheet.Cells[i, 3].Value).Substring(0, 10);
                        if (Convert.ToString(WorkSheet.Cells[i, 4].Value) != null) strFimFerias = Convert.ToString(WorkSheet.Cells[i, 4].Value).Substring(0, 10);
                        if (Convert.ToString(WorkSheet.Cells[i, 5].Value) != null) strDataDemissao = Convert.ToString(WorkSheet.Cells[i, 5].Value).Substring(0, 10);
                                                
                        string strStatus = (strInicioAfastado != "") ? "A" : (strInicioFerias != "") ? "F": (strDataDemissao != "") ? "D": "";
                        
                        if (tabelaNeg.ConsultaMatricula(strMatricula) == 1)
                        {
                            int intA = (strInicioAfastado != "") ? 1 : 0;
                            int intF = (strInicioFerias != "") ? 1 : 0;
                            int intD = (strDataDemissao != "") ? 1 : 0;

                            if (intA + intF + intD > 1)
                            {
                                strStatus = "-";
                                gvImportacao.Rows.Add(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao, "Status não definido corretamente");
                                gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                                gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                                loop = loop + 1;
                            }
                            else if ((strInicioFerias != "" && strFimFerias == "") || (strInicioFerias == "" && strFimFerias != ""))
                            {
                                gvImportacao.Rows.Add(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao, "Férias não informada corretamente");
                                gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                                gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                                loop = loop + 1;
                            }
                            else 
                            {
                                if (!tabelaNeg.EnviaStatus(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao))
                                {
                                    gvImportacao.Rows.Add(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao, "Erro na integridade do banco");
                                    gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                                    gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                                    loop = loop + 1;
                                }
                                else
                                {
                                    gvImportacao.Rows.Add(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao, "");
                                }
                            }
                        }
                        else
                        {
                            gvImportacao.Rows.Add(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao, "Matrícula não encontrada");
                            gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                            loop = loop + 1;
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
                            string strMatricula = gvImportacao.Rows[i].Cells[0].Value.ToString();
                            string strStatus = gvImportacao.Rows[i].Cells[1].Value.ToString();
                            string strInicioAfastado = gvImportacao.Rows[i].Cells[2].Value.ToString();
                            string strInicioFerias = gvImportacao.Rows[i].Cells[3].Value.ToString();
                            string strFimFerias = gvImportacao.Rows[i].Cells[4].Value.ToString();
                            string strDataDemissao = gvImportacao.Rows[i].Cells[5].Value.ToString();


                            if (tabelaNeg.AtualizaStatus(strMatricula, strStatus, strInicioAfastado, strInicioFerias, strFimFerias, strDataDemissao))
                            {
                                gvImportacao.Rows[i].Cells[6].Value = "Status importado com sucesso";
                                gvImportacao.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                                gvImportacao.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                            }
                            else
                            {
                                gvImportacao.Rows[i].Cells[6].Value = "Erro na integridade do banco";
                                gvImportacao.Rows[i - 2].DefaultCellStyle.BackColor = Color.Red;
                                gvImportacao.Rows[i - 2].DefaultCellStyle.ForeColor = Color.White;

                                loop = loop + 1;
                            }
                        }

                        if (loop > 0)
                        {
                            lbObs.Text = "Obs.: Existe" + ((loop > 1) ? "m " : " ") + loop + " Status" + ((loop > 1) ? "s" : "") + " que não fo" + ((loop > 1) ? "i " : "ram ") + " importado" + ((loop > 1) ? "s " : "");
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
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\Apropriacao_MOD\\Entrada_de_Dados\\Mascaras\\MasStatus.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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

        private void frmImpStatus_Load(object sender, EventArgs e)
        {

        }
    }
}
