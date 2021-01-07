using System;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFAMatch : IMatch
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public IEnumerable<ITeam> Teams { get; set; }
      public FIFATeam Local { get; set; }
      public FIFATeam Visitante { get; set; }
      public DateTime DateToBePlayed { get; set; }
      public int? GolesLocal { get; set; }
      public int? GolesVisitante { get; set; }
      public bool Equals(FIFAMatch other) =>
         other != null 
         && this.TournamentId == other.TournamentId
         && this.Local == other.Local 
         && this.Visitante == other.Visitante;
   }
}
