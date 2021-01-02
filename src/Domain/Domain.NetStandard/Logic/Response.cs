namespace Domain.NetStandard.Logic
{
   public class Response<T>
   {
      public T Data { get; set; }
      public string Message { get; set; }
      public bool WithError { get; set; }

      public Response(T data, string message, bool withError)
      {
         Data = data;
         Message = message;
         WithError = withError;
      }

   }

   public static class Response
   {
      public static Response<T> Fail<T>(string message, T data = default) => 
         new Response<T>(data, message, true);

      public static Response<T> Ok<T>(T data = default, string message = null) =>
         new Response<T>(data, message, false);
   }
}
