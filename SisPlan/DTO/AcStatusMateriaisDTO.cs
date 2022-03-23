using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcStatusMateriaisDTO : List<AcStatusMateriaisDTO> { }
    //====================================================================
    public class AcStatusMateriaisDTO : BaseDTO
    {
        private decimal id;
        private string diprCntrCodigo;
        private decimal diprId;
        private decimal diprPeso;
        private string sbcnSigla;
        private decimal discId;
        private string discNome;
        private decimal dcmnId;
        private string descTipoDicionario;

        private string dcmnNumero;
        private string replRev;
        private string diprCodigo;
        private string dipiDescricaoRes;
        private string unmeSigla;
        private decimal? repiQtdTotal;
        private string diprDimensoes;

        private string aufoNumero;
        private DateTime? aufoDtEmissao;
        private string aufoEmprNome;
        private decimal? afitQtd;
        private decimal? sldCompra;

        private string nofiNumero;
        private DateTime? nofiDtRecebimento;
        private decimal? nfitQtd;

        private string noenNumero;
        private decimal? noeiQtdNem;
        private string dvreNumero;
        private string aresSigla;

        private decimal? sldNecessidade;
        private decimal? sldEntrega;
        private decimal? fsitQtdReal;
        private DateTime createdDate;

        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string DiprCntrCodigo { get { return diprCntrCodigo; } set { diprCntrCodigo = TruncateValue(value, 30); } }
        public decimal DiprId { get { return diprId; } set { diprId = value; } }
        public decimal DiprPeso { get { return diprPeso; } set { diprPeso = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 50); } }
        public decimal DcmnId { get { return dcmnId; } set { dcmnId = value; } }
        public string DescTipoDicionario { get { return descTipoDicionario; } set { descTipoDicionario = TruncateValue(value, 50); } }

        public string DcmnNumero { get { return dcmnNumero; } set { dcmnNumero = TruncateValue(value, 200); } }
        public string ReplRev { get { return replRev; } set { replRev = TruncateValue(value, 10); } }
        public string DiprCodigo { get { return diprCodigo; } set { diprCodigo = TruncateValue(value, 50); } }
        public string DipiDescricaoRes { get { return dipiDescricaoRes; } set { dipiDescricaoRes = TruncateValue(value, 500); } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 10); } }
        public decimal? RepiQtdTotal { get { return repiQtdTotal; } set { repiQtdTotal = value; } }
        public string DiprDimensoes { get { return diprDimensoes; } set { diprDimensoes = TruncateValue(value, 50); } }

        public string AufoNumero { get { return aufoNumero; } set { aufoNumero = TruncateValue(value, 30); } }
        public DateTime? AufoDtEmissao { get { return aufoDtEmissao; } set { aufoDtEmissao = value; } }
        public string AufoEmprNome { get { return aufoEmprNome; } set { aufoEmprNome = TruncateValue(value, 200); } }
        public decimal? AfitQtd { get { return afitQtd; } set { afitQtd = value; } }
        public decimal? SldCompra { get { return sldCompra; } set { sldCompra = value; } }

        public string NofiNumero { get { return nofiNumero; } set { nofiNumero = TruncateValue(value, 20); } }
        public DateTime? NofiDtRecebimento { get { return nofiDtRecebimento; } set { nofiDtRecebimento = value; } }
        public decimal? NfitQtd { get { return nfitQtd; } set { nfitQtd = value; } }

        public string NoenNumero { get { return noenNumero; } set { noenNumero = TruncateValue(value, 200); } }
        public decimal? NoeiQtdNem { get { return noeiQtdNem; } set { noeiQtdNem = value; } }
        public string DvreNumero { get { return dvreNumero; } set { dvreNumero = TruncateValue(value, 200); } }
        public string AresSigla { get { return aresSigla; } set { aresSigla = TruncateValue(value, 50); } }

        public decimal? SldNecessidade { get { return sldNecessidade; } set { sldNecessidade = value; } }
        public decimal? SldEntrega { get { return sldEntrega; } set { sldEntrega = value; } }
        public decimal? FsitQtdReal { get { return fsitQtdReal; } set { fsitQtdReal = value; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
    }
}
