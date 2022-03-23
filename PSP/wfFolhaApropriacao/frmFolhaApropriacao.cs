using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridCarregamento.DAL;
using System.Collections;
using System.Collections.Specialized;

using Excel = Microsoft.Office.Interop.Excel;

namespace wfFolhaApropriacao
{
    public partial class frmFolhaApropriacao : Form
    {
        public frmFolhaApropriacao()
        {
            //frmSplash f = new frmSplash();
            //f.ShowDialog();
            InitializeComponent();

            TabelaDAL tabelaNeg = new TabelaDAL();
            cbGrupo.DataSource = tabelaNeg.ListGroup();
            cbGrupo.DisplayMember = "Descricao";
            cbGrupo.ValueMember = "ID";
            cbGrupo.SelectedIndex = -1;

            txtDateSelect.Text = DateTime.Now.Date.AddDays(-1).ToString("dd/MM/yyyy");
            PreencherValidation();
        }
        private void Clear(bool status)
        {
          //  btnAddMatricula.Visible = status;
            btnAddTarefa.Enabled = status;
            btnCancelar.Enabled = status;
            btnSalvar.Enabled = status;            
        }
        private void PreencherValidation()
        {            
            dataGridValidation.Rows.Clear();
            TabelaDAL tabelaNeg = new TabelaDAL();
            DataTable dataTableLine = new DataTable();
            dataTableLine = tabelaNeg.ListValidation(txtDateSelect.Text);

            int cnt = 0;
            if (dataTableLine.Rows.Count != 0)
            {
                //dataGridValidation.Columns[1].Visible = true;
                while (dataTableLine.Rows.Count != cnt)
                {
                    if (dataTableLine.Rows[cnt][0].ToString() == "0")
                    {
                        dataGridValidation.Rows.Add(wfFolhaApropriacao.Properties.Resources.salvar);
                    }
                    else
                    {
                        dataGridValidation.Rows.Add(wfFolhaApropriacao.Properties.Resources.cancelar);
                    }
                    dataGridValidation.Rows[cnt].Cells[1].Value = dataTableLine.Rows[cnt][1].ToString();
                    dataGridValidation.Rows[cnt].Cells[2].Value = dataTableLine.Rows[cnt][2].ToString();
                    dataGridValidation.Rows[cnt].Cells[3].Value = dataTableLine.Rows[cnt][3].ToString();
                    dataGridValidation.Rows[cnt].Cells[4].Value = dataTableLine.Rows[cnt][4].ToString();
                    dataGridValidation.Rows[cnt].Cells[5].Value = dataTableLine.Rows[cnt][5].ToString();
                    cnt++;
                }
             //   dataGridValidation.Columns[1].Visible = false;
                pnValidacao.Visible = true;
            }
            else
            {
                pnValidacao.Visible = false;
            }
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (e.ToString() != "")
            {
                CarregaGeral();
            }

            Clear(true);
            btnCalendar.Enabled = false;
            txtBarcode.Enabled = false;
            cbEquipe.Enabled = false;
            cbArea.Enabled = false;
            cbGrupo.Enabled = false;
            txtEquipe.Enabled = false;
            btEquipe.Enabled = false;
        }

