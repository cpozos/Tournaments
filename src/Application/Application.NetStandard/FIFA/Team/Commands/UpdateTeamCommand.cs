﻿using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Team.Commands
{
   public class UpdateTeamCommand : IRequestWrapper<TeamDTO>
   {
      public int Id { get; set; }
      public int TournamentId { get; set; }
      public string Name { get; set; }
      public int OwnerId { get; set; }
   }

   public class UpdateTeamCommandHandler : IHandlerWrapper<UpdateTeamCommand, TeamDTO>
   {
      private readonly ITeamRepository repository;

      public UpdateTeamCommandHandler(ITeamRepository repository)
      {
         this.repository = repository;
      }

      public Task<Response<TeamDTO>> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
      {
         return Task.FromResult(Response.Ok(repository.Update(request)));
      }
   }
}
