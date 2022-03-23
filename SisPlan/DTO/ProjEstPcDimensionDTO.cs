using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjEstPcDimensionDTO : List<ProjEstPcDimensionDTO> { }
    //====================================================================
    public class ProjEstPcDimensionDTO : BaseDTO
    {
        private decimal id;
        private string pc;
        private string dimension;
        private string fileName;
        //====================================================================
        public enum attributeName { ID, PC, DIMENSION, FILE_NAME };
        public enum propertyName { ID, PC, Dimension, FileName };
        //====================================================================
        private static int length = 4;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string PC { get { return pc; } set { pc = TruncateValue(value, 20); } }
        public string Dimension { get { return dimension; } set { dimension = TruncateValue(value, 100); } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 200); } }
    }
}
