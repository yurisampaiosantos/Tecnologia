using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionVwRmItemDTO : List<VwRmItemDTO> { }
    //====================================================================
    public class VwRmItemDTO : BaseDTO
    {
        private string dcmnNumero;
        private string dcmnTitulo;
        private string dipcCodigo;
        private string dipiDescricaoRes;
        private string dipiDescricaoCompl;
        private decimal afitItem;
        private decimal afitQtdTotal;
        private decimal aufoId;
        private string aufoNumero;
        private decimal aufoRev;
        private DateTime aufoDtEmissao;
        private DateTime aufoDtCadastro;
        private string dipqQtdRm;
        private string dipqQtdRmd;
        private string dipqQtdRmc;
        private string dipqQtdCp;
        private string dipqQtdAf;
        private string dipqQtdNf;
        private string dipqQtdNfd;
        private string dipqQtdDr;
        private string dipqQtdDrd;
        private string dipqQtdNe;
        private string dipqQtdNed;
        private string dipqQtdFs;
        private string dipqQtdEstoque;
        private decimal dipqQtdEstoqueCorrida;
        private string reprNumero;
        private string reprRev;
        private DateTime reprDtEmissao;
        private DateTime replNumero;
        private string diprCodigo;
        private string diprDim1;
        private string diprDim2;
        private string diprDim3;
        private string diprDimensoes;
        private string diprPeso;
        private DateTime diprDtCadastro;
        private string dipuCodigo;
        private string unmeSigla;
        private string unmeNome;
        private string emprNome;
        private string dipcDim1;
        private string dipcDim2;
        private string sbcnSigla;
        private string discSigla;
        private string discNome;
        private string unprSigla;
        private string unprNome;
        private string arapSigla;
        private string arapNome;
        private string dcprSigla;
        private string dcprNome;
        private string compNome;
        private string compFone1;
        private string compEmail;
        //====================================================================
        public enum attributeName { DCMN_NUMERO, DCMN_TITULO, DIPC_CODIGO, DIPI_DESCRICAO_RES, DIPI_DESCRICAO_COMPL, AFIT_ITEM, AFIT_QTD_TOTAL, AUFO_ID, AUFO_NUMERO, AUFO_REV, AUFO_DT_EMISSAO, AUFO_DT_CADASTRO, DIPQ_QTD_RM, DIPQ_QTD_RMD, DIPQ_QTD_RMC, DIPQ_QTD_CP, DIPQ_QTD_AF, DIPQ_QTD_NF, DIPQ_QTD_NFD, DIPQ_QTD_DR, DIPQ_QTD_DRD, DIPQ_QTD_NE, DIPQ_QTD_NED, DIPQ_QTD_FS, DIPQ_QTD_ESTOQUE, DIPQ_QTD_ESTOQUE_CORRIDA, REPR_NUMERO, REPR_REV, REPR_DT_EMISSAO, REPL_NUMERO, DIPR_CODIGO, DIPR_DIM1, DIPR_DIM2, DIPR_DIM3, DIPR_DIMENSOES, DIPR_PESO, DIPR_DT_CADASTRO, DIPU_CODIGO, UNME_SIGLA, UNME_NOME, EMPR_NOME, DIPC_DIM1, DIPC_DIM2, SBCN_SIGLA, DISC_SIGLA, DISC_NOME, UNPR_SIGLA, UNPR_NOME, ARAP_SIGLA, ARAP_NOME, DCPR_SIGLA, DCPR_NOME, COMP_NOME, COMP_FONE1, COMP_EMAIL };
        public enum propertyName { DcmnNumero, DcmnTitulo, DipcCodigo, DipiDescricaoRes, DipiDescricaoCompl, AfitItem, AfitQtdTotal, AufoId, AufoNumero, AufoRev, AufoDtEmissao, AufoDtCadastro, DipqQtdRm, DipqQtdRmd, DipqQtdRmc, DipqQtdCp, DipqQtdAf, DipqQtdNf, DipqQtdNfd, DipqQtdDr, DipqQtdDrd, DipqQtdNe, DipqQtdNed, DipqQtdFs, DipqQtdEstoque, DipqQtdEstoqueCorrida, ReprNumero, ReprRev, ReprDtEmissao, ReplNumero, DiprCodigo, DiprDim1, DiprDim2, DiprDim3, DiprDimensoes, DiprPeso, DiprDtCadastro, DipuCodigo, UnmeSigla, UnmeNome, EmprNome, DipcDim1, DipcDim2, SbcnSigla, DiscSigla, DiscNome, UnprSigla, UnprNome, ArapSigla, ArapNome, DcprSigla, DcprNome, CompNome, CompFone1, CompEmail };
        //====================================================================
        private static int length = 55;
        public static int Length { get { return length; } }
        //====================================================================
        public string DcmnNumero { get { return dcmnNumero; } set { dcmnNumero = TruncateValue(value, 200); } }
        public string DcmnTitulo { get { return dcmnTitulo; } set { dcmnTitulo = TruncateValue(value, 500); } }
        public string DipcCodigo { get { return dipcCodigo; } set { dipcCodigo = TruncateValue(value, 200); } }
        public string DipiDescricaoRes { get { return dipiDescricaoRes; } set { dipiDescricaoRes = TruncateValue(value, 500); } }
        public string DipiDescricaoCompl { get { return dipiDescricaoCompl; } set { dipiDescricaoCompl = TruncateValue(value, 4000); } }
        public decimal AfitItem { get { return afitItem; } set { afitItem = value; } }
        public decimal AfitQtdTotal { get { return afitQtdTotal; } set { afitQtdTotal = value; } }
        public decimal AufoId { get { return aufoId; } set { aufoId = value; } }
        public string AufoNumero { get { return aufoNumero; } set { aufoNumero = TruncateValue(value, 100); } }
        public decimal AufoRev { get { return aufoRev; } set { aufoRev = value; } }
        public DateTime AufoDtEmissao { get { return aufoDtEmissao; } set { aufoDtEmissao = value; } }
        public DateTime AufoDtCadastro { get { return aufoDtCadastro; } set { aufoDtCadastro = value; } }
        public string DipqQtdRm { get { return dipqQtdRm; } set { dipqQtdRm = TruncateValue(value, 22); } }
        public string DipqQtdRmd { get { return dipqQtdRmd; } set { dipqQtdRmd = TruncateValue(value, 22); } }
        public string DipqQtdRmc { get { return dipqQtdRmc; } set { dipqQtdRmc = TruncateValue(value, 22); } }
        public string DipqQtdCp { get { return dipqQtdCp; } set { dipqQtdCp = TruncateValue(value, 22); } }
        public string DipqQtdAf { get { return dipqQtdAf; } set { dipqQtdAf = TruncateValue(value, 22); } }
        public string DipqQtdNf { get { return dipqQtdNf; } set { dipqQtdNf = TruncateValue(value, 22); } }
        public string DipqQtdNfd { get { return dipqQtdNfd; } set { dipqQtdNfd = TruncateValue(value, 22); } }
        public string DipqQtdDr { get { return dipqQtdDr; } set { dipqQtdDr = TruncateValue(value, 22); } }
        public string DipqQtdDrd { get { return dipqQtdDrd; } set { dipqQtdDrd = TruncateValue(value, 22); } }
        public string DipqQtdNe { get { return dipqQtdNe; } set { dipqQtdNe = TruncateValue(value, 22); } }
        public string DipqQtdNed { get { return dipqQtdNed; } set { dipqQtdNed = TruncateValue(value, 22); } }
        public string DipqQtdFs { get { return dipqQtdFs; } set { dipqQtdFs = TruncateValue(value, 22); } }
        public string DipqQtdEstoque { get { return dipqQtdEstoque; } set { dipqQtdEstoque = TruncateValue(value, 22); } }
        public decimal DipqQtdEstoqueCorrida { get { return dipqQtdEstoqueCorrida; } set { dipqQtdEstoqueCorrida = value; } }
        public string ReprNumero { get { return reprNumero; } set { reprNumero = TruncateValue(value, 200); } }
        public string ReprRev { get { return reprRev; } set { reprRev = TruncateValue(value, 5); } }
        public DateTime ReprDtEmissao { get { return reprDtEmissao; } set { reprDtEmissao = value; } }
        public DateTime ReplNumero { get { return replNumero; } set { replNumero = value; } }
        public string DiprCodigo { get { return diprCodigo; } set { diprCodigo = TruncateValue(value, 200); } }
        public string DiprDim1 { get { return diprDim1; } set { diprDim1 = TruncateValue(value, 50); } }
        public string DiprDim2 { get { return diprDim2; } set { diprDim2 = TruncateValue(value, 50); } }
        public string DiprDim3 { get { return diprDim3; } set { diprDim3 = TruncateValue(value, 50); } }
        public string DiprDimensoes { get { return diprDimensoes; } set { diprDimensoes = TruncateValue(value, 186); } }
        public string DiprPeso { get { return diprPeso; } set { diprPeso = TruncateValue(value, 22); } }
        public DateTime DiprDtCadastro { get { return diprDtCadastro; } set { diprDtCadastro = value; } }
        public string DipuCodigo { get { return dipuCodigo; } set { dipuCodigo = TruncateValue(value, 200); } }
        public string UnmeSigla { get { return unmeSigla; } set { unmeSigla = TruncateValue(value, 10); } }
        public string UnmeNome { get { return unmeNome; } set { unmeNome = TruncateValue(value, 200); } }
        public string EmprNome { get { return emprNome; } set { emprNome = TruncateValue(value, 500); } }
        public string DipcDim1 { get { return dipcDim1; } set { dipcDim1 = TruncateValue(value, 50); } }
        public string DipcDim2 { get { return dipcDim2; } set { dipcDim2 = TruncateValue(value, 50); } }
        public string SbcnSigla { get { return sbcnSigla; } set { sbcnSigla = TruncateValue(value, 50); } }
        public string DiscSigla { get { return discSigla; } set { discSigla = TruncateValue(value, 256); } }
        public string DiscNome { get { return discNome; } set { discNome = TruncateValue(value, 256); } }
        public string UnprSigla { get { return unprSigla; } set { unprSigla = TruncateValue(value, 50); } }
        public string UnprNome { get { return unprNome; } set { unprNome = TruncateValue(value, 200); } }
        public string ArapSigla { get { return arapSigla; } set { arapSigla = TruncateValue(value, 50); } }
        public string ArapNome { get { return arapNome; } set { arapNome = TruncateValue(value, 200); } }
        public string DcprSigla { get { return dcprSigla; } set { dcprSigla = TruncateValue(value, 10); } }
        public string DcprNome { get { return dcprNome; } set { dcprNome = TruncateValue(value, 200); } }
        public string CompNome { get { return compNome; } set { compNome = TruncateValue(value, 200); } }
        public string CompFone1 { get { return compFone1; } set { compFone1 = TruncateValue(value, 50); } }
        public string CompEmail { get { return compEmail; } set { compEmail = TruncateValue(value, 500); } }
    }
}
