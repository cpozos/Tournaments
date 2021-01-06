using System.Linq;

using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Entities.Games.FIFA;

namespace Infraestructure.NetStandard.FIFA
{
   public class FIFATeamRepository : ITeamRepository
   {
      public TeamDTO Add(CreateTeamCommand request)
      {
         var team = new FIFATeam
         {
            Name = request.Name,
            OwnerId = request.PlayerId,
            TournamentId = request.TournamentId
         };

         FIFATeamDB.Add(team);

         return new TeamDTO
         {
            Id = team.Id
            , Name = team.Name
            , OwnerId = team.OwnerId
            , TournamentId = team.TournamentId
         };
      }

      public TeamDTO Get(GetTeamQuery request)
      {
         var team = FIFATeamDB.Items.FirstOrDefault(t =>
            t.TournamentId == request.TournamentId &&
            t.OwnerId == request.OwnerId &&
            t.Id == request.Id);

         return new TeamDTO
         {
            Name = team.Name,
            OwnerId = team.OwnerId,
            TournamentId = team.TournamentId
         };
      }

      public void Delete(DeleteTeamCommand request)
      {
         for (int i = 0; i < FIFATeamDB.Items.Count; i++)
         {
            if (FIFATeamDB.Items[i].Id == request.Id)
            {
               FIFATeamDB.Items.RemoveAt(i);
               break;
            }
         }
      }

      public TeamDTO Update(UpdateTeamCommand request)
      {
         throw new System.NotImplementedException();
      }
   }

  
}
