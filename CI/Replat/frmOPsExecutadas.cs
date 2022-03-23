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
    public partial class frmOPsExecutadas : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmOPsExecutadas()
        {
            InitializeComponent();
        }

        private void frmOPsExecutadas_Load(object sender, EventArgs e)
        {
            dtpDe.MaxDate = DateTime.Now.Date;
            dtpDe.Value = DateTime.Now.Date;
            dtpDe.Checked = false;
            dtpAte.Checked = false;
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            dtpAte.MinDate = dtpDe.Value;
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
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

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CarregaGrids();

                for (int o = 0; o < gvImportacao.Rows.Count; o++)
                {
                    if (gvImportacao[gvImportacao.Columns.Count - 1, o].Value.ToString() == "x")
                    {
                        gvImportacao.Rows[o].DefaultCellStyle.BackColor = Color.Lavender;
                        gvImportacao.Rows[o].DefaultCellStyle.ForeColor = Color.MediumBlue;
                    }
                }

                lblRegistros.Text = "Registros: " + gvImportacao.Rows.Count;

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

        private void CarregaGrids()
        {
            MDIParent1 frm = this.MdiParent as MDIParent1;
            frm.progressBar1.Maximum = 1;                                                                                                                       //
            frm.progressBar1.PerformStep();                                                                                                                     //

            gvImportacao.DataSource = CarregaOPs();

            frm.progressBar1.PerformStep();                                                                                                                     //
            frm.progressBar1.Value = 0;                                                                                                                         //--
        }

        public DataTable CarregaOPs()
        {
            string strSQL = @"TRUNCATE TABLE EREPLAT.RF_PRODUCAO_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_PRODUCAO_TEMP 
                            (ID_IMPORTACAO,ID_REF, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                            ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM)
                        SELECT 
                            opre.ID_IMPORTACAO, opre.ID_REF, opre.ALTA_PARCIAL, opre.COD_LOCATION, opre.COD_TIPO_OP, opre.DATA, opre.DATA_CONCLUSAO, opre.DATA_GER_LEG, opre.DATA_REFERENCIA, opre.DESCRICAO_SERVICO, opre.DIRECIONADA, opre.DOC_ORIGEM, opre.ENCOMENDANTE, opre.IDENTIFICADOR, opre.NUM_DOC, opre.NUM_ORDEM, 
                            opre.ORGANIZACAO, opre.PART_NUMBER, opre.PROCEDENCIA_INFO, opre.QTDE, opre.REF_NFE, opre.REF_NFS, opre.REF_OPR, opre.SEGMENTO1, opre.SEGMENTO2, opre.SEGMENTO3, opre.SEGMENTO4, opre.SEGMENTO5, opre.TIPO_MOV, opre.TIPO_TRANS, opre.VERSAO, opre.TEMPO_EXECUCAO, opre.DESIGNACAO_ETAPA, opre.NUM_RTM
                        FROM 
                            EREPLAT.V_OP_REPLAT_GERAL opre
                        WHERE
                            opre.DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"TRUNCATE TABLE RF_OP_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_OP_TEMP 
                            (ID_IMPORTACAO)
                        SELECT 
                            ID_IMPORTACAO 
                        FROM 
                            V_OP_REPLAT
                        ORDER BY
                            ID_IMPORTACAO";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL_OP());

            return dtConsulta;
        }

        public string SQL_OP()
        {
            return @"SELECT
                            prat.ATIV_SIG, prat.FOSE_NUMERO, prat.FCES_WBS, prat.FCES_NIVEL, prat.FCES_SIGLA, prat.FCES_DESCRICAO, prat.FSMP_DATA, '' AS QTDE_PROG, prat.FSMP_AVANCO_ACM, prat.FSMP_OBS, prat.FOSM_DUR_REAL, prat.FSME_DATA, prat.FSME_AVANCO_ACM, prat.FSME_OBS, prat.RPLB_NOME, prat.UNAC_SIGLA,
                            NVL2(opma.FCES_FCME_ID, 'x', NULL) AS NIVEL_CONCLUSAO
                        FROM
                              V_PROG_VIA_ATIVIDADE prat
                            , V_OP_REPLAT_MAX opma
                        WHERE
                                prat.FCME_ID = opma.FCES_FCME_ID (+)
                            AND prat.FCES_WBS = opma.FCES_WBS (+)
                        ORDER BY
                            ORDEM";
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
                    frm.progressBar1.PerformStep();

                    object misValue = System.Reflection.Missing.Value;

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

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

                    WorkSheet.Cells[1, 1] = this.Text;
                    WorkSheet.Cells[2, 1].Select();
                    WorkSheet.Name = this.Name;

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
    }
}
