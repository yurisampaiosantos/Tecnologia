using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace GenericClasses
{
    static public class Material
    {
        static DataTable dtMateriais = null;
        static DataTable dtRMs = null;
 
        static decimal counter, ca, cn, ce = 0;
        static DTO.CollectionAcStatusMateriaisDTO cAM = new DTO.CollectionAcStatusMateriaisDTO();
        static string strSQL = "";
        static string discAUX = "2,3,5,6,9,15,20"; //"2,3,5,6,9,15,20";

        //==================================================================
        public static void AplicaMaterial(string contrato)
        {
            string codigoMaterial, dimensoes = "";
            decimal diprId = 0;
            PreparaSaidaStatusMateriais();

            //Obtém todo o dicionário de materiais do contrato
            dtMateriais = GetDicionarioMateriais(contrato); 

            //Obtém as RMs  e suas quantidades
            strSQL = @"SELECT DISTINCT DIPR_CNTR_CODIGO, DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DCMN_ID, DCMN_NUMERO, REPI_QTD_TOTAL, REPR_NUMERO, REPL_REV FROM EEP_CONVERSION.V_RP_ITEM";
            dtRMs = BLL.AcStatusMateriaisBLL.Select(strSQL);
            //WHERE DIPR_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND DIPR_DIMENSOES = '16pol'

            //Obtém para cada FPSO a Qtd Necessária do material  - DADOS DOS MATERIAIS DO CONTRATO
            strSQL = @"SELECT DISTINCT
                              FSIT_CNTR_CODIGO, FOSE_SBCN_ID, SBCN_SIGLA, DISC_ID, FSIT_DIPR_ID, CODIGO, DIMENSOES, PESO, DESCRICAO, UNME_SIGLA,
                              SUM(FSIT_QTD_REAL) AS FSIT_QTD_REAL, SUM(FSIT_QTD_RESERVADA_CALC) AS FSIT_QTD_RESERVADA_CALC, SUM(FSIT_QTD_APLICADA_CALC) AS FSIT_QTD_APLICADA_CALC
                         FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM, EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.SUB_CONTRATO
                        WHERE FOSE_CNTR_CODIGO = FSIT_CNTR_CODIGO AND FOSE_ID = FSIT_FOSE_ID
                          AND FOSE_CNTR_CODIGO = SBCN_CNTR_CODIGO AND FOSE_SBCN_ID = SBCN_ID
                        GROUP BY FSIT_CNTR_CODIGO, FOSE_SBCN_ID, SBCN_SIGLA, DISC_ID, FSIT_DIPR_ID, CODIGO, DIMENSOES, PESO, DESCRICAO, UNME_SIGLA";
            DataTable dtQtdNecMatSubContrato = BLL.AcStatusMateriaisBLL.Select(strSQL);
            //WHERE FSIT_CNTR_CODIGO = 'Conversão' AND CODIGO = '5.01.01.001.52.20.04' AND DIMENSOES = '16pol'

            //Obtém AFs DO MATERIAL E RM
            strSQL = @"SELECT DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DIPR_PESO, DCMN_ID, DCMN_NUMERO, REPL_REV, AUFO_NUMERO, AUFO_DT_EMISSAO, AUFO_EMPR_NOME,
                              AFIT_QTD_TOTAL, AUFO_DT_CADASTRO, AUFO_STATUS, AUFO_EMPR_ID, AFIT_DT_CADASTRO, REPI_QTD_TOTAL, AFIC_CONTRATUAL
                         FROM EEP_CONVERSION.V_AF_ITEM";
            DataTable dtAFsMaterialRm = BLL.AcStatusMateriaisBLL.Select(strSQL);
            //WHERE DCMN_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND DCMN_ID = 275;

            //Obtém NFs com AF
            strSQL = @"SELECT DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DCMN_ID, DCMN_NUMERO, AUFO_NUMERO, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD FROM EEP_CONVERSION.V_NF_ITEM";
            DataTable dtNFsMaterialRm = BLL.AcStatusMateriaisBLL.Select(strSQL);
            //WHERE DCMN_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND DCMN_ID = 275;



            //NEMs COM NFS e AREA ESTOCAGEM
            strSQL = @"SELECT DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DCMN_ID, DCMN_NUMERO, AUFO_NUMERO, NOFI_NUMERO, NOEN_NUMERO, NOEI_QTD_NEM, DVRE_NUMERO , ARES_SIGLA FROM EEP_CONVERSION.V_NE_ITEM";
            DataTable dtNEMsMaterialRm = BLL.AcStatusMateriaisBLL.Select(strSQL);
            //WHERE DCMN_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND DCMN_ID = 275


            
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //NAO APAGAR

            ////Obtém as Áreas de Estocagem
            //strSQL = @"SELECT DIPR_CNTR_CODIGO, SBCN_SIGLA, DIPR_CODIGO, DIPR_ID, DIPR_DIMENSOES, QTD_AREA_ESTOCAGEM FROM EEP_CONVERSION.VW_AC_AREA_ESTOCAGEM";
            //DataTable dtAreaEstocagem = BLL.AcStatusMateriaisBLL.Select(strSQL);
            ////WHERE DIPR_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND SBCN_SIGLA = 'P76'
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            //===========================================================================================================================
            //Para cada material / equipamento ou diversos
            for (int i = 0; i < dtMateriais.Rows.Count; i++)
            {
                try
                {
                    diprId = Convert.ToDecimal(dtMateriais.Rows[i]["DIPR_ID"]);
                    codigoMaterial = Convert.ToString(dtMateriais.Rows[i]["DIPR_CODIGO"]);
                    dimensoes = Convert.ToString(dtMateriais.Rows[i]["DIPR_DIMENSOES"]);
                
                    cAM = BLL.AcStatusMateriaisBLL.GetCollection("DIPR_CNTR_CODIGO = '" + contrato + @"' AND DIPR_ID = " + diprId.ToString());
                
                    DTO.AcStatusMateriaisDTO am = new DTO.AcStatusMateriaisDTO();
                    if (cAM.Count > 0) am.ID = cAM[0].ID;
                    am.DiprCntrCodigo = Convert.ToString(dtMateriais.Rows[i]["DIPR_CNTR_CODIGO"]);
                    am.DiprId = Convert.ToDecimal(dtMateriais.Rows[i]["DIPR_ID"]);
                    am.DiprCodigo = Convert.ToString(dtMateriais.Rows[i]["DIPR_CODIGO"]);
                    am.DiprDimensoes = Convert.ToString(dtMateriais.Rows[i]["DIPR_DIMENSOES"]);
                    am.DiprPeso = Convert.ToDecimal(dtMateriais.Rows[i]["DIPR_PESO"]);
                    am.DipiDescricaoRes = Convert.ToString(dtMateriais.Rows[i]["DIPI_DESCRICAO_RES"]);
                    am.DiscId = Convert.ToDecimal(dtMateriais.Rows[i]["DISC_ID"]);
                    am.DiscNome = Convert.ToString(dtMateriais.Rows[i]["DISC_NOME"]);
                    am.UnmeSigla = Convert.ToString(dtMateriais.Rows[i]["UNME_SIGLA"]);
                    am.DescTipoDicionario = Convert.ToString(dtMateriais.Rows[i]["DESC_TIPO_DICIONARIO"]);
                
                    //Obtém as RMs do contrato para o material ordenadas por CÓDIGO DA RM
                    //WHERE DIPR_CNTR_CODIGO = 'Conversão' AND DIPR_CODIGO = '5.01.01.001.52.20.04' AND DIPR_DIMENSOES = '16pol' OU DIPR_ID
                    DataRow[] rowRMs = dtRMs.Select("DIPR_CNTR_CODIGO = '" + contrato + @"' AND DIPR_ID = " + am.DiprId.ToString(), "DCMN_NUMERO");
                    counter = rowRMs.Count();

                    //Caso não tenha cobertura de RM
                    if (counter == 0)
                    {
                        am.DcmnNumero = "NÃO ESPECIFICADO EM RM";
                        am.ReplRev = null;
                        SaveAplicabilidade(am);
                    }
                    else
                    {
                        //Para cada RM
                        for (int r = 0; r < counter; r++)
                        {
                        
                            try
                            {
                                am.DcmnId = Convert.ToDecimal(rowRMs[r]["DCMN_ID"]);
                                am.DcmnNumero = Convert.ToString(rowRMs[r]["DCMN_NUMERO"]);
                                am.ReplRev = Convert.ToString(rowRMs[r]["REPL_REV"]);
                                am.RepiQtdTotal = Convert.ToDecimal(rowRMs[r]["REPI_QTD_TOTAL"]);

                                //=================================================================================================================================================
                                //Obtém FPSO pela RM
                                am.SbcnSigla = GetSubcontratoByRM(contrato, am.DcmnNumero);
                        
                                //=================================================================================================================================================
                                //Obtém Qtd Necessária do material para a FPSO
                                //FSIT_CNTR_CODIGO, FOSE_SBCN_ID, SBCN_SIGLA, DISC_ID, FSIT_DIPR_ID, CODIGO, DIMENSOES, PESO, DESCRICAO, UNME_SIGLA,
                                //SUM(FSIT_QTD_REAL) AS FSIT_QTD_REAL, SUM(FSIT_QTD_RESERVADA_CALC) AS FSIT_QTD_RESERVADA_CALC, SUM(FSIT_QTD_APLICADA_CALC) AS FSIT_QTD_APLICADA_CALC
                                DataRow[] rowQtdNecMatSubContrato = dtQtdNecMatSubContrato.Select("SBCN_SIGLA = '" + am.SbcnSigla + @"' AND FSIT_DIPR_ID = " + am.DiprId.ToString(), null);
                        
                                //Qtd Necessária na FPSO
                                //=================================================================================================================================================
                                if (rowQtdNecMatSubContrato.Count() > 0)
                                {
                                    am.FsitQtdReal = Convert.ToDecimal(rowQtdNecMatSubContrato[0]["FSIT_QTD_REAL"]);
                                }

                                //=================================================================================================================================================
                                //Obtém os códigos das AFs desse material para essa RM
                                //DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DIPR_PESO, DCMN_ID, DCMN_NUMERO, REPL_REV, AUFO_NUMERO, AUFO_DT_EMISSAO, AUFO_EMPR_NOME,
                                //AFIT_QTD_TOTAL, AUFO_DT_CADASTRO, AUFO_STATUS, AUFO_EMPR_ID, AFIT_DT_CADASTRO, REPI_QTD_TOTAL, AFIC_CONTRATUAL
                                DataRow[] rowAFsMaterialRm = dtAFsMaterialRm.Select("DIPR_ID = " + am.DiprId.ToString() + @" AND DCMN_ID = " + am.DcmnId.ToString(), "AUFO_NUMERO");
                                ca = rowAFsMaterialRm.Count();
                                //Códigos das AFs
                                if (ca > 0)
                                {
                                    am.AufoNumero = null;
                                    am.AufoDtEmissao = null;
                                    am.AufoEmprNome = null;
                                    am.AfitQtd = null;
                                    for (int a = 0; a < ca; a++)
                                    {
                                        try
                                        {
                                            am.AufoNumero = Convert.ToString(rowAFsMaterialRm[a]["AUFO_NUMERO"]).Replace("'", "");
                                            am.AufoDtEmissao = Convert.ToDateTime(rowAFsMaterialRm[a]["AUFO_DT_EMISSAO"]);
                                            am.AufoEmprNome = Convert.ToString(rowAFsMaterialRm[a]["AUFO_EMPR_NOME"]);
                                            am.AfitQtd = Convert.ToDecimal(rowAFsMaterialRm[a]["AFIT_QTD_TOTAL"]);
                                            if (am.AufoNumero != null)
                                            {
                                                //=================================================================================================================================================
                                                //Obtém os códigos das NFs desse material para essa RM para cada AF
                                                //DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DCMN_ID, DCMN_NUMERO, AUFO_NUMERO, NOFI_NUMERO, NOFI_DT_RECEBIMENTO, NFIT_QTD
                                                DataRow[] rowNFsMaterialRm = dtNFsMaterialRm.Select("DIPR_ID = " + am.DiprId.ToString() + @" AND DCMN_ID = " + am.DcmnId.ToString() + @" AND AUFO_NUMERO = '" + am.AufoNumero + "'", "NOFI_NUMERO");
                                                cn = rowNFsMaterialRm.Count();
                                                //Códigos das NFs
                                                if (cn > 0)
                                                {
                                                    am.NofiNumero = null;
                                                    am.NofiDtRecebimento = null;
                                                    am.NfitQtd = null;
                                                    am.SldCompra = null;
                                                    for (int n = 0; n < cn; n++)
                                                    {
                                                        try
                                                        {
                                                            am.NofiNumero = Convert.ToString(rowNFsMaterialRm[n]["NOFI_NUMERO"]).Replace("'","");
                                                            if (rowNFsMaterialRm[n]["NOFI_DT_RECEBIMENTO"] != DBNull.Value) am.NofiDtRecebimento = Convert.ToDateTime(rowNFsMaterialRm[n]["NOFI_DT_RECEBIMENTO"]);
                                                            am.NfitQtd = Convert.ToDecimal(rowNFsMaterialRm[n]["NFIT_QTD"]);
                                                            //Calcula Saldo de Compra 
                                                            am.SldCompra = am.RepiQtdTotal - am.AfitQtd;

                                                            if (am.NofiNumero != null)
                                                            {
                                                                //=================================================================================================================================================
                                                                //Obtém os códigos das NEMs COM NFS e AREA ESTOCAGEM para cada AF para cada NF
                                                                //DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DCMN_ID, DCMN_NUMERO, AUFO_NUMERO, NOFI_NUMERO, NOEN_NUMERO, NOEI_QTD_NEM, DVRE_NUMERO , ARES_SIGLA
                                                                DataRow[] rowNEMsMaterialRm = dtNEMsMaterialRm.Select("DIPR_ID = " + am.DiprId.ToString() + @" AND DCMN_ID = " + am.DcmnId.ToString() + @" AND AUFO_NUMERO = '" + am.AufoNumero + "' AND NOFI_NUMERO = '" + am.NofiNumero + "'", "NOEN_NUMERO");
                                                                ce = rowNEMsMaterialRm.Count();
                                                                //Códigos das NEMs
                                                                if (ce > 0)
                                                                {
                                                                    am.NoenNumero = null;
                                                                    am.NoeiQtdNem = null;
                                                                    am.DvreNumero = null;
                                                                    am.AresSigla = null;
                                                                    am.SldEntrega = null;
                                                                    am.SldNecessidade = null;
                                                                    for (int e = 0; e < ce; e++)
                                                                    {
                                                                        try
                                                                        {
                                                                            am.NoenNumero = Convert.ToString(rowNEMsMaterialRm[e]["NOEN_NUMERO"]).Replace("'", "");
                                                                            am.NoeiQtdNem = Convert.ToDecimal(rowNEMsMaterialRm[e]["NOEI_QTD_NEM"]);
                                                                            am.DvreNumero = Convert.ToString(rowNEMsMaterialRm[e]["DVRE_NUMERO"]);
                                                                            am.AresSigla = Convert.ToString(rowNEMsMaterialRm[e]["ARES_SIGLA"]);
                                                                            //=================================================================================================================================================
                                                                            //Calcula Saldo de Entrega
                                                                            am.SldEntrega = am.AfitQtd - am.NfitQtd;
                                                                            //Calcula Saldo de Necessidade
                                                                            am.SldNecessidade = am.FsitQtdReal - am.RepiQtdTotal; //(SISEPC - RM)

                                                                            //Grava Registro (Nível NE)
                                                                            SaveAplicabilidade(am);
                                                                        }
                                                                        catch (Exception ex) { throw new Exception("GerarControleProducaoBase: Obtendo código das NEMs - " + ex.Message); }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    //Grava Registro (SEM NEM - NÃO LIBERADO)
                                                                    am.NoenNumero = "NÃO LIBERADO";
                                                                    am.NoeiQtdNem = null;
                                                                    am.DvreNumero = null;
                                                                    am.AresSigla = null;
                                                                    am.SldEntrega = null;
                                                                    am.SldNecessidade = null;
                                                                    SaveAplicabilidade(am);
                                                                }
                                                            }
                                                        }
                                                        catch (Exception ex) { throw new Exception("GerarControleProducaoBase: Obtendo código das NFs - " + ex.Message); }
                                                    }
                                                }
                                                else
                                                {
                                                    //Grava Registro (SEM NOTAS - NÃO ENTREGUE)
                                                    am.NofiNumero = "NÃO ENTREGUE";
                                                    am.NofiDtRecebimento = null;
                                                    am.NfitQtd = null;
                                                    am.SldCompra = null;
                                                    am.NoenNumero = null;
                                                    am.NoeiQtdNem = null;
                                                    am.DvreNumero = null;
                                                    am.AresSigla = null;
                                                    am.SldEntrega = null;
                                                    am.SldNecessidade = null;
                                                    SaveAplicabilidade(am);
                                                }
                                            }
                                        }
                                        catch (Exception ex) { throw new Exception("GerarControleProducaoBase: Obtendo códigos da NEMs - " + ex.Message); }
                                    }
                                }
                                else
                                {
                                    //Grava Registro (SEM AFs - NÃO COMPRADO)
                                    am.AufoNumero = "NÃO COMPRADO";
                                    am.AufoDtEmissao = null;
                                    am.AufoEmprNome = null;
                                    am.AfitQtd = null;
                                    am.NofiNumero = null;
                                    am.NofiDtRecebimento = null;
                                    am.NfitQtd = null;
                                    am.SldCompra = null;
                                    am.NoenNumero = null;
                                    am.NoeiQtdNem = null;
                                    am.DvreNumero = null;
                                    am.AresSigla = null;
                                    am.SldEntrega = null;
                                    am.SldNecessidade = null;
                                    SaveAplicabilidade(am);
                                }
                        
                        
                        
                                ////////=================================================================================================================================================
                                ////////dtAreaEstocagem, rowAreaEstocagem

                                ////////Incorpora Area Estocagem
                                ////////rowAreaEstocagem

                                //////DataRow[] rowAreaEstocagem = dtAreaEstocagem.Select("DIPR_CNTR_CODIGO = '" + contrato + "' AND DIPR_ID = " + am.DiprId.ToString(), "QTD_AREA_ESTOCAGEM");
                                //////string ARES = "";
                                //////ci = rowAreaEstocagem.Count();
                                //////try
                                //////{
                                //////    for (int a = 0; a < ci; a++)
                                //////    {
                                //////        if (ARES.IndexOf(rowAreaEstocagem[a]["QTD_AREA_ESTOCAGEM"].ToString()) == -1) ARES += " ; " + rowAreaEstocagem[a]["QTD_AREA_ESTOCAGEM"].ToString();
                                //////    }

                                //////    if (ARES != "") ARES = ARES.Substring(3);
                                //////    am.AreasEstocagem = ARES;
                                //////}
                                //////catch (Exception ex) { throw new Exception(ex.Message); }

                        }
                        catch (Exception ex) { throw new Exception("GerarControleProducaoBase: Obtendo códigos da RMs - " + ex.Message); }
                        }
                    }
                 }
                 catch (Exception ex) { throw new Exception("GerarControleProducaoBase: " + ex.Message); }
            }
        }
        //==================================================================
        private static void SaveAplicabilidade(DTO.AcStatusMateriaisDTO am)
        {
            if (am.ID == 0) am.ID = BLL.AcStatusMateriaisBLL.Insert(am, true);
            else BLL.AcStatusMateriaisBLL.Update(am);
        }
        //==================================================================
        private static string GetSubcontratoByRM(string contrato, string dcmnNumero)
        {
            DataTable dt = null; ;
            string sRet = "P74";
            if (dcmnNumero.IndexOf("0F") >= 0) sRet = "P74";
            else if (dcmnNumero.IndexOf("0G") >= 0) sRet = "P75";
            else if (dcmnNumero.IndexOf("0H") >= 0) sRet = "P76";
            else if (dcmnNumero.IndexOf("0J") >= 0) sRet = "P77";
            else
            {
                strSQL = @"SELECT SC.SBCN_ID, SBCN_SIGLA FROM EEP_CONVERSION.DOCUMENTO D, EEP_CONVERSION.SUB_CONTRATO SC WHERE D.DCMN_CNTR_CODIGO = '" + contrato + @"' AND D.DCMN_NUMERO = '" + dcmnNumero + "' AND SC.SBCN_CNTR_CODIGO = D.DCMN_CNTR_CODIGO AND SC.SBCN_ID = D.DCMN_SBCN_ID";
                dt = BLL.AcStatusMateriaisBLL.Select(strSQL);
                if (dt.Rows.Count > 0) sRet = dt.Rows[0]["SBCN_SIGLA"].ToString();
            }
            return sRet;
        }
        //==================================================================
        private static DataTable GetDicionarioMateriais(string contrato)
        {
            DataTable dt = null;
            //Acessa Dicionário de Materiais - MATERIAIS DO CONTRATO E DA DISCIPLINA (5)
            strSQL = @"SELECT
                                DIPR_CNTR_CODIGO, DIPR_ID, DIPR_CODIGO, DIPR_DIMENSOES, DIPR_PESO, DIPI_DESCRICAO_RES, DISC_ID, DISC_NOME, UNME_SIGLA,
                                DIPQ_QTD_RM, DIPQ_QTD_CP, DIPQ_QTD_AF, DIPQ_QTD_NF, DIPQ_QTD_NE, DIPQ_QTD_FS, DIPQ_QTD_RE, DIPQ_QTD_AP, DIPR_TIPO_DICIONARIO, 
                                CASE 
                                  WHEN DIPR_TIPO_DICIONARIO = 1 THEN 'EQUIPAMENTOS'
                                  WHEN DIPR_TIPO_DICIONARIO = 2 THEN 'MATERIAIS'
                                  WHEN DIPR_TIPO_DICIONARIO = 3 THEN 'DIVERSOS'
                                END DESC_TIPO_DICIONARIO
                           FROM 
                                EEP_CONVERSION.V_DICIONARIO_PRODUTO
                          WHERE 
                                DIPR_CNTR_CODIGO = 'Conversão'
                            --AND DIPR_CODIGO NOT LIKE '2.%'
                            --AND DIPR_CODIGO NOT LIKE '5.09.%'
                            AND DISC_ID IN (" + discAUX + @") --AND DIPR_CODIGO = '5.01.01.001.52.20.04'
                          ORDER BY DISC_ID DESC, DIPR_CODIGO, DIPR_DIMENSOES ";
            dt = BLL.AcStatusMateriaisBLL.Select(strSQL);
            return dt;
        }
        //==================================================================
        private static void PreparaSaidaStatusMateriais()
        {
//            strSQL = @"DELETE FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL APL
//                        WHERE APL.ID IN 
//                              (
//                                SELECT AM.ID FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL AM
//                                 WHERE AM.DIPR_CODIGO || AM.DIPR_DIMENSOES NOT IN (SELECT DP.DIPR_CODIGO || DP.DIPR_DIMENSOES FROM EEP_CONVERSION.V_DICIONARIO_PRODUTO DP WHERE DIPR_CNTR_CODIGO = 'Conversão')
//                              )";
            strSQL = @"DELETE FROM EEP_CONVERSION.AC_APLICABILIDADE_MATERIAL";
            BLL.AcStatusMateriaisBLL.ExecuteSQLInstruction(strSQL);
            BLL.AcStatusMateriaisBLL.ExecuteSQLInstruction("COMMIT");
        }
    }
}
/*  Areas de estocagem do material
               select d.DIPR_CNTR_CODIGO ,D.DIPR_ID ,d.dipr_codigo ,a.ares_sigla ,ad.diae_qtd ,d.unme_sigla ,d.dipr_dimensoes ,d.dipi_descricao_res 
  from dicionario_area_estocagem ad ,v_dicionario_produto d ,area_estocagem a
where dipr_codigo = '5.24.11.009.12.06.00'
  and ad.diae_cntr_codigo = d.DIPR_CNTR_CODIGO  and ad.diae_dipr_id = d.DIPR_ID
  and ad.diae_cntr_codigo = a.ares_cntr_codigo  and ad.diae_ares_id = a.ares_id;
             */