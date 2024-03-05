using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<object> GetCaptain()
        {
            var user1 = await _playerRepo.GetCaptain();

            var user = new
            {
                Name = user1.Firstname + user1.Lastname,
                Email = user1.Email,
                Contact = user1.ContactNumber
            };

            return user;
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

    }
}

