using Sports.Interface;
using Sports.Model;

namespace Sports.Services
{
   
    public class CoachService : ICoachService
    {
        #region properties
        private readonly ICoachRepo _coachRepo;
        private readonly IUserRepo _userRepo;

        #endregion

        #region ctor
        public CoachService(ICoachRepo coachRepo, IUserRepo userRepo)
        {
            _coachRepo= coachRepo;
            _userRepo= userRepo;
        }
        #endregion
        public async Task<string> AssignCaptain(int id)
        {
            bool res1 = await _coachRepo.CaptainExists(id);
            if (res1)
            {
                return "Captain already exists";
            }
            bool res2 = await _coachRepo.AssignCaptain(id);
            return "Captain assigned successfully";
        }

        public async Task<List<User>> AddPlayerToTeam(int id)
        {
            var user = await _userRepo.GetUserById(id);

            if (user != null && user.isMember == false && Team.Players.Count < 16)
            {
                Team.Players.Add(user);
                return Team.Players;
            }

            return null;
        }



    }
}
