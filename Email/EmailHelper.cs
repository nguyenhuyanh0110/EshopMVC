using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    public class EmailHelper
    {
        public void Email(string ToEmailAddress, string subject, string content)
        {
            //add key from Web Config
            var FromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var FromEmailName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var StmpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var StmpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool ssl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());

            //create email content
            string BodyEmail = content;
            MailMessage mail = new MailMessage(new MailAddress(FromEmailAddress, FromEmailName), new MailAddress(ToEmailAddress));
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = BodyEmail;

            //create authenticate
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(FromEmailAddress, FromEmailPassword);
            client.Host = StmpHost;
            client.EnableSsl = ssl;
            client.Port = !string.IsNullOrEmpty(StmpPort) ? Convert.ToInt32(StmpPort) : 0;
            client.Send(mail);
        }
    }
}
