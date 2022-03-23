using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcAvancoBkpDTO : List<AcAvancoBkpDTO> { }
    //====================================================================
    public class AcAvancoBkpDTO : BaseDTO
    {
        private decimal avbkId;
        private string fsmeCntrCodigo;
        private decimal fsmeId;
        private decimal fsmeFosmId;
        private DateTime fsmeData;
        private string fsmeDataText;
        private decimal? fsmeAvancoAcm;
        private decimal? fsmeQtdAcm;
        private decimal? fsmeSifsId;
        private string fsmeObs;
        private DateTime fsmeDtCadastro;
        private string fsmeDtCadastroText;
        private DateTime avbkDtCaptura;
        private string avbkDtCapturaText;
        //====================================================================
        public enum attributeName { AVBK_ID, FSME_CNTR_CODIGO, FSME_ID, FSME_FOSM_ID, FSME_DATA, FSME_DATA_TEXT, FSME_AVANCO_ACM, FSME_QTD_ACM, FSME_SIFS_ID, FSME_OBS, FSME_DT_CADASTRO, FSME_DT_CADASTRO_TEXT, AVBK_DT_CAPTURA, AVBK_DT_CAPTURA_TEXT };
        public enum propertyName { AvbkId, FsmeCntrCodigo, FsmeId, FsmeFosmId, FsmeData, FsmeDataText, FsmeAvancoAcm, FsmeQtdAcm, FsmeSifsId, FsmeObs, FsmeDtCadastro, FsmeDtCadastroText, AvbkDtCaptura, AvbkDtCapturaText };
        //====================================================================
        private static int length = 14;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal AvbkId { get { return avbkId; } set { avbkId = value; } }
        public string FsmeCntrCodigo { get { return fsmeCntrCodigo; } set { fsmeCntrCodigo = TruncateValue(value, 10); } }
        public decimal FsmeId { get { return fsmeId; } set { fsmeId = value; } }
        public decimal FsmeFosmId { get { return fsmeFosmId; } set { fsmeFosmId = value; } }
        public DateTime FsmeData { get { return fsmeData; } set { fsmeData = value; } }
        public string FsmeDataText { get { return fsmeDataText; } set { fsmeDataText = TruncateValue(value, 20); } }
        public decimal? FsmeAvancoAcm { get { return fsmeAvancoAcm; } set { fsmeAvancoAcm = value; } }
        public decimal? FsmeQtdAcm { get { return fsmeQtdAcm; } set { fsmeQtdAcm = value; } }
        public decimal? FsmeSifsId { get { return fsmeSifsId; } set { fsmeSifsId = value; } }
        public string FsmeObs { get { return fsmeObs; } set { fsmeObs = TruncateValue(value, 4000); } }
        public DateTime FsmeDtCadastro { get { return fsmeDtCadastro; } set { fsmeDtCadastro = value; } }
        public string FsmeDtCadastroText { get { return fsmeDtCadastroText; } set { fsmeDtCadastroText = TruncateValue(value, 20); } }
        public DateTime AvbkDtCaptura { get { return avbkDtCaptura; } set { avbkDtCaptura = value; } }
        public string AvbkDtCapturaText { get { return avbkDtCapturaText; } set { avbkDtCapturaText = TruncateValue(value, 20); } }
    }
}