using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public class PersonOrganizer : Person, IOrganizer
   {
      public List<Tournament> OrginizedTournaments { get; set; } = new List<Tournament>();
   }
}
