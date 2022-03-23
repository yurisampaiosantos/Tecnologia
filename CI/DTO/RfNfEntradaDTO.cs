using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionRfNfEntradaDTO : List<RfNfEntradaDTO> { }
    //====================================================================
    public class RfNfEntradaDTO : BaseDTO
    {
        private decimal id;
        private decimal idImportacao;
        private decimal idRef;
        private string cfop;
        private string codFornecedor;
        private string codProprietario;
        private string dataDoc;
        private string dataEntrada;
        private string dataGerLeg;
        private string dataNf;
        private string docOrigem;
        private string idCorporativo;
        private string ncm;
        private string nfE;
        private string numAdicao;
        private string numDiCambial;
        private decimal numItem;
        private string numItemAdicao;
        private string organizacao;
        private string partNumber;
        private string procedenciaInfo;
        private decimal qtde;
        private string refBaixa;
        private string refEntrada;
        private string refErpEnt;
        private string refNfe;
        private string segmento1;
        private string segmento2;
        private string segmento3;
        private string segmento4;
        private string segmento5;
        private string serieE;
        private string tipoEntrada;
        private decimal valorFiscal;
        private string vctoDiCambial;
        private string numContrato;
        private string finalidadeEntrada;
        //====================================================================
        public enum attributeName { ID, ID_IMPORTACAO, ID_REF, CFOP, COD_FORNECEDOR, COD_PROPRIETARIO, DATA_DOC, DATA_ENTRADA, DATA_GER_LEG, DATA_NF, DOC_ORIGEM, ID_CORPORATIVO, NCM, NF_E, NUM_ADICAO, NUM_DI_CAMBIAL, NUM_ITEM, NUM_ITEM_ADICAO, ORGANIZACAO, PART_NUMBER, PROCEDENCIA_INFO, QTDE, REF_BAIXA, REF_ENTRADA, REF_ERP_ENT, REF_NFE, SEGMENTO1, SEGMENTO2, SEGMENTO3, SEGMENTO4, SEGMENTO5, SERIE_E, TIPO_ENTRADA, VALOR_FISCAL, VCTO_DI_CAMBIAL, NUM_CONTRATO, FINALIDADE_ENTRADA };
        public enum propertyName { ID, IdImportacao, IdRef, Cfop, CodFornecedor, CodProprietario, DataDoc, DataEntrada, DataGerLeg, DataNf, DocOrigem, IdCorporativo, Ncm, NfE, NumAdicao, NumDiCambial, NumItem, NumItemAdicao, Organizacao, PartNumber, ProcedenciaInfo, Qtde, RefBaixa, RefEntrada, RefErpEnt, RefNfe, Segmento1, Segmento2, Segmento3, Segmento4, Segmento5, SerieE, TipoEntrada, ValorFiscal, VctoDiCambial, NumContrato, FinalidadeEntrada };
        //====================================================================
        private static int length = 37;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public decimal IdImportacao { get { return idImportacao; } set { idImportacao = value; } }
        public decimal IdRef { get { return idRef; } set { idRef = value; } }
        public string Cfop { get { return cfop; } set { cfop = TruncateValue(value, 4); } }
        public string CodFornecedor { get { return codFornecedor; } set { codFornecedor = TruncateValue(value, 20); } }
        public string CodProprietario { get { return codProprietario; } set { codProprietario = TruncateValue(value, 20); } }
        public string DataDoc { get { return dataDoc; } set { dataDoc = TruncateValue(value, 8); } }
        public string DataEntrada { get { return dataEntrada; } set { dataEntrada = TruncateValue(value, 8); } }
        public string DataGerLeg { get { return dataGerLeg; } set { dataGerLeg = TruncateValue(value, 8); } }
        public string DataNf { get { return dataNf; } set { dataNf = TruncateValue(value, 8); } }
        public string DocOrigem { get { return docOrigem; } set { docOrigem = TruncateValue(value, 50); } }
        public string IdCorporativo { get { return idCorporativo; } set { idCorporativo = TruncateValue(value, 100); } }
        public string Ncm { get { return ncm; } set { ncm = TruncateValue(value, 8); } }
        public string NfE { get { return nfE; } set { nfE = TruncateValue(value, 10); } }
        public string NumAdicao { get { return numAdicao; } set { numAdicao = TruncateValue(value, 3); } }
        public string NumDiCambial { get { return numDiCambial; } set { numDiCambial = TruncateValue(value, 10); } }
        public decimal NumItem { get { return numItem; } set { numItem = value; } }
        public string NumItemAdicao { get { return numItemAdicao; } set { numItemAdicao = TruncateValue(value, 16); } }
        public string Organizacao { get { return organizacao; } set { organizacao = TruncateValue(value, 100); } }
        public string PartNumber { get { return partNumber; } set { partNumber = TruncateValue(value, 100); } }
        public string ProcedenciaInfo { get { return procedenciaInfo; } set { procedenciaInfo = TruncateValue(value, 50); } }
        public decimal Qtde { get { return qtde; } set { qtde = value; } }
        public string RefBaixa { get { return refBaixa; } set { refBaixa = TruncateValue(value, 100); } }
        public string RefEntrada { get { return refEntrada; } set { refEntrada = TruncateValue(value, 100); } }
        public string RefErpEnt { get { return refErpEnt; } set { refErpEnt = TruncateValue(value, 15); } }
        public string RefNfe { get { return refNfe; } set { refNfe = TruncateValue(value, 100); } }
        public string Segmento1 { get { return segmento1; } set { segmento1 = TruncateValue(value, 250); } }
        public string Segmento2 { get { return segmento2; } set { segmento2 = TruncateValue(value, 250); } }
        public string Segmento3 { get { return segmento3; } set { segmento3 = TruncateValue(value, 250); } }
        public string Segmento4 { get { return segmento4; } set { segmento4 = TruncateValue(value, 250); } }
        public string Segmento5 { get { return segmento5; } set { segmento5 = TruncateValue(value, 250); } }
        public string SerieE { get { return serieE; } set { serieE = TruncateValue(value, 5); } }
        public string TipoEntrada { get { return tipoEntrada; } set { tipoEntrada = TruncateValue(value, 20); } }
        public decimal ValorFiscal { get { return valorFiscal; } set { valorFiscal = value; } }
        public string VctoDiCambial { get { return vctoDiCambial; } set { vctoDiCambial = TruncateValue(value, 8); } }
        public string NumContrato { get { return numContrato; } set { numContrato = TruncateValue(value, 50); } }
        public string FinalidadeEntrada { get { return finalidadeEntrada; } set { finalidadeEntrada = TruncateValue(value, 100); } }
    }
}
