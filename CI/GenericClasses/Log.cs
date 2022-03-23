using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Data;

namespace GenericClasses
{
    public class Log
    {
        //======================================================================
        public static void SaveLog(StreamWriter log, string line)
        {
            log.WriteLine(line);
            log.Flush();
        }
        ////======================================================================
        //private static void SaveDatabaseLog(string logTable, DTO.AcControleProducaoDTO ap, string message)
        //{
        //    try
        //    {
        //        DTO.AcControleProducaoLogDTO log = new DTO.AcControleProducaoLogDTO();
        //        log.FoseCntrCodigo = ap.FoseCntrCodigo;
        //        log.SemaId = ap.SemaId;
        //        log.DiscId = ap.DiscId;
        //        log.DiscNome = ap.DiscNome;
        //        log.FoseId = ap.FoseId;
        //        log.FoseNumero = ap.FoseNumero;
        //        log.Message = message;
        //        log.FcmeSigla = ap.FcmeSigla;
        //        log.FcesSigla = ap.FcesSigla;
        //        log.GrcrNome = ap.GrcrNome;
        //        log.SbcnId = ap.SbcnId;
        //        log.SbcnSigla = ap.SbcnSigla;
        //        log.OrigemFabricacao = ap.OrigemFabricacao;
        //        log.Equipe = ap.Equipe;
        //        log.Setor = ap.Setor;
        //        log.Localizacao = ap.Localizacao;
        //        log.DescricaoEstrutura = ap.DescricaoEstrutura;
        //        log.AvnRealExecPeriodo = Convert.ToDecimal(ap.AvnRealExecPeriodo);
        //        BLL.AcControleProducaoLogBLL.Insert(log, false);
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //}
        ////======================================================================
        //internal static bool ValidaControleProducao(DTO.AcControleProducaoDTO ap)
        //{
        //    try
        //    {
        //        //if (ap.FoseId == 108679) { string x = ""; }
        //        int count = 0;
        //        string strSQL = "";
        //        string message = "";
        //        bool bRet = true;
        //        string logTable = "EEP_CONVERSION.AC_CONTROLE_PRODUCAO_LOG";
        //        DataTable dtAUX = null;

        //        bool validaSubContrato = false;
        //        bool validaOrigemFabricacao = false;
        //        bool validaSetor = false;
        //        bool validaEquipe = false;
        //        bool validaDescricaoEstrutura = false;
        //        //string grupoCriterio = "";

