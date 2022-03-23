using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpAreaRespPendenciaDTO : List<CpAreaRespPendenciaDTO> { }
    //====================================================================
    public class CpAreaRespPendenciaDTO : BaseDTO
    {
        private string arpeCntrCodigo;
        private decimal arpeId;
        private string arpeDescricao;
        private string arpeEmailAgente;
        private string arpeEmailLeader;
        //====================================================================
        public enum attributeName { ARPE_CNTR_CODIGO, ARPE_ID, ARPE_DESCRICAO, ARPE_EMAIL_AGENTE, ARPE_EMAIL_LEADER };
        public enum propertyName { ArpeCntrCodigo, ArpeId, ArpeDescricao, ArpeEmailAgente, ArpeEmailLeader };
        //====================================================================
        private static int length = 5;
        public static int Length { get { return length; } }
        //====================================================================
        public string ArpeCntrCodigo { get { return arpeCntrCodigo; } set { arpeCntrCodigo = TruncateValue(value, 50); } }
        public decimal ArpeId { get { return arpeId; } set { arpeId = value; } }
        public string ArpeDescricao { get { return arpeDescricao; } set { arpeDescricao = TruncateValue(value, 50); } }
        public string ArpeEmailAgente { get { return arpeEmailAgente; } set { arpeEmailAgente = TruncateValue(value, 100); } }
        public string ArpeEmailLeader { get { return arpeEmailLeader; } set { arpeEmailLeader = TruncateValue(value, 100); } }
    }
}
