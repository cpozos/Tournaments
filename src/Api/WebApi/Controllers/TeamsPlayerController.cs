using Application.NetStandard.Player;
using Application.NetStandard.Player.Command;
using Application.NetStandard.Player.Queries;
using Domain.NetStandard.Logic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TeamsPlayerController : CommonController
   {
      public TeamsPlayerController(IMediator mediator) : base(mediator) { }


      [HttpPost]
      public Task<Response<TeamPlayerDto>> Create([FromBody]CreateTeamPlayerCommand request)
      {
         return _mediator.Send(request);
      }

      [HttpPost]
      public Task<Response<TeamPlayerDto>> Get([FromBody] GetTeamPlayerQuery request)
      {
         return _mediator.Send(request);
      }
   }
}
