using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwCpPastaUltMovDTO : List<VwCpPastaUltMovDTO> { }
    //====================================================================
    public class VwCpPastaUltMovDTO : BaseDTO
    {
        private decimal moviId;
        private string moviCntrCodigo;
        private string pastaSbcnSigla;
        private string pastaFase;
        private string pastaBloco;
        private string ssopCodigo;
        private string ssopDescricao;
        private decimal moviPastaId;
        private string pastaCodigo;
        private DateTime moviDate;
        private string moviDateDesc;
        private decimal stmoLocaId;
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
        private string smgrDescricao;
        private string stmoDescricao;
        private decimal discId;
        private string discSigla;
        private string discNome;
        private string areaDescricao;
        private string escoDescricao;
        private decimal stmoSequence;
        private decimal moviInGrd;
        private decimal smgrId;
        private decimal pastaSsopId;
        private decimal areaId;
        private decimal pastaEscoId;

        //====================================================================
        public decimal MoviId { get { return moviId; } set { moviId = value; } }
        public string MoviCntrCodigo { get { return moviCntrCodigo; } set { moviCntrCodigo = TruncateValue(value, 10); } }
        public string PastaSbcnSigla { get { return pastaSbcnSigla; } set { pastaSbcnSigla = TruncateValue(value, 10); } }
        public string PastaFase { get { return pastaFase; } set { pastaFase = TruncateValue(value, 10); } }
        public string PastaBloco { get { return pastaBloco; } set { pastaBloco = TruncateValue(value, 10); } }
        public string SsopCodigo { get { return ssopCodigo; } set { ssopCodigo = TruncateValue(value, 10); } }
        public string SsopDescricao { get { return ssopDescricao; } set { ssopDescricao = TruncateValue(value, 150); } }
        public decimal MoviPastaId { get { return moviPastaId; } set { moviPastaId = value; } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public DateTime MoviDate { get { return moviDate; } set { moviDate = value; } }
        public string MoviDateDesc { get { return moviDateDesc; } set { moviDateDesc = TruncateValue(value, 80); } }
        public decimal StmoLocaId { get { return stmoLocaId; } set { stmoLocaId = value; } }
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
        public string SmgrDescricao { get { return smgrDescricao; } set { smgrDescricao = TruncateValue(value, 50); } }
        public string StmoDescricao { get { return stmoDescricao; } set { stmoDescricao = TruncateValue(value, 50); } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscSigla { get { return discSigla; } set { discSigla = TruncateValue(value, 50); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 200); } }
        public string AreaDescricao { get { return areaDescricao; } set { areaDescricao = TruncateValue(value, 50); } }
        public string EscoDescricao { get { return escoDescricao; } set { escoDescricao = TruncateValue(value, 50); } }
        public decimal StmoSequence { get { return stmoSequence; } set { stmoSequence = value; } }
        public decimal MoviInGrd { get { return moviInGrd; } set { moviInGrd = value; } }
        public decimal SmgrId { get { return smgrId; } set { smgrId = value; } }
        public decimal PastaSsopId { get { return pastaSsopId; } set { pastaSsopId = value; } }
        public decimal AreaId { get { return areaId; } set { areaId = value; } }
        public decimal PastaEscoId { get { return pastaEscoId; } set { pastaEscoId = value; } }
        public decimal PastaStpaId { get; set; }
        public string StpaDescricao { get; set; }
        public string PastaExecutor { get; set; }
        public string PunchDescricao { get; set; }
        public string PunchSituacao { get; set; }
        public decimal PunchStpuId { get; set; }
        public string PunchStpuDescricao { get; set; }
        public string PastaObservacao { get; set; }
        public string PastaTesteLiberado { get; set; }

    }
}
