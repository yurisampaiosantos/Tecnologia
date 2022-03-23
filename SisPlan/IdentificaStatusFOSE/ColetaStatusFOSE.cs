using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Identifica os Status das Folhas de Servico - (Tabela - AC_CONTROLE_FOLHA_SERVICO)
namespace IdentificaStatusFOSE
{
    class ColetaStatusFOSE
    {
        enum rangeCalc { All, Period }
        static string contrato = "Conversão";
        static string discId = "";
        static void Main(string[] args)
        {   
            string sbcnSigla = "";
            string fcmeSigla = "";

            //ELÉTRICA
            //Gera status das Folhas de Servico da disciplina 6 - Elétrica
            discId = "6";
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());
            GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());


            //TUBULAÇÃO
            //Gera status das Folhas de Servico da disciplina 5 - Tubulação
            discId = "5";
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());
            GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());

            string[] criterio = { "TUB_FAB", "TUB_MONT" };
            string[] fpso = { "P74", "P75", "P76", "P77" };

            ////Para as FPSOs - fpso[]
            //for (int f = 0; f < 4; f++)
            //{
            //    sbcnSigla = fpso[f];
            //    //Para os critérios - criterio[]
            //    for (int c = 0; c < 2; c++)
            //    {
            //        fcmeSigla = criterio[c];
            //        //Atualiza o Status de Fabricação  da disciplina 5 - Tubulação (AC_STATUS_FAB)
            //        GenericClasses.FolhaServico.AtualizaStatusTubulacao(contrato, discId, sbcnSigla, fcmeSigla);
            //        GenericClasses.FolhaServico.TotalizaCriterio(contrato, discId, sbcnSigla, fcmeSigla);
            //        GenericClasses.FolhaServico.EmailsURIndefinidas(contrato, discId, sbcnSigla, fcmeSigla);
            //        DTO.AcStatusFoseUpdtCntrlDTO e = new DTO.AcStatusFoseUpdtCntrlDTO();
            //        e.SfucCntrCodigo = contrato;
            //        e.SfucDiscId = Convert.ToDecimal(discId);
            //        e.SfucSbcnSigla = sbcnSigla;
            //        e.SfucFcmeSigla = fcmeSigla;
            //        //e.SfucDataCorteUpdateControl = "13/06/2014 00:00:00";
            //        // System.DateTime.Now.DayOfWeek + " - " + System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
            //        e.SfucDataCorteUpdateControl = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //        GenericClasses.FolhaServico.SaveDataCorteUpdateControl(e);
            //    }
            //}

            //PINTURA
            //Gera status das Folhas de Servico da disciplina 9 - Pintura
            discId = "9";
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());

            //OUTFITTING
            //Gera status das Folhas de Servico da disciplina 20 - Outfitting
            discId = "20";
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());

            //ESTRUTURAS METÁLICAS
            //Gera status das Folhas de Servico da disciplina 2 - Estruturas Metálicas
            discId = "2";
            GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());

            //INSTRUMENTAÇÃO
            //Gera status das Folhas de Servico da disciplina 4 - Instrumentacao
            discId = "4";
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.All.ToString());
            //GenericClasses.FolhaServico.GerarStatusFOSE(contrato, discId, rangeCalc.Period.ToString());
        }
    }
}
