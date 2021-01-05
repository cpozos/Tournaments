
namespace Domain.NetStandard.Entities.Players
{
   public class PersonPlayer : Person, IPlayer
   {
      public Statistics Statistics { get; set; }
   }
}
