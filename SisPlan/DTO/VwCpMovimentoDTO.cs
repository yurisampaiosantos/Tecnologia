using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwCpMovimentoDTO : List<VwCpMovimentoDTO> { }
    //====================================================================
    public class VwCpMovimentoDTO : BaseDTO
    {
        private decimal moviId;
        private string moviCntrCodigo;
        private decimal moviPastaId;
        private string pastaCodigo;
        private DateTime moviDate;
        private string moviDateDesc;
        private string locaDescricao;
        private string moviUsuaLogin;
        private decimal usuaActive;
        private decimal usuaAgCriarPunch;
        private decimal usuaAgClassPunch;
        private decimal usuaAgStatusPunch;
        private decimal usuaAgCriarPendmat;
        private decimal usuaAgStatusPendmat;
        private string moviCreatedBy;
        private decimal moviStmoId;
        private string stmoDescricao;
        private decimal moviInGrd;
        private decimal smgrId;
        private string smgrDescricao;
        
        //====================================================================
        public decimal MoviId { get { return moviId; } set { moviId = value; } }
        public string MoviCntrCodigo { get { return moviCntrCodigo; } set { moviCntrCodigo = TruncateValue(value, 10); } }
        public decimal MoviPastaId { get { return moviPastaId; } set { moviPastaId = value; } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public DateTime MoviDate { get { return moviDate; } set { moviDate = value; } }
        public string MoviDateDesc { get { return moviDateDesc; } set { moviDateDesc = TruncateValue(value, 19); } }
        public string LocaDescricao { get { return locaDescricao; } set { locaDescricao = TruncateValue(value, 50); } }
        public string MoviUsuaLogin { get { return moviUsuaLogin; } set { moviUsuaLogin = TruncateValue(value, 50); } }
        public decimal UsuaActive { get { return usuaActive; } set { usuaActive = value; } }
        public decimal UsuaAgCriarPunch { get { return usuaAgCriarPunch; } set { usuaAgCriarPunch = value; } }
        public decimal UsuaAgClassPunch { get { return usuaAgClassPunch; } set { usuaAgClassPunch = value; } }
        public decimal UsuaAgStatusPunch { get { return usuaAgStatusPunch; } set { usuaAgStatusPunch = value; } }
        public decimal UsuaAgCriarPendmat { get { return usuaAgCriarPendmat; } set { usuaAgCriarPendmat = value; } }
        public decimal UsuaAgStatusPendmat { get { return usuaAgStatusPendmat; } set { usuaAgStatusPendmat = value; } }
        public string MoviCreatedBy { get { return moviCreatedBy; } set { moviCreatedBy = TruncateValue(value, 50); } }
        public decimal MoviStmoId { get { return moviStmoId; } set { moviStmoId = value; } }
        public string StmoDescricao { get { return stmoDescricao; } set { stmoDescricao = TruncateValue(value, 50); } }
        public decimal MoviInGrd { get { return moviInGrd; } set { moviInGrd = value; } }
        public decimal SmgrId { get { return smgrId; } set { smgrId = value; } }
        public string SmgrDescricao { get { return smgrDescricao; } set { smgrDescricao = TruncateValue(value, 50); } }
    }
}
