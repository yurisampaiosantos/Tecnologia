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
    public partial class frmTransfOrg : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmTransfOrg()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                frmAmbiente frm2 = new frmAmbiente();
                frm2.TipoBt = "Gerar";
                frm2.ShowDialog();

                if (RfNfEntradaBLL.strAmbiente != "")
                {
                    this.Cursor = Cursors.WaitCursor;

                    CarregaGrids();
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

        private void CarregaGrids()
        {
            MDIParent1 frm = this.MdiParent as MDIParent1;
            frm.progressBar1.Maximum = 3;                                                                                                                       //
            frm.progressBar1.PerformStep();                                                                                                                     //

            gvImportacao.DataSource = CarregaOPs();
            qtdeAlterado = 0;
            for (int o = 0; o < gvImportacao.Rows.Count; o++)
            {
                if (gvImportacao[gvImportacao.Columns.Count - 2, o].Value.ToString() == "ALTERADO")
                {
                    gvImportacao.Rows[o].DefaultCellStyle.BackColor = Color.Yellow;
                    gvImportacao.Rows[o].DefaultCellStyle.ForeColor = Color.Red;

                    qtdeAlterado += 1;
                }
            }

            lblProducao.Text = (qtdeAlterado > 0) ? "Registros Alterados: " + qtdeAlterado : "";

            //Não deixar ordenar na coluna
            foreach (DataGridViewColumn coluna in gvImportacao.Columns)
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

            frm.progressBar1.PerformStep();                                                                                                                     //

            TabPage t1 = tabControl1.TabPages[1];
            tabControl1.SelectedTab = t1;
            gvImportacao2.DataSource = CarregaMOV();
            qtdeAlterado = 0;
            for (int o = 0; o < gvImportacao2.Rows.Count; o++)
            {
                if (gvImportacao2[gvImportacao2.Columns.Count - 2, o].Value.ToString() == "ALTERADO")
                {
                    gvImportacao2.Rows[o].DefaultCellStyle.BackColor = Color.Yellow;
                    gvImportacao2.Rows[o].DefaultCellStyle.ForeColor = Color.Red;

                    qtdeAlterado += 1;
                }
            }

            lblMovimentacoes.Text = (qtdeAlterado > 0) ? "Registros Alterados: " + qtdeAlterado : "";

            //Não deixar ordenar na coluna
            foreach (DataGridViewColumn coluna in gvImportacao2.Columns)
                coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

            frm.progressBar1.PerformStep();                                                                                                                     //

            TabPage t0 = tabControl1.TabPages[0];
            tabControl1.SelectedTab = t0;

            frm.progressBar1.PerformStep();                                                                                                                     //
            frm.progressBar1.Value = 0;                                                                                                                         //--
        }

        public string SQL_OP()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                        ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF, AMBIENTE
                     FROM 
                        V_TRANSF_ORG_OP";
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                        PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO AS ID_IMPORTACAO_REAL, ID_REF, AMBIENTE
                     FROM 
                        V_TRANSF_ORG_MOV";
        }

        public DataTable CarregaOPs()
        {
            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL_OP());

            return dtConsulta;
        }

        public DataTable CarregaMOV()
        {
            DataTable dtConsulta2 = new DataTable();
            dtConsulta2 = RfNfEntradaBLL.Select(SQL_MOV());

            return dtConsulta2;
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
                    frm.progressBar1.Maximum = 3;
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
                                if (gvImportacao.Rows[o].DefaultCellStyle.BackColor == Color.Yellow)
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
                                if (gvImportacao2.Rows[o].DefaultCellStyle.BackColor == Color.Yellow)
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
                else
                {
                    string MsgAlterado = "";
                    if (lblProducao.Text != "" || lblMovimentacoes.Text != "") MsgAlterado = "Foi encontrado Registros Alterados.\n";

                    DialogResult myDialogResult = MessageBox.Show(MsgAlterado + "Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;
                        
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_PRODUCAO");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");

                            string strSQL = @"INSERT INTO RF_PRODUCAO 
                                            (ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                                            ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_OP().Replace(", ID_REF", ", NULL");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES 
                                            (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                                            PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV().Replace(", ID_REF", ", NULL");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            lblProducao.Text = "";
                            lblMovimentacoes.Text = "";

                            MessageBox.Show("OP's e Movimentações Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
