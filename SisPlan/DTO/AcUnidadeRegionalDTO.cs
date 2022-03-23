using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcUnidadeRegionalDTO : List<AcUnidadeRegionalDTO> { }
    //====================================================================
    public class AcUnidadeRegionalDTO : BaseDTO
    {
        private decimal unreId;
        private string unreRegionLike;
        private string unreUnidadeRegional;
        private decimal unreSequence;
        //====================================================================
        public enum attributeName { UNRE_ID, UNRE_REGION_LIKE, UNRE_UNIDADE_REGIONAL, UNRE_SEQUENCE };
        public enum propertyName { UnreId, UnreRegionLike, UnreUnidadeRegional, UnreSequence };
        //====================================================================
        private static int length = 4;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal UnreId { get { return unreId; } set { unreId = value; } }
        public string UnreRegionLike { get { return unreRegionLike; } set { unreRegionLike = TruncateValue(value, 50); } }
        public string UnreUnidadeRegional { get { return unreUnidadeRegional; } set { unreUnidadeRegional = TruncateValue(value, 50); } }
        public decimal UnreSequence { get { return unreSequence; } set { unreSequence = value; } }
    }
}