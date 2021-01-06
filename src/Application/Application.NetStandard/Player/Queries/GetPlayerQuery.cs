using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Queries
{
   public class GetPlayerQuery : IRequestWrapper<PlayerDto>
   {
   }

   public class GetPlayerQueryHandler : IHandlerWrapper<GetPlayerQuery, PlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public GetPlayerQueryHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<PlayerDto>> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
