using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using Application.NetStandard.Repositories.FIFA;

using Domain.NetStandard.Entities.Games.FIFA;

namespace Infraestructure.NetStandard.FIFA
{
   public class FIFATeamRepository : ITeamRepository
   {
      public FIFATeamDTO Get(GetTeamQuery request)
      {
         var team = FIFATeamDB.Items.FirstOrDefault(t =>
            t.TournamentId == request.TournamentId &&
            t.PlayerId == request.OwnerId);

         return new FIFATeamDTO
         {
            Name = team.Name,
            OwnerId = team.PlayerId
         };
      }

      private void AutoCreateMatches(IEnumerable<FIFATeam> teams, FIFATournament tournament)
      {
         foreach (var equipo in teams)
         {
            var team = new FIFATeam
            {
               Name = equipo.Name
            };

            foreach (var equipo2 in teams)
            {
               var team2 = new FIFATeam
               {
                  Name = equipo2.Name
               };

               if (!team.Equals(team2))
               {
                  var partido = new FIFAMatch
                  {
                     Teams = new List<FIFATeam>
                     {
                        team, 
                        team2
                     }
                  };

                  if (!tournament.Matches.Any(par => par.Equals(partido)))
                  {
                     tournament.Matches.Add(partido);
                  }
               }
            }
         }

      }

      public FIFATeamDTO Add(CreateTeamCommand request)
      {
         var team = new FIFATeam
         {
            Name = request.Name,
            PlayerId = request.PlayerId,
            TournamentId = request.TournamentId
         };

         FIFATeamDB.Add(team);

         return new FIFATeamDTO
         {
            Name = team.Name
            , OwnerId = team.PlayerId
            , TournamentId = team.TournamentId
         };
      }

      public IEnumerable<FIFATeamDTO> Add(CreateTeamsCommand request)
      {
         if(request?.Commands == null)
         {
            return null;
         }

         var added = new List<FIFATeam>();
         bool interrupted = true;

         foreach (var item in request.Commands)
         {
            var res = Add(item);
            if(res == null)
            {
               interrupted = true;
               break;
            }
            else
            {
               var team = new FIFATeam
               {
                  Name = item.Name,
                  PlayerId = item.PlayerId,
                  TournamentId = item.TournamentId
               };

               added.Add(team);
            }
         }

         if (interrupted)
         {
            foreach (var item in added)
            {
               this.Delete(new DeleteTeamCommand
               {
                  TournamentId = item.TournamentId,
                  PlayerId = item.PlayerId
               });
            }

            return null;
         }
         else
         {
            return added.Select(t => new FIFATeamDTO
            {
               Name = t.Name,
               OwnerId = t.PlayerId,
               TournamentId = t.TournamentId
            }).ToList();
         }
      }

      public void Delete(DeleteTeamCommand request)
      {
         for (int i = 0; i < FIFATeamDB.Items.Count; i++)
         {
            var team = FIFATeamDB.Items[i];
            if (team.TournamentId == request.TournamentId && team.PlayerId == request.PlayerId)
            {
               FIFATeamDB.Items.RemoveAt(i);
               break;
            }
         }
      }

      public FIFATeamDTO Update(UpdateTeamCommand request)
      {
         throw new System.NotImplementedException();
      }

      
   }

  
}
