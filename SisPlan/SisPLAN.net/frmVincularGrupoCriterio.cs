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
    public partial class frmVincularGrupoCriterio : Form
    {
        //============================================
        string strSQL = "";
        DataTable dtCriterioMedicao = null;
        DataTable dtGrupoCriterio = null;
        string codCriterio = "";
        string codGrupo = "";
        string grupoCriterio = "";
        int counter = 0;
        string message = "";
        //============================================
        public frmVincularGrupoCriterio()
        {
            InitializeComponent();
        }
        //============================================
        private void Form1_Load(object sender, EventArgs e)
        {
            strSQL = @"SELECT 
                              CASE WHEN GRFC_FCME_ID != 0 THEN TO_CHAR(GRFC_FCME_ID) ELSE '' END AS GRFC_FCME_ID, 
                              CASE WHEN FCME_SIGLA IS NOT NULL THEN FCME_SIGLA ELSE '' END AS FCME_SIGLA 
                         FROM (SELECT NULL AS GRFC_FCME_ID, '' AS FCME_SIGLA FROM DUAL UNION SELECT FCME_ID, FCME_SIGLA FROM EEP_CONVERSION.VW_GRUPO_CRITERIO_MEDICAO_FULL) 
                     ORDER BY 2 NULLS FIRST";
            dtCriterioMedicao = BLL.VwGrupoCriterioMedicaoBLL.Select(strSQL);
            cmbCriterioMedicao.DataSource = dtCriterioMedicao;
                cmbCriterioMedicao.ValueMember = "GRFC_FCME_ID";
                cmbCriterioMedicao.DisplayMember = "FCME_SIGLA";
                lblMessage.Text = "";
        }        
        //============================================
        private void btnAplicarVinculo_Click(object sender, EventArgs e)
        {
            try
            {
                codCriterio = cmbCriterioMedicao.SelectedValue.ToString();
                codGrupo = cmbSchedule.Text;
                grupoCriterio = cmbGrupoCriterio.SelectedValue.ToString();
                counter = BLL.VwGrupoCriterioMedicaoFullBLL.Count("GRCR_CNTR_CODIGO = 'Conversão' AND GRFC_FCME_ID = " + codCriterio + " AND GRCR_GRUPO_DESCRICAO = '" + codGrupo + "'");
                if (counter == 0)
                {

                    strSQL = @"INSERT INTO EEP_CONVERSION.AC_GRCR_VINCULO_FCME(GRFC_CNTR_CODIGO, GRFC_GRCR_ID, GRFC_FCME_ID) VALUES ('Conversão', " + grupoCriterio + "," + codCriterio + ")";
                    message = @"O critério " + cmbCriterioMedicao.Text + @" do " + cmbSchedule.Text + " NÃO ESTÁ RELACIONADO\n\rao grupo " + cmbGrupoCriterio.Text + ".\n\rConfirma a inclusão?";
                }
                else
                {
                    strSQL = @"UPDATE EEP_CONVERSION.AC_GRCR_VINCULO_FCME SET GRFC_GRCR_ID = " + grupoCriterio + " WHERE GRFC_FCME_ID = '" + codCriterio + "' AND GRFC_CNTR_CODIGO = 'Conversão'";
                    message = @"O critério " + cmbCriterioMedicao.Text + @" do " + cmbSchedule.Text + " SERÁ RELACIONADO\n\rao grupo " + cmbGrupoCriterio.Text + ".\n\r\n\rVocê confirma a alteração?";
                }
                DialogResult result = MessageBox.Show(message, "Aviso!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {

                    BLL.VwGrupoCriterioMedicaoBLL.ExecuteSQLInstruction(strSQL);
                    btnAplicarVinculo.Enabled = false;
                    cmbGrupoCriterio.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //============================================
        private void cmbCriterioMedicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCriterioMedicao.Text != "System.Data.DataRowView" && cmbCriterioMedicao.Text != "") PreencheGrupoCriterio();
        }
        //============================================
        private void cmbSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSchedule.Text != "System.Data.DataRowView" && cmbSchedule.Text != "") PreencheGrupoCriterio();
        }
        //============================================
        private void PreencheGrupoCriterio()
        {
            DTO.VwGrupoCriterioMedicaoFullDTO c = new DTO.VwGrupoCriterioMedicaoFullDTO();
            c = BLL.VwGrupoCriterioMedicaoFullBLL.GetObject("FCME_ID = " + cmbCriterioMedicao.SelectedValue);
            if (c.GrfcGrcrId == 0)
            {
                message = @"O critério " + c.FcmeSigla + @" não está relacionado a nenhum Grupo Critério ou schedule.";
            }
            else
            {
                message = @"O critério " + c.FcmeSigla + @" está relacionado ao Grupo Critério " + c.GrcrNome + " no " + c.GrcrGrupoDescricao + ".";
            }
            
            lblMessage.Text = message;
            Application.DoEvents();
            if(cmbCriterioMedicao.Text != "" && cmbSchedule.Text != "")
            {
                try
                {
                    cmbGrupoCriterio.Enabled = true;

                    strSQL = @"SELECT GRCR_GRUPO_SIGLA, GRCR_ID, GRCR_NOME FROM EEP_CONVERSION.AC_GRUPO_CRITERIO WHERE GRCR_CNTR_CODIGO = 'Conversão' AND GRCR_GRUPO_DESCRICAO = '" + cmbSchedule.Text + @"' AND GRCR_ID > 1
    ORDER BY GRCR_NOME";
                    dtGrupoCriterio = BLL.VwGrupoCriterioMedicaoBLL.Select(strSQL);
                    cmbGrupoCriterio.DataSource = dtGrupoCriterio;
                    cmbGrupoCriterio.ValueMember = "GRCR_ID";
                    cmbGrupoCriterio.DisplayMember = "GRCR_NOME";
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            }
        }
        //============================================
        private void cmbGrupoCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAplicarVinculo.Enabled = true;
        }
        //============================================
    }
}