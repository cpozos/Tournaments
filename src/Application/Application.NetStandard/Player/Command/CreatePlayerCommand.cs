using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Command
{
   public class CreatePlayerCommand : IRequestWrapper<PlayerDto>
   {
      public string Name { get; set; }
   }

   public class CreatePlayerCommandHandler : IHandlerWrapper<CreatePlayerCommand, PlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public CreatePlayerCommandHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<PlayerDto>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
      {
         return _repository.Add(request);
      }
   }
}
