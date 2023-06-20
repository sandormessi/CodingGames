namespace TheLabyrinth;

using CodingGames.Core.Abstraction.Data;

public class RoundGameInfo : GameDataPerRoundBase
{
   public RoundGameInfo(Position myPosition, int round, ExtendedLabyrinth labyrinth)
      : base(round)
   {
      MyPosition = myPosition;
      Labyrinth = labyrinth;
   }

   public Position MyPosition { get; }

   public ExtendedLabyrinth Labyrinth { get; }
}