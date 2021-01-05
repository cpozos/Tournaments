using System;

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

      public bool IsFinished => DateTime.Compare(DateTime.Now, TimeFinished) > 0;
   }
}
