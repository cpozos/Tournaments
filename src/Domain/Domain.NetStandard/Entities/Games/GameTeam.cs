using Domain.NetStandard.Entities.Players;

namespace Domain.NetStandard.Entities.Games
{
   public interface IGameTeam
   {
      public int TournamentId { get; set; }
      public int PlayerId { get; set; }
      public string Name { get; set; }
   }
}
