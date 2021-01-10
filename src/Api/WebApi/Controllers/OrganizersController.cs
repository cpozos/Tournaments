using Application.NetStandard.Organizer;
using Application.NetStandard.Organizer.Commands;
using Application.NetStandard.Organizer.Queries;
using Domain.NetStandard.Logic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class OrganizersController : CommonController
   {
      public OrganizersController(IMediator mediator) : base(mediator) { }


      [HttpGet]
      public Task<Response<OrganizerDto>> Get([FromBody] GetOrganizerQuery request)
      {
         return _mediator.Send(request);
      }

      [HttpPost]
      public Task<Response<OrganizerDto>> Post([FromBody] CreateOrganizerCommand request)
      {
         return _mediator.Send(request);
      }
   }
}
