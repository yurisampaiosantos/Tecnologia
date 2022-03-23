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
    public partial class frmAgendarEnviar : Form
    {
        public frmAgendarEnviar()
        {
            InitializeComponent();
        }

        private void frmAgendarEnviar_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dtConsulta = new DataTable();
                dtConsulta = RfNfEntradaBLL.Select("SELECT AMBIENTE FROM CI_AMBIENTE_SCHEDULE");

                lblAmbiente.Text = (dtConsulta.Rows[0][0].ToString() == "P") ? "Produção" : "Qualidade";

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
                gvInterfaces.Rows.Clear();

                DataTable dtbTabela = new DataTable();
                dtbTabela = RfNfEntradaBLL.Select(SQL());

                string interfaces;

                for (int i = 0; i < dtbTabela.Rows.Count; i++)
                {
                    switch (dtbTabela.Rows[i][2].ToString())
                    {
                        case "Produtos":
                            interfaces = "Produtos Novos";
                            break;
                        case "Descrição de Produtos":
                            interfaces = "Descrição de Produtos Novos";
                            break;
                        case "Locations":
                            interfaces = "Locations Novos";
                            break;
                        case "Saldo / Validação":
                            interfaces = "Saldo / Validação (Somente Schedulado)";
                            break;
                        default:
                            interfaces = dtbTabela.Rows[i][2].ToString();
                            break;
                    }

                    gvInterfaces.Rows.Add(dtbTabela.Rows[i][0].ToString(), dtbTabela.Rows[i][1].ToString(), interfaces, dtbTabela.Rows[i][3].ToString(), dtbTabela.Rows[i][4].ToString());
                }

                gvInterfaces.Rows[gvInterfaces.Rows.Count - 1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                gvInterfaces.Rows[gvInterfaces.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Gray;
                gvInterfaces.Rows[gvInterfaces.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
                gvInterfaces.Rows[gvInterfaces.Rows.Count - 1].DefaultCellStyle.SelectionForeColor = Color.Gray;
                gvInterfaces.Rows[gvInterfaces.Rows.Count - 1].Cells[1].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static string SQL()
        {
            string strSQL = @"SELECT 
                                    SCHE_ID, DECODE(SCHE_STATUS, 1, 'True', 'False') AS SCHE_STATUS, SCHE_INTERFACES, SCHE_HORARIO, SCHE_TABELAS
                                FROM 
                                    CI_SCHEDULE
                                WHERE
                                    SCHE_AGENDAR = 1
                                ORDER BY
                                    SCHE_ID";
            return strSQL;
        }

        private void btAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvInterfaces.Rows.Count > 0)
                {
                    SalvarSchedule();

                    carregaGrid();
                    MessageBox.Show("Todas as Interfaces Agendadas com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Não foi encontrado nem uma interface!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SalvarSchedule()
        {
            for (int i = 0; i < gvInterfaces.Rows.Count - 1; i++)
            {
                string strID = Convert.ToString(gvInterfaces.Rows[i].Cells[0].Value);
                string strStatus = (Convert.ToString(gvInterfaces.Rows[i].Cells[1].Value) == "True") ? "1" : "0";

                RfNfEntradaBLL.AtualizaSchedule(strID, strStatus);
            }

            string quebraLinha = Environment.NewLine;
            string strSQL = @"SELECT 
                                                SCHE_ID, DECODE(SCHE_STATUS, 1, 'True', 'False') AS SCHE_STATUS, SCHE_INTERFACES, SCHE_TABELAS, SCHE_CONSULTAS
                                            FROM 
                                                CI_SCHEDULE
                                            WHERE
                                                SCHE_STATUS = 1
                                            ORDER BY
                                                SCHE_ID";

            DataTable dtbTabela = new DataTable();
            dtbTabela = RfNfEntradaBLL.Select(strSQL);

            strSQL = @"create or replace procedure PRC_ATUALIZA_CAMADA_REPLAT_NFE is
                                                type t_char is table of varchar2(100) index by string (50);
                                                vt_tab   t_char;
                                                ind      varchar2(100);
                                                v_sql    varchar2(32676);
                                                colunas  varchar2(32676);
                                                colunas1  varchar2(32676);
                                        begin" + quebraLinha;

            for (int i = 0; i < dtbTabela.Rows.Count - 1; i++)
            {
                strSQL += @"                                vt_tab('" + dtbTabela.Rows[i][4].ToString() + "') := '" + dtbTabela.Rows[i][3].ToString() + "';" + quebraLinha;
            }

            strSQL += @"                                            for i in 1..2 loop
                                                ind := vt_tab.first;
    
                                                while ind is not null loop
                                                    select LISTAGG(column_name , ',') WITHIN GROUP (ORDER BY decode(t.column_name,'ID', 1, t.COLUMN_ID + 1)) into colunas from user_tab_columns t where t.table_name = vt_tab(ind);
                                                    colunas1 := replace(colunas, 'ID,','NULL ID,');

                                                    if i = 1 then
                                                        execute immediate 'truncate table ' || vt_tab(ind);
                                                    else
                                                        IF vt_tab(ind) = 'RF_PRODUTO' OR vt_tab(ind) = 'RF_DESCRICAO_PRODUTO' THEN
                                                            execute immediate 'truncate table ' || vt_tab(ind) || '_TEMP';

                                                            v_sql := 'insert into ' || vt_tab(ind) || '_TEMP (' || colunas || ')';
                                                            v_sql := v_sql || ' select ' || colunas1 || ' from ' || ind || '_geral';
                                                                execute immediate v_sql;
                                                        END IF;

                                                        v_sql := 'insert into ' || vt_tab(ind) || ' (' || colunas || ')';
                                                        v_sql := v_sql || ' select ' || colunas1 || ' from ' || ind;
                                                            execute immediate v_sql;
                                                    end if;
      
                                                    ind := vt_tab.next(ind);
                                                end loop;
                                            end loop;
  
                                            commit;
                                        EXCEPTION 
                                            WHEN OTHERS THEN
                                                dbms_output.put_line(v_sql);
                                                dbms_output.put_line(DBMS_UTILITY.format_error_backtrace);
                                            RAISE;
                                        end;";
            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                bool programado = false;

                for (int i = 0; i < gvInterfaces.Rows.Count - 1; i++)
                {
                    if (Convert.ToString(gvInterfaces.Rows[i].Cells[1].Value) == "True")
                    {
                        programado = true;
                        break;
                    }
                }

                if (!programado)
                {
                    MessageBox.Show("Não foi encontrado interface selecionada para processo!", "ATENÇÃO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } 
                else
                {
                    DialogResult myDialogResult = MessageBox.Show("Deseja Realmente Enviar as Interfaces Selecionadas?", "QUESTÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (myDialogResult == DialogResult.Yes)
                    {
                        frmAmbiente frm2 = new frmAmbiente();
                        frm2.ShowDialog();

                        if (RfNfEntradaBLL.strAmbiente != "")
                        {
                            this.Cursor = Cursors.WaitCursor;

                            MDIParent1 frm = this.MdiParent as MDIParent1;
                            frm.progressBar1.Maximum = 3;
                            frm.progressBar1.PerformStep();                                                                                                                     //
                            
                            SalvarSchedule();

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            string strSQL = @"BEGIN PRC_ATUALIZA_CAMADA_REPLAT_NFE(); END;";
                            RfNfEntradaBLL.ExecuteSQLInstruction(strSQL);

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            for (int i = 0; i < gvInterfaces.Rows.Count - 1; i++)
                            {
                                gvInterfaces.Rows[i].Cells[1].Value = "False";
                            }

                            SalvarSchedule();

                            frm.progressBar1.PerformStep();                                                                                                                     //

                            frm.progressBar1.Value = 0;

                            this.Cursor = Cursors.Default;

                            MessageBox.Show("Todos as Interfaces processadas com sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MDIParent1 frm1 = this.MdiParent as MDIParent1;
                frm1.progressBar1.Value = 0;

                this.Cursor = Cursors.Default;
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
