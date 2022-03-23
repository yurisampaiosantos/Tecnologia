using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using MODEL;

namespace BUSINESS
{
   public class UsessionBusiness
    {
        public List<Usession> SelectUsession(string connection)
        {
            UsessionData usessionData = new UsessionData();
            return usessionData.SelectUsession(connection);
        }

        public void UpdateUsession(string connection, decimal sessionId)
        {
            UsessionData usessionData = new UsessionData();
            usessionData.UpdateUsession(connection, sessionId);
        }

         
    }
}
