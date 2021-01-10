using Application.NetStandard.Organizer;
using Application.NetStandard.Organizer.Commands;
using Application.NetStandard.Organizer.Queries;

using System.Threading.Tasks;

namespace Application.NetStandard.Repositories
{
   public interface IOrganizersRepository
   {
      OrganizerDto Create(CreateOrganizerCommand request);
      OrganizerDto GetOrganizer(GetOrganizerQuery query);
   }
}
