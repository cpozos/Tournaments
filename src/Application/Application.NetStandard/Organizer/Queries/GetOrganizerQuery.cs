using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Organizer.Queries
{
   public class GetOrganizerQuery : IRequestWrapper<OrganizerDto>
   {
   }

   public class GetOrganizerQueryHandler : IHandlerWrapper<GetOrganizerQuery, OrganizerDto>
   {
      private readonly IOrganizersRepository _repository;

      public GetOrganizerQueryHandler(IOrganizersRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<OrganizerDto>> Handle(GetOrganizerQuery request, CancellationToken cancellationToken)
      {
         var org = _repository.GetOrganizer(request);

         return Task.FromResult(Response.Ok(org));
      }
   }
}
