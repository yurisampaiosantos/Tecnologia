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
    public partial class frmNftAlteradas : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmNftAlteradas()
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
                        vg.ID_IMPORTACAO,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        DECODE(vg.COD_FORNECEDOR, tl.COD_FORNECEDOR, '', '-> ') || vg.COD_FORNECEDOR COD_FORNECEDOR,
                        DECODE(vg.DATA, tl.DATA, '', '-> ') || vg.DATA DATA,
                        vg.DATA_GER_LEG,
                        DECODE(vg.DOC_CONTROLE, tl.DOC_CONTROLE, '', '-> ') || vg.DOC_CONTROLE DOC_CONTROLE,
                        DECODE(vg.ID_CORPORATIVO, tl.ID_CORPORATIVO, '', '-> ') || vg.ID_CORPORATIVO ID_CORPORATIVO,
                        DECODE(vg.NF_T, tl.NF_T, '', '-> ') || vg.NF_T NF_T,
                        DECODE(vg.NUM_ITEM, tl.NUM_ITEM, '', '-> ') || vg.NUM_ITEM NUM_ITEM,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE QTDE,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                        vg.SEGMENTO5,
                        DECODE(vg.SERIE_T, tl.SERIE_T, '', '-> ') || vg.SERIE_T SERIE_T,
                        DECODE(vg.TIPO_DESTINACAO, tl.TIPO_DESTINACAO, '', '-> ') || vg.TIPO_DESTINACAO TIPO_DESTINACAO,
                        DECODE(vg.TIPO_NF, tl.TIPO_NF, '', '-> ') || vg.TIPO_NF TIPO_NF,
                        DECODE(vg.VALOR_FISCAL, tl.VALOR_FISCAL, '', '-> ') || vg.VALOR_FISCAL VALOR_FISCAL,
                        DECODE(vg.CFOP, tl.CFOP, '', '-> ') || vg.CFOP CFOP,
                        DECODE(vg.REF_ERP_ENT, tl.REF_ERP_ENT, '', '-> ') || vg.REF_ERP_ENT REF_ERP_ENT,
                        vg.AMBIENTE
                    FROM 
                        V_NF_TRANSF_REPLAT_GERAL vg, 
                        V_NF_TRANSF_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.COD_FORNECEDOR || '-' || vg.DATA || '-' || vg.DOC_CONTROLE || '-' || vg.ID_CORPORATIVO || '-' || vg.NF_T || '-' || vg.NUM_ITEM || '-' || vg.ORGANIZACAO || '-' || vg.PART_NUMBER || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.SERIE_T || '-' || vg.TIPO_DESTINACAO || '-' || vg.TIPO_NF || '-' || vg.VALOR_FISCAL || '-' || vg.CFOP || '-' || vg.REF_ERP_ENT
                            <>
                            tl.ID_REF || '-' || tl.COD_FORNECEDOR || '-' || tl.DATA || '-' || tl.DOC_CONTROLE || '-' || tl.ID_CORPORATIVO || '-' || tl.NF_T || '-' || tl.NUM_ITEM || '-' || tl.ORGANIZACAO || '-' || tl.PART_NUMBER || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.SERIE_T || '-' || tl.TIPO_DESTINACAO || '-' || tl.TIPO_NF || '-' || tl.VALOR_FISCAL || '-' || tl.CFOP || '-' || tl.REF_ERP_ENT";
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.COD_LOCATION, tl.COD_LOCATION, '', '-> ') || vg.COD_LOCATION COD_LOCATION,
                        DECODE(vg.COD_TIPO_ORDER, tl.COD_TIPO_ORDER, '', '-> ') || vg.COD_TIPO_ORDER COD_TIPO_ORDER,
                        DECODE(vg.COEFICIENTE, tl.COEFICIENTE, '', '-> ') || vg.COEFICIENTE COEFICIENTE,
                        DECODE(vg.DATA, tl.DATA, '', '-> ') || vg.DATA DATA,
                        vg.DATA_GER_LEG,
                        DECODE(vg.NUM_DOC, tl.NUM_DOC, '', '-> ') || vg.NUM_DOC NUM_DOC,
                        DECODE(vg.NUM_ORDER, tl.NUM_ORDER, '', '-> ') || vg.NUM_ORDER NUM_ORDER,
                        DECODE(vg.ORDEM, tl.ORDEM, '', '-> ') || vg.ORDEM ORDEM,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.ORGANIZACAO_PN_ALTERNATIVO, tl.ORGANIZACAO_PN_ALTERNATIVO, '', '-> ') || vg.ORGANIZACAO_PN_ALTERNATIVO ORGANIZACAO_PN_ALTERNATIVO,
                        DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                        DECODE(vg.PN_ALTERNATIVO_REF, tl.PN_ALTERNATIVO_REF, '', '-> ') || vg.PN_ALTERNATIVO_REF PN_ALTERNATIVO_REF,
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE QTDE,
                        DECODE(vg.REFERENCIA, tl.REFERENCIA, '', '-> ') || vg.REFERENCIA REFERENCIA,
                        DECODE(vg.REF_NFE, tl.REF_NFE, '', '-> ') || vg.REF_NFE REF_NFE,
                        DECODE(vg.REF_OPR, tl.REF_OPR, '', '-> ') || vg.REF_OPR REF_OPR,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                        vg.SEGMENTO5,
                        DECODE(vg.TIPO_MOV, tl.TIPO_MOV, '', '-> ') || vg.TIPO_MOV TIPO_MOV,
                        DECODE(vg.TIPO_TRANS, tl.TIPO_TRANS, '', '-> ') || vg.TIPO_TRANS TIPO_TRANS,
                        DECODE(vg.NUM_CONTRATO, tl.NUM_CONTRATO, '', '-> ') || vg.NUM_CONTRATO NUM_CONTRATO,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        vg.AMBIENTE
                    FROM 
                        V_ROMANEIO_REPLAT_GERAL vg, 
                        V_ROMANEIO_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.COD_LOCATION || '-' || vg.COD_TIPO_ORDER || '-' || vg.COEFICIENTE || '-' || vg.DATA || '-' || vg.NUM_DOC || '-' || vg.NUM_ORDER || '-' || vg.ORDEM || '-' || vg.ORGANIZACAO || '-' || vg.ORGANIZACAO_PN_ALTERNATIVO || '-' || vg.PART_NUMBER || '-' || vg.PN_ALTERNATIVO_REF || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.REFERENCIA || '-' || vg.REF_NFE || '-' || vg.REF_OPR || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.TIPO_MOV || '-' || vg.TIPO_TRANS || '-' || vg.NUM_CONTRATO
                            <>
                            tl.ID_REF || '-' || tl.COD_LOCATION || '-' || tl.COD_TIPO_ORDER || '-' || tl.COEFICIENTE || '-' || tl.DATA || '-' || tl.NUM_DOC || '-' || tl.NUM_ORDER || '-' || tl.ORDEM || '-' || tl.ORGANIZACAO || '-' || tl.ORGANIZACAO_PN_ALTERNATIVO || '-' || tl.PART_NUMBER || '-' || tl.PN_ALTERNATIVO_REF || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.REFERENCIA || '-' || tl.REF_NFE || '-' || tl.REF_OPR || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.TIPO_MOV || '-' || tl.TIPO_TRANS || '-' || tl.NUM_CONTRATO";
        }

        public string SQL_RTM()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.EMPRESA, tl.EMPRESA, '', '-> ') || vg.EMPRESA EMPRESA,
                        DECODE(vg.IDENTIFICACAO_RTM, tl.IDENTIFICACAO_RTM, '', '-> ') || vg.IDENTIFICACAO_RTM IDENTIFICACAO_RTM,
                        DECODE(vg.PARCEIRO_TRANSFERENCIA, tl.PARCEIRO_TRANSFERENCIA, '', '-> ') || vg.PARCEIRO_TRANSFERENCIA PARCEIRO_TRANSFERENCIA,
                        DECODE(vg.ITEM, tl.ITEM, '', '-> ') || vg.ITEM ITEM,
                        DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                        DECODE(vg.NUM_SERIE, tl.NUM_SERIE, '', '-> ') || vg.NUM_SERIE NUM_SERIE,
                        DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE QTDE,
                        DECODE(vg.TIPO_RTM, tl.TIPO_RTM, '', '-> ') || vg.TIPO_RTM TIPO_RTM,
                        DECODE(vg.TIPO_DOCUMENTO, tl.TIPO_DOCUMENTO, '', '-> ') || vg.TIPO_DOCUMENTO TIPO_DOCUMENTO,
                        DECODE(vg.NUM_DOCUMENTO, tl.NUM_DOCUMENTO, '', '-> ') || vg.NUM_DOCUMENTO NUM_DOCUMENTO,
                        DECODE(vg.SERIE_DOCUMENTO, tl.SERIE_DOCUMENTO, '', '-> ') || vg.SERIE_DOCUMENTO SERIE_DOCUMENTO,
                        DECODE(vg.DATA_DOCUMENTO, tl.DATA_DOCUMENTO, '', '-> ') || vg.DATA_DOCUMENTO DATA_DOCUMENTO,
                        DECODE(vg.NUM_ITEM_DOCUMENTO, tl.NUM_ITEM_DOCUMENTO, '', '-> ') || vg.NUM_ITEM_DOCUMENTO NUM_ITEM_DOCUMENTO,
                        DECODE(vg.NUM_ADICAO_DOCUMENTO, tl.NUM_ADICAO_DOCUMENTO, '', '-> ') || vg.NUM_ADICAO_DOCUMENTO NUM_ADICAO_DOCUMENTO,
                        DECODE(vg.NUM_OP, tl.NUM_OP, '', '-> ') || vg.NUM_OP NUM_OP,
                        DECODE(vg.NUM_OS, tl.NUM_OS, '', '-> ') || vg.NUM_OS NUM_OS,
                        DECODE(vg.ESTORNO, tl.ESTORNO, '', '-> ') || vg.ESTORNO ESTORNO,
                        DECODE(vg.DATA_TRANSFERENCIA, tl.DATA_TRANSFERENCIA, '', '-> ') || vg.DATA_TRANSFERENCIA DATA_TRANSFERENCIA,
                        DECODE(vg.FINALIDADE_RTM, tl.FINALIDADE_RTM, '', '-> ') || vg.FINALIDADE_RTM FINALIDADE_RTM,
                        vg.DATA_GER_LEG,
                        vg.AMBIENTE
                    FROM 
                        V_RTM_REPLAT_GERAL vg, 
                        V_RTM_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ORGANIZACAO || '-' || vg.EMPRESA || '-' || vg.IDENTIFICACAO_RTM || '-' || vg.PARCEIRO_TRANSFERENCIA || '-' || vg.ITEM || '-' || vg.PART_NUMBER || '-' || vg.NUM_SERIE || '-' || vg.QTDE || '-' || vg.TIPO_RTM || '-' || vg.TIPO_DOCUMENTO || '-' || vg.NUM_DOCUMENTO || '-' || vg.SERIE_DOCUMENTO || '-' || vg.DATA_DOCUMENTO || '-' || vg.NUM_ITEM_DOCUMENTO || '-' || vg.NUM_ADICAO_DOCUMENTO || '-' || vg.NUM_OP || '-' || vg.NUM_OS || '-' || vg.ESTORNO || '-' || vg.DATA_TRANSFERENCIA || '-' || vg.FINALIDADE_RTM
                            <>
                            tl.ORGANIZACAO || '-' || tl.EMPRESA || '-' || tl.IDENTIFICACAO_RTM || '-' || tl.PARCEIRO_TRANSFERENCIA || '-' || tl.ITEM || '-' || tl.PART_NUMBER || '-' || tl.NUM_SERIE || '-' || tl.QTDE || '-' || tl.TIPO_RTM || '-' || tl.TIPO_DOCUMENTO || '-' || tl.NUM_DOCUMENTO || '-' || tl.SERIE_DOCUMENTO || '-' || tl.DATA_DOCUMENTO || '-' || tl.NUM_ITEM_DOCUMENTO || '-' || tl.NUM_ADICAO_DOCUMENTO || '-' || tl.NUM_OP || '-' || tl.NUM_OS || '-' || tl.ESTORNO || '-' || tl.DATA_TRANSFERENCIA || '-' || tl.FINALIDADE_RTM";
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
                    frm.progressBar1.Maximum = 6;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    gvImportacao.DataSource = RfNfEntradaBLL.Select(SQL());

                    bool linhaAlterada;
                    qtdeAlterado = 0;
                    for (int o = 0; o < gvImportacao.Rows.Count; o++)
                    {
                        linhaAlterada = false;

                        for (int j = 0; j < gvImportacao.Columns.Count; j++)
                        {
                            if (gvImportacao[j, o].Value.ToString().IndexOf("-> ") > -1)
                            {
                                gvImportacao[j, o].Value = gvImportacao[j, o].Value.ToString().Replace("-> ", "");
                                gvImportacao[j, o].Style.BackColor = Color.Yellow;
                                gvImportacao[j, o].Style.ForeColor = Color.Red;

                                if (gvImportacao.Columns[j].Name == "COD_FORNECEDOR" ||
                                    gvImportacao.Columns[j].Name == "DATA" ||
                                    gvImportacao.Columns[j].Name == "NF_T" ||
                                    gvImportacao.Columns[j].Name == "NUM_ITEM" ||
                                    gvImportacao.Columns[j].Name == "ORGANIZACAO" ||
                                    gvImportacao.Columns[j].Name == "PART_NUMBER" ||
                                    gvImportacao.Columns[j].Name == "SERIE_T" ||
                                    gvImportacao.Columns[j].Name == "REF_ERP_ENT"
                                ) linhaAlterada = true;
                            }
                        }

                        if (linhaAlterada == true) qtdeAlterado += 1;
                    }

                    lblNfEntrada.Text = (qtdeAlterado > 0) ? "NF com chave alterada: " + qtdeAlterado : "";

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    TabPage t2 = tabControl1.TabPages[1];
                    tabControl1.SelectedTab = t2;

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_MOV());

                    for (int o = 0; o < gvImportacao2.Rows.Count; o++)
                    {
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

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao2.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    TabPage t3 = tabControl1.TabPages[2];
                    tabControl1.SelectedTab = t3;

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    gvImportacao3.DataSource = RfNfEntradaBLL.Select(SQL_RTM());

                    for (int o = 0; o < gvImportacao3.Rows.Count; o++)
                    {
                        for (int j = 0; j < gvImportacao3.Columns.Count; j++)
                        {
                            if (gvImportacao3[j, o].Value.ToString().IndexOf("-> ") > -1)
                            {
                                gvImportacao3[j, o].Value = gvImportacao3[j, o].Value.ToString().Replace("-> ", "");
                                gvImportacao3[j, o].Style.BackColor = Color.Yellow;
                                gvImportacao3[j, o].Style.ForeColor = Color.Red;
                            }
                        }
                    }

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao3.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                 //

                    TabPage t1 = tabControl1.TabPages[0];
                    tabControl1.SelectedTab = t1;

                    frm.progressBar1.PerformStep();                                                                                                                 //

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

                        for (int o = 0; o < gvImportacao3.Rows.Count; o++)
                        {
                            for (int j = 0; j < gvImportacao3.Columns.Count; j++)
                            {
                                if (gvImportacao3[j, o].Style.BackColor == Color.Yellow)
                                {
                                    ws3.Cells[o + 2, j + 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                                    ws3.Cells[o + 2, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws3.Cells[o + 2, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
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

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_NF_TRANSF_TERC");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RL_RTM");

                            string strSQL = @"INSERT INTO RF_NF_TRANSF_TERC
                                            (ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA, DATA_GER_LEG, DOC_CONTROLE, ID_CORPORATIVO, NF_T, NUM_ITEM, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SERIE_T, TIPO_DESTINACAO, TIPO_NF, VALOR_FISCAL, CFOP, REF_ERP_ENT, AMBIENTE)" + quebraLinha;
                            strSQL += SQL().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES
                                       (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RL_RTM
                                        (ID_IMPORTACAO, ORGANIZACAO, EMPRESA, IDENTIFICACAO_RTM, PARCEIRO_TRANSFERENCIA, ITEM, PART_NUMBER, NUM_SERIE, QTDE, TIPO_RTM, TIPO_DOCUMENTO, NUM_DOCUMENTO, SERIE_DOCUMENTO, DATA_DOCUMENTO, NUM_ITEM_DOCUMENTO, NUM_ADICAO_DOCUMENTO, NUM_OP, NUM_OS, ESTORNO, DATA_TRANSFERENCIA, FINALIDADE_RTM, DATA_GER_LEG, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_RTM().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            gvImportacao3.DataSource = null;
                            lblNfEntrada.Text = "";
                            MessageBox.Show("NFT, Movimentações e RTM Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