        //        switch (Convert.ToInt32(ap.DiscId))
        //        {
        //            case 2:
        //                {
        //                    switch (ap.GrcrNome.ToUpper())
        //                    {
        //                        case "FABRICAÇÃO":
        //                            {
        //                                validaSubContrato = true;
        //                                validaOrigemFabricacao = true;
        //                                validaSetor = false;
        //                                validaEquipe = false;
        //                                validaDescricaoEstrutura = true;
        //                                break;
        //                            }
        //                        case "MONTAGEM":
        //                            {
        //                                validaSubContrato = true;
        //                                validaOrigemFabricacao = false;
        //                                validaSetor = true;
        //                                validaEquipe = true;
        //                                validaDescricaoEstrutura = true;
        //                                break;
        //                            }
        //                    }
        //                    break;
        //                }
        //            case 5:
        //                {
        //                    switch (ap.GrcrNome.ToUpper())
        //                    {
        //                        case "FABRICAÇÃO":
        //                            {
        //                                validaSubContrato = true;
        //                                validaOrigemFabricacao = false;
        //                                validaSetor = false;
        //                                validaEquipe = false;
        //                                validaDescricaoEstrutura = false;
        //                                break;
        //                            }
        //                        case "MONTAGEM":
        //                            {
        //                                validaSubContrato = true;
        //                                validaOrigemFabricacao = false;
        //                                validaSetor = true;
        //                                validaEquipe = true;
        //                                validaDescricaoEstrutura = false;
        //                                break;
        //                            }
        //                    }
        //                    break;
        //                }
        //        }
        //        //==================================================================
        //        // Valida Subcontrato
        //        if (validaSubContrato)
        //        {
        //            if (ap.SbcnSigla == null || ap.SbcnSigla == "") { bRet = false; message = "Subcontrato é um atributo obrigatório"; Log.SaveDatabaseLog(logTable, ap, message); }
        //            else { if ("P74P75P76P77".IndexOf(ap.SbcnSigla) == -1) { bRet = false; message = "Subcontrato " + ap.SbcnSigla + " inválido."; Log.SaveDatabaseLog(logTable, ap, message); } }
        //        }
        //        //==================================================================
        //        // Valida Origem Fabricação
        //        if (validaOrigemFabricacao)
        //        {
        //            if (ap.OrigemFabricacao == null || ap.OrigemFabricacao == "") { bRet = false; message = "Origem Fabricação é um atributo obrigatório."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            else
        //            {
        //                if ("EEPINTERNOINTERNAEXTERNOEXTERNA".IndexOf(ap.OrigemFabricacao.ToUpper()) == -1) { bRet = false; message = "Subcontrato " + ap.OrigemFabricacao + " inválida."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            }
        //        }
        //        //==================================================================
        //        // Valida Setor
        //        if (validaSetor)
        //        {
        //            if (ap.Setor == null || ap.Setor == "") { bRet = false; message = "Setor é um atributo obrigatório."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            else
        //            {
        //                strSQL = @"SELECT DISTINCT CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS QTD FROM EEP_CONVERSION.AC_SETOR S2 WHERE UPPER('" + ap.Setor.ToUpper() + "') IN (SELECT UPPER(S1.SETOR_NOME) FROM EEP_CONVERSION.AC_SETOR S1)";
        //                dtAUX = BLL.AcControleProducaoLogBLL.Select(strSQL);
        //                count = Convert.ToInt32(dtAUX.Rows[0]["QTD"]);
        //                if (count == 0) { bRet = false; message = "Setor " + ap.Setor + " inválido."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            }
        //        }
        //        //==================================================================
        //        // Valida Equipe
        //        if (validaEquipe)
        //        {
        //            if (ap.Equipe == null || ap.Equipe == "") { bRet = false; message = "Equipe é um atributo obrigatório."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            else { if ("123456".IndexOf(ap.Equipe) == -1) { bRet = false; message = "Equipe " + ap.Equipe + " inválida."; Log.SaveDatabaseLog(logTable, ap, message); } }
        //        }
        //        //==================================================================
        //        // Valida Descricao_Estrutura x Item_Controle
        //        if (validaDescricaoEstrutura)
        //        {
        //            if (ap.DescricaoEstrutura == null || ap.DescricaoEstrutura == "") { bRet = false; message = "Descrição Estrutura é um atributo obrigatório."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            else
        //            {
        //                strSQL = @"SELECT DISTINCT CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS QTD FROM EEP_CONVERSION.AC_ITEM_CONTROLE S2 WHERE UPPER('" + ap.DescricaoEstrutura.ToUpper() + "') IN (SELECT UPPER(S1.DESCRICAO_ESTRUTURA) FROM EEP_CONVERSION.AC_ITEM_CONTROLE S1)";
        //                dtAUX = BLL.AcControleProducaoLogBLL.Select(strSQL);
        //                count = Convert.ToInt32(dtAUX.Rows[0]["QTD"]);
        //                if (count == 0) { bRet = false; message = "Descrição Estrutura " + ap.DescricaoEstrutura + " inválida."; Log.SaveDatabaseLog(logTable, ap, message); }
        //            }
        //        }
        //        //==================================================================
        //        return bRet;
        //    }
        //    catch (Exception ex) { throw new Exception(ex.Message); }
        //    //======================================================================
        //}
        //======================================================================
    }
}
