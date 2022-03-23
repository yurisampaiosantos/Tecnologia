using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcUnidadeRegionalSisepcDTO : List<AcUnidadeRegionalSisepcDTO> { }
    //====================================================================
    public class AcUnidadeRegionalSisepcDTO : BaseDTO
    {
        private decimal urspId;
        private string urspCntrCodigo;
        private string urspSbcnSigla;
        private decimal urspDiscId;
        private string urspFcmeSigla;
        private decimal urspFoseId;
        private string urspFoseNumero;
        private string urspRegiao;
        private string urspUnidadeRegional;
        private decimal urspQtdPrevista;
        private string ursp;
        private decimal urspSequence;
        //====================================================================
        public enum attributeName { URSP_ID, URSP_CNTR_CODIGO, URSP_SBCN_SIGLA, URSP_DISC_ID, URSP_FCME_SIGLA, URSP_FOSE_ID, URSP_FOSE_NUMERO, URSP_REGIAO, URSP_UNIDADE_REGIONAL, URSP_QTD_PREVISTA, URSP_, URSP_SEQUENCE };
        public enum propertyName { UrspId, UrspCntrCodigo, UrspSbcnSigla, UrspDiscId, UrspFcmeSigla, UrspFoseId, UrspFoseNumero, UrspRegiao, UrspUnidadeRegional, UrspQtdPrevista, Ursp, UrspSequence };
        //====================================================================
        private static int length = 12;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal UrspId { get { return urspId; } set { urspId = value; } }
        public string UrspCntrCodigo { get { return urspCntrCodigo; } set { urspCntrCodigo = TruncateValue(value, 20); } }
        public string UrspSbcnSigla { get { return urspSbcnSigla; } set { urspSbcnSigla = TruncateValue(value, 20); } }
        public decimal UrspDiscId { get { return urspDiscId; } set { urspDiscId = value; } }
        public string UrspFcmeSigla { get { return urspFcmeSigla; } set { urspFcmeSigla = TruncateValue(value, 50); } }
        public decimal UrspFoseId { get { return urspFoseId; } set { urspFoseId = value; } }
        public string UrspFoseNumero { get { return urspFoseNumero; } set { urspFoseNumero = TruncateValue(value, 150); } }
        public string UrspRegiao { get { return urspRegiao; } set { urspRegiao = TruncateValue(value, 20); } }
        public string UrspUnidadeRegional { get { return urspUnidadeRegional; } set { urspUnidadeRegional = TruncateValue(value, 20); } }
        public decimal UrspQtdPrevista { get { return urspQtdPrevista; } set { urspQtdPrevista = value; } }
        public string Ursp { get { return ursp; } set { ursp = TruncateValue(value, 20); } }
        public decimal UrspSequence { get { return urspSequence; } set { urspSequence = value; } }
    }
}
