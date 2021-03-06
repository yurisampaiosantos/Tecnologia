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
using System.IO;
using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using Excel = Microsoft.Office.Interop.Excel;

namespace Replat
{
    public partial class frmNFSporLote : Form
    {
        string quebraLinha = Environment.NewLine;
        const string aspas = "\"";
        public string strFiltro = "";

        public frmNFSporLote()
        {
            InitializeComponent();
        }

        public string SQL()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ID_REF, CFOP, COD_CLIENTE, COD_CONSIGNATARIO, DATA_GER_LEG, DATA_NF, DATA_SAIDA, DESCRICAO, ENQUADRAMENTO, ID_CORPORATIVO, MACRO_PRODUTO, NCM, NF, NUM_ITEM, ORGANIZACAO, PART_NUMBER_ITEM, PROCEDENCIA_INFO, QTDE, REF_BAIXA, REF_NFE, REF_NFS, REF_SAIDA, SEGMENTO2, SEGMENTO1, SEGMENTO3, SEGMENTO4, SEGMENTO5, SENF, SERIE, VALOR_UN, FINALIDADE_SAIDA, NUM_CONTRATO, '' AMBIENTE
                    FROM 
                        V_NF_SAIDA_GERAL
                    WHERE 
                        EMPR_NOME || '-' || NF || '-' || SERIE IN (" + strFiltro.Substring(2) + @")
                    ORDER BY
                        ID_IMPORTACAO";
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        roex.ID_IMPORTACAO, roex.ID_REF, roex.COD_LOCATION, roex.COD_TIPO_ORDER, roex.COEFICIENTE, roex.DATA, roex.DATA_GER_LEG, roex.NUM_DOC, roex.NUM_ORDER, roex.ORDEM, roex.ORGANIZACAO, roex.ORGANIZACAO_PN_ALTERNATIVO, roex.PART_NUMBER, roex.PN_ALTERNATIVO_REF, roex.PROCEDENCIA_INFO, roex.QTDE, roex.REFERENCIA, roex.REF_NFE, roex.REF_OPR, roex.SEGMENTO1, roex.SEGMENTO2, roex.SEGMENTO3, roex.SEGMENTO4, roex.SEGMENTO5, roex.TIPO_MOV, roex.TIPO_TRANS, roex.NUM_CONTRATO, roex.ID_IMPORTACAO AS ID_IMPORTACAO_REAL, '' AMBIENTE
                    FROM 
                        (" + SQL() + @") nftr,
                        V_NF_SAIDA_MOV_GERAL roex
                    WHERE 
                        nftr.REF_SAIDA = roex.REFERENCIA
                    ORDER BY
                        roex.ID_IMPORTACAO";
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
                Excel.Workbook WorkBook = App.Workbooks.Open("F:\\CORPORATIVO\\SISTEMAS\\RePLAT.Net\\Mascaras\\MasNFSaida.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.DataSource = null;
                gvImportacao2.DataSource = null;
                gvImportacao.DefaultCellStyle.ForeColor = Color.Black;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivos do Excel | *.xlsx";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 9;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Open(openFileDialog1.FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    WorkSheet.Cells[1, 100].Formula = "=COUNTA(C[-99])";

                    int qtdLinhas = Convert.ToInt32(WorkSheet.Cells[1, 100].Value);
                    strFiltro = "";

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    for (int i = 2; i <= qtdLinhas; i++)
                    {
                        strFiltro += ", '" + Convert.ToString(WorkSheet.Cells[i, 1].Value).Trim() + '-' + Convert.ToString(WorkSheet.Cells[i, 2].Value).Trim() + '-' + Convert.ToString(WorkSheet.Cells[i, 3].Value).Trim() + "'";
                    }

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    WorkBook.Close(false, Type.Missing, Type.Missing);
                    App.Quit();

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    string strSQL = @"SELECT DISTINCT
                                            EMPR_NOME, NF_T, SERIE_T, DIPR_COD, QTDE, VALOR_FISCAL, DATA_EMISSAO, DATA_SAIDA, ALERTAS
                                        FROM 
                                            V_NFT_NFS_COM_ALERTAS
                                        WHERE
                                            EMPR_NOME || '-' || NF_T || '-' || SERIE_T IN (" + strFiltro.Substring(2) + @")";

                    DataTable dtConsulta = new DataTable();
                    dtConsulta = RfNfEntradaBLL.Select(strSQL);

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    if (dtConsulta.Rows.Count == 0)
                    {
                        gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());

                        frm.progressBar1.PerformStep();                                                                                                                 //

                        TabPage t2 = tabControl1.TabPages[1];
                        tabControl1.SelectedTab = t2;

                        frm.progressBar1.PerformStep();                                                                                                                 //

                        gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_MOV());

