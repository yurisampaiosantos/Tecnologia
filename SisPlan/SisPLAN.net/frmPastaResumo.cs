using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Microsoft.Reporting.WinForms;
//using System.Xml.Serialization;


namespace SisPLAN.net
{
    public partial class frmPastaResumo : Form
    {
        string userName = "";
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";
        string fpso = "";
        decimal usuaClasse = 1000;
        string discSigla = "";
        string filter = "";
        string strSQL = "";
        string titulo = "";
        DataTable dtDOC = null;
        DataTable dtDestinos = null;
        DataTable dtVwCpPastaResumo = null;
        DataRow[] row = null;
        static string lf = Convert.ToChar(10).ToString();
        DTO.CpPrevistoDTO p = new DTO.CpPrevistoDTO();
        DTO.CpPastaResumoDTO r = new DTO.CpPastaResumoDTO();

        //===================================================================================
        public frmPastaResumo()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmPastaResumo_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 200;

            DTO.CollectionCpUsuarioDTO cu = new DTO.CollectionCpUsuarioDTO();
            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToLower(); //Domínio + Login
            cu = BLL.CpUsuarioBLL.GetCollection("UPPER(USUA_LOGIN) = '" + userName.ToUpper() + "'");
            usuaClasse = cu[0].UsuaClasse;
            Application.DoEvents();

            //cmbFPSO
            strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                     @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 2 AS SBCN_ID, 'P75' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL UNION " +
                     @"SELECT 4 AS SBCN_ID, 'P77' AS SBCN_SIGLA from DUAL " +
                     @"ORDER  BY 1 NULLS FIRST";

            dtDOC = BLL.CpPastaResumoBLL.Select(strSQL);
            cmbFPSO.DataSource = dtDOC;
            cmbFPSO.DisplayMember = "SBCN_SIGLA";
            cmbFPSO.ValueMember = "SBCN_ID";

