using Sports.Interface;
using Sports.Model;

namespace Sports.Services
{
   
    public class CoachService : ICoachService
    {
        #region properties
        private readonly ICoachRepo _coachRepo;
        private const int MaxTeamSize = 15;
       
        #endregion

        #region ctor
        public CoachService(ICoachRepo coachRepo)
        {
            _coachRepo= coachRepo;
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
            var user = await _coachRepo.GetUserById(id);

            if (user != null && user.isMember == false)
            {
                Team.Players.Add(user);
                user.isMember = true;
                return Team.Players;
            }

            return null;
        }



    }
}
