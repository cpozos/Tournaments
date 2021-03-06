using System.Collections.Generic;

namespace Domain.NetStandard.Entities
{
   public class Calendar
   {
      public int Id { get; set; }
      public ICollection<Match> Matches { get; set; }
   }
}
