using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

using Application.NetStandard.Interfaces;
using Application.NetStandard.FIFA.Match;
using Application.NetStandard.FIFA.Tournament;

using Domain.NetStandard.Logic;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Players;

namespace Infraestructure.NetStandard.FIFA
{
   public class TournamentDAL : ITournamentRepository
   {
      private static string FilePath;
      public TournamentDAL()
      {
         string path = @"PartidosGenerados.xml";
         if (!File.Exists(path))
         {
            path = @"..\PartidosGenerados.xml";
            if (!File.Exists(path))
            {
               path = @"D:\Projects\NetCore\Tournaments\src\Infraestructure\Infraestructure.NetStandard\FIFA\PartidosGenerados.xml";
            }
         }
         FilePath = path;
      }
      public FIFATournament GetTournament(int id, int organizerId)
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
                   Owner = new PersonPlayer(equipo.Element("Propietario").Value)
                }).FirstOrDefault(),
                Visitante = node.Descendants("Visitante").Select(equipo => new FIFATeam
                {
                   Name = equipo.Element("Name").Value,
                   Owner = new PersonPlayer(equipo.Element("Propietario").Value)
                }).FirstOrDefault(),
             }).ToList();

         var org = new PersonOrganizer
         {
            FirstName = "Beto"
         };

         var teams = new List<FIFATeam>();
         foreach (var partido in partidos)
         {
            if (!teams.Contains(partido.Local))
               teams.Add(partido.Local);

            if (!teams.Contains(partido.Visitante))
               teams.Add(partido.Visitante);
         }

         var tor = new FIFATournament
         {
            Title = "Torneo 1"
            , GameId = 1
            , Teams = teams
            , Matches = partidos
            , Orginizer = org
            , TimeStarted = DateTime.Now
            , TimeCreated = DateTime.Now
         };

         return tor;
      }

      public AppResult Add(TournamentDTO tournament)
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
