using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericClasses
{
    static public class Semanas
    {
        static public DTO.AcSemanaDTO GetSemanaCorrente()
        {
            DateTime today = System.DateTime.Today;
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = BLL.AcSemanaBLL.GetObject("TO_DATE(SYSDATE,'DD/MM/YYYY') BETWEEN TO_DATE(X.SEMA_DATA_INICIO,'DD/MM/YYYY') AND TO_DATE(X.SEMA_DATA_FIM,'DD/MM/YYYY')");
            return s;
        }
    }
}
