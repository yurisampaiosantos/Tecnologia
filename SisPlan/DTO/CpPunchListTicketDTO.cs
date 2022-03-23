using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPunchListTicketDTO : List<CpPunchListTicketDTO> { }
    //====================================================================
    public class CpPunchListTicketDTO : BaseDTO
    {
        //====================================================================
        public string PunchResponsibleBy { get; set; }
        public decimal PastaId { get; set; }
        public string PastaCodigo { get; set; }

    }
}