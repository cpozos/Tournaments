using Domain.NetStandard.Entities;
using Domain.NetStandard.Entities.Players;
using System;
using System.Collections.Generic;

namespace Domain.NetStandard
{
   public class Tournament
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public int GameId { get; set; }
      public int OrginizerId { get; set; }

      public DateTime TimeCreated { get; set; }
      public DateTime TimeStarted { get; set; }
      public DateTime TimeFinished { get; set; }

      public Calendar Calendar { get; set; }
      public List<IPlayer> SinglePlayers { get; set; }
      public List<IPlayer> TeamPlayers { get; set; }
      public bool IsFinished => DateTime.Compare(DateTime.Now, TimeFinished) > 0;
   }
}
