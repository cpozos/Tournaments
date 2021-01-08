using Application.NetStandard.Common;
using Application.NetStandard.Repositories.FIFA;
using Domain.NetStandard.Entities.Games;
using Domain.NetStandard.Logic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Match.Commands
{
   public class SaveMatchCommand : IRequestWrapper<MatchDto>
   {
      public int TournamentId { get; set; }

      /// <summary>
      /// Teams to be faced
      /// </summary>
      public IEnumerable<IGameTeam> Teams { get; set; }

      public DateTime DateTime { get; set; }
   }

   public class SaveMatchesCommand : IRequestWrapper<IEnumerable<MatchDto>>
   {
      public IEnumerable<SaveMatchCommand> Matches { get; set; }
   }

   public class SaveMatchCommandHandler : IHandlerWrapper<SaveMatchCommand, MatchDto>
   {
      private readonly IMatchRepository _repository;

      public SaveMatchCommandHandler(IMatchRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<MatchDto>> Handle(SaveMatchCommand request, CancellationToken cancellationToken)
      {
         return _repository.Save(request);
      }
   }

   public class SaveMatchesCommandHandler : IHandlerWrapper<SaveMatchesCommand, IEnumerable<MatchDto>>
   {
      private readonly IMatchRepository _repository;

      public SaveMatchesCommandHandler(IMatchRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<IEnumerable<MatchDto>>> Handle(SaveMatchesCommand request, CancellationToken cancellationToken)
      {
         return _repository.Save(request);
      }
   }
}
