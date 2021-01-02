using Domain.NetStandard.ValueObjects;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Games
{
   public class Game
   {
      public uint Id { get; set; }
      public string Name { get; set; }
      public List<Game> Games { get; }
      public List<Platform> AvailablePlatforms { get; set; }
      public Game()
      {
         AvailablePlatforms = new List<Platform>();
      }
   }
}
