using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionCpUsuarioDTO : List<CpUsuarioDTO> { }
    //====================================================================
    public class CpUsuarioDTO : BaseDTO
    {
        private decimal usuaId;
        private string usuaLogin;
        private decimal usuaLocaId;
        private string usuaEmail;
        private decimal usuaClasse;
        private decimal usuaActive;
        private string usuaClasseDescricao;
        private string usuaObservacao;
        private decimal usuaAgCriarPunch;
        private decimal usuaAgClassPunch;
        private decimal usuaAgStatusPunch;
        private decimal usuaAgCriarPendmat;
        private decimal usuaAgStatusPendmat;
        //====================================================================
        public enum attributeName { USUA_ID, USUA_LOGIN, USUA_LOCA_ID, USUA_EMAIL, USUA_CLASSE, USUA_ACTIVE, USUA_CLASSE_DESCRICAO, USUA_OBSERVACAO, USUA_AG_CRIAR_PUNCH, USUA_AG_CLASS_PUNCH, USUA_AG_STATUS_PUNCH, USUA_AG_CRIAR_PENDMAT, USUA_AG_STATUS_PENDMAT };
        public enum propertyName { UsuaId, UsuaLogin, UsuaLocaId, UsuaEmail, UsuaClasse, UsuaActive, UsuaClasseDescricao, UsuaObservacao, UsuaAgCriarPunch, UsuaAgClassPunch, UsuaAgStatusPunch, UsuaAgCriarPendmat, UsuaAgStatusPendmat };
        //====================================================================
        private static int length = 13;
        public static int Length { get { return length; } }
        //====================================================================
        public decimal UsuaId { get { return usuaId; } set { usuaId = value; } }
        public string UsuaLogin { get { return usuaLogin; } set { usuaLogin = TruncateValue(value, 50); } }
        public decimal UsuaLocaId { get { return usuaLocaId; } set { usuaLocaId = value; } }
        public string UsuaEmail { get { return usuaEmail; } set { usuaEmail = TruncateValue(value, 100); } }
        public decimal UsuaClasse { get { return usuaClasse; } set { usuaClasse = value; } }
        public decimal UsuaActive { get { return usuaActive; } set { usuaActive = value; } }
        public string UsuaClasseDescricao { get { return usuaClasseDescricao; } set { usuaClasseDescricao = TruncateValue(value, 20); } }
        public string UsuaObservacao { get { return usuaObservacao; } set { usuaObservacao = TruncateValue(value, 100); } }
        public decimal UsuaAgCriarPunch { get { return usuaAgCriarPunch; } set { usuaAgCriarPunch = value; } }
        public decimal UsuaAgClassPunch { get { return usuaAgClassPunch; } set { usuaAgClassPunch = value; } }
        public decimal UsuaAgStatusPunch { get { return usuaAgStatusPunch; } set { usuaAgStatusPunch = value; } }
        public decimal UsuaAgCriarPendmat { get { return usuaAgCriarPendmat; } set { usuaAgCriarPendmat = value; } }
        public decimal UsuaAgStatusPendmat { get { return usuaAgStatusPendmat; } set { usuaAgStatusPendmat = value; } }
    }
}
