using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;

namespace GenericClasses
{
    public class Estrutura
    {
        static DTO.ProjTubHistoryDTO H = new DTO.ProjTubHistoryDTO();
        //====================================================================
        public static DataTable CreateEstHeaderFOSE()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Coluna 1", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 3", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 5", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 6", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 7", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 8", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 9", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 10", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 11", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 12", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 13", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 14", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 15", typeof(string)));
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Número"; row["Coluna 2"] = "Revisão"; row["Coluna 3"] = "Situação"; row["Coluna 4"] = "Critério Medição"; row["Coluna 5"] = "Descrição";
            row["Coluna 6"] = "Sub Contrato"; row["Coluna 7"] = "Unidade Processo"; row["Coluna 8"] = "Área Aplicação"; row["Coluna 9"] = "Produto Fabricado"; row["Coluna 10"] = "Observação";
            row["Coluna 11"] = "Qtd. Prev."; row["Coluna 12"] = "Qtd. Real"; row["Coluna 13"] = "Unid. Medida"; row["Coluna 14"] = "UA"; row["Coluna 15"] = "Liberação Automática";
            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Texto"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Número"; row["Coluna 12"] = "Número"; row["Coluna 13"] = "Texto"; row["Coluna 14"] = "Texto"; row["Coluna 15"] = "Lógico";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'10"; row["Coluna 3"] = "'30"; row["Coluna 4"] = "'50"; row["Coluna 5"] = "'2000";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'50"; row["Coluna 9"] = "'400"; row["Coluna 10"] = "'4000";
            row["Coluna 11"] = "'22"; row["Coluna 12"] = "'22"; row["Coluna 13"] = "'10"; row["Coluna 14"] = "'100"; row["Coluna 15"] = "COD_S, COD_N";
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Obrigatório"; row["Coluna 8"] = "Opcional"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional"; row["Coluna 12"] = "Opcional"; row["Coluna 13"] = "Opcional"; row["Coluna 14"] = "Opcional"; row["Coluna 15"] = "Opcional";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único"; row["Coluna 12"] = "Não Único"; row["Coluna 13"] = "Não Único"; row["Coluna 14"] = "Não Único"; row["Coluna 15"] = "Não Único";
            dt.Rows.Add(row);

            return dt;
        }
        //====================================================================
        public static void FillDataTableFOSE(ref DataTable dtProjFOSE, string criterioSelected, string plataforma, string fileName, string unidadeProcessoEstrutura, string prefixo, string sufixo)
        {
            string strSQL = @"SELECT X.PECA, X.PESO, X.PC, X.CRITERIO, X.DESCRICAO FROM PROJ_EST_RCPT X WHERE FILE_NAME = '" + fileName + "' ORDER BY TO_NUMBER(PKG_TOOLS.FUN_PIECE(X.PECA,1, '-'))";
            //string strSQL = @"SELECT X.PECA, X.PESO, X.CRITERIO, X.DESCRICAO FROM PROJ_EST_RCPT X WHERE FILE_NAME = '" + fileName + "' ORDER BY 1";
            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE
            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PROTUGUÊS DO BRASIL
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");
            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjEstRcptBLL.Select(strSQL);
            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;
            //Insere o DataTable na Tabela PROJ_EST_FOSE excluindo o cabeçalho(6 linhas)
            for (int r = 0; r < dtAUX.Rows.Count; r++)
            {
                row = dtProjFOSE.NewRow();
                row["Coluna 1"] = prefixo + dtAUX.Rows[r]["PECA"].ToString() + sufixo;
                row["Coluna 2"] = "0";
                row["Coluna 3"] = "Liberada";
                row["Coluna 4"] = dtAUX.Rows[r]["CRITERIO"].ToString();
                row["Coluna 5"] = dtAUX.Rows[r]["DESCRICAO"].ToString();
                row["Coluna 6"] = plataforma;
                row["Coluna 7"] = unidadeProcessoEstrutura;
                row["Coluna 8"] = unidadeProcessoEstrutura;
                row["Coluna 9"] = "";
                row["Coluna 10"] = "";
                row["Coluna 11"] = "'" + (Convert.ToDecimal(dtAUX.Rows[r]["PESO"]) /1000).ToString();
                row["Coluna 12"] = "";
                row["Coluna 13"] = "Ton";
                row["Coluna 14"] = "";
                row["Coluna 15"] = "";
                dtProjFOSE.Rows.Add(row);
            }
        }
        //====================================================================
        public static DataTable CreateEstHeaderPROD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Coluna 1", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 3", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 5", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 6", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 7", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 8", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 9", typeof(string))); dt.Columns.Add(new DataColumn("Coluna 10", typeof(string)));
            dt.Columns.Add(new DataColumn("Coluna 11", typeof(string)));
            DataRow row;

