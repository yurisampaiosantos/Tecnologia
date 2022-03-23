using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwCpPastaDTO : List<VwCpPastaDTO> { }
    //====================================================================
    public class VwCpPastaDTO : BaseDTO
    {
        private decimal pastaId;
        private string pastaCntrCodigo;
        private string pastaSbcnSigla;
        private string pastaCodigo;
        private string pastaFase;
        private string pastaBloco;
        private DateTime pastaProg;
        private string pastaObservacao;
        private string pastaRedirecionamento;
        private string discNome;
        private string escoDescricao;
        private string locaDescricao;
        private string ssopSbcnSigla;
        private string ssopCodigo;
        private string ssopDescricao;
        private string areaDescricao;
        private string stpaDescricao;
        private decimal pastaSsopId;
        private decimal pastaDiscId;
        private decimal pastaAreaId;
        private decimal pastaEscoId;
        private decimal pastaLocaId;
        private decimal pastaStpaId;
        //====================================================================
        public enum attributeName { PASTA_ID, PASTA_CNTR_CODIGO, PASTA_SBCN_SIGLA, PASTA_CODIGO, PASTA_FASE, PASTA_BLOCO, PASTA_PROG, PASTA_OBSERVACAO, PASTA_REDIRECIONAMENTO, DISC_NOME, ESCO_DESCRICAO, LOCA_DESCRICAO, SSOP_SBCN_SIGLA, SSOP_CODIGO, SSOP_DESCRICAO, AREA_DESCRICAO, STPA_DESCRICAO, PASTA_SSOP_ID, PASTA_DISC_ID, PASTA_AREA_ID, PASTA_ESCO_ID, PASTA_LOCA_ID, PASTA_STPA_ID };
        public enum propertyName { PastaId, PastaCntrCodigo, PastaSbcnSigla, PastaCodigo, PastaFase, PastaBloco, PastaProg, PastaObservacao, PastaTesteLiberado, PastaRedirecionamento, DiscNome, EscoDescricao, LocaDescricao, SsopSbcnSigla, SsopCodigo, SsopDescricao, AreaDescricao, StpaDescricao, PastaSsopId, PastaDiscId, PastaAreaId, PastaEscoId, PastaLocaId, PastaStpaId };
        //====================================================================
        private static int length = 23;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal PastaId { get { return pastaId; } set { pastaId = value; } }
        public string PastaCntrCodigo { get { return pastaCntrCodigo; } set { pastaCntrCodigo = TruncateValue(value, 10); } }
        public string PastaSbcnSigla { get { return pastaSbcnSigla; } set { pastaSbcnSigla = TruncateValue(value, 10); } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public string PastaFase { get { return pastaFase; } set { pastaFase = TruncateValue(value, 10); } }
        public string PastaBloco { get { return pastaBloco; } set { pastaBloco = TruncateValue(value, 10); } }
        public DateTime PastaProg { get { return pastaProg; } set { pastaProg = value; } }
        public string PastaObservacao { get { return pastaObservacao; } set { pastaObservacao = TruncateValue(value, 200); } }
        public string PastaRedirecionamento { get { return pastaRedirecionamento; } set { pastaRedirecionamento = TruncateValue(value, 50); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 200); } }
        public string EscoDescricao { get { return escoDescricao; } set { escoDescricao = TruncateValue(value, 50); } }
        public string LocaDescricao { get { return locaDescricao; } set { locaDescricao = TruncateValue(value, 50); } }
        public string SsopSbcnSigla { get { return ssopSbcnSigla; } set { ssopSbcnSigla = TruncateValue(value, 10); } }
        public string SsopCodigo { get { return ssopCodigo; } set { ssopCodigo = TruncateValue(value, 10); } }
        public string SsopDescricao { get { return ssopDescricao; } set { ssopDescricao = TruncateValue(value, 150); } }
        public string AreaDescricao { get { return areaDescricao; } set { areaDescricao = TruncateValue(value, 50); } }
        public string StpaDescricao { get { return stpaDescricao; } set { stpaDescricao = TruncateValue(value, 50); } }
        public decimal PastaSsopId { get { return pastaSsopId; } set { pastaSsopId = value; } }
        public decimal PastaDiscId { get { return pastaDiscId; } set { pastaDiscId = value; } }
        public decimal PastaAreaId { get { return pastaAreaId; } set { pastaAreaId = value; } }
        public decimal PastaEscoId { get { return pastaEscoId; } set { pastaEscoId = value; } }
        public decimal PastaLocaId { get { return pastaLocaId; } set { pastaLocaId = value; } }
        public decimal PastaStpaId { get { return pastaStpaId; } set { pastaStpaId = value; } }
        public decimal PastaTesteLiberado { get; set; }
    }
}
