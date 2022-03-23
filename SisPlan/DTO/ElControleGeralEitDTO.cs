using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionElControleGeralEitDTO : List<ElControleGeralEitDTO> { }
    //====================================================================
    public class ElControleGeralEitDTO : BaseDTO
    {
        private decimal id;
        private string contrato;
        private string sbcnSigla;
        private string classeDisciplina;
        private string criterio;
        private string eap;
        private string atividadeCriterio;
        private string tipoMaterial;
        private string statusEngenharia;
        private string desenho;
        private string desenhoRev;
        private string regiao;
        private string local;
        private string tag;
        private string descricao;
        private decimal? quantidadeProjeto;
        private string unmeSigla;
        private decimal? avancoFisico;
        private string semana;
        private string diprCodigo;
        private string reserva;
        private DateTime? blProjectStart;
        private DateTime? blProjectFinish;
        private string pastaCodigo;
        private string ssop;
        private string fase;
        private string bloco;
        private string desReferencia;
        private string rm;
        private string rmRev;
        private string afs;
        private DateTime? dataNecessaria;
        private string statusChegada;
        private decimal indice;
        private decimal fotaId;
        private decimal? produtividade;

        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string Contrato { get { return contrato; } set { contrato = TruncateValue(value, 50); } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public string ClasseDisciplina { get { return classeDisciplina; } set { classeDisciplina = TruncateValue(value, 20); } }
        public string Criterio { get { return criterio; } set { criterio = TruncateValue(value, 100); } }
        public string Eap { get { return eap; } set { eap = TruncateValue(value, 100); } }
        public string AtividadeCriterio { get { return atividadeCriterio; } set { atividadeCriterio = TruncateValue(value, 100); } }
        public string TipoMaterial { get { return tipoMaterial; } set { tipoMaterial = TruncateValue(value, 200); } }
        public string StatusEngenharia { get { return statusEngenharia; } set { statusEngenharia = TruncateValue(value, 20); } }
        public string Desenho { get { return desenho; } set { desenho = TruncateValue(value, 100); } }
        public string DesenhoRev { get { return desenhoRev; } set { desenhoRev = TruncateValue(value, 10); } }
        public string Regiao { get { return regiao; } set { regiao = TruncateValue(value, 100); } }
        public string Local { get { return local; } set { local = TruncateValue(value, 50); } }
        public string Tag { get { return tag; } set { tag = TruncateValue(value, 200); } }
        public string Descricao { get { return descricao; } set { descricao = TruncateValue(value, 500); } }
        public decimal? QuantidadeProjeto { get { return quantidadeProjeto; } set { quantidadeProjeto = value; } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 10); } }
        public decimal? AvancoFisico { get { return avancoFisico; } set { avancoFisico = value; } }
        public string Semana { get { return semana; } set { semana = TruncateValue(value, 20); } }
        public string DiprCodigo { get { return diprCodigo; } set { diprCodigo = TruncateValue(value, 100); } }
        public string Reserva { get { return reserva; } set { reserva = TruncateValue(value, 50); } }
        public DateTime? BlProjectStart { get { return blProjectStart; } set { blProjectStart = value; } }
        public DateTime? BlProjectFinish { get { return blProjectFinish; } set { blProjectFinish = value; } }
        public string PastaCodigo { get { return pastaCodigo; } set { pastaCodigo = TruncateValue(value, 50); } }
        public string Ssop { get { return ssop; } set { ssop = TruncateValue(value, 10); } }
        public string Fase { get { return fase; } set { fase = TruncateValue(value, 10); } }
        public string Bloco { get { return bloco; } set { bloco = TruncateValue(value, 20); } }
        public string DesReferencia { get { return desReferencia; } set { desReferencia = TruncateValue(value, 100); } }
        public string RM { get { return rm; } set { rm = TruncateValue(value, 100); } }
        public string RmRev { get { return rmRev; } set { rmRev = TruncateValue(value, 10); } }
        public string Afs { get { return afs; } set { afs = TruncateValue(value, 200); } }
        public DateTime? DataNecessaria { get { return dataNecessaria; } set { dataNecessaria = value; } }
        public string StatusChegada { get { return statusChegada; } set { statusChegada = TruncateValue(value, 50); } }
        public decimal Indice { get { return indice; } set { indice = value; } }
        public decimal FotaId { get { return fotaId; } set { fotaId = value; } }
        public decimal? Produtividade { get { return produtividade; } set { produtividade = value; } }
    }
}
