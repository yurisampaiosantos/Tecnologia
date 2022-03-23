using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpSubsistemaOperacionalDTO : List<CpSubsistemaOperacionalDTO> { }
    //====================================================================
    public class CpSubsistemaOperacionalDTO : BaseDTO
    {
        private decimal ssopId;
        private string ssopCntrCodigo;
        private string ssopDescricao;
        private string ssopSbcnSigla;
        private string ssopCodigo;
        //====================================================================
        public enum attributeName { SSOP_ID, SSOP_CNTR_CODIGO, SSOP_DESCRICAO, SSOP_SBCN_SIGLA, SSOP_CODIGO };
        public enum propertyName { SsopId, SsopCntrCodigo, SsopDescricao, SsopSbcnSigla, SsopCodigo };
        //====================================================================
        private static int length = 5;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal SsopId { get { return ssopId; } set { ssopId = value; } }
        public string SsopCntrCodigo { get { return ssopCntrCodigo; } set { ssopCntrCodigo = TruncateValue(value, 30); } }
        public string SsopDescricao { get { return ssopDescricao; } set { ssopDescricao = TruncateValue(value, 150); } }
        public string SsopSbcnSigla { get { return ssopSbcnSigla; } set { ssopSbcnSigla = TruncateValue(value, 10); } }
        public string SsopCodigo { get { return ssopCodigo; } set { ssopCodigo = TruncateValue(value, 10); } }
    }
}