using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwCpMaterialPendenteDTO : List<VwCpMaterialPendenteDTO> { }
    //====================================================================
    public class VwCpMaterialPendenteDTO : BaseDTO
    {
        private decimal mapeId;
        private string mapeCntrCodigo;
        private decimal mapePastaId;
        private string pastaCodigo;
        private string mapeDescricao;
        private decimal mapeQuantidade;
        private string mapeUnidade;
        private decimal mapeLocaId;
        private string locaDescricao;
        private decimal mapeStmpId;
        private string stmpDescricao;
        private string mapeCreatedBy;
        private DateTime mapeCreatedDate;
        private string mapeFornecedor;
        //====================================================================
        public enum attributeName { MAPE_ID, MAPE_CNTR_CODIGO, MAPE_PASTA_ID, PASTA_CODIGO, MAPE_DESCRICAO, MAPE_QUANTIDADE, MAPE_UNIDADE, MAPE_LOCA_ID, LOCA_DESCRICAO, MAPE_STMP_ID, STMP_DESCRICAO, MAPE_CREATED_BY, MAPE_CREATED_DATE, MAPE_FORNECEDOR };
        public enum propertyName { MapeId, MapeCntrCodigo, MapePastaId, PastaCodigo, MapeDescricao, MapeQuantidade, MapeUnidade, MapeLocaId, LocaDescricao, MapeStmpId, StmpDescricao, MapeCreatedBy, MapeCreatedDate, MapeFornecedor };
        //====================================================================
        private static int length = 14;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal MapeId { get { return mapeId; } set { mapeId = value; } }
        public string MapeCntrCodigo { get { return mapeCntrCodigo; } set { mapeCntrCodigo = TruncateValue(value, 10); } }
        public decimal MapePastaId { get { return mapePastaId; } set { mapePastaId = value; } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public string MapeDescricao { get { return mapeDescricao; } set { mapeDescricao = TruncateValue(value, 100); } }
        public decimal MapeQuantidade { get { return mapeQuantidade; } set { mapeQuantidade = value; } }
        public string MapeUnidade { get { return mapeUnidade; } set { mapeUnidade = TruncateValue(value, 5); } }
        public decimal MapeLocaId { get { return mapeLocaId; } set { mapeLocaId = value; } }
        public string LocaDescricao { get { return locaDescricao; } set { locaDescricao = TruncateValue(value, 50); } }
        public decimal MapeStmpId { get { return mapeStmpId; } set { mapeStmpId = value; } }
        public string StmpDescricao { get { return stmpDescricao; } set { stmpDescricao = TruncateValue(value, 50); } }
        public string MapeCreatedBy { get { return mapeCreatedBy; } set { mapeCreatedBy = TruncateValue(value, 50); } }
        public DateTime MapeCreatedDate { get { return mapeCreatedDate; } set { mapeCreatedDate = value; } }
        public string MapeFornecedor { get { return mapeFornecedor; } set { mapeFornecedor = TruncateValue(value, 50); } }
    }
}
