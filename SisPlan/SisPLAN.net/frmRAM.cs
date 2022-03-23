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
    public partial class frmRAM : Form
    {
        static string asp = Convert.ToChar(34).ToString();
        string contrato = "Conversão";
        string systemRepository = @"F:\CORPORATIVO\SISTEMAS\SisPLAN.Net\";

        DataTable dtDisciplina = null;
        static DTO.AcSemanaDTO semana = new DTO.AcSemanaDTO();
        DTO.LimitesPeriodoDTO limites = new DTO.LimitesPeriodoDTO();
        DTO.FcesTotaisDTO tot = new DTO.FcesTotaisDTO();
        DTO.FcesTotaisDTO totPeriodo = new DTO.FcesTotaisDTO();
        DTO.FcesTotaisDTO pesoCriterio = new DTO.FcesTotaisDTO();
        DTO.FcesTotaisDTO totAvancoPondPeriodo = new DTO.FcesTotaisDTO();
        DTO.FcesTotaisDTO avancoPondCriterio = new DTO.FcesTotaisDTO();
        DTO.FcesTotaisDTO totAvancoPondCriterio = new DTO.FcesTotaisDTO();
        decimal qtdRealCriterio = 0;
        static decimal pesoAtividade = 0;
        static decimal percAvancoAtividade = 0;
        string filter = "";

        string strSQL = "";
        string dtInicio, dtFim = "";
        DataTable dtDOC = null;
        DataTable dtCriterioCabecalho = null;
        static DataTable dtCriterioEstrutura = null;
        static DataTable dtCriterioEstruturaStage = null;
        static string disciplinas = "2,3,5,6,9,15,20";
        static DataTable dtFolhasDentroPeriodo = null;
        static DataTable dtFolhasForaPeriodo = null;
        static DataTable dtAvnDentroPeriodo = null;
        static DataTable dtAvnForaPeriodo = null;
        static decimal ramId = 0;
        static bool cabecalhoCriado = false;
        static int maxLevelCriterio = 0;
        static int maxColCriterio = 0;
        static int colPositionCriterio = 0;
        static int lec = 0;
        static decimal avancoRelativoPeriodo = 0;
        static decimal fsmeId = 0;
        static decimal avancoCalculado = 0;
        static string avancoCalculadoFormatado = "";
        static string fn = "n4";
        static string f2 = "n2";
        static string lf = Convert.ToChar(10).ToString();
        //===================================================================================
        public frmRAM()
        {
            InitializeComponent();
            this.reportViewer1.Visible = false;
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================
        private void frmRAM_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            panelDivision.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            reportViewer1.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 170;
            
            //Application.DoEvents();
            //cmbSemana
            strSQL = @"SELECT NULL AS VALUE, '' AS DISPLAY FROM DUAL UNION " +
                        @"SELECT SEMA_ID AS VALUE, SEMA_ID ||'  ( '|| SEMA_DATA_INICIO ||' - '|| SEMA_DATA_FIM ||' )' AS DISPLAY FROM 
                                (
                                    SELECT DISTINCT CP.SEMA_ID, SE.SEMA_DATA_INICIO, SE.SEMA_DATA_FIM 
                                      FROM EEP_CONVERSION.AC_CONTROLE_PRODUCAO CP, EEP_CONVERSION.AC_SEMANA SE
                                     WHERE CP.SEMA_ID = SE.SEMA_ID
                                     ORDER BY 1 DESC
                                ) 
                        WHERE ROWNUM <= 5
                        ORDER BY 1 DESC NULLS FIRST";
            dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
            cmbSemana.DataSource = dtDOC;
            cmbSemana.DisplayMember = "DISPLAY";
            cmbSemana.ValueMember = "VALUE";
            cmbSemana.SelectedItem = 0;
        }
        //===================================================================================
        private void btnExecute_Click(object sender, EventArgs e)
        {
            lblProgress.Visible = true;
            Application.DoEvents();
            DataTable dtRamId = BLL.AcRamAtividadeBLL.Select("SELECT MAX(RAM_ID) FROM EEP_CONVERSION.AC_RAM_ATIVIDADE");
            if ((dtRamId.Rows[0][0] != null) && (dtRamId.Rows[0][0] != DBNull.Value)) ramId = Convert.ToInt32(dtRamId.Rows[0][0]);
            //if (dtRamId.Rows[0][0] != null) ramId = Convert.ToInt32(dtRamId.Rows[0][0]);
            cabecalhoCriado = false;
            dtInicio = dtpInicio.Value.ToString("dd/MM/yyyy");
            dtFim = dtpFim.Value.ToString("dd/MM/yyyy");

            dtCriterioEstrutura = GetCriterioEstrutura(Convert.ToDecimal(cmbCriterio.SelectedValue));
            //Obtém Nivel máximo e numero colunas do critério
            GetMaxLevelMaxCol(dtCriterioEstrutura);

            //OBTEM FOLHAS EXECUTADOS NO PERIODO
            GetFolhasDentroPeriodo();
            //OBTEM FOLHAS EXECUTADOS FORA DO PERIODO
            GetFolhasForaPeriodo();

            //Criar atributos base
            DTO.AcRamAtividadeDTO ram = new DTO.AcRamAtividadeDTO();
            CriaAtributosBase(ram, 0);

            ////Obtem Quantidade Prevista da Atividade
            //qtdPrevistoAtividade = GetQtdPrevistoAtividade(ram.AtivId);

            //Monta Cabecalho
            MontaCabecalho(ram, dtCriterioEstrutura);

            // 0) Salva registro de separação
            SalvaNivelFolhaAvanco(ref ram, null, null, 25);

            //PREPARA REGISTRO DE FOLHAS FORA PERIODO
            PreparaRegistrosForaPeriodo(ram, ref tot);

            //Aqui começa a gravação dos registros
            //=========================================================================================================================================================
            //=========================================================================================================================================================


            // 1) Salva registro com total de folhas FORA do período (50)
            SalvaNivelFolhaAvanco(ref ram, null, null, 50);
        
            // 2) Prepara e grava cada folha DENTRO do período
            GenericClasses.AvancosFolhaServico avancosFolhaServico = new GenericClasses.AvancosFolhaServico();
            for (int i = 0; i < dtFolhasDentroPeriodo.Rows.Count; i++)
            {
                ram.FoseId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSE_ID"]);
                ram.FoseNumero = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FOSE_NUMERO"]);
                ram.FoseRev = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FOSE_REV"]);
                ram.FosmId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSM_ID"]);
                ram.FcesSigla = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FCES_SIGLA"]);
                ram.UnmeSigla = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["UNME_SIGLA"]);
                ram.FoseQtdPrevista = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSE_QTD_PREVISTA"]);

                //Obtém Quantidade Prevista da Atividade
                pesoAtividade = GetQtdPrevistoAtividade(ram.AtivId);

                //Calcula o percentual de peso da FOSE na Atividade
                if (pesoAtividade > 0) ram.QtdPrevistoAtividade = ((decimal)ram.FoseQtdPrevista / pesoAtividade * 100).ToString(fn);
                
                ram.FcesPesoRelCron = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FCES_PESO_REL_CRON"]);
                fsmeId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FSME_ID"]);
                colPositionCriterio = Convert.ToInt32(Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FCES_WBS"]).Split('.')[Convert.ToInt32(dtFolhasDentroPeriodo.Rows[i]["FCES_NIVEL"]) - 1]);
                avancosFolhaServico = GenericClasses.FolhaServico.GetAvancosFolhaServico(contrato, ram.FoseId, dtInicio, dtFim, ram.FcesSigla, ram.FoseQtdPrevista);

                //AvancoReal
                if (ram.FoseQtdPrevista > 0) avancoCalculado = (avancosFolhaServico.InFsmeAvancoAcm - avancosFolhaServico.OutFsmeAvancoAcm) * (decimal)ram.FoseQtdPrevista / 100;
                switch (colPositionCriterio)
                {
                    case 1: { tot.SumEl01 = tot.SumEl01 + avancoCalculado; totPeriodo.SumEl01 = totPeriodo.SumEl01 + avancoCalculado; break; }
                    case 2: { tot.SumEl02 = tot.SumEl02 + avancoCalculado; totPeriodo.SumEl02 = totPeriodo.SumEl02 + avancoCalculado; break; }
                    case 3: { tot.SumEl03 = tot.SumEl03 + avancoCalculado; totPeriodo.SumEl03 = totPeriodo.SumEl03 + avancoCalculado; break; }
                    case 4: { tot.SumEl04 = tot.SumEl04 + avancoCalculado; totPeriodo.SumEl04 = totPeriodo.SumEl04 + avancoCalculado; break; }
                    case 5: { tot.SumEl05 = tot.SumEl05 + avancoCalculado; totPeriodo.SumEl05 = totPeriodo.SumEl05 + avancoCalculado; break; }
                    case 6: { tot.SumEl06 = tot.SumEl06 + avancoCalculado; totPeriodo.SumEl06 = totPeriodo.SumEl06 + avancoCalculado; break; }
                    case 7: { tot.SumEl07 = tot.SumEl07 + avancoCalculado; totPeriodo.SumEl07 = totPeriodo.SumEl07 + avancoCalculado; break; }
                    case 8: { tot.SumEl08 = tot.SumEl08 + avancoCalculado; totPeriodo.SumEl08 = totPeriodo.SumEl08 + avancoCalculado; break; }
                    case 9: { tot.SumEl09 = tot.SumEl09 + avancoCalculado; totPeriodo.SumEl09 = totPeriodo.SumEl09 + avancoCalculado; break; }
                    case 10: { tot.SumEl10 = tot.SumEl10 + avancoCalculado; totPeriodo.SumEl10 = totPeriodo.SumEl10 + avancoCalculado; break; }
                }

                //Avanço Real Formatado
                avancoCalculadoFormatado = avancoCalculado.ToString(fn);
                //Salva registro de cada folha dentro do período
                //SalvaNivelFolhaAvanco(ref ram, avancoCalculado, avancosFolhaServico.InFsmeData, 21);
                SalvaNivelFolhaAvanco(ref ram, avancosFolhaServico.InFsmeData, avancoCalculadoFormatado, 22);
                
            }

            // 3) Salva Quantidade Total no período (30)
            SalvaTotalPeriodo(totPeriodo, ram);

            // 3.5) Salva Quantidade Total no período (40)
            SalvaTotalPonderadoPeriodo(totPeriodo, ram);

            // 4) Salva Quantidade Total antes e incluindo o período (60)
            SalvaTotalIncluindoPeriodo(tot, ram);

            // Obtém a quantidade executada ponderada NO Critério a partir dos DataTable dtCriterioEstrutura
            qtdRealCriterio = GetQtdRealCriterio(tot);

            //Calcula o percentual de Realização da Atividade
            if (pesoAtividade > 0) percAvancoAtividade = qtdRealCriterio / pesoAtividade * 100;

            //Salva Avanços Ponderados(80)
            SalvaAvancosPonderados(totAvancoPondCriterio, ram);

            //Insere linha em branco
            InicializaObjetoRAM(ram);
            SalvaNivelFolhaAvanco(ref ram, null, null, 90);

            //Salva Avanço da Atividade (100)
            SalvaAvancoAtividade(percAvancoAtividade, ram);
            
            //=========================================================================================================================================================
            //=========================================================================================================================================================
            filter = GetFilter();
            this.reportViewer1.Visible = false;
            //lblProcessando.Visible = true;
            //Application.DoEvents();
            ShowReport(filter);
            lblProgress.Visible = false;
            Application.DoEvents();
        }
        //===================================================================================
        private void SalvaAvancosPonderados(DTO.FcesTotaisDTO totAvancoPondCriterio, DTO.AcRamAtividadeDTO ram)
        {
            InicializaObjetoRAM(ram);
            string p = "<b><font color=" + asp + "Red" + asp + ">";
            string s = "</b>";
            ram.El01 = (totAvancoPondCriterio.SumEl01 != 0 ? p + totAvancoPondCriterio.SumEl01.ToString(fn) + s : null);
            ram.El02 = (totAvancoPondCriterio.SumEl02 != 0 ? p + totAvancoPondCriterio.SumEl02.ToString(fn) + s : null);
            ram.El03 = (totAvancoPondCriterio.SumEl03 != 0 ? p + totAvancoPondCriterio.SumEl03.ToString(fn) + s : null);
            ram.El04 = (totAvancoPondCriterio.SumEl04 != 0 ? p + totAvancoPondCriterio.SumEl04.ToString(fn) + s : null);
            ram.El05 = (totAvancoPondCriterio.SumEl05 != 0 ? p + totAvancoPondCriterio.SumEl05.ToString(fn) + s : null);
            ram.El06 = (totAvancoPondCriterio.SumEl06 != 0 ? p + totAvancoPondCriterio.SumEl06.ToString(fn) + s : null);
            ram.El07 = (totAvancoPondCriterio.SumEl07 != 0 ? p + totAvancoPondCriterio.SumEl07.ToString(fn) + s : null);
            ram.El08 = (totAvancoPondCriterio.SumEl08 != 0 ? p + totAvancoPondCriterio.SumEl08.ToString(fn) + s : null);
            ram.El09 = (totAvancoPondCriterio.SumEl09 != 0 ? p + totAvancoPondCriterio.SumEl09.ToString(fn) + s : null);
            ram.El10 = (totAvancoPondCriterio.SumEl10 != 0 ? p + totAvancoPondCriterio.SumEl10.ToString(fn) + s : null);

            SalvaNivelFolhaAvanco(ref ram, null, null, 80);
        }
        //===================================================================================
        private void SalvaAvancoAtividade(decimal percAvancoAtividade, DTO.AcRamAtividadeDTO ram)
        {
            InicializaObjetoRAM(ram);
            ram.El01 = "<b>" + (percAvancoAtividade != 0 ? percAvancoAtividade.ToString(f2) + "%" + "</b>" : null);
            
            SalvaNivelFolhaAvanco(ref ram, null, null, 100);
        }
        //===================================================================================
        private decimal GetQtdPrevistoAtividade(decimal ativId)
        {
            DTO.VwAcQuantidadeAtividadeDTO quantidadeAtividade = new DTO.VwAcQuantidadeAtividadeDTO();
            // WHERE ATIV_ID = " + ativId.ToString() + @" AND ATRE_QTD > 0 AND ROWNUM = 1 GROUP BY ATRE_QTD
            quantidadeAtividade = BLL.VwAcQuantidadeAtividadeBLL.GetObject("ATIV_ID = " + ativId.ToString() + @" AND ATRE_QTD > 0 AND ROWNUM = 1 GROUP BY X.POCR_CNTR_CODIGO, X.ATIV_SIG, X.ATIV_NOME, X.ATRE_QTD, X.ATRE_ID, X.ATIV_ID");
            
            return quantidadeAtividade.AtreQtd;
        }
        //===================================================================================
        private decimal GetQtdRealCriterio(DTO.FcesTotaisDTO tot)
        {
            decimal qtdRealCriterio = 0;
            strSQL = @"SELECT FCME_ID, FCME_SIGLA, FCES_SIGLA, FCES_DESCRICAO, FCES_NIVEL, FCES_WBS, FCES_PESO_REL_CRON
                       FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA
                      WHERE FCME_CNTR_CODIGO = 'Conversão'
                        AND FCES_CNTR_CODIGO = FCME_CNTR_CODIGO AND FCES_FCME_ID = FCME_ID
                        AND FCME_ID = " + cmbCriterio.SelectedValue.ToString() + @" AND FCES_NIVEL = " + maxLevelCriterio.ToString() +  @" 
                   ORDER BY FCME_ID, FCES_WBS";
            DataTable dt = BLL.AcRamAtividadeBLL.Select(strSQL);
            DTO.FcesTotaisDTO pesoCriterio = new DTO.FcesTotaisDTO();
            for (int i = 0; i < dt.Rows.Count; i ++ )
            {
                if (i == 0) { pesoCriterio.SumEl01 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl01 = tot.SumEl01 * pesoCriterio.SumEl01 / 100; }
                if (i == 1) { pesoCriterio.SumEl02 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl02 = tot.SumEl02 * pesoCriterio.SumEl02 / 100; }
                if (i == 2) { pesoCriterio.SumEl03 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl03 = tot.SumEl03 * pesoCriterio.SumEl03 / 100; }
                if (i == 3) { pesoCriterio.SumEl04 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl04 = tot.SumEl04 * pesoCriterio.SumEl04 / 100; }
                if (i == 4) { pesoCriterio.SumEl05 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl05 = tot.SumEl05 * pesoCriterio.SumEl05 / 100; }
                if (i == 5) { pesoCriterio.SumEl06 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl06 = tot.SumEl06 * pesoCriterio.SumEl06 / 100; }
                if (i == 6) { pesoCriterio.SumEl07 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl07 = tot.SumEl07 * pesoCriterio.SumEl07 / 100; }
                if (i == 7) { pesoCriterio.SumEl08 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl08 = tot.SumEl08 * pesoCriterio.SumEl08 / 100; }
                if (i == 8) { pesoCriterio.SumEl09 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl09 = tot.SumEl09 * pesoCriterio.SumEl09 / 100; }
                if (i == 9) { pesoCriterio.SumEl10 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); avancoPondCriterio.SumEl10 = tot.SumEl10 * pesoCriterio.SumEl10 / 100; }
            }
            totAvancoPondCriterio.SumEl01 = avancoPondCriterio.SumEl01;
            totAvancoPondCriterio.SumEl02 = avancoPondCriterio.SumEl02;
            totAvancoPondCriterio.SumEl03 = avancoPondCriterio.SumEl03;
            totAvancoPondCriterio.SumEl04 = avancoPondCriterio.SumEl04;
            totAvancoPondCriterio.SumEl05 = avancoPondCriterio.SumEl05;
            totAvancoPondCriterio.SumEl06 = avancoPondCriterio.SumEl06;
            totAvancoPondCriterio.SumEl07 = avancoPondCriterio.SumEl07;
            totAvancoPondCriterio.SumEl08 = avancoPondCriterio.SumEl08;
            totAvancoPondCriterio.SumEl09 = avancoPondCriterio.SumEl09;
            totAvancoPondCriterio.SumEl10 = avancoPondCriterio.SumEl10;
            qtdRealCriterio = (
                                avancoPondCriterio.SumEl01 + avancoPondCriterio.SumEl02 + avancoPondCriterio.SumEl03 + avancoPondCriterio.SumEl04 + avancoPondCriterio.SumEl05 +
                                avancoPondCriterio.SumEl06 + avancoPondCriterio.SumEl07 + avancoPondCriterio.SumEl08 + avancoPondCriterio.SumEl09 + avancoPondCriterio.SumEl10
                              );
            return qtdRealCriterio;
        }
        //===================================================================================
        private void SalvaTotalPeriodo(DTO.FcesTotaisDTO tot, DTO.AcRamAtividadeDTO ram)
        {
            ram.El01 = (tot.SumEl01 != 0 ? tot.SumEl01.ToString(fn) : null);
            ram.El02 = (tot.SumEl02 != 0 ? tot.SumEl02.ToString(fn) : null);
            ram.El03 = (tot.SumEl03 != 0 ? tot.SumEl03.ToString(fn) : null);
            ram.El04 = (tot.SumEl04 != 0 ? tot.SumEl04.ToString(fn) : null);
            ram.El05 = (tot.SumEl05 != 0 ? tot.SumEl05.ToString(fn) : null);
            ram.El06 = (tot.SumEl06 != 0 ? tot.SumEl06.ToString(fn) : null);
            ram.El07 = (tot.SumEl07 != 0 ? tot.SumEl07.ToString(fn) : null);
            ram.El08 = (tot.SumEl08 != 0 ? tot.SumEl08.ToString(fn) : null);
            ram.El09 = (tot.SumEl09 != 0 ? tot.SumEl09.ToString(fn) : null);
            ram.El10 = (tot.SumEl10 != 0 ? tot.SumEl10.ToString(fn) : null);

            SalvaNivelFolhaAvanco(ref ram, null, null, 30);
        }
        //===================================================================================
        private void SalvaTotalPonderadoPeriodo(DTO.FcesTotaisDTO totPeriodo, DTO.AcRamAtividadeDTO ram)
        {
            InicializaObjetoRAM(ram);
            string p = "<b><font color=" + asp + "Red" + asp + ">";
            string s = "</b>";

            strSQL = @"SELECT FCME_ID, FCME_SIGLA, FCES_SIGLA, FCES_DESCRICAO, FCES_NIVEL, FCES_WBS, FCES_PESO_REL_CRON
                       FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA
                      WHERE FCME_CNTR_CODIGO = 'Conversão'
                        AND FCES_CNTR_CODIGO = FCME_CNTR_CODIGO AND FCES_FCME_ID = FCME_ID
                        AND FCME_ID = " + cmbCriterio.SelectedValue.ToString() + @" AND FCES_NIVEL = " + maxLevelCriterio.ToString() + @" 
                   ORDER BY FCME_ID, FCES_WBS";
            DataTable dt = BLL.AcRamAtividadeBLL.Select(strSQL);
            DTO.FcesTotaisDTO pesoCriterio = new DTO.FcesTotaisDTO();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0) { pesoCriterio.SumEl01 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl01 = totPeriodo.SumEl01 * pesoCriterio.SumEl01 / 100; }
                if (i == 1) { pesoCriterio.SumEl02 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl02 = totPeriodo.SumEl02 * pesoCriterio.SumEl02 / 100; }
                if (i == 2) { pesoCriterio.SumEl03 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl03 = totPeriodo.SumEl03 * pesoCriterio.SumEl03 / 100; }
                if (i == 3) { pesoCriterio.SumEl04 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl04 = totPeriodo.SumEl04 * pesoCriterio.SumEl04 / 100; }
                if (i == 4) { pesoCriterio.SumEl05 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl05 = totPeriodo.SumEl05 * pesoCriterio.SumEl05 / 100; }
                if (i == 5) { pesoCriterio.SumEl06 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl06 = totPeriodo.SumEl06 * pesoCriterio.SumEl06 / 100; }
                if (i == 6) { pesoCriterio.SumEl07 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl07 = totPeriodo.SumEl07 * pesoCriterio.SumEl07 / 100; }
                if (i == 7) { pesoCriterio.SumEl08 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl08 = totPeriodo.SumEl08 * pesoCriterio.SumEl08 / 100; }
                if (i == 8) { pesoCriterio.SumEl09 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl09 = totPeriodo.SumEl09 * pesoCriterio.SumEl09 / 100; }
                if (i == 9) { pesoCriterio.SumEl10 = Convert.ToDecimal(dt.Rows[i]["FCES_PESO_REL_CRON"]); totAvancoPondPeriodo.SumEl10 = totPeriodo.SumEl10 * pesoCriterio.SumEl10 / 100; }
            }

            ram.El01 = (totAvancoPondPeriodo.SumEl01 != 0 ? p + totAvancoPondPeriodo.SumEl01.ToString(fn) + s : null);
            ram.El02 = (totAvancoPondPeriodo.SumEl02 != 0 ? p + totAvancoPondPeriodo.SumEl02.ToString(fn) + s : null);
            ram.El03 = (totAvancoPondPeriodo.SumEl03 != 0 ? p + totAvancoPondPeriodo.SumEl03.ToString(fn) + s : null);
            ram.El04 = (totAvancoPondPeriodo.SumEl04 != 0 ? p + totAvancoPondPeriodo.SumEl04.ToString(fn) + s : null);
            ram.El05 = (totAvancoPondPeriodo.SumEl05 != 0 ? p + totAvancoPondPeriodo.SumEl05.ToString(fn) + s : null);
            ram.El06 = (totAvancoPondPeriodo.SumEl06 != 0 ? p + totAvancoPondPeriodo.SumEl06.ToString(fn) + s : null);
            ram.El07 = (totAvancoPondPeriodo.SumEl07 != 0 ? p + totAvancoPondPeriodo.SumEl07.ToString(fn) + s : null);
            ram.El08 = (totAvancoPondPeriodo.SumEl08 != 0 ? p + totAvancoPondPeriodo.SumEl08.ToString(fn) + s : null);
            ram.El09 = (totAvancoPondPeriodo.SumEl09 != 0 ? p + totAvancoPondPeriodo.SumEl09.ToString(fn) + s : null);
            ram.El10 = (totAvancoPondPeriodo.SumEl10 != 0 ? p + totAvancoPondPeriodo.SumEl10.ToString(fn) + s : null);

            SalvaNivelFolhaAvanco(ref ram, null, null, 40);
        }
        //===================================================================================
        private void SalvaTotalIncluindoPeriodo(DTO.FcesTotaisDTO tot, DTO.AcRamAtividadeDTO ram)
        {
            
            ram.El01 = (tot.SumEl01 != 0 ? tot.SumEl01.ToString(fn) : null);
            ram.El02 = (tot.SumEl02 != 0 ? tot.SumEl02.ToString(fn) : null);
            ram.El03 = (tot.SumEl03 != 0 ? tot.SumEl03.ToString(fn) : null);
            ram.El04 = (tot.SumEl04 != 0 ? tot.SumEl04.ToString(fn) : null);
            ram.El05 = (tot.SumEl05 != 0 ? tot.SumEl05.ToString(fn) : null);
            ram.El06 = (tot.SumEl06 != 0 ? tot.SumEl06.ToString(fn) : null);
            ram.El07 = (tot.SumEl07 != 0 ? tot.SumEl07.ToString(fn) : null);
            ram.El08 = (tot.SumEl08 != 0 ? tot.SumEl08.ToString(fn) : null);
            ram.El09 = (tot.SumEl09 != 0 ? tot.SumEl09.ToString(fn) : null);
            ram.El10 = (tot.SumEl10 != 0 ? tot.SumEl10.ToString(fn) : null);

            SalvaNivelFolhaAvanco(ref ram, null, null, 60);
        }
        //===================================================================================
        private static void PreparaRegistrosForaPeriodo(DTO.AcRamAtividadeDTO ram, ref DTO.FcesTotaisDTO tot)
        {
            decimal v = 0;
            if (dtFolhasForaPeriodo.Rows.Count != 0)
            {
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL01_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El01 = v.ToString(fn); tot.SumEl01 = v; } else { ram.El01 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL02_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El02 = v.ToString(fn); tot.SumEl02 = v; } else { ram.El02 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL03_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El03 = v.ToString(fn); tot.SumEl03 = v; } else { ram.El03 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL04_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El04 = v.ToString(fn); tot.SumEl04 = v; } else { ram.El04 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL05_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El05 = v.ToString(fn); tot.SumEl05 = v; } else { ram.El05 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL06_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El06 = v.ToString(fn); tot.SumEl06 = v; } else { ram.El06 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL07_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El07 = v.ToString(fn); tot.SumEl07 = v; } else { ram.El07 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL08_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El08 = v.ToString(fn); tot.SumEl08 = v; } else { ram.El08 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL09_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El09 = v.ToString(fn); tot.SumEl09 = v; } else { ram.El09 = null; }
                v = Convert.ToDecimal(dtFolhasForaPeriodo.Rows[0]["EL10_FCES_AVN_REAL"]); if ((v).ToString() != "0") { ram.El10 = v.ToString(fn); tot.SumEl10 = v; } else { ram.El10 = null; }
            }
        }
        //===================================================================================
        private void CriaAtributosBase(DTO.AcRamAtividadeDTO ram, int i)
        {
            ram.Active = 1;
            ram.SbcnSigla = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["SBCN_SIGLA"]);
            ram.AtivSig = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["ATIV_SIG"]);
            ram.AtivNome = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["ATIV_NOME"]);
            ram.DiscNome = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["DISC_NOME"]);
            ram.UnmeId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["UNME_ID"]);
            ram.UnmeSigla = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["UNME_SIGLA"]);
            ram.FoseId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSE_ID"]);
            ram.FoseNumero = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FOSE_NUMERO"]);
            ram.FoseRev = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FOSE_REV"]);
            ram.FoseQtdPrevista = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSE_QTD_PREVISTA"]);
            //ram.Desenho = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["DESENHO"]);

            ram.FcmeId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FCME_ID"]);
            //dtCriterioEstrutura = GetCriterioEstrutura(ram.FcmeId);
            ram.FcmeSigla = Convert.ToString(dtCriterioEstrutura.Rows[i]["TITULO_CRITERIO"]);

            ram.FcesSigla = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FCES_SIGLA"]);
            ram.FcesWbs = Convert.ToString(dtFolhasDentroPeriodo.Rows[i]["FCES_WBS"]);
            ram.FcesPesoRelCron = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FCES_PESO_REL_CRON"]);

            ram.FosmCntrCodigo = contrato;
            ram.SbcnId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSE_SBCN_ID"]);
            ram.DiscId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["DISC_ID"]);
            ram.AtivId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["ATIV_ID"]);

            ram.FosmId = Convert.ToDecimal(dtFolhasDentroPeriodo.Rows[i]["FOSM_ID"]);
            ram.DtStart = Convert.ToDateTime(dtInicio);
            ram.DtEnd = Convert.ToDateTime(dtFim);
            ram.SemaId = null;
            if (cmbSemana.SelectedIndex > 0) ram.SemaId = Convert.ToDecimal(cmbSemana.SelectedValue);
            //Obtém Nivel máximo e numero colunas do critério
            //GetMaxLevelMaxCol(dtCriterioEstrutura);
        }
        //===================================================================================
        private void MontaCabecalho(DTO.AcRamAtividadeDTO ram, DataTable dtCriterioEstrutura)
        {
            //Inicializa tabela de Saída - AC_RAM_ATIVIDADE para a atividade solicitada
            strSQL = @"DELETE FROM EEP_CONVERSION.AC_RAM_ATIVIDADE WHERE FOSM_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = " + ram.SbcnId.ToString() + @" AND DISC_ID = " + ram.DiscId.ToString() + @" AND ATIV_ID = " + ram.AtivId.ToString() + @" AND FCME_ID = " + ram.FcmeId.ToString();
            BLL.AcRamAtividadeBLL.ExecuteSQLInstruction(strSQL);

            //Análise dos Níveis do Criterio
            for (int i = 0; i < dtCriterioEstrutura.Rows.Count; i++)
            {
                int fcesNivel = Convert.ToInt32(dtCriterioEstrutura.Rows[i]["FCES_NIVEL"]);
                string fcesWBS = Convert.ToString(dtCriterioEstrutura.Rows[i]["FCES_WBS"]);
                string tituloEstrutura = Convert.ToString(dtCriterioEstrutura.Rows[i]["TITULO_ESTRUTURA"]);
                ram.FcesSigla = Convert.ToString(dtCriterioEstrutura.Rows[i]["FCES_SIGLA"]);
                ram.FcesWbs = fcesWBS;
                ram.FcesPesoRelCron = Convert.ToDecimal(dtCriterioEstrutura.Rows[i]["FCES_PESO_REL_CRON"]);
                switch (maxLevelCriterio)
                {
                    case 1:  // MAX LEVEL
                        {
                            colPositionCriterio = 1;
                            ram.El01 = tituloEstrutura; 
                            ram.TipoLinha = 1;
                            ramId += 1;
                            ram.RamId = ramId;
                            ram.FoseId = null;
                            ram.FoseNumero = null;
                            ram.FoseRev = null;
                            BLL.AcRamAtividadeBLL.Insert(ram, false);
                            break;
                        }
                    case 2:  // MAX LEVEL
                        {
                            switch (fcesNivel)
                            {
                                case 1:  //FCES_NIVEL
                                    {
                                        SalvaNivelTopo(ram, tituloEstrutura);
                                        break;
                                    }
                                case 2:  //FCES_NIVEL
                                    {
                                        colPositionCriterio = Convert.ToInt32(fcesWBS.Split('.')[1]);
                                        SalvaNivelFolhaCabecalho(ram, tituloEstrutura, maxLevelCriterio);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:   //MAX LEVEL
                        {
                            switch (fcesNivel)
                            {
                                case 1:  //FCES_NIVEL
                                    {
                                        colPositionCriterio = maxColCriterio / 2;
                                        if ((maxColCriterio % 2) > 0) colPositionCriterio += 1;

                                        switch (colPositionCriterio)
                                        {
                                            case 1: { ram.El01 = tituloEstrutura; break; }
                                            case 2: { ram.El02 = tituloEstrutura; break; }
                                            case 3: { ram.El03 = tituloEstrutura; break; }
                                            case 4: { ram.El04 = tituloEstrutura; break; }
                                            case 5: { ram.El05 = tituloEstrutura; break; }
                                        }
                                        ram.TipoLinha = 1;
                                        ramId += 1;
                                        ram.RamId = ramId;
                                        ram.FoseId = null;
                                        ram.FoseNumero = null;
                                        ram.FoseRev = null;
                                        BLL.AcRamAtividadeBLL.Insert(ram, false);
                                        break;
                                    }
                                case 2:  //FCES_NIVEL
                                    {
                                        switch (fcesWBS)
                                        {
                                            case "1.1.":
                                                {
                                                    colPositionCriterio = 1;
                                                    break;
                                                }
                                            case "1.2.":
                                                {
                                                    colPositionCriterio = 4;
                                                    break;
                                                }
                                        }
                                        ram.TipoLinha = 2;

                                        ramId += 1;
                                        ram.RamId = ramId;
                                        LimpaAtributosLinhaCabecalho(ram);
                                        BLL.AcRamAtividadeBLL.Insert(ram, false);
                                        break;
                                    }
                                case 3:  //FCES_NIVEL
                                    {
                                        colPositionCriterio = Convert.ToInt32(fcesWBS.Split('.')[2]);
                                        SalvaNivelFolhaCabecalho(ram, tituloEstrutura, maxLevelCriterio);
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }
        //===================================================================================
        private static void LimpaAtributosLinhaCabecalho(DTO.AcRamAtividadeDTO ram)
        {
            ram.FoseId = null;
            ram.FoseNumero = null;
            ram.FoseRev = null;
            ram.FcesSigla = null;
            ram.FcesWbs = null;
            ram.FosmId = null;
        }
        //===================================================================================
        private static void SalvaNivelTopo(DTO.AcRamAtividadeDTO ram, string tituloEstrutura)
        {
            colPositionCriterio = maxColCriterio / 2;
            if ((maxColCriterio % 2) > 0) colPositionCriterio += 1;

            switch (colPositionCriterio)
            {
                case 1: { ram.El01 = tituloEstrutura; break; }
                case 2: { ram.El02 = tituloEstrutura; break; }
                case 3: { ram.El03 = tituloEstrutura; break; }
                case 4: { ram.El04 = tituloEstrutura; break; }
                case 5: { ram.El05 = tituloEstrutura; break; }
            }
            ram.TipoLinha = 1;
            ramId += 1;
            ram.RamId = ramId;
            ram.FoseId = null;
            ram.FoseNumero = null;
            ram.FoseRev = null;
            BLL.AcRamAtividadeBLL.Insert(ram, false);
        }
        //===================================================================================
        private DTO.AcRamAtividadeDTO SalvaNivelFolhaAvanco(ref DTO.AcRamAtividadeDTO ram, DateTime? fsmeData, string elemento, decimal tipo_linha)
        {
            int c = 0;
            if (fsmeData != null) elemento = ((DateTime)fsmeData).ToString("dd/MM/yy") + lf + elemento;

            ram.FcesSigla = "";
            ram.FcesWbs = "";
            ram.FcesPesoRelCron = 0;

            // Folhas dentro do período
            if (tipo_linha == 22)
            {
                InicializaObjetoRAM(ram);
                string filterTipo = @"FOSM_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = " + ram.SbcnId.ToString() + @" AND DISC_ID = " + ram.DiscId.ToString() + @" AND ATIV_ID = " + ram.AtivId.ToString() + @" AND FCME_ID = " + ram.FcmeId.ToString();
                if (tipo_linha >= 20) filterTipo += @" AND FOSE_ID = " + ram.FoseId.ToString();
                filterTipo += @" AND TIPO_LINHA = " + Convert.ToString(tipo_linha);
                c = BLL.AcRamAtividadeBLL.Count(filterTipo);
                if (c != 0) ram = BLL.AcRamAtividadeBLL.GetObject(filterTipo);

                //if (tipo_linha == 12)
                //{
                //    LimpaAtributosLinhaCabecalho(ram);
                //    ram.FoseNumero = "AVANÇOS ANTERIORES AO PERÍODO";
                //}

                switch (colPositionCriterio)
                {
                    case 1: { ram.El01 = elemento; break; }
                    case 2: { ram.El02 = elemento; break; }
                    case 3: { ram.El03 = elemento; break; }
                    case 4: { ram.El04 = elemento; break; }
                    case 5: { ram.El05 = elemento; break; }
                    case 6: { ram.El06 = elemento; break; }
                    case 7: { ram.El07 = elemento; break; }
                    case 8: { ram.El08 = elemento; break; }
                    case 9: { ram.El09 = elemento; break; }
                    case 10: { ram.El10 = elemento; break; }
                }
            }
            else
            {
                ram.FoseNumero = null;
                ram.FoseRev = null;
                ram.FoseQtdPrevista = null;
                ram.UnmeSigla = null;
                ram.FosmId = null;
                ram.FoseId = null;
                ram.QtdPrevistoAtividade = null;
            }

            if (c == 0)
            {
                ram.TipoLinha = tipo_linha;
                if (tipo_linha == 30) ram.FoseNumero = "Quantidade acumulada no período";
                if (tipo_linha == 40) ram.FoseNumero = "<b><font color=" + asp + "Red" + asp + ">Quantidade ponderada no período</b>";
                if (tipo_linha == 50) ram.FoseNumero = "Quantidade acumulada anterior";
                if (tipo_linha == 60) ram.FoseNumero = "Quantidade acumulada total";
                if (tipo_linha == 80) ram.FoseNumero = "<b><font color=" + asp + "Red" + asp + ">Avanço % ponderado total</b>";
                if (tipo_linha == 100) ram.FoseNumero = "<b><font color=" + asp + "Red" + asp + ">AVANÇO % DA ATIVIDADE</b>";
                ramId += 1;
                ram.RamId = ramId;
                BLL.AcRamAtividadeBLL.Insert(ram, false);
            }
            else
            {
                BLL.AcRamAtividadeBLL.Update(ram);
            }
            return ram;
        }
        //===================================================================================
        private static void InicializaObjetoRAM(DTO.AcRamAtividadeDTO ram)
        {
            ram.El01 = "";
            ram.El02 = "";
            ram.El03 = "";
            ram.El04 = "";
            ram.El05 = "";
            ram.El06 = "";
            ram.El07 = "";
            ram.El08 = "";
            ram.El09 = "";
            ram.El10 = "";
        }
        //===================================================================================
        private DTO.AcRamAtividadeDTO SalvaNivelFolhaCabecalho(DTO.AcRamAtividadeDTO ram, string tituloEstrutura, int maxLevelCriterio)
        {
            InicializaObjetoRAM(ram);
            string filterTipo = @"FOSM_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = " + ram.SbcnId.ToString() + @" AND DISC_ID = " + ram.DiscId.ToString() + @" AND ATIV_ID = " + ram.AtivId.ToString() + @" AND FCME_ID = " + ram.FcmeId.ToString() + " AND TIPO_LINHA = 2";
            int c = BLL.AcRamAtividadeBLL.Count(filterTipo);
            if (c != 0) ram = BLL.AcRamAtividadeBLL.GetObject(filterTipo);
            switch (colPositionCriterio)
            {
                case 1: { ram.El01 = tituloEstrutura; break; }
                case 2: { ram.El02 = tituloEstrutura; break; }
                case 3: { ram.El03 = tituloEstrutura; break; }
                case 4: { ram.El04 = tituloEstrutura; break; }
                case 5: { ram.El05 = tituloEstrutura; break; }
                case 6: { ram.El06 = tituloEstrutura; break; }
                case 7: { ram.El07 = tituloEstrutura; break; }
                case 8: { ram.El08 = tituloEstrutura; break; }
                case 9: { ram.El09 = tituloEstrutura; break; }
                case 10: { ram.El10 = tituloEstrutura; break; }

            }
            if (c == 0)
            {
                ram.TipoLinha = 2;
                if (maxLevelCriterio == 3) ram.TipoLinha = 3;
                ramId += 1;
                ram.RamId = ramId;
                LimpaAtributosLinhaCabecalho(ram);
                BLL.AcRamAtividadeBLL.Insert(ram, false);
            }
            else
            {
                BLL.AcRamAtividadeBLL.Update(ram);
            }
            return ram;
        }
        //===================================================================================
        private int GetMaxColLevel(int maxLevel, DTO.AcRamAtividadeDTO ram, int fcesNivel)
        {
            int maxColLevel = 0;
            strSQL = @"SELECT COUNT(*) FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA, EEP_CONVERSION.DISCIPLINA
                      WHERE FCME_CNTR_CODIGO = '" + contrato + @"' 
                        AND FCES_CNTR_CODIGO = FCME_CNTR_CODIGO AND FCES_FCME_ID = FCME_ID
                        AND FCME_CNTR_CODIGO = DISC_CNTR_CODIGO AND FCME_DISC_ID = DISC_ID
                        AND FOSE_FCME_ID = " + ram.FcmeId + @" 
                        AND FCES_NIVEL = " + fcesNivel.ToString();
            DataTable dt = BLL.AcRamAtividadeBLL.Select(strSQL);
            maxColLevel = Convert.ToInt32(dt.Rows[0][0]);
            return maxColLevel;
        }
        //===================================================================================
        private void GetMaxLevelMaxCol(DataTable dtCriterioEstrutura)
        {
            DataRow[] rows = dtCriterioEstrutura.Select("1 = 1", "FCES_NIVEL DESC");
            maxLevelCriterio = Convert.ToInt32(rows[0]["FCES_NIVEL"]);
            DataRow[] arrMaxCol = dtCriterioEstrutura.Select("FCES_NIVEL = " + maxLevelCriterio.ToString());
            maxColCriterio = arrMaxCol.Length;
        }
        //===================================================================================
        private DataTable GetCriterioEstrutura(decimal fcmeId)
        {
          strSQL = @"SELECT FCME_DISC_ID, DISC_NOME, FCME_ID, FCME_SIGLA, FCME_NOME, FCME_SIGLA ||' - '||FCME_NOME AS TITULO_CRITERIO, FCES_SIGLA, FCES_DESCRICAO, FCES_NIVEL, FCES_WBS, FCES_PESO_REL_CRON
                    ,  FCES_SIGLA || CHR(10) ||'('|| FCES_PESO_REL_CRON ||'%)' AS TITULO_ESTRUTURA
                       FROM EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO, EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA, EEP_CONVERSION.DISCIPLINA
                      WHERE FCME_CNTR_CODIGO = 'Conversão'
                        AND FCES_CNTR_CODIGO = FCME_CNTR_CODIGO AND FCES_FCME_ID = FCME_ID
                        AND FCME_CNTR_CODIGO = DISC_CNTR_CODIGO AND FCME_DISC_ID = DISC_ID
                        AND FCME_ID = " + fcmeId.ToString() + @" 
                   ORDER BY DISC_ID, FCME_ID, FCES_WBS";
          DataTable dt = BLL.AcRamAtividadeBLL.Select(strSQL);
          return dt;
        }
        //===================================================================================
        private void GetFolhasDentroPeriodo()
        {
            strSQL = @"SELECT DISTINCT 
                              FOSM_CNTR_CODIGO,  FOSM_ID,  ATIV_ID,  ATIV_SIG, ATIV_NOME,  UNME_ID,  UNME_SIGLA,  FOSE_ID,  FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_REV,  FOSE_SBCN_ID,  
                              DISC_ID,  DISC_NOME,  FCME_ID,  FCME_SIGLA,  FCME_NOME,  FCES_SIGLA,  FCES_DESCRICAO, FCES_NIVEL,  FCES_WBS,  FCES_PESO_REL_CRON,  SBCN_SIGLA, FSME_ID,
                              ROUND(MAX(FSME_AVANCO_ACM),10) AS FSME_AVANCO_ACM, MAX(FSME_DATA) AS FSME_DATA,  ROUND(MAX(FSME_QTD_ACM),10) AS FSME_QTD_ACM
                         FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE, EEP_CONVERSION.SUB_CONTRATO
                        
                        WHERE FSME_DATA BETWEEN TO_DATE('" + dtInicio + @"','DD/MM/YYYY') AND TO_DATE('" + dtFim + @"','DD/MM/YYYY') 
                          AND FCES_NIVEL =  " + maxLevelCriterio + @" 
                          AND FOSM_CNTR_CODIGO = '" + contrato + @"'
                          AND FOSE_SBCN_ID = " + cmbFPSO.SelectedValue + @" 
                          AND DISC_ID = " + cmbDisciplina.SelectedValue + @"  
                          AND ATIV_ID = " + cmbAtividade.SelectedValue + @" 
                          AND FCME_ID = " + cmbCriterio.SelectedValue + @" 
                          AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO)
                          AND SBCN_CNTR_CODIGO = FOSM_CNTR_CODIGO AND SBCN_ID = FOSE_SBCN_ID 
                     GROUP BY FOSM_CNTR_CODIGO,  FOSM_ID,  ATIV_ID,  ATIV_SIG, ATIV_NOME,  UNME_ID,  UNME_SIGLA,  FOSE_ID,  FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_REV,  FOSE_SBCN_ID,  
                              DISC_ID,  DISC_NOME,  FCME_ID,  FCME_SIGLA,  FCME_NOME,  FCES_SIGLA,  FCES_DESCRICAO, FCES_NIVEL,  FCES_WBS,  FCES_PESO_REL_CRON,  SBCN_SIGLA, FSME_ID
                     ORDER BY FOSE_NUMERO, FCES_WBS";

            dtFolhasDentroPeriodo = BLL.AcRamAtividadeBLL.Select(strSQL);
        }
        //===================================================================================
        private void GetFolhasForaPeriodo()
        {
            #region Obtém avanços fora do período
            strSQL = @"SELECT DISTINCT 
                              FOSM_CNTR_CODIGO,  FOSM_ID,  ATIV_ID,  ATIV_SIG, ATIV_NOME,  UNME_ID,  UNME_SIGLA,  FOSE_ID,  FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_REV,  FOSE_SBCN_ID,  
                              DISC_ID,  DISC_NOME,  FCME_ID,  FCME_SIGLA,  FCME_NOME,  FCES_SIGLA,  FCES_DESCRICAO, FCES_NIVEL,  FCES_WBS,  FCES_PESO_REL_CRON,  
                              ROUND(MAX(FSME_AVANCO_ACM),10) AS FSME_AVANCO_ACM, MAX(FSME_DATA) AS FSME_DATA,  ROUND(MAX(FSME_QTD_ACM),10) AS FSME_QTD_ACM
                         FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE
                        WHERE FSME_DATA < TO_DATE('" + dtInicio + @"','DD/MM/YYYY') AND FSME_DATA > TO_DATE('22/06/2012','DD/MM/YYYY') 
                          AND FCES_NIVEL =  " + maxLevelCriterio + @" 
                          AND FOSM_CNTR_CODIGO = '" + contrato + @"' 
                          AND FOSE_SBCN_ID = " + cmbFPSO.SelectedValue + @" 
                          AND DISC_ID = " + cmbDisciplina.SelectedValue + @"  
                          AND ATIV_ID = " + cmbAtividade.SelectedValue + @" 
                          AND FCME_ID = " + cmbCriterio.SelectedValue + @" 
                          AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO) 
                     GROUP BY FOSM_CNTR_CODIGO,  FOSM_ID,  ATIV_ID,  ATIV_SIG, ATIV_NOME,  UNME_ID,  UNME_SIGLA,  FOSE_ID,  FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_REV,  FOSE_SBCN_ID,  
                              DISC_ID,  DISC_NOME,  FCME_ID,  FCME_SIGLA,  FCME_NOME,  FCES_SIGLA,  FCES_DESCRICAO, FCES_NIVEL,  FCES_WBS,  FCES_PESO_REL_CRON
                     ORDER BY FOSE_ID, FCES_WBS";
            DataTable dtAvn = BLL.AcRamAtividadeStageBLL.Select(strSQL);
            #endregion

            //Limpa a tabela AC_RAM_ATIVIDADE_STAGE para o filtro correspondente às seleções
            #region Limpa Tabela STAGE
                strSQL = @"DELETE EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE WHERE ";
                string filter = @"FOSM_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = " + cmbFPSO.SelectedValue.ToString() + @" AND DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + @" AND ATIV_ID = " + cmbAtividade.SelectedValue.ToString() + @" AND FCME_ID = " + cmbCriterio.SelectedValue.ToString();
                strSQL += filter;
                BLL.AcRamAtividadeStageBLL.ExecuteSQLInstruction(strSQL);
            #endregion

            //Reune avancos da FOSE num único registro com os avanços Real e Ponderado fora do período
            #region AC_RAM_ATIVIDADE_STAGE
            //gera Registros em AC_RAM_ATIVIDADE_STAGE
            for (int a = 0; a < dtAvn.Rows.Count; a++)
            {
                DTO.AcRamAtividadeStageDTO stage = new DTO.AcRamAtividadeStageDTO();
                stage.SemaId = Convert.ToDecimal(cmbSemana.SelectedValue);
                stage.FosmCntrCodigo = Convert.ToString(dtAvn.Rows[a]["FOSM_CNTR_CODIGO"]);
                stage.FosmId = Convert.ToDecimal(dtAvn.Rows[a]["FOSM_ID"]);
                stage.AtivId = Convert.ToDecimal(dtAvn.Rows[a]["ATIV_ID"]);
                stage.AtivSig = Convert.ToString(dtAvn.Rows[a]["ATIV_SIG"]);
                stage.AtivNome = Convert.ToString(dtAvn.Rows[a]["ATIV_NOME"]);
                stage.UnmeId = Convert.ToDecimal(dtAvn.Rows[a]["UNME_ID"]);
                stage.UnmeSigla = Convert.ToString(dtAvn.Rows[a]["UNME_SIGLA"]);
                stage.FoseId = Convert.ToDecimal(dtAvn.Rows[a]["FOSE_ID"]);
                stage.FoseNumero = Convert.ToString(dtAvn.Rows[a]["FOSE_NUMERO"]);
                stage.FoseQtdPrevista = Convert.ToDecimal(dtAvn.Rows[a]["FOSE_QTD_PREVISTA"]);
                stage.FoseRev = Convert.ToString(dtAvn.Rows[a]["FOSE_REV"]);
                stage.SbcnId = Convert.ToDecimal(cmbFPSO.SelectedValue);
                stage.SbcnSigla = cmbFPSO.Text;
                stage.DiscId = Convert.ToDecimal(dtAvn.Rows[a]["DISC_ID"]);
                stage.DiscNome = Convert.ToString(dtAvn.Rows[a]["DISC_NOME"]);
                stage.FcmeId = Convert.ToDecimal(dtAvn.Rows[a]["FCME_ID"]);
                stage.FcmeSigla = Convert.ToString(dtAvn.Rows[a]["FCME_SIGLA"]);
                stage.FcmeNome = Convert.ToString(dtAvn.Rows[a]["FCME_NOME"]);

                filter = @"FOSM_CNTR_CODIGO = '" + contrato + @"' AND FOSE_NUMERO = '" + stage.FoseNumero + @"' AND SBCN_ID = " + stage.SbcnId.ToString() + @" AND DISC_ID = " + stage.DiscId.ToString() + @" AND ATIV_ID = " + stage.AtivId.ToString() + @" AND FCME_ID = " + stage.FcmeId.ToString() + @" AND FOSE_ID = " + stage.FoseId.ToString();
                int c = BLL.AcRamAtividadeStageBLL.Count(filter);
                if (c != 0) stage = BLL.AcRamAtividadeStageBLL.GetObject(filter);

                colPositionCriterio = Convert.ToInt32(Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]).Split('.')[maxLevelCriterio - 1]);
                //DTO.FcesTotaisDTO totFora = new DTO.FcesTotaisDTO();
                switch (colPositionCriterio)
                {
                    case 1: 
                        {
                            stage.El01FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El01FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El01FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El01FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El01FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El01FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El01FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El01FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El01FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El01FcesAvnPond = (stage.El01FcesAvnReal * stage.El01FcesPesoRelCron) / 100;

                            //tot.SumEl01 = stage.El01FcesAvnReal;
                            break; 
                        }
                    case 2:
                        {
                            stage.El02FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El02FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El02FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El02FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El02FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El02FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El02FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El02FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El02FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El02FcesAvnPond = (stage.El02FcesAvnReal * stage.El02FcesPesoRelCron) / 100;

                            //tot.SumEl02 = stage.El02FcesAvnReal;
                            break;
                        }
                    case 3:
                        {
                            stage.El03FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El03FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El03FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El03FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El03FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El03FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El03FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El03FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El03FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El03FcesAvnPond = (stage.El03FcesAvnReal * stage.El03FcesPesoRelCron) / 100;

                            //tot.SumEl02 = stage.El03FcesAvnReal;
                            break;
                        }
                    case 4:
                        {
                            stage.El04FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El04FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El04FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El04FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El04FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El04FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El04FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El04FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El04FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El04FcesAvnPond = (stage.El04FcesAvnReal * stage.El04FcesPesoRelCron) / 100;

                            //tot.SumEl04 = stage.El04FcesAvnReal;
                            break;
                        }
                    case 5:
                        {
                            stage.El05FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El05FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El05FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El05FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El05FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El05FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El05FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El05FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El05FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El05FcesAvnPond = (stage.El05FcesAvnReal * stage.El05FcesPesoRelCron) / 100;

                            //tot.SumEl05 = stage.El05FcesAvnReal;
                            break;
                        }
                    case 6:
                        {
                            stage.El06FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El06FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El06FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El06FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El06FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El06FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El06FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El06FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El06FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El06FcesAvnPond = (stage.El06FcesAvnReal * stage.El06FcesPesoRelCron) / 100;

                            //tot.SumEl06 = stage.El06FcesAvnReal;
                            break;
                        }
                    case 7:
                        {
                            stage.El07FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El07FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El07FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El07FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El07FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El07FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El07FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El07FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El07FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El07FcesAvnPond = (stage.El07FcesAvnReal * stage.El07FcesPesoRelCron) / 100;

                            //tot.SumEl07 = stage.El07FcesAvnReal;
                            break;
                        }
                    case 8:
                        {
                            stage.El08FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El08FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El08FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El08FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El08FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El08FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El08FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El08FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El08FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El08FcesAvnPond = (stage.El08FcesAvnReal * stage.El08FcesPesoRelCron) / 100;

                            //tot.SumEl08 = stage.El08FcesAvnReal;
                            break;
                        }
                    case 9:
                        {
                            stage.El09FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El09FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El09FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El09FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El09FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El09FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El09FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El09FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El09FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El09FcesAvnPond = (stage.El09FcesAvnReal * stage.El09FcesPesoRelCron) / 100;

                            //tot.SumEl09 = stage.El09FcesAvnReal;
                            break;
                        }
                    case 10:
                        {
                            stage.El10FcesSigla = Convert.ToString(dtAvn.Rows[a]["FCES_SIGLA"]);
                            stage.El10FcesDescricao = Convert.ToString(dtAvn.Rows[a]["FCES_DESCRICAO"]);
                            stage.El10FcesNivel = Convert.ToInt32(dtAvn.Rows[a]["FCES_NIVEL"]);
                            stage.El10FcesWbs = Convert.ToString(dtAvn.Rows[a]["FCES_WBS"]);
                            stage.El10FcesPesoRelCron = Convert.ToDecimal(dtAvn.Rows[a]["FCES_PESO_REL_CRON"]);
                            stage.El10FsmeAvancoAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]);
                            stage.El10FsmeQtdAcm = Convert.ToDecimal(dtAvn.Rows[a]["FSME_QTD_ACM"]);
                            stage.El10FsmeData = Convert.ToDateTime(dtAvn.Rows[a]["FSME_DATA"]);
                            stage.El10FcesAvnReal = Convert.ToDecimal(dtAvn.Rows[a]["FSME_AVANCO_ACM"]) * stage.FoseQtdPrevista / 100;
                            stage.El10FcesAvnPond = (stage.El10FcesAvnReal * stage.El10FcesPesoRelCron) / 100;

                            //tot.SumEl10 = stage.El10FcesAvnReal;
                            break;
                        }
                }
                if (c == 0) BLL.AcRamAtividadeStageBLL.Insert(stage, false);
                else BLL.AcRamAtividadeStageBLL.Update(stage);
            }
            #endregion

            AtualizaEstruturaCriterioStage();

                //Agrupa todas as folhas anteriores ao período com seus avanços no Critério de Medição
                #region AGRUPA AVANÇOS DO CRITÉRIO FORA DO PERÍODO
                strSQL = @"SELECT SEMA_ID, FOSM_CNTR_CODIGO, ATIV_ID, ATIV_SIG, ATIV_NOME, UNME_ID, UNME_SIGLA, SBCN_ID, DISC_ID,  DISC_NOME, FCME_ID, FCME_SIGLA, FCME_NOME, 
                              EL01_FCES_SIGLA, EL01_FCES_DESCRICAO, EL01_FCES_NIVEL, EL01_FCES_WBS, 
                              EL02_FCES_SIGLA, EL02_FCES_DESCRICAO, EL02_FCES_NIVEL, EL02_FCES_WBS, 
                              EL03_FCES_SIGLA, EL03_FCES_DESCRICAO, EL03_FCES_NIVEL, EL03_FCES_WBS, 
                              EL04_FCES_SIGLA, EL04_FCES_DESCRICAO, EL04_FCES_NIVEL, EL04_FCES_WBS, 
                              EL05_FCES_SIGLA, EL05_FCES_DESCRICAO, EL05_FCES_NIVEL, EL05_FCES_WBS, 
                              EL06_FCES_SIGLA, EL06_FCES_DESCRICAO, EL06_FCES_NIVEL, EL06_FCES_WBS, 
                              EL07_FCES_SIGLA, EL07_FCES_DESCRICAO, EL07_FCES_NIVEL, EL07_FCES_WBS, 
                              EL08_FCES_SIGLA, EL08_FCES_DESCRICAO, EL08_FCES_NIVEL, EL08_FCES_WBS, 
                              EL09_FCES_SIGLA, EL09_FCES_DESCRICAO, EL09_FCES_NIVEL, EL09_FCES_WBS, 
                              EL10_FCES_SIGLA, EL10_FCES_DESCRICAO, EL10_FCES_NIVEL, EL10_FCES_WBS, 

                              SUM(EL01_FSME_AVANCO_ACM) AS EL01_FSME_AVANCO_ACM, SUM(EL01_FSME_QTD_ACM) AS EL01_FSME_QTD_ACM, SUM(EL01_FCES_AVN_REAL) AS EL01_FCES_AVN_REAL, SUM(EL01_FCES_AVN_POND) AS EL01_FCES_AVN_POND,
                              SUM(EL02_FSME_AVANCO_ACM) AS EL02_FSME_AVANCO_ACM, SUM(EL02_FSME_QTD_ACM) AS EL02_FSME_QTD_ACM, SUM(EL02_FCES_AVN_REAL) AS EL02_FCES_AVN_REAL, SUM(EL02_FCES_AVN_POND) AS EL02_FCES_AVN_POND,
                              SUM(EL03_FSME_AVANCO_ACM) AS EL03_FSME_AVANCO_ACM, SUM(EL03_FSME_QTD_ACM) AS EL03_FSME_QTD_ACM, SUM(EL03_FCES_AVN_REAL) AS EL03_FCES_AVN_REAL, SUM(EL03_FCES_AVN_POND) AS EL03_FCES_AVN_POND,
                              SUM(EL04_FSME_AVANCO_ACM) AS EL04_FSME_AVANCO_ACM, SUM(EL04_FSME_QTD_ACM) AS EL04_FSME_QTD_ACM, SUM(EL04_FCES_AVN_REAL) AS EL04_FCES_AVN_REAL, SUM(EL04_FCES_AVN_POND) AS EL04_FCES_AVN_POND,
                              SUM(EL05_FSME_AVANCO_ACM) AS EL05_FSME_AVANCO_ACM, SUM(EL05_FSME_QTD_ACM) AS EL05_FSME_QTD_ACM, SUM(EL05_FCES_AVN_REAL) AS EL05_FCES_AVN_REAL, SUM(EL05_FCES_AVN_POND) AS EL05_FCES_AVN_POND,
                              SUM(EL06_FSME_AVANCO_ACM) AS EL06_FSME_AVANCO_ACM, SUM(EL06_FSME_QTD_ACM) AS EL06_FSME_QTD_ACM, SUM(EL06_FCES_AVN_REAL) AS EL06_FCES_AVN_REAL, SUM(EL06_FCES_AVN_POND) AS EL06_FCES_AVN_POND,
                              SUM(EL07_FSME_AVANCO_ACM) AS EL07_FSME_AVANCO_ACM, SUM(EL07_FSME_QTD_ACM) AS EL07_FSME_QTD_ACM, SUM(EL07_FCES_AVN_REAL) AS EL07_FCES_AVN_REAL, SUM(EL07_FCES_AVN_POND) AS EL07_FCES_AVN_POND,
                              SUM(EL08_FSME_AVANCO_ACM) AS EL08_FSME_AVANCO_ACM, SUM(EL08_FSME_QTD_ACM) AS EL08_FSME_QTD_ACM, SUM(EL08_FCES_AVN_REAL) AS EL08_FCES_AVN_REAL, SUM(EL08_FCES_AVN_POND) AS EL08_FCES_AVN_POND,
                              SUM(EL09_FSME_AVANCO_ACM) AS EL09_FSME_AVANCO_ACM, SUM(EL09_FSME_QTD_ACM) AS EL09_FSME_QTD_ACM, SUM(EL09_FCES_AVN_REAL) AS EL09_FCES_AVN_REAL, SUM(EL09_FCES_AVN_POND) AS EL09_FCES_AVN_POND,
                              SUM(EL10_FSME_AVANCO_ACM) AS EL10_FSME_AVANCO_ACM, SUM(EL10_FSME_QTD_ACM) AS EL10_FSME_QTD_ACM, SUM(EL10_FCES_AVN_REAL) AS EL10_FCES_AVN_REAL, SUM(EL10_FCES_AVN_POND) AS EL10_FCES_AVN_POND

                         FROM EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE
                        WHERE FOSM_CNTR_CODIGO = '" + contrato + @"' AND SBCN_ID = " + cmbFPSO.SelectedValue.ToString() + @" AND DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + @" AND ATIV_ID = " + cmbAtividade.SelectedValue.ToString() + @" AND FCME_ID = " + cmbCriterio.SelectedValue.ToString() + @" 
                        GROUP BY 
                              SEMA_ID, FOSM_CNTR_CODIGO, ATIV_ID, ATIV_SIG, ATIV_NOME, UNME_ID, UNME_SIGLA, SBCN_ID, DISC_ID,  DISC_NOME, FCME_ID, FCME_SIGLA, FCME_NOME, 
                              EL01_FCES_SIGLA, EL01_FCES_DESCRICAO, EL01_FCES_NIVEL, EL01_FCES_WBS, 
                              EL02_FCES_SIGLA, EL02_FCES_DESCRICAO, EL02_FCES_NIVEL, EL02_FCES_WBS, 
                              EL03_FCES_SIGLA, EL03_FCES_DESCRICAO, EL03_FCES_NIVEL, EL03_FCES_WBS, 
                              EL04_FCES_SIGLA, EL04_FCES_DESCRICAO, EL04_FCES_NIVEL, EL04_FCES_WBS, 
                              EL05_FCES_SIGLA, EL05_FCES_DESCRICAO, EL05_FCES_NIVEL, EL05_FCES_WBS, 
                              EL06_FCES_SIGLA, EL06_FCES_DESCRICAO, EL06_FCES_NIVEL, EL06_FCES_WBS, 
                              EL07_FCES_SIGLA, EL07_FCES_DESCRICAO, EL07_FCES_NIVEL, EL07_FCES_WBS, 
                              EL08_FCES_SIGLA, EL08_FCES_DESCRICAO, EL08_FCES_NIVEL, EL08_FCES_WBS, 
                              EL09_FCES_SIGLA, EL09_FCES_DESCRICAO, EL09_FCES_NIVEL, EL09_FCES_WBS, 
                              EL10_FCES_SIGLA, EL10_FCES_DESCRICAO, EL10_FCES_NIVEL, EL10_FCES_WBS
                        ORDER BY
                              FOSM_CNTR_CODIGO, SEMA_ID, SBCN_ID, DISC_NOME, FCME_SIGLA
                              ";
            #endregion

            //Gara saída sumarizada dos avanços no critério de medição referente às folhas anteriores ao período
            dtFolhasForaPeriodo = BLL.AcRamAtividadeStageBLL.Select(strSQL);
        }
        //===================================================================================
        private void AtualizaEstruturaCriterioStage()
        {
            #region Estrutura Critério
            strSQL = @"SELECT FCES_ID, FCES_SIGLA, FCES_DESCRICAO, FCES_NIVEL, FCES_PESO_REL_CRON, FCES_WBS FROM EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA WHERE FCES_NIVEL > 1 AND FCES_CNTR_CODIGO = '" + contrato + "' AND FCES_FCME_ID = " + Convert.ToDecimal(cmbCriterio.SelectedValue) + " ORDER BY FCES_WBS";
            dtCriterioEstruturaStage = BLL.AcRamAtividadeStageBLL.Select(strSQL);
            
            for (int c = 0; c < dtCriterioEstruturaStage.Rows.Count; c++)
            {
                string final = (c + 101).ToString();
                string posicao = "EL" + final.Substring(final.Length - 2);

                strSQL = "UPDATE EEP_CONVERSION.AC_RAM_ATIVIDADE_STAGE SET ";
                strSQL += posicao + "_FCES_SIGLA = '" + dtCriterioEstruturaStage.Rows[c]["FCES_SIGLA"].ToString() + "', ";
                strSQL += posicao + "_FCES_DESCRICAO = '" + dtCriterioEstruturaStage.Rows[c]["FCES_DESCRICAO"].ToString() + "', ";
                strSQL += posicao + "_FCES_NIVEL = " + dtCriterioEstruturaStage.Rows[c]["FCES_NIVEL"].ToString() + ", ";
                strSQL += posicao + "_FCES_WBS = '" + dtCriterioEstruturaStage.Rows[c]["FCES_WBS"].ToString() + "', ";
                strSQL += posicao + "_FCES_PESO_REL_CRON = " + dtCriterioEstruturaStage.Rows[c]["FCES_PESO_REL_CRON"].ToString() + " WHERE FCME_ID = " + cmbCriterio.SelectedValue.ToString();

                BLL.AcRamAtividadeStageBLL.ExecuteSQLInstruction(strSQL);
               
            }

            #endregion
        }
        //===================================================================================
        private string GetFilter()
        {
            string sRet = "";
            sRet = @"1 = 1 AND TIPO_LINHA > 10";
            if (cmbFPSO.SelectedIndex > 0) sRet += @" AND SBCN_ID = " + cmbFPSO.SelectedValue;
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND DISC_ID = " + cmbDisciplina.SelectedValue;
            if (cmbAtividade.SelectedIndex > 0) sRet += @" AND ATIV_ID = " + cmbAtividade.SelectedValue;
            if (cmbDisciplina.SelectedIndex > 0) sRet += @" AND FCME_ID = " + cmbCriterio.SelectedValue;
            return sRet;
        }
        //===================================================================================
        private void ShowReport(string filter)
        {
            //A3 - 29,7 x 42,0
            //A4 - 21,0 x 29,7

            DTO.CollectionAcRamAtividadeDTO col1 = new DTO.CollectionAcRamAtividadeDTO();
            col1 = BLL.AcRamAtividadeBLL.GetCollection(filter, "TIPO_LINHA, FOSE_NUMERO");

            reportViewer1.ProcessingMode = ProcessingMode.Local;
            LocalReport report = reportViewer1.LocalReport;
            report.ReportPath = systemRepository + @"RDLC\rdlcRAMAtividade.rdlc";

            ReportDataSource rds = new ReportDataSource("dsRAMAtividade", col1);
            report.DataSources.Add(rds);
            
            //CollectionDTOBindingSource.DataSource = col1;
            CollectionDTOBindingSource.DataSource = col1;
            reportViewer1.LocalReport.DataSources.Add(rds);

            // Create the parameterSemana report parameter
            string semana = "";
            if (rbSemana.Checked) semana = " - Semana: " + cmbSemana.Text;
            ReportParameter parameterSemana = new ReportParameter();
            parameterSemana.Name = "pSemana";
            parameterSemana.Values.Add(semana);

            // Create the parameterDisciplina report parameter
            string disciplina = "Disciplina: " + cmbDisciplina.Text;
            ReportParameter parameterDisciplina = new ReportParameter();
            parameterDisciplina.Name = "pDisciplina";
            parameterDisciplina.Values.Add(disciplina);

            // Create the parameterFPSO report parameter
            string fpso = "FPSO: " + cmbFPSO.Text;
            ReportParameter parameterFPSO = new ReportParameter();
            parameterFPSO.Name = "pFPSO";
            parameterFPSO.Values.Add(fpso);

            // Create the parameterCriterio report parameter
            string criterio = " - Critério de Medição: " + cmbCriterio.Text;
            ReportParameter parameterCriterio = new ReportParameter();
            parameterCriterio.Name = "pFCME";
            parameterCriterio.Values.Add(criterio);

            // Create the parameterAtividade report parameter
            string strPesoAtividade = "Não Informado";
            if (pesoAtividade > 0) strPesoAtividade = pesoAtividade.ToString();
            string atividade = "<b>Atividade: " + cmbAtividade.Text + "<br>Qtd Prevista: " + strPesoAtividade + "</b>";
            ReportParameter parameterAtividade = new ReportParameter();
            parameterAtividade.Name = "pAtividade";
            parameterAtividade.Values.Add(atividade);

            // Create the parameterPeriodo report parameter
            string periodo = "De " + dtInicio + " até " + dtFim;
            ReportParameter parameterPeriodo = new ReportParameter();
            parameterPeriodo.Name = "pPeriodo";
            parameterPeriodo.Values.Add(periodo);

            strSQL = @"SELECT FOSE_NUMERO, EL01, EL02, EL03, EL04, EL05, EL06, EL07, EL08, EL09, EL10 FROM EEP_CONVERSION.AC_RAM_ATIVIDADE WHERE ACTIVE = 1 
                          AND SBCN_ID = " + cmbFPSO.SelectedValue + @"
                          AND DISC_ID = " + cmbDisciplina.SelectedValue + @"
                          AND ATIV_ID = " + cmbAtividade.SelectedValue + @"
                          AND FCME_ID =  " + cmbCriterio.SelectedValue + @"
                          AND TIPO_LINHA < 10";
            dtCriterioCabecalho = BLL.AcRamAtividadeBLL.Select(strSQL);

            // Create the parameterEL* report parameter
            lec = maxLevelCriterio;

            ReportParameter parameterE1L1 = new ReportParameter();
            ReportParameter parameterE2L1 = new ReportParameter();
            ReportParameter parameterE3L1 = new ReportParameter();
            ReportParameter parameterE4L1 = new ReportParameter();
            ReportParameter parameterE5L1 = new ReportParameter();
            ReportParameter parameterE6L1 = new ReportParameter();
            ReportParameter parameterE7L1 = new ReportParameter();
            ReportParameter parameterE8L1 = new ReportParameter();
            ReportParameter parameterE9L1 = new ReportParameter();
            ReportParameter parameterE10L1 = new ReportParameter();

            ReportParameter parameterE1L2 = new ReportParameter();
            ReportParameter parameterE2L2 = new ReportParameter();
            ReportParameter parameterE3L2 = new ReportParameter();
            ReportParameter parameterE4L2 = new ReportParameter();
            ReportParameter parameterE5L2 = new ReportParameter();
            ReportParameter parameterE6L2 = new ReportParameter();
            ReportParameter parameterE7L2 = new ReportParameter();
            ReportParameter parameterE8L2 = new ReportParameter();
            ReportParameter parameterE9L2 = new ReportParameter();
            ReportParameter parameterE10L2 = new ReportParameter();

            ReportParameter parameterE1L3 = new ReportParameter();
            ReportParameter parameterE2L3 = new ReportParameter();
            ReportParameter parameterE3L3 = new ReportParameter();
            ReportParameter parameterE4L3 = new ReportParameter();
            ReportParameter parameterE5L3 = new ReportParameter();
            ReportParameter parameterE6L3 = new ReportParameter();
            ReportParameter parameterE7L3 = new ReportParameter();
            ReportParameter parameterE8L3 = new ReportParameter();
            ReportParameter parameterE9L3 = new ReportParameter();
            ReportParameter parameterE10L3 = new ReportParameter();


            for (int i = 0; i < lec; i++)
            {
                if (lec == 1)
                {
                    # region Parametros Linha 01
                    //PARAMETROS LINHA 01
                    // Create the parameterAtividade L1 report parameter 1
                    string e1L1 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                    //ReportParameter parameterE1L1 = new ReportParameter();
                    parameterE1L1.Name = "pE1L1";
                    parameterE1L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 2
                    string e2L1 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                    //ReportParameter parameterE2L1 = new ReportParameter();
                    parameterE2L1.Name = "pE2L1";
                    parameterE2L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 3
                    string e3L1 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                    //ReportParameter parameterE3L1 = new ReportParameter();
                    parameterE3L1.Name = "pE3L1";
                    parameterE3L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 4
                    string e4L1 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                    //ReportParameter parameterE4L1 = new ReportParameter();
                    parameterE4L1.Name = "pE4L1";
                    parameterE4L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 5
                    string e5L1 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                    //ReportParameter parameterE5L1 = new ReportParameter();
                    parameterE5L1.Name = "pE5L1";
                    parameterE5L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 6
                    string e6L1 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                    //ReportParameter parameterE6L1 = new ReportParameter();
                    parameterE6L1.Name = "pE6L1";
                    parameterE6L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 2
                    string e7L1 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                    //ReportParameter parameterE7L1 = new ReportParameter();
                    parameterE7L1.Name = "pE7L1";
                    parameterE7L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 3
                    string e8L1 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                    //ReportParameter parameterE8L1 = new ReportParameter();
                    parameterE8L1.Name = "pE8L1";
                    parameterE8L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 4
                    string e9L1 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                    //ReportParameter parameterE9L1 = new ReportParameter();
                    parameterE9L1.Name = "pE9L1";
                    parameterE9L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 5
                    string e10L1 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                    //ReportParameter parameterE10L1 = new ReportParameter();
                    parameterE10L1.Name = "pE10L1";
                    parameterE10L1.Values.Add(null);
                    # endregion

                    if (i == 0)
                    {
                        # region Parametros Linha 02

                        //PARAMETROS LINHA 02
                        // Create the parameterAtividade L2 report parameter 1
                        string e1L2 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                        //ReportParameter parameterE1L2 = new ReportParameter();
                        parameterE1L2.Name = "pE1L2";
                        parameterE1L2.Values.Add(e1L2);
                        // Create the parameterAtividade L2 report parameter 2
                        string e2L2 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                        //ReportParameter parameterE2L2 = new ReportParameter();
                        parameterE2L2.Name = "pE2L2";
                        parameterE2L2.Values.Add(e2L2);
                        // Create the parameterAtividade L2 report parameter 3
                        string e3L2 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                        //ReportParameter parameterE3L2 = new ReportParameter();
                        parameterE3L2.Name = "pE3L2";
                        parameterE3L2.Values.Add(e3L2);
                        // Create the parameterAtividade L2 report parameter 4
                        string e4L2 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                        //ReportParameter parameterE4L2 = new ReportParameter();
                        parameterE4L2.Name = "pE4L2";
                        parameterE4L2.Values.Add(e4L2);
                        // Create the parameterAtividade L2 report parameter 5
                        string e5L2 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                        //ReportParameter parameterE5L2 = new ReportParameter();
                        parameterE5L2.Name = "pE5L2";
                        parameterE5L2.Values.Add(e5L2);
                        // Create the parameterAtividade L2 report parameter 6
                        string e6L2 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                        //ReportParameter parameterE6L2 = new ReportParameter();
                        parameterE6L2.Name = "pE6L2";
                        parameterE6L2.Values.Add(e6L2);
                        // Create the parameterAtividade L2 report parameter 2
                        string e7L2 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                        //ReportParameter parameterE7L2 = new ReportParameter();
                        parameterE7L2.Name = "pE7L2";
                        parameterE7L2.Values.Add(e7L2);
                        // Create the parameterAtividade L2 report parameter 3
                        string e8L2 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                        //ReportParameter parameterE8L2 = new ReportParameter();
                        parameterE8L2.Name = "pE8L2";
                        parameterE8L2.Values.Add(e8L2);
                        // Create the parameterAtividade L2 report parameter 4
                        string e9L2 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                        //ReportParameter parameterE9L2 = new ReportParameter();
                        parameterE9L2.Name = "pE9L2";
                        parameterE9L2.Values.Add(e9L2);
                        // Create the parameterAtividade L2 report parameter 5
                        string e10L2 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                        //ReportParameter parameterE10L2 = new ReportParameter();
                        parameterE10L2.Name = "pE10L2";
                        parameterE10L2.Values.Add(e10L2);
                        # endregion
                    }
                }
                else if (lec == 2)
                {
                    # region Parametros Linha 01
                    //PARAMETROS LINHA 01
                    // Create the parameterAtividade L1 report parameter 1
                    string e1L1 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                    //ReportParameter parameterE1L1 = new ReportParameter();
                    parameterE1L1.Name = "pE1L1";
                    parameterE1L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 2
                    string e2L1 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                    //ReportParameter parameterE2L1 = new ReportParameter();
                    parameterE2L1.Name = "pE2L1";
                    parameterE2L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 3
                    string e3L1 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                    //ReportParameter parameterE3L1 = new ReportParameter();
                    parameterE3L1.Name = "pE3L1";
                    parameterE3L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 4
                    string e4L1 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                    //ReportParameter parameterE4L1 = new ReportParameter();
                    parameterE4L1.Name = "pE4L1";
                    parameterE4L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 5
                    string e5L1 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                    //ReportParameter parameterE5L1 = new ReportParameter();
                    parameterE5L1.Name = "pE5L1";
                    parameterE5L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 6
                    string e6L1 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                    //ReportParameter parameterE6L1 = new ReportParameter();
                    parameterE6L1.Name = "pE6L1";
                    parameterE6L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 2
                    string e7L1 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                    //ReportParameter parameterE7L1 = new ReportParameter();
                    parameterE7L1.Name = "pE7L1";
                    parameterE7L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 3
                    string e8L1 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                    //ReportParameter parameterE8L1 = new ReportParameter();
                    parameterE8L1.Name = "pE8L1";
                    parameterE8L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 4
                    string e9L1 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                    //ReportParameter parameterE9L1 = new ReportParameter();
                    parameterE9L1.Name = "pE9L1";
                    parameterE9L1.Values.Add(null);
                    // Create the parameterAtividade L1 report parameter 5
                    string e10L1 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                    //ReportParameter parameterE10L1 = new ReportParameter();
                    parameterE10L1.Name = "pE10L1";
                    parameterE10L1.Values.Add(null);
                    # endregion

                    if (i == 0)
                    {
                        # region Parametros Linha 02

                        //PARAMETROS LINHA 02
                        // Create the parameterAtividade L2 report parameter 1
                        string e1L2 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                        //ReportParameter parameterE1L2 = new ReportParameter();
                        parameterE1L2.Name = "pE1L2";
                        parameterE1L2.Values.Add(e1L2);
                        // Create the parameterAtividade L2 report parameter 2
                        string e2L2 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                        //ReportParameter parameterE2L2 = new ReportParameter();
                        parameterE2L2.Name = "pE2L2";
                        parameterE2L2.Values.Add(e2L2);
                        // Create the parameterAtividade L2 report parameter 3
                        string e3L2 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                        //ReportParameter parameterE3L2 = new ReportParameter();
                        parameterE3L2.Name = "pE3L2";
                        parameterE3L2.Values.Add(e3L2);
                        // Create the parameterAtividade L2 report parameter 4
                        string e4L2 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                        //ReportParameter parameterE4L2 = new ReportParameter();
                        parameterE4L2.Name = "pE4L2";
                        parameterE4L2.Values.Add(e4L2);
                        // Create the parameterAtividade L2 report parameter 5
                        string e5L2 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                        //ReportParameter parameterE5L2 = new ReportParameter();
                        parameterE5L2.Name = "pE5L2";
                        parameterE5L2.Values.Add(e5L2);
                        // Create the parameterAtividade L2 report parameter 6
                        string e6L2 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                        //ReportParameter parameterE6L2 = new ReportParameter();
                        parameterE6L2.Name = "pE6L2";
                        parameterE6L2.Values.Add(e6L2);
                        // Create the parameterAtividade L2 report parameter 2
                        string e7L2 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                        //ReportParameter parameterE7L2 = new ReportParameter();
                        parameterE7L2.Name = "pE7L2";
                        parameterE7L2.Values.Add(e7L2);
                        // Create the parameterAtividade L2 report parameter 3
                        string e8L2 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                        //ReportParameter parameterE8L2 = new ReportParameter();
                        parameterE8L2.Name = "pE8L2";
                        parameterE8L2.Values.Add(e8L2);
                        // Create the parameterAtividade L2 report parameter 4
                        string e9L2 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                        //ReportParameter parameterE9L2 = new ReportParameter();
                        parameterE9L2.Name = "pE9L2";
                        parameterE9L2.Values.Add(e9L2);
                        // Create the parameterAtividade L2 report parameter 5
                        string e10L2 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                        //ReportParameter parameterE10L2 = new ReportParameter();
                        parameterE10L2.Name = "pE10L2";
                        parameterE10L2.Values.Add(e10L2);
                        # endregion
                    }

                    if (i == 1)
                    {
                        # region Parametros Linha 03
                        //PARAMETROS LINHA 03
                        // Create the parameterAtividade L3 report parameter 1
                        string e1L3 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();

                        parameterE1L3.Name = "pE1L3";
                        parameterE1L3.Values.Add(e1L3);
                        // Create the parameterAtividade L3 report parameter 2
                        string e2L3 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                        //ReportParameter parameterE2L3 = new ReportParameter();
                        parameterE2L3.Name = "pE2L3";
                        parameterE2L3.Values.Add(e2L3);
                        // Create the parameterAtividade L3 report parameter 3
                        string e3L3 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                        //ReportParameter parameterE3L3 = new ReportParameter();
                        parameterE3L3.Name = "pE3L3";
                        parameterE3L3.Values.Add(e3L3);
                        // Create the parameterAtividade L3 report parameter 4
                        string e4L3 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                        //ReportParameter parameterE4L3 = new ReportParameter();
                        parameterE4L3.Name = "pE4L3";
                        parameterE4L3.Values.Add(e4L3);
                        // Create the parameterAtividade L3 report parameter 5
                        string e5L3 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                        //ReportParameter parameterE5L3 = new ReportParameter();
                        parameterE5L3.Name = "pE5L3";
                        parameterE5L3.Values.Add(e5L3);
                        // Create the parameterAtividade L3 report parameter 6
                        string e6L3 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                        //ReportParameter parameterE6L3 = new ReportParameter();
                        parameterE6L3.Name = "pE6L3";
                        parameterE6L3.Values.Add(e6L3);
                        // Create the parameterAtividade L3 report parameter 2
                        string e7L3 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                        //ReportParameter parameterE7L3 = new ReportParameter();
                        parameterE7L3.Name = "pE7L3";
                        parameterE7L3.Values.Add(e7L3);
                        // Create the parameterAtividade L3 report parameter 3
                        string e8L3 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                        //ReportParameter parameterE8L3 = new ReportParameter();
                        parameterE8L3.Name = "pE8L3";
                        parameterE8L3.Values.Add(e8L3);
                        // Create the parameterAtividade L3 report parameter 4
                        string e9L3 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                        //ReportParameter parameterE9L3 = new ReportParameter();
                        parameterE9L3.Name = "pE9L3";
                        parameterE9L3.Values.Add(e9L3);
                        // Create the parameterAtividade L3 report parameter 5
                        string e10L3 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                        //ReportParameter parameterE10L3 = new ReportParameter();
                        parameterE10L3.Name = "pE10L3";
                        parameterE10L3.Values.Add(e10L3);
                        # endregion
                    }
                }
                else
                {
                    # region Parametros Linha 01
                    //PARAMETROS LINHA 01
                    // Create the parameterAtividade L1 report parameter 1
                    string e1L1 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                    //ReportParameter parameterE1L1 = new ReportParameter();
                    parameterE1L1.Name = "pE1L1";
                    parameterE1L1.Values.Add(e1L1);
                    // Create the parameterAtividade L1 report parameter 2
                    string e2L1 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                    //ReportParameter parameterE2L1 = new ReportParameter();
                    parameterE2L1.Name = "pE2L1";
                    parameterE2L1.Values.Add(e2L1);
                    // Create the parameterAtividade L1 report parameter 3
                    string e3L1 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                    //ReportParameter parameterE3L1 = new ReportParameter();
                    parameterE3L1.Name = "pE3L1";
                    parameterE3L1.Values.Add(e3L1);
                    // Create the parameterAtividade L1 report parameter 4
                    string e4L1 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                    //ReportParameter parameterE4L1 = new ReportParameter();
                    parameterE4L1.Name = "pE4L1";
                    parameterE4L1.Values.Add(e4L1);
                    // Create the parameterAtividade L1 report parameter 5
                    string e5L1 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                    //ReportParameter parameterE5L1 = new ReportParameter();
                    parameterE5L1.Name = "pE5L1";
                    parameterE5L1.Values.Add(e5L1);
                    // Create the parameterAtividade L1 report parameter 6
                    string e6L1 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                    //ReportParameter parameterE6L1 = new ReportParameter();
                    parameterE6L1.Name = "pE6L1";
                    parameterE6L1.Values.Add(e6L1);
                    // Create the parameterAtividade L1 report parameter 2
                    string e7L1 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                    //ReportParameter parameterE7L1 = new ReportParameter();
                    parameterE7L1.Name = "pE7L1";
                    parameterE7L1.Values.Add(e7L1);
                    // Create the parameterAtividade L1 report parameter 3
                    string e8L1 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                    //ReportParameter parameterE8L1 = new ReportParameter();
                    parameterE8L1.Name = "pE8L1";
                    parameterE8L1.Values.Add(e8L1);
                    // Create the parameterAtividade L1 report parameter 4
                    string e9L1 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                    //ReportParameter parameterE9L1 = new ReportParameter();
                    parameterE9L1.Name = "pE9L1";
                    parameterE9L1.Values.Add(e9L1);
                    // Create the parameterAtividade L1 report parameter 5
                    string e10L1 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                    //ReportParameter parameterE10L1 = new ReportParameter();
                    parameterE10L1.Name = "pE10L1";
                    parameterE10L1.Values.Add(e10L1);
                    # endregion

                    # region Parametros Linha 02
                    //PARAMETROS LINHA 02
                    // Create the parameterAtividade L2 report parameter 1
                    string e1L2 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                    //ReportParameter parameterE1L2 = new ReportParameter();
                    parameterE1L2.Name = "pE1L2";
                    parameterE1L2.Values.Add(e1L2);
                    // Create the parameterAtividade L2 report parameter 2
                    string e2L2 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                    //ReportParameter parameterE2L2 = new ReportParameter();
                    parameterE2L2.Name = "pE2L2";
                    parameterE2L2.Values.Add(e2L2);
                    // Create the parameterAtividade L2 report parameter 3
                    string e3L2 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                    //ReportParameter parameterE3L2 = new ReportParameter();
                    parameterE3L2.Name = "pE3L2";
                    parameterE3L2.Values.Add(e3L2);
                    // Create the parameterAtividade L2 report parameter 4
                    string e4L2 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                    //ReportParameter parameterE4L2 = new ReportParameter();
                    parameterE4L2.Name = "pE4L2";
                    parameterE4L2.Values.Add(e4L2);
                    // Create the parameterAtividade L2 report parameter 5
                    string e5L2 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                    //ReportParameter parameterE5L2 = new ReportParameter();
                    parameterE5L2.Name = "pE5L2";
                    parameterE5L2.Values.Add(e5L2);
                    // Create the parameterAtividade L2 report parameter 6
                    string e6L2 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                    //ReportParameter parameterE6L2 = new ReportParameter();
                    parameterE6L2.Name = "pE6L2";
                    parameterE6L2.Values.Add(e6L2);
                    // Create the parameterAtividade L2 report parameter 2
                    string e7L2 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                    //ReportParameter parameterE7L2 = new ReportParameter();
                    parameterE7L2.Name = "pE7L2";
                    parameterE7L2.Values.Add(e7L2);
                    // Create the parameterAtividade L2 report parameter 3
                    string e8L2 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                    //ReportParameter parameterE8L2 = new ReportParameter();
                    parameterE8L2.Name = "pE8L2";
                    parameterE8L2.Values.Add(e8L2);
                    // Create the parameterAtividade L2 report parameter 4
                    string e9L2 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                    //ReportParameter parameterE9L2 = new ReportParameter();
                    parameterE9L2.Name = "pE9L2";
                    parameterE9L2.Values.Add(e9L2);
                    // Create the parameterAtividade L2 report parameter 5
                    string e10L2 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                    //ReportParameter parameterE10L2 = new ReportParameter();
                    parameterE10L2.Name = "pE10L2";
                    parameterE10L2.Values.Add(e10L2);
                    # endregion

                    # region Parametros Linha 03
                    //PARAMETROS LINHA 03
                    // Create the parameterAtividade L3 report parameter 1
                    string e1L3 = dtCriterioCabecalho.Rows[i]["EL01"].ToString();
                    //ReportParameter parameterE1L3 = new ReportParameter();
                    parameterE1L3.Name = "pE1L3";
                    parameterE1L3.Values.Add(e1L3);
                    // Create the parameterAtividade L3 report parameter 2
                    string e2L3 = dtCriterioCabecalho.Rows[i]["EL02"].ToString();
                    //ReportParameter parameterE2L3 = new ReportParameter();
                    parameterE2L3.Name = "pE2L3";
                    parameterE2L3.Values.Add(e2L3);
                    // Create the parameterAtividade L3 report parameter 3
                    string e3L3 = dtCriterioCabecalho.Rows[i]["EL03"].ToString();
                    //ReportParameter parameterE3L3 = new ReportParameter();
                    parameterE3L3.Name = "pE3L3";
                    parameterE3L3.Values.Add(e3L3);
                    // Create the parameterAtividade L3 report parameter 4
                    string e4L3 = dtCriterioCabecalho.Rows[i]["EL04"].ToString();
                    //ReportParameter parameterE4L3 = new ReportParameter();
                    parameterE4L3.Name = "pE4L3";
                    parameterE4L3.Values.Add(e4L3);
                    // Create the parameterAtividade L3 report parameter 5
                    string e5L3 = dtCriterioCabecalho.Rows[i]["EL05"].ToString();
                    //ReportParameter parameterE5L3 = new ReportParameter();
                    parameterE5L3.Name = "pE5L3";
                    parameterE5L3.Values.Add(e5L3);
                    // Create the parameterAtividade L3 report parameter 6
                    string e6L3 = dtCriterioCabecalho.Rows[i]["EL06"].ToString();
                    //ReportParameter parameterE6L3 = new ReportParameter();
                    parameterE6L3.Name = "pE6L3";
                    parameterE6L3.Values.Add(e6L3);
                    // Create the parameterAtividade L3 report parameter 2
                    string e7L3 = dtCriterioCabecalho.Rows[i]["EL07"].ToString();
                    //ReportParameter parameterE7L3 = new ReportParameter();
                    parameterE7L3.Name = "pE7L3";
                    parameterE7L3.Values.Add(e7L3);
                    // Create the parameterAtividade L3 report parameter 3
                    string e8L3 = dtCriterioCabecalho.Rows[i]["EL08"].ToString();
                    //ReportParameter parameterE8L3 = new ReportParameter();
                    parameterE8L3.Name = "pE8L3";
                    parameterE8L3.Values.Add(e8L3);
                    // Create the parameterAtividade L3 report parameter 4
                    string e9L3 = dtCriterioCabecalho.Rows[i]["EL09"].ToString();
                    //ReportParameter parameterE9L3 = new ReportParameter();
                    parameterE9L3.Name = "pE9L3";
                    parameterE9L3.Values.Add(e9L3);
                    // Create the parameterAtividade L3 report parameter 5
                    string e10L3 = dtCriterioCabecalho.Rows[i]["EL10"].ToString();
                    //ReportParameter parameterE10L3 = new ReportParameter();
                    parameterE10L3.Name = "pE10L3";
                    parameterE10L3.Values.Add(e10L3);
                    # endregion
                }
            }

            // Set the report parameters for the report
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterSemana, parameterDisciplina, parameterFPSO, parameterCriterio, parameterAtividade, parameterPeriodo, parameterE1L1, parameterE2L1, parameterE3L1, parameterE4L1, parameterE5L1, parameterE6L1, parameterE7L1, parameterE8L1, parameterE9L1, parameterE10L1, parameterE1L2, parameterE2L2, parameterE3L2, parameterE4L2, parameterE5L2, parameterE6L2, parameterE7L2, parameterE8L2, parameterE9L2, parameterE10L2, parameterE1L3, parameterE2L3, parameterE3L3, parameterE4L3, parameterE5L3, parameterE6L3, parameterE7L3, parameterE8L3, parameterE9L3, parameterE10L3 });


            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { parameterSemana, parameterDisciplina, parameterFPSO, parameterCriterio, parameterAtividade, parameterPeriodo });

            this.ParentForm.WindowState = FormWindowState.Maximized;
            this.WindowState = FormWindowState.Maximized;
            
            this.reportViewer1.RefreshReport();
            this.reportViewer1.Visible = true;
        }

        #region Filtros

        //===================================================================================
        private void rbPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = true;
            dtpFim.Enabled = true;
            cmbSemana.Visible = false;
            cmbSemana.SelectedIndex = 0;
        }
        //===================================================================================
        private void rbSemana_CheckedChanged(object sender, EventArgs e)
        {
            dtpInicio.Enabled = false;
            dtpFim.Enabled = false;
            cmbSemana.Visible = true;
        }
        //===================================================================================
        private void cmbSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSemana.Text.ToString() != "System.Data.DataRowView" && cmbSemana.Text.ToString() != "")
            {
                if (cmbSemana.SelectedIndex != -1)
                {
                    dtpInicio.Value = Convert.ToDateTime(cmbSemana.Text.Split(' ')[3]);
                    dtpFim.Value = Convert.ToDateTime(cmbSemana.Text.Split(' ')[5]);
                    Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            PreparaControlesPeriodo();
        }
        //===================================================================================
        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            PreparaControlesPeriodo();
        }
        //===================================================================================
        private void PreparaControlesPeriodo()
        {
            lblFPSO.Visible = false;
            cmbFPSO.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value)
                {
                    //cmbFPSO
                    //strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL UNION " +
                    //         @"SELECT 1 AS SBCN_ID, 'P74' AS SBCN_SIGLA from DUAL UNION " +
                    //         @"SELECT 2 AS SBCN_ID, 'P75' AS SBCN_SIGLA from DUAL UNION " +
                    //         @"SELECT 3 AS SBCN_ID, 'P76' AS SBCN_SIGLA from DUAL UNION " +
                    //         @"SELECT 4 AS SBCN_ID, 'P77' AS SBCN_SIGLA from DUAL " +
                    //         @"ORDER  BY 1 NULLS FIRST";

                    strSQL = @"SELECT NULL AS SBCN_ID, '' AS SBCN_SIGLA FROM DUAL" + @" UNION " + @"
                               SELECT DISTINCT SBCN_ID, SUBSTR(ATIV_SIG,1,3) AS SBCN_SIGLA
                                 FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE, EEP_CONVERSION.SUB_CONTRATO
                                WHERE FOSM_CNTR_CODIGO = SBCN_CNTR_CODIGO AND SUBSTR(ATIV_SIG,1,3) = SBCN_SIGLA
                                  AND FSME_DATA BETWEEN TO_DATE('" + dtpInicio.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND  TO_DATE('" + dtpFim.Value.ToString("dd/MM/yy") + @"','DD/MM/YY')
                                ORDER BY 1 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbFPSO.DataSource = dtDOC;
                    cmbFPSO.DisplayMember = "SBCN_SIGLA";
                    cmbFPSO.ValueMember = "SBCN_ID";

                    cmbFPSO.Visible = true;
                    lblFPSO.Visible = true;
                    
                    dtAvnDentroPeriodo = null;
                    dtAvnForaPeriodo = null;
                }
            }
        }
        //===================================================================================
        private void cmbFPSO_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDisciplina.Visible = false;
            cmbDisciplina.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbFPSO.SelectedIndex > 0)
                {
                    strSQL = @"SELECT NULL AS DISC_ID, NULL AS DISC_NOME FROM DUAL UNION SELECT DISTINCT DISC_ID, DISC_NOME FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE WHERE FSME_DATA BETWEEN TO_DATE('" + dtpInicio.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND TO_DATE('" + dtpFim.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND FOSE_SBCN_ID = " + cmbFPSO.SelectedValue + " ORDER BY 2 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbDisciplina.DataSource = dtDOC;
                    cmbDisciplina.DisplayMember = "DISC_NOME";
                    cmbDisciplina.ValueMember = "DISC_ID";
                    cmbDisciplina.Visible = true;
                    lblDisciplina.Visible = true;

                    dtAvnDentroPeriodo = null;
                    dtAvnForaPeriodo = null;
                }
            }
        }
        //===================================================================================
        private void cmbDisciplina_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAtividade.Visible = false;
            cmbAtividade.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbDisciplina.SelectedIndex > 0)
                {
                    lblProgress.Visible = true;
                    Application.DoEvents();
                    strSQL = @"SELECT NULL AS ATIV_ID, NULL AS ATIVIDADE FROM DUAL UNION SELECT DISTINCT ATIV_ID, ATIV_SIG || ' (' || ATIV_NOME || ')' AS ATIVIDADE FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE WHERE FSME_DATA BETWEEN TO_DATE('" + dtpInicio.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND TO_DATE('" + dtpFim.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND FOSE_SBCN_ID = " + cmbFPSO.SelectedValue + " AND DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + " AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO) ORDER BY 2 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbAtividade.DataSource = dtDOC;
                    cmbAtividade.DisplayMember = "ATIVIDADE";
                    cmbAtividade.ValueMember = "ATIV_ID";
                    cmbAtividade.Visible = true;
                    lblAtividade.Visible = true;

                    dtAvnDentroPeriodo = null;
                    dtAvnForaPeriodo = null;
                    lblProgress.Visible = false;
                    Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void cmbAtividade_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCriterio.Visible = false;
            cmbCriterio.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbAtividade.SelectedIndex > 0)
                {
                    lblProgress.Visible = true;
                    Application.DoEvents();
                    //strSQL = @"SELECT NULL AS FCME_ID, NULL AS CRITERIO FROM DUAL UNION SELECT DISTINCT FCME_ID, FCME_SIGLA || ' - ' || FCME_NOME AS CRITERIO FROM EEP_CONVERSION.VW_ATIV_FOSE_AVN_EXEC WHERE
                    strSQL = @"SELECT NULL AS FCME_ID, NULL AS CRITERIO FROM DUAL UNION SELECT DISTINCT FCME_ID, FCME_SIGLA || ' - ' || FCME_NOME AS CRITERIO FROM EEP_CONVERSION.VW_AC_AVN_ATIV_VINC_FOSM_FOSE WHERE
 FSME_DATA BETWEEN TO_DATE('" + dtpInicio.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND TO_DATE('" + dtpFim.Value.ToString("dd/MM/yy") + @"','DD/MM/YY') AND FOSE_SBCN_ID = " + cmbFPSO.SelectedValue + " AND DISC_ID = " + cmbDisciplina.SelectedValue.ToString() + " AND ATIV_ID = " + cmbAtividade.SelectedValue.ToString() + " AND ATIV_ID NOT IN (SELECT ATEX_ATIV_ID FROM EEP_CONVERSION.AC_ATIVIDADE_EXCECAO) ORDER BY 2 NULLS FIRST";
                    dtDOC = BLL.AcRamAtividadeBLL.Select(strSQL);
                    cmbCriterio.DataSource = dtDOC;
                    cmbCriterio.DisplayMember = "CRITERIO";
                    cmbCriterio.ValueMember = "FCME_ID";
                    cmbCriterio.Visible = true;
                    lblCriterio.Visible = true;

                    dtAvnDentroPeriodo = null;
                    dtAvnForaPeriodo = null;
                    lblProgress.Visible = false;
                    Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void cmbCriterio_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnExecute.Visible = false;
            if (dtpInicio.Value != null && dtpFim.Value != null)
            {
                if (dtpInicio.Value <= dtpFim.Value && cmbCriterio.SelectedIndex > 0)
                {
                    lblProgress.Visible = true;
                    Application.DoEvents();
                    btnExecute.Visible = true;
                    lblProgress.Visible = false;
                    Application.DoEvents();
                }
            }
        }
        //===================================================================================
        private void OnDoWork(object sender, DoWorkEventArgs e)
        {

        }
        //===================================================================================
        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }
        //===================================================================================
        private void OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
        //===================================================================================

        #endregion
    }
}