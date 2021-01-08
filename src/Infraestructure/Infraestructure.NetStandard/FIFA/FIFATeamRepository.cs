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

      private void AutoCreateMatches()
      {
         foreach (var equipo in request.Teams)
         {
            var team = new FIFATeam
            {
               Name = equipo.Name
            };

            foreach (var equipo2 in request.Teams)
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

                  if (!instance.Matches.Any(par => par.Equals(partido)))
                  {
                     instance.Matches.Add(partido);
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
            OwnerId = request.PlayerId,
            TournamentId = request.TournamentId
         };

         FIFATeamDB.Add(team);

         return new FIFATeamDTO
         {
            Id = team.Id
            , Name = team.Name
            , OwnerId = team.OwnerId
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
                  OwnerId = item.PlayerId,
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
                  Id = item.Id
               });
            }

            return null;
         }
         else
         {
            return added.Select(t => new FIFATeamDTO
            {
               Id = t.Id,
               Name = t.Name,
               OwnerId = t.OwnerId,
               TournamentId = t.TournamentId
            }).ToList();
         }
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

      public FIFATeamDTO Update(UpdateTeamCommand request)
      {
         throw new System.NotImplementedException();
      }

      
   }

  
}
