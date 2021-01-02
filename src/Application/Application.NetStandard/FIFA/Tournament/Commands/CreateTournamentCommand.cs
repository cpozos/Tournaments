using Application.NetStandard.Common;
using Domain.NetStandard.Logic;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Tournament.Commands
{
   public class CreateTournamentCommand : IRequestWrapper<TournamentDTO>
   {
      public string Title { get; set; }
   }

   public class CreateTournamentCommandHandler : IHandlerWrapper<CreateTournamentCommand, TournamentDTO>
   {
      public Task<Response<TournamentDTO>> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
