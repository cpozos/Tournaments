using System;
using System.Collections.Generic;

namespace Domain.NetStandard.Organizer
{
   public class PersonOrganizer : Person, IOrganizer
   {
      public ulong Id { get; private set; }
      public string Name => this.FullName;

      public List<Tournament> OrginizedTournaments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

   }
}
