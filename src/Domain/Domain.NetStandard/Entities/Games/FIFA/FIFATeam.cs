using Domain.NetStandard.Entities.Players;
using Domain.NetStandard.Exceptions;

namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFATeam
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public int OwnerId { get; set; }
      public PersonPlayer Owner { get; set; }
      public string Name { get; set; }
      public FIFATeamStatistics Statistics { get; set; }
      public FIFATeam()
      {
         Statistics = new FIFATeamStatistics();
      }      

      //public int CompareTo(FIFATeam other)
      //{
      //   if (other == null)
      //      throw new NullCompareToException();

      //   const int THIS_WINS = -1;
      //   const int OTHER_WINS = 1;
      //   const int TIES = 1;

      //   // Compare by points
      //   if (other.Puntos > this.Puntos)
      //      return OTHER_WINS;
      //   else if (other.Puntos < this.Puntos)
      //      return THIS_WINS;

      //   // Compare by Matches
      //   if (other.PartidosJugados < this.PartidosJugados)
      //      return OTHER_WINS;
      //   else if (other.PartidosJugados > this.PartidosJugados)
      //      return THIS_WINS;

      //   // Compaer by goals differences
      //   if (other.DiferenciaGoles > this.DiferenciaGoles)
      //      return OTHER_WINS;
      //   else if (other.DiferenciaGoles < this.DiferenciaGoles)
      //      return THIS_WINS;

      //   // Compare by 
      //   if (other.GolesFavor > this.GolesFavor)
      //      return OTHER_WINS;
      //   else if (other.GolesFavor < this.GolesFavor)
      //      return THIS_WINS;


      //   // Compare by name

      //   return TIES;
      //}
      public bool Equals(FIFATeam other) => other != null && Name == other.Name;
   }
}
