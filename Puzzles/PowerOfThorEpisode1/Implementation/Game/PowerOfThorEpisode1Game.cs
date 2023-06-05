namespace PowerOfThorEpisode1.Implementation.Game;

using System;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.InputReading;
using PowerOfThor.Core.Abstraction.Logic;

public class PowerOfThorEpisode1Game : IPowerOfThorGame
{
    private readonly IGameDataReader gameDataReader;

    private readonly IOutputManager outputManager;

    private readonly ICoordinateDirectionCalculator coordinateDirectionCalculator;

    public PowerOfThorEpisode1Game(IGameDataReader gameDataReader, IOutputManager outputManager, ICoordinateDirectionCalculator coordinateDirectionCalculator)
    {
        this.gameDataReader = gameDataReader ?? throw new ArgumentNullException(nameof(gameDataReader));
        this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        this.coordinateDirectionCalculator = coordinateDirectionCalculator ?? throw new ArgumentNullException(nameof(coordinateDirectionCalculator));
    }

    public void Execute()
    {
        while (true)
        {
            var gameData = gameDataReader.ReadGameData();

            var initialGameData = gameData.InitialGameData;

            var direction = coordinateDirectionCalculator.CalculateDirectionOfCoordinates(initialGameData.ThorPosition, initialGameData.LightPosition);

            outputManager.MoveThor(direction);
        }
    }
}