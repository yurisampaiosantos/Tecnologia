using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
//using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Core
{
    public class SpreadSheet
    {
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

                oSheet.Name = "Plan1";

                //oSheet.Visible = Excel.XlSheetVisibility.xlSheetHidden;

                // Process the DataTable 
                int rowCount = 1;
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

                //oRange = null;

                // ao final, salva no formato do Excel.

                oWB.SaveAs(fileFullName, Excel.XlFileFormat.xlXMLSpreadsheet, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                //oWB.SaveAs(fileFullName);
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
    }
}
