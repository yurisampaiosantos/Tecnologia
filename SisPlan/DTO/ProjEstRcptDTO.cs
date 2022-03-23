using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjEstRcptDTO : List<ProjEstRcptDTO> { }
    //====================================================================
    public class ProjEstRcptDTO : BaseDTO
    {
        private decimal id;
        private string peca;
        private string pc;
        private string peso;
        private string criterio;
        private string descricao;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        private string fileName;
        //====================================================================
        public enum attributeName { ID, PECA, PC, PESO, CRITERIO, DESCRICAO, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, FILE_NAME };
        public enum propertyName { ID, Peca, PC, Peso, Criterio, Descricao, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, FileName };
        //====================================================================
        private static int length = 11;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Peca { get { return peca; } set { peca = TruncateValue(value, 400); } }
        public string PC { get { return pc; } set { pc = TruncateValue(value, 20); } }
        public string Peso { get { return peso; } set { peso = TruncateValue(value, 400); } }
        public string Criterio { get { return criterio; } set { criterio = TruncateValue(value, 400); } }
        public string Descricao { get { return descricao; } set { descricao = TruncateValue(value, 400); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
    }
}
