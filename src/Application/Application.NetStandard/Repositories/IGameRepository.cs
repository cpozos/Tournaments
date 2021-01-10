using Application.NetStandard.Game;
using System.Collections.Generic;

namespace Application.NetStandard.Repositories
{
   public interface IGameRepository
   {
      IEnumerable<GameDto> GetAllGames();
      GameDto GetGame(int id);
   }
}
