using CodingGames.Core.Abstraction;
using CodingGames.Core.Implementation;
using PowerOfThor.Core.Abstraction.InputReading;
using PowerOfThor.Core.Abstraction.Logic;
using PowerOfThor.Core.Implementation.Game;
using PowerOfThor.Core.Implementation.Logic;
using PowerOfThorEpisode2.Abstraction.Game;

namespace PowerOfThorEpisode2.Implementation.Game;

using PowerOfThor.Core.Abstraction.Game;

public class PowerOfThorEpisode2Game : IPowerOfThorGame
{
    public void Execute()
    {
        IInputReader inputReader = new InputReader();
        IOutputManagerEpisode2 outputManager = new OutputManagerEpisode2();
        IInitialGameDataReader<> initialGameDataReader = new InitialGameDataReader(inputReader);
        IGameDataPerRoundReader gameDataPerRoundReader = new GameDataPerRoundReader(inputReader);
        IActualMovementCalculator actualMovementCalculator = new ActualMovementCalculator();

        IGameDataReader gameDataReader = new GameDataReader(initialGameDataReader, gameDataPerRoundReader);
        IGameLogicManager gameLogicManager = new GameLogicManager(outputManager, actualMovementCalculator);

        int round = 1;

        GameData gameData = gameDataReader.ReadGameData(round);

        var lastPosition = gameData.InitialGameData.ThorPosition;
        while (true)
        {
            var actualMovement = gameLogicManager.Execute(gameData, lastPosition);
            lastPosition = actualMovement.ActualPosition;
            round++;

            gameData = gameDataReader.ReadGameData(round);
        }
    }
}