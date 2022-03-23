using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace ImportacaoPesagem
{
    public partial class frmImportacaoPesagem : Form
    {
        string argParametro;
        public frmImportacaoPesagem(string arg)
        {
            InitializeComponent();
            Executar.Enabled = true;
            argParametro = arg;
        }

        private void Executar_Tick(object sender, EventArgs e)
        {
            Executar.Enabled = false;
            BalancaDAL balanca = new BalancaDAL();
            BalancaPrePesagemDAL balancaPrePesagem = new BalancaPrePesagemDAL();

            if (argParametro == "D")
            {
                balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-15), DateTime.Now.Date.AddDays(+1));
                balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-15), DateTime.Now.Date.AddDays(+1));
                /*
                 balanca.InserirResultado(DateTime.Now.Date.AddDays(-10), DateTime.Now.Date);
                 balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date);
                */
            }
            else
            {
                if (argParametro == "M")
                {
                    balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date.AddDays(+1));
                    balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date.AddDays(+1));
                   /*
                    balanca.InserirResultado(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date);
                    balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-61), DateTime.Now.Date);
                   */
                }
                else
                {
                    if (argParametro == "T")
                    {
                        balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-90), DateTime.Now.Date.AddDays(+1));
                        balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-90), DateTime.Now.Date.AddDays(+1));
                      /*
                        balanca.InserirResultado(DateTime.Now.Date.AddDays(-90), DateTime.Now.Date);
                        balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-90), DateTime.Now.Date);
                      */
                    }
                    else
                    {
                        if (argParametro == "S")
                        {
                            balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-180), DateTime.Now.Date.AddDays(+1));
                            balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-180), DateTime.Now.Date.AddDays(+1));
                           /*
                            balanca.InserirResultado(DateTime.Now.Date.AddDays(-180), DateTime.Now.Date);
                            balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-180), DateTime.Now.Date);
                           */
                        }
                        else
                        {
                            if (argParametro == "A")
                            {
                                balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date.AddDays(+1));
                                balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-31), DateTime.Now.Date.AddDays(+1));
                                /*
                                balanca.InserirResultado(DateTime.Now.Date.AddDays(-365), DateTime.Now.Date);
                                balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-365), DateTime.Now.Date);
                                */
                            }
                            else
                            if (argParametro == "F")
                            {
                                balanca.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-10000), DateTime.Now.Date.AddDays(+1));
                                balancaPrePesagem.InserirResultadoSqlServer(DateTime.Now.Date.AddDays(-10000), DateTime.Now.Date.AddDays(+1));
                                /*
                                balanca.InserirResultado(DateTime.Now.Date.AddDays(-365), DateTime.Now.Date);
                                balancaPrePesagem.InserirResultado(DateTime.Now.Date.AddDays(-365), DateTime.Now.Date);
                                */
                            }
                        }
                    }
                }
            }
            /* cadassdtro de veiculo */
                                VeiculoDAL veiculo = new VeiculoDAL();
            veiculo.InserirResultadoSqlServer();
            //veiculo.InserirResultado();
            Close();
        }
    }
}
