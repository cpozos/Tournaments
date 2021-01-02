using System;

namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFAMatch
   {
      public FIFATeam Local { get; set; }
      public FIFATeam Visitante { get; set; }
      public int? GolesLocal { get; set; }
      public int? GolesVisitante { get; set; }
      public DateTime DateTimeToPlayIt { get; set; }
      public bool WasPlayed => GolesLocal != null && GolesVisitante != null;
      public bool Equals(FIFAMatch other) =>
         other != null 
         && this.Local == other.Local 
         && this.Visitante == other.Visitante;
   }
}
