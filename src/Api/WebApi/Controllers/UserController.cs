using Application.NetStandard;
using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard.Logic;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UserController : ControllerBase
   {
      private readonly IMediator _mediator;

      public UserController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost]
      public Task<Response<PersonDTO>> Add()
      {
         return _mediator.Send(new CreatePersonCommand
         {
            FirstName = "Carlos",
            LastName = "Pozos"
         });
      }

      [HttpGet]
      public Task<Response<PersonDTO>> Get(int id)
      {
         return _mediator.Send(new GetPersonQuery
         {
            Id = id
         });
      }
   }
}
