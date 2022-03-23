using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace GedocLerXML
{
    public partial class AtualizaXML : Form
    {      
        //DEV
        //private string stringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCDBDEV01)(PORT= 1521)))(CONNECT_DATA=(SID=CRP01DEV)(SERVER=DEDICATED)));User Id=EEP_FINANCE;Password=eep_financeSAeep$dev";
        //PROD
        private static string stringDeConexao = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LDCRAC2-SCAN.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CRP01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_EGDOC;Password=FuncEnsA14";        
        public AtualizaXML()
        {
            InitializeComponent();
        }
        private void LerXML()
        {
            bool emit = false;
            bool ide = false;
            bool icms = false;
            bool inf = false;
            bool emitdest = false;

            string nNF = "";
            string serie = "";            
            string xNomeEmi = "";
            string CNPJEmi = "";
            string CNPJDest = "";
            string dEmi = "";
            string vNF = "";
            string tpNF = "";                     
            string chNFe = "";
            int ano = 0;

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

                    XmlTextReader tr = new XmlTextReader(fileinfo.DirectoryName + "\\" + fileinfo.Name);

                    while (tr.Read())
                    {
                        if (tr.IsStartElement())
                        {
                            if (tr.IsStartElement())
                            {
                                //-------------------------
                                if (tr.Name == "emit")
                                {
                                    emit = true;
                                    ide = false;
                                    icms = false;
                                    inf = false;
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
                                            CNPJEmi = tr.Value;
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
                                    /*if (tr.Name == "xNome")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            xNomeDest = tr.Value;
                                        }
                                    }*/


                                    if (tr.Name == "CNPJ" || tr.Name == "CPF")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            CNPJDest = tr.Value;
                                        }
                                        /*if (tr.Name == "xNome")
                                        {
                                            tr.Read();
                                            if (tr.NodeType == XmlNodeType.Text)
                                            {
                                                xNomeDest = tr.Value;
                                            }
                                        }*/
                                    }
                                }
                                if (tr.Name == "vPrest" || tr.Name == "retirada")
                                {
                                    emitdest = false;
                                }
                                //--------------------------
                                if (tr.Name == "ide")
                                {
                                    emit = false;
                                    ide = true;
                                    icms = false;
                                    inf = false;
                                    emitdest = false;
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
                                    if (tr.Name == "serie")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            serie = tr.Value;
                                        }
                                    }
                                    if (tr.Name == "dEmi" || tr.Name == "dhEmi" || tr.Name == "dhEvento")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            dEmi = tr.Value.Substring(0, 10);
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
                                }
                                //--------------------- 
                                if (tr.Name == "ICMSTot" || tr.Name == "vPrest")
                                {
                                    emit = false;
                                    ide = false;
                                    icms = true;
                                    inf = false;
                                    emitdest = false;
                                }                              
                                if (icms == true)
                                {                                    
                                    if (tr.Name == "vNF" || tr.Name == "vRec")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            vNF = tr.Value;
                                        }
                                    }
                                }
                                if (tr.Name == "infCTeNorm")
                                {
                                    icms = false;
                                }                              
                                //-----------------
                                if (tr.Name == "infProt")
                                {
                                    emit = false;
                                    ide = false;
                                    icms = false;
                                    inf = true;
                                    emitdest = false;
                                }
                                if (inf == true)
                                {
                                    if (tr.Name == "chNFe" || tr.Name == "chCTe")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            chNFe = tr.Value;
                                        }
                                    }
                                }
                                //-----------------                               
                            }
                        }
                    }
                    try
                    {
                        ano = Int32.Parse(dEmi.Substring(0, 4));
                    }
                    catch
                    {
                        ano = 0;
                    }
                
                    if (SelecionaXML(chNFe))
                    {
                        dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF , ano, 1 ); //Update XML
                        UpdateXML(chNFe);
                    }
                    else
                      /*  if (SelecionaXMLSAP(chNFe))
                        {
                            dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 2); //Update SAP
                            UpdateXMLSAP(chNFe);
                        }
                        else
                            if (ano < 2014)
                            {
                                dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 3); //Inset XML
                                InsertXML(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano);
                            }
                            else*/
                            {
                                dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 4); //Inset SAP
                                InsertXML(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano);
                            }

                    progressBar1.Value = progressBar1.Value + 1;
                }
            }        
        }
        private void LerXMLAutomatico()
        {
            bool emit = false;
            bool ide = false;
            bool icms = false;
            bool inf = false;
            bool emitdest = false;

            string nNF = "";
            string serie = "";
            string xNomeEmi = "";
            string CNPJEmi = "";
            string CNPJDest = "";
            string dEmi = "";
            string vNF = "";
            string tpNF = "";
            string chNFe = "";
            int ano = 0;

            progressBar1.Value = 0;

            DialogResult result = DialogResult.Yes;
            // bool importarBanco = true;


            DirectoryInfo diretorio = new DirectoryInfo(@"E:\Arquivos\GEDOC\Download\Programas\NFE");
            FileInfo[] Arquivos = diretorio.GetFiles("*.xml");
            progressBar1.Maximum = Arquivos.Count();
            foreach (FileInfo fileinfo in Arquivos)
            {                
                XmlTextReader tr = new XmlTextReader(fileinfo.DirectoryName + "\\" + fileinfo.Name);

                while (tr.Read())
                {
                    if (tr.IsStartElement())
                    {
                        if (tr.IsStartElement())
                        {
                            //-------------------------
                            if (tr.Name == "emit")
                            {
                                emit = true;
                                ide = false;
                                icms = false;
                                inf = false;
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
                                        CNPJEmi = tr.Value;
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
                                /*if (tr.Name == "xNome")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        xNomeDest = tr.Value;
                                    }
                                }*/


                                if (tr.Name == "CNPJ" || tr.Name == "CPF")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        CNPJDest = tr.Value;
                                    }
                                    /*if (tr.Name == "xNome")
                                    {
                                        tr.Read();
                                        if (tr.NodeType == XmlNodeType.Text)
                                        {
                                            xNomeDest = tr.Value;
                                        }
                                    }*/
                                }
                            }
                            if (tr.Name == "vPrest" || tr.Name == "retirada")
                            {
                                emitdest = false;
                            }
                            //--------------------------
                            if (tr.Name == "ide")
                            {
                                emit = false;
                                ide = true;
                                icms = false;
                                inf = false;
                                emitdest = false;
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
                                if (tr.Name == "serie")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        serie = tr.Value;
                                    }
                                }
                                if (tr.Name == "dEmi" || tr.Name == "dhEmi" || tr.Name == "dhEvento")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        dEmi = tr.Value.Substring(0, 10);
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
                            }
                            //--------------------- 
                            if (tr.Name == "ICMSTot" || tr.Name == "vPrest")
                            {
                                emit = false;
                                ide = false;
                                icms = true;
                                inf = false;
                                emitdest = false;
                            }
                            if (icms == true)
                            {
                                if (tr.Name == "vNF" || tr.Name == "vRec")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        vNF = tr.Value;
                                    }
                                }
                            }
                            if (tr.Name == "infCTeNorm")
                            {
                                icms = false;
                            }
                            //-----------------
                            if (tr.Name == "infProt")
                            {
                                emit = false;
                                ide = false;
                                icms = false;
                                inf = true;
                                emitdest = false;
                            }
                            if (inf == true)
                            {
                                if (tr.Name == "chNFe" || tr.Name == "chCTe")
                                {
                                    tr.Read();
                                    if (tr.NodeType == XmlNodeType.Text)
                                    {
                                        chNFe = tr.Value;
                                    }
                                }
                            }
                            //-----------------                               
                        }
                    }
                }
                tr.Dispose();
                try
                {
                    ano = Int32.Parse(dEmi.Substring(0, 4));
                }
                catch
                {
                    ano = 0;
                }
                if (SelecionaXML(chNFe))
                {
                    dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 1); //Update XML
                    UpdateXML(chNFe);
                    MoveArquivo(fileinfo);
                }
                else
                  /*  if (SelecionaXMLSAP(chNFe))
                    {
                        dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 2); //Update SAP
                        UpdateXMLSAP(chNFe);
                        MoveArquivo(fileinfo);
                    }
                    else
                        if (ano < 2014)
                        {
                            dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 3); //Inset XML
                            InsertXML(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano);
                            MoveArquivo(fileinfo);
                        }
                        else*/

                        {
                            dataGridView1.Rows.Add(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano, 4); //Inset SAP
                            InsertXML(chNFe, nNF, serie, xNomeEmi, CNPJEmi, CNPJDest, dEmi, tpNF, vNF, ano);
                            MoveArquivo(fileinfo);
                        }

                progressBar1.Value = progressBar1.Value + 1;
            }
        }
 /*       public bool SelecionaXML(string chave)
        {
            bool achou = false;
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT ID , DIRETORIO from EGDOC.GEDOC_XML WHERE CHAVE_NOTA =  '" + chave + "'";

                using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            if (dataReader.Read())
                            {
                                achou = true;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return achou;
        }
  */
        //public bool SelecionaXMLSAP(string chave)
        public bool SelecionaXML(string chave)
        {
            bool achou = false; 
            try
            {
                string sql;
                sql = "";
                sql += "  SELECT ID , DIRETORIO from EGEDOC.GEDOC_XML WHERE CHAVE_ACESSO = '" + chave + "'";

                using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                    {
                        using (OleDbDataReader dataReader = cmd.ExecuteReader()) //IDataReader
                        {
                            if (dataReader.Read())
                            {
                                achou = true;
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
            }
            return achou;
        }        

/*
        public void UpdateXML(string chave)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += "  UPDATE EGDOC.GEDOC_XML SET DIRETORIO = 'E:\\Arquivos\\GEDOC\\NF_ENT\\XML_SAP\\" + chave + ".xml' , STATUS = 'P' ";
                sql += "  WHERE CHAVE_NOTA  =  '" + chave + "'";


                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

            }
        }
 */
        //public void UpdateXMLSAP(string chave)
        public void UpdateXML(string chave)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += "  UPDATE EGEDOC.GEDOC_XML SET DIRETORIO = 'E:\\Arquivos\\GEDOC\\NF_ENT\\XML_SAP\\" + chave + ".xml' ";
                sql += "  WHERE CHAVE_ACESSO = '" + chave + "'";


                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {

            }
        }

    /*    public void InsertXML(string chNFe, string nNF, string serie, string xNomeEmi, string CNPJEmi, string CNPJDest, string dEmi, string tpNF, string vNF, int ano)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += " INSERT INTO EGDOC.GEDOC_XML  (    UO,    NUMERO_NOTA,    DATA_NOTA,    CHAVE_NOTA,    TOTAL,    FORNECEDOR,  DIRETORIO, OI , STATUS , TIPO) ";
                sql += "VALUES  ( '" + Convert.ToUInt64(CNPJDest).ToString(@"00\.000\.000\/0000\-00") + "' , '" + nNF + "', to_date('" + dEmi + "','YYYY-MM-DD'), '" + chNFe + "', to_number(" + vNF + "),  '" + xNomeEmi.Replace("'", "") + "', 'E:\\Arquivos\\GEDOC\\NF_ENT\\XML_SAP\\" + chNFe + ".xml' , '' , 'P' , 'ENTRADA')";

                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
     */
//public void InsertXMLSAP(string chNFe, string nNF, string serie, string xNomeEmi, string CNPJEmi, string CNPJDest, string dEmi, string tpNF, string vNF, int ano)
        public void InsertXML(string chNFe, string nNF, string serie, string xNomeEmi, string CNPJEmi, string CNPJDest, string dEmi, string tpNF, string vNF, int ano)
        {
            try
            {
                ///Metodo para Listar todos no banco
                ///                     

                string sql;
                sql = "";
                sql += " INSERT INTO EGEDOC.GEDOC_XML  (    NUMERO_NOTA,    TIPO_NOTA,    NOME_FORNECEDOR,    CNPJ,  LOCAL_NEGOCIO ,    DATA_DOCUMENTO,  EXERCICIO,    CHAVE_ACESSO,    VALOR,    DIRETORIO , CRIADOR_POR )";
                sql += " VALUES  ('" + nNF + '-' + serie + "' , '" + tpNF + "' , '" + xNomeEmi.Replace("'", "") + "' , '" + Convert.ToUInt64(CNPJEmi).ToString(@"00\.000\.000\/0000\-00") + "' , '" + Convert.ToUInt64(CNPJDest).ToString(@"00\.000\.000\/0000\-00") + "',  to_date('" + dEmi + "','YYYY-MM-DD'), " + ano + " , '" + chNFe + "' , to_number(" + vNF.Replace(",", "") + ") , 'E:\\Arquivos\\GEDOC\\NF_ENT\\XML_SAP\\" + chNFe + ".xml' , 'GEDOC')";

                // cmd.CommandType = CommandType.Text;
                try
                {
                    using (OleDbConnection conn = new OleDbConnection(stringDeConexao))
                    {
                        conn.Open();
                        using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MoveArquivo(FileInfo Arquivo)
        {
            string diretorioDestino = "E:\\Arquivos\\GEDOC\\NF_ENT\\XML_SAP\\" + Arquivo.Name;
            string diretorioOrigem = Arquivo.FullName;
            try
            {
                if (File.Exists(diretorioDestino))
                    File.Delete(diretorioDestino);
                File.Move(diretorioOrigem, diretorioDestino);                
            }
            catch (Exception e)
            {
//                MessageBox.Show(e.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LerXML();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Automatico.Enabled = false;
            LerXMLAutomatico();
            Application.Exit();
        }
    }
}
