using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentificaAvancosFOSE
{
    class ColetaAvancosFOSE
    {
        static string contrato = "Conversão";
        static string discId = "";

        static void Main(string[] args)
        {
            string dataInicial = "22/06/2012 00:00:00";
            //string dataInicial = "09/03/2015 00:00:00";
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = BLL.AcSemanaBLL.GetSemanaAnteriorCorrente();
            dataInicial = s.SemaDataInicio.ToString();
            
            //ELÉTRICA
            //Coleta Avanços das Folhas de Servico da disciplina 6 - Elétrica
            discId = "6";
            Avancos.Coleta(contrato, discId, dataInicial);

            //ELÉTRICA
            //Coleta Avanços das Folhas de Servico da disciplina 4 - Instrumentação
            discId = "4";
            Avancos.Coleta(contrato, discId, dataInicial);
        }
    }
}
