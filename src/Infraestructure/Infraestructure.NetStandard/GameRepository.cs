using Application.NetStandard.Repositories;
using Domain.NetStandard.Entities.Games;
using Domain.NetStandard.Enums;
using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class GameRepository : IGameRepository
   {
      public IEnumerable<Game> GetAllGames() => GameDB.Items;

      public Game GetGame(int id) => GameDB.Items.Find(g => g.Id == id);
   }
}
