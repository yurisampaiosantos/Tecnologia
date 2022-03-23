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
    public partial class frmProdutosAlterados : Form
    {
        string quebraLinha = Environment.NewLine;
        const string aspas = "\"";
        public string strFiltro = "";
        public int qtdeAlterado = 0;

        public frmProdutosAlterados()
        {
            InitializeComponent();
        }

        public string SQL()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO, 
                        DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        DECODE(vg.ALIQUOTA_ICMS, tl.ALIQUOTA_ICMS, '', '-> ') || vg.ALIQUOTA_ICMS ALIQUOTA_ICMS,
                        DECODE(vg.DATA_FIM, tl.DATA_FIM, '', '-> ') || vg.DATA_FIM DATA_FIM,
                        vg.DATA_GER_LEG, 
                        DECODE(vg.NCM, tl.NCM, '', '-> ') || vg.NCM NCM,
                        DECODE(vg.PESO, tl.PESO, '', '-> ') || vg.PESO PESO,
                        DECODE(vg.DATA_INICIO, tl.DATA_INICIO, '', '-> ') || vg.DATA_INICIO DATA_INICIO,
                        DECODE(vg.DIF_PESO_EMB, tl.DIF_PESO_EMB, '', '-> ') || vg.DIF_PESO_EMB DIF_PESO_EMB,
                        DECODE(vg.FATOR_CONVERSAO, tl.FATOR_CONVERSAO, '', '-> ') || vg.FATOR_CONVERSAO FATOR_CONVERSAO,
                        vg.ID_CORPORATIVO, 
                        DECODE(vg.II, tl.II, '', '-> ') || vg.II II,
                        DECODE(vg.IPI, tl.IPI, '', '-> ') || vg.IPI IPI,
                        DECODE(vg.ITEM_PRODUTIVO_RC, tl.ITEM_PRODUTIVO_RC, '', '-> ') || vg.ITEM_PRODUTIVO_RC ITEM_PRODUTIVO_RC,
                        DECODE(vg.MODELO, tl.MODELO, '', '-> ') || vg.MODELO MODELO,
                        DECODE(vg.NALADINCCA, tl.NALADINCCA, '', '-> ') || vg.NALADINCCA NALADINCCA,
                        DECODE(vg.NALADISH, tl.NALADISH, '', '-> ') || vg.NALADISH NALADISH,
                        DECODE(vg.NUM_EX_II, tl.NUM_EX_II, '', '-> ') || vg.NUM_EX_II NUM_EX_II,
                        DECODE(vg.NUM_EX_IPI, tl.NUM_EX_IPI, '', '-> ') || vg.NUM_EX_IPI NUM_EX_IPI,
                        vg.ORGANIZACAO, 
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        DECODE(vg.REDUCAO_ICMS, tl.REDUCAO_ICMS, '', '-> ') || vg.REDUCAO_ICMS REDUCAO_ICMS,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO10, tl.SEGMENTO10, '', '-> ') || vg.SEGMENTO10 SEGMENTO10,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                        DECODE(vg.SEGMENTO5, tl.SEGMENTO5, '', '-> ') || vg.SEGMENTO5 SEGMENTO5,
                        DECODE(vg.SEGMENTO6, tl.SEGMENTO6, '', '-> ') || vg.SEGMENTO6 SEGMENTO6,
                        DECODE(vg.SEGMENTO7, tl.SEGMENTO7, '', '-> ') || vg.SEGMENTO7 SEGMENTO7,
                        DECODE(vg.SEGMENTO8, tl.SEGMENTO8, '', '-> ') || vg.SEGMENTO8 SEGMENTO8,
                        DECODE(vg.SEGMENTO9, tl.SEGMENTO9, '', '-> ') || vg.SEGMENTO9 SEGMENTO9,
                        DECODE(vg.TIPO_EMBALAGEM, tl.TIPO_EMBALAGEM, '', '-> ') || vg.TIPO_EMBALAGEM TIPO_EMBALAGEM,
                        DECODE(vg.TIPO_PROD, tl.TIPO_PROD, '', '-> ') || vg.TIPO_PROD TIPO_PROD,
                        DECODE(vg.UNIDADE, tl.UNIDADE, '', '-> ') || vg.UNIDADE UNIDADE,
                        DECODE(vg.UNIDADE_COMERCIAL, tl.UNIDADE_COMERCIAL, '', '-> ') || vg.UNIDADE_COMERCIAL UNIDADE_COMERCIAL,
                        DECODE(vg.UNIDADE_FRACIONADA, tl.UNIDADE_FRACIONADA, '', '-> ') || vg.UNIDADE_FRACIONADA UNIDADE_FRACIONADA,
                        vg.ID_IMPORTACAO_REAL,
                        vg.AMBIENTE
                    FROM 
                        RF_PRODUTO_TEMP vg, 
                        (SELECT 
                                tl.*
                            FROM 
                                (SELECT l.* FROM RF_PRODUTO_LOG l, CI_AMBIENTE a WHERE l.AMBIENTE = a.AMBIENTE) tl,
                                V_PRODUTO_LOG_MAX tl2
                            WHERE
                                    tl.ID_IMPORTACAO = tl2.ID_IMPORTACAO
                                AND tl.ORGANIZACAO = tl2.ORGANIZACAO
                                AND tl.DATA_GER_LEG = tl2.DATA_GER_LEG) tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO
                        AND vg.ORGANIZACAO = tl.ORGANIZACAO
                        AND vg.ID_REF || '-' || vg.ALIQUOTA_ICMS || '-' || vg.DATA_FIM || '-' || vg.DATA_INICIO || '-' || vg.DIF_PESO_EMB || '-' || vg.FATOR_CONVERSAO || '-' || vg.II || '-' || vg.IPI || '-' || vg.ITEM_PRODUTIVO_RC || '-' || vg.MODELO || '-' || vg.NALADINCCA || '-' || vg.NALADISH || '-' || vg.NCM || '-' || vg.NUM_EX_II || '-' || vg.NUM_EX_IPI || '-' || vg.PART_NUMBER || '-' || vg.PESO || '-' || vg.PROCEDENCIA_INFO || '-' || vg.REDUCAO_ICMS || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO10 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.SEGMENTO5 || '-' || vg.SEGMENTO6 || '-' || vg.SEGMENTO7 || '-' || vg.SEGMENTO8 || '-' || vg.SEGMENTO9 || '-' || vg.TIPO_EMBALAGEM || '-' || vg.TIPO_PROD || '-' || vg.UNIDADE || '-' || vg.UNIDADE_COMERCIAL || '-' || vg.UNIDADE_FRACIONADA
                            <>
                            tl.ID_REF || '-' || tl.ALIQUOTA_ICMS || '-' || tl.DATA_FIM || '-' || tl.DATA_INICIO || '-' || tl.DIF_PESO_EMB || '-' || tl.FATOR_CONVERSAO || '-' || tl.II || '-' || tl.IPI || '-' || tl.ITEM_PRODUTIVO_RC || '-' || tl.MODELO || '-' || tl.NALADINCCA || '-' || tl.NALADISH || '-' || tl.NCM || '-' || tl.NUM_EX_II || '-' || tl.NUM_EX_IPI || '-' || tl.PART_NUMBER || '-' || tl.PESO || '-' || tl.PROCEDENCIA_INFO || '-' || tl.REDUCAO_ICMS || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO10 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.SEGMENTO5 || '-' || tl.SEGMENTO6 || '-' || tl.SEGMENTO7 || '-' || tl.SEGMENTO8 || '-' || tl.SEGMENTO9 || '-' || tl.TIPO_EMBALAGEM || '-' || tl.TIPO_PROD || '-' || tl.UNIDADE || '-' || tl.UNIDADE_COMERCIAL || '-' || tl.UNIDADE_FRACIONADA";
        }

        public string SQL_DESCR()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        DECODE(vg.DESCRICAO, tl.DESCRICAO, '', '-> ') || vg.DESCRICAO DESCRICAO,
                        DECODE(vg.DESCRICAO_DETALHADA, tl.DESCRICAO_DETALHADA, '', '-> ') || vg.DESCRICAO_DETALHADA DESCRICAO_DETALHADA,
                        DECODE(vg.NOME_COMERCIAL, tl.NOME_COMERCIAL, '', '-> ') || vg.NOME_COMERCIAL NOME_COMERCIAL,
                        vg.ORGANIZACAO,
                        DECODE(vg.PART_NUMBER, tl.PART_NUMBER, '', '-> ') || vg.PART_NUMBER PART_NUMBER,
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        vg.ID_IMPORTACAO_REAL, vg.AMBIENTE
                    FROM 
                        RF_DESCRICAO_PRODUTO_TEMP vg, 
                        (SELECT 
                              tl.*
                          FROM 
                              (SELECT l.* FROM RF_DESCRICAO_PRODUTO_LOG l, CI_AMBIENTE a WHERE l.AMBIENTE = a.AMBIENTE) tl,
                              V_DESCRICAO_LOG_MAX tl2
                          WHERE
                                  tl.ID_IMPORTACAO = tl2.ID_IMPORTACAO
                              AND tl.ORGANIZACAO = tl2.ORGANIZACAO
                              AND tl.DATA_GER_LEG = tl2.DATA_GER_LEG) tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO
                        AND vg.ORGANIZACAO = tl.ORGANIZACAO
                        AND vg.ID_REF || '-' || vg.DESCRICAO || '-' || vg.DESCRICAO_DETALHADA || '-' || vg.NOME_COMERCIAL || '-' || vg.PART_NUMBER || '-' || vg.PROCEDENCIA_INFO
                            <>
                            tl.ID_REF || '-' || tl.DESCRICAO || '-' || tl.DESCRICAO_DETALHADA || '-' || tl.NOME_COMERCIAL || '-' || tl.PART_NUMBER || '-' || tl.PROCEDENCIA_INFO";
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

                        if (gvImportacao2.Rows.Count > 0)
                        {
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
                    if (qtdeAlterado > 0) MsgAlterado = "Foi encontrado PART_NUMBER Alterado.\n";

                    DialogResult myDialogResult = MessageBox.Show(MsgAlterado + "Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            MDIParent1 frm = this.MdiParent as MDIParent1;
                            frm.progressBar1.Maximum = 2;
                            frm.progressBar1.PerformStep();                                                                                                                     //

                            string strSQL = @"TRUNCATE TABLE RF_PRODUTO";
                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
                        
                            strSQL = @"INSERT INTO RF_PRODUTO
                                            (ID_IMPORTACAO, PART_NUMBER, ID_REF, ALIQUOTA_ICMS, DATA_FIM, DATA_GER_LEG, NCM, PESO, DATA_INICIO, DIF_PESO_EMB, FATOR_CONVERSAO, ID_CORPORATIVO, II, IPI, ITEM_PRODUTIVO_RC, MODELO, NALADINCCA, NALADISH, NUM_EX_II, NUM_EX_IPI, ORGANIZACAO, PROCEDENCIA_INFO, REDUCAO_ICMS, SEGMENTO1, SEGMENTO10, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SEGMENTO6, SEGMENTO7, SEGMENTO8, SEGMENTO9, TIPO_EMBALAGEM, TIPO_PROD, UNIDADE, UNIDADE_COMERCIAL, UNIDADE_FRACIONADA, ID_IMPORTACAO_REAL, AMBIENTE)" + quebraLinha;
                            strSQL += SQL().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            strSQL = @"TRUNCATE TABLE RF_DESCRICAO_PRODUTO";
                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_DESCRICAO_PRODUTO
                                       (ID_IMPORTACAO, ID_REF, DESCRICAO, DESCRICAO_DETALHADA, NOME_COMERCIAL, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, ID_IMPORTACAO_REAL, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_DESCR().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            lblAlterados.Text = "";

                            frm.progressBar1.Value = 0;                                                                                                                         //--

                            MessageBox.Show("Produtos e Descrição de Produtos Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                this.Cursor = Cursors.WaitCursor;
                
                frmAmbiente frm2 = new frmAmbiente();
                frm2.TipoBt = "Gerar";
                frm2.ShowDialog();

                if (RfNfEntradaBLL.strAmbiente != "")
                {
                    this.Cursor = Cursors.WaitCursor;

                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = 4;
                    frm.progressBar1.PerformStep();                                                                                                                     //

                    PrepararProduto();
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

                                if (j == 1) qtdeAlterado += 1;
                            }
                        }
                    }

                    lblAlterados.Text = (qtdeAlterado > 0) ? "PART_NUMBER Alterado: " + qtdeAlterado : "";

                    //Não deixar ordenar na coluna
                    foreach (DataGridViewColumn coluna in gvImportacao.Columns)
                        coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                    frm.progressBar1.PerformStep();                                                                                                                     //

                    TabPage t2 = tabControl1.TabPages[1];
                    tabControl1.SelectedTab = t2;

                    PrepararDescricao();
                    frm.progressBar1.PerformStep();

                    gvImportacao2.DataSource = RfNfEntradaBLL.Select(SQL_DESCR());

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

        private void PrepararProduto()
        {
            string strSQL = @"TRUNCATE TABLE RF_PRODUTO_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_PRODUTO_TEMP
                            (ID_IMPORTACAO, ID_REF, ALIQUOTA_ICMS, DATA_FIM, DATA_GER_LEG, DATA_INICIO, DIF_PESO_EMB, FATOR_CONVERSAO, ID_CORPORATIVO, II, IPI, ITEM_PRODUTIVO_RC, MODELO, NALADINCCA, NALADISH, NCM, NUM_EX_II, NUM_EX_IPI, ORGANIZACAO, PART_NUMBER, PESO, PROCEDENCIA_INFO, REDUCAO_ICMS, SEGMENTO1, SEGMENTO10, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SEGMENTO6, SEGMENTO7, SEGMENTO8, SEGMENTO9, TIPO_EMBALAGEM, TIPO_PROD, UNIDADE, UNIDADE_COMERCIAL, UNIDADE_FRACIONADA, ID_IMPORTACAO_REAL, AMBIENTE)
                        SELECT 
                            ID_IMPORTACAO, ID_REF, ALIQUOTA_ICMS, DATA_FIM, DATA_GER_LEG, DATA_INICIO, DIF_PESO_EMB, FATOR_CONVERSAO, ID_CORPORATIVO, II, IPI, ITEM_PRODUTIVO_RC, MODELO, NALADINCCA, NALADISH, NCM, NUM_EX_II, NUM_EX_IPI, ORGANIZACAO, PART_NUMBER, PESO, PROCEDENCIA_INFO, REDUCAO_ICMS, SEGMENTO1, SEGMENTO10, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SEGMENTO6, SEGMENTO7, SEGMENTO8, SEGMENTO9, TIPO_EMBALAGEM, TIPO_PROD, UNIDADE, UNIDADE_COMERCIAL, UNIDADE_FRACIONADA, ID_IMPORTACAO_REAL, AMBIENTE
                        FROM 
                            V_PRODUTO_REPLAT_GERAL";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
        }

        private void PrepararDescricao()
        {
            string strSQL = @"TRUNCATE TABLE RF_DESCRICAO_PRODUTO_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_DESCRICAO_PRODUTO_TEMP
                            (ID_IMPORTACAO, ID_REF, DESCRICAO, DESCRICAO_DETALHADA, NOME_COMERCIAL, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, ID_IMPORTACAO_REAL, AMBIENTE)
                        SELECT 
                            ID_IMPORTACAO, ID_REF, DESCRICAO, DESCRICAO_DETALHADA, NOME_COMERCIAL, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, ID_IMPORTACAO_REAL, AMBIENTE
                        FROM 
                            V_DESCRICAO_REPLAT_GERAL";

            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
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
