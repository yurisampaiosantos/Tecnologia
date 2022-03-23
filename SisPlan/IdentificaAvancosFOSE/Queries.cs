using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace IdentificaAvancosFOSE
{
    public class Queries
    {
        //========================================================================================
        //public static DataTable GetAvancosFOSE(string foseNumero, string contrato, string discId, string dataInicial)
        public static DataTable GetAvancosFOSE(string contrato, string discId, string dataInicial)
        {
            DataTable dtAvancosFOSE = null;
            try
            {
                //Obtém os avanços a serem consolidados
                string strSQL = @"SELECT 
                                  D.DISC_NOME, 
                                  (SELECT  ATV.ATIV_SIG
                                   FROM   EEP_CONVERSION.FOLHA_SERVICO_MEDICAO FSM, EEP_CONVERSION.ATIV_VINCULO_FS VFS, EEP_CONVERSION.ATIVIDADE ATV
                                   WHERE 
                                          VFS.ATVF_CNTR_CODIGO = FSM.FOSM_CNTR_CODIGO AND VFS.ATVF_FOSM_ID = FSM.FOSM_ID AND
                                          ATV.ATIV_CNTR_CODIGO = VFS.ATVF_CNTR_CODIGO AND ATV.ATIV_ID = VFS.ATVF_ATIV_ID AND
                                          FSM.FOSM_CNTR_CODIGO = 'Conversão' AND ROWNUM = 1 AND VFS.ATVF_FOSM_ID = Q.FOSM_ID) AS ATIV_SIG,
                                  SC.SBCN_NOME, UNPR_SIGLA, UNPR_NOME, ARAP_SIGLA, ARAP_NOME, Q.FOSE_NUMERO, Q.FOSE_QTD_PREVISTA, Q.FOSE_QTD_REALIZADA, UNME_NOME, SF.SIFS_DESCRICAO, 
                                  (SELECT PA.DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO PA WHERE PA.FOSE_ID(+) = Q.FOSE_ID AND UPPER(PA.ATPE_NOME) = 'PASTA') AS PASTA, 
                                  (SELECT PA.DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO PA WHERE PA.FOSE_ID(+) = Q.FOSE_ID AND UPPER(PA.ATPE_NOME) = 'DESENHO') AS DESENHO, 
                                  (SELECT PA.DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO PA WHERE PA.FOSE_ID(+) = Q.FOSE_ID AND UPPER(PA.ATPE_NOME) = 'TIPO') AS TIPO, 
                                  (SELECT PA.DESCRICAO_ATRIBUTO FROM EEP_CONVERSION.VW_AC_ATRIBUTO_PERSONALIZADO PA WHERE PA.FOSE_ID(+) = Q.FOSE_ID AND UPPER(PA.ATPE_NOME) = 'SETOR') AS SETOR, 
                                  Q.FCES_SIGLA, Q.FCES_WBS,
                                  Q.FSMP_DATA, ROUND(Q.FSMP_AVANCO_ACM, 6) AS FSMP_AVANCO_ACM, ROUND(Q.FSMP_QTD_ACM, 6) AS FSMP_QTD_ACM, Q.FSMP_DT_CADASTRO,
                                  Q.FSME_DATA, ROUND(Q.FSME_AVANCO_ACM, 6) AS FSME_AVANCO_ACM, ROUND(Q.FSME_QTD_ACM, 6) AS FSME_QTD_ACM, Q.FSME_DT_CADASTRO,
                                  Q.FOSM_ID, Q.FOSM_FCES_ID,
                                  Q.FOSE_CNTR_CODIGO, Q.FOSE_SBCN_ID, Q.FOSE_UNPR_ID, Q.FOSE_ARAP_ID, Q.FOSE_DISC_ID, D.DISC_ID, Q.FOSE_ID, Q.FOSE_SIFS_ID, Q.FOSE_UNME_ID,
                                  Q.FCES_FCME_ID, M.FCME_SIGLA, Q.FCES_NIVEL, Q.FCES_PESO_REL_CRON
          
                        FROM (
                                  SELECT 
                                            FOSM_ID, FOSM_FCES_ID,
                                            FOSE_CNTR_CODIGO, FOSE_SBCN_ID, FOSE_UNPR_ID, FOSE_ARAP_ID, FOSE_DISC_ID, FOSE_ID, FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_QTD_REALIZADA, FOSE_SIFS_ID, FOSE_UNME_ID,
                                            FCES_CNTR_CODIGO, FCES_FCME_ID, FCES_SIGLA, FCES_WBS, FCES_NIVEL, FCES_PESO_REL_CRON,
                                            MAX(FSMP_DATA) AS FSMP_DATA, MAX(FSMP_AVANCO_ACM) AS FSMP_AVANCO_ACM, MAX(FSMP_QTD_ACM) AS FSMP_QTD_ACM, MAX(FSMP_DT_CADASTRO) AS FSMP_DT_CADASTRO,
                                            MAX(FSME_DATA) AS FSME_DATA, MAX(FSME_AVANCO_ACM) AS FSME_AVANCO_ACM, MAX(FSME_QTD_ACM) AS FSME_QTD_ACM, MAX(FSME_DT_CADASTRO) AS FSME_DT_CADASTRO
                                  FROM 
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,
                                            EEP_CONVERSION.FOLHA_SERVICO,
                                            EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG,
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC,
                                            EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                                  WHERE     
                                            
                                            FOSE_DISC_ID = " + discId + @" AND
                                            FOSM_CNTR_CODIGO = '" + contrato + @"' AND
                                            FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID AND
                                            FCES_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FCES_ID(+) = FOSM_FCES_ID AND
                                            FSMP_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID(+) = FOSM_ID AND
                                            FSME_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FSME_FOSM_ID(+) = FOSM_ID AND
                                            (
                                             FSMP_DT_CADASTRO >= TO_DATE('" + dataInicial + @"', 'DD/MM/YYYY HH24:MI:SS') OR 
                                             FSME_DT_CADASTRO >= TO_DATE('" + dataInicial + @"', 'DD/MM/YYYY HH24:MI:SS')
                                            )
                                  GROUP BY  
                                            FOSM_ID, FOSM_FCES_ID,
                                            FOSE_CNTR_CODIGO, FOSE_SBCN_ID, FOSE_UNPR_ID, FOSE_ARAP_ID, FOSE_DISC_ID, FOSE_ID, FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_QTD_REALIZADA, FOSE_SIFS_ID, FOSE_UNME_ID,
                                            FCES_CNTR_CODIGO, FCES_FCME_ID, FCES_SIGLA, FCES_WBS, FCES_NIVEL, FCES_PESO_REL_CRON
                              ) Q, 
                              EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO M,
                              EEP_CONVERSION.DISCIPLINA D,
                              EEP_CONVERSION.SUB_CONTRATO SC,
                              EEP_CONVERSION.UNIDADE_PROCESSO,
                              EEP_CONVERSION.AREA_APLICACAO,
                              EEP_CONVERSION.SITUACAO_FOLHA_SERVICO SF,
                              EEP_CONVERSION.UNIDADE_MEDIDA
                        WHERE 
                              Q.FCES_NIVEL IN (
                                                SELECT X.MAX_NIVEL_CRITERIO 
                                                FROM EEP_CONVERSION.VW_MAX_NIVEL_CRITERIO_MEDICAO X 
                                                WHERE X.FCES_CNTR_CODIGO = M.FCME_CNTR_CODIGO 
                                                AND X.FCES_FCME_ID = M.FCME_ID
                                              ) AND
                              M.FCME_CNTR_CODIGO = Q.FCES_CNTR_CODIGO AND M.FCME_ID = Q.FCES_FCME_ID AND
                              D.DISC_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND D.DISC_ID(+) = Q.FOSE_DISC_ID AND
                              SC.SBCN_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND SC.SBCN_ID(+) = Q.FOSE_SBCN_ID AND
                              UNPR_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND UNPR_ID(+) = FOSE_UNPR_ID AND
                              ARAP_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND ARAP_ID(+) = FOSE_ARAP_ID AND
                              SF.SIFS_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND SF.SIFS_ID(+) = FOSE_SIFS_ID AND
                              UNME_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND UNME_ID(+) = FOSE_SIFS_ID
                        ORDER BY FOSE_NUMERO, FCES_WBS";
                dtAvancosFOSE = BLL.ElAvnFoseBLL.Select(strSQL);
                return dtAvancosFOSE;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }

        }
        //========================================================================================
        public static DataTable GetFOSE(string contrato, string discId, string dataInicial)
        {
            DataTable dtFOSE = null;
            //Obtém a lista de FOSE
            string strSQL = @"SELECT Q.FOSE_NUMERO
                        FROM (
                                  SELECT 
                                            FOSM_ID, FOSM_FCES_ID,
                                            FOSE_CNTR_CODIGO, FOSE_SBCN_ID, FOSE_UNPR_ID, FOSE_ARAP_ID, FOSE_DISC_ID, FOSE_ID, FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_QTD_REALIZADA, FOSE_SIFS_ID, FOSE_UNME_ID,
                                            FCES_CNTR_CODIGO, FCES_FCME_ID, FCES_SIGLA, FCES_WBS, FCES_NIVEL, FCES_PESO_REL_CRON,
                                            MAX(FSMP_DATA) AS FSMP_DATA, MAX(FSMP_AVANCO_ACM) AS FSMP_AVANCO_ACM, MAX(FSMP_QTD_ACM) AS FSMP_QTD_ACM, MAX(FSMP_DT_CADASTRO) AS FSMP_DT_CADASTRO,
                                            MAX(FSME_DATA) AS FSME_DATA, MAX(FSME_AVANCO_ACM) AS FSME_AVANCO_ACM, MAX(FSME_QTD_ACM) AS FSME_QTD_ACM, MAX(FSME_DT_CADASTRO) AS FSME_DT_CADASTRO
                                  FROM 
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO,
                                            EEP_CONVERSION.FOLHA_SERVICO,
                                            EEP_CONVERSION.FOLHA_CRITERIO_ESTRUTURA,
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_PROG,
                                            EEP_CONVERSION.FOLHA_SERVICO_MEDICAO_EXEC,
                                            EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO
                                  WHERE     
                                            --(FOSE_NUMERO = 'SP-TC126.4-09.M702' OR FOSE_NUMERO = 'SP-TC126.4-20.F.704' ) AND
                                            FOSE_DISC_ID = " + discId + @" AND
                                            FOSM_CNTR_CODIGO = '" + contrato + @"' AND
                                            FOSE_CNTR_CODIGO = FOSM_CNTR_CODIGO AND FOSE_ID = FOSM_FOSE_ID AND
                                            FCES_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FCES_ID(+) = FOSM_FCES_ID AND
                                            FSMP_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FSMP_FOSM_ID(+) = FOSM_ID AND
                                            FSME_CNTR_CODIGO(+) = FOSM_CNTR_CODIGO AND FSME_FOSM_ID(+) = FOSM_ID AND
                                            (
                                             FSMP_DT_CADASTRO >= TO_DATE('" + dataInicial + @"', 'DD/MM/YYYY HH24:MI:SS') OR 
                                             FSME_DT_CADASTRO >= TO_DATE('" + dataInicial + @"', 'DD/MM/YYYY HH24:MI:SS')
                                            )
                                  GROUP BY  
                                            FOSM_ID, FOSM_FCES_ID,
                                            FOSE_CNTR_CODIGO, FOSE_SBCN_ID, FOSE_UNPR_ID, FOSE_ARAP_ID, FOSE_DISC_ID, FOSE_ID, FOSE_NUMERO, FOSE_QTD_PREVISTA, FOSE_QTD_REALIZADA, FOSE_SIFS_ID, FOSE_UNME_ID,
                                            FCES_CNTR_CODIGO, FCES_FCME_ID, FCES_SIGLA, FCES_WBS, FCES_NIVEL, FCES_PESO_REL_CRON
                              ) Q, 
                              EEP_CONVERSION.FOLHA_CRITERIO_MEDICAO M,
                              EEP_CONVERSION.DISCIPLINA D,
                              EEP_CONVERSION.SUB_CONTRATO SC,
                              EEP_CONVERSION.UNIDADE_PROCESSO,
                              EEP_CONVERSION.AREA_APLICACAO,
                              EEP_CONVERSION.SITUACAO_FOLHA_SERVICO SF,
                              EEP_CONVERSION.UNIDADE_MEDIDA
                        WHERE 
                              Q.FCES_NIVEL IN (
                                                SELECT X.MAX_NIVEL_CRITERIO 
                                                FROM EEP_CONVERSION.VW_MAX_NIVEL_CRITERIO_MEDICAO X 
                                                WHERE X.FCES_CNTR_CODIGO = M.FCME_CNTR_CODIGO 
                                                AND X.FCES_FCME_ID = M.FCME_ID
                                              ) AND
                              M.FCME_CNTR_CODIGO = Q.FCES_CNTR_CODIGO AND M.FCME_ID = Q.FCES_FCME_ID AND
                              D.DISC_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND D.DISC_ID(+) = Q.FOSE_DISC_ID AND
                              SC.SBCN_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND SC.SBCN_ID(+) = Q.FOSE_SBCN_ID AND
                              UNPR_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND UNPR_ID(+) = FOSE_UNPR_ID AND
                              ARAP_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND ARAP_ID(+) = FOSE_ARAP_ID AND
                              SF.SIFS_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND SF.SIFS_ID(+) = FOSE_SIFS_ID AND
                              UNME_CNTR_CODIGO(+) = Q.FOSE_CNTR_CODIGO AND UNME_ID(+) = FOSE_SIFS_ID
                        ORDER BY FOSE_NUMERO";
            dtFOSE = BLL.ElAvnFoseBLL.Select(strSQL);
            //Retorna DISTINCT das FOSE
            return dtFOSE.DefaultView.ToTable(true, "FOSE_NUMERO");
        }
    }
}
