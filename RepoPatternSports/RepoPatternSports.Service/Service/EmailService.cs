using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RepoPatternSports.Service.Service
{
    public class EmailService : IEmailService
    {
        public void SendEmail(EmailDTO emailDTO)
        {
            // Set up SMTP client
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("reactmp@outlook.com", "react#mp52");

            // Create email message
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("reactmp@outlook.com");
            mailMessage.To.Add(emailDTO.Email);
            mailMessage.Subject = emailDTO.Subject;

            mailMessage.IsBodyHtml = true;
            //StringBuilder mailBody = new StringBuilder();
            //mailBody.AppendFormat("<h1>User Registered</h1>");
            //mailBody.AppendFormat("<br />");
            //mailBody.AppendFormat("<p>Thank you For Registering account</p>");
            mailMessage.Body = emailDTO.Body;

            // Send email
            client.Send(mailMessage);
        }
    }
}
