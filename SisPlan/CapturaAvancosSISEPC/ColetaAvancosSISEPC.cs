using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapturaAvancosSISEPC
{
    class ColetaAvancosSISEPC
    {
        static string contrato = "Conversão";
        static void Main(string[] args)
        {
            GenericClasses.FolhaServico.RealizaCapturaSISEPC(contrato);
        }
    }
}
