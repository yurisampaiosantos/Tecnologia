using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcSetorDTO : List<AcSetorDTO> { }
    //====================================================================
    public class AcSetorDTO : BaseDTO
    {
        private decimal setorId;
        private string setorNome;
        //====================================================================
        public enum attributeName { SETOR_ID, SETOR_NOME };
        public enum propertyName { SetorId, SetorNome };
        //====================================================================
        private static int length = 2;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal SetorId { get { return setorId; } set { setorId = value; } }
        public string SetorNome { get { return setorNome; } set { setorNome = TruncateValue(value, 30); } }
    }
}
