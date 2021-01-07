using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using System.Collections.Generic;

namespace Application.NetStandard.Repositories
{
   public interface ITeamRepository
   {
      FIFATeamDTO Add(CreateTeamCommand request);
      IEnumerable<FIFATeamDTO> Add(CreateTeamsCommand request);
      FIFATeamDTO Get(GetTeamQuery request);
      void Delete(DeleteTeamCommand request);
      FIFATeamDTO Update(UpdateTeamCommand request);
   }
}
