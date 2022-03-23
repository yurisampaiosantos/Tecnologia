using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentificaAplicacaoMaterial
{
    class ColetaMaterial
    {
        static string contrato = "Conversão";
        static void Main(string[] args)
        {
            GenericClasses.Material.AplicaMaterial(contrato);
        }
    }
}
