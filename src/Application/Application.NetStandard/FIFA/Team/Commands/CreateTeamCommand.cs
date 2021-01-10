using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories.FIFA;
using Domain.NetStandard.Logic;

namespace Application.NetStandard.FIFA.Team.Commands
{
   public class CreateTeamCommand : IRequestWrapper<FIFATeamDTO>
   {
      public int TournamentId { get; set; }
      public int PlayerId { get; set; }
      public string Name { get; set; }
   }

   public class CreateTeamCommandHandler : IHandlerWrapper<CreateTeamCommand, FIFATeamDTO>
   {
      private readonly ITeamRepository repository;

      public CreateTeamCommandHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }
      public Task<Response<FIFATeamDTO>> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Add(request))); 

      }
   }

   public class CreateTeamsCommand : IRequestWrapper<IEnumerable<FIFATeamDTO>>
   {
      public IEnumerable<CreateTeamCommand> Commands { get; set; }
   }

   public class CreateTeamsCommandHandler : IHandlerWrapper<CreateTeamsCommand, IEnumerable<FIFATeamDTO>>
   {
      public Task<Response<IEnumerable<FIFATeamDTO>>> Handle(CreateTeamsCommand request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
