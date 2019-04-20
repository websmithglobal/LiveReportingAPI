using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace SOAP_LiveReporting.Bussiness
{
    public class SendMail
    {
        public string SendMailIn(string MailID, string Content)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("Support@livereporting.in", "livereporting.in");
            msg.To.Add(MailID);
            msg.Subject = "Livereporting inquiry confirmation details";
            msg.IsBodyHtml = true;
            msg.Body = Content;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.livereporting.in", 25);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("Support@livereporting.in", "Goodluck@9");
            client.Port = 25;
            client.Host = "mail.livereporting.in";
            client.Send(msg);
            return "1";

        }
        public string SendToSocialNetword(string MailID, string Content)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("Support@livereporting.in", "livereporting.in");
            msg.To.Add(MailID);
            msg.Subject = "User information";
            msg.IsBodyHtml = true;
            msg.Body = Content;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("mail.livereporting.in", 25);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("Support@livereporting.in", "Goodluck@9");
            client.Port = 25;
            client.Host = "mail.livereporting.in";
            client.Send(msg);
            return "1";
        }
        public string SendMailForgetIn(string MailID, string Content)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.From = new MailAddress("livereporting2015@gmail.com", "livereporting.in");
            msg.To.Add(MailID);
            msg.Subject = "Forget Password confirmation details";
            msg.IsBodyHtml = true;
            msg.Body = Content;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 25);
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("livereporting2015@gmail.com", "montu1341");
            client.Port = 25;
            client.Host = "smtp.gmail.com";
            client.Send(msg);
            return "1";

        }
    }
}