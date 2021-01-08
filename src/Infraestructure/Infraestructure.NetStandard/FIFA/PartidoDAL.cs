using System;

namespace Infraestructure.NetStandard.FIFA
{
   [Serializable()]
   public class PartidoDAL
   {
      public EquipoDAL Local { get; set; }
      public EquipoDAL Visitante { get; set; }
      public int GolesLocal { get; set; }
      public int GolesVisitante { get; set; }
      public bool YaSeJugo { get; set; }
   }
}
