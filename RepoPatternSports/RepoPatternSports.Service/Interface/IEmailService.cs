using RepoPatternSports.Repository.DTOs;

namespace RepoPatternSports.Service.Interface
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO emailDTO);
    }
}
