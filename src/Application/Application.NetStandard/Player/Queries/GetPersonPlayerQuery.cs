using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Player.Queries
{
   public class GetPersonPlayerQuery : IRequestWrapper<PersonPlayerDto>
   {
      public int Id { get; set; }
   }

   public class GetPersonPlayerQueryHandler : IHandlerWrapper<GetPersonPlayerQuery, PersonPlayerDto>
   {
      private readonly IPlayerRepository _repository;

      public GetPersonPlayerQueryHandler(IPlayerRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<PersonPlayerDto>> Handle(GetPersonPlayerQuery request, CancellationToken cancellationToken)
      {
         var person = _repository.GetPlayer(request);
         var player = new PersonPlayerDto
         {
            Id = person.Id,
            Name = $"{person.FirstName}{person.MiddleName}"
         };

         return Task.FromResult(Response.Ok(player));
      }
   }
}
