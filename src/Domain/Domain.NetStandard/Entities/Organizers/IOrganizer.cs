using System.Collections.Generic;

namespace Domain.NetStandard.Organizer
{
   public interface IOrganizer
   {
      ulong Id { get; }
      string Name { get; }
      List<Tournament> OrginizedTournaments { get; set; }
   }
}
