using System.Collections.Generic;

namespace Domain.NetStandard.Entities.Organizers
{
   public class Organization : IOrganizer
   {
      public ulong Id { get; }
      public string Name { get; }
      public List<PersonOrganizer> Integrants { get; set; }
      public List<Tournament> OrginizedTournaments { get; set; }
      
      public Organization()
      {
         InitializeLists();
      }
      public Organization(ulong id, string name)
      {
         Id = id;
         Name = name;
         InitializeLists();
      }

      private void InitializeLists()
      {
         Integrants = new List<PersonOrganizer>();
         OrginizedTournaments = new List<Tournament>();
      }

   }
}
