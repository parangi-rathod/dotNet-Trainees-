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

