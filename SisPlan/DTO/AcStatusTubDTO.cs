using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class CollectionAcStatusTubDTO : List<AcStatusTubDTO> { }
    //====================================================================
    public class AcStatusTubDTO : BaseDTO
    {
        private double tstfId;
        private double tstfDiscId;
        private string tstfSbcnSigla;
        private string tstfFcmeSigla;
        private double? tstfSpoolsPrevPc;
        private double? tstfSpoolsPrevPeso;
        private double? tstfSpoolsSisepcPc;
        private double? tstfSpoolsSisepcPeso;
        private double? tstfSpoolsAliberarPc;
        private double? tstfSpoolsAliberarPeso;
        private double? tstfSpoolsProgramadosPc;
        private double? tstfSpoolsProgramadosPeso;
        private double? tstfSpoolsAvancadosPc;
        private double? tstfSpoolsAvancadosPeso;
        private double? tstfSpoolsAprogramarPc;
        private double? tstfSpoolsAprogramarPeso;
        private double? tstfSpoolsOficinaPc;
        private double? tstfSpoolsOficinaPeso;
        private double? tstfSpoolsAAvancarPc;
        private double? tstfSpoolsAAvancarPeso;
        private DateTime tstfCreatedDate;
        private string tstfUnidadeRegional;
        private double tstfSequence;
        private double tstfActive;

        //====================================================================
        public double TstfId { get { return tstfId; } set { tstfId = value; } }
        public double TstfDiscId { get { return tstfDiscId; } set { tstfDiscId = value; } }
        public string TstfSbcnSigla { get { return tstfSbcnSigla; } set { tstfSbcnSigla = TruncateValue(value, 30); } }
        public string TstfFcmeSigla { get { return tstfFcmeSigla; } set { tstfFcmeSigla = TruncateValue(value, 30); } }
        public double? TstfSpoolsPrevPc { get { return tstfSpoolsPrevPc; } set { tstfSpoolsPrevPc = value; } }
        public double? TstfSpoolsPrevPeso { get { return tstfSpoolsPrevPeso; } set { tstfSpoolsPrevPeso = value; } }
        public double? TstfSpoolsSisepcPc { get { return tstfSpoolsSisepcPc; } set { tstfSpoolsSisepcPc = value; } }
        public double? TstfSpoolsSisepcPeso { get { return tstfSpoolsSisepcPeso; } set { tstfSpoolsSisepcPeso = value; } }
        public double? TstfSpoolsAliberarPc { get { return tstfSpoolsAliberarPc; } set { tstfSpoolsAliberarPc = value; } }
        public double? TstfSpoolsAliberarPeso { get { return tstfSpoolsAliberarPeso; } set { tstfSpoolsAliberarPeso = value; } }
        public double? TstfSpoolsProgramadosPc { get { return tstfSpoolsProgramadosPc; } set { tstfSpoolsProgramadosPc = value; } }
        public double? TstfSpoolsProgramadosPeso { get { return tstfSpoolsProgramadosPeso; } set { tstfSpoolsProgramadosPeso = value; } }
        public double? TstfSpoolsAvancadosPc { get { return tstfSpoolsAvancadosPc; } set { tstfSpoolsAvancadosPc = value; } }
        public double? TstfSpoolsAvancadosPeso { get { return tstfSpoolsAvancadosPeso; } set { tstfSpoolsAvancadosPeso = value; } }
        public double? TstfSpoolsAprogramarPc { get { return tstfSpoolsAprogramarPc; } set { tstfSpoolsAprogramarPc = value; } }
        public double? TstfSpoolsAprogramarPeso { get { return tstfSpoolsAprogramarPeso; } set { tstfSpoolsAprogramarPeso = value; } }
        public double? TstfSpoolsOficinaPc { get { return tstfSpoolsOficinaPc; } set { tstfSpoolsOficinaPc = value; } }
        public double? TstfSpoolsOficinaPeso { get { return tstfSpoolsOficinaPeso; } set { tstfSpoolsOficinaPeso = value; } }
        public double? TstfSpoolsAAvancarPc { get { return tstfSpoolsAAvancarPc; } set { tstfSpoolsAAvancarPc = value; } }
        public double? TstfSpoolsAAvancarPeso { get { return tstfSpoolsAAvancarPeso; } set { tstfSpoolsAAvancarPeso = value; } }
        public DateTime TstfCreatedDate { get { return tstfCreatedDate; } set { tstfCreatedDate = value; } }
        public string TstfUnidadeRegional { get { return tstfUnidadeRegional; } set { tstfUnidadeRegional = TruncateValue(value, 100); } }
        public double TstfSequence { get { return tstfSequence; } set { tstfSequence = value; } }
        public double TstfActive { get { return tstfActive; } set { tstfActive = value; } }
    }
}

