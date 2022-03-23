using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

using System.Data.OleDb;
using System.IO.Compression;

namespace wfaFTPTeewe
{
    public partial class frmFTP : Form
    {
        public frmFTP()
        {
            InitializeComponent();
            GerarArquivo();
            fechar.Enabled = true;
        }
        private void EnviarFTP(string caminho)
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            try
            {
                //define os requesitos para se conectar com o servidor
                FileInfo arquivo = new FileInfo(caminho);
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://ftp.cloud.teewe.com.br/01EEP/SISEPC/" + arquivo.Name));
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential("ftp_eep01_sisepc", "#2sisepc*9");

                //Seleção do arquivo a ser enviado
               
                byte[] fileContents = new byte[arquivo.Length];

                using (FileStream fr = arquivo.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(arquivo.Length));
                }

                using (Stream writer = ftpRequest.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //obtem o FtpWebResponse da operação de upload
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                //MessageBox.Show(ftpResponse.StatusDescription);
            }
            catch (WebException webex)
            {
                MessageBox.Show(webex.ToString());
            }
            ExcluirArquivo(caminho);
        }    
        private void GerarArquivo()
        {
            //string de conexao
            string conexaoEPCCQ = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCJUDB01.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CJU01.intranet.local)(SERVER=DEDICATED)));User Id=F_APP_TEEWE;Password=eTeeweora14";
            string conexaoConversion = "Provider=OraOLEDB.Oracle;Data Source=(DESCRIPTION=(CID=GTU_APP)(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=LCJUDB01.intranet.local)(PORT= 1521)))(CONNECT_DATA=(SERVICE_NAME=CJU01.intranet.local)(SERVER=DEDICATED)));User Id=F_GL_CONVERSION;Password=estaleiroSAF_GL_CONVERSION2013";
            //exclui os arquivos CSV
            ExcluirArquivo(@"c:\temp\teeWe\teeWe_query_EPCCQ.csv");
            ExcluirArquivo(@"c:\temp\teeWe\teeWe_query_EEP_CONVERSION.csv");
            //gerar os arquivos CSV
            ExportaCSV(conexaoEPCCQ, epccq.Text, @"c:\temp\teeWe\teeWe_query_EPCCQ.csv");
            ExportaCSV(conexaoConversion, conversion.Text, @"c:\temp\teeWe\teeWe_query_EEP_CONVERSION.csv");
            //Zipa os Arquivos CSV
            string startPath = @"c:\temp\teeWe";
            string zipPath = @"c:\temp\"+DateTime.Now.Date.ToString("ddMMyyyy")+".zip";
            ZipFile.CreateFromDirectory(startPath, zipPath);
            //Envia por FTP
            EnviarFTP(zipPath);
        }
        private void ExportaCSV(string conexao, string sql, string diretorio )
        {
            OleDbConnection con = new OleDbConnection(conexao);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                using (con)
                {
                    con.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();

                    DataSet ds = new DataSet();

                    if (reader != null)
                    {
                        ds.Load(reader, LoadOption.OverwriteChanges, string.Empty);
                    }
                    using (StreamWriter sw = new StreamWriter(diretorio,true, Encoding.GetEncoding(1252)))
                    {
                        foreach (DataColumn column in ds.Tables[0].Columns)
                        {
                            sw.Write((column.ColumnName) + ";");
                        }
                        sw.WriteLine();

                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                            {
                                sw.Write((row[i].ToString()) + ";");
                            }

                            sw.WriteLine();
                        }
                        sw.Close();
                    }
                    con.Close();
                }
            }
            catch (System.IO.IOException e) {
                con.Close();
                MessageBox.Show(e.ToString()); 
            }
        }
        private void ExcluirArquivo(string caminho)
        {
            if (System.IO.File.Exists(caminho))
            {
                try
                {
                    System.IO.File.Delete(caminho);
                }
                catch (System.IO.IOException e)
                {
                   // MessageBox.Show(e.ToString());
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }

}
