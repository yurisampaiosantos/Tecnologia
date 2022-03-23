using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiscomexEnseada
{    
    public partial class CriarNF : Form
    {
        private double id;
        private DateTime data;
        private Boolean alterar;
        public double Id { get => id; set => id = value; }
        public DateTime Data { get => data; set => data = value; }
        public bool Alterar { get => alterar; set => alterar = value; }

        private class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
            public ComboboxItem(string nome, string valor)
            {
                Text = nome;
                Value = valor;
            }
        }
        public CriarNF()
        {
            InitializeComponent();
            CarregarComboboxFornecedor();
        }
        
        private void CarregarComboboxFornecedor()
        {
            cbCnpjFornecedor.Items.Add(new ComboboxItem("Bahia Mineração S.A", "07392063000260"));
            cbCnpjFornecedor.Items.Add(new ComboboxItem("Brazil Iron Mineração", "13313434000274"));
            cbCnpjFornecedor.Items.Add(new ComboboxItem("Largo Resources", "15191786000220"));          
        }

        private void BtNotaFiscal_Click(object sender, EventArgs e)
        {
            ListaNotas listaNotas = new ListaNotas();
            listaNotas.CargaId = Id;
            listaNotas.CnpjFornecedor = (cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString(); 
            listaNotas.Alterar = Alterar;
            listaNotas.ShowDialog();
        }

        private void CriarNF_Load(object sender, EventArgs e)
        {
            btSalvar.Visible = Alterar;
            if (Id != 0 )
            {
                Preencher();
                btNotaFiscal.Visible = true;                
            }            
            else
            {
                btNotaFiscal.Visible = false;                
                cbCnpjFornecedor.SelectedIndex = 0;
            }
        }
        private void Preencher()
        {
            CargaDAL carga = new CargaDAL();
            carga.PreencherCarga(Id);

            txtAvaria.Text = carga.AvariasIdentificadas;
            txtCnpj.Text = carga.Cnpj;
            txtRa.Text = carga.CodigoRA;
            txtUrf.Text = carga.CodigoURF;
            txtDivergencia.Text = carga.DivergenciasIdentificadas;

            foreach (ComboboxItem comboFornecedor in cbCnpjFornecedor.Items)
            {
                if (comboFornecedor.Value.ToString() == carga.CnpjFornecedor)
                {
                    cbCnpjFornecedor.SelectedIndex = cbCnpjFornecedor.FindStringExact(comboFornecedor.Text);
                    break;
                }
            }
            foreach (ComboboxItem comboArmazenamento in cbLocalArmazenamento.Items)
            {
                if (comboArmazenamento.Value.ToString() == carga.LocalArmazenamento)
                {
                    cbLocalArmazenamento.SelectedIndex = cbLocalArmazenamento.FindStringExact(comboArmazenamento.Text);
                    break;
                }
            }
            foreach (ComboboxItem comboRecepcao in cbLocalRecepcao.Items)
            {
                if (comboRecepcao.Value.ToString() == carga.LocalRecepcao)
                {
                    cbLocalRecepcao.SelectedIndex = cbLocalRecepcao.FindStringExact(comboRecepcao.Text);
                    break;
                }
            }
            
            if (carga.Status == 1)
            {
                btSalvar.Visible = false;
            }
        }

        private void BtSalvar_Click(object sender, EventArgs e)
        {
            if (txtAvaria.Text == "" || txtCnpj.Text == "" || txtRa.Text == "" ||
                 txtUrf.Text == "" || txtDivergencia.Text == "" ||
                 (cbLocalArmazenamento.SelectedItem as ComboboxItem).Value.ToString() == "" ||
                 (cbLocalRecepcao.SelectedItem as ComboboxItem).Value.ToString() == "" ||
                (cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString() == "")
            {
                MessageBox.Show("Todos os campos tem que ser preenchidos");
            }
            else
            { 
                CargaDAL carga = new CargaDAL();

                carga.AvariasIdentificadas = txtAvaria.Text;
                carga.Cnpj = txtCnpj.Text;
                carga.CodigoRA = txtRa.Text;
                carga.CodigoURF = txtUrf.Text;
                carga.DivergenciasIdentificadas = txtDivergencia.Text;
                carga.LocalArmazenamento = (cbLocalArmazenamento.SelectedItem as ComboboxItem).Value.ToString();
                carga.LocalRecepcao = (cbLocalRecepcao.SelectedItem as ComboboxItem).Value.ToString();
                carga.CnpjFornecedor = (cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString();
                carga.Data = data;
                if (Id > 0)
                {
                    carga.Id = Id;
                    carga.Atualizar(carga);
                }
                else
                {
                    Id = carga.InserirCarga(carga);
                    btNotaFiscal.Visible = true;
                }
                MessageBox.Show("Lote Salvo com sucesso!");
            }
        }

        private void BtSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCnpjFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbLocalRecepcao.Items.Clear();
            cbLocalRecepcao.Text = "";
            cbLocalArmazenamento.Items.Clear();
            cbLocalArmazenamento.Text = "";

            if ((cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString() == "13313434000274")
            {
                cbLocalRecepcao.Items.Add(new ComboboxItem("TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO BI PIATA", 
                                                            "TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO BI PIATA"));

                cbLocalArmazenamento.Items.Add(new ComboboxItem("AREA 0008", "AREA 0008"));
                cbLocalArmazenamento.Items.Add(new ComboboxItem("AREA 0018", "AREA 0018"));
            }
            if ((cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString() == "15191786000220")
            {
                cbLocalRecepcao.Items.Add(new ComboboxItem("TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO VANADIO MARACAS",
                                                           "TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO VANADIO MARACAS"));

                cbLocalArmazenamento.Items.Add(new ComboboxItem("AREA GALPAO CEP", "AREA GALPAO CEP"));
            }
            if ((cbCnpjFornecedor.SelectedItem as ComboboxItem).Value.ToString() == "07392063000260")
            {
                cbLocalRecepcao.Items.Add(new ComboboxItem("TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO",
                                                           "TERMINAL ENSEADA - PATIO DE ARMAZENAGEM DE MINERIO"));

                cbLocalArmazenamento.Items.Add(new ComboboxItem("PATIO CAETITE", "PATIO CAETITE"));
            }
        }
    }
}
