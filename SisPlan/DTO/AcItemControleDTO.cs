using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcItemControleDTO : List<AcItemControleDTO> { }
    //====================================================================
    public class AcItemControleDTO : BaseDTO
    {
        private decimal id;
        private string descricaoEstrutura;
        private string itemControle;
        //====================================================================
        public enum attributeName { ID, DESCRICAO_ESTRUTURA, ITEM_CONTROLE };
        public enum propertyName { ID, DescricaoEstrutura, ItemControle };
        //====================================================================
        private static int length = 3;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string DescricaoEstrutura { get { return descricaoEstrutura; } set { descricaoEstrutura = TruncateValue(value, 200); } }
        public string ItemControle { get { return itemControle; } set { itemControle = TruncateValue(value, 40); } }
    }
}