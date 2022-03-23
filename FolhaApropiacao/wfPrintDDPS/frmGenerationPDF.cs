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


        private int m_currentPageIndex; private IList<Stream> m_streams;
        public string date;
        public decimal teamId;
        public string teamDescription;
        public bool preImpresso;

        public frmGenerationPDF()
        {
            InitializeComponent();
        }
        private void frmGenerationPDF_Load(object sender, EventArgs e)
        {
            string teamCode = "";
            string disciplina = " ";
            string[] lider = teamDescription.Split('(');
            string matricula = lider[1].Replace(")", "");
            string nomeLider = lider[0].Trim();
            string local = " ";
            string shift = " ";

            TabelaNeg tabelaNeg = new TabelaNeg();

            //DataTable dataTable = tabelaNeg.ListCraftLeaderSupervisor(teamId);
            //if (dataTable.Rows.Count != 0)
            //{
            //    lider += dataTable.Rows[0][0].ToString();
            //    supervisor += dataTable.Rows[0][1].ToString();
            //}

            DataTable dataTable = tabelaNeg.ListTeam(teamId);
            
            ListTimeSheetsBindingSource.DataSource = tabelaNeg.PrintTimeSheets(teamId, date);
            ListActivitiesBindingSource.DataSource = tabelaNeg.PrintActivities(teamId);
            IList<ReportParameter> reportParams = new List<ReportParameter>();
            reportParams.Add(new ReportParameter("date", Convert.ToDateTime(date).ToString("dd/MM/yyyy")));
            //reportParams.Add(new ReportParameter("barCode", tabelaNeg.Barcode(teamId, date)));
            //reportParams.Add(new ReportParameter("lider", teamDescription));
            //reportParams.Add(new ReportParameter("supervisor", supervisor));
            //reportParams.Add(new ReportParameter("idTime", teamId.ToString().PadLeft(8,'0')));

            teamCode = dataTable.Rows[0]["TEAM_CODE"].ToString();       //TEAMCODE
            reportParams.Add(new ReportParameter("teamcode", teamCode));

            disciplina = dataTable.Rows[0]["GROUP_TEAM_DESCRIPTION"].ToString(); //DISCIPLINA
            reportParams.Add(new ReportParameter("disciplina", disciplina));

            reportParams.Add(new ReportParameter("nomeLider", nomeLider));  //NOME LIDER
            reportParams.Add(new ReportParameter("matricula", matricula));  //MATRICULA LIDER

            local = "";
            reportParams.Add(new ReportParameter("local", local));

            reportParams.Add(new ReportParameter("activeDirectory", System.Environment.MachineName + " - " + System.Environment.UserName + " - " + DateTime.Now.ToString() + " - Versão 1.3 (TeamId-" + teamId.ToString() + ")"));
            
            shift = dataTable.Rows[0][2].ToString();            
            reportParams.Add(new ReportParameter("identification", shift));

            if (preImpresso == false)
            {
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.SetParameters(reportParams);
                reportViewer1.ShowParameterPrompts = false;
                Export(reportViewer1.LocalReport);
            }
            else
            {
                reportViewer2.RefreshReport();   
                reportViewer2.LocalReport.SetParameters(reportParams);
                reportViewer2.ShowParameterPrompts = false;
                Export(reportViewer2.LocalReport);
            }
            Print();
            Close();
          // reportViewer1.RefreshReport();    
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
