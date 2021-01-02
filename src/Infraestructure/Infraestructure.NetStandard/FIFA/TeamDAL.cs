using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using Application.NetStandard.Interfaces;
using Domain.NetStandard.Entities.Games.FIFA;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.NetStandard.FIFA
{
   public class TeamDAL : ITeamRepository
   {
      public TeamDTO Add(CreateTeamCommand request)
      {
         var team = new FIFATeam
         {
            Id = TeamDB.Items.Count,
            Name = request.Name,
            OwnerId = request.PlayerId,
            TournamentId = request.TournamentId
         };

         TeamDB.Items.Add(team);

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
         var team = TeamDB.Items.FirstOrDefault(t =>
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
         for (int i = 0; i < TeamDB.Items.Count; i++)
         {
            if (TeamDB.Items[i].Id == request.Id)
            {
               TeamDB.Items.RemoveAt(i);
               break;
            }
         }
      }

      public TeamDTO Update(UpdateTeamCommand request)
      {
         throw new System.NotImplementedException();
      }
   }

   public class TeamDB : MockDB<FIFATeam>
   {
   }
}
