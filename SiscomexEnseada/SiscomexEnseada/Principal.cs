using System;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Data;

namespace SiscomexEnseada
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void TsmCriarNota_Click(object sender, EventArgs e)
        {
            CriarNF criarNF = new CriarNF();
            criarNF.Data = dtSelecionada.Value;
            criarNF.Alterar = true;
            criarNF.ShowDialog();
            CarregarGrid();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (Conexao.ConecaoSiscomex.IndexOf("val.portalunico") > 0)
            {
                this.Text = this.Text + " - Treinamento";
            }
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                lbVersao.Text = string.Format(" V.Prod: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            else
            {
                var ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                lbVersao.Text = string.Format(" V.Prod: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            CarregarGrid();
        }

        private void DvCarga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                CriarNF criarNF = new CriarNF();
                criarNF.Id = Convert.ToDouble(dvCarga.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (dvCarga.Rows[e.RowIndex].Cells[7].Value.ToString() == "" || dvCarga.Rows[e.RowIndex].Cells[7].Value.ToString() == "0")
                {
                    criarNF.Alterar = true;
                }
                else
                {
                    criarNF.Alterar = false;
                }
                criarNF.ShowDialog();
                CarregarGrid();
            }
            catch
            { }
        }
        public void CarregarGrid()
        {
            dvCarga.AutoGenerateColumns = false;
            DataTable carga = (new CargaDAL()).ListaCarga(dtSelecionada.Value);
            try
            {
                dvCarga.DataSource = carga;
            }
            catch
            {
                dvCarga.DataSource = null;
            }
        }

        private void DtSelecionada_ValueChanged(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void DvCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dvCarga.Columns[e.ColumnIndex].Name == "Status")
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
                            dvCarga.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[0];
                        }
                        else if ((stringValue == 2))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dvCarga.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[1];
                        }
                        else if ((stringValue == 0))
                        {
                            //e.CellStyle.BackColor = System.Drawing.Color.Red;
                            dvCarga.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[2];
                        }
                    }
                    else
                    {
                        dvCarga.Rows[e.RowIndex].Cells["IconStatus"].Value = imageList1.Images[2];
                    }

                }
            }
        }
        private void BtEnviar_Click(object sender, EventArgs e)
        {
            if (dvCarga.Rows[dvCarga.SelectedRows[0].Index].Cells["status"].Value.ToString() == "1")
            {
                MessageBox.Show("Evento já transmitido, não pode ser reenviado.");
            }
            else
            {
                SiscomexController siscomex = new SiscomexController();
                CargaDAL carga = new CargaDAL();

                for (int x = 0; x < dvCarga.SelectedRows.Count; x++)
                {
                    int cargaID = Convert.ToInt32(dvCarga.Rows[dvCarga.SelectedRows[x].Index].Cells["ID"].Value.ToString());
                    carga.EnviarLoteXML(cargaID);                  
                }
                CarregarGrid();
                MessageBox.Show("Evento enviados");
            }
        }

        private void BtExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (dvCarga.Rows[dvCarga.SelectedRows[0].Index].Cells["status"].Value.ToString() == "1")
                {
                    MessageBox.Show("Evento já transmitido, não pode ser excluido.");
                }
                else
                {
                    CargaDAL carga = new CargaDAL();

                    for (int x = 0; x < dvCarga.SelectedRows.Count; x++)
                    {
                        int cargaID = Convert.ToInt32(dvCarga.Rows[dvCarga.SelectedRows[x].Index].Cells["ID"].Value.ToString());
                        carga.DeleteLote(cargaID);
                    }
                    CarregarGrid();
                }
            }
        }
    }
}



/*
 * 
 *  SiscomexController siscomexController = new SiscomexController();
            XElement xml = XElement.Load(@"C:\Temp\Siscomex.xml");

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, @"C:\Users\yuri.sampaio.INTRANET\source\repos\SiscomexEnseada\SiscomexEnseada\XSD\Validador\RecepcaoNFE.xsd");
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml.ToString());

            XmlReader xr = XmlReader.Create(new StringReader(xmlDocument.InnerXml), settings);
            try
            {
                while (xr.Read())
                {
                    string s = xr.Name;
                    //  Response.Write(s + "<br/>");
                }
            }
            catch (Exception ex)
            {
                string s = xr.Name + " : " + ex.Message;
            }

            siscomexController.GetDUE(xmlDocument.InnerXml);       



    **/