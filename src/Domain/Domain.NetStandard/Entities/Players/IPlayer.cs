﻿namespace Domain.NetStandard.Entities.Players
{
   public interface IPlayer
   {
      int Id { get; set; }
      Statistics Statistics { get; set; }
   }
}
