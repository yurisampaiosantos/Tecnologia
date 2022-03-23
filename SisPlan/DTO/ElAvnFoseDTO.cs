using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionElAvnFoseDTO : List<ElAvnFoseDTO> { }
    //====================================================================
    public class ElAvnFoseDTO : BaseDTO
    {
        private decimal id;
        private decimal active;
        private string foseCntrCodigo;
        private string sbcnSigla;
        private string discNome;
        private string sifsDescricao;
        private string ativSig;
        private string arapNome;
        private string unprNome;
        private decimal tipoLinha;
        private string foseNumero;
        private string fcmeSigla;
        private decimal fcesNivel;
        private string pasta;
        private string desenho;
        private string tipo;
        private string setor;
        private decimal foseQtdPrevista;
        private string unmeSigla;
        private string el01FcesSigla;
        private DateTime el01FsmpData;
        private DateTime el01FsmeData;
        private decimal el01FsmeQtdAcm;
        private decimal el01FsmeAvancoAcm;
        private string el02FcesSigla;
        private DateTime el02FsmpData;
        private DateTime el02FsmeData;
        private decimal el02FsmeQtdAcm;
        private decimal el02FsmeAvancoAcm;
        private string el03FcesSigla;
        private DateTime el03FsmpData;
        private DateTime el03FsmeData;
        private decimal el03FsmeQtdAcm;
        private decimal el03FsmeAvancoAcm;
        private string el04FcesSigla;
        private DateTime el04FsmpData;
        private DateTime el04FsmeData;
        private decimal el04FsmeQtdAcm;
        private decimal el04FsmeAvancoAcm;
        private string el05FcesSigla;
        private DateTime el05FsmpData;
        private DateTime el05FsmeData;
        private decimal el05FsmeQtdAcm;
        private decimal el05FsmeAvancoAcm;
        private string el06FcesSigla;
        private DateTime el06FsmpData;
        private DateTime el06FsmeData;
        private decimal el06FsmeQtdAcm;
        private decimal el06FsmeAvancoAcm;
        private string el07FcesSigla;
        private DateTime el07FsmpData;
        private DateTime el07FsmeData;
        private decimal el07FsmeQtdAcm;
        private decimal el07FsmeAvancoAcm;
        private string el08FcesSigla;
        private DateTime el08FsmpData;
        private DateTime el08FsmeData;
        private decimal el08FsmeQtdAcm;
        private decimal el08FsmeAvancoAcm;
        private string el09FcesSigla;
        private DateTime el09FsmpData;
        private DateTime el09FsmeData;
        private decimal el09FsmeQtdAcm;
        private decimal el09FsmeAvancoAcm;
        private string el10FcesSigla;
        private DateTime el10FsmpData;
        private DateTime el10FsmeData;
        private decimal el10FsmeQtdAcm;
        private decimal el10FsmeAvancoAcm;
        private string el11FcesSigla;
        private DateTime el11FsmpData;
        private DateTime el11FsmeData;
        private decimal el11FsmeQtdAcm;
        private decimal el11FsmeAvancoAcm;
        private string el12FcesSigla;
        private DateTime el12FsmpData;
        private DateTime el12FsmeData;
        private decimal el12FsmeQtdAcm;
        private decimal el12FsmeAvancoAcm;
        private decimal discId;
        private decimal ativId;
        private decimal foseId;
        private decimal fosmId;
        private decimal fcmeId;
        private DateTime createdDate;
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public decimal Active { get { return active; } set { active = value; } }
        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = TruncateValue(value, 10); } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public string SifsDescricao { get { return sifsDescricao; } set { sifsDescricao = TruncateValue(value, 20); } }
        public string AtivSig { get { return ativSig; } set { ativSig = TruncateValue(value, 50); } }
        public string ArapNome { get { return arapNome; } set { arapNome = TruncateValue(value, 30); } }
        public string UnprNome { get { return unprNome; } set { unprNome = TruncateValue(value, 30); } }
        public decimal TipoLinha { get { return tipoLinha; } set { tipoLinha = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 200); } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 100); } }
        public decimal FcesNivel { get { return fcesNivel; } set { fcesNivel = value; } }
        public string Pasta { get { return pasta; } set { pasta = TruncateValue(value, 30); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 100); } }
        public string Tipo { get { return tipo; } set { tipo = TruncateValue(value, 50); } }
        public string Setor { get { return setor; } set { setor = TruncateValue(value, 20); } }
        public decimal FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 20); } }
        public string El01FcesSigla { get { return el01FcesSigla; } set { el01FcesSigla = TruncateValue(value, 50); } }
        public DateTime El01FsmpData { get { return el01FsmpData; } set { el01FsmpData = value; } }
        public DateTime El01FsmeData { get { return el01FsmeData; } set { el01FsmeData = value; } }
        public decimal El01FsmeQtdAcm { get { return el01FsmeQtdAcm; } set { el01FsmeQtdAcm = value; } }
        public decimal El01FsmeAvancoAcm { get { return el01FsmeAvancoAcm; } set { el01FsmeAvancoAcm = value; } }
        public string El02FcesSigla { get { return el02FcesSigla; } set { el02FcesSigla = TruncateValue(value, 50); } }
        public DateTime El02FsmpData { get { return el02FsmpData; } set { el02FsmpData = value; } }
        public DateTime El02FsmeData { get { return el02FsmeData; } set { el02FsmeData = value; } }
        public decimal El02FsmeQtdAcm { get { return el02FsmeQtdAcm; } set { el02FsmeQtdAcm = value; } }
        public decimal El02FsmeAvancoAcm { get { return el02FsmeAvancoAcm; } set { el02FsmeAvancoAcm = value; } }
        public string El03FcesSigla { get { return el03FcesSigla; } set { el03FcesSigla = TruncateValue(value, 50); } }
        public DateTime El03FsmpData { get { return el03FsmpData; } set { el03FsmpData = value; } }
        public DateTime El03FsmeData { get { return el03FsmeData; } set { el03FsmeData = value; } }
        public decimal El03FsmeQtdAcm { get { return el03FsmeQtdAcm; } set { el03FsmeQtdAcm = value; } }
        public decimal El03FsmeAvancoAcm { get { return el03FsmeAvancoAcm; } set { el03FsmeAvancoAcm = value; } }
        public string El04FcesSigla { get { return el04FcesSigla; } set { el04FcesSigla = TruncateValue(value, 50); } }
        public DateTime El04FsmpData { get { return el04FsmpData; } set { el04FsmpData = value; } }
        public DateTime El04FsmeData { get { return el04FsmeData; } set { el04FsmeData = value; } }
        public decimal El04FsmeQtdAcm { get { return el04FsmeQtdAcm; } set { el04FsmeQtdAcm = value; } }
        public decimal El04FsmeAvancoAcm { get { return el04FsmeAvancoAcm; } set { el04FsmeAvancoAcm = value; } }
        public string El05FcesSigla { get { return el05FcesSigla; } set { el05FcesSigla = TruncateValue(value, 50); } }
        public DateTime El05FsmpData { get { return el05FsmpData; } set { el05FsmpData = value; } }
        public DateTime El05FsmeData { get { return el05FsmeData; } set { el05FsmeData = value; } }
        public decimal El05FsmeQtdAcm { get { return el05FsmeQtdAcm; } set { el05FsmeQtdAcm = value; } }
        public decimal El05FsmeAvancoAcm { get { return el05FsmeAvancoAcm; } set { el05FsmeAvancoAcm = value; } }
        public string El06FcesSigla { get { return el06FcesSigla; } set { el06FcesSigla = TruncateValue(value, 50); } }
        public DateTime El06FsmpData { get { return el06FsmpData; } set { el06FsmpData = value; } }
        public DateTime El06FsmeData { get { return el06FsmeData; } set { el06FsmeData = value; } }
        public decimal El06FsmeQtdAcm { get { return el06FsmeQtdAcm; } set { el06FsmeQtdAcm = value; } }
        public decimal El06FsmeAvancoAcm { get { return el06FsmeAvancoAcm; } set { el06FsmeAvancoAcm = value; } }
        public string El07FcesSigla { get { return el07FcesSigla; } set { el07FcesSigla = TruncateValue(value, 50); } }
        public DateTime El07FsmpData { get { return el07FsmpData; } set { el07FsmpData = value; } }
        public DateTime El07FsmeData { get { return el07FsmeData; } set { el07FsmeData = value; } }
        public decimal El07FsmeQtdAcm { get { return el07FsmeQtdAcm; } set { el07FsmeQtdAcm = value; } }
        public decimal El07FsmeAvancoAcm { get { return el07FsmeAvancoAcm; } set { el07FsmeAvancoAcm = value; } }
        public string El08FcesSigla { get { return el08FcesSigla; } set { el08FcesSigla = TruncateValue(value, 50); } }
        public DateTime El08FsmpData { get { return el08FsmpData; } set { el08FsmpData = value; } }
        public DateTime El08FsmeData { get { return el08FsmeData; } set { el08FsmeData = value; } }
        public decimal El08FsmeQtdAcm { get { return el08FsmeQtdAcm; } set { el08FsmeQtdAcm = value; } }
        public decimal El08FsmeAvancoAcm { get { return el08FsmeAvancoAcm; } set { el08FsmeAvancoAcm = value; } }
        public string El09FcesSigla { get { return el09FcesSigla; } set { el09FcesSigla = TruncateValue(value, 50); } }
        public DateTime El09FsmpData { get { return el09FsmpData; } set { el09FsmpData = value; } }
        public DateTime El09FsmeData { get { return el09FsmeData; } set { el09FsmeData = value; } }
        public decimal El09FsmeQtdAcm { get { return el09FsmeQtdAcm; } set { el09FsmeQtdAcm = value; } }
        public decimal El09FsmeAvancoAcm { get { return el09FsmeAvancoAcm; } set { el09FsmeAvancoAcm = value; } }
        public string El10FcesSigla { get { return el10FcesSigla; } set { el10FcesSigla = TruncateValue(value, 50); } }
        public DateTime El10FsmpData { get { return el10FsmpData; } set { el10FsmpData = value; } }
        public DateTime El10FsmeData { get { return el10FsmeData; } set { el10FsmeData = value; } }
        public decimal El10FsmeQtdAcm { get { return el10FsmeQtdAcm; } set { el10FsmeQtdAcm = value; } }
        public decimal El10FsmeAvancoAcm { get { return el10FsmeAvancoAcm; } set { el10FsmeAvancoAcm = value; } }
        public string El11FcesSigla { get { return el11FcesSigla; } set { el11FcesSigla = TruncateValue(value, 50); } }
        public DateTime El11FsmpData { get { return el11FsmpData; } set { el11FsmpData = value; } }
        public DateTime El11FsmeData { get { return el11FsmeData; } set { el11FsmeData = value; } }
        public decimal El11FsmeQtdAcm { get { return el11FsmeQtdAcm; } set { el11FsmeQtdAcm = value; } }
        public decimal El11FsmeAvancoAcm { get { return el11FsmeAvancoAcm; } set { el11FsmeAvancoAcm = value; } }
        public string El12FcesSigla { get { return el12FcesSigla; } set { el12FcesSigla = TruncateValue(value, 50); } }
        public DateTime El12FsmpData { get { return el12FsmpData; } set { el12FsmpData = value; } }
        public DateTime El12FsmeData { get { return el12FsmeData; } set { el12FsmeData = value; } }
        public decimal El12FsmeQtdAcm { get { return el12FsmeQtdAcm; } set { el12FsmeQtdAcm = value; } }
        public decimal El12FsmeAvancoAcm { get { return el12FsmeAvancoAcm; } set { el12FsmeAvancoAcm = value; } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public decimal AtivId { get { return ativId; } set { ativId = value; } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public decimal FosmId { get { return fosmId; } set { fosmId = value; } }
        public decimal FcmeId { get { return fcmeId; } set { fcmeId = value; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
    }
}
