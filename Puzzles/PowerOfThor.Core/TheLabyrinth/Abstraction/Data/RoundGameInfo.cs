namespace TheLabyrinth;

using System;

using CodingGames.Core.Abstraction.Data;

public class RoundGameInfo : GameDataPerRoundBase
{
   public RoundGameInfo(Position myPosition, int round, ExtendedLabyrinth labyrinth, Position startPosition)
      : base(round)
   {
      MyPosition = myPosition ?? throw new ArgumentNullException(nameof(myPosition));
      Labyrinth = labyrinth ?? throw new ArgumentNullException(nameof(labyrinth));
      StartPosition = startPosition ?? throw new ArgumentNullException(nameof(startPosition));
   }

   public Position MyPosition { get; }

   public Position StartPosition { get; }

   public ExtendedLabyrinth Labyrinth { get; }
}