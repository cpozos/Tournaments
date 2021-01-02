using System;
using System.Collections.Generic;
using System.Text;

namespace Application.NetStandard.FIFA.Team
{
   public class TeamDTO
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public string Name { get; set; }
      public int OwnerId { get; set; }
   }
}
