using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcAvnCriterioDTO : List<AcAvnCriterioDTO> { }
    //====================================================================
    public class AcAvnCriterioDTO : BaseDTO
    {
        private decimal id;
        private string grcrCntrCodigo;
        private decimal grcrId;
        private decimal semaId;
        private string grcrGrupoSigla;
        private string grcrNome;
        private string grcrGrupoDescricao;
        private decimal grcrSequence;
        private decimal fcmeId;
        private string fcmeSigla;
        private decimal fcesId;
        private string fcesSigla;
        private decimal fcesPesoRelCron;
        private int foseId;
        private string foseNumero;
        private int fosmId;
        private string avancoTipo;
        private string avancoPeriodo;
        private decimal foseQtdPrevista;
        private DateTime avancoData;
        private decimal qtdAvanco;
        //====================================================================
        public enum attributeName { ID, GRCR_CNTR_CODIGO, GRCR_ID, SEMA_ID, GRCR_GRUPO_SIGLA, GRCR_NOME, GRCR_GRUPO_DESCRICAO, GRCR_SEQUENCE, FCME_ID, FCME_SIGLA, FCES_ID, FCES_SIGLA, FCES_PESO_REL_CRON, FOSE_ID, FOSE_NUMERO, FOSM_ID, AVANCO_TIPO, AVANCO_PERIODO, FOSE_QTD_PREVISTA, AVANCO_DATA, QTD_AVANCO };
        public enum propertyName { ID, GrcrCntrCodigo, GrcrId, SemaId, GrcrGrupoSigla, GrcrNome, GrcrGrupoDescricao, GrcrSequence, FcmeId, FcmeSigla, FcesId, FcesSigla, FcesPesoRelCron, FoseId, FoseNumero, FosmId, AvancoTipo, AvancoPeriodo, FoseQtdPrevista, AvancoData, QtdAvanco };
        //====================================================================
        private static int length = 21;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string GrcrCntrCodigo { get { return grcrCntrCodigo; } set { grcrCntrCodigo = TruncateValue(value, 20); } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
        public decimal GrcrId { get { return grcrId; } set { grcrId = value; } }
        public string GrcrGrupoSigla { get { return grcrGrupoSigla; } set { grcrGrupoSigla = TruncateValue(value, 20); } }
        public string GrcrNome { get { return grcrNome; } set { grcrNome = TruncateValue(value, 50); } }
        public string GrcrGrupoDescricao { get { return grcrGrupoDescricao; } set { grcrGrupoDescricao = TruncateValue(value, 20); } }
        public decimal GrcrSequence { get { return grcrSequence; } set { grcrSequence = value; } }
        public decimal FcmeId { get { return fcmeId; } set { fcmeId = value; } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 30); } }
        public decimal FcesId { get { return fcesId; } set { fcesId = value; } }
        public string FcesSigla { get { return fcesSigla; } set { fcesSigla = TruncateValue(value, 30); } }
        public decimal FcesPesoRelCron { get { return fcesPesoRelCron; } set { fcesPesoRelCron = value; } }
        public int FoseId { get { return foseId; } set { foseId = value; } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 50); } }
        public int FosmId { get { return fosmId; } set { fosmId = value; } }
        public string AvancoTipo { get { return avancoTipo; } set { avancoTipo = TruncateValue(value, 1); } }
        public string AvancoPeriodo { get { return avancoPeriodo; } set { avancoPeriodo = TruncateValue(value, 1); } }
        public decimal FoseQtdPrevista { get { return foseQtdPrevista; } set { foseQtdPrevista = value; } }
        public DateTime AvancoData { get { return avancoData; } set { avancoData = value; } }
        public decimal QtdAvanco { get { return qtdAvanco; } set { qtdAvanco = value; } }
    }
}
