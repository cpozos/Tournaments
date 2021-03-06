﻿namespace Application.NetStandard.Person
{
   public class PersonDto
   {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string FullName => $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? " " : $" {MiddleName} ")}{LastName}";
   }
}
