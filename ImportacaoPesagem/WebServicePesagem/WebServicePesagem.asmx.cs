using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DAL;

namespace WebServicePesagem
{
    /// <summary>
    /// Summary description for WebServicePesagem
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServicePesagem : System.Web.Services.WebService
    {

        [WebMethod]
        public string AtualizarPesagem(string argParametro)
        {
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
            return "Atualizado";
        }
    }
}
