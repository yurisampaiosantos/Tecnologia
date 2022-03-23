using System;
using System.Net;
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

using Excel = Microsoft.Office.Interop.Excel;

namespace Replat
{
    public partial class frmMiniFIFO : Form
    {
        string strSQL;
        string quebraLinha = Environment.NewLine;
        string erroData = "Data de Movimentação não informada";

        public frmMiniFIFO()
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

        private void PrepararProduto()
        {
            strSQL = @"DELETE FROM CI_MINI_FIFO WHERE MIFI_IP = '" + RfNfEntradaBLL.Ip() + @"'";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

            strSQL = @"INSERT INTO CI_MINI_FIFO
                            (SEQ, DIPR_ID, DIPR_COD, DIPR_DIMENSOES, DESCRICAO_PRODUTO, REFERENCIA, ORGANIZACAO, ORIGEM, QTDE, DATA_MOV, MIFI_IP)
                        SELECT
                            ROW_NUMBER() OVER (PARTITION BY ORDEM ORDER BY DATA_MOV NULLS LAST, ORIGEM) SEQ, DIPR_ID, DIPR_COD, DIPR_DIMENSOES, DESCRICAO_PRODUTO, REFERENCIA, ORGANIZACAO, ORIGEM, QTDE, DATA_MOV, '" + RfNfEntradaBLL.Ip() + @"' MIFI_IP
                        FROM 
                            V_MINI_FIFO
                        WHERE 
                            ORGANIZACAO = '" + cbSubContrato.Text + @"'
                        ORDER BY
                            DIPR_ID, ORGANIZACAO, DATA_MOV, TO_NUMBER(REPLACE(SUBSTR(ORIGEM, 1, 2), '-', '')), SEQ";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
        }

