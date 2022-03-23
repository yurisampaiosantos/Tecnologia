using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcLocalizacaoDTO : List<AcLocalizacaoDTO> { }
    //====================================================================
    public class AcLocalizacaoDTO : BaseDTO
    {
        private decimal localizacaoId;
        private string localizacaoNome;
        //====================================================================
        public enum attributeName { LOCALIZACAO_ID, LOCALIZACAO_NOME };
        public enum propertyName { LocalizacaoId, LocalizacaoNome };
        //====================================================================
        private static int length = 2;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal LocalizacaoId { get { return localizacaoId; } set { localizacaoId = value; } }
        public string LocalizacaoNome { get { return localizacaoNome; } set { localizacaoNome = TruncateValue(value, 50); } }
    }
}
