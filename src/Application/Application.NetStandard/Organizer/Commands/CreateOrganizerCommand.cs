using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Organizer.Commands
{
   public class CreateOrganizerCommand : IRequestWrapper<OrganizerDto>
   {
      public List<Integrant> Integrants { get; set; }
      public string Identifier { get; set; }

      public class Integrant
      {
         public string Name { get; set; }
         public List<int> RolIds { get; set; }
      }
   }

   public class CreateOrganizerCommandHandler : IHandlerWrapper<CreateOrganizerCommand, OrganizerDto>
   {
      private readonly IOrganizersRepository _repository;

      public Task<Response<OrganizerDto>> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
      {
         // Check if there are a lot of integers and the roles
         return _repository.Add(request);
      }
   }
}
