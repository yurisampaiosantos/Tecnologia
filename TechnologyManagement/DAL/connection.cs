using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.OleDb;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace goliath.pdf.DAL
{
    public class connection
    {
        public static string StringToConnect
        {
            get
            {                                                                                                          
                //return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=drydock)(PORT= 1521)))(CONNECT_DATA=(SID=eep)(SERVER=DEDICATED)));User Id=EEP_TECNOLOGIA;Password=eepSA1986";
                return "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=WCHLDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=DEVBOX)(SERVER=DEDICATED)));User Id=EEP_TECNOLOGIA;Password=eep_tecnologia@eep";
            }
        }
    } 
}
