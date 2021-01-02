using Application.NetStandard.Common;
using Application.NetStandard.Interfaces;
using Domain.NetStandard.Logic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.NetStandard.Person.Commands
{
   public class CreatePersonCommand : IRequestWrapper<PersonDTO> 
   {
      public string FirstName { get; set; }
      public string MiddleName { get; set; }
      public string LastName { get; set; }
   }

   public class CreatePersonCommandHandler : IHandlerWrapper<CreatePersonCommand, PersonDTO>
   {
      private readonly IPersonRepository _repository;

      public CreatePersonCommandHandler(IPersonRepository repository)
      {
         _repository = repository;
      }
      public Task<Response<PersonDTO>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
      {
         return _repository.AddAsync(request);
      }
   }
}
