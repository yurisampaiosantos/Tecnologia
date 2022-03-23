using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcMontagemTubulacaoDTO : List<AcMontagemTubulacaoDTO> { }
    //====================================================================
    public class AcMontagemTubulacaoDTO : BaseDTO
    {
        private decimal motuId;
        private string motuSbcnSigla;
        private string motuSpool;
        private string motuIsometrico;
        private string motuSifsDescricao;
        private string motuDesenho;
        private string motuPipeline;
        private decimal motuArea;
        private decimal motuPeso;
        private decimal motuComprimento;
        private string motuTstfUnidadeRegional;
        private string motuRegiao;
        private string motuSistema;
        private string motuSpec;
        private DateTime motuProgramadoFabricacao;
        private string motuFabricado;
        private string motuTratamento;
        private string motuTesteHidrostatico;
        private decimal motuStatusGalvanizado;
        private DateTime motuDataGalvanizado;
        private decimal motuStatusRevestimento;
        private DateTime motuDataRevestimento;
        private decimal motuPintura;
        private string motuDisponivelMontagem;
        private decimal motuFoseFabricacaoId;
        private decimal motuFoseMontagemId;
        private decimal motuFoseHidrostaticoId;
        private decimal motuFoseGalvanizacaoId;
        private decimal motuFoseRevestimentoId;
        private decimal motuFosePinturaId;

        //====================================================================
        public decimal MotuId { get { return motuId; } set { motuId = value; } }
        public string MotuSbcnSigla { get { return motuSbcnSigla; } set { motuSbcnSigla = TruncateValue(value, 10); } }
        public string MotuSpool { get { return motuSpool; } set { motuSpool = TruncateValue(value, 100); } }
        public string MotuIsometrico { get { return motuIsometrico; } set { motuIsometrico = TruncateValue(value, 10); } }
        public string MotuSifsDescricao { get { return motuSifsDescricao; } set { motuSifsDescricao = TruncateValue(value, 30); } }
        public string MotuDesenho { get { return motuDesenho; } set { motuDesenho = TruncateValue(value, 50); } }
        public string MotuPipeline { get { return motuPipeline; } set { motuPipeline = TruncateValue(value, 50); } }
        public decimal MotuArea { get { return motuArea; } set { motuArea = value; } }
        public decimal MotuPeso { get { return motuPeso; } set { motuPeso = value; } }
        public decimal MotuComprimento { get { return motuComprimento; } set { motuComprimento = value; } }
        public string MotuTstfUnidadeRegional { get { return motuTstfUnidadeRegional; } set { motuTstfUnidadeRegional = TruncateValue(value, 100); } }
        public string MotuRegiao { get { return motuRegiao; } set { motuRegiao = TruncateValue(value, 50); } }
        public string MotuSistema { get { return motuSistema; } set { motuSistema = TruncateValue(value, 10); } }
        public string MotuSpec { get { return motuSpec; } set { motuSpec = TruncateValue(value, 10); } }
        public DateTime MotuProgramadoFabricacao { get { return motuProgramadoFabricacao; } set { motuProgramadoFabricacao = value; } }
        public string MotuFabricado { get { return motuFabricado; } set { motuFabricado = TruncateValue(value, 1); } }
        public string MotuTratamento { get { return motuTratamento; } set { motuTratamento = TruncateValue(value, 20); } }
        public string MotuTesteHidrostatico { get { return motuTesteHidrostatico; } set { motuTesteHidrostatico = TruncateValue(value, 1); } }
        public decimal MotuStatusGalvanizado { get { return motuStatusGalvanizado; } set { motuStatusGalvanizado = value; } }
        public DateTime MotuDataGalvanizado { get { return motuDataGalvanizado; } set { motuDataGalvanizado = value; } }
        public decimal MotuStatusRevestimento { get { return motuStatusRevestimento; } set { motuStatusRevestimento = value; } }
        public DateTime MotuDataRevestimento { get { return motuDataRevestimento; } set { motuDataRevestimento = value; } }
        public decimal MotuPintura { get { return motuPintura; } set { motuPintura = value; } }
        public string MotuDisponivelMontagem { get { return motuDisponivelMontagem; } set { motuDisponivelMontagem = TruncateValue(value, 1); } }
        public decimal MotuFoseFabricacaoId { get { return motuFoseFabricacaoId; } set { motuFoseFabricacaoId = value; } }
        public decimal MotuFoseMontagemId { get { return motuFoseMontagemId; } set { motuFoseMontagemId = value; } }
        public decimal MotuFoseHidrostaticoId { get { return motuFoseHidrostaticoId; } set { motuFoseHidrostaticoId = value; } }
        public decimal MotuFoseGalvanizacaoId { get { return motuFoseGalvanizacaoId; } set { motuFoseGalvanizacaoId = value; } }
        public decimal MotuFoseRevestimentoId { get { return motuFoseRevestimentoId; } set { motuFoseRevestimentoId = value; } }
        public decimal MotuFosePinturaId { get { return motuFosePinturaId; } set { motuFosePinturaId = value; } }
    }
}
