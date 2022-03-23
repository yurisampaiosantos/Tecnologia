using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcPendenciaMaterialDTO : List<AcPendenciaMaterialDTO> { }
    //====================================================================
    public class AcPendenciaMaterialDTO : BaseDTO
    {
        private decimal id;
        private string dcmnNumero;
        private string dcmnTitulo;
        private string dipcCodigo;
        private string dipiDescricaoRes;
        private decimal diprPeso;
        private decimal repiItem;
        private decimal repiQtdTotal;
        private decimal afitItem;
        private decimal afitQtdTotal;
        private decimal aufoId;
        private string aufoNumero;
        private decimal dipqQtdAf;
        private string unmeSigla;
        private decimal nfitQtd;
        private decimal afSaldo;
        private decimal nfSaldo;
        private decimal nemSaldo;
        private decimal necSaldo;
        private string nofiNumero;
        private string noenNumero;
        private DateTime noenDtEmissao;
        private string noenObs;
        private decimal noeiItem;
        private decimal noeiQtdNem;
        private string discNome;
        private string sbcnSigla;


        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string DcmnNumero { get { return dcmnNumero; } set { dcmnNumero = TruncateValue(value, 200); } }
        public string DcmnTitulo { get { return dcmnTitulo; } set { dcmnTitulo = TruncateValue(value, 200); } }
        public string DipcCodigo { get { return dipcCodigo; } set { dipcCodigo = TruncateValue(value, 200); } }
        public string DipiDescricaoRes { get { return dipiDescricaoRes; } set { dipiDescricaoRes = TruncateValue(value, 1000); } }
        public decimal DiprPeso { get { return diprPeso; } set { diprPeso = value; } }
        public string DiprDimensoes { get; set; }
        public string DiprDim1 { get; set; }
        public string DiprDim2 { get; set; }
        public string DiprDim3 { get; set; }
        public decimal RepiItem { get { return repiItem; } set { repiItem = value; } }
        public decimal RepiQtdTotal { get { return repiQtdTotal; } set { repiQtdTotal = value; } }
        public decimal FsitQtdReal { get ; set ; }
        public decimal AfitItem { get { return afitItem; } set { afitItem = value; } }
        public decimal AfitQtdTotal { get { return afitQtdTotal; } set { afitQtdTotal = value; } }
        public decimal AufoId { get { return aufoId; } set { aufoId = value; } }
        public string AufoNumero { get { return aufoNumero; } set { aufoNumero = TruncateValue(value, 50); } }
        public DateTime AufoDtEmissao { get; set; }
        public DateTime AficContratual { get; set; }
        public decimal DipqQtdAf { get { return dipqQtdAf; } set { dipqQtdAf = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 20); } }
        public string Prazos { get; set; }
        public string Entregas { get; set; }
        public string EmprNome { get; set; }
        public decimal NfitQtd { get { return nfitQtd; } set { nfitQtd = value; } }

        public decimal SldCompra { get { return afSaldo; } set { afSaldo = value; } }
        public decimal SldEntrega { get { return nfSaldo; } set { nfSaldo = value; } }
        public decimal SldLiberado { get { return nemSaldo; } set { nemSaldo = value; } }
        public decimal SldNecessidade { get { return necSaldo; } set { necSaldo = value; } }
        
        public DateTime NofiDtRecebimento { get ; set; }
        public string NofiNumero { get { return nofiNumero; } set { nofiNumero = TruncateValue(value, 2000); } }
        public string NoenNumero { get { return noenNumero; } set { noenNumero = TruncateValue(value, 20); } }
        public DateTime NoenDtEmissao { get { return noenDtEmissao; } set { noenDtEmissao = value; } }
        public string NoenObs { get { return noenObs; } set { noenObs = TruncateValue(value, 200); } }
        public decimal NoeiItem { get { return noeiItem; } set { noeiItem = value; } }
        public decimal NoeiQtdNem { get { return noeiQtdNem; } set { noeiQtdNem = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 100); } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 100); } }
        public string Status { get; set; }

        public decimal QtdRDR { get; set; }
        public string DadosRDR { get; set; }
    }
}
