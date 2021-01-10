using Application.NetStandard.Common;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Game.Commands
{
   public class CreateGameCommand : IRequestWrapper<GameDto>
   {

   }

   public class CreateGameCommandHandler : IHandlerWrapper<CreateGameCommand, GameDto>
   {
      public Task<Response<GameDto>> Handle(CreateGameCommand request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
