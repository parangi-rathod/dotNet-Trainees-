using Sports.Model;
using Sports.Interface;

namespace Sports.Services
{
   public class CaptainService : ICaptainService
    {
        #region properties
        private readonly ICoachRepo _coachRepo;

        #endregion

        #region ctor
        public CaptainService(ICoachRepo coachRepo)
        {
            _coachRepo = coachRepo;
        }
        #endregion
        public async Task<List<User>> FormFinalTeam(int id)
        {
            if (Team.FinalTeam.Count < 10)
            {
                var user = await _coachRepo.GetUserById(id);
                if (user != null && !Team.FinalTeam.Contains(user))
                {
                    user.isMember = true;
                    Team.FinalTeam.Add(user);
                }
            }

            // Always return the final team, even if it's empty or exceeds the limit
            return Team.FinalTeam;
        }
    }

    
    }
