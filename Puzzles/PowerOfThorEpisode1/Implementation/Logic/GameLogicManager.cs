using System;
using PowerOfThor.Core.Abstraction.Data;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.Logic;
using PowerOfThorEpisode1.Abstraction.Data;

namespace PowerOfThorEpisode1.Implementation.Logic;

public class GameLogicManager : IGameLogicManager<GameData, ActualMovement>
{
    private readonly IOutputManager outputManager;

    private readonly IActualMovementCalculator actualMovementCalculator;

    public GameLogicManager(IOutputManager outputManager,
        IActualMovementCalculator actualMovementCalculator)
    {
        this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
        this.actualMovementCalculator = actualMovementCalculator ??
                                             throw new ArgumentNullException(nameof(actualMovementCalculator));
    }

    public ActualMovement Execute(GameData gameData, Coordinate2D lastPosition)
    {
        if (gameData == null)
        {
            throw new ArgumentNullException(nameof(gameData));
        }

        if (lastPosition == null)
        {
            throw new ArgumentNullException(nameof(lastPosition));
        }

        var initialGameData = gameData.InitialGameData;

        var actualMovement = actualMovementCalculator.CalculateActualMovement(lastPosition, initialGameData.LightPosition);

        outputManager.MoveThor(actualMovement.Direction);

        return actualMovement;
    }
}