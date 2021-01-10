using Application.NetStandard.Player;
using Application.NetStandard.Player.Command;
using Application.NetStandard.Player.Queries;
using Application.NetStandard.Repositories;
using Domain.NetStandard;
using Domain.NetStandard.Entities.Players;
using Domain.NetStandard.Logic;
using System.Threading.Tasks;

namespace Infraestructure.NetStandard
{
   public class PlayerRepository : IPlayerRepository
   {
      public Task<Response<TeamPlayerDto>> CreateTeamPlayer(CreateTeamPlayerCommand query)
      {

         PlayerDB.Add(new SinglePlayer
         {
            FirstName = query.Name
         });

         return Task.FromResult(Response.Ok(new TeamPlayerDto
         {
            
         }));
      }

      public Person GetPlayer(GetPersonPlayerQuery query)
      {
         var player = PeopleDB.Items.Find(p => p.Id == query.Id);
         return player;
      }

      public TeamPlayerDto GetTeamPlayer(GetTeamPlayerQuery query)
      {
         throw new System.NotImplementedException();
      }
   }
}
