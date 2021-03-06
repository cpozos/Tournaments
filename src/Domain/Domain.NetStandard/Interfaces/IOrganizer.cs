using System.Collections.Generic;

namespace Domain.NetStandard.Interfaces
{
   public interface IOrganizer
   {
      int Id { get; set; }
      string Name { get; set; }
      List<Tournament> OrginizedTournaments { get; set; }
   }
}
