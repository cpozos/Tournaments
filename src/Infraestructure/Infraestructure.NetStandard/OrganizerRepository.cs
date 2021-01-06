using Application.NetStandard.Organizer;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Infraestructure.NetStandard
{
   public class OrganizerRepository : IOrganizersRepository
   {
      public Task<Response<OrganizerDto>> Add()
      {
         OrganizersDB.Items.Add()
      }
   }
}
