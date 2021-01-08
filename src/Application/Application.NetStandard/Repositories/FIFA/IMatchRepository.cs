using Application.NetStandard.FIFA.Match;
using Application.NetStandard.FIFA.Match.Commands;

using Domain.NetStandard.Logic;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.NetStandard.Repositories.FIFA
{
   public interface IMatchRepository
   {
      Task<Response<IEnumerable<MatchDto>>> Save(SaveMatchesCommand request);
      Task<Response<MatchDto>> Save(SaveMatchCommand request);
   }
}
