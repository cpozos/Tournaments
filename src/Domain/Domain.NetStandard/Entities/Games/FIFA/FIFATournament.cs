using System.Collections.Generic;
using System.Linq;

namespace Domain.NetStandard.Entities.Games.FIFA
{

   public class FIFATournament : Tournament
   {
      public FIFATournament()
      {
         Teams = new List<FIFATeam>();
         Matches = new List<FIFAMatch>();
      }

      public List<FIFATeam> Teams { get; set; }
      public List<FIFAMatch> Matches { get; set; }
   }

}
