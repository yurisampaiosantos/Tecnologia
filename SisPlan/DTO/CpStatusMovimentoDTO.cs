using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpStatusMovimentoDTO : List<CpStatusMovimentoDTO> { }
    //====================================================================
    public class CpStatusMovimentoDTO : BaseDTO
    {
        private decimal stmoId;
        private string stmoDescricao;
        private decimal stmoLocaId;
        private decimal stmoSequence;
        //====================================================================
        public enum attributeName { STMO_ID, STMO_DESCRICAO, STMO_LOCA_ID, STMO_SEQUENCE };
        public enum propertyName { StmoId, StmoDescricao, StmoLocaId, StmoSequence };
        //====================================================================
        private static int length = 4;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal StmoId { get { return stmoId; } set { stmoId = value; } }
        public string StmoDescricao { get { return stmoDescricao; } set { stmoDescricao = TruncateValue(value, 50); } }
        public decimal StmoLocaId { get { return stmoLocaId; } set { stmoLocaId = value; } }
        public decimal StmoSequence { get { return stmoSequence; } set { stmoSequence = value; } }
    }
}
