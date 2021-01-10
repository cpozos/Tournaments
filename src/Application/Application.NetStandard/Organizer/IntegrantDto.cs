using System.Collections.Generic;

namespace Application.NetStandard.Organizer
{
   public class IntegrantDto
   {
      public string Name { get; set; }
      public IEnumerable<int> RolIds { get; set; }
   }
}
