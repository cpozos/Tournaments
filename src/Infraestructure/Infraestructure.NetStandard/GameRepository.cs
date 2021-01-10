using Application.NetStandard.Game;
using Application.NetStandard.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.NetStandard
{
   public class GameRepository : IGameRepository
   {
      public IEnumerable<GameDto> GetAllGames() => GameDB.Items.Select(g => new GameDto
      {
         Id = g.Id,
         Name = g.Name
      });

      public GameDto GetGame(int id)
      {
         var item = GameDB.Items.Find(g => g.Id == id);

         if (item != null)
         {
            return new GameDto
            {
               Id = item.Id,
               Name = item?.Name
            };
         }
         else
         {
            return null;
         }
      }
   }
}
