using System;
using System.Collections.Generic;

namespace DTO
{
    //====================================================================
    public class LimitesPeriodoDTO : BaseDTO
    {
        //====================================================================
        public DateTime DataInicialSemana { get; set; }
        public DateTime DataFinalSemana { get; set; }
        public DateTime DataInicialMes { get; set; }
        public DateTime DataFinalMes { get; set; }
        public DateTime DataInicialAcumulado { get ; set ; }
        public DateTime DataFinalAcumulado { get; set; }
    }
}
