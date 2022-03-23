using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public partial class ConvertPDF : System.Web.UI.Page
{
   private Microsoft.Office.Interop.Word.ApplicationClass WordApp = new Microsoft.Office.Interop.Word.ApplicationClass();

   protected void Page_Load(object sender, EventArgs e)
   {
       if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
       {
           ConvertWordToPdf(Convert.ToInt32(Request.QueryString["ID"]));
       }
   }
   private void ConvertWordToPdf(int id)
   {
       // Use the open file dialog to choose a word document      
       string diretorio = Server.MapPath("") + @"\ModelWord\Termo.docx";

       // set the file name from the open file dialog
       object fileName = diretorio;
       object readOnly = false;
       object isVisible = false;
       // Here is the way to handle parameters you don't care about in .NET
       object missing = System.Reflection.Missing.Value;
       // Make word visible, so you can see what's happening
       WordApp.Visible = true;
       // Open the document that was chosen by the dialog
       Microsoft.Office.Interop.Word.Document aDoc = WordApp.Documents.Open(ref fileName, ref missing,
           ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing,
           ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
       // Activate the document so it shows up in front
       try
       {
           aDoc.Activate();

           goliath.pdf.MOD.UserMOD userMOD = new goliath.pdf.MOD.UserMOD();
           goliath.pdf.NEG.UserNEG userNEG = new goliath.pdf.NEG.UserNEG();
           userMOD = userNEG.Find(id);

           if (userMOD != null && userMOD.Name != "")
           {
               foreach (Microsoft.Office.Interop.Word.Range tmpRange in aDoc.StoryRanges)
               {
                   tmpRange.Find.Wrap = Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue;
                   object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                   tmpRange.Find.Text = "[COMMENTS]";
                   tmpRange.Find.Replacement.Text = userMOD.Comments;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[DATANOW]";
                   tmpRange.Find.Replacement.Text = userMOD.DateNow;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[DATEREG]";
                   tmpRange.Find.Replacement.Text = userMOD.DateReg;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[DESCRIPTION]";
                   tmpRange.Find.Replacement.Text = userMOD.Description;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[EMAIL]";
                   tmpRange.Find.Replacement.Text = userMOD.Email;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[NAME]";
                   tmpRange.Find.Replacement.Text = userMOD.Name;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[NUMBERSERIAL]";
                   tmpRange.Find.Replacement.Text = userMOD.NumberSerial;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[TAG]";
                   tmpRange.Find.Replacement.Text = userMOD.Tag;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[UA]";
                   tmpRange.Find.Replacement.Text = userMOD.Ua;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[UO]";
                   tmpRange.Find.Replacement.Text = userMOD.Uo;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);

                   tmpRange.Find.Text = "[LIDER]";
                   tmpRange.Find.Replacement.Text = userMOD.Lider;
                   tmpRange.Find.Execute(ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref missing,
                       ref missing, ref missing, ref missing, ref replaceAll,
                       ref missing, ref missing, ref missing, ref missing);
               }
           }

           aDoc.ExportAsFixedFormat(Server.MapPath("") + @"\ModelWord\Termo.pdf", Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF,
           false, Microsoft.Office.Interop.Word.WdExportOptimizeFor.wdExportOptimizeForOnScreen, Microsoft.Office.Interop.Word.WdExportRange.wdExportAllDocument, 0,
           0, Microsoft.Office.Interop.Word.WdExportItem.wdExportDocumentWithMarkup, true, true, Microsoft.Office.Interop.Word.WdExportCreateBookmarks.wdExportCreateWordBookmarks,
           true, true, false, ref missing);
       }
       finally
       {
           object doNotSaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
           aDoc.Close(ref doNotSaveChanges, ref missing, ref missing);
           WordApp.Application.Quit(ref missing, ref missing, ref missing);
       }
       ForceDownload(System.Web.HttpContext.Current.Response, Server.MapPath("") + @"\ModelWord\Termo.pdf");
   }
   public void ForceDownload(HttpResponse Response, string fileName)
   {
       Response.Clear();
       Response.AddHeader("Content-Disposition", "attachment; filename=Responsability Form.pdf");
       Response.TransmitFile(fileName);
       Response.End();
   }
}