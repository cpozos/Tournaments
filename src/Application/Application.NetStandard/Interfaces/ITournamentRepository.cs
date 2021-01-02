using Domain.NetStandard.Logic;
using System.Collections.Generic;
using Application.NetStandard.FIFA.Tournament;
using Application.NetStandard.FIFA.Match;
using Domain.NetStandard.Entities.Games.FIFA;

namespace Application.NetStandard.Interfaces
{
   public interface ITournamentRepository
   {
      AppResult Add(TournamentDTO tournament);
      FIFATournament GetTournament(int id, int organizerId);
      AppResult Save(FIFAMatch match);
      AppResult Save(List<FIFAMatch> matches);
   }
}
