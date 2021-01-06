using Application.NetStandard.Organizer;
using Domain.NetStandard.Logic;

using System.Threading.Tasks;

namespace Application.NetStandard.Repositories
{
   public interface IOrganizersRepository
   {
      Task<Response<OrganizerDto>> Add(CreateOrganizerCommand request);
   }
}
