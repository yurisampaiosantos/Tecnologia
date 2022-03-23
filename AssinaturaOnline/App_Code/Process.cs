using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;
using System.Security;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
/// <summary>
/// Summary description for Dados
/// </summary>
public class Process
{
    public Process()
	{
	}
    public static string StringDeConexao
    {
        get
        {                                                                                                             
            return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=drydock)(PORT= 1521)))(CONNECT_DATA=(SID=eep)(SERVER=DEDICATED)));User Id=EEP_TECNOLOGIA;Password=eepSA1986";
        }
    }
    public void EnviarEmail(string login, string password,string nomeRemetente, string emailRemetente, string nomeDestinatario, string emailDestinatario, string assunto, string texto, string anexo)
    {
        if (emailDestinatario != null && emailDestinatario != "")
        {
            SmtpClient cliente = new SmtpClient("mail.odebrecht.com");
            // cliente.EnableSsl = true;
            MailAddress remetente = new MailAddress(emailRemetente, nomeRemetente);
            MailAddress destinatario = new MailAddress(emailDestinatario, nomeDestinatario);
            MailMessage mensagem = new MailMessage(remetente, destinatario);
            mensagem.Attachments.Add(new Attachment(anexo));

            mensagem.Body = texto;
            mensagem.Subject = assunto;
            mensagem.IsBodyHtml = true;

            cliente.Credentials = new NetworkCredential(login, password); //CredentialCache.DefaultNetworkCredentials;
                        try
            {
                cliente.Send(mensagem);
                mensagem.Dispose();
                mensagem = null;
                cliente = null;


            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                // MessageBox.Show("Erro ao Enviar Email!");
            }
        }
    }
    public bool ValidationDomainGeneration(string domain,string login, string password)
    {
        bool result = false;
        try
        {            
            DirectoryEntry entry = new DirectoryEntry("LDAP://"+domain, login, password);
            object nativeObject = entry.NativeObject;
            User user = new User();
            user = user.List(login);
            if (user.Name != "")
            {
                string anexo = saveCertificate(user.Name, user.Department, "EEP - Estaleiro Enseada do Paraguaçu S.A. ", user.Tel, user.Cel, user.Email);
                EnviarEmail(login,password,"Assinatura Eletrônica", "AssinaturaEletronica@eepsa.com.br", user.Name, user.Email, "Assinatura", "Assinatura em anexo", anexo);
                result = true;
                ExcluirAnexo(anexo);
            }
            else
            {
                result = false;
            }
            result = true;
        }
        catch
        {
            result = false;
        }
         return result;
     }
    public bool ValidationDomainGeneration(string domain, string login, string password, string name, string departament, string tel, string cel, string email)
    {
        bool result = false;
        try
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, login, password);
            object nativeObject = entry.NativeObject;
            User user = new User();
            user.Name = name;
            user.Department = departament;
            user.Tel = tel;
            user.Cel = cel;
            user.Email = email;
            if (user.Name != "")
            {
                string anexo = saveCertificate(user.Name, user.Department, "EEP - Estaleiro Enseada do Paraguaçu S.A. ", user.Tel, user.Cel, user.Email);
                EnviarEmail(login,password,"Assinatura Eletrônica", "AssinaturaEletronica@eepsa.com.br", user.Name, user.Email, "Assinatura", "Assinatura em anexo", anexo);
                result = true;
                user.Update(login, user.Name, user.Department, user.Tel, user.Cel);
                ExcluirAnexo(anexo);
            }
            else
            {
                result = false;
            }
            result = true;
        }
        catch
        {
            result = false;
        }
        return result;
    }
    public User ValidationDomain(string domain, string login, string password)
    {
        User user = new User();
        try
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, login, password);
            object nativeObject = entry.NativeObject;
            user = user.List(login);           
        }
        catch
        {
        }
        return user;
    }
    private string saveCertificate(string name, string department, string title, string tel, string cel, string email)
     {
         Bitmap myBitmap = null;
         Graphics g = null;
         string appPath = @"c:\WebServicePublicado";//Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
         string OutputPath = @"c:\WebServicePublicado";

         StringFormat strFormat = new StringFormat();
         strFormat.Alignment = StringAlignment.Near;
         SolidBrush drawBrush = new SolidBrush(ColorTranslator.FromHtml("#831639"));
         SolidBrush drawBrush2 = new SolidBrush(ColorTranslator.FromHtml("#4F5054"));
         SolidBrush drawBrush3 = new SolidBrush(ColorTranslator.FromHtml("#394C97"));

         myBitmap = new Bitmap(appPath + "\\Image\\Assinatura.png");
         g = Graphics.FromImage(myBitmap);
         int linha = 16;
         if (name != "" && name != "N/A")
         {
             g.DrawString(name, new Font("Calibri", 10, FontStyle.Bold), drawBrush, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         if (department != "" && department != "N/A")
         {
             g.DrawString(department, new Font("Calibri", 10, FontStyle.Bold), drawBrush, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         if (title != "" && title != "N/A")
         {
             g.DrawString(title, new Font("Calibri", 10, FontStyle.Bold), drawBrush2, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         if (tel != "" && tel != "N/A" && tel != "(+__ __)____-____")
         {
             g.DrawString("Tel " + tel, new Font("Calibri", 9), drawBrush2, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         if (cel != "" && cel != "N/A" && cel != "(+__ __)____-____")
         {
             g.DrawString("Cel " + cel, new Font("Calibri", 9), drawBrush2, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         if (email != "" && email != "N/A")
         {
             g.DrawString(email, new Font("Calibri", 9, FontStyle.Underline), drawBrush3, new RectangleF(192, linha, 0, 0), strFormat);
             linha += 14;
         }
         g.Save();

         string FileName = "";


         if (!Directory.Exists(OutputPath + "\\"))
         {
             Directory.CreateDirectory(OutputPath + "\\");
         }
         if (!Directory.Exists(OutputPath + "\\"))
         {
             Directory.CreateDirectory(OutputPath + "\\");
         }
         FileName = OutputPath + "\\Anexos\\" + name.Replace(" ", null).ToUpper() + ".png";

         myBitmap.Save(FileName, System.Drawing.Imaging.ImageFormat.Png);

         return FileName;
         
     }
    private void ExcluirAnexo(string anexo)
    {
        System.IO.File.Delete(anexo);
    }
}