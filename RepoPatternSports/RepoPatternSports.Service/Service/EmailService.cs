using Microsoft.Extensions.Configuration;
using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Service.Interface;
using System.Net;
using System.Net.Mail;

namespace RepoPatternSports.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config= config;
        }
        public void SendEmail(EmailDTO emailDTO)
        {
            string smtpClient = _config["EmailService:smtpClient"];
            int smtpPort = int.Parse(_config["EmailService:smptpPort"]);
            string emailFrom = _config["EmailService:emailFrom"];
            string emailPass = _config["EmailService:emailPass"];

            SmtpClient client = new SmtpClient(smtpClient, smtpPort);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(emailFrom, emailPass);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(emailFrom);
            mailMessage.To.Add(emailDTO.Email);
            mailMessage.Subject = emailDTO.Subject;

            mailMessage.IsBodyHtml = true;
            mailMessage.Body = emailDTO.Body;

            client.Send(mailMessage);
        }



    }
}
