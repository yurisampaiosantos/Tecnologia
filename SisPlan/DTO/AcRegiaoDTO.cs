using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcRegiaoDTO : List<AcRegiaoDTO> { }
    //====================================================================
    public class AcRegiaoDTO : BaseDTO
    {
        private decimal regiId;
        private string regiDescricao;
        private string regiCntrCodigo;
        private string regiSbcnSigla;
        private decimal regiLocalizacaoId;
        private decimal regiSetorId;
        //====================================================================
        public enum attributeName { REGI_ID, REGI_DESCRICAO, REGI_CNTR_CODIGO, REGI_SBCN_SIGLA, REGI_LOCALIZACAO_ID, REGI_SETOR_ID };
        public enum propertyName { RegiId, RegiDescricao, RegiCntrCodigo, RegiSbcnSigla, RegiLocalizacaoId, RegiSetorId };
        //====================================================================
        private static int length = 6;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal RegiId { get { return regiId; } set { regiId = value; } }
        public string RegiDescricao { get { return regiDescricao; } set { regiDescricao = TruncateValue(value, 30); } }
        public string RegiCntrCodigo { get { return regiCntrCodigo; } set { regiCntrCodigo = TruncateValue(value, 30); } }
        public string RegiSbcnSigla { get { return regiSbcnSigla; } set { regiSbcnSigla = TruncateValue(value, 10); } }
        public decimal RegiLocalizacaoId { get { return regiLocalizacaoId; } set { regiLocalizacaoId = value; } }
        public decimal RegiSetorId { get { return regiSetorId; } set { regiSetorId = value; } }
    }
}
