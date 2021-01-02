using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Organizers;
using System;
using System.Collections.Generic;

namespace Application.NetStandard.FIFA.Tournament
{
   public class TournamentDTO
   {
      public string Title { get; set; }
      public IOrganizer Organizer { get; set; }
      public uint GameId { get; set; }
      public bool IsFinished => DateTime.Compare(DateTime.Now, TimeFinished) > 0;
      public DateTime TimeStarted { get; set; }
      public DateTime TimeFinished { get; set; }
      public DateTime TimeCreated { get; set; }

      public List<FIFATeam> Teams { get; set; }
      public List<FIFAMatch> Matches { get; set; }
   }
}
