using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPastaDTO : List<CpPastaDTO> { }
    //====================================================================
    public class CpPastaDTO : BaseDTO
    {
        private decimal pastaId;
        private string pastaCntrCodigo;
        private string pastaSbcnSigla;
        private string pastaCodigo;
        private decimal? pastaSsopId;
        private decimal pastaDiscId;
        private decimal? pastaAreaId;
        private decimal pastaEscoId;
        private decimal pastaLocaId;
        private string pastaFase;
        private string pastaBloco;
        private DateTime? pastaProg;
        private string pastaRedirecionamento;
        private string pastaObservacao;
        private decimal pastaStpaId;
        private decimal pastaZonaId;
        private string pastaResponsavel;
        private string pastaRegiao;
        private decimal pastaTesteLiberado;
        //====================================================================
        public decimal PastaId { get { return pastaId; } set { pastaId = value; } }
        public string PastaCntrCodigo { get { return pastaCntrCodigo; } set { pastaCntrCodigo = TruncateValue(value, 10); } }
        public string PastaSbcnSigla { get { return pastaSbcnSigla; } set { pastaSbcnSigla = TruncateValue(value, 10); } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public decimal? PastaSsopId { get { return pastaSsopId; } set { pastaSsopId = value; } }
        public decimal PastaDiscId { get { return pastaDiscId; } set { pastaDiscId = value; } }
        public decimal? PastaAreaId { get { return pastaAreaId; } set { pastaAreaId = value; } }
        public decimal PastaEscoId { get { return pastaEscoId; } set { pastaEscoId = value; } }
        public decimal PastaLocaId { get { return pastaLocaId; } set { pastaLocaId = value; } }
        public string PastaFase { get { return pastaFase; } set { pastaFase = TruncateValue(value, 10); } }
        public string PastaBloco { get { return pastaBloco; } set { pastaBloco = TruncateValue(value, 20); } }
        public DateTime? PastaProg { get { return pastaProg; } set { pastaProg = value; } }
        public string PastaRedirecionamento { get { return pastaRedirecionamento; } set { pastaRedirecionamento = value; } }
        public string PastaObservacao { get { return pastaObservacao; } set { pastaObservacao = TruncateValue(value, 200); } }
        public decimal PastaStpaId { get { return pastaStpaId; } set { pastaStpaId = value; } }
        public decimal PastaZonaId { get { return pastaZonaId; } set { pastaZonaId = value; } }
        public string PastaResponsavel { get { return pastaResponsavel; } set { pastaResponsavel = TruncateValue(value, 20); } }
        public string PastaRegiao { get { return pastaRegiao; } set { pastaRegiao = TruncateValue(value, 20); } }
        public string PastaExecutor { get; set; }
        public decimal PastaTesteLiberado { get; set; }
    }
}
