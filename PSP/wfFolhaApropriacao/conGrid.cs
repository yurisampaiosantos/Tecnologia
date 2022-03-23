using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GridCarregamento.Negocio;
using GridCarregamento.Modelo;
using GridCarregamento.DAL;

namespace wfFolhaApropriacao
{
    public partial class conGrid : UserControl
    {
        List<string> Activities = new List<string>();
        List<string> GridActivities = new List<string>();
        List<string> GridCrafts = new List<string>();
        //string tipoMenu;
        decimal horaMaxima;
        decimal horaMaximaExtra;
        public decimal teamIdGlobal;
        public string dateSelect;
        //----procedure created----//
        private void SumColumn(int columns)
        {
            decimal total = 0;
            decimal hour = 0;
            decimal minute = 0;
            string[] strHours;
            int cnt;
            string cel = "";

            for (cnt = 0; cnt < dataGridConteudo.Rows.Count; cnt++)
            {
                try
                {
                    cel = Convert.ToString(dataGridConteudo[columns, cnt].Value);
                    if (cel != "" && cel != null)
                    {
                        strHours = cel.Split(':');
                        hour += Convert.ToDecimal(strHours[0]);
                        minute += Convert.ToDecimal(strHours[1]);
                    }
                }
                catch { }
            }

            hour = hour + Convert.ToDecimal((int)(minute / 60));
            minute = minute % 60;

            if (minute.ToString().Length != 2)
            {
                total += Convert.ToDecimal(hour + "0" + minute);
            }
            else
            {
                total += Convert.ToDecimal(hour + "" + minute);
            }

            try
            {
                dataGridTitulo.Rows[1].Cells[columns].Value = total;
            }
            catch { }
        }
        private void SumLine(int line)
        {
            decimal total = 0;
            decimal totalExtra = 0;
            decimal hour = 0;
            decimal minute = 0;
            string[] strHours;
            string cell;
            //-----------//
            for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt = cnt + 2)
            {
                try
                {
                    cell = dataGridConteudo[cnt, line].Value.ToString();
                    if (cell.IndexOf(":") == 0)
                    {
                        cell = Convert.ToDecimal(cell).ToString("00:00");
                    }
                    strHours = cell.Split(':');
                    hour += Convert.ToDecimal(strHours[0]);
                    minute += Convert.ToDecimal(strHours[1]);
                }
                catch { }
            }
            hour = hour + Convert.ToDecimal((int)(minute / 60));
            minute = minute % 60;
            if (minute.ToString().Length != 2)
            {
                total += Convert.ToDecimal(hour + "0" + minute);
            }
            else
            {
                total += Convert.ToDecimal(hour + "" + minute);
            }
            dataGridSum.Rows[line].Cells[2].Value = total.ToString("00:00");
            //----------------------------//
            totalExtra = 0;
            hour = 0;
            minute = 0;
            for (int cnt = 0; cnt <= dataGridConteudo.Columns.Count; cnt = cnt + 2)
            {
                /*try
                {
                    total += Convert.ToDecimal(dataGridConteudo[cnt, line].Value.ToString().Replace(".", ",").Replace(":", ""));
                }
                catch { }
                 */
                try
                {
                    cell = dataGridConteudo[cnt - 1, line].Value.ToString();
                    if (cell.IndexOf(":") == 0)
                    {
                        cell = Convert.ToDecimal(cell).ToString("00:00");
                    }
                    strHours = cell.Split(':');
                    hour += Convert.ToDecimal(strHours[0]);
                    minute += Convert.ToDecimal(strHours[1]);
                }
                catch { }
            }


            hour = hour + Convert.ToDecimal((int)(minute / 60));
            minute = minute % 60;
            if (minute.ToString().Length != 2)
            {
                totalExtra += Convert.ToDecimal(hour + "0" + minute);
            }
            else
            {
                totalExtra += Convert.ToDecimal(hour + "" + minute);
            }
            dataGridSum.Rows[line].Cells[3].Value = totalExtra.ToString("00:00");

            //-- verificar inconsistencias --//
            decimal AllHourCraft = 0;
            decimal AllOverTimeCraft = 0; 
            TabelaNeg tabelaNeg = new TabelaNeg();
            try
            {
                string[] strAllHoursCraft = tabelaNeg.AllHoursCraft(Convert.ToDecimal(dataGridSum.Rows[line].Cells[0].Value), teamIdGlobal, dateSelect).Split('|');
                try
                {
                    AllHourCraft = Convert.ToDecimal(strAllHoursCraft[0]) * 100;
                }
                catch { }

                try
                {
                    AllOverTimeCraft = Convert.ToDecimal(strAllHoursCraft[1]) * 100;
                }
                catch { }
            }
            catch { }
            if (total > horaMaxima || totalExtra > horaMaximaExtra || total < horaMaxima ||
              (total + AllHourCraft) > horaMaxima || (totalExtra + AllOverTimeCraft) > horaMaximaExtra)
            {
                if (total > horaMaxima)
                {
                    for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                    {
                        dataGridConteudo[cnt, line].Style.BackColor = Color.FromArgb(255, 192, 192);
                    }
                }
                if (total < horaMaxima)
                {
                   // if (total != 0)
                   // {
                        for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                        {
                            dataGridConteudo[cnt, line].Style.BackColor = Color.FromArgb(224, 200, 225);
                        }
                  /* }
                    else
                    {
                        for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                        {
                            dataGridConteudo[cnt, line].Style.BackColor = Color.White;//Color.FromArgb(224, 200, 225);
                        }
                     }*/
                }
                if (totalExtra > horaMaximaExtra)
                {
                    for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                    {
                        dataGridConteudo[cnt, line].Style.BackColor = Color.FromArgb(255, 128, 128);
                    }
                }
                if ((AllHourCraft != 0 || AllOverTimeCraft != 0) && ((total + AllHourCraft) > horaMaxima || (totalExtra + AllOverTimeCraft) > horaMaximaExtra))
                {
                    for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                    {
                        dataGridConteudo[cnt, line].Style.BackColor = Color.FromArgb(255, 192, 128);
                    }
                }
            }
            else
            {
                for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                {
                    dataGridConteudo[cnt, line].Style.BackColor = Color.White;
                }
            }

