using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public interface IOrganizer
   {
      int Id { get; }
      List<Tournament> OrginizedTournaments { get; }
   }
}
