using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public interface IOrganizer
   {
      string Name { get; }
      List<Tournament> OrginizedTournaments { get; }
   }
}
