using System.Collections.Generic;

namespace Domain.NetStandard.Entities
{
   public class MatchTeam
   {
      public Team Team { get; set; }
      public IEnumerable<MatchPlayerStatistics> MatchResults { get; set; }
   }
}