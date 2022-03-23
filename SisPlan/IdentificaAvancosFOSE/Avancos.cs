using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace IdentificaAvancosFOSE
{
    public class Avancos
    {
        static string discNome = "";
        static string strSQL = "";
        static DataTable dtDisc = null;
        static DataTable dtFOSE = null;
        static string foseId = "";
        //========================================================================================
        static public void Coleta(string contrato, string discId, string dataInicial)
        {
            //Get Nome Disciplina
            strSQL = @"SELECT DISC_NOME FROM EEP_CONVERSION.DISCIPLINA WHERE DISC_CNTR_CODIGO = '" + contrato + "' AND DISC_ID = " + discId;
            dtDisc = BLL.ElAvnFoseBLL.Select(strSQL);
            discNome = dtDisc.Rows[0]["DISC_NOME"].ToString();

            //Carrega a lista das FOSE movimentadas no período
            dtFOSE = Queries.GetFOSE(contrato, discId, dataInicial);
            //Carrega os avanços da FOSE
            DataTable dtAvancosFOSE = Queries.GetAvancosFOSE(contrato, discId, dataInicial);
            for (int i = 0; i < dtFOSE.Rows.Count; i++)
            {
                try
                {
                    string foseNumero = dtFOSE.Rows[i]["FOSE_NUMERO"].ToString();
                    DTO.ElAvnFoseDTO f = new DTO.ElAvnFoseDTO();
                    DataRow[] r = dtAvancosFOSE.Select("FOSE_NUMERO = '" + foseNumero + "'", "FCES_WBS");
                    int countRows = r.Count();
                    for (int L = 0; L < countRows; L++)
                    {
                        try
                        {
                            f.Active = 1;
                            f.TipoLinha = 200;
                            f.DiscId = Convert.ToDecimal(discId);
                            f.FoseCntrCodigo = contrato;
                            f.DiscNome = r[L]["DISC_NOME"].ToString();
                            f.AtivSig = r[L]["ATIV_SIG"].ToString();
                            f.SifsDescricao = r[L]["SIFS_DESCRICAO"].ToString();
                            f.SbcnSigla = r[L]["SBCN_NOME"].ToString();
                            f.UnprNome = r[L]["UNPR_SIGLA"].ToString();
                            f.ArapNome = r[L]["ARAP_SIGLA"].ToString();
                            f.FoseNumero = r[L]["FOSE_NUMERO"].ToString();
                            f.FcmeSigla = r[L]["FCME_SIGLA"].ToString();
                            f.Pasta = r[L]["PASTA"].ToString();
                            f.Desenho = r[L]["DESENHO"].ToString();
                            f.Tipo = r[L]["TIPO"].ToString();
                            f.Setor = r[L]["SETOR"].ToString();
                            //Complementos
                            f.AtivSig = r[L]["ATIV_SIG"].ToString();
                            f.FoseQtdPrevista = Convert.ToDecimal(r[L]["FOSE_QTD_PREVISTA"]);
                            
                            f.UnmeSigla = r[L]["UNME_NOME"].ToString();

                            f.FosmId = Convert.ToDecimal(r[L]["FOSM_ID"]);
                            f.FoseCntrCodigo = r[L]["FOSE_CNTR_CODIGO"].ToString();
                            f.DiscId = Convert.ToDecimal(r[L]["DISC_ID"]);
                            f.FoseId = Convert.ToDecimal(r[L]["FOSE_ID"]);

                            f.FcmeId = Convert.ToDecimal(r[L]["FCES_FCME_ID"]);
                            f.FcesNivel = Convert.ToDecimal(r[L]["FCES_NIVEL"]);

                            #region Elementos do Criterio
                            switch (L + 1)
                            {
                                case 1:
                                    {
                                        f.El01FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El01FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El01FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El01FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El01FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 2:
                                    {
                                        f.El02FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El02FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El02FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El02FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El02FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 3:
                                    {
                                        f.El03FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El03FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El03FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El03FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El03FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 4:
                                    {
                                        f.El04FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El04FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El04FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El04FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El04FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 5:
                                    {
                                        f.El05FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El05FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El05FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El05FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El05FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 6:
                                    {
                                        f.El06FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El06FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El06FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El06FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El06FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 7:
                                    {
                                        f.El07FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El07FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El07FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El07FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El07FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 8:
                                    {
                                        f.El08FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El08FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El08FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El08FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El08FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 9:
                                    {
                                        f.El09FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El09FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El09FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El09FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El09FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 10:
                                    {
                                        f.El10FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El10FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El10FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El10FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El10FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 11:
                                    {
                                        f.El11FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El11FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El11FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El11FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El11FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                                case 12:
                                    {
                                        f.El12FcesSigla = r[L]["FCES_SIGLA"].ToString();
                                        if (r[L]["FSMP_DATA"] != System.DBNull.Value) f.El12FsmpData = Convert.ToDateTime(r[L]["FSMP_DATA"]);
                                        if (r[L]["FSME_DATA"] != System.DBNull.Value) f.El12FsmeData = Convert.ToDateTime(r[L]["FSME_DATA"]);
                                        if (r[L]["FSME_AVANCO_ACM"] != System.DBNull.Value) f.El12FsmeAvancoAcm = Convert.ToDecimal(r[L]["FSME_AVANCO_ACM"]);
                                        if (r[L]["FSME_QTD_ACM"] != System.DBNull.Value) f.El12FsmeQtdAcm = Convert.ToDecimal(r[L]["FSME_QTD_ACM"]);
                                        break;
                                    }
                            }
                            #endregion

                            //SAVE
                            SaveFOSE(f);
                        }
                        catch (Exception ex) { throw new Exception(ex.Message); }
                    }
                    f = null;
                }
                catch (Exception ex) {throw new Exception(ex.Message);}
            }
        }
        //========================================================================================
        private static void SaveFOSE(DTO.ElAvnFoseDTO f)
        {
            try
            {
                DTO.CollectionElAvnFoseDTO colAvn = new DTO.CollectionElAvnFoseDTO();
                colAvn = BLL.ElAvnFoseBLL.GetCollection("FOSE_NUMERO = '" + f.FoseNumero + "'");
                if (colAvn.Count == 0)
                {
                    //Obtém PK - ElAvnFose
                    strSQL = @"SELECT EEP_CONVERSION.EL_AVN_FOSE_SEQ.NEXTVAL FROM DUAL";
                    DataTable dtPK = BLL.ElAvnFoseBLL.Select(strSQL);
                    f.ID = Convert.ToDecimal(dtPK.Rows[0]["NEXTVAL"]);

                    //Insere registro da FOSE com dados básicos
                    BLL.ElAvnFoseBLL.Insert(f, false);
                }
                else
                {
                    f.ID = Convert.ToDecimal(colAvn[0].ID);
                    //Insere registro da FOSE com dados básicos
                    BLL.ElAvnFoseBLL.Update(f);
                }
                colAvn = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        //========================================================================================
    }
}
