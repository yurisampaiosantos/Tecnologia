using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace GenericClasses
{
    public class PreparaSaidasRelatorios
    {
        static DataTable dtRmSemAF = null;
        static DataTable dtRmComAFSemNF = null;
        static DataTable dtRmComAFComNFNaoLib = null;
        static DataTable dtFoseNumero = null;
        static DataTable dtQtdNecessariaMaterial = null;
        static DataTable dtFornecedor = null;
        static DataTable dtNF = null;
        static DataTable dtNE = null;
        static DataTable dtPrazo = null;
        //static DataRow[] rowsPrazo = null;
        
        static string strSQL = "";

        static decimal idAC_PENDENCIA_MATERIAL = 0;
        //static decimal idAC_PENDENCIA_FOLHA_SERVICO = 0;

        static string RM = "";
        static string titulo = "";
        static decimal aufoEmprId = 0;
        static decimal afitId = 0;

        //===================================================================================
        public static void SaidaPendenciaMateriais(string contrato)
        {
            //Carrega na memória as quantidades necessarias por Material do contrato
            strSQL = @"SELECT CODIGO, SUM(FSIT_QTD_REAL) AS FSIT_QTD_REAL
                                FROM ( SELECT CODIGO, FOSE_ID, FOSE_NUMERO, FSIT_QTD_REAL FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM , EEP_CONVERSION.FOLHA_SERVICO
                                       WHERE FSIT_CNTR_CODIGO = '" + contrato + @"' AND FOSE_CNTR_CODIGO = FSIT_CNTR_CODIGO AND FOSE_ID = FSIT_FOSE_ID )
                        GROUP BY CODIGO
                        ORDER BY CODIGO";
            dtQtdNecessariaMaterial = BLL.AcPendenciaMaterialBLL.Select(strSQL);

            //Carrega na memória todos os Fornecedores com movimento de AFs do contrato
            strSQL = @"SELECT DISTINCT V.AUFO_EMPR_ID, E.EMPR_NOME FROM EEP_CONVERSION.V_AF_ITEM V, EEP_CONVERSION.EMPRESA E
                        WHERE V.AUFO_CNTR_CODIGO = '" + contrato + @"' AND E.EMPR_CNTR_CODIGO = V.AUFO_CNTR_CODIGO AND E.EMPR_ID = V.AUFO_EMPR_ID
                        ORDER BY E.EMPR_NOME";
            dtFornecedor = BLL.AcPendenciaMaterialBLL.Select(strSQL);

            //Carrega na memória todos OS ITENS das Notas Fiscais do contrato QUE POSSUEM AF
            strSQL = @"SELECT DISTINCT NFIT_ID, AFIT_ID, NFIT_QTD, NOFI_NUMERO, NOFI_DT_RECEBIMENTO FROM EEP_CONVERSION.V_NF_ITEM WHERE NFIT_CNTR_CODIGO = '" + contrato + "' AND AUFO_NUMERO IS NOT NULL";
            dtNF = BLL.AcPendenciaMaterialBLL.Select(strSQL);

            //Carrega na memória todas as Notas de Entrada
            strSQL = @"SELECT DISTINCT NFIT_ID, NOEN_NUMERO, NOEN_DT_EMISSAO, NOEN_OBS, NOEI_NFIT_ID, NOEI_ITEM, NOEI_QTD_NEM FROM EEP_CONVERSION.V_NE_ITEM WHERE NFIT_ID > 0 AND NFIT_CNTR_CODIGO = '" + contrato + "'";
            dtNE = BLL.AcPendenciaMaterialBLL.Select(strSQL);

            //Carrega na memória todos os prazos de AFs
            strSQL = @"SELECT AFIT_ID, AFIP_PRAZO FROM EEP_CONVERSION.AF_ITEM, EEP_CONVERSION.AF_ITEM_PRAZO
                        WHERE AFIT_CNTR_CODIGO = '" + contrato + @"' AND AFIP_CNTR_CODIGO = AFIT_CNTR_CODIGO AND AFIP_AFIT_ID = AFIT_ID ORDER BY AFIT_ID";
            dtPrazo = BLL.AcPendenciaMaterialBLL.Select(strSQL);

            //Carrega na memória todas as Folhas de Servico associadas aos materiais
            strSQL = @"SELECT FOSE_ID, FOSE_NUMERO, FSIT_QTD_REAL, CODIGO, FOSE_SBCN_ID, SBCN_SIGLA, FOSE_DISC_ID, D.DISC_NOME
                         FROM EEP_CONVERSION.V_FOLHA_SERVICO_ITEM , EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.SUB_CONTRATO, EEP_CONVERSION.DISCIPLINA D
                        WHERE FSIT_CNTR_CODIGO = '" + contrato + @"' 
                          AND FOSE_CNTR_CODIGO = FSIT_CNTR_CODIGO AND FOSE_ID = FSIT_FOSE_ID
                          AND SBCN_CNTR_CODIGO = FOSE_CNTR_CODIGO AND SBCN_ID = FOSE_SBCN_ID
                          AND D.DISC_CNTR_CODIGO = FOSE_CNTR_CODIGO AND D.DISC_ID = FOSE_DISC_ID
                        ORDER BY FOSE_NUMERO";
            dtFoseNumero = BLL.AcPendenciaFolhaServicoBLL.Select(strSQL);

            //Inicializa tabela de pendencias
            strSQL = "DELETE FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL";
            BLL.AcPendenciaMaterialBLL.ExecuteSQLInstruction(strSQL);

            ////Inicializa tabela de pendencias
            //strSQL = "DELETE FROM EEP_CONVERSION.AC_PENDENCIA_FOLHA_SERVICO";
            //BLL.AcPendenciaFolhaServicoBLL.ExecuteSQLInstruction(strSQL);

            //RMs Com AF (COMPRADAS) E ITENS (NAO) ENTREGUES (Sem NF)
            //NE
            strSQL = @"SELECT SBCN_SIGLA, DISC_NOME, REPR_NUMERO, DCMN_TITULO, 
                              AUFO_ID, AUFO_NUMERO, AUFO_EMPR_ID, AUFO_DT_EMISSAO, 
                              AFIT_ID, AFIT_ITEM, AFIT_QTD_TOTAL, 
                              AFIC_CONTRATUAL, AFIR_VALOR_UNITARIO,                              
                              DIPC_CODIGO , DIPI_DESCRICAO_RES, DIPR_PESO, DIPR_DIMENSOES, DIPR_DIM1, DIPR_DIM2, DIPR_DIM3,
                              UNME_SIGLA, REPI_ITEM, REPI_QTD_TOTAL
                         FROM EEP_CONVERSION.V_AF_ITEM 
                        WHERE AFIT_CNTR_CODIGO = '" + contrato + @"' 
                          AND AFIT_ID NOT IN (
                                               SELECT N.AFIT_ID FROM EEP_CONVERSION.V_NF_ITEM N 
                                                WHERE N.NFIT_CNTR_CODIGO = '" + contrato + @"' 
                                                  AND N.AUFO_NUMERO IS NOT NULL
                                             )  
                          AND REPR_NUMERO NOT LIKE '%.'
                        ORDER   BY AUFO_NUMERO";
            dtRmComAFSemNF = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            GetRMComAFSemNF(contrato); // Compradas não entregues


            //RMs Com AF (COMPRADAS) E ITENS ENTREGUES  (Com NF)
            //NL e LB
            strSQL = @"SELECT 
                                SBCN_SIGLA, DISC_NOME, REPR_NUMERO, DCMN_TITULO, 
                                AUFO_ID, AUFO_NUMERO, AUFO_EMPR_ID, AUFO_DT_EMISSAO, 
                                AFIT_ID, AFIR_VALOR_UNITARIO, AFIT_ITEM, AFIT_QTD_TOTAL, 
                                DIPC_CODIGO , DIPI_DESCRICAO_RES, DIPR_PESO, DIPR_DIMENSOES, DIPR_DIM1, DIPR_DIM2, DIPR_DIM3,
                                AFIC_CONTRATUAL, 
                                UNME_SIGLA, REPI_ITEM, REPI_QTD_TOTAL,
                                NFIT_ID, NFIT_QTD, NOFI_NUMERO, NOFI_DT_RECEBIMENTO
                         FROM   EEP_CONVERSION.V_NF_ITEM N WHERE N.NFIT_CNTR_CODIGO = '" + contrato + @"' AND AFIT_ID IS NOT NULL AND REPR_NUMERO NOT LIKE '%.'
                        ORDER   BY AUFO_NUMERO";
            dtRmComAFComNFNaoLib = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            GetRMComAFComNFNaoLib(contrato); // Entregues Liberadas e não liberadas


            //RMs Sem AF (NÃO) COMPRADAS 
            //NC
//            strSQL = @"SELECT DISTINCT RP.* FROM EEP_CONVERSION.V_RP_ITEM RP, EEP_CONVERSION.V_AF_ITEM AF 
//                        WHERE RP.DCMN_CNTR_CODIGO = '" + contrato + @"' 
//                          AND RP.DCMN_NUMERO = AF.DCMN_NUMERO(+) AND RP.DIPC_CODIGO = AF.DIPC_CODIGO(+) 
//                          AND RP.DIPC_CODIGO IS NOT NULL
//                          AND RP.DCMN_NUMERO NOT LIKE '%.'
//                          AND RP.DCMN_NUMERO NOT IN (SELECT DISTINCT PD.DCMN_NUMERO FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL PD)";
            strSQL = @"SELECT DISTINCT RP.REPI_CNTR_CODIGO, RP.REPI_ITEM, RP.DCMN_NUMERO, RP.DCMN_TITULO, RP.SBCN_SIGLA, RP.DISC_NOME, RP.DIPR_PESO, RP.DIPC_CODIGO, RP.DIPI_DESCRICAO_RES, RP.UNME_SIGLA
                         FROM EEP_CONVERSION.V_RP_ITEM RP, EEP_CONVERSION.V_AF_ITEM AF 
                        WHERE RP.DCMN_CNTR_CODIGO = 'Conversão' 
                          AND RP.DCMN_NUMERO = AF.DCMN_NUMERO(+) AND RP.DIPC_CODIGO = AF.DIPC_CODIGO(+) 
                          AND RP.DIPC_CODIGO IS NOT NULL
                          AND RP.DCMN_NUMERO NOT LIKE '%.'
                          AND RP.DCMN_NUMERO NOT IN (SELECT DISTINCT PD.DCMN_NUMERO FROM EEP_CONVERSION.AC_PENDENCIA_MATERIAL PD)";
            dtRmSemAF = BLL.AcPendenciaMaterialBLL.Select(strSQL);
            GetRmSemAF(contrato); //Não compradas
        }
        
        //===================================================================================
        //NE
        internal static void GetRMComAFSemNF(string contrato)           //RMs Com AF -  (COMPRADAS) E ITENS (NAO ENTREGUES) - (Sem NF)
        {
            try
            {
                for (int i = 0; i < dtRmComAFSemNF.Rows.Count; i++)
                {

                    //if (i == 410)
                    //{
                    //    string x = "";
                    //}
                    RM = dtRmComAFSemNF.Rows[i]["REPR_NUMERO"].ToString();
                    titulo = dtRmComAFSemNF.Rows[i]["DCMN_TITULO"].ToString();
                    if ((dtRmComAFSemNF.Rows[i]["AUFO_EMPR_ID"] != null) && (dtRmComAFSemNF.Rows[i]["AUFO_EMPR_ID"] != DBNull.Value)) aufoEmprId = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["AUFO_EMPR_ID"]);
                    afitId = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["AFIT_ID"]);
                    
                    DTO.AcPendenciaMaterialDTO iAF = new DTO.AcPendenciaMaterialDTO();
                    //idAC_PENDENCIA_MATERIAL += 1;
                    //iAF.ID = idAC_PENDENCIA_MATERIAL;
                    iAF.DcmnNumero = RM;
                    iAF.DcmnTitulo = titulo;

                    iAF.DipcCodigo = dtRmComAFSemNF.Rows[i]["DIPC_CODIGO"].ToString();
                    iAF.DipiDescricaoRes = dtRmComAFSemNF.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    iAF.DiprPeso = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["DIPR_PESO"]);
                    if ((dtRmComAFSemNF.Rows[i]["DIPR_DIMENSOES"] != null) && (dtRmComAFSemNF.Rows[i]["DIPR_DIMENSOES"] != DBNull.Value)) iAF.DiprDimensoes = Convert.ToString(dtRmComAFSemNF.Rows[i]["DIPR_DIMENSOES"]);
                    if ((dtRmComAFSemNF.Rows[i]["DIPR_DIM1"] != null) && (dtRmComAFSemNF.Rows[i]["DIPR_DIM1"] != DBNull.Value)) iAF.DiprDim1 = Convert.ToString(dtRmComAFSemNF.Rows[i]["DIPR_DIM1"]);
                    if ((dtRmComAFSemNF.Rows[i]["DIPR_DIM2"] != null) && (dtRmComAFSemNF.Rows[i]["DIPR_DIM2"] != DBNull.Value)) iAF.DiprDim2 = Convert.ToString(dtRmComAFSemNF.Rows[i]["DIPR_DIM2"]);
                    if ((dtRmComAFSemNF.Rows[i]["DIPR_DIM3"] != null) && (dtRmComAFSemNF.Rows[i]["DIPR_DIM3"] != DBNull.Value)) iAF.DiprDim3 = Convert.ToString(dtRmComAFSemNF.Rows[i]["DIPR_DIM3"]);
                        
                    iAF.UnmeSigla = Convert.ToString(dtRmComAFSemNF.Rows[i]["UNME_SIGLA"]);
                    iAF.RepiItem = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["REPI_ITEM"]);

                    //ELIMINAR ATRIBUTO DO RELATORIO E DO DTO
                    //if ((dtRmComAFSemNF.Rows[i]["REPI_DT_NECESSIDADE"] != null) && (dtRmComAFSemNF.Rows[i]["REPI_DT_NECESSIDADE"] != DBNull.Value)) iAF.RepiDtNecessidade = Convert.ToDateTime(dtRmComAFSemNF.Rows[i]["REPI_DT_NECESSIDADE"]);

                    iAF.RepiQtdTotal = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["REPI_QTD_TOTAL"]);

                    //Qtd Necessária
                    iAF.FsitQtdReal = GetQtdNecessaria(iAF.DipcCodigo);

                    iAF.AfitItem = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["AFIT_ITEM"]);
                    iAF.AfitQtdTotal = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["AFIT_QTD_TOTAL"]);  //Qtd total do Item na AF
                    if ((dtRmComAFSemNF.Rows[i]["AUFO_DT_EMISSAO"] != null) && (dtRmComAFSemNF.Rows[i]["AUFO_DT_EMISSAO"] != DBNull.Value)) iAF.AufoDtEmissao = Convert.ToDateTime(dtRmComAFSemNF.Rows[i]["AUFO_DT_EMISSAO"]);
                    iAF.AficContratual = iAF.AufoDtEmissao;
                    if ((dtRmComAFSemNF.Rows[i]["AFIC_CONTRATUAL"] != null) && (dtRmComAFSemNF.Rows[i]["AFIC_CONTRATUAL"] != DBNull.Value) && (dtRmComAFSemNF.Rows[i]["AFIC_CONTRATUAL"].ToString().Substring(0, 10) != "00/00/0000")) iAF.AficContratual = Convert.ToDateTime(dtRmComAFSemNF.Rows[i]["AFIC_CONTRATUAL"]);
                    iAF.AufoId = Convert.ToDecimal(dtRmComAFSemNF.Rows[i]["AUFO_ID"]);
                    iAF.AufoNumero = Convert.ToString(dtRmComAFSemNF.Rows[i]["AUFO_NUMERO"]);
                    
                    if(aufoEmprId > 0) iAF.EmprNome = GetFornecedor(aufoEmprId);

                    //// Saldos
                    //iAF.SldCompra = iAF.RepiQtdTotal - iAF.AfitQtdTotal;
                    //iAF.SldNecessidade = iAF.RepiQtdTotal - iAF.FsitQtdReal;
                    
                    iAF.DiscNome = dtRmComAFSemNF.Rows[i]["DISC_NOME"].ToString();
                    iAF.SbcnSigla = dtRmComAFSemNF.Rows[i]["SBCN_SIGLA"].ToString();

                    //PRAZOS PREVISOES DE ENTREGA
                    iAF.Prazos = GetPrazosItem(afitId);
                    iAF.Entregas = GetEntregasItem(afitId,iAF.AficContratual);

                    iAF.Status = "NE";

                    idAC_PENDENCIA_MATERIAL += 1;
                    iAF.ID = idAC_PENDENCIA_MATERIAL;
                    InserePendencia(iAF);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //===================================================================================
        //NL E LB
        internal static void GetRMComAFComNFNaoLib(string contrato)     //RMs Com AF -  (COMPRADAS) E ITENS (ENTREGUES)     - (Com NF) (NAO LIBERADOS)
        {
            try
            {
                for (int i = 0; i < dtRmComAFComNFNaoLib.Rows.Count; i++)
                {
                    if (i == 481)
                    {
                        string x = "";
                    }
                    
                    afitId = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["AFIT_ID"]);

                    RM = dtRmComAFComNFNaoLib.Rows[i]["REPR_NUMERO"].ToString();
                    titulo = dtRmComAFComNFNaoLib.Rows[i]["DCMN_TITULO"].ToString();
                    if ((dtRmComAFComNFNaoLib.Rows[i]["AUFO_EMPR_ID"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["AUFO_EMPR_ID"] != DBNull.Value)) aufoEmprId = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["AUFO_EMPR_ID"]);
                
                    string nfitId = dtRmComAFComNFNaoLib.Rows[i]["NFIT_ID"].ToString();

                    DTO.AcPendenciaMaterialDTO iAF = new DTO.AcPendenciaMaterialDTO();
                    iAF.DcmnNumero = RM;
                    iAF.DcmnTitulo = titulo;

                    iAF.DipcCodigo = dtRmComAFComNFNaoLib.Rows[i]["DIPC_CODIGO"].ToString();
                    iAF.DipiDescricaoRes = dtRmComAFComNFNaoLib.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    iAF.DiprPeso = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["DIPR_PESO"]);
                    if ((dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIMENSOES"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIMENSOES"] != DBNull.Value)) iAF.DiprDimensoes = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIMENSOES"]);
                    if ((dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM1"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM1"] != DBNull.Value)) iAF.DiprDim1 = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM1"]);
                    if ((dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM2"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM2"] != DBNull.Value)) iAF.DiprDim2 = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM2"]);
                    if ((dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM3"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM3"] != DBNull.Value)) iAF.DiprDim3 = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["DIPR_DIM3"]);

                    iAF.UnmeSigla = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["UNME_SIGLA"]);

                    iAF.RepiItem = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["REPI_ITEM"]);
                    //if ((dtRmComAFComNFNaoLib.Rows[0]["REPI_DT_NECESSIDADE"] != null) && (dtRmComAFComNFNaoLib.Rows[0]["REPI_DT_NECESSIDADE"] != DBNull.Value)) iAF.RepiDtNecessidade = Convert.ToDateTime(dtRmComAFComNFNaoLib.Rows[i]["REPI_DT_NECESSIDADE"]);
                    iAF.RepiQtdTotal = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["REPI_QTD_TOTAL"]);

                    //Qtd Necessária
                    iAF.FsitQtdReal = GetQtdNecessaria(iAF.DipcCodigo);

                    iAF.AufoId = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["AUFO_ID"]);
                
                    iAF.AfitItem = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["AFIT_ITEM"]);
                    iAF.AfitQtdTotal = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["AFIT_QTD_TOTAL"]);
                    if ((dtRmComAFComNFNaoLib.Rows[i]["AUFO_DT_EMISSAO"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["AUFO_DT_EMISSAO"] != DBNull.Value)) iAF.AufoDtEmissao = Convert.ToDateTime(dtRmComAFComNFNaoLib.Rows[i]["AUFO_DT_EMISSAO"]);
                    iAF.AficContratual = iAF.AufoDtEmissao;
                    //if ((dtRmComAFComNFNaoLib.Rows[i]["AFIC_CONTRATUAL"] != null) && (dtRmComAFComNFNaoLib.Rows[i]["AFIC_CONTRATUAL"] != DBNull.Value && (dtRmComAFComNFNaoLib.Rows[i]["AFIC_CONTRATUAL"].ToString().Substring(0,10) != "00/00/0000"))) iAF.AficContratual = Convert.ToDateTime(dtRmComAFComNFNaoLib.Rows[i]["AFIC_CONTRATUAL"].ToString());
                    //iAF.DipqQtdAf = Convert.ToDecimal(dtRmComAFComNFNaoLib.Rows[i]["DIPQ_QTD_AF"]);
                    iAF.AufoNumero = Convert.ToString(dtRmComAFComNFNaoLib.Rows[i]["AUFO_NUMERO"]);

                    if (aufoEmprId > 0) iAF.EmprNome = GetFornecedor(aufoEmprId);

                    ////Saldos
                    //iAF.SldCompra = iAF.RepiQtdTotal - iAF.AfitQtdTotal;
                    //iAF.SldNecessidade = iAF.RepiQtdTotal - iAF.FsitQtdReal;

                    iAF.DiscNome = dtRmComAFComNFNaoLib.Rows[i]["DISC_NOME"].ToString();
                    iAF.SbcnSigla = dtRmComAFComNFNaoLib.Rows[i]["SBCN_SIGLA"].ToString();
                
                    //NF
                    DataRow[] rowNF = dtNF.Select("NFIT_ID = " + nfitId, "NOFI_NUMERO");
                    int countNF = rowNF.Count();
                    for (int cnf = 0; cnf < countNF; cnf++ )
                    {
                        iAF.NfitQtd = Convert.ToDecimal(rowNF[cnf]["NFIT_QTD"]);
                        iAF.NofiNumero = Convert.ToString(rowNF[cnf]["NOFI_NUMERO"]);
                        ////SldEntrega
                        //iAF.SldEntrega = iAF.RepiQtdTotal - iAF.NfitQtd;

                        if ((rowNF[cnf]["NOFI_DT_RECEBIMENTO"] != null) && (rowNF[cnf]["NOFI_DT_RECEBIMENTO"] != DBNull.Value)) iAF.NofiDtRecebimento = Convert.ToDateTime(rowNF[cnf]["NOFI_DT_RECEBIMENTO"]);
                        iAF.Status = "NL";

                        //PRAZOS PREVISOES DE ENTREGA
                        iAF.Prazos = GetPrazosItem(afitId);
                        iAF.Entregas = GetEntregasItem(afitId, iAF.AficContratual);

                        //NE
                        DataRow[] rowNE = dtNE.Select("NOEI_NFIT_ID = " + rowNF[cnf]["NFIT_ID"].ToString(), "NOEN_NUMERO");
                        int countNE = rowNE.Count();
                        if (countNE == 0)
                        {
                            iAF.Status = "NL";
                            SavePendencia(iAF);
                        }
                        else
                        {
                            for (int cne = 0; cne < countNE; cne++)
                            {
                                iAF.NoenNumero = Convert.ToString(rowNE[cne]["NOEN_NUMERO"]);
                                if ((rowNE[cne]["NOEN_DT_EMISSAO"] != null) && (rowNE[cne]["NOEN_DT_EMISSAO"] != DBNull.Value)) iAF.NoenDtEmissao = Convert.ToDateTime(rowNE[cne]["NOEN_DT_EMISSAO"]);
                                iAF.NoenObs = Convert.ToString(rowNE[cne]["NOEN_OBS"]);
                                iAF.NoeiItem = Convert.ToDecimal(rowNE[cne]["NOEI_ITEM"]);
                                iAF.NoeiQtdNem = Convert.ToDecimal(rowNE[cne]["NOEI_QTD_NEM"]);
                                ////SldLiberado
                                //iAF.SldLiberado = iAF.RepiQtdTotal - iAF.NoeiQtdNem;
                                iAF.Status = "NL";
                                if (iAF.NoeiQtdNem > 0 && iAF.NoenNumero != "") iAF.Status = "LB";
                                SavePendencia(iAF);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //===================================================================================
        //NC
        internal static void GetRmSemAF(string contrato)                //RMs Sem AF -  (NÃO COMPRADAS) 
        {
            try
            {
                for (int i = 0; i < dtRmSemAF.Rows.Count; i++)
                {
                    RM = dtRmSemAF.Rows[i]["DCMN_NUMERO"].ToString();
                    titulo = dtRmSemAF.Rows[i]["DCMN_TITULO"].ToString();

                    DTO.AcPendenciaMaterialDTO iAF = new DTO.AcPendenciaMaterialDTO();
                    idAC_PENDENCIA_MATERIAL += 1;
                    iAF.ID = idAC_PENDENCIA_MATERIAL;
                    iAF.DcmnNumero = RM;
                    iAF.DcmnTitulo = titulo;
                    iAF.DiscNome = dtRmSemAF.Rows[i]["DISC_NOME"].ToString();
                    iAF.SbcnSigla = dtRmSemAF.Rows[i]["SBCN_SIGLA"].ToString();
                    iAF.DipcCodigo = dtRmSemAF.Rows[i]["DIPC_CODIGO"].ToString();
                    iAF.DipiDescricaoRes = dtRmSemAF.Rows[i]["DIPI_DESCRICAO_RES"].ToString();
                    iAF.RepiItem = Convert.ToDecimal(dtRmSemAF.Rows[i]["REPI_ITEM"]);

                    //Qtd Necessária
                    iAF.FsitQtdReal = GetQtdNecessaria(iAF.DipcCodigo);

                    ////Saldos
                    //iAF.SldCompra = iAF.RepiQtdTotal - iAF.AfitQtdTotal;
                    //iAF.SldNecessidade = iAF.RepiQtdTotal - iAF.FsitQtdReal;

                    iAF.DiprPeso = Convert.ToDecimal(dtRmSemAF.Rows[i]["DIPR_PESO"]);
                    iAF.UnmeSigla = Convert.ToString(dtRmSemAF.Rows[i]["UNME_SIGLA"]);
                    iAF.Status = "NC";

                    InserePendencia(iAF);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //===================================================================================
        private static void SavePendencia(DTO.AcPendenciaMaterialDTO iAF)
        {
            idAC_PENDENCIA_MATERIAL += 1;
            iAF.ID = idAC_PENDENCIA_MATERIAL;
            InserePendencia(iAF);
        }
       
    #region Previsões e prazos
        //===================================================================================
        private static DataRow[] GetRowsPrazoItem(decimal afitId)
        {
            DataRow[] rows = null;
            rows = dtPrazo.Select("AFIT_ID = " + afitId.ToString()); 
            return rows;
        }
        //===================================================================================
        private static string GetPrazosItem(decimal afitId)
        {
            string sRet = "";
            DataRow[] rows = null;
            decimal prazo = 0;
            rows = dtPrazo.Select("AFIT_ID = " + afitId.ToString());
            int c = rows.Count();
            if (c > 0)
            {
                for (int r = 0; r < c; r++)
                {
                    prazo = Convert.ToDecimal(rows[r]["AFIP_PRAZO"]); ;
                    if (prazo > 0)
                    {
                        sRet += " ; " + prazo.ToString();
                    }
                    //if (iAF.AfipPrazo != 0)
                    //{
                    //    string x = "";
                    //}
                }
                if (sRet != "") sRet = sRet.Substring(3);
            }
            if (sRet == "") sRet = "N/A";
            return sRet;
        }
        //===================================================================================
        private static string GetEntregasItem(decimal afitId, DateTime dataContratual)
        {
            string sRet = "";
            DataRow[] rows = null;
            decimal prazo = 0;
            DateTime previsaoEntrega;
            rows = dtPrazo.Select("AFIT_ID = " + afitId.ToString());
            int c = rows.Count();
            if (c > 0)
            {
                for (int r = 0; r < c; r++)
                {
                    prazo = Convert.ToDecimal(rows[r]["AFIP_PRAZO"]); ;
                    if (prazo > 0)
                    {
                        previsaoEntrega = dataContratual.AddDays(Convert.ToDouble(prazo));
                        sRet += " ; " + previsaoEntrega.ToString("dd/MM/yyyy");
                    }
                    //if (iAF.AfipPrazo != 0)
                    //{
                    //    string x = "";
                    //}
                }
                if (sRet != "") sRet = sRet.Substring(3);
            }
            if (sRet == "") sRet = "N/A";
            return sRet;
        }
    #endregion


        //===================================================================================
        public static int CountRecordPendenciaMateriais(string contrato)
        {
            int iRet = 0;

            ////RMs Sem AF (NÃO) COMPRADAS 
            //strSQL = @"SELECT DISTINCT COUNT(*) FROM EEP_CONVERSION.DOCUMENTO WHERE DCMN_CNTR_CODIGO = '" + contrato + "' AND DCMN_DCTP_ID = 12 AND DCMN_NUMERO NOT IN (SELECT DISTINCT DCMN_NUMERO FROM V_AF_ITEM)";
            //int countRmSemAF = Convert.ToInt32(BLL.AcPendenciaMaterialBLL.Select(strSQL).Rows[0][0]);
            
            ////RMs Com AF (COMPRADAS) E ITENS (NAO) ENTREGUES (Sem NF)
            //strSQL = @"SELECT DISTINCT COUNT(*) FROM EEP_CONVERSION.V_AF_ITEM WHERE AFIT_CNTR_CODIGO = '" + contrato + "' AND DIPQ_QTD_NF = 0 ORDER BY DCMN_NUMERO";
            //int countRmComAFSemNF = Convert.ToInt32(BLL.AcPendenciaMaterialBLL.Select(strSQL).Rows[0][0]);
            
            ////RMs Com AF (COMPRADAS) E ITENS ENTREGUES  (Com NF)
            //strSQL = @"SELECT DISTINCT COUNT(*)  FROM EEP_CONVERSION.V_AF_ITEM WHERE AFIT_CNTR_CODIGO = '" + contrato + "' AND DIPQ_QTD_NF > 0";
            //int countRmComAFComNF = Convert.ToInt32(BLL.AcPendenciaMaterialBLL.Select(strSQL).Rows[0][0]);

            ////RMs Com NF (ENTREGUES) E ITENS (NAO) LIBERADOS
            //strSQL = @"SELECT DISTINCT COUNT(*) FROM EEP_CONVERSION.V_AF_ITEM WHERE AFIT_CNTR_CODIGO = '" + contrato + "' AND DIPQ_QTD_NF > 0 AND DIPQ_QTD_NE = 0 ORDER BY DCMN_NUMERO";
            //int countRmComNFSemNE = Convert.ToInt32(BLL.AcPendenciaMaterialBLL.Select(strSQL).Rows[0][0]);

            ////RMs Com NF (ENTREGUES) E ITENS LIBERADOS
            //strSQL = @"SELECT DISTINCT COUNT(*) FROM EEP_CONVERSION.V_AF_ITEM WHERE AFIT_CNTR_CODIGO = '" + contrato + "' AND DIPQ_QTD_NF > 0 AND DIPQ_QTD_NE > 0 ORDER BY DCMN_NUMERO";
            //int countRmComNFComNE = Convert.ToInt32(BLL.AcPendenciaMaterialBLL.Select(strSQL).Rows[0][0]);

            //iRet = countRmSemAF + countRmComAFSemNF + countRmComAFComNF + countRmComNFSemNE + countRmComNFComNE;
            
            return iRet;
        }
        //===================================================================================
        internal static decimal GetQtdNecessaria(string dipcCodigo)
        {
            decimal dRet = 0;
            DataRow[] rows;
            rows = dtQtdNecessariaMaterial.Select("CODIGO = '" + dipcCodigo +"'");
            if (rows.Count() > 0)
            {
                dRet = Convert.ToDecimal(rows[0]["FSIT_QTD_REAL"]);
            }
            return dRet;
        }
        //===================================================================================
        internal static string GetFornecedor(decimal aufoEmprId)
        {
            string sRet = "";
            DataRow[] rows;
            rows = dtFornecedor.Select("AUFO_EMPR_ID = " + aufoEmprId.ToString());
            if (rows.Count() > 0)
            {
                sRet = Convert.ToString(rows[0]["EMPR_NOME"]);
            }
            return sRet;
        }
        //===================================================================================
        private static void InserePendencia(DTO.AcPendenciaMaterialDTO iAF)
        {
            BLL.AcPendenciaMaterialBLL.Insert(iAF, false);
        }
        //===================================================================================
    }
}