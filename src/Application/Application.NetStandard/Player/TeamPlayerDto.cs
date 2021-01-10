using System.Collections.Generic;

namespace Application.NetStandard.Player
{
   public class TeamPlayerDto
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public IEnumerable<SinglePlayerDto> Integrants { get; set; }
   }
}