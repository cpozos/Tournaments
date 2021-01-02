using System.Collections.Generic;

namespace Domain.NetStandard
{
   public class Person
   {
      private string _fullName;
      public string FullName => _fullName ??= $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? " " : $" {MiddleName} ")}{LastName}";
      
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }

      public Person() { }
      public Person(string fullName) => _fullName = fullName;

      public List<Statistics> Statistics { get; set; }
   }
}
