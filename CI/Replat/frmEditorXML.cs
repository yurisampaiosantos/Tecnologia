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

using Excel = Microsoft.Office.Interop.Excel;

namespace Replat
{
    public partial class frmEditorXML : Form
    {
        public frmEditorXML()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btMascara_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\RePLAT.Net\\Mascaras\\MasEditorXML.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                App.Visible = true;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXLS_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                txtXLS.Text = "";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivos do Excel | *.xlsx";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtXLS.Text = openFileDialog1.FileName;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btXML_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                txtXML.Text = "";

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivo XML | *.xml";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtXML.Text = openFileDialog1.FileName;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string linha;
                string novoArquivoXML;

                int loop = 0;
                
                string arquivoXML = txtXML.Text;
                string arquivoXLS = txtXLS.Text;
                
                lblAlertas.Text = "";
                
                gvImportacao.Rows.Clear();
                gvImportacao.DefaultCellStyle.ForeColor = Color.Black;
                gvImportacao.DefaultCellStyle.BackColor = Color.White;
                
                if (!File.Exists(arquivoXML) || !File.Exists(arquivoXLS))
                {
                    MessageBox.Show("Os Arquivos 'XML' e 'XLS' são Obrigatórios", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Open(arquivoXLS, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    WorkSheet.Cells[1, 100].Formula = "=COUNTA(C[-99])";

                    int qtdLinhas = Convert.ToInt32(WorkSheet.Cells[1, 100].Value) + 1;

                    string strNNota = "";
                    string strOrg = "";
                    decimal decTxDolar = 0;

                    if (Convert.ToString(WorkSheet.Cells[2, 1].Value) != null) strNNota = Convert.ToString(WorkSheet.Cells[2, 1].Value).Trim();
                    if (Convert.ToString(WorkSheet.Cells[2, 2].Value) != null) strOrg = Convert.ToString(WorkSheet.Cells[2, 2].Value).Trim();
                    if (Convert.ToString(WorkSheet.Cells[2, 3].Value) != null) decTxDolar = Convert.ToDecimal(WorkSheet.Cells[2, 3].Value);

                    novoArquivoXML = arquivoXML.Replace(".xml", " - " + "NF " + strNNota + ".xml");
                    File.Copy(arquivoXML, novoArquivoXML, true);

                    int numeroLinhas = File.ReadAllLines(novoArquivoXML).Length + 1;

                    int linhaAtual = 1;
                    string[] dadoLinha = new string[numeroLinhas];

                    //Salva em string array os dados do arquivo original em XML
                    using (StreamReader ler = new StreamReader(novoArquivoXML))
                    {
                        while ((linha = ler.ReadLine()) != null)
                        {
                            dadoLinha[linhaAtual] = linha;
                            linhaAtual += 1;
                        }
                    }

                    //Inicia leitura linha a linha dos dados do Excel
                    for (int i = 5; i <= qtdLinhas; i++)
                    {
                        int encontrados = 0;
                        int contador = 1;
                        string strCodSAP = "";
                        string strCodSisEPC = "";
                        string strQtde = "";
                        decimal decOrigUnd = 0;
                        decimal decExcelUnd = 0;
                        string binQtde = "";
                        bool achado = false;
                        string aviso = "Código SAP não Encontrado no Arquivo XML";

                        if (Convert.ToString(WorkSheet.Cells[i, 1].Value) != null) strCodSAP = Convert.ToString(WorkSheet.Cells[i, 1].Value).Trim();                    //Cod SAP
                        if (Convert.ToString(WorkSheet.Cells[i, 2].Value) != null) strCodSisEPC = Convert.ToString(WorkSheet.Cells[i, 2].Value).Trim();                 //Cod sisEPC

                        if (Convert.ToString(WorkSheet.Cells[i, 3].Value) != null)
                        {
                            strQtde = Convert.ToString(WorkSheet.Cells[i, 3].Value).Trim();

                            string[] separa = strQtde.Split(',');
                            binQtde = separa[0].PadLeft(9, '0') + ((separa.Length > 1) ? separa[1].PadRight(5, '0') : "00000");                                         //Qtde Excel
                        }

                        if (Convert.ToString(WorkSheet.Cells[i, 4].Value) != null)
                        {
                            decOrigUnd = Math.Round(Convert.ToDecimal(WorkSheet.Cells[i, 4].Value) / decTxDolar, 2);
                            decExcelUnd = Math.Round(Convert.ToDecimal(WorkSheet.Cells[i, 4].Value) / decTxDolar, 0);                                                   //VUnd Excel
                        }

                        string padrao1 = "ORG(" + strOrg + ");PN(" + strCodSAP + ");";
                        string padrao2 = "ORG();PN(" + strCodSAP + ");";
                        string padrao3 = "ORG(" + strOrg + ");CSAP(" + strCodSAP + ");";
                        string padrao4 = "ORG();CSAP(" + strCodSAP + ");";
                        string padrao5 = "(ORG)" + strOrg + ";(PN)" + strCodSAP + ";";
                        string padrao6 = "PN(" + strCodSAP + ");";
                        string padrao7 = "(PN)" + strCodSAP + ";";

                        string foraPadrao = strCodSAP;

                        string alterado = "ORG(" + strOrg + ");PN(" + strCodSisEPC + ");";

                        StringBuilder arquivo = new StringBuilder();

                        //if (i == 21) 
                        //{

                        //}

                        //Inicia leitura linha a linha do arquivo XML
                        using (StreamReader ler = new StreamReader(novoArquivoXML))
                        {
                            while ((linha = ler.ReadLine()) != null)
                            {
                                string qtde = "";
                                string vUnd = "";
                                decimal decXmlUnd = 0;

                                linha = linha.Replace("          ", "");

                                if (contador + 4 < numeroLinhas)
                                {
                                    qtde = dadoLinha[contador + 2];
                                    vUnd = dadoLinha[contador + 4];

                                    if (vUnd.IndexOf("<valorUnitario>") > -1)
                                    {
                                        vUnd = vUnd.Replace("<valorUnitario>", "");
                                        vUnd = vUnd.Replace("</valorUnitario>", "");
                                        vUnd = vUnd.Replace(" ", "");

                                        decXmlUnd = Math.Round(Convert.ToDecimal(vUnd.Substring(0, 13) + "," + vUnd.Substring(13, 7)), 0);                              //VUnd XML
                                    }
                                }

                                //if (contador == 92 || contador == 106 || contador == 127)
                                //{

                                //}

                                if (!achado)
                                {
                                    if (dadoLinha[contador].IndexOf(foraPadrao) > -1 && linha.IndexOf(foraPadrao) == -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        aviso = "Código Encontrado mas já Substituido Anteriormente";
                                    }
                                    else if (linha.IndexOf(padrao1) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao1, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao2) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao2, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao3) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao3, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao4) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao4, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao5) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao5, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao6) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao6, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(padrao7) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        linha = linha.Replace(padrao6, alterado);

                                        aviso = "";
                                    }
                                    else if (linha.IndexOf(foraPadrao) > -1 && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        aviso = "Código Encontrado mas fora do Padrão Definido";
                                    }

                                    if ((linha.IndexOf(foraPadrao) > -1 || linha.IndexOf(strCodSisEPC) > -1) && qtde.IndexOf(binQtde) > -1 && decXmlUnd == decExcelUnd)
                                    {
                                        gvImportacao.Rows.Add(strCodSAP, strCodSisEPC, strQtde, "R$ " + decOrigUnd.ToString("####0.00"), contador, aviso);

                                        encontrados += 1;
                                        achado = true;

                                        if (aviso != "")
                                        {
                                            gvImportacao.Rows[gvImportacao.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                                            gvImportacao.Rows[gvImportacao.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;

                                            loop += 1;
                                        }
                                    }
                                }

                                arquivo.AppendLine(linha);

                                contador++;
                            } //while
                        }

                        if (encontrados == 0)
                        {
                            gvImportacao.Rows.Add(strCodSAP, strCodSisEPC, strQtde, "R$ " + decOrigUnd.ToString("####0.00"), 0, aviso);
                            gvImportacao.Rows[gvImportacao.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Red;
                            gvImportacao.Rows[gvImportacao.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.White;

                            loop += 1;
                        }

                        using (StreamWriter escrever = new StreamWriter(novoArquivoXML, false, Encoding.UTF8))
                        {
                            escrever.Write(arquivo.ToString());
                        }
                    } //for

                    WorkBook.Close(false, Type.Missing, Type.Missing);
                    App.Quit();

                    if (loop > 0)
                    {
                        lblAlertas.Text = "Existe" + ((loop > 1) ? "m " : " ") + loop + " alerta" + ((loop > 1) ? "s" : "") + " para verificação";
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
