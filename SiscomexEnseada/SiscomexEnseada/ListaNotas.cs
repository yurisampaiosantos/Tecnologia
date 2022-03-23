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
using OfficeOpenXml;

namespace SiscomexEnseada
{
    public partial class ListaNotas : Form
    {
        private double cargaId;
        private string cnpjFornecedor;
        private Boolean alterar;
        public double CargaId { get => cargaId; set => cargaId = value; }
        public string CnpjFornecedor { get => cnpjFornecedor; set => cnpjFornecedor = value; }
        public bool Alterar { get => alterar; set => alterar = value; }

        public ListaNotas()
        {
            InitializeComponent();
        }

        private void BtImportar_Click(object sender, EventArgs e)
        {
            ImportarNotas importarNotas = new ImportarNotas();
            importarNotas.CargaId = CargaId;
            importarNotas.ShowDialog();
            CarregarGrid();
        }
        public void CarregarGrid()
        {
            //btImportar.Visible = Alterar;
            btExcluir.Visible = Alterar;
            btSalvar.Visible = Alterar;
            btImportarXML.Visible = Alterar;
            btSelecionarTodos.Visible = Alterar;
            btTransformaTonKg.Visible = Alterar;

            dvListaNotas.AutoGenerateColumns = false;
            DataTable carga = (new CargaNotasDAL()).ListaCargaNotas(CargaId);
            try
            {
                dvListaNotas.DataSource = carga;
            }
            catch
            {
                dvListaNotas.DataSource = null;
            }
            lbTotalNotas.Text = "Total Notas = " + carga.Rows.Count.ToString();
        }

        private void ListaNotas_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtImportarXML_Click(object sender, EventArgs e)
        {
            ImportarNotasXML importarNotasXml = new ImportarNotasXML();
            importarNotasXml.CargaId = CargaId;
            importarNotasXml.CnpjFornecedor = CnpjFornecedor;
            importarNotasXml.ShowDialog();
            CarregarGrid();
        }

