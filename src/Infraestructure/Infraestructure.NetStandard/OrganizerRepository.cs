using Application.NetStandard.Organizer;
using Application.NetStandard.Organizer.Commands;
using Application.NetStandard.Organizer.Queries;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Infraestructure.NetStandard
{
   public class OrganizerRepository : IOrganizersRepository
   {
      public OrganizerDto Create(CreateOrganizerCommand request)
      {
         OrganizersDB.Add(new PersonOrganizer
         {
            FirstName = request.Identifier
         });

         return new OrganizerDto
         {
            Name = request.Identifier
         };
      }

      public OrganizerDto GetOrganizer(GetOrganizerQuery query)
      {
         var org = OrganizersDB.Items.Find(i => i.Id == query.Id);

         return new OrganizerDto
         {
            Name = org.Name
         };
      }
   }
}
