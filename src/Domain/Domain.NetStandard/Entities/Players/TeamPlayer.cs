using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Players
{
   public class TeamPlayer : IPlayer
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<SinglePlayer> Integrants { get; set; }
   }
}