        private void CarregaGeral()
        {
            TabelaDAL tabelaNeg = new TabelaDAL();

            DataTable dt = tabelaNeg.GetTeamCodeByID(cbEquipe.SelectedValue.ToString()); //Lista Cód da Equipe
            lblEquipe.Text = "";
            if (dt.Rows.Count > 0) lblEquipe.Text = cbEquipe.SelectedValue.ToString() + " / " + dt.Rows[0]["TEAM_CODE"].ToString();
            lblEquipeH.Visible = true;
            lblEquipe.Visible = true;

            conGrid1.teamIdGlobal = Convert.ToInt32(cbEquipe.SelectedValue.ToString());
            conGrid1.dateSelect = txtDateSelect.Text;
            conGrid1.HoraSelect(Convert.ToDateTime(txtDateSelect.Text));

            DataTable dtbTabela = new DataTable();
            dtbTabela = tabelaNeg.ListCraftUnion(Convert.ToInt32(cbEquipe.SelectedValue.ToString()), txtDateSelect.Text); //Lista primeiro Funcionários

            DataTable dtbQtdLocais = new DataTable();
            dtbQtdLocais = tabelaNeg.ListCraftUnion(Convert.ToInt32(cbEquipe.SelectedValue.ToString()), txtDateSelect.Text); //Lista primeiro Funcionários

            if (conGrid1.DataSourceFill(tabelaNeg.ListTimeSheets(Convert.ToInt32(cbEquipe.SelectedValue.ToString()), txtDateSelect.Text), Convert.ToInt32(cbEquipe.SelectedValue.ToString()), txtDateSelect.Text) == false)
            {
                conGrid1.teamIdGlobal = Convert.ToInt32(cbEquipe.SelectedValue.ToString());
                conGrid1.dateSelect = txtDateSelect.Text;
                conGrid1.HoraSelect(Convert.ToDateTime(txtDateSelect.Text));
                conGrid1.DataSourceLines(dtbTabela);
                conGrid1.Select();
            }
            conGrid1.LeaderSupervisor(Convert.ToInt32(cbEquipe.SelectedValue.ToString())); //Retorna Lider e Supervisor

            if (dtbTabela.Rows.Count > 0)
            {
                conGrid1.CarregaLocal(dtbTabela, dtbQtdLocais);
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult;
            myDialogResult = MessageBox.Show("Deseja salvar a folha de apropriação?", "Salvar", MessageBoxButtons.YesNo);

            if (myDialogResult == DialogResult.Yes)
            {
                if (cbEquipe.Text != "")
                {

                    bool inconsistency = conGrid1.Inconsistency();
                    if (inconsistency == false)
                    {
                        myDialogResult = DialogResult.Yes;
                    }
                    else
                    {
                        myDialogResult = MessageBox.Show("A Folha de Apropriação possui inconsistências, se for salva não será contabilizada para apropriação, será necessário corrigir agora ou futuramente. Deseja salvar mesmo assim?", "Inconsistências", MessageBoxButtons.YesNo);
                    }

                    if (myDialogResult == DialogResult.Yes)
                    {
                        if (conGrid1.Save(txtDateSelect.Text, Convert.ToDecimal(cbEquipe.SelectedValue), Convert.ToDecimal(cbArea.SelectedValue), Convert.ToDecimal(cbGrupo.SelectedValue)) == true)
                        {
                            MessageBox.Show("Salvo com sucesso!");
                            resetForm();
                            PreencherValidation();
                            txtEquipe.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Inconsistência ao salvar!");
                            txtEquipe.Focus();
                        }
                    }
                }
            }
        }        
        private void resetForm()
        {
            cbGrupo.SelectedIndex = -1;
            cbArea.DataSource = null;
            cbArea.Refresh();
            cbEquipe.DataSource = null;
            cbEquipe.Refresh();
            lblEquipeH.Visible = false;
            lblEquipe.Text = "";
            txtBarcode.Text = "";
            txtEquipe.SelectAll();
            conGrid1.ClearAll();
            Clear(false);
            cbGrupo.Enabled = true; 
            cbEquipe.Enabled = true;
            cbArea.Enabled = true;
            btnCalendar.Enabled = true;
            txtBarcode.Enabled = true;
            txtEquipe.Enabled = true;
            btEquipe.Enabled = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult myDialogResult;
            myDialogResult = MessageBox.Show("Deseja cancelar a folha de apropriação?", "Cancelar", MessageBoxButtons.YesNo);

            if (myDialogResult == DialogResult.Yes)
            {
                resetForm();
                txtEquipe.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            frmFindCraft f = new frmFindCraft(conGrid1.ListCraftUsed());     
            f.ShowDialog();
            if (f.strCraftId != null)
            {
                string matricula;
                string name;
                string[] strCraft = f.strCraftId.Split('|');

                matricula = strCraft[0];
                name = strCraft[1];
                conGrid1.DataSourceLineOne(matricula, name, "D", "");
            }
        }
        private void btnAddTarefa_Click(object sender, EventArgs e)
        {
            frmFindActivities f = new frmFindActivities(conGrid1.ListActivitiesUsed()); 
            f.ShowDialog();

            if (f.strTitleId != null)
            {
                string id;
                string title;
                string[] strActivities = f.strTitleId.Split('|');

                id = strActivities[0];
                title = strActivities[1];
                conGrid1.DataSourceColumnOne(id, title);
            }
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtBarcode.TextLength == 14)
                {
                    TabelaDAL tabelaNeg = new TabelaDAL();
                    if (tabelaNeg.DigitoVerificador(txtBarcode.Text.Substring(0, 13)).ToString() == txtBarcode.Text.Substring(13, 1))
                    {
                        txtDateSelect.Text = Convert.ToDateTime(txtBarcode.Text.Substring(6, 2) + "/" + txtBarcode.Text.Substring(4, 2) + "/" + txtBarcode.Text.Substring(0, 4)).ToString("dd/MM/yyyy");
                        cbArea.SelectedValue = tabelaNeg.TeamArea(Convert.ToInt16(txtBarcode.Text.Substring(8, 5)));
                        cbEquipe.SelectedValue = Convert.ToInt16(txtBarcode.Text.Substring(8, 5));
                        txtBarcode.Enabled = false;
                        Clear(true);
                        comboBox1_SelectionChangeCommitted(sender, e);
                        PreencherValidation();
                    }
                    else
                        MessageBox.Show("Barcode não é valido");
                }
                if (txtBarcode.Text.Length != 0)
                {
                    btnCalendar.Enabled = false;
                    cbEquipe.Enabled = false;                    
                    cbArea.Enabled = false;
                    cbGrupo.Enabled = false;
                    txtEquipe.Enabled = false;
                    btEquipe.Enabled = false;
                }
                else
                {
                    btnCalendar.Enabled = true;
                    cbEquipe.Enabled = true;
                    cbArea.Enabled = true;
                    cbGrupo.Enabled = true;
                    txtEquipe.Enabled = true;
                    btEquipe.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Barcode não é valido!");
            }
        }
        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar f = new frmCalendar();
            f.ShowDialog();
            if (f.selectDate != null && f.selectDate != "")
            {
                resetForm();
                txtDateSelect.Text = f.selectDate;
                PreencherValidation();
            }
        }
        private void dataGridValidation_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TabelaDAL tabelaNeg = new TabelaDAL();
                cbGrupo.SelectedValue = tabelaNeg.TeamGroup(Convert.ToDecimal(dataGridValidation.Rows[e.RowIndex].Cells[1].Value));
                cbArea.SelectedValue = tabelaNeg.TeamArea(Convert.ToDecimal(dataGridValidation.Rows[e.RowIndex].Cells[1].Value));
                cbEquipe.SelectedValue = dataGridValidation.Rows[e.RowIndex].Cells[1].Value;
                comboBox1_SelectionChangeCommitted(sender, e);
            }
            catch { }
        }
        private void frmFolhaApropriacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 112)
            {
                frmSplash f = new frmSplash();
                f.ShowDialog();
            }
        }
        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbArea.Text != "System.Data.DataRowView" && cbArea.Text != "" && cbArea.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    TabelaDAL tabelaNeg = new TabelaDAL();
                    cbEquipe.DataSource = tabelaNeg.ListTeamArea(Convert.ToDecimal(cbArea.SelectedValue), txtDateSelect.Text, Convert.ToDecimal(cbGrupo.SelectedValue));
                    cbEquipe.DisplayMember = "Descricao";
                    cbEquipe.ValueMember = "ID";
                    cbEquipe.SelectedIndex = -1;
                }
                else
                {
                    cbEquipe.SelectedIndex = -1;
                }
            }
            catch
            {
                cbEquipe.SelectedIndex = -1;
            }
        }
        private void cbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbGrupo.Text != "System.Data.DataRowView" && cbGrupo.Text != "")
                {
                    TabelaDAL tabelaNeg = new TabelaDAL();
                    cbArea.DataSource = tabelaNeg.ListAreaGroup(Convert.ToDecimal(cbGrupo.SelectedValue), txtDateSelect.Text);
                    cbArea.DisplayMember = "Descricao";
                    cbArea.ValueMember = "ID";
                    cbArea.SelectedIndex = -1;
                }
                else
                {
                    cbArea.SelectedIndex = -1;
                }
            }
            catch
            {
                cbArea.SelectedIndex = -1;
            }
        }
        private void dataGridValidation_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                // menu.Items.Add("Excluir Participante");
                menu.Items.Add("Excluir Apropriação");
                menu.Show(this.dataGridValidation, new Point(e.X, e.Y));
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClickedExcluirLine);
            }
        }
        void menu_ItemClickedExcluirLine(object sender, ToolStripItemClickedEventArgs e)
        {
            string comando = string.Empty;
            try
            {
                int currentLine = dataGridValidation.CurrentCell.RowIndex;
                ContextMenuStrip menu = (ContextMenuStrip)sender;
                menu.Hide();
                DialogResult myDialogResult;
                switch (e.ClickedItem.Text)
                {
                    case "Excluir Apropriação":
                        myDialogResult = MessageBox.Show("Tem certeza que deseja excluir a Apropriação da Equipe " + dataGridValidation.Rows[currentLine].Cells[2].Value.ToString() + "?", "Excluir Apropriação", MessageBoxButtons.YesNo);

                        if (myDialogResult == DialogResult.Yes)
                        {
                            conGrid1.DeleteTime(txtDateSelect.Text,Convert.ToDecimal(dataGridValidation.Rows[currentLine].Cells[1].Value));
                            PreencherValidation();
                        }
                        break;                   
                }
                if (!comando.Equals(""))
                    System.Diagnostics.Process.Start(comando);
            }
            catch { }
        }

        private void btEquipe_Click(object sender, EventArgs e)
        {
            consultaEquipe();
        }

        private void txtEquipe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                consultaEquipe();
            }
        }
        
        private void consultaEquipe()
        {
            try
            {
                TabelaDAL tabelaNeg = new TabelaDAL();
                DataTable dtLinha = new DataTable();

                dtLinha = tabelaNeg.ListarSuperiores(txtEquipe.Text, txtDateSelect.Text);

                if (dtLinha.Rows.Count == 0)
                {
                    MessageBox.Show("Código de Equipe não encontrado.\nVerifique se digitou corretamente.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtEquipe.SelectAll();
                //}
                //else if (Convert.ToInt32(dtLinha.Rows[0]["STATUS"]) == 0)
                //{
                //    MessageBox.Show("Esta Equipe encontra-se atualmente Inativa.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                //    txtEquipe.SelectAll();
                }
                else if (dtLinha.Rows.Count > 1 && Convert.ToInt32(dtLinha.Rows[1]["STATUS"]) == 1)
                {
                    MessageBox.Show("Foi encontrado mais de uma Equipe Ativa com esse Código.\nPor favor consulte o Portal / Cadastros / Equipes.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtEquipe.SelectAll();
                }
                else if (Convert.ToInt32(dtLinha.Rows[0]["QTD_FUNCIONARIO_EQUIPE"]) == 0)
                {
                    MessageBox.Show("Não há colaboradores associados a esta Equipe neste período", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtEquipe.SelectAll();
                }
                else if (dtLinha.Rows[0]["TEAM_TIPO_MO"].ToString() != "MOD")
                {
                    MessageBox.Show("Não é possivel apropriar horas para Equipe MOI.", "ATENÇÃO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txtEquipe.SelectAll();
                }
                else {
                    Clear(true);

                    btnCalendar.Enabled = false;
                    cbGrupo.Enabled = false;
                    cbArea.Enabled = false;
                    cbEquipe.Enabled = false;
                    txtEquipe.Enabled = false;
                    btEquipe.Enabled = false;

                    if (dtLinha.Rows[0]["GROUP_ID"].ToString().Length != 0) cbGrupo.SelectedValue = dtLinha.Rows[0]["GROUP_ID"].ToString();
                    if (dtLinha.Rows[0]["AREA_ID"].ToString().Length != 0) cbArea.SelectedValue = dtLinha.Rows[0]["AREA_ID"].ToString();
                    if (dtLinha.Rows[0]["TEAM_ID"].ToString().Length != 0) cbEquipe.SelectedValue = dtLinha.Rows[0]["TEAM_ID"].ToString();

                    CarregaGeral();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFolhaApropriacao_Load(object sender, EventArgs e)
        {
            dtApropriacao.MaxDate = DateTime.Now.Date;
            dtApropriacao.Value = DateTime.Now.Date.AddDays(-1);

            dtpDe.MaxDate = DateTime.Now.Date;
            dtpDe.Value = DateTime.Now.Date;

            dtpAte.MaxDate = DateTime.Now.Date;
            dtpAte.MinDate = DateTime.Now.Date;

            txtEquipe.Focus();
        }
        private void btSemApropricao_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                lblProcessando.Text = "Processando...";
                
                    DateTime dt1 = Convert.ToDateTime(dtpDe.Value);
                    DateTime dt2 = Convert.ToDateTime(dtpAte.Value);

                    TabelaDAL tabelaNeg = new TabelaDAL();
                    DataTable dtConsulta = new DataTable();

                    object misValue = System.Reflection.Missing.Value;

                    Excel.Application App = new Excel.Application();
                    Excel.Workbook WorkBook = App.Workbooks.Add(misValue);
                    Excel.Worksheet WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);

                    dtConsulta = tabelaNeg.ListarSemApropriacao(dt1, dt2);
                    
                    //Cabeçalho
                    for (int i = 1; i <= dtConsulta.Columns.Count; i++)
                    {
                        WorkSheet.Cells[3, i] = dtConsulta.Columns[i - 1].ColumnName;
                    }

                    //seleção das linhas
                    for (int o = 0; o < dtConsulta.Rows.Count; o++)
                    {
                        //Preenchimento das celulas
                        for (int j = 0; j < dtConsulta.Columns.Count; j++)
                        {
                            WorkSheet.Cells[o + 4, j + 1] = dtConsulta.Rows[o][j].ToString();
                        }
                    }

                    App.Columns.AutoFit();

                    WorkSheet.Cells[1, 1] = "Colaboradores sem apropriação de: " + dt1.ToString("dd/MM/yy") + " a " + dt2.ToString("dd/MM/yy");                                 //WorkSheet.Range["B1"].Value = "Colaboradores";

                    App.Visible = true;

                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                lblProcessando.Text = "";
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpDe_ValueChanged(object sender, EventArgs e)
        {
            dtpAte.MinDate = dtpDe.Value;
        }
    }
}
