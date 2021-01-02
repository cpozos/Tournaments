using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public class PersonOrganizer : Person, IOrganizer
   {
      public string Name => this.FullName;
      public List<OrganizerRol> Rols { get; set; }
      public List<Tournament> OrginizedTournaments { get; set; }

      public PersonOrganizer()
      {
         Rols = new List<OrganizerRol>();
         OrginizedTournaments = new List<Tournament>();
      }
   }
}
