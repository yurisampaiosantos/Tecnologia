using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcAcuracidadeDTO : List<VwAcAcuracidadeDTO> { }
    //====================================================================
    public class VwAcAcuracidadeDTO : BaseDTO
    {
        //====================================================================
        public string SbcnSigla { get; set; }
        public string TipoAvanco { get; set; }
        public DateTime DataAvanco { get; set; }
        public decimal FoseDiscId { get; set; }
        public string DiscNome { get; set; }
        public string FcmeSigla { get; set; }
        public string FcesSigla { get; set; }
        public string FcesWbs { get; set; }
        public string FoseNumero { get; set; }
        public string AtivSig { get; set; }
        public string AtivNome { get; set; }
        public string TstfUnidadeRegional { get; set; }
        public string Regiao { get; set; }
        public string Localizacao { get; set; }
        public string Equipe { get; set; }
        public decimal FosmId { get; set; }
        public decimal PercentualAvanco { get; set; }
        public decimal FoseQtdPrevista { get; set; }
        public decimal FcesPesoRelCron { get; set; }
        public decimal QtdAvancoPond { get; set; }
        public string UnmeSigla { get; set; }
        public decimal QtdAvancoReal { get; set; }
        public decimal FosmFoseId { get; set; }
        public decimal FosmFcesId { get; set; }
        public decimal FcesFcmeId { get; set; }
        public decimal FcmeId { get; set; }
    }
}