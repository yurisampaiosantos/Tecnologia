using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DAL
{
    public class Dados
    {
        public static string StringDeConexaoOracle
        {
            get
            {//MSDAORA                 
                //------produção                                                                             
                //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_ERF;Password=RecETiiFEDC20";
                //------Desenvolvimento                                                                             
                return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=F_APP_ERF;Password=FcnEfT20";
            }
        }

        public static string StringDeConexaoSqlServer
        {
            get
            {//SQL Server                 
                //------produção              
                return @"Data Source=WDCBALANCA01\SQLQBIT;Initial Catalog=Balanca;User ID=enseada;Password=ein@2021";                
            }
        }
    }
}
