using Application.NetStandard.Common;
using Application.NetStandard.Interfaces;

using Domain.NetStandard.Logic;

using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Person.Queries
{
   public class GetPersonQuery : IRequestWrapper<PersonDTO>
   {
      public int Id { get; set; }
      public string Name { get; set; }
   }

   public class GetPersonQueryHandler : IHandlerWrapper<GetPersonQuery, PersonDTO>
   {
      private readonly IPersonRepository _repository;

      public GetPersonQueryHandler(IPersonRepository repository)
      {
         _repository = repository;
      }

      public Task<Response<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
      {
         return Task.FromResult(_repository.GetPerson(request));
      }
   }
}
