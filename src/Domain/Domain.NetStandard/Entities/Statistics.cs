using System.Collections.Generic;

namespace Domain.NetStandard
{
   // Remove it ??
   public class Statistics
   {
      public List<Tournament> AllTournaments { get; set; }
      public List<Tournament> WinnedTournaments { get; set; }
      public List<Tournament> LostTournaments { get; set; }
   }
}
