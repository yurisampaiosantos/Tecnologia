using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcPendenciaFolhaServicoDTO : List<AcPendenciaFolhaServicoDTO> { }
    //====================================================================
    public class AcPendenciaFolhaServicoDTO : BaseDTO
    {
        private decimal id;
        private string sbcnSigla;
        private string discNome;
        private string foseNumero;
        private string dipcCodigo;
        private string dipiDescricaoRes;
        private decimal dipqQtdRm;
        private decimal fsitQtdReal;
        private string dcmnNumero;
        private string status;
        private DateTime createdDate;
        //====================================================================
        public enum attributeName { ID, SBCN_SIGLA, DISC_NOME, FOSE_NUMERO, DIPC_CODIGO, DIPI_DESCRICAO_RES, DIPQ_QTD_RM, FSIT_QTD_REAL, DCMN_NUMERO, STATUS, CREATED_DATE };
        public enum propertyName { ID, SbcnSigla, DiscNome, FoseNumero, DipcCodigo, DipiDescricaoRes, DipqQtdRm, FsitQtdReal, DcmnNumero, Status, CreatedDate };
        //====================================================================
        private static int length = 11;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 100); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 100); } }
        public string FoseNumero { get { return foseNumero; } set { foseNumero = TruncateValue(value, 100); } }
        public string DipcCodigo { get { return dipcCodigo; } set { dipcCodigo = TruncateValue(value, 200); } }
        public string DipiDescricaoRes { get { return dipiDescricaoRes; } set { dipiDescricaoRes = TruncateValue(value, 500); } }
        public decimal DipqQtdRm { get { return dipqQtdRm; } set { dipqQtdRm = value; } }
        public decimal FsitQtdReal { get { return fsitQtdReal; } set { fsitQtdReal = value; } }
        public string DcmnNumero { get { return dcmnNumero; } set { dcmnNumero = TruncateValue(value, 100); } }
        public string Status { get { return status; } set { status = TruncateValue(value, 2); } }
        public DateTime CreatedDate { get { return createdDate; } set { createdDate = value; } }
    }
}
