using RepoPatternSports.Repository.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Interface
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO emailDTO);
    }
}
