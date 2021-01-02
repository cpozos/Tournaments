using Application.NetStandard.Common;
using Application.NetStandard.Interfaces;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Team.Commands
{
   public class CreateTeamCommand : IRequestWrapper<TeamDTO>
   {
      public int TournamentId { get; set; }
      public int PlayerId { get; set; }
      public string Name { get; set; }
   }

   public class CreateTeamCommandHandler : IHandlerWrapper<CreateTeamCommand, TeamDTO>
   {
      private readonly ITeamRepository repository;

      public CreateTeamCommandHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }
      public Task<Response<TeamDTO>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Add(request))); 

      }
   }
}
