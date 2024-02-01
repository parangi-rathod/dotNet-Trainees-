namespace DI.Service
{
    public interface IMyService
    {
        public string Greet();
    }
    public class MyService : IMyService
    {
        public string Greet()
        {
            return "hkjslkmf";
        }
    }
}
