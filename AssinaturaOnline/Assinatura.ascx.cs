using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Assinatura : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    private void LimparErro()
    {
        blErro.Items.Clear();
        blErro.Visible = false;
    }
    protected void btnLogar_Click(object sender, EventArgs e)
    {
        LimparErro();
        WebService webService = new WebService();
        User user = new User();
        user = webService.Validation("eepsa", txtLogin.Text, txtPassword.Text);
        if (user.Name != null && user.Name != "")
        {
            txtNome.Text = user.Name;
            txtDepartamento.Text = user.Department;
            txtTelefone.Text = user.Tel;
            txtCelular.Text = user.Cel;
            txtEmail.Text = user.Email;
            txtPassword2.Text = txtPassword.Text;
            pnGerar_ModalPopupExtender.Show();
        }
        else
        {
            blErro.Items.Add("Login ou Senha invalida");
            blErro.Visible = true;
        }
    }
    protected void btGerar_Click(object sender, EventArgs e)
    {
        LimparErro();
        WebService webService = new WebService();
        if (webService.ValidationDomainGenerationParameter("eepsa", txtLogin.Text, txtPassword2.Text, txtNome.Text, txtDepartamento.Text, txtTelefone.Text, txtCelular.Text, txtEmail.Text))
        {
            pnGerar_ModalPopupExtender.Hide();
            txtLogin.Text = "";
            blErro.Items.Add("Assinatura enviada por e-mail");
            blErro.Visible = true;
        }
        else
        {
        }
        txtPassword.Text = "";
    }
}