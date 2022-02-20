using FootballManager.ViewModels;
using FootballManager.ViewModels.Players;
using System.Collections.Generic;

namespace FootballManager.Services.Contracts
{
    public interface IPlayerService
    {
        List<PlayersViewModel> GetAllPlayers();

        List<ErrorViewModel> CreatePlayer(PlayerInputModel model,string userId);

        bool AddPlayer(int playerId, string userId);

        List<PlayersViewModel> GetUserPlayers(string userId);

        void RemovePlayer(int playerId,string userId);

    }
}
