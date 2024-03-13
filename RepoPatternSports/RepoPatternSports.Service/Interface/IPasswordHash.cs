namespace RepoPatternSports.Service.Interface
{
    public interface IPasswordHash
    {
        string CreatePasswordHash(string password);
    }
}
