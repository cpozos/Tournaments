using Domain.NetStandard.Enums;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Games
{
   public class Game
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public IEnumerable<Platform> AvailablePlatforms { get; set; }
      public Game()
      {
         AvailablePlatforms = new List<Platform>();
      }
   }
}
