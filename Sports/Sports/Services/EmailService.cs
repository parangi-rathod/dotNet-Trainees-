using Sports.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace Sports.Services
{
    public class EmailService : IEmailService
    {
        #region Register Mail
        public void SendRegisterMail(string email, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("reactmp@outlook.com", "react#mp52");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("reactmp@outlook.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>User Registered</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
        #endregion

        #region Login Mail
        public void SendResetPassEmail(string email, string subject)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("reactmp@outlook.com", "react#mp52");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("reactmp@outlook.com");
            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            StringBuilder mailBody = new StringBuilder();
            mailBody.AppendFormat("<h1>Password changed</h1>");
            mailBody.AppendFormat("<br />");
            mailBody.AppendFormat("<p>Your password is changed!</p>");
            mailMessage.Body = mailBody.ToString();

            // Send email
            client.Send(mailMessage);
        }
        #endregion

        #region Forgot Password Mail
        #endregion
    }
}
