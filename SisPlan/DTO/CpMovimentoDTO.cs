using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpMovimentoDTO : List<CpMovimentoDTO> { }
    //====================================================================
    public class CpMovimentoDTO : BaseDTO
    {
        private decimal moviId;
        private string moviCntrCodigo;
        private decimal moviPastaId;
        private string moviUsuaLogin;
        private DateTime moviDate;
        private string moviCreatedBy;
        private decimal moviStmoId;
        private decimal moviInGrd;
        //====================================================================
        public decimal MoviId { get { return moviId; } set { moviId = value; } }
        public string MoviCntrCodigo { get { return moviCntrCodigo; } set { moviCntrCodigo = TruncateValue(value, 10); } }
        public decimal MoviPastaId { get { return moviPastaId; } set { moviPastaId = value; } }
        public string MoviUsuaLogin { get { return moviUsuaLogin; } set { moviUsuaLogin = TruncateValue(value, 50); } }
        public DateTime MoviDate { get { return moviDate; } set { moviDate = value; } }
        public string MoviCreatedBy { get { return moviCreatedBy; } set { moviCreatedBy = TruncateValue(value, 50); } }
        public decimal MoviStmoId { get { return moviStmoId; } set { moviStmoId = value; } }
        public decimal MoviInGRD { get { return moviInGrd; } set { moviInGrd = value; } }
    }
}
