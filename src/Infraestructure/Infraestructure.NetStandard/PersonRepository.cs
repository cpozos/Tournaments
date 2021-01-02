using Application.NetStandard.Interfaces;
using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard;
using Domain.NetStandard.Logic;

using System.Collections.Generic;
using System.Threading.Tasks;

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

         PeopleDB.Users.Add(person);

         return Task.FromResult(Response.Ok(new PersonDTO
         {
            FirstName = query.FirstName

         })); 
      }

      public Response<PersonDTO> GetPerson(GetPersonQuery query)
      {
         throw new System.NotImplementedException();
      }
   }


   public static class PeopleDB
   {
      public static List<Person> Users = new List<Person>();
   }
}
