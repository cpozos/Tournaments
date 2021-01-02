namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFATeamStatistics
   {
      public int GolesFavor { get; set; }
      public int GolesContra { get; set; }
      public int DiferenciaGoles { get => GolesFavor - GolesContra; }
      public int PartidosJugados { get; set; }
      public int PartidosGanados { get; set; }
      public int PartidosEmpatados { get; set; }
      public int PartidosPerdidos { get; set; }

      public int Puntos => PartidosGanados * 3 + PartidosEmpatados * 1;
   }
}
