using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Queries
{
   public class GetPersonPlayerQuery : IRequestWrapper<SinglePlayerDto>
   {
      public int Id { get; set; }
   }

   public class GetPersonPlayerQueryHandler : IHandlerWrapper<GetPersonPlayerQuery, SinglePlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public GetPersonPlayerQueryHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<SinglePlayerDto>> Handle(GetPersonPlayerQuery request, CancellationToken cancellationToken)
      {
         var person = _repository.GetPlayer(request);
         var player = new SinglePlayerDto
         {
            Id = person.Id,
            Name = $"{person.FirstName}{person.MiddleName}"
         };

         return Task.FromResult(Response.Ok(player));
      }
   }
}
