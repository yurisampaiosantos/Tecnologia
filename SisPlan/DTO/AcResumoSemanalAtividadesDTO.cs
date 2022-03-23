using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcResumoSemanalAtividadesDTO : List<AcResumoSemanalAtividadesDTO> { }
    //====================================================================
    public class AcResumoSemanalAtividadesDTO : BaseDTO
    {
        private string foseCntrCodigo;
        private string sbcnSigla;
        private decimal semaId;
        private string sumaAtivSig;
        private string fcmeSigla;
        private decimal avnPondExecPeriodo;
        private decimal avnRealExecPeriodo;
        private decimal avnPondProgPeriodo;
        private decimal avnRealProgPeriodo;
        private decimal fcesPesoRelCron;
        private decimal pondCriterio;

        //====================================================================

        public string FoseCntrCodigo { get { return foseCntrCodigo; } set { foseCntrCodigo = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 10); } }
        public decimal SemaId { get { return semaId; } set { semaId = value; } }
        public string SumaAtivSig { get { return sumaAtivSig; } set { sumaAtivSig = TruncateValue(value, 100); } }
        public string FcmeSigla { get { return fcmeSigla; } set { fcmeSigla = TruncateValue(value, 30); } }
        public decimal AvnPondExecPeriodo { get { return avnPondExecPeriodo; } set { avnPondExecPeriodo = value; } }
        public decimal AvnRealExecPeriodo { get { return avnRealExecPeriodo; } set { avnRealExecPeriodo = value; } }
        public decimal AvnPondProgPeriodo { get { return avnPondProgPeriodo; } set { avnPondProgPeriodo = value; } }
        public decimal AvnRealProgPeriodo { get { return avnRealProgPeriodo; } set { avnRealProgPeriodo = value; } }
        public decimal FcesPesoRelCron { get { return fcesPesoRelCron; } set { fcesPesoRelCron = value; } }
        public decimal PondCriterio { get { return pondCriterio; } set { pondCriterio = value; } }
    }
}
