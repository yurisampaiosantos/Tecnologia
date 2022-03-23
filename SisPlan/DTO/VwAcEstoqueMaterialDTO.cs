using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcEstoqueMaterialDTO : List<VwAcEstoqueMaterialDTO> { }
    //====================================================================
    public class VwAcEstoqueMaterialDTO : BaseDTO
    {
        //====================================================================
        //NOEN_DT_EMISSAO, DVRE_NUMERO, DVRE_OBS
        public string SbcnSigla { get; set; }
        public string AresSigla { get; set; }
        public string DiprCodigo { get; set; }
        public string DiprDimensoes { get; set; }
        public string UnmeSigla { get; set; }
        public string DipiDescricaoRes { get; set; }
        public string NofiNumero { get; set; }
        public string NofiDtRecebimento { get; set; }
        public decimal NfitQtd { get; set; }
        public string NoenNumero { get; set; }
        public decimal NoeiQtdNem { get; set; }
        public string NoenDtEmissao { get; set; }
        public string DvreNumero { get; set; }
        public string DvreObs { get; set; }
    }
}