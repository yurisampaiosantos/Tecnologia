using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcAvnGrupoCriterioDTO : List<AcAvnGrupoCriterioDTO> { }
    //====================================================================
    public class AcAvnGrupoCriterioDTO : BaseDTO
    {
        private string avgcCntrCodigo;
        private decimal avgcId;
        private decimal avgcSemaId;
        private string avgcMes;
        private string avgcObra;
        private string avgcGrupoSigla;
        private string avgcGrcrNome;
        private string avgcGrcrGrupoDescricao;
        private decimal avgcPrevistoSemanal;
        private decimal avgcAvancoSemanalProg;
        private decimal avgcAvancoSemanalExec;
        private decimal avgcPrevistoMensal;
        private decimal avgcAvancoMensalProg;
        private decimal avgcAvancoMensalExec;
        private decimal avgcPrevistoAcumulado;
        private decimal avgcAvancoAcumuladoProg;
        private decimal avgcAvancoAcumuladoExec;
        //====================================================================
        public enum attributeName { AVGC_CNTR_CODIGO, AVGC_ID, AVGC_SEMANA_ID, AVGC_MES, AVGC_OBRA, AVGC_GRUPO_SIGLA, AVGC_GRCR_NOME, AVGC_GRCR_GRUPO_DESCRICAO, AVGC_PREVISTO_SEMANAL, AVGC_AVANCO_SEMANAL_PROG, AVGC_AVANCO_SEMANAL_EXEC, AVGC_PREVISTO_MENSAL, AVGC_AVANCO_MENSAL_PROG, AVGC_AVANCO_MENSAL_EXEC, AVGC_PREVISTO_ACUMULADO, AVGC_AVANCO_ACUMULADO_PROG, AVGC_AVANCO_ACUMULADO_EXEC };
        public enum propertyName { AvgcCntrCodigo, AvgcId, AvgcSemanaId, AvgcMes, AvgcObra, AvgcGrupoSigla, AvgcGrcrNome, AvgcGrcrGrupoDescricao, AvgcPrevistoSemanal, AvgcAvancoSemanalProg, AvgcAvancoSemanalExec, AvgcPrevistoMensal, AvgcAvancoMensalProg, AvgcAvancoMensalExec, AvgcPrevistoAcumulado, AvgcAvancoAcumuladoProg, AvgcAvancoAcumuladoExec };
        //====================================================================
        private static int length = 17;
        public static int Length { get { return length; } }
        //====================================================================
        public string AvgcCntrCodigo { get { return avgcCntrCodigo; } set { avgcCntrCodigo = TruncateValue(value, 20); } }
        public decimal AvgcId { get { return avgcId; } set { avgcId = value; } }
        public decimal AvgcSemaId { get { return avgcSemaId; } set { avgcSemaId = value; } }
        public string AvgcMes { get { return avgcMes; } set { avgcMes = TruncateValue(value, 7); } }
        public string AvgcObra { get { return avgcObra; } set { avgcObra = TruncateValue(value, 20); } }
        public string AvgcGrupoSigla { get { return avgcGrupoSigla; } set { avgcGrupoSigla = TruncateValue(value, 20); } }
        public string AvgcGrcrNome { get { return avgcGrcrNome; } set { avgcGrcrNome = TruncateValue(value, 50); } }
        public string AvgcGrcrGrupoDescricao { get { return avgcGrcrGrupoDescricao; } set { avgcGrcrGrupoDescricao = TruncateValue(value, 20); } }
        public decimal AvgcPrevistoSemanal { get { return avgcPrevistoSemanal; } set { avgcPrevistoSemanal = value; } }
        public decimal AvgcAvancoSemanalProg { get { return avgcAvancoSemanalProg; } set { avgcAvancoSemanalProg = value; } }
        public decimal AvgcAvancoSemanalExec { get { return avgcAvancoSemanalExec; } set { avgcAvancoSemanalExec = value; } }
        public decimal AvgcPrevistoMensal { get { return avgcPrevistoMensal; } set { avgcPrevistoMensal = value; } }
        public decimal AvgcAvancoMensalProg { get { return avgcAvancoMensalProg; } set { avgcAvancoMensalProg = value; } }
        public decimal AvgcAvancoMensalExec { get { return avgcAvancoMensalExec; } set { avgcAvancoMensalExec = value; } }
        public decimal AvgcPrevistoAcumulado { get { return avgcPrevistoAcumulado; } set { avgcPrevistoAcumulado = value; } }
        public decimal AvgcAvancoAcumuladoProg { get { return avgcAvancoAcumuladoProg; } set { avgcAvancoAcumuladoProg = value; } }
        public decimal AvgcAvancoAcumuladoExec { get { return avgcAvancoAcumuladoExec; } set { avgcAvancoAcumuladoExec = value; } }
    }
}
