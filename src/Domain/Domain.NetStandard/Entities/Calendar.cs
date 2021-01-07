using Domain.NetStandard.Entities.Games.FIFA;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities
{
   public class Calendar
   {
      public ICollection<IMatch> Matches { get; set; }
   }
}
