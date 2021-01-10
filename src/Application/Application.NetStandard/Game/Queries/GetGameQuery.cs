using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Game.Queries
{

   public class GetGameQuery : IRequestWrapper<GameDto>
   {
      public int Id { get; set; }
   }


   public class GetGameQueryHandler : IHandlerWrapper<GetGameQuery, GameDto>
   {
      private readonly IGameRepository _repository;

      public GetGameQueryHandler(IGameRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<GameDto>> Handle(GetGameQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(_repository.GetGame(request.Id)));
      }
   }


   public class GetGamesQuery : IRequestWrapper<IEnumerable<GameDto>>
   {
      public IEnumerable<GetGamesQuery> Queries { get; set; }
   }


   public class GetGamesQueryHandler : IHandlerWrapper<GetGamesQuery, IEnumerable<GameDto>>
   {
      private readonly IGameRepository _repository;

      public GetGamesQueryHandler(IGameRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<IEnumerable<GameDto>>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(_repository.GetAllGames()));
      }
   }
}
