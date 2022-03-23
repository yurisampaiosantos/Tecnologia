using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjOutRcptDTO : List<ProjOutRcptDTO> { }
    //====================================================================
    public class ProjOutRcptDTO : BaseDTO
    {
        private decimal id;
        private string area;
        private string desenho;
        private string rev;
        private string tag;
        private string codigo;
        private string material;
        private string dim1;
        private string dim2;
        private string dim3;
        private string qtd;
        private string unid;
        private string weight;
        private string tipo;
        private string treatment;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        private string fileName;
        private string mult;
        //====================================================================
        public enum attributeName { ID, AREA, DESENHO, REV, TAG, CODIGO, MATERIAL, DIM1, DIM2, DIM3, QTD, UNID, WEIGHT, TIPO, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, FILE_NAME, TREATMENT, MULT };
        public enum propertyName { ID, Area, Desenho, Rev, Tag, Codigo, Material, Dim1, Dim2, Dim3, Qtd, Unid, Weight, Tipo, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, FileName, Treatment, Mult };
        //====================================================================
        private static int length = 21;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Area { get { return area; } set { area = TruncateValue(value, 400); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 400); } }
        public string Rev { get { return rev; } set { rev = TruncateValue(value, 200); } }
        public string Tag { get { return tag; } set { tag = TruncateValue(value, 100); } }
        public string Codigo { get { return codigo; } set { codigo = TruncateValue(value, 50); } }
        public string Material { get { return material; } set { material = TruncateValue(value, 100); } }
        public string Dim1 { get { return dim1; } set { dim1 = TruncateValue(value, 500); } }
        public string Dim2 { get { return dim2; } set { dim2 = TruncateValue(value, 200); } }
        public string Dim3 { get { return dim3; } set { dim3 = TruncateValue(value, 200); } }
        public string Qtd { get { return qtd; } set { qtd = TruncateValue(value, 200); } }
        public string Unid { get { return unid; } set { unid = TruncateValue(value, 200); } }
        public string Weight { get { return weight; } set { weight = TruncateValue(value, 40); } }
        public string Tipo { get { return tipo; } set { tipo = TruncateValue(value, 40); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
        public string Treatment { get { return treatment; } set { treatment = TruncateValue(value, 200); } }
        public string Mult { get { return mult; } set { mult = TruncateValue(value, 200); } }
    }
}
