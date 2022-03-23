using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificaMontagemTubulacao
{
    class ColetaMontagemTubulacao
    {
        static string contrato = "Conversão";
        static void Main(string[] args)
        {
            GenericClasses.PreparaMontagemTubulacao.GeraHistoricoSpool(contrato);
        }

    }
}
