using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace Core
{
    public class Avancos
    {
        //====================================================================================================================================================
        public static void CalculaAvancos(DTO.VwAcGrupoCriterioMedicaoDTO grupo, DTO.AcSemanaDTO semana, DTO.LimitesPeriodoDTO limites)
        {
            DTO.AcAvnCriterioDTO reg = new DTO.AcAvnCriterioDTO();
            reg.GrcrCntrCodigo = grupo.GrcrCntrCodigo;
            reg.GrcrId = grupo.GrcrId;
            reg.SemaId = semana.SemaId;
            reg.GrcrGrupoSigla = grupo.GrcrGrupoSigla;
            reg.GrcrNome = grupo.GrcrNome;
            reg.GrcrGrupoDescricao = grupo.GrcrGrupoDescricao;
            reg.GrcrSequence = grupo.GrcrSequence;
            reg.FcmeId = grupo.FcmeId;
            reg.FcmeSigla = grupo.FcmeSigla;
            reg.FcesId = grupo.FcesId;
            reg.FcesSigla = grupo.FcesSigla;
            reg.FcesPesoRelCron = grupo.FcesPesoRelCron;
            reg.FoseId = grupo.FoseId;
            reg.FoseNumero = grupo.FoseNumero;
            reg.FoseQtdPrevista = grupo.FoseQtdPrevista;
            reg.FosmId = grupo.FosmId;

            //Calcula avanços Grupo
            //================================================================================================================================================
            // Tipo E - (FSME)
            // AVANÇOS EXECUTADOS
            //================================================================================================================================================
            reg.AvancoTipo = "E";
            // Periodo S - Semana
            reg.AvancoPeriodo = "S";
            reg.QtdAvanco = GetAvancosFSME(reg.FoseId, limites.DataInicialSemana, limites.DataFinalSemana, reg.FcesSigla, reg.FoseQtdPrevista);              //(FSME)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            // Periodo M - Mês
            reg.AvancoPeriodo = "M";
            reg.QtdAvanco = GetAvancosFSME(reg.FoseId, limites.DataInicialMes, limites.DataFinalMes, reg.FcesSigla, reg.FoseQtdPrevista);                    //(FSME)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            // Periodo A - Acumulado
            reg.AvancoPeriodo = "A";
            reg.QtdAvanco = GetAvancosFSME(reg.FoseId, limites.DataInicialAcumulado, limites.DataFinalAcumulado, reg.FcesSigla, reg.FoseQtdPrevista);        //(FSME)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            //================================================================================================================================================



            //================================================================================================================================================
            // Tipo P - (FSMP)
            // AVANÇOS PROGRAMADOS
            //================================================================================================================================================
            reg.AvancoTipo = "P";
            // Periodo S - Semana
            reg.AvancoPeriodo = "S";
            reg.QtdAvanco = GetAvancosFSMP(reg.FoseId, limites.DataInicialSemana, limites.DataFinalSemana, reg.FcesSigla, reg.FoseQtdPrevista);              //(FSMP)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            // Periodo M - Mês
            reg.AvancoPeriodo = "M";
            reg.QtdAvanco = GetAvancosFSMP(reg.FoseId, limites.DataInicialMes, limites.DataFinalMes, reg.FcesSigla, reg.FoseQtdPrevista);                    //(FSMP)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            // Periodo A - Acumulado
            reg.AvancoPeriodo = "A";
            reg.QtdAvanco = GetAvancosFSMP(reg.FoseId, limites.DataInicialAcumulado, limites.DataFinalAcumulado, reg.FcesSigla, reg.FoseQtdPrevista);        //(FSMP)
            if (reg.QtdAvanco > 0)
            {
                BLL.AcAvnCriterioBLL.Insert(reg, false);
            }
            //================================================================================================================================================
        }
        //====================================================================================================================================================
        public static decimal GetAvancosFSME(int pFOSE_ID, DateTime dDT_START, DateTime dDT_END, string pFCES_SIGLA, decimal pFOSE_QTD_PREVISTA)
        {
            //Calcula Avanço Relativo no Período
            int mCOUNTER = 0;
            string strSQL = "";
            decimal mAVANCO_PERIODO = 0;
            decimal mAVANCO_ANTES_PERIODO = 0;
            decimal mAVANCO_CALCULADO = 0;
            string pDT_START = dDT_START.ToString("dd/MM/yyyy");
            string pDT_END = dDT_END.ToString("dd/MM/yyyy");
            //VERIFICA SE EXISTE AVANÇO NO PERIODO
            strSQL = @"SELECT COUNT(*)
                         FROM (
                                SELECT FOSE_NUMERO, FCES_SIGLA, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM
                                  FROM EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                 WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                        AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                        AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                        AND FSME_DATA >= TO_DATE('" + pDT_START + "', 'DD/MM/YYYY') AND FSME_DATA <= TO_DATE('" + pDT_END + @"', 'DD/MM/YYYY') 
                                        AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                        AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                              )
                        WHERE ROWNUM = 1";
            mCOUNTER = Convert.ToInt32(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            if (mCOUNTER > 0)  //EXISTE AVANÇO NO PERIODO
            {
                strSQL = @" SELECT ROUND(FSME_AVANCO_ACM,5) AS FSME_AVANCO
                              FROM (
                                    SELECT FOSE_NUMERO, FCES_SIGLA, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM
                                      FROM EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                     WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                       AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                       AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                       AND FSME_DATA >= TO_DATE('" + pDT_START + "', 'DD/MM/YYYY') AND FSME_DATA <= TO_DATE('" + pDT_END + @"', 'DD/MM/YYYY') 
                                       AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                       AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                                     ORDER  BY FCES_WBS, FCES_SIGLA, FSME_DATA DESC
                                   )
                             WHERE ROWNUM = 1
                             ORDER BY FSME_DATA DESC";
                mAVANCO_PERIODO = Convert.ToDecimal(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            }


            //VERIFICA SE EXISTE AVANÇO ANTES DO PERIODO
            strSQL = @"SELECT COUNT(*)
                         FROM (
                               SELECT  FOSE_NUMERO, FCES_SIGLA, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM
                               FROM  EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                               WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                 AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                 AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                 AND FSME_DATA < TO_DATE('" + pDT_START + @"', 'DD/MM/YYYY') AND FSME_DATA >= TO_DATE('22/06/2012', 'DD/MM/YYYY')
                                 AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                 AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                              )
                        WHERE ROWNUM = 1";
            mCOUNTER = Convert.ToInt32(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);

            if (mCOUNTER > 0)  //EXISTE AVANÇO ANTES DO PERIODO
            {
                strSQL = @"SELECT ROUND(FSME_AVANCO_ACM,5) AS FSME_AVANCO
                           FROM 
                           (
                               SELECT FOSE_NUMERO, FCES_SIGLA, FSME_DATA, FSME_AVANCO_ACM, FSME_QTD_ACM
                                 FROM EPCCQ.FOLHA_SERVICO_MEDICAO_EXEC, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                WHERE FSME_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSME_FOSM_ID = FOSM_ID
                                  AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                  AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                  AND FSME_DATA < TO_DATE('" + pDT_START + @"', 'DD/MM/YYYY') AND FSME_DATA >= TO_DATE('22/06/2012', 'DD/MM/YYYY')
                                 AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                        AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                                ORDER BY FCES_WBS, FCES_SIGLA, FSME_DATA DESC
                           )
                           WHERE ROWNUM = 1
                           ORDER BY FSME_DATA DESC";
                mAVANCO_ANTES_PERIODO = Convert.ToDecimal(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            }

            //CALCULA AVANCO DO PERIODO
            if (mAVANCO_PERIODO > mAVANCO_ANTES_PERIODO)
            {
                mAVANCO_CALCULADO = System.Math.Round((mAVANCO_PERIODO - mAVANCO_ANTES_PERIODO) * pFOSE_QTD_PREVISTA / 100, 4);
            }
            return mAVANCO_CALCULADO;
        }
        //====================================================================================================================================================
        public static decimal GetAvancosFSMP(int pFOSE_ID, DateTime dDT_START, DateTime dDT_END, string pFCES_SIGLA, decimal pFOSE_QTD_PREVISTA)
        {
            //Calcula Avanço Relativo no Período
            int mCOUNTER = 0;
            string strSQL = "";
            decimal mAVANCO_PERIODO = 0;
            decimal mAVANCO_ANTES_PERIODO = 0;
            decimal mAVANCO_CALCULADO = 0;
            string pDT_START = dDT_START.ToString("dd/MM/yyyy");
            string pDT_END = dDT_END.ToString("dd/MM/yyyy");
            //VERIFICA SE EXISTE AVANÇO NO PERIODO
            strSQL = @"SELECT COUNT(*)
                         FROM (
                                SELECT FOSE_NUMERO, FCES_SIGLA, FSMP_DATA, FSMP_AVANCO_ACM, FSMP_QTD_ACM
                                  FROM EPCCQ.FOLHA_SERVICO_MEDICAO_PROG, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                 WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                        AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                        AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                        AND FSMP_DATA >= TO_DATE('" + pDT_START + "', 'DD/MM/YYYY') AND FSMP_DATA <= TO_DATE('" + pDT_END + @"', 'DD/MM/YYYY') 
                                        AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                        AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                              )
                        WHERE ROWNUM = 1";
            mCOUNTER = Convert.ToInt32(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            if (mCOUNTER > 0)  //EXISTE AVANÇO NO PERIODO
            {
                strSQL = @" SELECT ROUND(FSMP_AVANCO_ACM,5) AS FSMP_AVANCO
                              FROM (
                                    SELECT FOSE_NUMERO, FCES_SIGLA, FSMP_DATA, FSMP_AVANCO_ACM, FSMP_QTD_ACM
                                      FROM EPCCQ.FOLHA_SERVICO_MEDICAO_PROG, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                     WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                       AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                       AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                       AND FSMP_DATA >= TO_DATE('" + pDT_START + "', 'DD/MM/YYYY') AND FSMP_DATA <= TO_DATE('" + pDT_END + @"', 'DD/MM/YYYY') 
                                       AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                       AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                                     ORDER  BY FCES_WBS, FCES_SIGLA, FSMP_DATA DESC
                                   )
                             WHERE ROWNUM = 1
                             ORDER BY FSMP_DATA DESC";
                mAVANCO_PERIODO = Convert.ToDecimal(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            }


            //VERIFICA SE EXISTE AVANÇO ANTES DO PERIODO
            strSQL = @"SELECT COUNT(*)
                         FROM (
                               SELECT  FOSE_NUMERO, FCES_SIGLA, FSMP_DATA, FSMP_AVANCO_ACM, FSMP_QTD_ACM
                               FROM  EPCCQ.FOLHA_SERVICO_MEDICAO_PROG, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                               WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                 AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                 AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                 AND FSMP_DATA < TO_DATE('" + pDT_START + @"', 'DD/MM/YYYY') AND FSMP_DATA >= TO_DATE('22/06/2012', 'DD/MM/YYYY')
                                 AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                 AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                              )
                        WHERE ROWNUM = 1";
            mCOUNTER = Convert.ToInt32(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);

            if (mCOUNTER > 0)  //EXISTE AVANÇO ANTES DO PERIODO
            {
                strSQL = @"SELECT ROUND(FSMP_AVANCO_ACM,5) AS FSMP_AVANCO
                           FROM 
                           (
                               SELECT FOSE_NUMERO, FCES_SIGLA, FSMP_DATA, FSMP_AVANCO_ACM, FSMP_QTD_ACM
                                 FROM EPCCQ.FOLHA_SERVICO_MEDICAO_PROG, EPCCQ.FOLHA_SERVICO_MEDICAO, EPCCQ.FOLHA_SERVICO, EPCCQ.FOLHA_CRITERIO_ESTRUTURA
                                WHERE FSMP_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID = FOSM_ID
                                  AND FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID
                                  AND FCES_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FCES_ID = FOSM_FCES_ID
                                  AND FSMP_DATA < TO_DATE('" + pDT_START + @"', 'DD/MM/YYYY') AND FSMP_DATA >= TO_DATE('22/06/2012', 'DD/MM/YYYY')
                                 AND FCES_SIGLA = '" + pFCES_SIGLA + @"' 
                                        AND FOSM_FOSE_ID = " + pFOSE_ID + @"
                                ORDER BY FCES_WBS, FCES_SIGLA, FSMP_DATA DESC
                           )
                           WHERE ROWNUM = 1
                           ORDER BY FSMP_DATA DESC";
                mAVANCO_ANTES_PERIODO = Convert.ToDecimal(BLL.AcAvnCriterioBLL.Select(strSQL).Rows[0][0]);
            }

            //CALCULA AVANCO DO PERIODO
            if (mAVANCO_PERIODO > mAVANCO_ANTES_PERIODO)
            {
                mAVANCO_CALCULADO = System.Math.Round((mAVANCO_PERIODO - mAVANCO_ANTES_PERIODO) * pFOSE_QTD_PREVISTA / 100, 4);
            }
            return mAVANCO_CALCULADO;
        }
        //====================================================================================================================================================
    }
}
