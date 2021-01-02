using System;
using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Games.FIFA
{
   public class FIFACalendar
   {
      public Dictionary<DateTime, FIFAMatch> Matches { get; set; }
   }
}
