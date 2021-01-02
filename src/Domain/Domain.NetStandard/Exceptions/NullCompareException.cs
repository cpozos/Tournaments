using System;

namespace Domain.NetStandard.Exceptions
{
   public class NullCompareToException : Exception
   {

      public override string Message => "A null object cannot be compared.";

   }
}
