using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace SisPLAN.net
{
    public partial class frmProdutividadePorUa : Form
    {
        string quebraLinha = Environment.NewLine;
        string aspas = "\"";

        public frmProdutividadePorUa()
        {
            InitializeComponent();
        }

        private void frmProdutividadePorUa_Load(object sender, EventArgs e)
        {
            dtpDe.MaxDate = DateTime.Now.Date;
            dtpDe.Value = DateTime.Now.Date;

            dtpAte.MaxDate = DateTime.Now.Date;
            dtpAte.MinDate = DateTime.Now.Date;

            string strSQL = @"SELECT 
                                    NULL AS DISC_ID, 
                                    '' AS DISC_NOME 
                                FROM 
                                    DUAL 
                                UNION SELECT DISTINCT 
                                    DISC_ID, DISC_NOME AS DISC_NOME 
                                FROM 
                                    EEP_CONVERSION.DISCIPLINA 
                                WHERE 
                                        DISC_CNTR_CODIGO = 'Conversão' 
                                    AND DISC_ID IN (2,3,4,5,6,9,20) 
                                ORDER BY 
                                    2 NULLS FIRST";

            DataTable dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
            cbDisciplina.DataSource = dtDOC;
            cbDisciplina.DisplayMember = "DISC_NOME";
            cbDisciplina.ValueMember = "DISC_ID";
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            dtpAte.MinDate = dtpDe.Value;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (cbDisciplina.Text == "")
                {
                    MessageBox.Show("O campo 'Disciplina' é de Preenchimento Obrigatório", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string strSQL = ConsultaSQL();

                    DataTable dtDOC = BLL.AcControleFolhaServicoBLL.Select(strSQL);
                    gvDados.DataSource = dtDOC;
                    gvDados.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    gvDados.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ConsultaSQL()
        {
            string strSQL = @"SELECT
                                SBCN_SIGLA AS " + aspas + @"PLAT." + aspas + @",
                                ATVI_TEXTO AS " + aspas + @"RESPONSÁVEL" + aspas + @",
                                UNAC_SIGLA AS " + aspas + @"CÓD UA" + aspas + @",
                                UNAC_NOME AS " + aspas + @"DESCRIÇÃO UA" + aspas + @",
                                REPLACE(ROUND(SUM(EXEC_POND), 3), '.', ',') AS " + aspas + @"EXECUTADO" + aspas + @"
                            FROM
                                (SELECT 
                                    sbcn.SBCN_SIGLA,
                                    fose.FOSE_DISC_ID,
                                    atvi.ATVI_TEXTO,
                                    NVL2(unac.UNAC_SIGLA, unac.UNAC_SIGLA, (SELECT UNAC_SIGLA FROM EPCCQ.UNIDADE_ACOMPANHAMENTO WHERE fose.FOSE_UNAC_ID = UNAC_ID)) AS UNAC_SIGLA,
                                    NVL2(unac.UNAC_SIGLA, unac.UNAC_NOME, (SELECT UNAC_NOME FROM EPCCQ.UNIDADE_ACOMPANHAMENTO WHERE fose.FOSE_UNAC_ID = UNAC_ID)) AS UNAC_NOME,
                                    exma.FSME_FOSM_ID,
                                    fose.FOSE_ID,
                                    fose.FOSE_NUMERO,
                                    fces.FCES_SIGLA,
                                    fces.FCES_NIVEL,
                                    MAX(exma.FSME_DATA) AS FSME_DATA,
                                    fose.FOSE_QTD_PREVISTA,
                                    fces.FCES_PESO_REL_CRON,
                                    ROUND(MAX(exma.FSME_AVANCO_ACM) - NVL(exan.FSME_AVANCO_ACM, 0), 3) AS FSME_AVANCO_ACM,
                                    spuf.FCES_PESO_REL_CRON AS SOMA_PERC,
                                    fose.FOSE_QTD_PREVISTA * ((fces.FCES_PESO_REL_CRON * ROUND(MAX(exma.FSME_AVANCO_ACM) - NVL(exan.FSME_AVANCO_ACM, 0), 3)) / spuf.FCES_PESO_REL_CRON / 100) AS EXEC_POND
                                FROM 
                                    EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC exma,
                                    (SELECT 
                                        FSME_CNTR_CODIGO,
                                        FSME_FOSM_ID,
                                        MAX(FSME_AVANCO_ACM) AS FSME_AVANCO_ACM
                                    FROM 
                                        EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC
                                    WHERE
                                            FSME_CNTR_CODIGO = 'Conversão'
                                        AND FSME_DATA < TO_DATE('" + dtpDe.Text + @"', 'DD/MM/YY')
                                    GROUP BY
                                        FSME_CNTR_CODIGO,
                                        FSME_FOSM_ID) exan,
                                    EPCCQ.FOLHA_SERVICO_MEDICAO fosm,
                                    EPCCQ.FOLHA_SERVICO fose,
                                    EPCCQ.SUB_CONTRATO sbcn,
                                    EPCCQ.ATRIBUTO_VINCULO atvi,
                                    EPCCQ.FOLHA_CRITERIO_ESTRUTURA fces,
                                    EPCCQ.UNIDADE_ACOMPANHAMENTO unac,
                                    EEP_CONVERSION.V_CRITERIO_NIVEL_BAIXO cnba,
                                    EEP_CONVERSION.V_SOMA_PERC_UA_FS spuf
                                WHERE
                                        exma.FSME_CNTR_CODIGO = exan.FSME_CNTR_CODIGO (+)
                                    AND exma.FSME_FOSM_ID = exan.FSME_FOSM_ID (+)
                                    AND exma.FSME_CNTR_CODIGO = fosm.FOSM_CNTR_CODIGO
                                    AND exma.FSME_FOSM_ID = fosm.FOSM_ID
                                    AND exma.FSME_CNTR_CODIGO = fose.FOSE_CNTR_CODIGO
                                    AND fosm.FOSM_FOSE_ID = fose.FOSE_ID
                                    AND exma.FSME_CNTR_CODIGO = fces.FCES_CNTR_CODIGO
                                    AND fosm.FOSM_FCES_ID = fces.FCES_ID
                                    AND fosm.FOSM_CNTR_CODIGO = unac.UNAC_CNTR_CODIGO (+)
                                    AND fosm.FOSM_UNAC_ID = unac.UNAC_ID (+)
                                    AND fosm.FOSM_CNTR_CODIGO = cnba.FCES_CNTR_CODIGO
                                    AND fosm.FOSM_FCES_ID = cnba.FCES_ID
                                    AND fose.FOSE_ID = spuf.FOSE_ID
                                    AND fose.FOSE_CNTR_CODIGO = atvi.ATVI_CNTR_CODIGO (+)
                                    AND fose.FOSE_ID = atvi.ATVI_FOSE_ID (+)
                                    AND fose.FOSE_CNTR_CODIGO = sbcn.SBCN_CNTR_CODIGO
                                    AND fose.FOSE_SBCN_ID = sbcn.SBCN_ID
                                    AND NVL2(unac.UNAC_SIGLA, unac.UNAC_SIGLA, (SELECT UNAC_SIGLA FROM EPCCQ.UNIDADE_ACOMPANHAMENTO WHERE fose.FOSE_UNAC_ID = UNAC_ID)) = spuf.UNAC_SIGLA
                                    AND fces.FCES_SIGLA NOT LIKE '%END%' 
                                    AND fces.FCES_SIGLA NOT LIKE '%CQ%'
                                    AND atvi.ATVI_ATPE_ID = 36
                                    AND (fose.FOSE_UNAC_ID IS NOT NULL OR unac.UNAC_ID IS NOT NULL)
                                    AND fose.FOSE_DISC_ID = " + cbDisciplina.SelectedValue + @"
                                    AND exma.FSME_DATA BETWEEN TO_DATE('" + dtpDe.Text + @"', 'DD/MM/YY') AND TO_DATE('" + dtpAte.Text + @"', 'DD/MM/YY')
                                GROUP BY
                                    sbcn.SBCN_SIGLA,
                                    fose.FOSE_DISC_ID,
                                    atvi.ATVI_TEXTO,
                                    fose.FOSE_UNAC_ID,
                                    unac.UNAC_SIGLA,
                                    unac.UNAC_NOME,
                                    exma.FSME_FOSM_ID,
                                    exan.FSME_AVANCO_ACM,
                                    fose.FOSE_ID,
                                    fose.FOSE_NUMERO,
                                    fose.FOSE_QTD_PREVISTA,
                                    fces.FCES_PESO_REL_CRON,
                                    fces.FCES_SIGLA,
                                    fces.FCES_NIVEL,
                                    spuf.FCES_PESO_REL_CRON)
                            WHERE
                                    EXEC_POND > 0
                                AND FSME_AVANCO_ACM > 0
                            GROUP BY
                                SBCN_SIGLA,
                                ATVI_TEXTO,
                                UNAC_SIGLA,
                                UNAC_NOME
                            ORDER BY
                                SBCN_SIGLA,
                                ATVI_TEXTO,
                                UNAC_SIGLA";
            return strSQL;
        }

        private void btExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (cbDisciplina.Text == "")
                {
                    MessageBox.Show("O campo 'Disciplina' é de Preenchimento Obrigatório", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    object misValue = System.Reflection.Missing.Value;

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    DataTable dtConsulta = new DataTable();
                    dtConsulta = BLL.AcControleFolhaServicoBLL.Select(ConsultaSQL());

                    //Cabeçalho
                    for (int i = 1; i <= dtConsulta.Columns.Count; i++)
                    {
                        WorkSheet.Cells[4, i] = dtConsulta.Columns[i - 1].ColumnName;
                    }

                    //seleção das linhas
                    for (int o = 0; o < dtConsulta.Rows.Count; o++)
                    {
                        //Preenchimento das celulas
                        for (int j = 0; j < dtConsulta.Columns.Count; j++)
                        {
                            WorkSheet.Cells[o + 5, j + 1] = dtConsulta.Rows[o][j].ToString();
                        }
                    }

                    App.Columns.AutoFit();

                    WorkSheet.Cells[1, 1] = "Disciplina: " + cbDisciplina.Text;
                    WorkSheet.Cells[2, 1] = "Produtividade por UA de: " + dtpDe.Text + " a " + dtpAte.Text;

                    App.Visible = true;
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
