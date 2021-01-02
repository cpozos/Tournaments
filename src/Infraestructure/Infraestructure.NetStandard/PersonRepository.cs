﻿using Application.NetStandard.Interfaces;
using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard;
using Domain.NetStandard.Logic;

using System.Collections.Generic;
using System.Linq;
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

      public PersonDTO GetPerson(GetPersonQuery query)
      {
         var person = PeopleDB.Users.FirstOrDefault(p => p.Id == query.Id);

         return new PersonDTO
         {
            FirstName = person.FirstName
         };
      }
   }


   public static class PeopleDB
   {
      public static List<Person> Users = new List<Person>
      {
         new Person
         {
            Id = 1,
            FirstName = "Alberto"
         }
      };
   }
}
