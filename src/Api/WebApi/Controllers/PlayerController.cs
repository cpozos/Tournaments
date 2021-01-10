using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PlayerController : CommonController
   {
      public PlayerController(IMediator mediator) : base(mediator) { }

   }
}
