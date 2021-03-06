using System;

namespace Domain.NetStandard.Entities
{
   public class Match
   {
      public int Id { get; set; }
      public Team HomeTeam { get; set; }
      public Team VisitingTeam { get; set; }
      public DateTime DateToBePlayed { get; set; }
      public DateTime DatePlayed { get; set; }
      public MatchResult Result { get; set; }
   }
}