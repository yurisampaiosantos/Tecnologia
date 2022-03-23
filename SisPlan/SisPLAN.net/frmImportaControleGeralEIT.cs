using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Data.OleDb;
using System.IO;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Diagnostics;


namespace SisPLAN.net
{
    public partial class frmImportaControleGeralEIT : Form
    {
        //============================================
        DataTable dt = null;
        //decimal empNumber = 0;
        static string repositoryFolder = "";
        static string exceptionFolder = "";
        static string handledFolder = "";
        static string safeFileName = "";
        string contrato = "";
        string sbcnSigla = "";
        public frmImportaControleGeralEIT()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            repositoryFolder = @"F:\CONVERSÃO\PLANEJAMENTO\3-PCP\";
            exceptionFolder = repositoryFolder + @"Exceptions\";
            handledFolder = repositoryFolder + @"Handled\";

            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
        }
        //============================================
        private void btnReadXLS_Click(object sender, EventArgs e)
        {
            string connStr = GetConnectionString();
            dt = BLL.ElControleGeralEitBLL.ReadSpreadSheet(connStr);

            gridView1.DataSource = dt;
            btnParseXLS.Visible = true;
        }
        //============================================
        private static string GetConnectionString()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = repositoryFolder;
            ofd.ShowDialog();
            PrepareFile(ofd);

            //return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;'", ofd.FileName);
            //return string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'", exceptionFolder + safeFileName);
            safeFileName = ofd.SafeFileName;

