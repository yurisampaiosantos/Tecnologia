using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwAvnFoseEletricaDTO : List<VwAvnFoseEletricaDTO> { }
    //====================================================================
    public class VwAvnFoseEletricaDTO : BaseDTO
    {
        private string discNome;
        private string ativSig;
        private string sbcnNome;
        private string unprSigla;
        private string unprNome;
        private string arapSigla;
        private string arapNome;
        private string foseNumero;
        private string foseQtdPrevista;
        private string foseQtdRealizada;
        private string unmeNome;
        private string sifsDescricao;
        private string pasta;
        private string desenho;
        private string tipo;
        private string setor;
        private string fcesSigla;
        private string fcesWbs;
        private DateTime fsmpData;
        private decimal fsmpAvancoAcm;
        private decimal fsmpQtdAcm;
        private DateTime fsmpDtCadastro;
        private DateTime fsmeData;
        private decimal fsmeAvancoAcm;
        private decimal fsmeQtdAcm;
        private DateTime fsmeDtCadastro;
        private decimal fosmId;
        private decimal fosmFcesId;
        private string foseCntrCodigo;
        private decimal foseSbcnId;
        private decimal foseUnprId;
        private decimal foseArapId;
        private decimal foseDiscId;
        private decimal discId;
        private decimal foseId;
        private decimal foseSifsId;
        private decimal foseUnmeId;
        private decimal fcesFcmeId;
        private string fcmeSigla;
        private decimal fcesNivel;
        private string fcesPesoRelCron;

        //====================================================================
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 200); } }
        public string AtivSig { get { return ativSig; } set { ativSig = TruncateValue(value, 100); } }
        public string SbcnNome { get { return sbcnNome; } set { sbcnNome = TruncateValue(value, 200); } }
        public string UnprSigla { get { return unprSigla; } set { unprSigla = TruncateValue(value, 50); } }
        public string UnprNome { get { return unprNome; } set { unprNome = TruncateValue(value, 200); } }
        public string ArapSigla { get { return arapSigla; } set { arapSigla = TruncateValue(value, 50); } }
        public string ArapNome { get { return arapNome; } set { arapNome = TruncateValue(value, 200); } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 200); } }
        public string FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = TruncateValue(value, 22); } }
        public string FoseQtdRealizada { get { return foseQtdRealizada; } set { foseQtdRealizada = TruncateValue(value, 22); } }
        public string UnmeNome { get { return unmeNome; } set { unmeNome = TruncateValue(value, 200); } }
        public string SifsDescricao { get { return sifsDescricao; } set { sifsDescricao = TruncateValue(value, 30); } }
        public string Pasta { get { return pasta; } set { pasta = TruncateValue(value, 30); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 100); } }
        public string Tipo { get { return tipo; } set { tipo = TruncateValue(value, 50); } }
        public string Setor { get { return setor; } set { setor = TruncateValue(value, 20); } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 50); } }
        public string FcesWbs { get { return fcesWbs; } set { fcesWbs = TruncateValue(value, 2000); } }
        public DateTime FsmpData { get { return fsmpData; } set { fsmpData = value; } }
        public decimal FsmpAvancoAcm { get { return fsmpAvancoAcm; } set { fsmpAvancoAcm = value; } }
        public decimal FsmpQtdAcm { get { return fsmpQtdAcm; } set { fsmpQtdAcm = value; } }
        public DateTime FsmpDtCadastro { get { return fsmpDtCadastro; } set { fsmpDtCadastro = value; } }
        public DateTime FsmeData { get { return fsmeData; } set { fsmeData = value; } }
        public decimal FsmeAvancoAcm { get { return fsmeAvancoAcm; } set { fsmeAvancoAcm = value; } }
        public decimal FsmeQtdAcm { get { return fsmeQtdAcm; } set { fsmeQtdAcm = value; } }
        public DateTime FsmeDtCadastro { get { return fsmeDtCadastro; } set { fsmeDtCadastro = value; } }
        public decimal FosmId { get { return fosmId; } set { fosmId = value; } }
        public decimal FosmFcesId { get { return fosmFcesId; } set { fosmFcesId = value; } }
        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = TruncateValue(value, 10); } }
        public decimal FoseSbcnId { get { return foseSbcnId; } set { foseSbcnId = value; } }
        public decimal FoseUnprId { get { return foseUnprId; } set { foseUnprId = value; } }
        public decimal FoseArapId { get { return foseArapId; } set { foseArapId = value; } }
        public decimal FoseDiscId { get { return foseDiscId; } set { foseDiscId = value; } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public decimal FoseSifsId { get { return foseSifsId; } set { foseSifsId = value; } }
        public decimal FoseUnmeId { get { return foseUnmeId; } set { foseUnmeId = value; } }
        public decimal FcesFcmeId { get { return fcesFcmeId; } set { fcesFcmeId = value; } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 50); } }
        public decimal FcesNivel { get { return fcesNivel; } set { fcesNivel = value; } }
        public string FcesPesoRelCron { get { return fcesPesoRelCron; } set { fcesPesoRelCron = TruncateValue(value, 22); } }
    }
}
