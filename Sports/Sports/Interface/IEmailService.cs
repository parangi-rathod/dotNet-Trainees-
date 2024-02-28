namespace Sports.Interface
{
    public interface IEmailService
    {
        void SendRegisterMail(string email, string subject);
        void SendLoginMail(string email, string subject);
    }
}
