namespace Sports.Repository
{
    public interface IConvertHashService
    {
        string CreatePasswordHash(string password);
    }
}
