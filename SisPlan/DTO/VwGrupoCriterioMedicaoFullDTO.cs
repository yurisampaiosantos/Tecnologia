using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwGrupoCriterioMedicaoFullDTO : List<VwGrupoCriterioMedicaoFullDTO> { }
    //====================================================================
    public class VwGrupoCriterioMedicaoFullDTO : BaseDTO
    {
        //====================================================================
        public decimal FcmeDiscId { get; set; }
        public string FcmeSigla { get; set; }
        public string GrcrNome { get; set; }
        public string GrcrGrupoDescricao { get; set; }
        public string GrcrGrupoSigla { get; set; }
        public int FcmeId { get; set; }
        public int GrfcGrcrId { get; set; }
        public int GrcrSequence { get; set; }
    }
}