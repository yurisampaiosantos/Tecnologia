using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class ListEquipes
    {
        public decimal EQUIPE_ID { get; set; }
        public string TEAM_CODE { get; set; }
        public string EQUIPE { get; set; }
        public decimal RP_ID { get; set; }
        public string RP_DESCRIPTION { get; set; }
        public decimal LEADER_ID { get; set; }
        public string LIDER { get; set; }
        public string LIDER_IDENTIFICATION { get; set; }
        public decimal GROUP_ID { get; set; }
        public string GROUP_TEAM_DESCRIPTION { get; set; }
        public decimal SUPERVISOR_ID { get; set; }
        public string SUPERVISOR { get; set; }
        public decimal LOCAL_ID { get; set; }
        public string LOCAL_DESCRIPTION { get; set; }
    }
}
