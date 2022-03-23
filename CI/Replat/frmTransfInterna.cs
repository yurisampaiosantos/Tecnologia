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
    public partial class frmTransfInterna : Form
    {
        string quebraLinha = Environment.NewLine;
        const string aspas = "\"";
        public string strFiltro = "";

        public frmTransfInterna()
        {
            InitializeComponent();
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ID_REF, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO AS ID_IMPORTACAO_REAL
                    FROM 
                        V_TRANSFERENCIA_REPLAT";
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
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
                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = gvImportacao.Rows.Count;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    object misValue = System.Reflection.Missing.Value;

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
                    Excel.Worksheet WorkSheet2 = (Excel.Worksheet)WorkBook.Worksheets.get_Item(2);
                    Excel.Worksheet WorkSheet3 = (Excel.Worksheet)WorkBook.Worksheets.get_Item(3);

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

                    WorkSheet.Cells[1, 1] = "Análise dos Movimentos Tipo 'QL'";
                    WorkSheet.Cells[2, 1].Select();
                    WorkSheet.Name = "Movimentos";

                    WorkSheet.Select();
                    WorkSheet2.Delete();
                    WorkSheet3.Delete();

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

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        MDIParent1 frm = this.MdiParent as MDIParent1;
                        frm.progressBar1.Maximum = 2;
                        frm.progressBar1.PerformStep();                                                                                                                     //
       
                        RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        string strSQL = @"INSERT INTO RF_MOVIMENTACOES
                                                (ID_IMPORTACAO, ID_REF, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL)" + quebraLinha;
                        strSQL += SQL_MOV();

                        RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        gvImportacao.DataSource = null;

                        frm.progressBar1.Value = 0;                                                                                                                         //--

                        MessageBox.Show("Movimentações tipo QL Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
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

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MDIParent1 frm = this.MdiParent as MDIParent1;
                frm.progressBar1.Maximum = 1;
                frm.progressBar1.PerformStep();                                                                                                                     //

                gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL_MOV());

                frm.progressBar1.PerformStep();                                                                                                                     //
                frm.progressBar1.Value = 0;                                                                                                                         //--

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
    }
}
