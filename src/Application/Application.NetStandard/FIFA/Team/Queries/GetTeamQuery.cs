using Application.NetStandard.Common;
using Application.NetStandard.Interfaces;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Team.Queries
{
   public class GetTeamQuery : IRequestWrapper<TeamDTO>
   {
      public int OwnerId { get; set; }
      public int TournamentId { get; set; }
      public int Id { get; set; }
   }

   public class GetTeamQueryHandler : IHandlerWrapper<GetTeamQuery, TeamDTO>
   {
      private readonly ITeamRepository repository;

      public GetTeamQueryHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }
      public Task<Response<TeamDTO>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Get(request)));
      }
   }
}
