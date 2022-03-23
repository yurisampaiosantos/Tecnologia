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
    public partial class frmImportaPastas : Form
    {
        //============================================
        static string usuarioPiloto = "estevan.alamo";
        static string contrato = "Conversão";
        static string sbcnSigla = "P74";
        static string strSQL = "";
        DataTable dt = null;
        DataTable dtAUX = null;
        //decimal empNumber = 0;
        static string repositoryFolder = "";
        static string exceptionFolder = "";
        static string handledFolder = "";
        static string safeFileName = "";
        string statusMovimentoDesc = "";
        public frmImportaPastas()
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
            OleDbConnection conn = new OleDbConnection(connStr);
            List<string> planilhas = GetSheetNames(conn);
            dt = null;

            strSQL = "SELECT * FROM [GERAL$] WHERE CODIGO_PASTA IS NOT NULL";

            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
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
                    pb.Value = i * 100 / maxLimit;
                    lblProgress.Text = (i+1).ToString() + " registros de " + maxLimit.ToString();
                    Application.DoEvents();

                    DTO.CpPastaDTO en = new DTO.CpPastaDTO();
                    en.PastaCntrCodigo = contrato;
                    en.PastaSbcnSigla = Convert.ToString(dt.Rows[i]["FPSO"]).Trim().Replace("  ", " ").ToUpper();
                    en.PastaCodigo = Convert.ToString(dt.Rows[i]["CODIGO_PASTA"]).Trim().Replace("  ", " ");
                    en.PastaFase = Convert.ToString(dt.Rows[i]["FASE"]).Trim();
                    en.PastaBloco = Convert.ToString(dt.Rows[i]["BLOCO"]).Trim();

                    //if (Convert.ToString(dt.Rows[i]["FASE"]) == "2 e 4")
                    //{
                    //    string x = "";
                    //}

                    //if (Convert.ToString(dt.Rows[i]["BLOCO"]).Trim().Length > 2)
                    //{
                    //    string x = "";
                    //}
                    //if (en.PastaCodigo == "P74-5124.401-L06")
                    //{
                    //    string x = "";
                    //}
                    //SSOP
                    en.PastaSsopId = null;
                    string ssop = Convert.ToString(dt.Rows[i]["SSOP"]).Trim().Replace("  ", " ").Replace(".","-");
                    string descricao = Convert.ToString(dt.Rows[i]["DESCRICAO"]).Trim().Replace("  ", " ");
                    if (ssop == "")
                    {
                        ssop = "0";
                    }
                    if (descricao == "")
                    {
                        descricao = "SSOP SEM DESCRIÇÃO";
                    }
                    try
                    {
                        strSQL = "SELECT SSOP_ID, SSOP_CODIGO, SSOP_DESCRICAO FROM EEP_CONVERSION.CP_SUBSISTEMA_OPERACIONAL WHERE SSOP_CNTR_CODIGO = '" + contrato + "' AND SSOP_SBCN_SIGLA = '" + en.PastaSbcnSigla + "' AND UPPER(SSOP_CODIGO) = UPPER('" + ssop + "')";
                        dtAUX = BLL.CpPastaBLL.Select(strSQL);
                        DTO.CpSubsistemaOperacionalDTO subsistema = new DTO.CpSubsistemaOperacionalDTO();
                    
                        if (dtAUX.Rows.Count > 0)
                        {
                            try
                            {
                            en.PastaSsopId = Convert.ToDecimal(dtAUX.Rows[0]["SSOP_ID"]);
                        
                            subsistema = BLL.CpSubsistemaOperacionalBLL.GetObject("SSOP_ID = " + en.PastaSsopId.ToString());
                            subsistema.SsopCntrCodigo = contrato;
                            subsistema.SsopDescricao = descricao;
                            subsistema.SsopSbcnSigla = en.PastaSbcnSigla;

                            BLL.CpSubsistemaOperacionalBLL.Update(subsistema);
                            }
                            catch (Exception ex) { throw new Exception(ex.Message); }
                        }
                        else
                        {
                            try
                            {
                                //subsistema = BLL.CpSubsistemaOperacionalBLL.GetObject("SSOP_CNTR_CODIGO = '" + contrato + "' AND SSOP_SBCN_SIGLA = ' " + en.PastaSbcnSigla + "' AND SSOP_DESCRICAO = '" + descricao + "'");
                                subsistema.SsopCntrCodigo = contrato;
                                subsistema.SsopCodigo = ssop;
                                subsistema.SsopDescricao = descricao;
                                subsistema.SsopSbcnSigla = en.PastaSbcnSigla;
                                
                                BLL.CpSubsistemaOperacionalBLL.Insert(subsistema, false);
                                
                            }
                            catch (Exception ex) { throw new Exception(ex.Message); }
                        }
                    }
                    catch (Exception ex) { throw new Exception(ex.Message); }


                    en.PastaDiscId = GetDisciplina(i);

                    en.PastaAreaId = GetArea(i);

                    en.PastaEscoId = GetEscopo(i);

                    ////Data de Programação
                    //string dtProgramacaoPasta = Convert.ToString(dt.Rows[i]["DATA_PROGRAMACAO"]).Trim().Replace("  ", " ");
                    //if (dtProgramacaoPasta != "")
                    //{
                    //    en.PastaProg = Convert.ToDateTime(dtProgramacaoPasta);
                    //}

                    try
                    {
                        //Obtém Objeto Pasta
                        cp = BLL.CpPastaBLL.GetCollection("PASTA_CNTR_CODIGO = '" + contrato + "' AND PASTA_SBCN_SIGLA = '" + en.PastaSbcnSigla + "' AND PASTA_CODIGO = '" + en.PastaCodigo + "'");

                        //DataTable p = BLL.CpPastaBLL.Get("X.PASTA_CODIGO = '" + en.PastaCodigo  + "'");
                        if (cp.Count == 0)
                        {
                            //Cria a pasta no banco
                            en.PastaStpaId = 1;
                            en.PastaLocaId = GetLocalizacao(i);
                            BLL.CpPastaBLL.Insert(en, true);

                            //Cria o primeiro movimento
                            DTO.CpMovimentoDTO m = new DTO.CpMovimentoDTO();
                            m.MoviCntrCodigo = contrato;
                            m.MoviUsuaLogin = usuarioPiloto;
                            m.MoviCreatedBy = m.MoviUsuaLogin;
                            
                            //Obtém pastaId
                            DTO.CpPastaDTO pasta = new DTO.CpPastaDTO();
                            pasta = BLL.CpPastaBLL.GetObject("PASTA_CNTR_CODIGO = '" +  contrato + "' AND PASTA_SBCN_SIGLA = '" + en.PastaSbcnSigla + "' AND PASTA_CODIGO = '" + en.PastaCodigo + "'");
                            m.MoviPastaId = pasta.PastaId;

                            

                            //Obtém o Status Atual
                            //statusMovimentoAtual = 0;
                            statusMovimentoDesc = Convert.ToString(dt.Rows[i]["STATUS"]).Trim().Replace("  ", " ").Replace("- ", "-").Replace(" -", "-").Replace("-", " - ");

                            strSQL = @"SELECT STMO_ID FROM EEP_CONVERSION.CP_STATUS_MOVIMENTO WHERE STMO_DESCRICAO = '" + statusMovimentoDesc + "'";
                            dtAUX = BLL.CpPastaBLL.Select(strSQL);
                            if (dtAUX.Rows.Count == 0) m.MoviStmoId = 1;
                            else m.MoviStmoId = Convert.ToDecimal(dtAUX.Rows[0]["STMO_ID"]);

                            SetMoviUsuaLogin(statusMovimentoDesc, ref m, en);

                            //Insere primeiro Movimento
                            BLL.CpMovimentoBLL.Insert(m, false);
                        }
                        else
                        {
                            //Edita a pasta no banco
                            en.PastaStpaId = cp[0].PastaStpaId;
                            en.PastaId = cp[0].PastaId;
                            en.PastaLocaId = cp[0].PastaLocaId;
                            en.PastaFase = Convert.ToString(dt.Rows[i]["FASE"]).Trim().Replace("  ", " ");
                            en.PastaBloco = Convert.ToString(dt.Rows[i]["BLOCO"]).Trim().Replace("  ", " ");
                            en.PastaSbcnSigla = Convert.ToString(dt.Rows[i]["FPSO"]).Trim().Replace("  ", " ").ToUpper();
                            en.PastaDiscId = GetDisciplina(i);
                            en.PastaAreaId = GetArea(i);
                            en.PastaEscoId = GetEscopo(i);
                            
                            BLL.CpPastaBLL.Update(en);
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
                MessageBox.Show(@"Pastas importadas com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //============================================
        private decimal GetDisciplina(int i)
        {
            decimal discId = 0;
            //Disciplina
            try
            {
                string disciplina = Convert.ToString(dt.Rows[i]["DISCIPLINA"]).Trim().Replace("  ", " ");
                strSQL = "SELECT DISC_ID FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = '" + contrato + "' AND UPPER(DISC_NOME) = UPPER('" + disciplina + "')";
                dtAUX = BLL.CpPastaBLL.Select(strSQL);
                if (dtAUX.Rows.Count > 0) discId = Convert.ToDecimal(dtAUX.Rows[0]["DISC_ID"]);
                if (discId == 14) discId = 15;  //Se disciplina Equipamentos aplica em Mecânica
                return discId;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private decimal GetArea(int i)
        {
            decimal areaId = 0;
            //Área
            try
            {
                string area = Convert.ToString(dt.Rows[i]["AREA"]).Trim().Replace("  ", " ");
                strSQL = "SELECT AREA_ID FROM EEP_CONVERSION.CP_AREA WHERE AREA_CNTR_CODIGO = '" + contrato + "' AND UPPER(AREA_DESCRICAO) = UPPER('" + area + "')";
                dtAUX = BLL.CpPastaBLL.Select(strSQL);
                //areaId = null;
                if (dtAUX.Rows.Count > 0)
                {
                    if (Convert.ToDecimal(dtAUX.Rows[0]["AREA_ID"]) != null && dtAUX.Rows[0]["AREA_ID"] != DBNull.Value)
                    {
                        areaId = Convert.ToDecimal(dtAUX.Rows[0]["AREA_ID"]);
                    }
                }
                return areaId;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private decimal GetEscopo(int i)
        {
            decimal escoId = 0;
            try
            {
                //Escopo
                string escopo = Convert.ToString(dt.Rows[i]["ESCOPO"]).Trim().Replace("  ", " ");
                strSQL = "SELECT ESCO_ID FROM EEP_CONVERSION.CP_ESCOPO WHERE ESCO_CNTR_CODIGO = '" + contrato + "' AND UPPER(ESCO_DESCRICAO) = UPPER('" + escopo + "')";
                dtAUX = BLL.CpPastaBLL.Select(strSQL);
                if (dtAUX.Rows.Count > 0) escoId = Convert.ToDecimal(dtAUX.Rows[0]["ESCO_ID"]);
                return escoId;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private decimal GetLocalizacao(int i)
        {
            decimal locaId = 0;
            //Localização
            try
            {
                string localizacao = Convert.ToString(dt.Rows[i]["LOCALIZACAO"]).Trim().Replace("  ", " ");
                strSQL = "SELECT LOCA_ID FROM EEP_CONVERSION.CP_LOCALIZACAO WHERE LOCA_CNTR_CODIGO = '" + contrato + "' AND UPPER(LOCA_DESCRICAO) = UPPER('" + localizacao + "')";
                dtAUX = BLL.CpPastaBLL.Select(strSQL);
                if (dtAUX.Rows.Count > 0) locaId = Convert.ToDecimal(dtAUX.Rows[0]["LOCA_ID"]);
                return locaId;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private void SetMoviUsuaLogin(string statusMovimentoDesc, ref DTO.CpMovimentoDTO m, DTO.CpPastaDTO en)
        {
            m.MoviCreatedBy = "frederico.wilken";
            m.MoviUsuaLogin = "jefferson.silva";
            if (statusMovimentoDesc == "CM - REVISANDO DOCUMENTOS") m.MoviUsuaLogin = "estevan.alamo";
            else if (statusMovimentoDesc == "PL - EM PROGRAMAÇÃO DE PENDÊNCIAS") m.MoviUsuaLogin = "jefferson.silva";
            else if (statusMovimentoDesc == "PL - EM ANÁLISE") m.MoviUsuaLogin = "jefferson.silva";
            else if (statusMovimentoDesc == "PL - LIBERADO PARA MONTAGEM") m.MoviUsuaLogin = "jefferson.silva";
            else if (statusMovimentoDesc == "PR - EM MONTAGEM")
            {
              if (en.PastaDiscId == 6) m.MoviUsuaLogin = "andre.piraja";
              if (en.PastaDiscId == 5 && en.PastaAreaId == 2) m.MoviUsuaLogin = "manoel.oiveira";  //ER/PR
              if (en.PastaDiscId == 5 && en.PastaAreaId == 1) m.MoviUsuaLogin = "eduardo.faria";  //CASCO
              if (en.PastaDiscId == 5 && en.PastaAreaId == 4) m.MoviUsuaLogin = "joao.burgos";  //MS
            }
            else if (statusMovimentoDesc == "PR - ELIMINANDO PENDÊNCIAS") m.MoviUsuaLogin = "joao.burgos";
            else if (statusMovimentoDesc == "CQ - VALIDANDO DOCUMENTOS") m.MoviUsuaLogin = "carlos.correa";
            else if (statusMovimentoDesc == "CM - ANALISANDO PENDÊNCIAS") m.MoviUsuaLogin = "roger.rodrigues";
            else if (statusMovimentoDesc == "PL - EM PROGRAMAÇÃO DE PENDÊNCIAS") m.MoviUsuaLogin = "jefferson.silva";
            else if (statusMovimentoDesc == "CM - EM FINALIZAÇÃO") m.MoviUsuaLogin = "roger.rodrigues";
            else if (statusMovimentoDesc == "CQ - VERIFICAÇÃO COMPLETAÇÃO") m.MoviUsuaLogin = "carlos.andrade";
            else if (statusMovimentoDesc == "PNBV - EM ANÁLISE") m.MoviUsuaLogin = "nilton.moreira";
            else if (statusMovimentoDesc == "CM - EM MONTAGEM") m.MoviUsuaLogin = "joao.burgos";
            else if (statusMovimentoDesc == "CM - FINALIZADA") m.MoviUsuaLogin = "estevan.alamo";
        }
        //============================================
    }
}
