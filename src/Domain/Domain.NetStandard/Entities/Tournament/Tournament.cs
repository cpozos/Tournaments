using Domain.NetStandard.Entities;
using Domain.NetStandard.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.NetStandard
{
   public class Tournament
   {
      public int Id { get; set; }
      public string Title { get; set; }
      public IOrganizer Organizer { get; set; }

      public DateTime TimeCreated { get; set; }
      public DateTime TimeStarted { get; set; }
      public DateTime TimeFinished { get; set; }

      public Calendar Calendar { get; set; }
      public List<Team> Teams { get; set; }


      // Remove
      public int GameId { get; set; }
      public List<Player> SinglePlayers { get; set; }
   }
}
