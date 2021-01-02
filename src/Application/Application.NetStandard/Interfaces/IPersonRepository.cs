using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Application.NetStandard.Interfaces
{
   public interface IPersonRepository
   {
      Task<Response<PersonDTO>> AddAsync(CreatePersonCommand query);

      PersonDTO GetPerson(GetPersonQuery query);
   }
}
