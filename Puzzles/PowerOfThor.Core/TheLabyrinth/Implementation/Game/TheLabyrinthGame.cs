﻿namespace TheLabyrinth;

using CodingGames.Core.Abstraction;
using CodingGames.Core.Implementation;

using TheLabyrinth.Abstraction;

public class TheLabyrinthGame : ITheLabyrinthGame
{
   public void StartGame()
   {
      //IInputReader inputReader = new InputReader();
      //IOutputManager outputManager = new OutputManager();
      //IGameLogicManager gameLogicManager = new GameLogicManager(outputManager);
      //IInitialGameInfoReader initialGameInfoReader = new InitialGameInfoReader(inputReader);
      //ILabyrinthCellReader labyrinthCellReader = new LabyrinthCellReader();
      //ILabyrinthReader labyrinthReader = new LabyrinthReader(labyrinthCellReader);
      //IRoundGameInfoReader roundInfoReader = new RoundGameInfoReader(inputReader, labyrinthReader);

      //var initialGameInfo = initialGameInfoReader.ReadInitialGameInfo();

      //var round = 1;
      //while (true)
      //{
      //   var roundGameInfo = roundInfoReader.ReadRoundGameInfo(initialGameInfo, round);
      //   gameLogicManager.ExecuteLogic(initialGameInfo, roundGameInfo);

      //   round++;
      //}
   }
}