using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;
using DTO;
using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Replat
{
    public partial class frmNemGeral : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmNemGeral()
        {
            InitializeComponent();
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

                gvImportacao.DataSource = CarregaSQL();

                lblRegistros.Text = "Registros: " + gvImportacao.Rows.Count;

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable CarregaSQL()
        {
            string SQL = @"SELECT
                                FORNECEDOR,
                                RAZAO_SOCIAL,
                                CNPJ,
                                NOFI_ID,
                                NOFI_SERIE,
                                NOFI_NUMERO,
                                TO_CHAR(NOFI_DT_EMISSAO, 'DD/MM/YY') NOFI_DT_EMISSAO,
                                TO_CHAR(NOFI_DT_RECEBIMENTO, 'DD/MM/YY') NOFI_DT_RECEBIMENTO,
                                TO_CHAR(NOFI_DT_RECEBIMENTO_SUP, 'DD/MM/YY') NOFI_DT_RECEBIMENTO_SUP,
                                NOFI_VALOR_TOTAL,
                                NOFI_RECEBIMENTO_DIRETO,
                                NOFI_PESO_TOTAL,
                                NOFI_REFERENCIA,
                                NOFI_OBS,
                                NFIT_ID,
                                NFIT_QTD,
                                NFIT_VLR_UNIT,
                                NFIT_DESTINO,
                                NFIT_OBS,
                                NOEN_ID,
                                NOEN_NUMERO,
                                TO_CHAR(NOEN_DT_EMISSAO, 'DD/MM/YY') NOEN_DT_EMISSAO,
                                TO_CHAR(NOEN_DT_INSPECAO, 'DD/MM/YY') NOEN_DT_INSPECAO,
                                NOEN_EMITIDO,
                                NOEN_ETQ_EMITIDO,
                                NOEN_PROCEDIMENTO,
                                NOEN_OBS,
                                TO_CHAR(NOEN_DT_CADASTRO, 'DD/MM/YY') NOEN_DT_CADASTRO,
                                NOEN_ORIGEM,
                                NOEI_ID,
                                NOEI_ITEM,
                                NOEI_QTD_NEM,
                                NOEI_CERTIFICADO,
                                NOEI_LOCALIZADOR,
                                NOEI_QTD_DIV,
                                NOEI_PROBLEMA,
                                NOEI_ACAO_SITUACAO,
                                TO_CHAR(NOEI_DT_SOLUCAO, 'DD/MM/YY') NOEI_DT_SOLUCAO,
                                NOEI_SOLUCAO,
                                NOEI_OBS,
                                TO_CHAR(NOEI_DT_EXPIRACAO, 'DD/MM/YY') NOEI_DT_EXPIRACAO,
                                NOEI_ITEM_DIV,
                                NOEI_TERCEIRO,
                                NOEI_RESPONSAVEL_SOLUCAO,
                                TO_CHAR(NOEI_DT_PREV_SOLUCAO, 'DD/MM/YY') NOEI_DT_PREV_SOLUCAO,
                                NOEI_RASTREABILIDADE,
                                DIPR_ID,
                                DIPR_COD,
                                PART_NUMBER,
                                DIPR_DIM1,
                                DIPR_DIM2,
                                DIPR_DIM3,
                                DIPR_DIMENSOES,
                                DIPR_TIPO_DICIONARIO,
                                DIPR_PESO,
                                DIPR_AREA,
                                DIPR_VOLUME,
                                DIPR_OBS,
                                TO_CHAR(DIPR_DT_CADASTRO, 'DD/MM/YY') DIPR_DT_CADASTRO,
                                DIPR_TOLERANCIA,
                                DIPR_MATERIAL_OBRIG,
                                DIPR_CONTROLA_CERTIFICADO,
                                DIPR_CONTROLA_LOCALIZADOR,
                                DIPR_CONTROLA_SERIE,
                                DIPP_PACOTE,
                                DIPU_CODIGO,
                                DIPU_DIM1,
                                DIPU_DIM2,
                                DIPU_DIM3,
                                DIPC_CODIGO,
                                DIPC_DIM1,
                                DIPC_DIM2,
                                DIPC_DIM3,
                                NOCM_CODIGO,
                                NOCM_DESCRICAO,
                                CFOP_CODIGO,
                                CFOP_DESCRICAO,
                                DIPI_DESCRICAO_RES,
                                DIPI_DESCRICAO_COMPL,
                                AUFO_ID,
                                AUFO_NUMERO,
                                AUFO_REV,
                                TO_CHAR(AUFO_DT_EMISSAO, 'DD/MM/YY') AUFO_DT_EMISSAO,
                                TO_CHAR(AUFO_DT_INICIO_PRAZO, 'DD/MM/YY') AUFO_DT_INICIO_PRAZO,
                                AUFO_MOTIVO_REV,
                                AUFO_EMITIDO,
                                AUFO_CAMBIO,
                                AUFO_CAMBIO_ORC,
                                AUFO_OBS,
                                TO_CHAR(AUFO_DT_CADASTRO, 'DD/MM/YY') AUFO_DT_CADASTRO,
                                AUFO_EXPORTADO,
                                AUFO_CTRL_PARCELA,
                                AFIT_ITEM,
                                AFIT_CLASSIF_FISCAL,
                                AFIT_QTD_TOTAL,
                                AFIT_OBS,
                                AFIT_ORIGEM,
                                RPAF_TIPO,
                                RPAF_ITEM,
                                RPAF_DOCUMENTO,
                                RPAF_QTD_TOTAL,
                                REPI_ITEM,
                                REPI_QTD_TOTAL,
                                TO_CHAR(REPI_DT_NECESSIDADE, 'DD/MM/YY') REPI_DT_NECESSIDADE,
                                REPI_OBS,
                                TO_CHAR(REPI_DT_CADASTRO, 'DD/MM/YY') REPI_DT_CADASTRO,
                                REPI_ESCOPO_COMPRA,
                                REPL_NUMERO,
                                REPL_REV,
                                TO_CHAR(REPL_DT_EMISSAO, 'DD/MM/YY') REPL_DT_EMISSAO,
                                TO_CHAR(REPL_DT_RECEBIMENTO, 'DD/MM/YY') REPL_DT_RECEBIMENTO,
                                REPL_OBS,
                                ARES_SIGLA,
                                ARES_NOME,
                                ARES_ENCERRADO,
                                ARES_EXTERNA,
                                ARES_BLOQUEADA_CORR,
                                ARES_WBS,
                                ARES_WBS_ORDEM,
                                ARES_ORDEM,
                                ARES_NIVEL,
                                ARES_REJEITADO,
                                EMPR_NOME,
                                EMPR_RAZAO_SOCIAL,
                                EMPR_ENDERECO,
                                EMPR_BAIRRO,
                                EMPR_CIDADE,
                                EMPR_CEP,
                                EMPR_FONE1,
                                EMPR_FONE2,
                                EMPR_FONE3,
                                EMPR_FAX,
                                EMPR_SITE,
                                EMPR_CODIGO,
                                EMPR_BANCO,
                                EMPR_AGENCIA,
                                EMPR_CONTA,
                                EMPR_STATUS,
                                EMPR_INSCRICAO_ESTADUAL,
                                EMPR_INSCRICAO_MUNICIPAL,
                                EMPR_FORMA_CADASTRO_QTD,
                                EMPR_OBS,
                                TO_CHAR(EMPR_DT_CADASTRO, 'DD/MM/YY') EMPR_DT_CADASTRO,
                                DCMN_NUMERO,
                                DCMN_NUMERO_CLIENTE,
                                DCMN_NUMERO_AUXILIAR,
                                DCMN_TITULO,
                                DCMN_OBS,
                                TO_CHAR(DCMN_DT_CADASTRO, 'DD/MM/YY') DCMN_DT_CADASTRO,
                                DCMN_QTD_PREV,
                                DCMN_QTD_REAL,
                                DCTP_SIGLA,
                                DCTP_NOME,
                                DCTP_TIPO_LISTA,
                                DCTP_FIXA,
                                SBCN_SIGLA SBCN_SIGLA_NFE,
                                SBCN_SIGLA_NEM,
                                DISC_SIGLA,
                                DISC_NOME,
                                DISC_FIXA,
                                UNPR_SIGLA,
                                UNPR_NOME,
                                ARAP_SIGLA,
                                ARAP_NOME,
                                DCRV_REV,
                                TO_CHAR(DCRV_DT_EMISSAO, 'DD/MM/YY') DCRV_DT_EMISSAO,
                                TO_CHAR(DCRV_DT_RECEBIMENTO, 'DD/MM/YY') DCRV_DT_RECEBIMENTO,
                                DCRV_OBS,
                                TO_CHAR(DCRV_DT_CADASTRO, 'DD/MM/YY') DCRV_DT_CADASTRO,
                                DCPR_SIGLA,
                                DCPR_NOME,
                                DCPR_PESO,
                                REPR_NUMERO,
                                REPR_NUMERO_CLIENTE,
                                REPR_NUMERO_AUXILIAR,
                                REPR_REV,
                                TO_CHAR(REPR_DT_EMISSAO, 'DD/MM/YY') REPR_DT_EMISSAO,
                                TO_CHAR(REPR_DT_RECEBIMENTO, 'DD/MM/YY') REPR_DT_RECEBIMENTO,
                                REPR_FORMA_CADASTRO_QTD,
                                REPR_ACAO,
                                REPR_ESCOPO_COMPRA,
                                REPR_TIPO_DICIONARIO,
                                REPR_OBS,
                                COMP_NOME,
                                COMP_FONE1,
                                COMP_FONE2,
                                COMP_EMAIL,
                                UNME_SIGLA,
                                UNME_NOME,
                                UNME_SOMENTE_INT,
                                UNME_PLANO_CORTE,
                                SPEC_SIGLA,
                                SPEC_DESCRICAO,
                                AFIR_QTD,
                                AFIR_VALOR_UNITARIO,
                                AFIR_DESCONTO,
                                AFIR_OBS,
                                AFIP_PRAZO,
                                AFIC_CONTRATUAL,
                                AFPR_PREVISTA,
                                CPIT_QTD_TOTAL,
                                TO_CHAR(CPIT_DT_ALTERADO_SISTEMA, 'DD/MM/YY') CPIT_DT_ALTERADO_SISTEMA,
                                CPIT_OBS,
                                COPR_NUMERO,
                                COPR_REV,
                                TO_CHAR(COPR_DT_EMISSAO, 'DD/MM/YY') COPR_DT_EMISSAO,
                                TO_CHAR(COPR_DT_VENCIMENTO, 'DD/MM/YY') COPR_DT_VENCIMENTO,
                                COPR_EMITIDO,
                                COPR_STATUS,
                                COPR_ANALISE_TEC,
                                COPR_DESCRICAO,
                                COPR_OBS,
                                TO_CHAR(COPR_DT_CADASTRO, 'DD/MM/YY') COPR_DT_CADASTRO,
                                DVRE_NUMERO,
                                TO_CHAR(DVRE_DT_EMISSAO, 'DD/MM/YY') DVRE_DT_EMISSAO,
                                DVRE_OBS,
                                DIRT_NOME,
                                INSP_NOME,
                                TO_CHAR(INSP_ADMISSAO, 'DD/MM/YY') INSP_ADMISSAO,
                                TO_CHAR(INSP_DEMISSAO, 'DD/MM/YY') INSP_DEMISSAO,
                                INSP_TEL_FIXO,
                                INSP_TEL_CELULAR,
                                INSP_SENHA,
                                INSP_HI_LO,
                                INSP_HI_LO_CERT,
                                INSP_CALIBRE,
                                INSP_CALIBRE_CERT,
                                INSP_TRENA,
                                INSP_TRENA_CERT,
                                INSP_ESQUADRO,
                                INSP_ESQUADRO_CERT,
                                INSP_NIVEL,
                                INSP_NIVEL_CERT,
                                INSP_INST_COMPLEMENTAR,
                                INSP_INST_COMPLEMENTAR_CERT,
                                DPLO_ORIGEM_TIPO,
                                DPLO_CERTIFICADO,
                                DPLO_LOCALIZADOR,
                                DPLO_NUMERO_SERIE,
                                TO_CHAR(DPLO_DT_EXPIRACAO, 'DD/MM/YY') DPLO_DT_EXPIRACAO
                            FROM 
                                V_NEM_ITEM";

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL);

            return dtConsulta;
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
                    string folderPath = "C:\\temp\\" + this.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.Name);                         //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                        ws.View.FreezePanes(2, 1);
                        //ws.Cells.AutoFitColumns();
                        //ws.Cells["A1"].Value = this.Text;

                        using (ExcelRange rng = ws.Cells[1, 1, 1, gvImportacao.Columns.Count])              //Adiciona um pouco de estilo
                        {
                            rng.Style.Font.Bold = true;
                            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 129, 189));
                            rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                        }

                        pck.Save();

                        Process.Start(folderPath);
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
