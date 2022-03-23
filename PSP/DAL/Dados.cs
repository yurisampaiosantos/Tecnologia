using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.OleDb;
using System.Data;
using GridCarregamento.Modelo;
using System.Collections;
using System.Collections.Specialized;
using System.DirectoryServices;

namespace GridCarregamento.DAL
{
    public class Dados
    {
        public static string StringDeConexao
        {
            get
            {
                //------produção                                                                             
                //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCHLRAC-SCAN.eepsa.com.br)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=EEPCONV)(SERVER=DEDICATED)));User Id=F_APP_TA;Password=f_app_taSAOra1978";
                //return "Data Source=LCHLRAC-SCAN.eepsa.com.br:1521/EEPCONV;User Id=F_APP_TA;Password=f_app_taSAOra1978;PERSIST SECURITY INFO=True;";
                //return "Data Source=LCJUDB01:1521/CJU01.intranet.local;User Id=F_APP_TA;Password=f_app_taSAOra1978;PERSIST SECURITY INFO=True;";

                //------desenvolvimento
                //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=EEPSSADEV)(SERVER=DEDICATED)));User Id=EEP_TECNOLOGIA;Password=eep_tecnologia@eep";

                //DESENVOLVIMENTO
                //return "Data Source=LCJUDBDEV01.intranet.local:1521/CJU01DEV.intranet.local;User Id=ETA;Password=TimeApprop14;PERSIST SECURITY INFO=True;";

                //PRODUÇÃO
                return "Data Source=LCJUDB01:1521/CJU01.intranet.local;User Id=ETA;Password=ApproP15Ora$;PERSIST SECURITY INFO=True;";
            }
        }
        //ingles
        /*
        public static string DataString(string data)
        {
            try
            {
                string dataResult = "";
                if (data != null && data != "")
                {
                    switch (DateTime.Parse(data).Month)
                    {
                        case 1:
                            dataResult = "jan";
                            break;
                        case 2:
                            dataResult = "feb";
                            break;
                        case 3:
                            dataResult = "mar";
                            break;
                        case 4:
                            dataResult = "apr";
                            break;
                        case 5:
                            dataResult = "may";
                            break;
                        case 6:
                            dataResult = "jun";
                            break;
                        case 7:
                            dataResult = "jul";
                            break;
                        case 8:
                            dataResult = "aug";
                            break;
                        case 9:
                            dataResult = "sep";
                            break;
                        case 10:
                            dataResult = "oct";
                            break;
                        case 11:
                            dataResult = "nov";
                            break;
                        case 12:
                            dataResult = "dec";
                            break;
                    }
                    return DateTime.Parse(data).Year.ToString() + "/" + dataResult + "/" + DateTime.Parse(data).Day.ToString();
                    // DateTime.Parse(data).Day.ToString() + "-" + dataResult + "-" + DateTime.Parse(data).Year.ToString();
                }
                else
                    return dataResult;
            }
            catch
            {
                throw new Exception(data);
            }
        }  
        */
        //portugues
        public static string DataString(string data)
        {
            string dataResult = "";
            if (data != null && data != "")
            {
                switch (DateTime.Parse(data).Month)
                {
                    case 1:
                        dataResult = "jan";
                        break;
                    case 2:
                        dataResult = "fev";
                        break;
                    case 3:
                        dataResult = "mar";
                        break;
                    case 4:
                        dataResult = "abr";
                        break;
                    case 5:
                        dataResult = "mai";
                        break;
                    case 6:
                        dataResult = "jun";
                        break;
                    case 7:
                        dataResult = "jul";
                        break;
                    case 8:
                        dataResult = "ago";
                        break;
                    case 9:
                        dataResult = "set";
                        break;
                    case 10:
                        dataResult = "out";
                        break;
                    case 11:
                        dataResult = "nov";
                        break;
                    case 12:
                        dataResult = "dez";
                        break;
                }
                return DateTime.Parse(data).Day.ToString() + "/" + dataResult + "/" + DateTime.Parse(data).Year.ToString();
            }
            else
                return dataResult;
        }   
        public static string DecimalString(decimal valor)
        {
            string valorString = valor.ToString();
            valorString = valorString.Replace(",", ".");
            return valorString;
        }
        public void EnviarEmail(string nomeRemetente, string emailRemetente, string nomeDestinatario, string emailDestinatario, string assunto, string texto)
        {
            if (emailDestinatario != null && emailDestinatario != "")
            {
                SmtpClient cliente = new SmtpClient("mail.odebrecht.com");
                // cliente.EnableSsl = true;
                MailAddress remetente = new MailAddress(emailRemetente, nomeRemetente);
                MailAddress destinatario = new MailAddress(emailDestinatario, nomeDestinatario);
                MailMessage mensagem = new MailMessage(remetente, destinatario);
               
                mensagem.Body = texto;
                mensagem.Subject = assunto;
                mensagem.IsBodyHtml = true;
                
                cliente.Credentials = CredentialCache.DefaultNetworkCredentials;
                
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
        public ArrayList DomainGroupsLocal()
        {
            System.Security.Principal.WindowsIdentity identity =  System.Security.Principal.WindowsIdentity.GetCurrent();
            // get the principal to test the user against a built-in role
            System.Security.Principal.WindowsPrincipal principal =  new System.Security.Principal.WindowsPrincipal(identity);
            // check the user against BUILTIN\Administrator
            ArrayList groups = new ArrayList();
            try
            {
                foreach (System.Security.Principal.IdentityReference group in
                identity.Groups)
                {
                    groups.Add(group.Translate(typeof
                        (System.Security.Principal.NTAccount)).ToString());
                }
            }
            catch { }

            return groups;
        }
        public StringCollection DomainGroupsNet()
        {
            StringCollection groups = new StringCollection();
            DirectoryEntry obEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
            DirectorySearcher srch = new DirectorySearcher(obEntry,"(sAMAccountName=" + Environment.UserName + ")");
            SearchResult res = srch.FindOne();
            if (null != res)
            {
                DirectoryEntry obUser = new DirectoryEntry(res.Path);
                // Invoke Groups method.
                object obGroups = obUser.Invoke("Groups");
                foreach (object ob in (IEnumerable)obGroups)
                {
                    // Create object for each group.
                    DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                    groups.Add(obGpEntry.Name);
                }
            }
            return groups;
        }
        public bool DomainGroupsNet(string groupDomain)
        {
            bool result = false; 
            DirectoryEntry obEntry = new DirectoryEntry("LDAP://" + Environment.UserDomainName);
            DirectorySearcher srch = new DirectorySearcher(obEntry, "(sAMAccountName=" + Environment.UserName + ")");
            SearchResult res = srch.FindOne();
            if (null != res)
            {
                DirectoryEntry obUser = new DirectoryEntry(res.Path);
                // Invoke Groups method.
                object obGroups = obUser.Invoke("Groups");
                foreach (object ob in (IEnumerable)obGroups)
                {
                    // Create object for each group.
                    DirectoryEntry obGpEntry = new DirectoryEntry(ob);
                    if (obGpEntry.Name == groupDomain)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
