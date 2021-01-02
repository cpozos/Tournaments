using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.FIFA.Tournament
{
   public class CreateTournamentCommand : IRequest<Unit> { }

   public class CreateTournamentCommandHandler : IRequestHandler<CreateTournamentCommand, Unit>
   {
      public Task<Unit> Handle(CreateTournamentCommand request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
