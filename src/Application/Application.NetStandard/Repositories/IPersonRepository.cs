using System.Collections.Generic;
using System.Threading.Tasks;

using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;

using Domain.NetStandard.Logic;

namespace Application.NetStandard.Repositories
{
   public interface IPersonRepository
   {
      Task<Response<PersonDto>> AddAsync(CreatePersonCommand query);

      PersonDto GetPerson(GetPersonQuery query);

      IEnumerable<PersonDto> GetUsers(GetUsersQuery query);
   }
}
