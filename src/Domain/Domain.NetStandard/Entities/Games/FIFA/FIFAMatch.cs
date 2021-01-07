using System;

namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFAMatch
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public FIFATeam Local { get; set; }
      public FIFATeam Visitante { get; set; }
      public DateTime DateTimePlayed { get; set; }
      public int? GolesLocal { get; set; }
      public int? GolesVisitante { get; set; }
      public bool WasPlayed => GolesLocal != null && GolesVisitante != null && DateTimePlayed != null;
      public bool Equals(FIFAMatch other) =>
         other != null 
         && this.TournamentId == other.TournamentId
         && this.Local == other.Local 
         && this.Visitante == other.Visitante;
   }
}
