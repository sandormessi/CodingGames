namespace TheLabyrinth;

using System;

using CodingGames.Core.Abstraction;

using TheLabyrinth.Abstraction.Data;

public class InitialGameInfoReader : IInitialGameInfoReader
{
   private readonly IInputReader inputReader;

   public InitialGameInfoReader(IInputReader inputReader)
   {
      this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
   }

   public InitialGameInfo ReadInitialGameInfo()
   {
      var input = inputReader.ReadInput();

      var portions = input.Split(' ');

      var rowCount = int.Parse(portions[0]);
      var columnCount = int.Parse(portions[1]);
      var alarmCountdown = int.Parse(portions[2]);

      var gameRules = GetGameRules();

      return new InitialGameInfo(rowCount, columnCount, alarmCountdown, gameRules);
   }

   private static GameRules GetGameRules()
   {
      GameRules gameRules = new(5);
      return gameRules;
   }
}