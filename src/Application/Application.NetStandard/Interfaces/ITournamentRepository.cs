using Domain.NetStandard.Logic;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Organizers;
using System.Collections.Generic;

namespace Application.NetStandard.Interfaces
{
   public interface ITournamentRepository
   {
      AppResult Add(FIFATournament tournament);
      FIFATournament GetTournament(uint id, IOrganizer organizer);
      AppResult Save(FIFAMatch match);
      AppResult Save(List<FIFAMatch> matches);
   }
}
