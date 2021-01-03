using Domain.NetStandard;
using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class MockDB<T>
   {
      public static List<T> Items { get; set; } = new List<T>();
   }



   public class PeopleDB : MockDB<Person> { }
}