            if (usuaClasse <= 15)
            {
                p = GenericClasses.XML.DeserializaArquivoXML(p, @"F:\CONVERSÃO\PLANEJAMENTO\23-Comissionamento\PrevisaoPastas.xml");
                ExibePrevisto(p);
            }
            else
            {
                MessageBox.Show("Usuário sem credenciamento para emissão de relatório");
            }

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void ExibePrevisto(DTO.CpPrevistoDTO p)
        {
            txtCascoMec.Text = p.CascoMec.ToString();
            txtCascoTub.Text = p.CascoTub.ToString();
            txtCascoEle.Text = p.CascoEle.ToString();
            txtCascoIns.Text = p.CascoIns.ToString();
            txtCascoTlc.Text = p.CascoTlc.ToString();

            txtErprMec.Text = p.ErprMec.ToString();
            txtErprTub.Text = p.ErprTub.ToString();
            txtErprEle.Text = p.ErprEle.ToString();
            txtErprIns.Text = p.ErprIns.ToString();
            txtErprTlc.Text = p.ErprTlc.ToString();

            txtMsMec.Text = p.MsMec.ToString();
            txtMsTub.Text = p.MsTub.ToString();
            txtMsEle.Text = p.MsEle.ToString();
            txtMsIns.Text = p.MsIns.ToString();
            txtMsTlc.Text = p.MsTlc.ToString();

            txtMaMec.Text = p.MaMec.ToString();
            txtMaTub.Text = p.MaTub.ToString();
            txtMaEle.Text = p.MaEle.ToString();
            txtMaIns.Text = p.MaIns.ToString();
            txtMaTlc.Text = p.MaTlc.ToString();

            if (usuaClasse > 5)
            {
                txtCascoMec.Enabled = false;
                txtCascoTub.Enabled = false;
                txtCascoEle.Enabled = false;
                txtCascoIns.Enabled = false;
                txtCascoTlc.Enabled = false;
                          
                txtErprMec.Enabled = false;
                txtErprTub.Enabled = false;
                txtErprEle.Enabled = false;
                txtErprIns.Enabled = false;
                txtErprTlc.Enabled = false;
                           
                txtMsMec.Enabled = false;
                txtMsTub.Enabled = false;
                txtMsEle.Enabled = false;
                txtMsIns.Enabled = false;
                txtMsTlc.Enabled = false;
                         
                txtMaMec.Enabled = false;
                txtMaTub.Enabled = false;
                txtMaEle.Enabled = false;
                txtMaIns.Enabled = false;
                txtMaTlc.Enabled = false;
            }
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = @"1 = 1";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND X.PARE_SBCN_SIGLA = '" + cmbFPSO.Text + "'";
            return sRet;
        }
        //===================================================================================
        private void PrepareReport(string filter, string fpso)
        {

            //Prepara os Destinos de pastas para a FPSO
            strSQL = @"SELECT SMGR_DESCRICAO FROM EEP_CONVERSION.CP_STATUS_MOVIMENTO_GRUPO ORDER BY SMGR_SEQUENCE";
            dtDestinos = BLL.VwCpPastaUltMovBLL.Select(strSQL);
            //Prepara Situação das Pastas
            PreparaSituacao(fpso, ref r);
            //Salva Previsto
            SalvaPrevisto();

            //Carrega o Resumo de pastas para a FPSO
            strSQL = @"SELECT PASTA_SBCN_SIGLA, LOCA_DESCRICAO, SMGR_DESCRICAO,  AREA_DESCRICAO,  DISC_SIGLA,  QUANTIDADE FROM EEP_CONVERSION.VW_CP_PASTA_RESUMO WHERE PASTA_SBCN_SIGLA = '" + fpso + "' ORDER BY 1,2,3,4";
            dtVwCpPastaResumo = BLL.VwCpPastaUltMovBLL.Select(strSQL);

            //Calcula a Situação das Pastas
            CalculaSituacao(fpso, ref r);
            CalculaTotaisDestino(fpso);
            CalculaTotais(fpso);
        }
        //===================================================================================
        private void PreparaSituacao(string fpso, ref DTO.CpPastaResumoDTO r)
        {
            try
            {
                //Os agrupamentos na tabela CP_PASTA_RESUMO
                for (int i = 0; i < dtDestinos.Rows.Count; i++)
                {
                    r.PareSbcnSigla = fpso;
                    r.PareSmgrDescricao = dtDestinos.Rows[i]["SMGR_DESCRICAO"].ToString();
                    BLL.CpPastaResumoBLL.Insert(r, false);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message + " - PreparaSituacao"); }
        }
        //===================================================================================
        private void SalvaPrevisto()
        {
            p.CascoMec = Convert.ToDecimal(txtCascoMec.Text);
            p.CascoTub = Convert.ToDecimal(txtCascoTub.Text);
            p.CascoEle = Convert.ToDecimal(txtCascoEle.Text);
            p.CascoIns = Convert.ToDecimal(txtCascoIns.Text);
            p.CascoTlc = Convert.ToDecimal(txtCascoTlc.Text);
            p.CascoTot = p.CascoMec + p.CascoTub + p.CascoEle + p.CascoIns + p.CascoTlc;

            p.ErprMec = Convert.ToDecimal(txtErprMec.Text);
            p.ErprTub = Convert.ToDecimal(txtErprTub.Text);
            p.ErprEle = Convert.ToDecimal(txtErprEle.Text);
            p.ErprIns = Convert.ToDecimal(txtErprIns.Text);
            p.ErprTlc = Convert.ToDecimal(txtErprTlc.Text);
            p.ErprTot = p.ErprMec + p.ErprTub + p.ErprEle + p.ErprIns + p.ErprTlc;

            p.MsMec = Convert.ToDecimal(txtMsMec.Text);
            p.MsTub = Convert.ToDecimal(txtMsTub.Text);
            p.MsEle = Convert.ToDecimal(txtMsEle.Text);
            p.MsIns = Convert.ToDecimal(txtMsIns.Text);
            p.MsTlc = Convert.ToDecimal(txtMsTlc.Text);
            p.MsTot = p.MsMec + p.MsTub + p.MsEle + p.MsIns + p.MsTlc;

            p.MaMec = Convert.ToDecimal(txtMaMec.Text);
            p.MaTub = Convert.ToDecimal(txtMaTub.Text);
            p.MaEle = Convert.ToDecimal(txtMaEle.Text);
            p.MaIns = Convert.ToDecimal(txtMaIns.Text);
            p.MaTlc = Convert.ToDecimal(txtMaTlc.Text);
            p.MaTot = p.MaMec + p.MaTub + p.MaEle + p.MaIns + p.MaTlc;

            GenericClasses.XML.SerializaArquivoXML(p, @"F:\CONVERSÃO\PLANEJAMENTO\23-Comissionamento\PrevisaoPastas.xml");

            r.PareSbcnSigla = fpso;
            //r.PareLocaDescricao = "";
            r.PareSmgrDescricao = "TOTAL PREVISTO";
            //r.PareAreaDescricao = "";
            strSQL = @"UPDATE EEP_CONVERSION.CP_PASTA_RESUMO SET";
            strSQL += @" PARE_SBCN_SIGLA = '" + fpso + "', ";
            strSQL += " PARE_CASCO_MEC = " + p.CascoMec.ToString() + ", ";
            strSQL += " PARE_CASCO_TUB = " + p.CascoTub.ToString() + ", ";
            strSQL += " PARE_CASCO_ELE = " + p.CascoEle.ToString() + ", ";
            strSQL += " PARE_CASCO_INS = " + p.CascoIns.ToString() + ", ";
            strSQL += " PARE_CASCO_TLC = " + p.CascoTlc.ToString() + ", ";
            strSQL += " PARE_CASCO_TOTAL = " + p.CascoTot.ToString()+ ", ";
           
            strSQL += " PARE_ERPR_MEC = " + p.ErprMec.ToString() + ", ";
            strSQL += " PARE_ERPR_TUB = " + p.ErprTub.ToString() + ", ";
            strSQL += " PARE_ERPR_ELE = " + p.ErprEle.ToString() + ", ";
            strSQL += " PARE_ERPR_INS = " + p.ErprIns.ToString() + ", ";
            strSQL += " PARE_ERPR_TLC = " + p.ErprTlc.ToString() + ", ";
            strSQL += " PARE_ERPR_TOTAL = " + p.ErprTot.ToString()+ ", ";
            
            strSQL += " PARE_MS_MEC = " + p.MsMec.ToString() + ", ";
            strSQL += " PARE_MS_TUB = " + p.MsTub.ToString() + ", ";
            strSQL += " PARE_MS_ELE = " + p.MsEle.ToString() + ", ";
            strSQL += " PARE_MS_INS = " + p.MsIns.ToString() + ", ";
            strSQL += " PARE_MS_TLC = " + p.MsTlc.ToString() + ", ";
            strSQL += " PARE_MS_TOTAL = " + p.MsTot.ToString()+ ", ";

            strSQL += " PARE_MA_MEC = " + p.MaMec.ToString() + ", ";
            strSQL += " PARE_MA_TUB = " + p.MaTub.ToString() + ", ";
            strSQL += " PARE_MA_ELE = " + p.MaEle.ToString() + ", ";
            strSQL += " PARE_MA_INS = " + p.MaIns.ToString() + ", ";
            strSQL += " PARE_MA_TLC = " + p.MaTlc.ToString() + ", ";
            strSQL += " PARE_MA_TOTAL = " + p.MaTot.ToString() ;

            strSQL += @" WHERE";
            strSQL += @" PARE_SBCN_SIGLA = '" + r.PareSbcnSigla + "' AND ";
            strSQL += @" PARE_SMGR_DESCRICAO = '" + r.PareSmgrDescricao + "'";

            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
        }
        //===================================================================================
        private void CalculaSituacao(string fpso, ref DTO.CpPastaResumoDTO r)
        {
            string areaAux = "";
            decimal qtd = 0;
            int limit = dtVwCpPastaResumo.Rows.Count;
;
            for (int i = 0; i < limit; i++)
            {
                qtd = Convert.ToDecimal(dtVwCpPastaResumo.Rows[i]["QUANTIDADE"]);
                if (i == 63)
                { }
                r.PareSbcnSigla = fpso;
                r.PareLocaDescricao = dtVwCpPastaResumo.Rows[i]["LOCA_DESCRICAO"].ToString();
                r.PareSmgrDescricao = dtVwCpPastaResumo.Rows[i]["SMGR_DESCRICAO"].ToString();
                r.PareAreaDescricao = dtVwCpPastaResumo.Rows[i]["AREA_DESCRICAO"].ToString();
                areaAux = r.PareAreaDescricao.Replace(@"/", "");
                discSigla = dtVwCpPastaResumo.Rows[i]["DISC_SIGLA"].ToString();

                switch (areaAux)
                {
                    case "CASCO":
                        {
                            switch (discSigla)
                            {
                                case "MEC": { r.PareCascoMec = qtd; break; }
                                case "TUB": { r.PareCascoTub = qtd; break; }
                                case "ELE": { r.PareCascoEle = qtd; break; }
                                case "INS": { r.PareCascoIns = qtd; break; }
                                case "TLC": { r.PareCascoTlc = qtd; break; }
                            } 
                            break;
                        }
                    case "ERPR":
                        {
                            switch (discSigla)
                            {
                                case "MEC": { r.PareErprMec = qtd; break; }
                                case "TUB": { r.PareErprTub = qtd; break; }
                                case "ELE": { r.PareErprEle = qtd; break; }
                                case "INS": { r.PareErprIns = qtd; break; }
                                case "TLC": { r.PareErprTlc = qtd; break; }
                            }
                            break;
                        }
                    case "MS":
                        {
                            switch (discSigla)
                            {
                                case "MEC": { r.PareMsMec = qtd; break; }
                                case "TUB": { r.PareMsTub = qtd; break; }
                                case "ELE": { r.PareMsEle = qtd; break; }
                                case "INS": { r.PareMsIns = qtd; break; }
                                case "TLC": { r.PareMsTlc = qtd; break; }
                            }
                            break;
                        }
                    case "MA":
                        {
                            switch (discSigla)
                            {
                                case "MEC": { r.PareMaMec = qtd; break; }
                                case "TUB": { r.PareMaTub = qtd; break; }
                                case "ELE": { r.PareMaEle = qtd; break; }
                                case "INS": { r.PareMaIns = qtd; break; }
                                case "TLC": { r.PareMaTlc = qtd; break; }
                            }
                            break;
                        }
                }

                SavePastaResumo(r);
            }
            //return qtd;
        }
        //===================================================================================
        private void CalculaTotaisDestino(string fpso)
        {
            DataTable dtD = null;
            strSQL = @"SELECT PARE_ID,
                              PARE_CASCO_MEC,  PARE_CASCO_TUB,  PARE_CASCO_ELE,  PARE_CASCO_INS,  PARE_CASCO_TLC,
                              PARE_ERPR_MEC,  PARE_ERPR_TUB,  PARE_ERPR_ELE,  PARE_ERPR_INS,  PARE_ERPR_TLC,
                              PARE_MS_MEC,  PARE_MS_TUB,  PARE_MS_ELE,  PARE_MS_INS,  PARE_MS_TLC,
                              PARE_MA_MEC,  PARE_MA_TUB,  PARE_MA_ELE,  PARE_MA_INS,  PARE_MA_TLC
                         FROM EEP_CONVERSION.CP_PASTA_RESUMO 
                        WHERE PARE_SBCN_SIGLA = '" + fpso + @"'
                        ORDER BY PARE_ID";
            dtD = BLL.CpPastaResumoBLL.Select(strSQL);
            for (int i = 0; i < dtD.Rows.Count; i++)
            {
                decimal pareId = Convert.ToDecimal(dtD.Rows[i]["PARE_ID"]);

                decimal pareCascoMec = Convert.ToDecimal(dtD.Rows[i]["PARE_CASCO_MEC"]);
                decimal pareCascoTub = Convert.ToDecimal(dtD.Rows[i]["PARE_CASCO_TUB"]);
                decimal pareCascoEle = Convert.ToDecimal(dtD.Rows[i]["PARE_CASCO_ELE"]);
                decimal pareCascoIns = Convert.ToDecimal(dtD.Rows[i]["PARE_CASCO_INS"]);
                decimal pareCascoTlc = Convert.ToDecimal(dtD.Rows[i]["PARE_CASCO_TLC"]);

                decimal pareErprMec = Convert.ToDecimal(dtD.Rows[i]["PARE_ERPR_MEC"]);
                decimal pareErprTub = Convert.ToDecimal(dtD.Rows[i]["PARE_ERPR_TUB"]);
                decimal pareErprEle = Convert.ToDecimal(dtD.Rows[i]["PARE_ERPR_ELE"]);
                decimal pareErprIns = Convert.ToDecimal(dtD.Rows[i]["PARE_ERPR_INS"]);
                decimal pareErprTlc = Convert.ToDecimal(dtD.Rows[i]["PARE_ERPR_TLC"]);

                decimal pareMsMec = Convert.ToDecimal(dtD.Rows[i]["PARE_MS_MEC"]);
                decimal pareMsTub = Convert.ToDecimal(dtD.Rows[i]["PARE_MS_TUB"]);
                decimal pareMsEle = Convert.ToDecimal(dtD.Rows[i]["PARE_MS_ELE"]);
                decimal pareMsIns = Convert.ToDecimal(dtD.Rows[i]["PARE_MS_INS"]);
                decimal pareMsTlc = Convert.ToDecimal(dtD.Rows[i]["PARE_MS_TLC"]);

                decimal pareMaMec = Convert.ToDecimal(dtD.Rows[i]["PARE_MA_MEC"]);
                decimal pareMaTub = Convert.ToDecimal(dtD.Rows[i]["PARE_MA_TUB"]);
                decimal pareMaEle = Convert.ToDecimal(dtD.Rows[i]["PARE_MA_ELE"]);
                decimal pareMaIns = Convert.ToDecimal(dtD.Rows[i]["PARE_MA_INS"]);
                decimal pareMaTlc = Convert.ToDecimal(dtD.Rows[i]["PARE_MA_TLC"]);

                decimal pareCascoTotal = pareCascoMec + pareCascoTub + pareCascoEle + pareCascoIns + pareCascoTlc;
                decimal pareErprTotal = pareErprMec + pareErprTub + pareErprEle + pareErprIns + pareErprTlc;
                decimal pareMsTotal = pareMsMec + pareMsTub + pareMsEle + pareMsIns + pareMsTlc;
                decimal pareMaTotal = pareMaMec + pareMaTub + pareMaEle + pareMaIns + pareMaTlc;

                decimal pareTotalMec = pareCascoMec + pareErprMec + pareMsMec + pareMaMec;
                decimal pareTotalTub = pareCascoTub + pareErprTub + pareMsTub + pareMaTub;
                decimal pareTotalEle = pareCascoEle + pareErprEle + pareMsEle + pareMaEle;
                decimal pareTotalIns = pareCascoIns + pareErprIns + pareMsIns + pareMaIns;
                decimal pareTotalTlc = pareCascoTlc + pareErprTlc + pareMsTlc + pareMaTlc;

                decimal pareTotalTotal = pareTotalMec + pareTotalTub + pareTotalEle + pareTotalIns + pareTotalTlc;

                strSQL = @"UPDATE EEP_CONVERSION.CP_PASTA_RESUMO SET";
                strSQL += " PARE_CASCO_TOTAL = " + pareCascoTotal.ToString() + ", ";
                strSQL += " PARE_ERPR_TOTAL = " + pareErprTotal.ToString() + ", ";
                strSQL += " PARE_MS_TOTAL = " + pareMsTotal.ToString() + ", ";
                strSQL += " PARE_MA_TOTAL = " + pareMaTotal.ToString() + ", ";

                strSQL += " PARE_TOTAL_MEC = " + pareTotalMec.ToString() + ", ";
                strSQL += " PARE_TOTAL_TUB = " + pareTotalTub.ToString() + ", ";
                strSQL += " PARE_TOTAL_ELE = " + pareTotalEle.ToString() + ", ";
                strSQL += " PARE_TOTAL_INS = " + pareTotalIns.ToString() + ", ";
                strSQL += " PARE_TOTAL_TLC = " + pareTotalTlc.ToString() + ", ";

                strSQL += " PARE_TOTAL_TOTAL= " + pareTotalTotal.ToString();

                strSQL += " WHERE PARE_ID = " + pareId.ToString();
                BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
            }
        }
        //===================================================================================
        private void CalculaTotais(string fpso)
        {
            strSQL = @" INSERT INTO EEP_CONVERSION.CP_PASTA_RESUMO
             SELECT 
                      NULL AS PARE_ID,
                      PARE_SBCN_SIGLA, 
                      '' AS PARE_LOCA_DESCRICAO,
                      'TOTAL' AS PARE_SMGR_DESCRICAO,
                      '' AS PARE_AREA_DESCRICAO,
                      SUM(PARE_CASCO_MEC) AS PARE_CASCO_MEC,
                      SUM(PARE_CASCO_TUB)AS PARE_CASCO_TUB,
                      SUM(PARE_CASCO_ELE) AS PARE_CASCO_ELE,
                      SUM(PARE_CASCO_INS) AS PARE_CASCO_INS,
                      SUM(PARE_CASCO_TLC) AS PARE_CASCO_TLC,
                      SUM(PARE_CASCO_TOTAL) AS PARE_CASCO_TOTAL,
                      SUM(PARE_ERPR_MEC) AS PARE_ERPR_MEC,
                      SUM(PARE_ERPR_TUB) AS PARE_ERPR_TUB,
                      SUM(PARE_ERPR_ELE) AS PARE_ERPR_ELE,
                      SUM(PARE_ERPR_INS) AS PARE_ERPR_INS,
                      SUM(PARE_ERPR_TLC) AS PARE_ERPR_TLC,
                      SUM(PARE_ERPR_TOTAL) AS PARE_ERPR_TOTAL,
                      SUM(PARE_MS_MEC) AS PARE_MS_MEC,
                      SUM(PARE_MS_TUB) AS PARE_MS_TUB,
                      SUM(PARE_MS_ELE) AS PARE_MS_ELE,
                      SUM(PARE_MS_INS) AS PARE_MS_INS,
                      SUM(PARE_MS_TLC) AS PARE_MS_TLC,
                      SUM(PARE_MS_TOTAL) AS PARE_MS_TOTAL,
                      SUM(PARE_MA_MEC) AS PARE_MA_MEC,
                      SUM(PARE_MA_TUB) AS PARE_MA_TUB,
                      SUM(PARE_MA_ELE) AS PARE_MA_ELE,
                      SUM(PARE_MA_INS) AS PARE_MA_INS,
                      SUM(PARE_MA_TLC) AS PARE_MA_TLC,
                      SUM(PARE_MA_TOTAL) AS PARE_MA_TOTAL,
                      SUM(PARE_TOTAL_MEC) AS PARE_TOTAL_MEC,
                      SUM(PARE_TOTAL_TUB) AS PARE_TOTAL_TUB,
                      SUM(PARE_TOTAL_ELE) AS PARE_TOTAL_ELE,
                      SUM(PARE_TOTAL_INS) AS PARE_TOTAL_INS,
                      SUM(PARE_TOTAL_TLC) AS PARE_TOTAL_TLC,
                      SUM(PARE_TOTAL_TOTAL) AS PARE_TOTAL_TOTAL
                    FROM EEP_CONVERSION.CP_PASTA_RESUMO 
                    WHERE PARE_SMGR_DESCRICAO != 'TOTAL PREVISTO' AND PARE_SBCN_SIGLA = '" + fpso + @"'
                    GROUP BY PARE_SBCN_SIGLA";
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
        }
        //===================================================================================
        private void SavePastaResumo(DTO.CpPastaResumoDTO r)
        {
            if (discSigla != "")
            {
                #region Update
                StringBuilder sb = new StringBuilder();
                //sb.Append(@"UPDATE EEP_CONVERSION.CP_PASTA_RESUMO SET PARE_LOCA_DESCRICAO = '" + r.PareLocaDescricao + "', ");
                sb.Append(@"UPDATE EEP_CONVERSION.CP_PASTA_RESUMO SET");
                string areaAux = r.PareAreaDescricao.Replace(@"/", "");
                try
                {
                    switch (areaAux)
                    {
                        case "CASCO":
                            {
                                switch (discSigla)
                                {
                                    case "MEC": { sb.Append(" PARE_CASCO_MEC = " + r.PareCascoMec.ToString()); break; }
                                    case "TUB": { sb.Append(" PARE_CASCO_TUB = " + r.PareCascoTub.ToString()); break; }
                                    case "ELE": { sb.Append(" PARE_CASCO_ELE = " + r.PareCascoEle.ToString()); break; }
                                    case "INS": { sb.Append(" PARE_CASCO_INS = PARE_CASCO_INS + " + r.PareCascoIns.ToString()); break; }
                                    case "TLC": { sb.Append(" PARE_CASCO_TLC = " + r.PareCascoTlc.ToString()); break; }
                                }
                                r.PareCascoTotal = r.PareCascoMec + r.PareCascoTub + r.PareCascoEle + r.PareCascoIns + r.PareCascoTlc;
                                break;
                            }
                        case "ERPR":
                            {
                                switch (discSigla)
                                {
                                    case "MEC": { sb.Append(" PARE_ERPR_MEC = " + r.PareErprMec.ToString()); break; }
                                    case "TUB": { sb.Append(" PARE_ERPR_TUB = " + r.PareErprTub.ToString()); break; }
                                    case "ELE": { sb.Append(" PARE_ERPR_ELE = " + r.PareErprEle.ToString()); break; }
                                    case "INS": { sb.Append(" PARE_ERPR_INS = " + r.PareErprIns.ToString()); break; }
                                    case "TLC": { sb.Append(" PARE_ERPR_TLC = " + r.PareErprTlc.ToString()); break; }
                                } break;
                            }
                        case "MS":
                            {
                                switch (discSigla)
                                {
                                    case "MEC": { sb.Append(" PARE_MS_MEC = " + r.PareMsMec.ToString()); break; }
                                    case "TUB": { sb.Append(" PARE_MS_TUB = " + r.PareMsTub.ToString()); break; }
                                    case "ELE": { sb.Append(" PARE_MS_ELE = " + r.PareMsEle.ToString()); break; }
                                    case "INS": { sb.Append(" PARE_MS_INS = " + r.PareMsIns.ToString()); break; }
                                    case "TLC": { sb.Append(" PARE_MS_TLC = " + r.PareMsTlc.ToString()); break; }
                                } break;
                            }
                        case "MA":
                            {
                                switch (discSigla)
                                {
                                    case "MEC": { sb.Append(" PARE_MA_MEC = " + r.PareMaMec.ToString()); break; }
                                    case "TUB": { sb.Append(" PARE_MA_TUB = " + r.PareMaTub.ToString()); break; }
                                    case "ELE": { sb.Append(" PARE_MA_ELE = " + r.PareMaEle.ToString()); break; }
                                    case "INS": { sb.Append(" PARE_MA_INS = " + r.PareMaIns.ToString()); break; }
                                    case "TLC": { sb.Append(" PARE_MA_TLC = " + r.PareMaTlc.ToString()); break; }
                                } break;
                            }
                    }

                    sb.Append(@" WHERE");
                    sb.Append(@" PARE_SBCN_SIGLA = '" + r.PareSbcnSigla + "' AND ");
                    sb.Append(@" PARE_SMGR_DESCRICAO = '" + r.PareSmgrDescricao + "'");

                    strSQL = sb.ToString();

                    if ("MECTUBELEINSTLC".IndexOf(discSigla) >= 0)
                    {
                        try
                        {
                            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message + " - PreparaSituacao"); }
                    }
                

                }
                catch (Exception ex) { throw new Exception(ex.Message + " - PreparaSituacao"); }
                #endregion
            }
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcResumoPasta.rdlc";

