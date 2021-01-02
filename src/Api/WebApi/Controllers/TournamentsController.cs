using Application.NetStandard.FIFA.Tournament;
using Application.NetStandard.FIFA.Tournament.Commands;
using Application.NetStandard.FIFA.Tournament.Queries;
using Application.NetStandard.Person;

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
   public class TournamentsController : ControllerBase
   {
      private readonly IMediator _mediator;

      public TournamentsController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpPost]
      public Task<Response<TournamentDTO>> Create()
      {
         return _mediator.Send(new CreateTournamentCommand
         {
            Title = "Nuevo torneo"
         });
      }


      [HttpGet("{id}&{organizerId}")]
      public Task<Response<TournamentDTO>> Get(int id, int organizerId)
      {
         return _mediator.Send(new GetTournamentQuery
         {
            Id = id
            , OrganizerId = organizerId
         });
      }
   }
}
