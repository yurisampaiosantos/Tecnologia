using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using System.Threading;

using System.Windows.Forms;



namespace GenericClasses
{
    public class SpreadSheets
    {
        static string spool = "";
        //============================================
        public static List<String> GetSheetNames(OleDbConnection conn)
        {
            conn.Open();
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            List<String> Lista = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                Lista.Add(row["TABLE_NAME"].ToString());
            }
            conn.Close();
            return Lista;
        }
        //============================================
        public static DataTable SpreadSheetReception(string connStr, string strSQL, string disciplina, string userId, string fileName)
        {
            try
            {
                DataTable dtRcpt = null;
                OleDbConnection conn = new OleDbConnection(connStr);
                List<string> planilhas = GetSheetNames(conn);
                OleDbCommand cmd = new OleDbCommand(strSQL, conn);
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                dtRcpt = ds.Tables[0];
                ClearDataTableBlankLines(ref dtRcpt);
                return dtRcpt;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        private static void ClearDataTableBlankLines(ref DataTable dtRcpt)
        {
            try
            {
                bool isEmpty = true;
                for (int i = 0; i < dtRcpt.Rows.Count; i++)
                {
                    isEmpty = true;

                    for (int j = 0; j < dtRcpt.Columns.Count; j++)
                    {
                        if (string.IsNullOrEmpty(dtRcpt.Rows[i][j].ToString()) == false)
                        {
                            isEmpty = false;
                            break;
                        }
                    }

                    if (isEmpty == true)
                    {
                        dtRcpt.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //============================================
        public static bool IsValidEstSpreadsheet(DataTable dtSpreadsheet, string fileName, string logFolder, StreamWriter log, string worksheetDisciplina)
        {
            bool bRet = true;
            string header = "";
            int numCol;
            switch (worksheetDisciplina)
            {
                case "LM$":
                    {
                        //Valida estrutura da planilha LM
                        string[] columns = { "DIMENSION", "PC" };
                        numCol = columns.Length;
                        for (int c = 0; c < columns.Length; c++)
                        {
                            header += "|" + columns[c];
                        }
                        header = header.Substring(1);
                        for (int i = 0; i < columns.Length - 1; i++)
                        {
                            if (dtSpreadsheet.Columns[i].ColumnName.ToUpper() != columns[i].ToUpper())
                            {
                                GenericClasses.Log.SaveLog(log, "A estrutura da planilha LM deve obedecer a estrutura abaixo: " + Convert.ToChar(13) + Convert.ToChar(10));
                                GenericClasses.Log.SaveLog(log, header);
                                bRet = false;
                                break;
                            }
                        }
                        for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
                        {
                            string dim = dtSpreadsheet.Rows[i]["DIMENSION"].ToString().Trim();
                            if (dim == "") { GenericClasses.Log.SaveLog(log, "Linha " + (i + 1).ToString() + " ==>  Coluna DIMENSION - em branco"); bRet = false; }
                            if (dim.IndexOf("mm.") < 0)
                            {
                                GenericClasses.Log.SaveLog(log, "Linha " + (i + 1).ToString() + " ==>  Coluna DIMENSION - Falta mm.");
                                bRet = false;
                                break;
                            }
                            if (dim.IndexOf("..") >= 0)
                            {
                                GenericClasses.Log.SaveLog(log, "Linha " + (i + 1).ToString() + " ==>  Coluna DIMENSION fora de padrão");
                                bRet = false;
                                break;
                            }
                        }
                        break;
                    }
                case "LP$":
                    {
                        //Valida estrutura da planilha LP
                        string[] columns = { "PECA", "PC", "PESO", "CRITERIO", "DESCRICAO" };
                        numCol = columns.Length;
                        for (int c = 0; c < columns.Length; c++)
                        {
                            header += "|" + columns[c];
                        }
                        header = header.Substring(1);
                        for (int i = 0; i < columns.Length - 1; i++)
                        {
                            if (dtSpreadsheet.Columns[i].ColumnName.ToUpper() != columns[i].ToUpper())
                            {
                                GenericClasses.Log.SaveLog(log, "A estrutura da planilha LP deve obedecer a estrutura abaixo: " + Convert.ToChar(13) + Convert.ToChar(10));
                                GenericClasses.Log.SaveLog(log, header);
                                bRet = false;
                                break;
                            }
                        }
                        break;
                    }
            }
            //if (worksheetDisciplina == "LP$")
            //{
            //    if (bRet) bRet = GenericClasses.Estrutura.VerificaExistenciaCamposObrigatoriosEst(log, dtSpreadsheet);
            //    //Fim
            //    if (bRet) GenericClasses.Log.SaveLog(log, "A Planilha atendeu aos requisitos básicos para ser processada.");
            //    GenericClasses.Log.SaveLog(log, "Término da Validação da planilha                                          : " + System.DateTime.Now);
            //}
            return bRet;
        }

        ////============================================
        //public static bool GetCodigoProduto(StreamWriter log, DataTable dtSpreadsheet, string colunaProduto, string disciplina)
        //{
        //    bool bRet = true;
        //    string strSQL = "";
        //    string codProduto = "";
        //    DataTable dt = null;
        //    /*
        //     SELECT DIPC_CNTR_CODIGO, DIPC_CODIGO, DIPR_ID, DIPR_PESO, DIPI_DESCRICAO_RES, DIPU_CODIGO
        //        --CASE WHEN COUNT(*) > 0 THEN 'SIM' ELSE 'NÃO' END AS CODIGO_VALIDO
        //        FROM EPCCQ.DICIONARIO_PRODUTO_COMPOSTO, EPCCQ.DICIONARIO_PRODUTO, EPCCQ.DICIONARIO_PRODUTO_IDIOMA, EPCCQ.DICIONARIO_PRODUTO_UNICO
        //         WHERE DIPC_CNTR_CODIGO = 'Conversão' --AND DIPC_CODIGO = '5.04.01.016.03.08.10'
        //         AND DIPR_CNTR_CODIGO = DIPC_CNTR_CODIGO AND DIPR_ID = DIPC_DIPR_ID
        //         AND DIPR_CNTR_CODIGO = DIPI_CNTR_CODIGO AND DIPR_ID = DIPI_DIPR_ID
        //         AND DIPR_CNTR_CODIGO = DIPU_CNTR_CODIGO(+) AND DIPR_ID = DIPU_DIPR_ID(+);
        //     */
        //    for (int i = 0; i < dtSpreadsheet.Rows.Count; i++)
        //    {
        //        codProduto = dtSpreadsheet.Rows[i][colunaProduto].ToString().Trim();
        //        // Valida material no dicionário SISEPC
        //        if (codProduto != "")
        //        {
        //            //============================================================
        //            //============================================================
        //            //string strConn = @"Data Source=LCHLRAC-scan.eepsa.com.br:1521/EEPCONV;User Id=eep_conversion;Password=EEPCONVeep_conversion2013;PERSIST SECURITY INFO=True;";

        //            //internal static string StandardConnection = @"Data Source=LCHLRAC-SCAN.eepsa.com.br:1521/EEPCORP.eepsa.com.br;User Id=F_GL_CONVERSION ;Password=estaleiroSAF_GL_CONVERSION2013;PERSIST SECURITY INFO=True;";
        //            string strConn = @"Data Source=LCHLRAC-scan.eepsa.com.br:1521/EEPCONV;User Id=EPCCQ;Password=EPCCQ;PERSIST SECURITY INFO=True;";
        //            strSQL = @"SELECT COUNT(*) FROM DICIONARIO_PRODUTO_COMPOSTO WHERE DIPC_CNTR_CODIGO = 'Conversão' AND DIPC_CODIGO = '" + codProduto + "'";
        //            //dt = BLL.ProjOutRcptBLL.Select(strSQL);

        //            try
        //            {
        //                DataSet ds = new DataSet();
        //                Oracle.DataAccess.Client.OracleDataAdapter adap = new Oracle.DataAccess.Client.OracleDataAdapter();
        //                using (Oracle.DataAccess.Client.OracleConnection conn = new Oracle.DataAccess.Client.OracleConnection(strConn))
        //                {
        //                    conn.Open();
        //                    Oracle.DataAccess.Client.OracleCommand cmd = new Oracle.DataAccess.Client.OracleCommand(strSQL, conn);
        //                    adap.SelectCommand = cmd;
        //                    adap.Fill(ds);
        //                    conn.Close();
        //                }
        //                dt = ds.Tables[0];
        //            }
        //            catch (Exception ex) { throw new Exception(ex.Message); }
        //            //============================================================
        //            //============================================================

        //            if (Convert.ToInt32(dt.Rows[0][0]) == 0)
        //            {
        //                string msg = "";
        //                switch (disciplina)
        //                {
        //                    case "Tubulacao":
        //                        {
        //                            msg = "Linha " + (i + 2).ToString() + " ==>  Coluna CLIENT_CC - Material inválido: " + codProduto;
        //                            msg += " | Contractor_CC: " + dtSpreadsheet.Rows[i]["Contractor_CC"].ToString().Trim();
        //                            msg += " | Short_Desc: " + dtSpreadsheet.Rows[i]["Short_Desc"].ToString().Trim();
        //                            msg += " | Pipeline: " + dtSpreadsheet.Rows[i]["Pipeline"].ToString().Trim();
        //                            msg += " | PartDiam1: " + dtSpreadsheet.Rows[i]["PartDiam1"].ToString().Trim();
        //                            msg += " | PartDiam2: " + dtSpreadsheet.Rows[i]["PartDiam2"].ToString().Trim();
        //                            break;
        //                        }
        //                    case "Eletrica":
        //                        {
        //                            msg = "Linha " + (i + 2).ToString() + " ==>  Coluna CODIGO - Material inválido: " + codProduto;
        //                            msg += " | DESCRICAO: " + dtSpreadsheet.Rows[i]["DESCRICAO"].ToString().Trim();
        //                            msg += " | DIMENSAO: " + dtSpreadsheet.Rows[i]["DIMENSAO"].ToString().Trim();
        //                            msg += " | TAG: " + dtSpreadsheet.Rows[i]["TAG"].ToString().Trim();
        //                            break;
        //                        }
        //                    default:
        //                        break;
        //                }
        //                GenericClasses.Log.SaveLog(log, msg);
        //                bRet = false;
        //            }
        //        }
        //    }
        //    return bRet;
        //}

        //============================================

        //============================================

        //============================================
        #region SpreadSheetIO
        //============================================
        public static void CreateSpreadSheetXLSX(System.Windows.Forms.DataGridView grv, string fileFullName)
        {
            try
            {
                Excel.Application App; // Aplicação Excel
            Excel.Workbook WorkBook; // Pasta
            Excel.Worksheet WorkSheet; // Planilha
            object misValue = System.Reflection.Missing.Value;
 
            App = new Excel.Application();
            WorkBook = App.Workbooks.Add(misValue);
            WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
            //int i = 0;
            //int j = 0;
 
            // storing header part in Excel
            for(int i = 1; i < grv.Columns.Count + 1; i++)
            {
                 WorkSheet.Cells[1, i] = grv.Columns[i-1].HeaderText;
            }
            // passa as celulas do DataGridView para a Pasta do Excel
            for (int i = 0; i < grv.RowCount -1; i++)
            {
                for (int j = 0; j < grv.ColumnCount; j++)
                {
                    WorkSheet.Cells[i + 2, j + 1] = grv.Rows[i].Cells[j].Value;
                }
            }
 
            // salva o arquivo
            //WorkBook.SaveAs(@"D:\Paulo.Almeida\Área de Trabalho\TESTE.xlsx", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            WorkBook.SaveAs(fileFullName);
            WorkBook.Close(true, misValue, misValue);
            App.Quit(); // encerra o excel
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        public static void CreateSpreadSheet(DataTable dtSaida, string fileFullName)
        {
            try
            {
                Excel.Application oXL;
                Excel.Workbook oWB;
                Excel.Worksheet oSheet;
                //Excel.Range oRange;

                // Start Excel and get Application object. 
                oXL = new Excel.Application();

                // Set some properties 
                oXL.Visible = false;
                oXL.DisplayAlerts = false;

                // Get a new workbook. 
                //oWB = (Excel.Workbook)oXL.Workbooks.Add(Missing.Value);
                oWB = oXL.Workbooks.Add(Missing.Value);

                // Get the active sheet 
                oSheet = (Excel.Worksheet)oWB.ActiveSheet;
                //set the RowHeight=25 of the first row
                //oWB.SetRowHeight(1, 25);



                oSheet.Name = "Plan1";

                //oSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

                // Process the DataTable 
                int rowCount = 1;
                int totLines = dtSaida.Rows.Count;
                foreach (DataRow dr in dtSaida.Rows)
                {
                    rowCount += 1;
                    for (int i = 1; i < dtSaida.Columns.Count + 1; i++)
                    {
                        // Add the header the first time through 
                        if (rowCount == 2) { oSheet.Cells[1, i] = dtSaida.Columns[i - 1].ColumnName; }
                        oSheet.Cells[rowCount, i] = dr[i - 1].ToString();
                    }
                }

                ////Resize the columns 
                //oRange = oSheet.get_Range(oSheet.Cells[1, 1], oSheet.Cells[rowCount, dtSaida.Columns.Count]);
                //oRange.EntireColumn.AutoFit();

                // Save the sheet and close 
                oSheet = null;
                //Thread.Sleep(500);
                //oRange = null;

                // ao final, salva no formato do Excel.
                oWB.SaveAs(fileFullName, Excel.XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                //Thread.Sleep(1000);
                oWB.Close(Missing.Value, Missing.Value, Missing.Value);
                //Thread.Sleep(500);
                oWB = null;
                oXL.Quit();

                // Clean up 
                // NOTE: When in release mode, this does the trick 
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        //============================================
        public static DataTable ReadSpreadSheet(string spreadSheetFile)
        {
            try
            {
                string spreadSheetProvider = "Provider=Microsoft.Jet.OLEDB.4.0;";
                string spreadSheetExtendedProperties = @"Extended Properties='Excel 8.0;HDR=Yes;'";
                return ReadSpreadSheet(spreadSheetFile, spreadSheetProvider, spreadSheetExtendedProperties);
            }
            catch (Exception ex) { throw ex; }
        }
        //============================================
        public static DataTable ReadSpreadSheet(string spreadSheetFile, string spreadSheetProvider, string spreadSheetExtendedProperties)
        {
            try
            {
                string spreadSheetDataSource = @"Data Source=" + spreadSheetFile + ";";
                string spreadSheetConnection = spreadSheetProvider + spreadSheetDataSource + spreadSheetExtendedProperties;
                return ReadSpreadSheet(spreadSheetFile, spreadSheetConnection);
            }
            catch (Exception ex) { throw ex; }
        }
        //============================================
        public static DataTable ReadSpreadSheet(string spreadSheetFile, string spreadSheetConnection)
        {
            Microsoft.Office.Interop.Excel.Application oAPP = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook oWB = oAPP.Workbooks.Open(spreadSheetFile);
            OleDbConnection oWSConnection = new OleDbConnection(spreadSheetConnection);
            try
            {


                oWSConnection.Open();
                //Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;

                foreach (Microsoft.Office.Interop.Excel.Worksheet oWS in oWB.Worksheets)
                {
                    OleDbCommand oWSCommand = new OleDbCommand("SELECT * FROM [" + oWS.Name + "$" + "]", oWSConnection);
                    OleDbDataAdapter oAdapter = new OleDbDataAdapter();
                    oAdapter.SelectCommand = oWSCommand;
                    DataSet oDS = new DataSet();
                    oAdapter.Fill(oDS);
                    return oDS.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
            finally
            {

                oWSConnection.Close();
                oWB.Close();
                oAPP.Quit();
            }

        }
        #endregion
        //============================================

    }
}
