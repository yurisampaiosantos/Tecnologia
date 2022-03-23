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
    public partial class frmMovimentaPastas : Form
    {
        //========================================================================================================================================================
        string strSQL = "";
        string contrato = "Conversão";
        string ticketFile = @"C:\Sisplan.Net\PunchListTicket\PunchListTicket.xml";
        DataTable dtPastas = null;
        string responsavel = "";
        DataTable dtResponsaveis = null;
        DataTable dtVwPastas = null;
        DataTable dtStatusOperacao = null;
        DataTable dtClasse = null;

        DataTable dtPunchlist = null;
        //DataTable dtMaterialPendente = null;
        DataTable dtTipoPendencia = null;
        DataTable dtStatusPunchlist = null;
        //DataTable dtStatusMaterialPendente = null;
        //DataTable dtMapeFornecedor = null;
        DataTable dtLocalizacao = null;

        string userName = "";
        DTO.CpUsuarioDTO u = new DTO.CpUsuarioDTO();
        DTO.CollectionCpPastaDTO p = new DTO.CollectionCpPastaDTO();
        DTO.CpPunchlistDTO pl = new DTO.CpPunchlistDTO();
        DTO.CpMaterialPendenteDTO mp = new DTO.CpMaterialPendenteDTO();

        string asp = Convert.ToChar(34).ToString();
        //========================================================================================================================================================
        public static string GetDefaultUserProfilePath()
        {
            string path = System.Environment.GetEnvironmentVariable("DEFAULTUSERPROFILE") ?? string.Empty;
            if (path.Length == 0)
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList"))
                {
                    path = (string)key.GetValue("Default", string.Empty);
                }
            }
            //path = System.Environment.GetFolderPath(0);
            string userDocuments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return path;
        }
        //========================================================================================================================================================
        public frmMovimentaPastas()
        {
            InitializeComponent();
        }
        //========================================================================================================================================================
        private void Form1_Load(object sender, EventArgs e)
        {
            string x = GetDefaultUserProfilePath();

            userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\')[1].ToLower();   //Domínio + Login
            //userName = "anderson-souza";

            //PunchListTicket
            //if (usuaClasse <= 5)
            //{
                //p = GenericClasses.XML.DeserializaArquivoXML(p, @"F:\CONVERSÃO\PLANEJAMENTO\23-Comissionamento\PrevisaoPastas.xml");
                //ExibePrevisto(p);
            //}

            //GenericClasses.XML.

            DTO.CollectionCpUsuarioDTO cu = new DTO.CollectionCpUsuarioDTO();
            cu = BLL.CpUsuarioBLL.GetCollection("UPPER(USUA_LOGIN) = '" + userName.ToUpper() + "'");
            if (cu.Count == 0)
            {
                MessageBox.Show("O usuário " + userName + " não possui permissão de acesso.");
                panelFundo.Visible = false;
            }
            else
            {
                u = cu[0];
                FillPastas();
                System.IO.FileInfo f = new FileInfo(ticketFile);
                if (!f.Exists)
                {
                    this.ParentForm.WindowState = FormWindowState.Maximized;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    DTO.CpPunchListTicketDTO t = new DTO.CpPunchListTicketDTO();
                    t = GenericClasses.XML.DeserializaPunchListTicketXML(t, ticketFile);
                    btnRetornoPendencia.Visible = true;
                    cmbPastas.SelectedValue = t.PastaCodigo;
                }

                //Feed cmbMapeLocalizacao
                strSQL = @"SELECT NULL AS LOCA_ID, NULL AS LOCA_DESCRICAO FROM DUAL UNION SELECT LOCA_ID, LOCA_DESCRICAO FROM EEP_CONVERSION.CP_LOCALIZACAO ORDER  BY 2 NULLS FIRST";
                dtLocalizacao = BLL.AcAvancoCompletacaoBLL.Select(strSQL);
                cmbLocalizacao.DataSource = dtLocalizacao;
                cmbLocalizacao.DisplayMember = "LOCA_DESCRICAO";
                cmbLocalizacao.ValueMember = "LOCA_ID";

                //Feed cmbStatusPunch
                strSQL = "SELECT NULL AS STPU_ID, NULL AS STPU_DESCRICAO FROM DUAL UNION SELECT STPU_ID, STPU_DESCRICAO FROM EEP_CONVERSION.CP_STATUS_PUNCHLIST ORDER BY 1 NULLS FIRST";
                dtStatusPunchlist = BLL.CpPastaBLL.Select(strSQL);
                cmbPunchStatus.DataSource = dtStatusPunchlist;
                cmbPunchStatus.ValueMember = "STPU_ID";
                cmbPunchStatus.DisplayMember = "STPU_DESCRICAO";
                cmbPunchStatus.SelectedIndex = 0;


                //Feed cmbTipoPendencia
                strSQL = "SELECT NULL AS TIPE_ID, NULL AS TIPE_DESCRICAO FROM DUAL UNION SELECT TIPE_ID, TIPE_DESCRICAO FROM EEP_CONVERSION.CP_TIPO_PENDENCIA ORDER BY 1 NULLS FIRST";
                dtTipoPendencia = BLL.CpPastaBLL.Select(strSQL);
                cmbTipoPendencia.DataSource = dtTipoPendencia;
                cmbTipoPendencia.ValueMember = "TIPE_ID";
                cmbTipoPendencia.DisplayMember = "TIPE_DESCRICAO";
                cmbTipoPendencia.SelectedIndex = 0;

                //Feed cmbRespPunchlist
                strSQL = @"SELECT * FROM (SELECT NULL AS ARPE_AGENTE, NULL AS ARPE_DESCRICAO FROM DUAL UNION SELECT ARPE_AGENTE, ARPE_DESCRICAO FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA ORDER BY ARPE_AGENTE) ORDER BY ARPE_DESCRICAO NULLS FIRST";
                dtResponsaveis = BLL.CpPastaBLL.Select(strSQL);
                cmbRespPunchlist.DataSource = dtResponsaveis;
                cmbRespPunchlist.ValueMember = "ARPE_DESCRICAO";
                cmbRespPunchlist.DisplayMember = "ARPE_AGENTE";
                cmbRespPunchlist.SelectedIndex = 2;

                //HABILITA EXECUTOR
                if (u.UsuaClasse <= 10)
                {
                    txtExecutor.Enabled = true;
                    btnZona.Visible = true;
                }
                else
                {
                    txtExecutor.Enabled = false;
                    btnZona.Visible = false;
                }

                //HABILITA CLASSE PUNCH
                if (u.UsuaAgClassPunch == 1)
                {
                    rbImped.Enabled = true;
                    rbNaoImped.Enabled = true;
                    cmbRespPunchlist.Enabled = true;
                }

                //HABILITA EDITAR STATUS PUNCH
                if (u.UsuaAgStatusPunch == 1)
                {
                    cmbPunchStatus.Enabled = true;
                }
                panelFundo.Visible = true;

                
            }
        }
        #region Pastas
        //========================================================================================================================================================
        private void cmbLocalizacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbLocalizacao.SelectedIndex > 0) FillPastas();
        }
        //========================================================================================================================================================
        private void FillPastas()
        {
            //FEED cmbPastas NÃO CANCELADAS
            strSQL = @"SELECT DISTINCT PASTA_CODIGO FROM EEP_CONVERSION.CP_PASTA";
            if(cmbLocalizacao.SelectedIndex > 0) strSQL += @" WHERE PASTA_LOCA_ID = " + cmbLocalizacao.SelectedValue.ToString() + @" AND PASTA_STPA_ID != 3";
            strSQL += @" ORDER BY 1 NULLS FIRST";
            dtPastas = BLL.CpPastaBLL.Select(strSQL);
            cmbPastas.DataSource = dtPastas;
            cmbPastas.ValueMember = "PASTA_CODIGO";
            cmbPastas.DisplayMember = "PASTA_CODIGO";
            if (dtPastas.Rows.Count > 0) cmbPastas.SelectedIndex = 0;
        } 
        //========================================================================================================================================================
        private void cmbPastas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbPastas.Text.Trim() == "")
                {
                    FillPastas();
                }
                else
                {
                    //Feed cmbPastas
                    strSQL = @"SELECT DISTINCT PASTA_CODIGO FROM EEP_CONVERSION.CP_PASTA WHERE UPPER(PASTA_CODIGO) LIKE '%" + cmbPastas.Text.ToUpper() + "%' ORDER BY 1 NULLS FIRST";
                    dtPastas = BLL.CpPastaBLL.Select(strSQL);
                    if (dtPastas.Rows.Count > 0)
                    {
                        cmbPastas.DataSource = dtPastas;
                        cmbPastas.ValueMember = "PASTA_CODIGO";
                        cmbPastas.DisplayMember = "PASTA_CODIGO";
                        cmbPastas.SelectedIndex = 0;
                    }
                }
            }
        }
        //========================================================================================================================================================
            private void cmbPastas_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmbPastas.SelectedIndex >= 0)
                {
                    p = BLL.CpPastaBLL.GetCollection("PASTA_CODIGO = '" + cmbPastas.SelectedValue + "'");
                    if (p.Count > 0)
                    {
                        strSQL = @"SELECT PASTA_ID,  PASTA_CNTR_CODIGO,  PASTA_SBCN_SIGLA,  PASTA_CODIGO,  PASTA_FASE,  PASTA_BLOCO,  PASTA_PROG,  PASTA_OBSERVACAO,                                                                                      
                                          PASTA_REDIRECIONAMENTO, DISC_NOME,  ESCO_DESCRICAO, LOCA_DESCRICAO,  
                                          SSOP_SBCN_SIGLA,  SSOP_CODIGO,  SSOP_DESCRICAO,  AREA_DESCRICAO,  STPA_DESCRICAO,  
                                          PASTA_SSOP_ID,  PASTA_DISC_ID, PASTA_AREA_ID,  PASTA_ESCO_ID,  PASTA_LOCA_ID, PASTA_STPA_ID, PASTA_ZONA_ID, ZONA_NOME, PASTA_RESPONSAVEL, PASTA_REGIAO, PASTA_EXECUTOR, PASTA_TESTE_LIBERADO
                                     FROM EEP_CONVERSION.VW_CP_PASTA 
                                    WHERE PASTA_CNTR_CODIGO = '" + contrato + @"' 
                                      AND PASTA_CODIGO = '" + cmbPastas.SelectedValue + "'";
                        dtVwPastas = BLL.CpPastaBLL.Select(strSQL);
                        if (dtVwPastas.Rows.Count == 0)
                        {
                            MessageBox.Show("Pasta não localizada.");
                        }
                        else
                        {
                            txtDataProgramacao.Text = "";
                            pl.PunchId = 0;
                            mp.MapeId = 0;
                            
                            lblPunchlist.Text = "Punch List - Pasta: " + p[0].PastaCodigo;

                            txtPastaId.Text = dtVwPastas.Rows[0]["PASTA_ID"].ToString();
                            txtSSOP.Text = dtVwPastas.Rows[0]["SSOP_CODIGO"].ToString() + " - " + dtVwPastas.Rows[0]["SSOP_DESCRICAO"].ToString();
                            txtStpaDescricao.Text = dtVwPastas.Rows[0]["STPA_DESCRICAO"].ToString();
                            if (dtVwPastas.Rows[0]["PASTA_PROG"].ToString() != "") txtDataProgramacao.Text = dtVwPastas.Rows[0]["PASTA_PROG"].ToString().Substring(0, 10);
                            txtFase.Text = dtVwPastas.Rows[0]["PASTA_FASE"].ToString();
                            txtBloco.Text = dtVwPastas.Rows[0]["PASTA_BLOCO"].ToString();
                            txtDisciplina.Text = dtVwPastas.Rows[0]["DISC_NOME"].ToString();
                            txtEscopo.Text = dtVwPastas.Rows[0]["ESCO_DESCRICAO"].ToString();
                            txtArea.Text = dtVwPastas.Rows[0]["AREA_DESCRICAO"].ToString();

                            //txtZona.Text = dtVwPastas.Rows[0]["PASTA_ZONA_ID"].ToString() + " - " + dtVwPastas.Rows[0]["ZONA_NOME"].ToString();
                            txtZona.Text = dtVwPastas.Rows[0]["PASTA_ZONA_ID"].ToString();
                            
                            txtResponsavel.Text = dtVwPastas.Rows[0]["PASTA_RESPONSAVEL"].ToString();
                            txtRegiao.Text = dtVwPastas.Rows[0]["PASTA_REGIAO"].ToString();
                            txtExecutor.Text = dtVwPastas.Rows[0]["PASTA_EXECUTOR"].ToString();

                            txtSbcnSigla.Text = dtVwPastas.Rows[0]["SSOP_SBCN_SIGLA"].ToString();
                            txtPastaObservacao.Text = dtVwPastas.Rows[0]["PASTA_OBSERVACAO"].ToString();

                            chkTesteLiberado.Checked = ((dtVwPastas.Rows[0]["PASTA_TESTE_LIBERADO"].ToString() == "1") ? true : false);

                            //Inicializa controles Punchlist
                            InitControlsPunchlist();

                            //GetMovimentoPasta()
                            GetMovimentoPasta();

                            //Habilita cmbResponsavel, chkCancelar e chkTesteLiberado caso o operador seja classe Administrador ou superior
                            strSQL = @"SELECT * FROM EEP_CONVERSION.CP_USUARIO WHERE USUA_ACTIVE = 1 AND LOWER(USUA_LOGIN) = '" + userName.ToLower() + "'";
                            dtClasse = BLL.CpPastaBLL.Select(strSQL);
                            if (dtClasse.Rows.Count > 0)
                            {
                                if (Convert.ToDecimal(dtClasse.Rows[0]["USUA_CLASSE"]) <= 10)
                                {

                                    chkCancelar.Enabled = true;
                                    chkTesteLiberado.Enabled = true;

                                    strSQL = @"SELECT NULL AS USUA_LOGIN, NULL AS DESCRICAO FROM DUAL UNION 
                                           SELECT USUA_LOGIN, DESCRICAO 
                                             FROM (
                                                   SELECT USUA_LOGIN, (LOCA_DESCRICAO || ' - ' || USUA_LOGIN) AS DESCRICAO 
                                                     FROM EEP_CONVERSION.CP_USUARIO, EEP_CONVERSION.CP_LOCALIZACAO 
                                                    WHERE USUA_ACTIVE = 1 AND LOCA_CNTR_CODIGO = '" + contrato + @"' 
                                                      AND LOCA_ID = USUA_LOCA_ID
                                                  )
                                            ORDER BY DESCRICAO NULLS FIRST, USUA_LOGIN NULLS FIRST";
                                    dtResponsaveis = BLL.CpPastaBLL.Select(strSQL);
                                    cmbResponsavel.DataSource = dtResponsaveis;
                                    cmbResponsavel.ValueMember = "USUA_LOGIN";
                                    cmbResponsavel.DisplayMember = "DESCRICAO";
                                    cmbResponsavel.SelectedIndex = 0;
                                    cmbResponsavel.Enabled = true;
                                    cmbResponsavel.Focus();
                                }
                            }
                            else
                            {
                                cmbStatusOperação.DataSource = null;
                                cmbPastas.Focus();
                            }

                            //Get Punchlist
                            GetPunchlist();

                            //Exibe resultado final
                            
                            
                            panelControls.Visible = true;
                        }
                    }
                }
            }
            //========================================================================================================================================================
            private void GetMovimentoPasta()
            {
                strSQL = @"SELECT MOVI_ID AS ID,
                                  TO_CHAR(MOVI_DATE,'DD/MM/YYYY HH24:MI') AS ENTRADA, 
                                  MOVI_USUA_LOGIN AS PARA, 
                                  STMO_DESCRICAO AS AÇÃO,                              
                                  LOCA_DESCRICAO AS DEPARTAMENTO, 
                                  MOVI_CREATED_BY AS ENCAMINHADOR
                             FROM EEP_CONVERSION.VW_CP_MOVIMENTO 
                            WHERE MOVI_PASTA_ID = " + p[0].PastaId.ToString() + @"
                            ORDER BY MOVI_DATE DESC";
                DataTable movimentoPasta = BLL.CpMovimentoBLL.Select(strSQL);

                dgvMovimento.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvMovimento.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

                dgvMovimento.DataSource = movimentoPasta;

                dgvMovimento.Columns[0].Width = 40;
                dgvMovimento.Columns[1].Width = 120;
                dgvMovimento.Columns[2].Width = 120;
                dgvMovimento.Columns[3].Width = 250;
                dgvMovimento.Columns[4].Width = 120;
                dgvMovimento.Columns[5].Width = 120;
                dgvMovimento.Visible = true;

                cmbPastas.Focus();
            }
            //========================================================================================================================================================
            private void dgvMovimento_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                //for (int c = 0; c < 6; c++ )
                //{
                //    dgvMovimento.Rows[0].Cells[c].Style.Font = new Font(dgvMovimento.DefaultCellStyle.Font, FontStyle.Bold);
                //    dgvMovimento.Rows[0].Cells[c].Style.ForeColor = Color.Black;
                //    dgvMovimento.Rows[0].Cells[c].Style.BackColor = Color.Yellow;
                //}
            }
            //========================================================================================================================================================
            private void btnAtribuirResponsabilidade_Click(object sender, EventArgs e)
            {
                //Cria o movimento
                DTO.CpMovimentoDTO m = new DTO.CpMovimentoDTO();
                m.MoviCntrCodigo = contrato;
                //m.MoviUsuaLogin = cmbResponsavel.Text.Split('-')[1].Trim();
                m.MoviUsuaLogin = responsavel;
                m.MoviCreatedBy = userName;
                m.MoviPastaId = p[0].PastaId;
                m.MoviStmoId = Convert.ToDecimal(cmbStatusOperação.SelectedValue);
            

                //Insere primeiro Movimento
                BLL.CpMovimentoBLL.Insert(m, false);

                cmbResponsavel.Enabled = false;
                cmbStatusOperação.Enabled = false;
                btnAtribuirResponsabilidade.Enabled = false;

                //Grava a Observação da Pasta
                strSQL = "UPDATE EEP_CONVERSION.CP_PASTA SET PASTA_OBSERVACAO = '" + txtPastaObservacao.Text + @"' WHERE PASTA_CODIGO = '" + cmbPastas.Text + "'";
                BLL.CpPastaBLL.ExecuteSQLInstruction(strSQL);
                BLL.CpPastaBLL.ExecuteSQLInstruction("COMMIT");

                GetMovimentoPasta();

            }
            //========================================================================================================================================================
            private void chkLeitorAtivo_CheckedChanged(object sender, EventArgs e)
            {
                if (chkLeitorAtivo.Checked) cmbPastas.DropDownStyle = ComboBoxStyle.Simple;
                else
                { cmbPastas.DropDownStyle = ComboBoxStyle.DropDown; }
                cmbPastas.Focus();
            }
            //========================================================================================================================================================
            private void cmbResponsavel_SelectedIndexChanged(object sender, EventArgs e)
            {
                if(cmbResponsavel.Enabled)
                {
                    if (cmbResponsavel.Text != "")
                    {
                        cmbStatusOperação.DataSource = null;
                        string[] arrayResponsavel = cmbResponsavel.Text.Split('-');
                        if (arrayResponsavel.Length == 2) responsavel = arrayResponsavel[1].Trim().ToLower();
                        if (arrayResponsavel.Length == 3) responsavel = arrayResponsavel[1].Trim().ToLower() + "-" + arrayResponsavel[2].Trim().ToLower();
                        strSQL = @" SELECT NULL AS STMO_ID, NULL AS STMO_DESCRICAO FROM DUAL UNION 
                                SELECT STMO_ID, STMO_DESCRICAO 
                                  FROM EEP_CONVERSION.VW_CP_STATUS_USUA_LOCA 
                                 WHERE USUA_ACTIVE = 1 AND LOWER(USUA_LOGIN) = '" + responsavel +
                                 @"' ORDER BY STMO_DESCRICAO NULLS FIRST";
                        dtStatusOperacao = BLL.CpPastaBLL.Select(strSQL);
                        if (dtStatusOperacao.Rows.Count != 0)
                        {
                            cmbStatusOperação.DataSource = dtStatusOperacao;
                            cmbStatusOperação.ValueMember = "STMO_ID";
                            cmbStatusOperação.DisplayMember = "STMO_DESCRICAO";
                            cmbStatusOperação.SelectedIndex = 0;
                            cmbStatusOperação.Enabled = true;
                        }
                    }
                }
            }
            //========================================================================================================================================================
            private void cmbStatusOperação_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Ação
            if (cmbStatusOperação.SelectedIndex > 0)
            {
                btnAtribuirResponsabilidade.Enabled = true;
                txtPastaObservacao.Enabled = true;
            }
        }
            //========================================================================================================================================================
        #endregion

        #region Punchlist
            //========================================================================================================================================================
            private void InitControlsPunchlist()
            {
                txtPunchDescricao.Text = "";
                txtPunchSituacao.Text = "";
                if (cmbRespPunchlist.Items.Count > 0) cmbRespPunchlist.SelectedIndex = 0;
                txtPunchCriadaPor.Text = "";
                cmbTipoPendencia.SelectedIndex = 1;
                dtpConcluida.Value = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"));
                
                txtPunchCreatedDate.Text = "";
                rbNaoImped.Checked = false;
                rbImped.Checked = true;

                cmbPunchStatus.SelectedIndex = 0;
                btnPunchSalvar.Enabled = true;
                btnExcluir.Enabled = true;

                txtPunchDescricao.Enabled = true;
                txtPunchSituacao.Enabled = true;
            }
            //========================================================================================================================================================
            private void GetPunchlist()
            {
                /*
                 SELECT      PUNCH_ID,  PUNCH_CNTR_CODIGO,  PUNCH_PASTA_ID,  PASTA_CODIGO,  PUNCH_DESCRICAO,  PUNCH_TIPE_ID,  PUNCH_DATA_PROMETIDA,  PUNCH_RESPONSIBLE_BY,  PUNCH_STPU_ID,
                             STPU_DESCRICAO,  PUNCH_APPROVED_BY,  PUNCH_APPROVED_DATE,  PUNCH_CREATED_BY,  PUNCH_CREATED_DATE,  PUNCH_DATA_CONCLUIDA,  PUNCH_ARPE_ID,  PUNCH_SITUACAO,  
                             PUNCH_IMPEDITIVA, PUNCH_IMPEDITIVA_DESC
                    FROM     EEP_CONVERSION.VW_CP_PUNCHLIST
                    WHERE    PUNCH_PASTA_ID = 14033  
                    ORDER BY PUNCH_ID DESC*/

                strSQL = @"SELECT PUNCH_ID AS " + asp + "ITEM" + asp +
                         @", PUNCH_DESCRICAO AS " + asp + "DESCRIÇÃO" + asp +
                         @", PUNCH_RESPONSIBLE_BY " + asp + "RESPONSÁVEL" + asp +
                         @", PUNCH_IMPEDITIVA_DESC AS " + asp + "TIPO" + asp +
                         @", STPU_DESCRICAO AS " + asp + "STATUS" + asp +
                         @", PUNCH_APPROVED_BY AS " + asp + "APROVADOR" + asp +
                         @", PUNCH_APPROVED_DATE AS " + asp + "APROVADO EM" + asp +
                         @", PUNCH_CREATED_BY AS " + asp + "CRIADOR" + asp +
                         @", TO_CHAR(PUNCH_CREATED_DATE,'DD/MM/YYYY HH24:MI') AS " + asp + "CRIADO EM" + asp +
                         @", PUNCH_SITUACAO AS " + asp + "SITUAÇÃO" + asp +
                         @"  FROM EEP_CONVERSION.VW_CP_PUNCHLIST WHERE PUNCH_PASTA_ID = " + p[0].PastaId +
                         @"  ORDER BY PUNCH_ID DESC";
                dtPunchlist = BLL.CpMovimentoBLL.Select(strSQL);

                dgvPunchlist.DataSource = dtPunchlist;

                dgvPunchlist.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvPunchlist.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

                dgvPunchlist.Columns[0].Width = 40;     //ID
                dgvPunchlist.Columns[1].Width = 400;    //DESCRIÇÃO
                dgvPunchlist.Columns[2].Width = 100;     //RESPONSÁVEL
                dgvPunchlist.Columns[3].Width = 80;     //TIPO
                dgvPunchlist.Columns[4].Width = 90;     //STATUS
                dgvPunchlist.Columns[5].Width = 90;     //APROVADOR
                dgvPunchlist.Columns[6].Width = 115;     //APROVADO EM
                dgvPunchlist.Columns[7].Width = 90;     //CRIADOR
                dgvPunchlist.Columns[8].Width = 115;    //CRIADO EM
                dgvPunchlist.Columns[9].Width = 300;     //SITUAÇÃO
                dgvPunchlist.Visible = true;

                //Habilita Controles do Usuário
                EnablePunchlist();
            }
            //========================================================================================================================================================
            private void EnablePunchlist()
            {
                btnPunchSalvar.Enabled = false;
                if (pl.PunchId != 0)  //Caso seja Inclusão
                {
                    //txtPunchDescricao.Enabled = false;
                    //txtPunchSituacao.Enabled = false;
                    //cmbRespPunchlist.Enabled = false;
                }
                if (pl.PunchId == 0 && u.UsuaAgCriarPunch == 1)  //Caso seja Inclusão e o usuário esteja habilitado a SALVAR
                {
                    txtPunchDescricao.Enabled = true;
                    txtPunchSituacao.Enabled = true;
                    cmbRespPunchlist.Enabled = true;
                    btnPunchSalvar.Enabled = true;
                }
                else if (u.UsuaAgStatusPunch == 1)
                {
                    if (pl.PunchStpuId != 1)
                    {
                        rbImped.Enabled = true;
                        rbNaoImped.Enabled = true;
                        cmbPunchStatus.Enabled = true;
                        txtPunchDescricao.Enabled = true;
                        txtPunchSituacao.Enabled = true;
                        cmbRespPunchlist.Enabled = true;
                        btnPunchSalvar.Enabled = true;
                        btnExcluir.Enabled = true;
                        btnTransfer.Enabled = true;
                    }
                }
            }
            //========================================================================================================================================================
            private void btnPunchSalvar_Click(object sender, EventArgs e)
            {
                PreparaExecutaSalvamentoPunchList();
            }
            //========================================================================================================================================================
            private void btnTransfer_Click(object sender, EventArgs e)
            {
                if (pl.PunchId != 0)
                {
                    DialogResult result = MessageBox.Show("Confirma a transferência da pendência?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        //ATRIBUI ITEM ATUAL PUNCH LIST DE ORIGEM COMO ATENDIDA
                        strSQL = @"UPDATE EEP_CONVERSION.CP_PUNCHLIST SET PUNCH_STPU_ID = 1 WHERE PUNCH_ID = " + pl.PunchId.ToString();
                        BLL.CpPunchlistBLL.ExecuteSQLInstruction(strSQL);
                        //GRAVA NOVO ITEM DE PUNCH LIST
                        pl.PunchId = 0;
                        PreparaExecutaSalvamentoPunchList();
                    }
                }
            }
            //========================================================================================================================================================
            private void PreparaExecutaSalvamentoPunchList()
            {
                txtPunchDescricao.Text = txtPunchDescricao.Text.Trim();
                if (txtPunchDescricao.Text == "")
                {
                    MessageBox.Show("Descrição de Punch List é um atributo de preenchimento obrigatório.");
                }
                else if (cmbTipoPendencia.SelectedIndex == 0)
                {
                    MessageBox.Show("Tipo de Pendência é um atributo de seleção obrigatória.");
                }
                else if (cmbRespPunchlist.SelectedIndex == 0)
                {
                    MessageBox.Show("Responsável pela pendência é um atributo de seleção obrigatória.");
                }
                else
                {
                    pl.PunchCntrCodigo = contrato;
                    pl.PunchDescricao = txtPunchDescricao.Text;
                    pl.PunchSituacao = txtPunchSituacao.Text.Trim();

                    if (pl.PunchId == 0)
                    {
                        pl.PunchCreatedBy = userName;
                        pl.PunchPastaId = p[0].PastaId;
                        pl.PunchTipeId = Convert.ToDecimal(cmbTipoPendencia.SelectedValue);
                        pl.PunchDataPrometida = DateTime.Today;
                        pl.PunchDataConcluida = null;
                        pl.PunchImpeditiva = 1;

                        pl.PunchStpuId = 0;
                        pl.PunchResponsibleBy = cmbRespPunchlist.Text;
                        pl.PunchCreatedBy = u.UsuaLogin;
                        pl.PunchCreatedDate = DateTime.Now;
                        BLL.CpPunchlistBLL.Insert(pl, false);
                    }
                    else if (pl.PunchId != 0)
                    {
                        pl.PunchImpeditiva = 0;
                        if (rbImped.Checked)
                        {
                            pl.PunchImpeditiva = 1;
                            if (pl.PunchApprovedDate == null)
                            {
                                pl.PunchApprovedBy = u.UsuaLogin;
                                pl.PunchApprovedDate = DateTime.Now;
                            }
                        }

                        pl.PunchStpuId = 0;
                        if (Convert.ToDecimal(cmbPunchStatus.SelectedValue) == 1)
                        {
                            pl.PunchStpuId = 1;
                            pl.PunchApprovedBy = u.UsuaLogin;
                            pl.PunchApprovedDate = DateTime.Now;
                        }
                        pl.PunchResponsibleBy = cmbRespPunchlist.Text;

                        BLL.CpPunchlistBLL.Update(pl);
                        pl.PunchId = 0;
                    }
                    //GetPunchlist
                    GetPunchlist();
                    txtPunchDescricao.Text = "";
                    txtPunchSituacao.Text = "";
                    dtpPrometida.Value = DateTime.Now;
                    dtpConcluida.Value = DateTime.Now;
                    txtAreaResp.Text = "";
                }
            }
            //========================================================================================================================================================
            private void dgvPunchlist_SelectionChanged(object sender, EventArgs e)
            {
                if (dgvPunchlist.SelectedRows.Count != 0)
                {
                    CarregaPunchlistForm();
                }
            }
            //========================================================================================================================================================
            private void CarregaPunchlistForm()
            {
                //Propriedades do item da Punchlist
                SetPropertiesPunchlist();

                //Preenche Atributos de tela
                FillPunchlistScreenAttributes();
            }
            //========================================================================================================================================================
            private void FillPunchlistScreenAttributes()
            {
                //Descrição
                txtPunchDescricao.Text = pl.PunchDescricao;
                // ResponsibleBy
                cmbRespPunchlist.Text = pl.PunchResponsibleBy;
                //Classificação
                if (pl.PunchImpeditiva == 0)
                {
                    rbNaoImped.Checked = true;
                }
                else
                {
                    rbImped.Checked = true;
                }
                //Aprovador
                txtPunchAprovadoPor.Text = pl.PunchApprovedBy;
                txtPunchApprovedDate.Text = pl.PunchApprovedDate.ToString();
                //Identificação
                txtPunchCriadaPor.Text = pl.PunchCreatedBy;
                txtPunchCreatedDate.Text = pl.PunchCreatedDate.ToString();

                //Status
                cmbPunchStatus.SelectedIndex = 1;
                if (pl.PunchStpuId == 1) cmbPunchStatus.SelectedIndex = 2;
                //Situação
                txtPunchSituacao.Text = pl.PunchSituacao;

                //Habilitação de atributos de tela
                if (pl.PunchStpuId == 0) //Punchlist não atendida
                {
                    EnablePunchlist();
                }
                else   //Punchlist atendida
                {
                    txtPunchDescricao.Enabled = false;
                    txtPunchSituacao.Enabled = false;
                    rbNaoImped.Enabled = false;
                    rbImped.Enabled = false;
                    cmbPunchStatus.Enabled = false;
                    dtpPrometida.Enabled = false;
                    dtpConcluida.Enabled = false;
                    btnPunchSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                }
            }
            //========================================================================================================================================================
            private void SetPropertiesPunchlist()
            {
                string status = "";
                pl.PunchId = Convert.ToDecimal(dgvPunchlist.CurrentRow.Cells["ITEM"].Value.ToString());
                pl.PunchCntrCodigo = p[0].PastaCntrCodigo;
                pl.PunchPastaId = p[0].PastaId;

                pl.PunchDescricao = dgvPunchlist.CurrentRow.Cells["DESCRIÇÃO"].Value.ToString();
                pl.PunchResponsibleBy = dgvPunchlist.CurrentRow.Cells["RESPONSÁVEL"].Value.ToString();
                if (dgvPunchlist.CurrentRow.Cells["TIPO"].Value.ToString().ToUpper() == "NÃO IMPEDITIVO")
                {
                    pl.PunchImpeditiva = 0;
                }
                else
                {
                    pl.PunchImpeditiva = 1;
                }
                pl.PunchApprovedBy = dgvPunchlist.CurrentRow.Cells["APROVADOR"].Value.ToString();
                pl.PunchCreatedBy = dgvPunchlist.CurrentRow.Cells["CRIADOR"].Value.ToString();
                pl.PunchCreatedDate = Convert.ToDateTime(dgvPunchlist.CurrentRow.Cells["CRIADO EM"].Value);
                status = dgvPunchlist.CurrentRow.Cells["STATUS"].Value.ToString();
                pl.PunchStpuId = 0;
                if (status == "Atendido") pl.PunchStpuId = 1;
                if (dgvPunchlist.CurrentRow.Cells["APROVADO EM"].Value != DBNull.Value) pl.PunchApprovedDate = Convert.ToDateTime(dgvPunchlist.CurrentRow.Cells["APROVADO EM"].Value);
                pl.PunchApprovedBy = dgvPunchlist.CurrentRow.Cells["APROVADOR"].Value.ToString();
                pl.PunchSituacao = dgvPunchlist.CurrentRow.Cells["SITUAÇÃO"].Value.ToString();
            }
            //========================================================================================================================================================
            private void rbImped_CheckedChanged(object sender, EventArgs e)
            {
                rbNaoImped.Checked = false;
                pl.PunchApprovedBy = userName;
                pl.PunchApprovedDate = DateTime.Now;
            }
            //========================================================================================================================================================
            private void rbNaoImped_CheckedChanged(object sender, EventArgs e)
            {
                rbImped.Checked = false;
                pl.PunchApprovedBy = userName;
                pl.PunchApprovedDate = DateTime.Now;
            }
            //========================================================================================================================================================
            private void cmbPunchStatus_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cmbPunchStatus.SelectedIndex > 0)
                {
                    pl.PunchStpuId = Convert.ToDecimal(cmbPunchStatus.SelectedValue);
                    //pl.PunchStpuDate = DateTime.Now;
                }
            }
            //========================================================================================================================================================
        #endregion
            //========================================================================================================================================================
            private void btnFOSE_Click(object sender, EventArgs e)
            {
                lblFOSEMessage.Visible = true;
                pBox.Visible = true;
                Application.DoEvents();
                // start background operation
                this.backgroundWorker.RunWorkerAsync();
            }
            //========================================================================================================================================================
            private void btnZona_Click(object sender, EventArgs e)
            {
                if (cmbPastas.Text != "")
                {
                    DialogResult result = MessageBox.Show("Confirma a mudança de Executor e Teste?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.OK)
                    {
                        int liberar = (chkTesteLiberado.Checked) ? 1: 0;

                        strSQL = "UPDATE EEP_CONVERSION.CP_PASTA SET PASTA_EXECUTOR = '" + txtExecutor.Text + @"', PASTA_TESTE_LIBERADO = " + liberar + " WHERE PASTA_CODIGO = '" + cmbPastas.Text + "'";
                        BLL.CpPastaBLL.ExecuteSQLInstruction(strSQL);
                        BLL.CpPastaBLL.ExecuteSQLInstruction("COMMIT");
                    }
                }
                else
                {
                    MessageBox.Show("Não foi encontrado nem uma Pasta para Salvar.", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //========================================================================================================================================================
            private void cmbRespPunchlist_SelectedIndexChanged(object sender, EventArgs e)
            {
                DataTable dtAUX = null;
                txtAreaResp.Text = "";
                if (cmbRespPunchlist.Text != "" && cmbRespPunchlist.Text != "System.Data.DataRowView")
                {
                    txtAreaResp.Text = cmbRespPunchlist.SelectedValue.ToString().Trim();
                    strSQL = @"SELECT ARPE_ID FROM EEP_CONVERSION.CP_AREA_RESP_PENDENCIA WHERE ARPE_AGENTE = '" + cmbRespPunchlist.Text.ToString() + "' AND ARPE_DESCRICAO = '" + cmbRespPunchlist.SelectedValue.ToString() + "' ORDER BY ARPE_AGENTE";
                    dtAUX = BLL.CpPunchlistBLL.Select(strSQL);
                    pl.PunchArpeId = Convert.ToDecimal(dtAUX.Rows[0]["ARPE_ID"]);
                }
            }
            //========================================================================================================================================================
            private void btnExcluir_Click(object sender, EventArgs e)
            {
                if (pl.PunchId != 0)
                {
                    DialogResult result = MessageBox.Show("Confirma a exclusão da pendência?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        BLL.CpPunchlistBLL.Delete(pl);
                        GetPunchlist();
                    }
                }
            }
            //========================================================================================================================================================
            private void btnRetornoPendencia_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            //========================================================================================================================================================
            private void chkCancelar_CheckedChanged(object sender, EventArgs e)
            {
                if (chkCancelar.Checked)
                {
                    DialogResult result = MessageBox.Show("Confirma o cancelamento da Pasta?", "Atenção!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        strSQL = "UPDATE EEP_CONVERSION.CP_PASTA SET PASTA_STPA_ID = 3 WHERE PASTA_ID = " + txtPastaId.Text;
                        BLL.CpPastaBLL.ExecuteSQLInstruction(strSQL);
                        chkCancelar.Enabled = false;
                        Application.DoEvents();
                        MessageBox.Show("Pasta cancelada com sucesso.");
                    }
                    else chkCancelar.Checked = false;
                }
            }
            #region Assincronous Task
            //===================================================================================
            private void OnDoWork(object sender, DoWorkEventArgs e)
            {
                // Report progress
                this.backgroundWorker.ReportProgress(-1, string.Format("Aguarde...", ""));
                strSQL = @"SELECT DISTINCT FOSE_NUMERO, ATIV_SIG FROM EEP_CONVERSION.VW_AVN_FOSE_BASE WHERE PASTA = '" + cmbPastas.Text + @"' ORDER BY FOSE_NUMERO";

                DataTable movimentoPasta = BLL.CpMovimentoBLL.Select(strSQL);

                lblFOSEMessage.Visible = false;
                pBox.Visible = false;
                Application.DoEvents();

                dgvFOSE.RowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvFOSE.AlternatingRowsDefaultCellStyle.BackColor = Color.DarkGray;

                dgvFOSE.DataSource = movimentoPasta;

                dgvFOSE.Columns[0].Width = 120;
                dgvFOSE.Columns[1].Width = 120;

                dgvFOSE.Visible = true;

                cmbPastas.Focus();
            }
            //===================================================================================
            private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                if (e.UserState is String)
                {
                    this.lblFOSEMessage.Text = (String)e.UserState;
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
                //else
                //{
                //    if (e.Error != null)
                //    {
                //        //this.labelProgress.Text = "Falha na operação: " + e.Error.Message;
                //        this.pBox.Image = Properties.Resources.ErrorImage;
                //    }
                //    else
                //    {

                //        // Create the parameterTitulo report parameter
                //        titulo = "Acompanhamento de Montagem de Tubulações " + cmbFPSO.Text;
                //        ReportParameter parameterTitulo = new ReportParameter();
                //        parameterTitulo.Name = "pTitulo";
                //        parameterTitulo.Values.Add(titulo);

                //        // Create the parameterSubtitulo report parameter
                //        string subTitulo = "";
                //        ReportParameter parameterSubtitulo = new ReportParameter();
                //        parameterSubtitulo.Name = "pSubTitulo";
                //        parameterSubtitulo.Values.Add(subTitulo);

                //        reportViewer1.Reset();
                //        reportViewer1.ProcessingMode = ProcessingMode.Local;
                //        LocalReport report = reportViewer1.LocalReport;
                //        report.ReportPath = systemRepository + @"RDLC\rdlcMontagemTubulacao.rdlc";

                //        ReportDataSource rds = new ReportDataSource("dsMontagemTubulacao", csr);
                //        report.DataSources.Add(rds);

                //        CollectionDTOBindingSource.DataSource = csr;
                //        reportViewer1.LocalReport.DataSources.Add(rds);
                //        // Set the report parameters for the report
                //        reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterTitulo, parameterSubtitulo });

                //        this.ParentForm.WindowState = FormWindowState.Maximized;
                //        this.WindowState = FormWindowState.Maximized;

                //        this.reportViewer1.RefreshReport();
                //        this.reportViewer1.Visible = true;
                //        this.btnExcel.Visible = true;
                //    }
                //}
                //// restore button states
                //lblProgress.Visible = false;
                //this.btnExecute.Enabled = true;
            }
            #endregion

        //========================================================================================================================================================
    }
}