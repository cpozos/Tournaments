namespace Domain.NetStandard.Entities.Players
{
   public interface IPlayer
   {
      string Name { get; }
      Statistics Statistics { get; set; }
   }
}
