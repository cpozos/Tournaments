using Domain.NetStandard.Entities.Organizers;
using System;

namespace Domain.NetStandard
{
   public class Tournament
   {
      public string Title { get; set; }
      public IOrganizer Orginizer { get; set; }
      public uint GameId { get; set; }
      public bool IsFinished => DateTime.Compare(DateTime.Now, TimeFinished) > 0;
      public DateTime TimeStarted { get; set; }
      public DateTime TimeFinished { get; set; }
      public DateTime TimeCreated { get; set; }
   }
}
