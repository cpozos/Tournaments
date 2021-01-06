using Application.NetStandard.Organizer;
using Application.NetStandard.Organizer.Commands;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Infraestructure.NetStandard
{
   public class OrganizerRepository : IOrganizersRepository
   {
      public Task<Response<OrganizerDto>> Add(CreateOrganizerCommand request)
      {
         OrganizersDB.Add(new PersonOrganizer
         {
            FirstName = request.Identifier
         });

         return Task.FromResult(Response.Ok(new OrganizerDto
         {
            Name = request.Identifier
         }));
      }
   }
}
