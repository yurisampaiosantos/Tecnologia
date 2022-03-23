using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpTipoPendenciaDTO : List<CpTipoPendenciaDTO> { }
    //====================================================================
    public class CpTipoPendenciaDTO : BaseDTO
    {
        private decimal tipeId;
        private string tipeDescricao;
        //====================================================================
        public enum attributeName { TIPE_ID, TIPE_DESCRICAO };
        public enum propertyName { TipeId, TipeDescricao };
        //====================================================================
        private static int length = 2;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal TipeId { get { return tipeId; } set { tipeId = value; } }
        public string TipeDescricao { get { return tipeDescricao; } set { tipeDescricao = TruncateValue(value, 50); } }
    }
}