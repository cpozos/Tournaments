using Application.NetStandard.Common;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Person.Queries
{
   public class GetPersonQuery : IRequestWrapper<PersonDTO> { }

   public class GetPersonQueryHandler : IHandlerWrapper<GetPersonQuery, PersonDTO>
   {
      public Task<Response<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
      {
         throw new System.NotImplementedException();
      }
   }
}
