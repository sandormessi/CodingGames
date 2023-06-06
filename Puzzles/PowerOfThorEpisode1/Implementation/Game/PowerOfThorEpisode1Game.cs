using PowerOfThor.Core.Abstraction.InputReading;
using PowerOfThorEpisode1.Abstraction.Data;
using PowerOfThorEpisode1.Implementation.InputReading;
using PowerOfThorEpisode1.Implementation.Logic;

namespace PowerOfThorEpisode1.Implementation.Game;

using CodingGames.Core.Abstraction;
using CodingGames.Core.Implementation;
using PowerOfThor.Core.Implementation.Game;
using PowerOfThor.Core.Implementation.Logic;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.Data;
using PowerOfThor.Core.Abstraction.Logic;

public class PowerOfThorEpisode1Game : IPowerOfThorGame
{
    public void Execute()
    {
        IInputReader inputReader = new InputReader();
        IOutputManager outputManager = new OutputManager();
        IInitialGameDataReader<InitialGameData> initialGameDataReader = new InitialGameDataReader(inputReader);
        IGameDataPerRoundReader<GameDataPerRound> gameDataPerRoundReader = new GameDataPerRoundReader(inputReader);
        IActualMovementCalculator actualMovementCalculator = new ActualMovementCalculator();

        IGameDataReader<GameData> gameDataReader = new GameDataReader(initialGameDataReader, gameDataPerRoundReader);
        IGameLogicManager<GameData, ActualMovement> gameLogicManager = new GameLogicManager(outputManager, actualMovementCalculator);

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