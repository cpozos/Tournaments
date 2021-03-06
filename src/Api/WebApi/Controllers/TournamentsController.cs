﻿using Application.NetStandard.FIFA.Tournament;
using Application.NetStandard.FIFA.Tournament.Commands;
using Application.NetStandard.FIFA.Tournament.Queries;

using Domain.NetStandard.Logic;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class TournamentsController : CommonController
   {
      public TournamentsController(IMediator mediator) : base(mediator) { }

      [HttpPost]
      public Task<Response<TournamentDTO>> Create(CreateTournamentCommand request)
      {
         return _mediator.Send(request);
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
