using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;

namespace GenericClasses
{
    public class Mail
    {
        //==============================================
        public void Sendmail(string from, string to, string cc, string bcc, string log, string subject, string body, string file)
        {
            //Sendmail("smtp.gmail.com", 587, from, to, subject, body, file);
            //Sendmail("localhost", 25, from, to, subject, body, file);
            //Sendmail("smtp.eepsa.com.br", 25, from, to, cc, bcc, log, subject, body, file);

            string host = "smtp.enseada.com";
            int port = 25;
            Sendmail(host, port, from, to, cc, bcc, log, subject, body, file);
        }
        //==============================================
        public void Sendmail(string host, int port, string from, string to, string cc, string bcc, string log, string subject, string body, string file)
        {
            // Create  the file attachment for this e-mail message.
            //Attachment fileAttached = new Attachment(file);

            string[] aTo = to.Split(';');
            string[] aCC = cc.Split(';');
            string[] aBCC = bcc.Split(';');
            string[] aLOG = log.Split(';');
            string[] aAttachment = { file };
            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Host = host;
            client.Port = port;

            //=====================================================================
            // setup Smtp authentication
            client.EnableSsl = false;
            client.UseDefaultCredentials = true;
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();

            //client.UseDefaultCredentials = false;
            //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(@"eepsa.com.br\goliath", "G0l!@th");

            //=====================================================================

            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.Priority = MailPriority.High;
            msg.From = new MailAddress(from);

            //Define Destinatários
            if (to.Length > 0) for (int i = 0; i < aTo.Length; i++) { msg.To.Add(new MailAddress(aTo[i])); }
            //Define CC
            if (cc.Length > 0) for (int i = 0; i < aCC.Length; i++) { msg.CC.Add(new MailAddress(aCC[i])); }
            //Define BCC
            if (bcc.Length > 0) for (int i = 0; i < aBCC.Length; i++) { msg.Bcc.Add(new MailAddress(aBCC[i])); }
            //Define LOG
            if (log.Length > 0) for (int i = 0; i < aLOG.Length; i++) { msg.To.Add(new MailAddress(aLOG[i])); }
            //Attach file
            if (file != "") msg.Attachments.Add(new Attachment(aAttachment[0]));


            //msg.CC.Add(@"paulo.almeida@enseada.com");
            //msg.To.Add(@"paulo.almeida@eepsa.com.br");

            msg.Subject = subject;
            msg.IsBodyHtml = true;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            
            msg.Body = body;
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw new Exception(ex.Message);
            }
        }
        //==============================================
    }
}