using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;
using DTO;
using System.Diagnostics;

using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Replat
{
    public partial class frmAmbienteAgendado : Form
    {
        public frmAmbienteAgendado()
        {
            InitializeComponent();
        }
        
        private void btFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public DataTable CarregaCB()
        {
            string SQL = @"SELECT
                                'Q' SCHE_ID, 'Qualidade' SCHE_TABELAS
                            FROM
                                DUAL
                            UNION ALL SELECT
                                'P' SCHE_ID, 'Produção' SCHE_TABELAS
                            FROM
                                DUAL";

            DataTable dtConsulta = new DataTable();
            dtConsulta = RfNfEntradaBLL.Select(SQL);

            return dtConsulta;
        }

        private void frmAmbienteAgendado_Load(object sender, EventArgs e)
        {
            try
            {
                cbInterface.DisplayMember = "SCHE_TABELAS";
                cbInterface.ValueMember = "SCHE_ID";
                cbInterface.DataSource = CarregaCB();

                DataTable dtConsulta = new DataTable();
                dtConsulta = RfNfEntradaBLL.Select("SELECT AMBIENTE FROM CI_AMBIENTE_SCHEDULE");

                cbInterface.SelectedValue = dtConsulta.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                RfNfEntradaBLL.ExecuteSQLInstruction("UPDATE CI_AMBIENTE_SCHEDULE SET AMBIENTE = '" + cbInterface.SelectedValue + "'");

                MessageBox.Show("Ambiente '" + cbInterface.Text + "' Agendado com Sucesso!", "SUCESSO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na Aplicação: " + ex.Message + "\n\nPor favor entre em contato com o Desenvolvedor!", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
