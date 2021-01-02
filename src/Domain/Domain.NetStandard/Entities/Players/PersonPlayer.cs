
namespace Domain.NetStandard.Entities.Players
{
   public class PersonPlayer : Person, IPlayer
   {
      public string Name => this.FullName;

      public PersonPlayer() { }
      public PersonPlayer(string fullName) : base(fullName) { }

      
      public TeamPlayer Team { get; set; }
      public Statistics Statistics { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
   }
}
