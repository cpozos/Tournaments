using Application.NetStandard.Person;
using Application.NetStandard.Person.Commands;
using Application.NetStandard.Person.Queries;
using Domain.NetStandard.Logic;

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class UsersController : CommonController
   {
      public UsersController(IMediator mediator) : base(mediator) { }

      /// <summary>
      /// It is used to add a new User
      /// </summary>
      /// <param name="request"></param>
      /// <returns></returns>
      [HttpPost]
      [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(Response<PersonDto>))]
      public Task<Response<PersonDto>> Create([FromBody] CreatePersonCommand request)
      {
         return _mediator.Send(request);
      }
      
      /// <summary>
      /// 
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      [HttpGet("{id}")]
      public Task<Response<PersonDto>> Get(int id)
      {
         return _mediator.Send(new GetPersonQuery
         {
            Id = id
         });
      }

      [HttpGet]
      public Task<Response<IEnumerable<PersonDto>>> Get()
      {
         return _mediator.Send(new GetUsersQuery());
      }
   }
}
