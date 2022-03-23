using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace IdentificaAtributoPersonalizado
{
    class ColetaAtributoPersonalizado
    {
        static string contrato = "Conversão";
        static DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
        static void Main(string[] args)
        {
            try
            {
                //Calcula a semana ANTERIOR à corrente
                s = BLL.AcSemanaBLL.GetSemanaAnteriorCorrente();
               GenericClasses.PreparaCelulasTrabalho.GerarControleProducaoBase(contrato, s.SemaId);
                //GenericClasses.PreparaCelulasTrabalho.GerarControleProducaoBase(contrato, 525);
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}




