using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjPlatAreaDTO : List<ProjPlatAreaDTO> { }
    //====================================================================
    public class ProjPlatAreaDTO : BaseDTO
    {
        private decimal id;
        private string plataforma;
        private string modulo;
        private string bloco;
        private string arapSigla;
        private decimal arapId;
        private string arapCntrCodigo;
        //====================================================================
        public enum attributeName { ID, PLATAFORMA, MODULO, BLOCO, ARAP_SIGLA, ARAP_ID, ARAP_CNTR_CODIGO };
        public enum propertyName { ID, Plataforma, Modulo, Bloco, ArapSigla, ArapId, ArapCntrCodigo };
        //====================================================================
        private static int length = 7;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Plataforma { get { return plataforma; } set { plataforma = TruncateValue(value, 10); } }
        public string Modulo { get { return modulo; } set { modulo = TruncateValue(value, 20); } }
        public string Bloco { get { return bloco; } set { bloco = TruncateValue(value, 20); } }
        public string ArapSigla { get { return arapSigla; } set { arapSigla = TruncateValue(value, 20); } }
        public decimal ArapId { get { return arapId; } set { arapId = value; } }
        public string ArapCntrCodigo { get { return arapCntrCodigo; } set { arapCntrCodigo = TruncateValue(value, 20); } }
    }
}
