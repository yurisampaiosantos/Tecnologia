using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionIntTarefasDTO : List<IntTarefasDTO> { }
    //====================================================================
    public class IntTarefasDTO : BaseDTO
    {
        private decimal intaId;
        private string intaFuncionario;
        private string intaTarefa;
        private decimal intaInloId;
        private decimal intaStatus;
        private decimal intaActive;
        //====================================================================
        public enum attributeName { INTA_ID, INTA_FUNCIONARIO, INTA_TAREFA, INTA_INLO_ID, INTA_STATUS, INTA_ACTIVE };
        public enum propertyName { IntaId, IntaFuncionario, IntaTarefa, IntaInloId, IntaStatus, IntaActive };
        //====================================================================
        private static int length = 6;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal IntaId { get { return intaId; } set { intaId = value; } }
        public string IntaFuncionario { get { return intaFuncionario; } set { intaFuncionario = TruncateValue(value, 50); } }
        public string IntaTarefa { get { return intaTarefa; } set { intaTarefa = TruncateValue(value, 100); } }
        public decimal IntaInloId { get { return intaInloId; } set { intaInloId = value; } }
        public decimal IntaStatus { get { return intaStatus; } set { intaStatus = value; } }
        public decimal IntaActive { get { return intaActive; } set { intaActive = value; } }
    }
}