using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.NetStandard.Entities
{
   public interface IMatchResult
   {
      ICollection<ITeam> Winners { get; set; }
      ICollection<ITeam> Loosers { get; set; }
   }
}
