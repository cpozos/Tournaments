using Domain.NetStandard.Entities.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.NetStandard.Repositories
{
   public interface IGameRepository
   {
      IEnumerable<Game> GetAllGames();
      Game GetGame(int id);
   }
}
