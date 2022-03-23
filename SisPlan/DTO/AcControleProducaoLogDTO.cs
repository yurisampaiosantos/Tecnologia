using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcControleProducaoLogDTO : List<AcControleProducaoLogDTO> { }
    //====================================================================
    public class AcControleProducaoLogDTO : BaseDTO
    {
        private decimal id;
        private string foseCntrCodigo;
        private decimal semaId;
        private decimal discId;
        private string discNome;
        private decimal foseId;
        private string foseNumero;
        private string message;
        private string fcmeSigla;
        private string fcesSigla;
        private string grcrNome;
        private string grcrGrupoSigla;
        private decimal grcrFcmeId;
        private decimal grfcGrcrId;
        private decimal sbcnId;
        private string sbcnSigla;
        private string origemFabricacao;
        private string equipe;
        private string setor;
        private string localizacao;
        private string descricaoEstrutura;
        private decimal avnRealExecPeriodo;
        private DateTime createdDate;
        //====================================================================
        public enum attributeName { ID, FOSE_CNTR_CODIGO, SEMA_ID, DISC_ID, DISC_NOME, FOSE_ID, FOSE_NUMERO, MESSAGE, FCME_SIGLA, FCES_SIGLA, GRCR_NOME, GRCR_GRUPO_SIGLA, GRCR_FCME_ID, GRFC_GRCR_ID, SBCN_ID, SBCN_SIGLA, ORIGEM_FABRICACAO, EQUIPE, SETOR, LOCALIZACAO, DESCRICAO_ESTRUTURA, AVN_REAL_EXEC_PERIODO, CREATED_DATE };
        public enum propertyName { ID, FoseCntrCodigo, SemaId, DiscId, DiscNome, FoseId, FoseNumero, Message, FcmeSigla, FcesSigla, GrcrNome, GrcrGrupoSigla, GrcrFcmeId, GrfcGrcrId, SbcnId, SbcnSigla, OrigemFabricacao, Equipe, Setor, Localizacao, DescricaoEstrutura, AvnRealExecPeriodo, CreatedDate };
        //====================================================================
        private static int length = 23;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = TruncateValue(value, 30); } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
        public decimal DiscId { get { return discId; } set { discId = value; } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 30); } }
        public decimal FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 100); } }
        public string Message { get { return message; } set { message = TruncateValue(value, 500); } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 30); } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 30); } }
        public string GrcrNome { get { return grcrNome; } set { grcrNome = TruncateValue(value, 20); } }
        public string GrcrGrupoSigla { get { return grcrGrupoSigla; } set { grcrGrupoSigla = TruncateValue(value, 20); } }
        public decimal GrcrFcmeId { get { return grcrFcmeId; } set { grcrFcmeId = value; } }
        public decimal GrfcGrcrId { get { return grfcGrcrId; } set { grfcGrcrId = value; } }
        public decimal SbcnId { get { return sbcnId; } set { sbcnId = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public string OrigemFabricacao { get { return origemFabricacao; } set { origemFabricacao = TruncateValue(value, 20); } }
        public string Equipe { get { return equipe; } set { equipe = TruncateValue(value, 10); } }
        public string Setor { get { return setor; } set { setor = TruncateValue(value, 20); } }
        public string Localizacao { get { return localizacao; } set { localizacao = TruncateValue(value, 50); } }
        public string DescricaoEstrutura { get { return descricaoEstrutura; } set { descricaoEstrutura = TruncateValue(value, 100); } }
        public decimal AvnRealExecPeriodo { get { return avnRealExecPeriodo; } set { avnRealExecPeriodo = value; } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
    }
}
