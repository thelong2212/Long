using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PhucAnh_done.Common
{
    public class MailHelper
    {
        public void SendMail(string toEmailAddress, string subject, string content)
        {
            // config -......
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            var fromEmailAddr = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var fromDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();

            bool enableSSl = bool.Parse(ConfigurationManager.AppSettings["EnableSSL"].ToString());

            MailMessage message = new MailMessage(new MailAddress(fromEmailAddr, fromDisplayName), new MailAddress(toEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = content;

            var client = new SmtpClient();

            client.Credentials = new NetworkCredential(fromEmailAddr, FromEmailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSSl;
            client.Port = Convert.ToInt32(smtpPort);
            client.Send(message);
        }
    }
}