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
    public partial class frmBatimentosTJ : Form
    {
        string quebraLinha = Environment.NewLine;
        const string aspas = "\"";
        public string strFiltro = "";
        public int qtdeAlterado = 0;
        int qtdLinhas;

        public frmBatimentosTJ()
        {
            InitializeComponent();
        }

        public string SQL()
        {
            return @"SELECT 
                        NUM_DOC, ORGANIZACAO, PART_NUMBER, QTDE, NUM_ORDEM, TIPO_MOV, TIPO_TRANS, COD_LOCATION, DATA, DIRECIONADA, REF_NFS, DATA_REFERENCIA, VERSAO, COD_TIPO_OP, DATA_CONCLUSAO, ENCOMENDANTE, DESCRICAO_SERVICO, DOC_ORIGEM, IDENTIFICADOR, REF_NFE, PROCEDENCIA_INFO, DATA_GER_LEG, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_OPR, ALTA_PARCIAL, NUM_RTM, TEMPO_EXECUCAO, DESIGNACAO_ETAPA
                     FROM 
                        RF_PRODUCAO_BAT";
        }

        public string SQL_REPLAT()
        {
            return @"SELECT 
                        ALERTA, NUM_DOC, ORGANIZACAO, PART_NUMBER, QTDE, NUM_ORDEM, TIPO_MOV, TIPO_TRANS, COD_LOCATION, DATA, DIRECIONADA, REF_NFS, DATA_REFERENCIA, VERSAO, COD_TIPO_OP, DATA_CONCLUSAO, ENCOMENDANTE, DESCRICAO_SERVICO, DOC_ORIGEM, IDENTIFICADOR, REF_NFE, PROCEDENCIA_INFO, DATA_GER_LEG, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_OPR, ALTA_PARCIAL, NUM_RTM, TEMPO_EXECUCAO, DESIGNACAO_ETAPA
                     FROM 
                        V_TJ_BATIMENTO_REPLAT";
        }

        public string SQL_SISEPC()
        {
            return @"SELECT 
                        ALERTA, ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF
                     FROM 
                        V_TJ_BATIMENTO_SISEPC";
        }

        public string SQL_SISEPC_ALTERADO()
        {
            return @"SELECT 
                        ALERTA, ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF
                    FROM 
                        (SELECT
                            'Dados diferente do Replat' ALERTA, vg.ID_IMPORTACAO,
                            DECODE(vg.ALTA_PARCIAL, tl.ALTA_PARCIAL, '', '-> ') || vg.ALTA_PARCIAL ALTA_PARCIAL,
                            DECODE(vg.COD_LOCATION, tl.COD_LOCATION, '', '-> ') || vg.COD_LOCATION COD_LOCATION,
                            DECODE(vg.COD_TIPO_OP, tl.COD_TIPO_OP, '', '-> ') || vg.COD_TIPO_OP COD_TIPO_OP,
                            DECODE(vg.DATA, tl.DATA, '', '-> ') || vg.DATA DATA,
                            DECODE(vg.DATA_CONCLUSAO, tl.DATA_CONCLUSAO, '', '-> ') || vg.DATA_CONCLUSAO DATA_CONCLUSAO,
                            vg.DATA_GER_LEG,
                            DECODE(vg.DATA_REFERENCIA, tl.DATA_REFERENCIA, '', '-> ') || vg.DATA_REFERENCIA DATA_REFERENCIA,
                            DECODE(vg.DESCRICAO_SERVICO, tl.DESCRICAO_SERVICO, '', '-> ') || vg.DESCRICAO_SERVICO DESCRICAO_SERVICO,
                            DECODE(vg.DIRECIONADA, tl.DIRECIONADA, '', '-> ') || vg.DIRECIONADA DIRECIONADA,
                            DECODE(vg.DOC_ORIGEM, tl.DOC_ORIGEM, '', '-> ') || vg.DOC_ORIGEM DOC_ORIGEM,
                            DECODE(vg.ENCOMENDANTE, tl.ENCOMENDANTE, '', '-> ') || vg.ENCOMENDANTE ENCOMENDANTE,
                            DECODE(vg.IDENTIFICADOR, tl.IDENTIFICADOR, '', '-> ') || vg.IDENTIFICADOR IDENTIFICADOR,
                            DECODE(vg.NUM_DOC, tl.NUM_DOC, '', '-> ') || vg.NUM_DOC NUM_DOC,
                            DECODE(vg.NUM_ORDEM, tl.NUM_ORDEM, '', '-> ') || vg.NUM_ORDEM NUM_ORDEM,
                            DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                            DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                            DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                            DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE QTDE,
                            DECODE(vg.REF_NFE, tl.REF_NFE, '', '-> ') || vg.REF_NFE REF_NFE,
                            DECODE(vg.REF_NFS, tl.REF_NFS, '', '-> ') || vg.REF_NFS REF_NFS,
                            DECODE(vg.REF_OPR, tl.REF_OPR, '', '-> ') || vg.REF_OPR REF_OPR,
                            DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                            DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                            DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                            DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                            vg.SEGMENTO5,
                            DECODE(vg.TIPO_MOV, tl.TIPO_MOV, '', '-> ') || vg.TIPO_MOV TIPO_MOV,
                            DECODE(vg.TIPO_TRANS, tl.TIPO_TRANS, '', '-> ') || vg.TIPO_TRANS TIPO_TRANS,
                            DECODE(vg.VERSAO, tl.VERSAO, '', '-> ') || vg.VERSAO VERSAO,
                            DECODE(vg.TEMPO_EXECUCAO, tl.TEMPO_EXECUCAO, '', '-> ') || vg.TEMPO_EXECUCAO TEMPO_EXECUCAO,
                            DECODE(vg.DESIGNACAO_ETAPA, tl.DESIGNACAO_ETAPA, '', '-> ') || vg.DESIGNACAO_ETAPA DESIGNACAO_ETAPA,
                            DECODE(vg.NUM_RTM, tl.NUM_RTM, '', '-> ') || vg.NUM_RTM NUM_RTM,
                            vg.ID_REF
                        FROM 
                            V_TRANSF_ORG_OP_GERAL vg, 
                            RF_PRODUCAO_BAT tl
                        WHERE
                                vg.SEGMENTO5 = tl.SEGMENTO5
                            AND vg.ALTA_PARCIAL || '-' || vg.COD_LOCATION || '-' || vg.COD_TIPO_OP || '-' || vg.DATA || '-' || vg.DATA_CONCLUSAO || '-' || vg.DATA_REFERENCIA || '-' || vg.DESCRICAO_SERVICO || '-' || vg.DIRECIONADA || '-' || vg.DOC_ORIGEM || '-' || vg.ENCOMENDANTE || '-' || vg.IDENTIFICADOR || '-' || vg.NUM_DOC || '-' || vg.NUM_ORDEM || '-' || vg.ORGANIZACAO || '-' || vg.PART_NUMBER || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.REF_NFE || '-' || vg.REF_NFS || '-' || vg.REF_OPR || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.TIPO_MOV || '-' || vg.TIPO_TRANS || '-' || vg.VERSAO || '-' || vg.TEMPO_EXECUCAO || '-' || vg.DESIGNACAO_ETAPA || '-' || vg.NUM_RTM
                                <>
                                tl.ALTA_PARCIAL || '-' || tl.COD_LOCATION || '-' || tl.COD_TIPO_OP || '-' || tl.DATA || '-' || tl.DATA_CONCLUSAO || '-' || tl.DATA_REFERENCIA || '-' || tl.DESCRICAO_SERVICO || '-' || tl.DIRECIONADA || '-' || tl.DOC_ORIGEM || '-' || tl.ENCOMENDANTE || '-' || tl.IDENTIFICADOR || '-' || tl.NUM_DOC || '-' || tl.NUM_ORDEM || '-' || tl.ORGANIZACAO || '-' || tl.PART_NUMBER || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.REF_NFE || '-' || tl.REF_NFS || '-' || tl.REF_OPR || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.TIPO_MOV || '-' || tl.TIPO_TRANS || '-' || tl.VERSAO || '-' || tl.TEMPO_EXECUCAO || '-' || tl.DESIGNACAO_ETAPA || '-' || tl.NUM_RTM)";
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
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Batimento Replat");                //Adicione uma nova planilha para a pasta de trabalho vazia
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

                        if (gvImportacao2.Rows.Count > 0)
                        {
                            ExcelWorksheet ws2 = pck.Workbook.Worksheets.Add("Batimento sisEPC");                 //Adicione uma nova planilha para a pasta de trabalho vazia
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

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao.DataSource = null;
                gvImportacao2.DataSource = null;

                DataTable dtConsulta = new DataTable();
                dtConsulta = RfNfEntradaBLL.Select("SELECT * FROM RF_PRODUCAO_BAT WHERE TIPO_TRANS = 'TJ'");

                if (dtConsulta.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Batimento", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 3;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL_REPLAT());

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    TabPage t2 = tabControl1.TabPages[1];
                    tabControl1.SelectedTab = t2;

                    frm.progressBar1.PerformStep();

                    gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_SISEPC() + quebraLinha + "UNION ALL " + SQL_SISEPC_ALTERADO());

                    qtdeAlterado = 0;

                    for (int o = 0; o < gvImportacao2.Rows.Count; o++)
                    {
                        if (gvImportacao2[0, o].Value.ToString() == "Dados diferente do Replat") qtdeAlterado += 1;

                        for (int j = 0; j < gvImportacao2.Columns.Count; j++)
                        {
                            if (gvImportacao2[j, o].Value.ToString().IndexOf("-> ") > -1)
                            {
                                gvImportacao2[j, o].Value = gvImportacao2[j, o].Value.ToString().Replace("-> ", "");
                                gvImportacao2[j, o].Style.BackColor = Color.Yellow;
                                gvImportacao2[j, o].Style.ForeColor = Color.Red;
                            }
                        }
                    }

                    lblMovimentacoes.Text = (qtdeAlterado > 0) ? "Dados diferente do Replat: " + qtdeAlterado : "";

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao2.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    TabPage t1 = tabControl1.TabPages[0];
                    tabControl1.SelectedTab = t1;

                    frm.progressBar1.PerformStep();                                                                                                                     //
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

        private void btQuery_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery();

            frm.strQuery = @"SELECT M.NUM_DOC,
O.NOME ORGANIZACAO,
P.PART_NUMBER,
M.QTDE,
OP.NUM_ORDER,
M.TIPO_MOV,
M.TIPO_TRANS,
L.COD_LOCATION,
TO_CHAR(M.DATA, 'YYYYMMDD') DATA,
'N' DIRECIONADA,
OP.REF_NFS,
TO_CHAR(M.DATA, 'YYYYMMDD') DATA_REFERENCIA,
NULL VERSAO,
OP.COD_TIPO_OP,
TO_CHAR(M.DATA, 'YYYYMMDD') DATA_CONCLUSAO,
NULL ENCOMENDANTE,
NULL DESCRICAO_SERVICO,
NULL DOC_ORIGEM,
M.REFERENCIA IDENTIFICADOR,
M.REF_NFE,
M.PROCEDENCIA_INFO,
TO_CHAR(M.DATA_GER_LEG, 'YYYYMMDD') DATA_GER_LEG,
M.SEGMENTO1,M.SEGMENTO2,M.SEGMENTO3,
M.SEGMENTO4,M.SEGMENTO5,M.REF_OPR,
NULL ALTA_PARCIAL,
NULL TEMPO_EXECUCAO,
NULL DESIGNACAO_ETAPA,
NULL NUM_RTM
FROM MOVIMENTO M, SFW_PRODUTO P, ORGANIZACAO O, LOCATIONS L, OP
WHERE M.ID_PRODUTO = P.ID_PRODUTO
AND M.ID_LOCATION = L.ID_LOCATION
AND P.ID_ORGANIZACAO = O.ID_ORGANIZACAO
AND M.ID_OP = OP.ID_OP(+)
AND M.TIPO_TRANS = 'TJ'
AND (M.SEGMENTO3 <> 'ESTORNO' OR M.SEGMENTO3 IS NULL)
AND M.DATA_GER_LEG > TO_DATE('12/05/2016','DD/MM/YYYY')";

            frm.ShowDialog();
        }

        private void btAbrir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                gvImportacao2.DataSource = null;
                gvImportacao.DataSource = null;
                gvImportacao2.DefaultCellStyle.ForeColor = Color.Black;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Abrir";
                openFileDialog1.Filter = "Arquivos do Excel | *.xlsx";

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    string strTbl = "RF_PRODUCAO_BAT";
                    RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE " + strTbl);

                    FileInfo file = new FileInfo(openFileDialog1.FileName);

                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                        StringBuilder Cols = new StringBuilder();

                        bool booColProximos = false;
                        int qtdCol = workSheet.Dimension.End.Column;
                        int qtdLinhas = workSheet.Dimension.End.Row;
                        var titulos = workSheet.Cells[1, 1, 1, qtdCol];

                        foreach (var firstRowCell in titulos)
                        {
                            if (booColProximos) Cols.Append(", ");
                            Cols.Append(firstRowCell.Text);

                            booColProximos = true;
                        }

                        MDIParent1 frm = this.MdiParent as MDIParent1;
                        frm.progressBar1.Maximum = qtdLinhas;
                        frm.progressBar1.PerformStep();

                        for (var i = 2; i <= qtdLinhas; i++)
                        {
                            frm.progressBar1.PerformStep();                                                                                                                     //

                            StringBuilder Rows = new StringBuilder();
                            bool booRowProximos = false;
                            var row = workSheet.Cells[i, 1, i, qtdCol];

                            for (int c = 1; c <= qtdCol; c++)
                            {
                                if (booRowProximos) Rows.Append(", ");
                                booRowProximos = true;

                                if (row[i, c].Value == null)
                                    Rows.Append("''");
                                else
                                    Rows.Append("'" + row[i, c].Value + "'");
                            }

                            RfNfEntradaBLL.ExecuteSQLInstruction("INSERT INTO " + strTbl + " (" + Cols + ") VALUES (" + Rows + ")");
                        }

                        frm.progressBar1.Value = 0;
                    }

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());
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

                if (gvImportacao2.Rows.Count == 0 || (lblMovimentacoes.Text == "" && cbProcedimento.SelectedIndex == 2))
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (cbProcedimento.Text == "")
                {
                    MessageBox.Show("Escolha um procedimento para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string MsgAlterado = "";
                    if (lblMovimentacoes.Text != "" && cbProcedimento.SelectedIndex == 2) MsgAlterado = "Foi encontrado Registros Alterados.\n";

                    DialogResult myDialogResult = MessageBox.Show(MsgAlterado + "Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_PRODUCAO");

                        string strSQL = @"INSERT INTO RF_PRODUCAO 
                                        (ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF)" + quebraLinha;

                        if (cbProcedimento.SelectedIndex == 1)
                        {
                            strSQL += SQL_SISEPC().Replace("ALERTA, ", "");
                        }
                        else
                        {
                            strSQL += SQL_SISEPC_ALTERADO().Replace("ALERTA, ID_IMPORTACAO, ", "ID_IMPORTACAO, ").Replace("-> ", "");
                        }

                        RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                        gvImportacao.DataSource = null;
                        gvImportacao2.DataSource = null;
                        lblMovimentacoes.Text = "";
                        MessageBox.Show("Transferência Organização (TJ) Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
