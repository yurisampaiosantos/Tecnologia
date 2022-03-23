using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcCorridaMaterialItemDTO : List<AcCorridaMaterialItemDTO> { }
    //====================================================================
    public class AcCorridaMaterialItemDTO : BaseDTO
    {
        private decimal cmitId;
        private decimal cmitComaId;
        private string cmitFoseNumero;
        private string cmitDiprCodigo;
        private string cmitDiprDimensoes;
        private string cmitDiprDescricao;
        private string cmitUnmeSigla;
        private decimal cmitQtdFsCorrida;
        private decimal cmitQtdAReservar;
        private string cmitStatus;
        private string cmitCreatedBy;

        //====================================================================
        public decimal CmitId { get { return cmitId; } set { cmitId = value; } }
        public decimal CmitComaId { get { return cmitComaId; } set { cmitComaId = value; } }
        public string CmitFoseNumero { get { return cmitFoseNumero; } set { cmitFoseNumero = TruncateValue(value, 200); } }
        public string CmitDiprCodigo { get { return cmitDiprCodigo; } set { cmitDiprCodigo = TruncateValue(value, 50); } }
        public string CmitDiprDimensoes { get { return cmitDiprDimensoes; } set { cmitDiprDimensoes = TruncateValue(value, 500); } }
        public string CmitDiprDescricao { get { return cmitDiprDescricao; } set { cmitDiprDescricao = TruncateValue(value, 2000); } }
        public string CmitUnmeSigla { get { return cmitUnmeSigla; } set { cmitUnmeSigla = TruncateValue(value, 20); } }
        public decimal CmitQtdFsCorrida { get { return cmitQtdFsCorrida; } set { cmitQtdFsCorrida = value; } }
        public decimal CmitQtdAReservar { get { return cmitQtdAReservar; } set { cmitQtdAReservar = value; } }
        public string CmitStatus { get { return cmitStatus; } set { cmitStatus = TruncateValue(value, 30); } }
        public string CmitCreatedBy { get { return cmitCreatedBy; } set { cmitCreatedBy = TruncateValue(value, 60); } }
    }
}