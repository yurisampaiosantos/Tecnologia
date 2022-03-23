using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionProjGenEmailDTO : List<ProjGenEmailDTO> { }
    //====================================================================
    public class ProjGenEmailDTO : BaseDTO
    {
        private decimal id;
        private string tipoDestinatario;
        private string disciplina;
        private string email;
        private decimal ativo;
        private string descricao;
        //====================================================================
        public enum attributeName { ID, TIPO_DESTINATARIO, DISCIPLINA, EMAIL, ATIVO, DESCRICAO };
        public enum propertyName { ID, TipoDestinatario, Disciplina, Email, Ativo, Descricao };
        //====================================================================
        private static int length = 6;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal ID { get { return id; } set { id = value; } }
        public string TipoDestinatario { get { return tipoDestinatario; } set { tipoDestinatario = TruncateValue(value, 3); } }
        public string Disciplina { get { return disciplina; } set { disciplina = TruncateValue(value, 20); } }
        public string Email { get { return email; } set { email = TruncateValue(value, 200); } }
        public decimal Ativo { get { return ativo; } set { ativo = value; } }
        public string Descricao { get { return descricao; } set { descricao = TruncateValue(value, 100); } }
    }
}
