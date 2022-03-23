using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GridCarregamento.Modelo;
using GridCarregamento.DAL;
using System.Data;
using System.Collections;
using System.Collections.Specialized;

namespace GridCarregamento.Negocio
{
    public class TabelaNeg
    {
        public DataTable ListArea()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListArea();
        }
        public DataTable ListAreaGroup(decimal groupId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListAreaGroup(groupId);
        }
        public DataTable ListGroup()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListGroup();
        }
        public static List<ListTimeSheets> ListCraft2(decimal team_id)
        {
            List<ListTimeSheets> listTimeSheets = new List<ListTimeSheets>();
            return listTimeSheets;
        }
        public DataTable ListCraft(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraft(team_id);
        }
        public DataTable ListCraftUnion(decimal team_id, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraftUnion(team_id, date);
        }
        public DataTable ListCraftLeaderSupervisor(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraftLeaderSupervisor(team_id);
        }
        public DataTable ListCraftLeaderSupervisorID(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraftLeaderSupervisorID(team_id);
        }
        public DataTable ListCraft(string listCraftUsed, string id_name)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraft(listCraftUsed, id_name);
        }
        public DataTable ListActivities(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListActivities(team_id);
        }
        public DataTable ListActivities(string listActivitieUsed, string title)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListActivities(listActivitieUsed,title);
        }
        public DataTable ListActivitiesUnion(decimal team_id, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListActivitiesUnion(team_id, date);
        }
        public DataTable ListTeam()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeam();
        }
        public DataTable GetTeamCodeByID(string teamId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.GetTeamCodeByID(teamId);
        }
        public DataTable ListTeamArea(decimal idArea, string date, decimal idGroup)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeamArea(idArea, date, idGroup);
        }
        public DataTable ListTeam(decimal idTeam)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeam(idTeam);
        }
        public decimal TeamArea(decimal idTeam)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.TeamArea(idTeam);
        }
        public decimal TeamGroup(decimal idTeam)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.TeamGroup(idTeam);
        }
        public DataTable ListTimeSheets(decimal team_id, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTimeSheets(team_id, date);
        }
        public bool SaveTimeSheetTemplate(List<ListTimeSheetsAll> listTimeSheetsAll)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.SaveTimeSheetTemplate(listTimeSheetsAll);
        }
        public string AllHoursCraft(decimal craftId, decimal teamId, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.AllHoursCraft(craftId, teamId, date);
        }        
        public DataTable ListValidation(string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListValidation(date);
        }
        public List<ListTimeSheets> PrintTimeSheets(decimal team_id, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.PrintTimeSheets(team_id, date);
        }
        public List<ListActivities> PrintActivities(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.PrintActivities(team_id);
        }
        public string Barcode(decimal teamId, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.Barcode(teamId, date);
        }
        public int DigitoVerificador(string barcode)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.DigitoVerificador(barcode);
        }
        public void EnviarEmail(string nomeRemetente, string emailRemetente, string nomeDestinatario, string emailDestinatario, string assunto, string texto)
        {
            Dados obj = new Dados();
            obj.EnviarEmail(nomeRemetente,emailRemetente, nomeDestinatario, emailDestinatario, assunto, texto);
        }
        public ArrayList DomainGroupsLocal()
        {
            Dados obj = new Dados();
            return obj.DomainGroupsLocal();
        }
        public StringCollection DomainGroupsNet()
        {
            Dados obj = new Dados();
            return obj.DomainGroupsNet();
        }
        public bool DomainGroupsNet(string groupDomain)
        {
            Dados obj = new Dados();
            return obj.DomainGroupsNet(groupDomain);
        }
        public void CalculationHoursProcedure(string data,string dia)
        {
            TabelaDAL obj = new TabelaDAL();
            obj.CalculationHoursProcedure(data,dia);
        }
        public bool HollydayVerification(DateTime date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.HollydayVerification(date);
        }
        /*public string Turno(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.Turno(team_id);
        }*/
        public string Turno(decimal team_id, DateTime date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.Turno(team_id, date);
        }
        public decimal CalendarHours(DateTime date, string turno)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.CalendarHours(date, turno);
        }
        public decimal HoursWork(decimal team_id, string turno, string dia)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.HoursWork(team_id, turno, dia);
        }
        public bool verifyDataBase()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.verifyDataBase();
        }
        public DateTime ClosingDate()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ClosingDate();
        }
        public void ListTimeSheetsDeleteExists(decimal team_id, string date)       
        {
            TabelaDAL obj = new TabelaDAL();
            obj.ListTimeSheetsDeleteExists(team_id, date);
        }
    }
}
