using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;

namespace Application.NetStandard.Repositories
{
   public interface ITeamRepository
   {
      TeamDTO Add(CreateTeamCommand request);
      void Delete(DeleteTeamCommand request);
      TeamDTO Update(UpdateTeamCommand request);

      TeamDTO Get(GetTeamQuery request);
   }
}
