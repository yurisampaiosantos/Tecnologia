using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcRamAtividadeDTO : List<AcRamAtividadeDTO> { }
    //====================================================================
    public class AcRamAtividadeDTO : BaseDTO
    {
        private decimal ramId;
        private decimal active;
        private string sbcnSigla;
        private string ativSig;
        private string ativNome;
        private string discNome;
        private decimal unmeId;
        private string unmeSigla;
        private decimal? foseId;
        private string foseNumero;
        private string foseRev;
        private decimal? foseQtdPrevista;
        private string desenho;
        private string fcmeSigla;
        private string fcesSigla;
        private string fcesWbs;
        private decimal fcesPesoRelCron;

        private string el01;
        private string el02;
        private string el03;
        private string el04;
        private string el05;
        private string el06;
        private string el07;
        private string el08;
        private string el09;
        private string el10;

        private DateTime createdDate;
        private string fosmCntrCodigo;
        private decimal sbcnId;
        private decimal discId;
        private decimal ativId;
        private decimal fcmeId;
        private decimal? fosmId;
        private decimal tipoLinha;
        private DateTime dtStart;
        private DateTime dtEnd;
        private decimal? semaId;
        private string qtdPrevistoAtividade;
        //====================================================================
        public enum attributeName { RAM_ID, ACTIVE, SBCN_SIGLA, ATIV_SIG, ATIV_NOME, DISC_NOME, UNME_ID, UNME_SIGLA, FOSE_ID, FOSE_NUMERO, FOSE_REV, FOSE_QTD_PREVISTA, DESENHO, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FCES_PESO_REL_CRON, EL01, EL02, EL03, EL04, EL05, EL06, EL07, EL08, EL09, EL10, CREATED_DATE, FOSM_CNTR_CODIGO, SBCN_ID, DISC_ID, ATIV_ID, FCME_ID, FOSM_ID, TIPO_LINHA, DT_START, DT_END, SEMA_ID, QTD_PREVISTO_ATIVIDADE };
        public enum propertyName { RamId, Active, SbcnSigla, AtivSig, AtivNome, DiscNome, UnmeId, UnmeSigla, FoseId, FoseNumero, FoseRev, FoseQtdPrevista, Desenho, FcmeSigla, FcesSigla, FcesWbs, FcesPesoRelCron, El01, El02, El03, El04, El05, El06, El07, El08, El09, El10, CreatedDate, FosmCntrCodigo, SbcnId, DiscId, AtivId, FcmeId, FosmId, TipoLinha, DtStart, DtEnd, SemaId, QtdPrevistoAtividade };
        //====================================================================
        private static int length = 38;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal RamId { get { return ramId; } set { ramId = value; } }
        public decimal Active { get { return active; } set { active = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public string AtivSig { get { return ativSig; } set { ativSig = TruncateValue(value, 50); } }
        public string AtivNome { get { return ativNome; } set { ativNome = TruncateValue(value, 200); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public decimal UnmeId { get { return unmeId; } set { unmeId = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 20); } }
        public decimal? FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 200); } }
        public string FoseRev { get { return foseRev; } set { foseRev = TruncateValue(value, 10); } }
        public decimal? FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 100); } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 150); } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 150); } }
        public string FcesWbs { get { return fcesWbs; } set { fcesWbs = TruncateValue(value, 30); } }
        public decimal FcesPesoRelCron { get { return fcesPesoRelCron; } set { fcesPesoRelCron = value; } }
        public string El01 { get { return el01; } set { el01 = TruncateValue(value, 50); } }
        public string El02 { get { return el02; } set { el02 = TruncateValue(value, 50); } }
        public string El03 { get { return el03; } set { el03 = TruncateValue(value, 50); } }
        public string El04 { get { return el04; } set { el04 = TruncateValue(value, 50); } }
        public string El05 { get { return el05; } set { el05 = TruncateValue(value, 50); } }
        public string El06 { get { return el06; } set { el06 = TruncateValue(value, 50); } }
        public string El07 { get { return el07; } set { el07 = TruncateValue(value, 50); } }
        public string El08 { get { return el08; } set { el08 = TruncateValue(value, 50); } }
        public string El09 { get { return el09; } set { el09 = TruncateValue(value, 50); } }
        public string El10 { get { return el10; } set { el10 = TruncateValue(value, 30); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public string FosmCntrCodigo { get { return fosmCntrCodigo; } set { fosmCntrCodigo = TruncateValue(value, 30); } }
        public decimal SbcnId { get { return sbcnId; } set { sbcnId = value; } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public decimal AtivId { get { return ativId; } set { ativId = value; } }
        public decimal FcmeId { get { return fcmeId; } set { fcmeId = value; } }
        public decimal? FosmId { get { return fosmId; } set { fosmId = value; } }
        public decimal TipoLinha { get { return tipoLinha; } set { tipoLinha = value; } }
        public DateTime DtStart { get { return dtStart; } set { dtStart = value; } }
        public DateTime DtEnd { get { return dtEnd; } set { dtEnd = value; } }
        public decimal? SemaId { get { return semaId; } set { semaId = value; } }
        public string QtdPrevistoAtividade { get { return qtdPrevistoAtividade; } set { qtdPrevistoAtividade = TruncateValue(value, 15); } }
    }
}
