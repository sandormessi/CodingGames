namespace PowerOfThor.Core.Implementation.Logic;

using System;
using Abstraction.Data;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.Logic;

public class GameLogicManager : IGameLogicManager
{
    private readonly IOutputManager outputManager;

    private readonly ICoordinateDirectionCalculator coordinateDirectionCalculator;

    public GameLogicManager(IOutputManager outputManager,
        ICoordinateDirectionCalculator coordinateDirectionCalculator)
    {
        this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        this.coordinateDirectionCalculator = coordinateDirectionCalculator ??
                                             throw new ArgumentNullException(nameof(coordinateDirectionCalculator));
    }

    public void Execute(GameData gameData)
    {
        if (gameData == null)
        {
            throw new ArgumentNullException(nameof(gameData));
        }

        var initialGameData = gameData.InitialGameData;

        var direction =
            coordinateDirectionCalculator.CalculateDirectionOfCoordinates(initialGameData.ThorPosition,
                initialGameData.LightPosition);

        outputManager.MoveThor(direction);
    }
}