using Application.NetStandard.FIFA.Team;
using Application.NetStandard.FIFA.Team.Commands;
using Application.NetStandard.FIFA.Team.Queries;
using Domain.NetStandard.Logic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TeamController : CommonController
   {
      public TeamController(IMediator mediator) : base(mediator) { }

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
