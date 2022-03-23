using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpAreaDTO : List<CpAreaDTO> { }
    //====================================================================
    public class CpAreaDTO : BaseDTO
    {
        private decimal areaId;
        private string areaDescricao;
        private string areaCntrCodigo;
        //====================================================================
        public enum attributeName { AREA_ID, AREA_DESCRICAO, AREA_CNTR_CODIGO };
        public enum propertyName { AreaId, AreaDescricao, AreaCntrCodigo };
        //====================================================================
        private static int length = 3;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal AreaId { get { return areaId; } set { areaId = value; } }
        public string AreaDescricao { get { return areaDescricao; } set { areaDescricao = TruncateValue(value, 50); } }
        public string AreaCntrCodigo { get { return areaCntrCodigo; } set { areaCntrCodigo = TruncateValue(value, 10); } }
    }
}
