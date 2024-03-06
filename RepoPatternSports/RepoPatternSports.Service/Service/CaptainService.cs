using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;

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

        #region methods
        public async Task<ResponseDTO> FormFinalTeam(int id)
        {
            int finalTeamCount = Team.FinalTeam.Count;

            int databasePlayerCount = await _capRepo.CountIsMemPlayers();

            int totalCount = finalTeamCount + databasePlayerCount;
            if (totalCount < 11)
            {
                var user = await _capRepo.CheckIsMem(id);

                if (user != null && user.isMember==true)
                {
                    if (!Team.FinalTeam.Contains(user))
                    {
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
            return Team.FinalTeam;
        }
        #endregion
    }
}
