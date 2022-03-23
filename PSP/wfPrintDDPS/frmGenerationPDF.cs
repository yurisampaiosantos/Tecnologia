using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using GridCarregamento.Negocio;
using GridCarregamento.DAL;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Runtime.InteropServices;

namespace wfPrintDDPS
{
    public partial class frmGenerationPDF : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private int m_currentPageIndex;
        private IList<Stream> m_streams;
        public string date;
        public string De;
        public string Ate;
        public decimal teamId;
        public string teamDescription;
        public string origem;
        public bool preImpresso;
        public bool cbDDPS;
        public bool cbFAD;

        public frmGenerationPDF()
        {
            InitializeComponent();
        }
        private void frmGenerationPDF_Load(object sender, EventArgs e)
        {
            try
            {
                string teamCode = "";
                string disciplina = " ";
                string[] lider = teamDescription.Split('(');
                string matricula = " ";
                string nomeLider = lider[0].Trim();
                string local = " ";
                string area = " ";
                string shift = " ";
                string tarefa = " ";
                string rp = " ";
                string supervisor = "Supervisor: ";

                TabelaNeg tabelaNeg = new TabelaNeg();

                DataTable dataTable = tabelaNeg.ListTeam(teamId);
            
                ListActivitiesBindingSource.DataSource = tabelaNeg.PrintActivities(teamId);
                IList<ReportParameter> reportParams = new List<ReportParameter>();
                reportParams.Add(new ReportParameter("date", Convert.ToDateTime(date).ToString("dd/MM/yyyy")));

                DataTable dtSupervisor = tabelaNeg.ListCraftLeaderSupervisor(teamId);
                if (dtSupervisor.Rows.Count != 0) supervisor += dtSupervisor.Rows[0][1].ToString();
                reportParams.Add(new ReportParameter("supervisor", supervisor));

                teamCode = dataTable.Rows[0]["TEAM_CODE"].ToString();                   //TEAMCODE
                reportParams.Add(new ReportParameter("teamcode", teamCode));

                disciplina = dataTable.Rows[0]["GROUP_TEAM_DESCRIPTION"].ToString();    //DISCIPLINA
                reportParams.Add(new ReportParameter("disciplina", disciplina));

                reportParams.Add(new ReportParameter("nomeLider", nomeLider));          //NOME LIDER

                matricula = dataTable.Rows[0]["MATRICULA"].ToString();                  
                reportParams.Add(new ReportParameter("matricula", matricula));          //MATRICULA LIDER

                local = dataTable.Rows[0]["LOCAL_DESCRIPTION"].ToString().Trim() + " - " + dataTable.Rows[0]["SBCN_SIGLA"].ToString();       //LOCAL + SBCN_SIGLA
                reportParams.Add(new ReportParameter("local", local));

                area = dataTable.Rows[0]["AREA_DESCRIPTION"].ToString();                //AREA
                reportParams.Add(new ReportParameter("area", area));

                reportParams.Add(new ReportParameter("activeDirectory", System.Environment.MachineName + " - " + System.Environment.UserName + " - " + DateTime.Now.ToString() + " - Versão 1.3 (TeamId-" + teamId.ToString() + ")"));
            
                shift = dataTable.Rows[0][2].ToString();            
                reportParams.Add(new ReportParameter("identification", shift));

                if (origem == "Exames")
                {
                    tarefa = dataTable.Rows[0]["TAREFA"].ToString();                    //TAREFA
                    reportParams.Add(new ReportParameter("tarefa", tarefa));

                    rp = dataTable.Rows[0]["RP"].ToString();                            //RP
                    reportParams.Add(new ReportParameter("rp", rp));

                    reportParams.Add(new ReportParameter("De", De));
                    reportParams.Add(new ReportParameter("Ate", Ate));

                    ListTimeSheetsBindingSource.DataSource = tabelaNeg.RelacaoConvocados(teamId, De, Ate);

                    reportViewer3.RefreshReport();
                    reportViewer3.LocalReport.EnableExternalImages = true;
                    reportViewer3.LocalReport.SetParameters(reportParams);
                    reportViewer3.ShowParameterPrompts = false;
                    Export(reportViewer3.LocalReport);

                    Print();
                }
                else
                {
                    TabelaDAL tabelaDAL = new TabelaDAL();

                    if (tabelaDAL.QtdIntegrantes(teamId))
                    {
                        ListTimeSheetsBindingSource.DataSource = tabelaDAL.ImprimeIntegrantes(tabelaDAL.SqlIntegrantes(teamId), teamId, date);

                        if (cbDDPS)
                        {
                            reportViewer1.RefreshReport();
                            reportViewer1.LocalReport.EnableExternalImages = true;
                            reportViewer1.LocalReport.SetParameters(reportParams);
                            reportViewer1.ShowParameterPrompts = false;
                            Export(reportViewer1.LocalReport);

                            Print();
                        }

                        if (cbFAD)
                        {
                            tarefa = dataTable.Rows[0]["TAREFA"].ToString();
                            reportParams.Add(new ReportParameter("tarefa", tarefa));

                            rp = dataTable.Rows[0]["RP"].ToString();
                            reportParams.Add(new ReportParameter("rp", rp));

                            string plataforma = dataTable.Rows[0]["SBCN_SIGLA"].ToString();
                            int idDisciplina = Convert.ToInt32(dataTable.Rows[0]["DIEF_ID"].ToString());
                            DataTable dtAtividades = tabelaNeg.ListaAtividades(plataforma, idDisciplina);

                            int qtdAtividades = (dtAtividades.Rows.Count > 12) ? 12 : dtAtividades.Rows.Count;

                            for (int i = 0; i < qtdAtividades; i++)
                            {
                                reportParams.Add(new ReportParameter("atividade" + (i + 1), dtAtividades.Rows[i]["ATIVIDADES"].ToString()));

                                if (dtAtividades.Rows[i]["ACDI_NIVEL_PRINCIPAL"].ToString() == "1")
                                {
                                    reportParams.Add(new ReportParameter("ua" + (i + 1), dtAtividades.Rows[i]["TA_UA"].ToString()));
                                }
                            }

                            reportViewer2.RefreshReport();
                            reportViewer2.LocalReport.EnableExternalImages = true;
                            reportViewer2.LocalReport.SetParameters(reportParams);
                            reportViewer2.ShowParameterPrompts = false;
                            Export(reportViewer2.LocalReport);

                            Print();
                        }
                    }
                }

                Close();
                this.reportViewer1.RefreshReport();
                this.reportViewer2.RefreshReport();
                this.reportViewer3.RefreshReport();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>21cm</PageWidth>
                <PageHeight>29,7cm</PageHeight>
                <MarginTop>0.5cm</MarginTop>
                <MarginLeft>0.5cm</MarginLeft>
                <MarginRight>0.5cm</MarginRight>
                <MarginBottom>0.5cm</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
         //   ps.PrinterName = printDialog1.PrinterSettings.PrinterName;
            ps.DefaultPageSettings.Landscape = false;
            ps.DefaultPageSettings.PrinterSettings.DefaultPageSettings.Landscape = false;
            printDoc.PrinterSettings = ps;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private void reportViewer1_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //this.reportViewer1.PrintDialog();
        }
    }
}
