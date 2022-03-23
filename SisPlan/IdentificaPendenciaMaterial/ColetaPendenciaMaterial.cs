using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Identifica as pendências de materiais da conversão, para as plataformas e respectivas disciplinas (Tabela => AC_PENDENCIA_MATERIAL)
namespace IdentificaPendenciaMaterial
{
    class ColetaPendenciaMaterial
    {
        static string contrato = "Conversão";
        static void Main(string[] args)
        {
            GenericClasses.PreparaSaidasRelatorios.SaidaPendenciaMateriais(contrato);
        }
    }
}
