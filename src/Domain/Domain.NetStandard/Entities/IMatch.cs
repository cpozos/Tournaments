using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.NetStandard.Entities
{
   public interface IMatch
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public IEnumerable<ITeam> Teams { get; set; }
      public DateTime DateToBePlayed { get; set; }
      public IMatchResult Result { get; set; }
   }
}
