using System.Linq;
using System.Threading.Tasks;

using Application.NetStandard.Repositories;
using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;

using Domain.NetStandard;
using Domain.NetStandard.Logic;

namespace Infraestructure.NetStandard
{
   public class PersonRepository : IPersonRepository
   {
      public Task<Response<PersonDTO>> AddAsync(CreatePersonCommand query)
      {
         var person = new Person
         {
            FirstName = query.FirstName
         };

         PeopleDB.Items.Add(person);

         return Task.FromResult(Response.Ok(new PersonDTO
         {
            FirstName = query.FirstName

         })); 
      }

      public PersonDTO GetPerson(GetPersonQuery query)
      {
         var person = PeopleDB.Items.FirstOrDefault(p => p.Id == query.Id);

         return new PersonDTO
         {
            FirstName = person.FirstName
         };
      }
   }

}
