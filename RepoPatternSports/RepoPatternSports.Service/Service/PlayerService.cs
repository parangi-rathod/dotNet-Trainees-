using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;

namespace RepoPatternSports.Service.Service
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

        #region methods
        public async Task<ResponseDTO> GetCaptain()
        {
            var user1 = await _playerRepo.GetCaptain();
            if (user1 != null)
            {

                var user = new
                {
                    Name = user1.Firstname + " " + user1.Lastname,
                    Email = user1.Email,
                    Contact = user1.ContactNumber
                };
                return new ResponseDTO { Status = 200, Data = user, Message = "" };
            }
            return new ResponseDTO { Status = 200, Message = "Captain is not decided yet" };
        }


        public async Task<object> GetCoach()
        {
            var user1 = await _playerRepo.GetCoach();

                var user = new
                {
                    Name = user1.Firstname +" "+ user1.Lastname,
                    Email = user1.Email,
                    Contact = user1.ContactNumber
                };

            return user;
        }
        #endregion
    }
}

