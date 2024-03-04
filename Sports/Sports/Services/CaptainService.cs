using Sports.Model;
using Sports.Interface;

namespace Sports.Services
{
   public class CaptainService : ICaptainService
    {
        #region properties
        private readonly IUserRepo _userRepo;
        private readonly ICaptainRepo _capRepo;


        #endregion

        #region ctor
        public CaptainService(IUserRepo userRepo, ICaptainRepo capRepo)
        {
            _userRepo = userRepo;
            _capRepo = capRepo;
        }
        #endregion
        public async Task<List<User>> FormFinalTeam(int id)
        {
            if (Team.FinalTeam.Count < 11)
            {
                var user = await _userRepo.GetUserById(id);
                if (user != null && !Team.FinalTeam.Contains(user))
                {
                    await _capRepo.UpdateUserIsMem(id);
                    Team.FinalTeam.Add(user);
                }
            }

            // Always return the final team, even if it's empty or exceeds the limit
            return Team.FinalTeam;
        }
    }

    
    }
