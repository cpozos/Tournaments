using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Queries
{
   public class GetTeamPlayerQuery : IRequestWrapper<TeamPlayerDto>
   {
      public int Id { get; set; }

      // Filters here??
      public int TournamentId { get; set; }
   }

   public class GetTeamPlayerQueryHandler : IHandlerWrapper<GetTeamPlayerQuery, TeamPlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public GetTeamPlayerQueryHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<TeamPlayerDto>> Handle(GetTeamPlayerQuery request, CancellationToken cancellationToken)
      {
         var team = _repository.GetTeamPlayer(request);

         return Task.FromResult(Response.Ok(team));
      }
   }
}
