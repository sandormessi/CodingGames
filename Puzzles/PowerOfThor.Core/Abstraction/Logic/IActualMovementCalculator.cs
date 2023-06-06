namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface IActualMovementCalculator
{
    ActualMovement CalculateActualMovement(Coordinate2D coordinate1, Coordinate2D coordinate2);
}