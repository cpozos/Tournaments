using System;

namespace Domain.NetStandard.Entities
{
   public class TeamPlayerDraftData
   {
      public DateTime Start { get; set; }
      public DateTime Finish { get; set; }
      public decimal PaymentPerMatch { get; set; }
   }
}
