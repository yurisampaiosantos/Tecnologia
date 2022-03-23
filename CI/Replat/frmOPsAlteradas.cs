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
    public partial class frmOPsAlteradas : Form
    {
        string quebraLinha = Environment.NewLine;
        public int qtdeAlterado = 0;

        public frmOPsAlteradas()
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

        private void frmOPsAlteradas_Load(object sender, EventArgs e)
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

                DataTable dtConsulta = new DataTable(); 
                dtConsulta = RfNfEntradaBLL.CarregaProdutos(dtpDe.Checked, dtpDe.Text, dtpAte.Checked, dtpAte.Text, cbSubContrato.Text, cbSubContrato.SelectedValue.ToString(), cbDisciplina.Text, cbDisciplina.SelectedValue.ToString());

                if (dtConsulta.Rows.Count == 0)
                {
                    CarregaGeral();
                }
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Foram Encontrados " + dtConsulta.Rows.Count + " Produtos Fabricados não Cadastrados. \n\nDeseja Realmente Continuar com o Processo?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        CarregaGeral();
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
                for (int o = 0; o < gvImportacao.Rows.Count; o++)
                {
                    for (int j = 0; j < gvImportacao.Columns.Count; j++)
                    {
                        if (gvImportacao[j, o].Value.ToString().IndexOf("-> ") > -1)
                        {
                            gvImportacao[j, o].Value = gvImportacao[j, o].Value.ToString().Replace("-> ", "");
                            gvImportacao[j, o].Style.BackColor = Color.Yellow;
                            gvImportacao[j, o].Style.ForeColor = Color.Red;
                        }
                    }
                }

                //Não deixar ordenar na coluna
                foreach (DataGridViewColumn coluna in gvImportacao.Columns)
                    coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t1 = tabControl1.TabPages[1];
                tabControl1.SelectedTab = t1;
                gvImportacao2.DataSource = CarregaMOV();
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

                TabPage t2 = tabControl1.TabPages[2];
                tabControl1.SelectedTab = t2;
                gvImportacao3.DataSource = CarregaEtapa();
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

                frm.progressBar1.PerformStep();                                                                                                                     //

                TabPage t3 = tabControl1.TabPages[3];
                tabControl1.SelectedTab = t3;
                gvImportacao4.DataSource = CarregaCompModelos();
                for (int o = 0; o < gvImportacao4.Rows.Count; o++)
                {
                    for (int j = 0; j < gvImportacao4.Columns.Count; j++)
                    {
                        if (gvImportacao4[j, o].Value.ToString().IndexOf("-> ") > -1)
                        {
                            gvImportacao4[j, o].Value = gvImportacao4[j, o].Value.ToString().Replace("-> ", "");
                            gvImportacao4[j, o].Style.BackColor = Color.Yellow;
                            gvImportacao4[j, o].Style.ForeColor = Color.Red;
                        }
                    }
                }

                //Não deixar ordenar na coluna
                foreach (DataGridViewColumn coluna in gvImportacao4.Columns)
                    coluna.SortMode = DataGridViewColumnSortMode.NotSortable;

                TabPage t0 = tabControl1.TabPages[0];
                tabControl1.SelectedTab = t0;

                frm.progressBar1.PerformStep();                                                                                                                     //
                frm.progressBar1.Value = 0;                                                                                                                         //--
            }
        }

        public string SQL_OP()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
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
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        vg.AMBIENTE
                    FROM 
                        RF_PRODUCAO_TEMP vg, 
                        V_OP_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ORGANIZACAO || '-' || vg.PART_NUMBER || '-' || vg.QTDE || '-' || vg.NUM_ORDEM || '-' || vg.TIPO_MOV || '-' || vg.TIPO_TRANS || '-' || vg.COD_LOCATION || '-' || vg.DATA || '-' || vg.DIRECIONADA || '-' || vg.REF_NFS || '-' || vg.DATA_REFERENCIA || '-' || vg.VERSAO || '-' || vg.COD_TIPO_OP || '-' || vg.DATA_CONCLUSAO || '-' || vg.ENCOMENDANTE || '-' || vg.DESCRICAO_SERVICO || '-' || vg.DOC_ORIGEM || '-' || vg.IDENTIFICADOR || '-' || vg.REF_NFE || '-' || vg.PROCEDENCIA_INFO || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.REF_OPR || '-' || vg.ALTA_PARCIAL || '-' || vg.NUM_RTM || '-' || vg.TEMPO_EXECUCAO || '-' || vg.DESIGNACAO_ETAPA || '-' || vg.ID_REF
                            <>
                            tl.ORGANIZACAO || '-' || tl.PART_NUMBER || '-' || tl.QTDE || '-' || tl.NUM_ORDEM || '-' || tl.TIPO_MOV || '-' || tl.TIPO_TRANS || '-' || tl.COD_LOCATION || '-' || tl.DATA || '-' || tl.DIRECIONADA || '-' || tl.REF_NFS || '-' || tl.DATA_REFERENCIA || '-' || tl.VERSAO || '-' || tl.COD_TIPO_OP || '-' || tl.DATA_CONCLUSAO || '-' || tl.ENCOMENDANTE || '-' || tl.DESCRICAO_SERVICO || '-' || tl.DOC_ORIGEM || '-' || tl.IDENTIFICADOR || '-' || tl.REF_NFE || '-' || tl.PROCEDENCIA_INFO || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.REF_OPR || '-' || tl.ALTA_PARCIAL || '-' || tl.NUM_RTM || '-' || tl.TEMPO_EXECUCAO || '-' || tl.DESIGNACAO_ETAPA || '-' || tl.ID_REF";
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
                        RF_MOVIMENTACOES_TEMP vg, 
                        V_APLICACAO_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.COD_LOCATION || '-' || vg.COD_TIPO_ORDER || '-' || vg.COEFICIENTE || '-' || vg.DATA || '-' || vg.NUM_DOC || '-' || vg.NUM_ORDER || '-' || vg.ORDEM || '-' || vg.ORGANIZACAO || '-' || vg.ORGANIZACAO_PN_ALTERNATIVO || '-' || vg.PART_NUMBER || '-' || vg.PN_ALTERNATIVO_REF || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE || '-' || vg.REFERENCIA || '-' || vg.REF_NFE || '-' || vg.REF_OPR || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.TIPO_MOV || '-' || vg.TIPO_TRANS || '-' || vg.NUM_CONTRATO
                            <>
                            tl.ID_REF || '-' || tl.COD_LOCATION || '-' || tl.COD_TIPO_ORDER || '-' || tl.COEFICIENTE || '-' || tl.DATA || '-' || tl.NUM_DOC || '-' || tl.NUM_ORDER || '-' || tl.ORDEM || '-' || tl.ORGANIZACAO || '-' || tl.ORGANIZACAO_PN_ALTERNATIVO || '-' || tl.PART_NUMBER || '-' || tl.PN_ALTERNATIVO_REF || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE || '-' || tl.REFERENCIA || '-' || tl.REF_NFE || '-' || tl.REF_OPR || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.TIPO_MOV || '-' || tl.TIPO_TRANS || '-' || tl.NUM_CONTRATO";
        }

        public string SQL_ETAPA()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.DESIGNACAO_ETAPA, tl.DESIGNACAO_ETAPA, '', '-> ') || vg.DESIGNACAO_ETAPA DESIGNACAO_ETAPA,
                        DECODE(vg.ESTORNO, tl.ESTORNO, '', '-> ') || vg.ESTORNO ESTORNO,
                        DECODE(vg.NUM_ORDEM, tl.NUM_ORDEM, '', '-> ') || vg.NUM_ORDEM NUM_ORDEM,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.QTDE, tl.QTDE, '', '-> ') || vg.QTDE QTDE,
                        DECODE(vg.COD_PROC_INDUSTR, tl.COD_PROC_INDUSTR, '', '-> ') || vg.COD_PROC_INDUSTR COD_PROC_INDUSTR,
                        DECODE(vg.TIPO_TRANS, tl.TIPO_TRANS, '', '-> ') || vg.TIPO_TRANS TIPO_TRANS,
                        DECODE(vg.TEMPO_EXECUCAO, tl.TEMPO_EXECUCAO, '', '-> ') || vg.TEMPO_EXECUCAO TEMPO_EXECUCAO,
                        vg.DATA_GER_LEG,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        vg.AMBIENTE
                    FROM 
                        V_ETAPA_OP_REPLAT_GERAL vg, 
                        V_ETAPA_OP_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.DESIGNACAO_ETAPA || '-' || vg.ESTORNO || '-' || vg.NUM_ORDEM || '-' || vg.ORGANIZACAO || '-' || vg.QTDE || '-' || vg.COD_PROC_INDUSTR || '-' || vg.TIPO_TRANS || '-' || vg.TEMPO_EXECUCAO
                            <>
                            tl.ID_REF || '-' || tl.DESIGNACAO_ETAPA || '-' || tl.ESTORNO || '-' || tl.NUM_ORDEM || '-' || tl.ORGANIZACAO || '-' || tl.QTDE || '-' || tl.COD_PROC_INDUSTR || '-' || tl.TIPO_TRANS || '-' || tl.TEMPO_EXECUCAO
                        AND DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
                        " + ((cbSubContrato.Text != "(Todos)") ? "AND FOSE_SBCN_ID = " + cbSubContrato.SelectedValue : "") + @"
                        " + ((cbDisciplina.Text != "(Todas)") ? "AND DISC_ID = " + cbDisciplina.SelectedValue : "");
        }

        public string SQL_COMP()
        {
            return @"SELECT 
                        vg.ID_IMPORTACAO,
                        DECODE(vg.COEF_UTILIZ, tl.COEF_UTILIZ, '', '-> ') || vg.COEF_UTILIZ COEF_UTILIZ,
                        DECODE(vg.DATA_ATUALIZACAO, tl.DATA_ATUALIZACAO, '', '-> ') || vg.DATA_ATUALIZACAO DATA_ATUALIZACAO,
                        DECODE(vg.DATA_FIM, tl.DATA_FIM, '', '-> ') || vg.DATA_FIM DATA_FIM,
                        vg.DATA_GER_LEG,
                        DECODE(vg.DATA_INICIO, tl.DATA_INICIO, '', '-> ') || vg.DATA_INICIO DATA_INICIO,
                        DECODE(vg.ESTIMATIVA_PERDA, tl.ESTIMATIVA_PERDA, '', '-> ') || vg.ESTIMATIVA_PERDA ESTIMATIVA_PERDA,
                        DECODE(vg.ID_CORPORATIVO, tl.ID_CORPORATIVO, '', '-> ') || vg.ID_CORPORATIVO ID_CORPORATIVO,
                        DECODE(vg.JUSTIFICATIVA_PERDA, tl.JUSTIFICATIVA_PERDA, '', '-> ') || vg.JUSTIFICATIVA_PERDA JUSTIFICATIVA_PERDA,
                        DECODE(vg.OBRIGATORIO, tl.OBRIGATORIO, '', '-> ') || vg.OBRIGATORIO OBRIGATORIO,
                        DECODE(vg.ORGANIZACAO, tl.ORGANIZACAO, '', '-> ') || vg.ORGANIZACAO ORGANIZACAO,
                        DECODE(vg.PHANTOM, tl.PHANTOM, '', '-> ') || vg.PHANTOM PHANTOM,
                        DECODE(vg.PN_ALTERNATIVO_REF, tl.PN_ALTERNATIVO_REF, '', '-> ') || vg.PN_ALTERNATIVO_REF PN_ALTERNATIVO_REF,
                        DECODE(vg.PN_FILHO, tl.PN_FILHO, '', '-> ') || vg.PN_FILHO PN_FILHO,
                        DECODE(vg.PN_PAI, tl.PN_PAI, '', '-> ') || vg.PN_PAI PN_PAI,
                        DECODE(vg.PROCEDENCIA_INFO, tl.PROCEDENCIA_INFO, '', '-> ') || vg.PROCEDENCIA_INFO PROCEDENCIA_INFO,
                        DECODE(vg.QTDE_ITENS_COMPOSICAO, tl.QTDE_ITENS_COMPOSICAO, '', '-> ') || vg.QTDE_ITENS_COMPOSICAO QTDE_ITENS_COMPOSICAO,
                        DECODE(vg.QTDE_MAX, tl.QTDE_MAX, '', '-> ') || vg.QTDE_MAX QTDE_MAX,
                        DECODE(vg.QTDE_MIM, tl.QTDE_MIM, '', '-> ') || vg.QTDE_MIM QTDE_MIM,
                        DECODE(vg.SEGMENTO1, tl.SEGMENTO1, '', '-> ') || vg.SEGMENTO1 SEGMENTO1,
                        DECODE(vg.SEGMENTO2, tl.SEGMENTO2, '', '-> ') || vg.SEGMENTO2 SEGMENTO2,
                        DECODE(vg.SEGMENTO3, tl.SEGMENTO3, '', '-> ') || vg.SEGMENTO3 SEGMENTO3,
                        DECODE(vg.SEGMENTO4, tl.SEGMENTO4, '', '-> ') || vg.SEGMENTO4 SEGMENTO4,
                        vg.SEGMENTO5,
                        DECODE(vg.VERSAO, tl.VERSAO, '', '-> ') || vg.VERSAO VERSAO,
                        DECODE(vg.ID_REF, tl.ID_REF, '', '-> ') || vg.ID_REF ID_REF,
                        vg.AMBIENTE
                    FROM 
                        V_COMP_MODELOS_REPLAT_GERAL vg, 
                        V_COMP_MODELOS_LOG_MAX tl
                    WHERE
                            vg.ID_IMPORTACAO = tl.ID_IMPORTACAO 
                        AND vg.ID_REF || '-' || vg.COEF_UTILIZ || '-' || vg.DATA_ATUALIZACAO || '-' || vg.DATA_FIM || '-' || vg.DATA_INICIO || '-' || vg.ESTIMATIVA_PERDA || '-' || vg.ID_CORPORATIVO || '-' || vg.JUSTIFICATIVA_PERDA || '-' || vg.OBRIGATORIO || '-' || vg.ORGANIZACAO || '-' || vg.PHANTOM || '-' || vg.PN_ALTERNATIVO_REF || '-' || vg.PN_FILHO || '-' || vg.PN_PAI || '-' || vg.PROCEDENCIA_INFO || '-' || vg.QTDE_ITENS_COMPOSICAO || '-' || vg.QTDE_MAX || '-' || vg.QTDE_MIM || '-' || vg.SEGMENTO1 || '-' || vg.SEGMENTO2 || '-' || vg.SEGMENTO3 || '-' || vg.SEGMENTO4 || '-' || vg.VERSAO
                            <>
                            tl.ID_REF || '-' || tl.COEF_UTILIZ || '-' || tl.DATA_ATUALIZACAO || '-' || tl.DATA_FIM || '-' || tl.DATA_INICIO || '-' || tl.ESTIMATIVA_PERDA || '-' || tl.ID_CORPORATIVO || '-' || tl.JUSTIFICATIVA_PERDA || '-' || tl.OBRIGATORIO || '-' || tl.ORGANIZACAO || '-' || tl.PHANTOM || '-' || tl.PN_ALTERNATIVO_REF || '-' || tl.PN_FILHO || '-' || tl.PN_PAI || '-' || tl.PROCEDENCIA_INFO || '-' || tl.QTDE_ITENS_COMPOSICAO || '-' || tl.QTDE_MAX || '-' || tl.QTDE_MIM || '-' || tl.SEGMENTO1 || '-' || tl.SEGMENTO2 || '-' || tl.SEGMENTO3 || '-' || tl.SEGMENTO4 || '-' || tl.VERSAO
                        AND DATA_FILTRO BETWEEN TO_DATE('" + ((dtpDe.Checked == false) ? "01/01/1800" : dtpDe.Text) + @"', 'DD/MM/YY') AND TO_DATE('" + ((dtpAte.Checked == false) ? "31/12/2099" : dtpAte.Text) + @"', 'DD/MM/YY')
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
                    frm.progressBar1.Maximum = 4;
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

                        for (int o = 0; o < gvImportacao4.Rows.Count; o++)
                        {
                            for (int j = 0; j < gvImportacao4.Columns.Count; j++)
                            {
                                if (gvImportacao4[j, o].Style.BackColor == Color.Yellow)
                                {
                                    ws4.Cells[o + 2, j + 1].Style.Font.Color.SetColor(System.Drawing.Color.Red);
                                    ws4.Cells[o + 2, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                    ws4.Cells[o + 2, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
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
                            strSQL += SQL_OP().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_MOVIMENTACOES 
                                            (ID_IMPORTACAO, COD_LOCATION, COD_TIPO_ORDER, COEFICIENTE, DATA, DATA_GER_LEG, NUM_DOC, NUM_ORDER, ORDEM, ORGANIZACAO, ORGANIZACAO_PN_ALTERNATIVO, 
                                            PART_NUMBER, PN_ALTERNATIVO_REF, PROCEDENCIA_INFO, QTDE, REFERENCIA, REF_NFE, REF_OPR, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, TIPO_MOV, TIPO_TRANS, NUM_CONTRATO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_MOV().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RL_ETAPA_OP 
                                            (ID_IMPORTACAO, DESIGNACAO_ETAPA, ESTORNO, NUM_ORDEM, ORGANIZACAO, QTDE, COD_PROC_INDUSTR, TIPO_TRANS, TEMPO_EXECUCAO, DATA_GER_LEG, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_ETAPA().Replace("-> ", "");

                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            strSQL = @"INSERT INTO RF_COMPOSICAO_DE_MODELOS
                                            (ID_IMPORTACAO, COEF_UTILIZ, DATA_ATUALIZACAO, DATA_FIM, DATA_GER_LEG, DATA_INICIO, ESTIMATIVA_PERDA, ID_CORPORATIVO, JUSTIFICATIVA_PERDA, OBRIGATORIO, 
                                            ORGANIZACAO, PHANTOM, PN_ALTERNATIVO_REF, PN_FILHO, PN_PAI, PROCEDENCIA_INFO, QTDE_ITENS_COMPOSICAO, QTDE_MAX, QTDE_MIM, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, VERSAO, ID_REF, AMBIENTE)" + quebraLinha;
                            strSQL += SQL_COMP().Replace("-> ", "");

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
