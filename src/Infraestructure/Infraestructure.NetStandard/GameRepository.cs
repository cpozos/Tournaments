using Application.NetStandard.Repositories;
using Domain.NetStandard.Entities.Games;
using Domain.NetStandard.ValueObjects;
using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class GameRepository : IGameRepository
   {
      public static readonly List<Game> Games = new List<Game>
      {
         new Game
         {
            Id = 1,
            Name = "FIFA",
            AvailablePlatforms = new List<Platform>
            {
               Platforms.PlayStation4,
               Platforms.XboxOne
            }
         }
      };

      public IEnumerable<Game> GetAllGames() => Games;

      public Game GetGame(int id) => Games.Find(g => g.Id == id);
   }
}
