﻿namespace PowerOfThorEpisode1.Implementation.Game;

using CodingGames.Core.Abstraction;
using CodingGames.Core.Implementation;
using PowerOfThor.Core.Implementation.Game;
using PowerOfThor.Core.Implementation.InputReading;
using PowerOfThor.Core.Implementation.Logic;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.Data;
using PowerOfThor.Core.Abstraction.Logic;
using PowerOfThor.Core.Abstraction.InputReading;

public class PowerOfThorEpisode1Game : IPowerOfThorGame
{
    public void Execute()
    {
        IInputReader inputReader = new InputReader();
        IOutputManager outputManager = new OutputManager();
        IInitialGameDataReader initialGameDataReader = new InitialGameDataReader(inputReader);
        IGameDataPerRoundReader gameDataPerRoundReader = new GameDataPerRoundReader(inputReader);
        ICoordinateDirectionCalculator coordinateDirectionCalculator = new CoordinateDirectionCalculator();

        IGameDataReader gameDataReader = new GameDataReader(initialGameDataReader, gameDataPerRoundReader);
        IGameLogicManager gameLogicManager = new GameLogicManager(outputManager, coordinateDirectionCalculator);

        while (true)
        {
            GameData gameData = gameDataReader.ReadGameData();
            gameLogicManager.Execute(gameData);
        }
    }
}