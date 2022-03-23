using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjTubRcptDTO : List<ProjTubRcptDTO> { }
    //====================================================================
    public class ProjTubRcptDTO : BaseDTO
    {
        private decimal id;
        private string area;
        private string isom;
        private string pipeline;
        private string revisao;
        private string spool;
        private string contractorCc;
        private string clientCc;
        private string shortDesc;
        private string partDiam1;
        private string partDiam2;
        private string partSched1;
        private string partSched2;
        private string areaPainting;
        private string quantity;
        private string weight;
        private string treatment;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        private string fileName;
        private string categoria;
        //====================================================================
        public enum attributeName { ID, AREA, ISOM, PIPELINE, REVISAO, SPOOL, CONTRACTOR_CC, CLIENT_CC, SHORT_DESC, PART_DIAM1, PART_DIAM2, PART_SCHED1, PART_SCHED2, AREA_PAINTIG, QUANTITY, WEIGHT, TREATMENT, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, FILE_NAME, CATEGORIA };
        public enum propertyName { ID, Area, Isom, Pipeline, Revisao, Spool, ContractorCC, ClientCC, ShortDesc, PartDiam1, PartDiam2, PartSched1, PartSched2, AreaPaintig, Quantity, Weight, Treatment, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, FileName, Categoria };
        //====================================================================
        private static int length = 23;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Area { get { return area; } set { area = TruncateValue(value, 20); } }
        public string Isom { get { return isom; } set { isom = TruncateValue(value, 200); } }
        public string Pipeline { get { return pipeline; } set { pipeline = TruncateValue(value, 20); } }
        public string Revisao { get { return revisao; } set { revisao = TruncateValue(value, 10); } }
        public string Spool { get { return spool; } set { spool = TruncateValue(value, 200); } }
        public string ContractorCC { get { return contractorCc; } set { contractorCc = TruncateValue(value, 50); } }
        public string ClientCC { get { return clientCc; } set { clientCc = TruncateValue(value, 100); } }
        public string ShortDesc { get { return shortDesc; } set { shortDesc = TruncateValue(value, 250); } }
        public string PartDiam1 { get { return partDiam1; } set { partDiam1 = TruncateValue(value, 100); } }
        public string PartDiam2 { get { return partDiam2; } set { partDiam2 = TruncateValue(value, 100); } }
        public string PartSched1 { get { return partSched1; } set { partSched1 = TruncateValue(value, 100); } }
        public string PartSched2 { get { return partSched2; } set { partSched2 = TruncateValue(value, 100); } }
        public string AreaPainting { get { return areaPainting; } set { areaPainting = TruncateValue(value, 20); } }
        public string Quantity { get { return quantity; } set { quantity = TruncateValue(value, 20); } }
        public string Weight { get { return weight; } set { weight = TruncateValue(value, 20); } }
        public string Treatment { get { return treatment; } set { treatment = TruncateValue(value, 20); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 30); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 30); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
        public string Categoria { get { return categoria; } set { categoria = TruncateValue(value, 20); } }
    }
}
