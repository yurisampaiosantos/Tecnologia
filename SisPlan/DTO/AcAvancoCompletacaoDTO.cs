using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcAvancoCompletacaoDTO : List<AcAvancoCompletacaoDTO> { }
    //====================================================================
    public class AcAvancoCompletacaoDTO : BaseDTO
    {
        //====================================================================
        public string FoseCntrCodigo { get; set; }
        public string FoseSbcnSigla { get; set; }
        public string DiscSigla { get; set; }
        public string CodBarras { get; set; }
        public string FoseNumero { get; set; }
        public decimal FoseId { get; set; }
        public string Tarefa { get; set; }
        public string LocalizacaoRegiao { get; set; }
        public string Regiao { get; set; }
        public decimal ZonaId { get; set; }
        public string Equipe { get; set; }
    }
}
