using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace SpringBlog.Helpers
{
    public static class EmailUtilities
    {
        public static async Task SendMailAsync(string destination, string subject, string body)
        {

            // http://csharp.net-informations.com/communications/csharp-smtp-mail.htm
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(ConfigurationManager.AppSettings["mailAccount"], "Spring Blog");
            mail.To.Add(destination);
            mail.Subject = subject + DateTime.Now;
            mail.Body = body;
            mail.IsBodyHtml = true;

            using (var smtClient = new SmtpClient())
            {
                smtClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mailAccount"],
                    ConfigurationManager.AppSettings["mailPassword"]);
               await smtClient.SendMailAsync(mail);
            }
        }
    }
}