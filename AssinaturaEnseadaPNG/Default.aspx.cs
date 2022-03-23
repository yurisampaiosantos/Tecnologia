using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using AssinaturaEnseadaPNG;
public partial class Default : System.Web.UI.Page
{ 
    private static DescricaoCentroCusto descricaoCentroCustoGeral;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            descricaoCentroCustoGeral = null;
            CarregarDados();
        }
    }

    private void CarregarDados()
    {
       // string userName = "yuri.sampaio";
         
        string userName = System.Web.HttpContext.Current.User.Identity.Name;
        string ldapPath = "LDAP://WDCDC01.INTRANET.LOCAL";
        try
        {
            using (DirectoryEntry root = new DirectoryEntry(ldapPath))
            {
                DirectorySearcher searcher = new DirectorySearcher(root);
                searcher.Filter = string.Format("(sAMAccountName=" + userName.Substring(userName.IndexOf("\\") + 1, userName.Length - userName.IndexOf("\\") - 1) + ")");
                searcher.PropertiesToLoad.Add("displayName");                
                searcher.PropertiesToLoad.Add("mail");
                searcher.PropertiesToLoad.Add("department");
                searcher.PropertiesToLoad.Add("cc");  
               // searcher.PropertiesToLoad.Add("msRTCSIP");
                SearchResultCollection result = searcher.FindAll();
                SearchResult searchResult = result[0];
                

             //   string telefones =  searchResult.Properties["msRTCSIP-Line"][0].ToString();
                //  string[] tels;
                //  tels = telefones.Split(';');
                
               // string telefone = "";
               // string voip = "";
                DescricaoCentroCusto descricaoCentroCusto = new DescricaoCentroCusto();

                descricaoCentroCustoGeral = descricaoCentroCusto.SelecionarAnexoContrato(searchResult.Properties["cc"][0].ToString());
                string area = "";
                if (descricaoCentroCustoGeral.DescricaoPortugues == null || descricaoCentroCustoGeral.DescricaoPortugues == "")
                {
                    descricaoCentroCustoGeral.DescricaoPortugues = MaMiArea(searchResult.Properties["department"][0].ToString());
                    area = MaMiArea(searchResult.Properties["department"][0].ToString());
                    lbIdioma.Visible = false;
                }
                else
                {
                    area = descricaoCentroCustoGeral.DescricaoPortugues; 
                    if (descricaoCentroCustoGeral.DescricaoIngles == "" || descricaoCentroCustoGeral.DescricaoIngles == null)
                    {
                        lbIdioma.Visible = false;
                    }
                    else
                    {
                        lbIdioma.Visible = true;
                    }
                }

                string nome = searchResult.Properties["displayName"][0].ToString();
                
                string email = searchResult.Properties["mail"][0].ToString();
                area = area.Replace("peo", "P&O");
                /*      foreach (string resultado in tels)
                      {
                          if (resultado.ToUpper().IndexOf("TEL", 0) != -1)
                          {
                              telefone = resultado;
                          }
                          if (resultado.ToUpper().IndexOf("EXT", 0) != -1)
                          {
                              voip = resultado;
                          }
                      }*/
                txtNome.Text = nome;
                txtArea.Text = area;
                txtEmail.Text = email;
            //    txtTelefone.Text = FormataString("+ ## ## ####-#####", telefone.ToUpper().Replace("TEL:+", ""));
             //   txtVoip.Text = FormataString("#### #####", voip.ToUpper().Replace("EXT=", ""));
            }
        }
        catch 
        { 
        }
    }
    protected string FormataString(string mascara, string valor)
    {
        string novoValor = string.Empty;
        int posicao = 0;
        for (int i = 0; mascara.Length > i; i++)
        {
            if (mascara[i] == '#')
            {
                if (valor.Length > posicao)
                {
                    novoValor = novoValor + valor[posicao];
                    posicao++;
                }
                else
                    break;
            }
            else
            {
                if (valor.Length > posicao)
                    novoValor = novoValor + mascara[i];
                else
                    break;
            }
        }
        return novoValor;
    }
    private string MaMiArea(string nomeArea)
    {
        String[] nomes = nomeArea.ToLower().Split(' ');
        string resultado = "";
        // string area = nomeArea[1].ToString();
        foreach (string area in nomes)
        {
            if (area.Length <= 3)
            {
                resultado = resultado + area + " ";
            }
            else
            {
                string str = area.Substring(0, 1);
                resultado = resultado + str.ToUpper() + area.Substring(1) + " ";
            }

        }
        return resultado.Trim();
    }

    protected void txtVoip_TextChanged(object sender, EventArgs e)
    {
        txtVoip.Text = txtVoip.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        txtVoip.Text = FormataString("####-#####", txtVoip.Text);
    }

    protected void txtCelular_TextChanged(object sender, EventArgs e)
    {
        txtCelular.Text = txtCelular.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        txtCelular.Text = FormataString("+ ## ## ####-#####", txtCelular.Text);
    }

    protected void txtTelefone_TextChanged(object sender, EventArgs e)
    {
        txtTelefone.Text = txtTelefone.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
        txtTelefone.Text = FormataString("+ ## ## ####-#####", txtTelefone.Text);
    }

    protected void Download_Click(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(2 * 1000);
        try
        {
            Response.AddHeader("Content-Disposition", "attachment; filename=\""+txtNome.Text+".png\"");
            //Retornar a imagem
            Response.ContentType = "image/png";
            Response.WriteFile(MapPath("~/canvas.png"), true);
        }
        catch { }
    }

    protected void idioma_Onclick(object sender, EventArgs e)
    {
        if (lbIdioma.Text == "English")
        {
            lbIdioma.Text = "Português";
            txtArea.Text = descricaoCentroCustoGeral.DescricaoIngles;
        }
        else
        {
            lbIdioma.Text = "English";
            txtArea.Text = descricaoCentroCustoGeral.DescricaoPortugues;
        }
    }
}