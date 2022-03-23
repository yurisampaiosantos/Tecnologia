using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcPrevisaoEngenhariaDTO : List<AcPrevisaoEngenhariaDTO> { }
    //====================================================================
    public class AcPrevisaoEngenhariaDTO : BaseDTO
    {
        private decimal pengId;
        private string pengUnidadeRegional;
        private decimal pengPecas;
        private decimal pengPeso;
        private decimal pengSequence;
        //====================================================================
        public enum attributeName { PENG_ID, PENG_UNIDADE_REGIONAL, PENG_PECAS, PENG_PESO, PENG_SEQUENCE };
        public enum propertyName { PengId, PengUnidadeRegional, PengPecas, PengPeso, PengSequence };
        //====================================================================
        private static int length = 5;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal PengId { get { return pengId; } set { pengId = value; } }
        public string PengUnidadeRegional { get { return pengUnidadeRegional; } set { pengUnidadeRegional = TruncateValue(value, 50); } }
        public decimal PengPecas { get { return pengPecas; } set { pengPecas = value; } }
        public decimal PengPeso { get { return pengPeso; } set { pengPeso = value; } }
        public decimal PengSequence { get { return pengSequence; } set { pengSequence = value; } }
    }
}