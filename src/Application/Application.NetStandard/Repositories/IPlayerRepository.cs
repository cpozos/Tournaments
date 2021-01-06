using Application.NetStandard.Player;
using Application.NetStandard.Player.Command;
using Application.NetStandard.Player.Queries;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Application.NetStandard.Repositories
{
   public interface IPlayerRepository
   {
      Task<Response<PlayerDto>> Add(CreatePlayerCommand query);

      PlayerDto Get(GetPlayerQuery query);
   }
}
