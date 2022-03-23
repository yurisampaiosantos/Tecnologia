using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcSemanaDTO : List<AcSemanaDTO> { }
    //====================================================================
    public class AcSemanaDTO : BaseDTO
    {
        private string semaCntrCodigo;
        private decimal semaId;
        private DateTime semaDataInicio;
        private DateTime semaDataFim;
        private string semaMesCompetencia;
        //====================================================================
        public enum attributeName { SEMA_CNTR_CODIGO, SEMA_ID, SEMA_DATA_INICIO, SEMA_DATA_FIM, SEMA_MES_COMPETENCIA };
        public enum propertyName { SemaCntrCodigo, SemaId, SemaDataInicio, SemaDataFim, SemaMesCompetencia };
        //====================================================================
        private static int length = 5;
        public static int Length { get { return length; } }
        //====================================================================
        public string SemaCntrCodigo { get { return semaCntrCodigo; } set { semaCntrCodigo = TruncateValue(value, 20); } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
        public DateTime SemaDataInicio { get { return semaDataInicio; } set { semaDataInicio = value; } }
        public DateTime SemaDataFim { get { return semaDataFim; } set { semaDataFim = value; } }
        public string SemaMesCompetencia { get { return semaMesCompetencia; } set { semaMesCompetencia = value; } }
    }
}