            DTO.CollectionCpPastaResumoDTO ca = new DTO.CollectionCpPastaResumoDTO();
            ca = BLL.CpPastaResumoBLL.GetCollection(filter, "PARE_ID");

            ReportDataSource rds = new ReportDataSource("dsResumoPasta", ca);
            report.DataSources.Add(rds);

            CollectionDTOBindingSource.DataSource = ca;
            reportViewer1.LocalReport.DataSources.Add(rds);
        }

        #region Filtros
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Este relatório encontra-se em manutenção, favor aguardar liberação.");
            // show animated image
            this.pBox.Image = Properties.Resources.BarraEvolucao;
            btnExecute.Enabled = false;

            //Montar filtros antes de disparar a thread de montagem da Collection (OnDoWork)
            filter = GetFilter();

            reportViewer1.Reset();
            this.reportViewer1.Visible = false;
            lblProgress.Visible = true;
            Application.DoEvents();

            // start background operation
            this.backgroundWorker.RunWorkerAsync();
        }
        //===================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            // Report progress
            this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));
            //Limpa tabela de resumo
            strSQL = @"DELETE EEP_CONVERSION.CP_PASTA_RESUMO WHERE PARE_SBCN_SIGLA = '" + fpso + "'";
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction(strSQL);
            BLL.CpPastaResumoBLL.ExecuteSQLInstruction("COMMIT");
            PrepareReport(filter, fpso);
            ShowReport(filter);
        }
        //===================================================================================
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is String)
            {
                this.lblProgress.Text = (String)e.UserState;
            }
        }
        //===================================================================================
        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // hide animation
            this.pBox.Image = null;
            // show result indication
            if (e.Cancelled)
            {
                //this.labelProgress.Text = "Operação cancelada pelo usuário!";
                this.pBox.Image = Properties.Resources.WarningImage;
            }
            else
            {
                if (e.Error != null)
                {
                    //this.labelProgress.Text = "Falha na operação: " + e.Error.Message;
                    this.pBox.Image = Properties.Resources.ErrorImage;
                }
                else
                {
                    //this.la.Text = "Operação concluída com sucesso!";
                    //this.pBox.Image = Properties.Resources.InformationImage;

                    // Create the parameterTitulo report parameter
                    titulo = "Resumo de Pastas de Comissionamento por Localização e Disciplina";
                    if (cmbFPSO.Text != "") titulo += " - " + cmbFPSO.Text;

                    ReportParameter parameterTitulo = new ReportParameter();
                    parameterTitulo.Name = "pTitulo";
                    parameterTitulo.Values.Add(titulo);

                    // Create the parameterEmissao report parameter
                    string emissao = "Emitido em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    ReportParameter parameterEmissao = new ReportParameter();
                    parameterEmissao.Name = "pEmissao";
                    parameterEmissao.Values.Add(emissao);

                    string subTitulo = "";
                    //if (cmbFPSO.SelectedIndex > 0) subTitulo = "FPSO: " + cmbFPSO.Text;
                    ReportParameter parameterSubtitulo = new ReportParameter();
                    parameterSubtitulo.Name = "pSubTitulo";
                    parameterSubtitulo.Values.Add(subTitulo);

                    // Set the report parameters for the report
                    reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterEmissao, parameterSubtitulo });

                    this.ParentForm.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Maximized;

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.Visible = true;
                    this.btnExcel.Visible = true;
                }
            }
            // restore button states
            lblProgress.Visible = false;
            //this.btnExecute.Enabled = true;
        }
        //===================================================================================
        private void btnExcel_Click(object sender, EventArgs e)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;
            string deviceInfo = null;
            byte[] bytes = reportViewer1.LocalReport.Render("Excel", deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);

            string path = systemRepository + @"Reports\" + titulo + " - " + cmbFPSO.Text + " (" + System.DateTime.Now.ToString("dd_MM_yyyy HH.mm.ss") + ").xls";

            FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
            fs.Write(bytes, 0, bytes.Length);
            fs.Close();

            lblProgress.Text = "";
            Application.DoEvents();
            MessageBox.Show("Planilha gerada com sucesso em:\r\n" + path);
            System.Diagnostics.Process.Start(path);
        }
        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFPSO.SelectedIndex != 0)
            {
                btnExecute.Visible = true;
                fpso = cmbFPSO.Text;
                if (usuaClasse <= 5) panelFilter.Visible = true;
            }
        }
        //===================================================================================

        #endregion
    }
}