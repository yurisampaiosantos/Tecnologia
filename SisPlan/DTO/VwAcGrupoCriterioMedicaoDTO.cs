using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcGrupoCriterioMedicaoDTO : List<VwAcGrupoCriterioMedicaoDTO> { }
    //====================================================================
    public class VwAcGrupoCriterioMedicaoDTO : BaseDTO
    {
        //====================================================================
        public string GrcrCntrCodigo { get; set; }
        public int GrcrId { get; set; }
        public string GrcrGrupoSigla { get; set; }
        public string GrcrNome { get; set; }
        public string GrcrGrupoDescricao { get; set; }
        public int GrcrSequence { get; set; }
        public int FcmeId { get; set; }
        public string FcmeSigla { get; set; }
        public int FcesId { get; set; }
        public string FcesSigla { get; set; }
        public decimal FcesPesoRelCron { get; set; }
        public int FoseId { get; set; }
        public string FoseNumero { get; set; }
        public decimal FoseQtdPrevista { get; set; }
        public int FosmId { get; set; }
        
    }
}