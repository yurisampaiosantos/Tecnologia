using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcMateriaisPendentesDTO : List<AcMateriaisPendentesDTO> { }
    //====================================================================
    public class AcMateriaisPendentesDTO : BaseDTO
    {
        private decimal mapdId;
        private decimal mapdComaId;
        private string mapdSbcnSigla;
        private decimal mapdDiscId;
        private string mapdDiprCodigo;
        private string mapdDiprDimensoes;
        private string mapdUnmeSigla;
        private decimal? mapdQtdNecAnteriorCorrida;
        private decimal mapdQtdNecCorrida;
        private decimal mapdQtdNecTotal;
        private decimal mapdQtdMaterialRm;
        private decimal mapdCoberturaRm;
        private decimal? mapdQtdMaterialAf;
        private decimal? mapdCoberturaAf;
        private string mapdDcmnNumero;
        private string mapdReplRev;
        private string mapdAufoNumero;
        private string mapdAufoEmprNome;
        private string mapdProxDataRecebimento;
        private string mapdNotasFiscais;
        private decimal? mapdNfitQtd;
        private decimal mapdSaldoEntrega;
        private decimal? mapdAguardandoRecebimento;
        private decimal? mapdCorrecaoRm;
        private decimal? mapdSolicitacaoCompra;
        private string mapdPrevisaoRecebimento;
        private string mapdComentSupr;
        private string mapdDatasRecebimento;
        private string mapdNoenNumero;
        private decimal? mapdNoeiQtdNem;
        private decimal mapdSaldoLiberado;
        private string mapdDvreNumero;
        private string mapdAreasEstocagem;
        private string mapdDiprDescricao;
        private decimal mapdDcmnId;
        private string mapdNofiReferencia;
        //====================================================================
        public enum attributeName { MAPD_ID, MAPD_COMA_ID, MAPD_SBCN_SIGLA, MAPD_DISC_ID, MAPD_DIPR_CODIGO, MAPD_DIPR_DIMENSOES, MAPD_UNME_SIGLA, MAPD_QTD_NEC_ANTERIOR_CORRIDA, MAPD_QTD_NEC_CORRIDA, MAPD_QTD_NEC_TOTAL, MAPD_QTD_MATERIAL_RM, MAPD_COBERTURA_RM, MAPD_QTD_MATERIAL_AF, MAPD_COBERTURA_AF, MAPD_DCMN_NUMERO, MAPD_REPL_REV, MAPD_AUFO_NUMERO, MAPD_AUFO_EMPR_NOME, MAPD_PROX_DATA_RECEBIMENTO, MAPD_NOTAS_FISCAIS, MAPD_NFIT_QTD, MAPD_SALDO_ENTREGA, MAPD_AGUARDANDO_RECEBIMENTO, MAPD_CORRECAO_RM, MAPD_SOLICITACAO_COMPRA, MAPD_PREVISAO_RECEBIMENTO, MAPD_COMENT_SUPR, MAPD_DATAS_RECEBIMENTO, MAPD_NOEN_NUMERO, MAPD_NOEI_QTD_NEM, MAPD_SALDO_LIBERADO, MAPD_DVRE_NUMERO, MAPD_AREAS_ESTOCAGEM, MAPD_DIPR_DESCRICAO, MAPD_DCMN_ID, MAPD_NOFI_REFERENCIA };
        public enum propertyName { MapdId, MapdComaId, MapdSbcnSigla, MapdDiscId, MapdDiprCodigo, MapdDiprDimensoes, MapdUnmeSigla, MapdQtdNecAnteriorCorrida, MapdQtdNecCorrida, MapdQtdNecTotal, MapdQtdMaterialRm, MapdCoberturaRm, MapdQtdMaterialAf, MapdCoberturaAf, MapdDcmnNumero, MapdReplRev, MapdAufoNumero, MapdAufoEmprNome, MapdProxDataRecebimento, MapdNotasFiscais, MapdNfitQtd, MapdSaldoEntrega, MapdAguardandoRecebimento, MapdCorrecaoRm, MapdSolicitacaoCompra, MapdPrevisaoRecebimento, MapdComentSupr, MapdDatasRecebimento, MapdNoenNumero, MapdNoeiQtdNem, MapdSaldoLiberado, MapdDvreNumero, MapdAreasEstocagem, MapdDiprDescricao, MapdDcmnId, MapdNofiReferencia };
        //====================================================================
        private static int length = 36;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal MapdId { get { return mapdId; } set { mapdId = value; } }
        public decimal MapdComaId { get { return mapdComaId; } set { mapdComaId = value; } }
        public string MapdSbcnSigla { get { return mapdSbcnSigla; } set { mapdSbcnSigla = TruncateValue(value, 10); } }
        public decimal MapdDiscId { get { return mapdDiscId; } set { mapdDiscId = value; } }
        public string MapdDiprCodigo { get { return mapdDiprCodigo; } set { mapdDiprCodigo = TruncateValue(value, 50); } }
        public string MapdDiprDimensoes { get { return mapdDiprDimensoes; } set { mapdDiprDimensoes = TruncateValue(value, 50); } }
        public string MapdUnmeSigla { get { return mapdUnmeSigla; } set { mapdUnmeSigla = TruncateValue(value, 20); } }
        public decimal? MapdQtdNecAnteriorCorrida { get { return mapdQtdNecAnteriorCorrida; } set { mapdQtdNecAnteriorCorrida = value; } }
        public decimal MapdQtdNecCorrida { get { return mapdQtdNecCorrida; } set { mapdQtdNecCorrida = value; } }
        public decimal MapdQtdNecTotal { get { return mapdQtdNecTotal; } set { mapdQtdNecTotal = value; } }
        public decimal MapdQtdMaterialRm { get { return mapdQtdMaterialRm; } set { mapdQtdMaterialRm = value; } }
        public decimal MapdCoberturaRm { get { return mapdCoberturaRm; } set { mapdCoberturaRm = value; } }
        public decimal? MapdQtdMaterialAf { get { return mapdQtdMaterialAf; } set { mapdQtdMaterialAf = value; } }
        public decimal? MapdCoberturaAf { get { return mapdCoberturaAf; } set { mapdCoberturaAf = value; } }
        public string MapdDcmnNumero { get { return mapdDcmnNumero; } set { mapdDcmnNumero = TruncateValue(value, 100); } }
        public string MapdReplRev { get { return mapdReplRev; } set { mapdReplRev = TruncateValue(value, 20); } }
        public string MapdAufoNumero { get { return mapdAufoNumero; } set { mapdAufoNumero = TruncateValue(value, 200); } }
        public string MapdAufoEmprNome { get { return mapdAufoEmprNome; } set { mapdAufoEmprNome = TruncateValue(value, 200); } }
        public string MapdProxDataRecebimento { get { return mapdProxDataRecebimento; } set { mapdProxDataRecebimento = TruncateValue(value, 100); } }
        public string MapdNotasFiscais { get { return mapdNotasFiscais; } set { mapdNotasFiscais = TruncateValue(value, 200); } }
        public decimal? MapdNfitQtd { get { return mapdNfitQtd; } set { mapdNfitQtd = value; } }
        public decimal MapdSaldoEntrega { get { return mapdSaldoEntrega; } set { mapdSaldoEntrega = value; } }
        public decimal? MapdAguardandoRecebimento { get { return mapdAguardandoRecebimento; } set { mapdAguardandoRecebimento = value; } }
        public decimal? MapdCorrecaoRm { get { return mapdCorrecaoRm; } set { mapdCorrecaoRm = value; } }
        public decimal? MapdSolicitacaoCompra { get { return mapdSolicitacaoCompra; } set { mapdSolicitacaoCompra = value; } }
        public string MapdPrevisaoRecebimento { get { return mapdPrevisaoRecebimento; } set { mapdPrevisaoRecebimento = TruncateValue(value, 50); } }
        public string MapdComentSupr { get { return mapdComentSupr; } set { mapdComentSupr = TruncateValue(value, 100); } }
        public string MapdDatasRecebimento { get { return mapdDatasRecebimento; } set { mapdDatasRecebimento = TruncateValue(value, 150); } }
        public string MapdNoenNumero { get { return mapdNoenNumero; } set { mapdNoenNumero = TruncateValue(value, 200); } }
        public decimal? MapdNoeiQtdNem { get { return mapdNoeiQtdNem; } set { mapdNoeiQtdNem = value; } }
        public decimal MapdSaldoLiberado { get { return mapdSaldoLiberado; } set { mapdSaldoLiberado = value; } }
        public string MapdDvreNumero { get { return mapdDvreNumero; } set { mapdDvreNumero = TruncateValue(value, 200); } }
        public string MapdAreasEstocagem { get { return mapdAreasEstocagem; } set { mapdAreasEstocagem = TruncateValue(value, 2000); } }
        public string MapdDiprDescricao { get { return mapdDiprDescricao; } set { mapdDiprDescricao = TruncateValue(value, 2000); } }
        public decimal MapdDcmnId { get { return mapdDcmnId; } set { mapdDcmnId = value; } }
        public string MapdNofiReferencia { get { return mapdNofiReferencia; } set { mapdNofiReferencia = TruncateValue(value, 200); } }
    }
}
