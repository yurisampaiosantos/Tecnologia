using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace LendoXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LerXML()
        {
            Item item = new Item();

            bool emit = false;
            bool ide = false;
            bool prod = false;
            bool icms = false;
            bool inf = false;
            bool emitdest = false;
            bool infAdic = false;
            bool vol = false;
            bool infProt = false;
            bool cobr = false;
            bool transp = false;
            
            string CNPJEmi = "";
            string xNomeEmi = "";
            string xFant = "";
            string nNF = "";
            string serie = "";
            string dEmi = "";
            string natOp = "";
            string tpNF = "";
            string vNF = "";
            string vProd2 = "";
            string chNFe = "";
            string cDV = "";
            string CNPJDest = "";
            string xNomeDest = "";
            string infCpl = "";
            string qVol = "";
            string CFOP = "";
            string UF = "";
            string xMotivo = "";
            string vFrete = "";
            string vOutro = "";
            string dVenc = "";
            string refNFe = "";
            string cstat = "";
            string pesoL = "";
            string pesoB = "";

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
                    List<Item> listaItem = new List<Item>();
                    /* XmlDocument xmlDocument = new XmlDocument();
                     xmlDocument.Load(fileinfo.DirectoryName + "\\" + fileinfo.Name);

                     foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("infCte"))
                         Console.WriteLine("Id do Pedido: {0}", xmlNode.Attributes["Id"].Value);
                     foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("infNFe"))
                         Console.WriteLine("Id do Pedido: {0}", xmlNode.Attributes["Id"].Value);
                     */
                    XmlTextReader tr = new XmlTextReader(fileinfo.DirectoryName + "\\" + fileinfo.Name);

                    while (tr.Read())
                    {
                        if (tr.IsStartElement())
                        {
                            //-------------------------
                            if (tr.Name == "emit")
                            {
                                emit = true;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = false;
                                infAdic = false;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (emit == true)
                            {
                                if (tr.Name == "xNome" && emitdest == false)
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        xNomeEmi = tr.Value;
                                    }
                                }


                                if (tr.Name == "CNPJ" && emitdest == false)
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        CNPJEmi = "'" + tr.Value;
                                    }
                                }

                                if (tr.Name == "xFant" && emitdest == false)
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        xFant = tr.Value;
                                    }
                                }
                                if (tr.Name == "UF" && emitdest == false)
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        UF = tr.Value;
                                    }
                                }
                            }
                            if (tr.Name == "rem")
                            {
                                emit = false;
                            }
                            //-------------
                            
                            if (tr.Name == "dest")
                            {
                                emitdest = true;
                            }
                            if (emitdest == true)
                            {
                                if (tr.Name == "xNome")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        xNomeDest = tr.Value;
                                    }
                                }


                                if (tr.Name == "CNPJ" || tr.Name == "CPF")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text && CNPJDest == "")
                                    {
                                        CNPJDest = "'" + tr.Value;
                                    }
                                    if (tr.Name == "xNome")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            xNomeDest = tr.Value;
                                        }
                                    }
                                }
                            }
                            if (tr.Name == "vPrest" || tr.Name == "retirada" || tr.Name == "autXML" )
                            {
                                emitdest = false;
                            }
                            //--------------------------
                            if (tr.Name == "ide")
                            {
                                emit = false;
                                ide = true;
                                prod = false;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (ide == true)
                            {
                                if (tr.Name == "nNF" || tr.Name == "nCT")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        nNF = tr.Value;
                                    }
                                }
                                if (tr.Name == "CFOP")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        CFOP = tr.Value;
                                    }
                                }
                                if (tr.Name == "serie")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        serie = tr.Value;
                                    }
                                }
                                if (tr.Name == "dEmi" || tr.Name == "dhEmi")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        dEmi = tr.Value.Substring(0, 10);
                                    }
                                }
                                if (tr.Name == "natOp")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        natOp = tr.Value;
                                    }
                                }
                                if (tr.Name == "tpNF")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        tpNF = tr.Value;
                                    }
                                }
                                if (tr.Name == "cDV")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        cDV = tr.Value;
                                    }
                                }
                                if (tr.Name == "refNFe")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        refNFe = "'" + tr.Value;
                                    }
                                }
                            }
                            //---------------------
                            if (tr.Name == "prod")
                            {
                                if (item.CProd != null || item.XProd != null)
                                {
                                    listaItem.Add(item);
                                    item = new Item();
                                }

                                emit = false;
                                ide = false;
                                prod = true;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (prod == true)
                            {
                                if (tr.Name == "vProd")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VProd = tr.Value;
                                    }
                                }
                                if (tr.Name == "indTot") //detitem
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.DetnItem = tr.Value;
                                    }
                                }
                                if (tr.Name == "cProd")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.CProd = tr.Value;
                                    }
                                }
                                if (tr.Name == "xProd")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.XProd = tr.Value;
                                    }
                                }
                                if (tr.Name == "NCM")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.NCM = tr.Value;
                                    }
                                }
                                if (tr.Name == "CFOP")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.CFOP = tr.Value;
                                    }
                                }
                                if (tr.Name == "uCom")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.UCom = tr.Value;
                                    }
                                }
                                if (tr.Name == "qCom")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.QCom = tr.Value;
                                    }
                                }
                                if (tr.Name == "vUnCom")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VUnCom = tr.Value;
                                    }
                                }
                                if (tr.Name == "infAdProd")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.InfAdProd = tr.Value;
                                    }
                                }
                                if (tr.Name == "pICMS")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.PICMS = tr.Value;
                                    }
                                }
                                if (tr.Name == "vICMS")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VICMS = tr.Value;
                                    }
                                }
                                if (tr.Name == "vBC")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        item.VBC = tr.Value;
                                    }
                                }
                            }
                            //----------------------
                            if (tr.Name == "ICMSTot" || tr.Name == "vPrest")
                            {
                                if (item.CProd != null || item.XProd != null)
                                {
                                    listaItem.Add(item);
                                    item = new Item();
                                }

                                emit = false;
                                ide = false;
                                prod = false;
                                icms = true;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (icms == true)
                            {
                                if (tr.Name == "vProd" || tr.Name == "vTPrest")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        vProd2 = tr.Value;
                                    }
                                }
                                if (tr.Name == "vNF" || tr.Name == "vRec")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        vNF = tr.Value;
                                    }
                                }
                                if (tr.Name == "vFrete")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        vFrete = tr.Value;
                                    }
                                }
                                if (tr.Name == "vOutro")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        vOutro = tr.Value;
                                    }
                                }
                            }
                            if (tr.Name == "infCTeNorm")
                            {
                                icms = false;
                            }
                            //------------
                            if (tr.Name == "infAdic")
                            {
                                emit = false;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = true;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (infAdic == true)
                            {
                                if (tr.Name == "infCpl")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        infCpl = tr.Value;
                                    }
                                }
                            }


                            //-----------------
                            if (tr.Name == "infProt")
                            {
                                emit = false;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = true;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                cobr = false;
                                transp = false;
                            }
                            if (inf == true)
                            {
                                if (tr.Name == "chNFe" || tr.Name == "chCTe")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        chNFe = "'" + tr.Value;
                                    }
                                }
                                if (tr.Name == "cStat")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        cstat = tr.Value;
                                    }
                                }
                            }
                            //-----------------
                            if (tr.Name == "transp")
                            {
                                transp = true;
                            }
                            if (tr.Name == "vol")
                            {
                                emit = false;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = true;
                                cobr = false;                             
                            }
                            if (vol == true)
                            {
                                if (tr.Name == "qVol")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        qVol = tr.Value;
                                    }
                                }
                                if (transp == true)
                                {
                                    if (tr.Name == "pesoL")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            pesoL = tr.Value;
                                        }
                                    }
                                    if (tr.Name == "pesoB")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            pesoB = tr.Value;
                                        }
                                    }
                                }
                            }

                            if (tr.Name == "infProt")
                            {
                                emit = false;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                infProt = true;
                                cobr = false;
                                transp = false;
                            }
                            if (infProt == true)
                            {
                                if (tr.Name == "xMotivo")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        xMotivo = tr.Value;
                                        infProt = false;
                                    }
                                }
                                if (tr.Name == "cStat")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        cstat = tr.Value;
                                    }
                                }
                            }

                            if (tr.Name == "cobr")
                            {
                                emit = false;
                                ide = false;
                                prod = false;
                                icms = false;
                                inf = false;
                                emitdest = false;
                                infAdic = false;
                                vol = false;
                                infProt = false;
                                cobr = true;
                                transp = false;
                            }
                            if (cobr == true)
                            {
                                if (tr.Name == "dVenc")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        dVenc = tr.Value;
                                        infProt = cobr;
                                    }
                                }
                            }
                            
                        }
                        //chave ID
                        // numero da nota nCT
                        //nome fornecedor xNome
                        //NCPJ CNPJ
                        //data dhEmi
                        //tipo mod (57 = YT 55 = YA)
                        //CNPJ tomador 
                        //Valor vTPrest
                    }
                    int x = 1;
                    if (listaItem.Count == 0)
                    {
                        Inserir(fileinfo.Name, chNFe, CNPJEmi, xNomeEmi, xFant, CNPJDest, xNomeDest, nNF, serie, dEmi, UF, natOp, tpNF, cDV, vNF, "", "", "", "", "", "", "", "", infCpl, "", CFOP, "", "", "", vFrete, vOutro, qVol, vProd2, xMotivo, dVenc, refNFe, cstat,pesoB,pesoL);
                    }
                    else
                    {
                        foreach (Item lineItem in listaItem)
                        {
                            Inserir(fileinfo.Name, chNFe, CNPJEmi, xNomeEmi, xFant, CNPJDest, xNomeDest, nNF, serie, dEmi, UF, natOp, tpNF, cDV, vNF, lineItem.VProd, x.ToString(), lineItem.CProd, lineItem.InfAdProd, lineItem.XProd, lineItem.PICMS, lineItem.VICMS, lineItem.VBC, infCpl, lineItem.NCM, lineItem.CFOP, lineItem.UCom, lineItem.QCom, lineItem.VUnCom, vFrete, vOutro, qVol, vProd2, xMotivo, dVenc, refNFe, cstat,pesoB,pesoL);
                            x++;
                        }
                    }
                    CFOP = "";
                    listaItem.Clear();
                    CNPJEmi = "";
                    xNomeEmi = "";
                    xFant = "";
                    nNF = "";
                    serie = "";
                    dEmi = "";
                    natOp = "";
                    tpNF = "";
                    cDV = "";
                    vNF = "";
                    vProd2 = "";
                    CNPJDest = "";
                    xNomeDest = "";
                    infCpl = "";
                    xMotivo = "";
                    vFrete = "";
                    vOutro = "";
                    dVenc = "";
                    refNFe = "";
                    cstat = "";
                    pesoB = "";
                    pesoL = "";


                    progressBar1.Value = progressBar1.Value + 1;
                }

            }
        }

        /*        private void LerXML()
                {

                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(@"c:\temp\a.xml");

                    Console.WriteLine("Recuperando todos os elementos Pedido e exibindo o seu respectivo id");

                    foreach (XmlNode xmlNode in xmlDocument.GetElementsByTagName("infCte"))
                        Console.WriteLine("Id do Pedido: {0}", xmlNode.Attributes["Id"].Value);



                    XmlTextReader tr = new XmlTextReader(@"c:\temp\a.xml");

                    while (tr.Read())
                    {
                        if (tr.IsStartElement())
                        {
                            if (tr.Name == "xNome")
                            {
                                tr.Read();
                                if (tr.NodeType == XmlNodeType.Text)
                                    System.Console.WriteLine(tr.Value);
                                //chave ID
                                // numero da nota nCT
                                //nome fornecedor xNome
                                //NCPJ CNPJ
                                //data dhEmi
                                //tipo mod (57 = YT 55 = YA)
                                //CNPJ tomador 
                                //Valor vTPrest
                            }
                        }
                    }
                }
         */
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
                                        xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
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
        private void Inserir(string nomeArquivo, string chNFe, string CNPJ, string xNome, string xFant, string CNPJDest, string xNomeDest, string nNF, string serie, string dEmi, string UF, string natOp, string tpNF, string cDV,
                             string vNF, string vProd, string detnItem, string cProd, string infAdProd, string xProd, string pICMS, string vICMS, string vBC, string infCpl, string NCM, string CFOP, string uCom, string qCom, string vUnCom,
                             string vFrete, string vOutro, string qVol, string vProd2, string xMotivo, string dVenc, string refNFe, string cStat , string pesoB, string pesoL)
        {
            dataGridView1.Rows.Add(nomeArquivo, chNFe, CNPJ, xNome, xFant, CNPJDest, xNomeDest, nNF, serie, dEmi, UF, natOp, tpNF, cDV, vNF, vProd, detnItem, cProd, infAdProd, xProd, pICMS, vICMS, vBC, infCpl, NCM, CFOP, uCom, qCom, vUnCom, vFrete, vOutro, qVol, vProd2, xMotivo, dVenc, refNFe, cStat, pesoB, pesoL);
        }

        private void btSalvarExcel_Click(object sender, EventArgs e)
        {
            SalvarExcel();            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}