        private void DvListaNotas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dvListaNotas.Columns[e.ColumnIndex].Name == "Status")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    if (e.Value != System.DBNull.Value)
                    {
                        decimal stringValue = (decimal)e.Value;
                        if ((stringValue == 1))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                            dvListaNotas.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[0];
                        }
                        else if ((stringValue == 2))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dvListaNotas.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[1];
                        }
                        else if ((stringValue == 0))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dvListaNotas.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[2];
                        }
                    }
                    else
                    {
                        dvListaNotas.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[2];
                    }

                }
            }
            if (this.dvListaNotas.Columns[e.ColumnIndex].Name == "STATUSBALANCA")
            {
                if (e.Value != null)
                {
                    // Check for the string "pink" in the cell.
                    if (e.Value != System.DBNull.Value)
                    {
                        decimal stringValue = (decimal)e.Value;
                        if ((stringValue == 1))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.LightGreen;
                            dvListaNotas.Rows[e.RowIndex].Cells["BALANCA"].Value = imageList1.Images[0];
                        }
                        else if ((stringValue == 2))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dvListaNotas.Rows[e.RowIndex].Cells["BALANCA"].Value = imageList1.Images[2];
                        }
                    }
                    else
                    {
                        dvListaNotas.Rows[e.RowIndex].Cells["BALANCA"].Value = imageList1.Images[2];
                    }

                }
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CargaNotasDAL cargaNotas = new CargaNotasDAL();

                for (int x = 0; x < dvListaNotas.Rows.Count; x++)
                {
                    if (dvListaNotas.Rows[x].Cells["SELECAO"].Value != null && dvListaNotas.Rows[x].Cells["SELECAO"].Value.ToString() != "false")
                    {
                        dvListaNotas.Rows[x].Cells["SELECAO"].Value = null;
                        int cargaNotaID = Convert.ToInt32(dvListaNotas.Rows[x].Cells["ID"].Value.ToString());
                        cargaNotas.DeleteNota(cargaNotaID);
                    }
                }
                CarregarGrid();
                CargaDAL carga = new CargaDAL();
                carga.AtualizarStatus(CargaId);
            }
        }

        private void BtSalvarExcel_Click(object sender, EventArgs e)
        {
            SalvarExcel();
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void SalvarExcel()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel | *.xlsx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null && saveFileDialog1.FileName != "")
                {
                    FileInfo infoArquivo = new FileInfo(saveFileDialog1.FileName);
                    if (File.Exists(saveFileDialog1.FileName))
                        File.Delete(saveFileDialog1.FileName);

                    using (ExcelPackage excelPackage = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Notas");
                        //Set some properties of the Excel document
                        excelPackage.Workbook.Properties.Author = "Enseada";
                        excelPackage.Workbook.Properties.Title = "Siscomex";
                        excelPackage.Workbook.Properties.Subject = "Geração de notas";
                        excelPackage.Workbook.Properties.Created = DateTime.Now;
                        try
                        {
                            //cabecalho
                            for (int j = 1; j <= dvListaNotas.ColumnCount; j++)
                            {
                                worksheet.Cells[1, j].Value = dvListaNotas.Columns[j-1].HeaderText;
                            }
                            //linhas
                            for (int i = 1; i <= dvListaNotas.RowCount; i++)
                            {
                                for (int j = 1; j <= dvListaNotas.ColumnCount; j++)
                                {
                                    try
                                    {
                                        DataGridViewCell cell = dvListaNotas[j-1, i-1];
                                        if (cell.Value != System.DBNull.Value)
                                        {
                                            worksheet.Cells[i + 1, j].Value = cell.Value;                                           
                                        }
                                    }
                                    catch (Exception ex) { }
                                }
                            }
                            excelPackage.SaveAs(infoArquivo);
                            MessageBox.Show("Arquivo salvo com sucesso!");
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("erro = " + ex.Message);
                        }                  
                        
                    }
                }
            }
        }

        private void btTransformaTonKg_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja converter o peso de TON para KG?", "Conversão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CargaNotasDAL cargaNotas = new CargaNotasDAL();
                for (int x = 0; x < dvListaNotas.Rows.Count; x++)
                {
                    if (dvListaNotas.Rows[x].Cells["SELECAO"].Value != null && dvListaNotas.Rows[x].Cells["SELECAO"].Value.ToString() != "false")
                    {
                        dvListaNotas.Rows[x].Cells["SELECAO"].Value = null;
                        int cargaNotaID = Convert.ToInt32(dvListaNotas.Rows[x].Cells["ID"].Value.ToString());
                        cargaNotas.AtualizarPeso(cargaNotaID);
                    }
                }
                CarregarGrid();
                CargaDAL carga = new CargaDAL();
                carga.AtualizarStatus(CargaId);
                MessageBox.Show("Registro(s) Atualizado(s) com sucesso.");
            }
        }
        private void btSelecionarTodos_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < dvListaNotas.Rows.Count; x++)
            {
                dvListaNotas.Rows[x].Cells["SELECAO"].Value = true;
            }
        }

        private void dvListaNotas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1)
            {
                dvListaNotas.Rows[e.RowIndex].Cells["SELECAO"].Value = true;
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja Salvar?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                CargaNotasDAL cargaNotas = new CargaNotasDAL();


                for (int x = 0; x < dvListaNotas.Rows.Count; x++)
                {
                    if (dvListaNotas.Rows[x].Cells["SELECAO"].Value != null && dvListaNotas.Rows[x].Cells["SELECAO"].Value.ToString() != "false")
                    {
                        dvListaNotas.Rows[x].Cells["SELECAO"].Value = null;
                        int cargaNotaID = Convert.ToInt32(dvListaNotas.Rows[x].Cells["ID"].Value.ToString());
                        string cnpjTransportadora = dvListaNotas.Rows[x].Cells["CNPJ_TRANSPORTADOR"].Value.ToString();
                        string observacao = dvListaNotas.Rows[x].Cells["OBSERVACOES_GERAIS"].Value.ToString();
                        double peso = Convert.ToDouble(dvListaNotas.Rows[x].Cells["PESO"].Value.ToString());
                        cargaNotas.AtualizarNota(cargaNotaID, cnpjTransportadora, observacao, peso);                        
                    }
                }
                CarregarGrid();
                CargaDAL carga = new CargaDAL();
                carga.AtualizarStatus(CargaId);
            }
        }
    }
}
