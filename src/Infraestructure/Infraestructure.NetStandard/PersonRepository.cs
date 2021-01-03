using System.Linq;
using System.Threading.Tasks;

using Application.NetStandard.Repositories;
using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;

using Domain.NetStandard;
using Domain.NetStandard.Logic;
using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class PersonRepository : IPersonRepository
   {
      public Task<Response<PersonDTO>> AddAsync(CreatePersonCommand query)
      {
         // Creates entity
         var person = new Person
         {
            Id = PeopleDB.Items.Count + 1,
            FirstName = query.FirstName,
            MiddleName = query.MiddleName,
            LastName = query.LastName,
         };

         // Insert it
         PeopleDB.Items.Add(person);

         // Returns DTO
         return Task.FromResult(Response.Ok(new PersonDTO
         {
            Id = person.Id,
            FirstName = query.FirstName,
            MiddleName = query.MiddleName,
            LastName = query.LastName
         })); 
      }

      public PersonDTO GetPerson(GetPersonQuery query)
      {
         var person = PeopleDB.Items.Find(p => p.Id == query.Id);
         
         return new PersonDTO
         {
            Id = person.Id,
            FirstName = person.FirstName,
            MiddleName = person.MiddleName,
            LastName = person.LastName
         };
      }


      public IEnumerable<PersonDTO> GetUsers(GetUsersQuery query)
      {
         return PeopleDB.Items.Select(p => new PersonDTO
         {
            Id = p.Id,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            LastName = p.LastName
         });
      }
   }

}
