﻿using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

using Application.NetStandard.Repositories;
using Application.NetStandard.FIFA.Tournament;

using Domain.NetStandard.Logic;
using Domain.NetStandard.Entities.Organizers;
using Domain.NetStandard.Entities.Games.FIFA;
using Domain.NetStandard.Entities.Players;
using Application.NetStandard.FIFA.Tournament.Commands;

namespace Infraestructure.NetStandard.FIFA
{
   public class TournamentRepository : ITournamentRepository
   {
      private static string FilePath;
      public TournamentRepository()
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
                  Player = new SinglePlayer{
                     FirstName = equipo.Element("Propietario").Value
                  }
               }).FirstOrDefault(),
               Visitante = node.Descendants("Visitante").Select(equipo => new FIFATeam
               {
                  Name = equipo.Element("Name").Value,
                  Player = new SinglePlayer { 
                     FirstName = equipo.Element("Propietario").Value
                  }
               }).FirstOrDefault(),
            }).ToList();

         var org = new PersonOrganizer
         {
            FirstName = "Beto"
         };
         org.Id = org.FirstName.GetHashCode();

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
            , OrginizerId = org.Id
            , TimeStarted = DateTime.Now
            , TimeCreated = DateTime.Now
         };

         return tor;
      }

      public TournamentDTO Add(CreateTournamentCommand request)
      {
         // Validates entity
         if (request == null)
         {
            return null;
         }

         // Mapping
         var instance = new FIFATournament
         {
            Title = request.Title,
            TimeCreated = DateTime.Now
         };

         FIFATournDB.Add(instance);

         return new TournamentDTO
         {
            Title = instance.Title,
            Matches = instance.Matches,
         };
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
