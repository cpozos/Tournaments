using Application.NetStandard.Common;
using Application.NetStandard.Interfaces;

using Domain.NetStandard.Logic;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Person.Queries
{
   public class GetPersonQuery : IRequestWrapper<PersonDTO>
   {
      public int Id { get; set; }
      public string Name { get; set; }
   }

   public class GetPersonQueryHandler : IHandlerWrapper<GetPersonQuery, PersonDTO>
   {
      private readonly IPersonRepository _repository;

      public GetPersonQueryHandler(IPersonRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
      {
         var person = _repository.GetPerson(request);

         if(person == null)
         {
            return Task.FromResult(Response.Fail<PersonDTO>("Error returning Person"));
         }

         if (string.IsNullOrWhiteSpace(person.FirstName))
         {
            return Task.FromResult(Response.Fail<PersonDTO>("Error returning Person"));
         }

         return Task.FromResult(Response.Ok(person));
      }
   }
}
