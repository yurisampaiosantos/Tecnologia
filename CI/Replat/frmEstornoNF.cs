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
    public partial class frmEstornoNF : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmEstornoNF()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEstornoNF_Load(object sender, EventArgs e)
        {
            dtpDe.MaxDate = DateTime.Now.Date.AddDays(-3);
            dtpDe.Value = DateTime.Now.Date.AddDays(-3);

            dtpAte.MaxDate = DateTime.Now.Date.AddDays(-3);
            dtpAte.MinDate = DateTime.Now.Date.AddDays(-3);
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            dtpAte.MinDate = dtpDe.Value;
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dtConsulta = new DataTable();
                dtConsulta = CarregaGrid();

                gvImportacao.DataSource = dtConsulta;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string SQL()
        {
            string strSQL = @"SELECT 
                                    opre.COD_FORNEC, opre.DATA, opre.DATA_GER_LEG, opre.DATA_NF_ESTORNADA, opre.ID_CORPORATIVO, opre.ID_IMPORTACAO, opre.ID_REF, opre.NF, opre.NUM_ITEM, 
                                    opre.ORGANIZACAO, opre.PROCEDENCIA_INFO, opre.QTDE_ESTORNAR, opre.REF_ERP_ENT, opre.REF_OPR, opre.SEGMENTO1, opre.SEGMENTO2, opre.SEGMENTO3, 
                                    opre.SEGMENTO4, opre.SEGMENTO5, opre.SENF, opre.SERIE, opre.TIPO_NF
                                FROM 
                                    EREPLAT.V_ESTORNO_RDR_REPLAT opre, (SELECT DISTINCT * FROM EREPLAT.RF_ESTORNO_NF UNION SELECT * FROM EREPLAT.RF_ESTORNO_NF_LOG) prlo
                                WHERE
                                        opre.ID_IMPORTACAO = prlo.ID_IMPORTACAO (+) 
                                    AND opre.DATA_FILTRO BETWEEN TO_DATE('" + dtpDe.Text + @"', 'DD/MM/YY') AND TO_DATE('" + dtpAte.Text + @"', 'DD/MM/YY')
                                    AND (
                                        prlo.ID_IMPORTACAO IS NULL OR
                                        opre.COD_FORNEC || '-' || opre.DATA || '-' || opre.DATA_NF_ESTORNADA || '-' || opre.ID_CORPORATIVO || '-' || opre.ID_IMPORTACAO || '-' || 
                                        opre.ID_REF || '-' || opre.NF || '-' || opre.NUM_ITEM || '-' || opre.ORGANIZACAO || '-' || opre.PROCEDENCIA_INFO || '-' || opre.QTDE_ESTORNAR || '-' || 
                                        opre.REF_ERP_ENT || '-' || opre.REF_OPR || '-' || opre.SEGMENTO1 || '-' || opre.SEGMENTO2 || '-' || opre.SEGMENTO3 || '-' || opre.SEGMENTO4 || '-' || 
                                        opre.SEGMENTO5 || '-' || opre.SENF || '-' || opre.SERIE || '-' || opre.TIPO_NF
                                        <>
                                        prlo.COD_FORNEC || '-' || prlo.DATA || '-' || prlo.DATA_NF_ESTORNADA || '-' || prlo.ID_CORPORATIVO || '-' || prlo.ID_IMPORTACAO || '-' || 
                                        prlo.ID_REF || '-' || prlo.NF || '-' || prlo.NUM_ITEM || '-' || prlo.ORGANIZACAO || '-' || prlo.PROCEDENCIA_INFO || '-' || prlo.QTDE_ESTORNAR || '-' || 
                                        prlo.REF_ERP_ENT || '-' || prlo.REF_OPR || '-' || prlo.SEGMENTO1 || '-' || prlo.SEGMENTO2 || '-' || prlo.SEGMENTO3 || '-' || prlo.SEGMENTO4 || '-' || 
                                        prlo.SEGMENTO5 || '-' || prlo.SENF || '-' || prlo.SERIE || '-' || prlo.TIPO_NF
                                    )";
            return strSQL;
        }

        public DataTable CarregaGrid()
        {
            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL());

            return dtConsulta;
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime dt1 = Convert.ToDateTime(dtpDe.Value);
                DateTime dt2 = Convert.ToDateTime(dtpAte.Value);

                object misValue = System.Reflection.Missing.Value;

                Excel.Application App = new Excel.Application();
                Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                DataTable dtConsulta = new DataTable();
                dtConsulta = CarregaGrid();

                //Cabeçalho
                for (int i = 1; i <= dtConsulta.Columns.Count; i++)
                {
                    WorkSheet.Cells[3, i] = dtConsulta.Columns[i - 1].ColumnName;
                }

                //seleção das linhas
                for (int o = 0; o < dtConsulta.Rows.Count; o++)
                {
                    //Preenchimento das celulas
                    for (int j = 0; j < dtConsulta.Columns.Count; j++)
                    {
                        WorkSheet.Cells[o + 4, j + 1] = dtConsulta.Rows[o][j].ToString();
                    }
                }

                App.Columns.AutoFit();

                WorkSheet.Cells[1, 1] = "Não processadas de: " + dt1.ToString("dd/MM/yy") + " a " + dt2.ToString("dd/MM/yy");
                WorkSheet.Cells[2, 1].Select();

                App.Visible = true;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
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

                        string strSQL = @"INSERT INTO RF_ESTORNO_NF
                                        (COD_FORNEC, DATA, DATA_GER_LEG, DATA_NF_ESTORNADA, ID_CORPORATIVO, ID_IMPORTACAO, ID_REF, NF, NUM_ITEM, ORGANIZACAO, PROCEDENCIA_INFO, QTDE_ESTORNAR, 
                                         REF_ERP_ENT, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SENF, SERIE, TIPO_NF)" + quebraLinha;
                        strSQL += SQL();

                        RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                        gvImportacao.DataSource = null;
                        MessageBox.Show("Todos os Registros enviados com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
