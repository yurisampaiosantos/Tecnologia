using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionIntLocaisDTO : List<IntLocaisDTO> { }
    //====================================================================
    public class IntLocaisDTO : BaseDTO
    {
        private decimal inloId;
        private string inloNome;
        //====================================================================
        public enum attributeName { INLO_ID, INLO_NOME };
        public enum propertyName { InloId, InloNome };
        //====================================================================
        private static int length = 2;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal InloId { get { return inloId; } set { inloId = value; } }
        public string InloNome { get { return inloNome; } set { inloNome = TruncateValue(value, 50); } }
    }
}
