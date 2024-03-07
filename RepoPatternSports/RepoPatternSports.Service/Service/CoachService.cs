using RepoPatternSports.Repository.Interface;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;

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

            if (user != null)
            {
                int teamMembersCount = await _userRepo.GetTeamMembersCount();

                if (user.isMember == false && teamMembersCount < 16)
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
                else if (user.isMember == true)
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = $"User with {id} is already a member of the team"
                    };
                }
                else if (teamMembersCount >= 15)
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = "Team can only contain up to 15 players"
                    };
                }
            }

            return new ResponseDTO
            {
                Status = 404,
                Message = $"User with id {id} not found or invalid"
            };
        }

        public async Task<ResponseDTO> AssignCaptain(int id)
        {
            bool captainExists = await _userRepo.CheckCaptain();

            if (!captainExists)
            {
                bool isAssigned = await _coachRepo.AssignCaptain(id);

                if (isAssigned)
                {
                    var captain = await _userRepo.GetUserById(id);

                    if (captain != null)
                    {
                        Team.Players.Add(captain);
                        return new ResponseDTO
                        {
                            Status = 200,
                            Message = $"Player with id {id} assigned as captain"
                        };
                    }
                    else
                    {
                        return new ResponseDTO
                        {
                            Status = 404,
                            Message = $"Player with id {id} not found"
                        };
                    }
                }
                else
                {
                    return new ResponseDTO
                    {
                        Status = 400,
                        Message = "Failed to assign captain"
                    };
                }
            }
            else
            {
                return new ResponseDTO
                {
                    Status = 400,
                    Message = "Captain already exists"
                };
            }
        }


        public async Task<List<User>> ViewTeam()
        {
            List<User> coachTeam = await _coachRepo.ViewTeam();
            //List<User> teamPlayers = Team.Players;

            //List<User> combinedList = coachTeam.Concat(teamPlayers).ToList();

            return coachTeam;
        }

        #endregion
    }
}
