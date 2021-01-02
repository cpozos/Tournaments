using System.Collections.Generic;

namespace Domain.NetStandard.Organizer
{
   public class Organization : IOrganizer
   {
      public ulong Id { get; }
      public string Name { get; }
      public Organization(ulong id, string name)
      {
         Id = id;
         Name = name;
      }

      public List<Person> Admins { get; set; }
      public List<Tournament> OrginizedTournaments { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

   }
}
