using Domain.NetStandard.Logic;
using System.Collections.Generic;
using Application.NetStandard.FIFA.Tournament;
using Application.NetStandard.FIFA.Match;
using Domain.NetStandard.Entities.Games.FIFA;
using Application.NetStandard.FIFA.Tournament.Commands;

namespace Application.NetStandard.Interfaces
{
   public interface ITournamentRepository
   {
      TournamentDTO Add(CreateTournamentCommand tournament);
      FIFATournament GetTournament(int id, int organizerId);
      AppResult Save(FIFAMatch match);
      AppResult Save(List<FIFAMatch> matches);
   }
}
