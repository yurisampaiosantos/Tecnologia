using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcGrupoCriterioDTO : List<AcGrupoCriterioDTO> { }
    //====================================================================
    public class AcGrupoCriterioDTO : BaseDTO
    {
        private string grcrCntrCodigo;
        private decimal grcrId;
        private string grcrGrupoSigla;
        private string grcrNome;
        private decimal grcrSequence;
        private string grcrGrupoDescricao;
        //====================================================================
        public enum attributeName { GRCR_CNTR_CODIGO, GRCR_ID, GRCR_GRUPO_PRINCIPAL, GRCR_NOME, GRCR_SEQUENCE, GRCR_GRUPO_DESCRICAO };
        public enum propertyName { GrcrCntrCodigo, GrcrId, GrcrGrupoPrincipal, GrcrNome, GrcrSequence, GrcrGrupoDescricao };
        //====================================================================
        private static int length = 6;
        public static int Length { get { return length; } }
        //====================================================================
        public string GrcrCntrCodigo { get { return grcrCntrCodigo; } set { grcrCntrCodigo = TruncateValue(value, 20); } }
        public decimal GrcrId { get { return grcrId; } set { grcrId = value; } }
        public string GrcrGrupoSigla { get { return grcrGrupoSigla; } set { grcrGrupoSigla = TruncateValue(value, 20); } }
        public string GrcrNome { get { return grcrNome; } set { grcrNome = TruncateValue(value, 50); } }
        public decimal GrcrSequence { get { return grcrSequence; } set { grcrSequence = value; } }
        public string GrcrGrupoDescricao { get { return grcrGrupoDescricao; } set { grcrGrupoDescricao = TruncateValue(value, 20); } }
    }
}
