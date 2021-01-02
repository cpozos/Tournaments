using Domain.NetStandard.Logic;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Organizer;
using System.Collections.Generic;

namespace Application.NetStandard.FIFA
{
   public interface ITournamentManager
   {
      AppResult Add(FIFATournament tournament);
      FIFATournament GetTournament(uint id, IOrganizer organizer);
      AppResult Save(FIFAMatch match);
      AppResult Save(List<FIFAMatch> matches);
   }
}
