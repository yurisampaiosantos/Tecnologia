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
        public DataTable ListAreaGroupComissionamento(decimal groupId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListAreaGroupComissionamento(groupId);
        }
        public DataTable ListaArea(decimal groupId, decimal responsavelId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListaArea(groupId, responsavelId);
        }
        public DataTable ListaResponsavel(decimal groupId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListaResponsavel(groupId);
        }
        public DataTable ListGroup()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListGroup();
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
        public DataTable ListTeamOtherFKs(decimal team_id)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeamOtherFKs(team_id);
        }
        public DataTable ListCraft(string listCraftUsed, string id_name)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListCraft(listCraftUsed, id_name);
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
        public DataTable ListRP()
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListRP();
        }
        public DataTable GetTeamCodeByID(string teamId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.GetTeamCodeByID(teamId);
        }
        public DataTable GetTeamByRpID(decimal rpId)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.GetTeamByRpId(rpId);
        }
        public DataTable ListTeamAreaComissionamento(decimal idArea, string date, decimal idGroup, string turno)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeamAreaComissionamento(idArea, date, idGroup, turno);
        }
        public DataTable ListaEquipe(decimal idArea, string date, decimal idGroup, string turno, decimal idResponsavel)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListaEquipe(idArea, date, idGroup, turno, idResponsavel);
        }
        public DataTable ListTeam(decimal idTeam)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListTeam(idTeam);
        }
        public DataTable qtdeEquipes(string De, string Ate)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.qtdeEquipes(De, Ate);
        }
        public DataTable ListaAtividades(string plataforma, int idDisciplina)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.ListaAtividades(plataforma, idDisciplina);
        }
        public bool SaveTimeSheetTemplate(List<ListTimeSheetsAll> listTimeSheetsAll)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.SaveTimeSheetTemplate(listTimeSheetsAll);
        }
        public decimal RetornaIdLocal(string strNovoLocal)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.RetornaIdLocal(strNovoLocal);
        }
        public string AllHoursCraft(decimal craftId, decimal teamId, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.AllHoursCraft(craftId, teamId, date);
        }    
        public List<ListTimeSheets> PrintTimeSheets(decimal team_id, string date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.PrintTimeSheets(team_id, date);
        }
        public List<ListTimeSheets> RelacaoConvocados(decimal TeamId, string De, string Ate)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.RelacaoConvocados(TeamId, De, Ate);
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
        public bool DomainGroupsNet(string groupDomain)
        {
            Dados obj = new Dados();
            return obj.DomainGroupsNet(groupDomain);
        }
        public bool HollydayVerification(DateTime date)
        {
            TabelaDAL obj = new TabelaDAL();
            return obj.HollydayVerification(date);
        }
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