            //Linha 1
            row = dt.NewRow();
            row["Coluna 1"] = "Folha de Serviço"; row["Coluna 2"] = "Tipo"; row["Coluna 3"] = "Origem"; row["Coluna 4"] = "Código Recurso"; row["Coluna 5"] = "Dim 1";
            row["Coluna 6"] = "Dim 2"; row["Coluna 7"] = "Dim 3"; row["Coluna 8"] = "Qtd. Necessária"; row["Coluna 9"] = "Etapa de Medição"; row["Coluna 10"] = "Certificado";
            row["Coluna 11"] = "UA";
            dt.Rows.Add(row);

            //Linha 2
            row = dt.NewRow();
            row["Coluna 1"] = "Texto"; row["Coluna 2"] = "Texto"; row["Coluna 3"] = "Texto"; row["Coluna 4"] = "Texto"; row["Coluna 5"] = "Texto";
            row["Coluna 6"] = "Texto"; row["Coluna 7"] = "Texto"; row["Coluna 8"] = "Número"; row["Coluna 9"] = "Texto"; row["Coluna 10"] = "Texto";
            row["Coluna 11"] = "Texto";
            dt.Rows.Add(row);

            //Linha 3
            row = dt.NewRow();
            row["Coluna 1"] = "'200"; row["Coluna 2"] = "'4000"; row["Coluna 3"] = "'4000"; row["Coluna 4"] = "'4000"; row["Coluna 5"] = "'50";
            row["Coluna 6"] = "'50"; row["Coluna 7"] = "'50"; row["Coluna 8"] = "'22"; row["Coluna 9"] = "'50"; row["Coluna 10"] = "'100";
            row["Coluna 11"] = "'100";
            dt.Rows.Add(row);

            //Linha 4
            row = dt.NewRow();
            row["Coluna 1"] = "Obrigatório"; row["Coluna 2"] = "Obrigatório"; row["Coluna 3"] = "Obrigatório"; row["Coluna 4"] = "Obrigatório"; row["Coluna 5"] = "Opcional";
            row["Coluna 6"] = "Opcional"; row["Coluna 7"] = "Opcional"; row["Coluna 8"] = "Obrigatório"; row["Coluna 9"] = "Opcional"; row["Coluna 10"] = "Opcional";
            row["Coluna 11"] = "Opcional";
            dt.Rows.Add(row);

