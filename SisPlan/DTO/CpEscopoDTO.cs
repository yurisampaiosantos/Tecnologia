using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpEscopoDTO : List<CpEscopoDTO> { }
    //====================================================================
    public class CpEscopoDTO : BaseDTO
    {
        private decimal escoId;
        private string escoDescricao;
        private string escoCntrCodigo;
        //====================================================================
        public enum attributeName { ESCO_ID, ESCO_DESCRICAO, ESCO_CNTR_CODIGO };
        public enum propertyName { EscoId, EscoDescricao, EscoCntrCodigo };
        //====================================================================
        private static int length = 3;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal EscoId { get { return escoId; } set { escoId = value; } }
        public string EscoDescricao { get { return escoDescricao; } set { escoDescricao = TruncateValue(value, 50); } }
        public string EscoCntrCodigo { get { return escoCntrCodigo; } set { escoCntrCodigo = TruncateValue(value, 10); } }
    }
}
