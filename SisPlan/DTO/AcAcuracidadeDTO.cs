using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcAcuracidadeDTO : List<AcAcuracidadeDTO> { }
    //====================================================================
    public class AcAcuracidadeDTO : BaseDTO
    {
        private decimal acurId;
        private string acurSbcnSigla;
        private decimal acurDiscId;
        private string acurDiscNome;
        private decimal acurFcmeId;
        private string acurFcmeSigla;
        private decimal acurFcesId;
        private string acurFcesSigla;
        private string acurFcesWbs;
        private decimal acurFoseId;
        private string acurFoseNumero;
        private string acurAtivSig;
        private string acurAtivNome;
        private string acurUnmeSigla;
        private string acurTstfUnidadeRegional;
        private string acurRegiao;
        private string acurLocalizacao;
        private string acurEquipe;
        private decimal acurQtdPrevista;
        private decimal acurFcesPesoRelCron;

        private decimal? acurFsmpFosmId;
        private DateTime? acurMaxFsmpData;
        private decimal? acurFsmpAvancoAcm;
        private decimal? acurQtdProg;
        private decimal? acurQtdAvancoProgPond;

        private decimal? acurFsmeFosmId;
        private DateTime? acurMaxFsmeData;
        private decimal? acurFsmeAvancoAcm;
        private decimal? acurQtdExec;
        private decimal? acurQtdAvancoExecPond;
        private DateTime? acurCreatedDate;

        //====================================================================
        public decimal AcurId { get { return acurId; } set { acurId = value; } }
        public string AcurSbcnSigla { get { return acurSbcnSigla; } set { acurSbcnSigla = TruncateValue(value, 10); } }
        public decimal AcurDiscId { get { return acurDiscId; } set { acurDiscId = value; } }
        public string AcurDiscNome { get { return acurDiscNome; } set { acurDiscNome = TruncateValue(value, 50); } }
        public decimal AcurFcmeId { get { return acurFcmeId; } set { acurFcmeId = value; } }
        public string AcurFcmeSigla { get { return acurFcmeSigla; } set { acurFcmeSigla = TruncateValue(value, 50); } }
        public decimal AcurFcesId { get { return acurFcesId; } set { acurFcesId = value; } }
        public string AcurFcesSigla { get { return acurFcesSigla; } set { acurFcesSigla = TruncateValue(value, 20); } }
        public string AcurFcesWbs { get { return acurFcesWbs; } set { acurFcesWbs = TruncateValue(value, 20); } }
        public decimal AcurFoseId { get { return acurFoseId; } set { acurFoseId = value; } }
        public string AcurFoseNumero { get { return acurFoseNumero; } set { acurFoseNumero = TruncateValue(value, 200); } }
        public string AcurAtivSig { get { return acurAtivSig; } set { acurAtivSig = TruncateValue(value, 100); } }
        public string AcurAtivNome { get { return acurAtivNome; } set { acurAtivNome = TruncateValue(value, 100); } }
        public string AcurUnmeSigla { get { return acurUnmeSigla; } set { acurUnmeSigla = TruncateValue(value, 20); } }
        public string AcurTstfUnidadeRegional { get { return acurTstfUnidadeRegional; } set { acurTstfUnidadeRegional = TruncateValue(value, 100); } }
        public string AcurRegiao { get { return acurRegiao; } set { acurRegiao = TruncateValue(value, 50); } }
        public string AcurLocalizacao { get { return acurLocalizacao; } set { acurLocalizacao = TruncateValue(value, 50); } }
        public string AcurEquipe { get { return acurEquipe; } set { acurEquipe = TruncateValue(value, 10); } }
        public decimal AcurQtdPrevista { get { return acurQtdPrevista; } set { acurQtdPrevista = value; } }
        public decimal AcurFcesPesoRelCron { get { return acurFcesPesoRelCron; } set { acurFcesPesoRelCron = value; } }

        public decimal? AcurFsmpFosmId { get { return acurFsmpFosmId; } set { acurFsmpFosmId = value; } }
        public DateTime? AcurMaxFsmpData { get { return acurMaxFsmpData; } set { acurMaxFsmpData = value; } }
        public decimal? AcurFsmpAvancoAcm { get { return acurFsmpAvancoAcm; } set { acurFsmpAvancoAcm = value; } }
        public decimal? AcurQtdProg { get { return acurQtdProg; } set { acurQtdProg = value; } }
        public decimal? AcurQtdAvancoProgPond { get { return acurQtdAvancoProgPond; } set { acurQtdAvancoProgPond = value; } }

        public decimal? AcurFsmeFosmId { get { return acurFsmeFosmId; } set { acurFsmeFosmId = value; } }
        public DateTime? AcurMaxFsmeData { get { return acurMaxFsmeData; } set { acurMaxFsmeData = value; } }
        public decimal? AcurFsmeAvancoAcm { get { return acurFsmeAvancoAcm; } set { acurFsmeAvancoAcm = value; } }
        public decimal? AcurQtdExec { get { return acurQtdExec; } set { acurQtdExec = value; } }
        public decimal? AcurQtdAvancoExecPond { get { return acurQtdAvancoExecPond; } set { acurQtdAvancoExecPond = value; } }
        public DateTime? AcurCreatedDate { get { return acurCreatedDate; } set { acurCreatedDate = value; } }
    }
}
