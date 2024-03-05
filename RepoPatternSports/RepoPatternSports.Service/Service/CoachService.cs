using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Service
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
            _coachRepo = coachRepo;
            _userRepo = userRepo;
        }
        #endregion

        #region methods
        public async Task<ResponseDTO> AddPlayerToTeam(int id)
        {
            var user = await _userRepo.GetUserById(id);

            if (user != null && user.isMember == false && Team.Players.Count < 16)
            {
                if (!Team.Players.Contains(user))
                {
                    await _coachRepo.UpdateUserIsMem(id);
                    Team.Players.Add(user);
                    return new ResponseDTO
                    {
                        Status = 200,
                        Message = "Player added into team!"
                    };
                }
                return new ResponseDTO
                {
                    Status = 400,
                    Message = $"Team already contains user with {id}"
                };
            }

            return new ResponseDTO
            {
                Status = 400,
                Message = $"Team can only contains upto 16 players OR Team already contains user with {id}"
            };

        }
                
        public async Task<ResponseDTO> AssignCaptain(int id)
        {
           bool res1 = await _coachRepo.AssignCaptain(id);
            bool res2 = await _coachRepo.CaptainExists(id);
            if (res1 == true && res2==false)
            {
                return new ResponseDTO
                {
                    Status = 200,
                    Message = $"id {id} assigned as captain"
                };
            }

            return new ResponseDTO
            {
                Status = 400,
                Message = "Captain already exists"
            };
        }

        public async Task<List<User>> ViewTeam()
        {
            List<User> coachTeam = await _coachRepo.ViewTeam();
            List<User> teamPlayers = Team.Players;

            List<User> combinedList = coachTeam.Concat(teamPlayers).ToList();

            return combinedList;
        }

        #endregion
    }
}
