﻿using System;
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
    public partial class frmEntradaFabricado : Form
    {
        string quebraLinha = Environment.NewLine;

        public frmEntradaFabricado()
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
                                DIPR_ID,
                                DIPR_COD,
                                FSES_ID,
                                FSES_TIPO_MOVIMENTO,
                                FSES_FSEM_ID,
                                FSES_DT_EMISSAO,
                                FSES_RESPONSAVEL,
                                FSES_DISC_ID,
                                FSES_OBS,
                                FSES_STATUS,
                                FSEI_ID,
                                FSEI_ARES_ID,
                                FSEI_FSES_ID,
                                FSEI_OBS,
                                FSEI_FSIT_ID,
                                FSEI_QTD,
                                FSEI_DPLO_ID,
                                SBCN_SIGLA,
                                ARES_NOME
                            FROM 
                                V_ENTRADA_PRODUTO_FABRICADO";

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

        private void LocalizaTexto()
        {
            try
            {
                bool encontrado = false;
                int colAtual = gvImportacao.CurrentCell.ColumnIndex;
                int linAtual = gvImportacao.CurrentCell.RowIndex;
                int proximaLinha = gvImportacao.CurrentCell.RowIndex + 1;
                string txtBusca = txtLocalizar.Text.ToUpper();
                string valorAtual;

                proximaLinha = (proximaLinha == gvImportacao.Rows.Count) ? 0 : proximaLinha;

                for (int o = proximaLinha; o < gvImportacao.Rows.Count; o++)
                {
                    valorAtual = gvImportacao[colAtual, o].Value.ToString().ToUpper();

                    //if (gvImportacao[colAtual, o].Value.ToString().ToUpper() == txtLocalizar.Text.ToUpper())
                    if (valorAtual.IndexOf(txtBusca) > -1)
                    {
                        gvImportacao.CurrentCell = gvImportacao.Rows[o].Cells[colAtual];

                        encontrado = true;
                        break;
                    }
                }

                if (encontrado == false)
                {
                    for (int o = 0; o <= linAtual; o++)
                    {
                        valorAtual = gvImportacao[colAtual, o].Value.ToString().ToUpper();

                        if (valorAtual.IndexOf(txtBusca) > -1)
                        {
                            gvImportacao.CurrentCell = gvImportacao.Rows[o].Cells[colAtual];
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void txtLocalizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LocalizaTexto();
            }
        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            try
            {
                LocalizaTexto();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
