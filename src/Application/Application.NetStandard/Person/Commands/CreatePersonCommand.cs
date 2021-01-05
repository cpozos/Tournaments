using System.Threading;
using System.Threading.Tasks;

using Application.NetStandard.Common;
using Application.NetStandard.Repositories;

using Domain.NetStandard.Logic;

namespace Application.NetStandard.Person.Commands
{
   public class CreatePersonCommand : IRequestWrapper<PersonDto> 
   {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
      public string Email { get; set; }
   }

   public class CreatePersonCommandHandler : IHandlerWrapper<CreatePersonCommand, PersonDto>
   {
      private readonly IPersonRepository _repository;

      public CreatePersonCommandHandler(IPersonRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<PersonDto>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
      {
         return _repository.AddAsync(request);
      }
   }
}
