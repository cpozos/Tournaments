using Application.NetStandard.FIFA;

using Domain.NetStandard.Organizer;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Logic;

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using System.Xml.Linq;
using System.Xml.Serialization;
using Domain.NetStandard.Entities.Players;

namespace Infraestructure.NetStandard.FIFA
{
   public class TournamentManager : ITournamentManager
   {

      private static string FilePath;
      public TournamentManager()
      {
         string path = @"PartidosGenerados.xml";
         if (!File.Exists(path))
         {
            path = @"..\PartidosGenerados.xml";
            if (!File.Exists(path))
            {
               path = @"D:\Projects\NetCore\Tournaments\src\Infraestructure\PartidosGenerados.xml";
            }
         }
         FilePath = path;
      }
      public FIFATournament GetTournament(uint id, IOrganizer organizer)
      {
         var doc = XDocument.Load(FilePath);

         var partidos = doc.Root
             .Descendants("Partido")
             .Select(node => new FIFAMatch
             {
                GolesLocal = int.Parse(node.Element("GolesLocal").Value),
                GolesVisitante = int.Parse(node.Element("GolesVisitante").Value),
                Local = node.Descendants("Local").Select(equipo => new FIFATeam
                {
                   Name = equipo.Element("Name").Value,
                   Owner = new PersonPlayer(equipo.Element("Owner").Value)
                }).FirstOrDefault(),
                Visitante = node.Descendants("Visitante").Select(equipo => new FIFATeam
                {
                   Name = equipo.Element("Name").Value,
                   Owner = new PersonPlayer(equipo.Element("Owner").Value)
                }).FirstOrDefault(),
             }).ToList();

         var org = new PersonOrganizer
         {
            FirstName = "Beto"
         };

         var tor = new FIFATournament
         {
            GameId = 1
            ,
            Matches = partidos
            ,
            Orginizer = org
            ,
            TimeStarted = DateTime.Now
            ,
            TimeCreated = DateTime.Now
         };

         return tor;
      }

      public AppResult Add(FIFATournament tournament)
      {
         var result = new AppResult
         {
            Result = false
         };

         // Validates entity
         if (tournament == null || tournament.Teams.Count == 0)
         {
            return result;
         }


         foreach (var equipo in tournament.Teams)
         {
            foreach (var equipo2 in tournament.Teams)
            {
               if (!equipo.Equals(equipo2))
               {
                  var partido = new FIFAMatch
                  {
                     Local = equipo,
                     Visitante = equipo2
                  };

                  if (!tournament.Matches.Any(par => par.Equals(partido)))
                  {
                     tournament.Matches.Add(partido);
                  }
               }
            }
         }

         if (tournament.Matches.Count < 1)
         {
            return result;
         }

         result = Save(tournament.Matches);

         return result;
      }

      public AppResult Save(FIFAMatch match) => Save(new List<FIFAMatch> { match });

      public AppResult Save(List<FIFAMatch> partidos)
      {
         var result = new AppResult
         {
            Result = true
         };

         try
         {
            //create the serialiser to create the xml
            XmlSerializer serialiser = new XmlSerializer(typeof(List<FIFAMatch>));

            // Create the TextWriter for the serialiser to use
            TextWriter filestream = new StreamWriter(FilePath);


            //write to the file
            serialiser.Serialize(filestream, partidos);

            // Close the file
            filestream.Close();
         }
         catch (Exception e)
         {
            result.Result = false;
            result.Exception = e;
         }

         return result;
      }

   }
}
