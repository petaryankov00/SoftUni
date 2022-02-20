using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Services.Contracts;
using FootballManager.ViewModels;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;
using System.Linq;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public PlayerService(IRepository repo,IValidationService validationService)
        {
            this.repo = repo;
            this.validationService = validationService;
        }

        public bool AddPlayer(int playerId, string userId)
        {
            var userPlayer = new UserPlayer
            {
                PlayerId = playerId,
                UserId = userId
            };
            
            if (repo.All<UserPlayer>().Contains(userPlayer))
            {
                return false;
            }

            repo.Add(userPlayer);
            repo.SaveChanges();

            return true;
            
        }

        public List<ErrorViewModel> CreatePlayer(PlayerInputModel model,string userId)
        {
            var errors = validationService.ValidateModel(model);

            if (errors.Count > 0)
            {
                return errors;
            }

            var player = new Player
            {
                Description = model.Description,
                FullName = model.FullName,
                Endurance = (byte)model.Endurance,
                ImageUrl = model.ImageUrl,
                Position = model.Position,
                Speed = (byte)model.Speed,
            };

            var user = repo.All<User>()
                .FirstOrDefault(x=>x.Id == userId);

            var userPlayer = new UserPlayer
            {
                Player = player,
                User = user
            };

            if (!user.UserPlayers.Contains(userPlayer))
            {
                user.UserPlayers.Add(userPlayer);
            }

            repo.Add(player);
            repo.SaveChanges();

            return errors;
        }

        public List<PlayersViewModel> GetAllPlayers()
        {
            var players = repo.All<Player>()
                .Select(x=> new PlayersViewModel
                {
                    PlayerId = x.Id,
                    FullName = x.FullName,
                    ImageUrl = x.ImageUrl,
                    Description = x.Description,
                    Position = x.Position,
                    Speed = x.Speed,
                    Endurance = x.Endurance,
                })
                .ToList();

            return players;
        }

        public List<PlayersViewModel> GetUserPlayers(string userId)
        {
            var players = repo.All<UserPlayer>()
                .Where(x => x.UserId == userId)
                .Select(x => new PlayersViewModel
                {
                    PlayerId = x.PlayerId,
                    FullName = x.Player.FullName,
                    Description = x.Player.Description,
                    Speed = x.Player.Speed,
                    Endurance = x.Player.Endurance,
                    ImageUrl = x.Player.ImageUrl,
                    Position = x.Player.Position
                })
                .ToList();

            return players;
        }

        public void RemovePlayer(int playerId,string userId)
        {
            var player = repo.All<UserPlayer>()
                .FirstOrDefault(x=>x.UserId == userId && x.PlayerId == playerId);

            if (player != null)
            {
                repo.Remove(player);
                repo.SaveChanges();
            }
        }
    }
}
