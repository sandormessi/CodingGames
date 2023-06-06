namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface ICoordinateDirectionCalculator
{
    ActualMovement CalculateDirectionOfCoordinates(Coordinate2D coordinate1, Coordinate2D coordinate2);
}