using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace Replat
{
    public partial class frmDisponiveis : Form
    {
        public frmDisponiveis()
        {
            InitializeComponent();
        }

        private void frmDisponiveis_Load(object sender, EventArgs e)
        {
            try
            {
                carregaGrid();

                //Não deixar ordenar na coluna
                foreach (DataGridViewColumn coluna in gvInterfaces.Columns)
                    coluna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void carregaGrid()
        {
            try
            {
                ckbTodos.Checked = false;
                gvInterfaces.Rows.Clear();

                string strSQL = @"SELECT 
                                        SCHE_INTERFACES, SCHE_TABELAS
                                    FROM 
                                        CI_SCHEDULE
                                    WHERE
                                        SCHE_DISPONIVEL = 1
                                    ORDER BY
                                        SCHE_ID";

                DataTable dtbTabela = new DataTable();
                dtbTabela = RfNfEntradaBLL.Select(strSQL);

                for (int i = 0; i < dtbTabela.Rows.Count; i++)
                {
                    DataTable dtbQTDE = new DataTable();
                    dtbQTDE = RfNfEntradaBLL.Select("SELECT NVL(SUM(DECODE(AMBIENTE, 'P', 0, 1)), 0) QUAL, NVL(SUM(DECODE(AMBIENTE, 'P', 1, 0)), 0) PROD FROM " + dtbTabela.Rows[i][1].ToString());

                    gvInterfaces.Rows.Add(false, dtbTabela.Rows[i][0].ToString(), dtbQTDE.Rows[0][0].ToString(), dtbQTDE.Rows[0][1].ToString(), dtbTabela.Rows[i][1].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ckbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTodos.Checked)
            {
                for (int i = 0; i < gvInterfaces.Rows.Count; i++)
                {
                    gvInterfaces.Rows[i].Cells[0].Value = "True";
                }
            } 
            else
            {
                for (int i = 0; i < gvInterfaces.Rows.Count; i++)
                {
                    gvInterfaces.Rows[i].Cells[0].Value = "False";
                }
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult myDialogResult = MessageBox.Show("Deseja Realmente Limpar todas as Interfaces Selecionadas?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (myDialogResult == DialogResult.Yes)
                {
                    this.Cursor = Cursors.WaitCursor;

                    for (int i = 0; i < gvInterfaces.Rows.Count; i++)
                    {
                        if (Convert.ToString(gvInterfaces.Rows[i].Cells[0].Value) == "True")
                        {
                            string strSQL = @"TRUNCATE TABLE " + gvInterfaces.Rows[i].Cells[4].Value;
                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
                        }
                    }

                    carregaGrid();

                    //MessageBox.Show("Todos as Interfaces Selecionadas Limpas com Sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            carregaGrid();
        }
    }
}
