using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class MockDB<T>
   {
      public static List<T> Items { get; set; } = new List<T>();
   }
}
