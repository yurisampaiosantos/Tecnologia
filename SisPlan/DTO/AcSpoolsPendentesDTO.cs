using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcSpoolsPendentesDTO : List<AcSpoolsPendentesDTO> { }
    //====================================================================
    public class AcSpoolsPendentesDTO : BaseDTO
    {
        private decimal sppdId;
        private decimal sppdComaId;
        private string sppdSbcnSigla;
        private decimal sppdFoseId;
        private string sppdFoseNumero;
        private string sppdPipeLine;
        private string sppdFoseRev;
        private string sppdFoseDescricao;
        private string sppdTstfUnidadeRegional;
        private string sppdRegiao;
        private string sppdDiprCodigo;
        private string sppdDiprDimensoes;
        private string sppdDiprDescricao;
        private string sppdUnmeSigla;
        private decimal sppdQtdNecessaria;
        private decimal sppdQtdFsCorrida;
        private decimal sppdQtdAReservar;
        private string sppdDcmnNumero;
        private string sppdReplRev;
        private string sppdAufoNumero;
        private string sppdProxDataRecebimento;
        private string sppdDatasRecebimento;
        private string sppdNotasFiscais;
        private string sppdAreasEstocagem;
        private decimal sppdDcmnId;
        private string sppdCreatedBy;
        private DateTime sppdCreatedDate;
        private string sppdFabricado;

        //====================================================================
        public decimal SppdId { get { return sppdId; } set { sppdId = value; } }
        public decimal SppdComaId { get { return sppdComaId; } set { sppdComaId = value; } }
        public string SppdSbcnSigla { get { return sppdSbcnSigla; } set { sppdSbcnSigla = TruncateValue(value, 10); } }
        public decimal SppdFoseId { get { return sppdFoseId; } set { sppdFoseId = value; } }
        public string SppdFoseNumero { get { return sppdFoseNumero; } set { sppdFoseNumero = TruncateValue(value, 100); } }
        public string SppdPipeline { get { return sppdPipeLine; } set { sppdPipeLine = TruncateValue(value, 50); } }
        public string SppdFoseRev { get { return sppdFoseRev; } set { sppdFoseRev = TruncateValue(value, 20); } }
        public string SppdFoseDescricao { get { return sppdFoseDescricao; } set { sppdFoseDescricao = TruncateValue(value, 100); } }
        public string SppdTstfUnidadeRegional { get { return sppdTstfUnidadeRegional; } set { sppdTstfUnidadeRegional = TruncateValue(value, 100); } }
        public string SppdRegiao { get { return sppdRegiao; } set { sppdRegiao = TruncateValue(value, 100); } }
        public string SppdDiprCodigo { get { return sppdDiprCodigo; } set { sppdDiprCodigo = TruncateValue(value, 50); } }
        public string SppdDiprDimensoes { get { return sppdDiprDimensoes; } set { sppdDiprDimensoes = TruncateValue(value, 50); } }
        public string SppdDiprDescricao { get { return sppdDiprDescricao; } set { sppdDiprDescricao = TruncateValue(value, 2000); } }
        public string SppdUnmeSigla { get { return sppdUnmeSigla; } set { sppdUnmeSigla = TruncateValue(value, 20); } }
        public decimal SppdQtdNecessaria { get { return sppdQtdNecessaria; } set { sppdQtdNecessaria = value; } }
        public decimal SppdQtdFsCorrida { get { return sppdQtdFsCorrida; } set { sppdQtdFsCorrida = value; } }
        public decimal SppdQtdAReservar { get { return sppdQtdAReservar; } set { sppdQtdAReservar = value; } }
        public string SppdDcmnNumero { get { return sppdDcmnNumero; } set { sppdDcmnNumero = TruncateValue(value, 100); } }
        public string SppdReplRev { get { return sppdReplRev; } set { sppdReplRev = TruncateValue(value, 20); } }
        public string SppdAufoNumero { get { return sppdAufoNumero; } set { sppdAufoNumero = TruncateValue(value, 200); } }
        public string SppdProxDataRecebimento { get { return sppdProxDataRecebimento; } set { sppdProxDataRecebimento = TruncateValue(value, 100); } }
        public string SppdDatasRecebimento { get { return sppdDatasRecebimento; } set { sppdDatasRecebimento = TruncateValue(value, 150); } }
        public string SppdNotasFiscais { get { return sppdNotasFiscais; } set { sppdNotasFiscais = TruncateValue(value, 150); } }
        public string SppdAreasEstocagem { get { return sppdAreasEstocagem; } set { sppdAreasEstocagem = TruncateValue(value, 300); } }
        public decimal SppdDcmnId { get { return sppdDcmnId; } set { sppdDcmnId = value; } }
        public string SppdCreatedBy { get { return sppdCreatedBy; } set { sppdCreatedBy = TruncateValue(value, 60); } }
        public DateTime SppdCreatedDate { get { return sppdCreatedDate; } set { sppdCreatedDate = value; } }
        public string SppdFabricado { get { return sppdFabricado; } set { sppdFabricado = TruncateValue(value, 1); } }
    }
}
