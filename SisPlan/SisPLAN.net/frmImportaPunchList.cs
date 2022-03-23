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
    public partial class frmImportaPunchList : Form
    {
        //============================================
        static string usuarioPiloto = "anderson-souza";
        static string contrato = "Conversão";
        static string sbcnSigla = "P74";
        static string strSQL = "";
        static string pastaCodigo = "";
        string pendencia = "";
        string arpeDescricao = "";
        DataTable dt = null;
        DataTable dtAUX = null;

        static string repositoryFolder = "";
        static string exceptionFolder = "";
        static string handledFolder = "";
        static string safeFileName = "";
        string statusMovimentoDesc = "";
        public frmImportaPunchList()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            repositoryFolder =  @"SisPLAN.net\";
            GenericClasses.Util.CreateDefaultImportRepositoryFolder(repositoryFolder);
            exceptionFolder = GenericClasses.Util.GetUserDocumentFolderName() + repositoryFolder + @"Exceptions\";
            handledFolder = GenericClasses.Util.GetUserDocumentFolderName() + repositoryFolder + @"Handled\";

            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            gridView1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
        }
        //============================================
        public static List<String> GetSheetNames(OleDbConnection conn)
        {
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<String> Lista = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                Lista.Add(row["TABLE_NAME"].ToString());
            }
            conn.Close();
            return Lista;
        }
        //============================================
        public static DataTable ReadSpreadSheet(string connStr)
        {
            DataTable dt = null;
            try
            {
                OleDbConnection conn = new OleDbConnection(connStr);
                List<string> planilhas = GetSheetNames(conn);
                dt = null;

                strSQL = "SELECT * FROM [PENDENCIAS$] WHERE [Nº PASTA] IS NOT NULL";

                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private void btnReadXLS_Click(object sender, EventArgs e)
        {
            string connStr = GetConnectionString();
            dt = ReadSpreadSheet(connStr);

            gridView1.DataSource = dt;
            btnParseXLS.Visible = true;
        }
        //============================================
        private static string GetConnectionString()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Worksheets|*.xls";
            ofd.InitialDirectory = repositoryFolder;
            ofd.ShowDialog();
            PrepareFile(ofd);

            safeFileName = ofd.SafeFileName;
            //return string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;'", exceptionFolder + safeFileName);
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

                DTO.CollectionCpPastaDTO cp = new DTO.CollectionCpPastaDTO();

                for (int i = 0; i < maxLimit; i++)
                {
                    try 
                    {
                        pb.Value = i * 100 / maxLimit;
                        lblProgress.Text = (i+1).ToString() + " registros de " + maxLimit.ToString();
                        Application.DoEvents();

                        DTO.CpPunchlistDTO en = new DTO.CpPunchlistDTO();

                        pastaCodigo = Convert.ToString(dt.Rows[i]["Nº PASTA"]).Trim().Replace("  ", " ");
                        strSQL = @"SELECT PASTA_ID FROM EEP_CONVERSION.CP_PASTA WHERE PASTA_CODIGO = '" + pastaCodigo + "'";
                        dtAUX = BLL.CpPunchlistBLL.Select(strSQL);
                        if (dtAUX.Rows.Count == 0)
                        {
                            MessageBox.Show("A pasta " + pastaCodigo + " não existe no Sisplan.");
                        }
                        else
                        {
                            en.PunchPastaId = Convert.ToDecimal(dtAUX.Rows[0]["PASTA_ID"]);
                            en.PunchCntrCodigo = contrato;

                            en.PunchDescricao = dt.Rows[i]["DESCRIÇÃO"].ToString();
                            en.PunchTipeId = 2;

                            en.PunchResponsibleBy = dt.Rows[i]["RESP#"].ToString();

                            pendencia = dt.Rows[i]["DATA CONCLUSÃO DA PENDENCIA"].ToString();
                            en.PunchStpuId = 0;
                            en.PunchApprovedBy = "";
                            en.PunchApprovedDate = null;
                            if (pendencia == "")
                            {
                                en.PunchDataPrometida = null;
                                en.PunchDataConcluida = null;
                            }
                            else if (pendencia == "OK")
                            {
                                en.PunchStpuId = 1;
                                en.PunchDataPrometida = DateTime.Now;
                                en.PunchDataConcluida = DateTime.Now;
                                en.PunchApprovedBy = usuarioPiloto;
                                en.PunchApprovedDate = DateTime.Now;
                            }
                            else
                            {
                                en.PunchDataPrometida = Convert.ToDateTime(pendencia);
                                en.PunchDataConcluida = null;
                            }


                            en.PunchCreatedBy = usuarioPiloto;
                            en.PunchCreatedDate = System.DateTime.Now;

                            strSQL = @"SELECT ARPE_ID FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA WHERE UPPER(ARPE_AGENTE) = '" + en.PunchResponsibleBy.ToUpper() + "'";
                            dtAUX = BLL.CpPunchlistBLL.Select(strSQL);
                            en.PunchArpeId = 11;
                            if (dtAUX.Rows.Count > 0) en.PunchArpeId = Convert.ToDecimal(dtAUX.Rows[0]["ARPE_ID"]);
                            en.PunchSituacao = dt.Rows[i]["SITUAÇÃO"].ToString();
                            en.PunchImpeditiva = 1;

                            //Cria a Punch List no banco
                            BLL.CpPunchlistBLL.Insert(en, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                Application.DoEvents();
                FileInfo fi = new FileInfo(exceptionFolder + safeFileName);
                fi.MoveTo(handledFolder + safeFileName);
                MessageBox.Show(@"Pendências importadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //============================================
    }
}
