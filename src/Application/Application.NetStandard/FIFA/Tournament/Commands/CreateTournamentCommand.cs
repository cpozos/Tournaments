using Application.NetStandard.Common;
using Application.NetStandard.FIFA.Team;
using Application.NetStandard.Interfaces;
using Domain.NetStandard.Logic;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Tournament.Commands
{
   public class CreateTournamentCommand : IRequestWrapper<TournamentDTO>
   {
      public int OrganizerId { get; set; }
      public string Title { get; set; }
      public List<TeamDTO> Teams { get; set; }
   }

   public class CreateTournamentCommandHandler : IHandlerWrapper<CreateTournamentCommand, TournamentDTO>
   {
      private readonly ITournamentRepository repository;

      public CreateTournamentCommandHandler(ITournamentRepository repository)
      {
         this.repository = repository;
      }

      public Task<Response<TournamentDTO>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Add(request)));
      }
   }
}
