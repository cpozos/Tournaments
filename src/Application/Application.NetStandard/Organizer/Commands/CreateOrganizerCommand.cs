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
      public string Identifier { get; set; }
      public List<IntegrantDto> Integrants { get; set; }
   }

   public class CreateOrganizerCommandHandler : IHandlerWrapper<CreateOrganizerCommand, OrganizerDto>
   {
      private readonly IOrganizersRepository _repository;

      public CreateOrganizerCommandHandler(IOrganizersRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<OrganizerDto>> Handle(CreateOrganizerCommand request, CancellationToken cancellationToken)
      {
         // Check if there are a lot of integers and the roles

         var org = _repository.Create(request);
         return Task.FromResult(Response.Ok(org));
      }
   }
}
