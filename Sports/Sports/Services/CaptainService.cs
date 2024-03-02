using Sports.Model;
using Sports.Interface;

namespace Sports.Services
{
   public class CaptainService : ICaptainService
    {
        public async Task<List<User>> FormFinalTeam(int id)
        {
            if (Team.FinalTeam.Count < 10)
            {
                var user = Team.Players.FirstOrDefault(u => u.UserId == id);
                if (user != null && !Team.FinalTeam.Contains(user))
                {
                    Team.FinalTeam.Add(user);
                }
            }

            // Always return the final team, even if it's empty or exceeds the limit
            return Team.FinalTeam;
        }
    }

    
    }
