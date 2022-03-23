using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Globalization;

namespace LendoDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LerXML()
        {
            ItemDI item = new ItemDI();
            MercadoriaDI itemMercadoria = new MercadoriaDI();

            bool mercadoria = false;
            bool adicao = false;
            bool icms = false;
            bool armazem = false;
            bool embalagem = false;
            bool pagamento = false;
                        
            string DI = "";
            string Origem = "";
            string Destino = "";
            string DataRegistro = "";
            string DataDesembaraco = "";
            string DataEmbarque = "";
            string DataChegada = "";
            string PesoBruto = "";
            string PesoLiquido = "";
            string VMLDUSD = "";
            string VMLDBRL = "";
            string VMLEUSD = "";
            string VMLEBRL = "";
            string MoedaFrete = "";
            string ValorFreteUSD = "";
            string MoedaFreteMoeda = "";
            string ValorFreteBRL = "";
            string SeguroMoeda = "";
            string SeguroUSD = "";
            string SeguroMoedaCodigo = "";
            string SeguroBRL = "";
            string QuantidadeVolumes = "";
            string Embalagem = "";
            string NumeroManifesto = "";
            string Armazem = "";
            string RecintoAduaneiro = "";
            string InformacaoComplementar = "";
            string ModalidadeDespacho = "";
            string TipoDeclaracaoNome = "";
            string ViaTransporteNome = "";
            string ViaTransporteNomeTransportador = "";
            string ViaTransporteNomeVeiculo = "";      

            progressBar1.Value = 0;

            DialogResult result = DialogResult.Yes;
            // bool importarBanco = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo infoArquivo = new FileInfo(openFileDialog1.FileName);
                DirectoryInfo diretorio = new DirectoryInfo(infoArquivo.DirectoryName);
                FileInfo[] Arquivos = diretorio.GetFiles("*.xml");
                progressBar1.Maximum = Arquivos.Count();
                foreach (FileInfo fileinfo in Arquivos)
                {
                    List<ItemDI> listaItem = new List<ItemDI>();

                    XmlTextReader tr = new XmlTextReader(fileinfo.DirectoryName + "\\" + fileinfo.Name);

                    

                    while (tr.Read())
                    {
                        if (tr.IsStartElement())
                        {
                            //-------------------------
                            if (tr.Name == "adicao")
                            {
                                mercadoria = false;
                                adicao = true;
                                icms = false;
                                armazem = false;
                                embalagem = false;
                                pagamento = false;
                            }

                            if (adicao == true)
                            {
                                if (tr.Name == "mercadoria")
                                {
                                    if (itemMercadoria.QuantiadeMercadoria != "")
                                    {
                                        item.Mercadoria.Add(itemMercadoria);
                                        itemMercadoria = new MercadoriaDI();
                                    }
                                }

                                if (tr.Name == "numeroAdicao")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NumeroAdicao = tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosMercadoriaPesoLiquido")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.DadosMercadoriaPesoLiquido = tr.Value;
                                    }
                                }

                                if (tr.Name == "cofinsAliquotaAdValorem")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.CofinsAliquotaAdValorem = tr.Value;
                                    }
                                }
                                if (tr.Name == "iiAliquotaAdValorem")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.IiAliquotaAdValorem = tr.Value;
                                    }
                                }
                                if (tr.Name == "ipiAliquotaAdValorem")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.IpiAliquotaAdValorem = tr.Value;
                                    }
                                }
                                if (tr.Name == "pisPasepAliquotaAdValorem")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.PisPasepAliquotaAdValorem = tr.Value;
                                    }
                                }

                                if (tr.Name == "numeroDI" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NumeroDI =  tr.Value;
                                    }
                                }

                               
                                if (tr.Name == "numeroLI" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NumeroLI = tr.Value;
                                    }
                                }

                                if (tr.Name == "fornecedorNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.FornecedorNome = tr.Value;
                                    }
                                }

                                if (tr.Name == "paisAquisicaoMercadoriaNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.PaisAquisicao =  tr.Value;
                                    }
                                }

                                if (tr.Name == "fabricanteNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.FabricanteNome =  tr.Value;
                                    }
                                }
                                
                                if (tr.Name == "paisOrigemMercadoriaNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.PaisOrigem =  tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosMercadoriaCodigoNcm" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NCM =  tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosMercadoriaNomeNcm")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NCMDescricao = tr.Value;
                                    }
                                }

                                if (tr.Name == "condicaoVendaMoedaNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VCMVMoeda = tr.Value;
                                        try
                                        {
                                            item.VCMVMoeda = (Convert.ToDouble(item.VCMVMoeda) / 100).ToString();
                                        }
                                        catch { }
                                    }
                                }

                                if (tr.Name == "condicaoVendaValorMoeda" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VCMVValorMoedaAdicao = tr.Value;
                                        try
                                        {
                                            item.VCMVValorMoedaAdicao = (Convert.ToDouble(item.VCMVValorMoedaAdicao) / 100).ToString();
                                        }
                                        catch { }
                                    }
                                }

                                if (tr.Name == "condicaoVendaValorReais" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VCMVValorBRL =  tr.Value;
                                        try
                                        {
                                            item.VCMVValorBRL = (Convert.ToDouble(item.VCMVValorBRL) / 100).ToString();
                                        }
                                        catch { }
                                    }
                                }

                                if (tr.Name == "condicaoVendaIncoterm" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VCMVIncontermAdicao =  tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosCambiaisCoberturaCambialNome" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.DadosCoberturaCambial =  tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosMercadoriaMedidaEstatisticaUnidade")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.UnidadeAdicao =  tr.Value;
                                    }
                                }

                                if (tr.Name == "dadosMercadoriaMedidaEstatisticaQuantidade")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.PesoLiquidoAdicao =  tr.Value;
                                        try
                                        {
                                            item.PesoLiquidoAdicao = (Convert.ToDouble(item.PesoLiquidoAdicao) / 100000).ToString();
                                        }
                                        catch { }
                                    }
                                }

                                if (tr.Name == "mercadoria")
                                {
                                    mercadoria = true;
                                }                           
                                
                                if (mercadoria == true)
                                {
                                    if (tr.Name == "numeroSequencialItem" )
                                    {  
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            itemMercadoria.SeqMercadoria = tr.Value;
                                        }
                                    }

                                    if (tr.Name == "descricaoMercadoria")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            itemMercadoria.DescricaoMercadoria = tr.Value;
                                        }
                                    } 
  
                                    if (tr.Name == "quantidade" )
                                    {  
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            itemMercadoria.QuantiadeMercadoria = tr.Value;
                                            try
                                            {
                                                itemMercadoria.QuantiadeMercadoria = (Convert.ToDouble(itemMercadoria.QuantiadeMercadoria) / 100000).ToString();
                                            }
                                            catch { }
                                        }
                                    }  

                                    if (tr.Name == "unidadeMedida" )
                                    {  
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            itemMercadoria.UnidadeMercadoria = tr.Value;
                                        }
                                    } 
 
                                    if (tr.Name == "valorUnitario" )
                                    {  
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            itemMercadoria.VUVCMoeda = tr.Value;
                                            try
                                            {
                                                itemMercadoria.VUVCMoeda = (Convert.ToDouble(itemMercadoria.VUVCMoeda) / 10000000).ToString();
                                            }
                                            catch { }
                                        }
                                    }

                                }
                                if (tr.Name == "adicao")
                                {
                                    if (item.NumeroAdicao != "")
                                    {
                                        item.Mercadoria.Add(itemMercadoria);
                                        listaItem.Add(item);
                                        item = new ItemDI();
                                        itemMercadoria = new MercadoriaDI();
                                    }
                                }
                            }

                            //--------------------------armazem
                            if (tr.Name == "armazem")
                            {
                                mercadoria = false;
                                adicao = false;
                                icms = false;
                                armazem = false;
                                embalagem = false;
                                pagamento = false;

                                if (item.NumeroAdicao != "")
                                {
                                    item.Mercadoria.Add(itemMercadoria);
                                    listaItem.Add(item);
                                    item = new ItemDI();
                                    itemMercadoria = new MercadoriaDI();
                                }

                            }

                            if (tr.Name == "cargaPaisProcedenciaNome" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    Origem = tr.Value;
                                }
                             }

                            if (tr.Name == "cargaUrfEntradaNome" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    Destino = tr.Value;
                                }
                             }


                            if (tr.Name == "icms")
                            {
                                mercadoria = false;
                                adicao = false;
                                icms = true;
                                armazem = false;
                                embalagem = false;
                                pagamento = false;

                                if (item.NumeroAdicao != "")
                                {
                                    item.Mercadoria.Add(itemMercadoria);
                                    listaItem.Add(item);
                                    item = new ItemDI();
                                    itemMercadoria = new MercadoriaDI();
                                }
                            }


                            if (icms == false)
                            {
                                if (tr.Name == "dataRegistro")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        DataRegistro = tr.Value;
                                        try
                                        {
                                            DataRegistro = DateTime.ParseExact(DataRegistro, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                                        }
                                        catch { }
                                    }
                                }

                                if (tr.Name == "dataDesembaraco")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        DataDesembaraco = tr.Value;
                                        try
                                        {
                                            DataDesembaraco = DateTime.ParseExact(DataDesembaraco, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                                        }
                                        catch { }
                                    }
                                }
                            }

                            if (tr.Name == "conhecimentoCargaEmbarqueData" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    DataEmbarque = tr.Value;
                                    try
                                    {
                                        DataEmbarque = DateTime.ParseExact(DataEmbarque, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                                    }
                                    catch { }
                                }
                             }

                            if (tr.Name == "cargaDataChegada" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    DataChegada = tr.Value;
                                    try
                                    {
                                        DataChegada = DateTime.ParseExact(DataChegada, "yyyyMMdd", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy");
                                    }
                                    catch { }
                                }
                             }

                            if (tr.Name == "cargaPesoBruto" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    PesoBruto = tr.Value;
                                    try
                                    {
                                        PesoBruto = (Convert.ToDouble(PesoBruto) / 100000).ToString();
                                    }
                                    catch { }
                                }
                             }

                            if (tr.Name == "cargaPesoLiquido" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    PesoLiquido = tr.Value;
                                    try
                                    {
                                        PesoLiquido = (Convert.ToDouble(PesoLiquido) / 100000).ToString();
                                    }
                                    catch { }
                                }
                             }

                            if (tr.Name == "documentoChegadaCargaNumero" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    NumeroManifesto = "'" + tr.Value;
                                }
                             }

                            if (tr.Name == "nomeArmazem" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    Armazem = tr.Value;
                                }
                             }

                            if (tr.Name == "armazenamentoRecintoAduaneiroNome" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    RecintoAduaneiro = tr.Value;
                                }
                             }
                            //-------------------------- ICMS
                            if (tr.Name == "numeroDI" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    DI = tr.Value;
                                }
                             }
                            if (tr.Name == "localDescargaTotalDolares" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    VMLDUSD = tr.Value;
                                    try
                                    {
                                        VMLDUSD = (Convert.ToDouble(VMLDUSD) / 100).ToString();
                                    }
                                    catch { }
                                }
                             }
                            if (tr.Name == "localDescargaTotalReais" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    VMLDBRL = tr.Value;
                                    try
                                    {
                                        VMLDBRL = (Convert.ToDouble(VMLDBRL) / 100).ToString();
                                    }
                                    catch { }
                                }
                             }                                
                            if (tr.Name == "localEmbarqueTotalDolares" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    VMLEUSD = tr.Value;
                                    try
                                    {
                                        VMLEUSD = (Convert.ToDouble(VMLEUSD) / 100).ToString();
                                    }
                                    catch { }
                                }
                             } 
                            if (tr.Name == "localEmbarqueTotalReais" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    VMLEBRL = tr.Value;
                                    try
                                    {
                                        VMLEBRL = (Convert.ToDouble(VMLEBRL) / 100).ToString();
                                    }
                                    catch { }
                                }
                             }

                            if (tr.Name == "informacaoComplementar")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    InformacaoComplementar = tr.Value;
                                }
                            }

                            if (tr.Name == "modalidadeDespachoNome" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ModalidadeDespacho = tr.Value;
                                }
                             } 
                            //--------------------------
 
                            //-------------------------- embalagem
                            if (tr.Name == "freteMoedaNegociadaNome" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    MoedaFrete = tr.Value;
                                }
                             } 

                            if (tr.Name == "freteTotalDolares" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ValorFreteUSD = tr.Value;
                                    try
                                    {
                                        ValorFreteUSD = (Convert.ToDouble(ValorFreteUSD) / 100).ToString();
                                    }
                                    catch { }
                                }
                             } 

                            if (tr.Name == "freteTotalMoeda" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    MoedaFreteMoeda = tr.Value;
                                    try
                                    {
                                        MoedaFreteMoeda = (Convert.ToDouble(MoedaFreteMoeda) / 100).ToString();
                                    }
                                    catch { }
                                }
                             } 

                            if (tr.Name == "freteTotalReais" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ValorFreteBRL = tr.Value;
                                    try
                                    {
                                        ValorFreteBRL = (Convert.ToDouble(ValorFreteBRL) / 100).ToString();
                                    }
                                    catch { }
                                }
                             } 

                            if (tr.Name == "embalagem")
                            {
                                mercadoria = false;
                                adicao = false;
                                icms = false;
                                armazem = false;
                                embalagem = true;
                                pagamento = false;
                            }

                            if (embalagem == true)
                            {
                                if (tr.Name == "quantidadeVolume")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        QuantidadeVolumes = tr.Value;
                                    }
                                 } 

                                if (tr.Name == "nomeEmbalagem" )
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        Embalagem = tr.Value;
                                    }
                                 } 
                            }

                            //--------------------------

                            //-------------------------- Pagamento
                            if (tr.Name == "pagamento")
                            {
                                mercadoria = false;
                                adicao = false;
                                icms = false;
                                armazem = false;
                                embalagem = false;
                                pagamento = true;
                            }

                            if (tr.Name == "seguroMoedaNegociadaCodigo" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    SeguroMoedaCodigo = tr.Value;
                                }
                             } 

                            if (tr.Name == "seguroTotalDolares" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    SeguroUSD = tr.Value;
                                }
                             } 

                            if (tr.Name == "seguroTotalMoedaNegociada" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    SeguroMoeda = tr.Value;
                                }
                             } 

                            if (tr.Name == "seguroTotalReais" )
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    SeguroBRL = tr.Value;
                                }
                             }
                            //--------------------------outros  
                            if (tr.Name == "tipoDeclaracaoNome")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    TipoDeclaracaoNome = tr.Value;
                                }
                            }
                            if (tr.Name == "viaTransporteNome")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ViaTransporteNome = tr.Value;
                                }
                            }
                            if (tr.Name == "viaTransporteNomeTransportador")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ViaTransporteNomeTransportador = tr.Value;
                                }
                            }
                            if (tr.Name == "viaTransporteNomeVeiculo")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                {
                                    ViaTransporteNomeVeiculo = tr.Value;
                                }
                            } 

                        }
                    }
                    
                    if (listaItem.Count == 0)
                    {
                       Inserir(fileinfo.Name, "", "", "", "", "", "", "", "", "", "", "",
                                     "", "", "", "", "", "", "", "", "", "", "" , DI, Origem,
                                     Destino, DataRegistro, DataDesembaraco, DataEmbarque, DataChegada, PesoBruto, PesoLiquido, VMLDUSD, VMLDBRL, VMLEUSD, VMLEBRL, MoedaFrete,
                                     ValorFreteUSD,MoedaFreteMoeda, ValorFreteBRL, SeguroMoeda, SeguroUSD, SeguroMoedaCodigo, SeguroBRL, QuantidadeVolumes, Embalagem, NumeroManifesto, Armazem,
                                     RecintoAduaneiro, InformacaoComplementar, ModalidadeDespacho, TipoDeclaracaoNome, ViaTransporteNome, ViaTransporteNomeTransportador, ViaTransporteNomeVeiculo,
                                     "", "", "", "");
                    }
                    else
                    {
                        foreach (ItemDI lineItem in listaItem)
                        {
                            if (lineItem.Mercadoria.Count == 0)
                            {
                                Inserir(fileinfo.Name, lineItem.NumeroDI, lineItem.NumeroLI, lineItem.NumeroAdicao, lineItem.FornecedorNome, lineItem.PaisAquisicao, lineItem.FabricanteNome, lineItem.PaisOrigem, lineItem.NCM, lineItem.NCMDescricao, "", "",
                                         "", "", "", lineItem.VCMVMoeda, lineItem.VCMVValorMoedaAdicao, lineItem.VCMVValorBRL, lineItem.VCMVIncontermAdicao, lineItem.DadosCoberturaCambial, lineItem.UnidadeAdicao, lineItem.PesoLiquidoAdicao, lineItem.DadosMercadoriaPesoLiquido, DI, Origem,
                                         Destino, DataRegistro, DataDesembaraco, DataEmbarque, DataChegada, PesoBruto, PesoLiquido, VMLDUSD, VMLDBRL, VMLEUSD, VMLEBRL, MoedaFrete,
                                         ValorFreteUSD, MoedaFreteMoeda ,ValorFreteBRL, SeguroMoeda, SeguroUSD, SeguroMoedaCodigo, SeguroBRL, QuantidadeVolumes, Embalagem, NumeroManifesto, Armazem,
                                         RecintoAduaneiro, InformacaoComplementar, ModalidadeDespacho, TipoDeclaracaoNome, ViaTransporteNome, ViaTransporteNomeTransportador, ViaTransporteNomeVeiculo,
                                         lineItem.CofinsAliquotaAdValorem, lineItem.IiAliquotaAdValorem, lineItem.IpiAliquotaAdValorem, lineItem.PisPasepAliquotaAdValorem);
                            }
                            else
                            {
                                foreach (MercadoriaDI lineMercItem in lineItem.Mercadoria)
                                {

                                    Inserir(fileinfo.Name, lineItem.NumeroDI, lineItem.NumeroLI, lineItem.NumeroAdicao, lineItem.FornecedorNome, lineItem.PaisAquisicao, lineItem.FabricanteNome, lineItem.PaisOrigem, lineItem.NCM, lineItem.NCMDescricao, lineMercItem.SeqMercadoria, lineMercItem.DescricaoMercadoria,
                                             lineMercItem.QuantiadeMercadoria, lineMercItem.UnidadeMercadoria, lineMercItem.VUVCMoeda, lineItem.VCMVMoeda, lineItem.VCMVValorMoedaAdicao, lineItem.VCMVValorBRL, lineItem.VCMVIncontermAdicao, lineItem.DadosCoberturaCambial, lineItem.UnidadeAdicao, lineItem.PesoLiquidoAdicao, lineItem.DadosMercadoriaPesoLiquido, DI, Origem,
                                             Destino, DataRegistro, DataDesembaraco, DataEmbarque, DataChegada, PesoBruto, PesoLiquido, VMLDUSD, VMLDBRL, VMLEUSD, VMLEBRL, MoedaFrete,
                                             ValorFreteUSD,MoedaFreteMoeda, ValorFreteBRL, SeguroMoeda, SeguroUSD, SeguroMoedaCodigo, SeguroBRL, QuantidadeVolumes, Embalagem, NumeroManifesto, Armazem,
                                             RecintoAduaneiro, InformacaoComplementar, ModalidadeDespacho, TipoDeclaracaoNome, ViaTransporteNome, ViaTransporteNomeTransportador, ViaTransporteNomeVeiculo,
                                             lineItem.CofinsAliquotaAdValorem, lineItem.IiAliquotaAdValorem, lineItem.IpiAliquotaAdValorem, lineItem.PisPasepAliquotaAdValorem);
                                }
                            }
                        }
                    }
                     DI = "";
                     Origem = "";
                     Destino = "";
                     DataRegistro = "";
                     DataDesembaraco = "";
                     DataEmbarque = "";
                     DataChegada = "";
                     PesoBruto = "";
                     PesoLiquido = "";
                     VMLDUSD = "";
                     VMLDBRL = "";
                     VMLEUSD = "";
                     VMLEBRL = "";
                     MoedaFrete = "";
                     MoedaFreteMoeda = "";
                     ValorFreteUSD = "";
                     ValorFreteBRL = "";
                     SeguroMoeda = "";
                     SeguroUSD = "";
                     SeguroMoedaCodigo = "";
                     SeguroBRL = "";
                     QuantidadeVolumes = "";
                     Embalagem = "";
                     NumeroManifesto = "";
                     Armazem = "";
                     RecintoAduaneiro = "";
                     InformacaoComplementar = "";
                     ModalidadeDespacho = "";
                     TipoDeclaracaoNome = "";
                     ViaTransporteNome = "";
                     ViaTransporteNomeTransportador = "";
                     ViaTransporteNomeVeiculo = "";
              

                    progressBar1.Value = progressBar1.Value + 1;
                   
                }

            }
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            LerXML();
            btSalvarExcel.Visible = true;
        }
        private void SalvarExcel()
        {
            progressBar1.Value = 0;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != null && saveFileDialog1.FileName != "")
                {
                    FileInfo infoArquivo = new FileInfo(saveFileDialog1.FileName);
                    if (File.Exists(saveFileDialog1.FileName))
                        File.Delete(saveFileDialog1.FileName);

                    Excel.Application xlApp;
                    Excel.Workbook xlWorkBook;
                    Excel.Worksheet xlWorkSheet;
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    try
                    {
                        int i = 0;
                        int j = 0;
                        //cabecalho
                        for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                        {
                            xlWorkSheet.Cells[i + 1, j + 1] = dataGridView1.Columns[j].HeaderText;
                        }
                        //dados
                        progressBar1.Maximum = dataGridView1.RowCount;
                        //for (int y = 0; y != 10; y++)
                        //{
                            for (i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                for (j = 0; j <= dataGridView1.ColumnCount - 1; j++)
                                {
                                    DataGridViewCell cell = dataGridView1[j, i];
                                    if (cell.Value != null && cell.Value != "" && cell.Value.ToString().Substring(0, 1) == "=")
                                    {
                                        xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value; 
                                    }
                                    else
                                    {
                                        xlWorkSheet.Cells[i + 2, j + 1] =  cell.Value;
                                    }
                                }
                                progressBar1.Value = progressBar1.Value + 1;
                            }
                       // }
                        xlWorkBook.SaveAs(saveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();

                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                        MessageBox.Show("Arquivo salvo com sucesso!");
                    }
                    catch
                    {
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                    }
                }
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void Inserir(string filename , string DIAdicao,string LIAdicao,string NumeroAdicao,string FornecedorAdicao,string PaisAquisicao,string Fabricante,string PaisOrigem,string NCM,string NCMDescricao,string SeqMercadoria,string DescricaoMercadoria,
                                string QtdMercadoria,string UnidadeMercadoria,string VUCV,string VCMVMoeda,string VCMVValorMoeda,string VCMVValorBRL,string VCMVIncoterm,string DadosCobertura,string UnidadeAcao,string PesoAcao, string DadosMercadoriaPesoLiquido, string DI,string Origem,
                                string Destino,string DataRegistro,string DataDesembaraco,string DataEmbarque,string DataChegada,string PesoBruto,string PesoLiquido,string VMLDUSD,string VMLDBRL,string VMLEUSD,string VMLEBRL,string MoedaFrete,
                                string ValorFreteUSD,string MoedaFreteMoeda, string ValorFreteBRL,string SeguroMoeda,string SeguroUSD,string SeguroMoedaCodigo,string SeguroBRL,string QuantidadeVolumes,string Embalagem,string NumeroManifesto,string Armazem,
                                string RecintoAduaneiro, string InformacaoComplementar, string ModalidadeDespacho, string TipoDeclaracaoNome, string ViaTransporteNome, string ViaTransporteNomeTransportador, string ViaTransporteNomeVeiculo,
                                string cofinsAliquotaAdValorem, string iiAliquotaAdValorem, string ipiAliquotaAdValorem, string pisPasepAliquotaAdValorem)
        {
            dataGridView1.Rows.Add(filename, DIAdicao, LIAdicao, NumeroAdicao, FornecedorAdicao, PaisAquisicao, Fabricante, PaisOrigem, NCM, NCMDescricao, SeqMercadoria, DescricaoMercadoria,
                                     QtdMercadoria, UnidadeMercadoria, VUCV, VCMVMoeda, VCMVValorMoeda, VCMVValorBRL, VCMVIncoterm, DadosCobertura, UnidadeAcao, PesoAcao, DadosMercadoriaPesoLiquido , DI, Origem,
                                     Destino, DataRegistro, DataDesembaraco, DataEmbarque, DataChegada, PesoBruto, PesoLiquido, VMLDUSD, VMLDBRL, VMLEUSD, VMLEBRL, MoedaFrete,
                                     ValorFreteUSD,MoedaFreteMoeda, ValorFreteBRL, SeguroMoeda, SeguroUSD, SeguroMoedaCodigo, SeguroBRL, QuantidadeVolumes, Embalagem, NumeroManifesto, Armazem,
                                     RecintoAduaneiro, InformacaoComplementar, ModalidadeDespacho, TipoDeclaracaoNome, ViaTransporteNome, ViaTransporteNomeTransportador, ViaTransporteNomeVeiculo,
                                     cofinsAliquotaAdValorem, iiAliquotaAdValorem, ipiAliquotaAdValorem, pisPasepAliquotaAdValorem);
        }

        private void btSalvarExcel_Click(object sender, EventArgs e)
        {
            SalvarExcel();            
        }
    }
}