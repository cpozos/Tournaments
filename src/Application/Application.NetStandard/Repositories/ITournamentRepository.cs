using System.Collections.Generic;

using Application.NetStandard.FIFA.Tournament;
using Application.NetStandard.FIFA.Tournament.Commands;

using Domain.NetStandard.Logic;
using Domain.NetStandard.Entities.Games.FIFA;

namespace Application.NetStandard.Repositories
{
   public interface ITournamentRepository
   {
      TournamentDTO Add(CreateTournamentCommand tournament);
      FIFATournament GetTournament(int id, int organizerId);
      AppResult Save(FIFAMatch match);
      AppResult Save(List<FIFAMatch> matches);
   }
}
