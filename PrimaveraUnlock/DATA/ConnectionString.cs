using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
   public class ConnectionString
    {
       public string Connection(string connection)
       {
           string result = "";
           if (connection == "Sondas")
           {
               //homolocacao
             //  result = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=WCHLBDHML.eepsa.com.br)(PORT= 1522)))(CONNECT_DATA=(SID=EEPSONDHML)(SERVER=DEDICATED)));User Id=admuser;Password=admuser";
             //produção
               result = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCHLRAC-SCAN.eepsa.com.br)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=EEPSOND)(SERVER=DEDICATED)));User Id=admuser;Password=admuser";
           }
           if (connection == "Conversão")
           {
               result = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCHLRAC-SCAN.eepsa.com.br)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=EEPCONV)(SERVER=DEDICATED)));User Id=admuser;Password=admuser";
           }
           if (connection == "CEP")
           {
               result = "Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCHLRAC-SCAN.eepsa.com.br)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=EEPCEP)(SERVER=DEDICATED)));User Id=admuser;Password=admuser";
           }
           return result;
       }
   }
}
