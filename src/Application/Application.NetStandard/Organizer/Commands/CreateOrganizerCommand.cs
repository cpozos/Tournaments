using Application.NetStandard.Common;

using Domain.NetStandard.Logic;

using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Organizer.Commands
{
   public class CreateOrganizerCommand : IRequestWrapper<OrganizerDto>
   {
   }

   public class CreateOrganizerCommandHandler : IHandlerWrapper<CreateOrganizerCommand, OrganizerDto>
   {
      public Task<Response<OrganizerDto>> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
