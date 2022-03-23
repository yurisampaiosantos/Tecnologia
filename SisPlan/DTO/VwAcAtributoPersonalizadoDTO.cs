using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcAtributoPersonalizadoDTO : List<VwAcAtributoPersonalizadoDTO> { }
    //====================================================================
    public class VwAcAtributoPersonalizadoDTO : BaseDTO
    {
        public decimal ID { get; set; }
        public string FoseCntrCodigo { get; set; }
        public decimal SbcnId { get; set; }
        public string SbcnSigla { get; set; }
        public decimal DiscId { get; set; }
        public string DiscNome { get; set; }
        public decimal FoseId { get; set; }
        public string FoseNumero { get; set; }
        public string FcmeSigla { get; set; }
        public string FcesSigla { get; set; }
        public string AtpeNome { get; set; }
        public string DescricaoAtributo { get; set; }
        public decimal FoseQtdPrevista { get; set; }
        public decimal FosmId { get; set; }
    }
}
