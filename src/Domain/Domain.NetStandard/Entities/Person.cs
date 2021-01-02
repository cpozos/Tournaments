namespace Domain.NetStandard
{
   public class Person
   {
      private string _fullName;
      public uint Id { get; set; }
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string FullName => _fullName ??= $"{FirstName}{(string.IsNullOrWhiteSpace(MiddleName) ? " " : $" {MiddleName} ")}{LastName}";

      public Person() { }
      public Person(string fullName) => _fullName = fullName;
   }
}
