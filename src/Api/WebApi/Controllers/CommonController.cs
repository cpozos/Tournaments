using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
   public class CommonController : ControllerBase
   {
      protected readonly IMediator _mediator;
      public CommonController(IMediator mediator) => _mediator = mediator;
   }
}
