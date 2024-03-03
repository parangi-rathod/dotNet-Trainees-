using Sports.Interface;
using Sports.Model;
using Sports.Repository;

namespace Sports.Services
{
    public class PlayerService : IPlayerService
    {
        #region prop
        private readonly IPlayerRepo _playerRepo;
        #endregion

        #region ctor
        public PlayerService(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }
        #endregion
        public async Task<User> GetCaptain()
        {
            return await _playerRepo.GetCaptain();
        }

        public async Task<User> GetCoach()
        {
           return await _playerRepo.GetCoach();
        }
    }
}
