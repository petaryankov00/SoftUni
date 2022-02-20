using FootballManager.Services.Contracts;
using FootballManager.ViewModels;
using FootballManager.ViewModels.Players;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;

        public PlayersController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [Authorize]
        public HttpResponse All()
        {
            var players = playerService.GetAllPlayers();
            return this.View(players);
        }
        
        [Authorize]
        public HttpResponse Add()
            => this.View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(PlayerInputModel model)
        {
            var errors = playerService.CreatePlayer(model, this.User.Id);

            if (errors.Count > 0)
            {
                return View("/Error", errors);
            }

            return Redirect("/Players/All");
        }

        [Authorize]
        public HttpResponse AddToCollection(int playerId)
        {
            var isAdded = playerService.AddPlayer(playerId, this.User.Id);

            if (!isAdded)
            {
                return View("/Error", new List<ErrorViewModel> { new ErrorViewModel
                { Message = "Player is already in your collection" } });
            }

            return Redirect("/Players/All");

        }

        [Authorize]
        public HttpResponse Collection()
        {
            var players = this.playerService.GetUserPlayers(this.User.Id);

            return this.View(players);
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int playerId)
        {
            playerService.RemovePlayer(playerId, this.User.Id);

            return Redirect("/Players/Collection");
        }
    }
}
