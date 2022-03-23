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
    public partial class ImportarNotas : Form
    {
        private double cargaId;
        public double CargaId { get => cargaId; set => cargaId = value; }

        private DataSet ds;
        public ImportarNotas()
        {
            InitializeComponent();
        }              

        private void BtImportarPlanilha_Click(object sender, EventArgs e)
        {
            OpenFileDialog vAbreArq = new OpenFileDialog();
            vAbreArq.Filter = "Excel 97-2003 WorkBook|*.xls|Excel WorkBook|*.xlsx|All Excel Files|*.xls;*.xlsx|All Files|*.*";
            vAbreArq.Title = "Selecione o Arquivo";
            if (vAbreArq.ShowDialog() == DialogResult.OK)
            {
                ds = new DataSet();
                OleDbConnection conexao = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" +
                "Data Source=" + vAbreArq.FileName + ";" +
                "Extended Properties=Excel 8.0;");
                OleDbDataAdapter da = new OleDbDataAdapter("Select * From [SAÍDA_PORTO$]", conexao);
                da.Fill(ds);
                dvListanotas.DataSource = ds.Tables[0];
                dvListanotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                conexao.Close();
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            CargaNotasDAL cargaNotas = new CargaNotasDAL();
            cargaNotas.InserirNotasPlanilha(ds, cargaId);
            this.Close();
        }
    }
}
