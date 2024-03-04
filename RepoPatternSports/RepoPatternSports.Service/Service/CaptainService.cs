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
    public class CaptainService : ICaptainService
    {
        #region properties
        private readonly ICaptainRepo _capRepo;


        #endregion

        #region ctor
        public CaptainService(ICaptainRepo capRepo)
        {
            _capRepo = capRepo;
        }
        #endregion
        public async Task<ResponseDTO> FormFinalTeam(int id)
        {
            int finalTeamCount = Team.FinalTeam.Count;

            int databasePlayerCount = await _capRepo.CountIsMemPlayers();

            int totalCount = finalTeamCount + databasePlayerCount;
            if (totalCount < 11)
            {
                var user = await _capRepo.CheckIsMem(id);

                // Check if the user exists, is a member, and is part of Team.Players
                if (user != null /*&& Team.Players.Contains(user)*/)
                {
                    if (!Team.FinalTeam.Contains(user))
                    {
                        await _capRepo.UpdateUserIsMem(id);
                        Team.FinalTeam.Add(user);
                        return new ResponseDTO
                        {
                            Status = 200,
                            Message = "User added successfully to the team"
                        };
                    }
                    else
                    {
                        return new ResponseDTO
                        {
                            Status = 400,
                            Message = $"User with ID {id} is already in the final team"
                        };
                    }
                }
                else
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = $"User with ID {id} is not found, is not a member, or is not part of Team.Players"
                    };
                }
            }
            return new ResponseDTO
            {
                Status = 400,
                Message = "Team can only contain 11 players"
            };
        }


        public async Task<List<User>> ViewTeam()
        {
            List<User> finalTeamMembers = Team.FinalTeam.ToList();

            List<User> databaseTeamMembers = await _capRepo.GetIsMemPlayers();

            List<User> allTeamMembers = finalTeamMembers.Concat(databaseTeamMembers).ToList();

            return allTeamMembers;
        }
    }
}
