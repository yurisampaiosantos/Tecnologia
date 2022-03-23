using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;

namespace IdentificaAcuracidade
{
    class ColetaAcuracidade
    {
        static string contrato = "Conversão";
        static string filterAcuracidade = "";
        static string strSQL = "";
        static void Main(string[] args)
        {
            DTO.AcSemanaDTO s = new DTO.AcSemanaDTO();
            s = BLL.AcSemanaBLL.GetSemanaAnteriorCorrente();
            GerarAcuracidadePeriodo(contrato, s.SemaDataInicio.ToString("dd/MM/yyyy"), s.SemaDataFim.ToString("dd/MM/yyyy"));
            filterAcuracidade = @"ACUR_MAX_FSMP_DATA IS NULL";
            DTO.CollectionAcAcuracidadeDTO cp = new DTO.CollectionAcAcuracidadeDTO();
            DataTable dtRescue = BLL.AcAcuracidadeBLL.Get(filterAcuracidade);
            cp = BLL.AcAcuracidadeBLL.GetCollection(dtRescue);
            for (int p = 0; p < cp.Count; p++)
            {
                //Resgata o maior avanço de programação para essa FOSE
                GenericClasses.FolhaServico.GetMaxAvnProgFose(cp[p]);
            }
        }
        //================================================================================================
        static void GerarAcuracidadePeriodo(string contrato, string dtInicial, string dtFinal)
        {
            try
            {
                strSQL = @"SELECT DISTINCT SBCN_SIGLA, TIPO_AVANCO, MAX(DATA_AVANCO) AS DATA_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
                              TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE, 
                              FOSM_ID, MAX(PERCENTUAL_AVANCO) AS PERCENTUAL_AVANCO, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, MAX(QTD_AVANCO_REAL) AS QTD_AVANCO_REAL,
                              FOSM_FOSE_ID, FOSM_FCES_ID, FCES_FCME_ID, FCME_ID
                        FROM (
                              SELECT SBCN_SIGLA, TIPO_AVANCO, DATA_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
                                     TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE,
                                     FOSM_ID, PERCENTUAL_AVANCO, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, QTD_AVANCO_REAL,
                                     FOSM_FOSE_ID, FOSM_FCES_ID, FCES_FCME_ID, FCME_ID 
                                FROM EEP_CONVERSION.VW_AC_ACURACIDADE)
                     ";
                strSQL += @" WHERE DATA_AVANCO BETWEEN TO_DATE('" + dtInicial + @"','DD/MM/YYYY') 
                             AND TO_DATE('" + dtFinal + "','DD/MM/YYYY')";

                //strSQL += @" AND FOSE_NUMERO = 'BSMF40" + Convert.ToChar(34) + "-CO-USM028'";
                
                //strSQL += @" AND FOSE_NUMERO = 'M-ANT-TQ2S22-03R'";

                strSQL += @" GROUP BY SBCN_SIGLA, TIPO_AVANCO, FOSE_DISC_ID, DISC_NOME, FCME_SIGLA, FCES_SIGLA, FCES_WBS, FOSE_NUMERO, 
                                  TSTF_UNIDADE_REGIONAL, REGIAO, LOCALIZACAO, EQUIPE, 
                                  FOSM_ID, FOSE_QTD_PREVISTA, FCES_PESO_REL_CRON, QTD_AVANCO_POND, UNME_SIGLA, FOSM_FOSE_ID, FOSM_FCES_ID, FCES_FCME_ID, FCME_ID 
                         ORDER BY SBCN_SIGLA, FOSE_NUMERO,TIPO_AVANCO, FCES_WBS, DATA_AVANCO";
                DataTable dtVwAcAcuracidade = BLL.VwAcAcuracidadeBLL.Select(strSQL);

                DTO.CollectionVwAcAcuracidadeDTO col = new DTO.CollectionVwAcAcuracidadeDTO();
                col = BLL.VwAcAcuracidadeBLL.GetCollection(dtVwAcAcuracidade);

                //BLL.AcAcuracidadeBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_ACURACIDADE WHERE ACUR_MAX_FSMP_DATA BETWEEN TO_DATE('" + dtInicial + "','DD/MM/YYYY') AND TO_DATE('" + dtFinal + "','DD/MM/YYYY')");
                BLL.AcAcuracidadeBLL.ExecuteSQLInstruction("DELETE EEP_CONVERSION.AC_ACURACIDADE");
                BLL.AcAcuracidadeBLL.ExecuteSQLInstruction("COMMIT");

                if (col.Count > 0)
                {
                    FeedAcuracidade(col); 
                    col = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
        //================================================================================================
        private static void FeedAcuracidade(DTO.CollectionVwAcAcuracidadeDTO col)
        {
            filterAcuracidade = "";
            DTO.CollectionAcAcuracidadeDTO ca = new DTO.CollectionAcAcuracidadeDTO();
            try
            {
                for (int i = 0; i < col.Count; i++)
                {
                    DTO.AcAcuracidadeDTO a = new DTO.AcAcuracidadeDTO();
                    a.AcurSbcnSigla = col[i].SbcnSigla;
                    a.AcurDiscId = col[i].FoseDiscId;
                    a.AcurDiscNome = col[i].DiscNome;
                    a.AcurFcmeId = col[i].FcmeId;
                    a.AcurFcmeSigla = col[i].FcmeSigla;
                    a.AcurFcesId = col[i].FosmFcesId;
                    a.AcurFcesSigla = col[i].FcesSigla;
                    a.AcurFcesWbs = col[i].FcesWbs;
                    a.AcurFoseId = col[i].FosmFoseId;
                    a.AcurFoseNumero = col[i].FoseNumero;
                    a.AcurUnmeSigla = col[i].UnmeSigla;
                    a.AcurTstfUnidadeRegional = col[i].TstfUnidadeRegional;
                    a.AcurRegiao = col[i].Regiao;
                    a.AcurLocalizacao = col[i].Localizacao;
                    a.AcurEquipe = col[i].Equipe;
                    a.AcurQtdPrevista = col[i].FoseQtdPrevista;
                    a.AcurFcesPesoRelCron = col[i].FcesPesoRelCron;
                    a.AcurFsmpFosmId = col[i].FosmId;

                    //if (a.AcurFoseNumero == "M-6S38-02R")
                    //{
                    //    string x = "";
                    //}

                    filterAcuracidade = @"ACUR_FOSE_ID = " + col[i].FosmFoseId.ToString() + " AND ACUR_FCES_SIGLA = '" + col[i].FcesSigla + "'";
                    ca = BLL.AcAcuracidadeBLL.GetCollection(filterAcuracidade);
                    switch (col[i].TipoAvanco)
                    {
                        case "P":
                            {

                                if (ca.Count == 0)
                                {
                                    try
                                    {
                                        a.AcurFsmpAvancoAcm = col[i].PercentualAvanco;
                                        a.AcurMaxFsmpData = col[i].DataAvanco;
                                        a.AcurQtdProg = col[i].QtdAvancoReal;
                                        a.AcurQtdAvancoProgPond = col[i].QtdAvancoPond;
                                        BLL.AcAcuracidadeBLL.Insert(a, false);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message);
                                    }  
                                }
                                else
                                {
                                    try
                                    {
                                        a = ca[0];
                                        a.AcurFsmpAvancoAcm = col[i].PercentualAvanco;
                                        a.AcurMaxFsmpData = col[i].DataAvanco;
                                        a.AcurQtdProg = col[i].QtdAvancoReal;
                                        a.AcurQtdAvancoProgPond = col[i].QtdAvancoPond;
                                        BLL.AcAcuracidadeBLL.Update(a);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message);
                                    }  
                                }
                                break;
                            }
                        case "X":
                            {
                                //a.AcurFsmeFosmId = col[i].FosmId;
                                //a.AcurFsmeAvancoAcm = col[i].PercentualAvanco;
                                //a.AcurMaxFsmeData = col[i].DataAvanco;
                                //a.AcurQtdExec = col[i].QtdAvancoReal;
                                //a.AcurQtdAvancoExecPond = col[i].QtdAvancoPond;
                                //if (a.AcurFoseId == 97448)
                                //{
                                //    string x = "";
                                //}
                                //filterAcuracidade = @"ACUR_MAX_FSMP_DATA IS NOT NULL AND ACUR_FOSE_ID = " + col[i].FosmFoseId.ToString() + " AND ACUR_TIPO_AVANCO = 'P' AND ACUR_FCES_SIGLA = '" + col[i].FcesSigla + "'";
                                //M-1P-82-01R

                                filterAcuracidade = @"ACUR_FOSE_ID = " + col[i].FosmFoseId.ToString() + " AND ACUR_FCES_SIGLA = '" + col[i].FcesSigla + "'";
                                ca = BLL.AcAcuracidadeBLL.GetCollection(filterAcuracidade);
                                if (ca.Count == 0)
                                {
                                    try
                                    {
                                        //insere registro de execução sem avanco de programação
                                        a.AcurFsmeFosmId = col[i].FosmId;
                                        a.AcurFsmeAvancoAcm = col[i].PercentualAvanco;
                                        a.AcurMaxFsmeData = col[i].DataAvanco;
                                        a.AcurQtdExec = col[i].QtdAvancoReal;
                                        a.AcurQtdAvancoExecPond = col[i].QtdAvancoPond;

                                        BLL.AcAcuracidadeBLL.Insert(a, false);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message);
                                    }  
                                }
                                else
                                {
                                    try
                                    {
                                        a = ca[0];
                                        a.AcurFsmeFosmId = col[i].FosmId;
                                        a.AcurFsmeAvancoAcm = col[i].PercentualAvanco;
                                        a.AcurMaxFsmeData = col[i].DataAvanco;
                                        a.AcurQtdExec = col[i].QtdAvancoReal;
                                        a.AcurQtdAvancoExecPond = col[i].QtdAvancoPond;
                                        BLL.AcAcuracidadeBLL.Update(a);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception(ex.Message);
                                    }  
                                }
                                break;
                            }
                    }
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }
        //================================================================================================
    }
}
