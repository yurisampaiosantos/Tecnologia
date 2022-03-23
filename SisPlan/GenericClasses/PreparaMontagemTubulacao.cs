using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.IO;
using System.Windows.Forms;

namespace GenericClasses
{
    public class PreparaMontagemTubulacao
    {
        static string strSQL = "";
        static DataTable dtSpoolsMontagem = null;
        public static void GeraHistoricoSpool(string contrato)
        {
            strSQL = @"DELETE FROM EEP_CONVERSION.AC_MONTAGEM_TUBULACAO";
            BLL.AcMontagemTubulacaoBLL.ExecuteSQLInstruction(strSQL);
            strSQL = @"   SELECT FOSE_ID, FOSE_NUMERO, SIFS_DESCRICAO, SPOOL, ISOMETRICO
                            FROM 
                            (
                                SELECT FOSE_ID, FOSE_NUMERO, SIFS_DESCRICAO, 
                                        --INSTR(FOSE_NUMERO, '.', 2, 2) AS POS,
                                        CASE 
                                            WHEN INSTR(FOSE_NUMERO, '.', 2, 2) > 2 THEN SUBSTR(FOSE_NUMERO,1, INSTR(FOSE_NUMERO, '.', 2, 2) - 1)
                                            ELSE EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(FOSE_NUMERO, 1, '.')
                                        END AS SPOOL,
                                        CASE
                                            WHEN INSTR(FOSE_NUMERO, '.', 2, 2) > 2 THEN SUBSTR(FOSE_NUMERO, INSTR(FOSE_NUMERO, '.', 2, 2) + 1)
                                            ELSE EEP_CONVERSION.PKG_TOOLS.FUN_PIECE(FOSE_NUMERO, 2, '.')
                                        END AS ISOMETRICO
                                FROM EEP_CONVERSION.FOLHA_SERVICO, EEP_CONVERSION.SITUACAO_FOLHA_SERVICO
                                WHERE FOSE_CNTR_CODIGO = 'Conversão' AND FOSE_DISC_ID = 5 AND FOSE_FCME_ID NOT IN (36, 37,40) AND FOSE_NUMERO LIKE '%.%' AND FOSE_NUMERO NOT LIKE '%Spool Mont%'
                                    AND SIFS_CNTR_CODIGO = FOSE_CNTR_CODIGO AND SIFS_ID = FOSE_SIFS_ID
                                ORDER BY FOSE_NUMERO
                            )
                            WHERE LENGTH(ISOMETRICO) <= 17";
            dtSpoolsMontagem = BLL.AcMontagemTubulacaoBLL.Select(strSQL);
            //Carrega a Tabela EEP_CONVERSION.AC_MONTAGEM_TUBULACAO
            for (int i = 0; i < dtSpoolsMontagem.Rows.Count; i++)
            {
                DTO.AcMontagemTubulacaoDTO m = new DTO.AcMontagemTubulacaoDTO();
                m.MotuSpool = dtSpoolsMontagem.Rows[i]["SPOOL"].ToString();
                m.MotuIsometrico = dtSpoolsMontagem.Rows[i]["ISOMETRICO"].ToString();
                m.MotuSifsDescricao = dtSpoolsMontagem.Rows[i]["SIFS_DESCRICAO"].ToString();
                BLL.AcMontagemTubulacaoBLL.Insert(m, false);
            }
        }
    }
}