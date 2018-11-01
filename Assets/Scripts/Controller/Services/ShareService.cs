
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Rehab.Services
{
    public interface IShareService
    {
        void SendEmail(string[] activities, float[] times, Action onSend);
    }

    public class ShareService : IShareService
    {
        public void SendEmail(string[] activities, float[] times, Action onSend)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress(Constans.ADMIN_EMAIL);
            mail.To.Add(Selected.USER.Email);
            mail.Subject = GetEmailSubject();
            mail.Body = GetEmailBody(activities, times);

            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential(Constans.ADMIN_EMAIL, Constans.ADMIN_EMAIL_PASSWORD) as ICredentialsByHost,
                EnableSsl = true
            };
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
            smtpServer.Send(mail);
            onSend();
        }

        private string GetEmailSubject()
        {
            string userName = Selected.USER.Name;
            string userSurname = Selected.USER.Surname;
            return "Plan_" + userName + "_" + userSurname + "_"+ DateTime.Today.ToShortDateString();
        }

        private string GetEmailBody(string[] activities, float[] times)
        {
            string toSend = "Witaj! \n\n" +
                "Plan " + Selected.USER.Name + " " + Selected.USER.Surname +
                " na dzień: " + DateTime.Today.ToShortDateString() + " wygląda następująco: \n\n";

            string body = "";
            for (int i = 0; i < activities.Length && i < times.Length; i++)
                body += (i + 1).ToString() + ". " + activities[i] + " - " + times[i].ToString() + " min.\n";

            string end = "\n\n Pozdrawiam.";

            return toSend + body + end;
        }
    }
}
