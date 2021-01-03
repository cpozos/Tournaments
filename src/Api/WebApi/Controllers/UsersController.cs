using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard.Logic;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UsersController : CommonController
   {
      public UsersController(IMediator mediator) : base(mediator) { }

      [HttpPost]
      public Task<Response<PersonDTO>> Add([FromBody] CreatePersonCommand request)
      {
         return _mediator.Send(request);
      }
      
      [HttpGet("{id}")]
      public Task<Response<PersonDTO>> Get(int id)
      {
         return _mediator.Send(new GetPersonQuery
         {
            Id = id
         });
      }

      [HttpGet]
      public Task<Response<IEnumerable<PersonDTO>>> Get()
      {
         return _mediator.Send(new GetUsersQuery());
      }
   }
}
