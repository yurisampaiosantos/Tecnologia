using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace goliath.licensecapture.DAL
{
    public class ArchiveDAL
    {
        public void GenerateArchive()
        {
            string nome_arquivo = "C:\\LicenseCapture\\LicenseCapture.bat";
            string nome_arquivo2 = "C:\\LicenseCapture\\LicenseCapture.yur";
            if (File.Exists(nome_arquivo))
                File.Delete(nome_arquivo);
            if (File.Exists(nome_arquivo2))
                File.Delete(nome_arquivo2);
            File.CreateText(nome_arquivo).Close();
            //Abrir o arquivo
            StreamWriter valor = new StreamWriter("C:\\LicenseCapture\\LicenseCapture.bat");
            valor.WriteLine("@echo off");
            valor.WriteLine("cls");
            valor.WriteLine("Echo.");
            valor.WriteLine("Echo.");
            valor.WriteLine("cd\\");
            valor.WriteLine("C:\\AVEVA_X64\\FlexMan5.2\\lmstat -f > C:\\LicenseCapture\\LicenseCapture.yur");
            valor.Close();
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("C:\\LicenseCapture\\LicenseCapture.bat");
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardError = true;
            System.Diagnostics.Process proc = System.Diagnostics.Process.Start(psi);
            proc.WaitForExit();
            proc.Close();
            CaptureArchive();
        }
        private void CaptureArchive()
        {
            // Cria Objetos 
            int x;
            System.IO.StreamReader sr;
            string linhaAtual;
            string service;
            string issued;
            string use;
            string temp;
            string userLoc;
            string marchine;
            string day;
            string hour;
            string year = "";            
            LicenseDAL licenseDAL = new LicenseDAL();
            // Verifica se o Arquivo não Existe 
            using (sr = new System.IO.StreamReader("C:\\LicenseCapture\\LicenseCapture.yur"))
            {

                while (!sr.EndOfStream)
                {
                    linhaAtual = sr.ReadLine();
                     if (linhaAtual.IndexOf("Flexible License Manager status") != -1)
                     {
                         year = linhaAtual.Substring(linhaAtual.IndexOf("Flexible License Manager status") + 44, 4);
                     }
                    if (linhaAtual.IndexOf("Users of") != -1 && linhaAtual.IndexOf("Uncounted,")==-1)
                    {
                        MOD.License license = new MOD.License();
                        service = "";
                        issued = "";
                        use = "";
                        userLoc = "";
                        marchine = "";
                        day = "";
                        hour = "";
                        //service
                        service = linhaAtual.Substring(linhaAtual.IndexOf("Users of ") + 8, linhaAtual.Count()-10);
                        x = 1;
                        temp = "";
                        while (service[x].ToString() != ":")
                        {
                            temp += service[x].ToString();
                            x++;
                        }
                        service = temp;
                        //issued
                        issued = linhaAtual.Substring(linhaAtual.IndexOf("(Total of")+9, 10);
                        x = 1;
                        temp = "";
                        while (issued[x].ToString() != " ")
                        {
                            temp += issued[x].ToString();
                            x++;
                        }
                        issued = temp;
                        //issued
                        use = linhaAtual.Substring(linhaAtual.IndexOf(";  Total of")+11, 10);
                        x = 1;
                        temp = "";
                        while (use[x].ToString() != " ")
                        {
                            temp += use[x].ToString();
                            x++;
                        }
                        use = temp;

                        license.Service = service;
                        license.Issued = issued;
                        license.Use = use;                      

                        //capiturar quem esta utilizando                        
                        if (use.Trim() != "0")
                        {
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            sr.ReadLine();
                            linhaAtual = sr.ReadLine();

                            while (linhaAtual != "")
                            {
                                userLoc = "";
                                marchine = "";
                                day = "";
                                hour = "";
                                x = 1;
                                //user
                                while (linhaAtual[x].ToString() == " ")
                                {
                                    x++;
                                }
                                userLoc = "";
                                while (linhaAtual[x].ToString() != " ")
                                {
                                    userLoc += linhaAtual[x].ToString();
                                    x++;
                                }
                                //marchine
                                while (linhaAtual[x].ToString() == " ")
                                {
                                    x++;
                                }
                                marchine = "";
                                while (linhaAtual[x].ToString() != " ")
                                {
                                    marchine += linhaAtual[x].ToString();
                                    x++;
                                }
                                //
                                linhaAtual = linhaAtual.Substring(linhaAtual.IndexOf(", start ") + 11, linhaAtual.Count() - linhaAtual.IndexOf(", start ") - 11);
                                x = 0;
                                //day
                                while (linhaAtual[x].ToString() == " ")
                                {
                                    x++;
                                }
                                day = "";
                                while (linhaAtual[x].ToString() != " ")
                                {
                                    day += linhaAtual[x].ToString();
                                    x++;
                                }
                                //hours
                                while (linhaAtual[x].ToString() == " ")
                                {
                                    x++;
                                }
                                hour = "";
                                while (x + 1 <= linhaAtual.Count() && linhaAtual[x].ToString() != " ")
                                {
                                    hour += linhaAtual[x].ToString();
                                    x++;
                                }
                                license.Users = userLoc;
                                license.Marchine = marchine;
                                license.DateStart = day+"/"+year;
                                license.Hours = hour;
                                licenseDAL.Insert(license);
                                //
                                linhaAtual = sr.ReadLine();
                            }
                        }
                        else
                        {                             
                            licenseDAL.Insert(license);
                        }
                    }
                }
                sr.Close();
            }
        }      
    }
}
