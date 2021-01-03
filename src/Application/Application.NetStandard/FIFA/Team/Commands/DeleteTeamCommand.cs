using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Team.Commands
{
   public class DeleteTeamCommand : IRequestWrapper<Unit>
   {
      public int Id { get; set; }
   }

   public class DeleteTeamCommandHandler : IHandlerWrapper<DeleteTeamCommand, Unit>
   {
      private readonly ITeamRepository repository;

      public DeleteTeamCommandHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }

      public Task<Response<Unit>> Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
      {
         repository.Delete(request);
         return Task.FromResult(Response.Ok<Unit>());
      }
   }
}
