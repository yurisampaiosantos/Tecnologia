using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Reporting.WinForms;

namespace SisPLAN.net
{
    public partial class frmPendenciaMateriais : Form
    {
        int totRecords = 0;
        DataTable dtDOC = null;
        DataTable dtDisciplina = null;
        //DataTable dtRmSemAF = null;
        //DataTable dtRmComAF = null;
        //DataTable dtRmComAFSemNF = null;
        //DataTable dtRmComAFComNF = null;
        //DataTable dtRmComNFSemNE = null;
        //DataTable dtRmComNFComNE = null;
        //DataTable dtRMItem = null;
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        //static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        string filter = "";
        //string filterColGrupoCriterio = "";
        //string filterColGruposCriterioMedicao = "";
        string strSQL = "";
        //===================================================================================
        public frmPendenciaMateriais()
        {
            InitializeComponent();
        }
        //===================================================================================
        private void frmPendenciaMateriais_Load(object sender, EventArgs e)
        {
            strSQL = @"SELECT '' AS DCMN_NUMERO FROM DUAL UNION SELECT DISTINCT DCMN_NUMERO FROM DOCUMENTO WHERE DCMN_CNTR_CODIGO = 'Conversão' AND DCMN_DCTP_ID = 12 ORDER BY 1 NULLS FIRST";
            dtDOC = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            cmbRM.DataSource = dtDOC;
            cmbRM.DisplayMember = "DCMN_NUMERO";
            cmbRM.ValueMember = "DCMN_NUMERO";

            strSQL = @"SELECT '' AS DISCIPLINA FROM DUAL UNION SELECT DISTINCT DISCIPLINA AS DISCIPLINA FROM EEP_CONVERSION.VW_AC_RECEBIMENTO_MATERIAIS ORDER BY 1 NULLS FIRST";
            dtDisciplina = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            cmbDisciplina.DataSource = dtDisciplina;
            cmbDisciplina.DisplayMember = "DISCIPLINA";
            cmbDisciplina.ValueMember = "DISCIPLINA";

            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //txtNF.Text = txtNF.Text.Trim();
            txtAF.Text = txtAF.Text.Trim();
            txtCodigoMat.Text = txtCodigoMat.Text.Trim();
            filter = GetFilter();

            if (chkRecalcular.Checked)
            {
                totRecords = GenericClasses.PreparaSaidasRelatorios.CountRecordPendenciaMateriais(contrato);
                //MessageBox.Show(totRecords.ToString());
                //MessageBox.Show(System.DateTime.Now.ToString());
                GenericClasses.PreparaSaidasRelatorios.SaidaPendenciaMateriais(contrato);
               //MessageBox.Show(System.DateTime.Now.ToString());
            }

            ShowReport(filter);
        }
        //===================================================================================
        private string GetFilter()
        {
            //string sRet = " DIPQ_QTD_AF > 0";  // RMS COMPRADAS E NÃO NECESSARIAMENTE RECEBIDAS
            string sRet = "(X.STATUS = 'NC' OR X.STATUS = 'NE' OR X.STATUS = 'NL')";

            if (cmbRM.SelectedIndex > 0) sRet += @" AND X.DCMN_NUMERO = '" + cmbRM.SelectedValue + "'";

            if (txtAF.Text != "") sRet += @" AND X.AUFO_NUMERO = '" + txtAF.Text + "'";

            if (txtCodigoMat.Text != "") sRet += @" AND X.DIPC_CODIGO LIKE '%" + txtCodigoMat.Text + "%'";

            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND X.SBCN_SIGLA = '" + cmbFPSO.SelectedItem + "'";
            
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND X.DISC_NOME = '" + cmbDisciplina.SelectedValue + "'";

            return sRet;
            //sRet = @"DATA_REC BETWEEN TO_DATE('" + dtInicio + "', 'DD/MM/YYYY') AND TO_DATE('" + dtFim + "', 'DD/MM/YYYY')";

            //if (txtNF.Text != "")
            //{
            //    sRet += @" AND NF LIKE '%" + txtNF.Text + "%'";
            //}
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            //filter = "DCMN_NUMERO = '" + RM + "' AND DIPQ_QTD_NF = 0"; // ITENS QUE POSSUEM AF E NAO POSSUEM NF (Não entregues)
            //filter = "DCMN_NUMERO = '" + RM + "'"; // ITENS QUE POSSUEM AF (Todos os Itens comprados, entregues ou não)
            //Itens de RMs QUE POSSUEM AF E NÃO POSSUEM NFs
            //DTO.CollectionVwRmItemDTO colItemsRM = BLL.VwRmItemBLL.GetCollection(filter, "DCMN_NUMERO");

            this.reportViewer1.Size = new System.Drawing.Size(1340,600);

            DTO.CollectionAcPendenciaMaterialDTO col = new DTO.CollectionAcPendenciaMaterialDTO();
            col = BLL.AcPendenciaMaterialBLL.GetCollection(filter, "DCMN_NUMERO, REPI_ITEM, DIPC_CODIGO, AUFO_NUMERO, AFIT_ITEM");
            DataTable dtBaseDados = BLL.AcPendenciaMaterialBLL.Get(filter, "DCMN_NUMERO, REPI_ITEM, DIPC_CODIGO, AUFO_NUMERO, AFIT_ITEM");
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\\PendenciaMateriais.rdlc";

            ReportDataSource rds = new ReportDataSource("dsPendenciaMateriais",col);
            report.DataSources.Add(rds);
            CollectionAcPendenciaMaterialDTOBindingSource.DataSource = col;

            reportViewer1.LocalReport.DataSources.Add(rds);

            string subTitulo = " ";
            // Create the parameterSubTitulo report parameter
            ReportParameter parameterSubTitulo = new ReportParameter();
            parameterSubTitulo.Name = "pSubTitulo";
            parameterSubTitulo.Values.Add(subTitulo);

            string itensRelatorio = "TOTAL GERAL DE ITENS: " + col.Count.ToString();
            ReportParameter parameterItensRelatorio = new ReportParameter();
            parameterItensRelatorio.Name = "pItensRelatorio";
            parameterItensRelatorio.Values.Add(itensRelatorio);

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterSubTitulo, parameterItensRelatorio });

            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            this.reportViewer1.RefreshReport();
            this.reportViewer1.Visible = true;

            string path = systemRepository + @"Reports\Pendência de Materiais (" + System.DateTime.Now.ToString("dd MMM yyyy hh.mm.ss") + ").xlsx";
            grv.DataSource = dtBaseDados;
            GenericClasses.SpreadSheets.CreateSpreadSheetXLSX(grv, path);
        }
        //===================================================================================
    }
}