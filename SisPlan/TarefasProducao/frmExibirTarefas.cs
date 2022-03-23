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
//using System.Web.UI.HtmlControls;
using System.Diagnostics;


namespace TarefasProducao
{
    public partial class frmExibirTarefas : Form
    {
        static string strSQL = "";
        DataTable dtFoseP76 = null;
        DataTable dtFoseP76AUX = null;
        string foseId, foseNumero, linha, spool, caderno, regiao, foseP76 = "";
        //===========================================================================
        public frmExibirTarefas()
        {
            InitializeComponent();
        }
        //===========================================================================
        private void frmExibirTarefas_Load(object sender, EventArgs e) 
        {
            
        }
        //===========================================================================
        private void btnConverteP76FOSE_Click(object sender, EventArgs e)
        {
            strSQL = @"SELECT FOSE_ID, FOSE_NUMERO, 
                              EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(FOSE_NUMERO, 2, '_') AS LINHA, 
                              EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(FOSE_NUMERO, 3, '_'),1,'.') AS SPOOL, 
                              EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(FOSE_NUMERO, 3, '_'),2,'.') AS CADERNO
                         FROM EEP_CONVERSION.FOLHA_SERVICO
                        WHERE FOSE_CNTR_CODIGO = 'Conversão' AND SUBSTR(FOSE_NUMERO,1,3) = 'P76' and FOSE_DISC_ID = 5";
            dtFoseP76 = BLL.AcControleFolhaServicoBLL.Select(strSQL);

            //Prepara tabela de conversão
            strSQL = @"DELETE EEP_CONVERSION.AC_FOSE_P76_CONVERSAO";
            BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);

            for (int i = 0; i < dtFoseP76.Rows.Count; i++)
            {
                foseId = dtFoseP76.Rows[i]["FOSE_ID"].ToString();
                foseNumero = dtFoseP76.Rows[i]["FOSE_NUMERO"].ToString();
                linha = dtFoseP76.Rows[i]["LINHA"].ToString();
                spool = dtFoseP76.Rows[i]["SPOOL"].ToString();
                //if (spool == "Spool Mont") { string x = ""; }
                spool = spool.Replace("Spool Mont", "MT").Replace("Spool", "SP");
                caderno = dtFoseP76.Rows[i]["CADERNO"].ToString();
                switch (caderno.Length)
                {
                    case 4: { caderno = caderno.Substring(1, 3); break; }
                    case 5: { caderno = caderno.Substring(1, 4); break; }
                }

                //Obtem a Regiao da FOSE
                strSQL = @"SELECT DESCRICAO_ATRIBUTO AS REGIAO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO Z WHERE Z.FOSE_ID = " + foseId + " AND Z.ATPE_NOME = 'Regiao'";
                dtFoseP76AUX = BLL.AcControleFolhaServicoBLL.Select(strSQL);

                regiao = "";
                if (dtFoseP76AUX.Rows.Count > 0) regiao = dtFoseP76AUX.Rows[0]["REGIAO"].ToString();

                //Compoe código novo
                foseP76 = regiao + "_" + linha + "_" + caderno + "_" + spool;

                //Grava tabela de saida
                strSQL = @"INSERT INTO EEP_CONVERSION.AC_FOSE_P76_CONVERSAO (FOSE_NUMERO_OLD, FOSE_NUMERO_NEW) VALUES ('" + foseNumero + "', '" + foseP76 + "')";
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction(strSQL);
                BLL.AcControleFolhaServicoBLL.ExecuteSQLInstruction("COMMIT");
            }
        }
        //===========================================================================
    }
}

/*
//===========================================================================
        private void RefreshTarefas()
        {
            DataTable dt = BLL.IntTarefasBLL.Get("Y.INLO_ID = X.INTA_INLO_ID AND INTA_ACTIVE = 1", "INTA_STATUS DESC, INTA_FUNCIONARIO");
            dtg.DataSource = dt;

                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "img";
                img.HeaderText = "Concluído";

                dtg.Columns.Add(img);


                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                style.ForeColor = Color.IndianRed;
                style.BackColor = Color.Ivory;
                style.Font = new Font("Tahoma", 12.5F, GraphicsUnit.Pixel);

                dtg.Columns["INTA_FUNCIONARIO"].HeaderCell.Style = style;
                dtg.Columns["INTA_FUNCIONARIO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dtg.Columns["INTA_FUNCIONARIO"].Name = DataGridViewContentAlignment.BottomCenter.ToString();

                dtg.Columns["INTA_TAREFA"].HeaderCell.Style = style;
                dtg.Columns["INTA_TAREFA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dtg.Columns["INTA_TAREFA"].Name = DataGridViewContentAlignment.BottomCenter.ToString();

                dtg.Columns["INLO_NOME"].HeaderCell.Style = style;
                dtg.Columns["INLO_NOME"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dtg.Columns["INLO_NOME"].Name = DataGridViewContentAlignment.BottomCenter.ToString();

                //dtg.Columns["img"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomCenter;
                dtg.Columns["img"].HeaderCell.Style = style;
                dtg.Columns["img"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                dtg.Columns["img"].Name = DataGridViewContentAlignment.BottomCenter.ToString();
            

            int number_of_rows = dtg.RowCount;
            for (int i = 0; i < number_of_rows; i++)
            {
                //if (Convert.ToDecimal(dtg.Rows[i].Cells["INTA_STATUS"].Value) == 1)
                if (Convert.ToDecimal(dt.Rows[i]["INTA_STATUS"]) == 1)
                {
                    //Icon
                    //System.Drawing.Image image = TarefasProducao.Properties.Resources.sim;
                    //dtg.Rows[i].Cells["img"].Value = image;
                    //img.Image = TarefasProducao.Properties.Resources.sim;
                    dtg.Rows[i].Cells[7].Value = TarefasProducao.Properties.Resources.sim; //img.Image;
                }
                else
                {
                    //System.Drawing.Image image = TarefasProducao.Properties.Resources.nao;
                    //dtg.Rows[i].Cells["img"].Value = image;
                    //img.Image = TarefasProducao.Properties.Resources.nao;
                    dtg.Rows[i].Cells[7].Value = TarefasProducao.Properties.Resources.nao;  //img.Image;
                }
            }
            Process[] processos = Process.GetProcesses();
        }
*/