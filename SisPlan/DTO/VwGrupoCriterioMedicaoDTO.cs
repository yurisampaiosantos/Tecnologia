using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwGrupoCriterioMedicaoDTO : List<VwGrupoCriterioMedicaoDTO> { }
    //====================================================================
    public class VwGrupoCriterioMedicaoDTO : BaseDTO
    {
        //====================================================================
        public string GrcrCntrCodigo { get; set; }
        public int GrcrId { get; set; }
        public string GrcrGrupoSigla { get; set; }
        public string GrcrNome { get; set; }
        public string GrcrGrupoDescricao { get; set; }
        public int GrcrSequence { get; set; }
        public int GrfcFcmeId { get; set; }
        public string FcmeSigla { get; set; }
    }
}