        private void btGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (cbSubContrato.Text == "")
                {
                    MessageBox.Show("Escolha um Sub Contrato para Gerar", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    PrepararProduto();

                    string erroNfe = "NFE sem NEM cadastrada";
                    string erroNem = "NEM sem NFE cadastrada";
                    string erroQtdeNem = "Qtde da NEM diferente da NFE";
                    string erroTrf = "Transf. entre Plataformas maior que o Saldo Atual";
                    string erroNft = "NFT sem Romaneio cadastrado";
                    string erroRom = "Romaneio sem NFT cadastrado";
                    string erroQtdeRom = "Qtde do Romaneio diferente da NFT";
                    string erroApl = "Aplicação maior que o Saldo Atual";
                    string erroNfs = "NFS sem Baixa cadastrada";
                    string erroBax = "Baixa sem NFS cadastrada";
                    string erroQtdeBax = "Qtde da Baixa diferente da NFS";
                    string erroMovSaldo = "Movimentação maior que o Saldo Atual";

                    DataTable dtConsulta = new DataTable();
                    dtConsulta = RfNfEntradaBLL.Select("SELECT DISTINCT DIPR_ID FROM CI_MINI_FIFO WHERE MIFI_IP = '" + RfNfEntradaBLL.Ip() + "' ORDER BY DIPR_ID");

                    DataTable dtConsulta3 = new DataTable();
                    dtConsulta3 = RfNfEntradaBLL.Select(SQL(null, null));

                    int colSeq = NumCol(dtConsulta3, "SEQ");
                    int colDiprId = NumCol(dtConsulta3, "DIPR_ID");
                    int colDiprCod = NumCol(dtConsulta3, "DIPR_COD");
                    int colDiprDimensoes = NumCol(dtConsulta3, "DIPR_DIMENSOES");
                    int colDescricaoProd = NumCol(dtConsulta3, "DESCRICAO_PRODUTO");
                    int colRef = NumCol(dtConsulta3, "REFERENCIA");
                    int colOrganizacao = NumCol(dtConsulta3, "ORGANIZACAO");
                    int colOrigem = NumCol(dtConsulta3, "ORIGEM");
                    int colQtde = NumCol(dtConsulta3, "QTDE");
                    int colDataMov = NumCol(dtConsulta3, "DATA_MOV");

                    MDIParent1 frm = this.MdiParent as MDIParent1;
                    frm.progressBar1.Maximum = dtConsulta.Rows.Count;
                    frm.progressBar1.PerformStep();

                    for (int i = 0; i < dtConsulta.Rows.Count; i++) //Produto
                    {
                        frm.progressBar1.PerformStep();

                        decimal decSaldo = 0;

                        DataTable dtConsulta2 = new DataTable();
                        dtConsulta2 = RfNfEntradaBLL.Select(SQL(dtConsulta.Rows[i][0].ToString(), RfNfEntradaBLL.Ip()));

                        for (int o = 0; o < dtConsulta2.Rows.Count; o++) //Detalhe do Produto
                        {
                            string aviso = "";
                            bool erro = false;
                            decimal decSeq = Convert.ToDecimal(dtConsulta2.Rows[o][colSeq]);
                            decimal decDiprID = Convert.ToDecimal(dtConsulta2.Rows[o][colDiprId]);
                            string strDiprCod = dtConsulta2.Rows[o][colDiprCod].ToString();

                            string strDiprDimensoes = dtConsulta2.Rows[o][colDiprDimensoes].ToString();
                            string strDescricaoProd = dtConsulta2.Rows[o][colDescricaoProd].ToString();
                            string strRef = dtConsulta2.Rows[o][colRef].ToString();
                            string strOrganizacao = dtConsulta2.Rows[o][colOrganizacao].ToString();

                            string strOrigem = dtConsulta2.Rows[o][colOrigem].ToString();
                            decimal decQtde = Convert.ToDecimal(dtConsulta2.Rows[o][colQtde]);

                            string strDataMov = "";
                            if (Convert.ToString(dtConsulta2.Rows[o][colDataMov]) != "")
                            {
                                DateTime dttDataMov = Convert.ToDateTime(dtConsulta2.Rows[o][colDataMov]);
                                strDataMov = dttDataMov.ToString("dd/MM/yyyy");
                            }

                            if (strOrigem == "1-NFE")
                            {
                                decSaldo += decQtde;

                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "2-NEM", true);

                                if (erro)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroNfe + VerificaData(strDataMov)); 
                            }
                            else if (strOrigem == "2-NEM")
                            {
                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "1-NFE", false);

                                if (erro)
                                {
                                    decSaldo += decQtde;

                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroNem + VerificaData(strDataMov)); 
                                } 
                                else
                                {
                                    if (decQtde != Convert.ToDecimal(dtConsulta2.Rows[o - 1][colQtde]))
                                        dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroQtdeNem + VerificaData(strDataMov));
                                }
                            }
                            else if (strOrigem == "5-MOV")
                            {
                                if (decQtde > decSaldo)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroMovSaldo + VerificaData(strDataMov));
                            }
                            else if (strOrigem == "3-FAB" || strOrigem == "4-SUC" || strOrigem == "6-TRF-e")
                            {
                                decSaldo += decQtde;
                            }
                            else if (strOrigem == "7-TRF-s")
                            {
                                decSaldo = decSaldo + (decQtde * (-1));

                                if (decSaldo < 0)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroTrf + VerificaData(strDataMov));
                            }
                            else if (strOrigem == "8-NFT")
                            {
                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "9-ROM", true);

                                if (decQtde > decSaldo) 
                                    aviso = erroMovSaldo + ((erro) ? ", " : "");

                                if (erro || decQtde > decSaldo)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + ((erro) ? erroNft : "") + VerificaData(strDataMov));
                            }
                            else if (strOrigem == "9-ROM")
                            {
                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "8-NFT", false);

                                if (decQtde > decSaldo) 
                                    aviso = erroMovSaldo + ", ";
                            
                                if (erro)
                                {
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + erroRom + VerificaData(strDataMov));
                                }
                                else
                                {
                                    if (decQtde != Convert.ToDecimal(dtConsulta2.Rows[o - 1][colQtde]))
                                    {
                                        dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + erroQtdeRom + VerificaData(strDataMov));
                                    }
                                    else if (decQtde > decSaldo)
                                    {
                                        dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroMovSaldo + VerificaData(strDataMov));
                                    }  
                                }
                            }
                            else if (strOrigem == "10-APL")
                            {
                                decSaldo = decSaldo + (decQtde * (-1));

                                if (decSaldo < 0)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroApl + VerificaData(strDataMov));
                            }
                            else if (strOrigem == "11-NFS")
                            {
                                decSaldo = decSaldo + (decQtde * (-1));

                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "12-BAX", true);

                                if (decSaldo < 0) 
                                    aviso = erroMovSaldo + ((erro) ? ", " : "");

                                if (erro || decSaldo < 0)
                                {
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + ((erro) ? erroNfs : "") + VerificaData(strDataMov));
                                }
                            }
                            else if (strOrigem == "12-BAX")
                            {
                                erro = ErroParOrigem(dtConsulta2, o, colOrigem, "11-NFS", false);

                                if (erro)
                                {
                                    decSaldo = decSaldo + (decQtde * (-1));

                                    if (decSaldo < 0) aviso = erroMovSaldo + ", ";

                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + erroBax + VerificaData(strDataMov));
                                }
                                else
                                {
                                    if (decQtde != Convert.ToDecimal(dtConsulta2.Rows[o - 1][colQtde]))
                                    {
                                        if (decSaldo < 0) aviso = erroMovSaldo + ", ";

                                        dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, aviso + erroQtdeBax + VerificaData(strDataMov));
                                    }
                                    else if (decSaldo < 0)
                                    {
                                        dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroMovSaldo + VerificaData(strDataMov));
                                    }
                                }
                            }

                            if (strDataMov == "")
                            {
                                erro = false;

                                if (dtConsulta3.Rows.Count > 0)
                                {
                                    if (decSeq != Convert.ToDecimal(dtConsulta3.Rows[dtConsulta3.Rows.Count - 1][0])) erro = true;
                                }
                                else
                                {
                                    erro = true;
                                }

                                if (erro)
                                    dtConsulta3.Rows.Add(decSeq, decDiprID, strDiprCod, strDiprDimensoes, strDescricaoProd, strRef, strOrganizacao, strOrigem, decQtde, strDataMov, erroData);
                            }
                        }
                    }

                    gvImportacao.DataSource = dtConsulta3;

                    lblRegistros.Text = "Registros: " + gvImportacao.Rows.Count;

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

        private string SQL(string DiprId, string MifiIp)
        {
            strSQL = @"SELECT 
                            mifi.SEQ, mifi.DIPR_ID, mifi.DIPR_COD, mifi.DIPR_DIMENSOES, mifi.DESCRICAO_PRODUTO, mifi.REFERENCIA,
                            mifi.ORGANIZACAO, mifi.ORIGEM, mifi.QTDE, TO_CHAR(mifi.DATA_MOV, 'DD/MM/YYYY') DATA_MOV, '' ALERTAS
                        FROM 
                            CI_MINI_FIFO mifi
                        WHERE 
                                mifi.DIPR_ID = '" + DiprId + @"'
                            AND MIFI_IP = '" + MifiIp + @"' 
                        ORDER BY 
                            mifi.DIPR_ID, mifi.DATA_MOV, TO_NUMBER(REPLACE(SUBSTR(mifi.ORIGEM, 1, 2), '-', '')), mifi.SEQ";

            return strSQL;
        }

        private int NumCol(DataTable dt, string strCol)
        {
            int colSeq = -1;

            for (int u = 0; u < dt.Columns.Count; u++)
            {
                if (dt.Columns[u].ColumnName == strCol) colSeq = u;
            }

            return colSeq;
        }

        private string VerificaData(string strDataMov)
        {
            return ((strDataMov == "") ? ", " + erroData : "");
        }

        private bool ErroParOrigem(DataTable dtConsulta2, int o, int col, string strParOrigem, bool booDirecaoAbaixo)
        {
            bool semPar = false;

            if (booDirecaoAbaixo)
            {
                if (o + 1 >= dtConsulta2.Rows.Count)
                {
                    semPar = true;
                }
                else
                {
                    if (dtConsulta2.Rows[o + 1][col].ToString() != strParOrigem) semPar = true;
                }
            }
            else
            {
                if (o - 1 < 0)
                {
                    semPar = true;
                }
                else
                {
                    if (dtConsulta2.Rows[o - 1][col].ToString() != strParOrigem) semPar = true;
                }
            }

            return semPar;
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
                    string folderPath = "C:\\temp\\" + this.Text + " - " + cbSubContrato.Text + " - " + DateTime.Now.ToString("yyMMddHHmmss") + ".xlsx";

                    FileInfo file = new FileInfo(folderPath);

                    using (ExcelPackage pck = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = pck.Workbook.Worksheets.Add(this.Name);                         //Adicione uma nova planilha para a pasta de trabalho vazia
                        ws.Cells["A1"].LoadFromDataTable(((DataTable)gvImportacao.DataSource), true);       //Carregar dados da DataTable para a planilha
                        ws.Cells[ws.Dimension.Address].AutoFilter = true;
                        ws.View.FreezePanes(2, 1);
                        ws.Cells.AutoFitColumns();
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

        private void gvImportacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                RfNfEntradaBLL.strScript = gvImportacao.Rows[e.RowIndex].Cells[1].Value.ToString() + "-" + cbSubContrato.Text;

                frmProdutoDetalhes frm = new frmProdutoDetalhes();
                frm.ShowDialog();
            }
            catch (Exception ex)
            { }
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
    }
}
