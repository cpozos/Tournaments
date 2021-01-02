using Domain.NetStandard.Logic;
using MediatR;

namespace Application.NetStandard.Common
{
   public interface IRequestWrapper<T> : IRequest<Response<T>> { }
   public interface IHandlerWrapper<TRequest, TResponse> : IRequestHandler<TRequest, Response<TResponse>>
      where TRequest : IRequestWrapper<TResponse>
   {

   }
}
