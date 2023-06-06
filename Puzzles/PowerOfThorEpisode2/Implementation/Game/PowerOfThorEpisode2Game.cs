namespace PowerOfThorEpisode2.Implementation.Game;

using PowerOfThor.Core.Abstraction.Game;

public class PowerOfThorEpisode2Game : IPowerOfThorGame
{
    public void Execute()
    {
        //IInputReader inputReader = new InputReader();
        //IOutputManager outputManager = new OutputManager();
        //IInitialGameDataReader initialGameDataReader = new InitialGameDataReader(inputReader);
        //IGameDataPerRoundReader gameDataPerRoundReader = new GameDataPerRoundReader(inputReader);
        //IActualMovementCalculator actualMovementCalculator = new ActualMovementCalculator();

        //IGameDataReader gameDataReader = new GameDataReader(initialGameDataReader, gameDataPerRoundReader);
        //IGameLogicManager gameLogicManager = new GameLogicManager(outputManager, actualMovementCalculator);

        //int round = 1;

        //GameData gameData = gameDataReader.ReadGameData(round);

        //var lastPosition = gameData.InitialGameData.ThorPosition;
        //while (true)
        //{
        //    var actualMovement = gameLogicManager.Execute(gameData, lastPosition);
        //    lastPosition = actualMovement.ActualPosition;
        //    round++;

        //    gameData = gameDataReader.ReadGameData(round);
        //}
    }
}