using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpLocalizacaoDTO : List<CpLocalizacaoDTO> { }
    //====================================================================
    public class CpLocalizacaoDTO : BaseDTO
    {
        private decimal locaId;
        private string locaDescricao;
        private string locaCntrCodigo;
        //====================================================================
        public enum attributeName { LOCA_ID, LOCA_DESCRICAO, LOCA_CNTR_CODIGO };
        public enum propertyName { LocaId, LocaDescricao, LocaCntrCodigo };
        //====================================================================
        private static int length = 3;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal LocaId { get { return locaId; } set { locaId = value; } }
        public string LocaDescricao { get { return locaDescricao; } set { locaDescricao = TruncateValue(value, 50); } }
        public string LocaCntrCodigo { get { return locaCntrCodigo; } set { locaCntrCodigo = TruncateValue(value, 10); } }
    }
}
