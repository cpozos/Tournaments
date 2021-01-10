using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Command
{
   public class CreateTeamPlayerCommand : IRequestWrapper<TeamPlayerDto>
   {
      public string Name { get; set; }
      public IEnumerable<TeamPlayerDto> Players { get; set; }
   }

   public class CreateTeamPlayerCommandHandler : IHandlerWrapper<CreateTeamPlayerCommand, TeamPlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public CreateTeamPlayerCommandHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<TeamPlayerDto>> Handle(CreateTeamPlayerCommand request, CancellationToken cancellationToken)
      {
         return _repository.CreateTeamPlayer(request);
      }
   }
}
