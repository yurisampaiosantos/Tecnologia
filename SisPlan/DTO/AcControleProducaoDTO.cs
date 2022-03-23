using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcControleProducaoDTO : List<AcControleProducaoDTO> { }
    //====================================================================
    public class AcControleProducaoDTO : BaseDTO
    {
        private decimal id;
        private string foseCntrCodigo;
        private decimal semaId;
        private string mesCompetencia;
        private string anoCompetencia;
        private decimal sbcnId;
        private string sbcnSigla;
        private decimal discId;
        private string discNome;
        private decimal foseId;
        private string foseNumero;
        private string foseDescricao;
        private string unmeSigla ;
        private string foseStatus;
        private string sifsDescricao;
        private string fcmeSigla;
        private string sumaAtivSig;
        private string grcrNome;
        private string fcesSigla;
        private string foseQtdPrevista;
        private string qtdAcumulada; // tela de avanço no SISEPC
        private decimal foseComprimento;
        private decimal fcesPesoRelCron;
        private DateTime fsmeData;
        private string avnPondExecPeriodo;  //fsmeQtdAvnPond;
        private string avnRealExecPeriodo;
        private DateTime fsmpData;
        private string avnPondProgPeriodo;  //fsmpQtdAvnPond;
        private string avnRealProgPeriodo;
        private string equipe;
        private string setor;
        private string localizacao;
        private string desenho;
        private string origemFabricacao;
        private string areaPintura;
        private string classificado;
        private string descricaoEstrutura;
        private string itemControle;
        private string diam;
        private string empresaResponsavel;
        private string nota;
        private string regiao;
        private string semanaFolha;
        private string sistema;
        private string spec;
        private string tratamento;
        private string indefinido;
        private decimal? zonaId;
        private string responsavel;
        private string pastaCodigo;



        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = value; } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
        public string MesCompetencia { get { return mesCompetencia; } set { mesCompetencia = value; } }
        public string AnoCompetencia { get { return anoCompetencia; } set { anoCompetencia = value; } }
        public decimal SbcnId { get { return sbcnId; } set { sbcnId = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 200); } }
        public string FoseDescricao { get { return foseDescricao; } set { foseDescricao = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = value; } }
        public string FoseStatus { get { return foseStatus; } set { foseStatus = value; } }
        public string SifsDescricao { get { return sifsDescricao; } set { sifsDescricao = value; } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 30); } }
        public string SumaAtivSig { get { return sumaAtivSig; } set { sumaAtivSig = TruncateValue(value, 100); } }
        public string GrcrNome { get { return grcrNome; } set { grcrNome = TruncateValue(value, 20); } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 30); } }
        public string FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public string QtdAcumulada { get { return qtdAcumulada; } set { qtdAcumulada = value; } }
        public decimal FoseComprimento { get { return foseComprimento; } set { foseComprimento = value; } }
        public decimal FcesPesoRelCron { get { return fcesPesoRelCron; } set { fcesPesoRelCron = value; } }
        public DateTime FsmeData { get { return fsmeData; } set { fsmeData = value; } }
        public string AvnPondExecPeriodo { get { return avnPondExecPeriodo; } set { avnPondExecPeriodo = value; } }
        public string AvnRealExecPeriodo { get { return avnRealExecPeriodo; } set { avnRealExecPeriodo = value; } }
        public DateTime FsmpData { get { return fsmpData; } set { fsmpData = value; } }
        public string AvnPondProgPeriodo { get { return avnPondProgPeriodo; } set { avnPondProgPeriodo = value; } }
        public string AvnRealProgPeriodo { get { return avnRealProgPeriodo; } set { avnRealProgPeriodo = value; } }
        public string Equipe { get { return equipe; } set { equipe = TruncateValue(value, 10); } }
        public string Setor { get { return setor; } set { setor = TruncateValue(value, 20); } }
        public string Localizacao { get { return localizacao; } set { localizacao = TruncateValue(value, 50); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 50); } }
        public string OrigemFabricacao { get { return origemFabricacao; } set { origemFabricacao = TruncateValue(value, 20); } }
        public string AreaPintura { get { return areaPintura; } set { areaPintura = TruncateValue(value, 100); } }
        public string Classificado { get { return classificado; } set { classificado = TruncateValue(value, 100); } }
        public string DescricaoEstrutura { get { return descricaoEstrutura; } set { descricaoEstrutura = TruncateValue(value, 200); } }
        public string ItemControle { get { return itemControle; } set { itemControle = TruncateValue(value, 40); } }
        public string Diam { get { return diam; } set { diam = TruncateValue(value, 100); } }
        public string EmpresaResponsavel { get { return empresaResponsavel; } set { empresaResponsavel = TruncateValue(value, 100); } }
        public string Nota { get { return nota; } set { nota = TruncateValue(value, 100); } }
        public string Regiao { get { return regiao; } set { regiao = TruncateValue(value, 100); } }
        public string SemanaFolha { get { return semanaFolha; } set { semanaFolha = TruncateValue(value, 100); } }
        public string Sistema { get { return sistema; } set { sistema = TruncateValue(value, 100); } }
        public string Spec { get { return spec; } set { spec = TruncateValue(value, 100); } }
        public string Tratamento { get { return tratamento; } set { tratamento = TruncateValue(value, 100); } }
        public string Indefinido { get { return indefinido; } set { indefinido = TruncateValue(value, 100); } }
        public decimal? ZonaId { get { return zonaId; } set { zonaId = value; } }
        public string Responsavel { get { return responsavel; } set { responsavel = TruncateValue(value, 20); } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
    }
}
