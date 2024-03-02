using Sports.Model;

namespace Sports.Interface
{
    public interface ICaptainService
    {
        Task<List<User>> FormFinalTeam(int id);
    }
}
