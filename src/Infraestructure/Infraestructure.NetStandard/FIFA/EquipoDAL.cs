using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Infraestructure.NetStandard.FIFA
{
   public class EquipoDAL : IEquatable<EquipoDAL>, IComparable<EquipoDAL>
   {
      public string Name { get; set; }
      public string Propietario { get; set; }

      public string CompleteName { get => this.Name + " (" + this.Propietario + ")"; }

      [XmlIgnore]
      public int GolesFavor { get; set; }
      [XmlIgnore]
      public int GolesContra { get; set; }
      [XmlIgnore]
      public int DiferenciaGoles { get => GolesFavor - GolesContra; }

      [XmlIgnore]
      public int Puntos { get; set; }
      [XmlIgnore]
      public int Posicion { get; set; }
      [XmlIgnore]
      public int PartidosJugados { get; set; }
      [XmlIgnore]
      public int PartidosGanados { get; set; }
      [XmlIgnore]
      public int PartidosEmpatados { get; set; }
      [XmlIgnore]
      public int PartidosPerdidos { get; set; }

      public int CompareTo([AllowNull] EquipoDAL other)
      {
         int THIS_WINS = -1;
         int OTHER_WINS = 1;
         int TIES = 1;

         if (other.Puntos > this.Puntos)
            return OTHER_WINS;
         else if (other.Puntos < this.Puntos)
            return THIS_WINS;
         else if (other.Puntos == this.Puntos)
         {
            if (other.PartidosJugados < this.PartidosJugados)
               return OTHER_WINS;
            else if (other.PartidosJugados > this.PartidosJugados)
               return THIS_WINS;
            else
            {
               if (other.DiferenciaGoles > this.DiferenciaGoles)
                  return OTHER_WINS;
               else if (other.DiferenciaGoles < this.DiferenciaGoles)
                  return THIS_WINS;
               else if (other.DiferenciaGoles == other.DiferenciaGoles)
               {
                  if (other.GolesFavor > this.GolesFavor)
                     return OTHER_WINS;
                  else if (other.GolesFavor < this.GolesFavor)
                     return THIS_WINS;
                  else
                     return TIES;
               }
               else
                  throw new ArgumentException("Error comparable");
            }
         }
         else
            throw new ArgumentException("Error comparable");

      }
      public bool Equals([AllowNull] EquipoDAL other)
      {
         return Name == other.Name;
      }

   }

}
