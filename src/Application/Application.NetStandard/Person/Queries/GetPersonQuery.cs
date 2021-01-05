using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

namespace Application.NetStandard.Person.Queries
{
   public class GetPersonQuery : IRequestWrapper<PersonDto>
   {
      public int Id { get; set; }
      public string Name { get; set; }
   }

   public class GetPersonQueryHandler : IHandlerWrapper<GetPersonQuery, PersonDto>
   {
      private readonly IPersonRepository _repository;

      public GetPersonQueryHandler(IPersonRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<PersonDto>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
      {
         var person = _repository.GetPerson(request);

         if(person == null)
         {
            return Task.FromResult(Response.Fail<PersonDto>("Error returning Person"));
         }

         if (string.IsNullOrWhiteSpace(person.FirstName))
         {
            return Task.FromResult(Response.Fail<PersonDto>("Error returning Person"));
         }

         return Task.FromResult(Response.Ok(person));
      }
   }
}
