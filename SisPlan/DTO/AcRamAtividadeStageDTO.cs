using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcRamAtividadeStageDTO : List<AcRamAtividadeStageDTO> { }
    //====================================================================
    public class AcRamAtividadeStageDTO : BaseDTO
    {
        private decimal ramStageId;
        private string fosmCntrCodigo;
        private decimal fosmId;
        private decimal sbcnId;
        private string sbcnSigla;
        private decimal ativId;
        private string ativSig;
        private string ativNome;
        private decimal discId;
        private string discNome;
        private decimal unmeId;
        private string unmeSigla;
        private decimal foseId;
        private string foseNumero;
        private string foseRev;
        private decimal foseQtdPrevista;
        private decimal fcmeId;
        private string fcmeSigla;
        private string fcmeNome;
        private string el01FcesSigla;
        private string el01FcesDescricao;
        private decimal el01FcesNivel;
        private string el01FcesWbs;
        private decimal el01FcesPesoRelCron;
        private decimal el01FsmeAvancoAcm;
        private decimal el01FsmeQtdAcm;
        private DateTime el01FsmeData;
        private decimal el01FcesAvnReal;
        private decimal el01FcesAvnPond;
        private string el02FcesSigla;
        private string el02FcesDescricao;
        private decimal el02FcesNivel;
        private string el02FcesWbs;
        private decimal el02FcesPesoRelCron;
        private decimal el02FsmeAvancoAcm;
        private decimal el02FsmeQtdAcm;
        private DateTime el02FsmeData;
        private decimal el02FcesAvnReal;
        private decimal el02FcesAvnPond;
        private string el03FcesSigla;
        private string el03FcesDescricao;
        private decimal el03FcesNivel;
        private string el03FcesWbs;
        private decimal el03FcesPesoRelCron;
        private decimal el03FsmeAvancoAcm;
        private decimal el03FsmeQtdAcm;
        private DateTime el03FsmeData;
        private decimal el03FcesAvnReal;
        private decimal el03FcesAvnPond;
        private string el04FcesSigla;
        private string el04FcesDescricao;
        private decimal el04FcesNivel;
        private string el04FcesWbs;
        private decimal el04FcesPesoRelCron;
        private decimal el04FsmeAvancoAcm;
        private decimal el04FsmeQtdAcm;
        private DateTime el04FsmeData;
        private decimal el04FcesAvnReal;
        private decimal el04FcesAvnPond;
        private string el05FcesSigla;
        private string el05FcesDescricao;
        private decimal el05FcesNivel;
        private string el05FcesWbs;
        private decimal el05FcesPesoRelCron;
        private decimal el05FsmeAvancoAcm;
        private decimal el05FsmeQtdAcm;
        private DateTime el05FsmeData;
        private decimal el05FcesAvnReal;
        private decimal el05FcesAvnPond;
        private string el06FcesSigla;
        private string el06FcesDescricao;
        private decimal el06FcesNivel;
        private string el06FcesWbs;
        private decimal el06FcesPesoRelCron;
        private decimal el06FsmeAvancoAcm;
        private decimal el06FsmeQtdAcm;
        private DateTime el06FsmeData;
        private decimal el06FcesAvnReal;
        private decimal el06FcesAvnPond;
        private string el07FcesSigla;
        private string el07FcesDescricao;
        private decimal el07FcesNivel;
        private string el07FcesWbs;
        private decimal el07FcesPesoRelCron;
        private decimal el07FsmeAvancoAcm;
        private decimal el07FsmeQtdAcm;
        private DateTime el07FsmeData;
        private decimal el07FcesAvnReal;
        private decimal el07FcesAvnPond;
        private string el08FcesSigla;
        private string el08FcesDescricao;
        private decimal el08FcesNivel;
        private string el08FcesWbs;
        private decimal el08FcesPesoRelCron;
        private decimal el08FsmeAvancoAcm;
        private decimal el08FsmeQtdAcm;
        private DateTime el08FsmeData;
        private decimal el08FcesAvnReal;
        private decimal el08FcesAvnPond;
        private string el09FcesSigla;
        private string el09FcesDescricao;
        private decimal el09FcesNivel;
        private string el09FcesWbs;
        private decimal el09FcesPesoRelCron;
        private decimal el09FsmeAvancoAcm;
        private decimal el09FsmeQtdAcm;
        private DateTime el09FsmeData;
        private decimal el09FcesAvnReal;
        private decimal el09FcesAvnPond;
        private string el10FcesSigla;
        private string el10FcesDescricao;
        private decimal el10FcesNivel;
        private string el10FcesWbs;
        private decimal el10FcesPesoRelCron;
        private decimal el10FsmeAvancoAcm;
        private decimal el10FsmeQtdAcm;
        private DateTime el10FsmeData;
        private decimal el10FcesAvnReal;
        private decimal el10FcesAvnPond;
        private DateTime createdDate;
        private DateTime dtStart;
        private DateTime dtEnd;
        private decimal semaId;

        //====================================================================
        public decimal RamStageId { get { return ramStageId; } set { ramStageId = value; } }
        public string FosmCntrCodigo { get { return fosmCntrCodigo; } set { fosmCntrCodigo = TruncateValue(value, 30); } }
        public decimal FosmId { get { return fosmId; } set { fosmId = value; } }
        public decimal SbcnId { get { return sbcnId; } set { sbcnId = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public decimal AtivId { get { return ativId; } set { ativId = value; } }
        public string AtivSig { get { return ativSig; } set { ativSig = TruncateValue(value, 50); } }
        public string AtivNome { get { return ativNome; } set { ativNome = TruncateValue(value, 200); } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public decimal UnmeId { get { return unmeId; } set { unmeId = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 20); } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 200); } }
        public string FoseRev { get { return foseRev; } set { foseRev = TruncateValue(value, 10); } }
        public decimal FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public decimal FcmeId { get { return fcmeId; } set { fcmeId = value; } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 100); } }
        public string FcmeNome { get { return fcmeNome; } set { fcmeNome = TruncateValue(value, 150); } }
        public string El01FcesSigla { get { return el01FcesSigla; } set { el01FcesSigla = TruncateValue(value, 100); } }
        public string El01FcesDescricao { get { return el01FcesDescricao; } set { el01FcesDescricao = TruncateValue(value, 100); } }
        public decimal El01FcesNivel { get { return el01FcesNivel; } set { el01FcesNivel = value; } }
        public string El01FcesWbs { get { return el01FcesWbs; } set { el01FcesWbs = TruncateValue(value, 30); } }
        public decimal El01FcesPesoRelCron { get { return el01FcesPesoRelCron; } set { el01FcesPesoRelCron = value; } }
        public decimal El01FsmeAvancoAcm { get { return el01FsmeAvancoAcm; } set { el01FsmeAvancoAcm = value; } }
        public decimal El01FsmeQtdAcm { get { return el01FsmeQtdAcm; } set { el01FsmeQtdAcm = value; } }
        public DateTime El01FsmeData { get { return el01FsmeData; } set { el01FsmeData = value; } }
        public decimal El01FcesAvnReal { get { return el01FcesAvnReal; } set { el01FcesAvnReal = value; } }
        public decimal El01FcesAvnPond { get { return el01FcesAvnPond; } set { el01FcesAvnPond = value; } }
        public string El02FcesSigla { get { return el02FcesSigla; } set { el02FcesSigla = TruncateValue(value, 100); } }
        public string El02FcesDescricao { get { return el02FcesDescricao; } set { el02FcesDescricao = TruncateValue(value, 100); } }
        public decimal El02FcesNivel { get { return el02FcesNivel; } set { el02FcesNivel = value; } }
        public string El02FcesWbs { get { return el02FcesWbs; } set { el02FcesWbs = TruncateValue(value, 30); } }
        public decimal El02FcesPesoRelCron { get { return el02FcesPesoRelCron; } set { el02FcesPesoRelCron = value; } }
        public decimal El02FsmeAvancoAcm { get { return el02FsmeAvancoAcm; } set { el02FsmeAvancoAcm = value; } }
        public decimal El02FsmeQtdAcm { get { return el02FsmeQtdAcm; } set { el02FsmeQtdAcm = value; } }
        public DateTime El02FsmeData { get { return el02FsmeData; } set { el02FsmeData = value; } }
        public decimal El02FcesAvnReal { get { return el02FcesAvnReal; } set { el02FcesAvnReal = value; } }
        public decimal El02FcesAvnPond { get { return el02FcesAvnPond; } set { el02FcesAvnPond = value; } }
        public string El03FcesSigla { get { return el03FcesSigla; } set { el03FcesSigla = TruncateValue(value, 100); } }
        public string El03FcesDescricao { get { return el03FcesDescricao; } set { el03FcesDescricao = TruncateValue(value, 100); } }
        public decimal El03FcesNivel { get { return el03FcesNivel; } set { el03FcesNivel = value; } }
        public string El03FcesWbs { get { return el03FcesWbs; } set { el03FcesWbs = TruncateValue(value, 30); } }
        public decimal El03FcesPesoRelCron { get { return el03FcesPesoRelCron; } set { el03FcesPesoRelCron = value; } }
        public decimal El03FsmeAvancoAcm { get { return el03FsmeAvancoAcm; } set { el03FsmeAvancoAcm = value; } }
        public decimal El03FsmeQtdAcm { get { return el03FsmeQtdAcm; } set { el03FsmeQtdAcm = value; } }
        public DateTime El03FsmeData { get { return el03FsmeData; } set { el03FsmeData = value; } }
        public decimal El03FcesAvnReal { get { return el03FcesAvnReal; } set { el03FcesAvnReal = value; } }
        public decimal El03FcesAvnPond { get { return el03FcesAvnPond; } set { el03FcesAvnPond = value; } }
        public string El04FcesSigla { get { return el04FcesSigla; } set { el04FcesSigla = TruncateValue(value, 100); } }
        public string El04FcesDescricao { get { return el04FcesDescricao; } set { el04FcesDescricao = TruncateValue(value, 100); } }
        public decimal El04FcesNivel { get { return el04FcesNivel; } set { el04FcesNivel = value; } }
        public string El04FcesWbs { get { return el04FcesWbs; } set { el04FcesWbs = TruncateValue(value, 30); } }
        public decimal El04FcesPesoRelCron { get { return el04FcesPesoRelCron; } set { el04FcesPesoRelCron = value; } }
        public decimal El04FsmeAvancoAcm { get { return el04FsmeAvancoAcm; } set { el04FsmeAvancoAcm = value; } }
        public decimal El04FsmeQtdAcm { get { return el04FsmeQtdAcm; } set { el04FsmeQtdAcm = value; } }
        public DateTime El04FsmeData { get { return el04FsmeData; } set { el04FsmeData = value; } }
        public decimal El04FcesAvnReal { get { return el04FcesAvnReal; } set { el04FcesAvnReal = value; } }
        public decimal El04FcesAvnPond { get { return el04FcesAvnPond; } set { el04FcesAvnPond = value; } }
        public string El05FcesSigla { get { return el05FcesSigla; } set { el05FcesSigla = TruncateValue(value, 100); } }
        public string El05FcesDescricao { get { return el05FcesDescricao; } set { el05FcesDescricao = TruncateValue(value, 100); } }
        public decimal El05FcesNivel { get { return el05FcesNivel; } set { el05FcesNivel = value; } }
        public string El05FcesWbs { get { return el05FcesWbs; } set { el05FcesWbs = TruncateValue(value, 30); } }
        public decimal El05FcesPesoRelCron { get { return el05FcesPesoRelCron; } set { el05FcesPesoRelCron = value; } }
        public decimal El05FsmeAvancoAcm { get { return el05FsmeAvancoAcm; } set { el05FsmeAvancoAcm = value; } }
        public decimal El05FsmeQtdAcm { get { return el05FsmeQtdAcm; } set { el05FsmeQtdAcm = value; } }
        public DateTime El05FsmeData { get { return el05FsmeData; } set { el05FsmeData = value; } }
        public decimal El05FcesAvnReal { get { return el05FcesAvnReal; } set { el05FcesAvnReal = value; } }
        public decimal El05FcesAvnPond { get { return el05FcesAvnPond; } set { el05FcesAvnPond = value; } }
        public string El06FcesSigla { get { return el06FcesSigla; } set { el06FcesSigla = TruncateValue(value, 100); } }
        public string El06FcesDescricao { get { return el06FcesDescricao; } set { el06FcesDescricao = TruncateValue(value, 100); } }
        public decimal El06FcesNivel { get { return el06FcesNivel; } set { el06FcesNivel = value; } }
        public string El06FcesWbs { get { return el06FcesWbs; } set { el06FcesWbs = TruncateValue(value, 30); } }
        public decimal El06FcesPesoRelCron { get { return el06FcesPesoRelCron; } set { el06FcesPesoRelCron = value; } }
        public decimal El06FsmeAvancoAcm { get { return el06FsmeAvancoAcm; } set { el06FsmeAvancoAcm = value; } }
        public decimal El06FsmeQtdAcm { get { return el06FsmeQtdAcm; } set { el06FsmeQtdAcm = value; } }
        public DateTime El06FsmeData { get { return el06FsmeData; } set { el06FsmeData = value; } }
        public decimal El06FcesAvnReal { get { return el06FcesAvnReal; } set { el06FcesAvnReal = value; } }
        public decimal El06FcesAvnPond { get { return el06FcesAvnPond; } set { el06FcesAvnPond = value; } }
        public string El07FcesSigla { get { return el07FcesSigla; } set { el07FcesSigla = TruncateValue(value, 100); } }
        public string El07FcesDescricao { get { return el07FcesDescricao; } set { el07FcesDescricao = TruncateValue(value, 100); } }
        public decimal El07FcesNivel { get { return el07FcesNivel; } set { el07FcesNivel = value; } }
        public string El07FcesWbs { get { return el07FcesWbs; } set { el07FcesWbs = TruncateValue(value, 30); } }
        public decimal El07FcesPesoRelCron { get { return el07FcesPesoRelCron; } set { el07FcesPesoRelCron = value; } }
        public decimal El07FsmeAvancoAcm { get { return el07FsmeAvancoAcm; } set { el07FsmeAvancoAcm = value; } }
        public decimal El07FsmeQtdAcm { get { return el07FsmeQtdAcm; } set { el07FsmeQtdAcm = value; } }
        public DateTime El07FsmeData { get { return el07FsmeData; } set { el07FsmeData = value; } }
        public decimal El07FcesAvnReal { get { return el07FcesAvnReal; } set { el07FcesAvnReal = value; } }
        public decimal El07FcesAvnPond { get { return el07FcesAvnPond; } set { el07FcesAvnPond = value; } }
        public string El08FcesSigla { get { return el08FcesSigla; } set { el08FcesSigla = TruncateValue(value, 100); } }
        public string El08FcesDescricao { get { return el08FcesDescricao; } set { el08FcesDescricao = TruncateValue(value, 100); } }
        public decimal El08FcesNivel { get { return el08FcesNivel; } set { el08FcesNivel = value; } }
        public string El08FcesWbs { get { return el08FcesWbs; } set { el08FcesWbs = TruncateValue(value, 30); } }
        public decimal El08FcesPesoRelCron { get { return el08FcesPesoRelCron; } set { el08FcesPesoRelCron = value; } }
        public decimal El08FsmeAvancoAcm { get { return el08FsmeAvancoAcm; } set { el08FsmeAvancoAcm = value; } }
        public decimal El08FsmeQtdAcm { get { return el08FsmeQtdAcm; } set { el08FsmeQtdAcm = value; } }
        public DateTime El08FsmeData { get { return el08FsmeData; } set { el08FsmeData = value; } }
        public decimal El08FcesAvnReal { get { return el08FcesAvnReal; } set { el08FcesAvnReal = value; } }
        public decimal El08FcesAvnPond { get { return el08FcesAvnPond; } set { el08FcesAvnPond = value; } }
        public string El09FcesSigla { get { return el09FcesSigla; } set { el09FcesSigla = TruncateValue(value, 100); } }
        public string El09FcesDescricao { get { return el09FcesDescricao; } set { el09FcesDescricao = TruncateValue(value, 100); } }
        public decimal El09FcesNivel { get { return el09FcesNivel; } set { el09FcesNivel = value; } }
        public string El09FcesWbs { get { return el09FcesWbs; } set { el09FcesWbs = TruncateValue(value, 30); } }
        public decimal El09FcesPesoRelCron { get { return el09FcesPesoRelCron; } set { el09FcesPesoRelCron = value; } }
        public decimal El09FsmeAvancoAcm { get { return el09FsmeAvancoAcm; } set { el09FsmeAvancoAcm = value; } }
        public decimal El09FsmeQtdAcm { get { return el09FsmeQtdAcm; } set { el09FsmeQtdAcm = value; } }
        public DateTime El09FsmeData { get { return el09FsmeData; } set { el09FsmeData = value; } }
        public decimal El09FcesAvnReal { get { return el09FcesAvnReal; } set { el09FcesAvnReal = value; } }
        public decimal El09FcesAvnPond { get { return el09FcesAvnPond; } set { el09FcesAvnPond = value; } }
        public string El10FcesSigla { get { return el10FcesSigla; } set { el10FcesSigla = TruncateValue(value, 100); } }
        public string El10FcesDescricao { get { return el10FcesDescricao; } set { el10FcesDescricao = TruncateValue(value, 100); } }
        public decimal El10FcesNivel { get { return el10FcesNivel; } set { el10FcesNivel = value; } }
        public string El10FcesWbs { get { return el10FcesWbs; } set { el10FcesWbs = TruncateValue(value, 30); } }
        public decimal El10FcesPesoRelCron { get { return el10FcesPesoRelCron; } set { el10FcesPesoRelCron = value; } }
        public decimal El10FsmeAvancoAcm { get { return el10FsmeAvancoAcm; } set { el10FsmeAvancoAcm = value; } }
        public decimal El10FsmeQtdAcm { get { return el10FsmeQtdAcm; } set { el10FsmeQtdAcm = value; } }
        public DateTime El10FsmeData { get { return el10FsmeData; } set { el10FsmeData = value; } }
        public decimal El10FcesAvnReal { get { return el10FcesAvnReal; } set { el10FcesAvnReal = value; } }
        public decimal El10FcesAvnPond { get { return el10FcesAvnPond; } set { el10FcesAvnPond = value; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
        public DateTime DtStart { get { return dtStart; } set { dtStart = value; } }
        public DateTime DtEnd { get { return dtEnd; } set { dtEnd = value; } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
    }
}
