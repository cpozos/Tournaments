using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories.FIFA;

using Domain.NetStandard.Logic;

namespace Application.NetStandard.FIFA.Team.Queries
{
   public class GetTeamQuery : IRequestWrapper<FIFATeamDTO>
   {
      public int OwnerId { get; set; }
      public int TournamentId { get; set; }
      public int Id { get; set; }
   }

   public class GetTeamQueryHandler : IHandlerWrapper<GetTeamQuery, FIFATeamDTO>
   {
      private readonly ITeamRepository repository;

      public GetTeamQueryHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }
      public Task<Response<FIFATeamDTO>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Get(request)));
      }
   }
}