            //Linha 5
            row = dt.NewRow();
            row["Coluna 1"] = "Não Único"; row["Coluna 2"] = "Não Único"; row["Coluna 3"] = "Não Único"; row["Coluna 4"] = "Não Único"; row["Coluna 5"] = "Não Único";
            row["Coluna 6"] = "Não Único"; row["Coluna 7"] = "Não Único"; row["Coluna 8"] = "Não Único"; row["Coluna 9"] = "Não Único"; row["Coluna 10"] = "Não Único";
            row["Coluna 11"] = "Não Único";
            dt.Rows.Add(row);
            return dt;
        }
        //====================================================================
        public static void FillDataTablePROD(ref DataTable dtProjPROD, string fileName, string prefixo, string sufixo, DataTable dtEstLM)
        {
            string strSQL = @"SELECT X.PECA, X.PC, X.PESO, X.CRITERIO, X.DESCRICAO FROM PROJ_EST_RCPT X WHERE FILE_NAME = '" + fileName + "' ORDER BY TO_NUMBER(PKG_TOOLS.FUN_PIECE(X.PECA,1, '-'))";
            //Insere as linhas de conteudo agrupado no DataTable dtProjFOSE

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA PROTUGUÊS DO BRASIL
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='BRAZIL'");
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_language='BRAZILIAN PORTUGUESE'");

            //Obtem DataTable de complemento
            DataTable dtAUX = BLL.ProjEstRcptBLL.Select(strSQL);

            //TRATA GLOBALIZAÇÃO NO ORACLE PARA INGLÊS AMERICANO
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_territory='AMERICA'");
            BLL.ProjEstRcptBLL.ExecuteSQLInstruction("alter session set nls_language='AMERICAN'");

            DataRow row;

            //Insere o DataTable na Tabela PROJ_TUB_FOSE excluindo o cabeçalho(6 linhas)
            try
            {
                for (int r = 0; r < dtAUX.Rows.Count; r++)
                {
                    string produto, dimension = "";
                    string dim1 = "";
                    string dim2 = "";
                    string dim3 = "";
                    string grau = "";
                    string medidas = "";
                    string pc = dtAUX.Rows[r]["PC"].ToString().Trim();
                    dimension = BLL.ProjEstPcDimensionBLL.GetObject("PC = '" + pc + "'").Dimension.Replace("mm.", "|");
                    medidas = dimension.Split('|')[0];
                    grau = dimension.Split('|')[1];
                    dim1 = medidas.Split('x')[0];
                    dim2 = medidas.Split('x')[1];
                    dim3 = medidas.Split('x')[2];

                    produto = BLL.ProjEstPcDimensionBLL.GetCodigoProduto(dim1, dim2, dim3, grau).ToString().Trim();
                    //produto = GetCodigoProduto(dtEstLM, dtAUX.Rows[r]["PC"].ToString().Trim());
                    row = dtProjPROD.NewRow();
                    row["Coluna 1"] = prefixo + dtAUX.Rows[r]["PECA"].ToString() + sufixo;
                    row["Coluna 2"] = "Produto Consumido";
                    row["Coluna 3"] = "Material";
                    row["Coluna 4"] = produto;
                    row["Coluna 5"] = dim1;
                    row["Coluna 6"] = dim2;
                    row["Coluna 7"] = dim3;
                    row["Coluna 8"] = dtAUX.Rows[r]["PESO"].ToString();
                    row["Coluna 9"] = "";
                    row["Coluna 10"] = "";
                    row["Coluna 11"] = "";
                    dtProjPROD.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //============================================
        public static void SaveProjPcDimension(StreamWriter log, DataTable dtEstLM, string fileName)
        {
            int c = 0;
            string pc, dimension;
            string filter = "";
            //Gravar tabela PROJ_EST_DIMENSION
            for (int i = 0; i < dtEstLM.Rows.Count; i++)
            {
                pc = dtEstLM.Rows[i]["PC"].ToString().Replace(" ", "");
                dimension = dtEstLM.Rows[i]["DIMENSION"].ToString().Replace(" ", "");
                //strSQL = @"SELECT COUNT(*) FROM PROJ_EST_DIMENSION WHERE PC = '" + pc + "' AND DIMENSION = '" + dimension + "'";
                filter = @"PC = '" + pc + "' AND DIMENSION = '" + dimension + "'";
                c = BLL.ProjEstPcDimensionBLL.Count(filter);

                //Grava LM no Banco de Dados referente a disciplina Estrutura
                DTO.ProjEstPcDimensionDTO entity = new DTO.ProjEstPcDimensionDTO();
                entity.PC = pc;
                entity.Dimension = dimension;
                entity.FileName = fileName;
                try
                {
                    if(c == 0) BLL.ProjEstPcDimensionBLL.Insert(entity, false);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            //GenericClasses.Log.SaveLog(log, "A planilha " + fileName + " foi incorporada ao banco de dados ");
        }
        //============================================
        public static void SaveProjEstRcpt(DataTable dtProjRcpt, string disciplina, string userId, string fileName, StreamWriter log)
        {
            string strSQL = "DELETE FROM PROJ_EST_RCPT WHERE file_name = '" + fileName + "'";
            BLL.ProjOutRcptBLL.ExecuteSQLInstruction(strSQL);
            //Gravar tabela PROJ_EST_RCPT
            for (int i = 0; i < dtProjRcpt.Rows.Count; i++)
            {
                //int c = 0;
                //Grava Recepcao no Banco de Dados referente a disciplina Tubulacao
                DTO.ProjEstRcptDTO entity = new DTO.ProjEstRcptDTO();
                entity.Peca = dtProjRcpt.Rows[i]["PECA"].ToString().Trim();
                entity.PC = dtProjRcpt.Rows[i]["PC"].ToString().Trim();
                entity.Peso = dtProjRcpt.Rows[i]["PESO"].ToString().Trim();
                entity.Criterio = dtProjRcpt.Rows[i]["CRITERIO"].ToString().Trim();
                entity.Descricao = dtProjRcpt.Rows[i]["DESCRICAO"].ToString().Trim();
                entity.CreatedBy = userId;
                entity.CreatedDate = System.DateTime.Now;
                entity.ModifiedBy = userId;
                entity.ModifiedDate = System.DateTime.Now;
                entity.FileName = fileName;
                try
                {
                    BLL.ProjEstRcptBLL.Insert(entity, false);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            H.ProcessHistory = "A planilha " + fileName + " foi incorporada ao banco de dados ";
            GenericClasses.Log.SaveLog(log, H);
        }
        //============================================
        public static bool VerificaExistenciaCamposObrigatoriosEst(StreamWriter log, DataTable dtSpreadsheet)
        {
            bool bRet = true;
            try
            {
                for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
                {
                    if (dtSpreadsheet.Rows[i]["PECA"].ToString().Trim() == "") 
                    {
                        H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna PECA - em branco"; GenericClasses.Log.SaveLog(log, H); 
                        bRet = false; 
                    }
                    if (dtSpreadsheet.Rows[i]["PC"].ToString().Trim() == "") 
                    {
                        H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna PC - em branco";
                        GenericClasses.Log.SaveLog(log, H); 
                        bRet = false; 
                    }
                    if (dtSpreadsheet.Rows[i]["PESO"].ToString().Trim() == "") 
                    {
                        H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna PESO - em branco";
                        GenericClasses.Log.SaveLog(log, H); 
                        bRet = false; 
                    }
                    if (dtSpreadsheet.Rows[i]["CRITERIO"].ToString().Trim() == "") 
                    {
                        H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna CRITERIO - em branco";
                        GenericClasses.Log.SaveLog(log, H); bRet = false; }
                    if (dtSpreadsheet.Rows[i]["DESCRICAO"].ToString().Trim() == "") 
                    {
                        H.ProcessHistory = "Linha " + (i + 1).ToString() + " ==>  Coluna MEDICAO - em branco";
                        GenericClasses.Log.SaveLog(log, H); 
                        bRet = false; 
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return bRet;
        }
    }
}