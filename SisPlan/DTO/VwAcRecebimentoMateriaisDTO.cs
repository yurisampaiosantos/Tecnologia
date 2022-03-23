using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAcRecebimentoMateriaisDTO : List<VwAcRecebimentoMateriaisDTO> { }
    //====================================================================
    public class VwAcRecebimentoMateriaisDTO : BaseDTO
    {
        //====================================================================
        public decimal ItensRecebidos { get; set; }
        public string SbcnSigla { get; set; }
        public string DataRec { get; set; }
        public string NF { get; set; }
        public string Fornecedor { get; set; }
        public string AF { get; set; }
        public int ItemAF { get; set; }
        public string CodigoMat { get; set; }
        public string Corridas { get; set; }
        public int ReprTipoDicionario { get; set; }
        public string TipoDicionario { get; set; }
        public string Descricao { get; set; }
        public string Dimensoes { get; set; }
        public string UN { get; set; }
        public string FcesSigla { get; set; }
        public decimal QtdAF { get; set; }
        public decimal QtdNF { get; set; }
        public string NEM { get; set; }
        public string DataNEM { get; set; }
        public decimal QtdNEM { get; set; }
        public string NumeroRDR { get; set; }
        public decimal QtdRDR { get; set; }
        public string DadosRDR { get; set; }
        public decimal PesoUnit { get; set; }
        public string Disciplina { get; set; }
        public string RM { get; set; }
        public decimal QtdRM { get; set; }
        public string LM { get; set; }
        public string RevLM { get; set; }
        public decimal QtdLM { get; set; }
        public decimal QtdAplicada { get; set; }
    }
}