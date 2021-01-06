using Domain.NetStandard;
using Domain.NetStandard.Entities.Games;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Enums;
using System.Collections.Generic;

namespace Infraestructure.NetStandard
{
   public class MockDB<T>
   {
      public static List<T> Items { get; set; } = new List<T>();
   }

   public class PeopleDB : MockDB<Person> { }
   public class OrganizersDB : MockDB<IOrganizer> { }
   public class TournDB : MockDB<FIFATournament> { }

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
}
