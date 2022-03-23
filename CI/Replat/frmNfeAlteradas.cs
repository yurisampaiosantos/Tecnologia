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
    public partial class frmNfeAlteradas : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmNfeAlteradas()
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
                        TO_CHAR(DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO) ORGANIZACAO,
                        TO_CHAR(DECODE(vg.COD_FORNECEDOR, tl.COD_FORNECEDOR, '', '-> ') || vg.COD_FORNECEDOR) COD_FORNECEDOR,
                        TO_CHAR(DECODE(vg.NF_E, tl.NF_E, '', '-> ') || vg.NF_E) NF_E,
                        TO_CHAR(DECODE(vg.SERIE_E, tl.SERIE_E, '', '-> ') || vg.SERIE_E) SERIE_E,
                        TO_CHAR(DECODE(vg.NUM_ITEM, tl.NUM_ITEM, '', '-> ') || vg.NUM_ITEM) NUM_ITEM,
                        TO_CHAR(DECODE(vg.DATA_NF, tl.DATA_NF, '', '-> ') || vg.DATA_NF) DATA_NF,
                        TO_CHAR(DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER) PART_NUMBER,
                        TO_CHAR(DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE) QTDE,
                        TO_CHAR(DECODE(vg.REF_ENTRADA, tl.REF_ENTRADA, '', '-> ') || vg.REF_ENTRADA) REF_ENTRADA,
                        TO_CHAR(DECODE(vg.VALOR_FISCAL, tl.VALOR_FISCAL, '', '-> ') || vg.VALOR_FISCAL) VALOR_FISCAL,
                        TO_CHAR(DECODE(vg.NCM, tl.NCM, '', '-> ') || vg.NCM) NCM,
                        TO_CHAR(DECODE(vg.CFOP, tl.CFOP, '', '-> ') || vg.CFOP) CFOP,
                        TO_CHAR(DECODE(vg.DOC_ORIGEM, tl.DOC_ORIGEM, '', '-> ') || vg.DOC_ORIGEM) DOC_ORIGEM,
                        TO_CHAR(DECODE(vg.DATA_DOC, tl.DATA_DOC, '', '-> ') || vg.DATA_DOC) DATA_DOC,
                        TO_CHAR(DECODE(vg.TIPO_ENTRADA, tl.TIPO_ENTRADA, '', '-> ') || vg.TIPO_ENTRADA) TIPO_ENTRADA,
                        TO_CHAR(DECODE(vg.REF_NFE, tl.REF_NFE, '', '-> ') || vg.REF_NFE) REF_NFE,
                        TO_CHAR(DECODE(vg.COD_PROPRIETARIO, tl.COD_PROPRIETARIO, '', '-> ') || vg.COD_PROPRIETARIO) COD_PROPRIETARIO,
                        TO_CHAR(DECODE(vg.REF_BAIXA, tl.REF_BAIXA, '', '-> ') || vg.REF_BAIXA) REF_BAIXA,
                        TO_CHAR(DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO) PROCEDENCIA_INFO,
                        vg.DATA_GER_LEG,
                        TO_CHAR(DECODE(vg.ID_CORPORATIVO, tl.ID_CORPORATIVO, '', '-> ') || vg.ID_CORPORATIVO) ID_CORPORATIVO,
                        TO_CHAR(DECODE(vg.NUM_ADICAO, tl.NUM_ADICAO, '', '-> ') || vg.NUM_ADICAO) NUM_ADICAO,
                        TO_CHAR(DECODE(vg.NUM_ITEM_ADICAO, tl.NUM_ITEM_ADICAO, '', '-> ') || vg.NUM_ITEM_ADICAO) NUM_ITEM_ADICAO,
                        TO_CHAR(DECODE(vg.NUM_DI_CAMBIAL, tl.NUM_DI_CAMBIAL, '', '-> ') || vg.NUM_DI_CAMBIAL) NUM_DI_CAMBIAL,
                        TO_CHAR(DECODE(vg.VCTO_DI_CAMBIAL, tl.VCTO_DI_CAMBIAL, '', '-> ') || vg.VCTO_DI_CAMBIAL) VCTO_DI_CAMBIAL,
                        TO_CHAR(DECODE(vg.DATA_ENTRADA, tl.DATA_ENTRADA, '', '-> ') || vg.DATA_ENTRADA) DATA_ENTRADA,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        vg.SEGMENTO4,
                        vg.SEGMENTO5,
                        TO_CHAR(DECODE(vg.REF_ERP_ENT, tl.REF_ERP_ENT, '', '-> ') || vg.REF_ERP_ENT) REF_ERP_ENT,
                        TO_CHAR(DECODE(vg.FINALIDADE_ENTRADA, tl.FINALIDADE_ENTRADA, '', '-> ') || vg.FINALIDADE_ENTRADA) FINALIDADE_ENTRADA,
                        TO_CHAR(DECODE(vg.NUM_CONTRATO, tl.NUM_CONTRATO, '', '-> ') || vg.NUM_CONTRATO) NUM_CONTRATO,
                        vg.ID_REF,
                        vg.AMBIENTE
                    FROM 
                        V_NF_ENTRADA_REPLAT_GERAL vg, 
                        V_NF_ENTRADA_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.CFOP || '-' || vg.COD_FORNECEDOR || '-' || vg.COD_PROPRIETARIO || '-' || vg.DATA_DOC || '-' || vg.DATA_ENTRADA || '-' || vg.DATA_NF || '-' || vg.DOC_ORIGEM || '-' || vg.NCM || '-' || vg.NF_E || '-' || vg.NUM_ADICAO || '-' || vg.NUM_DI_CAMBIAL || '-' || vg.NUM_ITEM || '-' || vg.NUM_ITEM_ADICAO || '-' || vg.ORGANIZACAO || '-' || vg.PART_NUMBER || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.REF_BAIXA || '-' || vg.REF_ENTRADA || '-' || vg.REF_ERP_ENT || '-' || vg.REF_NFE || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SERIE_E || '-' || vg.TIPO_ENTRADA || '-' || vg.VALOR_FISCAL || '-' || vg.VCTO_DI_CAMBIAL || '-' || vg.NUM_CONTRATO || '-' || vg.FINALIDADE_ENTRADA
                            <>
                            tl.ID_REF || '-' || tl.CFOP || '-' || tl.COD_FORNECEDOR || '-' || tl.COD_PROPRIETARIO || '-' || tl.DATA_DOC || '-' || tl.DATA_ENTRADA || '-' || tl.DATA_NF || '-' || tl.DOC_ORIGEM || '-' || tl.NCM || '-' || tl.NF_E || '-' || tl.NUM_ADICAO || '-' || tl.NUM_DI_CAMBIAL || '-' || tl.NUM_ITEM || '-' || tl.NUM_ITEM_ADICAO || '-' || tl.ORGANIZACAO || '-' || tl.PART_NUMBER || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.REF_BAIXA || '-' || tl.REF_ENTRADA || '-' || tl.REF_ERP_ENT || '-' || tl.REF_NFE || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SERIE_E || '-' || tl.TIPO_ENTRADA || '-' || tl.VALOR_FISCAL || '-' || tl.VCTO_DI_CAMBIAL || '-' || tl.NUM_CONTRATO || '-' || tl.FINALIDADE_ENTRADA
                        " + ((cbTipo.Text != "(Todas)") ? "AND TIPO = '" + cbTipo.Text + "'": "");
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
                        vg.SEGMENTO4,
                        vg.SEGMENTO5,
                        DECODE(vg.TIPO_MOV, tl.TIPO_MOV, '', '-> ') || vg.TIPO_MOV TIPO_MOV,
                        DECODE(vg.TIPO_TRANS, tl.TIPO_TRANS, '', '-> ') || vg.TIPO_TRANS TIPO_TRANS,
                        DECODE(vg.NUM_CONTRATO, tl.NUM_CONTRATO, '', '-> ') || vg.NUM_CONTRATO NUM_CONTRATO,
                        vg.ID_REF,
                        vg.AMBIENTE
                    FROM 
                        V_RECEBIMENTO_REPLAT_GERAL vg, 
                        V_RECEBIMENTO_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.COD_LOCATION || '-' || vg.COD_TIPO_ORDER || '-' || vg.COEFICIENTE || '-' || vg.DATA || '-' || vg.NUM_DOC || '-' || vg.NUM_ORDER || '-' || vg.ORDEM || '-' || vg.ORGANIZACAO || '-' || vg.ORGANIZACAO_PN_ALTERNATIVO || '-' || vg.PART_NUMBER || '-' || vg.PN_ALTERNATIVO_REF || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.REFERENCIA || '-' || vg.REF_NFE || '-' || vg.REF_OPR || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.TIPO_MOV || '-' || vg.TIPO_TRANS || '-' || vg.NUM_CONTRATO
                            <>
                            tl.ID_REF || '-' || tl.COD_LOCATION || '-' || tl.COD_TIPO_ORDER || '-' || tl.COEFICIENTE || '-' || tl.DATA || '-' || tl.NUM_DOC || '-' || tl.NUM_ORDER || '-' || tl.ORDEM || '-' || tl.ORGANIZACAO || '-' || tl.ORGANIZACAO_PN_ALTERNATIVO || '-' || tl.PART_NUMBER || '-' || tl.PN_ALTERNATIVO_REF || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.REFERENCIA || '-' || tl.REF_NFE || '-' || tl.REF_OPR || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.TIPO_MOV || '-' || tl.TIPO_TRANS || '-' || tl.NUM_CONTRATO";
        }

        public string SQL_IMP()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        DECODE(vg.COD_FORNECEDOR, tl.COD_FORNECEDOR, '', '-> ') || vg.COD_FORNECEDOR COD_FORNECEDOR,
                        DECODE(vg.DATA_CONTABIL, tl.DATA_CONTABIL, '', '-> ') || vg.DATA_CONTABIL DATA_CONTABIL,
                        DECODE(vg.DATA_EMISSAO, tl.DATA_EMISSAO, '', '-> ') || vg.DATA_EMISSAO DATA_EMISSAO,
                        vg.INFO_COMPLEMENTARES,
                        DECODE(vg.NF, tl.NF, '', '-> ') || vg.NF NF,
                        DECODE(vg.NUM_ITEM, tl.NUM_ITEM, '', '-> ') || vg.NUM_ITEM NUM_ITEM,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.REF_ERP_ENT, tl.REF_ERP_ENT, '', '-> ') || vg.REF_ERP_ENT REF_ERP_ENT,
                        DECODE(vg.SERIE, tl.SERIE, '', '-> ') || vg.SERIE SERIE,
                        DECODE(vg.SIGLA_IMPOSTO, tl.SIGLA_IMPOSTO, '', '-> ') || vg.SIGLA_IMPOSTO SIGLA_IMPOSTO,
                        DECODE(vg.TIPO_NF, tl.TIPO_NF, '', '-> ') || vg.TIPO_NF TIPO_NF,
                        DECODE(vg.VALOR, tl.VALOR, '', '-> ') || vg.VALOR VALOR,
                        vg.DATA_GER_LEG,
                        vg.AMBIENTE
                    FROM 
                        V_IMPOSTO_GERAL vg, 
                        V_IMPOSTO_LOG_MAX tl
                    WHERE
                            vg.INFO_COMPLEMENTARES = tl.INFO_COMPLEMENTARES 
                        AND vg.ID_REF || '-' || vg.COD_FORNECEDOR || '-' || vg.DATA_CONTABIL || '-' || vg.DATA_EMISSAO || '-' || vg.NF || '-' || vg.NUM_ITEM || '-' || vg.ORGANIZACAO || '-' || vg.REF_ERP_ENT || '-' || vg.SERIE || '-' || vg.SIGLA_IMPOSTO || '-' || vg.TIPO_NF || '-' || vg.VALOR
                            <>
                            tl.ID_REF || '-' || tl.COD_FORNECEDOR || '-' || tl.DATA_CONTABIL || '-' || tl.DATA_EMISSAO || '-' || tl.NF || '-' || tl.NUM_ITEM || '-' || tl.ORGANIZACAO || '-' || tl.REF_ERP_ENT || '-' || tl.SERIE || '-' || tl.SIGLA_IMPOSTO || '-' || tl.TIPO_NF || '-' || tl.VALOR";
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

                                if (gvImportacao.Columns[j].Name == "ORGANIZACAO" ||
                                    gvImportacao.Columns[j].Name == "COD_FORNECEDOR" ||
                                    gvImportacao.Columns[j].Name == "NF_E" ||
                                    gvImportacao.Columns[j].Name == "SERIE_E" ||
                                    gvImportacao.Columns[j].Name == "NUM_ITEM" ||
                                    gvImportacao.Columns[j].Name == "DATA_NF" ||
                                    gvImportacao.Columns[j].Name == "PART_NUMBER" ||
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

                    gvImportacao3.DataSource = RfNfEntradaBLL.Select(SQL_IMP());

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

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_NF_ENTRADA");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_IMPOSTO_CALC");

                            string strSQL = @"INSERT INTO RF_NF_ENTRADA
                                            (ID_IMPORTACAO, ORGANIZACAO, COD_FORNECEDOR, NF_E, SERIE_E, NUM_ITEM, DATA_NF, PART_NUMBER, QTDE, REF_ENTRADA, VALOR_FISCAL, NCM, CFOP, DOC_ORIGEM, DATA_DOC, TIPO_ENTRADA, REF_NFE, COD_PROPRIETARIO, REF_BAIXA, PROCEDENCIA_INFO, DATA_GER_LEG, ID_CORPORATIVO, NUM_ADICAO, NUM_ITEM_ADICAO, NUM_DI_CAMBIAL, VCTO_DI_CAMBIAL, DATA_ENTRADA, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, REF_ERP_ENT, FINALIDADE_ENTRADA, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES
                                       (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_IMPOSTO_CALC
                                        (ID_IMPORTACAO, ID_REF, COD_FORNECEDOR, DATA_CONTABIL, DATA_EMISSAO, INFO_COMPLEMENTARES, NF, NUM_ITEM, ORGANIZACAO, REF_ERP_ENT, SERIE, SIGLA_IMPOSTO, TIPO_NF, VALOR, DATA_GER_LEG, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_IMP().Replace("-> ", "");

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

        private void frmNfeAlteradas_Load(object sender, EventArgs e)
        {
            cbTipo.SelectedIndex = 0;
        }
    }
}
