using Application.NetStandard.Game.Commands;
using Application.NetStandard.Game.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class GamesController : CommonController
   {
      public GamesController(IMediator mediator) : base(mediator) { }

      [HttpPost]
      public void Add(CreateGameCommand request)
      {
         _mediator.Send(request);
      }

      [HttpGet]
      public void GetGames()
      {
         _mediator.Send(new GetGamesQuery
         { });
      }

      [HttpGet("{id}")]
      public void GetGame(int id)
      {
         _mediator.Send(new GetGameQuery
         {
            Id = id
         });
      }
   }
}
