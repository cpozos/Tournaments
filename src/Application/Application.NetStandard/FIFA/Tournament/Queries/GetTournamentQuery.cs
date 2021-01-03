using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories;
using Domain.NetStandard.Logic;

namespace Application.NetStandard.FIFA.Tournament.Queries
{
   public class GetTournamentQuery : IRequestWrapper<TournamentDTO>
   {
      public int Id { get; set; }
      public int OrganizerId { get; set; }
   }

   public class GetTournamentQueryHandler : IHandlerWrapper<GetTournamentQuery, TournamentDTO>
   {
      private readonly ITournamentRepository repository;

      public GetTournamentQueryHandler(ITournamentRepository repository)
      {
         this.repository = repository;
      }

      public Task<Response<TournamentDTO>> Handle(GetTournamentQuery request, CancellationToken cancellationToken)
      {
         var tourn = repository.GetTournament(request.Id, request.OrganizerId);

         if (tourn == null || string.IsNullOrEmpty(tourn.Title))
         {
            return Task.FromResult(Response.Fail<TournamentDTO>("Error"));
         }


         return Task.FromResult(Response.Ok(new TournamentDTO
         {
            Teams = tourn.Teams,
            Title = tourn.Title
         }));
      }
   }
}
