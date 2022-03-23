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
    public partial class frmOPsNovas : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmOPsNovas()
        {
            InitializeComponent();
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public DataTable CarregaSBCN()
        {
            string SQL = @"SELECT
                                0 SBCN_ID, '(Todos)' SBCN_NOME
                            FROM
                                DUAL
                            UNION ALL SELECT 
                                SBCN_ID, SBCN_NOME
                            FROM 
                                EPCCQ.SUB_CONTRATO
                            WHERE
                                SBCN_CNTR_CODIGO = 'Conversão'";

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL);

            return dtConsulta;
        }

        public DataTable CarregaDISC()
        {
            string SQL = @"SELECT
                                0 DISC_ID, '(Todas)' DISC_NOME
                            FROM
                                DUAL
                            UNION ALL SELECT 
                                DISC_ID, DISC_NOME
                            FROM 
                                EPCCQ.DISCIPLINA
                            WHERE
                                DISC_CNTR_CODIGO = 'Conversão'";

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL);

            return dtConsulta;
        }

        private void frmOPsNovas_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDe.MaxDate = DateTime.Now.Date;
                dtpDe.Value = DateTime.Now.Date;
                dtpDe.Checked = false;
                dtpAte.Checked = false;

                cbSubContrato.ValueMember = "SBCN_ID";
                cbSubContrato.DisplayMember = "SBCN_NOME";
                cbSubContrato.DataSource = CarregaSBCN();

                cbDisciplina.ValueMember = "DISC_ID";
                cbDisciplina.DisplayMember = "DISC_NOME";
                cbDisciplina.DataSource = CarregaDISC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                //DataTable dtConsulta = new DataTable();
                //dtConsulta = RfNfEntradaBLL.CarregaProdutos(dtpDe.Checked, dtpDe.Text, dtpAte.Checked, dtpAte.Text, cbSubContrato.Text, cbSubContrato.SelectedValue.ToString(), cbDisciplina.Text, cbDisciplina.SelectedValue.ToString());

                //if (dtConsulta.Rows.Count == 0)
                //{
                    CarregaGeral();
                //}
                //else
                //{
                //    MessageBox.Show("Foram Encontrados " + dtConsulta.Rows.Count + " Produtos Fabricados não Cadastrados.\nRegularize e repita o processo", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}

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

        private void CarregaGeral()
        {
            DataTable dtConsulta = new DataTable();
            dtConsulta = PreparaMOV();

            if (dtConsulta.Rows.Count == 0)
            {
                CarregaGrids();
            }
            else
            {
                DialogResult myDialogResult = MessageBox.Show("Foram Encontrados " + dtConsulta.Rows.Count + " Locations Externos ou Inválidos. \n\nDeseja Realmente Continuar com o Processo?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (myDialogResult == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    CarregaGrids();
                }
            }
        }

        private void CarregaGrids()
        {
            frmAmbiente frm2 = new frmAmbiente();
            frm2.TipoBt = "Gerar";
            frm2.ShowDialog();

            if (RfNfEntradaBLL.strAmbiente != "")
            {
                this.Cursor = Cursors.WaitCursor;

                MDIParent1 frm = this.MdiParent as MDIParent1;
                frm.progressBar1.Maximum = 4;                                                                                                                       //
                frm.progressBar1.PerformStep();                                                                                                                     //

                gvImportacao.DataSource = CarregaOPs();

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t1 = tabControl1.TabPages[1];
                tabControl1.SelectedTab = t1;
                gvImportacao2.DataSource = CarregaMOV();

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t2 = tabControl1.TabPages[2];
                tabControl1.SelectedTab = t2;
                gvImportacao3.DataSource = CarregaEtapa();

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t3 = tabControl1.TabPages[3];
                tabControl1.SelectedTab = t3;
                gvImportacao4.DataSource = CarregaCompModelos();

                TabPage t0 = tabControl1.TabPages[0];
                tabControl1.SelectedTab = t0;

                frm.progressBar1.PerformStep();                                                                                                                     //
                frm.progressBar1.Value = 0;                                                                                                                         //--
            }
        }

        public string SQL_OP()
        {
            return @"SELECT 
                        ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                        ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF, AMBIENTE
                     FROM 
                        V_OP_REPLAT";
        }

        public string SQL_MOV()
        {
            return @"SELECT 
                        ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                        PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL, ID_REF, AMBIENTE
                     FROM 
                        V_APLICACAO_REPLAT";
        }

        public string SQL_ETAPA()
        {
            return @"SELECT 
                        ID_IMPORTACAO, DESIGNACAO_ETAPA, ESTORNO, NUM_ORDEM, ORGANIZACAO, QTDE, COD_PROC_INDUSTR, TIPO_TRANS, TEMPO_EXECUCAO, DATA_GER_LEG, ID_REF, AMBIENTE
                     FROM 
                        V_ETAPA_OP_REPLAT
                     WHERE
                            DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                        " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                        " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");
        }

        public string SQL_COMP()
        {
            return @"SELECT 
                        ID_IMPORTACAO, COEF_UTILIZ, DATA_ATUALIZACAO, DATA_FIM, DATA_GER_LEG, DATA_INICIO, ESTIMATIVA_PERDA, ID_CORPORATIVO, JUSTIFICATIVA_PERDA, OBRIGATORIO, 
                        ORGANIZACAO, PHANTOM, PN_ALTERNATIVO_REF, PN_FILHO, PN_PAI, PROCEDENCIA_INFO, QTDE_ITENS_COMPOSICAO, QTDE_MAX, QTDE_MIM, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, VERSAO, ID_REF, AMBIENTE
                     FROM 
                        V_COMP_MODELOS_REPLAT
                     WHERE
                            DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                        " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                        " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");
        }

        public DataTable CarregaOPs()
        {
            string strSQL = @"TRUNCATE TABLE EREPLAT.RF_PRODUCAO_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_PRODUCAO_TEMP 
                            (ID_IMPORTACAO,ID_REF, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                            ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, AMBIENTE)
                        SELECT 
                            opre.ID_IMPORTACAO, opre.ID_REF, opre.ALTA_PARCIAL, opre.COD_LOCATION, opre.COD_TIPO_OP, opre.DATA, opre.DATA_CONCLUSAO, opre.DATA_GER_LEG, opre.DATA_REFERENCIA, opre.DESCRICAO_SERVICO, opre.DIRECIONADA, opre.DOC_ORIGEM, opre.ENCOMENDANTE, opre.IDENTIFICADOR, opre.NUM_DOC, opre.NUM_ORDEM, 
                            opre.ORGANIZACAO, opre.PART_NUMBER, opre.PROCEDENCIA_INFO, opre.QTDE, opre.REF_NFE, opre.REF_NFS, opre.REF_OPR, opre.SEGMENTO1, opre.SEGMENTO2, opre.SEGMENTO3, opre.SEGMENTO4, opre.SEGMENTO5, opre.TIPO_MOV, opre.TIPO_TRANS, opre.VERSAO, opre.TEMPO_EXECUCAO, opre.DESIGNACAO_ETAPA, opre.NUM_RTM, opre.AMBIENTE
                        FROM 
                            EREPLAT.V_OP_REPLAT_GERAL opre
                        WHERE
                                opre.DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                            " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                            " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");

            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL_OP());

            return dtConsulta;
        }

        public DataTable CarregaMOV()
        {
            string strSQL = @"TRUNCATE TABLE EREPLAT.RF_MOVIMENTACOES_TEMP";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO RF_MOVIMENTACOES_TEMP 
                            (ID_IMPORTACAO, ID_REF, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                            PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL, AMBIENTE)
                        SELECT 
                            gera.ID_IMPORTACAO, gera.ID_REF, gera.COD_LOCATION, gera.COD_TIPO_ORDER, gera.COEFICIENTE, gera.DATA, gera.DATA_GER_LEG, gera.NUM_DOC, gera.NUM_ORDER, gera.ORDEM, gera.ORGANIZACAO, gera.ORGANIZACAO_PN_ALTERNATIVO, 
                            PART_NUMBER, gera.PN_ALTERNATIVO_REF, gera.PROCEDENCIA_INFO, gera.QTDE, gera.REFERENCIA, gera.REF_NFE, gera.REF_OPR, gera.SEGMENTO1, gera.SEGMENTO2, gera.SEGMENTO3, gera.SEGMENTO4, gera.SEGMENTO5, gera.TIPO_MOV, gera.TIPO_TRANS, gera.NUM_CONTRATO, gera.ID_IMPORTACAO_REAL, gera.AMBIENTE
                        FROM 
                            EREPLAT.V_APLICACAO_REPLAT_GERAL gera
                        WHERE
                            gera.DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                            " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                            " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");

            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            DataTable dtConsulta2 = new DataTable();
            dtConsulta2 = RfNfEntradaBLL.Select(SQL_MOV());

            return dtConsulta2;
        }

        public DataTable PreparaMOV()
        {
            string strSQL = @"SELECT
                                *
                            FROM 
                                V_APLICACAO_LOCATION
                            WHERE
                                    DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                                " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                                " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");

            DataTable dtConsulta2 = new DataTable();
            dtConsulta2 = RfNfEntradaBLL.Select(strSQL);

            return dtConsulta2;
        }

        public DataTable CarregaEtapa()
        {
            DataTable dtConsulta3 = new DataTable();
            dtConsulta3 = RfNfEntradaBLL.Select(SQL_ETAPA());

            return dtConsulta3;
        }

        public DataTable CarregaCompModelos()
        {
            DataTable dtConsulta4 = new DataTable();
            dtConsulta4 = RfNfEntradaBLL.Select(SQL_COMP());

            return dtConsulta4;
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0 && gvImportacao3.Rows.Count == 0 && gvImportacao4.Rows.Count == 0)
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

                        frm.progressBar1.PerformStep();                                                                                                                     //

                        ExcelWorksheet ws4 = pck.Workbook.Worksheets.Add(tabControl1.TabPages[3].Text);                 //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws4.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao4.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws4.Cells[ws4.Dimension.Address].AutoFilter = true;
                        ws4.View.FreezePanes(2, 1);

                        using (ExcelRange rng4 = ws4.Cells[1, 1, 1, gvImportacao4.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng4.Style.Font.Bold = true;
                            rng4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng4.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng4.Style.Font.Color.SetColor(System.Drawing.Color.White);
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

                if (gvImportacao.Rows.Count == 0 && gvImportacao2.Rows.Count == 0 && gvImportacao3.Rows.Count == 0 && gvImportacao4.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado dados para Enviar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Deseja realmente enviar esses dados?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_PRODUCAO");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_MOVIMENTACOES");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RL_ETAPA_OP");
                            RfNfEntradaBLL.ExecuteSQLInstruction("TRUNCATE TABLE RF_COMPOSICAO_DE_MODELOS");

                            string strSQL = @"INSERT INTO RF_PRODUCAO 
                                            (ID_IMPORTACAO, ALTA_PARCIAL, COD_LOCATION, COD_TIPO_OP, DATA, DATA_CONCLUSAO, DATA_GER_LEG, DATA_REFERENCIA, DESCRICAO_SERVICO, DIRECIONADA, DOC_ORIGEM, ENCOMENDANTE, IDENTIFICADOR, NUM_DOC, NUM_ORDEM,
                                            ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_NFE, REF_NFS, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, VERSAO, TEMPO_EXECUCAO, DESIGNACAO_ETAPA, NUM_RTM, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_OP();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES 
                                            (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                                            PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_IMPORTACAO_REAL, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RL_ETAPA_OP 
                                            (ID_IMPORTACAO, DESIGNACAO_ETAPA, ESTORNO, NUM_ORDEM, ORGANIZACAO, QTDE, COD_PROC_INDUSTR, TIPO_TRANS, TEMPO_EXECUCAO, DATA_GER_LEG, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_ETAPA();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_COMPOSICAO_DE_MODELOS
                                            (ID_IMPORTACAO, COEF_UTILIZ, DATA_ATUALIZACAO, DATA_FIM, DATA_GER_LEG, DATA_INICIO, ESTIMATIVA_PERDA, ID_CORPORATIVO, JUSTIFICATIVA_PERDA, OBRIGATORIO, 
                                            ORGANIZACAO, PHANTOM, PN_ALTERNATIVO_REF, PN_FILHO, PN_PAI, PROCEDENCIA_INFO, QTDE_ITENS_COMPOSICAO, QTDE_MAX, QTDE_MIM, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, VERSAO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_COMP();

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            gvImportacao.DataSource = null;
                            gvImportacao2.DataSource = null;
                            gvImportacao3.DataSource = null;
                            gvImportacao4.DataSource = null;
                            MessageBox.Show("OP's, Movimentações, Etapas e Comp. Modelos Disponíveis no IN-OUT", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
