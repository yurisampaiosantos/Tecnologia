using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace goliath.licensecapture.DAL
{
    class Dados
    {
        public static string StringDeConexao
        {
            get
            {
                return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=drydock)(PORT= 1521)))(CONNECT_DATA=(SID=eep)(SERVER=DEDICATED)));User Id=EEP_ENGINEERING;Password=eepSA1986";
            }
        }
    }
}
