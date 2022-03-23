using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPrevistoDTO : List<CpPrevistoDTO> { }
    //====================================================================
    public class CpPrevistoDTO : BaseDTO
    {
        public decimal CascoMec { get ; set; }
        public decimal CascoTub { get ; set; }
        public decimal CascoEle { get ; set; }
        public decimal CascoIns { get ; set; }
        public decimal CascoTlc { get ; set; }
        public decimal CascoTot { get ; set; }

        public decimal ErprMec { get; set; }
        public decimal ErprTub { get; set; }
        public decimal ErprEle { get; set; }
        public decimal ErprIns { get; set; }
        public decimal ErprTlc { get; set; }
        public decimal ErprTot { get; set; }

        public decimal MsMec { get; set; }
        public decimal MsTub { get; set; }
        public decimal MsEle { get; set; }
        public decimal MsIns { get; set; }
        public decimal MsTlc { get; set; }
        public decimal MsTot { get; set; }

        public decimal MaMec { get; set; }
        public decimal MaTub { get; set; }
        public decimal MaEle { get; set; }
        public decimal MaIns { get; set; }
        public decimal MaTlc { get; set; }
        public decimal MaTot { get; set; }
    }
}