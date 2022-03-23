using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPunchlistDTO : List<CpPunchlistDTO> { }
    //====================================================================
    public class CpPunchlistDTO : BaseDTO
    {
        private decimal punchId;
        private string punchCntrCodigo;
        private decimal punchPastaId;
        private string punchDescricao;
        private decimal punchTipeId;
        private DateTime? punchDataPrometida;
        private string punchResponsibleBy;
        private decimal punchStpuId;
        private string punchApprovedBy;
        private DateTime? punchApprovedDate;
        private string punchCreatedBy;
        private DateTime punchCreatedDate;
        private DateTime? punchDataConcluida;
        private decimal punchArpeId;
        private string punchSituacao;
        private decimal punchImpeditiva;
        //====================================================================
        public enum attributeName { PUNCH_ID, PUNCH_CNTR_CODIGO, PUNCH_PASTA_ID, PUNCH_DESCRICAO, PUNCH_TIPE_ID, PUNCH_DATA_PROMETIDA, PUNCH_RESPONSIBLE_BY, PUNCH_STPU_ID, PUNCH_APPROVED_BY, PUNCH_APPROVED_DATE, PUNCH_CREATED_BY, PUNCH_CREATED_DATE, PUNCH_DATA_CONCLUIDA, PUNCH_ARPE_ID, PUNCH_SITUACAO, PUNCH_IMPEDITIVA };
        public enum propertyName { PunchId, PunchCntrCodigo, PunchPastaId, PunchDescricao, PunchTipeId, PunchDataPrometida, PunchResponsibleBy, PunchStpuId, PunchApprovedBy, PunchApprovedDate, PunchCreatedBy, PunchCreatedDate, PunchDataConcluida, PunchArpeId, PunchSituacao, PunchImpeditiva };
        //====================================================================
        private static int length = 16;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal PunchId { get { return punchId; } set { punchId = value; } }
        public string PunchCntrCodigo { get { return punchCntrCodigo; } set { punchCntrCodigo = TruncateValue(value, 10); } }
        public decimal PunchPastaId { get { return punchPastaId; } set { punchPastaId = value; } }
        public string PunchDescricao { get { return punchDescricao; } set { punchDescricao = TruncateValue(value, 250); } }
        public decimal PunchTipeId { get { return punchTipeId; } set { punchTipeId = value; } }
        public DateTime? PunchDataPrometida { get { return punchDataPrometida; } set { punchDataPrometida = value; } }
        public string PunchResponsibleBy { get { return punchResponsibleBy; } set { punchResponsibleBy = TruncateValue(value, 50); } }
        public decimal PunchStpuId { get { return punchStpuId; } set { punchStpuId = value; } }
        public string PunchApprovedBy { get { return punchApprovedBy; } set { punchApprovedBy = TruncateValue(value, 50); } }
        public DateTime? PunchApprovedDate { get { return punchApprovedDate; } set { punchApprovedDate = value; } }
        public string PunchCreatedBy { get { return punchCreatedBy; } set { punchCreatedBy = TruncateValue(value, 50); } }
        public DateTime PunchCreatedDate { get { return punchCreatedDate; } set { punchCreatedDate = value; } }
        public DateTime? PunchDataConcluida { get { return punchDataConcluida; } set { punchDataConcluida = value; } }
        public decimal PunchArpeId { get { return punchArpeId; } set { punchArpeId = value; } }
        public string PunchSituacao { get { return punchSituacao; } set { punchSituacao = TruncateValue(value, 250); } }
        public decimal PunchImpeditiva { get { return punchImpeditiva; } set { punchImpeditiva = value; } }
    }
}
