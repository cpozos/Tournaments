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
            Id = TeamDB.Teams.Count,
            Name = request.Name,
            OwnerId = request.PlayerId,
            TournamentId = request.TournamentId
         };

         TeamDB.Teams.Add(team);

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
         var team = TeamDB.Teams.FirstOrDefault(t =>
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
         for (int i = 0; i < TeamDB.Teams.Count; i++)
         {
            if (TeamDB.Teams[i].Id == request.Id)
            {
               TeamDB.Teams.RemoveAt(i);
               break;
            }
         }
      }

      public TeamDTO Update(UpdateTeamCommand request)
      {
         throw new System.NotImplementedException();
      }
   }

   public class TeamDB
   {
      public static List<FIFATeam> Teams { get; set; } = new List<FIFATeam>();
   }
}
