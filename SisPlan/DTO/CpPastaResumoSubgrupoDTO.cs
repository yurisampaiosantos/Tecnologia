using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPastaResumoSubgrupoDTO : List<CpPastaResumoSubgrupoDTO> { }
    //====================================================================
    public class CpPastaResumoSubgrupoDTO : BaseDTO
    {
        private decimal prsgId;
        private string prsgCntrCodigo;
        private string prsgSbcnSigla;
        private string prsgArea;
        private string prsgDiscSigla;
        private string prsgSmgrDescricao;
        private string prsgSmsgDescricao;
        private decimal? prsgQuantidade;
        private decimal prsgSmgrSequence;
        private decimal prsgSmsgSequence;
        //====================================================================
        public enum attributeName { PRSG_ID, PRSG_CNTR_CODIGO, PRSG_SBCN_SIGLA, PRSG_AREA, PRSG_DISC_SIGLA, PRSG_SMGR_DESCRICAO, PRSG_SMSG_DESCRICAO, PRSG_QUANTIDADE, PRSG_SMGR_SEQUENCE, PRSG_SMSG_SEQUENCE };
        public enum propertyName { PrsgId, PrsgCntrCodigo, PrsgSbcnSigla, PrsgArea, PrsgDiscSigla, PrsgSmgrDescricao, PrsgSmsgDescricao, PrsgQuantidade, PrsgSmgrSequence, PrsgSmsgSequence };
        //====================================================================
        private static int length = 10;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal PrsgId { get { return prsgId; } set { prsgId = value; } }
        public string PrsgCntrCodigo { get { return prsgCntrCodigo; } set { prsgCntrCodigo = TruncateValue(value, 30); } }
        public string PrsgSbcnSigla { get { return prsgSbcnSigla; } set { prsgSbcnSigla = TruncateValue(value, 10); } }
        public string PrsgArea { get { return prsgArea; } set { prsgArea = TruncateValue(value, 20); } }
        public string PrsgDiscSigla { get { return prsgDiscSigla; } set { prsgDiscSigla = TruncateValue(value, 100); } }
        public string PrsgSmgrDescricao { get { return prsgSmgrDescricao; } set { prsgSmgrDescricao = TruncateValue(value, 50); } }
        public string PrsgSmsgDescricao { get { return prsgSmsgDescricao; } set { prsgSmsgDescricao = TruncateValue(value, 50); } }
        public decimal? PrsgQuantidade { get { return prsgQuantidade; } set { prsgQuantidade = value; } }
        public decimal PrsgSmgrSequence { get { return prsgSmgrSequence; } set { prsgSmgrSequence = value; } }
        public decimal PrsgSmsgSequence { get { return prsgSmsgSequence; } set { prsgSmsgSequence = value; } }
    }
}
