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
    public partial class frmLocationsAlterados : Form
    {
        string quebraLinha = Environment.NewLine;
        const string aspas = "\"";
        public string strFiltro = "";
        public int qtdeAlterado = 0;

        public frmLocationsAlterados()
        {
            InitializeComponent();
        }

        public string SQL()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO, 
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        DECODE(vg.COD_LOCATION, tl.COD_LOCATION, '', '-> ') || vg.COD_LOCATION COD_LOCATION,
                        DECODE(vg.COD_PARCEIRO, tl.COD_PARCEIRO, '', '-> ') || vg.COD_PARCEIRO COD_PARCEIRO,
                        vg.DATA_GER_LEG,  
                        DECODE(vg.DESCRICAO, tl.DESCRICAO, '', '-> ') || vg.DESCRICAO DESCRICAO,
                        DECODE(vg.ID_CORPORATIVO, tl.ID_CORPORATIVO, '', '-> ') || vg.ID_CORPORATIVO ID_CORPORATIVO,
                        DECODE(vg.LOCAL, tl.LOCAL, '', '-> ') || vg.LOCAL LOCAL,
                        DECODE(vg.LOCATION_PADRAO, tl.LOCATION_PADRAO, '', '-> ') || vg.LOCATION_PADRAO LOCATION_PADRAO,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                        DECODE(vg.SEGMENTO5, tl.SEGMENTO5, '', '-> ') || vg.SEGMENTO5 SEGMENTO5,
                        DECODE(vg.STATUS, tl.STATUS, '', '-> ') || vg.STATUS STATUS,
                        DECODE(vg.TIPO, tl.TIPO, '', '-> ') || vg.TIPO TIPO,
                        vg.ID_IMPORTACAO_REAL,
                        vg.AMBIENTE
                    FROM 
                        V_AREA_ESTOCAGEM_GERAL vg, 
                        (SELECT 
                              tl.*
                          FROM 
                              RF_LOCATIONS_LOG tl,
                              V_AREA_ESTOCAGEM_LOG_MAX tl2
                          WHERE
                                  tl.ID_IMPORTACAO = tl2.ID_IMPORTACAO
                              AND tl.DATA_GER_LEG = tl2.DATA_GER_LEG) tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO
                        AND vg.ID_REF || '-' || vg.COD_LOCATION || '-' || vg.COD_PARCEIRO || '-' || vg.DESCRICAO || '-' || vg.ID_CORPORATIVO || '-' || vg.LOCAL || '-' || vg.LOCATION_PADRAO || '-' || vg.ORGANIZACAO || '-' || vg.PROCEDENCIA_INFO || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.SEGMENTO5 || '-' || vg.STATUS || '-' || vg.TIPO
                            <>
                            tl.ID_REF || '-' || tl.COD_LOCATION || '-' || tl.COD_PARCEIRO || '-' || tl.DESCRICAO || '-' || tl.ID_CORPORATIVO || '-' || tl.LOCAL || '-' || tl.LOCATION_PADRAO || '-' || tl.ORGANIZACAO || '-' || tl.PROCEDENCIA_INFO || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.SEGMENTO5 || '-' || tl.STATUS || '-' || tl.TIPO";
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
                    frm.progressBar1.Maximum = 2;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    string folderPath = "C:\\temp\\" + this.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.Name);                //Adicione uma nova planilha para a pasta de trabalho vazia
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

                if (gvImportacao.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string MsgAlterado = "";
                    if (qtdeAlterado > 0) MsgAlterado = "Foi encontrado COD_LOCATION Alterado.\n";
 
                    DialogResult myDialogResult = MessageBox.Show(MsgAlterado + "Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            MDIParent1 frm = this.MdiParent as MDIParent1;
                            frm.progressBar1.Maximum = 1;
                            frm.progressBar1.PerformStep();                                                                                                                     //

                            string strSQL = @"INSERT INTO RF_LOCATIONS
                                            (ID_IMPORTACAO, ID_REF, COD_LOCATION, COD_PARCEIRO, DATA_GER_LEG, DESCRICAO, ID_CORPORATIVO, LOCAL, LOCATION_PADRAO, ORGANIZACAO, PROCEDENCIA_INFO, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, STATUS, TIPO, ID_IMPORTACAO_REAL, AMBIENTE)" + quebraLinha;
                            strSQL += SQL().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            gvImportacao.DataSource = null;
                            lblAlterados.Text = "";

                            frm.progressBar1.Value = 0;                                                                                                                         //--

                            MessageBox.Show("Locations Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
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
                frmAmbiente frm2 = new frmAmbiente();
                frm2.TipoBt = "Gerar";
                frm2.ShowDialog();

                if (RfNfEntradaBLL.strAmbiente != "")
                {
                    this.Cursor = Cursors.WaitCursor;

                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 1;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());

                    qtdeAlterado = 0;
                    for (int o = 0; o < gvImportacao.Rows.Count; o++)
                    {
                        for (int j = 0; j < gvImportacao.Columns.Count; j++)
                        {
                            if (gvImportacao[j, o].Value.ToString().IndexOf("-> ") > -1)
                            {
                                gvImportacao[j, o].Value = gvImportacao[j, o].Value.ToString().Replace("-> ", "");
                                gvImportacao[j, o].Style.BackColor = Color.Yellow;
                                gvImportacao[j, o].Style.ForeColor = Color.Red;

                                if (j == 2) qtdeAlterado += 1;
                            }
                        }
                    }

                    lblAlterados.Text = (qtdeAlterado > 0) ? "COD_LOCATION Alterado: " + qtdeAlterado : "";

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                     //
                    frm.progressBar1.Value = 0;                                                                                                                         //--

                    this.Cursor = Cursors.Default;
                }
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
