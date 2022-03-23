using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcQuantidadeAtividadeDTO : List<VwAcQuantidadeAtividadeDTO> { }
    //====================================================================
    public class VwAcQuantidadeAtividadeDTO : BaseDTO
    {
        public decimal ID { get; set; }
        public string PocrCntrCodigo { get; set; }
        public DateTime PocrDt { get; set; }
        public string AtivSig { get; set; }
        public string AtivNome { get; set; }
        public decimal AtreQtd { get; set; }
        public DateTime AtreDtInicio { get; set; }
        public DateTime AtreDtFim { get; set; }
        public decimal PocrId { get; set; }
        public decimal AtreId { get; set; }
        public decimal AtivId { get; set; }   
    }
}
