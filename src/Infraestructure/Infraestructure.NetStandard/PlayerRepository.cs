using Application.NetStandard.Player;
using Application.NetStandard.Player.Command;
using Application.NetStandard.Player.Queries;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Entities.Players;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Infraestructure.NetStandard
{
   public class PlayerRepository : IPlayerRepository
   {
      public Task<Response<PlayerDto>> Add(CreatePlayerCommand query)
      {

         PlayerDB.Add(new PersonPlayer
         {
            FirstName = query.Name
         });

         return Task.FromResult(Response.Ok(new PlayerDto
         {
            
         }));
      }

      public PlayerDto Get(GetPlayerQuery query)
      {
         throw new System.NotImplementedException();
      }
   }
}