                        frm.progressBar1.PerformStep();                                                                                                                 //

                        TabPage t1 = tabControl1.TabPages[0];
                        tabControl1.SelectedTab = t1;

                        frm.progressBar1.PerformStep();                                                                                                                 //
                    }
                    else
                    {
                        MessageBox.Show("Foram encontradas algumas inconsistências de dados\nRegularize e repita o processo", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        gvImportacao.DataSource = dtConsulta;
                        gvImportacao.Columns[gvImportacao.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        gvImportacao.DefaultCellStyle.ForeColor = Color.Red;
                    }

                    frm.progressBar1.Value = 0;                                                                                                                         //--
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

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Exportar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 2;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    string folderPath = "C:\\temp\\" + this.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(tabControl1.TabPages[0].Text);                //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                        ws.View.FreezePanes(2, 1);

                        using (ExcelRange rng = ws.Cells[1, 1, 1, gvImportacao.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        for (int o = 0; o < gvImportacao.Rows.Count; o++)
                        {
                            for (int j = 0; j < gvImportacao.Columns.Count; j++)
                            {
                                if (gvImportacao[j, o].Style.BackColor == Color.Yellow)
                                {
                                    ws.Cells[o + 2, j + 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                                    ws.Cells[o + 2, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws.Cells[o + 2, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                }
                            }
                        }

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add(tabControl1.TabPages[1].Text);                 //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws2.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao2.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws2.Cells[ws2.Dimension.Address].AutoFilter = true;
                        ws2.View.FreezePanes(2, 1);

                        using (ExcelRange rng2 = ws2.Cells[1, 1, 1, gvImportacao2.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng2.Style.Font.Bold = true;
                            rng2.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng2.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng2.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        for (int o = 0; o < gvImportacao2.Rows.Count; o++)
                        {
                            for (int j = 0; j < gvImportacao2.Columns.Count; j++)
                            {
                                if (gvImportacao2[j, o].Style.BackColor == Color.Yellow)
                                {
                                    ws2.Cells[o + 2, j + 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                                    ws2.Cells[o + 2, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws2.Cells[o + 2, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                                }
                            }
                        }

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        pck.Save();

                        Process.Start(folderPath);
                    }

                    frm.progressBar1.Value = 0;
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

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (gvImportacao.Columns[4].Name == "ALERTAS")
                {
                    MessageBox.Show("Foram encontradas algumas inconsistências de dados\nRegularize e repita o processo", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_NF_SAIDA");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");

                            string strSQL = @"INSERT INTO RF_NF_SAIDA
                                            (ID_IMPORTACAO, ID_REF, CFOP, COD_CLIENTE, COD_CONSIGNATARIO, DATA_GER_LEG, DATA_NF, DATA_SAIDA, DESCRICAO, ENQUADRAMENTO, ID_CORPORATIVO, MACRO_PRODUTO, NCM, NF, NUM_ITEM, ORGANIZACAO, PART_NUMBER_ITEM, PROCEDENCIA_INFO, QTDE, REF_BAIXA, REF_NFE, REF_NFS, REF_SAIDA, SEGMENTO2, SEGMENTO1, SEGMENTO3, SEGMENTO4, SEGMENTO5, SENF, SERIE, VALOR_UN, FINALIDADE_SAIDA, NUM_CONTRATO, AMBIENTE)" + quebraLinha;
                            strSQL += SQL().Replace("'' AMBIENTE", "'" + RfNfEntradaBLL.strAmbiente + "' AMBIENTE");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES
                                        (ID_IMPORTACAO, ID_REF, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV().Replace("'' AMBIENTE", "'" + RfNfEntradaBLL.strAmbiente + "' AMBIENTE");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            MessageBox.Show("NFS e Movimentações Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
