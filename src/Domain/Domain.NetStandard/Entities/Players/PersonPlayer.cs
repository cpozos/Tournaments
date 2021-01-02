
namespace Domain.NetStandard.Entities.Players
{
   public class PersonPlayer : Person, IPlayer
   {
      public string Name => this.FullName;
      public Statistics Statistics { get; set; }
      public PersonPlayer() { }
      public PersonPlayer(string fullName) : base(fullName) { }
   }
}
