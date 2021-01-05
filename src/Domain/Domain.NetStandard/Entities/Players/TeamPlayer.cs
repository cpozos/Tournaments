using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Players
{
   public class TeamPlayer : IPlayer
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public Statistics Statistics { get; set; }
      public List<PersonPlayer> Integrants { get; set; }
   }
}
