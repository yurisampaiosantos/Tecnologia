using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LendoDI
{
    public class ItemDI
    {
        string numeroDI = "";

        public string NumeroDI
        {
            get { return numeroDI; }
            set { numeroDI = value; }
        }
        string numeroLI = "";

        public string NumeroLI
        {
            get { return numeroLI; }
            set { numeroLI = value; }
        }
        string numeroAdicao = "";

        public string NumeroAdicao
        {
            get { return numeroAdicao; }
            set { numeroAdicao = value; }
        }
        string fornecedorNome = "";

        public string FornecedorNome
        {
            get { return fornecedorNome; }
            set { fornecedorNome = value; }
        }
        string paisAquisicao = "";

        public string PaisAquisicao
        {
            get { return paisAquisicao; }
            set { paisAquisicao = value; }
        }
        string fabricanteNome = "";

        public string FabricanteNome
        {
            get { return fabricanteNome; }
            set { fabricanteNome = value; }
        }
        string paisOrigem = "";

        public string PaisOrigem
        {
            get { return paisOrigem; }
            set { paisOrigem = value; }
        }
        string nCM = "";

        public string NCM
        {
            get { return nCM; }
            set { nCM = value; }
        }
        string nCMDescricao = "";

        public string NCMDescricao
        {
            get { return nCMDescricao; }
            set { nCMDescricao = value; }
        }
        string vCMVMoeda = "";

        public string VCMVMoeda
        {
            get { return vCMVMoeda; }
            set { vCMVMoeda = value; }
        }
        string vCMCMoedaAdicao = "";

        public string VCMVValorMoedaAdicao
        {
            get { return vCMCMoedaAdicao; }
            set { vCMCMoedaAdicao = value; }
        }
        string vCMVValorAdicao = "";

        public string VCMVValorBRL
        {
            get { return vCMVValorAdicao; }
            set { vCMVValorAdicao = value; }
        }
        string vCMVIncontermAdicao = "";

        public string VCMVIncontermAdicao
        {
            get { return vCMVIncontermAdicao; }
            set { vCMVIncontermAdicao = value; }
        }
        string dadosCoberturaCambial = "";

        public string DadosCoberturaCambial
        {
            get { return dadosCoberturaCambial; }
            set { dadosCoberturaCambial = value; }
        }
        string unidadeAdicao = "";

        public string UnidadeAdicao
        {
            get { return unidadeAdicao; }
            set { unidadeAdicao = value; }
        }
        string pesoLiquidoAdicao = "";

        public string PesoLiquidoAdicao
        {
            get { return pesoLiquidoAdicao; }
            set { pesoLiquidoAdicao = value; }
        }

        string dadosMercadoriaPesoLiquido = "";

        public string DadosMercadoriaPesoLiquido
        {
            get { return dadosMercadoriaPesoLiquido; }
            set { dadosMercadoriaPesoLiquido = value; }
        }

        string cofinsAliquotaAdValorem = "";

        public string CofinsAliquotaAdValorem
        {
            get
            {
                decimal valor;
                try
                {
                    valor = Convert.ToDecimal(cofinsAliquotaAdValorem) / 10000;
                }
                catch
                { valor = 0; }

                return valor.ToString();
            }
            set { cofinsAliquotaAdValorem = value; }
        }
        string iiAliquotaAdValorem = "";

        public string IiAliquotaAdValorem
        {
            get
            {
                decimal valor;
                try
                {
                    valor = Convert.ToDecimal(iiAliquotaAdValorem) / 10000;
                }
                catch
                { valor = 0; }

                return valor.ToString();
            }
            set { iiAliquotaAdValorem = value; }
        }
        string ipiAliquotaAdValorem = "";

        public string IpiAliquotaAdValorem
        {
            get
            {
                decimal valor;
                try
                {
                    valor = Convert.ToDecimal(ipiAliquotaAdValorem) / 10000;
                }
                catch
                { valor = 0; }

                return valor.ToString();
            }
            set { ipiAliquotaAdValorem = value; }
        }
        string pisPasepAliquotaAdValorem = "";

        public string PisPasepAliquotaAdValorem
        {
            get
            {
                decimal valor;
                try
                {
                    valor = Convert.ToDecimal(pisPasepAliquotaAdValorem) / 10000;
                }
                catch
                { valor = 0; }

                return valor.ToString();
            }
            set { pisPasepAliquotaAdValorem = value; }
        }

        private List<MercadoriaDI> mercadoria = new List<MercadoriaDI>();

        public List<MercadoriaDI> Mercadoria
        {
            get { return mercadoria; }
            set { mercadoria = value; }
        }

    }
}
