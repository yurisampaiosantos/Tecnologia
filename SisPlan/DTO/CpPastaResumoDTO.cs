using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpPastaResumoDTO : List<CpPastaResumoDTO> { }
    //====================================================================
    public class CpPastaResumoDTO : BaseDTO
    {
        private decimal pareId;
        private string pareSbcnSigla;
        private string pareLocaDescricao;
        private string pareSmgrDescricao;
        private string pareAreaDescricao;

        private decimal pareCascoMec;
        private decimal pareCascoTub;
        private decimal pareCascoEle;
        private decimal pareCascoIns;
        private decimal pareCascoTlc;
        private decimal pareCascoTotal;
        private decimal pareErprMec;
        private decimal pareErprTub;
        private decimal pareErprEle;
        private decimal pareErprIns;
        private decimal pareErprTlc;
        private decimal pareErprTotal;
        private decimal pareMsMec;
        private decimal pareMsTub;
        private decimal pareMsEle;
        private decimal pareMsIns;
        private decimal pareMsTlc;
        private decimal pareMsTotal;
        private decimal pareMaMec;
        private decimal pareMaTub;
        private decimal pareMaEle;
        private decimal pareMaIns;
        private decimal pareMaTlc;
        private decimal pareMaTotal;
        private decimal pareTotalMec;
        private decimal pareTotalTub;
        private decimal pareTotalEle;
        private decimal pareTotalIns;
        private decimal pareTotalTlc;
        private decimal pareTotalTotal;

        //====================================================================
        public decimal PareId { get { return pareId; } set { pareId = value; } }
        public string PareSbcnSigla { get { return pareSbcnSigla; } set { pareSbcnSigla = TruncateValue(value, 10); } }
        public string PareLocaDescricao { get { return pareLocaDescricao; } set { pareLocaDescricao = TruncateValue(value, 50); } }
        public string PareSmgrDescricao { get { return pareSmgrDescricao; } set { pareSmgrDescricao = TruncateValue(value, 50); } }
        public string PareAreaDescricao { get { return pareAreaDescricao; } set { pareAreaDescricao = TruncateValue(value, 50); } }

        public decimal PareCascoMec { get { return pareCascoMec; } set { pareCascoMec = value; } }
        public decimal PareCascoTub { get { return pareCascoTub; } set { pareCascoTub = value; } }
        public decimal PareCascoEle { get { return pareCascoEle; } set { pareCascoEle = value; } }
        public decimal PareCascoIns { get { return pareCascoIns; } set { pareCascoIns = value; } }
        public decimal PareCascoTlc { get { return pareCascoTlc; } set { pareCascoTlc = value; } }
        public decimal PareCascoTotal { get { return pareCascoTotal; } set { pareCascoTotal = value; } }
        public decimal PareErprMec { get { return pareErprMec; } set { pareErprMec = value; } }
        public decimal PareErprTub { get { return pareErprTub; } set { pareErprTub = value; } }
        public decimal PareErprEle { get { return pareErprEle; } set { pareErprEle = value; } }
        public decimal PareErprIns { get { return pareErprIns; } set { pareErprIns = value; } }
        public decimal PareErprTlc { get { return pareErprTlc; } set { pareErprTlc = value; } }
        public decimal PareErprTotal { get { return pareErprTotal; } set { pareErprTotal = value; } }
        public decimal PareMsMec { get { return pareMsMec; } set { pareMsMec = value; } }
        public decimal PareMsTub { get { return pareMsTub; } set { pareMsTub = value; } }
        public decimal PareMsEle { get { return pareMsEle; } set { pareMsEle = value; } }
        public decimal PareMsIns { get { return pareMsIns; } set { pareMsIns = value; } }
        public decimal PareMsTlc { get { return pareMsTlc; } set { pareMsTlc = value; } }
        public decimal PareMsTotal { get { return pareMsTotal; } set { pareMsTotal = value; } }
        public decimal PareMaMec { get { return pareMaMec; } set { pareMaMec = value; } }
        public decimal PareMaTub { get { return pareMaTub; } set { pareMaTub = value; } }
        public decimal PareMaEle { get { return pareMaEle; } set { pareMaEle = value; } }
        public decimal PareMaIns { get { return pareMaIns; } set { pareMaIns = value; } }
        public decimal PareMaTlc { get { return pareMaTlc; } set { pareMaTlc = value; } }
        public decimal PareMaTotal { get { return pareMaTotal; } set { pareMaTotal = value; } }
        public decimal PareTotalMec { get { return pareTotalMec; } set { pareTotalMec = value; } }
        public decimal PareTotalTub { get { return pareTotalTub; } set { pareTotalTub = value; } }
        public decimal PareTotalEle { get { return pareTotalEle; } set { pareTotalEle = value; } }
        public decimal PareTotalIns { get { return pareTotalIns; } set { pareTotalIns = value; } }
        public decimal PareTotalTlc { get { return pareTotalTlc; } set { pareTotalTlc = value; } }
        public decimal PareTotalTotal { get { return pareTotalTotal; } set { pareTotalTotal = value; } }
    }
}
