using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridCarregamento.Modelo
{
    public class ListTimeSheetsAll
    {
        private decimal _activetyId;

        public decimal ActivetyId
        {
            get { return _activetyId; }
            set { _activetyId = value; }
        }

        private decimal _craftId;

        public decimal CraftId
        {
            get { return _craftId; }
            set { _craftId = value; }
        }
        private decimal _teamId;

        public decimal TeamId
        {
            get { return _teamId; }
            set { _teamId = value; }
        }
        private decimal _workedHours;

        public decimal WorkedHours
        {
            get { return _workedHours; }
            set { _workedHours = value; }
        }

        private decimal _workedOverTime;

        public decimal WorkedOverTime
        {
            get { return _workedOverTime; }
            set { _workedOverTime = value; }
        }

        private string _executionDate;

        public string ExecutionDate
        {
            get { return _executionDate; }
            set { _executionDate = value; }
        }

        private string _specialSituation;

        public string SpecialSituation
        {
            get { return _specialSituation; }
            set { _specialSituation = value; }
        }

        private decimal _inconsistency;

        public decimal Inconsistency
        {
            get { return _inconsistency; }
            set { _inconsistency = value; }
        }

        private string _turno;

        public string Turno
        {
            get { return _turno; }
            set { _turno = value; }
        }

        private decimal _areaId;

        public decimal AreaId
        {
            get { return _areaId; }
            set { _areaId = value; }
        }

        private decimal _grupoId;

        public decimal GrupoId
        {
            get { return _grupoId; }
            set { _grupoId = value; }
        }
        private decimal _leaderId;

        public decimal LeaderId
        {
            get { return _leaderId; }
            set { _leaderId = value; }
        }

        private decimal _supervisorId;

        public decimal SupervisorId
        {
            get { return _supervisorId; }
            set { _supervisorId = value; }
        }
        public string TeamCode { get; set; }
        public decimal RpId { get; set; }
        public decimal GereId { get; set; }
        public decimal LocalId { get; set; }
        public decimal TaskId { get; set; }
        public decimal DiefId { get; set; }
        public string SbcnSigla { get; set; }
        public string TeamTipoMo { get; set; }
    }
}