            SumAll();
        }
        private void SumLineAll()
        {
            decimal total = 0;
            decimal totalExtra = 0;
            decimal hour = 0;
            decimal minute = 0;
            string[] strHours;
            string cell;
            //-----------//
            for (int cntLine = 0; cntLine < dataGridConteudo.Rows.Count; cntLine++)
            {
                total = 0;
                totalExtra = 0;
                hour = 0;
                minute = 0;
                for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt = cnt + 2)
                {
                    try
                    {
                        cell = dataGridConteudo[cnt, cntLine].Value.ToString();
                        if (cell.IndexOf(":") == 0)
                        {
                            cell = Convert.ToDecimal(cell).ToString("00:00");
                        }
                        strHours = cell.Split(':');
                        hour += Convert.ToDecimal(strHours[0]);
                        minute += Convert.ToDecimal(strHours[1]);
                    }
                    catch
                    {
                    }
                }
                hour = hour + Convert.ToDecimal((int)(minute / 60));
                minute = minute % 60;
                if (minute.ToString().Length != 2)
                {
                    total += Convert.ToDecimal(hour + "0" + minute);
                }
                else
                {
                    total += Convert.ToDecimal(hour + "" + minute);
                }

                //----------------------------//
                totalExtra = 0;
                hour = 0;
                minute = 0;
                for (int cnt = 0; cnt <= dataGridConteudo.Columns.Count; cnt = cnt + 2)
                {
                    /*try
                    {
                        total += Convert.ToDecimal(dataGridConteudo[cnt, cntLine].Value.ToString().Replace(".", ",").Replace(":", ""));
                    }
                    catch { }
                     */
                    try
                    {
                        cell = dataGridConteudo[cnt - 1, cntLine].Value.ToString();
                        if (cell.IndexOf(":") == 0)
                        {
                            cell = Convert.ToDecimal(cell).ToString("00:00");
                        }
                        strHours = cell.Split(':');
                        hour += Convert.ToDecimal(strHours[0]);
                        minute += Convert.ToDecimal(strHours[1]);
                    }
                    catch { }
                }


                hour = hour + Convert.ToDecimal((int)(minute / 60));
                minute = minute % 60;
                if (minute.ToString().Length != 2)
                {
                    totalExtra += Convert.ToDecimal(hour + "0" + minute);
                }
                else
                {
                    totalExtra += Convert.ToDecimal(hour + "" + minute);
                }


                //-- verificar inconsistencias --//
                decimal AllHourCraft = 0;
                decimal AllOverTimeCraft = 0;
                TabelaNeg tabelaNeg = new TabelaNeg();
                try
                {
                    string[] strAllHoursCraft = tabelaNeg.AllHoursCraft(Convert.ToDecimal(dataGridSum.Rows[cntLine].Cells[0].Value), teamIdGlobal, dateSelect).Split('|');
                    try
                    {
                        AllHourCraft = Convert.ToDecimal(strAllHoursCraft[0]) * 100;
                    }
                    catch { }

                    try
                    {
                        AllOverTimeCraft = Convert.ToDecimal(strAllHoursCraft[1]) * 100;
                    }
                    catch { }
                }
                catch { }
                if (total > horaMaxima || totalExtra > horaMaximaExtra || total < horaMaxima ||
                    (total + AllHourCraft) > horaMaxima || (totalExtra + AllOverTimeCraft) > horaMaximaExtra)
                {
                    if (total > horaMaxima)
                    {
                        for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                        {
                            dataGridConteudo[cnt, cntLine].Style.BackColor = Color.FromArgb(255, 192, 192);
                        }
                    }
                    if (total < horaMaxima)
                    {
                       // if (total != 0)
                        //{
                            for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                            {
                                dataGridConteudo[cnt, cntLine].Style.BackColor = Color.FromArgb(224, 200, 225);
                            }
                        /*}
                        else
                        {
                            for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                            {
                                dataGridConteudo[cnt, cntLine].Style.BackColor = Color.White;// Color.FromArgb(224, 200, 225);
                            }
                        }*/
                    }
                    if (totalExtra > horaMaximaExtra)
                    {
                        for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                        {
                            dataGridConteudo[cnt, cntLine].Style.BackColor = Color.FromArgb(255, 128, 128);
                        }
                    }
                    if ((AllHourCraft != 0 || AllOverTimeCraft != 0) && ((total + AllHourCraft) > horaMaxima || (totalExtra + AllOverTimeCraft) > horaMaximaExtra))
                    {
                        for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                        {
                            dataGridConteudo[cnt, cntLine].Style.BackColor = Color.FromArgb(255, 192, 128);
                        }
                    }
                }
                else
                {
                    for (int cnt = 0; cnt < dataGridConteudo.Columns.Count; cnt++)
                    {
                        dataGridConteudo[cnt, cntLine].Style.BackColor = Color.White;
                    }
                }
            }
        }
        private void SumAll()
        {
            decimal totalHH = 0;
            decimal totalHE = 0;
            decimal total = 0;

            decimal hourHH = 0;
            decimal minuteHH = 0;
            decimal hourHE = 0;
            decimal minuteHE = 0;
            decimal hourTotal = 0;
            decimal minuteTotal = 0;
            decimal hourTotalHH = 0;
            decimal minuteTotalHH = 0;
            decimal hourTotalHE = 0;
            decimal minuteTotalHE = 0;
            string[] strHH;
            string[] strHE;

            for (int cnt = 0; cnt < dataGridSum.Rows.Count; cnt++)
            {
                total = 0;

                hourHH = 0;
                minuteHH = 0;
                hourHE = 0;
                minuteHE = 0;
                hourTotal = 0;
                minuteTotal = 0;

                try
                {
                    strHH = dataGridSum[2, cnt].Value.ToString().Split(':');
                    hourHH = Convert.ToDecimal(strHH[0]);
                    hourTotalHH += hourHH;
                    minuteHH = Convert.ToDecimal(strHH[1]);
                    minuteTotalHH += minuteHH;
                }
                catch { }
                try
                {
                    strHE = dataGridSum[3, cnt].Value.ToString().Split(':');
                    hourHE = Convert.ToDecimal(strHE[0]);
                    hourTotalHE += hourHE;
                    minuteHE = Convert.ToDecimal(strHE[1]);
                    minuteTotalHE += minuteHE;
                }
                catch { }

                // total//
                hourTotal = hourHH + hourHE;
                minuteTotal = minuteHH + minuteHE;
                hourTotal = hourTotal + Convert.ToDecimal((int)(minuteTotal / 60));
                minuteTotal = minuteTotal % 60;
                if (minuteTotal.ToString().Length != 2)
                {
                    total += Convert.ToDecimal(hourTotal + "0" + minuteTotal);
                }
                else
                {
                    total += Convert.ToDecimal(hourTotal + "" + minuteTotal);
                }
                //-----//
                dataGridSum.Rows[cnt].Cells[4].Value = total.ToString("00:00");
            }

            // Total//
            total = 0;
            hourTotal = hourTotalHH + hourTotalHE;
            minuteTotal = minuteTotalHH + minuteTotalHE;
            hourTotal = hourTotal + Convert.ToDecimal((int)(minuteTotal / 60));
            minuteTotal = minuteTotal % 60;
            if (minuteTotal.ToString().Length != 2)
            {
                total += Convert.ToDecimal(hourTotal + "0" + minuteTotal);
            }
            else
            {
                total += Convert.ToDecimal(hourTotal + "" + minuteTotal);
            }
            //----normal---//
            hourTotalHH = hourTotalHH + Convert.ToDecimal((int)(minuteTotalHH / 60));
            minuteTotalHH = minuteTotalHH % 60;
            if (minuteTotalHH.ToString().Length != 2)
            {
                totalHH += Convert.ToDecimal(hourTotalHH + "0" + minuteTotalHH);
            }
            else
            {
                totalHH += Convert.ToDecimal(hourTotalHH + "" + minuteTotalHH);
            }

            // extra//
            hourTotalHE = hourTotalHE + Convert.ToDecimal((int)(minuteTotalHE / 60));
            minuteHE = minuteHE % 60;
            if (minuteTotalHE.ToString().Length != 2)
            {
                totalHE += Convert.ToDecimal(hourTotalHE + "0" + minuteTotalHE);
            }
            else
            {
                totalHE += Convert.ToDecimal(hourTotalHE + "" + minuteTotalHE);
            }

            txtSumTotalHH.Text = totalHH.ToString("00:00");
            txtSumTotalHE.Text = totalHE.ToString("00:00");
            txtSumTotal.Text = total.ToString("00:00");
        }
        public bool Inconsistency()
        {
            bool result = false;
            for (int cnt = 0; cnt < dataGridConteudo.Rows.Count; cnt++)
            {
                if (dataGridConteudo.Rows[cnt].Cells[0].Style.BackColor != Color.White)
                    result = true;
            }
            return result;
        }
        private decimal InconsistencyOne(int line)
        {
            decimal result = 0;
            try
            {
                if (dataGridConteudo.Rows[line].Cells[0].Style.BackColor != Color.White)
                {
                    if (dataGridConteudo.Rows[line].Cells[0].Style.BackColor != Color.FromArgb(255, 192, 192))
                    {
                        //Horas maior que a maxima
                        result = -1;
                    }
                    else
                        if (dataGridConteudo.Rows[line].Cells[0].Style.BackColor != Color.FromArgb(224, 200, 225))
                        {
                            //Horas menor que a maxima
                            result = -2;
                        }
                        else
                            if (dataGridConteudo.Rows[line].Cells[0].Style.BackColor != Color.FromArgb(255, 128, 128))
                            {
                                //Horas extras maior que a maxima
                                result = -3;
                            }
                            else
                                if (dataGridConteudo.Rows[line].Cells[0].Style.BackColor != Color.FromArgb(255, 192, 128))
                                {
                                    //Horas total no dia maior que a maxima
                                    result = -4;
                                }
                }
            }
            catch { }
            return result;
        }
        public void ClearAll()
        {
            ClearGrid(dataGridConteudo);
            ClearGrid(dataGridTitulo);
            dataGridSum.Rows.Clear();
            dataGridLocal.Rows.Clear();
            Activities.Clear();
            txtSumTotal.Text = "";
            txtSumTotalHE.Text = "";
            txtSumTotalHH.Text = "";
            lbSupervisor.Text = "";
            lbLider.Text = "";            
            txtSumTotal.Visible = false;
            txtSumTotalHE.Visible = false;
            txtSumTotalHH.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            lbJornada.Visible = false;
        }
        private void ClearGrid(DataGridView dataGridView)
        {
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
        }
        public string ListCraftUsed()
        {
            string list = "";
            for (int cnt = 0; cnt < dataGridSum.Rows.Count; cnt++)
            {
                list = list + "," + dataGridSum.Rows[cnt].Cells[0].Value;
            }
            if (list == "")
            {
                list = "0";
            }
            return list.Remove(0, 1);
        }
        public string ListActivitiesUsed()
        {
            string list = "";
            for (int cnt = 0; cnt < dataGridTitulo.Columns.Count; cnt = cnt + 2)
            {
                list = list + "," + dataGridTitulo.Rows[0].Cells[cnt].Value;
            }
            if (list == "")
            {
                list = "0";
            }
            return list.Remove(0, 1);
        }
        private decimal ConvertHoursToNumber(string hours)
        {
            decimal hour = 0;
            decimal minute = 0;
            string[] strHours = hours.Split(':');
            try
            {
                hour = Convert.ToDecimal(strHours[0]);
            }
            catch
            {
                hour = 0;
            }
            try
            {
                minute = Convert.ToDecimal(strHours[1]);
                minute = (minute * 100) / 60;
            }
            catch
            {
                minute = 0;
            }
            return Convert.ToDecimal(hour + "," + minute);
        }
        private string ConvertNumberToHours(decimal value)
        {
            string hour = "";
            string minute = "";
            string[] strHours = value.ToString().Split(',');
            try
            {
                hour = strHours[0];
            }
            catch
            {
                hour = "00";
            }

            try
            {
                minute = strHours[1];
                minute = Convert.ToString((Convert.ToDecimal(minute) * 60) / 100);
            }
            catch
            {
                minute = "00";
            }
            //---- config --- /
            if (hour.Length < 2)
            {
                hour = "0" + hour;
            }
            if (minute.Length < 2)
            {
                minute = minute + "0";
            }
            return hour + ":" + minute;
        }
        public bool Save(string date, decimal teamId, decimal areaId, decimal grupoId)       
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            bool result = true;
            bool testSave = false;
            if (tabelaNeg.verifyDataBase() == true)
            {

                decimal activetyId = 0;
                decimal craftId = 0;
                decimal workedHours = 0;
                decimal workedOverTime = 0;
                string specialSituation = "";
                decimal vallueInconsistency = 0;
                string turno = "";
                decimal leaderId = 0;
                decimal supervisorId = 0;

                string teamCode = "";
                decimal rpId = 0;
                decimal gereId = 0;
                decimal localId = 0;
                decimal taskId = 0;
                decimal diefId = 0;
                string sbcnSigla = "";
                string teamTipoMo = "";
                string teamLocalNome = "";
                decimal novoIdLocal = 0;

                DataTable dataTable = tabelaNeg.ListTeamOtherFKs(teamId);
                try
                {
                    if (dataTable.Rows.Count != 0)
                    {
                        leaderId = Convert.ToDecimal(dataTable.Rows[0][0]);
                        supervisorId = Convert.ToDecimal(dataTable.Rows[0][1]);

                        if (dataTable.Rows[0][2] != System.DBNull.Value) teamCode = Convert.ToString(dataTable.Rows[0][2]);
                        if (dataTable.Rows[0][3] != System.DBNull.Value) rpId = Convert.ToDecimal(dataTable.Rows[0][3]);
                        if (dataTable.Rows[0][4] != System.DBNull.Value) gereId = Convert.ToDecimal(dataTable.Rows[0][4]);
                        if (dataTable.Rows[0][5] != System.DBNull.Value) localId = Convert.ToDecimal(dataTable.Rows[0][5]);
                        if (dataTable.Rows[0][6] != System.DBNull.Value) taskId = Convert.ToDecimal(dataTable.Rows[0][6]);
                        if (dataTable.Rows[0][7] != System.DBNull.Value) diefId = Convert.ToDecimal(dataTable.Rows[0][7]);
                        if (dataTable.Rows[0][8] != System.DBNull.Value) sbcnSigla = Convert.ToString(dataTable.Rows[0][8]);
                        if (dataTable.Rows[0][9] != System.DBNull.Value) teamTipoMo = Convert.ToString(dataTable.Rows[0][9]);
                        if (dataTable.Rows[0][10] != System.DBNull.Value) teamLocalNome = Convert.ToString(dataTable.Rows[0][10]);
                    }
                }
                catch 
                {
                    
                }

                //tabelaNeg.ListTimeSheetsDeleteExists(teamId, date);
                turno = tabelaNeg.Turno(teamId, Convert.ToDateTime(date));
                List<ListTimeSheetsAll> listTimeSheetsAll = new List<ListTimeSheetsAll>();
                for (int cntCraft = 0; cntCraft < dataGridConteudo.Rows.Count; cntCraft++)
                {
                    vallueInconsistency = InconsistencyOne(cntCraft);
                    try
                    {
                        specialSituation = Convert.ToString(dataGridSum.Rows[cntCraft].Cells[5].Value);
                    }
                    catch
                    {
                        specialSituation = "";
                    }

                    for (int cntActivities = 0; cntActivities < dataGridTitulo.Columns.Count; cntActivities = cntActivities + 2)
                    {
                        try
                        {
                            activetyId = Convert.ToDecimal(dataGridTitulo.Rows[0].Cells[cntActivities].Value);
                        }
                        catch
                        {
                            activetyId = 0;
                        }
                        try
                        {
                            craftId = Convert.ToDecimal(dataGridSum.Rows[cntCraft].Cells[0].Value);
                        }
                        catch
                        {
                            craftId = 0;
                        }
                        try
                        {
                            workedHours = ConvertHoursToNumber(dataGridConteudo.Rows[cntCraft].Cells[cntActivities].Value.ToString());
                        }
                        catch
                        {
                            workedHours = 0;
                        }
                        try
                        {
                            workedOverTime = ConvertHoursToNumber(dataGridConteudo.Rows[cntCraft].Cells[cntActivities + 1].Value.ToString());
                        }
                        catch
                        {
                            workedOverTime = 0;
                        }
                        ListTimeSheetsAll timeSheetsAll = new ListTimeSheetsAll();
                        timeSheetsAll.ActivetyId = activetyId;
                        timeSheetsAll.CraftId = craftId;
                        timeSheetsAll.TeamId = teamId;
                        timeSheetsAll.WorkedHours = workedHours;
                        timeSheetsAll.WorkedOverTime = workedOverTime;
                        timeSheetsAll.ExecutionDate = date;
                        timeSheetsAll.SpecialSituation = specialSituation;
                        timeSheetsAll.Inconsistency = vallueInconsistency;
                        timeSheetsAll.Turno = turno;
                        timeSheetsAll.AreaId = areaId;
                        timeSheetsAll.GrupoId = grupoId;
                        timeSheetsAll.LeaderId = leaderId;
                        timeSheetsAll.SupervisorId = supervisorId;
                        timeSheetsAll.TeamCode = teamCode;
                        timeSheetsAll.RpId = rpId;
                        timeSheetsAll.GereId = gereId;
                        timeSheetsAll.TaskId = taskId;
                        timeSheetsAll.DiefId = diefId;
                        timeSheetsAll.SbcnSigla = sbcnSigla;
                        timeSheetsAll.TeamTipoMo = teamTipoMo;

                        if (dataGridLocal.Rows[cntCraft].Cells[0].Value.ToString() == teamLocalNome)
                        {
                            timeSheetsAll.LocalId = localId;
                        }
                        else
                        {
                            novoIdLocal = tabelaNeg.RetornaIdLocal(dataGridLocal.Rows[cntCraft].Cells[0].Value.ToString());
                            timeSheetsAll.LocalId = novoIdLocal;
                        }

                        listTimeSheetsAll.Add(timeSheetsAll);
                    }
                }
                testSave = tabelaNeg.SaveTimeSheetTemplate(listTimeSheetsAll);
                if (testSave == false)
                {
                    result = false;
                }
                else
                {
                    //tabelaNeg.CalculationHoursProcedure(date, Convert.ToDateTime(date).ToString("ddd"));
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public void DeleteTime(string date, decimal teamId)
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            tabelaNeg.ListTimeSheetsDeleteExists(teamId, date);
        }
        private void AddColumnDefault()
        {
            txtSumTotal.Visible = true;
            txtSumTotalHE.Visible = true;
            txtSumTotalHH.Visible = true;
            AddLineDefault();
            for (int cnt = 0; cnt < dataGridSum.Rows.Count; cnt++)
            {
                dataGridConteudo.Rows.Add(""); 
            }
            dataGridConteudo.ColumnHeadersHeight = 48;
        }
        private void AddLineDefault()
        {
            dataGridTitulo.Rows.Add("");
            dataGridTitulo.Rows[0].Visible = false;
            dataGridTitulo.Rows.Add("");
            dataGridTitulo.Rows[1].Cells[0].ReadOnly = true;
            dataGridTitulo.ColumnHeadersHeight = 48;

        }
        private void DataSourceValueOne(string activitiesId, string craftId, string hours, string OverTime)
        {
            //---- hora normal ---/
            int line = GridCrafts.IndexOf(craftId);
            int column = GridActivities.IndexOf(activitiesId);

            try
            {
                if (hours != "0")
                {
                    dataGridConteudo.Rows[line].Cells[column * 2].Value = ConvertNumberToHours(Convert.ToDecimal(hours));
                }
            }
            catch { }
            //---- hora extra ---/
            try
            {
                if (OverTime != "0")
                {
                    dataGridConteudo.Rows[line].Cells[column * 2 + 1].Value = ConvertNumberToHours(Convert.ToDecimal(OverTime));
                }
            }
            catch { }

            SumColumn(column);
            SumColumn(column+1);
            SumLine(line);
        }
        public void DataSourceLines(DataTable dataTableLine)
        {
            ClearGrid(dataGridConteudo);
            ClearGrid(dataGridTitulo);
            dataGridSum.Rows.Clear();

            int cnt = 0;
            {
                while (dataTableLine.Rows.Count != cnt)
                {
                    dataGridSum.Rows.Add(dataTableLine.Rows[cnt][0].ToString());
                    dataGridSum.Rows[cnt].Cells[1].Value = dataTableLine.Rows[cnt][1].ToString();
                    dataGridSum.Rows[cnt].Cells[5].Value = dataTableLine.Rows[cnt][2].ToString();
                    dataGridSum.Rows[cnt].Cells[6].Value = dataTableLine.Rows[cnt][3].ToString();

                    dataGridSum.Rows[cnt].Cells[0].ReadOnly = true;
                    if (dataGridConteudo.Rows.Count != 0)
                        dataGridConteudo.Rows.Add("");
                    SumLine(cnt);
                    cnt++;
                }
                if (dataGridTitulo.Rows.Count != 0)
                {
                    dataGridTitulo.Rows.Add("");
                    dataGridTitulo.Rows[1].Cells[0].ReadOnly = true;
                    for (cnt = 0; cnt < dataGridConteudo.Columns.Count - 1; cnt++)
                    {
                        dataGridTitulo.Rows[1].Cells[0].Value = dataTableLine.Rows.Count + ":00";
                    }
                    SumAll();
                }
            }
        }
        public void DataSourceLineOne(string id, string description, string specialSituation, string strFalta)
        {
                dataGridSum.Rows.Add(id.ToString());
                dataGridSum.Rows[dataGridSum.Rows.Count - 1].Cells[1].Value = description;
                dataGridSum.Rows[dataGridSum.Rows.Count - 1].Cells[5].Value = specialSituation;
                dataGridSum.Rows[dataGridSum.Rows.Count - 1].Cells[6].Value = strFalta;
                if (dataGridConteudo.Rows.Count != 0)
                    dataGridConteudo.Rows.Add("");
               // SumColumn(dataGridSum.Rows.Count-1);
               // SumLineAll();
               // SumAll();       
        }
        public void DataSourceColumnOne(string id, string description)
        {
            DataGridViewTextBoxColumn texto = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn texto2 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn texto3 = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn texto4 = new DataGridViewTextBoxColumn();

            texto.HeaderText = "HN";
            texto.SortMode = DataGridViewColumnSortMode.NotSortable;
            texto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            texto.Width = 50;
            texto2.HeaderText = "HE";
            texto2.SortMode = DataGridViewColumnSortMode.NotSortable;
            texto2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            texto2.Width = 50;
            //---------------------------//
            texto3.HeaderText = "HN";
            texto3.SortMode = DataGridViewColumnSortMode.NotSortable;
            texto3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            texto3.Width = 50;
            texto4.HeaderText = "HE";
            texto4.SortMode = DataGridViewColumnSortMode.NotSortable;
            texto4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            texto4.Width = 50;

            //----------------------------//
            dataGridTitulo.Columns.Add(texto);
            dataGridTitulo.Columns.Add(texto2);
            dataGridConteudo.Columns.Add(texto3);
            dataGridConteudo.Columns.Add(texto4);
            Activities.Add(description);
            if (dataGridTitulo.Rows.Count == 0)
                AddColumnDefault();
            //----------------------------//
            dataGridTitulo.Rows[0].Cells[dataGridTitulo.Columns.Count-2].Value = id;
            SumLineAll();
            //SumAll(); 
        }

        public void CarregaLocal(DataTable dtbFuncionarios, DataTable dtbQtdLocais)
        {
            dataGridLocal.Columns.Clear();

            DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            cmb.Name = "Local";

            DataTable dtbTabela = new DataTable();
            TabelaDAL tabelaDAL = new TabelaDAL();
            dtbTabela = tabelaDAL.ListaLocal();

            for (int i = 0; i < dtbTabela.Rows.Count; i++)
            {
                cmb.Items.Add(dtbTabela.Rows[i][1].ToString());
            }

            RemoveDuplicates(dtbQtdLocais);

            if (!(dtbQtdLocais.Rows.Count == 1 && Convert.ToInt32(dtbQtdLocais.Rows[0][5]) == 1))
            {
                for (int i = 0; i < dtbQtdLocais.Rows.Count; i++)
                {
                    cmb.Items.Add(dtbQtdLocais.Rows[i][4].ToString());
                }
            }

            dataGridLocal.Columns.Add(cmb);
            dataGridLocal.Columns[0].Width = 133;

            for (int i = 0; i < dtbFuncionarios.Rows.Count; i++)
            {
                dataGridLocal.Rows.Add(dtbFuncionarios.Rows[i][4].ToString());
            }
        }

        private void RemoveDuplicates(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = dt.Rows.Count - 1; i >= 0; i--)
                {
                    if (i == 0)
                    {
                        break;
                    }

                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (dt.Rows[i]["LOCAL"].ToString() == dt.Rows[j]["LOCAL"].ToString() || Convert.ToInt32(dt.Rows[i]["STATUS_LOCAL"]) == 1)
                        {
                            dt.Rows[i].Delete();
                            break;
                        }
                    }
                }

                dt.AcceptChanges();
            }
        }

        public bool DataSourceFill(DataTable dataTable, decimal team_id, string date)
        {
            bool result = false;
            if (dataTable.Rows.Count != 0)
            {
                ClearAll();
                GridCrafts.Clear();
                GridActivities.Clear();
                int cnt = 0;

                //    adicionando 

                //    adicionar integrantes do time 
                DataTable dataTableCraft = new DataTable();
                TabelaNeg tabelaNeg = new TabelaNeg();
        
                dataTableCraft = tabelaNeg.ListCraftUnion(team_id, date);
                try
                {
                    while (dataTableCraft.Rows[cnt][0].ToString() != "0")
                    {
                        DataSourceLineOne(dataTableCraft.Rows[cnt][0].ToString(), dataTableCraft.Rows[cnt][1].ToString(), dataTableCraft.Rows[cnt][2].ToString(), dataTableCraft.Rows[cnt][3].ToString());
                        GridCrafts.Add(dataTableCraft.Rows[cnt][0].ToString());
                        cnt++;
                    }
                }
                catch { }

                //    adicionar atividades
                DataTable dataTableActivities = new DataTable();
                dataTableActivities = tabelaNeg.ListActivitiesUnion(team_id, date);
                cnt = 0;
                try
                {
                    while (dataTableActivities.Rows[cnt][0].ToString() != "0")
                    {
                        DataSourceColumnOne(dataTableActivities.Rows[cnt][0].ToString(), dataTableActivities.Rows[cnt][1].ToString());
                        GridActivities.Add(dataTableActivities.Rows[cnt][0].ToString());
                        cnt++;
                    }
                }
                catch { }

                //---- add value --//
             //   int cntLine = 0;
                cnt = 0;
                try
                {
                    while (dataTable.Rows.Count != cnt)
                    {
                        DataSourceValueOne(dataTable.Rows[cnt][0].ToString(), dataTable.Rows[cnt][1].ToString(), dataTable.Rows[cnt][2].ToString(), dataTable.Rows[cnt][3].ToString());
                        SumColumn(cnt);
                    //    SumLine(cntLine);
                        cnt++;
                    }
                }
                catch { }

                
                SumLineAll();
                SumAll();
                result = true;
            }
             return result;
        }
        public void LeaderSupervisor(int team_id)
        {
            TabelaNeg tabelaNeg = new TabelaNeg();
            DataTable dataTable = tabelaNeg.ListCraftLeaderSupervisor(team_id);
            if (dataTable.Rows.Count != 0)
            {
                lbLider.Text = dataTable.Rows[0][0].ToString();
                lbSupervisor.Text = dataTable.Rows[0][1].ToString();
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                lbJornada.Visible = true;
            }
        }
        private void ClearPreencher(int line)
        {
            try
            {
                if (dataGridSum.Rows[line].Cells[5].Value != null && dataGridSum.Rows[line].Cells[5].Value.ToString() != "")
                {
                    dataGridConteudo.Rows[line].Cells[0].Value = "0"+horaMaxima.ToString().Substring(0,1)+":00";

                    for (int x = 0; x < dataGridConteudo.Columns.Count; x++)
                    {
                        dataGridConteudo.Rows[line].Cells[x].Value = "";
                        SumColumn(x);
                    }                    
                }
                else
                {
                    dataGridConteudo.Rows[line].Cells[0].Value = "";
                }
                SumLine(line);
                SumAll();
            }
            catch { }
        }
        public void HoraSelect(DateTime data)
        {
            string turno = "";
            decimal horasDiferenciadas = 0;
            TabelaNeg tabelaNeg = new TabelaNeg();
            if (tabelaNeg.HollydayVerification(data))
            {
                horaMaxima = 0;
            }
            else
            {
                turno = tabelaNeg.Turno(teamIdGlobal, data);
                horasDiferenciadas = tabelaNeg.CalendarHours(data, turno);
                if (horasDiferenciadas == 0)
                {
                    horaMaxima = tabelaNeg.HoursWork(teamIdGlobal, turno, data.ToString("ddd"));
                }
                else
                {
                    horaMaxima = horasDiferenciadas;
                }
            }
            try
            {
                lbJornada.Text = ConvertNumberToHours(horaMaxima/100);
            }
            catch
            {
                lbJornada.Text = "";
            }
        }
        //--------------------------//
        public conGrid()
        {
            InitializeComponent();
            horaMaximaExtra = 1000;
            dataGridConteudo.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridConteudo_CellFormatting);
            dataGridSum.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridSum_CellFormatting);
            dataGridTitulo.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridTitulo_CellFormatting);
            dataGridConteudo.AutoGenerateColumns = true;
        }
        void menu_ItemClickedExcluirLineOrColumn(object sender, ToolStripItemClickedEventArgs e)
        {
            string comando = string.Empty;
            try
            {
                int currentCell = dataGridConteudo.CurrentCell.ColumnIndex;
                int currentLine = dataGridConteudo.CurrentCell.RowIndex;
                ContextMenuStrip menu = (ContextMenuStrip)sender;
                menu.Hide();
                DialogResult myDialogResult;
                switch (e.ClickedItem.Text)
                {
                    case "Excluir Participante":
                        myDialogResult = MessageBox.Show("Tem certeza que desja excluir o Participante selecionado?", "Excluir Participante", MessageBoxButtons.YesNo);

                        if (myDialogResult == DialogResult.Yes)
                        {
                            dataGridConteudo.Rows.RemoveAt(currentLine);
                            dataGridSum.Rows.RemoveAt(currentLine);
                        }
                        break;
                    case "Excluir Atividade":
                        myDialogResult = MessageBox.Show("Tem certeza que desja excluir a Atividade selecionada", "Excluir Atividade", MessageBoxButtons.YesNo);

                        if (myDialogResult == DialogResult.Yes)
                        {
                            // if (dataGridConteudo.CurrentCell.ColumnIndex != 0)// && dataGridConteudo.CurrentCell.ColumnIndex != 1)
                            // {
                            if (dataGridConteudo.CurrentCell.ColumnIndex % 2 == 0)
                            {
                                dataGridConteudo.Columns.RemoveAt(currentCell + 1);
                                dataGridTitulo.Columns.RemoveAt(currentCell + 1);
                                dataGridConteudo.Columns.RemoveAt(currentCell);
                                dataGridTitulo.Columns.RemoveAt(currentCell);
                                Activities.RemoveAt(currentCell / 2);
                            }
                            else
                            {
                                dataGridConteudo.Columns.RemoveAt(currentCell);
                                dataGridTitulo.Columns.RemoveAt(currentCell);
                                dataGridConteudo.Columns.RemoveAt(currentCell - 1);
                                dataGridTitulo.Columns.RemoveAt(currentCell - 1);
                                Activities.RemoveAt((currentCell - 1) / 2);
                            }
                            // }
                        }
                        break;
                }
                if (!comando.Equals(""))
                    System.Diagnostics.Process.Start(comando);
                SumAll();
            }
            catch { }
        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                {
                    double d = double.Parse(dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(":", ""));
                    dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = d.ToString("00:00");
                    // valida de os minuto digitado é menor que 60 e divisível por 15
                    if ((Convert.ToDecimal(dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Substring(3, 2)) % 15 != 0 ||
                        Convert.ToDecimal(dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Substring(3, 2)) >= 60) &&
                        Convert.ToDecimal(dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Substring(3, 2)) != 0)
                    {
                        dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        MessageBox.Show("O valor em minutos deve ser divisível por 15 e menor que 60.");
                    }
                }
                SumColumn(e.ColumnIndex);
                SumLine(e.RowIndex);
            }
            catch
            {
                dataGridConteudo.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                MessageBox.Show("Valor informadado não permitido!");
            }
        }
        private void dataGridConteudo_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
               // menu.Items.Add("Excluir Participante");
                menu.Items.Add("Excluir Atividade");
                menu.Show(this.dataGridConteudo, new Point(e.X, e.Y));
                menu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClickedExcluirLineOrColumn);
            }
        }
        private void dataGridTitulo_Scroll(object sender, ScrollEventArgs e)
        {
        //    dataGridConteudo.FirstDisplayedScrollingRowIndex = dataGridTitulo.FirstDisplayedScrollingRowIndex;
            Rectangle rtHeader = this.dataGridTitulo.DisplayRectangle;
            rtHeader.Height = this.dataGridTitulo.ColumnHeadersHeight / 2;
            this.dataGridTitulo.Invalidate(rtHeader);
        }
        private void dataGridTitulo_Paint(object sender, PaintEventArgs e)
        {
            if (dataGridTitulo.Columns.Count != 0)
            {
                //string[] monthes = { "Emp Info", "", "", "", "" };
                for (int j = 0; j < dataGridTitulo.Columns.Count; )
                {
                    Rectangle r1 = dataGridTitulo.GetCellDisplayRectangle(j, -1, true);
                    int w2 = dataGridTitulo.GetCellDisplayRectangle(j + 1, -1, true).Width;
                    r1.X += 1;
                    r1.Y += 1;
                    r1.Width = r1.Width + w2 - 2;
                    r1.Height = r1.Height / 2 - 2;
                    e.Graphics.FillRectangle(new SolidBrush(dataGridTitulo.ColumnHeadersDefaultCellStyle.BackColor), r1);
                    StringFormat format = new StringFormat();
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    try
                    {
                        e.Graphics.DrawString(Activities[j / 2],
                            //  e.Graphics.DrawString(monthes[j / 2],
                        dataGridTitulo.ColumnHeadersDefaultCellStyle.Font,
                        new SolidBrush(dataGridTitulo.ColumnHeadersDefaultCellStyle.ForeColor),
                        r1,
                        format);
                    }
                    catch { }
                    j += 2;
                }
            }

        }
        private void dataGridTitulo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dataGridTitulo.DisplayRectangle;
            rtHeader.Height = this.dataGridTitulo.ColumnHeadersHeight / 2;
            this.dataGridTitulo.Invalidate(rtHeader);
        }
        void dataGridConteudo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.Value != null)
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("00:00");
                }
            }
            catch 
            {                
            }
        }
        void dataGridSum_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1)
               {            
            try
            {
                double d = double.Parse(e.Value.ToString());
                e.Value = d.ToString("00:00");
            }
            catch { }
               }
        }
        void dataGridTitulo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                try
                {
                    double d = double.Parse(e.Value.ToString());
                    e.Value = d.ToString("00:00");
                }
                catch { }

            }
        }
        private void dataGridSum_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridConteudo.FirstDisplayedScrollingRowIndex = dataGridSum.FirstDisplayedScrollingRowIndex;
            }
            catch { }
        }
        private void dataGridConteudo_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridSum.FirstDisplayedScrollingRowIndex = dataGridConteudo.FirstDisplayedScrollingRowIndex;
                dataGridLocal.FirstDisplayedScrollingRowIndex = dataGridConteudo.FirstDisplayedScrollingRowIndex;
            }
            catch { }
            try
            {
                dataGridTitulo.FirstDisplayedScrollingColumnIndex = dataGridConteudo.FirstDisplayedScrollingColumnIndex;
            }
            catch { }
        }
        private void dataGridSum_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridConteudo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridTitulo.Columns[e.ColumnIndex].Selected = true;
                dataGridSum.Rows[e.RowIndex].Cells[0].Selected = true;
                dataGridLocal.Rows[e.RowIndex].Cells[0].Selected = true;
            }
            catch { }
        }
        private void dataGridLocal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridTitulo.Columns[e.ColumnIndex].Selected = true;
                dataGridSum.Rows[e.RowIndex].Cells[0].Selected = true;
                dataGridConteudo.Rows[e.RowIndex].Cells[0].Selected = true;
            }
            catch { }
        }
        private void dataGridSum_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
              //  ClearPreencher(e.RowIndex);
            }
            catch { }
        }
        private void dataGridSum_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridConteudo.Rows[e.RowIndex].Cells[0].Selected = true;
            }
            catch { }
        }
        private void dataGridConteudo_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridSum.Rows[e.RowIndex].Cells[0].Selected = true;
                dataGridLocal.Rows[e.RowIndex].Cells[0].Selected = true;
            }
            catch { }
        }
    }
}
