using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcCorridaMaterialDTO : List<AcCorridaMaterialDTO> { }
    //====================================================================
    public class AcCorridaMaterialDTO : BaseDTO
    {
        private decimal comaId;
        private string comaFileName;
        private string comaCreatedBy;

        //====================================================================
        public decimal ComaId { get { return comaId; } set { comaId = value; } }
        public string ComaFileName { get { return comaFileName; } set { comaFileName = TruncateValue(value, 500); } }
        public string ComaCreatedBy { get { return comaCreatedBy; } set { comaCreatedBy = TruncateValue(value, 60); } }
    }
}