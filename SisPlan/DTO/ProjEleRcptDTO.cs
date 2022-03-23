using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjEleRcptDTO : List<ProjEleRcptDTO> { }
    //====================================================================
    public class ProjEleRcptDTO : BaseDTO
    {
        private decimal id;
        private string codigo;
        private string unidadeProcesso;
        private string local;
        private string desenho;
        private string revisao;
        private string tag;
        private string descricao;
        private string dimensao;
        private string quantProjeto;
        private string quantReal;
        private string unidade;
        private string createdBy;
        private DateTime createdDate;
        private string modifiedBy;
        private DateTime modifiedDate;
        private string fileName;
        //====================================================================
        public enum attributeName { ID, CODIGO, UNIDADE_PROCESSO, LOCAL, DESENHO, REVISAO, TAG, DESCRICAO, DIMENSAO, QUANT_PROJETO, QUANT_REAL, UNIDADE, CREATED_BY, CREATED_DATE, MODIFIED_BY, MODIFIED_DATE, FILE_NAME };
        public enum propertyName { ID, Codigo, UnidadeProcesso, Local, Desenho, Revisao, Tag, Descricao, Dimensao, QuantProjeto, QuantReal, Unidade, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate, FileName };
        //====================================================================
        private static int length = 17;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Codigo { get { return codigo; } set { codigo = TruncateValue(value, 400); } }
        public string UnidadeProcesso { get { return unidadeProcesso; } set { unidadeProcesso = TruncateValue(value, 40); } }
        public string Local { get { return local; } set { local = TruncateValue(value, 40); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 200); } }
        public string Revisao { get { return revisao; } set { revisao = TruncateValue(value, 100); } }
        public string Tag { get { return tag; } set { tag = TruncateValue(value, 100); } }
        public string Descricao { get { return descricao; } set { descricao = TruncateValue(value, 500); } }
        public string Dimensao { get { return dimensao; } set { dimensao = TruncateValue(value, 40); } }
        public string QuantProjeto { get { return quantProjeto; } set { quantProjeto = value; } }
        public string QuantReal { get { return quantReal; } set { quantReal = value; } }
        public string Unidade { get { return unidade; } set { unidade = TruncateValue(value, 20); } }
        public string CreatedBy { get { return createdBy; } set { createdBy = TruncateValue(value, 60); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string ModifiedBy { get { return modifiedBy; } set { modifiedBy = TruncateValue(value, 60); } }
        public DateTime ModifiedDate { get { return modifiedDate; } set { modifiedDate = value; } }
        public string FileName { get { return fileName; } set { fileName = TruncateValue(value, 500); } }
    }
}
