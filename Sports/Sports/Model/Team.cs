namespace Sports.Model
{
    public static class Team
    {
        public static List<User> Players { get; set; }
        public static List<User> FinalTeam { get; } = new List<User>();
        static Team()
        {
            Players = new List<User>();
            FinalTeam = new List<User>();
        }
    }
}
