using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcControleFolhaServicoDTO : List<AcControleFolhaServicoDTO> { }
    //====================================================================
    public class AcControleFolhaServicoDTO : BaseDTO
    {
        private string foseCntrCodigo;
        private decimal sbcnId;
        private string sbcnSigla;
        private decimal discId;
        private string discNome;
        private decimal foseId;
        private string foseNumero;
        private string foseRev;
        private string foseDescricao;
        private string unmeSigla;
        private string fcmeSigla;
        private string fcesSigla;
        private string equipe;
        private string setor;
        private string localizacao;
        private string classificado;
        private string desenho;
        private string origemFabricacao;
        private string areaPintura;
        private decimal foseComprimento;
        private string descricaoEstrutura;
        private string diam;
        private string empresaResponsavel;
        private string nota;
        private string regiao;
        private string semanaFolha;
        private string sistema;
        private string spec;
        private string tratamento;
        private string indefinido;
        private decimal foseQtdPrevista;
        private decimal qtdAcumulada;
        private string sifsDescricao;
        private string foseStatus;
        private DateTime lastUpdate;

        private string statusTratamento;
        private DateTime dtStatusTratamento;
        private string localEstocagem;
        private DateTime maxFsmeData;
        private string tstfUnidadeRegional;
        private string programacao;
        //====================================================================
        
        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = TruncateValue(value, 30); } }
        public decimal SbcnId { get { return sbcnId; } set { sbcnId = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 100); } }
        public string FoseRev { get { return foseRev; } set { foseRev = TruncateValue(value, 10); } }
        public string FoseDescricao { get { return foseDescricao; } set { foseDescricao = TruncateValue(value, 500); } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 20); } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 30); } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 30); } }
        public string Equipe { get { return equipe; } set { equipe = TruncateValue(value, 10); } }
        public string Setor { get { return setor; } set { setor = TruncateValue(value, 20); } }
        public string Localizacao { get { return localizacao; } set { localizacao = TruncateValue(value, 50); } }
        public string Classificado { get { return classificado; } set { classificado = TruncateValue(value, 100); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 50); } }
        public string OrigemFabricacao { get { return origemFabricacao; } set { origemFabricacao = TruncateValue(value, 20); } }
        public string AreaPintura { get { return areaPintura; } set { areaPintura = TruncateValue(value, 100); } }
        public decimal FoseComprimento { get { return foseComprimento; } set { foseComprimento = value; } }
        public string DescricaoEstrutura { get { return descricaoEstrutura; } set { descricaoEstrutura = TruncateValue(value, 100); } }
        public string Diam { get { return diam; } set { diam = TruncateValue(value, 100); } }
        public string EmpresaResponsavel { get { return empresaResponsavel; } set { empresaResponsavel = TruncateValue(value, 100); } }
        public string Nota { get { return nota; } set { nota = TruncateValue(value, 100); } }
        public string Regiao { get { return regiao; } set { regiao = TruncateValue(value, 100); } }
        public string SemanaFolha { get { return semanaFolha; } set { semanaFolha = TruncateValue(value, 100); } }
        public string Sistema { get { return sistema; } set { sistema = TruncateValue(value, 100); } }
        public string Spec { get { return spec; } set { spec = TruncateValue(value, 100); } }
        public string Tratamento { get { return tratamento; } set { tratamento = TruncateValue(value, 100); } }
        public string Indefinido { get { return indefinido; } set { indefinido = TruncateValue(value, 200); } }
        public decimal FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public decimal QtdAcumulada { get { return qtdAcumulada; } set { qtdAcumulada = value; } }
        public string SifsDescricao { get { return sifsDescricao; } set { sifsDescricao = TruncateValue(value, 50); } }
        public string FoseStatus { get { return foseStatus; } set { foseStatus = TruncateValue(value, 50); } }
        public DateTime LastUpdate { get { return lastUpdate; } set { lastUpdate = value; } }

        public string StatusTratamento { get { return statusTratamento; } set { statusTratamento = TruncateValue(value, 50); } }
        public DateTime DtStatusTratamento { get { return dtStatusTratamento; } set { dtStatusTratamento = value; } }
        public string LocalEstocagem { get { return localEstocagem; } set { localEstocagem = TruncateValue(value, 50); } }
        public DateTime MaxFsmeData { get { return maxFsmeData; } set { maxFsmeData = value; } }
        public string TstfUnidadeRegional { get { return tstfUnidadeRegional; } set { tstfUnidadeRegional = TruncateValue(value, 100); } }
        public string Programacao { get { return programacao; } set { programacao = TruncateValue(value, 50); } }

    }
}
