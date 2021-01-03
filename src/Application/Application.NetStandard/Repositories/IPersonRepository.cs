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
      Task<Response<PersonDTO>> AddAsync(CreatePersonCommand query);

      PersonDTO GetPerson(GetPersonQuery query);

      IEnumerable<PersonDTO> GetUsers(GetUsersQuery query);
   }
}
