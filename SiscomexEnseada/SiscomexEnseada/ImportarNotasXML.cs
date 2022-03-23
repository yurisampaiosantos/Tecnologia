using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SiscomexEnseada
{
    public partial class ImportarNotasXML : Form
    {
        private double cargaId;
        private string cnpjFornecedor;
        public double CargaId { get => cargaId; set => cargaId = value; }
        public string CnpjFornecedor { get => cnpjFornecedor; set => cnpjFornecedor = value; }

        private List<CargaNotasDAL> listaCargaNotas;
        public ImportarNotasXML()
        {
            InitializeComponent();
        }              

        private void BtImportarPlanilha_Click(object sender, EventArgs e)
        {
            dvListanotas.AutoGenerateColumns = false;
            CargaNotasDAL x = new CargaNotasDAL();
            listaCargaNotas = x.LerXML(CnpjFornecedor);
            dvListanotas.DataSource = listaCargaNotas;
            dvListanotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            btSalvar.Visible = true;
            //MessageBox.Show("Total de Notas importadas = " + listaCargaNotas.Count().ToString());
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            CargaNotasDAL cargaNotas = new CargaNotasDAL();
            cargaNotas.InserirNotasXML(listaCargaNotas, cargaId);
            MessageBox.Show("XML(s) salvo(s) com sucesso!");
            this.Close();
        }
    }
}
