using System;
using System.IO;

namespace SiscomexEnseada
{
    public class Conexao
    {
        //producao 
        // public static string StringDeConexao = "User Id=F_APP_ESISEPC;Password=EpCAppPRD20;Data Source=ldcrac202/CRP01.intranet.local";

        //Desenvolvimentio
         public static string StringDeConexao = "User Id=ESISEPC;Password=DevEPC18;Data Source=LDCDBDEV01.intranet.local/CRP01DEV.intranet.local";

        //-----------------------------------------------------------------------------------------//

        //producao 
        public static string ConecaoSiscomex = "https://portalunico.siscomex.gov.br";
        //Desenvolvimentio
        //public static string ConecaoSiscomex = "https://val.portalunico.siscomex.gov.br";

        //-----------------------------------------------------------------------------------------//

        //producao 
        public static string DiretorioValidador = @"\\wdciis03\Siscomex\XSD\Validador\RecepcaoNFE.xsd";
        //Desenvolvimentio
        //public static string DiretorioValidador = @"C:\Users\yuri.sampaio.INTRANET\source\repos\SiscomexEnseada\DAL\XSD\Validador\RecepcaoNFE.xsd";
    }
}