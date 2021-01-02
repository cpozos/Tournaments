using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Players
{
   public class TeamPlayer : IPlayer
   {
      public string Name => throw new System.NotImplementedException();
      public List<PersonPlayer> PersonPlayers { get; set; }
      public Statistics Statistics { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

      public TeamPlayer()
      {
         PersonPlayers = new List<PersonPlayer>();
      }
   }
}
