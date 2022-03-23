using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using System.IO;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Windows.Forms;

namespace OutlookGeradorAssinatura
{
    public partial class RibbonAssinatura
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            CarregarDados();
        }

        private void btGerarAssinatura_Click(object sender, RibbonControlEventArgs e)
        {
           GerarAssinatura();           
        }
        private static void generateSignatureFile(string nome, string area, string areaIngles, string escritorio, string telefone, string celular, string voip)
        //Generates the Word document used by outlook as the source for the signature
        {
            try
            {
                Object oTrue = true;
                Object oFalse = false;
                string username = Environment.UserName;
                Microsoft.Office.Interop.Word.Application oWord = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document oWordDoc = new Microsoft.Office.Interop.Word.Document();
                oWord.Visible = false;
                object missing = System.Reflection.Missing.Value;
                Object oTemplatePath = @"\\wdciis03\Assinatura\Documento\Assinatura.docm";
                oWordDoc = oWord.Documents.Add(oTemplatePath);
                

                foreach (Microsoft.Office.Interop.Word.Field myMergeField in oWordDoc.Fields)
                {
                    int iTotalFields = 0;
                    iTotalFields++;
                    Microsoft.Office.Interop.Word.Range mgFieldCode = myMergeField.Code;
                    String fieldText = mgFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);
                        fieldName = fieldName.Trim();

                        if (fieldName == "nome")
                        {
                            myMergeField.Select();
                            if (nome != null && nome != "")
                            {
                                oWord.Selection.TypeText(nome);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "area")
                        {
                            myMergeField.Select();
                            if (area != null && area != "")
                            {
                                oWord.Selection.TypeText(area);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "area_ingles")
                        {
                            myMergeField.Select();
                            if (areaIngles != null && areaIngles != "")
                            {
                                oWord.Selection.TypeText(areaIngles);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "escritorio")
                        {
                            myMergeField.Select();
                            if (escritorio != null && escritorio != "")
                            {
                                oWord.Selection.TypeText(escritorio);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "telefone")
                        {
                            myMergeField.Select();
                            if (telefone != null && telefone != "")
                            {
                                oWord.Selection.TypeText(telefone);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }                        
                        if (fieldName == "celular")
                        {
                            myMergeField.Select();
                            if (celular != null && celular != "" && celular != "+55")
                            {
                                oWord.Selection.TypeText(celular);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "voip")
                        {
                            myMergeField.Select();
                            if (voip != null && voip != "")
                            {
                                oWord.Selection.TypeText(voip);
                            }
                            else
                            {
                                oWord.Selection.TypeBackspace();
                                oWord.Selection.TypeBackspace();
                            }
                        }
                        if (fieldName == "email")
                        {
                            myMergeField.Select();
                            oWord.Selection.TypeText(username+"@enseada.com");
                        }

                    }
                }
                               
                oWordDoc.Paragraphs.SpaceAfter = 0;
                int linhaRemover = 3;
                if (telefone == null || telefone == "")
                {
                    Microsoft.Office.Interop.Word.Range secondRange = oWordDoc.Paragraphs[linhaRemover].Range;
                    secondRange.Select();
                    secondRange.Delete();
                }
                else
                {
                    linhaRemover = linhaRemover + 1;
                }
                if (celular == null || celular == "" || celular == "+55")
                {
                    Microsoft.Office.Interop.Word.Range secondRange = oWordDoc.Paragraphs[linhaRemover].Range;
                    secondRange.Select();
                    secondRange.Delete();
                }
                else
                {
                    linhaRemover = linhaRemover + 1;
                }
                if (voip == null || voip == "")
                {
                    Microsoft.Office.Interop.Word.Range secondRange = oWordDoc.Paragraphs[linhaRemover].Range;
                    secondRange.Select();
                    secondRange.Delete();
                }



                object start = oWordDoc.Content.Start;
                object end = oWordDoc.Content.End;
                Microsoft.Office.Interop.Word.Range rng;
                rng = oWordDoc.Range(ref start, ref end);

                if (nome.Length > 30)
                {
                    nome = nome.Substring(0, 29).Trim();
                }

                oWord.Application.EmailOptions.EmailSignature.EmailSignatureEntries.Add(nome, oWordDoc.Range(ref start, ref end));
                oWord.Application.EmailOptions.EmailSignature.NewMessageSignature = nome;
                oWord.Application.EmailOptions.EmailSignature.ReplyMessageSignature = nome;


                if (!Directory.Exists(@"C:\users\" + username))
                {
                    username = username + ".INTRANET";
                }   

                if (File.Exists(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".docx"))
                {
                    File.Delete(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".docx");
                }
                if (File.Exists(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".rtf"))
                {
                    File.Delete(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".rtf");
                }
                if (File.Exists(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".txt"))
                {
                    File.Delete(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".txt");
                }
                if (!Directory.Exists(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures"))
                {
                    Directory.CreateDirectory(@"C:\users\" + username + @"\appdata\roaming\microsoft\signatures");
                }
            

                string savePath = @"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".txt";
                string savePath2 = @"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".rtf";
                string savePath3 = @"C:\users\" + username + @"\appdata\roaming\microsoft\signatures\" + nome + ".htm";
                oWordDoc.SaveAs2(savePath, 7);
                oWordDoc.SaveAs2(savePath2, 6);
                oWordDoc.SaveAs2(savePath3, 10);
                oWordDoc.Close();
                oWord.Quit();

                MessageBox.Show("Assinatura gerada com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema ao gerar Assinatura, erro :" + ex.Message);
            }


        }

        private void GerarAssinatura()
        {
            // Obtém o login do usuário na rede.
            string loginUserNetwork = Environment.UserName.Replace(@"INTRANET\", "");

            if (loginUserNetwork == "" || loginUserNetwork == null)
            {
                loginUserNetwork = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("INTRANET\\", "");

                if (loginUserNetwork == "" || loginUserNetwork == null)
                {
                    loginUserNetwork = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"INTRANET\", "");
                }

            }
            // Cria um contexto principal para definir a busca na base do AD.
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);

            // Cria uma query do Active Directory Domain Services.
            DirectorySearcher directorySearcher = new DirectorySearcher(principalContext.ConnectedServer);

            // Cria um filtro para a busca com o login do usuário da rede.
            directorySearcher.Filter = "(sAMAccountName=" + loginUserNetwork + ")";

            /*
             * Cria um elemento da hierarquia do Active Directory.
             * Este elemento é retornado durante uma busca através de DirectorySearcher.
             */
            SearchResult searchResult = directorySearcher.FindOne();

            // Cria um objeto encapsulado da hierarquia de diretório serviços do AD.
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();




            generateSignatureFile(editNome.Text, editArea.Text, editAreaIngles.Text, cbEscritorio.Text, editTelefone.Text, editCelular.Text, editVOIP.Text);
            // Cria um usuário.
            //   return new Usuario(directoryEntry);
        }

        private void CarregarDados()
        {

            // Obtém o login do usuário na rede.
            string loginUserNetwork = Environment.UserName.Replace(@"INTRANET\", "");

            if (loginUserNetwork == "" || loginUserNetwork == null)
            {
                loginUserNetwork = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace("INTRANET\\", "");
                
                if (loginUserNetwork == "" || loginUserNetwork == null)
                {
                    loginUserNetwork = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Replace(@"INTRANET\", ""); 
                }

            }

            // Cria um contexto principal para definir a busca na base do AD.
            PrincipalContext principalContext = new PrincipalContext(ContextType.Domain);

            // Cria uma query do Active Directory Domain Services.
            DirectorySearcher directorySearcher = new DirectorySearcher(principalContext.ConnectedServer);

            // Cria um filtro para a busca com o login do usuário da rede.
            directorySearcher.Filter = "(sAMAccountName=" + loginUserNetwork + ")";

            /*
             * Cria um elemento da hierarquia do Active Directory.
             * Este elemento é retornado durante uma busca através de DirectorySearcher.
             */
            SearchResult searchResult = directorySearcher.FindOne();

            // Cria um objeto encapsulado da hierarquia de diretório serviços do AD.
            DirectoryEntry directoryEntry = searchResult.GetDirectoryEntry();


            string telefones = directoryEntry.Properties["msRTCSIP-Line"][0].ToString();
            string[] tels;
            tels = telefones.Split(';');

            string telefone = "";
            string voip = "";
            string nome = directoryEntry.Properties["displayName"][0].ToString();
            string area = MaMiArea(directoryEntry.Properties["department"][0].ToString());

            foreach (string resultado in tels)
            {
                if (resultado.ToUpper().IndexOf("TEL", 0) != -1)
                {
                    telefone = resultado;
                }
                if (resultado.ToUpper().IndexOf("EXT", 0) != -1)
                {
                    voip = resultado;
                }
            }
            editNome.Text = nome;
            editArea.Text = area;
            editTelefone.Text = FormataString("+## (##) ####-#####", telefone.ToUpper().Replace("TEL:+", ""));
            editCelular.Text = "+55";
            editVOIP.Text = FormataString("####-#####", voip.ToUpper().Replace("EXT=", "")); 
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

        private void editCelular_TextChanged(object sender, RibbonControlEventArgs e)
        {
            editCelular.Text = editCelular.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            editCelular.Text = FormataString("+## (##) #####-####", editCelular.Text);
        }

        private void editTelefone_TextChanged(object sender, RibbonControlEventArgs e)
        {
            editTelefone.Text = editTelefone.Text.Replace("+", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            editTelefone.Text = FormataString("+## (##) ####-#####", editTelefone.Text);
        }

        private void editVOIP_TextChanged(object sender, RibbonControlEventArgs e)
        {
            editVOIP.Text = FormataString("####-#####", editVOIP.Text);
        }        

    }
}
