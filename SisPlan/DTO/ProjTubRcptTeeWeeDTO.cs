using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjTubRcptTeeweeDTO : List<ProjTubRcptTeeweeDTO> { }
    //====================================================================
    public class ProjTubRcptTeeweeDTO : BaseDTO
    {
        private decimal id;
        private string fpso;
        private string area;
        private string subarea;
        private string isom;
        private string rev;
        private string pipeline;
        private string isolinha;
        private string revlinha;
        private string spool;
        private string clientCc;
        private string contractorCc;
        private string shortDesc;
        private string partDiam1;
        private string partDiam2;
        private string partSched1;
        private string partSched2;
        private string category;
        private string areaPainting;
        private string quantity;
        private string weight;
        private string painting;
        private string treatment;
        private string fileName;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        //====================================================================
        public enum attributeName { ID, FPSO, AREA, SUBAREA, ISOM, REV, PIPELINE, ISOLINHA, REVLINHA, SPOOL, CLIENT_CC, CONTRACTOR_CC, SHORT_DESC, PART_DIAM1, PART_DIAM2, PART_SCHED1, PART_SCHED2, CATEGORY, AREA_PAINTING, QUANTITY, WEIGHT, PAINTING, TREATMENT, FILE_NAME, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE };
        public enum propertyName { ID, Fpso, Area, Subarea, Isom, Rev, Pipeline, Isolinha, Revlinha, Spool, ClientCc, ContractorCc, ShortDesc, PartDiam1, PartDiam2, PartSched1, PartSched2, Category, AreaPainting, Quantity, Weight, Painting, Treatment, FileName, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate };
        //====================================================================
        private static int length = 28;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Fpso { get { return fpso; } set { fpso = TruncateValue(value, 20); } }
        public string Area { get { return area; } set { area = TruncateValue(value, 40); } }
        public string Subarea { get { return subarea; } set { subarea = TruncateValue(value, 40); } }
        public string Isom { get { return isom; } set { isom = TruncateValue(value, 400); } }
        public string Rev { get { return rev; } set { rev = TruncateValue(value, 20); } }
        public string Pipeline { get { return pipeline; } set { pipeline = TruncateValue(value, 100); } }
        public string Isolinha { get { return isolinha; } set { isolinha = TruncateValue(value, 300); } }
        public string Revlinha { get { return revlinha; } set { revlinha = TruncateValue(value, 20); } }
        public string Spool { get { return spool; } set { spool = TruncateValue(value, 400); } }
        public string ClientCc { get { return clientCc; } set { clientCc = TruncateValue(value, 200); } }
        public string ContractorCc { get { return contractorCc; } set { contractorCc = TruncateValue(value, 100); } }
        public string ShortDesc { get { return shortDesc; } set { shortDesc = TruncateValue(value, 500); } }
        public string PartDiam1 { get { return partDiam1; } set { partDiam1 = TruncateValue(value, 200); } }
        public string PartDiam2 { get { return partDiam2; } set { partDiam2 = TruncateValue(value, 200); } }
        public string PartSched1 { get { return partSched1; } set { partSched1 = TruncateValue(value, 200); } }
        public string PartSched2 { get { return partSched2; } set { partSched2 = TruncateValue(value, 200); } }
        public string Category { get { return category; } set { category = TruncateValue(value, 20); } }
        public string AreaPainting { get { return areaPainting; } set { areaPainting = TruncateValue(value, 40); } }
        public string Quantity { get { return quantity; } set { quantity = TruncateValue(value, 40); } }
        public string Weight { get { return weight; } set { weight = TruncateValue(value, 40); } }
        public string Painting { get { return painting; } set { painting = TruncateValue(value, 40); } }
        public string Treatment { get { return treatment; } set { treatment = TruncateValue(value, 40); } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
    }
}
