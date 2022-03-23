using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcStatusFoseUpdtCntrlDTO : List<AcStatusFoseUpdtCntrlDTO> { }
    //====================================================================
    public class AcStatusFoseUpdtCntrlDTO : BaseDTO
    {
        private decimal sfucId;
        private string sfucCntrCodigo;
        private decimal sfucDiscId;
        private string sfucSbcnSigla;
        private string sfucFcmeSigla;
        private string sfucDataCorteUpdateControl;
        //====================================================================
        public enum attributeName { SFUC_ID, SFUC_CNTR_CODIGO, SFUC_DISC_ID, SFUC_SBCN_SIGLA, SFUC_FCME_SIGLA, SFUC_DATA_CORTE_UPDATE_CONTROL };
        public enum propertyName { SfucId, SfucCntrCodigo, SfucDiscId, SfucSbcnSigla, SfucFcmeSigla, SfucDataCorteUpdateControl };
        //====================================================================
        private static int length = 6;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal SfucId { get { return sfucId; } set { sfucId = value; } }
        public string SfucCntrCodigo { get { return sfucCntrCodigo; } set { sfucCntrCodigo = TruncateValue(value, 50); } }
        public decimal SfucDiscId { get { return sfucDiscId; } set { sfucDiscId = value; } }
        public string SfucSbcnSigla { get { return sfucSbcnSigla; } set { sfucSbcnSigla = TruncateValue(value, 30); } }
        public string SfucFcmeSigla { get { return sfucFcmeSigla; } set { sfucFcmeSigla = TruncateValue(value, 30); } }
        public string SfucDataCorteUpdateControl { get { return sfucDataCorteUpdateControl; } set { sfucDataCorteUpdateControl = value; } }
    }
}