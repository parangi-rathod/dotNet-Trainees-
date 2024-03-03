namespace Sports.Interface
{
    public interface IEmailService
    {
        void SendRegisterMail(string email, string subject);
        void SendResetPassEmail(string email, string subject);
    }
}
