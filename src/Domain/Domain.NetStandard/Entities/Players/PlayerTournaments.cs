using Domain.NetStandard.Entities.Players;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities
{
   public class PlayerTournaments
   {
      public IPlayer Player { get; set; }
      public ICollection<Tournament> Tournaments { get; set; }
   }
}
