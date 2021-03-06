using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public class OrganizationIntegrant : Person
   {
      public List<OrganizerRol> Rols { get; set; }
   }
}
