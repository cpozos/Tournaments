﻿using System.Collections.Generic;

namespace Domain.NetStandard.Entities
{
   public class Team
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public IEnumerable<TeamOwner> Owners { get; set; }
      public IEnumerable<TeamPlayer> Players { get; set; }
      public Stadium Stadium { get; set; }
   }
}