using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using Domain.NetStandard.Logic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TeamController : ControllerBase
   {
      private readonly IMediator _mediator;

      public TeamController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost]
      public Task<Response<TeamDTO>> Create([FromBody] CreateTeamCommand request)
      {
         return _mediator.Send(request);
      }


      [HttpGet("{id}&{tournamentId}&{playerId}")]
      public Task<Response<TeamDTO>> Get(int id, int tournamentId, int playerId)
      {
         return _mediator.Send(new GetTeamQuery
         {
            Id = id,
            TournamentId = tournamentId,
            OwnerId = playerId
         });
      }
   }
}
