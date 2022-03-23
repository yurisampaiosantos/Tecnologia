using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LendoDI
{
    public class MercadoriaDI
    {
        string seqMercadoria = "";

        public string SeqMercadoria
        {
            get { return seqMercadoria; }
            set { seqMercadoria = value; }
        }
        string descricaoMercadoria = "";

        public string DescricaoMercadoria
        {
            get { return descricaoMercadoria; }
            set { descricaoMercadoria = value; }
        }
        string quantiadeMercadoria = "";

        public string QuantiadeMercadoria
        {
            get { return quantiadeMercadoria; }
            set { quantiadeMercadoria = value; }
        }
        string unidadeMercadoria = "";

        public string UnidadeMercadoria
        {
            get { return unidadeMercadoria; }
            set { unidadeMercadoria = value; }
        }
        string vUVCMoeda = "";

        public string VUVCMoeda
        {
            get { return vUVCMoeda; }
            set { vUVCMoeda = value; }
        }
    }
}
