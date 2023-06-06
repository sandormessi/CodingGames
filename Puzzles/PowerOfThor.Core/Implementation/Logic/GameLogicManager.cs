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

    public ActualMovement Execute(GameData gameData, Coordinate2D lastPosition)
    {
        if (gameData == null)
        {
            throw new ArgumentNullException(nameof(gameData));
        }

        var initialGameData = gameData.InitialGameData;

        var actualMovement = coordinateDirectionCalculator.CalculateDirectionOfCoordinates(lastPosition, initialGameData.LightPosition);

        outputManager.MoveThor(actualMovement.Direction);

        return actualMovement;
    }
}