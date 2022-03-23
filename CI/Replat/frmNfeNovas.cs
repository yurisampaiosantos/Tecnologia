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

namespace Replat
{
    public partial class frmNfeNovas : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmNfeNovas()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public string SQL()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ORGANIZACAO, COD_FORNECEDOR, NF_E, SERIE_E, NUM_ITEM, DATA_NF, PART_NUMBER, QTDE, REF_ENTRADA, VALOR_FISCAL, NCM, CFOP, DOC_ORIGEM, DATA_DOC, TIPO_ENTRADA, REF_NFE, COD_PROPRIETARIO, REF_BAIXA, PROCEDENCIA_INFO, DATA_GER_LEG, ID_CORPORATIVO, NUM_ADICAO, NUM_ITEM_ADICAO, NUM_DI_CAMBIAL, VCTO_DI_CAMBIAL, DATA_ENTRADA, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_ERP_ENT, FINALIDADE_ENTRADA, NUM_CONTRATO, ID_REF, AMBIENTE
                    FROM 
                        V_NF_ENTRADA_REPLAT" + ((cbTipo.Text != "(Todas)") ? " WHERE TIPO = '" + cbTipo.Text + "'": "");
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_REF, AMBIENTE
                    FROM 
                        V_RECEBIMENTO_REPLAT" + ((cbTipo.Text != "(Todas)") ? " WHERE TIPO = '" + cbTipo.Text + "'" : "");
        }

        public string SQL_IMP()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA_CONTABIL, DATA_EMISSAO, INFO_COMPLEMENTARES, NF, NUM_ITEM, ORGANIZACAO, REF_ERP_ENT, SERIE, SIGLA_IMPOSTO, TIPO_NF, VALOR, DATA_GER_LEG, AMBIENTE
                    FROM 
                        V_IMPOSTO_REPLAT" + ((cbTipo.Text != "(Todas)") ? " WHERE TIPO = '" + cbTipo.Text + "'" : "");
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAmbiente frm2 = new frmAmbiente();
                frm2.TipoBt = "Gerar";
                frm2.ShowDialog();

                if (RfNfEntradaBLL.strAmbiente != "")
                {
                    this.Cursor = Cursors.WaitCursor;

                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 3;
                    frm.progressBar1.PerformStep();                                                                                                                 //
                    frm.progressBar1.PerformStep();                                                                                                                 //

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    TabPage t2 = tabControl1.TabPages[1];
                    tabControl1.SelectedTab = t2;
                    gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_MOV());

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    TabPage t3 = tabControl1.TabPages[2];
                    tabControl1.SelectedTab = t3;
                    gvImportacao3.DataSource = RfNfEntradaBLL.Select(SQL_IMP());

                    TabPage t1 = tabControl1.TabPages[0];
                    tabControl1.SelectedTab = t1;

                    frm.progressBar1.PerformStep();                                                                                                                 //
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

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0 && gvImportacao3.Rows.Count == 0)
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

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        ExcelWorksheet ws3 = pck.Workbook.Worksheets.Add(tabControl1.TabPages[2].Text);                 //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws3.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao3.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws3.Cells[ws3.Dimension.Address].AutoFilter = true;
                        ws3.View.FreezePanes(2, 1);

                        using (ExcelRange rng3 = ws3.Cells[1, 1, 1, gvImportacao3.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng3.Style.Font.Bold = true;
                            rng3.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng3.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng3.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

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

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0 && gvImportacao3.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string MsgAlterado = "";
                    if (qtdeAlterado > 0) MsgAlterado = "Foi encontrado NF com chave alterada.\n";

                    DialogResult myDialogResult = MessageBox.Show(MsgAlterado + "Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_NF_ENTRADA");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_IMPOSTO_CALC");

                            string strSQL = @"INSERT INTO RF_NF_ENTRADA
                                            (ID_IMPORTACAO, ORGANIZACAO, COD_FORNECEDOR, NF_E, SERIE_E, NUM_ITEM, DATA_NF, PART_NUMBER, QTDE, REF_ENTRADA, VALOR_FISCAL, NCM, CFOP, DOC_ORIGEM, DATA_DOC, TIPO_ENTRADA, REF_NFE, COD_PROPRIETARIO, REF_BAIXA, PROCEDENCIA_INFO, DATA_GER_LEG, ID_CORPORATIVO, NUM_ADICAO, NUM_ITEM_ADICAO, NUM_DI_CAMBIAL, VCTO_DI_CAMBIAL, DATA_ENTRADA, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_ERP_ENT, FINALIDADE_ENTRADA, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES
                                       (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_IMPOSTO_CALC
                                        (ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA_CONTABIL, DATA_EMISSAO, INFO_COMPLEMENTARES, NF, NUM_ITEM, ORGANIZACAO, REF_ERP_ENT, SERIE, SIGLA_IMPOSTO, TIPO_NF, VALOR, DATA_GER_LEG, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_IMP();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            gvImportacao3.DataSource = null;
                            MessageBox.Show("NF de Entrada, Movimentações e Imposto Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void frmNfeNovas_Load(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
        }
    }
}