            return string.Format(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=YES;IMEX=1;'", exceptionFolder + safeFileName);
        }
        //============================================
        private static void PrepareFile(OpenFileDialog ofd)
        {
            if (ofd.FileName != "")
            {
                FileInfo fi = new FileInfo(ofd.FileName);
                fi.CopyTo(exceptionFolder + ofd.SafeFileName, true);
                fi.Delete();
            }
        }
        //============================================
        private void btnParseXLS_Click(object sender, EventArgs e)
        {
            try
            {
                lblProgress.Visible = true;
                pb.Visible = true;
                int maxLimit = dt.Rows.Count;
                int c = 0;
                contrato = Convert.ToString(dt.Rows[0]["CONTRATO"]).Trim().Replace("  ", " ");
                sbcnSigla = Convert.ToString(dt.Rows[0]["SBCN_SIGLA"]).Trim().Replace("  ", " ");
                string strSQL = "DELETE FROM EEP_CONVERSION.EL_ATIV_X_CLASSE_X_LOCAL ";  //INICIALIZA TABELA COM ATIVIDADE x CLASSE x LOCAL (Entidade Relacional)
                BLL.ElControleGeralEitBLL.ExecuteSQLInstruction(strSQL);
                    
                strSQL = "DELETE FROM EEP_CONVERSION.EL_CONTROLE_GERAL_EIT ";
                BLL.ElControleGeralEitBLL.ExecuteSQLInstruction(strSQL);
                BLL.ElControleGeralEitBLL.ExecuteSQLInstruction("COMMIT");
                for (int i = 0; i < maxLimit; i++)
                {
                    //if (i == 14730)
                    //{
                    //    int x = 0;
                    //}
                    pb.Value = i * 100 / maxLimit;
                    lblProgress.Text = (i+1).ToString() + " registros de " + maxLimit.ToString();
                    Application.DoEvents();

                    DTO.ElControleGeralEitDTO en = new DTO.ElControleGeralEitDTO();
                    try
                    {
                    en.ClasseDisciplina = Convert.ToString(dt.Rows[i]["CLASSE_DISCIPLINA"]).Trim().Replace("  ", " ").ToUpper();
                    en.Criterio = Convert.ToString(dt.Rows[i]["CRITERIO"]).Trim().Replace("  ", " ");
                    en.Eap = Convert.ToString(dt.Rows[i]["EAP"]).Trim().Replace("  ", " ");
                    en.AtividadeCriterio = Convert.ToString(dt.Rows[i]["ATIVIDADE_CRITERIO"]).Trim().Replace("  ", " ");
                    en.TipoMaterial = Convert.ToString(dt.Rows[i]["TIPO_MATERIAL"]).Trim().Replace("  ", " ");
                    en.StatusEngenharia = Convert.ToString(dt.Rows[i]["STATUS_ENGENHARIA"]).Trim().Replace("  ", " ");
                    en.Desenho = Convert.ToString(dt.Rows[i]["DESENHO"]).Trim().Replace("  ", " ");
                    en.DesenhoRev = Convert.ToString(dt.Rows[i]["DESENHO_REV"]).Trim().Replace("  ", " ");
                    en.Regiao = Convert.ToString(dt.Rows[i]["REGIAO"]).Trim().Replace("  ", " ");
                    en.Local = Convert.ToString(dt.Rows[i]["LOCAL"]).Trim().Replace("  ", " ");
                    en.Tag = Convert.ToString(dt.Rows[i]["TAG"]).Trim().Replace("  ", " ");
                    en.Descricao = Convert.ToString(dt.Rows[i]["DESCRICAO"]).Trim().Replace("  ", " ");
                    en.QuantidadeProjeto = Convert.ToDecimal(dt.Rows[i]["QUANTIDADE_PROJETO"]);
                    en.UnmeSigla = Convert.ToString(dt.Rows[i]["UNME_SIGLA"]).Trim().Replace("  ", " ");
                    if ((dt.Rows[i]["AVANCO_FISICO"] != null) && (dt.Rows[i]["AVANCO_FISICO"] != DBNull.Value)) en.AvancoFisico = Convert.ToDecimal(dt.Rows[i]["AVANCO_FISICO"]);
                    en.Semana = Convert.ToString(dt.Rows[i]["SEMANA"]);
                    en.DiprCodigo = Convert.ToString(dt.Rows[i]["DIPR_CODIGO"]).Trim().Replace("  ", " ");
                    en.Reserva = Convert.ToString(dt.Rows[i]["RESERVA"]).Trim().Replace("  ", " ");
                    if ((dt.Rows[i]["BL_PROJECT_START"] != null) && (dt.Rows[i]["BL_PROJECT_START"] != DBNull.Value)) en.BlProjectStart = Convert.ToDateTime(dt.Rows[i]["BL_PROJECT_START"]);
                    if ((dt.Rows[i]["BL_PROJECT_FINISH"] != null) && (dt.Rows[i]["BL_PROJECT_FINISH"] != DBNull.Value)) en.BlProjectFinish = Convert.ToDateTime(dt.Rows[i]["BL_PROJECT_FINISH"]);
                    en.PastaCodigo = Convert.ToString(dt.Rows[i]["PASTA_CODIGO"]).Trim().Replace("  ", " ");
                    en.Ssop = Convert.ToString(dt.Rows[i]["SSOP"]).Trim().Replace("  ", " ");
                    en.Fase = Convert.ToString(dt.Rows[i]["FASE"]).Trim().Replace("  ", " ");
                    en.Bloco = Convert.ToString(dt.Rows[i]["BLOCO"]).Trim().Replace("  ", " ");
                    en.DesReferencia = Convert.ToString(dt.Rows[i]["DES_REFERENCIA"]).Trim().Replace("  ", " ");
                    en.RM = Convert.ToString(dt.Rows[i]["RM"]).Trim().Replace("  ", " ");
                    en.RmRev = Convert.ToString(dt.Rows[i]["RM_REV"]).Trim().Replace("  ", " ");
                    en.Afs = Convert.ToString(dt.Rows[i]["AFS"]).Trim().Replace("  ", " ");
                    if ((dt.Rows[i]["DATA_NECESSARIA"] != null) && (dt.Rows[i]["DATA_NECESSARIA"] != DBNull.Value)) en.DataNecessaria = Convert.ToDateTime(dt.Rows[i]["DATA_NECESSARIA"]);
                    en.StatusChegada = Convert.ToString(dt.Rows[i]["STATUS_CHEGADA"]).Trim().Replace("  ", " ");
                    if ((dt.Rows[i]["INDICE"] != null) && (dt.Rows[i]["INDICE"] != DBNull.Value)) en.Indice = Convert.ToDecimal(dt.Rows[i]["INDICE"]);
                    en.FotaId = Convert.ToDecimal(dt.Rows[i]["FORCA_TAREFA"]);
                    en.SbcnSigla = Convert.ToString(dt.Rows[i]["SBCN_SIGLA"]).Trim().Replace("  ", " ");
                    en.Contrato = Convert.ToString(dt.Rows[i]["CONTRATO"]).Trim().Replace("  ", " ");
                    en.Produtividade = Convert.ToDecimal(dt.Rows[i]["PRODUTIVIDAE"]);
                   
                    //if (en.DescricaoEstrutura != null && en.DescricaoEstrutura != "")
                    //{
                        //c = BLL.AcItemControleBLL.Count("UPPER(DESCRICAO_ESTRUTURA) = '" + en.DescricaoEstrutura.ToUpper() + "'");
                        //c = BLL.ElControleGeralEitBLL.CountByDescricaoEstrutura(en.DescricaoEstrutura.ToUpper());
                        //if (c == 0) BLL.ElControleGeralEitBLL.Insert(en, false);
                    BLL.ElControleGeralEitBLL.Insert(en, false);
                    IncrementaTAG(en);

                        //else BLL.ElControleGeralEitBLL.Update(en);
                    //}
                    }
            catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                        
                }
                Application.DoEvents();
                FileInfo fi = new FileInfo(exceptionFolder + safeFileName);
                fi.MoveTo(handledFolder + safeFileName);
                MessageBox.Show(@"Itens de Controle importados com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //============================================
        private void IncrementaTAG(DTO.ElControleGeralEitDTO en)
        {
            throw new NotImplementedException();
        }
        //============================================

        public static void WriteCSV(string strFileName, DataTable tbl)
        {
            try
            {
                StringBuilder strResult = new StringBuilder();
                foreach(DataColumn col in tbl.Columns) 
                { 
                    strResult.Append(@""" " + col.ColumnName + @" "",");
                }
                //strResult.Append(vbNewLine)
                //string CRLF = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); 


                foreach(DataRow row in tbl.Rows)
                {
                    foreach(DataColumn col in tbl.Columns)
                    {
                        strResult.Append(@"""" + col.ColumnName.ToString() + @""",");
                    }
                    //strResult.Append(vbNewLine)
                    //string CRLF = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); 
                }
                

                HttpContext.Current.Response.Expires = 0;
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "inline;filename=" + strFileName + "");
                HttpContext.Current.Response.AddHeader("Content-type", "application/vnd.ms-excel");
                HttpContext.Current.Response.Write(strResult.ToString());
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}



/*
 string connStr = "";
            string provider;
            string dataSource;
            //string file;
            string properties;
            string A = Convert.ToChar(34).ToString();
            
            //string folder = @"D:\Users\Paulo\Paulo\Visual Studio 2010\Projects\VSTO\Documents\Moldurarte\";
            //string folder = @"D:\Desktop\VSTO\";
            //string folder = @"D:\Documentos\_EEPSA\Comissionamento\PlanilhasFIC\";
            //file = @"TABELA DE PREÇO ATUALIZADA A-3 DE 27-02-2012- ICMS 12%.xls;";
            //file = @"impFolhaServicoMedicao_2003.xls;";
            //file = @"6.5.malha.xls;";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\Documentos\_EEPSA\Comissionamento\PlanilhasFIC\";
            ofd.ShowDialog();
            provider = @"Provider=Microsoft.Jet.Oledb.4.0;";
            dataSource = @"Data Source=";
            properties = @"Extended Properties=" + A + @"Excel 8.0;HDR=Yes;IMEX=1" + A;
            //connStr = provider + dataSource + file + properties;
            connStr = provider + dataSource + ofd.FileName + ";" + properties;
            return connStr;
 */




//Código para ler Todas as Worksheets de todos os Workbooks (xls) de um diretório
/*
 /// <summary>
/// This method retrieves the excel sheet names from 
/// an excel workbook.
/// </summary>
/// <param name="excelFile">The excel file.</param>
/// <returns>String[]</returns>
private String[] GetExcelSheetNames(string excelFile)
{
    OleDbConnection objConn = null;
    System.Data.DataTable dt = null;
    try
    {
        // Connection String. Change the excel file to the file you
        // will search.
        String connString = "Provider=Microsoft.Jet.OLEDB.4.0;" + 
          "Data Source=" + excelFile + ";Extended Properties=Excel 8.0;";
        // Create connection object by using the preceding connection string.
        objConn = new OleDbConnection(connString);
        // Open connection with the database.
        objConn.Open();
        // Get the data table containg the schema guid.
        dt = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        if(dt == null)
        {
           return null;
        }
        String[] excelSheets = new String[dt.Rows.Count];
        int i = 0;
        // Add the sheet name to the string array.
        foreach(DataRow row in dt.Rows)
        {
           excelSheets[i] = row["TABLE_NAME"].ToString();
           i++;
        }
        // Loop through all of the sheets if you want too...
        for(int j=0; j < excelSheets.Length; j++)
        {
            // Query each excel sheet.
        }
        return excelSheets;
   }
   catch(Exception ex)
   {
       return null;
   }
   finally
   {
      // Clean up.
      if(objConn != null)
      {
          objConn.Close();
          objConn.Dispose();
      }
      if(dt != null)
      {
          dt.Dispose();
      }
   }
}
*/