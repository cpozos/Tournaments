namespace Domain.NetStandard.ValueObjects
{
   public class Platform
   {
      public string Name { get; private set; }
      public string Company { get; private set; }
      internal Platform(string name, string company = null)
      {
         Name = name;
         Company = company;
      }
   }

   public static class Platforms
   {
      public static Platform XboxOne = new Platform("Xbox One", "Microsoft");
      public static Platform PlayStation4 = new Platform("Play Station 4", "Sony");
      public static Platform NintendoSwitch = new Platform("Nintendo Switch", "Nintendo");
   }
}
