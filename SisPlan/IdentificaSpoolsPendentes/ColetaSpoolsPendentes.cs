
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;

namespace IdentificaSpoolsPendentes
{
    public class ColetaSpoolsPendentes
    {
        static string contrato = "Conversão";
        static string discId = "5";
        static void Main(string[] args)
        {
            /*
             DateTime t1 = new DateTime(100); 
             DateTime t2 = new DateTime(20);
             if (DateTime.Compare(t1, t2) >  0) Console.WriteLine("t1 > t2");
             if (DateTime.Compare(t1, t2) == 0) Console.WriteLine("t1 == t2");
             if (DateTime.Compare(t1, t2) <  0) Console.WriteLine("t1 < t2");
            */
            //Calcula a pendência de Spools para Conversão e Tubulação
            GenericClasses.PreparaPendenciaSpools.GerarPendenciaSpools(contrato, discId, null, null);

        }
    }
}
