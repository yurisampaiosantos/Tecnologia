using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD
{
    public class BalancaMOD
    {
        private double id;
        private string movimento;
        private string placaCavalo;
        private string placaCarreta;
        private string idExternoCliente;
        private string idExternoTransportadora;
        private string idExternoMotorista;
        private string idExternoProduto;
        private string observacao;
        private string idExterno;
        private string minutaRomaneio;

        private string chaveAcesso;        
        private string numeroNotaFiscal;
        private string pesoNotaFiscal;
        private string pesoLiquido;
        private string volume;
        private string numeroPedido;
        private string dataRmissao;

        public double Id { get => id; set => id = value; }
        public string Movimento { get => movimento; set => movimento = value; }
        public string PlacaCavalo { get => placaCavalo; set => placaCavalo = value; }
        public string PlacaCarreta { get => placaCarreta; set => placaCarreta = value; }
        public string IdExternoCliente { get => idExternoCliente; set => idExternoCliente = value; }
        public string IdExternoTransportadora { get => idExternoTransportadora; set => idExternoTransportadora = value; }
        public string IdExternoMotorista { get => idExternoMotorista; set => idExternoMotorista = value; }
        public string IdExternoProduto { get => idExternoProduto; set => idExternoProduto = value; }
        public string Observacao { get => observacao; set => observacao = value; }
        public string IdExterno { get => idExterno; set => idExterno = value; }
        public string MinutaRomaneio { get => minutaRomaneio; set => minutaRomaneio = value; }
        public string ChaveAcesso { get => chaveAcesso; set => chaveAcesso = value; }
        public string NumeroNotaFiscal { get => numeroNotaFiscal; set => numeroNotaFiscal = value; }
        public string PesoNotaFiscal { get => pesoNotaFiscal; set => pesoNotaFiscal = value; }
        public string PesoLiquido { get => pesoLiquido; set => pesoLiquido = value; }
        public string Volume { get => volume; set => volume = value; }
        public string NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public string DataRmissao { get => dataRmissao; set => dataRmissao = value; }
    }
}
