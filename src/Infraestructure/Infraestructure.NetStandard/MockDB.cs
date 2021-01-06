using Domain.NetStandard;
using Domain.NetStandard.Entities.Games;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Entities.Players;
using Domain.NetStandard.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Infraestructure.NetStandard
{
   public class MockDB<T>
   {
      public static List<T> Items { get; set; } = new List<T>();

      public static void Add(T item)
      {
         var props = item.GetType().GetProperties();
         var id = props
            .FirstOrDefault(p => p.Name.Equals("id", System.StringComparison.OrdinalIgnoreCase));

         if(id != null)
         {
            id.SetValue(item, Items.Count + 1);
         }

         Items.Add(item);
      }
   }

   public class PeopleDB : MockDB<Person> { }
   public class OrganizersDB : MockDB<IOrganizer> { }
   public class PlayerDB : MockDB<IPlayer> { }
   public class GameDB : MockDB<Game>
   {
      public static new readonly List<Game> Items = new List<Game>
      {
         new Game
         {
            Id = 1,
            Name = "FIFA",
            AvailablePlatforms = new List<Platform>
            {
               Platform.PlayStation4,
               Platform.XboxOne
            }
         }
      };

   }

   // FIFA
   public class FIFATournDB : MockDB<FIFATournament> { }
   public class FIFATeamDB : MockDB<FIFATeam> { }
}
