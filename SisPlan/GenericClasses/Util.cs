using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace GenericClasses
{
    static public class Util
    {
        //=================================================================
        public static string FormataString(string mascara, string valor)
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
        //=================================================================
        public static double MathRoundValue(double valor, int numeroCasasDecimais)
        {
            double fator = Math.Pow(10, numeroCasasDecimais); 
            valor *= fator;
            valor = Math.Ceiling(valor);
            valor /= fator;
 
            return valor;
        }
        //=================================================================
        public static string GetUserDocumentFolderName()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\";
        }
        //=================================================================
        //=================================================================
        public static void CreateDefaultImportRepositoryFolder(string folderName)
        {
            string folder = GetUserDocumentFolderName() + folderName;
            string exceptionFolder = folder + @"Exceptions\";
            string handledFolder = folder + @"Handled\";
            bool exist = System.IO.Directory.Exists(folder);
            if (!exist)
            {
                System.IO.Directory.CreateDirectory(folder);
                System.IO.Directory.CreateDirectory(exceptionFolder);
                System.IO.Directory.CreateDirectory(handledFolder);
            }
        }
        //=================================================================
        public static void CreateDefaultReportRepositoryFolder(string folderName)
        {
            if (!System.IO.Directory.Exists(folderName)) System.IO.Directory.CreateDirectory(folderName);
        }
        //=================================================================
    }
}
