using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpMaterialPendenteDTO : List<CpMaterialPendenteDTO> { }
    //====================================================================
    public class CpMaterialPendenteDTO : BaseDTO
    {
        private decimal mapeId;
        private string mapeCntrCodigo;
        private decimal mapePastaId;
        private string mapeDescricao;
        private decimal mapeQuantidade;
        private string mapeUnidade;
        private decimal mapeLocaId;
        private decimal mapeStmpId;
        private string mapeCreatedBy;
        private DateTime mapeCreatedDate;
        private string mapeFornecedor;
        //====================================================================
        public decimal MapeId { get { return mapeId; } set { mapeId = value; } }
        public string MapeCntrCodigo { get { return mapeCntrCodigo; } set { mapeCntrCodigo = TruncateValue(value, 10); } }
        public decimal MapePastaId { get { return mapePastaId; } set { mapePastaId = value; } }
        public string MapeDescricao { get { return mapeDescricao; } set { mapeDescricao = TruncateValue(value, 100); } }
        public decimal MapeQuantidade { get { return mapeQuantidade; } set { mapeQuantidade = value; } }
        public string MapeUnidade { get { return mapeUnidade; } set { mapeUnidade = TruncateValue(value, 5); } }
        public decimal MapeLocaId { get { return mapeLocaId; } set { mapeLocaId = value; } }
        public decimal MapeStmpId { get { return mapeStmpId; } set { mapeStmpId = value; } }
        public string MapeCreatedBy { get { return mapeCreatedBy; } set { mapeCreatedBy = TruncateValue(value, 50); } }
        public DateTime MapeCreatedDate { get { return mapeCreatedDate; } set { mapeCreatedDate = value; } }
        public string MapeFornecedor { get { return mapeFornecedor; } set { mapeFornecedor = TruncateValue(value, 100); } }
    }
}
