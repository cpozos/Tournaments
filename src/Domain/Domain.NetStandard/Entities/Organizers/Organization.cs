using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public class Organization : IOrganizer
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public List<OrganizationIntegrant> Integrants { get; set; } = new List<OrganizationIntegrant>();
      public List<Tournament> OrginizedTournaments { get; set; } = new List<Tournament>();
   }
}
