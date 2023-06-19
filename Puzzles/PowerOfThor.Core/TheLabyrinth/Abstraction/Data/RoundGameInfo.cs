using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth;

using CodingGames.Core.Abstraction.Data;

public class RoundGameInfo : GameDataPerRoundBase
{
   public RoundGameInfo(Position myPosition, int round, Labyrinth labyrinth)
      : base(round)
   {
      MyPosition = myPosition;
      Labyrinth = labyrinth;
   }

   public Position MyPosition { get; }

   public Labyrinth Labyrinth { get; }
}