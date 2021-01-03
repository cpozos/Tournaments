using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

namespace Application.NetStandard.Person.Queries
{
   public class GetUsersQuery : IRequestWrapper<IEnumerable<PersonDTO>>
   {
   }

   public class GetUsersQueryHandler : IHandlerWrapper<GetUsersQuery, IEnumerable<PersonDTO>>
   {
      private readonly IPersonRepository _repository;

      public GetUsersQueryHandler(IPersonRepository repository) => _repository = repository;

      public Task<Response<IEnumerable<PersonDTO>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
      {
         var person = _repository.GetUsers(request);

         if (person == null)
         {
            return Task.FromResult(Response.Fail<IEnumerable<PersonDTO>>("Error returning Person"));
         }

         return Task.FromResult(Response.Ok(person));
      }
   }
}
